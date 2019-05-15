// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.Discover.MainContainerHelper
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using SIMS.Entities;
using SIMS.Processes.Discover;
using System;
using System.Windows.Forms;

namespace SIMS.UserInterfaces.Discover
{
  public static class MainContainerHelper
  {
    private static RecordMenuUsageDelegate recordMenuUsage;
    private static DisplayComponentDelegate displayComponent;
    private static DisplayNewComponentDelegate displayNewComponent;
    private static ComponentExists componentExists;
    private static UIMenuItem menuItemDiscoverGroups;
    private static UIMenuItem menuItemASMSeparator5;
    private static UIMenuItem menuItemDiscoverLaunch;
    private static UIMenuItem menuItemASMSeparator8a;
    private static UIMenuItem menuItemDiscoverSetup;
    private static UIMenuItem menuItemDiscoverAspects;

    public static void InitialiseMenus(
      MainMenu mainMenu,
      RecordMenuUsageDelegate recordMenuUsage,
      DisplayComponentDelegate displayComponent,
      DisplayNewComponentDelegate displayNewComponent,
      ComponentExists componentExists)
    {
      if (mainMenu == null)
        throw new ArgumentNullException(nameof (mainMenu));
      if (recordMenuUsage == null)
        throw new ArgumentNullException(nameof (recordMenuUsage));
      if (displayComponent == null)
        throw new ArgumentNullException(nameof (displayComponent));
      if (displayNewComponent == null)
        throw new ArgumentNullException(nameof (displayNewComponent));
      if (componentExists == null)
        throw new ArgumentNullException(nameof (componentExists));
      MainContainerHelper.recordMenuUsage = recordMenuUsage;
      MainContainerHelper.displayComponent = displayComponent;
      MainContainerHelper.displayNewComponent = displayNewComponent;
      MainContainerHelper.componentExists = componentExists;
      UIMenuItem menuItem1 = mainMenu.MenuItems["focusMenu"] as UIMenuItem;
      UIMenuItem menuItem2 = menuItem1.MenuItems["menuItemGroups"] as UIMenuItem;
      UIMenuItem menuItem3 = menuItem2.MenuItems["menuItemAssManUDG"] as UIMenuItem;
      UIMenuItem menuItem4 = menuItem1.MenuItems["menuItemFocusASM"] as UIMenuItem;
      UIMenuItem menuItem5 = menuItem4.MenuItems["menuItemPATrackingGrid"] as UIMenuItem;
      UIMenuItem menuItem6 = ((mainMenu.MenuItems["toolsMenu"] as UIMenuItem).MenuItems["menuItemToolsPATools"] as UIMenuItem).MenuItems["menuItemToolsPAAnalysis"] as UIMenuItem;
      UIMenuItem menuItem7 = menuItem6.MenuItems["menuItemPAToolsDefineSettings"] as UIMenuItem;
      MainContainerHelper.menuItemDiscoverGroups = new UIMenuItem();
      MainContainerHelper.menuItemASMSeparator5 = new UIMenuItem();
      MainContainerHelper.menuItemDiscoverLaunch = new UIMenuItem();
      MainContainerHelper.menuItemASMSeparator8a = new UIMenuItem();
      MainContainerHelper.menuItemDiscoverSetup = new UIMenuItem();
      MainContainerHelper.menuItemDiscoverAspects = new UIMenuItem();
      menuItem2.MenuItems.Add(menuItem3.Index + 1, (MenuItem) MainContainerHelper.menuItemDiscoverGroups);
      menuItem4.MenuItems.Add(menuItem5.Index + 1, (MenuItem) MainContainerHelper.menuItemASMSeparator5);
      menuItem4.MenuItems.Add(menuItem5.Index + 2, (MenuItem) MainContainerHelper.menuItemDiscoverLaunch);
      menuItem6.MenuItems.Add(menuItem7.Index + 1, (MenuItem) MainContainerHelper.menuItemASMSeparator8a);
      menuItem6.MenuItems.Add(menuItem7.Index + 2, (MenuItem) MainContainerHelper.menuItemDiscoverSetup);
      menuItem6.MenuItems.Add(menuItem7.Index + 3, (MenuItem) MainContainerHelper.menuItemDiscoverAspects);
      MainContainerHelper.menuItemDiscoverGroups.ImageIndex = -1;
      MainContainerHelper.menuItemDiscoverGroups.ImageList = (ImageList) null;
      MainContainerHelper.menuItemDiscoverGroups.NoEdit = false;
      MainContainerHelper.menuItemDiscoverGroups.NoUIModify = false;
      MainContainerHelper.menuItemDiscoverGroups.OriginalText = "";
      MainContainerHelper.menuItemDiscoverGroups.OwnerDraw = true;
      MainContainerHelper.menuItemDiscoverGroups.Text = "&Discover Groups";
      MainContainerHelper.menuItemDiscoverGroups.Click += new EventHandler(MainContainerHelper.menuItemDiscoverGroups_Click);
      MainContainerHelper.menuItemASMSeparator5.ImageIndex = -1;
      MainContainerHelper.menuItemASMSeparator5.ImageList = (ImageList) null;
      MainContainerHelper.menuItemASMSeparator5.NoEdit = false;
      MainContainerHelper.menuItemASMSeparator5.NoUIModify = false;
      MainContainerHelper.menuItemASMSeparator5.OriginalText = "";
      MainContainerHelper.menuItemASMSeparator5.OwnerDraw = true;
      MainContainerHelper.menuItemASMSeparator5.Text = "-";
      MainContainerHelper.menuItemDiscoverLaunch.ImageIndex = 160;
      MainContainerHelper.menuItemDiscoverLaunch.ImageList = StandardIcons.Get();
      MainContainerHelper.menuItemDiscoverLaunch.NoEdit = false;
      MainContainerHelper.menuItemDiscoverLaunch.NoUIModify = false;
      MainContainerHelper.menuItemDiscoverLaunch.OriginalText = "";
      MainContainerHelper.menuItemDiscoverLaunch.OwnerDraw = true;
      MainContainerHelper.menuItemDiscoverLaunch.Text = "&Discover";
      MainContainerHelper.menuItemDiscoverLaunch.Click += new EventHandler(MainContainerHelper.menuItemDiscoverLaunch_Click);
      MainContainerHelper.menuItemASMSeparator8a.ImageIndex = -1;
      MainContainerHelper.menuItemASMSeparator8a.ImageList = (ImageList) null;
      MainContainerHelper.menuItemASMSeparator8a.NoEdit = false;
      MainContainerHelper.menuItemASMSeparator8a.NoUIModify = false;
      MainContainerHelper.menuItemASMSeparator8a.OriginalText = "";
      MainContainerHelper.menuItemASMSeparator8a.OwnerDraw = true;
      MainContainerHelper.menuItemASMSeparator8a.Text = "-";
      MainContainerHelper.menuItemDiscoverSetup.ImageIndex = -1;
      MainContainerHelper.menuItemDiscoverSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemDiscoverSetup.NoEdit = false;
      MainContainerHelper.menuItemDiscoverSetup.NoUIModify = false;
      MainContainerHelper.menuItemDiscoverSetup.OriginalText = "";
      MainContainerHelper.menuItemDiscoverSetup.OwnerDraw = true;
      MainContainerHelper.menuItemDiscoverSetup.Text = "&Discover Setup";
      MainContainerHelper.menuItemDiscoverSetup.Click += new EventHandler(MainContainerHelper.menuItemDiscoverSetup_Click);
      MainContainerHelper.menuItemDiscoverAspects.ImageIndex = -1;
      MainContainerHelper.menuItemDiscoverAspects.ImageList = (ImageList) null;
      MainContainerHelper.menuItemDiscoverAspects.NoEdit = false;
      MainContainerHelper.menuItemDiscoverAspects.NoUIModify = false;
      MainContainerHelper.menuItemDiscoverAspects.OriginalText = "";
      MainContainerHelper.menuItemDiscoverAspects.OwnerDraw = true;
      MainContainerHelper.menuItemDiscoverAspects.Text = "D&iscover Aspects";
      MainContainerHelper.menuItemDiscoverAspects.Click += new EventHandler(MainContainerHelper.menuItemDiscoverAspects_Click);
    }

