// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.DefaultEntryPoint
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using SIMS.Entities;
using SIMS.Processes;
using SIMS.Processes.ThirdParty;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SIMS.UserInterfaces
{
  public class DefaultEntryPoint
  {
    private static string autoStartMenu = "Focus|Home Page";
    private static bool multiInstance = false;
    private static Splash splashScreen = (Splash) null;
    private const string singleInstanceMutexName = "SuperStar-1E44201B-3100-4355-ACED-CF53E4C22194";

    [STAThread]
    private static void Main(string[] commandLineArguments)
    {
      Application.EnableVisualStyles();
      Application.ThreadException += new ThreadExceptionEventHandler(DefaultEntryPoint.catchAll);
      try
      {
        if (!DefaultEntryPoint.processCommandLine(commandLineArguments))
          return;
        bool createdNew;
        using (new Mutex(true, "SuperStar-1E44201B-3100-4355-ACED-CF53E4C22194", out createdNew))
        {
          if (!createdNew && !DefaultEntryPoint.multiInstance)
          {
            DefaultEntryPoint.BringExistingToTop();
          }
          else
          {
            if (!DefaultEntryPoint.ConnectINIAvailable())
            {
              int num = (int) new LocateSIMS().ShowDialog();
            }
            if (!DefaultEntryPoint.ConnectINIAvailable())
              return;
            using (LoginUI loginUi = new LoginUI())
            {
              Cache.InitializeDatabaseInfo();
              if (DialogResult.OK != loginUi.ShowDialog(new ParameterlessDelegate(DefaultEntryPoint.showSplashScreen), new ParameterlessDelegate(DefaultEntryPoint.hideSplashScreen)))
                return;
              Application.Run((System.Windows.Forms.Form) new MainContainer(new ParameterlessDelegate(DefaultEntryPoint.hideSplashScreen), DefaultEntryPoint.autoStartMenu));
            }
          }
        }
      }
      catch (System.Exception ex)
      {
        DefaultEntryPoint.catchAll((object) null, new ThreadExceptionEventArgs(ex));
      }
      finally
      {
        Provider.CleanUpTemporaryFiles();
      }
    }

    private static void catchAll(object sender, ThreadExceptionEventArgs e)
    {
      MainException mainException = new MainException(e.Exception);
      mainException.Visible = false;
      mainException.TopMost = true;
      int num = (int) mainException.ShowDialog();
      Application.Exit();
    }

    private static void showSplashScreen()
    {
      DefaultEntryPoint.splashScreen = new Splash();
      DefaultEntryPoint.splashScreen.Opacity = 1.0;
      DefaultEntryPoint.splashScreen.Show();
      DefaultEntryPoint.splashScreen.BringToFront();
      DefaultEntryPoint.splashScreen.Refresh();
    }

    private static bool processCommandLine(string[] commandLine)
    {
      foreach (string str in commandLine)
      {
        if (str == "/?" || str.ToUpper() == "/HELP")
        {
          DefaultEntryPoint.writeCommandLineHelp();
          return false;
        }
        if (str.StartsWith("/START:"))
          DefaultEntryPoint.autoStartMenu = str.Substring(7).Replace("\"", "");
        if (str.StartsWith("/CONNECT:"))
          Cache.ConnectINIDirectoryLocation = str.Substring(9).Replace("\"", "");
        if (str.StartsWith("/MULTIINSTANCE"))
          DefaultEntryPoint.multiInstance = true;
      }
      return true;
    }

    private static void writeCommandLineHelp()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("/?, /HELP - give help on parameters and do not start the application\n");
      stringBuilder.Append("/START:XXXX - automatically start the named menu item. Surround the menu item name in quotes. Example : Pulsar.exe /START:\"Focus|Student|Student Details\" \n");
      stringBuilder.Append("/CONNECT:XXXX - alternative location to find Connect.INI. Surround the path in quotes. Do not include the file name Connect.INI. Example : Pulsar.exe /CONNECT:\"c:\\sims.net\\\"\n");
      stringBuilder.Append("/NOVERSIONCHECK - prevents version checking on startup.");
      int num = (int) MessageBox.Show(stringBuilder.ToString(), Cache.ApplicationName + " Parameters");
    }

    private static void hideSplashScreen()
    {
      if (DefaultEntryPoint.splashScreen != null)
        DefaultEntryPoint.splashScreen.Close();
      DefaultEntryPoint.splashScreen = (Splash) null;
    }

    private static void BringExistingToTop()
    {
      Process currentProcess = Process.GetCurrentProcess();
      foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
      {
        if (process.Id != currentProcess.Id)
        {
          if (DefaultEntryPoint.IsIconic(process.MainWindowHandle))
          {
            DefaultEntryPoint.OpenIcon(process.MainWindowHandle);
            break;
          }
          DefaultEntryPoint.SetForegroundWindow(process.MainWindowHandle);
          break;
        }
      }
    }

    private static bool ConnectINIAvailable()
    {
      try
      {
        return new FileInfo(Database.ConnectionINIFile).Exists;
      }
      catch (System.Exception ex)
      {
        return false;
      }
    }

    [DllImport("USER32.DLL")]
    private static extern bool IsIconic(IntPtr hWnd);

    [DllImport("USER32.DLL")]
    private static extern bool OpenIcon(IntPtr hWnd);

    [DllImport("USER32.DLL")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);
  }
}
