// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.SystemManager.MainContainerHelper
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using SIMS.Entities;
using System;
using System.Windows.Forms;

namespace SIMS.UserInterfaces.SystemManager
{
  public static class MainContainerHelper
  {
    private static RecordMenuUsageDelegate _recordMenuUsage;
    private static DisplayComponentDelegate _displayComponent;
    private static UIMenuItem _menuItemSystemManager;
    private static UIMenuItem _menuItemManageUsers;
    private static UIMenuItem _menuItemManageGroups;
    private static UIMenuItem _menuItemExportGroups;
    private static UIMenuItem _menuItemImportGroups;
    private static UIMenuItem _menuItemSettings;
    private static UIMenuItem _menuItemUserAccessLog;

    private static void MenuItemManageUsersClick(object sender, EventArgs e)
    {
      MainContainerHelper._recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new UserContainer());
    }

    private static void MenuItemManageGroupsClick(object sender, EventArgs e)
    {
      MainContainerHelper._recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new GroupContainer());
    }

    private static void MenuItemExportGroupsClick(object sender, EventArgs e)
    {
      MainContainerHelper._recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new GroupExport());
    }

    private static void MenuItemImportGroupsClick(object sender, EventArgs e)
    {
      MainContainerHelper._recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new GroupImport());
    }

    private static void MenuItemEditSettingsClick(object sender, EventArgs e)
    {
      MainContainerHelper._recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new Settings());
    }

    private static void MenuItemUserAccessLogClick(object sender, EventArgs e)
    {
      MainContainerHelper._recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new UserAccessLogBrowser());
    }

    public static void InitialiseMenus(
      MainMenu mainMenu,
      RecordMenuUsageDelegate recordMenuUsage,
      DisplayComponentDelegate displayComponent)
    {
      if (mainMenu == null)
        throw new ArgumentNullException(nameof (mainMenu));
      if (recordMenuUsage == null)
        throw new ArgumentNullException(nameof (recordMenuUsage));
      if (displayComponent == null)
        throw new ArgumentNullException(nameof (displayComponent));
      MainContainerHelper._recordMenuUsage = recordMenuUsage;
      MainContainerHelper._displayComponent = displayComponent;
      UIMenuItem menuItem1 = mainMenu.MenuItems["focusMenu"] as UIMenuItem;
      MenuItem menuItem2 = mainMenu.MenuItems["toolsMenu"];
      MainContainerHelper._menuItemSystemManager = new UIMenuItem();
      MainContainerHelper._menuItemManageUsers = new UIMenuItem();
      MainContainerHelper._menuItemManageGroups = new UIMenuItem();
      MainContainerHelper._menuItemExportGroups = new UIMenuItem();
      MainContainerHelper._menuItemImportGroups = new UIMenuItem();
      MainContainerHelper._menuItemSettings = new UIMenuItem();
      MainContainerHelper._menuItemUserAccessLog = new UIMenuItem();
      menuItem1.MenuItems.Add(14, (MenuItem) MainContainerHelper._menuItemSystemManager);
      MainContainerHelper._menuItemSystemManager.Text = "Sys&tem Manager";
      MainContainerHelper._menuItemSystemManager.ImageList = StandardIcons.Get();
      MainContainerHelper._menuItemSystemManager.ImageIndex = 21;
      MainContainerHelper._menuItemManageUsers.Text = "Manage &Users";
      MainContainerHelper._menuItemManageGroups.Text = "Manage &Groups";
      MainContainerHelper._menuItemExportGroups.Text = "&Export Groups";
      MainContainerHelper._menuItemImportGroups.Text = "&Import Groups";
      MainContainerHelper._menuItemSettings.Text = "&Settings";
      MainContainerHelper._menuItemUserAccessLog.Text = "User Access &Log";
      MainContainerHelper._menuItemManageUsers.Click += new EventHandler(MainContainerHelper.MenuItemManageUsersClick);
      MainContainerHelper._menuItemManageGroups.Click += new EventHandler(MainContainerHelper.MenuItemManageGroupsClick);
      MainContainerHelper._menuItemExportGroups.Click += new EventHandler(MainContainerHelper.MenuItemExportGroupsClick);
      MainContainerHelper._menuItemImportGroups.Click += new EventHandler(MainContainerHelper.MenuItemImportGroupsClick);
      MainContainerHelper._menuItemSettings.Click += new EventHandler(MainContainerHelper.MenuItemEditSettingsClick);
      MainContainerHelper._menuItemUserAccessLog.Click += new EventHandler(MainContainerHelper.MenuItemUserAccessLogClick);
      MainContainerHelper._menuItemSystemManager.MenuItems.AddRange(new MenuItem[6]
      {
        (MenuItem) MainContainerHelper._menuItemManageUsers,
        (MenuItem) MainContainerHelper._menuItemManageGroups,
        (MenuItem) MainContainerHelper._menuItemExportGroups,
        (MenuItem) MainContainerHelper._menuItemImportGroups,
        (MenuItem) MainContainerHelper._menuItemUserAccessLog,
        (MenuItem) MainContainerHelper._menuItemSettings
      });
    }

    private static void DisplayComponent(Control component)
    {
      Control control = MainContainerHelper._displayComponent((IIDEntity) null, component);
    }

    public static void RebuildMenus()
    {
      Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper._menuItemManageGroups, GroupContainer.HostedProcessNames());
      Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper._menuItemManageUsers, UserContainer.HostedProcessNames());
      Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper._menuItemUserAccessLog, UserAccessLogBrowser.HostedProcessNames());
      Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper._menuItemSettings, Settings.HostedProcessNames());
      Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper._menuItemExportGroups, GroupExport.HostedProcessNames());
      Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper._menuItemImportGroups, GroupImport.HostedProcessNames());
    }
  }
}
