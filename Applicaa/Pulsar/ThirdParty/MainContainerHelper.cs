// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.ThirdParty.MainContainerHelper
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using SIMS.Entities;
using System;
using System.Windows.Forms;

namespace SIMS.UserInterfaces.ThirdParty
{
  public static class MainContainerHelper
  {
    private static RecordMenuUsageDelegate recordMenuUsage;
    private static DisplayComponentDelegate displayComponent;
    private static UIMenuItem menuItemThirdPartyPlugins;
    private static UIMenuItem menuItemServiceEncryptionManager;

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
      MainContainerHelper.recordMenuUsage = recordMenuUsage;
      MainContainerHelper.displayComponent = displayComponent;
      UIMenuItem menuItem1 = (mainMenu.MenuItems["toolsMenu"] as UIMenuItem).MenuItems["menuItemSetups"] as UIMenuItem;
      UIMenuItem menuItem2 = menuItem1.MenuItems["menuItemEmergencyAlertSetup"] as UIMenuItem;
      MainContainerHelper.menuItemThirdPartyPlugins = new UIMenuItem();
      menuItem1.MenuItems.Add(menuItem2.Index + 1, (MenuItem) MainContainerHelper.menuItemThirdPartyPlugins);
      MainContainerHelper.menuItemServiceEncryptionManager = new UIMenuItem();
      menuItem1.MenuItems.Add(MainContainerHelper.menuItemThirdPartyPlugins.Index + 1, (MenuItem) MainContainerHelper.menuItemServiceEncryptionManager);
      MainContainerHelper.menuItemThirdPartyPlugins.BaseName = "menuItemThirdPartyPlugins";
      MainContainerHelper.menuItemThirdPartyPlugins.ImageIndex = -1;
      MainContainerHelper.menuItemThirdPartyPlugins.ImageList = (ImageList) null;
      MainContainerHelper.menuItemThirdPartyPlugins.NoEdit = false;
      MainContainerHelper.menuItemThirdPartyPlugins.NoUIModify = false;
      MainContainerHelper.menuItemThirdPartyPlugins.OriginalText = "";
      MainContainerHelper.menuItemThirdPartyPlugins.OwnerDraw = true;
      MainContainerHelper.menuItemThirdPartyPlugins.Text = "Partner Plu&gins";
      MainContainerHelper.menuItemThirdPartyPlugins.Click += new EventHandler(MainContainerHelper.menuItemThirdPartyPlugins_Click);
      MainContainerHelper.menuItemServiceEncryptionManager.BaseName = "menuItemServiceEncryptionManager";
      MainContainerHelper.menuItemServiceEncryptionManager.ImageIndex = -1;
      MainContainerHelper.menuItemServiceEncryptionManager.ImageList = (ImageList) null;
      MainContainerHelper.menuItemServiceEncryptionManager.NoEdit = false;
      MainContainerHelper.menuItemServiceEncryptionManager.NoUIModify = false;
      MainContainerHelper.menuItemServiceEncryptionManager.OriginalText = "";
      MainContainerHelper.menuItemServiceEncryptionManager.OwnerDraw = true;
      MainContainerHelper.menuItemServiceEncryptionManager.Text = "&Service Encryption Manager";
      MainContainerHelper.menuItemServiceEncryptionManager.Click += new EventHandler(MainContainerHelper.MenuItemServiceEncryptionManagerClick);
    }

    public static void RebuildMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemThirdPartyPlugins, "ThirdParty.EditPluginSetup");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemServiceEncryptionManager, "ServiceEncryptionManagerViewAll");
    }

    public static void SetupContextMenus()
    {
    }

    private static Control DisplayComponent(Control component)
    {
      return MainContainerHelper.displayComponent((IIDEntity) null, component);
    }

    private static void menuItemThirdPartyPlugins_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new EditPluginSetup());
    }

    private static void MenuItemServiceEncryptionManagerClick(object sender, EventArgs e)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new ServiceEncryptionManager());
    }
  }
}
