// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.HelpContextIds
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

namespace SIMS.UserInterfaces
{
  public class HelpContextIds
  {
    public static int GetHelpContextId(object callingClass)
    {
      if (callingClass.GetType() == typeof (EmployeeDetailUI))
        return 5000;
      if (callingClass.GetType() == typeof (EmployeeBrowseUI))
        return 1002;
      if (callingClass.GetType() == typeof (ContactDetails))
        return 5101;
      if (callingClass.GetType() == typeof (BrowseContacts))
        return 1001;
      return callingClass.GetType() == typeof (NextOfKinDialog) ? 5001 : 0;
    }
  }
}
