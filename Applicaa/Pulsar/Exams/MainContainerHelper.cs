// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.Exams.MainContainerHelper
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using SIMS.Entities;
using SIMS.Processes.Exams;
using System;
using System.Windows.Forms;

namespace SIMS.UserInterfaces.Exams
{
  public class MainContainerHelper
  {
    public static readonly UIMenuItem ExamsMainMenu = new UIMenuItem();
    private static readonly UIMenuItem EditPerformanceIndicators = new UIMenuItem();
    private static readonly UIMenuItem SetUpPerformanceIndicators = new UIMenuItem();
    private static readonly UIMenuItem EntryReport = new UIMenuItem();
    private static readonly UIMenuItem ImportQualificationData = new UIMenuItem();
    private static readonly UIMenuItem PerformanceIndicator = new UIMenuItem();
    private static readonly UIMenuItem PerformanceIndicatorReports = new UIMenuItem();
    private static readonly UIMenuItem Separator1 = new UIMenuItem();
    private static readonly UIMenuItem Separator2 = new UIMenuItem();
    private static readonly UIMenuItem ExternalResultsManualEntry = new UIMenuItem();
    private static readonly UIMenuItem Separator3 = new UIMenuItem();
    private static readonly UIMenuItem QANCorrelationReport = new UIMenuItem();
    private static readonly UIMenuItem QANCorrelationReportNoUserQN = new UIMenuItem();
    private static readonly UIMenuItem QANCorrelationReportWithUserQN = new UIMenuItem();
    private static RecordMenuUsageDelegate recordMenuUsageDelegate;
    private static DisplayComponentDelegate displayComponentDelegate;

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
      MainContainerHelper.recordMenuUsageDelegate = recordMenuUsage;
      MainContainerHelper.displayComponentDelegate = displayComponent;
      UIMenuItem menuItem1 = mainMenu.MenuItems["toolsMenu"] as UIMenuItem;
      if (menuItem1 == null)
        throw new ArgumentException("toolsMenu is null.");
      UIMenuItem menuItem2 = menuItem1.MenuItems["menuItemToolsPATools"] as UIMenuItem;
      if (menuItem2 == null)
        throw new ArgumentException("paToolsMenu is null.");
      menuItem1.MenuItems.Add(menuItem2.Index + 1, (MenuItem) MainContainerHelper.ExamsMainMenu);
      MainContainerHelper.ExamsMainMenu.BaseName = "ExamsMainMenu";
      MainContainerHelper.ExamsMainMenu.OwnerDraw = true;
      MainContainerHelper.ExamsMainMenu.Text = "&Examinations";
      MenuItem[] items1 = new MenuItem[11]
      {
        (MenuItem) MainContainerHelper.ImportQualificationData,
        (MenuItem) MainContainerHelper.PerformanceIndicator,
        (MenuItem) MainContainerHelper.EditPerformanceIndicators,
        (MenuItem) MainContainerHelper.PerformanceIndicatorReports,
        (MenuItem) MainContainerHelper.SetUpPerformanceIndicators,
        (MenuItem) MainContainerHelper.Separator1,
        (MenuItem) MainContainerHelper.EntryReport,
        (MenuItem) MainContainerHelper.Separator2,
        (MenuItem) MainContainerHelper.ExternalResultsManualEntry,
        (MenuItem) MainContainerHelper.Separator3,
        (MenuItem) MainContainerHelper.QANCorrelationReport
      };
      int count = MainContainerHelper.ExamsMainMenu.MenuItems.Count;
      MenuItem[] items2 = new MenuItem[count];
      if (count > 0)
      {
        MainContainerHelper.ExamsMainMenu.MenuItems.CopyTo((Array) items2, 0);
        MainContainerHelper.ExamsMainMenu.MenuItems.Clear();
      }
      MainContainerHelper.ExamsMainMenu.MenuItems.AddRange(items1);
      MainContainerHelper.ExamsMainMenu.MenuItems.AddRange(items2);
      MainContainerHelper.configureExamsSubMenu();
    }

