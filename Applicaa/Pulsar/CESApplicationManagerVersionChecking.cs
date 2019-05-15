// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.CESApplicationManagerVersionChecking
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using SIMS.Utilities;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SIMS.UserInterfaces
{
  internal class CESApplicationManagerVersionChecking
  {
    public double CurrentVersion = 7.05;
    public double AvailableUpgrade = 7.05;
    private const string upgradeLocationRoot = "SIMS.net.Codebase";
    private const string upgradeVersionDirectory = "Version.";

    public bool NewApplicationVersionAvailable()
    {
      INIFile iniFile = new INIFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CESApplicationManager.INI"));
      string str = iniFile.Read("Defaults", "OtherLocationPath");
      if (iniFile.Read("Defaults", "UpgradeSource") == CESApplicationManagerVersionChecking.enumUpgradeFrom.Other.ToString() && Directory.Exists(str))
      {
        string validatedLocation = this.searchNominatedSiteForUpgrades(str);
        if (validatedLocation == null)
          return false;
        double[] availableUpgrades = this.upgradeDirectories("Version.", validatedLocation);
        CESApplicationManagerVersionChecking.Manifest manifest = new CESApplicationManagerVersionChecking.Manifest();
        manifest.Location = Path.GetDirectoryName(Application.ExecutablePath);
        manifest.Read();
        this.CurrentVersion = manifest.SoftwareVersion;
        double[] numArray = this.ApplicableUpgrades(availableUpgrades);
        if (numArray.Length > 0)
        {
          this.AvailableUpgrade = numArray[numArray.Length - 1];
          return true;
        }
      }
      return false;
    }

    public CESApplicationManagerVersionChecking.enumDatabaseState GetDatabaseVersionState()
    {
      using (CESApplicationManagerVersionChecking.SIMSDatabaseConnection databaseConnection = new CESApplicationManagerVersionChecking.SIMSDatabaseConnection(Path.GetDirectoryName(Application.ExecutablePath)))
      {
        CESApplicationManagerVersionChecking.Manifest manifest = new CESApplicationManagerVersionChecking.Manifest();
        manifest.Location = Path.GetDirectoryName(Application.ExecutablePath);
        manifest.Read();
        if (databaseConnection.CurrentSchemaVersion == 0.0 || manifest.ManifestFileIsMissing)
          return CESApplicationManagerVersionChecking.enumDatabaseState.ApplicationConsistentWithRequired;
        if (manifest.RequiredSchemaVersion < databaseConnection.CurrentSchemaVersion)
          return CESApplicationManagerVersionChecking.enumDatabaseState.ApplicationLowerThanRequired;
        if (manifest.RequiredSchemaVersion > databaseConnection.CurrentSchemaVersion)
          return CESApplicationManagerVersionChecking.enumDatabaseState.ApplicationHigherThanRequired;
      }
      return CESApplicationManagerVersionChecking.enumDatabaseState.ApplicationConsistentWithRequired;
    }

    private double[] ApplicableUpgrades(double[] availableUpgrades)
    {
      ArrayList arrayList = new ArrayList();
      foreach (double availableUpgrade in availableUpgrades)
      {
        if (availableUpgrade > this.CurrentVersion)
          arrayList.Add((object) availableUpgrade);
      }
      return (double[]) arrayList.ToArray(typeof (double));
    }

    private double[] upgradeDirectories(string directorySpec, string validatedLocation)
    {
      ArrayList arrayList = new ArrayList();
      foreach (string path in this.availableUpgradesUNC(validatedLocation))
      {
        string fileName = Path.GetFileName(path);
        if (fileName.ToUpper().StartsWith(directorySpec.ToUpper()))
        {
          double num = this.directoryVersionNumber(fileName, directorySpec);
          if (num > 0.0)
            arrayList.Add((object) num);
        }
      }
      double[] numArray = new double[arrayList.Count];
      for (int index = 0; index < arrayList.Count; ++index)
        numArray[index] = (double) arrayList[index];
      return numArray;
    }

    private double directoryVersionNumber(string directory, string directoryPrefix)
    {
      int num = directory.ToUpper().IndexOf(directoryPrefix.ToUpper());
      return double.Parse(directory.Substring(num + directoryPrefix.Length));
    }

    private string searchNominatedSiteForUpgrades(string proposedLocation)
    {
      foreach (string allDirectory in this.getAllDirectories(proposedLocation))
      {
        if (allDirectory.ToUpper().EndsWith("SIMS.net.Codebase".ToUpper()))
          return allDirectory;
      }
      return (string) null;
    }

    private StringCollection availableUpgradesUNC(string upgradeLocation)
    {
      StringCollection stringCollection = new StringCollection();
      stringCollection.AddRange(Directory.GetDirectories(upgradeLocation));
      return stringCollection;
    }

    private string[] getAllDirectories(string path)
    {
      string[] directories;
      try
      {
        directories = Directory.GetDirectories(path);
      }
      catch (IOException ex)
      {
        return new string[0];
      }
      ArrayList arrayList = new ArrayList((ICollection) directories);
      int index = 0;
      for (int length = directories.Length; index < length; ++index)
      {
        string[] allDirectories = this.getAllDirectories(arrayList[index].ToString());
        arrayList.InsertRange(0, (ICollection) allDirectories);
      }
      return (string[]) arrayList.ToArray(typeof (string));
    }

    public enum enumDatabaseState
    {
      ApplicationConsistentWithRequired,
      ApplicationHigherThanRequired,
      ApplicationLowerThanRequired,
    }

    private enum enumUpgradeFrom
    {
      CD,
      Internet,
      Other,
    }

    private class Manifest
    {
      public static string FileName = "CESManifest.XML";
      public string Location = "";
      public double SoftwareVersion = 7.05;
      public double RequiredSchemaVersion = 60.009;
      public bool ManifestFileIsMissing = true;
      private string temporaryLocation = "";

      public string FullyQualifiedFileName
      {
        get
        {
          if (this.temporaryLocation.Length == 0)
            return Path.Combine(this.Location, CESApplicationManagerVersionChecking.Manifest.FileName);
          return Path.Combine(this.temporaryLocation, CESApplicationManagerVersionChecking.Manifest.FileName);
        }
      }

      public void Read()
      {
        XmlDocument xmlDocument = new XmlDocument();
        if (File.Exists(this.FullyQualifiedFileName))
        {
          xmlDocument.Load(this.FullyQualifiedFileName);
          XmlNodeList elementsByTagName1 = xmlDocument.GetElementsByTagName("RequiredSchemaVersion");
          if (elementsByTagName1 != null)
            this.RequiredSchemaVersion = double.Parse(elementsByTagName1[0].InnerText);
          XmlNodeList elementsByTagName2 = xmlDocument.GetElementsByTagName("Version");
          if (elementsByTagName2 != null)
            this.SoftwareVersion = double.Parse(elementsByTagName2[0].InnerText);
          this.ManifestFileIsMissing = false;
        }
        else
          this.ManifestFileIsMissing = true;
      }
    }

    private class SIMSDatabaseConnection : IDisposable
    {
      private static byte[] simsinit = new byte[40]
      {
        (byte) 97,
        (byte) 71,
        (byte) 100,
        (byte) 107,
        (byte) 90,
        (byte) 110,
        (byte) 108,
        (byte) 112,
        (byte) 100,
        (byte) 50,
        (byte) 49,
        (byte) 107,
        (byte) 98,
        (byte) 109,
        (byte) 74,
        (byte) 50,
        (byte) 89,
        (byte) 88,
        (byte) 78,
        (byte) 121,
        (byte) 100,
        (byte) 50,
        (byte) 108,
        (byte) 113,
        (byte) 99,
        (byte) 87,
        (byte) 53,
        (byte) 104,
        (byte) 99,
        (byte) 72,
        (byte) 70,
        (byte) 111,
        (byte) 90,
        (byte) 87,
        (byte) 108,
        (byte) 117,
        (byte) 89,
        (byte) 51,
        (byte) 104,
        (byte) 53
      };
      private static byte[] simsadm = (byte[]) null;
      public string SIMSPath = "";
      private double currentSchemaVersion;
      private CESApplicationManagerVersionChecking.SIMSDatabaseConnection.DatabaseInfo databaseInfo;
      private int databaseSignature;
      private SqlConnection sqlConnection;

      internal SIMSDatabaseConnection(string simsPath)
      {
        this.SIMSPath = simsPath;
      }

      public double CurrentSchemaVersion
      {
        get
        {
          if (this.currentSchemaVersion == 0.0)
            this.currentSchemaVersion = this.GetDatabaseSchemaVersion();
          return this.currentSchemaVersion;
        }
      }

      private double GetDatabaseSchemaVersion()
      {
        SqlConnection connection = this.GetConnection();
        if (connection == null)
          return 0.0;
        try
        {
          string s = this.FillDataSet(new SqlCommand("\r\n\r\n\t\t\t\t\tselect schema_version \r\n\t\t\t\t\tfrom sims.db_version_info\r\n\t\t\t\t\twhere\r\n\t\t\t\t\tschema_date = \r\n\t\t\t\t\t\t(\r\n\t\t\t\t\t\tselect max(schema_date)                  \r\n\t\t\t\t\t\tfrom sims.db_version_info\r\n\t\t\t\t\t\t) \r\n\r\n\t\t\t\t\t\t\t"), connection).Tables[0].Rows[0][0].ToString();
          if (s.StartsWith("3."))
            s = s.Substring(2);
          return double.Parse(s);
        }
        catch
        {
          return 0.0;
        }
      }

      private SqlConnection GetConnection()
      {
        try
        {
          if (this.databaseInfo.serverName == null)
            this.databaseInfo = this.DatabaseInformation();
          if (this.databaseInfo.databaseURL.Length > 0)
            return (SqlConnection) null;
          if (this.sqlConnection == null)
          {
            this.sqlConnection = new SqlConnection("Data Source=" + this.databaseInfo.serverName + ";UID=simsinit;PWD=" + this.base64Decode(new ASCIIEncoding().GetString(CESApplicationManagerVersionChecking.SIMSDatabaseConnection.simsinit)) + ";Initial Catalog=" + this.databaseInfo.databaseName);
            this.sqlConnection.Open();
          }
          return this.sqlConnection;
        }
        catch
        {
        }
        return (SqlConnection) null;
      }

      public SqlConnection GetConnection(string username, string password)
      {
        try
        {
          if (this.databaseInfo.serverName == null)
            this.databaseInfo = this.DatabaseInformation();
          if (this.databaseInfo.databaseURL.Length > 0)
            return (SqlConnection) null;
          if (this.sqlConnection == null)
          {
            this.sqlConnection = new SqlConnection("Data Source=" + this.databaseInfo.serverName + ";UID=simsinit;PWD=" + this.base64Decode(new ASCIIEncoding().GetString(CESApplicationManagerVersionChecking.SIMSDatabaseConnection.simsinit)) + ";Initial Catalog=" + this.databaseInfo.databaseName);
            this.sqlConnection.Open();
          }
          if (this.sqlConnection != null)
          {
            if (this.sqlConnection.ConnectionString.IndexOf("UID=simsadm") == -1)
            {
              this.databaseSignature = this.getDatabaseSignature(username, password);
              if (this.databaseSignature <= 0)
                return (SqlConnection) null;
              this.getSimsConnectionInfo(this.databaseSignature);
              this.sqlConnection.Close();
              this.sqlConnection = (SqlConnection) null;
              this.sqlConnection = new SqlConnection("Data Source=" + this.databaseInfo.serverName + ";UID=simsadm;PWD=" + this.base64Decode(new ASCIIEncoding().GetString(CESApplicationManagerVersionChecking.SIMSDatabaseConnection.simsadm)) + ";Initial Catalog=" + this.databaseInfo.databaseName);
              this.sqlConnection.Open();
            }
          }
          else
          {
            this.sqlConnection.Close();
            this.sqlConnection = (SqlConnection) null;
          }
          return this.sqlConnection;
        }
        catch
        {
        }
        return (SqlConnection) null;
      }

      private int getDatabaseSignature(string username, string password)
      {
        string str = "[" + Environment.MachineName + "]";
        try
        {
          SqlCommand command = this.sqlConnection.CreateCommand();
          command.CommandText = "sims.db_pic_signature_init";
          command.CommandType = CommandType.StoredProcedure;
          command.Parameters.AddWithValue("@module_code", (object) "ATW");
          command.Parameters.AddWithValue("@workstation", (object) str);
          command.Parameters.AddWithValue("@login_name", (object) username);
          command.Parameters.AddWithValue("@login_password", (object) this.encryptPassword(password));
          command.Parameters.AddWithValue("@mode", (object) "F");
          return (int) command.ExecuteScalar();
        }
        catch (SqlException ex)
        {
          if (ex.Number != 50000)
            throw ex;
          return 0;
        }
      }

      private void getSimsConnectionInfo(int dbSignature)
      {
        if (dbSignature <= 0)
          return;
        SqlCommand command = this.sqlConnection.CreateCommand();
        command.CommandText = "sims.db_pic_get_user_info";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Signature", (object) dbSignature);
        DataTable table = this.FillDataSet(command, this.sqlConnection).Tables[0];
        if (table.Rows.Count <= 0 || table.Columns.Count != 3)
          return;
        CESApplicationManagerVersionChecking.SIMSDatabaseConnection.simsadm = new ASCIIEncoding().GetBytes(table.Rows[0][1].ToString());
      }

      ~SIMSDatabaseConnection()
      {
        this.terminateConnection();
      }

      public void ExecuteSQL(string sqlString)
      {
        this.FillDataSet(sqlString, this.GetConnection());
      }

      private DataSet FillDataSet(SqlCommand command, SqlConnection databaseConnection)
      {
        DataSet dataSet = new DataSet();
        command.Connection = this.GetConnection();
        new SqlDataAdapter(command).Fill(dataSet);
        return dataSet;
      }

      private DataSet FillDataSet(string command, SqlConnection databaseConnection)
      {
        DataSet dataSet = new DataSet();
        new SqlDataAdapter(command, databaseConnection).Fill(dataSet);
        return dataSet;
      }

      private CESApplicationManagerVersionChecking.SIMSDatabaseConnection.DatabaseInfo DatabaseInformation()
      {
        CESApplicationManagerVersionChecking.SIMSDatabaseConnection.DatabaseInfo info = new CESApplicationManagerVersionChecking.SIMSDatabaseConnection.DatabaseInfo();
        if (this.SIMSPath == "")
          this.SIMSPath = Path.GetDirectoryName(Application.ExecutablePath);
        this.getCreationInfo(Path.Combine(this.SIMSPath, "connect.ini"), 0, ref info);
        return info;
      }

      private void getCreationInfo(
        string path,
        int recursionDepth,
        ref CESApplicationManagerVersionChecking.SIMSDatabaseConnection.DatabaseInfo info)
      {
        if (recursionDepth > 10)
          throw new Exception("Connect.ini error. Circular reference or too many redirections");
        INIFile iniFile = new INIFile(path);
        info.serverName = iniFile.Read("SIMSConnection", "ServerName");
        info.databaseName = iniFile.Read("SIMSConnection", "DatabaseName");
        switch (iniFile.Read("SIMSConnection", "ServerType").ToString().ToUpper())
        {
          case "SIMSSQL":
            info.databaseType = CESApplicationManagerVersionChecking.SIMSDatabaseConnection.SupportedDatabaseTypes.SIMSSqlServer;
            break;
          case "SQLSERVER":
            info.databaseType = CESApplicationManagerVersionChecking.SIMSDatabaseConnection.SupportedDatabaseTypes.SqlServer;
            break;
          case "ORACLE":
            info.databaseType = CESApplicationManagerVersionChecking.SIMSDatabaseConnection.SupportedDatabaseTypes.Oracle;
            break;
          case "OLEDB":
            info.databaseType = CESApplicationManagerVersionChecking.SIMSDatabaseConnection.SupportedDatabaseTypes.OleDB;
            break;
        }
        if ("" == info.serverName || "" == info.databaseName)
        {
          string str = iniFile.Read("SIMSConnection", "Redirect");
          if ("" == str.ToString())
            throw new Exception(string.Format("Incorrect {0} file", (object) path));
          this.getCreationInfo(Path.Combine(str.ToString(), "Connect.ini"), recursionDepth + 1, ref info);
        }
        info.databaseURL = iniFile.Read("SIMSConnection", "DatabaseURL");
        info.databaseServerVersion = iniFile.Read("SIMSConnection", "DatabaseServerVersion");
      }

      private string encryptPassword(string Pwd)
      {
        Pwd = CESApplicationManagerVersionChecking.SIMSDatabaseConnection.padPassword(Pwd);
        return this.base64Encode(Pwd);
      }

      private static string padPassword(string password)
      {
        int[] numArray = new int[7]
        {
          204,
          170,
          153,
          238,
          221,
          187,
          (int) byte.MaxValue
        };
        string upper = password.ToUpper();
        if (upper.Length > 18)
          password.Remove(18, password.Length - 18);
        else if (upper.Length < 18)
        {
          int num = 1;
          while (upper.Length < 18)
          {
            upper += (string) (object) (char) numArray[num % numArray.Length];
            ++num;
          }
        }
        char[] charArray = upper.ToCharArray();
        for (int index = 1; index <= 18; ++index)
        {
          charArray[index - 1] = index % 2 == 0 ? (char) ((int) byte.MaxValue & ((int) charArray[index - 1] << 5 | (int) charArray[index - 1] >> 3)) : (char) ((int) byte.MaxValue & ((int) charArray[index - 1] << 3 | (int) charArray[index - 1] >> 5));
          switch (index % 5)
          {
            case 0:
              charArray[index - 1] ^= '\x0001';
              break;
            case 1:
              charArray[index - 1] ^= '#';
              break;
            case 2:
              charArray[index - 1] ^= 'E';
              break;
            case 3:
              charArray[index - 1] ^= 'g';
              break;
            case 4:
              charArray[index - 1] ^= '\x0089';
              break;
          }
        }
        return new string(charArray);
      }

      private string base64Decode(string s)
      {
        byte[] numArray = Convert.FromBase64String(s);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Length = numArray.Length;
        for (int index = 0; index < numArray.Length; ++index)
          stringBuilder[index] = (char) numArray[index];
        return stringBuilder.ToString();
      }

      private string base64Encode(string s)
      {
        byte[] inArray = new byte[s.Length];
        for (int index = 0; index < s.Length; ++index)
          inArray[index] = (byte) s[index];
        return Convert.ToBase64String(inArray);
      }

      public void Dispose()
      {
        this.terminateConnection();
        GC.SuppressFinalize((object) this);
      }

      private void terminateConnection()
      {
        if (this.sqlConnection == null)
          return;
        if (this.sqlConnection.State != ConnectionState.Open)
          return;
        try
        {
          this.sqlConnection.Close();
        }
        catch (InvalidOperationException ex)
        {
        }
      }

      private enum SupportedDatabaseTypes
      {
        Unknown,
        SIMSSqlServer,
        SqlServer,
        Oracle,
        OleDB,
      }

      private struct DatabaseInfo
      {
        public string serverName;
        public string databaseName;
        public CESApplicationManagerVersionChecking.SIMSDatabaseConnection.SupportedDatabaseTypes databaseType;
        public string databaseURL;
        public string databaseServerVersion;
      }
    }
  }
}