    public static void RebuildMenus()
    {
      string[] processNames1 = new string[2]
      {
        "Discover.BrowseGroup",
        "Discover.EditGroup"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemDiscoverGroups, processNames1);
      MainContainerHelper.menuItemDiscoverLaunch.Visible = LaunchApplication.TargetExists();
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemDiscoverSetup, "Discover.EditSetup");
      string[] processNames2 = new string[2]
      {
        "Discover.BrowseAspect",
        "Discover.EditAspect"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemDiscoverAspects, processNames2);
    }

    public static void SetupContextMenus()
    {
    }

    public static void BuildFocusBar(Launcher2 launcher)
    {
      if (!LaunchApplication.TargetExists())
        return;
      launcher.AddFocusBarSeparator();
      launcher.AddFocusBarItem(MainContainerHelper.menuItemDiscoverLaunch);
    }

    private static Control DisplayComponent(Control component)
    {
      return MainContainerHelper.displayComponent((IIDEntity) null, component);
    }

    private static Control DisplayComponentWithInterfaces(Control component)
    {
      return MainContainerHelper.componentExists(component as ISameAs, component.GetType().ToString()) ?? MainContainerHelper.displayNewComponent((IIDEntity) null, component);
    }

    private static void menuItemDiscoverGroups_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new MaintainGroup());
    }

    private static void menuItemDiscoverLaunch_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      LaunchApplication.Execute();
    }

    private static void menuItemDiscoverSetup_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new EditSetup());
    }

    private static void menuItemDiscoverAspects_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new MaintainAspect());
    }
  }
}