    private static void configureExamsSubMenu()
    {
      MainContainerHelper.EditPerformanceIndicators.BaseName = "EditPerformanceIndicators";
      MainContainerHelper.EditPerformanceIndicators.OwnerDraw = true;
      MainContainerHelper.EditPerformanceIndicators.Click += new EventHandler(MainContainerHelper.MenuItemExamsPiValuesEdit_Click);
      MainContainerHelper.EditPerformanceIndicators.Text = "&Edit PI Data";
      MainContainerHelper.SetUpPerformanceIndicators.BaseName = "SetUpPerformanceIndicators";
      MainContainerHelper.SetUpPerformanceIndicators.OwnerDraw = true;
      MainContainerHelper.SetUpPerformanceIndicators.Text = "PI &Setup";
      MainContainerHelper.SetUpPerformanceIndicators.Click += new EventHandler(MainContainerHelper.MenuItemExamsSetup_Click);
      MainContainerHelper.EntryReport.BaseName = "EntryReport";
      MainContainerHelper.EntryReport.OwnerDraw = true;
      MainContainerHelper.EntryReport.Text = "E&ntry Report";
      MainContainerHelper.EntryReport.Click += new EventHandler(MainContainerHelper.MenuItemExamsEntryReport_Click);
      MainContainerHelper.ImportQualificationData.BaseName = "ImportQualificationData";
      MainContainerHelper.ImportQualificationData.OwnerDraw = true;
      MainContainerHelper.ImportQualificationData.Text = "&Import Qualification Data";
      MainContainerHelper.ImportQualificationData.Click += new EventHandler(MainContainerHelper.MenuItemUpdateCatalogueFromQWS_Click);
      MainContainerHelper.ImportQualificationData.Index = 0;
      MainContainerHelper.PerformanceIndicator.BaseName = "PerformanceIndicator";
      MainContainerHelper.PerformanceIndicator.OwnerDraw = true;
      MainContainerHelper.PerformanceIndicator.Text = "&Manage Performance Indicator";
      MainContainerHelper.PerformanceIndicator.Click += new EventHandler(MainContainerHelper.MenuItemUpdatePerformanceIndicator_Click);
      MainContainerHelper.PerformanceIndicatorReports.BaseName = "PerformanceIndicatorReports";
      MainContainerHelper.PerformanceIndicatorReports.OwnerDraw = true;
      MainContainerHelper.PerformanceIndicatorReports.Text = "PI &Reports";
      MainContainerHelper.PerformanceIndicatorReports.Click += new EventHandler(MainContainerHelper.MenuItemExamsReportsPerformanceTables_Click);
      MainContainerHelper.Separator1.OwnerDraw = true;
      MainContainerHelper.Separator1.Text = "-";
      MainContainerHelper.Separator2.OwnerDraw = true;
      MainContainerHelper.Separator2.Text = "-";
      MainContainerHelper.ExternalResultsManualEntry.BaseName = "ExternalResultsManualEntry";
      MainContainerHelper.ExternalResultsManualEntry.OwnerDraw = true;
      MainContainerHelper.ExternalResultsManualEntry.Text = "E&xternal Results Manual Entry";
      MainContainerHelper.ExternalResultsManualEntry.Click += new EventHandler(MainContainerHelper.ExternalResultsManualEntry_Click);
      MainContainerHelper.Separator3.OwnerDraw = true;
      MainContainerHelper.Separator3.Text = "-";
      MainContainerHelper.QANCorrelationReport.BaseName = "QANCorrelationReport";
      MainContainerHelper.QANCorrelationReport.OwnerDraw = true;
      MainContainerHelper.QANCorrelationReport.Text = "&QN Correlation Report";
      if (MainContainerHelper.canHaveUserDefinedQN())
      {
        MainContainerHelper.QANCorrelationReportNoUserQN.BaseName = "QANCorrelationReportNoUserQN";
        MainContainerHelper.QANCorrelationReportNoUserQN.OwnerDraw = true;
        MainContainerHelper.QANCorrelationReportNoUserQN.Text = "&Without User Defined QNs";
        MainContainerHelper.QANCorrelationReportNoUserQN.Click += new EventHandler(MainContainerHelper.QANCorrelationReport_Click);
        MainContainerHelper.QANCorrelationReportWithUserQN.BaseName = "QANCorrelationReportWithUserQN";
        MainContainerHelper.QANCorrelationReportWithUserQN.OwnerDraw = true;
        MainContainerHelper.QANCorrelationReportWithUserQN.Text = "With &User Defined QNs";
        MainContainerHelper.QANCorrelationReportWithUserQN.Click += new EventHandler(MainContainerHelper.QANCorrelationReportWithUserQN_Click);
        MainContainerHelper.QANCorrelationReport.MenuItems.AddRange(new MenuItem[2]
        {
          (MenuItem) MainContainerHelper.QANCorrelationReportWithUserQN,
          (MenuItem) MainContainerHelper.QANCorrelationReportNoUserQN
        });
      }
      else
        MainContainerHelper.QANCorrelationReport.Click += new EventHandler(MainContainerHelper.QANCorrelationReport_Click);
    }

