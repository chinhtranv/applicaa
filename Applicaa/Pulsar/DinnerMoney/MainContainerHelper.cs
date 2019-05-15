// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.DinnerMoney.MainContainerHelper
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using SIMS.Entities;
using SIMS.Processes;
using SIMS.Processes.DinnerMoney;
using SIMS.UserInterfaces.InTouch;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SIMS.UserInterfaces.DinnerMoney
{
  public static class MainContainerHelper
  {
    private const string MSG_INFO_NOT_FIRST_YEAR = "This feature is unavailable because you are not in the first year of implementation.";
    private const string MSG_INFO_NOT_SUPPORTED = "This feature is unavailable because Dinner Money 1.40 is no longer supported.";
    private static RecordMenuUsageDelegate recordMenuUsage;
    private static DisplayComponentDelegate displayComponent;
    private static DisplayComponentWithInterfacesDelegate displayComponentWithInterfaces;
    private static UIMenuItem menuItemFocusDinnerMoney;
    private static UIMenuItem menuItemStudentRecordMeals;
    private static UIMenuItem menuItemStudentEditMeals;
    private static UIMenuItem menuItemFocusSeparator1;
    private static UIMenuItem menuItemStudentPayments;
    private static UIMenuItem menuItemStudentDefaultMealPatterns;
    private static UIMenuItem menuItemStudentOpeningBalances;
    private static UIMenuItem menuItemStudentAdditionalTransactions;
    private static UIMenuItem menuItemFocusSeparator2;
    private static UIMenuItem menuItemEmployeeRecordMeals;
    private static UIMenuItem menuItemFocusSeparator3;
    private static UIMenuItem menuItemEmployeePayments;
    private static UIMenuItem menuItemEmployeeOpeningBalances;
    private static UIMenuItem menuItemEmployeeAdditionalTransactions;
    private static UIMenuItem menuItemFocusSeparator4;
    private static UIMenuItem menuItemAdhocMeals;
    private static UIMenuItem menuItemOtherSales;
    private static UIMenuItem menuItemFocusSeparator5;
    private static UIMenuItem menuItemBankingReturn;
    private static UIMenuItem menuItemCateringReturn;
    private static UIMenuItem menuItemReportsDinnerMoney;
    private static UIMenuItem menuItemDinnerMoneyStatistics;
    private static UIMenuItem menuItemKitchenStatisticsReport;
    private static UIMenuItem menuItemDinnerNumbersByWeekReport;
    private static UIMenuItem menuItemYearlyStatisticsReport;
    private static UIMenuItem menuItemDinnerMoneyListings;
    private static UIMenuItem menuItemManualEntryDinnerRegister;
    private static UIMenuItem menuItemSupervisorListReport;
    private static UIMenuItem menuItemSplitPaymentsListReport;
    private static UIMenuItem menuItemDinnerMoneyFinance;
    private static UIMenuItem menuItemChequeAndPaymentDetailListReport;
    private static UIMenuItem menuItemTransactionListByTypeReport;
    private static UIMenuItem menuItemTransactionListByNumberReport;
    private static UIMenuItem menuItemOpeningBalancesReport;
    private static UIMenuItem menuItemStudentBalancesReport;
    private static UIMenuItem menuItemEmployeeBalancesReport;
    private static UIMenuItem menuItemStudentDetailedStatementOfAccountReport;
    private static UIMenuItem menuItemEmployeeDetailedStatementOfAccountReport;
    private static UIMenuItem menuItemDinnerMoneyLetters;
    private static UIMenuItem menuItemFreeSchoolMealLetter;
    private static UIMenuItem menuItemDebtorLetter;
    private static UIMenuItem menuItemCreditorLetter;
    private static UIMenuItem menuItemSummaryStatementLetter;
    private static UIMenuItem menuItemChargeForecastLetter;
    private static UIMenuItem menuItemDinnerMoneyAudit;
    private static UIMenuItem menuItemAuditLogReport;
    private static UIMenuItem menuItemCostIncomeSummaryReport;
    private static UIMenuItem menuItemReportsSeparator1;
    private static UIMenuItem menuItemBankingReturn2;
    private static UIMenuItem menuItemCateringReturn2;
    private static UIMenuItem menuItemStudentDefaultMealPatterns2;
    private static UIMenuItem menuItemRoutinesDinnerMoney;
    private static UIMenuItem menuItemAutofillDefaultMeals;
    private static UIMenuItem menuItemRoutinesSeparator1;
    private static UIMenuItem menuItemImportBankingCodes;
    private static UIMenuItem menuItemImportMealDefinitions;
    private static UIMenuItem menuItemImportStudentOpeningBalances;
    private static UIMenuItem menuItemRoutinesSeparator2;
    private static UIMenuItem menuItemExportBankingCodes;
    private static UIMenuItem menuItemExportMealDefinitions;
    private static UIMenuItem menuItemToolsDinnerMoney;
    private static UIMenuItem menuItemBankingCodes;
    private static UIMenuItem menuItemVATCodes;
    private static UIMenuItem menuItemToolsSeparator1;
    private static UIMenuItem menuItemSetup;
    private static UIMenuItem menuItemToolsSeparator2;
    private static UIMenuItem menuItemStudentMealDefinitions;
    private static UIMenuItem menuItemEmployeeMealDefinitions;
    private static UIMenuItem menuItemAdhocMealDefinitions;
    private static UIMenuItem menuItemOtherSalesDefinitions;
    private static UIMenuItem menuItemToolsSeparator3;
    private static UIMenuItem menuItemUnprocessMeals;
    private static UIMenuItem menuItemUnlockMealProcessing;

    public static void InitialiseMenus(
      MainMenu mainMenu,
      RecordMenuUsageDelegate recordMenuUsage,
      DisplayComponentDelegate displayComponent,
      DisplayComponentWithInterfacesDelegate displayComponentWithInterfaces)
    {
      if (mainMenu == null)
        throw new ArgumentNullException(nameof (mainMenu));
      if (recordMenuUsage == null)
        throw new ArgumentNullException(nameof (recordMenuUsage));
      if (displayComponent == null)
        throw new ArgumentNullException(nameof (displayComponent));
      if (displayComponentWithInterfaces == null)
        throw new ArgumentNullException(nameof (displayComponentWithInterfaces));
      MainContainerHelper.recordMenuUsage = recordMenuUsage;
      MainContainerHelper.displayComponent = displayComponent;
      MainContainerHelper.displayComponentWithInterfaces = displayComponentWithInterfaces;
      UIMenuItem menuItem1 = mainMenu.MenuItems["focusMenu"] as UIMenuItem;
      UIMenuItem menuItem2 = menuItem1.MenuItems["menuItemAttendance"] as UIMenuItem;
      UIMenuItem menuItem3 = mainMenu.MenuItems["MenuItemReports"] as UIMenuItem;
      UIMenuItem menuItem4 = menuItem3.MenuItems["menuItemAttendanceReports"] as UIMenuItem;
      UIMenuItem menuItem5 = mainMenu.MenuItems["menuItemRoutines"] as UIMenuItem;
      UIMenuItem menuItem6 = menuItem5.MenuItems["menuItemRoutinesStudents"] as UIMenuItem;
      UIMenuItem menuItem7 = menuItem6.MenuItems["menuItemStudentBulkUpdate"] as UIMenuItem;
      UIMenuItem menuItem8 = menuItem5.MenuItems["menuItemAttendanceRoutines"] as UIMenuItem;
      UIMenuItem menuItem9 = mainMenu.MenuItems["toolsMenu"] as UIMenuItem;
      UIMenuItem menuItem10 = menuItem9.MenuItems["menuItemCurrLessPlannerTools"] as UIMenuItem;
      MainContainerHelper.menuItemFocusDinnerMoney = new UIMenuItem();
      MainContainerHelper.menuItemStudentRecordMeals = new UIMenuItem();
      MainContainerHelper.menuItemStudentEditMeals = new UIMenuItem();
      MainContainerHelper.menuItemFocusSeparator1 = new UIMenuItem();
      MainContainerHelper.menuItemStudentPayments = new UIMenuItem();
      MainContainerHelper.menuItemStudentDefaultMealPatterns = new UIMenuItem();
      MainContainerHelper.menuItemStudentOpeningBalances = new UIMenuItem();
      MainContainerHelper.menuItemStudentAdditionalTransactions = new UIMenuItem();
      MainContainerHelper.menuItemFocusSeparator2 = new UIMenuItem();
      MainContainerHelper.menuItemEmployeeRecordMeals = new UIMenuItem();
      MainContainerHelper.menuItemFocusSeparator3 = new UIMenuItem();
      MainContainerHelper.menuItemEmployeePayments = new UIMenuItem();
      MainContainerHelper.menuItemEmployeeOpeningBalances = new UIMenuItem();
      MainContainerHelper.menuItemEmployeeAdditionalTransactions = new UIMenuItem();
      MainContainerHelper.menuItemFocusSeparator4 = new UIMenuItem();
      MainContainerHelper.menuItemAdhocMeals = new UIMenuItem();
      MainContainerHelper.menuItemOtherSales = new UIMenuItem();
      MainContainerHelper.menuItemFocusSeparator5 = new UIMenuItem();
      MainContainerHelper.menuItemBankingReturn = new UIMenuItem();
      MainContainerHelper.menuItemCateringReturn = new UIMenuItem();
      MainContainerHelper.menuItemReportsDinnerMoney = new UIMenuItem();
      MainContainerHelper.menuItemDinnerMoneyStatistics = new UIMenuItem();
      MainContainerHelper.menuItemKitchenStatisticsReport = new UIMenuItem();
      MainContainerHelper.menuItemDinnerNumbersByWeekReport = new UIMenuItem();
      MainContainerHelper.menuItemYearlyStatisticsReport = new UIMenuItem();
      MainContainerHelper.menuItemDinnerMoneyListings = new UIMenuItem();
      MainContainerHelper.menuItemManualEntryDinnerRegister = new UIMenuItem();
      MainContainerHelper.menuItemSupervisorListReport = new UIMenuItem();
      MainContainerHelper.menuItemSplitPaymentsListReport = new UIMenuItem();
      MainContainerHelper.menuItemDinnerMoneyFinance = new UIMenuItem();
      MainContainerHelper.menuItemChequeAndPaymentDetailListReport = new UIMenuItem();
      MainContainerHelper.menuItemTransactionListByTypeReport = new UIMenuItem();
      MainContainerHelper.menuItemTransactionListByNumberReport = new UIMenuItem();
      MainContainerHelper.menuItemOpeningBalancesReport = new UIMenuItem();
      MainContainerHelper.menuItemStudentBalancesReport = new UIMenuItem();
      MainContainerHelper.menuItemEmployeeBalancesReport = new UIMenuItem();
      MainContainerHelper.menuItemStudentDetailedStatementOfAccountReport = new UIMenuItem();
      MainContainerHelper.menuItemEmployeeDetailedStatementOfAccountReport = new UIMenuItem();
      MainContainerHelper.menuItemDinnerMoneyLetters = new UIMenuItem();
      MainContainerHelper.menuItemFreeSchoolMealLetter = new UIMenuItem();
      MainContainerHelper.menuItemDebtorLetter = new UIMenuItem();
      MainContainerHelper.menuItemCreditorLetter = new UIMenuItem();
      MainContainerHelper.menuItemSummaryStatementLetter = new UIMenuItem();
      MainContainerHelper.menuItemChargeForecastLetter = new UIMenuItem();
      MainContainerHelper.menuItemDinnerMoneyAudit = new UIMenuItem();
      MainContainerHelper.menuItemAuditLogReport = new UIMenuItem();
      MainContainerHelper.menuItemCostIncomeSummaryReport = new UIMenuItem();
      MainContainerHelper.menuItemReportsSeparator1 = new UIMenuItem();
      MainContainerHelper.menuItemBankingReturn2 = new UIMenuItem();
      MainContainerHelper.menuItemCateringReturn2 = new UIMenuItem();
      MainContainerHelper.menuItemStudentDefaultMealPatterns2 = new UIMenuItem();
      MainContainerHelper.menuItemRoutinesDinnerMoney = new UIMenuItem();
      MainContainerHelper.menuItemAutofillDefaultMeals = new UIMenuItem();
      MainContainerHelper.menuItemRoutinesSeparator1 = new UIMenuItem();
      MainContainerHelper.menuItemImportBankingCodes = new UIMenuItem();
      MainContainerHelper.menuItemImportMealDefinitions = new UIMenuItem();
      MainContainerHelper.menuItemImportStudentOpeningBalances = new UIMenuItem();
      MainContainerHelper.menuItemRoutinesSeparator2 = new UIMenuItem();
      MainContainerHelper.menuItemExportBankingCodes = new UIMenuItem();
      MainContainerHelper.menuItemExportMealDefinitions = new UIMenuItem();
      MainContainerHelper.menuItemToolsDinnerMoney = new UIMenuItem();
      MainContainerHelper.menuItemBankingCodes = new UIMenuItem();
      MainContainerHelper.menuItemVATCodes = new UIMenuItem();
      MainContainerHelper.menuItemToolsSeparator1 = new UIMenuItem();
      MainContainerHelper.menuItemSetup = new UIMenuItem();
      MainContainerHelper.menuItemToolsSeparator2 = new UIMenuItem();
      MainContainerHelper.menuItemStudentMealDefinitions = new UIMenuItem();
      MainContainerHelper.menuItemEmployeeMealDefinitions = new UIMenuItem();
      MainContainerHelper.menuItemAdhocMealDefinitions = new UIMenuItem();
      MainContainerHelper.menuItemOtherSalesDefinitions = new UIMenuItem();
      MainContainerHelper.menuItemToolsSeparator3 = new UIMenuItem();
      MainContainerHelper.menuItemUnprocessMeals = new UIMenuItem();
      MainContainerHelper.menuItemUnlockMealProcessing = new UIMenuItem();
      menuItem1.MenuItems.Add(menuItem2.Index + 1, (MenuItem) MainContainerHelper.menuItemFocusDinnerMoney);
      menuItem3.MenuItems.Add(menuItem4.Index + 1, (MenuItem) MainContainerHelper.menuItemReportsDinnerMoney);
      menuItem5.MenuItems.Add(menuItem8.Index + 1, (MenuItem) MainContainerHelper.menuItemRoutinesDinnerMoney);
      menuItem9.MenuItems.Add(menuItem10.Index + 1, (MenuItem) MainContainerHelper.menuItemToolsDinnerMoney);
      menuItem6.MenuItems.Add(menuItem7.Index + 1, (MenuItem) MainContainerHelper.menuItemStudentDefaultMealPatterns2);
      MainContainerHelper.menuItemFocusDinnerMoney.ImageIndex = -1;
      MainContainerHelper.menuItemFocusDinnerMoney.ImageList = (ImageList) null;
      MainContainerHelper.menuItemFocusDinnerMoney.MenuItems.AddRange(new MenuItem[19]
      {
        (MenuItem) MainContainerHelper.menuItemStudentRecordMeals,
        (MenuItem) MainContainerHelper.menuItemStudentEditMeals,
        (MenuItem) MainContainerHelper.menuItemFocusSeparator1,
        (MenuItem) MainContainerHelper.menuItemStudentPayments,
        (MenuItem) MainContainerHelper.menuItemStudentDefaultMealPatterns,
        (MenuItem) MainContainerHelper.menuItemStudentOpeningBalances,
        (MenuItem) MainContainerHelper.menuItemStudentAdditionalTransactions,
        (MenuItem) MainContainerHelper.menuItemFocusSeparator2,
        (MenuItem) MainContainerHelper.menuItemEmployeeRecordMeals,
        (MenuItem) MainContainerHelper.menuItemFocusSeparator3,
        (MenuItem) MainContainerHelper.menuItemEmployeePayments,
        (MenuItem) MainContainerHelper.menuItemEmployeeOpeningBalances,
        (MenuItem) MainContainerHelper.menuItemEmployeeAdditionalTransactions,
        (MenuItem) MainContainerHelper.menuItemFocusSeparator4,
        (MenuItem) MainContainerHelper.menuItemAdhocMeals,
        (MenuItem) MainContainerHelper.menuItemOtherSales,
        (MenuItem) MainContainerHelper.menuItemFocusSeparator5,
        (MenuItem) MainContainerHelper.menuItemBankingReturn,
        (MenuItem) MainContainerHelper.menuItemCateringReturn
      });
      MainContainerHelper.menuItemFocusDinnerMoney.NoEdit = false;
      MainContainerHelper.menuItemFocusDinnerMoney.NoUIModify = false;
      MainContainerHelper.menuItemFocusDinnerMoney.OriginalText = "";
      MainContainerHelper.menuItemFocusDinnerMoney.OwnerDraw = true;
      MainContainerHelper.menuItemFocusDinnerMoney.Text = "&Dinner Money";
      MainContainerHelper.menuItemStudentRecordMeals.ImageIndex = -1;
      MainContainerHelper.menuItemStudentRecordMeals.ImageList = (ImageList) null;
      MainContainerHelper.menuItemStudentRecordMeals.NoEdit = false;
      MainContainerHelper.menuItemStudentRecordMeals.NoUIModify = false;
      MainContainerHelper.menuItemStudentRecordMeals.OriginalText = "";
      MainContainerHelper.menuItemStudentRecordMeals.OwnerDraw = true;
      MainContainerHelper.menuItemStudentRecordMeals.Text = "Record Student &Meals";
      MainContainerHelper.menuItemStudentRecordMeals.Click += new EventHandler(MainContainerHelper.menuItemStudentRecordMeals_Click);
      MainContainerHelper.menuItemStudentEditMeals.ImageIndex = -1;
      MainContainerHelper.menuItemStudentEditMeals.ImageList = (ImageList) null;
      MainContainerHelper.menuItemStudentEditMeals.NoEdit = false;
      MainContainerHelper.menuItemStudentEditMeals.NoUIModify = false;
      MainContainerHelper.menuItemStudentEditMeals.OriginalText = "";
      MainContainerHelper.menuItemStudentEditMeals.OwnerDraw = true;
      MainContainerHelper.menuItemStudentEditMeals.Text = "Edit Student M&eals";
      MainContainerHelper.menuItemStudentEditMeals.Click += new EventHandler(MainContainerHelper.menuItemStudentEditMeals_Click);
      MainContainerHelper.menuItemFocusSeparator1.ImageIndex = -1;
      MainContainerHelper.menuItemFocusSeparator1.ImageList = (ImageList) null;
      MainContainerHelper.menuItemFocusSeparator1.NoEdit = false;
      MainContainerHelper.menuItemFocusSeparator1.NoUIModify = false;
      MainContainerHelper.menuItemFocusSeparator1.OriginalText = "";
      MainContainerHelper.menuItemFocusSeparator1.OwnerDraw = true;
      MainContainerHelper.menuItemFocusSeparator1.Text = "-";
      MainContainerHelper.menuItemStudentPayments.ImageIndex = -1;
      MainContainerHelper.menuItemStudentPayments.ImageList = (ImageList) null;
      MainContainerHelper.menuItemStudentPayments.NoEdit = false;
      MainContainerHelper.menuItemStudentPayments.NoUIModify = false;
      MainContainerHelper.menuItemStudentPayments.OriginalText = "";
      MainContainerHelper.menuItemStudentPayments.OwnerDraw = true;
      MainContainerHelper.menuItemStudentPayments.Text = "Student &Payments";
      MainContainerHelper.menuItemStudentPayments.Click += new EventHandler(MainContainerHelper.menuItemStudentPayments_Click);
      MainContainerHelper.menuItemStudentDefaultMealPatterns.ImageIndex = -1;
      MainContainerHelper.menuItemStudentDefaultMealPatterns.ImageList = (ImageList) null;
      MainContainerHelper.menuItemStudentDefaultMealPatterns.NoEdit = false;
      MainContainerHelper.menuItemStudentDefaultMealPatterns.NoUIModify = false;
      MainContainerHelper.menuItemStudentDefaultMealPatterns.OriginalText = "";
      MainContainerHelper.menuItemStudentDefaultMealPatterns.OwnerDraw = true;
      MainContainerHelper.menuItemStudentDefaultMealPatterns.Text = "Student &Default Meal Patterns";
      MainContainerHelper.menuItemStudentDefaultMealPatterns.Click += new EventHandler(MainContainerHelper.menuItemStudentDefaultMealPatterns_Click);
      MainContainerHelper.menuItemStudentOpeningBalances.ImageIndex = -1;
      MainContainerHelper.menuItemStudentOpeningBalances.ImageList = (ImageList) null;
      MainContainerHelper.menuItemStudentOpeningBalances.NoEdit = false;
      MainContainerHelper.menuItemStudentOpeningBalances.NoUIModify = false;
      MainContainerHelper.menuItemStudentOpeningBalances.OriginalText = "";
      MainContainerHelper.menuItemStudentOpeningBalances.OwnerDraw = true;
      MainContainerHelper.menuItemStudentOpeningBalances.Text = "Student &Opening Balances";
      MainContainerHelper.menuItemStudentOpeningBalances.Click += new EventHandler(MainContainerHelper.menuItemStudentOpeningBalances_Click);
      MainContainerHelper.menuItemStudentAdditionalTransactions.ImageIndex = -1;
      MainContainerHelper.menuItemStudentAdditionalTransactions.ImageList = (ImageList) null;
      MainContainerHelper.menuItemStudentAdditionalTransactions.NoEdit = false;
      MainContainerHelper.menuItemStudentAdditionalTransactions.NoUIModify = false;
      MainContainerHelper.menuItemStudentAdditionalTransactions.OriginalText = "";
      MainContainerHelper.menuItemStudentAdditionalTransactions.OwnerDraw = true;
      MainContainerHelper.menuItemStudentAdditionalTransactions.Text = "Student Additional &Transactions";
      MainContainerHelper.menuItemStudentAdditionalTransactions.Click += new EventHandler(MainContainerHelper.menuItemStudentAdditionalTransactions_Click);
      MainContainerHelper.menuItemFocusSeparator2.ImageIndex = -1;
      MainContainerHelper.menuItemFocusSeparator2.ImageList = (ImageList) null;
      MainContainerHelper.menuItemFocusSeparator2.NoEdit = false;
      MainContainerHelper.menuItemFocusSeparator2.NoUIModify = false;
      MainContainerHelper.menuItemFocusSeparator2.OriginalText = "";
      MainContainerHelper.menuItemFocusSeparator2.OwnerDraw = true;
      MainContainerHelper.menuItemFocusSeparator2.Text = "-";
      MainContainerHelper.menuItemEmployeeRecordMeals.ImageIndex = -1;
      MainContainerHelper.menuItemEmployeeRecordMeals.ImageList = (ImageList) null;
      MainContainerHelper.menuItemEmployeeRecordMeals.NoEdit = false;
      MainContainerHelper.menuItemEmployeeRecordMeals.NoUIModify = false;
      MainContainerHelper.menuItemEmployeeRecordMeals.OriginalText = "";
      MainContainerHelper.menuItemEmployeeRecordMeals.OwnerDraw = true;
      MainContainerHelper.menuItemEmployeeRecordMeals.Text = "Record Staff Mea&ls";
      MainContainerHelper.menuItemEmployeeRecordMeals.Click += new EventHandler(MainContainerHelper.menuItemEmployeeRecordMeals_Click);
      MainContainerHelper.menuItemFocusSeparator3.ImageIndex = -1;
      MainContainerHelper.menuItemFocusSeparator3.ImageList = (ImageList) null;
      MainContainerHelper.menuItemFocusSeparator3.NoEdit = false;
      MainContainerHelper.menuItemFocusSeparator3.NoUIModify = false;
      MainContainerHelper.menuItemFocusSeparator3.OriginalText = "";
      MainContainerHelper.menuItemFocusSeparator3.OwnerDraw = true;
      MainContainerHelper.menuItemFocusSeparator3.Text = "-";
      MainContainerHelper.menuItemEmployeePayments.ImageIndex = -1;
      MainContainerHelper.menuItemEmployeePayments.ImageList = (ImageList) null;
      MainContainerHelper.menuItemEmployeePayments.NoEdit = false;
      MainContainerHelper.menuItemEmployeePayments.NoUIModify = false;
      MainContainerHelper.menuItemEmployeePayments.OriginalText = "";
      MainContainerHelper.menuItemEmployeePayments.OwnerDraw = true;
      MainContainerHelper.menuItemEmployeePayments.Text = "Staff Pa&yments";
      MainContainerHelper.menuItemEmployeePayments.Click += new EventHandler(MainContainerHelper.menuItemEmployeePayments_Click);
      MainContainerHelper.menuItemEmployeeOpeningBalances.ImageIndex = -1;
      MainContainerHelper.menuItemEmployeeOpeningBalances.ImageList = (ImageList) null;
      MainContainerHelper.menuItemEmployeeOpeningBalances.NoEdit = false;
      MainContainerHelper.menuItemEmployeeOpeningBalances.NoUIModify = false;
      MainContainerHelper.menuItemEmployeeOpeningBalances.OriginalText = "";
      MainContainerHelper.menuItemEmployeeOpeningBalances.OwnerDraw = true;
      MainContainerHelper.menuItemEmployeeOpeningBalances.Text = "Staff Ope&ning Balances";
      MainContainerHelper.menuItemEmployeeOpeningBalances.Click += new EventHandler(MainContainerHelper.menuItemEmployeeOpeningBalances_Click);
      MainContainerHelper.menuItemEmployeeAdditionalTransactions.ImageIndex = -1;
      MainContainerHelper.menuItemEmployeeAdditionalTransactions.ImageList = (ImageList) null;
      MainContainerHelper.menuItemEmployeeAdditionalTransactions.NoEdit = false;
      MainContainerHelper.menuItemEmployeeAdditionalTransactions.NoUIModify = false;
      MainContainerHelper.menuItemEmployeeAdditionalTransactions.OriginalText = "";
      MainContainerHelper.menuItemEmployeeAdditionalTransactions.OwnerDraw = true;
      MainContainerHelper.menuItemEmployeeAdditionalTransactions.Text = "Staff Additional T&ransactions";
      MainContainerHelper.menuItemEmployeeAdditionalTransactions.Click += new EventHandler(MainContainerHelper.menuItemEmployeeAdditionalTransactions_Click);
      MainContainerHelper.menuItemFocusSeparator4.ImageIndex = -1;
      MainContainerHelper.menuItemFocusSeparator4.ImageList = (ImageList) null;
      MainContainerHelper.menuItemFocusSeparator4.NoEdit = false;
      MainContainerHelper.menuItemFocusSeparator4.NoUIModify = false;
      MainContainerHelper.menuItemFocusSeparator4.OriginalText = "";
      MainContainerHelper.menuItemFocusSeparator4.OwnerDraw = true;
      MainContainerHelper.menuItemFocusSeparator4.Text = "-";
      MainContainerHelper.menuItemAdhocMeals.ImageIndex = -1;
      MainContainerHelper.menuItemAdhocMeals.ImageList = (ImageList) null;
      MainContainerHelper.menuItemAdhocMeals.NoEdit = false;
      MainContainerHelper.menuItemAdhocMeals.NoUIModify = false;
      MainContainerHelper.menuItemAdhocMeals.OriginalText = "";
      MainContainerHelper.menuItemAdhocMeals.OwnerDraw = true;
      MainContainerHelper.menuItemAdhocMeals.Text = "&Adhoc Meals";
      MainContainerHelper.menuItemAdhocMeals.Click += new EventHandler(MainContainerHelper.menuItemAdhocMeals_Click);
      MainContainerHelper.menuItemOtherSales.ImageIndex = -1;
      MainContainerHelper.menuItemOtherSales.ImageList = (ImageList) null;
      MainContainerHelper.menuItemOtherSales.NoEdit = false;
      MainContainerHelper.menuItemOtherSales.NoUIModify = false;
      MainContainerHelper.menuItemOtherSales.OriginalText = "";
      MainContainerHelper.menuItemOtherSales.OwnerDraw = true;
      MainContainerHelper.menuItemOtherSales.Text = "Other &Sales";
      MainContainerHelper.menuItemOtherSales.Click += new EventHandler(MainContainerHelper.menuItemOtherSales_Click);
      MainContainerHelper.menuItemFocusSeparator5.ImageIndex = -1;
      MainContainerHelper.menuItemFocusSeparator5.ImageList = (ImageList) null;
      MainContainerHelper.menuItemFocusSeparator5.NoEdit = false;
      MainContainerHelper.menuItemFocusSeparator5.NoUIModify = false;
      MainContainerHelper.menuItemFocusSeparator5.OriginalText = "";
      MainContainerHelper.menuItemFocusSeparator5.OwnerDraw = true;
      MainContainerHelper.menuItemFocusSeparator5.Text = "-";
      MainContainerHelper.menuItemBankingReturn.ImageIndex = -1;
      MainContainerHelper.menuItemBankingReturn.ImageList = (ImageList) null;
      MainContainerHelper.menuItemBankingReturn.NoEdit = false;
      MainContainerHelper.menuItemBankingReturn.NoUIModify = false;
      MainContainerHelper.menuItemBankingReturn.OriginalText = "";
      MainContainerHelper.menuItemBankingReturn.OwnerDraw = true;
      MainContainerHelper.menuItemBankingReturn.Text = "&Banking Return";
      MainContainerHelper.menuItemBankingReturn.Click += new EventHandler(MainContainerHelper.menuItemBankingReturn_Click);
      MainContainerHelper.menuItemCateringReturn.ImageIndex = -1;
      MainContainerHelper.menuItemCateringReturn.ImageList = (ImageList) null;
      MainContainerHelper.menuItemCateringReturn.NoEdit = false;
      MainContainerHelper.menuItemCateringReturn.NoUIModify = false;
      MainContainerHelper.menuItemCateringReturn.OriginalText = "";
      MainContainerHelper.menuItemCateringReturn.OwnerDraw = true;
      MainContainerHelper.menuItemCateringReturn.Text = "&Catering Return";
      MainContainerHelper.menuItemCateringReturn.Click += new EventHandler(MainContainerHelper.menuItemCateringReturn_Click);
      MainContainerHelper.menuItemReportsDinnerMoney.ImageIndex = -1;
      MainContainerHelper.menuItemReportsDinnerMoney.ImageList = (ImageList) null;
      MainContainerHelper.menuItemReportsDinnerMoney.MenuItems.AddRange(new MenuItem[8]
      {
        (MenuItem) MainContainerHelper.menuItemDinnerMoneyStatistics,
        (MenuItem) MainContainerHelper.menuItemDinnerMoneyListings,
        (MenuItem) MainContainerHelper.menuItemDinnerMoneyFinance,
        (MenuItem) MainContainerHelper.menuItemDinnerMoneyLetters,
        (MenuItem) MainContainerHelper.menuItemDinnerMoneyAudit,
        (MenuItem) MainContainerHelper.menuItemReportsSeparator1,
        (MenuItem) MainContainerHelper.menuItemBankingReturn2,
        (MenuItem) MainContainerHelper.menuItemCateringReturn2
      });
      MainContainerHelper.menuItemReportsDinnerMoney.NoEdit = false;
      MainContainerHelper.menuItemReportsDinnerMoney.NoUIModify = false;
      MainContainerHelper.menuItemReportsDinnerMoney.OriginalText = "";
      MainContainerHelper.menuItemReportsDinnerMoney.OwnerDraw = true;
      MainContainerHelper.menuItemReportsDinnerMoney.Text = "Dinner &Money";
      MainContainerHelper.menuItemDinnerMoneyStatistics.ImageIndex = -1;
      MainContainerHelper.menuItemDinnerMoneyStatistics.ImageList = (ImageList) null;
      MainContainerHelper.menuItemDinnerMoneyStatistics.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) MainContainerHelper.menuItemKitchenStatisticsReport,
        (MenuItem) MainContainerHelper.menuItemDinnerNumbersByWeekReport,
        (MenuItem) MainContainerHelper.menuItemYearlyStatisticsReport
      });
      MainContainerHelper.menuItemDinnerMoneyStatistics.NoEdit = false;
      MainContainerHelper.menuItemDinnerMoneyStatistics.NoUIModify = false;
      MainContainerHelper.menuItemDinnerMoneyStatistics.OriginalText = "";
      MainContainerHelper.menuItemDinnerMoneyStatistics.OwnerDraw = true;
      MainContainerHelper.menuItemDinnerMoneyStatistics.Text = "&Statistics";
      MainContainerHelper.menuItemKitchenStatisticsReport.ImageIndex = -1;
      MainContainerHelper.menuItemKitchenStatisticsReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemKitchenStatisticsReport.NoEdit = false;
      MainContainerHelper.menuItemKitchenStatisticsReport.NoUIModify = false;
      MainContainerHelper.menuItemKitchenStatisticsReport.OriginalText = "";
      MainContainerHelper.menuItemKitchenStatisticsReport.OwnerDraw = true;
      MainContainerHelper.menuItemKitchenStatisticsReport.Text = "&Kitchen Statistics";
      MainContainerHelper.menuItemKitchenStatisticsReport.Click += new EventHandler(MainContainerHelper.menuItemKitchenStatisticsReport_Click);
      MainContainerHelper.menuItemDinnerNumbersByWeekReport.ImageIndex = -1;
      MainContainerHelper.menuItemDinnerNumbersByWeekReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemDinnerNumbersByWeekReport.NoEdit = false;
      MainContainerHelper.menuItemDinnerNumbersByWeekReport.NoUIModify = false;
      MainContainerHelper.menuItemDinnerNumbersByWeekReport.OriginalText = "";
      MainContainerHelper.menuItemDinnerNumbersByWeekReport.OwnerDraw = true;
      MainContainerHelper.menuItemDinnerNumbersByWeekReport.Text = "&Dinner Numbers By Week";
      MainContainerHelper.menuItemDinnerNumbersByWeekReport.Click += new EventHandler(MainContainerHelper.menuItemDinnerNumbersByWeekReport_Click);
      MainContainerHelper.menuItemYearlyStatisticsReport.ImageIndex = -1;
      MainContainerHelper.menuItemYearlyStatisticsReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemYearlyStatisticsReport.NoEdit = false;
      MainContainerHelper.menuItemYearlyStatisticsReport.NoUIModify = false;
      MainContainerHelper.menuItemYearlyStatisticsReport.OriginalText = "";
      MainContainerHelper.menuItemYearlyStatisticsReport.OwnerDraw = true;
      MainContainerHelper.menuItemYearlyStatisticsReport.Text = "&Yearly Statistics";
      MainContainerHelper.menuItemYearlyStatisticsReport.Click += new EventHandler(MainContainerHelper.menuItemYearlyStatisticsReport_Click);
      MainContainerHelper.menuItemDinnerMoneyListings.ImageIndex = -1;
      MainContainerHelper.menuItemDinnerMoneyListings.ImageList = (ImageList) null;
      MainContainerHelper.menuItemDinnerMoneyListings.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) MainContainerHelper.menuItemManualEntryDinnerRegister,
        (MenuItem) MainContainerHelper.menuItemSupervisorListReport,
        (MenuItem) MainContainerHelper.menuItemSplitPaymentsListReport
      });
      MainContainerHelper.menuItemDinnerMoneyListings.NoEdit = false;
      MainContainerHelper.menuItemDinnerMoneyListings.NoUIModify = false;
      MainContainerHelper.menuItemDinnerMoneyListings.OriginalText = "";
      MainContainerHelper.menuItemDinnerMoneyListings.OwnerDraw = true;
      MainContainerHelper.menuItemDinnerMoneyListings.Text = "&Listings";
      MainContainerHelper.menuItemManualEntryDinnerRegister.ImageIndex = -1;
      MainContainerHelper.menuItemManualEntryDinnerRegister.ImageList = (ImageList) null;
      MainContainerHelper.menuItemManualEntryDinnerRegister.NoEdit = false;
      MainContainerHelper.menuItemManualEntryDinnerRegister.NoUIModify = false;
      MainContainerHelper.menuItemManualEntryDinnerRegister.OriginalText = "";
      MainContainerHelper.menuItemManualEntryDinnerRegister.OwnerDraw = true;
      MainContainerHelper.menuItemManualEntryDinnerRegister.Text = "&Manual Entry Dinner Register";
      MainContainerHelper.menuItemManualEntryDinnerRegister.Click += new EventHandler(MainContainerHelper.menuItemManualEntryDinnerRegister_Click);
      MainContainerHelper.menuItemSupervisorListReport.ImageIndex = -1;
      MainContainerHelper.menuItemSupervisorListReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemSupervisorListReport.NoEdit = false;
      MainContainerHelper.menuItemSupervisorListReport.NoUIModify = false;
      MainContainerHelper.menuItemSupervisorListReport.OriginalText = "";
      MainContainerHelper.menuItemSupervisorListReport.OwnerDraw = true;
      MainContainerHelper.menuItemSupervisorListReport.Text = "&Supervisor's List";
      MainContainerHelper.menuItemSupervisorListReport.Click += new EventHandler(MainContainerHelper.menuItemSupervisorListReport_Click);
      MainContainerHelper.menuItemSplitPaymentsListReport.ImageIndex = -1;
      MainContainerHelper.menuItemSplitPaymentsListReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemSplitPaymentsListReport.NoEdit = false;
      MainContainerHelper.menuItemSplitPaymentsListReport.NoUIModify = false;
      MainContainerHelper.menuItemSplitPaymentsListReport.OriginalText = "";
      MainContainerHelper.menuItemSplitPaymentsListReport.OwnerDraw = true;
      MainContainerHelper.menuItemSplitPaymentsListReport.Text = "Split &Payments List";
      MainContainerHelper.menuItemSplitPaymentsListReport.Click += new EventHandler(MainContainerHelper.menuItemSplitPaymentsListReport_Click);
      MainContainerHelper.menuItemDinnerMoneyFinance.ImageIndex = -1;
      MainContainerHelper.menuItemDinnerMoneyFinance.ImageList = (ImageList) null;
      MainContainerHelper.menuItemDinnerMoneyFinance.MenuItems.AddRange(new MenuItem[8]
      {
        (MenuItem) MainContainerHelper.menuItemChequeAndPaymentDetailListReport,
        (MenuItem) MainContainerHelper.menuItemTransactionListByTypeReport,
        (MenuItem) MainContainerHelper.menuItemTransactionListByNumberReport,
        (MenuItem) MainContainerHelper.menuItemOpeningBalancesReport,
        (MenuItem) MainContainerHelper.menuItemStudentBalancesReport,
        (MenuItem) MainContainerHelper.menuItemEmployeeBalancesReport,
        (MenuItem) MainContainerHelper.menuItemStudentDetailedStatementOfAccountReport,
        (MenuItem) MainContainerHelper.menuItemEmployeeDetailedStatementOfAccountReport
      });
      MainContainerHelper.menuItemDinnerMoneyFinance.NoEdit = false;
      MainContainerHelper.menuItemDinnerMoneyFinance.NoUIModify = false;
      MainContainerHelper.menuItemDinnerMoneyFinance.OriginalText = "";
      MainContainerHelper.menuItemDinnerMoneyFinance.OwnerDraw = true;
      MainContainerHelper.menuItemDinnerMoneyFinance.Text = "&Finance";
      MainContainerHelper.menuItemChequeAndPaymentDetailListReport.ImageIndex = -1;
      MainContainerHelper.menuItemChequeAndPaymentDetailListReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemChequeAndPaymentDetailListReport.NoEdit = false;
      MainContainerHelper.menuItemChequeAndPaymentDetailListReport.NoUIModify = false;
      MainContainerHelper.menuItemChequeAndPaymentDetailListReport.OriginalText = "";
      MainContainerHelper.menuItemChequeAndPaymentDetailListReport.OwnerDraw = true;
      MainContainerHelper.menuItemChequeAndPaymentDetailListReport.Text = "&Cheque and Payment Detail List";
      MainContainerHelper.menuItemChequeAndPaymentDetailListReport.Click += new EventHandler(MainContainerHelper.menuItemChequeAndPaymentDetailListReport_Click);
      MainContainerHelper.menuItemTransactionListByTypeReport.ImageIndex = -1;
      MainContainerHelper.menuItemTransactionListByTypeReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemTransactionListByTypeReport.NoEdit = false;
      MainContainerHelper.menuItemTransactionListByTypeReport.NoUIModify = false;
      MainContainerHelper.menuItemTransactionListByTypeReport.OriginalText = "";
      MainContainerHelper.menuItemTransactionListByTypeReport.OwnerDraw = true;
      MainContainerHelper.menuItemTransactionListByTypeReport.Text = "Transaction List By &Type";
      MainContainerHelper.menuItemTransactionListByTypeReport.Click += new EventHandler(MainContainerHelper.menuItemTransactionListByTypeReport_Click);
      MainContainerHelper.menuItemTransactionListByNumberReport.ImageIndex = -1;
      MainContainerHelper.menuItemTransactionListByNumberReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemTransactionListByNumberReport.NoEdit = false;
      MainContainerHelper.menuItemTransactionListByNumberReport.NoUIModify = false;
      MainContainerHelper.menuItemTransactionListByNumberReport.OriginalText = "";
      MainContainerHelper.menuItemTransactionListByNumberReport.OwnerDraw = true;
      MainContainerHelper.menuItemTransactionListByNumberReport.Text = "Transaction List By &Number";
      MainContainerHelper.menuItemTransactionListByNumberReport.Click += new EventHandler(MainContainerHelper.menuItemTransactionListByNumberReport_Click);
      MainContainerHelper.menuItemOpeningBalancesReport.ImageIndex = -1;
      MainContainerHelper.menuItemOpeningBalancesReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemOpeningBalancesReport.NoEdit = false;
      MainContainerHelper.menuItemOpeningBalancesReport.NoUIModify = false;
      MainContainerHelper.menuItemOpeningBalancesReport.OriginalText = "";
      MainContainerHelper.menuItemOpeningBalancesReport.OwnerDraw = true;
      MainContainerHelper.menuItemOpeningBalancesReport.Text = "&Opening Balances";
      MainContainerHelper.menuItemOpeningBalancesReport.Click += new EventHandler(MainContainerHelper.menuItemOpeningBalancesReport_Click);
      MainContainerHelper.menuItemStudentBalancesReport.ImageIndex = -1;
      MainContainerHelper.menuItemStudentBalancesReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemStudentBalancesReport.NoEdit = false;
      MainContainerHelper.menuItemStudentBalancesReport.NoUIModify = false;
      MainContainerHelper.menuItemStudentBalancesReport.OriginalText = "";
      MainContainerHelper.menuItemStudentBalancesReport.OwnerDraw = true;
      MainContainerHelper.menuItemStudentBalancesReport.Text = "Student &Balances";
      MainContainerHelper.menuItemStudentBalancesReport.Click += new EventHandler(MainContainerHelper.menuItemStudentBalancesReport_Click);
      MainContainerHelper.menuItemEmployeeBalancesReport.ImageIndex = -1;
      MainContainerHelper.menuItemEmployeeBalancesReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemEmployeeBalancesReport.NoEdit = false;
      MainContainerHelper.menuItemEmployeeBalancesReport.NoUIModify = false;
      MainContainerHelper.menuItemEmployeeBalancesReport.OriginalText = "";
      MainContainerHelper.menuItemEmployeeBalancesReport.OwnerDraw = true;
      MainContainerHelper.menuItemEmployeeBalancesReport.Text = "Staff B&alances";
      MainContainerHelper.menuItemEmployeeBalancesReport.Click += new EventHandler(MainContainerHelper.menuItemEmployeeBalancesReport_Click);
      MainContainerHelper.menuItemStudentDetailedStatementOfAccountReport.ImageIndex = -1;
      MainContainerHelper.menuItemStudentDetailedStatementOfAccountReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemStudentDetailedStatementOfAccountReport.NoEdit = false;
      MainContainerHelper.menuItemStudentDetailedStatementOfAccountReport.NoUIModify = false;
      MainContainerHelper.menuItemStudentDetailedStatementOfAccountReport.OriginalText = "";
      MainContainerHelper.menuItemStudentDetailedStatementOfAccountReport.OwnerDraw = true;
      MainContainerHelper.menuItemStudentDetailedStatementOfAccountReport.Text = "Student &Detailed Statement Of Account";
      MainContainerHelper.menuItemStudentDetailedStatementOfAccountReport.Click += new EventHandler(MainContainerHelper.menuItemStudentDetailedStatementOfAccountReport_Click);
      MainContainerHelper.menuItemEmployeeDetailedStatementOfAccountReport.ImageIndex = -1;
      MainContainerHelper.menuItemEmployeeDetailedStatementOfAccountReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemEmployeeDetailedStatementOfAccountReport.NoEdit = false;
      MainContainerHelper.menuItemEmployeeDetailedStatementOfAccountReport.NoUIModify = false;
      MainContainerHelper.menuItemEmployeeDetailedStatementOfAccountReport.OriginalText = "";
      MainContainerHelper.menuItemEmployeeDetailedStatementOfAccountReport.OwnerDraw = true;
      MainContainerHelper.menuItemEmployeeDetailedStatementOfAccountReport.Text = "Staff D&etailed Statement Of Account";
      MainContainerHelper.menuItemEmployeeDetailedStatementOfAccountReport.Click += new EventHandler(MainContainerHelper.menuItemEmployeeDetailedStatementOfAccountReport_Click);
      MainContainerHelper.menuItemDinnerMoneyLetters.ImageIndex = -1;
      MainContainerHelper.menuItemDinnerMoneyLetters.ImageList = (ImageList) null;
      MainContainerHelper.menuItemDinnerMoneyLetters.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) MainContainerHelper.menuItemFreeSchoolMealLetter,
        (MenuItem) MainContainerHelper.menuItemDebtorLetter,
        (MenuItem) MainContainerHelper.menuItemCreditorLetter,
        (MenuItem) MainContainerHelper.menuItemSummaryStatementLetter,
        (MenuItem) MainContainerHelper.menuItemChargeForecastLetter
      });
      MainContainerHelper.menuItemDinnerMoneyLetters.NoEdit = false;
      MainContainerHelper.menuItemDinnerMoneyLetters.NoUIModify = false;
      MainContainerHelper.menuItemDinnerMoneyLetters.OriginalText = "";
      MainContainerHelper.menuItemDinnerMoneyLetters.OwnerDraw = true;
      MainContainerHelper.menuItemDinnerMoneyLetters.Text = "L&etters";
      MainContainerHelper.menuItemFreeSchoolMealLetter.ImageIndex = -1;
      MainContainerHelper.menuItemFreeSchoolMealLetter.ImageList = (ImageList) null;
      MainContainerHelper.menuItemFreeSchoolMealLetter.NoEdit = false;
      MainContainerHelper.menuItemFreeSchoolMealLetter.NoUIModify = false;
      MainContainerHelper.menuItemFreeSchoolMealLetter.OriginalText = "";
      MainContainerHelper.menuItemFreeSchoolMealLetter.OwnerDraw = true;
      MainContainerHelper.menuItemFreeSchoolMealLetter.Text = "&Free School Meal Expiry";
      MainContainerHelper.menuItemFreeSchoolMealLetter.Click += new EventHandler(MainContainerHelper.menuItemFreeSchoolMealLetter_Click);
      MainContainerHelper.menuItemDebtorLetter.ImageIndex = -1;
      MainContainerHelper.menuItemDebtorLetter.ImageList = (ImageList) null;
      MainContainerHelper.menuItemDebtorLetter.NoEdit = false;
      MainContainerHelper.menuItemDebtorLetter.NoUIModify = false;
      MainContainerHelper.menuItemDebtorLetter.OriginalText = "";
      MainContainerHelper.menuItemDebtorLetter.OwnerDraw = true;
      MainContainerHelper.menuItemDebtorLetter.Text = "&Debtor";
      MainContainerHelper.menuItemDebtorLetter.Click += new EventHandler(MainContainerHelper.menuItemDebtorLetter_Click);
      MainContainerHelper.menuItemCreditorLetter.ImageIndex = -1;
      MainContainerHelper.menuItemCreditorLetter.ImageList = (ImageList) null;
      MainContainerHelper.menuItemCreditorLetter.NoEdit = false;
      MainContainerHelper.menuItemCreditorLetter.NoUIModify = false;
      MainContainerHelper.menuItemCreditorLetter.OriginalText = "";
      MainContainerHelper.menuItemCreditorLetter.OwnerDraw = true;
      MainContainerHelper.menuItemCreditorLetter.Text = "&Creditor";
      MainContainerHelper.menuItemCreditorLetter.Click += new EventHandler(MainContainerHelper.menuItemCreditorLetter_Click);
      MainContainerHelper.menuItemSummaryStatementLetter.ImageIndex = -1;
      MainContainerHelper.menuItemSummaryStatementLetter.ImageList = (ImageList) null;
      MainContainerHelper.menuItemSummaryStatementLetter.NoEdit = false;
      MainContainerHelper.menuItemSummaryStatementLetter.NoUIModify = false;
      MainContainerHelper.menuItemSummaryStatementLetter.OriginalText = "";
      MainContainerHelper.menuItemSummaryStatementLetter.OwnerDraw = true;
      MainContainerHelper.menuItemSummaryStatementLetter.Text = "&Summary Statement";
      MainContainerHelper.menuItemSummaryStatementLetter.Click += new EventHandler(MainContainerHelper.menuItemSummaryStatementLetter_Click);
      MainContainerHelper.menuItemChargeForecastLetter.ImageIndex = -1;
      MainContainerHelper.menuItemChargeForecastLetter.ImageList = (ImageList) null;
      MainContainerHelper.menuItemChargeForecastLetter.NoEdit = false;
      MainContainerHelper.menuItemChargeForecastLetter.NoUIModify = false;
      MainContainerHelper.menuItemChargeForecastLetter.OriginalText = "";
      MainContainerHelper.menuItemChargeForecastLetter.OwnerDraw = true;
      MainContainerHelper.menuItemChargeForecastLetter.Text = "C&harge Forecast";
      MainContainerHelper.menuItemChargeForecastLetter.Click += new EventHandler(MainContainerHelper.menuItemChargeForecastLetter_Click);
      MainContainerHelper.menuItemDinnerMoneyAudit.ImageIndex = -1;
      MainContainerHelper.menuItemDinnerMoneyAudit.ImageList = (ImageList) null;
      MainContainerHelper.menuItemDinnerMoneyAudit.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) MainContainerHelper.menuItemAuditLogReport,
        (MenuItem) MainContainerHelper.menuItemCostIncomeSummaryReport
      });
      MainContainerHelper.menuItemDinnerMoneyAudit.NoEdit = false;
      MainContainerHelper.menuItemDinnerMoneyAudit.NoUIModify = false;
      MainContainerHelper.menuItemDinnerMoneyAudit.OriginalText = "";
      MainContainerHelper.menuItemDinnerMoneyAudit.OwnerDraw = true;
      MainContainerHelper.menuItemDinnerMoneyAudit.Text = "&Audit";
      MainContainerHelper.menuItemAuditLogReport.ImageIndex = -1;
      MainContainerHelper.menuItemAuditLogReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemAuditLogReport.NoEdit = false;
      MainContainerHelper.menuItemAuditLogReport.NoUIModify = false;
      MainContainerHelper.menuItemAuditLogReport.OriginalText = "";
      MainContainerHelper.menuItemAuditLogReport.OwnerDraw = true;
      MainContainerHelper.menuItemAuditLogReport.Text = "&Audit Log";
      MainContainerHelper.menuItemAuditLogReport.Click += new EventHandler(MainContainerHelper.menuItemAuditLogReport_Click);
      MainContainerHelper.menuItemCostIncomeSummaryReport.ImageIndex = -1;
      MainContainerHelper.menuItemCostIncomeSummaryReport.ImageList = (ImageList) null;
      MainContainerHelper.menuItemCostIncomeSummaryReport.NoEdit = false;
      MainContainerHelper.menuItemCostIncomeSummaryReport.NoUIModify = false;
      MainContainerHelper.menuItemCostIncomeSummaryReport.OriginalText = "";
      MainContainerHelper.menuItemCostIncomeSummaryReport.OwnerDraw = true;
      MainContainerHelper.menuItemCostIncomeSummaryReport.Text = "&Cost/Income Summary";
      MainContainerHelper.menuItemCostIncomeSummaryReport.Click += new EventHandler(MainContainerHelper.menuItemCostIncomeSummaryReport_Click);
      MainContainerHelper.menuItemReportsSeparator1.ImageIndex = -1;
      MainContainerHelper.menuItemReportsSeparator1.ImageList = (ImageList) null;
      MainContainerHelper.menuItemReportsSeparator1.NoEdit = false;
      MainContainerHelper.menuItemReportsSeparator1.NoUIModify = false;
      MainContainerHelper.menuItemReportsSeparator1.OriginalText = "";
      MainContainerHelper.menuItemReportsSeparator1.OwnerDraw = true;
      MainContainerHelper.menuItemReportsSeparator1.Text = "-";
      MainContainerHelper.menuItemBankingReturn2.ImageIndex = -1;
      MainContainerHelper.menuItemBankingReturn2.ImageList = (ImageList) null;
      MainContainerHelper.menuItemBankingReturn2.NoEdit = false;
      MainContainerHelper.menuItemBankingReturn2.NoUIModify = false;
      MainContainerHelper.menuItemBankingReturn2.OriginalText = "";
      MainContainerHelper.menuItemBankingReturn2.OwnerDraw = true;
      MainContainerHelper.menuItemBankingReturn2.Text = "&Banking Return";
      MainContainerHelper.menuItemBankingReturn2.Click += new EventHandler(MainContainerHelper.menuItemBankingReturn_Click);
      MainContainerHelper.menuItemCateringReturn2.ImageIndex = -1;
      MainContainerHelper.menuItemCateringReturn2.ImageList = (ImageList) null;
      MainContainerHelper.menuItemCateringReturn2.NoEdit = false;
      MainContainerHelper.menuItemCateringReturn2.NoUIModify = false;
      MainContainerHelper.menuItemCateringReturn2.OriginalText = "";
      MainContainerHelper.menuItemCateringReturn2.OwnerDraw = true;
      MainContainerHelper.menuItemCateringReturn2.Text = "&Catering Return";
      MainContainerHelper.menuItemCateringReturn2.Click += new EventHandler(MainContainerHelper.menuItemCateringReturn_Click);
      MainContainerHelper.menuItemStudentDefaultMealPatterns2.ImageIndex = -1;
      MainContainerHelper.menuItemStudentDefaultMealPatterns2.ImageList = (ImageList) null;
      MainContainerHelper.menuItemStudentDefaultMealPatterns2.NoEdit = false;
      MainContainerHelper.menuItemStudentDefaultMealPatterns2.NoUIModify = false;
      MainContainerHelper.menuItemStudentDefaultMealPatterns2.OriginalText = "";
      MainContainerHelper.menuItemStudentDefaultMealPatterns2.OwnerDraw = true;
      MainContainerHelper.menuItemStudentDefaultMealPatterns2.Text = "Default &Meal Patterns";
      MainContainerHelper.menuItemStudentDefaultMealPatterns2.Click += new EventHandler(MainContainerHelper.menuItemStudentDefaultMealPatterns_Click);
      MainContainerHelper.menuItemRoutinesDinnerMoney.ImageIndex = -1;
      MainContainerHelper.menuItemRoutinesDinnerMoney.ImageList = (ImageList) null;
      MainContainerHelper.menuItemRoutinesDinnerMoney.MenuItems.AddRange(new MenuItem[8]
      {
        (MenuItem) MainContainerHelper.menuItemAutofillDefaultMeals,
        (MenuItem) MainContainerHelper.menuItemRoutinesSeparator1,
        (MenuItem) MainContainerHelper.menuItemImportBankingCodes,
        (MenuItem) MainContainerHelper.menuItemImportMealDefinitions,
        (MenuItem) MainContainerHelper.menuItemImportStudentOpeningBalances,
        (MenuItem) MainContainerHelper.menuItemRoutinesSeparator2,
        (MenuItem) MainContainerHelper.menuItemExportBankingCodes,
        (MenuItem) MainContainerHelper.menuItemExportMealDefinitions
      });
      MainContainerHelper.menuItemRoutinesDinnerMoney.NoEdit = false;
      MainContainerHelper.menuItemRoutinesDinnerMoney.NoUIModify = false;
      MainContainerHelper.menuItemRoutinesDinnerMoney.OriginalText = "";
      MainContainerHelper.menuItemRoutinesDinnerMoney.OwnerDraw = true;
      MainContainerHelper.menuItemRoutinesDinnerMoney.Text = "Dinner &Money";
      MainContainerHelper.menuItemAutofillDefaultMeals.ImageIndex = -1;
      MainContainerHelper.menuItemAutofillDefaultMeals.ImageList = (ImageList) null;
      MainContainerHelper.menuItemAutofillDefaultMeals.NoEdit = false;
      MainContainerHelper.menuItemAutofillDefaultMeals.NoUIModify = false;
      MainContainerHelper.menuItemAutofillDefaultMeals.OriginalText = "";
      MainContainerHelper.menuItemAutofillDefaultMeals.OwnerDraw = true;
      MainContainerHelper.menuItemAutofillDefaultMeals.Text = "&Autofill Default Meals";
      MainContainerHelper.menuItemAutofillDefaultMeals.Click += new EventHandler(MainContainerHelper.menuItemAutofillDefaultMeals_Click);
      MainContainerHelper.menuItemRoutinesSeparator1.ImageIndex = -1;
      MainContainerHelper.menuItemRoutinesSeparator1.ImageList = (ImageList) null;
      MainContainerHelper.menuItemRoutinesSeparator1.NoEdit = false;
      MainContainerHelper.menuItemRoutinesSeparator1.NoUIModify = false;
      MainContainerHelper.menuItemRoutinesSeparator1.OriginalText = "";
      MainContainerHelper.menuItemRoutinesSeparator1.OwnerDraw = true;
      MainContainerHelper.menuItemRoutinesSeparator1.Text = "-";
      MainContainerHelper.menuItemImportBankingCodes.ImageIndex = -1;
      MainContainerHelper.menuItemImportBankingCodes.ImageList = (ImageList) null;
      MainContainerHelper.menuItemImportBankingCodes.NoEdit = false;
      MainContainerHelper.menuItemImportBankingCodes.NoUIModify = false;
      MainContainerHelper.menuItemImportBankingCodes.OriginalText = "";
      MainContainerHelper.menuItemImportBankingCodes.OwnerDraw = true;
      MainContainerHelper.menuItemImportBankingCodes.Text = "Import &Banking Codes";
      MainContainerHelper.menuItemImportBankingCodes.Click += new EventHandler(MainContainerHelper.menuItemImportBankingCodes_Click);
      MainContainerHelper.menuItemImportMealDefinitions.ImageIndex = -1;
      MainContainerHelper.menuItemImportMealDefinitions.ImageList = (ImageList) null;
      MainContainerHelper.menuItemImportMealDefinitions.NoEdit = false;
      MainContainerHelper.menuItemImportMealDefinitions.NoUIModify = false;
      MainContainerHelper.menuItemImportMealDefinitions.OriginalText = "";
      MainContainerHelper.menuItemImportMealDefinitions.OwnerDraw = true;
      MainContainerHelper.menuItemImportMealDefinitions.Text = "Import &Meal Definitions";
      MainContainerHelper.menuItemImportMealDefinitions.Click += new EventHandler(MainContainerHelper.menuItemImportMealDefinitions_Click);
      MainContainerHelper.menuItemImportStudentOpeningBalances.ImageIndex = -1;
      MainContainerHelper.menuItemImportStudentOpeningBalances.ImageList = (ImageList) null;
      MainContainerHelper.menuItemImportStudentOpeningBalances.NoEdit = false;
      MainContainerHelper.menuItemImportStudentOpeningBalances.NoUIModify = false;
      MainContainerHelper.menuItemImportStudentOpeningBalances.OriginalText = "";
      MainContainerHelper.menuItemImportStudentOpeningBalances.OwnerDraw = true;
      MainContainerHelper.menuItemImportStudentOpeningBalances.Text = "Import Student &Opening Balances";
      MainContainerHelper.menuItemImportStudentOpeningBalances.Click += new EventHandler(MainContainerHelper.menuItemImportStudentOpeningBalances_Click);
      MainContainerHelper.menuItemRoutinesSeparator2.ImageIndex = -1;
      MainContainerHelper.menuItemRoutinesSeparator2.ImageList = (ImageList) null;
      MainContainerHelper.menuItemRoutinesSeparator2.NoEdit = false;
      MainContainerHelper.menuItemRoutinesSeparator2.NoUIModify = false;
      MainContainerHelper.menuItemRoutinesSeparator2.OriginalText = "";
      MainContainerHelper.menuItemRoutinesSeparator2.OwnerDraw = true;
      MainContainerHelper.menuItemRoutinesSeparator2.Text = "-";
      MainContainerHelper.menuItemExportBankingCodes.ImageIndex = -1;
      MainContainerHelper.menuItemExportBankingCodes.ImageList = (ImageList) null;
      MainContainerHelper.menuItemExportBankingCodes.NoEdit = false;
      MainContainerHelper.menuItemExportBankingCodes.NoUIModify = false;
      MainContainerHelper.menuItemExportBankingCodes.OriginalText = "";
      MainContainerHelper.menuItemExportBankingCodes.OwnerDraw = true;
      MainContainerHelper.menuItemExportBankingCodes.Text = "Export Banking &Codes";
      MainContainerHelper.menuItemExportBankingCodes.Click += new EventHandler(MainContainerHelper.menuItemExportBankingCodes_Click);
      MainContainerHelper.menuItemExportMealDefinitions.ImageIndex = -1;
      MainContainerHelper.menuItemExportMealDefinitions.ImageList = (ImageList) null;
      MainContainerHelper.menuItemExportMealDefinitions.NoEdit = false;
      MainContainerHelper.menuItemExportMealDefinitions.NoUIModify = false;
      MainContainerHelper.menuItemExportMealDefinitions.OriginalText = "";
      MainContainerHelper.menuItemExportMealDefinitions.OwnerDraw = true;
      MainContainerHelper.menuItemExportMealDefinitions.Text = "Export Meal &Definitions";
      MainContainerHelper.menuItemExportMealDefinitions.Click += new EventHandler(MainContainerHelper.menuItemExportMealDefinitions_Click);
      MainContainerHelper.menuItemToolsDinnerMoney.BaseName = "menuItemToolsDinnerMoney";
      MainContainerHelper.menuItemToolsDinnerMoney.ImageIndex = -1;
      MainContainerHelper.menuItemToolsDinnerMoney.ImageList = (ImageList) null;
      MainContainerHelper.menuItemToolsDinnerMoney.MenuItems.AddRange(new MenuItem[12]
      {
        (MenuItem) MainContainerHelper.menuItemBankingCodes,
        (MenuItem) MainContainerHelper.menuItemVATCodes,
        (MenuItem) MainContainerHelper.menuItemToolsSeparator1,
        (MenuItem) MainContainerHelper.menuItemSetup,
        (MenuItem) MainContainerHelper.menuItemToolsSeparator2,
        (MenuItem) MainContainerHelper.menuItemStudentMealDefinitions,
        (MenuItem) MainContainerHelper.menuItemEmployeeMealDefinitions,
        (MenuItem) MainContainerHelper.menuItemAdhocMealDefinitions,
        (MenuItem) MainContainerHelper.menuItemOtherSalesDefinitions,
        (MenuItem) MainContainerHelper.menuItemToolsSeparator3,
        (MenuItem) MainContainerHelper.menuItemUnprocessMeals,
        (MenuItem) MainContainerHelper.menuItemUnlockMealProcessing
      });
      MainContainerHelper.menuItemToolsDinnerMoney.NoEdit = false;
      MainContainerHelper.menuItemToolsDinnerMoney.NoUIModify = false;
      MainContainerHelper.menuItemToolsDinnerMoney.OriginalText = "";
      MainContainerHelper.menuItemToolsDinnerMoney.OwnerDraw = true;
      MainContainerHelper.menuItemToolsDinnerMoney.Text = "Dinne&r Money";
      MainContainerHelper.menuItemBankingCodes.ImageIndex = -1;
      MainContainerHelper.menuItemBankingCodes.ImageList = (ImageList) null;
      MainContainerHelper.menuItemBankingCodes.NoEdit = false;
      MainContainerHelper.menuItemBankingCodes.NoUIModify = false;
      MainContainerHelper.menuItemBankingCodes.OriginalText = "";
      MainContainerHelper.menuItemBankingCodes.OwnerDraw = true;
      MainContainerHelper.menuItemBankingCodes.Text = "&Banking Codes";
      MainContainerHelper.menuItemBankingCodes.Click += new EventHandler(MainContainerHelper.menuItemBankingCodes_Click);
      MainContainerHelper.menuItemVATCodes.ImageIndex = -1;
      MainContainerHelper.menuItemVATCodes.ImageList = (ImageList) null;
      MainContainerHelper.menuItemVATCodes.NoEdit = false;
      MainContainerHelper.menuItemVATCodes.NoUIModify = false;
      MainContainerHelper.menuItemVATCodes.OriginalText = "";
      MainContainerHelper.menuItemVATCodes.OwnerDraw = true;
      MainContainerHelper.menuItemVATCodes.Text = "&VAT Codes";
      MainContainerHelper.menuItemVATCodes.Click += new EventHandler(MainContainerHelper.menuItemVATCodes_Click);
      MainContainerHelper.menuItemToolsSeparator1.ImageIndex = -1;
      MainContainerHelper.menuItemToolsSeparator1.ImageList = (ImageList) null;
      MainContainerHelper.menuItemToolsSeparator1.NoEdit = false;
      MainContainerHelper.menuItemToolsSeparator1.NoUIModify = false;
      MainContainerHelper.menuItemToolsSeparator1.OriginalText = "";
      MainContainerHelper.menuItemToolsSeparator1.OwnerDraw = true;
      MainContainerHelper.menuItemToolsSeparator1.Text = "-";
      MainContainerHelper.menuItemSetup.ImageIndex = -1;
      MainContainerHelper.menuItemSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemSetup.NoEdit = false;
      MainContainerHelper.menuItemSetup.NoUIModify = false;
      MainContainerHelper.menuItemSetup.OriginalText = "";
      MainContainerHelper.menuItemSetup.OwnerDraw = true;
      MainContainerHelper.menuItemSetup.Text = "&Setup";
      MainContainerHelper.menuItemSetup.Click += new EventHandler(MainContainerHelper.menuItemSetup_Click);
      MainContainerHelper.menuItemToolsSeparator2.ImageIndex = -1;
      MainContainerHelper.menuItemToolsSeparator2.ImageList = (ImageList) null;
      MainContainerHelper.menuItemToolsSeparator2.NoEdit = false;
      MainContainerHelper.menuItemToolsSeparator2.NoUIModify = false;
      MainContainerHelper.menuItemToolsSeparator2.OriginalText = "";
      MainContainerHelper.menuItemToolsSeparator2.OwnerDraw = true;
      MainContainerHelper.menuItemToolsSeparator2.Text = "-";
      MainContainerHelper.menuItemStudentMealDefinitions.ImageIndex = -1;
      MainContainerHelper.menuItemStudentMealDefinitions.ImageList = (ImageList) null;
      MainContainerHelper.menuItemStudentMealDefinitions.NoEdit = false;
      MainContainerHelper.menuItemStudentMealDefinitions.NoUIModify = false;
      MainContainerHelper.menuItemStudentMealDefinitions.OriginalText = "";
      MainContainerHelper.menuItemStudentMealDefinitions.OwnerDraw = true;
      MainContainerHelper.menuItemStudentMealDefinitions.Text = "Student &Meal Definitions";
      MainContainerHelper.menuItemStudentMealDefinitions.Click += new EventHandler(MainContainerHelper.menuItemStudentMealDefinitions_Click);
      MainContainerHelper.menuItemEmployeeMealDefinitions.ImageIndex = -1;
      MainContainerHelper.menuItemEmployeeMealDefinitions.ImageList = (ImageList) null;
      MainContainerHelper.menuItemEmployeeMealDefinitions.NoEdit = false;
      MainContainerHelper.menuItemEmployeeMealDefinitions.NoUIModify = false;
      MainContainerHelper.menuItemEmployeeMealDefinitions.OriginalText = "";
      MainContainerHelper.menuItemEmployeeMealDefinitions.OwnerDraw = true;
      MainContainerHelper.menuItemEmployeeMealDefinitions.Text = "Staff M&eal Definitions";
      MainContainerHelper.menuItemEmployeeMealDefinitions.Click += new EventHandler(MainContainerHelper.menuItemEmployeeMealDefinitions_Click);
      MainContainerHelper.menuItemAdhocMealDefinitions.ImageIndex = -1;
      MainContainerHelper.menuItemAdhocMealDefinitions.ImageList = (ImageList) null;
      MainContainerHelper.menuItemAdhocMealDefinitions.NoEdit = false;
      MainContainerHelper.menuItemAdhocMealDefinitions.NoUIModify = false;
      MainContainerHelper.menuItemAdhocMealDefinitions.OriginalText = "";
      MainContainerHelper.menuItemAdhocMealDefinitions.OwnerDraw = true;
      MainContainerHelper.menuItemAdhocMealDefinitions.Text = "Adhoc Me&al Definitions";
      MainContainerHelper.menuItemAdhocMealDefinitions.Click += new EventHandler(MainContainerHelper.menuItemAdhocMealDefinitions_Click);
      MainContainerHelper.menuItemOtherSalesDefinitions.ImageIndex = -1;
      MainContainerHelper.menuItemOtherSalesDefinitions.ImageList = (ImageList) null;
      MainContainerHelper.menuItemOtherSalesDefinitions.NoEdit = false;
      MainContainerHelper.menuItemOtherSalesDefinitions.NoUIModify = false;
      MainContainerHelper.menuItemOtherSalesDefinitions.OriginalText = "";
      MainContainerHelper.menuItemOtherSalesDefinitions.OwnerDraw = true;
      MainContainerHelper.menuItemOtherSalesDefinitions.Text = "Other Sa&les Definitions";
      MainContainerHelper.menuItemOtherSalesDefinitions.Click += new EventHandler(MainContainerHelper.menuItemOtherSalesDefinitions_Click);
      MainContainerHelper.menuItemToolsSeparator3.ImageIndex = -1;
      MainContainerHelper.menuItemToolsSeparator3.ImageList = (ImageList) null;
      MainContainerHelper.menuItemToolsSeparator3.NoEdit = false;
      MainContainerHelper.menuItemToolsSeparator3.NoUIModify = false;
      MainContainerHelper.menuItemToolsSeparator3.OriginalText = "";
      MainContainerHelper.menuItemToolsSeparator3.OwnerDraw = true;
      MainContainerHelper.menuItemToolsSeparator3.Text = "-";
      MainContainerHelper.menuItemUnprocessMeals.ImageIndex = -1;
      MainContainerHelper.menuItemUnprocessMeals.ImageList = (ImageList) null;
      MainContainerHelper.menuItemUnprocessMeals.NoEdit = false;
      MainContainerHelper.menuItemUnprocessMeals.NoUIModify = false;
      MainContainerHelper.menuItemUnprocessMeals.OriginalText = "";
      MainContainerHelper.menuItemUnprocessMeals.OwnerDraw = true;
      MainContainerHelper.menuItemUnprocessMeals.Text = "BackDate Meals &Processed";
      MainContainerHelper.menuItemUnprocessMeals.Click += new EventHandler(MainContainerHelper.menuItemUnprocessMeals_Click);
      MainContainerHelper.menuItemUnlockMealProcessing.ImageIndex = -1;
      MainContainerHelper.menuItemUnlockMealProcessing.ImageList = (ImageList) null;
      MainContainerHelper.menuItemUnlockMealProcessing.NoEdit = false;
      MainContainerHelper.menuItemUnlockMealProcessing.NoUIModify = false;
      MainContainerHelper.menuItemUnlockMealProcessing.OriginalText = "";
      MainContainerHelper.menuItemUnlockMealProcessing.OwnerDraw = true;
      MainContainerHelper.menuItemUnlockMealProcessing.Text = "&Unlock Meal Processing";
      MainContainerHelper.menuItemUnlockMealProcessing.Click += new EventHandler(MainContainerHelper.menuItemUnlockMealProcessing_Click);
      Utilities.ReplaceAllTexts((System.Windows.Forms.Form) null, (IEnumerable<Control>) null, (IEnumerable<Menu>) new Menu[4]
      {
        (Menu) MainContainerHelper.menuItemFocusDinnerMoney,
        (Menu) MainContainerHelper.menuItemReportsDinnerMoney,
        (Menu) MainContainerHelper.menuItemRoutinesDinnerMoney,
        (Menu) MainContainerHelper.menuItemToolsDinnerMoney
      }, (IEnumerable<System.Windows.Forms.ToolBar>) null);
      BaseHtmlReport.AttendanceStyleSheetContents = new GetStyleSheetContentsDelegate(ATWXMLReportProcess.GetAttendanceStyleSheet);
    }

    public static void RebuildMenus()
    {
      string[] processNames1 = new string[2]
      {
        "TakeRegisterSessionProcess",
        "TakeDinnerRegister"
      };
      string[] processNames2 = new string[2]
      {
        "TakeRegisterLessonProcess",
        "TakeDinnerRegister"
      };
      MainContainerHelper.menuItemStudentRecordMeals.Visible = SIMS.Entities.Cache.ProcessVisible(processNames1) || SIMS.Entities.Cache.ProcessVisible(processNames2);
      string[] processNames3 = new string[2]
      {
        "EditSessionMarksProcess",
        "TakeDinnerRegister"
      };
      string[] processNames4 = new string[2]
      {
        "EditLessonMarksProcess",
        "TakeDinnerRegister"
      };
      MainContainerHelper.menuItemStudentEditMeals.Visible = SIMS.Entities.Cache.ProcessVisible(processNames3) || SIMS.Entities.Cache.ProcessVisible(processNames4);
      string[] processNames5 = new string[2]
      {
        "DinnerMoney.BrowseStudents",
        "DinnerMoney.EditStudentPayments"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemStudentPayments, processNames5);
      string[] processNames6 = new string[2]
      {
        "DinnerMoney.BrowseStudents",
        "DinnerMoney.EditStudentDefaultMealPatterns"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemStudentDefaultMealPatterns, processNames6);
      string[] processNames7 = new string[2]
      {
        "DinnerMoney.BrowseStudents",
        "DinnerMoney.EditStudentBalances"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemStudentOpeningBalances, processNames7);
      string[] processNames8 = new string[2]
      {
        "DinnerMoney.BrowseStudent",
        "DinnerMoney.EditStudentAdditionalTransactions"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemStudentAdditionalTransactions, processNames8);
      string[] processNames9 = new string[2]
      {
        "DinnerMoney.BrowseEmployees",
        "DinnerMoney.EditEmployeeMealTakens"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemEmployeeRecordMeals, processNames9);
      string[] processNames10 = new string[2]
      {
        "DinnerMoney.BrowseEmployees",
        "DinnerMoney.EditEmployeePayments"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemEmployeePayments, processNames10);
      string[] processNames11 = new string[2]
      {
        "DinnerMoney.BrowseEmployees",
        "DinnerMoney.EditEmployeeBalances"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemEmployeeOpeningBalances, processNames11);
      string[] processNames12 = new string[2]
      {
        "DinnerMoney.BrowseEmployee",
        "DinnerMoney.EditEmployeeAdditionalTransactions"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemEmployeeAdditionalTransactions, processNames12);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemAdhocMeals, "DinnerMoney.EditAdhocMeals");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemOtherSales, "DinnerMoney.EditOtherSales");
      string[] processNames13 = new string[2]
      {
        "DinnerMoney.BrowseBankingReturn",
        "DinnerMoney.EditBankingReturn"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemBankingReturn, processNames13);
      string[] processNames14 = new string[2]
      {
        "DinnerMoney.BrowseCateringReturn",
        "DinnerMoney.EditCateringReturn"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemCateringReturn, processNames14);
      string[] processNames15 = new string[2]
      {
        "DinnerMoney.ViewManualEntryRegister",
        "DinnerMoney.UpdateCurrentBalances"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemManualEntryDinnerRegister, processNames15);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemKitchenStatisticsReport, "DinnerMoney.ViewKitchenStatisticsReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemDinnerNumbersByWeekReport, "DinnerMoney.ViewDinnerNumbersByWeekReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemYearlyStatisticsReport, "DinnerMoney.ViewYearlyStatisticsReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemSupervisorListReport, "DinnerMoney.ViewSupervisorListReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemSplitPaymentsListReport, "DinnerMoney.ViewSplitPaymentsListReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemChequeAndPaymentDetailListReport, "DinnerMoney.ViewChequeAndPaymentDetailListReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemTransactionListByTypeReport, "DinnerMoney.ViewTransactionListByTypeReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemTransactionListByNumberReport, "DinnerMoney.ViewTransactionListByNumberReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemOpeningBalancesReport, "DinnerMoney.ViewOpeningBalancesReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemStudentBalancesReport, "DinnerMoney.ViewStudentBalancesReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemEmployeeBalancesReport, "DinnerMoney.ViewEmployeeBalancesReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemStudentDetailedStatementOfAccountReport, "DinnerMoney.ViewStudentDetailedStatementOfAccountReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemEmployeeDetailedStatementOfAccountReport, "DinnerMoney.ViewEmployeeDetailedStatementOfAccountReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemFreeSchoolMealLetter, "DinnerMoney.ViewFreeSchoolMealLetter");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemDebtorLetter, "DinnerMoney.ViewDebtorLetter");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemCreditorLetter, "DinnerMoney.ViewCreditorLetter");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemSummaryStatementLetter, "DinnerMoney.ViewSummaryStatementLetter");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemChargeForecastLetter, "DinnerMoney.ViewChargeForecastLetter");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemAuditLogReport, "DinnerMoney.ViewAuditLogReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemCostIncomeSummaryReport, "DinnerMoney.ViewCostIncomeSummaryReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemBankingReturn2, processNames13);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemCateringReturn2, processNames14);
      string[] processNames16 = new string[2]
      {
        "DinnerMoney.BrowseStudents",
        "DinnerMoney.EditStudentDefaultMealPatterns"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemStudentDefaultMealPatterns2, processNames16);
      MainContainerHelper.menuItemAutofillDefaultMeals.Visible = SIMS.Entities.Cache.ProcessVisible("DinnerMoney.AutofillDefaultMeals") && SIMS.Processes.DinnerMoney.AutofillDefaultMeals.CanExecute;
      MainContainerHelper.menuItemImportBankingCodes.Visible = SIMS.Entities.Cache.ProcessVisible("DinnerMoney.ImportBankingCodesWizard") && SIMS.Processes.DinnerMoney.ImportBankingCodesWizard.CanExecute;
      MainContainerHelper.menuItemImportMealDefinitions.Visible = SIMS.Entities.Cache.ProcessVisible("DinnerMoney.ImportMealDefinitionsWizard") && SIMS.Processes.DinnerMoney.ImportMealDefinitionsWizard.CanExecute;
      MainContainerHelper.menuItemImportStudentOpeningBalances.Visible = SIMS.Entities.Cache.ProcessVisible("DinnerMoney.ImportOpeningBalancesWizard") && SIMS.Processes.DinnerMoney.ImportOpeningBalancesWizard.CanExecute;
      MainContainerHelper.menuItemExportBankingCodes.Visible = SIMS.Entities.Cache.ProcessVisible("DinnerMoney.ExportBankingCodesWizard") && SIMS.Processes.DinnerMoney.ExportBankingCodesWizard.CanExecute;
      MainContainerHelper.menuItemExportMealDefinitions.Visible = SIMS.Entities.Cache.ProcessVisible("DinnerMoney.ExportMealDefinitionsWizard") && SIMS.Processes.DinnerMoney.ExportMealDefinitionsWizard.CanExecute;
      string[] processNames17 = new string[2]
      {
        "DinnerMoney.BrowseBankingCode",
        "DinnerMoney.EditBankingCode"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemBankingCodes, processNames17);
      string[] processNames18 = new string[2]
      {
        "DinnerMoney.BrowseVATCode",
        "DinnerMoney.EditVATCode"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemVATCodes, processNames18);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemSetup, "DinnerMoney.EditSetup");
      string[] processNames19 = new string[2]
      {
        "DinnerMoney.BrowseStudentMealDefinition",
        "DinnerMoney.EditStudentMealDefinition"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemStudentMealDefinitions, processNames19);
      string[] processNames20 = new string[2]
      {
        "DinnerMoney.BrowseEmployeeMealDefinition",
        "DinnerMoney.EditEmployeeMealDefinition"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemEmployeeMealDefinitions, processNames20);
      string[] processNames21 = new string[2]
      {
        "DinnerMoney.BrowseAdhocMealDefinition",
        "DinnerMoney.EditAdhocMealDefinition"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemAdhocMealDefinitions, processNames21);
      string[] processNames22 = new string[2]
      {
        "DinnerMoney.BrowseOtherSalesDefinition",
        "DinnerMoney.EditOtherSalesDefinition"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemOtherSalesDefinitions, processNames22);
      MainContainerHelper.menuItemUnprocessMeals.Visible = SIMS.Entities.Cache.ProcessVisible("DinnerMoney.UnprocessMeals") && SIMS.Processes.DinnerMoney.UnprocessMeals.CanExecute;
      MainContainerHelper.menuItemUnlockMealProcessing.Visible = SIMS.Entities.Cache.ProcessVisible("DinnerMoney.UnlockMealProcessing") && SIMS.Processes.DinnerMoney.UnlockMealProcessing.CanExecute;
      bool flag = SIMS.Entities.Cache.Settings["DM7Licensed"] == "T";
      MainContainerHelper.menuItemStudentDefaultMealPatterns.Visible &= flag;
      MainContainerHelper.menuItemStudentDefaultMealPatterns2.Visible &= !flag;
    }

    public static void SetupContextMenus()
    {
      if (SIMS.Entities.Cache.ProcessVisible("DinnerMoney.EditStudentAdditionalTransactions"))
        NavigationRouteCache.AddRoute("Dinner Money Financials", new NavigationRouteDelegate(MainContainerHelper.contextStudentAdditionalTransactions), new int[1]
        {
          4
        }, typeof (EditStudentAdditionalTransactions));
      if (!SIMS.Entities.Cache.ProcessVisible("DinnerMoney.EditEmployeeAdditionalTransactions"))
        return;
      NavigationRouteCache.AddRoute("Dinner Money Financials", new NavigationRouteDelegate(MainContainerHelper.contextEmployeeAdditionalTransactions), new int[1]
      {
        28
      }, typeof (EditEmployeeAdditionalTransactions));
    }

    private static Control DisplayComponent(Control component)
    {
      return MainContainerHelper.displayComponent((IIDEntity) null, component);
    }

    private static void menuItemStudentRecordMeals_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new TakeRegisterContainer(TakeRegisterContainer.InitialTab.DinnerMoney));
    }

    private static void menuItemStudentEditMeals_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new EditMarksContainer(EditMarksContainer.InitialTab.DinnerMoney));
    }

    private static void menuItemStudentPayments_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (SelectPaymentsDateType paymentsDateType = new SelectPaymentsDateType())
      {
        if (paymentsDateType.ShowDialog() != DialogResult.OK)
          return;
        Control control = MainContainerHelper.displayComponentWithInterfaces((Control) new MaintainStudentPayments(paymentsDateType.PaymentDate, paymentsDateType.PaymentType));
      }
    }

    private static void menuItemStudentDefaultMealPatterns_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new MaintainStudentDefaultMealPatterns());
    }

    private static void menuItemStudentOpeningBalances_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new MaintainStudentBalances());
    }

    private static void menuItemStudentAdditionalTransactions_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      MainContainerHelper.DisplayComponent((Control) new MaintainStudentAdditionalTransactions());
    }

    private static void menuItemEmployeeRecordMeals_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new MaintainEmployeeMealTakens());
    }

    private static void menuItemEmployeePayments_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (SelectPaymentsDateType paymentsDateType = new SelectPaymentsDateType())
      {
        if (paymentsDateType.ShowDialog() != DialogResult.OK)
          return;
        Control control = MainContainerHelper.displayComponentWithInterfaces((Control) new MaintainEmployeePayments(paymentsDateType.PaymentDate, paymentsDateType.PaymentType));
      }
    }

    private static void menuItemEmployeeOpeningBalances_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new MaintainEmployeeBalances());
    }

    private static void menuItemEmployeeAdditionalTransactions_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      MainContainerHelper.DisplayComponent((Control) new MaintainEmployeeAdditionalTransactions());
    }

    private static void menuItemAdhocMeals_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (SelectAdhocMealDate selectAdhocMealDate = new SelectAdhocMealDate())
      {
        if (selectAdhocMealDate.ShowDialog() != DialogResult.OK)
          return;
        Control control = MainContainerHelper.displayComponentWithInterfaces((Control) new EditAdhocMeals(selectAdhocMealDate.MealDate));
      }
    }

    private static void menuItemOtherSales_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      Control control = MainContainerHelper.displayComponentWithInterfaces((Control) new EditOtherSales());
    }

    private static void menuItemBankingReturn_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      MainContainerHelper.DisplayComponent((Control) new MaintainBankingReturn());
    }

    private static void menuItemCateringReturn_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      MainContainerHelper.DisplayComponent((Control) new MaintainCateringReturn());
    }

    private static void menuItemKitchenStatisticsReport_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ViewKitchenStatisticsReport statisticsReport = new ViewKitchenStatisticsReport())
      {
        int num = (int) statisticsReport.ShowDialog();
      }
    }

    private static void menuItemDinnerNumbersByWeekReport_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (ViewDinnerNumbersByWeekReport numbersByWeekReport = new ViewDinnerNumbersByWeekReport())
      {
        int num = (int) numbersByWeekReport.ShowDialog();
      }
    }

    private static void menuItemYearlyStatisticsReport_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (ViewYearlyStatisticsReport statisticsReport = new ViewYearlyStatisticsReport())
      {
        int num = (int) statisticsReport.ShowDialog();
      }
    }

    private static void menuItemManualEntryDinnerRegister_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (ViewManualEntryRegister manualEntryRegister = new ViewManualEntryRegister())
      {
        int num = (int) manualEntryRegister.ShowDialog();
      }
    }

    private static void menuItemSupervisorListReport_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ViewSupervisorListReport supervisorListReport = new ViewSupervisorListReport())
      {
        int num = (int) supervisorListReport.ShowDialog();
      }
    }

    private static void menuItemSplitPaymentsListReport_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ViewSplitPaymentsListReport paymentsListReport = new ViewSplitPaymentsListReport())
      {
        int num = (int) paymentsListReport.ShowDialog();
      }
    }

    private static void menuItemChequeAndPaymentDetailListReport_Click(
      object sender,
      EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ViewChequeAndPaymentDetailListReport detailListReport = new ViewChequeAndPaymentDetailListReport())
      {
        int num = (int) detailListReport.ShowDialog();
      }
    }

    private static void menuItemTransactionListByTypeReport_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ViewTransactionListByTypeReport listByTypeReport = new ViewTransactionListByTypeReport())
      {
        int num = (int) listByTypeReport.ShowDialog();
      }
    }

    private static void menuItemTransactionListByNumberReport_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ViewTransactionListByNumberReport listByNumberReport = new ViewTransactionListByNumberReport())
      {
        int num = (int) listByNumberReport.ShowDialog();
      }
    }

    private static void menuItemOpeningBalancesReport_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ViewOpeningBalancesReport openingBalancesReport = new ViewOpeningBalancesReport())
      {
        int num = (int) openingBalancesReport.ShowDialog();
      }
    }

    private static void menuItemStudentBalancesReport_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (ViewStudentBalancesReport studentBalancesReport = new ViewStudentBalancesReport())
      {
        int num = (int) studentBalancesReport.ShowDialog();
      }
    }

    private static void menuItemEmployeeBalancesReport_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (ViewEmployeeBalancesReport employeeBalancesReport = new ViewEmployeeBalancesReport())
      {
        int num = (int) employeeBalancesReport.ShowDialog();
      }
    }

    private static void menuItemStudentDetailedStatementOfAccountReport_Click(
      object sender,
      EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (ViewStudentDetailedStatementOfAccountReport statementOfAccountReport = new ViewStudentDetailedStatementOfAccountReport())
      {
        int num = (int) statementOfAccountReport.ShowDialog();
      }
    }

    private static void menuItemEmployeeDetailedStatementOfAccountReport_Click(
      object sender,
      EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (ViewEmployeeDetailedStatementOfAccountReport statementOfAccountReport = new ViewEmployeeDetailedStatementOfAccountReport())
      {
        int num = (int) statementOfAccountReport.ShowDialog();
      }
    }

    private static void menuItemFreeSchoolMealLetter_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ViewFreeSchoolMealLetter schoolMealLetter = new ViewFreeSchoolMealLetter())
        MainContainerHelper.ShowDinnerMoneyLetterDialogAndLaunchInTouchHostIfRequired((BaseReportCriteria) schoolMealLetter);
    }

    private static void menuItemDebtorLetter_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (ViewDebtorLetter viewDebtorLetter = new ViewDebtorLetter())
        MainContainerHelper.ShowDinnerMoneyLetterDialogAndLaunchInTouchHostIfRequired((BaseReportCriteria) viewDebtorLetter);
    }

    private static void menuItemCreditorLetter_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (ViewCreditorLetter viewCreditorLetter = new ViewCreditorLetter())
        MainContainerHelper.ShowDinnerMoneyLetterDialogAndLaunchInTouchHostIfRequired((BaseReportCriteria) viewCreditorLetter);
    }

    private static void menuItemSummaryStatementLetter_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (ViewSummaryStatementLetter summaryStatementLetter = new ViewSummaryStatementLetter())
        MainContainerHelper.ShowDinnerMoneyLetterDialogAndLaunchInTouchHostIfRequired((BaseReportCriteria) summaryStatementLetter);
    }

    private static void menuItemChargeForecastLetter_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (ViewChargeForecastLetter chargeForecastLetter = new ViewChargeForecastLetter())
        MainContainerHelper.ShowDinnerMoneyLetterDialogAndLaunchInTouchHostIfRequired((BaseReportCriteria) chargeForecastLetter);
    }

    private static void menuItemAuditLogReport_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ViewAuditLogReport viewAuditLogReport = new ViewAuditLogReport())
      {
        int num = (int) viewAuditLogReport.ShowDialog();
      }
    }

    private static void menuItemCostIncomeSummaryReport_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!UpdateCurrentBalances.Execute())
        return;
      using (ViewCostIncomeSummaryReport incomeSummaryReport = new ViewCostIncomeSummaryReport())
      {
        int num = (int) incomeSummaryReport.ShowDialog();
      }
    }

    private static void menuItemAutofillDefaultMeals_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (AutofillDefaultMeals autofillDefaultMeals = new AutofillDefaultMeals())
      {
        int num = (int) autofillDefaultMeals.ShowDialog();
      }
    }

    private static void menuItemImportBankingCodes_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ImportBankingCodesWizard bankingCodesWizard = new ImportBankingCodesWizard())
      {
        int num = (int) bankingCodesWizard.ShowDialog();
      }
    }

    private static void menuItemImportMealDefinitions_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ImportMealDefinitionsWizard definitionsWizard = new ImportMealDefinitionsWizard())
      {
        int num = (int) definitionsWizard.ShowDialog();
      }
    }

    private static void menuItemImportStudentOpeningBalances_Click(object sender, EventArgs e)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      SIMS.Processes.DinnerMoney.Cache.Populate();
      if (!SIMS.Entities.DinnerMoney.Cache.Setup.EditOpeningBalances)
      {
        int num1 = (int) MessageBox.Show("This feature is unavailable because you are not in the first year of implementation.", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num2 = (int) MessageBox.Show("This feature is unavailable because Dinner Money 1.40 is no longer supported.", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private static void menuItemExportBankingCodes_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ExportBankingCodesWizard bankingCodesWizard = new ExportBankingCodesWizard())
      {
        int num = (int) bankingCodesWizard.ShowDialog();
      }
    }

    private static void menuItemExportMealDefinitions_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ExportMealDefinitionsWizard definitionsWizard = new ExportMealDefinitionsWizard())
      {
        int num = (int) definitionsWizard.ShowDialog();
      }
    }

    private static void menuItemBankingCodes_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new MaintainBankingCode());
    }

    private static void menuItemVATCodes_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new MaintainVATCode());
    }

    private static void menuItemSetup_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new EditSetup());
    }

    private static void menuItemStudentMealDefinitions_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new MaintainStudentMealDefinition());
    }

    private static void menuItemEmployeeMealDefinitions_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new MaintainEmployeeMealDefinition());
    }

    private static void menuItemAdhocMealDefinitions_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new MaintainAdhocMealDefinition());
    }

    private static void menuItemOtherSalesDefinitions_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new MaintainOtherSalesDefinition());
    }

    private static void menuItemUnprocessMeals_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (SIMS.Entities.DinnerMoney.Cache.ProcessesInUse("DinnerMoney.EditStudentPayments") || SIMS.Entities.DinnerMoney.Cache.ProcessesInUse("DinnerMoney.EditStudentBalances") || (SIMS.Entities.DinnerMoney.Cache.ProcessesInUse("DinnerMoney.EditEmployeeAdditionalTransactions") || SIMS.Entities.DinnerMoney.Cache.ProcessesInUse("DinnerMoney.EditStudentAdditionalTransactions")) || (SIMS.Entities.DinnerMoney.Cache.ProcessesInUse("DinnerMoney.EditEmployeePayments") || SIMS.Entities.DinnerMoney.Cache.ProcessesInUse("DinnerMoney.EditEmployeeBalances") || (SIMS.Entities.DinnerMoney.Cache.ProcessesInUse("DinnerMoney.EditBankingReturn") || SIMS.Entities.DinnerMoney.Cache.ProcessesInUse("DinnerMoney.EditCateringReturn"))))
      {
        int num1 = (int) MessageBox.Show("There are processing screens or reports open which are preventing this action. Please close all Dinner Money screens and reports with the exception of Record Student Meals, Edit Student Meals and Record Staff Meals.", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        using (UnprocessMeals unprocessMeals = new UnprocessMeals())
        {
          int num2 = (int) unprocessMeals.ShowDialog();
        }
      }
    }

    private static void menuItemUnlockMealProcessing_Click(object sender, EventArgs e)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (UnlockMealProcessing unlockMealProcessing = new UnlockMealProcessing())
      {
        int num = (int) unlockMealProcessing.ShowDialog();
      }
    }

    private static void ShowDinnerMoneyLetterDialogAndLaunchInTouchHostIfRequired(
      BaseReportCriteria reportCriteria)
    {
      if (reportCriteria.ShowDialog() != DialogResult.OK || reportCriteria.DlgRtfLetter == null || reportCriteria.DlgRtfLetter.DataForInTouchHost == null)
        return;
      SIMS.Entities.Cache.HostNewControl((IIDEntity) null, (object) new SendDinnerMoneyLetterMessageHost(reportCriteria.DlgRtfLetter.DataForInTouchHost.Item1, reportCriteria.DlgRtfLetter.DataForInTouchHost.Item2, reportCriteria.DlgRtfLetter.DataForInTouchHost.Item3, reportCriteria.DlgRtfLetter.DataForInTouchHost.Item4, reportCriteria.DlgRtfLetter.DataForInTouchHost.Item5, reportCriteria.DlgRtfLetter.DataForInTouchHost.Item6, reportCriteria.DlgRtfLetter.DataForInTouchHost.Item7));
    }

    private static void contextStudentAdditionalTransactions(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      if (!UpdateCurrentBalances.Execute())
        return;
      MainContainerHelper.DisplayComponent((Control) new EditStudentAdditionalTransactions(entityToDisplay));
    }

    private static void contextEmployeeAdditionalTransactions(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      if (!UpdateCurrentBalances.Execute())
        return;
      MainContainerHelper.DisplayComponent((Control) new EditEmployeeAdditionalTransactions(entityToDisplay));
    }
  }
}