    private static bool canHaveUserDefinedQN()
    {
      return SystemConfigurationCache.LocaleCode == "ENG";
    }

    public static void SetExamsMenuVisibility(bool isVisible)
    {
      MainContainerHelper.ExamsMainMenu.Visible = isVisible;
    }

    public static void RebuildMenu()
    {
      bool flag1 = Cache.ProcessAvailable("PLASCBrowser") && Cache.ProcessAvailable("PLASCDetails");
      bool flag2 = Cache.ProcessVisible("LaunchExamsOrganiser") && Cache.ProcessVisible("UpdateQANCatalogue");
      bool flag3 = Cache.ProcessVisible("ManageCourse") && Cache.ProcessVisible("ManageCourseClassification");
      bool flag4 = Cache.ProcessVisible("Exams.ManagePISetup");
      bool flag5 = Cache.ProcessVisible("Exams.ViewPISetup");
      bool flag6 = flag4 || flag5 || Cache.ProcessVisible("Exams.ExamReports");
      bool flag7 = Cache.ProcessVisible("Exams.MaintainExamPIValues");
      bool flag8 = Cache.ProcessAvailable("Exams.ManagePIBrowser");
      MainContainerHelper.ExamsMainMenu.Visible = flag1 || flag2 || (flag3 || flag6) || flag8;
      MainContainerHelper.ImportQualificationData.Visible = flag1 || flag2 || flag3 || flag7;
      MainContainerHelper.PerformanceIndicator.Visible = flag8;
      MainContainerHelper.EditPerformanceIndicators.Visible = flag7;
      MainContainerHelper.SetUpPerformanceIndicators.Visible = flag5;
      MainContainerHelper.PerformanceIndicatorReports.Visible = flag6;
      MainContainerHelper.EntryReport.Visible = flag6;
      MainContainerHelper.ExternalResultsManualEntry.Visible = Cache.ProcessAvailable("Exams.BrowseExamStudents");
      MainContainerHelper.QANCorrelationReport.Visible = flag6;
      foreach (MenuItem menuItem in MainContainerHelper.QANCorrelationReport.MenuItems)
        menuItem.Visible = MainContainerHelper.QANCorrelationReport.Visible;
      SIMS.Processes.ExamCache.PopulateSeasonCache();
      MainContainerHelper.SetPiEnabled(SIMS.Entities.ExamCache.JuneExists != "F");
    }

    public static void SetPiEnabled(bool piEnabled)
    {
      MainContainerHelper.QANCorrelationReport.Enabled = SIMS.Entities.ExamCache.CurrentSeasonEndDate.Year > 2016;
      MainContainerHelper.EditPerformanceIndicators.Enabled = piEnabled;
      if (SIMS.Entities.ExamCache.CurrentSeasonEndDate.Year > 2016 && piEnabled)
        MainContainerHelper.PerformanceIndicator.Enabled = true;
      else
        MainContainerHelper.PerformanceIndicator.Enabled = false;
    }

    private static void ExternalResultsManualEntry_Click(object sender, EventArgs e)
    {
      SIMS.Processes.ExamCache.Populate();
      MainContainerHelper.menuItem_Click(sender, (Control) new ExternalResultsManualEntryContainer());
    }

    private static void QANCorrelationReport_Click(object sender, EventArgs e)
    {
      MainContainerHelper.generateQANCorrellationReport(sender, false);
    }

    private static void QANCorrelationReportWithUserQN_Click(object sender, EventArgs e)
    {
      MainContainerHelper.generateQANCorrellationReport(sender, true);
    }

    private static void generateQANCorrellationReport(object sender, bool includeUserQN)
    {
      if (SIMS.Entities.ExamCache.CurrentSeasonEndDate.Year <= 2016)
        return;
      Cursor cursor = (Cursor) null;
      SIMS.UserInterfaces.Form target = MainContainerHelper.recordMenuUsageDelegate.Target as SIMS.UserInterfaces.Form;
      if (target != null)
      {
        cursor = target.Cursor;
        target.Cursor = Cursors.WaitCursor;
      }
      try
      {
        SIMS.Processes.ExamCache.Populate();
        MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
        using (QNCorrelationReportProcess correlationReportProcess = new QNCorrelationReportProcess())
          correlationReportProcess.GenerateMissingQNReport(includeUserQN);
      }
      finally
      {
        if (target != null)
          target.Cursor = cursor;
      }
    }

    private static void MenuItemExamsReportsPerformanceTables_Click(object sender, EventArgs e)
    {
      SIMS.Processes.ExamCache.Populate();
      MainContainerHelper.menuItem_Click(sender, (Control) new MaintainExamPerformanceTableReports());
    }

    private static void MenuItemExamsSetup_Click(object sender, EventArgs e)
    {
      SIMS.Processes.ExamCache.Populate();
      MainContainerHelper.menuItem_Click(sender, (Control) new ExamsSetup());
    }

    private static void MenuItemExamsEntryReport_Click(object sender, EventArgs e)
    {
      SIMS.Processes.ExamCache.Populate();
      MainContainerHelper.menuItem_Click(sender, (Control) new MaintainExamReports());
    }

    private static void MenuItemExamsPiValuesEdit_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(SystemConfigurationCache.LocaleCode == "NI" ? "Please confirm that your NIEFQAN file import is up to date." : "Please confirm that your QWS QN Catalogue and Performance Measures are up to date.", "SIMS.net", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      SIMS.Processes.ExamCache.Populate();
      MainContainerHelper.menuItem_Click(sender, (Control) new MaintainExamPIValuesContainer());
    }

    private static void MenuItemUpdateCatalogueFromQWS_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Please confirm that your download is up to date.", "SIMS.net", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      SIMS.Processes.PLASCCache.Populate();
      SIMS.Processes.ExamCache.Populate();
      MainContainerHelper.menuItem_Click(sender, (Control) new SIMS.UserInterfaces.CensusImportQANFromQWS());
    }

    private static void MenuItemUpdatePerformanceIndicator_Click(object sender, EventArgs e)
    {
      SIMS.Processes.ExamCache.Populate();
      MainContainerHelper.SetPiEnabled(SIMS.Entities.ExamCache.JuneExists != "F");
      ExamQanPerformanceYear qanPerformanceYear = SIMS.Entities.ExamCache.ExamQanPerformanceYears.Value[0] as ExamQanPerformanceYear;
      if (qanPerformanceYear != null && !qanPerformanceYear.PiDataExists)
      {
        int num = (int) MessageBox.Show("The QNs for " + (object) qanPerformanceYear.Year + " have not been cloned. \nPlease go to Tools | Examinations | PI Setup.", "SIMS.net", MessageBoxButtons.OK);
      }
      else if (MainContainerHelper.PerformanceIndicator.Enabled)
      {
        MainContainerHelper.menuItem_Click(sender, (Control) new ManagePIBrowserDetail());
      }
      else
      {
        if (MainContainerHelper.PerformanceIndicator.Enabled)
          return;
        Cache.StatusMessage("The Manage PI is not active for current season.", UserMessageEventEnum.Warning);
      }
    }

    private static void recordMenuUsage(UIMenuItem menuItem)
    {
      MainContainerHelper.recordMenuUsageDelegate(menuItem);
    }

    private static void displayComponent(Control component)
    {
      Control control = MainContainerHelper.displayComponentDelegate((IIDEntity) null, component);
    }

    private static void menuItem_Click(object sender, Control component)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.displayComponent(component);
    }
  }
}
