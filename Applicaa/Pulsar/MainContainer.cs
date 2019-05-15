// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.MainContainer
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using CESOMRUIEXW620;
using DataDynamics.ActiveReports;
using NETXP.Controls.Bars;
using NETXP.Win32;
using SIMS.Entities;
using SIMS.Entities.Admissions;
using SIMS.Entities.OnlineServices;
using SIMS.Processes;
using SIMS.Processes.InTouch;
using SIMS.Processes.Provisioning;
using SIMS.UserInterfaces.Admissions;
using SIMS.UserInterfaces.Admissions.Statutory;
using SIMS.UserInterfaces.DCSWriteback;
using SIMS.UserInterfaces.Discover;
using SIMS.UserInterfaces.Interventions;
using SIMS.UserInterfaces.InTouch;
using SIMS.UserInterfaces.PersonDataOutput;
using SIMS.UserInterfaces.Provisioning;
using SIMS.UserInterfaces.Reports;
using SIMS.UserInterfaces.SLGReports;
using SIMS.UserInterfaces.SystemManager;
using SIMS.Utilities;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace SIMS.UserInterfaces
{
  public class MainContainer : Form
  {
    internal static string simsUpdatingProgramFileName = Path.Combine(Directory.GetCurrentDirectory(), "SOLUS.exe");
    private MaintainCache maintainCache = new MaintainCache();
    private ArrayList NavigationZOrder = new ArrayList();
    private readonly UIMenuItem menuItemA2CSeparator = new UIMenuItem();
    private readonly string base_template_file_dot = Path.GetTempPath() + "\\IndRepBaseTemplate.dot";
    private string DMS_DOWNLOAD_PATH_FILENAME = Path.GetTempPath() + "BaseProfileTemplate.dot";
    private string DMS_DOWNLOAD_PATH_INI_FILENAME = Path.GetTempPath() + "PRWInteropLogin.ini";
    private string ASSESSMENT_MAPPING_COMPONENT_RESOURCE_NEEDED_MSG = "Unable to open the Assessment Mapping Tool as you are missing the Resources needed to use it. Please import the Assessment Resources into SIMS.";
    private const string MAIN_HELP_FILE_NAME = "SIMSnet.chm";
    private const string SUPPORT_HELP_FILE_NAME = "SIMSSupport.chm";
    private const string VIEWER_HELP_FILE_NAME = "SIMSViewer.chm";
    private const string WHATS_NEW_FILE_NAME = "WhatsNew";
    private const string NOSTUDENTSELECTED = "No student selected.";
    private const string INTOUCH_SEND_ATTENDANCE_LETTER = "InTouch.SendStudentAttendanceLettertMessageHost";
    private const string FILE_PATH_NOT_FOUND = "Documentation Index File missing...";
    private const string CURRPT_STUDENT_ANALYSIS_REPORT = "Student &Analysis Reports";
    private const string CURRPT_STUDENT_TOTALS_FOR_YEARGROUPS = "Student Totals for &Year Groups";
    private const string CURRPT_STUDENT_TOTALS_YEAR_BANDS = "Student Totals for Years and &Bands";
    private const string CURRPT_STUDENT_TOTALS_YEAR_REGISTRATION = "Student Totals for Year and &Registration Groups";
    private const string CURRPT_STUDENT_TOTALS_YEAR_VERTICAL_REGISTRATION = "Student Totals for &Vertical Registration Groups";
    private const string CURRPT_STUDENT_TOTALS_YEAR_AGE = "&Age Breakdown for Year Groups";
    private const string CURRPT_STUDENT_TOTALS_CLASSES_YEAR = "Student Totals for &Classes in a Year Group";
    private const string CURRPT_STUDENT_TOTALS_CLASSES_PERIOD = "Classes Active on a Particular &Period";
    private const string CURRPT_STUDENT_TOTALS_EACH_SUBJECT = "Student Totals for &Each Subject";
    private const string CURRPT_STUDENT_TOTALS_PAIRING_ONE = "Pairings for &One Subject";
    private const string CURRPT_STUDENT_TOTALS_ORDERED_PAIRING = "Ordered &Totals for Subject Pairings";
    private const string CURRPT_RUN_PREDEFINED_REPORTS = "RunStudentAnalysisReports";
    public const string ApplicationTitle = "SIMS";
    private const string simsUpdatingProgramParameters = "";
    private const string DMS_UNAVAILABLE = "Unable to find a document server. Please check in Tools, System Setup";
    private const string OFFICE_NOT_SETUP = "Unable to setup the Office path. Please associate the <.doc> files to Microsoft Word application and <.xls> files to Microsoft Excel application.";
    private const string DMS_FAILURE_BASE = "Unable to download the Base Template file. Please close the application and then open it again.";
    private const string ELWA_SUMMER_DEFAULT_FOLDER = "Please use Tools | Statutory Return Tools | Folder Names and Security Message to set up a suitable folder for this statutory return.\nPlease ensure that authorised personnel only have access to this folder as it will contain sensitive data";
    private const string ELWA_DEFAULT_FOLDER = "Please use Tools | PLASC/ELWA Tools | PLASC/ELWA Defaults to setup a suitable folder for this Statutory return";
    private const string WELSH_ATT_COLL_DEFAULT_FOLDER = "Please use Tools | Statutory Return Tools | Folder Names and Security Message to setup a suitable folder for this statutory return.";
    private const string CESEW_COLL_DEFAULT_FOLDER = "Please use Tools | Statutory Return Tools | Folder Names and Security Message to setup a suitable folder for this statutory return.\nPlease ensure that authorised personnel only have access to this folder as it will contain sensitive data";
    private const string MSG_VALID_IND_FOLDER = "Please use Tools | Statutory Return Tools | Independent Return Defaults to setup a suitable folder for the Independent Returns.\nPlease ensure that only authorised personnel have access to the folder locations as they contain sensitive data.";
    private const string MSG_DENI_HOLDING_DRIVE = "DENI holding drive does not exist.\nPlease go to Routines | Statutory Returns | DENI | Change Holding Drive and select a drive.";
    private const string MSG_VALID_ATTENANCE_COLLECTION_MENU = "Primary and Secondary census collections cannot be open at the same time";
    private const string PARENT_LITE_PROMOTIONAL_URL = "https://www.capita-sims.co.uk/products-and-services/sims-parent-lite-app";
    private System.Windows.Forms.StatusBar statusBar;
    private MainMenu mainMenu;
    private Panel panelToolBar;
    private Panel panelOptions;
    private Splitter splitterVertical;
    private StatusBarPanel statusBarPanelMessage;
    private ImageList imageListStatusBar;
    private Panel panelMain;
    private StatusBarPanel statusBarPanelIcon;
    private IContainer components;
    private UIMenuItem focusMenu;
    private UIMenuItem editMenu;
    private UIMenuItem helpMenu;
    private UIMenuItem toolsMenu;
    private UIMenuItem MenuItemStudent;
    private UIMenuItem MenuItemStudentEdit;
    private UIMenuItem MenuItemStudentHistory;
    private UIMenuItem MenuItemDesignReport;
    private UIMenuItem MenuItemReports;
    private UIMenuItem menuItemReportsBehaviour;
    private UIMenuItem menuItemReportsBehaviourRunReportCard;
    private UIMenuItem MenuItemExit;
    private UIMenuItem MenuItemUndo;
    private UIMenuItem MenuItemCut;
    private UIMenuItem MenuItemCopy;
    private UIMenuItem MenuItemPaste;
    private UIMenuItem MenuItemDelete;
    private UIMenuItem MenuItemSelectAll;
    private UIMenuItem MenuItemDocumentServers;
    private UIMenuItem MenuItemContents;
    private UIMenuItem MenuItemSearch;
    private UIMenuItem MenuItemGettingStarted;
    private UIMenuItem MenuItemTechnicalSupport;
    private UIMenuItem MenuItemHowToUseHelp;
    private UIMenuItem menuItemSystemInformation;
    private UIMenuItem MenuItemAbout;
    private UIMenuItem MenuItemRunReport;
    private UIMenuItem menuItemHomework;
    private CommandBar commandBarRight;
    private CommandBar commandBarNavigation;
    private CommandBarButtonItem commandBarButtonItemBack;
    private CommandBarButtonItem commandBarButtonItemForward;
    private CommandBarButtonItem commandBarItemShowLauncher;
    private CommandBarSeparatorItem commandBarSeparatorItemNavigation;
    private UIMenuItem WindowMenu;
    private Launcher2 launcher;
    private UIMenuItem MenuItemCheckForUpdate;
    private bool closingForApplicationUpdate;
    private UIMenuItem MenuItemSchool;
    private UIMenuItem MenuItemSchoolOrganiser;
    private UIMenuItem MenuItemPastoralStructure;
    private UIMenuItem MenuItemCurrentPastoralStructure;
    private UIMenuItem MenuItemNextAcademicYearPastoralStructure;
    private UIMenuItem MenuItemPhotoImportStudentAdNo;
    private UIMenuItem MenuItemPhotoImportStudentRgGp;
    private UIMenuItem MenuItemBreak1;
    private UIMenuItem MenuItemBreak2;
    private UIMenuItem MenuItemBreak4;
    private UIMenuItem MenuItemBreak6;
    private ImageList MenuImages;
    private UIMenuItem MenuItemCalendar;
    private UIMenuItem MenuItemEditAgent;
    private UIMenuItem MenuItemEditAgency;
    private UIMenuItem menuItemLookupMaintenance;
    private UIMenuItem menuItemHomePage;
    private UIMenuItem menuItemCapita;
    private UIMenuItem menuItemSolus;
    private UIMenuItem menuItemCapitamyAccount;
    private UIMenuItem menuItemToolsOptions;
    private UIMenuItem menuItemToolsSeparator;
    private UIMenuItem menuItemSetupMessage;
    private UIMenuItem menuItemDataChangeManagement;
    private UIMenuItem menuItemRooms;
    private UIMenuItem menuItem4;
    private UIMenuItem menuItem24;
    private UIMenuItem menuItemExclusions;
    private UIMenuItem menuItemEmployeeDetails;
    private UIMenuItem menuItemSchoolBase;
    private UIMenuItem menuItemSchoolPromotion;
    private UIMenuItem menuItemStatutoryReturns;
    private UIMenuItem menuItemPLASCDENI;
    private UIMenuItem menuItemRoutinesStudents;
    private UIMenuItem menuItemLeavers;
    private UIMenuItem menuItemExternalSchools;
    private UIMenuItem menuItemPeople;
    private UIMenuItem menuItemToolUploadDocuments;
    private UIMenuItem menuItemToolMaintainDocuments;
    private UIMenuItem menuItemToolMaintainDMS;
    private UIMenuItem menuItemImoprtFromEMS;
    private UIMenuItem menuItemExportToEMS;
    private UIMenuItem menuItem1;
    private UIMenuItem menuItemImportReport;
    private UIMenuItem menuItemExportReport;
    private UIMenuItem menuItemFullSchoolReport;
    private UIMenuItem menuItemPersonDataOutput;
    private UIMenuItem menuItem2;
    private System.Windows.Forms.PictureBox pictureBoxLogo;
    private UIMenuItem menuItemUDFSetup;
    private UIMenuItem menuItemStudentSEN;
    private UIMenuItem menuItemSEN;
    private UIMenuItem menuItemUserOptions;
    private UIMenuItem menuItem12;
    private UIMenuItem menuItemReconcileExamLA;
    private UIMenuItem menuItemReconcileExamEntries;
    private UIMenuItem menuItemStudentCourses;
    private UIMenuItem menuItemUpdateCourseClassification;
    private UIMenuItem menuItemImportQansForCM;
    private UIMenuItem menuItemImportQWADForCM;
    private UIMenuItem menuItemCESEWLookups;
    private UIMenuItem menuItemDuplicateQANReport;
    private UIMenuItem menuItemAcademicYear;
    private UIMenuItem menuItemEditAcademicYear;
    private UIMenuItem menuItemDeleteAcademicYear;
    private UIMenuItem menuItemSchoolDetailsChange;
    private UIMenuItem menuItemConfigurePastoralGroups;
    private UIMenuItem menuItemRoutinesDocuments;
    private ImageList imageListNavigation;
    private UIMenuItem menuItem14;
    private UIMenuItem menuItemConnexionsCard;
    private UIMenuItem menuItemCCardSetup;
    private UIMenuItem menuItemCCardSeperator1;
    private UIMenuItem menuItemCCardholderDetails;
    private UIMenuItem menuItemCCardholderDownload;
    private UIMenuItem menuItemCCardSeperator2;
    private UIMenuItem menuItemCCardAttSummaryExport;
    private UIMenuItem menuItemCCardRequestResponseFile;
    private UIMenuItem menuItemCCardReports;
    private UIMenuItem menuItemCCardAttSummaryExportReport;
    private UIMenuItem menuItemCCardSchemeMembersReport;
    private UIMenuItem menuItemAdmission;
    private UIMenuItem menuItemToolAdmissions;
    private UIMenuItem menuItemAdmissions;
    private UIMenuItem menuItemCoverTools;
    private UIMenuItem menuItemPlasc;
    private UIMenuItem menuItemAttendanceReturnSecondary;
    private UIMenuItem menuItemAttendanceReturnPrimary;
    private UIMenuItem menuItemIntouchUnexplainedAbsence;
    private UIMenuItem menuItemIntouchPercentageAttendanceNotification;
    private UIMenuItem menuItemLateNotification;
    private NotifyIcon notifyIconInformation;
    private NotifyIcon notifyIconWarning;
    private NotifyIcon notifyIconError;
    private UIMenuItem menuItemFilesetImport;
    private UIMenuItem menuItemB2B;
    private UIMenuItem menuItemAgency;
    private UIMenuItem menuItemCommunication;
    private UIMenuItem menuItemDataOut;
    private UIMenuItem menuItemDataIn;
    private UIMenuItem menuItemBatchPhoto;
    private UIMenuItem menuItemMaintainLookup;
    private UIMenuItem menuItemINCASExport;
    private UIMenuItem menuItemRecruitmentAgencyExport;
    private UIMenuItem menuItemRecruitmentAgencyImport;
    private UIMenuItem menuItemCBAExport;
    private UIMenuItem menuItemCTFout;
    private UIMenuItem menuItemCTFin;
    private UIMenuItem menuItemSetups;
    private UIMenuItem menuItemCTFSetup;
    private UIMenuItem menuItemRoutines;
    private UIMenuItem menuItemConnexionsMain;
    private UIMenuItem menuItemStudentConcessions;
    private UIMenuItem menuItemConcessionSetup;
    private UIMenuItem menuItemCurricStudent;
    private UIMenuItem menuItemAcademicStructure;
    private UIMenuItem menuItemToolsAcademic;
    private UIMenuItem menuItemMaintainMedicalEvent;
    public TempFileCollection tempFiles;
    private UIMenuItem menuItemSetupAddresseeFormat;
    private UIMenuItem menuItemUpdateStudentAddressee;
    private UIMenuItem menuItemUpdateParentalAddressee;
    private UIMenuItem menuItemUpdateContactAddressee;
    private UIMenuItem menuItemConfigureEthnicCodes;
    private UIMenuItem menuItemExportLookups;
    private UIMenuItem menuItemUserDefinedGroups;
    private UIMenuItem menuItemGroups;
    private UIMenuItem menuItemPLASCTools;
    private UIMenuItem menuItemHousekeeping;
    private UIMenuItem menuItemSysDiag;
    private UIMenuItem menuItemMembershipFix;
    private UIMenuItem menuItemAuthoriseSIMSPrimaryTransfer;
    private UIMenuItem MenuItemMaintainSIMSServices;
    private UIMenuItem menuItemStudentBulkUpdate;
    private UIMenuItem menuItemPost16Autumn;
    private UIMenuItem menuItemPost16Summer;
    private UIMenuItem menuItemBehaviourMgmt;
    private UIMenuItem menuItemAttendance;
    private UIMenuItem menuItemToolsAttArchiving;
    private UIMenuItem menuItemToolsAttArchivingArchive;
    private UIMenuItem menuItemToolsAttArchivingHistory;
    private UIMenuItem menuItemEmergencyAlertSetup;
    private UIMenuItem menuItemSendEmergencyAlert;
    private UIMenuItem menuItemSchoolOptions;
    private UIMenuItem menuItemInterventions;
    private UIMenuItem menuItemInterventionsReports;
    private UIMenuItem menuItemRoutinesStaffs;
    private UIMenuItem menuItemStaff;
    private UIMenuItem menuItemPersonnelReport;
    private UIMenuItem menuItemStaffPerformanceReport;
    private UIMenuItem menuItemStaffLineManagementReport;
    private UIMenuItem menuItemStaffObservationsReport;
    private UIMenuItem menuItemStaffAnalysisByGradeReport;
    private UIMenuItem menuItemStaffAnalysisByProfessionalStandardReport;
    private UIMenuItem menuItemAuditLogReport;
    private UIMenuItem menuItemAuditLogLineManagementReport;
    private UIMenuItem menuItemAuditLogStaffPerformanceReport;
    private UIMenuItem menuItemImportLookups;
    private UIMenuItem menuItemSetSchoolWorkingDays;
    private int activeComponent;
    private bool plascloaded;
    private bool m_SchoolCensusLoaded;
    private bool elwaloaded;
    private UIMenuItem menuItemToolsCurriculum;
    private bool m_DENILoaded;
    private bool m_SWCLoaded;
    private int attendanceReturnRunMode;
    private bool isLoaded;
    private UIMenuItem menuItemStudentAnalysis;
    private UIMenuItem menuItemPupilPremium;
    private UIMenuItem menuItemPupilPremiumImport;
    private UIMenuItem menuItemPupilPremiumMaintain;
    private UIMenuItem menuItemEMA;
    private UIMenuItem menuItemEMASetup;
    private ImageList imageListOfflineShortcuts;
    private UIMenuItem menuItemCommentEntry;
    private UIMenuItem menuItemMarksheet;
    private UIMenuItem menuItemDeleteStudent;
    private UIMenuItem menuItemB2BPersonnel;
    private UIMenuItem menuItemB2BStudent;
    private UIMenuItem menuItemB2BFieldProcessing;
    private UIMenuItem menuItemB2BAuthoriseChanges;
    private UIMenuItem menuItemB2BSuspension;
    private UIMenuItem menuItemB2BImportALLEmployee;
    private UIMenuItem menuItemB2BExportALLEmployee;
    private UIMenuItem menuItemShowLauncher;
    private UIMenuItem menuItemFees;
    private UIMenuItem menuItemFeesBillingTools;
    private UIMenuItem menuItemFeesBillingRoutines;
    private UIMenuItem menuItemChangeEnrolmentStatus;
    private UIMenuItem menuItemNDCWales;
    private UIMenuItem menuItemFocusProfiles;
    private UIMenuItem menuItemFocusASM;
    private UIMenuItem menuItemReportProfiles;
    private UIMenuItem menuItemReportAssessment;
    private UIMenuItem menuItemToolsASMTools;
    private UIMenuItem menuItemToolsPAAnalysis;
    private UIMenuItem menuItemToolsPATools;
    private UIMenuItem menuItemToolsProfilesTools;
    private UIMenuItem menuItemDataOutASM;
    private UIMenuItem menuItemDataOutPA;
    private UIMenuItem menuItemDataInPA;
    private UIMenuItem menuItemDataInASM;
    private UIMenuItem menuItemSeperator1;
    private UIMenuItem menuItemExamsA2CCommunications;
    private UIMenuItem menuItemExamsA2CGRPProcesses;
    private UIMenuItem menuItemExamsA2CViewProductCatalogue;
    private UIMenuItem menuItemExamsA2CSubmitOrders;
    private UIMenuItem menuItemExamsA2CSubmitCoursework;
    private UIMenuItem menuItemExamsA2CAmendLearnerDetails;
    private UIMenuItem menuItemExamsA2CSummary;
    private UIMenuItem menuItemExamsA2CGRPTools;
    private UIMenuItem menuItemExamsA2CLoadProductCatalogue;
    private UIMenuItem menuItemExamsA2CLoadResults;
    private UIMenuItem menuItemExamsA2CSettings;
    private UIMenuItem menuItemBulkAddressTools;
    private UIMenuItem menuItemBulkAddressValidationScheduler;
    private UIMenuItem menuItemBABulkAddressValidationSchedule;
    private UIMenuItem menuItemBABulkAddressValidation;
    private UIMenuItem menuItemBAVOtherSchools;
    private UIMenuItem menuItemBAVApplicantsAndContacts;
    private UIMenuItem menuItemBAVStudentsAndContacts;
    private UIMenuItem menuItemBAVEnquierAddress;
    private UIMenuItem menuItemBAVStaff;
    private UIMenuItem menuItemBAVAgents;
    private UIMenuItem menuItemBAVAgencies;
    private UIMenuItem menuItemTidyAndMergeAddresses;
    private UIMenuItem menuItemUnmatchableAddressesReport;
    private UIMenuItem menuItemAddressTidyAndMergeSetup;
    private UIMenuItem menuASCIS;
    private UIMenuItem menuISC;
    private int updateDepth;
    private ParameterlessDelegate closeSplashScreen;
    private bool autoStartItemLaunched;
    private Control controlActiveBeforeLauncherActivated;
    private bool statusBarMenuItemHelpDescriptions;
    private System.Drawing.Icon statusBarPanelIconIcon;
    private string statusBarPanelMessageText;
    private HomePageDetail homepage;
    private UIMenuItem menuItemApplication;
    private UIMenuItem menuItemEnquiry;
    private UIMenuItem menuItemInternalVisit;
    private UIMenuItem menuItemAdmissionGroups;
    private UIMenuItem menuItemSetupAdmissionGroups;
    private UIMenuItem menuItemTransferApplicants;
    private UIMenuItem menuItemFinaliseOffers;
    private UIMenuItem menuItemAcceptApplications;
    private UIMenuItem menuItemAdmitApplications;
    private UIMenuItem menuItemRecordApplicationCriteria;
    private UIMenuItem menuItemASLEntry;
    private UIMenuItem menuItemImportADTFile;
    private UIMenuItem menuItemExportASLFile;
    private UIMenuItem menuItemImportATFFile;
    private UIMenuItem menuItemADMImportEnquiry;
    private UIMenuItem menuItemADMImportApplication;
    private UIMenuItem menuItemSetupAdmissionDefaults;
    private UIMenuItem menuItemSetupAdmissionCriterion;
    private UIMenuItem menuItemSetupAdmissionPolicy;
    private UIMenuItem menuItemCurrSchemeDetails;
    private UIMenuItem menuItemCurrStudentDetails;
    private UIMenuItem menuItemCurrWholeDetails;
    private UIMenuItem menuItemCurrEditLesson;
    private UIMenuItem menuItemCurrRotateResources;
    private UIMenuItem menuItemCurrSetAcademicYear;
    private UIMenuItem menuItemSetCurrentTier;
    private UIMenuItem menuItemCurrUpdateCourseMembers;
    private UIMenuItem menuItemCurrCourseManagerBulkUpdate;
    private UIMenuItem menuItemCurrStudentCourseReport;
    private UIMenuItem menuItemCurrProgrammeOfStudy;
    private UIMenuItem menuItemCurrCourseManagerSettings;
    private UIMenuItem menuItemCurrAssignablePeople;
    private UIMenuItem menuItemCurrApplyTimetable;
    private UIMenuItem menuItemCurrDefineTimetableCycle;
    private UIMenuItem menuItemCurrSetup;
    private UIMenuItem menuItemAcademicPromotion;
    private UIMenuItem menuItemCurrEditScheme;
    private UIMenuItem menuItemCurrViewLessonList;
    private UIMenuItem menuItemCurrStudentSummary;
    private UIMenuItem menuItemCourseManager;
    private UIMenuItem menuItemMaintainCourse;
    private UIMenuItem menuItemNewMaintainCourse;
    private UIMenuItem menuItemMaintainCourseClassification;
    private UIMenuItem menuItemCourseManagerSetup;
    private UIMenuItem menuItemConfigureSetting;
    private UIMenuItem menuItemMaintainTasks;
    private UIMenuItem menuItemTaskLog;
    private UIMenuItem menuItemSuspenseProcessing;
    private UIMenuItem menuItemCTFExportLog;
    private UIMenuItem menuItemRunCTFExport;
    private UIMenuItem menuItemCTFImport;
    private UIMenuItem menuItemCTFImportLog;
    private UIMenuItem menuItemUpdatePLASCClassType;
    private UIMenuItem menuItemPlascBasicSkills;
    private UIMenuItem menuItemUpdateHoursAtSetting;
    private UIMenuItem menuItemUpdateTopupFunding;
    private UIMenuItem menuItemAdoptedFromCare;
    private UIMenuItem menuItemPriorAttainment;
    private UIMenuItem menuItemUpdateTimeInUnit;
    private UIMenuItem menuItemUpdateProviderStatus;
    private UIMenuItem menuItemAuthorisedCensus;
    private UIMenuItem menuItemSchoolCensus;
    private UIMenuItem menuItemSchoolsWorkforceReturn;
    private UIMenuItem menuItemSchoolsCESEWReturn;
    private UIMenuItem menuItemSchoolsWorkforceReturnDefaults;
    private UIMenuItem menuItemWelshAttendanceCollection;
    private UIMenuItem menuItemWelshAttendanceCollectionMiddle;
    private UIMenuItem menuItemPrepareDENIReturn;
    private UIMenuItem menuItemCreateDENIReturn;
    private UIMenuItem menuItemCreateLeaversReturn;
    private UIMenuItem menuItemViewDENILog;
    private UIMenuItem menuItemChangeDrive;
    private UIMenuItem menuItemDENISeparator;
    private UIMenuItem menuItemStudentEMADetails;
    private UIMenuItem menuItemCreateAuthoriseWeeklyPayments;
    private UIMenuItem menuItemCreateAuthoriseBonusPayments;
    private UIMenuItem menuItemExportsToAPB;
    private UIMenuItem menuItemEnrolmentExport;
    private UIMenuItem menuItemWeeklyAuthorisationsExport;
    private UIMenuItem menuItemBonusesExport;
    private UIMenuItem menuItemAuditSummary;
    private UIMenuItem menuItemPendingAPBResponse;
    private UIMenuItem menuItemELWAPlascDefaults;
    private UIMenuItem menuItemRunSQLDiagnostics;
    private UIMenuItem menuItemSynchronize;
    private UIMenuItem menuItemManageConflicts;
    private UIMenuItem menuItemUserProfileSetup;
    private UIMenuItem menuItemOfflineDatabase;
    private UIMenuItem menuItemNDCResultsKeyStage2;
    private UIMenuItem menuItemNDCResultsKeyStage3;
    private UIMenuItem menuItemNDCResultsFoundationOutcome;
    private UIMenuItem menuItemNDCResultsNRT;
    private UIMenuItem menuItemNDCResults;
    private UIMenuItem menuItemNDCResultsNRTImport;
    private UIMenuItem menuItemNDCResultsBaselineAssessment;
    private UIMenuItem menuItemNDCNIResultsImport;
    private UIMenuItem menuItemNDCNIResultsExport;
    private bool m_ExportNDCResultLoaded;
    private UIMenuItem menuItemASCIS;
    private UIMenuItem menuItemISC;
    private UIMenuItem menuItemIndependentReturnDefaults;
    private UIMenuItem menuItemVLEOut;
    private UIMenuItem menuItemVLEExportLog;
    private UIMenuItem menuItemASMMarksheetEntry;
    private UIMenuItem menuItemASMOMREntry;
    private UIMenuItem menuItemASMIndividualReport;
    private UIMenuItem menuItemSeperator2;
    private UIMenuItem menuItemSeperator3;
    private UIMenuItem menuItemASMGradeSet;
    private UIMenuItem menuItemASMAspect;
    private UIMenuItem menuItemASMResultSet;
    private UIMenuItem menuItemLookUpTables;
    private UIMenuItem menuItemASMTemplate;
    private UIMenuItem menuItemASMOMRTemplate;
    private UIMenuItem menuItemFFTEstimates;
    private UIMenuItem menuItemPAGroupAnalysis;
    private UIMenuItem menuItemPAAspectAnalysis;
    private UIMenuItem menuItemPAResultSetAnalysis;
    private UIMenuItem menuItemPAChanceAnalysis;
    private UIMenuItem menuItemSeperator4;
    private UIMenuItem menuItemPATrendAnalysis;
    private UIMenuItem menuItemPATrendAnalysisReview;
    private UIMenuItem menuItemPATrendAnalysisPrediction;
    private UIMenuItem menuItemPATrackingSeparator;
    private UIMenuItem menuItemPATrackingTemplate;
    private UIMenuItem menuItemPATrackingGrid;
    private UIMenuItem menuItemAPPGridTemplate;
    private UIMenuItem menuItemAPPGridEntry;
    private UIMenuItem menuItemTPPGridEntry;
    private UIMenuItem menuItemPoSManagement;
    private UIMenuItem menuItemPoSManagingContent;
    private UIMenuItem menuItemPoSManagingGrades;
    private UIMenuItem menuItemProfilesCommentBanks;
    private UIMenuItem menuItemProfilesDataEntry;
    private UIMenuItem menuItemProfilesDataEntryListEntry;
    private UIMenuItem menuItemProfilesDataEntryGridEntry;
    private UIMenuItem menuItemProfilesDataEntryOMREntry;
    private UIMenuItem menuItemProfilesStudentProfiles;
    private UIMenuItem menuItemProfilesReviewProfiles;
    private UIMenuItem menuItemProfilesCommentUsageAnalysis;
    private UIMenuItem menuItemProfilesMissingEntriesReport;
    private UIMenuItem menuItemProfilesAreasNotApprovedReport;
    private UIMenuItem menuItemDataOutASMExport;
    private UIMenuItem menuItemDataOutASMWResourceUtilityExport;
    private UIMenuItem menuItemDataOutPAExport;
    private UIMenuItem menuItemDataInPAImport;
    private UIMenuItem menuItemDataInASMImport;
    private UIMenuItem menuItemDataInASMImportFromSpreadsheet;
    private UIMenuItem menuItemDataInFFTImport;
    private UIMenuItem menuItemASMToolsCategory;
    private UIMenuItem menuItemASMToolsTemplateConversion;
    private UIMenuItem menuItemASMToolsSystemUtilities;
    private UIMenuItem menuItemASMToolsWizardManager;
    private UIMenuItem menuItemASMToolsAssessmentMapping;
    private UIMenuItem menuItemASMToolsSystemUtilitiesAspects;
    private UIMenuItem menuItemASMToolsSystemUtilitiesGradeSets;
    private UIMenuItem menuItemASMToolsSystemUtilitiesTemplates;
    private UIMenuItem menuItemASMToolsSystemUtilitiesMarksheets;
    private UIMenuItem menuItemASMToolsSystemUtilitiesResults;
    private UIMenuItem menuItemASMToolsSystemUtilitiesOMRTemplates;
    private UIMenuItem menuItemASMToolsSystemUtilitiesOMRSheets;
    private UIMenuItem menuItemASMToolsSystemUtilitiesIndividualReports;
    private UIMenuItem menuItemASMToolsSystemUtilitiesResultSets;
    private UIMenuItem menuItemReportAssessmentMissingResults;
    private UIMenuItem menuItemReportPoS;
    private UIMenuItem menuItemReportPoSSubjectStrandIndividual;
    private UIMenuItem menuItemPoSAnalysisSummativeAttainment;
    private UIMenuItem menuItemPoSAnalysisFormativeAttainment;
    private UIMenuItem menuItemPoSAnalysisSummativeProgress;
    private UIMenuItem menuItemPoSAnalysisFormativeProgress;
    private UIMenuItem menuItemAssessmentPoSAnalysis;
    private UIMenuItem menuItemASMToolsSystemUtilitiesKSMWizards;
    private UIMenuItem menuItemSeperator7;
    private UIMenuItem menuItemSeperator8;
    private UIMenuItem menuItemASMToolsOptions;
    private UIMenuItem menuItemASMToolsFFTOptions;
    private UIMenuItem menuItemPAToolsValueAddedLines;
    private UIMenuItem menuItemPAToolsProgressionLines;
    private UIMenuItem menuItemSeperator9;
    private UIMenuItem menuItemPAToolsSystemUtilities;
    private UIMenuItem menuItemSeperator10;
    private UIMenuItem menuItemPAToolsBuildExamAnalysis;
    private UIMenuItem menuItemPAToolsDefineSettings;
    private UIMenuItem menuItemProfilesToolsCompareCommentBanks;
    private UIMenuItem menuItemProfilesToolsBatchPrintingOfClassCheckSheets;
    private UIMenuItem menuItemProfilesMissingComments;
    private UIMenuItem menuItemProfilesSessionManager;
    private UIMenuItem menuItemProfilesUDG;
    private UIMenuItem menuItemAssManUDG;
    private UIMenuItem menuItemOMRSetup;
    private UIMenuItem menuItemPAToolsSystemUtilitiesTrendLines;
    private UIMenuItem menuItemPAToolsSystemUtilitiesTrackingTemplates;
    private UIMenuItem menuItemPAToolsSystemUtilitiesTrackingGrids;
    private UIMenuItem menuItemPAToolsSystemUtilitiesAnalysisResources;
    private UIMenuItem menuItemAMPASep1;
    private UIMenuItem menuItemFFTSeparator;
    private UIMenuItem menuItemProfilesToolsAddNamesToDictionary;
    private UIMenuItem menuItemStudBehaviour;
    private UIMenuItem menuItemBehaviourIncident;
    private UIMenuItem menuItemAchievement;
    private UIMenuItem menuItemDetention;
    private UIMenuItem menuItemBehaviourType;
    private UIMenuItem menuItemBehaviourRoleType;
    private UIMenuItem menuItemAchievementType;
    private UIMenuItem menuItemDetentionType;
    private UIMenuItem menuItemReportCard;
    private UIMenuItem menuItemBehaviourManagement;
    private UIMenuItem menuItemReportCardTemplate;
    private UIMenuItem menuItemAchievementNotifications;
    private UIMenuItem menuItemBehaviourNotifications;
    private UIMenuItem menuItemIntervPlanIntervention;
    private UIMenuItem menuItemIntervRunIntervention;
    private UIMenuItem menuItemIntervSchoolInterventionReport;
    private UIMenuItem menuItemIntervOutcomeAnalysisReport;
    private UIMenuItem menuItemIntervStudentInterventionReport;
    private UIMenuItem menuItemIntervCostAnalysisReport;
    private UIMenuItem menuItemDeleteUnlinkedContacts;
    private UIMenuItem menuItemHousekeepingGeneral;
    private UIMenuItem menuItemMergeAgencies;
    private UIMenuItem menuItemMergeAgents;
    private UIMenuItem menuItemAttendanceReports;
    private UIMenuItem menuItemAttendanceSetup;
    private UIMenuItem menuItemLessonMonitorOptions;
    private UIMenuItem menuItemAttendanceRoutines;
    private UIMenuItem menuItemAttendanceModuleSetup;
    private UIMenuItem menuItemAttendanceOMRSetup;
    private UIMenuItem menuItemATWRegistrationOrganisation;
    private UIMenuItem menuItemCodes;
    private UIMenuItem menuItemMaintainCodes;
    private UIMenuItem menuItemLateCodes;
    private UIMenuItem menuItemPartTimePupils;
    private UIMenuItem menuItemLetterDefinition;
    private UIMenuItem menuItemEditQuickLetter;
    private UIMenuItem menuItemTakeRegister;
    private UIMenuItem menuItemDisplayAttendanceMarks;
    private UIMenuItem menuItemSeparatorAttendanceFocus;
    private UIMenuItem menuItemEditMarks;
    private UIMenuItem menuItemUnexplainedAbsences;
    private UIMenuItem menuItemDisplayMissingMarks;
    private UIMenuItem menuItemCodeOverDateRange;
    private UIMenuItem menuItemEnterWeeklyPattern;
    private UIMenuItem menuItemLessonMonitorReportLaunch;
    private UIMenuItem menuItemExceptionalCircumstances;
    private UIMenuItem menuItemOMR;
    private UIMenuItem menuItemPrintOMRRegistrationSheet;
    private UIMenuItem menuItemPrintOMRRegistrationSheetWeekendSession;
    private UIMenuItem menuItemPrintOMRAbsenceSheet;
    private UIMenuItem menuItemReadOMRRegistrationSheet;
    private UIMenuItem menuItemReadOMRAbsenceSheet;
    private UIMenuItem menuItemConflictingLessonMarks;
    private UIMenuItem menuItemConflictingSessionMarks;
    private UIMenuItem menuItemExtraNames;
    private UIMenuItem menuItemEditReasonForChange;
    private UIMenuItem menuItemLessonMonitorSetup;
    private UIMenuItem menuItemEarliestMarksSetup;
    private UIMenuItem menuItemIndividualStudentReports;
    private UIMenuItem menuItemWholeGroupStudentReports;
    private UIMenuItem menuItemSelectedStudentReports;
    private UIMenuItem menuItemGroupReports;
    private UIMenuItem menuItemModuleReports;
    private UIMenuItem menuItemLetters;
    private UIMenuItem menuItemManualEntry;
    private UIMenuItem menuItemIndividualRegisterReport;
    private UIMenuItem menuItemIndividualAttendanceSummary;
    private UIMenuItem menuItemFullRegisterReport;
    private UIMenuItem menuItemClassRegisterReport;
    private UIMenuItem menuItemLessonMarksbyCategory;
    private UIMenuItem menuItemGroupAnalysisByAttendanceCategory;
    private UIMenuItem menuItemLessonAbsencesReport;
    private UIMenuItem menuItemLessonAttendancebySubjects;
    private UIMenuItem menuItemMinutesLateReport;
    private UIMenuItem menuItemLessonAttendancebyClassesReport;
    private UIMenuItem menuItemPercentageAttendanceReport;
    private UIMenuItem menuItemCommentsReport;
    private UIMenuItem menuItemPostRegAbsenceReport;
    private UIMenuItem menuItemHistoryOfChangesReport;
    private UIMenuItem menuItemStudentWeeklyLessonAttendanceReport;
    private UIMenuItem menuItemPeriodsWithChosenCodeReport;
    private UIMenuItem menuItemMealListReport;
    private UIMenuItem menuItemRegistersWithMissingMarksReport;
    private UIMenuItem menuItemCompareMarksbyColumnReport;
    private UIMenuItem menuItemTodaysRegisterReport;
    private UIMenuItem menuItemGroupWeeklyLessonAttendanceReport;
    private UIMenuItem menuItemNewAbsenteesReport;
    private UIMenuItem menuItemJointAbsenceDetection;
    private UIMenuItem menuItemSiblingAbsenceDetection;
    private UIMenuItem menuItemRegisterCertificateReport;
    private UIMenuItem menuItemSchoolProspectusAnalysis;
    private UIMenuItem menuItemPupilsSchoolCareerAttendance;
    private UIMenuItem menuItemSessionMissingMarks;
    private UIMenuItem menuItemIndividualSummaryReport;
    private UIMenuItem menuItemContinuousAbsenceReport;
    private UIMenuItem menuItemSessionAbsencesReport;
    private UIMenuItem menuItemOfficialRegisterReport;
    private UIMenuItem menuItemUnexplainedAbsencesReport;
    private UIMenuItem menuItemFirstDayofAbsenceReport;
    private UIMenuItem menuItemPupilsYearlyAttendance;
    private UIMenuItem menuItemPupilAnalysisByAMPM;
    private UIMenuItem menuItemBrokenWeekReport;
    private UIMenuItem menuItemGroupAnalysisbyCodeReport;
    private UIMenuItem menuItemPupilAnalysisBySessionInWeek;
    private UIMenuItem menuItemGroupSessionSummary;
    private UIMenuItem menuItemWelshSchoolPerformanceInformation;
    private UIMenuItem menuItemGroupWeeklyAnalysisReport;
    private UIMenuItem menuItemPupilAnalysisByAttendanceCode;
    private UIMenuItem menuItemGroupAnalysisbyAMPMReport;
    private UIMenuItem menuItemMissedCurriculumReport;
    private UIMenuItem menuItemGroupAnalysisBySessionInWeekReport;
    private UIMenuItem menuItemPupilswithChosenCodeReport;
    private UIMenuItem menuItemGroupAnalysisbySTARFieldReport;
    private UIMenuItem menuItemGroupAnalysisbyVulnerabilityReport;
    private UIMenuItem menuItemPrintLetters;
    private UIMenuItem menuItemLettersCreated;
    private UIMenuItem menuItemPrintRegistrationSheet;
    private UIMenuItem menuItemPrintAbsenceSheet;
    private UIMenuItem menuItemPersistentAbsenceReport;
    private UIMenuItem menuItemPersistentAbsenceStudentThreshold;
    private UIMenuItem menuItemAttendanceReportSeperator1;
    private UIMenuItem menuItemAttendanceReportSeperator2;
    private UIMenuItem menuItemAttendanceReportSeperator3;
    private UIMenuItem menuItemAttendanceReportSeperator4;
    private UIMenuItem menuItemAttendanceReportSeperator5;
    private UIMenuItem menuItemAttendanceReportSeperator6;
    private UIMenuItem menuItemAttendanceReportSeperator7;
    private UIMenuItem menuItemAttendanceReportSeperator8;
    private UIMenuItem menuItemNIClosingReport;
    private UIMenuItem menuItemAbsenceAnalysis;
    private UIMenuItem menuItemIndividualAbsence;
    private UIMenuItem menuItemLongTermAbsenceAnalysis;
    private UIMenuItem menuItemContractAnalysis;
    private UIMenuItem menuItemContractInformation;
    private UIMenuItem menuItemSalaryInformation;
    private UIMenuItem menuItemStaffTraining;
    private UIMenuItem menuItemTrainingCourse;
    private UIMenuItem menuItemTerminatingContracts;
    private UIMenuItem menuItemDeleteStaff;
    private UIMenuItem menuItemTraining;
    private UIMenuItem menuItemPayRelated;
    private UIMenuItem menuItemAnnualIncrement;
    private UIMenuItem menuItemSalaryRangeUpdate;
    private UIMenuItem menuItemSuperannuation;
    private UIMenuItem menuItemNationalInsuranceRates;
    private UIMenuItem menuItemPayRelatedImport;
    private UIMenuItem menuItemPayRelatedExport;
    private UIMenuItem menuItemPerformanceManagement;
    private UIMenuItem menuItemSPSchoolSetup;
    private UIMenuItem menuItemLineManagementStructure;
    private UIMenuItem menuItemCurrLessPlannerFocus;
    private UIMenuItem menuItemCLPStudyTopics;
    private UIMenuItem menuItemCLPSchoolPlans;
    private UIMenuItem menuItemCLPSubjectPlans;
    private UIMenuItem menuItemCLPCohortPlans;
    private UIMenuItem menuItemCLPLessonPlans;
    private UIMenuItem menuItemCurrLessPlannerRoutines;
    private UIMenuItem menuItemImportCLPStudyTopics;
    private UIMenuItem menuItemImportCLPPoSRequirements;
    private UIMenuItem menuItemImportCLPLearningObjectives;
    private UIMenuItem menuItemCurrLessPlannerTools;
    private UIMenuItem menuItemCLPSetup;
    private UIMenuItem menuItemCLPSubjects;
    private UIMenuItem menuItemCLPPlanningCohorts;
    private UIMenuItem menuItemCLPPoSRequirements;
    private UIMenuItem menuItemCLPLearningObjectives;
    private UIMenuItem menuItemAlerts;
    private UIMenuItem menuItemAlertsSetupReminders;
    private UIMenuItem menuItemAlertsScheduleReports;
    private UIMenuItem menuItemPersonalTask;
    private UIMenuItem menuItemGeneralMessages;
    private UIMenuItem menuItemSetupSLGUsers;
    private UIMenuItem menuItemSLGExportUsers;
    private UIMenuItem menuItemSLGExportingUsers;
    private UIMenuItem menuItemApplyCharges;
    private UIMenuItem menuItemSurchargeCalculation;
    private UIMenuItem menuItemChargeBatchReport;
    private UIMenuItem menuItemUpdateBills;
    private UIMenuItem menuItemGlobalUpdateOfCharges;
    private UIMenuItem menuItemAmendBillDetails;
    private UIMenuItem menuItemBreakFees1;
    private UIMenuItem menuItemBreakFees2;
    private UIMenuItem menuItemBreakFees3;
    private UIMenuItem menuItemBreakFees4;
    private UIMenuItem menuItemBreakFees5;
    private UIMenuItem menuItemBreakFees6;
    private UIMenuItem menuItemBreakFees7;
    private UIMenuItem menuItemBreakFees8;
    private UIMenuItem menuItemBreakFees9;
    private UIMenuItem menuItemBreakFees10;
    private UIMenuItem menuItemAssignBillNumbers;
    private UIMenuItem menuItemAddNotesToBill;
    private UIMenuItem menuItemPrintBills;
    private UIMenuItem menuItemCopyBills;
    private UIMenuItem menuItemMiscellaneousChargeSheet;
    private UIMenuItem menuItemPreviousBills;
    private UIMenuItem menuItemTermEnd;
    private UIMenuItem menuItemTransferBills;
    private UIMenuItem menuItem49menuItemProcessTransaction;
    private UIMenuItem menuItemAuditReport;
    private UIMenuItem menuItemUpdatePayers;
    private UIMenuItem menuItemRefundCreditBalances;
    private UIMenuItem menuItemStandingOrders;
    private UIMenuItem menuItemCancelBills;
    private UIMenuItem menuItemCancelBillsReport;
    private UIMenuItem menuItemAllocateTransactions;
    private UIMenuItem menuItemParameters;
    private UIMenuItem menuItemChargeCodeSetup;
    private UIMenuItem menuItemGeneralLedgerAccounts;
    private UIMenuItem menuItemInterestRates;
    private UIMenuItem menuItemVAT;
    private UIMenuItem menuItemTransactionType;
    private UIMenuItem menuItemFiscalYear;
    private UIMenuItem menuItemPaymentType;
    private UIMenuItem menuItemClearanceRoutines;
    private UIMenuItem menuItemImportChartOfAccounts;
    private UIMenuItem menuItemFeesBillingReports;
    private UIMenuItem menuItemBillingReports;
    private UIMenuItem menuItemTransactionReports;
    private UIMenuItem menuItemSetUpReports;
    private UIMenuItem menuItemLogs;
    private UIMenuItem menuItemDesignTemplates;
    private UIMenuItem menuItemBillAudit;
    private UIMenuItem menuItemChargesAudit;
    private UIMenuItem menuItemCrossReference;
    private UIMenuItem menuItemException;
    private UIMenuItem menuItemAgedDebtors;
    private UIMenuItem menuItemControlAccount;
    private UIMenuItem menuItemGLInterface;
    private UIMenuItem menuItemGLReconcilation;
    private UIMenuItem menuItemTransactionList;
    private UIMenuItem menuItemStatementDetails;
    private UIMenuItem menuItemUnallocatedTransactions;
    private UIMenuItem menuItemChargeBatchLog;
    private UIMenuItem menuItemReceiptBatchLog;
    private UIMenuItem menuItemAllocationLog;
    private UIMenuItem menuItemFeesCharging;
    private UIMenuItem menuItemFeesBilling;
    private UIMenuItem menuItemFeesPeriodic;
    private UIMenuItem menuItemFeesTransactions;
    private UIMenuItem menuItemChangesLog;
    private UIMenuItem menuItemTransactionTypes;
    private UIMenuItem menuItemFiscalCalendar;
    private UIMenuItem menuItemGLCodes;
    private UIMenuItem menuItemVATCodes;
    private UIMenuItem menuItemChargeCodes;
    private UIMenuItem menuItemEditBillPayer;
    private UIMenuItem menuItemFeesInstalments;
    private UIMenuItem menuItemBACSGeneration;
    private UIMenuItem menuItemDDInstalmentSchedule;
    private UIMenuItem menuItemSOInstalmentSchedule;
    private UIMenuItem menuItemApplyRefund;
    private UIMenuItem menuItemADProvisioning;
    private UIMenuItem menuItemADProvisionUsers;
    private UIMenuItem menuItemADProvisionGroups;
    private UIMenuItem menuItemADPStudent;
    private UIMenuItem menuItemADPAddStudents;
    private UIMenuItem menuItemADPRemoveStudents;
    private UIMenuItem menuItemADPReProvisionStudents;
    private UIMenuItem menuItemADPContact;
    private UIMenuItem menuItemADPAddContacts;
    private UIMenuItem menuItemADPRemoveContacts;
    private UIMenuItem menuItemADPReProvisionContacts;
    private UIMenuItem menuItemADPStaff;
    private UIMenuItem menuItemADPAddStaff;
    private UIMenuItem menuItemADPRemoveStaff;
    private UIMenuItem menuItemADPReProvisionStaff;
    private UIMenuItem menuItemADPAgent;
    private UIMenuItem menuItemADPAddAgent;
    private UIMenuItem menuItemADPRemoveAgent;
    private UIMenuItem menuItemADPReProvisionAgent;
    private UIMenuItem menuItemADPReProvisionGroups;
    private UIMenuItem menuItemADRegisterProvisioningService;
    private UIMenuItem menuItemADViewFailedRequests;
    private UIMenuItem menuItemSLG;
    private UIMenuItem menuItemOnlineReports;
    private UIMenuItem menuItemDataCollectionSheet;
    private UIMenuItem menuItemAssessmentGraphSetup;
    private UIMenuItem menuItemClosureReasons;
    private UIMenuItem menuItemAbsenceReasons;
    private UIMenuItem menuItemRegisterRoomClosure;
    private UIMenuItem menuItemManageCoverRota;
    private UIMenuItem menuItemEditRoomClosure;
    private UIMenuItem menuItemNonClassCodeRule;
    private UIMenuItem menuItemCoverDairy;
    private UIMenuItem menuItemStaffWeighting;
    private UIMenuItem menuItemIdentifySupplyStaff;
    private UIMenuItem menuItemSuspensionRule;
    private UIMenuItem menuItemCoverDairyForRegisterAbsence;
    private UIMenuItem menuItemGlobalSetting;
    private UIMenuItem menuItemCoverCreditSetting;
    private UIMenuItem menuItemCoverStatistics;
    private UIMenuItem menuItemCoverCoverStatistics;
    private UIMenuItem menuItemCoverAbsenceStatistics;
    private UIMenuItem menuItemCoverAbsenceImpactReports;
    private UIMenuItem menuItemClassesImpactedByAbsence;
    private UIMenuItem menuItemStudentsImpactedByAbsence;
    private UIMenuItem menuItemDetectTimetableChanges;
    private UIMenuItem menuItemCoverOrgBookings;
    private UIMenuItem menuItemCurrOrganisations;
    private UIMenuItem menuItemCurrBookings;
    private UIMenuItem menuItemCurrDefineTimes;
    private UIMenuItem menuItemEmploymentParam;
    private UIMenuItem menuItemCoverImportExamData;
    private UIMenuItem menuItemCoverManageStaffLeavers;
    private UIMenuItem menuItemTeachersView;
    private UIMenuItem menuItemTeachersViewSetup;
    private UIMenuItem menuItemSipaAgent;
    private UIMenuItem menuItemConfigureSipaAgent;
    private UIMenuItem menuItemSipaAgentSchedules;
    private UIMenuItem menuItemSipaAgentLogs;
    private UIMenuItem menuItemSipaSpare;
    private UIMenuItem menuItemPartnership;
    private UIMenuItem menuItemPartnerships;
    private UIMenuItem menuItemConfigurePartnership;
    private UIMenuItem menuItemSchedules;
    private UIMenuItem menuItemPartnershipLogs;
    private UIMenuItem menuItemPrivateDocuments;
    private UIMenuItem menuItemStudentList;
    private UIMenuItem menuItemGeneralStudentList;
    private UIMenuItem menuItemClassList;
    private UIMenuItem menuItemRegGroupList;
    private UIMenuItem menuItemViewTimeTables;
    private UIMenuItem menuItemStaffTimetable;
    private UIMenuItem menuItemRoomTimetable;
    private UIMenuItem menuItemStudentTimetable;
    private UIMenuItem menuItemNonclasscodeTimetable;
    private UIMenuItem menuItemAllStaffTimetable;
    private UIMenuItem menuItemAllRoomTimetable;
    private UIMenuItem menuItemSelection;
    private UIMenuItem menuItemYearBand;
    private UIMenuItem menuItemSubjects;
    private UIMenuItem menuItemAllNonclassCodesTimetable;
    private UIMenuItem menuItemFreeStaff;
    private UIMenuItem menuItemFreeRooms;
    private UIMenuItem menuItemPeriods;
    private UIMenuItem menuItemSeparator;
    private UIMenuItem menuItemYearGroupTotals;
    private UIMenuItem menuItemYearBandTotals;
    private UIMenuItem menuItemYearRegTotals;
    private UIMenuItem menuItemVertRegTotals;
    private UIMenuItem menuItemAgeBreakTotals;
    private UIMenuItem menuItemClassesYearTotals;
    private UIMenuItem menuItemClassesPeriodTotals;
    private UIMenuItem menuItemEachSubject;
    private UIMenuItem menuItemPairingOne;
    private UIMenuItem menuItemOrderedPairing;
    private UIMenuItem menuItemHomePageGroup;
    private UIMenuItem menuItemLockHomePageConfig;
    private UIMenuItem menuItemHomePageGroupConfig;
    private UIMenuItem menuItemHouseKeepingManageMessages;
    private UIMenuItem menuItemHomePageTimelineConfig;
    private UIMenuItem menuItemHomePageConfigSettingsReport;
    private UIMenuItem menuItemOptionsOffer;
    private UIMenuItem menuItemMaintainOffers;
    private UIMenuItem menuItemStudentChoices;
    private UIMenuItem menuItemOptionsNGRun;
    private UIMenuItem menuItemSimsParent;
    private UIMenuItem menuItemMaintainEarlyYearProv;
    private UIMenuItem menuItemAdmissionReport;
    private UIMenuItem menuItemProjectedPupilNumbers;
    private UIMenuItem menuItemManageHomework;

    private event MainContainer.functionPIvisibility piVisiblityFunctionPointer;

    private void setSupportedImages()
    {
      ImageList imageList1 = CheckBoxListViewImages.CreateImageList();
      this.imageListStatusBar.Images.Clear();
      this.imageListStatusBar.Images.Add(imageList1.Images[34]);
      this.imageListStatusBar.Images.Add(imageList1.Images[35]);
      this.imageListStatusBar.Images.Add(imageList1.Images[33]);
      ImageList imageList2 = new ImageList();
      imageList2.ImageSize = new Size(16, 16);
      imageList2.ColorDepth = ColorDepth.Depth32Bit;
      imageList2.TransparentColor = imageList1.TransparentColor;
      imageList2.Images.Add(imageList1.Images[15]);
      imageList2.Images.Add(imageList1.Images[16]);
      imageList2.Images.Add(this.imageListNavigation.Images[2]);
      imageList2.Images.Add(this.imageListNavigation.Images[3]);
      this.imageListNavigation.Images.Clear();
      this.imageListNavigation.ImageSize = new Size(16, 16);
      this.imageListNavigation.ColorDepth = ColorDepth.Depth32Bit;
      this.imageListNavigation.TransparentColor = imageList1.TransparentColor;
      foreach (Image image in imageList2.Images)
        this.imageListNavigation.Images.Add(image);
    }

    protected override void WndProc(ref Message m)
    {
      bool flag = false;
      switch (m.Msg)
      {
        case 793:
          flag = this.actionWM_APPCOMMAND(ref m);
          break;
        case 1024:
          flag = InterProcessComms.ProcessMessage(ref m, (Form) this);
          break;
      }
      if (flag)
        return;
      base.WndProc(ref m);
    }

    private bool actionWM_APPCOMMAND(ref Message m)
    {
      short appcommandLparam = Win32Declarations.GET_APPCOMMAND_LPARAM(m.LParam.ToInt32());
      bool flag = false;
      switch (appcommandLparam)
      {
        case 1:
          this.commandBarButtonItemBack_Click((object) this, new EventArgs());
          flag = true;
          break;
        case 2:
          this.commandBarButtonItemForward_Click((object) this, new EventArgs());
          flag = true;
          break;
      }
      return flag;
    }

    private void beginUpdate()
    {
      ++this.updateDepth;
    }

    private void endUpdate()
    {
      if (this.updateDepth > 0)
        --this.updateDepth;
      if (this.updateDepth != 0)
        return;
      this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (this.updateDepth != 0)
        return;
      base.OnPaint(e);
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
      if (this.updateDepth != 0)
        return;
      base.OnPaintBackground(pevent);
    }

    protected override void OnActivated(EventArgs e)
    {
      if (this.updateDepth != 0)
        return;
      base.OnActivated(e);
    }

    public MainContainer(ParameterlessDelegate splashScreenClose, string autoStartMenuItemPath)
    {
      try
      {
        this.Visible = false;
        this.beginUpdate();
        this.Shaded = false;
        this.Text = "SIMS";
        this.piVisiblityFunctionPointer += new MainContainer.functionPIvisibility(SIMS.UserInterfaces.Exams.MainContainerHelper.SetPiEnabled);
        SIMS.Processes.ExamCache.PIvisibiltyFunctionPointer = (Delegate) this.piVisiblityFunctionPointer;
        SIMS.Entities.Cache.HostControl += new HostControlEventHandler(this.whenHostControlRequested);
        SIMS.Entities.Cache.ContextReport += new ContextReportEventHandler(this.whenContextReportRequested);
        UserInterfaceManager.MainForm = (Control) this;
        string directoryName = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
        SIMS.Entities.Cache.UICache.UIInternalUse = File.Exists(Path.Combine(directoryName, "Internal.UI"));
        SIMS.Entities.InTouch.Cache.RefreshMessage += new EventHandler(this.refreshInTouchMessageLists);
        if (SIMS.Entities.Cache.ProcessAvailable("MaintainUserInterfaceLabels"))
          Label.UIEditExternal += new UIEditEventHandler(UIExternalEditDlg.Instantiate);
        if (SIMS.Entities.Cache.ProcessAvailable("MaintainUserInterfaceLabels") && SIMS.Entities.Cache.UICache.UIInternalUse)
          Label.UIEditInternal += new UIEditEventHandler(UIInternalEditDlg.Instantiate);
        UserInterfaceConfiguration.HelpFileTranslation = new StringTranslationDelegate(this.HelpFilenameMapping);
        UserInterfaceConfiguration.HelpContextID = new HelpContextDelegate(this.CallingClass);
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.SetStyle(ControlStyles.UserPaint, true);
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        this.SetStyle(ControlStyles.DoubleBuffer, true);
        this.InitializeComponent();
        this.Controls.SetChildIndex((Control) this.statusBar, 0);
        this.statusBar.BringToFront();
        this.Controls.SetChildIndex((Control) this.panelToolBar, 1);
        this.panelToolBar.BringToFront();
        this.Controls.SetChildIndex((Control) this.panelOptions, 2);
        this.panelOptions.BringToFront();
        this.Controls.SetChildIndex((Control) this.splitterVertical, 3);
        this.splitterVertical.BringToFront();
        this.Controls.SetChildIndex((Control) this.panelMain, 4);
        this.panelMain.BringToFront();
        this.WindowState = FormWindowState.Minimized;
        this.panelOptions.Shaded = false;
        this.panelMain.Shaded = false;
        this.panelToolBar.Shaded = false;
        this.setSupportedImages();
        this.initRAMenus();
        this.initTeachersViewMenus();
        this.initExportMenus();
        this.initPlascMenus();
        this.initELWAMenus();
        this.initSchoolCensusMenus();
        this.initCESEWCensusMenus();
        this.initSchoolWorkforceCensusDefaultMenu();
        this.initReconcileExamResultsMenu();
        this.initReconcileExamEntriesMenu();
        this.initPRUMenu();
        this.initCTFMenus();
        this.initAcademicMenus();
        this.initB2BMenus();
        this.initDENIMenus();
        this.initEMAMenus();
        this.initTeachersDesktopMenus();
        this.initSystemDiagMenus();
        this.initNDCMenus();
        this.initIndependentMenus();
        this.initPerformanceMenus();
        this.initVLEMenus();
        this.initBehaviourMenus();
        this.initInterventionsMenus();
        this.initHousekeepingMenus();
        this.initAttendanceMenus();
        this.initPersonnelMenus();
        this.initCLPMenus();
        this.initAlertsMenu();
        this.initSLGMenus();
        this.initFeesLedgerMenus();
        this.initADPMenus();
        this.initSLGReportsMenus();
        this.initCoverMenus();
        this.initDMSMenus();
        this.initPartnerShipMenus();
        this.initSipaMenus();
        this.initHomePageMenus();
        this.initCurriculumnReportingMenus();
        this.initStudentAnalysisMenus();
        this.initTTPrintingMenus();
        this.initNurseryHoursMenus();
        this.initAdmissionReportsMenus();
        this.initFullSchoolReportMenu();
        this.initPersonDataOutputMenu();
        this.initHomeworkMenus();
        this.initPupilPremiumMenus();
        SIMS.UserInterfaces.DinnerMoney.MainContainerHelper.InitialiseMenus(this.mainMenu, new SIMS.UserInterfaces.DinnerMoney.RecordMenuUsageDelegate(this.recordMenuUsage), new SIMS.UserInterfaces.DinnerMoney.DisplayComponentDelegate(this.DisplayComponent), new SIMS.UserInterfaces.DinnerMoney.DisplayComponentWithInterfacesDelegate(this.DisplayComponentWithInterfaces));
        SIMS.UserInterfaces.InTouch.MainContainerHelper.InitialiseMenus(this.mainMenu, new SIMS.UserInterfaces.InTouch.RecordMenuUsageDelegate(this.recordMenuUsage), new SIMS.UserInterfaces.InTouch.DisplayComponentDelegate(this.DisplayComponent), new SIMS.UserInterfaces.InTouch.DisplayComponentWithInterfacesDelegate(this.DisplayComponentWithInterfaces), new ComponentExistsDelegate(this.ComponentExists), new EventHandler(this.hostedComponent_TitleChanged));
        SIMS.UserInterfaces.Discover.MainContainerHelper.InitialiseMenus(this.mainMenu, new SIMS.UserInterfaces.Discover.RecordMenuUsageDelegate(this.recordMenuUsage), new SIMS.UserInterfaces.Discover.DisplayComponentDelegate(this.DisplayComponent), new DisplayNewComponentDelegate(this.DisplayNewComponent), new ComponentExists(this.ComponentExists));
        SIMS.UserInterfaces.SystemManager.MainContainerHelper.InitialiseMenus(this.mainMenu, new SIMS.UserInterfaces.SystemManager.RecordMenuUsageDelegate(this.recordMenuUsage), new SIMS.UserInterfaces.SystemManager.DisplayComponentDelegate(this.DisplayComponent));
        SIMS.UserInterfaces.ThirdParty.MainContainerHelper.InitialiseMenus(this.mainMenu, new SIMS.UserInterfaces.ThirdParty.RecordMenuUsageDelegate(this.recordMenuUsage), new SIMS.UserInterfaces.ThirdParty.DisplayComponentDelegate(this.DisplayComponent));
        SIMS.UserInterfaces.Exams.MainContainerHelper.InitialiseMenus(this.mainMenu, new SIMS.UserInterfaces.Exams.RecordMenuUsageDelegate(this.recordMenuUsage), new SIMS.UserInterfaces.Exams.DisplayComponentDelegate(this.DisplayComponent));
        this.launcher.LaunchFavourite = new Favourites.LaunchFavouriteDelegate(this.launchFavourite);
        this.launcher.RefreshLauncher();
        this.Text = SIMS.Entities.Cache.ApplicationName;
        this.MenuItemAbout.Text = string.Format(this.MenuItemAbout.Text, (object) SIMS.Entities.Cache.ApplicationName);
        UserInterfaceManager.Label((System.Windows.Forms.Form) this);
        this.setMenuIcons();
        this.RebuildMenu();
        this.SetupContextMenu();
        SIMS.Entities.Cache.ShowUserMessage += new UserMessageEventHandler(this.userMessageHandler);
        UIMenuItem.MenuItemSelect += new EventHandler(this.MainContainer_MenuItemSelect);
        this.configureLauncherhideShow();
        this.launcher.MainContainerMainMenu = this.mainMenu;
        if (!SIMS.Entities.Cache.ProcessVisible("DisplayExternalApplications"))
        {
          this.panelOptions.Visible = false;
          this.splitterVertical.Visible = false;
        }
        else if (this.launcher != null)
        {
          this.launcher.Populate();
          this.addOfflineShortcutsToLauncher();
        }
        this.commandBarItemShowLauncher.Checked = this.panelOptions.Visible && SIMS.Entities.Cache.ProcessVisible("DisplayExternalApplications");
        this.panelMain.BackColor = SystemColors.Window;
        this.BackColor = SystemColors.Window;
        this.ForeColor = UserOptionsCache.UserOptions.ControlForeColour;
        this.panelToolBar.BackColor = this.panelMain.BackColor;
        SIMS.UserInterfaces.Utilities.SetChildColours((Control) this);
        this.loadBackgroundImage();
        System.Windows.Forms.Application.DoEvents();
        if (SIMS.Entities.Cache.SetupRequired)
        {
          this.runAsSetup();
        }
        else
        {
          this.showWhatsNew();
          SIMS.UserInterfaces.InTouch.MainContainerHelper.CheckInTouchServices();
          this.autoStartMenuItem(autoStartMenuItemPath);
          this.autoStartItemLaunched = true;
        }
        System.Windows.Forms.Application.DoEvents();
        this.CustomiseMenuItems();
        this.tempFiles = LocalFileSystem.SecureTempFiles();
        this.tempFiles.Delete();
        this.buildFocusBar();
        HomePageWidgetsGlobal.EnumerateMainMenu(this.mainMenu);
        this.closeSplashScreen = splashScreenClose;
        GC.Collect(1);
      }
      catch (System.Exception ex)
      {
        splashScreenClose();
        throw ex;
      }
    }

    private void initFullSchoolReportMenu()
    {
      this.menuItemFullSchoolReport.ImageIndex = -1;
      this.menuItemFullSchoolReport.ImageList = (ImageList) null;
      this.menuItemFullSchoolReport.NoEdit = false;
      this.menuItemFullSchoolReport.NoUIModify = false;
      this.menuItemFullSchoolReport.OriginalText = "";
      this.menuItemFullSchoolReport.OwnerDraw = true;
      this.menuItemFullSchoolReport.Text = "&School Report";
      this.menuItemFullSchoolReport.Click += new EventHandler(this.menuItemFullSchoolReport_Click);
      this.MenuItemReports.MenuItems.Add((MenuItem) this.menuItemFullSchoolReport);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemFullSchoolReport, "SchoolReportRun");
    }

    private void initPersonDataOutputMenu()
    {
      this.menuItemPersonDataOutput.ImageIndex = -1;
      this.menuItemPersonDataOutput.ImageList = (ImageList) null;
      this.menuItemPersonDataOutput.NoEdit = false;
      this.menuItemPersonDataOutput.NoUIModify = false;
      this.menuItemPersonDataOutput.OriginalText = "";
      this.menuItemPersonDataOutput.OwnerDraw = true;
      this.menuItemPersonDataOutput.Text = "Person &Data Output";
      this.menuItemPersonDataOutput.Click += new EventHandler(this.menuItemPersonDataOutput_Click);
      this.menuItemDataOut.MenuItems.Add((MenuItem) this.menuItemPersonDataOutput);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPersonDataOutput, new string[1]
      {
        "PDORun"
      });
    }

    private void showWhatsNew()
    {
      if (!SIMS.Entities.Cache.UpgradeHelpRequired)
        return;
      try
      {
        string documentationFile = LoadCache.GetDocumentationFile("WhatsNew");
        if (!string.IsNullOrEmpty(documentationFile))
        {
          try
          {
            new ProcessStartInfo(documentationFile).WindowStyle = ProcessWindowStyle.Normal;
            Process.Start(documentationFile);
            SIMS.Entities.Cache.StatusMessage("", UserMessageEventEnum.Information);
          }
          catch (System.Exception ex)
          {
            int num = (int) MessageBox.Show(ex.Message, SIMS.Entities.Cache.ApplicationName);
          }
        }
        else
          SIMS.Entities.Cache.StatusMessage("Documentation Index File missing...", UserMessageEventEnum.Error);
      }
      catch
      {
      }
    }

    private string AddMessage()
    {
      return SIMS.Entities.Cache.DialogTitleFollowingConversion;
    }

    private void autoStartMenuItem(string menuItemPath)
    {
      if (menuItemPath.Length <= 0)
        return;
      this.autoStartMenuItem(menuItemPath.Split('|'), 1, (Menu) this.mainMenu);
    }

    private void autoStartMenuItem(string[] menuItemNames, int depth, Menu menu)
    {
      if (depth > menuItemNames.Length)
        return;
      string str = menuItemNames[depth - 1].Trim();
      foreach (UIMenuItem menuItem in menu.MenuItems)
      {
        if (this.trueText(menuItem.Text) == str)
        {
          if (depth == menuItemNames.Length)
          {
            if (menuItem.Visible)
            {
              menuItem.PerformClick();
              break;
            }
          }
          else if (menuItem.IsParent)
            this.autoStartMenuItem(menuItemNames, depth + 1, (Menu) menuItem);
        }
      }
    }

    private string trueText(string menuItemText)
    {
      return menuItemText.Replace("&&", "||").Replace("&", "").Replace("||", "&").Trim();
    }

    private void SetInitialWindowHeight()
    {
      Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
      this.DesktopBounds = new Rectangle((workingArea.Right - workingArea.Left - this.Width) / 2, 0, this.Width, workingArea.Bottom);
    }

    private object whenHostControlRequested(HostControlEventArgs args)
    {
      if (!(args.Component is Control))
        return (object) null;
      ISameAs entity = args.Entity as ISameAs;
      Control component = (Control) args.Component;
      if (entity != null)
      {
        string componentTypeName = component.GetType().ToString();
        if (this.ComponentExists(entity, componentTypeName) != null)
        {
          this.checkForBackBranch(component);
          return (object) this.DisplayNewComponent(args.Entity, component);
        }
        this.checkForBackBranch(component);
        return (object) this.DisplayComponent(args.Entity, component);
      }
      this.checkForBackBranch(component);
      return (object) this.DisplayComponent(args.Entity, component);
    }

    private object whenContextReportRequested(ContextReportEventArgs args)
    {
      new ContextReport(args.Text, args.ID, args.AskParams).Run((Form) this);
      return (object) null;
    }

    public Control ComponentExists(string componentTypeName)
    {
      string str = componentTypeName.Trim();
      for (int index = 0; index < this.panelMain.Controls.Count; ++index)
      {
        Control control = this.panelMain.Controls[index];
        if (control != this.pictureBoxLogo && control.GetType().ToString() == str)
        {
          this.activateItem(control);
          return control;
        }
      }
      return (Control) null;
    }

    public Control ComponentExists(ISameAs entity, string componentTypeName)
    {
      string componentType = componentTypeName.Trim();
      for (int index = 0; index < this.panelMain.Controls.Count; ++index)
      {
        Control control = this.panelMain.Controls[index];
        if (control != this.pictureBoxLogo && control.GetType().ToString() == componentType)
        {
          ICompareWindow compareWindow = control as ICompareWindow;
          if (compareWindow != null && compareWindow.IsSameAs(entity, componentType))
          {
            this.activateItem(control);
            return control;
          }
        }
      }
      return (Control) null;
    }

    public Control ComponentExists(string componentTypeName, string windowTitle)
    {
      string str = componentTypeName.Trim();
      for (int index = 0; index < this.panelMain.Controls.Count; ++index)
      {
        Control control = this.panelMain.Controls[index];
        if (control != this.pictureBoxLogo && control.GetType().ToString() == str && control.Text == windowTitle)
        {
          this.activateItem(control);
          return control;
        }
      }
      return (Control) null;
    }

    public Control ComponentExistsLike(string componentTypeName, string windowTitle)
    {
      string str = componentTypeName.Trim();
      for (int index = 0; index < this.panelMain.Controls.Count; ++index)
      {
        Control control = this.panelMain.Controls[index];
        if (control != this.pictureBoxLogo && control.GetType().ToString() == str && control.Text.StartsWith(windowTitle))
        {
          this.activateItem(control);
          return control;
        }
      }
      return (Control) null;
    }

    public Control ComponentExists(
      ISameAs entity,
      string componentTypeName,
      string windowTitle)
    {
      return this.ComponentExists(entity, componentTypeName) ?? this.ComponentExists(componentTypeName, windowTitle);
    }

    private Control DisplayNewComponent(Control component)
    {
      return this.DisplayNewComponent((IIDEntity) null, component);
    }

    private Control DisplayNewComponent(IIDEntity entity, Control component)
    {
      Cursor cursor = this.Cursor;
      API.SendMessage(this.panelMain.Handle, 11, 0, 0);
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.disableTabStop();
        this.panelMain.Visible = true;
        component.Dock = DockStyle.Fill;
        DateTime now = DateTime.Now;
        this.panelMain.Controls.Add(component);
        component.BringToFront();
        if (component is AbstractContainerControl)
        {
          ((AbstractContainerControl) component).ComponentClosing -= new ComponentClosingEventHandler(this.ComponentClosing);
          ((AbstractContainerControl) component).ComponentClosing += new ComponentClosingEventHandler(this.ComponentClosing);
        }
        component.Focus();
        (component as AbstractContainerControl)?.SetInitialFocus();
        if (!this.NavigationZOrder.Contains((object) component))
          this.NavigationZOrder.Add((object) component);
        this.activeComponent = this.panelMain.Controls.IndexOf(component);
        component.Visible = true;
        UserInterfaceManager.Label(component);
        this.hookTitleChangedEvent(component);
        this.reconfigureNavigation();
        return (Control) null;
      }
      finally
      {
        this.Cursor = cursor;
        API.SendMessage(this.panelMain.Handle, 11, 1, 0);
      }
    }

    private Control DisplayComponent(Control component)
    {
      return this.DisplayComponent((IIDEntity) null, component);
    }

    private Control DisplayComponentWithInterfaces(Control component)
    {
      return this.ComponentExists(component as ISameAs, component.GetType().ToString()) ?? this.DisplayNewComponent((IIDEntity) null, component);
    }

    private void launchFavourite(Control component, IIDEntity entity)
    {
      this.whenHostControlRequested(new HostControlEventArgs(entity, (object) component));
    }

    private Control DisplayComponent(IIDEntity entity, Control component)
    {
      if (!this.CanFocus && component is AbstractControlHost)
      {
        ((AbstractControlHost) component).PinnedMode = false;
        AbstractComponentWindow abstractComponentWindow = new AbstractComponentWindow(component as AbstractContainerControl);
        abstractComponentWindow.Text = component.Text;
        AbstractContainerControl containerControl = this.NavigationZOrder[0] as AbstractContainerControl;
        abstractComponentWindow.Size = containerControl.Size;
        abstractComponentWindow.Location = containerControl.Location;
        if (this.launcher.Visible)
          abstractComponentWindow.Left += this.launcher.Width;
        return (Control) null;
      }
      bool flag = false;
      Cursor cursor = this.Cursor;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        MaintainB2BAuthoriseDataInformation bauthoriseDataInformation = component as MaintainB2BAuthoriseDataInformation;
        B2BAuthoriseDataDetailUI bauthoriseDataDetailUi = component as B2BAuthoriseDataDetailUI;
        B2BSuspensionDetailUI bsuspensionDetailUi = component as B2BSuspensionDetailUI;
        if (bauthoriseDataInformation != null)
        {
          bauthoriseDataInformation.EventEmployeeDetails -= new NavigationRouteDelegate(this.ContextStaffDetail);
          bauthoriseDataInformation.EventEmployeeDetails += new NavigationRouteDelegate(this.ContextStaffDetail);
        }
        if (bauthoriseDataDetailUi != null)
        {
          bauthoriseDataDetailUi.EventEmployeeDetails -= new NavigationRouteDelegate(this.ContextStaffDetail);
          bauthoriseDataDetailUi.EventEmployeeDetails += new NavigationRouteDelegate(this.ContextStaffDetail);
        }
        Control existingComponent = this.findExistingComponent(entity, component);
        if (existingComponent != null && existingComponent is BasicDetailControl && component is BasicDetailControl)
          flag = ((BasicDetailControl) existingComponent).ContextMenuLink.CurrentEntityID != ((BasicDetailControl) component).ContextMenuLink.CurrentEntityID;
        if (existingComponent != null && !flag)
        {
          component.Dispose();
          this.NavigationZOrder.Remove((object) component);
          this.activateItem(existingComponent);
          return existingComponent;
        }
        API.SendMessage(this.panelMain.Handle, 11, 0, 0);
        try
        {
          this.disableTabStop();
          this.panelMain.Visible = true;
          component.Dock = DockStyle.Fill;
          DateTime now = DateTime.Now;
          if (component is AbstractContainerControl)
            ((AbstractContainerControl) component).ComponentClosing += new ComponentClosingEventHandler(this.ComponentClosing);
          this.panelMain.Controls.Add(component);
          if (!this.panelMain.Controls.Contains(component) && component is AbstractContainerControl)
            ((AbstractContainerControl) component).ComponentClosing -= new ComponentClosingEventHandler(this.ComponentClosing);
          if (bauthoriseDataDetailUi != null && bauthoriseDataDetailUi.Process.B2BOutEmployee.ID == 0)
          {
            int num = (int) MessageBox.Show((IWin32Window) this.ParentForm, "You cannot open Review Changes screen because data has been cleared", "B2B:Personnel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            this.panelMain.Controls.Remove(component);
            if (bauthoriseDataDetailUi.Close != null)
              bauthoriseDataDetailUi.Close((AbstractContainerControl) bauthoriseDataDetailUi);
            return (Control) null;
          }
          if (bsuspensionDetailUi != null && bsuspensionDetailUi.Process.B2BInEmployee.ID == 0)
          {
            int num = (int) MessageBox.Show((IWin32Window) this.ParentForm, "You cannot open Suspense Processing screen because data has been cleared", "B2B:Personnel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            this.panelMain.Controls.Remove(component);
            return (Control) null;
          }
          if (this.panelMain.Controls.Contains(component))
          {
            component.BringToFront();
            component.Focus();
            (component as AbstractContainerControl)?.SetInitialFocus();
            this.refreshNavigationZOrder(component);
            this.activeComponent = this.panelMain.Controls.IndexOf(component);
            component.Visible = true;
            UserInterfaceManager.Label(component);
            this.hookTitleChangedEvent(component);
            this.reconfigureNavigation();
          }
        }
        finally
        {
          API.SendMessage(this.panelMain.Handle, 11, 1, 0);
          this.Invalidate(true);
        }
        return (Control) null;
      }
      finally
      {
        this.Cursor = cursor;
      }
    }

    public void ComponentClosing(object sender, ComponentClosingEventArgs args)
    {
      this.tempFiles = LocalFileSystem.SecureTempFiles();
      this.tempFiles.Delete();
      Control control1 = (Control) sender;
      this.controlActiveBeforeLauncherActivated = (Control) null;
      this.splitterVertical.Focus();
      this.RemoveFromWindowMenu(control1);
      control1.Visible = false;
      Control control2 = (Control) null;
      int num = this.NavigationZOrder.IndexOf((object) control1);
      if (num > 0)
        control2 = (Control) this.NavigationZOrder[num - 1];
      for (int index = this.NavigationZOrder.Count - 1; index >= 0; --index)
      {
        Control control3 = (Control) this.NavigationZOrder[index];
        if (control3 != control1)
        {
          control3.TabStop = true;
          break;
        }
      }
      control1.SelectNextControl(control1, true, true, false, true);
      this.NavigationZOrder.Remove((object) control1);
      if (args.Mode == EComponentClosingMode.Close)
        control1.Dispose();
      this.panelMain.Controls.Remove(control1);
      control2?.BringToFront();
      this.reconfigureNavigation();
      if (this.panelMain.Controls.Count <= 0 || !(this.panelMain.Controls[0] is IRefreshOnActivate))
        return;
      (this.panelMain.Controls[0] as IRefreshOnActivate).RefreshOnActivate();
    }

    private void runAsSetup()
    {
      for (int index = 1; index < this.mainMenu.MenuItems.Count - 1; ++index)
        (this.mainMenu.MenuItems[index] as UIMenuItem).Visible = false;
      if (this.mainMenu.MenuItems.Count > 0)
      {
        foreach (UIMenuItem menuItem in this.mainMenu.MenuItems[0].MenuItems)
          menuItem.Visible = menuItem.Text == "Sys&tem Manager";
      }
      this.DisplayComponent((Control) new SetupPageDetail()
      {
        Completed = new ParameterlessDelegate(this.RebuildMenu)
      });
    }

    private void MenuItemSchoolOrganiser_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SchoolEditorUI());
    }

    private void menuItemExternalSchools_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainExternalSchool());
    }

    private void MenuItemCurrentPastoralStructure_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.YearGroupsSetupUI", "Current Academic Year Pastoral Structure") != null)
        return;
      this.DisplayNewComponent((Control) new YearGroupsSetupUI(PastoralStructureType.Current));
    }

    private void MenuItemNextAcademicYearPastoralStructure_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.YearGroupsSetupUI", "Next Academic Year Pastoral Structure") != null)
        return;
      this.DisplayNewComponent((Control) new YearGroupsSetupUI(PastoralStructureType.NextAcademicYear));
    }

    private void MenuItemPhotoImportStudentAdNo_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new StudAdNoPhotoImportContainer());
    }

    private void MenuItemPhotoImportStudentRgGp_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new StudRgGpPhotoImportContainer());
    }

    private void MenuItemPhotoImportStaff_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new StaffPhotoImportContainer());
    }

    private void MenuItemEmployeeAdd_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainEmployeeInformation());
    }

    private void MenuItemCalendar_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      try
      {
        this.DisplayComponent((Control) new CalendarContainer());
      }
      catch (CalendarBuilder.AcademicYearNotDefinedException ex)
      {
        int num = (int) MessageBox.Show((IWin32Window) this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void MenuItemEditAgent_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      AgencyUIInterfaceReferences.StudentInterfaceReference = (IStudentBrowse) new IStudentBrowseContainer();
      this.DisplayComponent((Control) new AgentUI());
    }

    private void MenuItemEditAgency_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      AgencyUIInterfaceReferences.StudentInterfaceReference = (IStudentBrowse) new IStudentBrowseContainer();
      this.DisplayComponent((Control) new AgencyUI());
    }

    private void menuItemLookupMaintenance_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new LookupBrowserDetailUI());
    }

    private void menuItemRooms_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new RoomEditor());
    }

    private void menuItemExclusions_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ExclusionEditor());
    }

    private void menuItemStudentSEN_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainStudentSENInformation());
    }

    private void menuItemSchoolPromotion_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PromotionEditor());
    }

    private void menuItemToolUploadDocuments_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new UploadDocuments().ShowDialog();
    }

    private void menuItemLeavers_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainStudentLeavingDetails());
    }

    private void menuItemSENSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SENAdmin());
    }

    private void menuItemAcademicYear_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (CreateAcadYearWizard createAcadYearWizard = new CreateAcadYearWizard(AcademicYearWizardMode.Create, -1))
      {
        int num = (int) createAcadYearWizard.ShowDialog();
      }
    }

    private void menuItemEditAcademicYear_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (SelectAcademicYearForm academicYearForm = new SelectAcademicYearForm())
      {
        if (DialogResult.OK != academicYearForm.ShowDialog())
          return;
        using (CreateAcadYearWizard createAcadYearWizard = new CreateAcadYearWizard(AcademicYearWizardMode.Edit, academicYearForm.SelectedAcademicYear.ID))
        {
          int num = (int) createAcadYearWizard.ShowDialog();
        }
      }
    }

    private void menuItemSchoolDetailsChange_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!SIMS.Entities.Cache.ProcessVisible("EditSchoolDetails") || SIMS.Entities.Cache.ProcessVisible("PXChangeRun"))
        return;
      int num = (int) new SchoolDetailsWizard().ShowDialog();
    }

    private void menuItemDeleteAcademicYear_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ValidationError validationError = new CalendarBuilder().CanDeleteAcademicYear();
      if (validationError != null)
      {
        int num1 = (int) MessageBox.Show((IWin32Window) this.ParentForm, validationError.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        if (DialogResult.Yes != MessageBox.Show((IWin32Window) this.ParentForm, "Latest academic year and all associated data will be deleted. Do you want to continue?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
          return;
        MaintainAcademicYear maintainAcademicYear = new MaintainAcademicYear();
        Cursor.Current = Cursors.WaitCursor;
        try
        {
          Thread thread = new Thread(new ThreadStart(maintainAcademicYear.DeleteCurrent));
          thread.Start();
          this.Enabled = false;
          while (!thread.Join(100))
          {
            System.Windows.Forms.Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
          }
          if (maintainAcademicYear.SaveException != null)
            throw maintainAcademicYear.SaveException;
          int num2 = (int) MessageBox.Show((IWin32Window) this.ParentForm, "Academic year was successfully deleted", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        finally
        {
          this.Enabled = true;
          Cursor.Current = Cursors.Default;
        }
      }
    }

    private void MenuItemEditStudent_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExistsLike("SIMS.UserInterfaces.MaintainStudentInformation", SIMS.Entities.Cache.UserInterfaceLabel("Student Details")) != null)
        return;
      this.DisplayNewComponent((Control) new MaintainStudentInformation());
    }

    private void MenuItemAddStudent_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new AddStudent());
    }

    private void menuItemStudentDetails_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainStudentInformation());
    }

    private void MenuItemDesignReports_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!DisplayReports.CheckDocumentServer() || (Component) this.ComponentExists("SIMS.UserInterfaces.ReportController", "Design Report") != null)
        return;
      this.DisplayNewComponent((Control) new ReportController(EReportOpMode.New));
    }

    private void MenuItemContactsEdit_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainContactInformation());
    }

    private void MenuItemRunReports_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!DisplayReports.CheckDocumentServer() || (Component) this.ComponentExists("SIMS.UserInterfaces.ReportController", "Run Report") != null)
        return;
      this.DisplayNewComponent((Control) new ReportController(EReportOpMode.Run));
    }

    private void menuItemSIMSExtApps_Click(object sender, EventArgs e)
    {
      new DisplayExternalApplications().Launch((SIMS.Entities.ExternalApplication) ((UIMenuItem) sender).Tag);
    }

    private void MenuItemExit_Click(object sender, EventArgs e)
    {
      this.tempFiles = LocalFileSystem.SecureTempFiles();
      this.tempFiles.Delete();
      this.Close();
    }

    private void MenuItemUndo_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("TODO: Edit | Undo", this.Text);
    }

    private void MenuItemCut_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("TODO: Edit | Cut", this.Text);
    }

    private void MenuItemCopy_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("TODO: Edit | Copy", this.Text);
    }

    private void MenuItemPaste_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("TODO: Edit | Paste", this.Text);
    }

    private void MenuItemDelete_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("TODO: Edit | Delete", this.Text);
    }

    private void MenuItemSelectAll_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("TODO: Edit | Select All", this.Text);
    }

    private void MenuItemUserPreferences_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainProcessVisibility()
      {
        MainMenuRebuildDelegate = new ParameterlessDelegate(this.RebuildMenu)
      });
    }

    private void MenuItemUserInterfaceLabels_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainInterfaceLabels());
    }

    private void MenuItemCustomize_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new Customize());
    }

    private void MenuItemConfigureDocServers_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new DocumentServerDetail());
    }

    private void MenuItemContents_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      OnlineHelp.ShowTOC((Control) this, "SIMSnet.chm");
    }

    private void MenuItemSearchForHelpOn_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      OnlineHelp.ShowIndex((Control) this, "SIMSnet.chm");
    }

    private void MenuItemGettingStarted_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      string fileName = Path.Combine(SIMSFolderLocations.SIMSDocumentationFolder(), "getStart.pdf");
      try
      {
        Process.Start(new ProcessStartInfo(fileName));
      }
      catch (Win32Exception ex)
      {
        int num = (int) MessageBox.Show((IWin32Window) this, "Your getting started handbook file (getStart.pdf) is missing", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void MenuItemTechnicalSupport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      OnlineHelp.ShowTOC((Control) this, "SIMSSupport.chm");
    }

    private void MenuItemHowToUseHelp_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      OnlineHelp.ShowTOC((Control) this, "SIMSViewer.chm");
    }

    private void menuItemSystemInformation_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (SystemInfoDlg systemInfoDlg = new SystemInfoDlg())
      {
        int num = (int) systemInfoDlg.ShowDialog();
      }
    }

    private void MenuItemAbout_Click(object sender, EventArgs e)
    {
      int num = (int) new AboutBox().ShowDialog();
    }

    private void MenuItemMaintainMedicalEvent_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new LookupEventTypeBrowserDetailUI());
    }

    private Control getFocussedControl(Control control)
    {
      if (control != null)
      {
        if (control.Focused)
          return control;
        foreach (Control control1 in (ArrangedElementCollection) control.Controls)
        {
          Control focussedControl = this.getFocussedControl(control1);
          if (focussedControl != null)
            return focussedControl;
        }
      }
      return (Control) null;
    }

    private ITeacherLocation getTeacherLocation()
    {
      foreach (Control control in (ArrangedElementCollection) this.panelMain.Controls)
      {
        if (control is ITeacherLocation && ((ITeacherLocation) control).Found)
          return (ITeacherLocation) control;
      }
      return (ITeacherLocation) null;
    }

    private void refreshInTouchMessageLists(object sender, EventArgs args)
    {
      foreach (Control control in (ArrangedElementCollection) this.panelMain.Controls)
      {
        if (control is IInTouchMessageList touchMessageList)
          touchMessageList.RefreshMessages();
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      Keys keys1 = keyData & Keys.Modifiers;
      Keys keys2 = keyData & Keys.KeyCode;
      if (this.ActiveControl != this.launcher)
      {
        Control focussedControl = this.getFocussedControl(this.ActiveControl);
        if (focussedControl != null && (focussedControl.Parent == null || !(focussedControl.Parent.GetType().Name == "LinksPanel")))
          this.controlActiveBeforeLauncherActivated = focussedControl;
      }
      if (keys1 == Keys.Control)
      {
        if (keys2 == Keys.D1)
        {
          this.launcher.FocusShortcuts();
          return true;
        }
        if (keys2 == Keys.D2)
        {
          this.launcher.FocusFavourites();
          return true;
        }
      }
      if (keys1 == (Keys.Shift | Keys.Control) && (keys2 == Keys.D1 || keys2 == Keys.D2 || (keys2 == Keys.H || keys2 == Keys.L)) && this.controlActiveBeforeLauncherActivated != null)
        this.controlActiveBeforeLauncherActivated.Focus();
      return base.ProcessCmdKey(ref msg, keyData);
    }

    protected void userMessageHandler(object sender, UserMessageEventArgs args)
    {
      System.Drawing.Icon icon;
      if (args.Message != string.Empty)
      {
        switch (args.MessageType)
        {
          case UserMessageEventEnum.Information:
            icon = this.notifyIconInformation.Icon;
            break;
          case UserMessageEventEnum.Warning:
            icon = this.notifyIconWarning.Icon;
            break;
          case UserMessageEventEnum.Error:
            icon = this.notifyIconError.Icon;
            break;
          default:
            icon = (System.Drawing.Icon) null;
            break;
        }
      }
      else
        icon = (System.Drawing.Icon) null;
      if (this.statusBarMenuItemHelpDescriptions)
      {
        this.statusBarPanelIconIcon = icon;
        this.statusBarPanelMessageText = args.Message + this.AddMessage();
      }
      else
      {
        if (this.statusBarPanelIcon.Icon != null)
          this.statusBarPanelIcon.Icon.Dispose();
        this.statusBarPanelIcon.Icon = icon;
        this.statusBarPanelMessage.Text = args.Message + this.AddMessage();
      }
    }

    private void statusBar_DrawItem(object sender, StatusBarDrawItemEventArgs args)
    {
      if (args.Panel != this.statusBarPanelMessage)
        return;
      Rectangle bounds = args.Bounds;
      ++bounds.X;
      --bounds.Width;
      TextRenderer.DrawText((IDeviceContext) args.Graphics, args.Panel.Text, args.Font, bounds, args.ForeColor, args.BackColor, TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ResourceManager resourceManager = new ResourceManager(typeof (MainContainer));
      this.statusBar = new System.Windows.Forms.StatusBar();
      this.statusBarPanelIcon = new StatusBarPanel();
      this.statusBarPanelMessage = new StatusBarPanel();
      this.mainMenu = new MainMenu();
      this.panelToolBar = new Panel();
      this.focusMenu = new UIMenuItem();
      this.menuItemHomePage = new UIMenuItem();
      this.menuItemCapita = new UIMenuItem();
      this.menuItemSolus = new UIMenuItem();
      this.menuItemCapitamyAccount = new UIMenuItem();
      this.menuItemToolsOptions = new UIMenuItem();
      this.menuItemToolsSeparator = new UIMenuItem();
      this.menuItemSetupMessage = new UIMenuItem();
      this.menuItemDataChangeManagement = new UIMenuItem();
      this.MenuItemSchool = new UIMenuItem();
      this.MenuItemPastoralStructure = new UIMenuItem();
      this.MenuItemCurrentPastoralStructure = new UIMenuItem();
      this.MenuItemNextAcademicYearPastoralStructure = new UIMenuItem();
      this.menuItemConfigurePastoralGroups = new UIMenuItem();
      this.menuItemAcademicStructure = new UIMenuItem();
      this.menuItemRooms = new UIMenuItem();
      this.MenuItemSchoolOrganiser = new UIMenuItem();
      this.MenuItemCalendar = new UIMenuItem();
      this.MenuItemStudent = new UIMenuItem();
      this.MenuItemStudentEdit = new UIMenuItem();
      this.menuItemAttendance = new UIMenuItem();
      this.menuItemToolsAttArchiving = new UIMenuItem();
      this.menuItemToolsAttArchivingArchive = new UIMenuItem();
      this.menuItemToolsAttArchivingHistory = new UIMenuItem();
      this.menuItemHomework = new UIMenuItem();
      this.menuItemAlerts = new UIMenuItem();
      this.menuItemStudentSEN = new UIMenuItem();
      this.menuItemExclusions = new UIMenuItem();
      this.MenuItemStudentHistory = new UIMenuItem();
      this.menuItemCurricStudent = new UIMenuItem();
      this.menuItemStudentConcessions = new UIMenuItem();
      this.menuItemBehaviourMgmt = new UIMenuItem();
      this.menuItemPeople = new UIMenuItem();
      this.menuItemEmployeeDetails = new UIMenuItem();
      this.menuItem4 = new UIMenuItem();
      this.MenuItemEditAgent = new UIMenuItem();
      this.menuItemGroups = new UIMenuItem();
      this.menuItemUserDefinedGroups = new UIMenuItem();
      this.menuItemAgency = new UIMenuItem();
      this.MenuItemEditAgency = new UIMenuItem();
      this.menuItemAdmission = new UIMenuItem();
      this.menuItemCommunication = new UIMenuItem();
      this.menuItemCommentEntry = new UIMenuItem();
      this.menuItemMarksheet = new UIMenuItem();
      this.MenuItemBreak1 = new UIMenuItem();
      this.MenuItemExit = new UIMenuItem();
      this.editMenu = new UIMenuItem();
      this.MenuImages = new ImageList(this.components);
      this.MenuItemUndo = new UIMenuItem();
      this.MenuItemBreak2 = new UIMenuItem();
      this.MenuItemCut = new UIMenuItem();
      this.MenuItemCopy = new UIMenuItem();
      this.MenuItemPaste = new UIMenuItem();
      this.MenuItemDelete = new UIMenuItem();
      this.MenuItemBreak4 = new UIMenuItem();
      this.MenuItemSelectAll = new UIMenuItem();
      this.MenuItemReports = new UIMenuItem();
      this.menuItemReportsBehaviour = new UIMenuItem();
      this.menuItemReportsBehaviourRunReportCard = new UIMenuItem();
      this.MenuItemRunReport = new UIMenuItem();
      this.MenuItemDesignReport = new UIMenuItem();
      this.menuItem1 = new UIMenuItem();
      this.menuItem2 = new UIMenuItem();
      this.menuItemImportReport = new UIMenuItem();
      this.menuItemExportReport = new UIMenuItem();
      this.menuItemFullSchoolReport = new UIMenuItem();
      this.menuItemPersonDataOutput = new UIMenuItem();
      this.menuItemRoutines = new UIMenuItem();
      this.menuItemAdmissions = new UIMenuItem();
      this.menuItemCoverTools = new UIMenuItem();
      this.menuItem24 = new UIMenuItem();
      this.menuItemImoprtFromEMS = new UIMenuItem();
      this.menuItemExportToEMS = new UIMenuItem();
      this.menuItemSchoolBase = new UIMenuItem();
      this.menuItemSchoolPromotion = new UIMenuItem();
      this.menuItemAcademicYear = new UIMenuItem();
      this.menuItemEditAcademicYear = new UIMenuItem();
      this.menuItemDeleteAcademicYear = new UIMenuItem();
      this.menuItemSchoolDetailsChange = new UIMenuItem();
      this.menuItemDataOut = new UIMenuItem();
      this.menuItemCBAExport = new UIMenuItem();
      this.menuItemINCASExport = new UIMenuItem();
      this.menuItemRecruitmentAgencyExport = new UIMenuItem();
      this.menuItemRecruitmentAgencyImport = new UIMenuItem();
      this.menuItemCTFout = new UIMenuItem();
      this.menuItemDataIn = new UIMenuItem();
      this.menuItemCTFin = new UIMenuItem();
      this.menuItemStatutoryReturns = new UIMenuItem();
      this.menuItemPLASCDENI = new UIMenuItem();
      this.menuItemPlasc = new UIMenuItem();
      this.menuItemAttendanceReturnSecondary = new UIMenuItem();
      this.menuItemAttendanceReturnPrimary = new UIMenuItem();
      this.menuItemRoutinesStudents = new UIMenuItem();
      this.menuItemBatchPhoto = new UIMenuItem();
      this.MenuItemPhotoImportStudentAdNo = new UIMenuItem();
      this.MenuItemPhotoImportStudentRgGp = new UIMenuItem();
      this.menuItemStudentBulkUpdate = new UIMenuItem();
      this.menuItemLeavers = new UIMenuItem();
      this.menuItemUpdateStudentAddressee = new UIMenuItem();
      this.menuItemUpdateParentalAddressee = new UIMenuItem();
      this.menuItemUpdateContactAddressee = new UIMenuItem();
      this.menuItemDeleteStudent = new UIMenuItem();
      this.menuItemChangeEnrolmentStatus = new UIMenuItem();
      this.menuItemRoutinesDocuments = new UIMenuItem();
      this.menuItemToolUploadDocuments = new UIMenuItem();
      this.menuItemToolMaintainDocuments = new UIMenuItem();
      this.menuItemToolMaintainDMS = new UIMenuItem();
      this.menuItemConnexionsMain = new UIMenuItem();
      this.menuItemCCardholderDetails = new UIMenuItem();
      this.menuItemCCardholderDownload = new UIMenuItem();
      this.menuItemCCardSeperator2 = new UIMenuItem();
      this.menuItemCCardAttSummaryExport = new UIMenuItem();
      this.menuItemCCardRequestResponseFile = new UIMenuItem();
      this.menuItem14 = new UIMenuItem();
      this.menuItemCCardReports = new UIMenuItem();
      this.menuItemCCardAttSummaryExportReport = new UIMenuItem();
      this.menuItemCCardSchemeMembersReport = new UIMenuItem();
      this.menuItemEMA = new UIMenuItem();
      this.menuItemB2B = new UIMenuItem();
      this.toolsMenu = new UIMenuItem();
      this.menuItemToolAdmissions = new UIMenuItem();
      this.menuItemLookupMaintenance = new UIMenuItem();
      this.menuItemMaintainLookup = new UIMenuItem();
      this.menuItemConfigureEthnicCodes = new UIMenuItem();
      this.menuItemExportLookups = new UIMenuItem();
      this.menuItemExternalSchools = new UIMenuItem();
      this.menuItemSetups = new UIMenuItem();
      this.menuItemSEN = new UIMenuItem();
      this.menuItemConcessionSetup = new UIMenuItem();
      this.menuItemSetupAddresseeFormat = new UIMenuItem();
      this.MenuItemDocumentServers = new UIMenuItem();
      this.MenuItemMaintainSIMSServices = new UIMenuItem();
      this.menuItemFilesetImport = new UIMenuItem();
      this.menuItemConnexionsCard = new UIMenuItem();
      this.menuItemEMASetup = new UIMenuItem();
      this.menuItemCTFSetup = new UIMenuItem();
      this.menuItemUDFSetup = new UIMenuItem();
      this.menuItemUserOptions = new UIMenuItem();
      this.menuItemToolsCurriculum = new UIMenuItem();
      this.menuItemHousekeeping = new UIMenuItem();
      this.menuItemToolsAcademic = new UIMenuItem();
      this.menuItemMaintainMedicalEvent = new UIMenuItem();
      this.menuItemPLASCTools = new UIMenuItem();
      this.menuItem12 = new UIMenuItem();
      this.menuItemReconcileExamLA = new UIMenuItem();
      this.menuItemReconcileExamEntries = new UIMenuItem();
      this.menuItemStudentCourses = new UIMenuItem();
      this.menuItemUpdateCourseClassification = new UIMenuItem();
      this.menuItemImportQansForCM = new UIMenuItem();
      this.menuItemImportQWADForCM = new UIMenuItem();
      this.menuItemDuplicateQANReport = new UIMenuItem();
      this.MenuItemCheckForUpdate = new UIMenuItem();
      this.menuItemSysDiag = new UIMenuItem();
      this.menuItemMembershipFix = new UIMenuItem();
      this.menuItemAuthoriseSIMSPrimaryTransfer = new UIMenuItem();
      this.WindowMenu = new UIMenuItem();
      this.menuItemShowLauncher = new UIMenuItem();
      this.helpMenu = new UIMenuItem();
      this.MenuItemContents = new UIMenuItem();
      this.MenuItemSearch = new UIMenuItem();
      this.MenuItemGettingStarted = new UIMenuItem();
      this.MenuItemTechnicalSupport = new UIMenuItem();
      this.MenuItemHowToUseHelp = new UIMenuItem();
      this.menuItemSystemInformation = new UIMenuItem();
      this.MenuItemBreak6 = new UIMenuItem();
      this.MenuItemAbout = new UIMenuItem();
      this.menuItemNDCWales = new UIMenuItem();
      this.menuItemPost16Autumn = new UIMenuItem();
      this.menuItemPost16Summer = new UIMenuItem();
      this.menuItemWelshAttendanceCollection = new UIMenuItem();
      this.menuItemWelshAttendanceCollectionMiddle = new UIMenuItem();
      this.menuItemCCardSetup = new UIMenuItem();
      this.menuItemCCardSeperator1 = new UIMenuItem();
      this.menuItemEmergencyAlertSetup = new UIMenuItem();
      this.menuItemSendEmergencyAlert = new UIMenuItem();
      this.menuItemSetSchoolWorkingDays = new UIMenuItem();
      this.menuItemSchoolOptions = new UIMenuItem();
      this.menuItemInterventions = new UIMenuItem();
      this.menuItemInterventionsReports = new UIMenuItem();
      this.menuItemFocusASM = new UIMenuItem();
      this.menuItemFocusProfiles = new UIMenuItem();
      this.menuItemToolsASMTools = new UIMenuItem();
      this.menuItemToolsPAAnalysis = new UIMenuItem();
      this.menuItemToolsPATools = new UIMenuItem();
      this.menuItemAssessmentPoSAnalysis = new UIMenuItem();
      this.menuItemPoSAnalysisSummativeAttainment = new UIMenuItem();
      this.menuItemPoSAnalysisFormativeAttainment = new UIMenuItem();
      this.menuItemPoSAnalysisSummativeProgress = new UIMenuItem();
      this.menuItemPoSAnalysisFormativeProgress = new UIMenuItem();
      this.menuItemReportAssessmentMissingResults = new UIMenuItem();
      this.menuItemReportPoS = new UIMenuItem();
      this.menuItemReportPoSSubjectStrandIndividual = new UIMenuItem();
      this.menuItemReportProfiles = new UIMenuItem();
      this.menuItemReportAssessment = new UIMenuItem();
      this.menuItemDataOutASM = new UIMenuItem();
      this.menuItemDataOutPA = new UIMenuItem();
      this.menuItemDataInPA = new UIMenuItem();
      this.menuItemDataInASM = new UIMenuItem();
      this.menuItemADMImportEnquiry = new UIMenuItem();
      this.menuItemADMImportApplication = new UIMenuItem();
      this.menuItemToolsProfilesTools = new UIMenuItem();
      this.menuItemSeperator1 = new UIMenuItem();
      this.menuItemBulkAddressTools = new UIMenuItem();
      this.menuItemBulkAddressValidationScheduler = new UIMenuItem();
      this.menuItemBABulkAddressValidationSchedule = new UIMenuItem();
      this.menuItemBAVOtherSchools = new UIMenuItem();
      this.menuItemBAVApplicantsAndContacts = new UIMenuItem();
      this.menuItemBAVStudentsAndContacts = new UIMenuItem();
      this.menuItemBAVEnquierAddress = new UIMenuItem();
      this.menuItemBAVStaff = new UIMenuItem();
      this.menuItemBAVAgents = new UIMenuItem();
      this.menuItemBAVAgencies = new UIMenuItem();
      this.menuItemBABulkAddressValidation = new UIMenuItem();
      this.menuItemTidyAndMergeAddresses = new UIMenuItem();
      this.menuItemUnmatchableAddressesReport = new UIMenuItem();
      this.menuItemAddressTidyAndMergeSetup = new UIMenuItem();
      this.menuItemFeesBillingRoutines = new UIMenuItem();
      this.menuItemFeesBillingTools = new UIMenuItem();
      this.menuItemFees = new UIMenuItem();
      this.menuItemImportLookups = new UIMenuItem();
      this.launcher = new Launcher2();
      this.panelOptions = new Panel();
      this.splitterVertical = new Splitter();
      this.imageListStatusBar = new ImageList(this.components);
      this.panelMain = new Panel();
      this.commandBarRight = new CommandBar();
      this.commandBarNavigation = new CommandBar();
      this.commandBarButtonItemBack = new CommandBarButtonItem();
      this.commandBarButtonItemForward = new CommandBarButtonItem();
      this.commandBarSeparatorItemNavigation = new CommandBarSeparatorItem();
      this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
      this.commandBarItemShowLauncher = new CommandBarButtonItem();
      this.imageListNavigation = new ImageList(this.components);
      this.notifyIconInformation = new NotifyIcon(this.components);
      this.notifyIconWarning = new NotifyIcon(this.components);
      this.notifyIconError = new NotifyIcon(this.components);
      this.imageListOfflineShortcuts = new ImageList(this.components);
      this.menuASCIS = new UIMenuItem();
      this.menuISC = new UIMenuItem();
      this.menuItemPersonnelReport = new UIMenuItem();
      this.menuItemStaffPerformanceReport = new UIMenuItem();
      this.menuItemStaffLineManagementReport = new UIMenuItem();
      this.menuItemStaffObservationsReport = new UIMenuItem();
      this.menuItemStaffAnalysisByGradeReport = new UIMenuItem();
      this.menuItemStaffAnalysisByProfessionalStandardReport = new UIMenuItem();
      this.menuItemStaff = new UIMenuItem();
      this.menuItemRoutinesStaffs = new UIMenuItem();
      this.menuItemAuditLogReport = new UIMenuItem();
      this.menuItemAuditLogLineManagementReport = new UIMenuItem();
      this.menuItemAuditLogStaffPerformanceReport = new UIMenuItem();
      this.menuItemPupilPremium = new UIMenuItem();
      this.menuItemAttendanceReports = new UIMenuItem();
      this.menuItemAttendanceSetup = new UIMenuItem();
      this.menuItemLessonMonitorOptions = new UIMenuItem();
      this.menuItemAttendanceRoutines = new UIMenuItem();
      this.menuItemAttendanceModuleSetup = new UIMenuItem();
      this.menuItemAttendanceOMRSetup = new UIMenuItem();
      this.menuItemATWRegistrationOrganisation = new UIMenuItem();
      this.menuItemCodes = new UIMenuItem();
      this.menuItemMaintainCodes = new UIMenuItem();
      this.menuItemLateCodes = new UIMenuItem();
      this.menuItemPartTimePupils = new UIMenuItem();
      this.menuItemLetterDefinition = new UIMenuItem();
      this.menuItemEditQuickLetter = new UIMenuItem();
      this.statusBarPanelIcon.BeginInit();
      this.statusBarPanelMessage.BeginInit();
      this.panelToolBar.SuspendLayout();
      this.panelOptions.SuspendLayout();
      this.panelMain.SuspendLayout();
      this.commandBarRight.BeginInit();
      this.commandBarNavigation.BeginInit();
      this.SuspendLayout();
      this.statusBar.Location = new System.Drawing.Point(0, 503);
      this.statusBar.Name = "statusBar";
      this.statusBar.Panels.AddRange(new StatusBarPanel[2]
      {
        this.statusBarPanelIcon,
        this.statusBarPanelMessage
      });
      this.statusBar.ShowPanels = true;
      this.statusBar.Size = new Size(893, 22);
      this.statusBar.TabIndex = 0;
      this.statusBar.DrawItem += new StatusBarDrawItemEventHandler(this.statusBar_DrawItem);
      this.statusBarPanelIcon.BorderStyle = StatusBarPanelBorderStyle.None;
      this.statusBarPanelIcon.Width = 24;
      this.statusBarPanelMessage.AutoSize = StatusBarPanelAutoSize.Spring;
      this.statusBarPanelMessage.Style = StatusBarPanelStyle.OwnerDraw;
      this.statusBarPanelMessage.Text = "Ready" + this.AddMessage();
      this.statusBarPanelMessage.Width = 853;
      this.mainMenu.MenuItems.AddRange(new MenuItem[7]
      {
        (MenuItem) this.focusMenu,
        (MenuItem) this.editMenu,
        (MenuItem) this.MenuItemReports,
        (MenuItem) this.menuItemRoutines,
        (MenuItem) this.toolsMenu,
        (MenuItem) this.WindowMenu,
        (MenuItem) this.helpMenu
      });
      this.focusMenu.BaseName = "focusMenu";
      this.focusMenu.ImageIndex = -1;
      this.focusMenu.ImageList = (ImageList) null;
      this.focusMenu.Index = 0;
      this.focusMenu.MenuItems.AddRange(new MenuItem[21]
      {
        (MenuItem) this.menuItemHomePage,
        (MenuItem) this.MenuItemSchool,
        (MenuItem) this.MenuItemStudent,
        (MenuItem) this.menuItemBehaviourMgmt,
        (MenuItem) this.menuItemPeople,
        (MenuItem) this.menuItemGroups,
        (MenuItem) this.menuItemAgency,
        (MenuItem) this.menuItemAdmission,
        (MenuItem) this.menuItemAttendance,
        (MenuItem) this.menuItemFees,
        (MenuItem) this.menuItemCommunication,
        (MenuItem) this.menuItemAlerts,
        (MenuItem) this.menuItemFocusASM,
        (MenuItem) this.menuItemFocusProfiles,
        (MenuItem) this.menuItemHomework,
        (MenuItem) this.menuItemSeperator1,
        (MenuItem) this.menuItemCommentEntry,
        (MenuItem) this.menuItemMarksheet,
        (MenuItem) this.menuItemInterventions,
        (MenuItem) this.MenuItemBreak1,
        (MenuItem) this.menuItemToolsOptions
      });
      this.focusMenu.NoEdit = false;
      this.focusMenu.NoUIModify = false;
      this.focusMenu.OriginalText = "";
      this.focusMenu.OwnerDraw = true;
      this.focusMenu.Text = "&Focus";
      this.menuItemHomePage.ImageIndex = -1;
      this.menuItemHomePage.ImageList = (ImageList) null;
      this.menuItemHomePage.Index = 0;
      this.menuItemHomePage.NoEdit = false;
      this.menuItemHomePage.NoUIModify = false;
      this.menuItemHomePage.OriginalText = "";
      this.menuItemHomePage.OwnerDraw = true;
      this.menuItemHomePage.Text = "&Home Page";
      this.menuItemHomePage.Shortcut = Shortcut.CtrlQ;
      this.menuItemHomePage.Click += new EventHandler(this.menuItemHomePage_Click);
      this.MenuItemSchool.ImageIndex = -1;
      this.MenuItemSchool.ImageList = (ImageList) null;
      this.MenuItemSchool.Index = 1;
      this.MenuItemSchool.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.MenuItemPastoralStructure,
        (MenuItem) this.menuItemAcademicStructure,
        (MenuItem) this.menuItemRooms,
        (MenuItem) this.MenuItemSchoolOrganiser,
        (MenuItem) this.MenuItemCalendar
      });
      this.MenuItemSchool.NoEdit = false;
      this.MenuItemSchool.NoUIModify = false;
      this.MenuItemSchool.OriginalText = "";
      this.MenuItemSchool.OwnerDraw = true;
      this.MenuItemSchool.Text = "S&chool";
      this.MenuItemPastoralStructure.ImageIndex = -1;
      this.MenuItemPastoralStructure.ImageList = (ImageList) null;
      this.MenuItemPastoralStructure.Index = 0;
      this.MenuItemPastoralStructure.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) this.MenuItemCurrentPastoralStructure,
        (MenuItem) this.MenuItemNextAcademicYearPastoralStructure,
        (MenuItem) this.menuItemConfigurePastoralGroups
      });
      this.MenuItemPastoralStructure.NoEdit = false;
      this.MenuItemPastoralStructure.NoUIModify = false;
      this.MenuItemPastoralStructure.OriginalText = "";
      this.MenuItemPastoralStructure.OwnerDraw = true;
      this.MenuItemPastoralStructure.Text = "&Pastoral Structure";
      this.MenuItemCurrentPastoralStructure.ImageIndex = -1;
      this.MenuItemCurrentPastoralStructure.ImageList = (ImageList) null;
      this.MenuItemCurrentPastoralStructure.Index = 0;
      this.MenuItemCurrentPastoralStructure.NoEdit = false;
      this.MenuItemCurrentPastoralStructure.NoUIModify = false;
      this.MenuItemCurrentPastoralStructure.OriginalText = "";
      this.MenuItemCurrentPastoralStructure.OwnerDraw = true;
      this.MenuItemCurrentPastoralStructure.Text = "&Current Structure";
      this.MenuItemCurrentPastoralStructure.Click += new EventHandler(this.MenuItemCurrentPastoralStructure_Click);
      this.MenuItemNextAcademicYearPastoralStructure.ImageIndex = -1;
      this.MenuItemNextAcademicYearPastoralStructure.ImageList = (ImageList) null;
      this.MenuItemNextAcademicYearPastoralStructure.Index = 1;
      this.MenuItemNextAcademicYearPastoralStructure.NoEdit = false;
      this.MenuItemNextAcademicYearPastoralStructure.NoUIModify = false;
      this.MenuItemNextAcademicYearPastoralStructure.OriginalText = "";
      this.MenuItemNextAcademicYearPastoralStructure.OwnerDraw = true;
      this.MenuItemNextAcademicYearPastoralStructure.Text = "&Next Academic Year Structure";
      this.MenuItemNextAcademicYearPastoralStructure.Click += new EventHandler(this.MenuItemNextAcademicYearPastoralStructure_Click);
      this.menuItemConfigurePastoralGroups.ImageIndex = -1;
      this.menuItemConfigurePastoralGroups.ImageList = (ImageList) null;
      this.menuItemConfigurePastoralGroups.Index = 2;
      this.menuItemConfigurePastoralGroups.NoEdit = false;
      this.menuItemConfigurePastoralGroups.NoUIModify = false;
      this.menuItemConfigurePastoralGroups.OriginalText = "";
      this.menuItemConfigurePastoralGroups.OwnerDraw = true;
      this.menuItemConfigurePastoralGroups.Text = "&Group Supervisors";
      this.menuItemConfigurePastoralGroups.Click += new EventHandler(this.menuItemConfigurePastoralGroups_Click);
      this.menuItemAcademicStructure.ImageIndex = -1;
      this.menuItemAcademicStructure.ImageList = (ImageList) null;
      this.menuItemAcademicStructure.Index = 1;
      this.menuItemAcademicStructure.NoEdit = false;
      this.menuItemAcademicStructure.NoUIModify = false;
      this.menuItemAcademicStructure.OriginalText = "";
      this.menuItemAcademicStructure.OwnerDraw = true;
      this.menuItemAcademicStructure.Text = "&Academic Structure";
      this.menuItemRooms.ImageIndex = -1;
      this.menuItemRooms.ImageList = (ImageList) null;
      this.menuItemRooms.Index = 2;
      this.menuItemRooms.NoEdit = false;
      this.menuItemRooms.NoUIModify = false;
      this.menuItemRooms.OriginalText = "";
      this.menuItemRooms.OwnerDraw = true;
      this.menuItemRooms.Text = "&Rooms";
      this.menuItemRooms.Click += new EventHandler(this.menuItemRooms_Click);
      this.MenuItemSchoolOrganiser.ImageIndex = -1;
      this.MenuItemSchoolOrganiser.ImageList = (ImageList) null;
      this.MenuItemSchoolOrganiser.Index = 3;
      this.MenuItemSchoolOrganiser.NoEdit = false;
      this.MenuItemSchoolOrganiser.NoUIModify = false;
      this.MenuItemSchoolOrganiser.OriginalText = "";
      this.MenuItemSchoolOrganiser.OwnerDraw = true;
      this.MenuItemSchoolOrganiser.Text = "School &Details";
      this.MenuItemSchoolOrganiser.Click += new EventHandler(this.MenuItemSchoolOrganiser_Click);
      this.MenuItemCalendar.ImageIndex = -1;
      this.MenuItemCalendar.ImageList = (ImageList) null;
      this.MenuItemCalendar.Index = 4;
      this.MenuItemCalendar.NoEdit = false;
      this.MenuItemCalendar.NoUIModify = false;
      this.MenuItemCalendar.OriginalText = "";
      this.MenuItemCalendar.OwnerDraw = true;
      this.MenuItemCalendar.Text = "School Diar&y";
      this.MenuItemCalendar.Click += new EventHandler(this.MenuItemCalendar_Click);
      this.MenuItemStudent.BaseName = "MenuItemStudent";
      this.MenuItemStudent.ImageIndex = -1;
      this.MenuItemStudent.ImageList = (ImageList) null;
      this.MenuItemStudent.Index = 2;
      this.MenuItemStudent.MenuItems.AddRange(new MenuItem[7]
      {
        (MenuItem) this.MenuItemStudentEdit,
        (MenuItem) this.menuItemStudentSEN,
        (MenuItem) this.menuItemExclusions,
        (MenuItem) this.MenuItemStudentHistory,
        (MenuItem) this.menuItemCurricStudent,
        (MenuItem) this.menuItemStudentConcessions,
        (MenuItem) this.menuItemStudentCourses
      });
      this.MenuItemStudent.NoEdit = false;
      this.MenuItemStudent.NoUIModify = false;
      this.MenuItemStudent.OriginalText = "";
      this.MenuItemStudent.OwnerDraw = true;
      this.MenuItemStudent.Text = "&Student";
      this.MenuItemStudentEdit.ImageIndex = -1;
      this.MenuItemStudentEdit.ImageList = (ImageList) null;
      this.MenuItemStudentEdit.Index = 0;
      this.MenuItemStudentEdit.NoEdit = false;
      this.MenuItemStudentEdit.NoUIModify = false;
      this.MenuItemStudentEdit.OriginalText = "&Student Details";
      this.MenuItemStudentEdit.OwnerDraw = true;
      this.MenuItemStudentEdit.Text = "&Student Details";
      this.MenuItemStudentEdit.Click += new EventHandler(this.MenuItemEditStudent_Click);
      this.menuItemStudentSEN.ImageIndex = -1;
      this.menuItemStudentSEN.ImageList = (ImageList) null;
      this.menuItemStudentSEN.Index = 2;
      this.menuItemStudentSEN.NoEdit = false;
      this.menuItemStudentSEN.NoUIModify = false;
      this.menuItemStudentSEN.OriginalText = "Special Educational &Needs";
      this.menuItemStudentSEN.OwnerDraw = true;
      this.menuItemStudentSEN.Text = "Special Educational &Needs";
      this.menuItemStudentSEN.Click += new EventHandler(this.menuItemStudentSEN_Click);
      this.menuItemExclusions.ImageIndex = -1;
      this.menuItemExclusions.ImageList = (ImageList) null;
      this.menuItemExclusions.Index = 3;
      this.menuItemExclusions.NoEdit = false;
      this.menuItemExclusions.NoUIModify = false;
      this.menuItemExclusions.OriginalText = "";
      this.menuItemExclusions.OwnerDraw = true;
      this.menuItemExclusions.Text = "E&xclusions";
      this.menuItemExclusions.Click += new EventHandler(this.menuItemExclusions_Click);
      this.MenuItemStudentHistory.ImageIndex = -1;
      this.MenuItemStudentHistory.ImageList = (ImageList) null;
      this.MenuItemStudentHistory.Index = 4;
      this.MenuItemStudentHistory.NoEdit = false;
      this.MenuItemStudentHistory.NoUIModify = false;
      this.MenuItemStudentHistory.OriginalText = "&Education History";
      this.MenuItemStudentHistory.OwnerDraw = true;
      this.MenuItemStudentHistory.Text = "&Education History";
      this.MenuItemStudentHistory.Click += new EventHandler(this.MenuItemStudentHistory_Click);
      this.menuItemCurricStudent.ImageIndex = -1;
      this.menuItemCurricStudent.ImageList = (ImageList) null;
      this.menuItemCurricStudent.Index = 5;
      this.menuItemCurricStudent.NoEdit = false;
      this.menuItemCurricStudent.NoUIModify = false;
      this.menuItemCurricStudent.OriginalText = "";
      this.menuItemCurricStudent.OwnerDraw = true;
      this.menuItemCurricStudent.Text = "&Curriculum Assignment by " + SIMS.Entities.Cache.UserInterfaceLabel("Student");
      this.menuItemStudentConcessions.ImageIndex = -1;
      this.menuItemStudentConcessions.ImageList = (ImageList) null;
      this.menuItemStudentConcessions.Index = 5;
      this.menuItemStudentConcessions.NoEdit = false;
      this.menuItemStudentConcessions.NoUIModify = false;
      this.menuItemStudentConcessions.OriginalText = "";
      this.menuItemStudentConcessions.OwnerDraw = true;
      this.menuItemStudentConcessions.Text = "C&oncessions";
      this.menuItemStudentConcessions.Click += new EventHandler(this.menuItemStudentConcessions_Click);
      this.menuItemStudentCourses.ImageIndex = -1;
      this.menuItemStudentCourses.ImageList = (ImageList) null;
      this.menuItemStudentCourses.Index = 6;
      this.menuItemStudentCourses.NoEdit = false;
      this.menuItemStudentCourses.NoUIModify = false;
      this.menuItemStudentCourses.OriginalText = "";
      this.menuItemStudentCourses.OwnerDraw = true;
      this.menuItemStudentCourses.Text = "Co&urses";
      this.menuItemStudentCourses.Click += new EventHandler(this.menuItemStudentCourses_Click);
      this.menuItemBehaviourMgmt.ImageIndex = -1;
      this.menuItemBehaviourMgmt.ImageList = (ImageList) null;
      this.menuItemBehaviourMgmt.Index = 3;
      this.menuItemBehaviourMgmt.NoEdit = false;
      this.menuItemBehaviourMgmt.NoUIModify = false;
      this.menuItemBehaviourMgmt.OriginalText = "";
      this.menuItemBehaviourMgmt.OwnerDraw = true;
      this.menuItemBehaviourMgmt.Text = "&Behaviour Management";
      this.menuItemInterventions.ImageIndex = -1;
      this.menuItemInterventions.ImageList = (ImageList) null;
      this.menuItemInterventions.Index = 4;
      this.menuItemInterventions.NoEdit = false;
      this.menuItemInterventions.NoUIModify = false;
      this.menuItemInterventions.OriginalText = "";
      this.menuItemInterventions.OwnerDraw = true;
      this.menuItemInterventions.Text = "&Interventions";
      this.menuItemPeople.ImageIndex = -1;
      this.menuItemPeople.ImageList = (ImageList) null;
      this.menuItemPeople.Index = 5;
      this.menuItemPeople.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) this.menuItemEmployeeDetails,
        (MenuItem) this.menuItem4,
        (MenuItem) this.MenuItemEditAgent
      });
      this.menuItemPeople.NoEdit = false;
      this.menuItemPeople.NoUIModify = false;
      this.menuItemPeople.OriginalText = "";
      this.menuItemPeople.OwnerDraw = true;
      this.menuItemPeople.Text = "&Person";
      this.menuItemEmployeeDetails.ImageIndex = -1;
      this.menuItemEmployeeDetails.ImageList = (ImageList) null;
      this.menuItemEmployeeDetails.Index = 0;
      this.menuItemEmployeeDetails.NoEdit = false;
      this.menuItemEmployeeDetails.NoUIModify = false;
      this.menuItemEmployeeDetails.OriginalText = "";
      this.menuItemEmployeeDetails.OwnerDraw = true;
      this.menuItemEmployeeDetails.Text = "&Staff";
      this.menuItemEmployeeDetails.Click += new EventHandler(this.MenuItemBrowseEmployee_Click);
      this.menuItem4.ImageIndex = -1;
      this.menuItem4.ImageList = (ImageList) null;
      this.menuItem4.Index = 1;
      this.menuItem4.NoEdit = false;
      this.menuItem4.NoUIModify = false;
      this.menuItem4.OriginalText = "";
      this.menuItem4.OwnerDraw = true;
      this.menuItem4.Text = "&Contacts";
      this.menuItem4.Click += new EventHandler(this.MenuItemContactsEdit_Click);
      this.MenuItemEditAgent.ImageIndex = -1;
      this.MenuItemEditAgent.ImageList = (ImageList) null;
      this.MenuItemEditAgent.Index = 2;
      this.MenuItemEditAgent.NoEdit = false;
      this.MenuItemEditAgent.NoUIModify = false;
      this.MenuItemEditAgent.OriginalText = "";
      this.MenuItemEditAgent.OwnerDraw = true;
      this.MenuItemEditAgent.Text = "A&gents";
      this.MenuItemEditAgent.Click += new EventHandler(this.MenuItemEditAgent_Click);
      this.menuItemGroups.BaseName = "menuItemGroups";
      this.menuItemGroups.ImageIndex = -1;
      this.menuItemGroups.ImageList = (ImageList) null;
      this.menuItemGroups.Index = 6;
      this.menuItemGroups.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemUserDefinedGroups
      });
      this.menuItemGroups.NoEdit = false;
      this.menuItemGroups.NoUIModify = false;
      this.menuItemGroups.OriginalText = "";
      this.menuItemGroups.OwnerDraw = true;
      this.menuItemGroups.Text = "&Groups";
      this.menuItemUserDefinedGroups.ImageIndex = -1;
      this.menuItemUserDefinedGroups.ImageList = (ImageList) null;
      this.menuItemUserDefinedGroups.Index = 0;
      this.menuItemUserDefinedGroups.NoEdit = false;
      this.menuItemUserDefinedGroups.NoUIModify = false;
      this.menuItemUserDefinedGroups.OriginalText = "";
      this.menuItemUserDefinedGroups.OwnerDraw = true;
      this.menuItemUserDefinedGroups.Text = "&User Defined Groups";
      this.menuItemUserDefinedGroups.Click += new EventHandler(this.MenuItemUDG_Click);
      this.menuItemAgency.ImageIndex = -1;
      this.menuItemAgency.ImageList = (ImageList) null;
      this.menuItemAgency.Index = 7;
      this.menuItemAgency.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.MenuItemEditAgency
      });
      this.menuItemAgency.NoEdit = false;
      this.menuItemAgency.NoUIModify = false;
      this.menuItemAgency.OriginalText = "";
      this.menuItemAgency.OwnerDraw = true;
      this.menuItemAgency.Text = "Agenc&y";
      this.MenuItemEditAgency.ImageIndex = -1;
      this.MenuItemEditAgency.ImageList = (ImageList) null;
      this.MenuItemEditAgency.Index = 0;
      this.MenuItemEditAgency.NoEdit = false;
      this.MenuItemEditAgency.NoUIModify = false;
      this.MenuItemEditAgency.OriginalText = "";
      this.MenuItemEditAgency.OwnerDraw = true;
      this.MenuItemEditAgency.Text = "&Agencies";
      this.MenuItemEditAgency.Click += new EventHandler(this.MenuItemEditAgency_Click);
      this.menuItemAdmission.ImageIndex = -1;
      this.menuItemAdmission.ImageList = (ImageList) null;
      this.menuItemAdmission.Index = 8;
      this.menuItemAdmission.NoEdit = false;
      this.menuItemAdmission.NoUIModify = false;
      this.menuItemAdmission.OriginalText = "";
      this.menuItemAdmission.OwnerDraw = true;
      this.menuItemAdmission.Text = "&Admission";
      this.menuItemAttendance.BaseName = "menuItemAttendance";
      this.menuItemAttendance.ImageIndex = -1;
      this.menuItemAttendance.ImageList = (ImageList) null;
      this.menuItemAttendance.Index = 9;
      this.menuItemAttendance.NoEdit = false;
      this.menuItemAttendance.NoUIModify = false;
      this.menuItemAttendance.OriginalText = "";
      this.menuItemAttendance.OwnerDraw = true;
      this.menuItemAttendance.Text = "A&ttendance";
      this.menuItemToolsAttArchiving.BaseName = "menuItemToolsAttArchiving";
      this.menuItemToolsAttArchiving.ImageIndex = -1;
      this.menuItemToolsAttArchiving.ImageList = (ImageList) null;
      this.menuItemToolsAttArchiving.Index = 10;
      this.menuItemToolsAttArchiving.NoEdit = false;
      this.menuItemToolsAttArchiving.NoUIModify = false;
      this.menuItemToolsAttArchiving.OriginalText = "";
      this.menuItemToolsAttArchiving.OwnerDraw = true;
      this.menuItemToolsAttArchiving.Text = "A&rchive Attendance Marks";
      this.menuItemToolsAttArchiving.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemToolsAttArchivingArchive,
        (MenuItem) this.menuItemToolsAttArchivingHistory
      });
      this.menuItemToolsAttArchivingArchive.ImageIndex = -1;
      this.menuItemToolsAttArchivingArchive.ImageList = (ImageList) null;
      this.menuItemToolsAttArchivingArchive.Index = 0;
      this.menuItemToolsAttArchivingArchive.NoEdit = false;
      this.menuItemToolsAttArchivingArchive.NoUIModify = false;
      this.menuItemToolsAttArchivingArchive.OriginalText = "";
      this.menuItemToolsAttArchivingArchive.OwnerDraw = true;
      this.menuItemToolsAttArchivingArchive.Text = "&Archive";
      this.menuItemToolsAttArchivingArchive.Click += new EventHandler(this.menuItemToolsAttArchivingArchive_Click);
      this.menuItemToolsAttArchivingHistory.ImageIndex = -1;
      this.menuItemToolsAttArchivingHistory.ImageList = (ImageList) null;
      this.menuItemToolsAttArchivingHistory.Index = 1;
      this.menuItemToolsAttArchivingHistory.NoEdit = false;
      this.menuItemToolsAttArchivingHistory.NoUIModify = false;
      this.menuItemToolsAttArchivingHistory.OriginalText = "";
      this.menuItemToolsAttArchivingHistory.OwnerDraw = true;
      this.menuItemToolsAttArchivingHistory.Text = "View Archive &History";
      this.menuItemToolsAttArchivingHistory.Click += new EventHandler(this.menuItemToolsAttArchivingHistory_Click);
      this.menuItemCommunication.ImageIndex = -1;
      this.menuItemCommunication.ImageList = (ImageList) null;
      this.menuItemCommunication.Index = 11;
      this.menuItemCommunication.NoEdit = false;
      this.menuItemCommunication.NoUIModify = false;
      this.menuItemCommunication.OriginalText = "";
      this.menuItemCommunication.OwnerDraw = true;
      this.menuItemCommunication.Text = "&Communication";
      this.menuItemSendEmergencyAlert.ImageIndex = -1;
      this.menuItemSendEmergencyAlert.ImageList = (ImageList) null;
      this.menuItemSendEmergencyAlert.Index = 3;
      this.menuItemSendEmergencyAlert.NoEdit = false;
      this.menuItemSendEmergencyAlert.NoUIModify = false;
      this.menuItemSendEmergencyAlert.OriginalText = "";
      this.menuItemSendEmergencyAlert.OwnerDraw = true;
      this.menuItemSendEmergencyAlert.Text = "Send &Emergency Alert";
      this.menuItemSendEmergencyAlert.Click += new EventHandler(this.menuItemSendEmergencyAlert_Click);
      this.menuItemFocusASM.BaseName = "menuItemFocusASM";
      this.menuItemFocusASM.ImageIndex = -1;
      this.menuItemFocusASM.ImageList = (ImageList) null;
      this.menuItemFocusASM.Index = 12;
      this.menuItemFocusASM.NoEdit = false;
      this.menuItemFocusASM.NoUIModify = false;
      this.menuItemFocusASM.OriginalText = "";
      this.menuItemFocusASM.OwnerDraw = true;
      this.menuItemFocusASM.Text = "Assessme&nt";
      this.menuItemFocusProfiles.ImageIndex = -1;
      this.menuItemFocusProfiles.ImageList = (ImageList) null;
      this.menuItemFocusProfiles.Index = 13;
      this.menuItemFocusProfiles.NoEdit = false;
      this.menuItemFocusProfiles.NoUIModify = false;
      this.menuItemFocusProfiles.OriginalText = "";
      this.menuItemFocusProfiles.OwnerDraw = true;
      this.menuItemFocusProfiles.Text = "Pro&files";
      this.menuItemHomework.BaseName = "menuItemHomework";
      this.menuItemHomework.ImageIndex = -1;
      this.menuItemHomework.Index = 14;
      this.menuItemHomework.ImageList = (ImageList) null;
      this.menuItemHomework.NoEdit = false;
      this.menuItemHomework.NoUIModify = false;
      this.menuItemHomework.OriginalText = "";
      this.menuItemHomework.OwnerDraw = true;
      this.menuItemHomework.Text = "Home&work";
      this.MenuItemBreak1.ImageIndex = -1;
      this.MenuItemBreak1.ImageList = (ImageList) null;
      this.MenuItemBreak1.Index = 15;
      this.MenuItemBreak1.NoEdit = false;
      this.MenuItemBreak1.NoUIModify = false;
      this.MenuItemBreak1.OriginalText = "";
      this.MenuItemBreak1.OwnerDraw = true;
      this.MenuItemBreak1.Text = "-";
      this.menuItemCommentEntry.ImageIndex = -1;
      this.menuItemCommentEntry.ImageList = (ImageList) null;
      this.menuItemCommentEntry.Index = 16;
      this.menuItemCommentEntry.NoEdit = false;
      this.menuItemCommentEntry.NoUIModify = false;
      this.menuItemCommentEntry.OriginalText = "";
      this.menuItemCommentEntry.OwnerDraw = true;
      this.menuItemCommentEntry.Text = "My List &Entry";
      this.menuItemMarksheet.ImageIndex = -1;
      this.menuItemMarksheet.ImageList = (ImageList) null;
      this.menuItemMarksheet.Index = 17;
      this.menuItemMarksheet.NoEdit = false;
      this.menuItemMarksheet.NoUIModify = false;
      this.menuItemMarksheet.OriginalText = "";
      this.menuItemMarksheet.OwnerDraw = true;
      this.menuItemMarksheet.Text = "My &Marksheet Entry";
      this.menuItemSeperator1.ImageIndex = -1;
      this.menuItemSeperator1.ImageList = (ImageList) null;
      this.menuItemSeperator1.Index = 18;
      this.menuItemSeperator1.NoEdit = false;
      this.menuItemSeperator1.NoUIModify = false;
      this.menuItemSeperator1.OriginalText = "";
      this.menuItemSeperator1.OwnerDraw = true;
      this.menuItemSeperator1.Text = "-";
      this.MenuItemExit.ImageIndex = -1;
      this.MenuItemExit.ImageList = (ImageList) null;
      this.MenuItemExit.NoEdit = false;
      this.MenuItemExit.NoUIModify = false;
      this.MenuItemExit.OriginalText = "";
      this.MenuItemExit.OwnerDraw = true;
      this.MenuItemExit.Text = "E&xit";
      this.MenuItemExit.Click += new EventHandler(this.MenuItemExit_Click);
      this.editMenu.ImageIndex = -1;
      this.editMenu.ImageList = this.MenuImages;
      this.editMenu.Index = 1;
      this.editMenu.MenuItems.AddRange(new MenuItem[8]
      {
        (MenuItem) this.MenuItemUndo,
        (MenuItem) this.MenuItemBreak2,
        (MenuItem) this.MenuItemCut,
        (MenuItem) this.MenuItemCopy,
        (MenuItem) this.MenuItemPaste,
        (MenuItem) this.MenuItemDelete,
        (MenuItem) this.MenuItemBreak4,
        (MenuItem) this.MenuItemSelectAll
      });
      this.editMenu.NoEdit = false;
      this.editMenu.NoUIModify = false;
      this.editMenu.OriginalText = "";
      this.editMenu.OwnerDraw = true;
      this.editMenu.Text = "&Edit";
      this.MenuImages.ImageSize = new Size(16, 16);
      this.MenuImages.ImageStream = (ImageListStreamer) resourceManager.GetObject("MenuImages.ImageStream");
      this.MenuImages.TransparentColor = Color.Transparent;
      this.MenuItemUndo.ImageIndex = -1;
      this.MenuItemUndo.ImageList = (ImageList) null;
      this.MenuItemUndo.Index = 0;
      this.MenuItemUndo.NoEdit = false;
      this.MenuItemUndo.NoUIModify = false;
      this.MenuItemUndo.OriginalText = "";
      this.MenuItemUndo.OwnerDraw = true;
      this.MenuItemUndo.Text = "&Undo";
      this.MenuItemUndo.Click += new EventHandler(this.MenuItemUndo_Click);
      this.MenuItemBreak2.ImageIndex = -1;
      this.MenuItemBreak2.ImageList = (ImageList) null;
      this.MenuItemBreak2.Index = 1;
      this.MenuItemBreak2.NoEdit = false;
      this.MenuItemBreak2.NoUIModify = false;
      this.MenuItemBreak2.OriginalText = "";
      this.MenuItemBreak2.OwnerDraw = true;
      this.MenuItemBreak2.Text = "-";
      this.MenuItemCut.ImageIndex = 1;
      this.MenuItemCut.ImageList = this.MenuImages;
      this.MenuItemCut.Index = 2;
      this.MenuItemCut.NoEdit = false;
      this.MenuItemCut.NoUIModify = false;
      this.MenuItemCut.OriginalText = "";
      this.MenuItemCut.OwnerDraw = true;
      this.MenuItemCut.Text = "Cu&t";
      this.MenuItemCut.Click += new EventHandler(this.MenuItemCut_Click);
      this.MenuItemCopy.ImageIndex = 0;
      this.MenuItemCopy.ImageList = this.MenuImages;
      this.MenuItemCopy.Index = 3;
      this.MenuItemCopy.NoEdit = false;
      this.MenuItemCopy.NoUIModify = false;
      this.MenuItemCopy.OriginalText = "";
      this.MenuItemCopy.OwnerDraw = true;
      this.MenuItemCopy.Text = "&Copy";
      this.MenuItemCopy.Click += new EventHandler(this.MenuItemCopy_Click);
      this.MenuItemPaste.ImageIndex = 2;
      this.MenuItemPaste.ImageList = this.MenuImages;
      this.MenuItemPaste.Index = 4;
      this.MenuItemPaste.NoEdit = false;
      this.MenuItemPaste.NoUIModify = false;
      this.MenuItemPaste.OriginalText = "";
      this.MenuItemPaste.OwnerDraw = true;
      this.MenuItemPaste.Text = "&Paste";
      this.MenuItemPaste.Click += new EventHandler(this.MenuItemPaste_Click);
      this.MenuItemDelete.ImageIndex = 3;
      this.MenuItemDelete.ImageList = this.MenuImages;
      this.MenuItemDelete.Index = 5;
      this.MenuItemDelete.NoEdit = false;
      this.MenuItemDelete.NoUIModify = false;
      this.MenuItemDelete.OriginalText = "";
      this.MenuItemDelete.OwnerDraw = true;
      this.MenuItemDelete.Text = "&Delete";
      this.MenuItemDelete.Click += new EventHandler(this.MenuItemDelete_Click);
      this.MenuItemBreak4.ImageIndex = -1;
      this.MenuItemBreak4.ImageList = (ImageList) null;
      this.MenuItemBreak4.Index = 6;
      this.MenuItemBreak4.NoEdit = false;
      this.MenuItemBreak4.NoUIModify = false;
      this.MenuItemBreak4.OriginalText = "";
      this.MenuItemBreak4.OwnerDraw = true;
      this.MenuItemBreak4.Text = "-";
      this.MenuItemSelectAll.ImageIndex = -1;
      this.MenuItemSelectAll.ImageList = (ImageList) null;
      this.MenuItemSelectAll.Index = 7;
      this.MenuItemSelectAll.NoEdit = false;
      this.MenuItemSelectAll.NoUIModify = false;
      this.MenuItemSelectAll.OriginalText = "";
      this.MenuItemSelectAll.OwnerDraw = true;
      this.MenuItemSelectAll.Text = "Select &All";
      this.MenuItemSelectAll.Click += new EventHandler(this.MenuItemSelectAll_Click);
      this.MenuItemReports.BaseName = "MenuItemReports";
      this.MenuItemReports.ImageIndex = -1;
      this.MenuItemReports.ImageList = (ImageList) null;
      this.MenuItemReports.Index = 2;
      this.MenuItemReports.MenuItems.AddRange(new MenuItem[11]
      {
        (MenuItem) this.MenuItemRunReport,
        (MenuItem) this.MenuItemDesignReport,
        (MenuItem) this.menuItem1,
        (MenuItem) this.menuItem2,
        (MenuItem) this.menuItemPersonnelReport,
        (MenuItem) this.menuItemImportReport,
        (MenuItem) this.menuItemReportProfiles,
        (MenuItem) this.menuItemExportReport,
        (MenuItem) this.menuItemAttendanceReports,
        (MenuItem) this.menuItemReportAssessment,
        (MenuItem) this.menuItemReportsBehaviour
      });
      this.MenuItemReports.NoEdit = false;
      this.MenuItemReports.NoUIModify = false;
      this.MenuItemReports.OriginalText = "";
      this.MenuItemReports.OwnerDraw = true;
      this.MenuItemReports.Text = "&Reports";
      this.MenuItemRunReport.ImageIndex = -1;
      this.MenuItemRunReport.ImageList = (ImageList) null;
      this.MenuItemRunReport.Index = 0;
      this.MenuItemRunReport.NoEdit = false;
      this.MenuItemRunReport.NoUIModify = false;
      this.MenuItemRunReport.OriginalText = "";
      this.MenuItemRunReport.OwnerDraw = true;
      this.MenuItemRunReport.Text = "&Run Report";
      this.MenuItemRunReport.Click += new EventHandler(this.MenuItemRunReports_Click);
      this.menuItemInterventionsReports.ImageIndex = -1;
      this.menuItemInterventionsReports.ImageList = (ImageList) null;
      this.menuItemInterventionsReports.NoEdit = false;
      this.menuItemInterventionsReports.NoUIModify = false;
      this.menuItemInterventionsReports.OriginalText = "";
      this.menuItemInterventionsReports.OwnerDraw = true;
      this.menuItemInterventionsReports.Text = "&Interventions";
      this.menuItemReportsBehaviour.ImageIndex = -1;
      this.menuItemReportsBehaviour.ImageList = (ImageList) null;
      this.menuItemReportsBehaviour.Index = 10;
      this.menuItemReportsBehaviour.NoEdit = false;
      this.menuItemReportsBehaviour.NoUIModify = false;
      this.menuItemReportsBehaviour.OriginalText = "&Behaviour Management";
      this.menuItemReportsBehaviour.OwnerDraw = true;
      this.menuItemReportsBehaviour.Text = "&Behaviour Management";
      this.menuItemReportsBehaviour.MenuItems.Add((MenuItem) this.menuItemReportsBehaviourRunReportCard);
      this.menuItemReportsBehaviourRunReportCard.ImageIndex = -1;
      this.menuItemReportsBehaviourRunReportCard.ImageList = (ImageList) null;
      this.menuItemReportsBehaviourRunReportCard.Index = 0;
      this.menuItemReportsBehaviourRunReportCard.NoEdit = false;
      this.menuItemReportsBehaviourRunReportCard.NoUIModify = false;
      this.menuItemReportsBehaviourRunReportCard.OriginalText = "&Report Card";
      this.menuItemReportsBehaviourRunReportCard.OwnerDraw = true;
      this.menuItemReportsBehaviourRunReportCard.Text = "&Report Card";
      this.menuItemReportsBehaviourRunReportCard.Click += new EventHandler(this.menuItemReportsBehaviourRunReportCard_Click);
      this.MenuItemDesignReport.ImageIndex = -1;
      this.MenuItemDesignReport.ImageList = (ImageList) null;
      this.MenuItemDesignReport.Index = 1;
      this.MenuItemDesignReport.NoEdit = false;
      this.MenuItemDesignReport.NoUIModify = false;
      this.MenuItemDesignReport.OriginalText = "";
      this.MenuItemDesignReport.OwnerDraw = true;
      this.MenuItemDesignReport.Text = "&Design Report";
      this.MenuItemDesignReport.Click += new EventHandler(this.MenuItemDesignReports_Click);
      this.menuItem1.ImageIndex = -1;
      this.menuItem1.ImageList = (ImageList) null;
      this.menuItem1.Index = 2;
      this.menuItem1.NoEdit = false;
      this.menuItem1.NoUIModify = false;
      this.menuItem1.OriginalText = "";
      this.menuItem1.OwnerDraw = true;
      this.menuItem1.Text = "-";
      this.menuItem2.ImageIndex = -1;
      this.menuItem2.ImageList = (ImageList) null;
      this.menuItem2.Index = 3;
      this.menuItem2.NoEdit = false;
      this.menuItem2.NoUIModify = false;
      this.menuItem2.OriginalText = "";
      this.menuItem2.OwnerDraw = true;
      this.menuItem2.Text = "User Rights";
      this.menuItem2.Click += new EventHandler(this.MenuItemSecurity_Click);
      this.menuItemImportReport.ImageIndex = -1;
      this.menuItemImportReport.ImageList = (ImageList) null;
      this.menuItemImportReport.Index = 4;
      this.menuItemImportReport.NoEdit = false;
      this.menuItemImportReport.NoUIModify = false;
      this.menuItemImportReport.OriginalText = "";
      this.menuItemImportReport.OwnerDraw = true;
      this.menuItemImportReport.Text = "&Import";
      this.menuItemImportReport.Click += new EventHandler(this.menuItemImportReport_Click);
      this.menuItemExportReport.ImageIndex = -1;
      this.menuItemExportReport.ImageList = (ImageList) null;
      this.menuItemExportReport.Index = 5;
      this.menuItemExportReport.NoEdit = false;
      this.menuItemExportReport.NoUIModify = false;
      this.menuItemExportReport.OriginalText = "";
      this.menuItemExportReport.OwnerDraw = true;
      this.menuItemExportReport.Text = "&Export";
      this.menuItemExportReport.Click += new EventHandler(this.menuItemExportReport_Click);
      this.menuItemPersonnelReport.ImageIndex = -1;
      this.menuItemPersonnelReport.ImageList = (ImageList) null;
      this.menuItemPersonnelReport.Index = 6;
      this.menuItemPersonnelReport.NoEdit = false;
      this.menuItemPersonnelReport.NoUIModify = false;
      this.menuItemPersonnelReport.OriginalText = "";
      this.menuItemPersonnelReport.OwnerDraw = true;
      this.menuItemPersonnelReport.Text = "&Personnel";
      this.menuItemAttendanceReports.BaseName = "menuItemAttendanceReports";
      this.menuItemAttendanceReports.OriginalText = "&Attendance";
      this.menuItemAttendanceReports.Text = "&Attendance";
      this.menuItemAttendanceReports.Index = 9;
      this.menuItemAttendanceSetup.OriginalText = "Attendan&ce Setup";
      this.menuItemAttendanceSetup.Text = "Attendan&ce Setup";
      this.menuItemAttendanceSetup.MenuItems.AddRange(new MenuItem[8]
      {
        (MenuItem) this.menuItemAttendanceModuleSetup,
        (MenuItem) this.menuItemAttendanceOMRSetup,
        (MenuItem) this.menuItemATWRegistrationOrganisation,
        (MenuItem) this.menuItemCodes,
        (MenuItem) this.menuItemPartTimePupils,
        (MenuItem) this.menuItemLetterDefinition,
        (MenuItem) this.menuItemEditQuickLetter,
        (MenuItem) this.menuItemSetSchoolWorkingDays
      });
      this.menuItemLessonMonitorOptions.OriginalText = "&Lesson Monitor Options";
      this.menuItemLessonMonitorOptions.Text = "&Lesson Monitor Options";
      this.menuItemAttendanceRoutines.BaseName = "menuItemAttendanceRoutines";
      this.menuItemAttendanceRoutines.OriginalText = "A&ttendance";
      this.menuItemAttendanceRoutines.Text = "A&ttendance";
      this.menuItemAttendanceModuleSetup.OriginalText = "&Module Setup";
      this.menuItemAttendanceModuleSetup.Text = "Module Setup";
      this.menuItemAttendanceModuleSetup.Click += new EventHandler(this.menuItemAttendanceModuleSetup_Click);
      this.menuItemAttendanceOMRSetup.OriginalText = "&OMR Setup";
      this.menuItemAttendanceOMRSetup.Text = "OMR Setup";
      this.menuItemAttendanceOMRSetup.Click += new EventHandler(this.menuItemAttendanceOMRSetup_Click);
      this.menuItemATWRegistrationOrganisation.OriginalText = "&Registration Organisation";
      this.menuItemATWRegistrationOrganisation.Text = "&Registration Organisation";
      this.menuItemATWRegistrationOrganisation.Click += new EventHandler(this.menuItemATWRegistrationOrganisation_Click);
      this.menuItemCodes.OriginalText = "&Codes";
      this.menuItemCodes.Text = "&Codes";
      this.menuItemCodes.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemMaintainCodes,
        (MenuItem) this.menuItemLateCodes
      });
      this.menuItemMaintainCodes.OriginalText = "&Maintain Codes";
      this.menuItemMaintainCodes.Text = "&Maintain Codes";
      this.menuItemMaintainCodes.Click += new EventHandler(this.menuItemMaintainCodes_Click);
      this.menuItemLateCodes.OriginalText = "&Late Codes";
      this.menuItemLateCodes.Text = "&Late Codes";
      this.menuItemLateCodes.Click += new EventHandler(this.menuItemLateCodes_Click);
      this.menuItemPartTimePupils.OriginalText = "&Part Time Pupils";
      this.menuItemPartTimePupils.Text = "&Part Time Pupils";
      this.menuItemPartTimePupils.Click += new EventHandler(this.menuItemPartTimePupils_Click);
      this.menuItemLetterDefinition.OriginalText = "&Letter Definition";
      this.menuItemLetterDefinition.Text = "&Letter Definition";
      this.menuItemLetterDefinition.Click += new EventHandler(this.menuItemLetterDefinition_Click);
      this.menuItemEditQuickLetter.OriginalText = "Edit &Quick Letter Template";
      this.menuItemEditQuickLetter.Text = "Edit &Quick Letter Template";
      this.menuItemEditQuickLetter.Click += new EventHandler(this.menuItemEditQuickLetter_Click);
      this.menuItemSetSchoolWorkingDays.Index = 7;
      this.menuItemSetSchoolWorkingDays.Text = "Set School Working Days";
      this.menuItemSetSchoolWorkingDays.Click += new EventHandler(this.menuItemSetSchoolWorkingDays_Click);
      this.menuItemStaff.ImageIndex = -1;
      this.menuItemStaff.ImageList = (ImageList) null;
      this.menuItemStaff.Index = 14;
      this.menuItemStaff.NoEdit = false;
      this.menuItemStaff.NoUIModify = false;
      this.menuItemStaff.OriginalText = "";
      this.menuItemStaff.OwnerDraw = true;
      this.menuItemStaff.Text = "Sta&ff";
      this.menuItemRoutinesStaffs.ImageIndex = -1;
      this.menuItemRoutinesStaffs.ImageList = (ImageList) null;
      this.menuItemRoutinesStaffs.Index = 9;
      this.menuItemRoutinesStaffs.NoEdit = false;
      this.menuItemRoutinesStaffs.NoUIModify = false;
      this.menuItemRoutinesStaffs.OriginalText = "";
      this.menuItemRoutinesStaffs.OwnerDraw = true;
      this.menuItemRoutinesStaffs.Text = "Sta&ff";
      this.menuItemImportLookups.ImageIndex = -1;
      this.menuItemImportLookups.ImageList = (ImageList) null;
      this.menuItemImportLookups.Index = 3;
      this.menuItemImportLookups.NoEdit = false;
      this.menuItemImportLookups.NoUIModify = false;
      this.menuItemImportLookups.OriginalText = "";
      this.menuItemImportLookups.OwnerDraw = true;
      this.menuItemImportLookups.Text = "&Import Lookups";
      this.menuItemImportLookups.Click += new EventHandler(this.menuItemImportLookups_Click);
      this.menuItemRoutines.BaseName = "menuItemRoutines";
      this.menuItemRoutines.ImageIndex = -1;
      this.menuItemRoutines.ImageList = (ImageList) null;
      this.menuItemRoutines.Index = 3;
      this.menuItemRoutines.MenuItems.AddRange(new MenuItem[14]
      {
        (MenuItem) this.menuItemAdmissions,
        (MenuItem) this.menuItem24,
        (MenuItem) this.menuItemSchoolBase,
        (MenuItem) this.menuItemDataOut,
        (MenuItem) this.menuItemDataIn,
        (MenuItem) this.menuItemStatutoryReturns,
        (MenuItem) this.menuItemRoutinesStudents,
        (MenuItem) this.menuItemFeesBillingRoutines,
        (MenuItem) this.menuItemRoutinesStaffs,
        (MenuItem) this.menuItemAttendanceRoutines,
        (MenuItem) this.menuItemRoutinesDocuments,
        (MenuItem) this.menuItemConnexionsMain,
        (MenuItem) this.menuItemEMA,
        (MenuItem) this.menuItemB2B
      });
      this.menuItemRoutines.NoEdit = false;
      this.menuItemRoutines.NoUIModify = false;
      this.menuItemRoutines.OriginalText = "";
      this.menuItemRoutines.OwnerDraw = true;
      this.menuItemRoutines.Text = "R&outines";
      this.menuItemAdmissions.ImageIndex = -1;
      this.menuItemAdmissions.ImageList = (ImageList) null;
      this.menuItemAdmissions.Index = 0;
      this.menuItemAdmissions.NoEdit = false;
      this.menuItemAdmissions.NoUIModify = false;
      this.menuItemAdmissions.OriginalText = "";
      this.menuItemAdmissions.OwnerDraw = true;
      this.menuItemAdmissions.Text = "&Admission";
      this.menuItemCoverTools.ImageIndex = -1;
      this.menuItemCoverTools.ImageList = (ImageList) null;
      this.menuItemCoverTools.Index = 12;
      this.menuItemCoverTools.NoEdit = false;
      this.menuItemCoverTools.NoUIModify = false;
      this.menuItemCoverTools.OriginalText = "";
      this.menuItemCoverTools.OwnerDraw = true;
      this.menuItemCoverTools.Text = "C&over";
      this.menuItem24.ImageIndex = -1;
      this.menuItem24.ImageList = (ImageList) null;
      this.menuItem24.Index = 1;
      this.menuItem24.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemImoprtFromEMS,
        (MenuItem) this.menuItemExportToEMS
      });
      this.menuItem24.NoEdit = false;
      this.menuItem24.NoUIModify = false;
      this.menuItem24.OriginalText = "";
      this.menuItem24.OwnerDraw = true;
      this.menuItem24.Text = "Data &Exchange";
      this.menuItemImoprtFromEMS.ImageIndex = -1;
      this.menuItemImoprtFromEMS.ImageList = (ImageList) null;
      this.menuItemImoprtFromEMS.Index = 0;
      this.menuItemImoprtFromEMS.NoEdit = false;
      this.menuItemImoprtFromEMS.NoUIModify = false;
      this.menuItemImoprtFromEMS.OriginalText = "";
      this.menuItemImoprtFromEMS.OwnerDraw = true;
      this.menuItemImoprtFromEMS.Text = "&Import from ONE";
      this.menuItemExportToEMS.ImageIndex = -1;
      this.menuItemExportToEMS.ImageList = (ImageList) null;
      this.menuItemExportToEMS.Index = 1;
      this.menuItemExportToEMS.NoEdit = false;
      this.menuItemExportToEMS.NoUIModify = false;
      this.menuItemExportToEMS.OriginalText = "";
      this.menuItemExportToEMS.OwnerDraw = true;
      this.menuItemExportToEMS.Text = "&Export to ONE";
      this.menuItemSchoolBase.ImageIndex = -1;
      this.menuItemSchoolBase.ImageList = (ImageList) null;
      this.menuItemSchoolBase.Index = 3;
      this.menuItemSchoolBase.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemSchoolPromotion,
        (MenuItem) this.menuItemAcademicYear,
        (MenuItem) this.menuItemEditAcademicYear,
        (MenuItem) this.menuItemDeleteAcademicYear,
        (MenuItem) this.menuItemSchoolDetailsChange
      });
      this.menuItemSchoolBase.NoEdit = false;
      this.menuItemSchoolBase.NoUIModify = false;
      this.menuItemSchoolBase.OriginalText = "";
      this.menuItemSchoolBase.OwnerDraw = true;
      this.menuItemSchoolBase.Text = "&School";
      this.menuItemSchoolPromotion.ImageIndex = -1;
      this.menuItemSchoolPromotion.ImageList = (ImageList) null;
      this.menuItemSchoolPromotion.Index = 0;
      this.menuItemSchoolPromotion.NoEdit = false;
      this.menuItemSchoolPromotion.NoUIModify = false;
      this.menuItemSchoolPromotion.OriginalText = "";
      this.menuItemSchoolPromotion.OwnerDraw = true;
      this.menuItemSchoolPromotion.Text = "&Promotion";
      this.menuItemSchoolPromotion.Click += new EventHandler(this.menuItemSchoolPromotion_Click);
      this.menuItemAcademicYear.ImageIndex = -1;
      this.menuItemAcademicYear.ImageList = (ImageList) null;
      this.menuItemAcademicYear.Index = 1;
      this.menuItemAcademicYear.NoEdit = false;
      this.menuItemAcademicYear.NoUIModify = false;
      this.menuItemAcademicYear.OriginalText = "";
      this.menuItemAcademicYear.OwnerDraw = true;
      this.menuItemAcademicYear.Text = "&Academic Year";
      this.menuItemAcademicYear.Click += new EventHandler(this.menuItemAcademicYear_Click);
      this.menuItemEditAcademicYear.ImageIndex = -1;
      this.menuItemEditAcademicYear.ImageList = (ImageList) null;
      this.menuItemEditAcademicYear.Index = 2;
      this.menuItemEditAcademicYear.NoEdit = false;
      this.menuItemEditAcademicYear.NoUIModify = false;
      this.menuItemEditAcademicYear.OriginalText = "";
      this.menuItemEditAcademicYear.OwnerDraw = true;
      this.menuItemEditAcademicYear.Text = "&Edit Academic Year";
      this.menuItemEditAcademicYear.Click += new EventHandler(this.menuItemEditAcademicYear_Click);
      this.menuItemDeleteAcademicYear.ImageIndex = -1;
      this.menuItemDeleteAcademicYear.ImageList = (ImageList) null;
      this.menuItemDeleteAcademicYear.Index = 3;
      this.menuItemDeleteAcademicYear.NoEdit = false;
      this.menuItemDeleteAcademicYear.NoUIModify = false;
      this.menuItemDeleteAcademicYear.OriginalText = "";
      this.menuItemDeleteAcademicYear.OwnerDraw = true;
      this.menuItemDeleteAcademicYear.Text = "&Delete Latest Academic Year";
      this.menuItemDeleteAcademicYear.Click += new EventHandler(this.menuItemDeleteAcademicYear_Click);
      this.menuItemSchoolDetailsChange.ImageIndex = -1;
      this.menuItemSchoolDetailsChange.ImageList = (ImageList) null;
      this.menuItemSchoolDetailsChange.Index = 4;
      this.menuItemSchoolDetailsChange.NoEdit = false;
      this.menuItemSchoolDetailsChange.NoUIModify = false;
      this.menuItemSchoolDetailsChange.OriginalText = "";
      this.menuItemSchoolDetailsChange.OwnerDraw = true;
      this.menuItemSchoolDetailsChange.Text = "Change &School Details";
      this.menuItemSchoolDetailsChange.Click += new EventHandler(this.menuItemSchoolDetailsChange_Click);
      this.menuItemDataOut.BaseName = "menuItemDataOut";
      this.menuItemDataOut.ImageIndex = -1;
      this.menuItemDataOut.ImageList = (ImageList) null;
      this.menuItemDataOut.Index = 4;
      this.menuItemDataOut.MenuItems.AddRange(new MenuItem[7]
      {
        (MenuItem) this.menuItemCTFout,
        (MenuItem) this.menuItemDataOutASM,
        (MenuItem) this.menuItemDataOutPA,
        (MenuItem) this.menuItemNDCWales,
        (MenuItem) this.menuItemINCASExport,
        (MenuItem) this.menuItemCBAExport,
        (MenuItem) this.menuItemRecruitmentAgencyExport
      });
      this.menuItemDataOut.NoEdit = false;
      this.menuItemDataOut.NoUIModify = false;
      this.menuItemDataOut.OriginalText = "";
      this.menuItemDataOut.OwnerDraw = true;
      this.menuItemDataOut.Text = "&Data Out";
      this.menuItemCTFout.ImageIndex = -1;
      this.menuItemCTFout.ImageList = (ImageList) null;
      this.menuItemCTFout.Index = 0;
      this.menuItemCTFout.NoEdit = false;
      this.menuItemCTFout.NoUIModify = false;
      this.menuItemCTFout.OriginalText = "";
      this.menuItemCTFout.OwnerDraw = true;
      this.menuItemCTFout.Text = "&CTF";
      this.menuItemDataIn.ImageIndex = -1;
      this.menuItemDataIn.ImageList = (ImageList) null;
      this.menuItemDataIn.Index = 5;
      this.menuItemDataIn.MenuItems.AddRange(new MenuItem[4]
      {
        (MenuItem) this.menuItemCTFin,
        (MenuItem) this.menuItemDataInASM,
        (MenuItem) this.menuItemDataInPA,
        (MenuItem) this.menuItemRecruitmentAgencyImport
      });
      this.menuItemDataIn.NoEdit = false;
      this.menuItemDataIn.NoUIModify = false;
      this.menuItemDataIn.OriginalText = "";
      this.menuItemDataIn.OwnerDraw = true;
      this.menuItemDataIn.Text = "Data &In";
      this.menuItemCTFin.ImageIndex = -1;
      this.menuItemCTFin.ImageList = (ImageList) null;
      this.menuItemCTFin.NoEdit = false;
      this.menuItemCTFin.NoUIModify = false;
      this.menuItemCTFin.OriginalText = "";
      this.menuItemCTFin.OwnerDraw = true;
      this.menuItemCTFin.Text = "&CTF";
      this.menuItemStatutoryReturns.ImageIndex = -1;
      this.menuItemStatutoryReturns.ImageList = (ImageList) null;
      this.menuItemStatutoryReturns.Index = 6;
      this.menuItemStatutoryReturns.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemPLASCDENI,
        (MenuItem) this.menuItemPlasc,
        (MenuItem) this.menuItemPost16Autumn,
        (MenuItem) this.menuItemWelshAttendanceCollection,
        (MenuItem) this.menuItemWelshAttendanceCollectionMiddle
      });
      this.menuItemStatutoryReturns.NoEdit = false;
      this.menuItemStatutoryReturns.NoUIModify = false;
      this.menuItemStatutoryReturns.OriginalText = "";
      this.menuItemStatutoryReturns.OwnerDraw = true;
      this.menuItemStatutoryReturns.Text = "Statutory &Returns";
      this.menuItemStatutoryReturns.Visible = false;
      this.menuItemPLASCDENI.ImageIndex = -1;
      this.menuItemPLASCDENI.ImageList = (ImageList) null;
      this.menuItemPLASCDENI.Index = 0;
      this.menuItemPLASCDENI.NoEdit = false;
      this.menuItemPLASCDENI.NoUIModify = false;
      this.menuItemPLASCDENI.OriginalText = "";
      this.menuItemPLASCDENI.OwnerDraw = true;
      this.menuItemPLASCDENI.Text = "&DENI";
      this.menuItemPLASCDENI.Visible = false;
      this.menuItemPlasc.ImageIndex = -1;
      this.menuItemPlasc.ImageList = (ImageList) null;
      this.menuItemPlasc.Index = 1;
      this.menuItemPlasc.NoEdit = false;
      this.menuItemPlasc.NoUIModify = false;
      this.menuItemPlasc.OriginalText = "";
      this.menuItemPlasc.OwnerDraw = true;
      this.menuItemPlasc.Text = "&PLASC";
      this.menuItemRoutinesStudents.BaseName = "menuItemRoutinesStudents";
      this.menuItemRoutinesStudents.ImageIndex = -1;
      this.menuItemRoutinesStudents.ImageList = (ImageList) null;
      this.menuItemRoutinesStudents.Index = 7;
      this.menuItemRoutinesStudents.MenuItems.AddRange(new MenuItem[6]
      {
        (MenuItem) this.menuItemBatchPhoto,
        (MenuItem) this.menuItemStudentBulkUpdate,
        (MenuItem) this.menuItemLeavers,
        (MenuItem) this.menuItemUpdateStudentAddressee,
        (MenuItem) this.menuItemDeleteStudent,
        (MenuItem) this.menuItemChangeEnrolmentStatus
      });
      this.menuItemRoutinesStudents.NoEdit = false;
      this.menuItemRoutinesStudents.NoUIModify = false;
      this.menuItemRoutinesStudents.OriginalText = "";
      this.menuItemRoutinesStudents.OwnerDraw = true;
      this.menuItemRoutinesStudents.Text = "St&udent";
      this.menuItemBatchPhoto.ImageIndex = -1;
      this.menuItemBatchPhoto.ImageList = (ImageList) null;
      this.menuItemBatchPhoto.Index = 0;
      this.menuItemBatchPhoto.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.MenuItemPhotoImportStudentAdNo,
        (MenuItem) this.MenuItemPhotoImportStudentRgGp
      });
      this.menuItemBatchPhoto.NoEdit = false;
      this.menuItemBatchPhoto.NoUIModify = false;
      this.menuItemBatchPhoto.OriginalText = "";
      this.menuItemBatchPhoto.OwnerDraw = true;
      this.menuItemBatchPhoto.Text = "&Batch Import Photographs";
      this.MenuItemPhotoImportStudentAdNo.ImageIndex = -1;
      this.MenuItemPhotoImportStudentAdNo.ImageList = (ImageList) null;
      this.MenuItemPhotoImportStudentAdNo.Index = 0;
      this.MenuItemPhotoImportStudentAdNo.NoEdit = false;
      this.MenuItemPhotoImportStudentAdNo.NoUIModify = false;
      this.MenuItemPhotoImportStudentAdNo.OriginalText = "";
      this.MenuItemPhotoImportStudentAdNo.OwnerDraw = true;
      this.MenuItemPhotoImportStudentAdNo.Text = "By &Admission Numbers";
      this.MenuItemPhotoImportStudentAdNo.Click += new EventHandler(this.MenuItemPhotoImportStudentAdNo_Click);
      this.MenuItemPhotoImportStudentRgGp.ImageIndex = -1;
      this.MenuItemPhotoImportStudentRgGp.ImageList = (ImageList) null;
      this.MenuItemPhotoImportStudentRgGp.Index = 1;
      this.MenuItemPhotoImportStudentRgGp.NoEdit = false;
      this.MenuItemPhotoImportStudentRgGp.NoUIModify = false;
      this.MenuItemPhotoImportStudentRgGp.OriginalText = "";
      this.MenuItemPhotoImportStudentRgGp.OwnerDraw = true;
      this.MenuItemPhotoImportStudentRgGp.Text = "By &Registration Group";
      this.MenuItemPhotoImportStudentRgGp.Click += new EventHandler(this.MenuItemPhotoImportStudentRgGp_Click);
      this.menuItemStudentBulkUpdate.BaseName = "menuItemStudentBulkUpdate";
      this.menuItemStudentBulkUpdate.ImageIndex = -1;
      this.menuItemStudentBulkUpdate.ImageList = (ImageList) null;
      this.menuItemStudentBulkUpdate.Index = 1;
      this.menuItemStudentBulkUpdate.NoEdit = false;
      this.menuItemStudentBulkUpdate.NoUIModify = false;
      this.menuItemStudentBulkUpdate.OriginalText = "";
      this.menuItemStudentBulkUpdate.OwnerDraw = true;
      this.menuItemStudentBulkUpdate.Text = "Bul&K Update";
      this.menuItemStudentBulkUpdate.Click += new EventHandler(this.menuItemStudentBulkUpdate_Click);
      this.menuItemLeavers.ImageIndex = -1;
      this.menuItemLeavers.ImageList = (ImageList) null;
      this.menuItemLeavers.Index = 2;
      this.menuItemLeavers.NoEdit = false;
      this.menuItemLeavers.NoUIModify = false;
      this.menuItemLeavers.OriginalText = "";
      this.menuItemLeavers.OwnerDraw = true;
      this.menuItemLeavers.Text = "&Leavers";
      this.menuItemLeavers.Click += new EventHandler(this.menuItemLeavers_Click);
      this.menuItemUpdateStudentAddressee.ImageIndex = -1;
      this.menuItemUpdateStudentAddressee.ImageList = (ImageList) null;
      this.menuItemUpdateStudentAddressee.Index = 3;
      this.menuItemUpdateStudentAddressee.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemUpdateParentalAddressee,
        (MenuItem) this.menuItemUpdateContactAddressee
      });
      this.menuItemUpdateStudentAddressee.NoEdit = false;
      this.menuItemUpdateStudentAddressee.NoUIModify = false;
      this.menuItemUpdateStudentAddressee.OriginalText = "";
      this.menuItemUpdateStudentAddressee.OwnerDraw = true;
      this.menuItemUpdateStudentAddressee.Text = "&Update Salutation / Addressee";
      this.menuItemUpdateParentalAddressee.ImageIndex = -1;
      this.menuItemUpdateParentalAddressee.ImageList = (ImageList) null;
      this.menuItemUpdateParentalAddressee.Index = 0;
      this.menuItemUpdateParentalAddressee.NoEdit = false;
      this.menuItemUpdateParentalAddressee.NoUIModify = false;
      this.menuItemUpdateParentalAddressee.OriginalText = "";
      this.menuItemUpdateParentalAddressee.OwnerDraw = true;
      this.menuItemUpdateParentalAddressee.Text = "&Parental";
      this.menuItemUpdateParentalAddressee.Click += new EventHandler(this.menuItemUpdateParentalAddressee_Click);
      this.menuItemUpdateContactAddressee.ImageIndex = -1;
      this.menuItemUpdateContactAddressee.ImageList = (ImageList) null;
      this.menuItemUpdateContactAddressee.Index = 1;
      this.menuItemUpdateContactAddressee.NoEdit = false;
      this.menuItemUpdateContactAddressee.NoUIModify = false;
      this.menuItemUpdateContactAddressee.OriginalText = "";
      this.menuItemUpdateContactAddressee.OwnerDraw = true;
      this.menuItemUpdateContactAddressee.Text = "&Contact";
      this.menuItemUpdateContactAddressee.Click += new EventHandler(this.menuItemUpdateContactAddressee_Click);
      this.menuItemDeleteStudent.ImageIndex = -1;
      this.menuItemDeleteStudent.ImageList = (ImageList) null;
      this.menuItemDeleteStudent.Index = 4;
      this.menuItemDeleteStudent.NoEdit = false;
      this.menuItemDeleteStudent.NoUIModify = false;
      this.menuItemDeleteStudent.OriginalText = "";
      this.menuItemDeleteStudent.OwnerDraw = true;
      this.menuItemDeleteStudent.Text = "&Delete Student";
      this.menuItemDeleteStudent.Click += new EventHandler(this.menuItemStudentDelete_Click);
      this.menuItemChangeEnrolmentStatus.ImageIndex = -1;
      this.menuItemChangeEnrolmentStatus.ImageList = (ImageList) null;
      this.menuItemChangeEnrolmentStatus.Index = 5;
      this.menuItemChangeEnrolmentStatus.NoEdit = false;
      this.menuItemChangeEnrolmentStatus.NoUIModify = false;
      this.menuItemChangeEnrolmentStatus.OriginalText = "";
      this.menuItemChangeEnrolmentStatus.OwnerDraw = true;
      this.menuItemChangeEnrolmentStatus.Text = "Change &Enrolment Status";
      this.menuItemChangeEnrolmentStatus.Click += new EventHandler(this.menuItemChangeEnrolmentStatus_Click);
      this.menuItemFeesBillingRoutines.ImageIndex = -1;
      this.menuItemFeesBillingRoutines.ImageList = (ImageList) null;
      this.menuItemFeesBillingRoutines.Index = 8;
      this.menuItemFeesBillingRoutines.NoEdit = false;
      this.menuItemFeesBillingRoutines.NoUIModify = false;
      this.menuItemFeesBillingRoutines.OriginalText = "";
      this.menuItemFeesBillingRoutines.OwnerDraw = true;
      this.menuItemFeesBillingRoutines.Text = "&Fees Billing";
      this.menuItemFeesBillingRoutines.Popup += new EventHandler(this.menuItemFeesBillingRoutines_Popup);
      this.menuItemRoutinesDocuments.ImageIndex = -1;
      this.menuItemRoutinesDocuments.ImageList = (ImageList) null;
      this.menuItemRoutinesDocuments.Index = 10;
      this.menuItemRoutinesDocuments.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemToolUploadDocuments
      });
      this.menuItemRoutinesDocuments.NoEdit = false;
      this.menuItemRoutinesDocuments.NoUIModify = false;
      this.menuItemRoutinesDocuments.OriginalText = "";
      this.menuItemRoutinesDocuments.OwnerDraw = true;
      this.menuItemRoutinesDocuments.Text = "D&ocuments";
      this.menuItemToolUploadDocuments.ImageIndex = -1;
      this.menuItemToolUploadDocuments.ImageList = (ImageList) null;
      this.menuItemToolUploadDocuments.Index = 0;
      this.menuItemToolUploadDocuments.NoEdit = false;
      this.menuItemToolUploadDocuments.NoUIModify = false;
      this.menuItemToolUploadDocuments.OriginalText = "";
      this.menuItemToolUploadDocuments.OwnerDraw = true;
      this.menuItemToolUploadDocuments.Text = "&Upload Documents";
      this.menuItemToolUploadDocuments.Click += new EventHandler(this.menuItemToolUploadDocuments_Click);
      this.menuItemToolMaintainDMS.ImageIndex = -1;
      this.menuItemToolMaintainDMS.ImageList = (ImageList) null;
      this.menuItemToolMaintainDMS.Index = 1;
      this.menuItemToolMaintainDMS.NoEdit = false;
      this.menuItemToolMaintainDMS.NoUIModify = false;
      this.menuItemToolMaintainDMS.OriginalText = "";
      this.menuItemToolMaintainDMS.OwnerDraw = true;
      this.menuItemToolMaintainDMS.Text = "Maintain &Orphaned Documents";
      this.menuItemToolMaintainDMS.Click += new EventHandler(this.menuItemToolMaintainDocuments_Click);
      this.menuItemToolMaintainDocuments.ImageIndex = -1;
      this.menuItemToolMaintainDocuments.ImageList = (ImageList) null;
      this.menuItemToolMaintainDocuments.Index = 1;
      this.menuItemToolMaintainDocuments.NoEdit = false;
      this.menuItemToolMaintainDocuments.NoUIModify = false;
      this.menuItemToolMaintainDocuments.OriginalText = "";
      this.menuItemToolMaintainDocuments.OwnerDraw = true;
      this.menuItemToolMaintainDocuments.Text = "Document Management &Server";
      this.menuItemToolMaintainDocuments.MenuItems.Add((MenuItem) this.menuItemToolMaintainDMS);
      this.menuItemConnexionsMain.ImageIndex = -1;
      this.menuItemConnexionsMain.ImageList = (ImageList) null;
      this.menuItemConnexionsMain.Index = 11;
      this.menuItemConnexionsMain.MenuItems.AddRange(new MenuItem[7]
      {
        (MenuItem) this.menuItemCCardholderDetails,
        (MenuItem) this.menuItemCCardholderDownload,
        (MenuItem) this.menuItemCCardSeperator2,
        (MenuItem) this.menuItemCCardAttSummaryExport,
        (MenuItem) this.menuItemCCardRequestResponseFile,
        (MenuItem) this.menuItem14,
        (MenuItem) this.menuItemCCardReports
      });
      this.menuItemConnexionsMain.NoEdit = false;
      this.menuItemConnexionsMain.NoUIModify = false;
      this.menuItemConnexionsMain.OriginalText = "";
      this.menuItemConnexionsMain.OwnerDraw = true;
      this.menuItemConnexionsMain.Text = "CONNE&XIONS CARD";
      this.menuItemCCardholderDetails.ImageIndex = -1;
      this.menuItemCCardholderDetails.ImageList = (ImageList) null;
      this.menuItemCCardholderDetails.Index = 0;
      this.menuItemCCardholderDetails.NoEdit = false;
      this.menuItemCCardholderDetails.NoUIModify = false;
      this.menuItemCCardholderDetails.OriginalText = "";
      this.menuItemCCardholderDetails.OwnerDraw = true;
      this.menuItemCCardholderDetails.Text = "&Add/Edit Cardholder Details";
      this.menuItemCCardholderDetails.Click += new EventHandler(this.menuItemCCardholderDetails_Click);
      this.menuItemCCardholderDownload.ImageIndex = -1;
      this.menuItemCCardholderDownload.ImageList = (ImageList) null;
      this.menuItemCCardholderDownload.Index = 1;
      this.menuItemCCardholderDownload.NoEdit = false;
      this.menuItemCCardholderDownload.NoUIModify = false;
      this.menuItemCCardholderDownload.OriginalText = "";
      this.menuItemCCardholderDownload.OwnerDraw = true;
      this.menuItemCCardholderDownload.Text = "&Download Cardholder Details";
      this.menuItemCCardholderDownload.Click += new EventHandler(this.menuItemCCardholderDownload_Click);
      this.menuItemCCardSeperator2.ImageIndex = -1;
      this.menuItemCCardSeperator2.ImageList = (ImageList) null;
      this.menuItemCCardSeperator2.Index = 2;
      this.menuItemCCardSeperator2.NoEdit = false;
      this.menuItemCCardSeperator2.NoUIModify = false;
      this.menuItemCCardSeperator2.OriginalText = "";
      this.menuItemCCardSeperator2.OwnerDraw = true;
      this.menuItemCCardSeperator2.Text = "-";
      this.menuItemCCardAttSummaryExport.ImageIndex = -1;
      this.menuItemCCardAttSummaryExport.ImageList = (ImageList) null;
      this.menuItemCCardAttSummaryExport.Index = 3;
      this.menuItemCCardAttSummaryExport.NoEdit = false;
      this.menuItemCCardAttSummaryExport.NoUIModify = false;
      this.menuItemCCardAttSummaryExport.OriginalText = "";
      this.menuItemCCardAttSummaryExport.OwnerDraw = true;
      this.menuItemCCardAttSummaryExport.Text = "Attendance &Summary Export";
      this.menuItemCCardAttSummaryExport.Click += new EventHandler(this.menuItemCCardAttSummaryExport_Click);
      this.menuItemCCardRequestResponseFile.ImageIndex = -1;
      this.menuItemCCardRequestResponseFile.ImageList = (ImageList) null;
      this.menuItemCCardRequestResponseFile.Index = 4;
      this.menuItemCCardRequestResponseFile.NoEdit = false;
      this.menuItemCCardRequestResponseFile.NoUIModify = false;
      this.menuItemCCardRequestResponseFile.OriginalText = "";
      this.menuItemCCardRequestResponseFile.OwnerDraw = true;
      this.menuItemCCardRequestResponseFile.Text = "Request Response &File";
      this.menuItemCCardRequestResponseFile.Click += new EventHandler(this.menuItemCCardRequestResponseFile_Click);
      this.menuItem14.ImageIndex = -1;
      this.menuItem14.ImageList = (ImageList) null;
      this.menuItem14.Index = 5;
      this.menuItem14.NoEdit = false;
      this.menuItem14.NoUIModify = false;
      this.menuItem14.OriginalText = "";
      this.menuItem14.OwnerDraw = true;
      this.menuItem14.Text = "-";
      this.menuItemCCardReports.ImageIndex = -1;
      this.menuItemCCardReports.ImageList = (ImageList) null;
      this.menuItemCCardReports.Index = 6;
      this.menuItemCCardReports.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemCCardAttSummaryExportReport,
        (MenuItem) this.menuItemCCardSchemeMembersReport
      });
      this.menuItemCCardReports.NoEdit = false;
      this.menuItemCCardReports.NoUIModify = false;
      this.menuItemCCardReports.OriginalText = "";
      this.menuItemCCardReports.OwnerDraw = true;
      this.menuItemCCardReports.Text = "&Reports";
      this.menuItemCCardAttSummaryExportReport.ImageIndex = -1;
      this.menuItemCCardAttSummaryExportReport.ImageList = (ImageList) null;
      this.menuItemCCardAttSummaryExportReport.Index = 0;
      this.menuItemCCardAttSummaryExportReport.NoEdit = false;
      this.menuItemCCardAttSummaryExportReport.NoUIModify = false;
      this.menuItemCCardAttSummaryExportReport.OriginalText = "";
      this.menuItemCCardAttSummaryExportReport.OwnerDraw = true;
      this.menuItemCCardAttSummaryExportReport.Text = "Attendance &Summary Export";
      this.menuItemCCardAttSummaryExportReport.Click += new EventHandler(this.menuItemCCardAttSummaryExportReport_Click);
      this.menuItemCCardSchemeMembersReport.ImageIndex = -1;
      this.menuItemCCardSchemeMembersReport.ImageList = (ImageList) null;
      this.menuItemCCardSchemeMembersReport.Index = 1;
      this.menuItemCCardSchemeMembersReport.NoEdit = false;
      this.menuItemCCardSchemeMembersReport.NoUIModify = false;
      this.menuItemCCardSchemeMembersReport.OriginalText = "";
      this.menuItemCCardSchemeMembersReport.OwnerDraw = true;
      this.menuItemCCardSchemeMembersReport.Text = "&CONNEXIONS CARD Scheme Members";
      this.menuItemCCardSchemeMembersReport.Click += new EventHandler(this.menuItemCCardSchemeMembersReport_Click);
      this.menuItemEMA.ImageIndex = -1;
      this.menuItemEMA.ImageList = (ImageList) null;
      this.menuItemEMA.Index = 12;
      this.menuItemEMA.NoEdit = false;
      this.menuItemEMA.NoUIModify = false;
      this.menuItemEMA.OriginalText = "";
      this.menuItemEMA.OwnerDraw = true;
      this.menuItemEMA.Text = "&EMA";
      this.menuItemB2B.ImageIndex = -1;
      this.menuItemB2B.ImageList = (ImageList) null;
      this.menuItemB2B.Index = 13;
      this.menuItemB2B.NoEdit = false;
      this.menuItemB2B.NoUIModify = false;
      this.menuItemB2B.OriginalText = "";
      this.menuItemB2B.OwnerDraw = true;
      this.menuItemB2B.Text = "&Business to Business ";
      this.toolsMenu.BaseName = "toolsMenu";
      this.toolsMenu.ImageIndex = -1;
      this.toolsMenu.ImageList = (ImageList) null;
      this.toolsMenu.Index = 4;
      this.toolsMenu.MenuItems.AddRange(new MenuItem[22]
      {
        (MenuItem) this.menuItemToolAdmissions,
        (MenuItem) this.menuItemLookupMaintenance,
        (MenuItem) this.menuItemExternalSchools,
        (MenuItem) this.menuItemSetups,
        (MenuItem) this.menuItemHousekeeping,
        (MenuItem) this.menuItemToolsAcademic,
        (MenuItem) this.menuItemCoverTools,
        (MenuItem) this.menuItemFeesBillingTools,
        (MenuItem) this.menuItemMaintainMedicalEvent,
        (MenuItem) this.menuItemPLASCTools,
        (MenuItem) this.menuItem12,
        (MenuItem) this.MenuItemCheckForUpdate,
        (MenuItem) this.menuItemMembershipFix,
        (MenuItem) this.menuItemAuthoriseSIMSPrimaryTransfer,
        (MenuItem) this.menuItemSysDiag,
        (MenuItem) this.menuItemToolsPATools,
        (MenuItem) this.menuItemStaff,
        (MenuItem) this.menuItemToolsSeparator,
        (MenuItem) this.menuItemCapita,
        (MenuItem) this.menuItemSolus,
        (MenuItem) this.menuItemCapitamyAccount,
        (MenuItem) this.menuItemSetupMessage
      });
      this.toolsMenu.NoEdit = false;
      this.toolsMenu.NoUIModify = false;
      this.toolsMenu.OriginalText = "";
      this.toolsMenu.OwnerDraw = true;
      this.toolsMenu.Text = "&Tools";
      this.menuItemToolAdmissions.ImageIndex = -1;
      this.menuItemToolAdmissions.ImageList = (ImageList) null;
      this.menuItemToolAdmissions.Index = 0;
      this.menuItemToolAdmissions.NoEdit = false;
      this.menuItemToolAdmissions.NoUIModify = false;
      this.menuItemToolAdmissions.OriginalText = "";
      this.menuItemToolAdmissions.OwnerDraw = true;
      this.menuItemToolAdmissions.Text = "&Admissions";
      this.menuItemLookupMaintenance.ImageIndex = -1;
      this.menuItemLookupMaintenance.ImageList = (ImageList) null;
      this.menuItemLookupMaintenance.Index = 1;
      this.menuItemLookupMaintenance.MenuItems.AddRange(new MenuItem[4]
      {
        (MenuItem) this.menuItemMaintainLookup,
        (MenuItem) this.menuItemConfigureEthnicCodes,
        (MenuItem) this.menuItemExportLookups,
        (MenuItem) this.menuItemImportLookups
      });
      this.menuItemLookupMaintenance.NoEdit = false;
      this.menuItemLookupMaintenance.NoUIModify = false;
      this.menuItemLookupMaintenance.OriginalText = "";
      this.menuItemLookupMaintenance.OwnerDraw = true;
      this.menuItemLookupMaintenance.Text = "&Lookups";
      this.menuItemMaintainLookup.ImageIndex = -1;
      this.menuItemMaintainLookup.ImageList = (ImageList) null;
      this.menuItemMaintainLookup.Index = 0;
      this.menuItemMaintainLookup.NoEdit = false;
      this.menuItemMaintainLookup.NoUIModify = false;
      this.menuItemMaintainLookup.OriginalText = "";
      this.menuItemMaintainLookup.OwnerDraw = true;
      this.menuItemMaintainLookup.Text = "&Maintain";
      this.menuItemMaintainLookup.Click += new EventHandler(this.menuItemLookupMaintenance_Click);
      this.menuItemConfigureEthnicCodes.ImageIndex = -1;
      this.menuItemConfigureEthnicCodes.ImageList = (ImageList) null;
      this.menuItemConfigureEthnicCodes.Index = 1;
      this.menuItemConfigureEthnicCodes.NoEdit = false;
      this.menuItemConfigureEthnicCodes.NoUIModify = false;
      this.menuItemConfigureEthnicCodes.OriginalText = "";
      this.menuItemConfigureEthnicCodes.OwnerDraw = true;
      this.menuItemConfigureEthnicCodes.Text = "&Configure Ethnic Codes";
      this.menuItemConfigureEthnicCodes.Click += new EventHandler(this.menuItemConfigureEthnicCodes_Click);
      this.menuItemExportLookups.ImageIndex = -1;
      this.menuItemExportLookups.ImageList = (ImageList) null;
      this.menuItemExportLookups.Index = 2;
      this.menuItemExportLookups.NoEdit = false;
      this.menuItemExportLookups.NoUIModify = false;
      this.menuItemExportLookups.OriginalText = "";
      this.menuItemExportLookups.OwnerDraw = true;
      this.menuItemExportLookups.Text = "&Export Lookup Data";
      this.menuItemExportLookups.Click += new EventHandler(this.menuItemExportLookups_Click);
      this.menuItemExternalSchools.ImageIndex = -1;
      this.menuItemExternalSchools.ImageList = (ImageList) null;
      this.menuItemExternalSchools.Index = 2;
      this.menuItemExternalSchools.NoEdit = false;
      this.menuItemExternalSchools.NoUIModify = false;
      this.menuItemExternalSchools.OriginalText = "";
      this.menuItemExternalSchools.OwnerDraw = true;
      this.menuItemExternalSchools.Text = "O&ther Schools";
      this.menuItemExternalSchools.Click += new EventHandler(this.menuItemExternalSchools_Click);
      this.menuItemSetups.BaseName = "menuItemSetups";
      this.menuItemSetups.ImageIndex = -1;
      this.menuItemSetups.ImageList = (ImageList) null;
      this.menuItemSetups.Index = 3;
      this.menuItemSetups.MenuItems.AddRange(new MenuItem[15]
      {
        (MenuItem) this.menuItemSEN,
        (MenuItem) this.menuItemConcessionSetup,
        (MenuItem) this.menuItemSetupAddresseeFormat,
        (MenuItem) this.MenuItemDocumentServers,
        (MenuItem) this.menuItemDataChangeManagement,
        (MenuItem) this.MenuItemMaintainSIMSServices,
        (MenuItem) this.menuItemFilesetImport,
        (MenuItem) this.menuItemConnexionsCard,
        (MenuItem) this.menuItemEMASetup,
        (MenuItem) this.menuItemCTFSetup,
        (MenuItem) this.menuItemUDFSetup,
        (MenuItem) this.menuItemUserOptions,
        (MenuItem) this.menuItemAttendanceSetup,
        (MenuItem) this.menuItemLessonMonitorOptions,
        (MenuItem) this.menuItemEmergencyAlertSetup
      });
      this.menuItemSetups.NoEdit = false;
      this.menuItemSetups.NoUIModify = false;
      this.menuItemSetups.OriginalText = "";
      this.menuItemSetups.OwnerDraw = true;
      this.menuItemSetups.Text = "&Setups";
      this.menuItemSEN.ImageIndex = -1;
      this.menuItemSEN.ImageList = (ImageList) null;
      this.menuItemSEN.Index = 0;
      this.menuItemSEN.NoEdit = false;
      this.menuItemSEN.NoUIModify = false;
      this.menuItemSEN.OriginalText = "";
      this.menuItemSEN.OwnerDraw = true;
      this.menuItemSEN.Text = "S&EN Setup";
      this.menuItemSEN.Click += new EventHandler(this.menuItemSENSetup_Click);
      this.menuItemConcessionSetup.ImageIndex = -1;
      this.menuItemConcessionSetup.ImageList = (ImageList) null;
      this.menuItemConcessionSetup.Index = 1;
      this.menuItemConcessionSetup.NoEdit = false;
      this.menuItemConcessionSetup.NoUIModify = false;
      this.menuItemConcessionSetup.OriginalText = "";
      this.menuItemConcessionSetup.OwnerDraw = true;
      this.menuItemConcessionSetup.Text = "&Students Concessions";
      this.menuItemConcessionSetup.Click += new EventHandler(this.menuItemConcessionSetup_Click);
      this.menuItemSetupAddresseeFormat.DefaultItem = true;
      this.menuItemSetupAddresseeFormat.ImageIndex = -1;
      this.menuItemSetupAddresseeFormat.ImageList = (ImageList) null;
      this.menuItemSetupAddresseeFormat.Index = 2;
      this.menuItemSetupAddresseeFormat.NoEdit = false;
      this.menuItemSetupAddresseeFormat.NoUIModify = false;
      this.menuItemSetupAddresseeFormat.OriginalText = "";
      this.menuItemSetupAddresseeFormat.OwnerDraw = true;
      this.menuItemSetupAddresseeFormat.Text = "Setu&p Addressee Format";
      this.menuItemSetupAddresseeFormat.Click += new EventHandler(this.menuItemSetupAddresseeFormat_Click);
      this.MenuItemDocumentServers.ImageIndex = -1;
      this.MenuItemDocumentServers.ImageList = (ImageList) null;
      this.MenuItemDocumentServers.Index = 3;
      this.MenuItemDocumentServers.NoEdit = false;
      this.MenuItemDocumentServers.NoUIModify = false;
      this.MenuItemDocumentServers.OriginalText = "";
      this.MenuItemDocumentServers.OwnerDraw = true;
      this.MenuItemDocumentServers.Text = "&Document Management Server";
      this.MenuItemDocumentServers.Click += new EventHandler(this.MenuItemConfigureDocServers_Click);
      this.MenuItemMaintainSIMSServices.ImageIndex = -1;
      this.MenuItemMaintainSIMSServices.ImageList = (ImageList) null;
      this.MenuItemMaintainSIMSServices.Index = 5;
      this.MenuItemMaintainSIMSServices.NoEdit = false;
      this.MenuItemMaintainSIMSServices.NoUIModify = false;
      this.MenuItemMaintainSIMSServices.OriginalText = "";
      this.MenuItemMaintainSIMSServices.OwnerDraw = true;
      this.MenuItemMaintainSIMSServices.Text = "SIMS Ser&vices";
      this.MenuItemMaintainSIMSServices.Click += new EventHandler(this.MenuItemMaintainSIMSServices_Click);
      this.menuItemFilesetImport.ImageIndex = -1;
      this.menuItemFilesetImport.ImageList = (ImageList) null;
      this.menuItemFilesetImport.Index = 7;
      this.menuItemFilesetImport.NoEdit = false;
      this.menuItemFilesetImport.NoUIModify = false;
      this.menuItemFilesetImport.OriginalText = "";
      this.menuItemFilesetImport.OwnerDraw = true;
      this.menuItemFilesetImport.Text = "Import Fileset";
      this.menuItemFilesetImport.Click += new EventHandler(this.menuItemFilesetImport_Click);
      this.menuItemConnexionsCard.ImageIndex = -1;
      this.menuItemConnexionsCard.ImageList = (ImageList) null;
      this.menuItemConnexionsCard.Index = 8;
      this.menuItemConnexionsCard.NoEdit = false;
      this.menuItemConnexionsCard.NoUIModify = false;
      this.menuItemConnexionsCard.OriginalText = "";
      this.menuItemConnexionsCard.OwnerDraw = true;
      this.menuItemConnexionsCard.Text = "CONNE&XIONS CARD";
      this.menuItemConnexionsCard.Click += new EventHandler(this.menuItemCCardSetup_Click);
      this.menuItemEMASetup.ImageIndex = -1;
      this.menuItemEMASetup.ImageList = (ImageList) null;
      this.menuItemEMASetup.Index = 9;
      this.menuItemEMASetup.NoEdit = false;
      this.menuItemEMASetup.NoUIModify = false;
      this.menuItemEMASetup.OriginalText = "";
      this.menuItemEMASetup.OwnerDraw = true;
      this.menuItemEMASetup.Text = "E&MA Setup";
      this.menuItemCTFSetup.ImageIndex = -1;
      this.menuItemCTFSetup.ImageList = (ImageList) null;
      this.menuItemCTFSetup.Index = 10;
      this.menuItemCTFSetup.NoEdit = false;
      this.menuItemCTFSetup.NoUIModify = false;
      this.menuItemCTFSetup.OriginalText = "";
      this.menuItemCTFSetup.OwnerDraw = true;
      this.menuItemCTFSetup.Text = "CT&F";
      this.menuItemUDFSetup.ImageIndex = -1;
      this.menuItemUDFSetup.ImageList = (ImageList) null;
      this.menuItemUDFSetup.Index = 11;
      this.menuItemUDFSetup.NoEdit = false;
      this.menuItemUDFSetup.NoUIModify = false;
      this.menuItemUDFSetup.OriginalText = "";
      this.menuItemUDFSetup.OwnerDraw = true;
      this.menuItemUDFSetup.Text = "&User Defined Fields";
      this.menuItemUDFSetup.Click += new EventHandler(this.menuItemUDFFieldDetails_Click);
      this.menuItemUserOptions.ImageIndex = -1;
      this.menuItemUserOptions.ImageList = (ImageList) null;
      this.menuItemUserOptions.Index = 12;
      this.menuItemUserOptions.NoEdit = false;
      this.menuItemUserOptions.NoUIModify = false;
      this.menuItemUserOptions.OriginalText = "";
      this.menuItemUserOptions.OwnerDraw = true;
      this.menuItemUserOptions.Text = "User &Options";
      this.menuItemUserOptions.Visible = false;
      this.menuItemUserOptions.Click += new EventHandler(this.MenuItemCustomize_Click);
      this.menuItemToolsCurriculum.ImageIndex = -1;
      this.menuItemToolsCurriculum.ImageList = (ImageList) null;
      this.menuItemToolsCurriculum.Index = 13;
      this.menuItemToolsCurriculum.NoEdit = false;
      this.menuItemToolsCurriculum.NoUIModify = false;
      this.menuItemToolsCurriculum.OriginalText = "";
      this.menuItemToolsCurriculum.OwnerDraw = true;
      this.menuItemToolsCurriculum.Text = "Curriculu&m Setup";
      this.menuItemEmergencyAlertSetup.BaseName = "menuItemEmergencyAlertSetup";
      this.menuItemEmergencyAlertSetup.ImageIndex = -1;
      this.menuItemEmergencyAlertSetup.ImageList = (ImageList) null;
      this.menuItemEmergencyAlertSetup.Index = 13;
      this.menuItemEmergencyAlertSetup.NoEdit = false;
      this.menuItemEmergencyAlertSetup.NoUIModify = false;
      this.menuItemEmergencyAlertSetup.OriginalText = "";
      this.menuItemEmergencyAlertSetup.OwnerDraw = true;
      this.menuItemEmergencyAlertSetup.Text = "Emergenc&y Alert";
      this.menuItemEmergencyAlertSetup.Click += new EventHandler(this.menuItemEmergencyAlertSetup_Click);
      this.menuItemHousekeeping.BaseName = "menuItemToolsHousekeeping";
      this.menuItemHousekeeping.ImageIndex = -1;
      this.menuItemHousekeeping.ImageList = (ImageList) null;
      this.menuItemHousekeeping.Index = 4;
      this.menuItemHousekeeping.NoEdit = false;
      this.menuItemHousekeeping.NoUIModify = false;
      this.menuItemHousekeeping.OriginalText = "";
      this.menuItemHousekeeping.OwnerDraw = true;
      this.menuItemHousekeeping.Text = "&Housekeeping";
      this.menuItemToolsAcademic.ImageIndex = -1;
      this.menuItemToolsAcademic.ImageList = (ImageList) null;
      this.menuItemToolsAcademic.Index = 5;
      this.menuItemToolsAcademic.NoEdit = false;
      this.menuItemToolsAcademic.NoUIModify = false;
      this.menuItemToolsAcademic.OriginalText = "";
      this.menuItemToolsAcademic.OwnerDraw = true;
      this.menuItemToolsAcademic.Text = "A&cademic Management";
      this.menuItemFeesBillingTools.ImageIndex = -1;
      this.menuItemFeesBillingTools.ImageList = (ImageList) null;
      this.menuItemFeesBillingTools.Index = 6;
      this.menuItemFeesBillingTools.NoEdit = false;
      this.menuItemFeesBillingTools.NoUIModify = false;
      this.menuItemFeesBillingTools.OriginalText = "";
      this.menuItemFeesBillingTools.OwnerDraw = true;
      this.menuItemFeesBillingTools.Text = "&Fees Billing";
      this.menuItemMaintainMedicalEvent.ImageIndex = -1;
      this.menuItemMaintainMedicalEvent.ImageList = (ImageList) null;
      this.menuItemMaintainMedicalEvent.Index = 7;
      this.menuItemMaintainMedicalEvent.NoEdit = false;
      this.menuItemMaintainMedicalEvent.NoUIModify = false;
      this.menuItemMaintainMedicalEvent.OriginalText = "";
      this.menuItemMaintainMedicalEvent.OwnerDraw = true;
      this.menuItemMaintainMedicalEvent.Text = "&Maintain Medical Event";
      this.menuItemMaintainMedicalEvent.Click += new EventHandler(this.MenuItemMaintainMedicalEvent_Click);
      this.menuItemPLASCTools.ImageIndex = -1;
      this.menuItemPLASCTools.ImageList = (ImageList) null;
      this.menuItemPLASCTools.Index = 8;
      this.menuItemPLASCTools.NoEdit = false;
      this.menuItemPLASCTools.NoUIModify = false;
      this.menuItemPLASCTools.OriginalText = "";
      this.menuItemPLASCTools.OwnerDraw = true;
      this.menuItemPLASCTools.Text = "Statut&ory Return Tools";
      this.menuItem12.ImageIndex = -1;
      this.menuItem12.ImageList = (ImageList) null;
      this.menuItem12.Index = 9;
      this.menuItem12.NoEdit = false;
      this.menuItem12.NoUIModify = false;
      this.menuItem12.OriginalText = "";
      this.menuItem12.OwnerDraw = true;
      this.menuItem12.Text = "-";
      this.MenuItemCheckForUpdate.ImageIndex = -1;
      this.MenuItemCheckForUpdate.ImageList = (ImageList) null;
      this.MenuItemCheckForUpdate.Index = 10;
      this.MenuItemCheckForUpdate.NoEdit = false;
      this.MenuItemCheckForUpdate.NoUIModify = false;
      this.MenuItemCheckForUpdate.OriginalText = "";
      this.MenuItemCheckForUpdate.OwnerDraw = true;
      this.MenuItemCheckForUpdate.Text = "Check for &Update";
      this.MenuItemCheckForUpdate.Click += new EventHandler(this.MenuItemCheckForUpdate_Click);
      this.menuItemSysDiag.ImageIndex = -1;
      this.menuItemSysDiag.ImageList = (ImageList) null;
      this.menuItemSysDiag.Index = 11;
      this.menuItemSysDiag.NoEdit = false;
      this.menuItemSysDiag.NoUIModify = false;
      this.menuItemSysDiag.OriginalText = "";
      this.menuItemSysDiag.OwnerDraw = true;
      this.menuItemSysDiag.Text = "System &Diagnostics";
      this.menuItemMembershipFix.ImageIndex = -1;
      this.menuItemMembershipFix.ImageList = (ImageList) null;
      this.menuItemMembershipFix.Index = 12;
      this.menuItemMembershipFix.NoEdit = false;
      this.menuItemMembershipFix.NoUIModify = false;
      this.menuItemMembershipFix.OriginalText = "";
      this.menuItemMembershipFix.OwnerDraw = true;
      this.menuItemMembershipFix.Text = "&Validate Memberships";
      this.menuItemMembershipFix.Click += new EventHandler(this.menuItemMemberhipFix_Click);
      this.menuItemAuthoriseSIMSPrimaryTransfer.ImageIndex = -1;
      this.menuItemAuthoriseSIMSPrimaryTransfer.ImageList = (ImageList) null;
      this.menuItemAuthoriseSIMSPrimaryTransfer.Index = 13;
      this.menuItemAuthoriseSIMSPrimaryTransfer.NoEdit = false;
      this.menuItemAuthoriseSIMSPrimaryTransfer.NoUIModify = false;
      this.menuItemAuthoriseSIMSPrimaryTransfer.OriginalText = "";
      this.menuItemAuthoriseSIMSPrimaryTransfer.OwnerDraw = true;
      this.menuItemAuthoriseSIMSPrimaryTransfer.Text = "Authorise SIMS &Primary Transfer";
      this.menuItemAuthoriseSIMSPrimaryTransfer.Click += new EventHandler(this.menuItemAuthorizeSIMSPrimaryTransfer_Click);
      this.WindowMenu.ImageIndex = -1;
      this.WindowMenu.ImageList = this.MenuImages;
      this.WindowMenu.Index = 5;
      this.WindowMenu.NoEdit = false;
      this.WindowMenu.NoUIModify = false;
      this.WindowMenu.OriginalText = "";
      this.WindowMenu.OwnerDraw = true;
      this.WindowMenu.Text = "&Window";
      this.WindowMenu.Popup += new EventHandler(this.WindowMenu_Popup);
      this.WindowMenu.Click += new EventHandler(this.WindowMenu_Click);
      this.menuItemShowLauncher.Checked = true;
      this.menuItemShowLauncher.ImageIndex = -1;
      this.menuItemShowLauncher.ImageList = (ImageList) null;
      this.menuItemShowLauncher.Index = 0;
      this.menuItemShowLauncher.NoEdit = false;
      this.menuItemShowLauncher.NoUIModify = false;
      this.menuItemShowLauncher.OriginalText = "";
      this.menuItemShowLauncher.OwnerDraw = true;
      this.menuItemShowLauncher.Text = "&Show Launcher";
      this.menuItemShowLauncher.Click += new EventHandler(this.menuItemShowLauncher_Click);
      this.menuItemShowLauncher.Visible = false;
      this.helpMenu.ImageIndex = -1;
      this.helpMenu.ImageList = (ImageList) null;
      this.helpMenu.Index = 6;
      this.helpMenu.MenuItems.AddRange(new MenuItem[8]
      {
        (MenuItem) this.MenuItemContents,
        (MenuItem) this.MenuItemSearch,
        (MenuItem) this.MenuItemGettingStarted,
        (MenuItem) this.MenuItemTechnicalSupport,
        (MenuItem) this.MenuItemHowToUseHelp,
        (MenuItem) this.menuItemSystemInformation,
        (MenuItem) this.MenuItemBreak6,
        (MenuItem) this.MenuItemAbout
      });
      this.helpMenu.NoEdit = false;
      this.helpMenu.NoUIModify = false;
      this.helpMenu.OriginalText = "";
      this.helpMenu.OwnerDraw = true;
      this.helpMenu.Text = "&Help";
      this.MenuItemContents.ImageIndex = -1;
      this.MenuItemContents.ImageList = (ImageList) null;
      this.MenuItemContents.Index = 0;
      this.MenuItemContents.NoEdit = false;
      this.MenuItemContents.NoUIModify = false;
      this.MenuItemContents.OriginalText = "";
      this.MenuItemContents.OwnerDraw = true;
      this.MenuItemContents.Shortcut = Shortcut.CtrlF1;
      this.MenuItemContents.Text = "&Contents";
      this.MenuItemContents.Click += new EventHandler(this.MenuItemContents_Click);
      this.MenuItemSearch.ImageIndex = -1;
      this.MenuItemSearch.ImageList = (ImageList) null;
      this.MenuItemSearch.Index = 1;
      this.MenuItemSearch.NoEdit = false;
      this.MenuItemSearch.NoUIModify = false;
      this.MenuItemSearch.OriginalText = "";
      this.MenuItemSearch.OwnerDraw = true;
      this.MenuItemSearch.Text = "&Search for Help on...";
      this.MenuItemSearch.Click += new EventHandler(this.MenuItemSearchForHelpOn_Click);
      this.MenuItemGettingStarted.ImageIndex = -1;
      this.MenuItemGettingStarted.ImageList = (ImageList) null;
      this.MenuItemGettingStarted.Index = 2;
      this.MenuItemGettingStarted.NoEdit = false;
      this.MenuItemGettingStarted.NoUIModify = false;
      this.MenuItemGettingStarted.OriginalText = "";
      this.MenuItemGettingStarted.OwnerDraw = true;
      this.MenuItemGettingStarted.Text = "&Getting Started Handbook";
      this.MenuItemGettingStarted.Click += new EventHandler(this.MenuItemGettingStarted_Click);
      this.MenuItemTechnicalSupport.ImageIndex = -1;
      this.MenuItemTechnicalSupport.ImageList = (ImageList) null;
      this.MenuItemTechnicalSupport.Index = 3;
      this.MenuItemTechnicalSupport.NoEdit = false;
      this.MenuItemTechnicalSupport.NoUIModify = false;
      this.MenuItemTechnicalSupport.OriginalText = "";
      this.MenuItemTechnicalSupport.OwnerDraw = true;
      this.MenuItemTechnicalSupport.Text = "&Technical Support";
      this.MenuItemTechnicalSupport.Click += new EventHandler(this.MenuItemTechnicalSupport_Click);
      this.MenuItemHowToUseHelp.ImageIndex = -1;
      this.MenuItemHowToUseHelp.ImageList = (ImageList) null;
      this.MenuItemHowToUseHelp.Index = 4;
      this.MenuItemHowToUseHelp.NoEdit = false;
      this.MenuItemHowToUseHelp.NoUIModify = false;
      this.MenuItemHowToUseHelp.OriginalText = "";
      this.MenuItemHowToUseHelp.OwnerDraw = true;
      this.MenuItemHowToUseHelp.Text = "How to &Use Help";
      this.MenuItemHowToUseHelp.Visible = false;
      this.MenuItemHowToUseHelp.Click += new EventHandler(this.MenuItemHowToUseHelp_Click);
      this.menuItemSystemInformation.Index = 5;
      this.menuItemSystemInformation.Text = "System &Information";
      this.menuItemSystemInformation.Click += new EventHandler(this.menuItemSystemInformation_Click);
      this.MenuItemBreak6.ImageIndex = -1;
      this.MenuItemBreak6.ImageList = (ImageList) null;
      this.MenuItemBreak6.Index = 6;
      this.MenuItemBreak6.NoEdit = false;
      this.MenuItemBreak6.NoUIModify = false;
      this.MenuItemBreak6.OriginalText = "";
      this.MenuItemBreak6.OwnerDraw = true;
      this.MenuItemBreak6.Text = "-";
      this.MenuItemAbout.ImageIndex = -1;
      this.MenuItemAbout.ImageList = (ImageList) null;
      this.MenuItemAbout.Index = 7;
      this.MenuItemAbout.NoEdit = false;
      this.MenuItemAbout.NoUIModify = false;
      this.MenuItemAbout.OriginalText = "";
      this.MenuItemAbout.OwnerDraw = true;
      this.MenuItemAbout.Text = "&About {0}";
      this.MenuItemAbout.Click += new EventHandler(this.MenuItemAbout_Click);
      this.menuItemNDCWales.ImageIndex = -1;
      this.menuItemNDCWales.ImageList = (ImageList) null;
      this.menuItemNDCWales.NoEdit = false;
      this.menuItemNDCWales.NoUIModify = false;
      this.menuItemNDCWales.OriginalText = "";
      this.menuItemNDCWales.OwnerDraw = true;
      this.menuItemNDCWales.Text = "NDC &Results";
      this.menuItemPost16Autumn.ImageIndex = -1;
      this.menuItemPost16Autumn.ImageList = (ImageList) null;
      this.menuItemPost16Autumn.Index = 2;
      this.menuItemPost16Autumn.NoEdit = false;
      this.menuItemPost16Autumn.NoUIModify = false;
      this.menuItemPost16Autumn.OriginalText = "";
      this.menuItemPost16Autumn.OwnerDraw = true;
      this.menuItemPost16Autumn.Text = "Post 16 P&LASC";
      this.menuItemPost16Summer.ImageIndex = -1;
      this.menuItemPost16Summer.ImageList = (ImageList) null;
      this.menuItemPost16Summer.Index = 3;
      this.menuItemPost16Summer.NoEdit = false;
      this.menuItemPost16Summer.NoUIModify = false;
      this.menuItemPost16Summer.OriginalText = "";
      this.menuItemPost16Summer.OwnerDraw = true;
      this.menuItemPost16Summer.Text = "Post 16 &Summer";
      this.menuItemPost16Summer.Visible = false;
      this.menuItemWelshAttendanceCollection.Text = "A&ttendance Collection";
      this.menuItemWelshAttendanceCollection.Click += new EventHandler(this.menuItemWelshAttendanceCollection_Click);
      this.menuItemWelshAttendanceCollectionMiddle.Text = "A&ttendance Collection";
      this.menuItemWelshAttendanceCollectionMiddle.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemAttendanceReturnPrimary,
        (MenuItem) this.menuItemAttendanceReturnSecondary
      });
      this.menuItemAttendanceReturnSecondary.Text = "&Secondary";
      this.menuItemAttendanceReturnSecondary.Click += new EventHandler(this.menuItemAttendanceReturnSecondary_Click);
      this.menuItemAttendanceReturnPrimary.Text = "&Primary";
      this.menuItemAttendanceReturnPrimary.Click += new EventHandler(this.menuItemAttendanceReturnPrimary_Click);
      this.menuItemCCardSetup.ImageIndex = -1;
      this.menuItemCCardSetup.ImageList = (ImageList) null;
      this.menuItemCCardSetup.Index = -1;
      this.menuItemCCardSetup.NoEdit = false;
      this.menuItemCCardSetup.NoUIModify = false;
      this.menuItemCCardSetup.OriginalText = "";
      this.menuItemCCardSetup.OwnerDraw = true;
      this.menuItemCCardSetup.Text = "Setup";
      this.menuItemCCardSetup.Click += new EventHandler(this.menuItemCCardSetup_Click);
      this.menuItemCCardSeperator1.ImageIndex = -1;
      this.menuItemCCardSeperator1.ImageList = (ImageList) null;
      this.menuItemCCardSeperator1.Index = -1;
      this.menuItemCCardSeperator1.NoEdit = false;
      this.menuItemCCardSeperator1.NoUIModify = false;
      this.menuItemCCardSeperator1.OriginalText = "";
      this.menuItemCCardSeperator1.OwnerDraw = true;
      this.menuItemCCardSeperator1.Text = "-";
      this.menuItemFees.ImageIndex = -1;
      this.menuItemFees.ImageList = (ImageList) null;
      this.menuItemFees.Index = 9;
      this.menuItemFees.NoEdit = false;
      this.menuItemFees.NoUIModify = false;
      this.menuItemFees.OriginalText = "";
      this.menuItemFees.OwnerDraw = true;
      this.menuItemFees.Text = "";
      this.panelToolBar.Shaded = false;
      this.panelToolBar.BackColor = SystemColors.Window;
      this.panelToolBar.Controls.Add((Control) this.commandBarRight);
      this.panelToolBar.Controls.Add((Control) this.commandBarNavigation);
      this.panelToolBar.Dock = DockStyle.Top;
      this.panelToolBar.Location = new System.Drawing.Point(0, 0);
      this.panelToolBar.Name = "panelToolBar";
      this.panelToolBar.Size = new Size(761, 33);
      this.panelToolBar.TabStop = false;
      this.panelToolBar.TabIndex = 0;
      this.panelOptions.Shaded = false;
      this.panelOptions.BackColor = SystemColors.Window;
      this.panelOptions.Dock = DockStyle.Left;
      this.panelOptions.Location = new System.Drawing.Point(0, 0);
      this.panelOptions.Name = "panelOptions";
      this.panelOptions.Size = new Size(128, 503);
      this.panelOptions.TabIndex = 2;
      this.panelOptions.Controls.Add((Control) this.launcher);
      this.panelOptions.Resize += new EventHandler(this.panelOptions_Resize);
      this.launcher.BackColor = SystemColors.Window;
      this.launcher.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.launcher.Dock = DockStyle.Fill;
      this.launcher.FocusBar = (CommandBar) null;
      this.launcher.Location = new System.Drawing.Point(0, 0);
      this.launcher.Name = "launcher";
      this.launcher.Size = new Size(128, 504);
      this.launcher.TabIndex = 3;
      this.launcher.TabStop = false;
      this.splitterVertical.BackColor = SystemColors.Window;
      this.splitterVertical.Cursor = Cursors.VSplit;
      this.splitterVertical.Location = new System.Drawing.Point(128, 0);
      this.splitterVertical.Name = "splitterVertical";
      this.splitterVertical.Size = new Size(4, 503);
      this.splitterVertical.TabIndex = 3;
      this.splitterVertical.TabStop = false;
      this.imageListStatusBar.ColorDepth = ColorDepth.Depth32Bit;
      this.imageListStatusBar.ImageSize = new Size(16, 16);
      this.imageListStatusBar.ImageStream = (ImageListStreamer) resourceManager.GetObject("imageListStatusBar.ImageStream");
      this.imageListStatusBar.TransparentColor = Color.Transparent;
      this.panelMain.Shaded = false;
      this.panelMain.BackColor = SystemColors.Window;
      this.panelMain.Controls.Add((Control) this.pictureBoxLogo);
      this.panelMain.Dock = DockStyle.Fill;
      this.panelMain.Location = new System.Drawing.Point(132, 0);
      this.panelMain.Name = "panelMain";
      this.panelMain.Size = new Size(761, 503);
      this.panelMain.TabIndex = 4;
      this.commandBarRight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.commandBarRight.BackColor = Color.Transparent;
      this.commandBarRight.CustomBackground = true;
      this.commandBarRight.CustomizeText = "&Customize Toolbar...";
      this.commandBarRight.Dock = DockStyle.Right;
      this.commandBarRight.ID = 2566;
      this.commandBarRight.Location = new System.Drawing.Point(0, 0);
      this.commandBarRight.Margins.Bottom = 1;
      this.commandBarRight.Margins.Left = 1;
      this.commandBarRight.Margins.Right = 1;
      this.commandBarRight.Margins.Top = 1;
      this.commandBarRight.Name = "commandBarRight";
      this.commandBarRight.Size = new Size(43, 33);
      this.commandBarRight.TabIndex = 4;
      this.commandBarRight.TabStop = false;
      this.commandBarRight.Text = "";
      this.commandBarNavigation.CustomBackground = true;
      this.commandBarNavigation.BackColor = Color.Transparent;
      this.commandBarNavigation.CustomizeText = "&Customize Toolbar...";
      this.commandBarNavigation.Dock = DockStyle.Fill;
      this.commandBarNavigation.ID = 1587;
      this.commandBarNavigation.Items.AddRange(new CommandBarItem[4]
      {
        (CommandBarItem) this.commandBarItemShowLauncher,
        (CommandBarItem) this.commandBarButtonItemBack,
        (CommandBarItem) this.commandBarButtonItemForward,
        (CommandBarItem) this.commandBarSeparatorItemNavigation
      });
      this.commandBarNavigation.Location = new System.Drawing.Point(0, 0);
      this.commandBarNavigation.Margins.Bottom = 1;
      this.commandBarNavigation.Margins.Left = 1;
      this.commandBarNavigation.Margins.Right = 1;
      this.commandBarNavigation.Margins.Top = 1;
      this.commandBarNavigation.Name = "commandBarNavigation";
      this.commandBarNavigation.Size = new Size(761, 33);
      this.commandBarNavigation.TabIndex = 3;
      this.commandBarNavigation.TabStop = false;
      this.commandBarNavigation.Text = "";
      this.commandBarButtonItemBack.Image = (Image) resourceManager.GetObject("commandBarButtonItemBack.Image");
      this.commandBarButtonItemBack.PadHorizontal = 10;
      this.commandBarButtonItemBack.ShowText = true;
      this.commandBarButtonItemBack.Style = ButtonItemStyle.Command;
      this.commandBarButtonItemBack.Text = "Back";
      this.commandBarButtonItemBack.Click += new EventHandler(this.commandBarButtonItemBack_Click);
      this.commandBarButtonItemForward.Image = (Image) resourceManager.GetObject("commandBarButtonItemForward.Image");
      this.commandBarButtonItemForward.PadHorizontal = 10;
      this.commandBarButtonItemForward.ShowText = true;
      this.commandBarButtonItemForward.Style = ButtonItemStyle.Command;
      this.commandBarButtonItemForward.Text = "Forward";
      this.commandBarButtonItemForward.Click += new EventHandler(this.commandBarButtonItemForward_Click);
      this.commandBarButtonItemForward.Visible = true;
      this.pictureBoxLogo.Dock = DockStyle.Fill;
      this.pictureBoxLogo.Image = (Image) resourceManager.GetObject("pictureBoxLogo.Image");
      this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
      this.pictureBoxLogo.Name = "pictureBoxLogo";
      this.pictureBoxLogo.Size = new Size(761, 503);
      this.pictureBoxLogo.SizeMode = PictureBoxSizeMode.CenterImage;
      this.pictureBoxLogo.TabIndex = 0;
      this.pictureBoxLogo.TabStop = false;
      this.commandBarItemShowLauncher.ShowText = true;
      this.commandBarItemShowLauncher.Style = ButtonItemStyle.Command;
      this.commandBarItemShowLauncher.Text = "Show Launcher";
      this.commandBarItemShowLauncher.ShowText = false;
      this.commandBarItemShowLauncher.Click += new EventHandler(this.commandBarItemShowLauncher_Click);
      this.imageListNavigation.ImageSize = new Size(16, 16);
      this.imageListNavigation.ImageStream = (ImageListStreamer) resourceManager.GetObject("imageListNavigation.ImageStream");
      this.imageListNavigation.TransparentColor = Color.Transparent;
      this.notifyIconInformation.Icon = (System.Drawing.Icon) resourceManager.GetObject("notifyIconInformation.Icon");
      this.notifyIconInformation.Text = "";
      this.notifyIconWarning.Icon = (System.Drawing.Icon) resourceManager.GetObject("notifyIconWarning.Icon");
      this.notifyIconWarning.Text = "";
      this.notifyIconError.Icon = (System.Drawing.Icon) resourceManager.GetObject("notifyIconError.Icon");
      this.notifyIconError.Text = "";
      this.imageListOfflineShortcuts.ImageSize = new Size(16, 16);
      this.imageListOfflineShortcuts.ImageStream = (ImageListStreamer) resourceManager.GetObject("imageListOfflineShortcuts.ImageStream");
      this.imageListOfflineShortcuts.TransparentColor = Color.Transparent;
      this.menuItemReportAssessment.ImageIndex = -1;
      this.menuItemReportAssessment.ImageList = (ImageList) null;
      this.menuItemReportAssessment.Index = 8;
      this.menuItemReportAssessment.NoEdit = false;
      this.menuItemReportAssessment.NoUIModify = false;
      this.menuItemReportAssessment.OriginalText = "";
      this.menuItemReportAssessment.OwnerDraw = true;
      this.menuItemReportAssessment.Text = "&Assessment";
      this.menuItemReportAssessment.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemReportAssessmentMissingResults,
        (MenuItem) this.menuItemReportPoS
      });
      this.menuItemReportAssessmentMissingResults.ImageIndex = -1;
      this.menuItemReportAssessmentMissingResults.ImageList = (ImageList) null;
      this.menuItemReportAssessmentMissingResults.Index = 0;
      this.menuItemReportAssessmentMissingResults.NoEdit = false;
      this.menuItemReportAssessmentMissingResults.NoUIModify = false;
      this.menuItemReportAssessmentMissingResults.OriginalText = "";
      this.menuItemReportAssessmentMissingResults.OwnerDraw = true;
      this.menuItemReportAssessmentMissingResults.Text = "&Missing Results Report";
      this.menuItemReportAssessmentMissingResults.Click += new EventHandler(this.menuItemReportAssessmentMissingResults_Click);
      this.menuItemReportPoS.ImageIndex = -1;
      this.menuItemReportPoS.ImageList = (ImageList) null;
      this.menuItemReportPoS.Index = 1;
      this.menuItemReportPoS.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemReportPoSSubjectStrandIndividual,
        (MenuItem) this.menuItemPoSAnalysisSummativeAttainment
      });
      this.menuItemReportPoS.NoEdit = false;
      this.menuItemReportPoS.NoUIModify = false;
      this.menuItemReportPoS.OriginalText = "";
      this.menuItemReportPoS.OwnerDraw = true;
      this.menuItemReportPoS.Text = "&Programme of Study";
      this.menuItemReportPoSSubjectStrandIndividual.ImageIndex = -1;
      this.menuItemReportPoSSubjectStrandIndividual.ImageList = (ImageList) null;
      this.menuItemReportPoSSubjectStrandIndividual.Index = 0;
      this.menuItemReportPoSSubjectStrandIndividual.NoEdit = false;
      this.menuItemReportPoSSubjectStrandIndividual.NoUIModify = false;
      this.menuItemReportPoSSubjectStrandIndividual.OriginalText = "";
      this.menuItemReportPoSSubjectStrandIndividual.OwnerDraw = true;
      this.menuItemReportPoSSubjectStrandIndividual.Text = "Subject/Strand &Individual Report";
      this.menuItemReportPoSSubjectStrandIndividual.Click += new EventHandler(this.menuItemReportPoSSubjectStrandIndividual_Click);
      this.menuItemReportProfiles.ImageIndex = -1;
      this.menuItemReportProfiles.ImageList = (ImageList) null;
      this.menuItemReportProfiles.Index = 7;
      this.menuItemReportProfiles.NoEdit = false;
      this.menuItemReportProfiles.NoUIModify = false;
      this.menuItemReportProfiles.OriginalText = "";
      this.menuItemReportProfiles.OwnerDraw = true;
      this.menuItemReportProfiles.Text = "&Profiles";
      this.menuItemToolsASMTools.ImageIndex = -1;
      this.menuItemToolsASMTools.ImageList = (ImageList) null;
      this.menuItemToolsASMTools.Index = 0;
      this.menuItemToolsASMTools.NoEdit = false;
      this.menuItemToolsASMTools.NoUIModify = false;
      this.menuItemToolsASMTools.OriginalText = "";
      this.menuItemToolsASMTools.OwnerDraw = true;
      this.menuItemToolsASMTools.Text = "Ass&essment";
      this.menuItemToolsPATools.BaseName = "menuItemToolsPATools";
      this.menuItemToolsPATools.ImageIndex = -1;
      this.menuItemToolsPATools.ImageList = (ImageList) null;
      this.menuItemToolsPATools.Index = 12;
      this.menuItemToolsPATools.NoEdit = false;
      this.menuItemToolsPATools.NoUIModify = false;
      this.menuItemToolsPATools.OriginalText = "";
      this.menuItemToolsPATools.OwnerDraw = true;
      this.menuItemToolsPATools.Text = "Per&formance";
      this.menuItemToolsProfilesTools.ImageIndex = -1;
      this.menuItemToolsProfilesTools.ImageList = (ImageList) null;
      this.menuItemToolsProfilesTools.Index = 2;
      this.menuItemToolsProfilesTools.NoEdit = false;
      this.menuItemToolsProfilesTools.NoUIModify = false;
      this.menuItemToolsProfilesTools.OriginalText = "";
      this.menuItemToolsProfilesTools.OwnerDraw = true;
      this.menuItemToolsProfilesTools.Text = "Prof&iles";
      this.menuItemToolsSeparator.Text = "-";
      this.menuItemToolsOptions.ImageIndex = -1;
      this.menuItemToolsOptions.ImageList = (ImageList) null;
      this.menuItemToolsOptions.NoEdit = false;
      this.menuItemToolsOptions.NoUIModify = false;
      this.menuItemToolsOptions.OriginalText = "";
      this.menuItemToolsOptions.OwnerDraw = true;
      this.menuItemToolsOptions.Text = "Options";
      this.menuItemToolsOptions.Click += new EventHandler(this.menuItemToolsOptions_Click);
      this.menuItemCapita.ImageIndex = -1;
      this.menuItemCapita.ImageList = (ImageList) null;
      this.menuItemCapita.NoEdit = false;
      this.menuItemCapita.NoUIModify = false;
      this.menuItemCapita.OriginalText = "";
      this.menuItemCapita.OwnerDraw = true;
      this.menuItemCapita.Text = "CAPITA";
      this.menuItemCapita.Visible = true;
      this.menuItemCapita.Click += new EventHandler(this.menuItemCapita_Click);
      this.menuItemSolus.ImageIndex = -1;
      this.menuItemSolus.ImageList = (ImageList) null;
      this.menuItemSolus.NoEdit = false;
      this.menuItemSolus.NoUIModify = false;
      this.menuItemSolus.OriginalText = "";
      this.menuItemSolus.OwnerDraw = true;
      this.menuItemSolus.Text = "SOLUS";
      this.menuItemSolus.Visible = true;
      this.menuItemSolus.Click += new EventHandler(this.menuItemSolus_Click);
      this.menuItemCapitamyAccount.ImageIndex = -1;
      this.menuItemCapitamyAccount.ImageList = (ImageList) null;
      this.menuItemCapitamyAccount.NoEdit = false;
      this.menuItemCapitamyAccount.NoUIModify = false;
      this.menuItemCapitamyAccount.OriginalText = "";
      this.menuItemCapitamyAccount.OwnerDraw = true;
      this.menuItemCapitamyAccount.Text = "Capita My Account";
      this.menuItemCapitamyAccount.Visible = true;
      this.menuItemCapitamyAccount.Click += new EventHandler(this.menuItemCapitamyAccount_Click);
      this.menuItemDataChangeManagement.Index = 4;
      this.menuItemDataChangeManagement.Text = "Data Change Management";
      this.menuItemDataChangeManagement.Click += new EventHandler(this.menuItemDataChangeManagement_Click);
      this.menuItemSetupMessage.Index = 4;
      this.menuItemSetupMessage.Text = "Setup Message Options";
      this.menuItemSetupMessage.Click += new EventHandler(this.menuItemSetupMessage_Click);
      this.menuItemDataOutASM.ImageIndex = -1;
      this.menuItemDataOutASM.ImageList = (ImageList) null;
      this.menuItemDataOutASM.NoEdit = false;
      this.menuItemDataOutASM.NoUIModify = false;
      this.menuItemDataOutASM.OriginalText = "";
      this.menuItemDataOutASM.OwnerDraw = true;
      this.menuItemDataOutASM.Text = "&Assessment";
      this.menuItemDataOutPA.ImageIndex = -1;
      this.menuItemDataOutPA.ImageList = (ImageList) null;
      this.menuItemDataOutPA.NoEdit = false;
      this.menuItemDataOutPA.NoUIModify = false;
      this.menuItemDataOutPA.OriginalText = "";
      this.menuItemDataOutPA.OwnerDraw = true;
      this.menuItemDataOutPA.Text = "&Performance Analysis";
      this.menuItemDataInPA.ImageIndex = -1;
      this.menuItemDataInPA.ImageList = (ImageList) null;
      this.menuItemDataInPA.NoEdit = false;
      this.menuItemDataInPA.NoUIModify = false;
      this.menuItemDataInPA.OriginalText = "";
      this.menuItemDataInPA.OwnerDraw = true;
      this.menuItemDataInPA.Text = "&Performance Analysis";
      this.menuItemDataInASM.ImageIndex = -1;
      this.menuItemDataInASM.ImageList = (ImageList) null;
      this.menuItemDataInASM.NoEdit = false;
      this.menuItemDataInASM.NoUIModify = false;
      this.menuItemDataInASM.OriginalText = "";
      this.menuItemDataInASM.OwnerDraw = true;
      this.menuItemDataInASM.Text = "&Assessment";
      this.menuASCIS.ImageIndex = -1;
      this.menuASCIS.ImageList = (ImageList) null;
      this.menuASCIS.Index = -1;
      this.menuASCIS.NoEdit = false;
      this.menuASCIS.NoUIModify = false;
      this.menuASCIS.OriginalText = "";
      this.menuASCIS.OwnerDraw = true;
      this.menuASCIS.Text = "&SLASC";
      this.menuISC.ImageIndex = -1;
      this.menuISC.ImageList = (ImageList) null;
      this.menuISC.Index = -1;
      this.menuISC.NoEdit = false;
      this.menuISC.NoUIModify = false;
      this.menuISC.OriginalText = "";
      this.menuISC.OwnerDraw = true;
      this.menuISC.Text = "ISC";
      this.menuItemPupilPremium.ImageIndex = -1;
      this.menuItemPupilPremium.ImageList = (ImageList) null;
      this.menuItemPupilPremium.Index = 10;
      this.menuItemPupilPremium.NoEdit = false;
      this.menuItemPupilPremium.NoUIModify = false;
      this.menuItemPupilPremium.OriginalText = "";
      this.menuItemPupilPremium.OwnerDraw = true;
      this.menuItemPupilPremium.Text = "Pupil Pre&mium";
      this.menuItemSchoolOptions.BaseName = "menuItemSchoolOptions";
      this.menuItemSchoolOptions.ImageIndex = -1;
      this.menuItemSchoolOptions.ImageList = (ImageList) null;
      this.menuItemSchoolOptions.NoEdit = false;
      this.menuItemSchoolOptions.NoUIModify = false;
      this.menuItemSchoolOptions.OriginalText = "";
      this.menuItemSchoolOptions.OwnerDraw = true;
      this.menuItemSchoolOptions.Text = "School Optio&ns";
      this.menuItemSchoolOptions.Click += new EventHandler(this.menuItemSchoolOptions_Click);
      this.Visible = false;
      this.WindowState = FormWindowState.Minimized;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(893, 525);
      this.Controls.Add((Control) this.panelToolBar);
      this.Controls.Add((Control) this.panelMain);
      this.Controls.Add((Control) this.splitterVertical);
      this.Controls.Add((Control) this.panelOptions);
      this.Controls.Add((Control) this.statusBar);
      this.Icon = (System.Drawing.Icon) resourceManager.GetObject("$this.Icon");
      this.Menu = this.mainMenu;
      this.Name = nameof (MainContainer);
      this.MinimumSize = new Size(800, 600);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "SIMS";
      this.ShowInTaskbar = true;
      this.Closing += new CancelEventHandler(this.MainContainer_Closing);
      this.Load += new EventHandler(this.MainContainer_Load);
      this.Closed += new EventHandler(this.MainContainer_Closed);
      this.MenuStart += new EventHandler(this.MainContainer_MenuStart);
      this.MenuComplete += new EventHandler(this.MainContainer_MenuComplete);
      this.statusBarPanelIcon.EndInit();
      this.statusBarPanelMessage.EndInit();
      this.panelOptions.ResumeLayout(false);
      this.panelMain.ResumeLayout(false);
      this.panelToolBar.ResumeLayout(false);
      this.commandBarRight.EndInit();
      this.commandBarNavigation.EndInit();
      this.ResumeLayout(false);
    }

    private void menuItemReportsBehaviourRunReportCard_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ReportCardBrowse()
      {
        IsMultiSelectable = true
      });
    }

    private void menuItemToolsAttArchivingHistory_Click(object sender, EventArgs e)
    {
      int num = (int) new ArchiveHistory().ShowDialog();
    }

    private void menuItemToolsAttArchivingArchive_Click(object sender, EventArgs e)
    {
      int num = (int) new ArchivingWizardContainer().ShowDialog();
    }

    public void statusLabel_Click(object sender, EventArgs e)
    {
      this.menuItemCurrSetAcademicYear_Click(sender, e);
    }

    public void homePageSetAcademicYear_Click()
    {
      this.menuItemCurrSetAcademicYear_Click((object) null, new EventArgs());
    }

    private void menuItemWindowChild_Click(object sender, EventArgs args)
    {
      UIMenuItem uiMenuItem = sender as UIMenuItem;
      if (uiMenuItem == null)
        return;
      this.activateItem((Control) uiMenuItem.Tag);
    }

    private void activateItem(Control component)
    {
      if (component == null || component.IsDisposed)
        return;
      this.disableTabStop();
      component.TabStop = true;
      API.SendMessage(this.Handle, 11, 0, 0);
      try
      {
        component.Visible = true;
        component.BringToFront();
        component.Focus();
        this.ActiveControl = component;
        this.activeComponent = this.panelMain.Controls.IndexOf(component);
        this.reconfigureNavigation();
        component.Refresh();
        if (!(component is IRefreshOnActivate))
          return;
        (component as IRefreshOnActivate).RefreshOnActivate();
      }
      finally
      {
        API.SendMessage(this.Handle, 11, 1, 0);
        this.Refresh();
      }
    }

    private void RemoveFromWindowMenu(Control component)
    {
      foreach (UIMenuItem menuItem in this.WindowMenu.MenuItems)
      {
        if (menuItem.Tag == component)
        {
          this.WindowMenu.MenuItems.Remove((MenuItem) menuItem);
          menuItem.Dispose();
          break;
        }
      }
    }

    private void buildDynamicWindowMenu()
    {
      this.WindowMenu.MenuItems.Clear();
      this.buildHideShowLauncherMenuItem();
      if (this.WindowMenu.MenuItems.Count > 0 && this.panelMain.Controls.Count > 2)
        this.addSeparatorToWindowMenu();
      int num = 0;
      for (int index = 0; index < this.panelMain.Controls.Count; ++index)
      {
        Control control = this.panelMain.Controls[index];
        if (control != this.pictureBoxLogo && control != this.panelToolBar)
        {
          UIMenuItem uiMenuItem = new UIMenuItem();
          uiMenuItem.Tag = (object) control;
          uiMenuItem.Text = control.Text.Length <= 0 ? control.GetType().Name : control.Text.Replace(Environment.NewLine, " | ");
          uiMenuItem.Click += new EventHandler(this.menuItemWindowChild_Click);
          this.WindowMenu.MenuItems.Add((MenuItem) uiMenuItem);
          ++num;
        }
      }
      if (num <= 0)
        return;
      UIMenuItem uiMenuItem1 = new UIMenuItem();
      uiMenuItem1.Text = SIMS.Entities.Cache.UserInterfaceLabel("Close All");
      uiMenuItem1.Click -= new EventHandler(this.closeAll_Click);
      uiMenuItem1.Click += new EventHandler(this.closeAll_Click);
      uiMenuItem1.ImageList = StandardIcons.Get();
      uiMenuItem1.ImageIndex = 8;
      this.addSeparatorToWindowMenu();
      this.WindowMenu.MenuItems.Add((MenuItem) uiMenuItem1);
    }

    private void addSeparatorToWindowMenu()
    {
      this.WindowMenu.MenuItems.Add((MenuItem) new UIMenuItem()
      {
        Text = "-"
      });
    }

    private void closeAll_Click(object sender, EventArgs e)
    {
      bool flag1 = false;
      ArrayList arrayList = new ArrayList();
      foreach (UIMenuItem menuItem in this.WindowMenu.MenuItems)
      {
        if (menuItem != null && menuItem.Tag != null)
        {
          Control tag = menuItem.Tag as Control;
          if (tag != null)
          {
            bool flag2 = true;
            AbstractContainerControl containerControl = tag as AbstractContainerControl;
            if (containerControl != null)
              flag2 = containerControl.QueryCloseContainer();
            if (containerControl is HomePageDetail)
            {
              flag2 = false;
              flag1 = true;
            }
            if (flag2)
            {
              this.NavigationZOrder.Remove((object) tag);
              this.panelMain.Controls.Remove(tag);
              arrayList.Add((object) tag);
            }
          }
        }
      }
      if (!flag1 && this.menuItemHomePage.Visible)
        this.menuItemHomePage.PerformClick();
      if (arrayList.Count > 0 && this.panelMain.Controls.Count > 0)
      {
        this.panelMain.Controls[this.panelMain.Controls.Count - 1].Focus();
        foreach (Component component in arrayList)
          component.Dispose();
      }
      this.buildDynamicWindowMenu();
      this.reconfigureNavigation();
    }

    private Control findExistingComponent(IIDEntity entity, Control component)
    {
      for (int index = 0; index < this.panelMain.Controls.Count; ++index)
      {
        Control control1 = this.panelMain.Controls[index];
        if (control1 != this.pictureBoxLogo)
        {
          if (control1 is BasicDetailControl)
          {
            if (component is BasicDetailControl && this.matchingDetailControls(control1, component, entity))
              return control1;
          }
          else if (control1 is AbstractContainerControl)
          {
            if (component is BasicDetailControl)
            {
              foreach (Control control2 in (ArrangedElementCollection) control1.Controls)
              {
                if (control2 is BasicDetailControl && this.matchingDetailControls(control2, component, entity))
                  return control1;
              }
            }
            else if (component is AbstractContainerControl && this.matchingMaintainControls(control1, component))
              return control1;
          }
        }
      }
      return (Control) null;
    }

    private bool matchingDetailControls(Control control, Control component, IIDEntity entity)
    {
      if (control.GetType().Name == component.GetType().Name)
      {
        IIDEntity idEntity = control as IIDEntity;
        if (idEntity != null && entity != null)
        {
          if (idEntity.ID == entity.ID)
            return true;
        }
        else if (control.Text == component.Text)
          return true;
      }
      return false;
    }

    private bool matchingMaintainControls(Control control, Control component)
    {
      return control.GetType().Name == component.GetType().Name;
    }

    private void WindowMenu_Popup(object sender, EventArgs args)
    {
      this.buildDynamicWindowMenu();
    }

    private void WindowMenu_Click(object sender, EventArgs args)
    {
      this.buildDynamicWindowMenu();
    }

    private string HelpFilenameMapping(string originalFileName)
    {
      return originalFileName;
    }

    private int CallingClass(object callingClass)
    {
      return HelpContextIds.GetHelpContextId(callingClass);
    }

    private void setupEmployeeContextMenu()
    {
      if (!SIMS.Entities.Cache.ProcessVisible("ViewStaffDetails"))
        return;
      NavigationRouteCache.AddRoute("Employee Details", new NavigationRouteDelegate(this.ContextEmployeeDetailUI), new int[1]
      {
        27
      }, typeof (EmployeeDetailUI), 28);
    }

    private void setupExtraNameContextMenu()
    {
      NavigationRouteCache.AddRoute("Extra Name", new NavigationRouteDelegate(this.ContextExtraNameUI), new int[1]
      {
        27
      }, typeof (ExtraNameContainer), 61);
    }

    private void setupConflictingMarkContextMenu()
    {
      NavigationRouteCache.AddRoute("Conflicting Marks", new NavigationRouteDelegate(this.ContextConflictingMarkUI), new int[1]
      {
        27
      }, typeof (ConflictingLessonMarksContainer), 62);
    }

    private void setupTakeRegisterContextMenu()
    {
      NavigationRouteCache.AddRoute("Take Register", new NavigationRouteDelegate(this.ContextTakeRegisterUI), new int[1]
      {
        27
      }, typeof (TakeRegisterContainer), 66);
    }

    private void ContextEmployeeDetailUI(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      EmployeeDetailUI employeeDetailUi = new EmployeeDetailUI(entityToDisplay);
      this.ShowContextControl((BasicDetailControl) employeeDetailUi, showAsIndependentWindow);
      employeeDetailUi.NavigateToRequiredLocation(entityToDisplay.Description);
    }

    private void ContextExtraNameUI(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((AbstractContainerControl) new ExtraNameContainer(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextConflictingMarkUI(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((AbstractContainerControl) new ConflictingLessonMarksContainer(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextTakeRegisterUI(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((AbstractContainerControl) new TakeRegisterContainer(), showAsIndependentWindow);
    }

    private void SetupContextMenu()
    {
      this.setupEmployeeContextMenu();
      this.setupExtraNameContextMenu();
      this.setupConflictingMarkContextMenu();
      this.setupTakeRegisterContextMenu();
      if (SIMS.Entities.Cache.ProcessVisible("LookupTypeBrowser") && SIMS.Entities.Cache.ProcessVisible("LookupTypeDetail"))
        NavigationRouteCache.AddRoute("Maintain Lookups", new NavigationRouteDelegate(this.ContextMaintainLookupType), new int[1]
        {
          40
        }, typeof (LookupBrowserDetailUI));
      if (SIMS.Entities.Cache.ProcessVisible("AttRetBrowser") && SIMS.Entities.Cache.ProcessVisible("AttRetDetail"))
        NavigationRouteCache.AddRoute("Attendance Return Collection", new NavigationRouteDelegate(this.ContextStudentReturn), new int[1]
        {
          41
        }, typeof (EditStudent), 41);
      if ((SIMS.Entities.Cache.ProcessVisible("EditSENStudent") || SIMS.Entities.Cache.ProcessVisible("EditStudentInformation")) && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
        NavigationRouteCache.AddRoute("Linked Documents", new NavigationRouteDocumentDelegate(this.ContextPersonLinkedDocuments), new int[1]
        {
          4
        }, typeof (ManageEntityDocuments));
      if (SIMS.Entities.Cache.ProcessVisible("ADMViewEnquiries") && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
        NavigationRouteCache.AddRoute("Linked Documents", new NavigationRouteDocumentDelegate(this.ContextPersonLinkedDocuments), new int[1]
        {
          49
        }, typeof (ManageEntityDocuments));
      if (SIMS.Entities.Cache.ProcessVisible("RunReport"))
        NavigationRouteCache.AddRoute("Quick letter", new NavigationRouteDelegate(this.ContextLetterStudent), new int[1]
        {
          4
        }, typeof (ContextReport));
      if (SIMS.Entities.Cache.ProcessVisible("RunReport") && SIMS.Entities.Cache.ProcessVisible("ADMViewEnquiries"))
        NavigationRouteCache.AddRoute("Quick letter", new NavigationRouteDelegate(this.ContextLetterEnquiry), new int[1]
        {
          49
        }, typeof (ContextReport));
      if (SIMS.Entities.Cache.ProcessVisible("RunReport"))
        NavigationRouteCache.AddRoute("Data Collection Sheet", new NavigationRouteDelegate(this.ContextDCSReport), new int[1]
        {
          4
        }, typeof (ContextReport));
      if (SIMS.Entities.InTouch.Cache.IsLicensed)
      {
        if (SIMS.Entities.Cache.ProcessVisible("InTouch.SendStudentMessageHost"))
          NavigationRouteCache.AddRoute("Send Message", new NavigationRouteDelegate(this.ContextSendStudentInTouchMsg), new int[2]
          {
            4,
            46
          }, typeof (SIMS.UserInterfaces.InTouch.SendStudentMessageHost));
        if (SIMS.Entities.Cache.ProcessVisible("InTouch.SendApplicantMessageHost"))
          NavigationRouteCache.AddRoute("Send Message", new NavigationRouteDelegate(this.ContextSendApplicantInTouchMsg), new int[4]
          {
            6,
            51,
            56,
            45
          }, typeof (SendApplicationMessageHost));
      }
      else if (SIMS.Entities.Cache.ProcessVisible("SendMessage"))
        NavigationRouteCache.AddRoute("Send Message", new NavigationRouteDelegate(this.ContextSendMsg), new int[1]
        {
          4
        }, typeof (AlertsDlgMessage));
      if (SIMS.Entities.Cache.ProcessVisible("TeachersView"))
        NavigationRouteCache.AddRoute("Student Teacher View", new NavigationRouteDelegate(this.ContextStudentTeacherView), new int[1]
        {
          4
        }, typeof (TeacherViewStudentDetail));
      if (SIMS.Entities.Cache.ProcessVisible("EditStudentInformation"))
        NavigationRouteCache.AddRoute("Student Details", new NavigationRouteDelegate(this.ContextStudent), new int[1]
        {
          4
        }, typeof (EditStudent));
      if (SIMS.Entities.Cache.ProcessVisible("EditStudentInformationReadOnly"))
        NavigationRouteCache.AddRoute("History", new NavigationRouteDatedDelegate(this.ContextStudentHistory), new int[1]
        {
          4
        }, typeof (TextBox), 4);
      if (SIMS.Entities.Cache.ProcessVisible("RunReport") && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
        NavigationRouteCache.AddRoute("Reports", new NavigationRouteDelegate(this.ContextReportStudent), new int[1]
        {
          4
        }, typeof (ContextReport));
      if (SIMS.Entities.Cache.ProcessVisible("ViewSENStudent"))
        NavigationRouteCache.AddRoute("SEN", new NavigationRouteDelegate(this.ContextSENOverview), new int[1]
        {
          4
        }, typeof (EditSENStudent));
      if (SIMS.Entities.Cache.ProcessVisible("ViewExclusionDetails"))
        NavigationRouteCache.AddRoute(SIMS.Entities.Cache.UserInterfaceLabel("Exclusions"), new NavigationRouteDelegate(this.ContextExclusions), new int[1]
        {
          4
        }, typeof (ExclusionDetails));
      if (SIMS.Entities.Cache.ProcessVisible("MaintainBehaviourDetails"))
        NavigationRouteCache.AddRoute("Behaviour Management", new NavigationRouteDelegate(this.ContextStudentBehaviour), new int[1]
        {
          4
        }, typeof (BehaviourDetails), 73);
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentConcessions") || SIMS.Entities.Cache.ProcessVisible("EditStudentConcessions"))
        NavigationRouteCache.AddRoute("Concessions", new NavigationRouteDelegate(this.ContextMenuBackStudentConcessions), new int[1]
        {
          4
        }, typeof (ConcessionDetail));
      if (SIMS.Entities.Cache.ProcessVisible(RegistrationGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("Registration Group Details", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          10
        }, typeof (RegistrationGroupDetails), 10);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("Year Group", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          13
        }, typeof (GeneralPurposeGroupDetails), 13);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("National Curriculum Year", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          14
        }, typeof (GeneralPurposeGroupDetails), 14);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("Language", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          15
        }, typeof (GeneralPurposeGroupDetails), 15);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("Religion", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          16
        }, typeof (GeneralPurposeGroupDetails), 16);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("House", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          17
        }, typeof (GeneralPurposeGroupDetails), 17);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("Ethnicity", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          18
        }, typeof (GeneralPurposeGroupDetails), 18);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("Dietary Needs", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          30
        }, typeof (GeneralPurposeGroupDetails), 30);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("Meals", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          31
        }, typeof (GeneralPurposeGroupDetails), 31);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("Modes of Travel", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          32
        }, typeof (GeneralPurposeGroupDetails), 32);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("Attendance Mode", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          19
        }, typeof (GeneralPurposeGroupDetails), 19);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("Travel Route", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          20
        }, typeof (GeneralPurposeGroupDetails), 20);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("Recoupment", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          21
        }, typeof (GeneralPurposeGroupDetails), 21);
      if (SIMS.Entities.Cache.ProcessVisible(GeneralPurposeGroupDetails.HostedProcessName()))
        NavigationRouteCache.AddRoute("Boarder", new NavigationRouteDatedDelegate(this.ContextGeneralPurposeGroupDetails), new int[1]
        {
          22
        }, typeof (GeneralPurposeGroupDetails), 22);
      if (SIMS.Entities.Cache.ProcessVisible("BrowseContacts"))
        NavigationRouteCache.AddRoute("Contact", new NavigationRouteDelegate(this.ContextContact), new int[1]
        {
          3
        }, typeof (ContactDetails), 3);
      if (SIMS.Entities.Cache.ProcessAvailable("ViewHomeSchool") || SIMS.Entities.Cache.ProcessAvailable("EditHomeSchool"))
      {
        NavigationRouteCache.AddRoute("School", new NavigationRouteDelegate(this.ContextSchool), new int[1]
        {
          33
        }, typeof (SchoolEditorUI), 33);
        NavigationRouteCache.AddRoute("School", new NavigationRouteDelegate(this.ContextSchool), new int[1]
        {
          34
        }, typeof (SchoolEditorUI));
      }
      if (SIMS.Entities.Cache.ProcessAvailable("ViewPastoralStructure") || SIMS.Entities.Cache.ProcessAvailable("EditPastoralStructure"))
        NavigationRouteCache.AddRoute("Pastoral structure", new NavigationRouteDelegate(this.ContextPastoral), new int[1]
        {
          33
        }, typeof (YearGroupsSetupUI), 12);
      if (SIMS.Entities.Cache.ProcessAvailable("ViewRoomDetails") || SIMS.Entities.Cache.ProcessAvailable("EditRoomDetails"))
      {
        NavigationRouteCache.AddRoute("Rooms", new NavigationRouteDelegate(this.ContextRooms), new int[1]
        {
          34
        }, typeof (RoomEditor), 34);
        NavigationRouteCache.AddRoute("Rooms", new NavigationRouteDelegate(this.ContextRooms), new int[1]
        {
          33
        }, typeof (RoomEditor));
      }
      if (SIMS.Entities.Cache.ProcessAvailable("EditDocumentServer"))
        NavigationRouteCache.AddRoute("Document Server", new NavigationRouteDelegate(this.ContextDocServers), new int[1]
        {
          36
        }, typeof (DocumentServerDetail), 36);
      if (SIMS.Entities.Cache.ProcessVisible("RunReport"))
        NavigationRouteCache.AddRoute("Print School Diary", new NavigationRouteDelegate(this.ContextReportDiary), new int[1]
        {
          11
        }, typeof (ContextReport));
      if (SIMS.Entities.Cache.ProcessVisible("ViewPastoralStructure") || SIMS.Entities.Cache.ProcessVisible("EditPastoralStructure"))
      {
        NavigationRouteCache.AddRoute("Current Structure", new NavigationRouteDelegate(this.ContextCurrPastoralStructure), new int[1]
        {
          33
        }, typeof (YearGroupsSetupUI));
        NavigationRouteCache.AddRoute("Next Academic Year Structure", new NavigationRouteDelegate(this.ContextNextPastoralStructure), new int[1]
        {
          33
        }, typeof (YearGroupsSetupUI));
      }
      if (SIMS.Entities.Cache.ProcessVisible("ViewCalendar") || SIMS.Entities.Cache.ProcessVisible("EditCalendar"))
        NavigationRouteCache.AddRoute("School Diary", new NavigationRouteDelegate(this.ContextSchoolDiary), new int[1]
        {
          33
        }, typeof (CalendarContainer));
      if (SIMS.Entities.Cache.ProcessVisible("ViewSENStudent") && SIMS.Entities.Cache.ProcessVisible("ApplicantDetail"))
        NavigationRouteCache.AddRoute("Student SEN", new NavigationRouteDelegate(this.ContextSENOverview), new int[1]
        {
          6
        }, typeof (EditSENStudent));
      if (SIMS.Entities.Cache.ProcessVisible("RunReport") && SIMS.Entities.Cache.ProcessVisible("ApplicantDetail"))
        NavigationRouteCache.AddRoute("Student Reports", new NavigationRouteDelegate(this.ContextReportStudent), new int[1]
        {
          6
        }, typeof (ContextReport));
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentTimetable"))
        NavigationRouteCache.AddRoute("Timetable", new NavigationRouteDatedDelegate(this.ContextStudentTimetableDetails), new int[1]
        {
          4
        }, typeof (TimetableUI), 23);
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentClasses"))
        NavigationRouteCache.AddRoute("Classes", new NavigationRouteDatedDelegate(this.ContextStudentClassesDetails), new int[1]
        {
          4
        }, typeof (StudentClassesUI), 24);
      if (SIMS.Entities.Cache.ProcessVisible("ManageCourse") && SIMS.Entities.Cache.ProcessVisible("ViewCourse"))
        NavigationRouteCache.AddRoute("Maintain Course", new NavigationRouteDelegate(this.ContextCourseEditCourseDetails), new int[1]
        {
          65
        }, typeof (MaintainCourseDetail), 65);
      if (SIMS.Entities.Cache.ProcessVisible("ManageCourse") && SIMS.Entities.Cache.ProcessVisible("ViewCourse"))
        NavigationRouteCache.AddRoute("Maintain Course", new NavigationRouteDelegate(this.ContextNewCourseEditCourseDetails), new int[1]
        {
          77
        }, typeof (MaintainCourseDetail), 77);
      if (SIMS.Entities.Cache.ProcessVisible("StudentSessionMarksProcess"))
        NavigationRouteCache.AddRoute("Attendance", new NavigationRouteDatedDelegate(this.ContextStudentAttendanceDetails), new int[1]
        {
          4
        }, typeof (StudentMarksDetail), 25);
      SIMS.UserInterfaces.DinnerMoney.MainContainerHelper.SetupContextMenus();
      SIMS.UserInterfaces.InTouch.MainContainerHelper.SetupContextMenus();
      SIMS.UserInterfaces.Discover.MainContainerHelper.SetupContextMenus();
      SIMS.UserInterfaces.ThirdParty.MainContainerHelper.SetupContextMenus();
      if (SIMS.Entities.Cache.ProcessVisible("StudentSessionMarksProcess"))
        NavigationRouteCache.AddRoute("Deal with Missing Marks", new NavigationRouteDelegate(this.ContextStudentDealWithMissingMarks), new int[1]
        {
          64
        }, typeof (StudentMarksDetail), 64);
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentAssessment"))
        NavigationRouteCache.AddRoute("Assessment", new NavigationRouteDelegate(this.contextStudentAssessResultsDetail), new int[1]
        {
          4
        }, typeof (StudentAssessResultsDetail), 26);
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentExamResults"))
        NavigationRouteCache.AddRoute("Examinations", new NavigationRouteDelegate(this.contextStudentExamResultsDetail), new int[1]
        {
          4
        }, typeof (StudentExamResultsDetail));
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentClasses"))
        NavigationRouteCache.AddRoute("Class", new NavigationRouteDatedDelegate(this.ContextSingleClassDetails), new int[1]
        {
          24
        }, typeof (SingleClassUI), 27);
      if (SIMS.Entities.Cache.ProcessVisible("ViewStaffDetails"))
        NavigationRouteCache.AddRoute("Employee Details", new NavigationRouteDatedDelegate(this.ContextEmployeeDetail), new int[1]
        {
          27
        }, typeof (EmployeeDetailUI), 28);
      if (SIMS.Entities.Cache.ProcessVisible("ViewStaffDetails"))
        NavigationRouteCache.AddRoute("Staff Timetable", new NavigationRouteDatedDelegate(this.ContextStaffTimetableDetails), new int[1]
        {
          28
        }, typeof (StaffTimetableUI), 29);
      if (SIMS.Entities.Cache.ProcessVisible("ViewStaffDetails"))
        NavigationRouteCache.AddRoute("Staff Groups", new NavigationRouteDatedDelegate(this.ContextTeacherGroupDetails), new int[1]
        {
          28
        }, typeof (StaffGroupsUI), 38);
      if (SIMS.Entities.Cache.ProcessVisible("RunReport") && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
        NavigationRouteCache.AddRoute("Employee Reports", new NavigationRouteDelegate(this.ContextReportEmployee), new int[1]
        {
          28
        }, typeof (ContextReport));
      if (SIMS.Entities.Cache.ProcessVisible("ViewStaffDetails") && SIMS.Entities.Cache.ProcessVisible("EditAuthorisation") && SIMS.Entities.Cache.EnableB2B)
        NavigationRouteCache.AddRoute(this.menuItemB2BAuthoriseChanges.Text, new NavigationRouteDelegate(this.ContextStaffAuthorization), new int[1]
        {
          28
        }, typeof (B2BAuthoriseDataDetailUI));
      if (SIMS.Entities.Cache.ProcessVisible("ViewStaffDetails") && SIMS.Entities.Cache.ProcessVisible("EditSuspense") && SIMS.Entities.Cache.EnableB2B)
        NavigationRouteCache.AddRoute(this.menuItemB2BSuspension.Text, new NavigationRouteDelegate(this.ContextStaffSuspense), new int[1]
        {
          28
        }, typeof (B2BSuspensionDetailUI));
      if (SIMS.Entities.Cache.ProcessVisible("ViewHomeSchool") || SIMS.Entities.Cache.ProcessVisible("EditHomeSchool"))
        NavigationRouteCache.AddRoute("External Schools", new NavigationRouteDelegate(this.ContextExternalScools), new int[1]
        {
          37
        }, typeof (ExternalSchoolEditor), 37);
      if (SIMS.Entities.Cache.ProcessVisible("ViewHomeSchool") && SIMS.Entities.Cache.ProcessVisible("EditHomeSchool"))
        NavigationRouteCache.AddRoute("Schools", new NavigationRouteDelegate(this.ContextSchools), new int[1]
        {
          -1
        }, typeof (MaintainExternalSchool));
      if (SIMS.Entities.Cache.ProcessVisible("FeesDetailsView") || SIMS.Entities.Cache.ProcessAvailable("FeesViewRegistrationDetails"))
      {
        NavigationRouteCache.AddRoute("Fees Details", new NavigationRouteDelegate(this.ContextFeesStudentDetailsOverview), new int[1]
        {
          4
        }, typeof (FeesStudentDetail));
        NavigationRouteCache.AddRoute("Fees Details", new NavigationRouteDelegate(this.ContextFeesStudentDetailsRAOverview), new int[1]
        {
          6
        }, typeof (FeesApplicationDetail));
      }
      if (SIMS.Entities.Cache.ProcessVisible("ViewCourse"))
        NavigationRouteCache.AddRoute("Courses", new NavigationRouteDelegate(this.ContextStudentCoursesDetail), new int[1]
        {
          4
        }, typeof (StudentCoursesDetail), 58);
      if (SIMS.Entities.Cache.ProcessVisible("TeachersView"))
        NavigationRouteCache.AddRoute("Student Teachers View", new NavigationRouteDelegate(this.ContextTeachersView), new int[1]
        {
          63
        }, typeof (TeacherViewStudentDetail), 63);
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentPpodData"))
      {
        NavigationRouteCache.AddRoute("PPOD Student Details", new NavigationRouteDelegate(this.ContextPPODStudentView), new int[1]
        {
          4
        }, typeof (DlgPPODReport));
        NavigationRouteCache.AddRoute("PPOD Student Details", new NavigationRouteDelegate(this.ContextPPODStudentView), new int[1]
        {
          6
        }, typeof (DlgPPODReport));
      }
      if (SIMS.Entities.Cache.ProcessVisible("ViewSchoolPpodData"))
        NavigationRouteCache.AddRoute("PPOD School Details", new NavigationRouteDelegate(this.ContextPPODSchoolDetailsView), new int[1]
        {
          33
        }, typeof (DlgPPODReport));
      this.setupDeniContextMenu();
      this.setupPlascContextMenu();
      this.addRAContextLinks();
      this.addAcademicContextLinks();
      this.addFeesContextLinks();
      this.setupViewTimetableContextMenu();
      this.setupAgentContextMenu();
      this.setupDetentionsContextMenu();
      this.setupUDGContextMenu();
      this.setupProfilesContextMenu();
      if (SIMS.Entities.Cache.ProcessVisible("TPPGridViewAll"))
      {
        NavigationRouteCache.AddRoute("Subject/Strand Individual Report", new NavigationRouteDelegateForPoS(this.ContextMenuSubjectStrandReport), new int[1]
        {
          83
        }, typeof (DlgIndividualAnalysisReportDialog), 83);
        if (SystemConfigurationCache.LocaleCode == "ENG")
        {
          NavigationRouteCache.AddRoute("Summative Attainment", new NavigationRouteDelegateForPoS(this.ContextMenuSummativeAttainmentReport), new int[1]
          {
            83
          }, typeof (PoSSummativeAttainmentDetail), 83);
          NavigationRouteCache.AddRoute("Summative Progress", new NavigationRouteDelegateForPoS(this.ContextMenuSummativeProgressReport), new int[1]
          {
            83
          }, typeof (PoSSummativeProgressDetail), 83);
        }
        NavigationRouteCache.AddRoute("Formative Attainment", new NavigationRouteDelegateForPoS(this.ContextMenuFormativeAttainmentReport), new int[1]
        {
          83
        }, typeof (PoSFormativeAttainmentDetail), 83);
        NavigationRouteCache.AddRoute("Formative Progress", new NavigationRouteDelegateForPoS(this.ContextMenuFormativeProgressReport), new int[1]
        {
          83
        }, typeof (PoSFormativeProgressDetail), 83);
      }
      if (SIMS.Entities.Cache.ProcessVisible("IntervRunViewAll"))
      {
        NavigationRouteCache.AddRoute("Run Intervention", new NavigationRouteDelegate(this.ContextMenuInterventionRun), new int[1]
        {
          84
        }, typeof (InterventionInstanceDetail), 84);
        NavigationRouteCache.AddRoute("Intervention Report", new NavigationRouteDelegate(this.ContextMenuInterventionReport), new int[1]
        {
          4
        }, typeof (DlgInterventionStudentReport), 85);
      }
      if (!SIMS.Entities.Cache.ProcessVisible("EditStudentNationalityProcess") || !SIMS.Entities.Cache.CurrentSchool.Tier4Applications)
        return;
      NavigationRouteCache.AddRoute("Tier 4 Details", new NavigationRouteDelegate(this.ContextTier4Details), new int[1]
      {
        4
      }, typeof (StudentTier4Detail));
      NavigationRouteCache.AddRoute("Tier 4 Details", new NavigationRouteDelegate(this.ContextTier4Details), new int[1]
      {
        6
      }, typeof (StudentTier4Detail));
    }

    private void setupProfilesContextMenu()
    {
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentAssessment"))
        NavigationRouteCache.AddRoute("Assessment", new NavigationRouteDelegate(this.contextStudentAssessResultsDetail), new int[1]
        {
          81
        }, typeof (StudentAssessResultsDetail), 26);
      if (SIMS.Entities.Cache.ProcessVisible("StudentSessionMarksProcess"))
        NavigationRouteCache.AddRoute("Attendance", new NavigationRouteDatedDelegate(this.ContextStudentAttendanceDetails), new int[1]
        {
          81
        }, typeof (StudentMarksDetail), 25);
      if (SIMS.Entities.Cache.ProcessVisible("MaintainBehaviourDetails"))
        NavigationRouteCache.AddRoute("Behaviour Management", new NavigationRouteDelegate(this.ContextStudentBehaviour), new int[1]
        {
          81
        }, typeof (BehaviourDetails));
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentExamResults"))
        NavigationRouteCache.AddRoute("Examinations", new NavigationRouteDelegate(this.contextStudentExamResultsDetail), new int[1]
        {
          81
        }, typeof (StudentExamResultsDetail));
      if (GridEntryBrowser.Ispermitted())
        NavigationRouteCache.AddRoute("Linked Documents", new NavigationRouteDocumentDelegate(this.ContextPersonLinkedDocuments), new int[1]
        {
          81
        }, typeof (ManageEntityDocuments));
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentAssessment"))
        NavigationRouteCache.AddRoute("Assessment", new NavigationRouteDelegate(this.contextStudentAssessResultsDetail), new int[1]
        {
          80
        }, typeof (StudentAssessResultsDetail), 26);
      if (SIMS.Entities.Cache.ProcessVisible("StudentSessionMarksProcess"))
        NavigationRouteCache.AddRoute("Attendance", new NavigationRouteDatedDelegate(this.ContextStudentAttendanceDetails), new int[1]
        {
          80
        }, typeof (StudentMarksDetail), 25);
      if (SIMS.Entities.Cache.ProcessVisible("MaintainBehaviourDetails"))
        NavigationRouteCache.AddRoute("Behaviour Management", new NavigationRouteDelegate(this.ContextStudentBehaviour), new int[1]
        {
          80
        }, typeof (BehaviourDetails));
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentExamResults"))
        NavigationRouteCache.AddRoute("Examinations", new NavigationRouteDelegate(this.contextStudentExamResultsDetail), new int[1]
        {
          80
        }, typeof (StudentExamResultsDetail));
      if (ListEntryDetail.Ispermitted())
        NavigationRouteCache.AddRoute("Linked Documents", new NavigationRouteDocumentDelegate(this.ContextPersonLinkedDocuments), new int[1]
        {
          80
        }, typeof (ManageEntityDocuments));
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentAssessment"))
        NavigationRouteCache.AddRoute("Assessment", new NavigationRouteDelegate(this.contextStudentAssessResultsDetail), new int[1]
        {
          82
        }, typeof (StudentAssessResultsDetail), 26);
      if (SIMS.Entities.Cache.ProcessVisible("StudentSessionMarksProcess"))
        NavigationRouteCache.AddRoute("Attendance", new NavigationRouteDatedDelegate(this.ContextStudentAttendanceDetails), new int[1]
        {
          82
        }, typeof (StudentMarksDetail), 25);
      if (SIMS.Entities.Cache.ProcessVisible("MaintainBehaviourDetails"))
        NavigationRouteCache.AddRoute("Behaviour Management", new NavigationRouteDelegate(this.ContextStudentBehaviour), new int[1]
        {
          82
        }, typeof (BehaviourDetails));
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentExamResults"))
        NavigationRouteCache.AddRoute("Examinations", new NavigationRouteDelegate(this.contextStudentExamResultsDetail), new int[1]
        {
          82
        }, typeof (StudentExamResultsDetail));
      if (!GridEntryDetail.Ispermitted())
        return;
      NavigationRouteCache.AddRoute("Linked Documents", new NavigationRouteDocumentDelegate(this.ContextPersonLinkedDocuments), new int[1]
      {
        82
      }, typeof (ManageEntityDocuments));
    }

    private void ContextStaffAuthorization(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (!SIMS.Entities.Cache.EnableB2B)
      {
        int num = (int) MessageBox.Show((IWin32Window) this.ParentForm, "B2B:Personnel has not been activated.", "B2B:Personnel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
      }
      else
        this.ShowContextControl((BasicDetailControl) new B2BAuthoriseDataDetailUI(entityToDisplay), false);
    }

    private void ContextStaffSuspense(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (!SIMS.Entities.Cache.EnableB2B)
      {
        int num = (int) MessageBox.Show((IWin32Window) this.ParentForm, "B2B:Personnel has not been activated.", "B2B:Personnel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
      }
      else
        this.ShowContextControl((BasicDetailControl) new B2BSuspensionDetailUI(entityToDisplay), false);
    }

    private void ContextStaffDetail(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl(entityToDisplay, (BasicDetailControl) new EmployeeDetailUI(entityToDisplay), false);
    }

    private void ContextExternalScools(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new ExternalSchoolEditor(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextTeacherGroupDetails(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new StaffGroupsUI(entityToDisplay, effectiveDate), showAsIndependentWindow);
    }

    private void ContextEmployeeDetail(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new EmployeeDetailUI(entityToDisplay, effectiveDate), showAsIndependentWindow);
    }

    private void ContextStaffTimetableDetails(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new StaffTimetableUI(entityToDisplay, effectiveDate), showAsIndependentWindow);
    }

    private void ContextStudentTimetableDetails(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      if (entityToDisplay != null)
        this.ShowContextControl((BasicDetailControl) new TimetableUI(entityToDisplay, effectiveDate), showAsIndependentWindow);
      else
        SIMS.Entities.Cache.StatusMessage("No student selected.", UserMessageEventEnum.Information);
    }

    private void ContextStudentClassesDetails(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      if (entityToDisplay != null)
        this.ShowContextControl((BasicDetailControl) new StudentClassesUI(entityToDisplay, effectiveDate), showAsIndependentWindow);
      else
        SIMS.Entities.Cache.StatusMessage("No student selected.", UserMessageEventEnum.Information);
    }

    private void ContextSingleClassDetails(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new SingleClassUI(entityToDisplay, effectiveDate), showAsIndependentWindow);
    }

    private void ContextCourseEditCourseDetails(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      MaintainCourseDetail maintainCourseDetail = new MaintainCourseDetail(entityToDisplay);
      this.ShowContextControl((BasicDetailControl) maintainCourseDetail, showAsIndependentWindow);
      maintainCourseDetail.NavigateToPanel(entityToDisplay.Description);
    }

    private void ContextNewCourseEditCourseDetails(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      CourseManagerMaintainCourseDetail maintainCourseDetail = new CourseManagerMaintainCourseDetail(entityToDisplay);
      this.ShowContextControl((BasicDetailControl) maintainCourseDetail, showAsIndependentWindow);
      maintainCourseDetail.NavigateToPanel(entityToDisplay.Description);
    }

    private void ContextStudentAttendanceDetails(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new StudentMarksDetail(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextStudentDealWithMissingMarks(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new MissingMarksDetail(entityToDisplay), showAsIndependentWindow);
    }

    private void contextStudentAssessResultsDetail(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new StudentAssessResultsDetail(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextGeneralPurposeGroupDetails(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new GeneralPurposeGroupDetails(entityToDisplay, effectiveDate), showAsIndependentWindow);
    }

    private void ContextMaintainLookupType(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((AbstractContainerControl) new LookupBrowserDetailUI(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextSENOverview(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      EditSENStudent editSenStudent = new EditSENStudent(entityToDisplay);
      if (entityToDisplay is DetailedApplication)
        editSenStudent.IsApplication = true;
      this.ShowContextControl((BasicDetailControl) editSenStudent, showAsIndependentWindow);
      editSenStudent.LinkBar.NavigateTo(editSenStudent.groupBoxOverview);
    }

    private void ContextSendSENMsg(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (entityToDisplay.ID == 0)
        return;
      int num = (int) new SENMessageUserInterface(entityToDisplay).ShowDialog();
    }

    private void ContextSENNeeds(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      EditSENStudent editSenStudent = new EditSENStudent(entityToDisplay);
      this.ShowContextControl((BasicDetailControl) editSenStudent, showAsIndependentWindow);
      editSenStudent.LinkBar.NavigateTo(editSenStudent.groupBoxBasicSENDetails);
    }

    private void ContextSENReviews(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      EditSENStudent editSenStudent = new EditSENStudent(entityToDisplay);
      this.ShowContextControl((BasicDetailControl) editSenStudent, showAsIndependentWindow);
      editSenStudent.LinkBar.NavigateTo(editSenStudent.groupBoxReviews);
    }

    private void ContextSENIEP(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      EditSENStudent editSenStudent = new EditSENStudent(entityToDisplay);
      this.ShowContextControl((BasicDetailControl) editSenStudent, showAsIndependentWindow);
      editSenStudent.LinkBar.NavigateTo(editSenStudent.groupBoxIEP);
    }

    private void ContextSENEvents(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      EditSENStudent editSenStudent = new EditSENStudent(entityToDisplay);
      this.ShowContextControl((BasicDetailControl) editSenStudent, showAsIndependentWindow);
      editSenStudent.LinkBar.NavigateTo(editSenStudent.groupBoxEvents);
    }

    private void ContextSENStatement(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      EditSENStudent editSenStudent = new EditSENStudent(entityToDisplay);
      this.ShowContextControl((BasicDetailControl) editSenStudent, showAsIndependentWindow);
      editSenStudent.LinkBar.NavigateTo(editSenStudent.groupBoxStatements);
    }

    private void ContextSENProvision(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      EditSENStudent editSenStudent = new EditSENStudent(entityToDisplay);
      this.ShowContextControl((BasicDetailControl) editSenStudent, showAsIndependentWindow);
      editSenStudent.LinkBar.NavigateTo(editSenStudent.groupBoxProvisions);
    }

    private void ContextExclusions(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (entityToDisplay != null)
        this.ShowContextControl((BasicDetailControl) new ExclusionDetails(entityToDisplay), showAsIndependentWindow);
      else
        SIMS.Entities.Cache.StatusMessage("No student selected.", UserMessageEventEnum.Information);
    }

    private void ContextClassType(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new EditStudentClassType(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextUpdateHoursAtSetting(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new EditStudentUpdatHoursAtSetting(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextBasicSkills(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new PLASCEditBasicSkills(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextStudentBehaviour(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (entityToDisplay != null)
        this.ShowContextControl((BasicDetailControl) new BehaviourDetails(entityToDisplay), showAsIndependentWindow);
      else
        SIMS.Entities.Cache.StatusMessage("No student selected.", UserMessageEventEnum.Information);
    }

    private void ContextMenuBackStudentConcessions(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new ConcessionDetail(entityToDisplay), showAsIndependentWindow);
    }

    private string getNameofOpenPosAnalysisScreen()
    {
      string str = string.Empty;
      if (this.ComponentExists("SIMS.UserInterfaces.PoSSummativeAttainmentDetail") != null)
        str = "Programme of Study Summative Attainment Analysis";
      else if (this.ComponentExists("SIMS.UserInterfaces.PoSSummativeProgressDetail") != null)
        str = "Programme of Study Summative Progress Analysis";
      else if (this.ComponentExists("SIMS.UserInterfaces.PoSFormativeAttainmentDetail") != null)
        str = "Programme of Study Formative Attainment Analysis";
      else if (this.ComponentExists("SIMS.UserInterfaces.PoSFormativeProgressDetail") != null)
        str = "Programme of Study Formative Progress Analysis";
      return str;
    }

    private void ContextMenuFormativeAttainmentReport(
      object callingProcess,
      bool showAsIndependentWindow)
    {
      string posAnalysisScreen = this.getNameofOpenPosAnalysisScreen();
      if (posAnalysisScreen != string.Empty)
      {
        int num = (int) MessageBox.Show(string.Format("Please close the {0} screen before opening this screen.", (object) posAnalysisScreen), SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
        this.ShowContextControl((BasicDetailControl) new PoSFormativeAttainmentDetail(callingProcess as SIMS.Processes.TPPGridDetail), showAsIndependentWindow);
    }

    private void ContextMenuFormativeProgressReport(
      object callingProcess,
      bool showAsIndependentWindow)
    {
      string posAnalysisScreen = this.getNameofOpenPosAnalysisScreen();
      if (posAnalysisScreen != string.Empty)
      {
        int num = (int) MessageBox.Show(string.Format("Please close the {0} screen before opening this screen.", (object) posAnalysisScreen), SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
        this.ShowContextControl((BasicDetailControl) new PoSFormativeProgressDetail(callingProcess as SIMS.Processes.TPPGridDetail), showAsIndependentWindow);
    }

    private void ContextMenuSummativeProgressReport(
      object callingProcess,
      bool showAsIndependentWindow)
    {
      string posAnalysisScreen = this.getNameofOpenPosAnalysisScreen();
      if (posAnalysisScreen != string.Empty)
      {
        int num = (int) MessageBox.Show(string.Format("Please close the {0} screen before opening this screen.", (object) posAnalysisScreen), SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
        this.ShowContextControl((BasicDetailControl) new PoSSummativeProgressDetail(callingProcess as SIMS.Processes.TPPGridDetail), showAsIndependentWindow);
    }

    private void ContextMenuSummativeAttainmentReport(
      object callingProcess,
      bool showAsIndependentWindow)
    {
      string posAnalysisScreen = this.getNameofOpenPosAnalysisScreen();
      if (posAnalysisScreen != string.Empty)
      {
        int num = (int) MessageBox.Show(string.Format("Please close the {0} screen before opening this screen.", (object) posAnalysisScreen), SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
        this.ShowContextControl((BasicDetailControl) new PoSSummativeAttainmentDetail(callingProcess as SIMS.Processes.TPPGridDetail), showAsIndependentWindow);
    }

    private void ContextMenuSubjectStrandReport(object callingProcess, bool showAsIndependentWindow)
    {
      int num = (int) new DlgIndividualAnalysisReportDialog(callingProcess as SIMS.Processes.TPPGridDetail).ShowDialog();
    }

    private void ContextMenuInterventionRun(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new InterventionInstanceDetail(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextMenuInterventionReport(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      using (DlgInterventionStudentReport interventionStudentReport = new DlgInterventionStudentReport(entityToDisplay))
      {
        int num = (int) interventionStudentReport.ShowDialog((IWin32Window) this);
      }
    }

    private void ContextAgent(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      AgencyUIInterfaceReferences.StudentInterfaceReference = (IStudentBrowse) new IStudentBrowseContainer();
      this.ShowContextControl((BasicDetailControl) new AgentDetailUI(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextStudentTeacherView(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (entityToDisplay != null)
        this.ShowContextControl((BasicDetailControl) new TeacherViewStudentDetail(entityToDisplay), showAsIndependentWindow);
      else
        SIMS.Entities.Cache.StatusMessage("No student selected.", UserMessageEventEnum.Information);
    }

    private void ContextStudent(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new EditStudent(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextStudentHistory(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new EditStudent(entityToDisplay, effectiveDate, true), showAsIndependentWindow);
    }

    private void ContextRegistrationGroup(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new RegistrationGroupDetails(entityToDisplay, effectiveDate), showAsIndependentWindow);
    }

    private void ContextAgency(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      AgencyUIInterfaceReferences.StudentInterfaceReference = (IStudentBrowse) new IStudentBrowseContainer();
      this.ShowContextControl((BasicDetailControl) new AgencyDetailUI(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextContact(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new ContactDetails(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextSchool(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new SchoolEditorUI(), showAsIndependentWindow);
    }

    private void ContextPastoral(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      PastoralStructureType structureType = PastoralStructureType.Undefined;
      if (entityToDisplay.ID == 0)
        structureType = PastoralStructureType.Current;
      if (entityToDisplay.ID == 1)
        structureType = PastoralStructureType.NextAcademicYear;
      this.ShowContextControl((AbstractComponentControl) new YearGroupsSetupUI(structureType), showAsIndependentWindow);
    }

    private void ContextRooms(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.DisplayComponent((Control) new RoomEditor());
    }

    private void ContextDocServers(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.DisplayComponent((Control) new DocumentServerDetail());
    }

    private void ContextTimeInUnit(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new EditStudentTimeInUnit(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextProviderStatus(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new EditStudentProviderStatus(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextPersonLinkedDocuments(
      IIDEntity entityToDisplay,
      int navigationContext,
      bool showAsIndependentWindow)
    {
      if (entityToDisplay == null)
        SIMS.Entities.Cache.StatusMessage("No student selected.", UserMessageEventEnum.Information);
      else if (entityToDisplay is DetailedApplication)
      {
        MainContainer.IDShim idShim = new MainContainer.IDShim();
        idShim.SetDescription(entityToDisplay.Description);
        idShim.ID = entityToDisplay.ID;
        int num = (int) new ManageEntityDocuments((IIDEntity) idShim, navigationContext).ShowDialog((IWin32Window) this);
      }
      else
      {
        int num1 = (int) new ManageEntityDocuments(entityToDisplay, navigationContext).ShowDialog((IWin32Window) this);
      }
    }

    private void ContextReportStudent(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (entityToDisplay != null)
        new ContextReport("Student", entityToDisplay.ID).Run((Form) this);
      else
        SIMS.Entities.Cache.StatusMessage("No student selected.", UserMessageEventEnum.Information);
    }

    private void ContextReportDiary(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      new ContextReport("Diary", 0).Run((Form) this);
    }

    private void ContextCurrPastoralStructure(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.DisplayComponent((Control) new YearGroupsSetupUI(PastoralStructureType.Current));
    }

    private void ContextNextPastoralStructure(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.DisplayComponent((Control) new YearGroupsSetupUI(PastoralStructureType.NextAcademicYear));
    }

    private void ContextSchoolDiary(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      try
      {
        this.DisplayComponent((Control) new CalendarContainer());
      }
      catch (CalendarBuilder.AcademicYearNotDefinedException ex)
      {
        int num = (int) MessageBox.Show((IWin32Window) this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void ContextReportEmployee(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      new ContextReport("Staff", entityToDisplay.ID, true).Run((Form) this);
    }

    private void ContextLetterStudent(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (entityToDisplay != null)
        new ContextReport("Student", entityToDisplay.ID).RunQuickLetter();
      else
        SIMS.Entities.Cache.StatusMessage("No student selected.", UserMessageEventEnum.Information);
    }

    private void ContextDCSReport(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (entityToDisplay != null)
        new ContextReport("Data Collection Sheet", entityToDisplay.ID).Run((Form) this);
      else
        SIMS.Entities.Cache.StatusMessage("No student selected.", UserMessageEventEnum.Information);
    }

    private void contextStudentExamResultsDetail(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      StudentExamResultsDetail examResultsDetail = new StudentExamResultsDetail(entityToDisplay);
      if (entityToDisplay is DetailedApplication)
        examResultsDetail.IsApplication = true;
      this.ShowContextControl((BasicDetailControl) examResultsDetail, showAsIndependentWindow);
    }

    private void ShowContextControl(AbstractComponentControl control, bool showAsIndependentWindow)
    {
      this.ShowContextControl((IIDEntity) null, control, showAsIndependentWindow);
    }

    private void ShowContextControl(AbstractContainerControl control, bool showAsIndependentWindow)
    {
      this.ShowContextControl((IIDEntity) null, control, showAsIndependentWindow);
    }

    private void ShowContextControl(BasicDetailControl control, bool showAsIndependentWindow)
    {
      this.ShowContextControl((IIDEntity) null, control, showAsIndependentWindow);
    }

    private void ShowContextControl(
      IIDEntity entity,
      AbstractComponentControl control,
      bool showAsIndependentWindow)
    {
      if (showAsIndependentWindow)
      {
        control.Unpin((AbstractContainerControl) control);
        control.Show();
      }
      else
      {
        this.checkForBackBranch((Control) control);
        this.DisplayComponent(entity, (Control) control);
      }
    }

    private void ShowContextControl(
      IIDEntity entity,
      AbstractContainerControl control,
      bool showAsIndependentWindow)
    {
      if (showAsIndependentWindow)
      {
        control.Unpin(control);
        control.Show();
      }
      else
      {
        this.checkForBackBranch((Control) control);
        this.DisplayComponent(entity, (Control) control);
      }
    }

    private void ShowContextControl(
      IIDEntity entity,
      ApplicationContainer control,
      bool showAsIndependentWindow)
    {
      if (showAsIndependentWindow)
      {
        control.Unpin((AbstractContainerControl) control);
        control.Show();
      }
      else if (this.findExistingComponent(entity, (Control) control) == null)
      {
        this.checkForBackBranch((Control) control);
        this.DisplayComponent(entity, (Control) control);
      }
      else
      {
        int num = (int) MessageBox.Show("The Application Screen is already opened. Please close the Application screen before creating a new application.", "SIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void ShowContextControl(
      IIDEntity entity,
      BasicDetailControl control,
      bool showAsIndependentWindow)
    {
      if (showAsIndependentWindow)
      {
        control.Unpin((AbstractContainerControl) control);
        control.Show();
      }
      else
      {
        this.checkForBackBranch((Control) control);
        this.DisplayComponent(entity, (Control) control);
      }
    }

    private void MainContainer_Closing(object sender, CancelEventArgs e)
    {
      DynamicHelp.Save();
      this.maintainCache.SaveUserOptionsCache();
    }

    private void replaceNavigationImages()
    {
      ImageList imageList1 = StandardIcons.Get(StandardIcons.IconSizes.Size24);
      ImageList imageList2 = new ImageList();
      imageList2.ColorDepth = ColorDepth.Depth32Bit;
      imageList2.ImageSize = new Size(24, 24);
      imageList2.Images.Add(imageList1.Images[15]);
      imageList2.Images.Add(imageList1.Images[16]);
      imageList2.Images.Add(this.imageListNavigation.Images[2]);
      imageList2.Images.Add(this.imageListNavigation.Images[3]);
      this.imageListNavigation.Images.Clear();
      this.imageListNavigation.Images.Add(imageList2.Images[0]);
      this.imageListNavigation.Images.Add(imageList2.Images[1]);
      this.imageListNavigation.Images.Add(imageList2.Images[2]);
      this.imageListNavigation.Images.Add(imageList2.Images[3]);
      this.commandBarButtonItemBack.Image = imageList1.Images[15];
      this.commandBarButtonItemForward.Image = imageList1.Images[16];
    }

    private void MainContainer_Load(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Maximized;
      this.load();
      this.endUpdate();
      this.Visible = true;
      if (this.closeSplashScreen != null)
        this.closeSplashScreen();
      if (!(SIMS.Entities.Cache.MigrationStarted == "True"))
        return;
      int num = (int) MessageBox.Show(SIMS.Entities.Cache.StartUpMessageAsFollowingConversion, SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void load()
    {
      bool flag = false;
      this.replaceNavigationImages();
      if (SIMS.Entities.Cache.ConfigurationRequired)
      {
        int num = (int) MessageBox.Show("You must run the configuration utility\nbefore you can use this application", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.Close();
      }
      else
        this.WindowState = FormWindowState.Maximized;
      this.initialiseTeachersDesktop();
      if (SIMS.Entities.Cache.ProcessAvailable("ResourcesAutoUpdate"))
        SIMS.Processes.PerformanceCache.eventobj += new ImportAMPARKDelegate(this.InitiateAMPARKImport);
      if (Shortcuts.SIMSExternalApplications != null)
      {
        foreach (SIMS.Entities.ExternalApplication externalApplication in (CollectionBase) Shortcuts.SIMSExternalApplications)
        {
          if (!string.IsNullOrEmpty(externalApplication.Description))
          {
            UIMenuItem uiMenuItem = new UIMenuItem();
            uiMenuItem.ImageIndex = -1;
            uiMenuItem.ImageList = (ImageList) null;
            uiMenuItem.NoEdit = false;
            uiMenuItem.NoUIModify = false;
            uiMenuItem.OriginalText = "";
            uiMenuItem.OwnerDraw = true;
            uiMenuItem.Tag = (object) externalApplication;
            uiMenuItem.Text = externalApplication.Description;
            uiMenuItem.Click += new EventHandler(this.menuItemSIMSExtApps_Click);
            if (uiMenuItem.Text == "System")
            {
              this.addToSystemManagerMenu((MenuItem) uiMenuItem);
            }
            else
            {
              this.focusMenu.MenuItems.Add((MenuItem) uiMenuItem);
              if (uiMenuItem.Text == "Examinations")
                flag = true;
            }
          }
        }
        if (!flag)
          SIMS.UserInterfaces.Exams.MainContainerHelper.SetExamsMenuVisibility(SIMS.Entities.Cache.ProcessAvailable("Exams.ManagePIBrowser"));
      }
      this.focusMenu.MenuItems.Add((MenuItem) this.MenuItemExit);
      this.panelOptions.Width = UserOptionsCache.UserOptions.LauncherWidth;
      this.isLoaded = true;
    }

    private void addToSystemManagerMenu(MenuItem sm6)
    {
      foreach (MenuItem menuItem in this.focusMenu.MenuItems)
      {
        if (menuItem.Text.Replace("&", "") == "System Manager")
        {
          menuItem.MenuItems.Add((MenuItem) new UIMenuItem()
          {
            Text = "-"
          });
          sm6.Text = "System Manager &6";
          menuItem.MenuItems.Add(sm6);
          break;
        }
      }
    }

    private void buildFocusBar()
    {
      this.panelMain.BackColor = SystemColors.Window;
      this.commandBarNavigation.CustomBackground = true;
      this.launcher.FocusBar = this.commandBarNavigation;
      this.launcher.SetFocusBarImageSize(StandardIcons.IconSizes.Size24);
      this.commandBarItemShowLauncher.Image = this.launcher.FocusBarImageList.Images[96];
      this.MenuItemStudentEdit.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemEmployeeDetails.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.MenuItemCalendar.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemStudBehaviour.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItem4.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.MenuItemEditAgent.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.MenuItemDesignReport.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.MenuItemRunReport.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemMarksheet.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemTPPGridEntry.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemCommentEntry.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemStudentSEN.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemTakeRegister.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemSynchronize.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemIntervRunIntervention.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemSimsParent.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.MenuItemStudentEdit.ImageIndex = 73;
      this.menuItemTeachersView.ImageIndex = 73;
      this.menuItemEmployeeDetails.ImageIndex = 74;
      this.MenuItemCalendar.ImageIndex = 91;
      this.menuItemStudBehaviour.ImageIndex = 80;
      this.menuItem4.ImageIndex = 82;
      this.MenuItemEditAgent.ImageIndex = 79;
      this.MenuItemDesignReport.ImageIndex = 88;
      this.menuItemMarksheet.ImageIndex = 87;
      this.menuItemTPPGridEntry.ImageIndex = 167;
      this.menuItemCommentEntry.ImageIndex = 86;
      this.menuItemStudentSEN.ImageIndex = 92;
      this.menuItemTakeRegister.ImageIndex = 94;
      this.menuItemSynchronize.ImageIndex = 93;
      this.menuItemIntervRunIntervention.ImageIndex = 168;
      this.menuItemSimsParent.ImageIndex = 169;
      if (!SIMS.Entities.Cache.Settings.ContainsKey("TeacherViewDefaultScreen") ? SIMS.Entities.Cache.Settings.ContainsKey("TeacherViewTeachingStaff") && SIMS.Entities.Cache.Settings["TeacherViewTeachingStaff"] == "T" && SIMS.Entities.Cache.ProcessAvailable("TeachersView") : SIMS.Entities.Cache.Settings["TeacherViewDefaultScreen"] == "1" && SIMS.Entities.Cache.ProcessAvailable("TeachersView"))
        this.launcher.AddFocusBarItem(this.menuItemTeachersView);
      else
        this.launcher.AddFocusBarItem(this.MenuItemStudentEdit);
      this.launcher.AddFocusBarItem(this.menuItemEmployeeDetails);
      this.launcher.AddFocusBarSeparator();
      this.launcher.AddFocusBarItem(this.MenuItemCalendar);
      this.launcher.AddFocusBarItem(this.menuItemStudBehaviour);
      this.launcher.AddFocusBarItem(this.menuItem4);
      this.launcher.AddFocusBarItem(this.MenuItemEditAgent);
      this.launcher.AddFocusBarSeparator();
      this.launcher.AddFocusBarItem(this.MenuItemDesignReport);
      this.launcher.AddFocusBarItem(this.MenuItemRunReport);
      this.launcher.AddFocusBarItem(this.menuItemMarksheet);
      this.launcher.AddFocusBarItem(this.menuItemCommentEntry);
      this.launcher.AddFocusBarItem(this.menuItemStudentSEN);
      this.launcher.AddFocusBarItem(this.menuItemIntervRunIntervention);
      this.launcher.AddFocusBarItem(this.menuItemTakeRegister);
      this.buildAdmissionFocusBar();
      this.buildFeesFocusBar();
      if (this.menuItemSynchronize.Visible)
        this.launcher.AddFocusBarItem(this.menuItemSynchronize);
      this.buildApplicationTitle();
      this.panelOptions.Width = UserOptionsCache.UserOptions.LauncherWidth;
      this.launcher.SetFocusBarVisibility(UserOptionsCache.UserOptions.DisplayFocusBar);
      this.MenuItemSchoolOrganiser.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.MenuItemSchoolOrganiser.ImageIndex = 90;
      ImageList imageList = StandardIcons.Get();
      this.menuItemCLPStudyTopics.ImageList = imageList;
      this.menuItemCLPStudyTopics.ImageIndex = 99;
      this.menuItemCLPSchoolPlans.ImageList = imageList;
      this.menuItemCLPSchoolPlans.ImageIndex = 98;
      this.menuItemCLPLessonPlans.ImageList = imageList;
      this.menuItemCLPLessonPlans.ImageIndex = 97;
      this.launcher.AddFocusBarSeparator();
      this.launcher.AddFocusBarItem(this.menuItemCLPStudyTopics);
      this.launcher.AddFocusBarItem(this.menuItemCLPSchoolPlans);
      this.launcher.AddFocusBarItem(this.menuItemCLPLessonPlans);
      if (SIMS.Entities.InTouch.Cache.IsLicensed || SIMS.Entities.InTouch.Cache.UseEmergencyAlert)
      {
        this.launcher.AddFocusBarSeparator();
        if (SIMS.Entities.InTouch.Cache.IsLicensed)
        {
          SIMS.UserInterfaces.InTouch.MainContainerHelper.MenuItemInTouchSendMessage.ImageList = imageList;
          SIMS.UserInterfaces.InTouch.MainContainerHelper.MenuItemInTouchSendMessage.ImageIndex = 150;
          this.launcher.AddFocusBarItem(SIMS.UserInterfaces.InTouch.MainContainerHelper.MenuItemInTouchSendMessage);
          this.menuItemIntouchUnexplainedAbsence.ImageList = imageList;
          this.menuItemIntouchUnexplainedAbsence.ImageIndex = 151;
          this.launcher.AddFocusBarItem(this.menuItemIntouchUnexplainedAbsence);
        }
        if (SIMS.Entities.InTouch.Cache.UseEmergencyAlert)
        {
          this.menuItemSendEmergencyAlert.ImageList = imageList;
          this.menuItemSendEmergencyAlert.ImageIndex = 149;
          this.launcher.AddFocusBarItem(this.menuItemSendEmergencyAlert, this.commandBarRight);
        }
      }
      SIMS.UserInterfaces.Discover.MainContainerHelper.BuildFocusBar(this.launcher);
      this.launcher.AddFocusBarItem(this.menuItemTPPGridEntry);
      this.launcher.AddFocusBarItem(this.menuItemSimsParent);
    }

    private void buildApplicationTitle()
    {
      if (SystemConfigurationCache.IsIndependentSchool)
        this.Text += ": Independent School Edition";
      if (SIMS.Entities.Cache.CurrentSchool != null)
      {
        MainContainer mainContainer = this;
        mainContainer.Text = mainContainer.Text + ": " + SIMS.Entities.Cache.CurrentSchool.SchoolName;
      }
      switch (SystemConfigurationCache.ExtendedRegionCode.ToUpper())
      {
        case "IND":
          this.Text = "SIMS .net: India: " + SIMS.Entities.Cache.CurrentSchool.SchoolName;
          break;
      }
      this.Text += this.AddMessage();
    }

    private void MenuItemCheckForUpdate_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      SIMS.Entities.Cache.StatusMessage("Starting version checker...", UserMessageEventEnum.Information);
      this.closingForApplicationUpdate = true;
      this.Close();
    }

    private void menuItemToolsOptions_Click(object sender, EventArgs e)
    {
      SIMS.Entities.ExternalApplication externalApplication = new SIMS.Entities.ExternalApplication();
      externalApplication.Description = "Options";
      string simsNetApplications = UserOptionsCache.UserOptions.PathToSIMSNetApplications;
      externalApplication.Target = Path.Combine(simsNetApplications, "OptionsW.EXE");
      externalApplication.SIMSApplication = true;
      externalApplication.ToolTip = "Options";
      new DisplayExternalApplications().Launch(externalApplication);
    }

    private void MainContainer_Closed(object sender, EventArgs e)
    {
      this.tempFiles = LocalFileSystem.SecureTempFiles();
      this.tempFiles.Delete();
      if (!this.closingForApplicationUpdate)
        return;
      ProcessStartInfo startInfo = new ProcessStartInfo();
      startInfo.FileName = MainContainer.simsUpdatingProgramFileName;
      startInfo.WorkingDirectory = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
      startInfo.Arguments = "";
      try
      {
        Process.Start(startInfo);
      }
      catch
      {
        int num = (int) MessageBox.Show(string.Format("There was a problem starting {0}.\nPlease check that the file is present and try again.", (object) startInfo.FileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void MainContainer_MenuStart(object sender, EventArgs args)
    {
      this.statusBarMenuItemHelpDescriptions = true;
      if (this.statusBarPanelIconIcon == null)
      {
        this.statusBarPanelIconIcon = this.statusBarPanelIcon.Icon;
        this.statusBarPanelIcon.Icon = (System.Drawing.Icon) null;
      }
      if (this.statusBarPanelMessageText != null)
        return;
      this.statusBarPanelMessageText = this.statusBarPanelMessage.Text + this.AddMessage();
      this.statusBarPanelMessage.Text = this.AddMessage() ?? "";
    }

    private void MainContainer_MenuComplete(object sender, EventArgs args)
    {
      if (this.statusBarPanelIcon.Icon != null)
        this.statusBarPanelIcon.Icon.Dispose();
      this.statusBarPanelIcon.Icon = this.statusBarPanelIconIcon;
      this.statusBarPanelIconIcon = (System.Drawing.Icon) null;
      this.statusBarPanelMessage.Text = this.statusBarPanelMessageText + this.AddMessage();
      this.statusBarPanelMessageText = this.AddMessage() ?? "";
      this.statusBarMenuItemHelpDescriptions = false;
    }

    private void MainContainer_MenuItemSelect(object sender, EventArgs args)
    {
      UIMenuItem uiMenuItem = sender as UIMenuItem;
      if (uiMenuItem == null || uiMenuItem.GetMainMenu() != this.mainMenu)
        return;
      this.statusBarPanelMessage.Text = uiMenuItem.HelpDescription + this.AddMessage();
    }

    private void RebuildIntouchMenus()
    {
      this.menuItemIntouchUnexplainedAbsence = new UIMenuItem();
      this.menuItemAttendance.MenuItems.Add(this.menuItemUnexplainedAbsences.Index + 1, (MenuItem) this.menuItemIntouchUnexplainedAbsence);
      this.menuItemIntouchUnexplainedAbsence.ImageIndex = -1;
      this.menuItemIntouchUnexplainedAbsence.ImageList = (ImageList) null;
      this.menuItemIntouchUnexplainedAbsence.NoEdit = false;
      this.menuItemIntouchUnexplainedAbsence.NoUIModify = false;
      this.menuItemIntouchUnexplainedAbsence.OriginalText = "";
      this.menuItemIntouchUnexplainedAbsence.OwnerDraw = true;
      this.menuItemIntouchUnexplainedAbsence.Text = "Deal with Unexplained Absences (InTouch)";
      this.menuItemIntouchUnexplainedAbsence.Click += new EventHandler(SIMS.UserInterfaces.InTouch.MainContainerHelper.menuItemUnexplainedAbsence_Click);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemIntouchUnexplainedAbsence, "InTouch.SendUnexplainedAbsenceMessageHost");
      UIMenuItem unexplainedAbsence = this.menuItemIntouchUnexplainedAbsence;
      unexplainedAbsence.Visible = ((unexplainedAbsence.Visible ? 1 : 0) & (!this.menuItemIntouchUnexplainedAbsence.Visible ? 0 : (SIMS.Entities.InTouch.Cache.IsLicensed ? 1 : 0))) != 0;
      this.menuItemIntouchPercentageAttendanceNotification = new UIMenuItem();
      this.menuItemAttendance.MenuItems.Add(this.menuItemAttendance.MenuItems.Count, (MenuItem) this.menuItemIntouchPercentageAttendanceNotification);
      this.menuItemIntouchPercentageAttendanceNotification.NoEdit = false;
      this.menuItemIntouchPercentageAttendanceNotification.NoUIModify = false;
      this.menuItemIntouchPercentageAttendanceNotification.OwnerDraw = true;
      this.menuItemIntouchPercentageAttendanceNotification.Text = "Send Percentage Attendance Notifications";
      this.menuItemIntouchPercentageAttendanceNotification.OriginalText = "Send Percentage Attendance Notifications";
      this.menuItemIntouchPercentageAttendanceNotification.Click += new EventHandler(SIMS.UserInterfaces.InTouch.MainContainerHelper.menuItemIntouchPercentageAttendanceNotification_Click);
      this.menuItemAttendance.MenuItems.Add(this.menuItemAttendance.MenuItems.Count, (MenuItem) this.menuItemIntouchPercentageAttendanceNotification);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemIntouchPercentageAttendanceNotification, "InTouch.SendPercentageAttendanceMessageHost");
      UIMenuItem attendanceNotification = this.menuItemIntouchPercentageAttendanceNotification;
      attendanceNotification.Visible = ((attendanceNotification.Visible ? 1 : 0) & (!this.menuItemIntouchPercentageAttendanceNotification.Visible ? 0 : (SIMS.Entities.InTouch.Cache.IsLicensed ? 1 : 0))) != 0;
      this.menuItemLateNotification = new UIMenuItem();
      this.menuItemAttendance.MenuItems.Add(this.menuItemAttendance.MenuItems.Count, (MenuItem) this.menuItemLateNotification);
      this.menuItemLateNotification.NoEdit = false;
      this.menuItemLateNotification.NoUIModify = false;
      this.menuItemLateNotification.OwnerDraw = true;
      this.menuItemLateNotification.Text = "Send &Late Notifications";
      this.menuItemLateNotification.OriginalText = "Send &Late Notifications";
      this.menuItemLateNotification.Click += new EventHandler(SIMS.UserInterfaces.InTouch.MainContainerHelper.menuItemLateNotification_Click);
      this.menuItemAttendance.MenuItems.Add(this.menuItemAttendance.MenuItems.Count, (MenuItem) this.menuItemLateNotification);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemLateNotification, "InTouch.SendLateNotificationMessageHost");
      UIMenuItem lateNotification = this.menuItemLateNotification;
      lateNotification.Visible = ((lateNotification.Visible ? 1 : 0) & (!this.menuItemLateNotification.Visible ? 0 : (SIMS.Entities.InTouch.Cache.IsLicensed ? 1 : 0))) != 0;
    }

    public void RebuildMenu()
    {
      this.rebuildRAMenus();
      this.rebuildPlascMenus();
      this.rebuildSchoolCensusMenus();
      this.rebuildCESEWMenus();
      this.rebuildELWAMenus();
      this.rebuildCTFMenus();
      this.rebuildAcademicMenus();
      this.rebuildB2BMenus();
      this.rebuildDENIMenus();
      this.rebuildEMAMenus();
      this.rebuildTeachersDesktopMenus();
      this.rebuildSystemDiagMenus();
      this.rebuildNDCMenus();
      this.rebuildIndependentMenus();
      this.rebuildPerformanceMenus();
      SIMS.UserInterfaces.Exams.MainContainerHelper.RebuildMenu();
      this.rebuildVLEMenus();
      this.rebuildBehaviourMenus();
      this.rebuildInterventionsMenus();
      this.rebuildHousekeepingMenus();
      this.rebuildAttendanceMenus();
      this.rebuildPersonnelMenus();
      this.rebuildCLPMenus();
      this.rebuildAlertsMenu();
      this.rebuildSLGMenus();
      this.rebuildFeesMenus();
      this.rebuildExportMenus();
      this.rebuildADPMenus();
      this.rebuildSLGReportsMenus();
      this.rebuildCoverMenus();
      this.rebuildTeachersViewMenus();
      this.rebuildStudentAnalysisMenus();
      this.rebuildCurriculumReportMenus();
      this.rebuildTTPrintingMenus();
      SIMS.UserInterfaces.DinnerMoney.MainContainerHelper.RebuildMenus();
      SIMS.UserInterfaces.Discover.MainContainerHelper.RebuildMenus();
      this.rebuildDMSMenus();
      this.rebuildPartnershipMenus();
      this.rebuildSipaAgentMenus();
      this.rebuildHomePageMenus();
      this.rebuildNurseryHoursMenus();
      SIMS.UserInterfaces.InTouch.MainContainerHelper.RebuildMenus();
      this.RebuildIntouchMenus();
      SIMS.UserInterfaces.SystemManager.MainContainerHelper.RebuildMenus();
      SIMS.UserInterfaces.ThirdParty.MainContainerHelper.RebuildMenus();
      this.rebuildAdmissionReportMenus();
      this.rebuildHomeworkMenus();
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemRecruitmentAgencyExport, new string[2]
      {
        "RecruitmentAgencyTransfer",
        "AlphaPlusRecruitmentExport"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemRecruitmentAgencyImport, new string[2]
      {
        "RecruitmentAgencyTransfer",
        "AlphaPlusRecruitmentImport"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMaintainMedicalEvent, new string[2]
      {
        "LookupEventTypeBrowser",
        "LookupEventTypeDetail"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemConfigureEthnicCodes, "CTFConfigureEthnicCodes");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUpdateStudentAddressee, "AddStudent");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUpdateParentalAddressee, new string[1]
      {
        "MergeContacts"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUpdateContactAddressee, new string[1]
      {
        "MergeContacts"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSetupAddresseeFormat, "UDFFieldDetail");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemToolUploadDocuments, "DocumentManagement");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemToolMaintainDMS, "MaintainDocumentManagementServer");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMembershipFix, "PrePromotionCheckProcess");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAuthoriseSIMSPrimaryTransfer, "AuthoriseMigrationToSimsPrimary");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.MenuItemEditAgent, new string[2]
      {
        "ViewAgent",
        "BrowseAgent"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.MenuItemEditAgency, new string[2]
      {
        "ViewAgency",
        "BrowseAgency"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.MenuItemStudentEdit, new string[2]
      {
        "StudentBrowseProcess",
        "EditStudentInformation"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.MenuItemStudentHistory, new string[2]
      {
        "StudentBrowseProcess",
        "EditStudentInformationReadOnly"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItem2, "ReportSecurity");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemImportReport, "ImportReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExportReport, "ExportReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.MenuItemRunReport, "RunReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.MenuItemDesignReport, "DesignReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemEmployeeDetails, new string[2]
      {
        "EditEmployee",
        "BrowseEmployee"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItem4, "BrowseContacts");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUserOptions, "MaintainUserOptions");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.MenuItemDocumentServers, "EditDocumentServer");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.MenuItemPhotoImportStudentAdNo, "StudentPhotoProcess");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.MenuItemPhotoImportStudentRgGp, "StudentPhotoProcess");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemHomePage, HomePageDetail.HostedProcessName);
      this.menuItemRooms.Visible = SIMS.Entities.Cache.ProcessVisible("EditRoomDetails") || SIMS.Entities.Cache.ProcessVisible("ViewRoomDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUserOptions, "MaintainUserOptions");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemStudentSEN, new string[2]
      {
        "SENStudentBrowse",
        "ViewSENStudent"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSEN, "ViewSENAdmin");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemStudentBulkUpdate, PersonBulkAssignmentConatiner.HostedProcessName("Student"));
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemLeavers, new string[2]
      {
        "EditLeavingDetails",
        "StudentLeaversBrowse"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExclusions, new string[2]
      {
        "StudentBrowseProcess",
        "ViewExclusionDetails"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemFilesetImport, new string[2]
      {
        "FileDeployer",
        "FilesetImportProcess"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemEmergencyAlertSetup, "InTouch.EmergencyAlertSetupDetail");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSendEmergencyAlert, "InTouch.SendEmergencyAlert");
      this.menuItemSendEmergencyAlert.Visible &= SIMS.Entities.InTouch.Cache.UseEmergencyAlert;
      this.editMenu.Visible = false;
      this.MenuItemUndo.Visible = false;
      this.MenuItemCut.Visible = false;
      this.MenuItemCopy.Visible = false;
      this.MenuItemPaste.Visible = false;
      this.MenuItemDelete.Visible = false;
      this.MenuItemSelectAll.Visible = false;
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemConnexionsCard, "ConnexionsSetup");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCCardholderDetails, "UpdateCardholderDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCCardholderDownload, "DownloadCardholderDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCCardAttSummaryExport, "AttendanceSummaryExport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCCardRequestResponseFile, "AttendanceSummaryExport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCCardSchemeMembersReport, "ReportFormatter");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCCardAttSummaryExportReport, "ReportFormatter");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMaintainLookup, new string[2]
      {
        "LookupTypeBrowser",
        "LookupTypeDetail"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUDFSetup, new string[2]
      {
        "UDFFieldBrowser",
        "UDFFieldDetail"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemImoprtFromEMS, "ImportFromEMS");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExportToEMS, "Export ToEMS");
      this.menuItemConfigurePastoralGroups.Visible = SIMS.Entities.Cache.ProcessVisible("ViewPastoralSetup") || SIMS.Entities.Cache.ProcessVisible("EditPastoralSetup");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSchoolPromotion, "MaintainPromotionMapping");
      this.menuItemDeleteStudent.Visible = SIMS.Entities.Cache.ProcessVisible("DeletePersonRole");
      this.MenuItemCurrentPastoralStructure.Visible = SIMS.Entities.Cache.ProcessVisible("ViewPastoralStructure") || SIMS.Entities.Cache.ProcessVisible("EditPastoralStructure");
      this.MenuItemNextAcademicYearPastoralStructure.Visible = SIMS.Entities.Cache.ProcessVisible("ViewPastoralStructure") || SIMS.Entities.Cache.ProcessVisible("EditPastoralStructure");
      this.MenuItemCalendar.Visible = SIMS.Entities.Cache.ProcessVisible("ViewCalendar") || SIMS.Entities.Cache.ProcessVisible("EditCalendar");
      this.MenuItemSchoolOrganiser.Visible = SIMS.Entities.Cache.ProcessVisible("ViewHomeSchool") || SIMS.Entities.Cache.ProcessVisible("EditHomeSchool");
      this.menuItemExternalSchools.Visible = SIMS.Entities.Cache.ProcessVisible("ViewHomeSchool") || SIMS.Entities.Cache.ProcessVisible("EditHomeSchool");
      this.menuItemConcessionSetup.Visible = SIMS.Entities.Cache.ProcessVisible("ViewConcessionDetails") || SIMS.Entities.Cache.ProcessVisible("EditConcessionDetails");
      this.menuItemStudentConcessions.Visible = SIMS.Entities.Cache.ProcessVisible("ViewStudentConcessions") || SIMS.Entities.Cache.ProcessVisible("EditStudentConcessions");
      this.menuItemChangeEnrolmentStatus.Visible = SIMS.Entities.Cache.ProcessVisible("BrowseEnrolmentStatus") && SIMS.Entities.Cache.ProcessVisible("ChangeEnrolmentStatus");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAcademicYear, "CreateAcademicYear");
      if (this.menuItemAcademicYear.Visible)
      {
        ProcessPermission processPermission = SIMS.Entities.Cache.ProcessPermissions.Item("CreateAcademicYear");
        if (processPermission == null || processPermission.ReadOnly)
          this.menuItemAcademicYear.Enabled = false;
      }
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemEditAcademicYear, "EditAcademicYear");
      if (this.menuItemEditAcademicYear.Visible)
      {
        ProcessPermission processPermission = SIMS.Entities.Cache.ProcessPermissions.Item("EditAcademicYear");
        if (processPermission == null || processPermission.ReadOnly)
          this.menuItemEditAcademicYear.Enabled = false;
      }
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemDeleteAcademicYear, "DeleteAcademicYear");
      if (this.menuItemDeleteAcademicYear.Visible)
      {
        ProcessPermission processPermission = SIMS.Entities.Cache.ProcessPermissions.Item("DeleteAcademicYear");
        if (processPermission == null || processPermission.ReadOnly)
          this.menuItemDeleteAcademicYear.Enabled = false;
      }
      this.menuItemSchoolDetailsChange.Visible = SIMS.Entities.Cache.ProcessVisible("EditSchoolDetails") && !SIMS.Entities.Cache.ProcessVisible("PXChangeRun");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExportLookups, "ExportLookups");
      this.MenuItemMaintainSIMSServices.Visible = SIMS.Entities.Cache.ProcessVisible("AdminSIMSServices") || SIMS.Entities.Cache.ProcessVisible("ViewSIMSServices");
      string[] strArray = new string[2]
      {
        "ViewOwnUDGroup",
        "ViewUDGroup"
      };
      this.menuItemUserDefinedGroups.Visible = false;
      foreach (string processName in strArray)
        this.menuItemUserDefinedGroups.Visible = this.menuItemUserDefinedGroups.Visible || SIMS.Entities.Cache.ProcessVisible(processName);
      string[] processNames = new string[1]
      {
        "PupilPremiumEdit"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPupilPremium, processNames);
      if (this.menuItemPupilPremiumImport != null)
      {
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPupilPremiumImport, processNames);
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPupilPremiumMaintain, processNames);
      }
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExamsA2CCommunications, new string[2]
      {
        "A2CConnectionProcess",
        "A2CTransport"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExamsA2CLoadProductCatalogue, new string[1]
      {
        "A2CConnectionProcess"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExamsA2CLoadResults, new string[1]
      {
        "A2CConnectionProcess"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExamsA2CSettings, new string[1]
      {
        "A2CSettingsProcess"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExamsA2CViewProductCatalogue, new string[2]
      {
        "A2CViewProductCatalogue",
        "A2CAOBrowseProcess"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExamsA2CSubmitOrders, new string[3]
      {
        "A2CConnectionProcess",
        "A2CSeriesBrowseProcess",
        "A2CSubmitEntriesProcess"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExamsA2CSubmitCoursework, new string[3]
      {
        "A2CConnectionProcess",
        "A2CSeriesBrowseProcess",
        "A2CSubmitCourseworkProcess"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExamsA2CAmendLearnerDetails, new string[1]
      {
        "A2CAmendLearnerDetailsProcess"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExamsA2CSummary, new string[1]
      {
        "A2CSummaryProcess"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSchoolOptions, new string[1]
      {
        "MaintainSchoolOptions"
      });
      SIMS.UserInterfaces.Utilities.RollupInvisibleMenus(this.mainMenu);
    }

    private void menuItemAuthorizeSIMSPrimaryTransfer_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgAuthorisingToSIMSPrimaryDataTransfer primaryDataTransfer = new DlgAuthorisingToSIMSPrimaryDataTransfer())
      {
        int num = (int) primaryDataTransfer.Display();
      }
    }

    private void menuItemMemberhipFix_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      PromotionPrecheckForm promotionPrecheckForm = new PromotionPrecheckForm();
      try
      {
        promotionPrecheckForm.Owner = (System.Windows.Forms.Form) this;
        if (!promotionPrecheckForm.RunVM())
          return;
        promotionPrecheckForm.Show();
        this.Enabled = false;
        promotionPrecheckForm.RunCheck();
      }
      finally
      {
        promotionPrecheckForm.Owner = (System.Windows.Forms.Form) null;
        promotionPrecheckForm.Dispose();
        this.Enabled = true;
      }
    }

    private void menuItemHomePage_Click(object sender, EventArgs e)
    {
      bool forceRestart = true;
      this.recordMenuUsage(sender as UIMenuItem);
      if (this.homepage == null)
      {
        this.homepage = new HomePageDetail();
        this.homepage.HPLaunchFavourite = new HomePageDetail.HPLaunchFavouriteDelegate(this.launchFavourite);
        this.homepage.homepage_InTouchMessages += new EventHandler(this.homepage_InTouchMessages_Click);
        this.homepage.LaunchSchoolDiary += new EventHandler(this.MenuItemCalendar_Click);
        this.homepage.HPSetAcademicYear += new HomePageDetail.HPSetAcademicYearDelegate(this.homePageSetAcademicYear_Click);
      }
      else
        forceRestart = !this.homepage.Visible;
      this.DisplayNewComponent((Control) this.homepage);
      this.homepage.RefreshActivePanels(forceRestart);
    }

    private void homepage_InTouchMessages_Click(object sender, EventArgs e)
    {
      if (!(sender is MyMessagesWidget))
        return;
      SIMS.UserInterfaces.InTouch.MainContainerHelper.menuItemInTouchShowMessagesClick((object) this, EventArgs.Empty);
    }

    private void menuItemImportReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!DisplayReports.CheckDocumentServer())
        return;
      int num = (int) new ReportImport().ShowDialog();
      Component component = (Component) this.ComponentExists("SIMS.UserInterfaces.ReportController", "Run Report");
      if (component == null)
        return;
      component.Dispose();
      this.DisplayNewComponent((Control) new ReportController(EReportOpMode.Run));
    }

    private void menuItemExportReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!DisplayReports.CheckDocumentServer())
        return;
      ReportBrowseDlg reportBrowseDlg = new ReportBrowseDlg("Select reports to export", false);
      if (reportBrowseDlg.ShowDialog() != DialogResult.OK)
        return;
      int num = (int) new ReportExport(reportBrowseDlg.SelectedReportSummaries).ShowDialog();
    }

    private void menuItemFullSchoolReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new DlgReportDialog().ShowDialog();
    }

    private void menuItemPersonDataOutput_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PersonDataOutputLog());
    }

    private void menuItemExportLookups_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ExportLookupsUI());
    }

    private void MenuItemSecurity_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new EMSSecurityDlg().ShowDialog();
    }

    private void loadBackgroundImage()
    {
      if (!File.Exists(UserOptionsCache.UserOptions.BackgroundImageFile))
        return;
      try
      {
        this.pictureBoxLogo.Image = (Image) new Bitmap(UserOptionsCache.UserOptions.BackgroundImageFile);
      }
      catch
      {
        SIMS.Entities.Cache.StatusMessage("Background image file " + UserOptionsCache.UserOptions.BackgroundImageFile + " could not be loaded.", UserMessageEventEnum.Information);
      }
    }

    private void menuItemUDFFieldDetails_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainUDFFieldInformation());
    }

    private void menuItemConfigurePastoralGroups_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SupervisorRoleSetup());
    }

    private void menuItemFilesetImport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FilesetImport());
    }

    private void menuItemConcessionSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ConcessionSetupContainer());
    }

    private void menuItemStudentConcessions_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ConcessionContainer());
    }

    private void menuItemUpdateParentalAddressee_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainStudentSalutationAddresseeDetails());
    }

    private void menuItemUpdateContactAddressee_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainContactSalutationAddresseeDetails());
    }

    private void menuItemStudentDelete_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new DeletePersonRole());
    }

    private void menuItemSetupAddresseeFormat_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new DlgStudentAdresseeFormatsetup().ShowDialog();
    }

    private void menuItemConfigureEthnicCodes_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CTFConfigureEthnicCodes());
    }

    private void MenuItemStudentHistory_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExistsLike("SIMS.UserInterfaces.MaintainStudentInformation", SIMS.Entities.Cache.UserInterfaceLabel("Student History")) != null)
        return;
      this.DisplayNewComponent((Control) new MaintainStudentInformation(true));
    }

    private void hookTitleChangedEvent(Control component)
    {
      BasicDetailControl basicDetailControl1 = component as BasicDetailControl;
      if (basicDetailControl1 != null)
      {
        basicDetailControl1.TitleChanged -= new EventHandler(this.hostedComponent_TitleChanged);
        basicDetailControl1.TitleChanged += new EventHandler(this.hostedComponent_TitleChanged);
      }
      else
      {
        foreach (Control control in (ArrangedElementCollection) component.Controls)
        {
          BasicDetailControl basicDetailControl2 = control as BasicDetailControl;
          if (basicDetailControl2 != null)
          {
            basicDetailControl2.TitleChanged -= new EventHandler(this.hostedComponent_TitleChanged);
            basicDetailControl2.TitleChanged += new EventHandler(this.hostedComponent_TitleChanged);
          }
        }
      }
    }

    private void hostedComponent_TitleChanged(object sender, EventArgs e)
    {
      this.reconfigureNavigation();
      this.buildDynamicWindowMenu();
    }

    private Control focusedControl()
    {
      if (this.activeComponent < this.panelMain.Controls.Count && this.activeComponent >= 0)
        return this.panelMain.Controls[this.activeComponent];
      return (Control) null;
    }

    private void reconfigureNavigation()
    {
      this.commandBarButtonItemBack.Items.Clear();
      this.commandBarButtonItemForward.Items.Clear();
      Control control1 = this.focusedControl();
      bool flag = true;
      CommandBarItemCollection barItemCollection = new CommandBarItemCollection();
      for (int index = 0; index <= this.NavigationZOrder.Count - 1; ++index)
      {
        Control control2 = (Control) this.NavigationZOrder[index];
        HomePageDetail homePageDetail = control2 as HomePageDetail;
        if (control2 == control1)
        {
          if (homePageDetail != null)
            homePageDetail.VisibleToUser = true;
          flag = false;
        }
        else if (this.NavigationZOrder.Count > 0)
        {
          if (homePageDetail != null)
            homePageDetail.VisibleToUser = false;
          CommandBarButtonItem commandBarButtonItem = new CommandBarButtonItem(control2.Text);
          commandBarButtonItem.Tag = (object) control2;
          commandBarButtonItem.Click += new EventHandler(this.contextMenuNavigation_Click);
          if (flag)
            barItemCollection.Add((CommandBarItem) commandBarButtonItem);
          else
            this.commandBarButtonItemForward.Items.Add((CommandBarItem) commandBarButtonItem);
        }
      }
      if (barItemCollection.Count > 0)
      {
        for (int index = barItemCollection.Count - 1; index >= 0; --index)
        {
          if (barItemCollection[index].Text.Length > 0)
            this.commandBarButtonItemBack.Items.Add(barItemCollection[index]);
        }
      }
      this.commandBarButtonItemBack.Enabled = this.commandBarButtonItemBack.Items.Count > 0;
      this.commandBarButtonItemForward.Enabled = this.commandBarButtonItemForward.Items.Count > 0;
      if (this.commandBarButtonItemBack.Items.Count > 0 && this.commandBarButtonItemBack.Items[0] is CommandBarButtonItem)
        ((CommandBarButtonItem) this.commandBarButtonItemBack.Items[0]).DefaultItem = true;
      if (this.commandBarButtonItemForward.Items.Count <= 0 || !(this.commandBarButtonItemForward.Items[0] is CommandBarButtonItem))
        return;
      ((CommandBarButtonItem) this.commandBarButtonItemForward.Items[0]).DefaultItem = true;
    }

    private void contextMenuNavigation_Click(object sender, EventArgs args)
    {
      this.activateItem((Control) ((CommandBarItem) sender).Tag);
    }

    private void commandBarButtonItemForward_Click(object sender, EventArgs e)
    {
      if (this.commandBarButtonItemForward.Items.Count <= 0)
        return;
      Control component = (Control) null;
      int num = 0;
      while ((component == null || component.IsDisposed) && this.commandBarButtonItemForward.Items.Count > num)
        component = this.commandBarButtonItemForward.Items[num++].Tag as Control;
      this.activateItem(component);
    }

    private void commandBarItemShowLauncher_Click(object sender, EventArgs e)
    {
      this.menuItemShowLauncher.PerformClick();
    }

    private void commandBarButtonItemBack_Click(object sender, EventArgs e)
    {
      if (this.commandBarButtonItemBack.Items.Count <= 0)
        return;
      Control component = (Control) null;
      int num = 0;
      while ((component == null || component.IsDisposed) && this.commandBarButtonItemBack.Items.Count > num)
        component = this.commandBarButtonItemBack.Items[num++].Tag as Control;
      this.activateItem(component);
    }

    private void checkForBackBranch(Control newComponentBeingOpened)
    {
      foreach (CommandBarItem commandBarItem in (CollectionBase) this.commandBarButtonItemForward.Items)
        this.NavigationZOrder.Remove((object) (Control) commandBarItem.Tag);
      this.refreshNavigationZOrder(newComponentBeingOpened);
    }

    private void refreshNavigationZOrder(Control newComponentBeingOpened)
    {
      if (!this.NavigationZOrder.Contains((object) newComponentBeingOpened))
        this.NavigationZOrder.Add((object) newComponentBeingOpened);
      foreach (CommandBarItem commandBarItem in (CollectionBase) this.commandBarButtonItemForward.Items)
      {
        Control tag = (Control) commandBarItem.Tag;
        if (!this.NavigationZOrder.Contains((object) tag))
          this.NavigationZOrder.Add((object) tag);
      }
    }

    private void CustomiseMenuItems()
    {
      this.CustomiseSTARMenus();
      this.customiseRAMenus();
      this.customiseCTFMenus();
      this.customiseB2BMenus();
    }

    protected override void OnClosing(CancelEventArgs args)
    {
      base.OnClosing(args);
      if (!args.Cancel && SIMS.Entities.InTouch.Cache.IsLicensed && !SIMS.UserInterfaces.InTouch.MainContainerHelper.CanPulsarClose())
      {
        args.Cancel = true;
      }
      else
      {
        if (!args.Cancel && UserOptionsCache.UserOptions.ConfirmClosingSIMS)
        {
          bool dontAskAgain = !UserOptionsCache.UserOptions.ConfirmClosingSIMS;
          DialogResult dialogResult = SIMSMessageBox.Show((IWin32Window) this, "Are you sure you wish to close SIMS .net?", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, ref dontAskAgain);
          UserOptionsCache.UserOptions.ConfirmClosingSIMS = !dontAskAgain;
          this.maintainCache.SaveUserOptionsCache();
          if (dialogResult == DialogResult.No)
          {
            args.Cancel = true;
            return;
          }
        }
        this.tempFiles = LocalFileSystem.SecureTempFiles();
        this.tempFiles.Delete();
        DocumentManagement.RemoveViewedFiles();
        if (UserOptionsCache.UserOptions.ClearMYSIMSDocumentsOnLogOff)
          DocumentManagement.ClearMYSIMSDocuments();
        this.buildDynamicWindowMenu();
        bool flag = false;
        foreach (UIMenuItem menuItem in this.WindowMenu.MenuItems)
        {
          Control tag = (Control) menuItem.Tag;
          if (tag != null)
          {
            AbstractContainerControl containerControl = tag as AbstractContainerControl;
            if (containerControl != null && !containerControl.QueryCloseContainer())
              flag = true;
          }
        }
        if (!flag)
          flag = this.closeTeachersDesktop();
        args.Cancel = flag;
      }
    }

    private void setMenuIcons()
    {
      ImageList imageList = CheckBoxListViewImages.CreateImageList();
      this.MenuItemCut.ImageList = imageList;
      this.MenuItemCut.ImageIndex = 27;
      this.MenuItemCopy.ImageList = imageList;
      this.MenuItemCopy.ImageIndex = 28;
      this.MenuItemPaste.ImageList = imageList;
      this.MenuItemPaste.ImageIndex = 29;
      this.MenuItemDelete.ImageList = imageList;
      this.MenuItemDelete.ImageIndex = 19;
      this.MenuItemRunReport.ImageList = imageList;
      this.MenuItemRunReport.ImageIndex = 36;
      this.MenuItemExit.ImageList = imageList;
      this.MenuItemExit.ImageIndex = 8;
      this.MenuItemCheckForUpdate.ImageList = imageList;
      this.MenuItemCheckForUpdate.ImageIndex = 21;
      this.setTDMenuIcons();
    }

    private void disableTabStop()
    {
      foreach (Control control in (ArrangedElementCollection) this.panelMain.Controls)
      {
        if (control != this.pictureBoxLogo)
          control.TabStop = false;
      }
    }

    private void MenuItemMaintainSIMSServices_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainSIMSServices());
    }

    private void menuItemStudentBulkUpdate_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PersonBulkAssignmentConatiner("Student"));
    }

    private void menuItemEmergencyAlertSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SIMS.UserInterfaces.InTouch.EmergencyAlertSetupDetail());
    }

    private void menuItemSendEmergencyAlert_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      SIMS.UserInterfaces.InTouch.SendEmergencyAlert.Execute(new SIMS.Processes.InTouch.SendEmergencyAlert.GetTeacherLocationDelegate(this.getTeacherLocation));
    }

    private void menuItemChangeEnrolmentStatus_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ChangeEnrolStatusBrowserDetail());
    }

    private void initExportMenus()
    {
      this.menuItemINCASExport.BaseName = "menuItemINCASExport";
      this.menuItemINCASExport.ImageIndex = -1;
      this.menuItemINCASExport.ImageList = (ImageList) null;
      this.menuItemINCASExport.NoEdit = false;
      this.menuItemINCASExport.NoUIModify = false;
      this.menuItemINCASExport.OriginalText = "";
      this.menuItemINCASExport.OwnerDraw = true;
      this.menuItemINCASExport.Text = "&InCAS";
      this.menuItemINCASExport.Click += new EventHandler(this.menuItemINCASExport_Click);
      this.menuItemCBAExport.BaseName = "menuItemCBAExport";
      this.menuItemCBAExport.ImageIndex = -1;
      this.menuItemCBAExport.ImageList = (ImageList) null;
      this.menuItemCBAExport.NoEdit = false;
      this.menuItemCBAExport.NoUIModify = false;
      this.menuItemCBAExport.OriginalText = "";
      this.menuItemCBAExport.OwnerDraw = true;
      this.menuItemCBAExport.Text = "C&BA";
      this.menuItemCBAExport.Click += new EventHandler(this.menuItemCBAExport_Click);
      this.menuItemRecruitmentAgencyExport.BaseName = "menuItemRecruitmentAgencyExport";
      this.menuItemRecruitmentAgencyExport.ImageIndex = -1;
      this.menuItemRecruitmentAgencyExport.ImageList = (ImageList) null;
      this.menuItemRecruitmentAgencyExport.NoEdit = false;
      this.menuItemRecruitmentAgencyExport.NoUIModify = false;
      this.menuItemRecruitmentAgencyExport.OriginalText = "";
      this.menuItemRecruitmentAgencyExport.OwnerDraw = true;
      this.menuItemRecruitmentAgencyExport.Text = "&Recruitment Agencies";
      this.menuItemRecruitmentAgencyExport.Click += new EventHandler(this.menuItemRecruitmentAgencyExport_Click);
      this.menuItemRecruitmentAgencyImport.BaseName = "menuItemRecruitmentAgencyImport";
      this.menuItemRecruitmentAgencyImport.ImageIndex = -1;
      this.menuItemRecruitmentAgencyImport.ImageList = (ImageList) null;
      this.menuItemRecruitmentAgencyImport.NoEdit = false;
      this.menuItemRecruitmentAgencyImport.NoUIModify = false;
      this.menuItemRecruitmentAgencyImport.OriginalText = "";
      this.menuItemRecruitmentAgencyImport.OwnerDraw = true;
      this.menuItemRecruitmentAgencyImport.Text = "&Recruitment Agencies";
      this.menuItemRecruitmentAgencyImport.Click += new EventHandler(this.menuItemRecruitmentAgencyImport_Click);
    }

    private void rebuildExportMenus()
    {
      this.menuItemCBAExport.Visible = false;
      this.menuItemINCASExport.Visible = false;
      if (SIMS.Entities.Cache.CurrentSchool.Region == "Northern Ireland")
      {
        if (!this.validForCBAExport())
          return;
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCBAExport, "CBAExportProcess");
      }
      else
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemINCASExport, "InCasExportProcess");
    }

    private bool validForCBAExport()
    {
      if (!SIMS.Entities.Cache.CurrentSchool.SchoolPhase.Contains("Secondary"))
        return !SIMS.Entities.Cache.CurrentSchool.SchoolPhase.Contains("Further Education");
      return false;
    }

    private void menuItemCBAExport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (CBAExportWizard cbaExportWizard = new CBAExportWizard())
      {
        int num = (int) cbaExportWizard.ShowDialog();
      }
    }

    private void menuItemINCASExport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (InCASExportWizard inCasExportWizard = new InCASExportWizard())
      {
        int num = (int) inCasExportWizard.ShowDialog();
      }
    }

    private void menuItemRecruitmentAgencyExport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgRecruitmentAgencyExport recruitmentAgencyExport = new DlgRecruitmentAgencyExport())
      {
        int num = (int) recruitmentAgencyExport.ShowDialog();
      }
    }

    private void menuItemRecruitmentAgencyImport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgRecruitmentAgencyImport recruitmentAgencyImport = new DlgRecruitmentAgencyImport())
      {
        int num = (int) recruitmentAgencyImport.ShowDialog();
      }
    }

    private void hideShowLauncher(bool show)
    {
      this.panelOptions.Visible = show && SIMS.Entities.Cache.ProcessVisible("DisplayExternalApplications");
      this.splitterVertical.Visible = this.panelOptions.Visible;
      this.menuItemShowLauncher.Checked = this.panelOptions.Visible;
      this.commandBarItemShowLauncher.Checked = this.panelOptions.Visible;
      this.commandBarItemShowLauncher.Text = this.commandBarItemShowLauncher.Checked ? "Hide Launcher" : "Show Launcher";
      this.launcher.Visible = this.panelOptions.Visible;
    }

    private void configureLauncherhideShow()
    {
      this.launcher.HideLauncher = new HideShowLauncherDelegate(this.hideShowLauncher);
    }

    private void menuItemShowLauncher_Click(object sender, EventArgs e)
    {
      this.hideShowLauncher(!this.menuItemShowLauncher.Checked);
      this.launcher.LauncherVisible(this.menuItemShowLauncher.Checked);
    }

    private void buildHideShowLauncherMenuItem()
    {
      if (!SIMS.Entities.Cache.ProcessAvailable("DisplayExternalApplications"))
        return;
      this.menuItemShowLauncher.Index = 0;
      this.WindowMenu.MenuItems.Add((MenuItem) this.menuItemShowLauncher);
      this.configureLauncherhideShow();
    }

    private void menuItemCCardSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EditConnexionsSetup());
    }

    private void menuItemCCardholderDetails_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CardholderBrowserDetail());
    }

    private void menuItemCCardholderDownload_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (ConnexionsDownLoad connexionsDownLoad = new ConnexionsDownLoad())
      {
        int num = (int) connexionsDownLoad.DisplayWizard();
      }
    }

    private void menuItemCCardAttSummaryExport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (AttendanceSummaryExport attendanceSummaryExport = new AttendanceSummaryExport())
      {
        int num = (int) attendanceSummaryExport.DisplayWizard();
      }
    }

    private void menuItemCCardRequestResponseFile_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (RequestResponse requestResponse = new RequestResponse())
      {
        int num = (int) requestResponse.DisplayWizard();
      }
    }

    private void menuItemCCardAttSummaryExportReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (ConnexionsPrintDialog connexionsPrintDialog = new ConnexionsPrintDialog(this.menuItemCCardAttSummaryExportReport.Text))
      {
        int num = (int) connexionsPrintDialog.DisplayTransmissionReportDialog();
      }
    }

    private void menuItemCCardSchemeMembersReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (ConnexionsPrintDialog connexionsPrintDialog = new ConnexionsPrintDialog(this.menuItemCCardSchemeMembersReport.Text))
      {
        int num = (int) connexionsPrintDialog.DisplayMembersReportDialog();
      }
    }

    private void initRAMenus()
    {
      this.menuItemEnquiry = new UIMenuItem();
      this.menuItemInternalVisit = new UIMenuItem();
      this.menuItemApplication = new UIMenuItem();
      this.menuItemAdmissionGroups = new UIMenuItem();
      this.menuItemSetupAdmissionGroups = new UIMenuItem();
      this.menuItemTransferApplicants = new UIMenuItem();
      this.menuItemFinaliseOffers = new UIMenuItem();
      this.menuItemAcceptApplications = new UIMenuItem();
      this.menuItemAdmitApplications = new UIMenuItem();
      this.menuItemRecordApplicationCriteria = new UIMenuItem();
      this.menuItemASLEntry = new UIMenuItem();
      this.menuItemImportADTFile = new UIMenuItem();
      this.menuItemExportASLFile = new UIMenuItem();
      this.menuItemImportATFFile = new UIMenuItem();
      this.menuItemSetupAdmissionDefaults = new UIMenuItem();
      this.menuItemSetupAdmissionPolicy = new UIMenuItem();
      this.menuItemSetupAdmissionCriterion = new UIMenuItem();
      this.menuItemCommunication.Click += new EventHandler(this.menuItemCommunication_Click);
      this.menuItemAdmissions.MenuItems.AddRange(new MenuItem[11]
      {
        (MenuItem) this.menuItemAdmissionGroups,
        (MenuItem) this.menuItemADMImportEnquiry,
        (MenuItem) this.menuItemADMImportApplication,
        (MenuItem) this.menuItemImportADTFile,
        (MenuItem) this.menuItemRecordApplicationCriteria,
        (MenuItem) this.menuItemASLEntry,
        (MenuItem) this.menuItemFinaliseOffers,
        (MenuItem) this.menuItemExportASLFile,
        (MenuItem) this.menuItemImportATFFile,
        (MenuItem) this.menuItemAcceptApplications,
        (MenuItem) this.menuItemAdmitApplications
      });
      this.menuItemAdmissionGroups.ImageIndex = -1;
      this.menuItemAdmissionGroups.ImageList = (ImageList) null;
      this.menuItemAdmissionGroups.Index = 0;
      this.menuItemAdmissionGroups.NoEdit = false;
      this.menuItemAdmissionGroups.NoUIModify = false;
      this.menuItemAdmissionGroups.OriginalText = "";
      this.menuItemAdmissionGroups.OwnerDraw = true;
      this.menuItemAdmissionGroups.Text = "Admission &Groups";
      this.menuItemAdmissionGroups.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemSetupAdmissionGroups,
        (MenuItem) this.menuItemTransferApplicants
      });
      this.menuItemSetupAdmissionGroups.ImageIndex = -1;
      this.menuItemSetupAdmissionGroups.ImageList = (ImageList) null;
      this.menuItemSetupAdmissionGroups.Index = 0;
      this.menuItemSetupAdmissionGroups.NoEdit = false;
      this.menuItemSetupAdmissionGroups.NoUIModify = false;
      this.menuItemSetupAdmissionGroups.OriginalText = "";
      this.menuItemSetupAdmissionGroups.OwnerDraw = true;
      this.menuItemSetupAdmissionGroups.Text = "&Setup";
      this.menuItemSetupAdmissionGroups.Click += new EventHandler(this.menuItemSetupAdmissionGroups_Click);
      this.menuItemTransferApplicants.ImageIndex = -1;
      this.menuItemTransferApplicants.ImageList = (ImageList) null;
      this.menuItemTransferApplicants.Index = 1;
      this.menuItemTransferApplicants.NoEdit = false;
      this.menuItemTransferApplicants.NoUIModify = false;
      this.menuItemTransferApplicants.OriginalText = "";
      this.menuItemTransferApplicants.OwnerDraw = true;
      this.menuItemTransferApplicants.Text = "&Transfer Applications";
      this.menuItemTransferApplicants.Click += new EventHandler(this.menuItemTransferApplicants_Click);
      this.menuItemADMImportEnquiry.ImageIndex = -1;
      this.menuItemADMImportEnquiry.ImageList = (ImageList) null;
      this.menuItemADMImportEnquiry.Index = 1;
      this.menuItemADMImportEnquiry.NoEdit = false;
      this.menuItemADMImportEnquiry.NoUIModify = false;
      this.menuItemADMImportEnquiry.OriginalText = "";
      this.menuItemADMImportEnquiry.OwnerDraw = true;
      this.menuItemADMImportEnquiry.Text = "Import En&quiries";
      this.menuItemADMImportEnquiry.Click += new EventHandler(this.menuItemADMImportEnquiry_Click);
      this.menuItemADMImportApplication.ImageIndex = -1;
      this.menuItemADMImportApplication.ImageList = (ImageList) null;
      this.menuItemADMImportApplication.Index = 2;
      this.menuItemADMImportApplication.NoEdit = false;
      this.menuItemADMImportApplication.NoUIModify = false;
      this.menuItemADMImportApplication.OriginalText = "";
      this.menuItemADMImportApplication.OwnerDraw = true;
      this.menuItemADMImportApplication.Text = "Import A&pplications";
      this.menuItemADMImportApplication.Click += new EventHandler(this.menuItemADMImportApplication_Click);
      this.menuItemImportADTFile.ImageIndex = -1;
      this.menuItemImportADTFile.ImageList = (ImageList) null;
      this.menuItemImportADTFile.Index = 3;
      this.menuItemImportADTFile.NoEdit = false;
      this.menuItemImportADTFile.NoUIModify = false;
      this.menuItemImportADTFile.OriginalText = "";
      this.menuItemImportADTFile.OwnerDraw = true;
      this.menuItemImportADTFile.Text = "&Import ADT File";
      this.menuItemImportADTFile.Click += new EventHandler(this.menuItemImportADTFile_Click);
      this.menuItemRecordApplicationCriteria.ImageIndex = -1;
      this.menuItemRecordApplicationCriteria.ImageList = (ImageList) null;
      this.menuItemRecordApplicationCriteria.Index = 4;
      this.menuItemRecordApplicationCriteria.NoEdit = false;
      this.menuItemRecordApplicationCriteria.NoUIModify = false;
      this.menuItemRecordApplicationCriteria.OriginalText = "";
      this.menuItemRecordApplicationCriteria.OwnerDraw = true;
      this.menuItemRecordApplicationCriteria.Text = "&Record Application Criteria";
      this.menuItemRecordApplicationCriteria.Click += new EventHandler(this.menuItemRecordApplicationCriteria_Click);
      this.menuItemASLEntry.ImageIndex = -1;
      this.menuItemASLEntry.ImageList = (ImageList) null;
      this.menuItemASLEntry.Index = 5;
      this.menuItemASLEntry.NoEdit = false;
      this.menuItemASLEntry.NoUIModify = false;
      this.menuItemASLEntry.OriginalText = "";
      this.menuItemASLEntry.OwnerDraw = true;
      this.menuItemASLEntry.Text = "&ASL Data Entry";
      this.menuItemASLEntry.Click += new EventHandler(this.menuItemASLEntry_Click);
      this.menuItemFinaliseOffers.ImageIndex = -1;
      this.menuItemFinaliseOffers.ImageList = (ImageList) null;
      this.menuItemFinaliseOffers.Index = 6;
      this.menuItemFinaliseOffers.NoEdit = false;
      this.menuItemFinaliseOffers.NoUIModify = false;
      this.menuItemFinaliseOffers.OriginalText = "";
      this.menuItemFinaliseOffers.OwnerDraw = true;
      this.menuItemFinaliseOffers.Text = "&Finalise Offers";
      this.menuItemFinaliseOffers.Click += new EventHandler(this.menuItemFinaliseOffers_Click);
      this.menuItemExportASLFile.ImageIndex = -1;
      this.menuItemExportASLFile.ImageList = (ImageList) null;
      this.menuItemExportASLFile.Index = 7;
      this.menuItemExportASLFile.NoEdit = false;
      this.menuItemExportASLFile.NoUIModify = false;
      this.menuItemExportASLFile.OriginalText = "";
      this.menuItemExportASLFile.OwnerDraw = true;
      this.menuItemExportASLFile.Text = "&Export ASL File";
      this.menuItemExportASLFile.Click += new EventHandler(this.menuItemExportASLFile_Click);
      this.menuItemImportATFFile.ImageIndex = -1;
      this.menuItemImportATFFile.ImageList = (ImageList) null;
      this.menuItemImportATFFile.Index = 8;
      this.menuItemImportATFFile.NoEdit = false;
      this.menuItemImportATFFile.NoUIModify = false;
      this.menuItemImportATFFile.OriginalText = "";
      this.menuItemImportATFFile.OwnerDraw = true;
      this.menuItemImportATFFile.Text = "I&mport ATF File";
      this.menuItemImportATFFile.Click += new EventHandler(this.menuItemImportATFFile_Click);
      this.menuItemImportATFFile.Visible = false;
      this.menuItemAcceptApplications.ImageIndex = -1;
      this.menuItemAcceptApplications.ImageList = (ImageList) null;
      this.menuItemAcceptApplications.Index = 9;
      this.menuItemAcceptApplications.NoEdit = false;
      this.menuItemAcceptApplications.NoUIModify = false;
      this.menuItemAcceptApplications.OriginalText = "";
      this.menuItemAcceptApplications.OwnerDraw = true;
      this.menuItemAcceptApplications.Text = "A&ccept Applications";
      this.menuItemAcceptApplications.Click += new EventHandler(this.menuItemAcceptApplications_Click);
      this.menuItemAdmitApplications.ImageIndex = -1;
      this.menuItemAdmitApplications.ImageList = (ImageList) null;
      this.menuItemAdmitApplications.Index = 10;
      this.menuItemAdmitApplications.NoEdit = false;
      this.menuItemAdmitApplications.NoUIModify = false;
      this.menuItemAdmitApplications.OriginalText = "";
      this.menuItemAdmitApplications.OwnerDraw = true;
      this.menuItemAdmitApplications.Text = "A&dmit Applications";
      this.menuItemAdmitApplications.Click += new EventHandler(this.menuItemAdmitApplications_Click);
      this.menuItemSetupAdmissionDefaults.Index = 0;
      this.menuItemSetupAdmissionDefaults.Text = "&Defaults";
      this.menuItemSetupAdmissionDefaults.Click += new EventHandler(this.menuItemSetupAdmissionDefaults_Click);
      this.menuItemSetupAdmissionCriterion.Index = 1;
      this.menuItemSetupAdmissionCriterion.Text = "&Criterion";
      this.menuItemSetupAdmissionCriterion.Click += new EventHandler(this.menuItemSetupAdmissionCriterion_Click);
      this.menuItemSetupAdmissionPolicy.Index = 2;
      this.menuItemSetupAdmissionPolicy.Text = "&Policies";
      this.menuItemSetupAdmissionPolicy.Click += new EventHandler(this.menuItemSetupAdmissionPolicy_Click);
      this.menuItemAdmission.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) this.menuItemEnquiry,
        (MenuItem) this.menuItemApplication,
        (MenuItem) this.menuItemInternalVisit
      });
      this.menuItemToolAdmissions.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) this.menuItemSetupAdmissionDefaults,
        (MenuItem) this.menuItemSetupAdmissionCriterion,
        (MenuItem) this.menuItemSetupAdmissionPolicy
      });
      this.menuItemEnquiry.Index = 0;
      this.menuItemEnquiry.Text = "&Enquiry";
      this.menuItemEnquiry.Click += new EventHandler(this.menuItemEnquiry_Click);
      this.menuItemApplication.Index = 1;
      this.menuItemApplication.Text = "&Application";
      this.menuItemApplication.Click += new EventHandler(this.menuItemApplication_Click);
      this.menuItemInternalVisit.Index = 2;
      this.menuItemInternalVisit.Text = "&Interviews && Visits";
      this.menuItemInternalVisit.Click += new EventHandler(this.menuItemInternalVisit_Click);
    }

    private void rebuildRAMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemEnquiry, "ADMViewEnquiries");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemApplication, "ADMViewApplications");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSetupAdmissionGroups, "ADMSetupAdmissionGroups");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemFinaliseOffers, "ADMRoutinesFinaliseOffers");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemTransferApplicants, "ADMGroupTransferApplicants");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemImportADTFile, "ADMRoutinesImportADT");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExportASLFile, "ADMRoutinesExportASL");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemImportATFFile, "ADMRoutinesImportATF");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAcceptApplications, "ADMRoutinesAcceptApplicants");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAdmitApplications, "ADMRoutinesAdmitApplicants");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemRecordApplicationCriteria, "ADMRoutinesRecordApplicationCriteria");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemASLEntry, "ADMRoutinesASLDataEntry");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSetupAdmissionDefaults, "ADMSetupDefaults");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSetupAdmissionCriterion, "ADMSetupCriterion");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSetupAdmissionPolicy, "ADMSetupPolicies");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemADMImportEnquiry, "ADMImportEnquiries");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemADMImportApplication, "ADMImportApplications");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemInternalVisit, "ADMViewVisit");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCommunication, "ViewCommunications");
    }

    private void customiseRAMenus()
    {
      int num = SystemConfigurationCache.IsIndependentSchool ? 1 : 0;
    }

    private void addRAContextLinks()
    {
      if (SIMS.Entities.Cache.ProcessVisible("RunReport") && SIMS.Entities.Cache.ProcessVisible("ADMViewApplications"))
        NavigationRouteCache.AddRoute("Quick letter", new NavigationRouteDelegate(this.ContextLetterApplicant), new int[1]
        {
          6
        }, typeof (ContextReport));
      if (SIMS.Entities.Cache.ProcessVisible("RunReport") && SIMS.Entities.Cache.ProcessVisible("ADMViewEnquiries"))
        NavigationRouteCache.AddRoute("Enquiry Reports", new NavigationRouteDelegate(this.ContextReportEnquiry), new int[1]
        {
          49
        }, typeof (ContextReport));
      if (SIMS.Entities.Cache.ProcessVisible("ADMViewApplications"))
        NavigationRouteCache.AddRoute("Application", new NavigationRouteDelegate(this.ContextApplication), new int[1]
        {
          6
        }, typeof (ApplicationDetail), 6);
      if (SIMS.Entities.Cache.ProcessVisible("ADMViewApplications"))
        NavigationRouteCache.AddRoute("Application", new NavigationRouteDelegate(this.ContextQuickSearchApplication), new int[1]
        {
          76
        }, typeof (ApplicationDetail), 76);
      if (SIMS.Entities.Cache.ProcessVisible("ADMViewVisit"))
      {
        NavigationRouteCache.AddRoute("School Diary", new NavigationRouteDelegate(this.ContextSchoolDiary), new int[1]
        {
          53
        }, typeof (CalendarContainer));
        NavigationRouteCache.AddRoute("School Diary", new NavigationRouteDelegate(this.ContextSchoolDiary), new int[1]
        {
          54
        }, typeof (CalendarContainer));
      }
      if (SIMS.Entities.Cache.ProcessVisible("ViewCommunications"))
        NavigationRouteCache.AddRoute("Communication", new NavigationRouteDelegate(this.ContextCommunication), new int[1]
        {
          50
        }, typeof (CommunicationDetail), 50);
      if (SIMS.Entities.Cache.ProcessVisible("ADMViewEnquiries"))
        NavigationRouteCache.AddRoute("Enquiry", new NavigationRouteDelegate(this.ContextEnquiry), new int[1]
        {
          49
        }, typeof (EnquiryDetail), 49);
      if (SIMS.Entities.Cache.ProcessVisible("ViewSENStudent") && SIMS.Entities.Cache.ProcessVisible("ADMViewApplications"))
      {
        NavigationRouteCache.AddRoute("SEN", new NavigationRouteDelegate(this.ContextSENOverview), new int[1]
        {
          6
        }, typeof (EditSENStudent));
        NavigationRouteCache.AddRoute("Application", new NavigationRouteDelegate(this.ContextApplication), new int[1]
        {
          56
        }, typeof (ApplicationContainer));
      }
      if (SIMS.Entities.Cache.ProcessVisible("RunReport") && SIMS.Entities.Cache.ProcessVisible("ADMViewApplications"))
        NavigationRouteCache.AddRoute("Application Reports", new NavigationRouteDelegate(this.ContextReportApplication), new int[1]
        {
          6
        }, typeof (ContextReport));
      if ((SIMS.Entities.Cache.ProcessVisible("ViewSENStudent") || SIMS.Entities.Cache.ProcessVisible("ADMViewApplications")) && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
        NavigationRouteCache.AddRoute("Linked Documents", new NavigationRouteDocumentDelegate(this.ContextPersonLinkedDocuments), new int[1]
        {
          6
        }, typeof (ManageEntityDocuments));
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentExamResults"))
        NavigationRouteCache.AddRoute("Examinations", new NavigationRouteDelegate(this.contextStudentExamResultsDetail), new int[1]
        {
          6
        }, typeof (StudentExamResultsDetail));
      if (SIMS.Entities.Cache.ProcessVisible("ViewStudentConcessions") || SIMS.Entities.Cache.ProcessVisible("EditStudentConcessions"))
        NavigationRouteCache.AddRoute("Concessions", new NavigationRouteDelegate(this.ContextMenuApplicantConcessions), new int[1]
        {
          6
        }, typeof (ConcessionDetail));
      if (SIMS.Entities.Cache.ProcessVisible("ViewCommunications"))
        NavigationRouteCache.AddRoute("Communication Log", new NavigationRouteDelegate(this.contextCommunicationLog), new int[1]
        {
          4
        }, typeof (PersonCommunicationContainer));
      CommunicationDetail.AddCommunicationContext("APPLICATION", 6);
      CommunicationDetail.AddCommunicationContext("ENQUIRY", 49);
    }

    private void menuItemEnquiry_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EnquiryContainer());
    }

    private void menuItemInternalVisit_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new InternalVisitContainer());
    }

    private void menuItemExternalVisit_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ExternalVisitContainer());
    }

    private void menuItemSetupAdmissionGroups_Click(object sender, EventArgs e)
    {
      if (SIMS.Entities.Cache.ProcessAvailable("ADMViewApplications"))
        this.warningIfScreenIsOpen("SIMS.UserInterfaces.Admissions.ApplicationContainer", "Application Details");
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new IntakeGroupContainer());
    }

    private void menuItemFinaliseOffers_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FinaliseOffersContainer());
    }

    private void menuItemAcceptApplications_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new AcceptApplicationBrowserDetail());
    }

    private void menuItemAdmitApplications_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new AdmitApplicantContainer());
    }

    private void menuItemTransferApplicants_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EditAdmissionGroupMembers());
    }

    private void menuItemCommunication_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CommunicationContainer());
    }

    private void menuItemSetupAdmissionDefaults_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new SIMS.UserInterfaces.Admissions.AdmissionSetup());
    }

    private void menuItemSetupAdmissionPolicy_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new AdmissionPolicyContainer());
    }

    private void menuItemSetupAdmissionCriterion_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SetupCriterionContainer());
    }

    private void ContextReportApplication(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      new ContextReport("Application", entityToDisplay.ID).Run((Form) this);
    }

    private void ContextLetterApplicant(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      new ContextReport("Applicant", entityToDisplay.ID).RunQuickLetter();
    }

    private void ContextLetterEnquiry(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      new ContextReport("Enquiry", entityToDisplay.ID).RunQuickLetter();
    }

    private void ContextApplication(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl(entityToDisplay, new ApplicationContainer(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextQuickSearchApplication(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new ApplicationDetail(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextEnquiry(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl(entityToDisplay, (AbstractContainerControl) new EnquiryContainer(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextReportEnquiry(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      new ContextReport("Admission Enquiry", entityToDisplay.ID).Run((Form) this);
    }

    private void ContextInternalVisit(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl(entityToDisplay, (AbstractContainerControl) new InternalVisitContainer(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextExternalVisit(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl(entityToDisplay, (AbstractContainerControl) new ExternalVisitContainer(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextCommunication(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      this.ShowContextControl(entityToDisplay, (AbstractContainerControl) new CommunicationContainer(entityToDisplay), showAsIndependentWindow);
    }

    private void contextCommunicationLog(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      string messageType = SIMS.UserInterfaces.InTouch.SendStudentMessageHost.ConvertControlNameToMessageType(this.panelMain.Controls.Count > 0 ? this.panelMain.Controls[0].Name : this.focusedControl().Name);
      this.ShowContextControl((AbstractContainerControl) new PersonCommunicationContainer(entityToDisplay, messageType), showAsIndependentWindow);
    }

    private void ContextMenuApplicantConcessions(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      ConcessionDetail concessionDetail = new ConcessionDetail(entityToDisplay);
      if (entityToDisplay is DetailedApplication)
        concessionDetail.IsApplication = true;
      this.ShowContextControl((BasicDetailControl) concessionDetail, showAsIndependentWindow);
    }

    private void menuItemApplication_Click(object sender, EventArgs e)
    {
      if (SIMS.Entities.Cache.ProcessAvailable("ADMSetupAdmissionGroups"))
        this.warningIfScreenIsOpen("SIMS.UserInterfaces.Admissions.IntakeGroupContainer", "Intake Group");
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ApplicationContainer());
    }

    private void menuItemRecordApplicationCriteria_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CriteriaResultContainer());
    }

    private void menuItemASLEntry_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new BasicASLEntryContainer());
    }

    private void menuItemImportADTFile_Click(object sender, EventArgs e)
    {
      int num = (int) new ImportWizard(ImportWizard.enumProcessType.ImportADT).ShowDialog((IWin32Window) this);
    }

    private void menuItemExportASLFile_Click(object sender, EventArgs e)
    {
      ExportBasicAslWizard.DisplayExportWizard((IWin32Window) this);
    }

    private void menuItemImportATFFile_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ImportWizard importWizard = new ImportWizard(ImportWizard.enumProcessType.ImportATF);
      importWizard.FormBorderStyle = FormBorderStyle.FixedDialog;
      int num = (int) importWizard.ShowDialog((IWin32Window) this);
    }

    private void ContextPreAdStudent(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
    }

    private void initAcademicMenus()
    {
      this.initOptionsOfferMenu();
      this.initOptionsNGMenu();
      this.initSimsParentMenu();
      this.menuItemCurrSchemeDetails = new UIMenuItem();
      this.menuItemCurrStudentDetails = new UIMenuItem();
      this.menuItemCurrWholeDetails = new UIMenuItem();
      this.menuItemCurrEditLesson = new UIMenuItem();
      this.menuItemCurrRotateResources = new UIMenuItem();
      this.menuItemCurrSetAcademicYear = new UIMenuItem();
      this.menuItemSetCurrentTier = new UIMenuItem();
      this.menuItemCurrUpdateCourseMembers = new UIMenuItem();
      this.menuItemCurrCourseManagerBulkUpdate = new UIMenuItem();
      this.menuItemCurrStudentCourseReport = new UIMenuItem();
      this.menuItemCurrProgrammeOfStudy = new UIMenuItem();
      this.menuItemCurrCourseManagerSettings = new UIMenuItem();
      this.menuItemCurrAssignablePeople = new UIMenuItem();
      this.menuItemCurrApplyTimetable = new UIMenuItem();
      this.menuItemCurrDefineTimetableCycle = new UIMenuItem();
      this.menuItemCurrSetup = new UIMenuItem();
      this.menuItemAcademicPromotion = new UIMenuItem();
      this.menuItemCurrEditScheme = new UIMenuItem();
      this.menuItemCurrViewLessonList = new UIMenuItem();
      this.menuItemCurrStudentSummary = new UIMenuItem();
      this.menuItemCourseManager = new UIMenuItem();
      this.menuItemMaintainCourseClassification = new UIMenuItem();
      this.menuItemMaintainCourse = new UIMenuItem();
      this.menuItemNewMaintainCourse = new UIMenuItem();
      this.menuItemCourseManagerSetup = new UIMenuItem();
      this.menuItemAcademicStructure.MenuItems.AddRange(new MenuItem[8]
      {
        (MenuItem) this.menuItemCurrSchemeDetails,
        (MenuItem) this.menuItemCurrStudentDetails,
        (MenuItem) this.menuItemCurrWholeDetails,
        (MenuItem) this.menuItemCurrEditLesson,
        (MenuItem) this.menuItemCurrRotateResources,
        (MenuItem) this.menuItemCurrEditScheme,
        (MenuItem) this.menuItemCurrViewLessonList,
        (MenuItem) this.menuItemCurrStudentSummary
      });
      this.menuItemToolsAcademic.MenuItems.AddRange(new MenuItem[6]
      {
        (MenuItem) this.menuItemCurrSetAcademicYear,
        (MenuItem) this.menuItemSetCurrentTier,
        (MenuItem) this.menuItemCurrApplyTimetable,
        (MenuItem) this.menuItemCourseManager,
        (MenuItem) this.menuItemCurrDefineTimetableCycle,
        (MenuItem) this.menuItemOptionsOffer
      });
      this.menuItemSetups.MenuItems.Add((MenuItem) this.menuItemToolsCurriculum);
      this.menuItemSchoolBase.MenuItems.Add((MenuItem) this.menuItemAcademicPromotion);
      this.menuItemCurricStudent.Click += new EventHandler(this.menuItemCurrStudentDetails_Click);
      this.menuItemCurrSchemeDetails.ImageIndex = -1;
      this.menuItemCurrSchemeDetails.ImageList = (ImageList) null;
      this.menuItemCurrSchemeDetails.NoEdit = false;
      this.menuItemCurrSchemeDetails.NoUIModify = false;
      this.menuItemCurrSchemeDetails.OriginalText = "";
      this.menuItemCurrSchemeDetails.OwnerDraw = true;
      this.menuItemCurrSchemeDetails.Text = "C&urriculum Assignment by Scheme";
      this.menuItemCurrSchemeDetails.Click += new EventHandler(this.menuItemCurrSchemeDetails_Click);
      this.menuItemCurrStudentDetails.ImageIndex = -1;
      this.menuItemCurrStudentDetails.ImageList = (ImageList) null;
      this.menuItemCurrStudentDetails.NoEdit = false;
      this.menuItemCurrStudentDetails.NoUIModify = false;
      this.menuItemCurrStudentDetails.OriginalText = "";
      this.menuItemCurrStudentDetails.OwnerDraw = true;
      this.menuItemCurrStudentDetails.Text = "&Curriculum Assignment by " + SIMS.Entities.Cache.UserInterfaceLabel("Student");
      this.menuItemCurrStudentDetails.Click += new EventHandler(this.menuItemCurrStudentDetails_Click);
      this.menuItemCurrWholeDetails.ImageIndex = -1;
      this.menuItemCurrWholeDetails.ImageList = (ImageList) null;
      this.menuItemCurrWholeDetails.NoEdit = false;
      this.menuItemCurrWholeDetails.NoUIModify = false;
      this.menuItemCurrWholeDetails.OriginalText = "";
      this.menuItemCurrWholeDetails.OwnerDraw = true;
      this.menuItemCurrWholeDetails.Text = "&Whole Curriculum Assignment";
      this.menuItemCurrWholeDetails.Click += new EventHandler(this.menuItemCurrWholeDetails_Click);
      this.menuItemCurrEditScheme.ImageIndex = -1;
      this.menuItemCurrEditScheme.ImageList = (ImageList) null;
      this.menuItemCurrEditScheme.Index = 0;
      this.menuItemCurrEditScheme.NoEdit = false;
      this.menuItemCurrEditScheme.NoUIModify = false;
      this.menuItemCurrEditScheme.OriginalText = "";
      this.menuItemCurrEditScheme.OwnerDraw = true;
      this.menuItemCurrEditScheme.Text = "&Edit Curriculum Structure";
      this.menuItemCurrEditScheme.Click += new EventHandler(this.menuItemCurrEditScheme_Click);
      this.menuItemCurrEditLesson.ImageIndex = -1;
      this.menuItemCurrEditLesson.ImageList = (ImageList) null;
      this.menuItemCurrEditLesson.NoEdit = false;
      this.menuItemCurrEditLesson.NoUIModify = false;
      this.menuItemCurrEditLesson.OriginalText = "";
      this.menuItemCurrEditLesson.OwnerDraw = true;
      this.menuItemCurrEditLesson.Text = "&Edit Lesson Staff and Rooms";
      this.menuItemCurrEditLesson.Click += new EventHandler(this.menuItemCurrEditLesson_Click);
      this.menuItemCurrViewLessonList.ImageIndex = -1;
      this.menuItemCurrViewLessonList.ImageList = (ImageList) null;
      this.menuItemCurrViewLessonList.NoEdit = false;
      this.menuItemCurrViewLessonList.NoUIModify = false;
      this.menuItemCurrViewLessonList.OriginalText = "";
      this.menuItemCurrViewLessonList.OwnerDraw = true;
      this.menuItemCurrViewLessonList.Text = "&View Lesson List";
      this.menuItemCurrViewLessonList.Click += new EventHandler(this.menuItemCurrViewLessonList_Click);
      this.menuItemCurrStudentSummary.ImageIndex = -1;
      this.menuItemCurrStudentSummary.ImageList = (ImageList) null;
      this.menuItemCurrStudentSummary.NoEdit = false;
      this.menuItemCurrStudentSummary.NoUIModify = false;
      this.menuItemCurrStudentSummary.OriginalText = "";
      this.menuItemCurrStudentSummary.OwnerDraw = true;
      this.menuItemCurrStudentSummary.Text = "View " + SIMS.Entities.Cache.UserInterfaceLabel("Student") + " Curriculum &Summary";
      this.menuItemCurrStudentSummary.Click += new EventHandler(this.menuItemCurrStudentSummary_Click);
      this.menuItemCurrRotateResources.ImageIndex = -1;
      this.menuItemCurrRotateResources.ImageList = (ImageList) null;
      this.menuItemCurrRotateResources.NoEdit = false;
      this.menuItemCurrRotateResources.NoUIModify = false;
      this.menuItemCurrRotateResources.OriginalText = "";
      this.menuItemCurrRotateResources.OwnerDraw = true;
      this.menuItemCurrRotateResources.Text = "&Rotate Timetabled Staff/Rooms";
      this.menuItemCurrRotateResources.Click += new EventHandler(this.menuItemCurrRotateResources_Click);
      this.menuItemCurrSetAcademicYear.ImageIndex = -1;
      this.menuItemCurrSetAcademicYear.ImageList = (ImageList) null;
      this.menuItemCurrSetAcademicYear.Index = 0;
      this.menuItemCurrSetAcademicYear.NoEdit = false;
      this.menuItemCurrSetAcademicYear.NoUIModify = false;
      this.menuItemCurrSetAcademicYear.OriginalText = "";
      this.menuItemCurrSetAcademicYear.OwnerDraw = true;
      this.menuItemCurrSetAcademicYear.Text = "&Set Academic Year";
      this.menuItemCurrSetAcademicYear.Click += new EventHandler(this.menuItemCurrSetAcademicYear_Click);
      this.menuItemSetCurrentTier.ImageIndex = -1;
      this.menuItemSetCurrentTier.ImageList = (ImageList) null;
      this.menuItemSetCurrentTier.Index = 0;
      this.menuItemSetCurrentTier.NoEdit = false;
      this.menuItemSetCurrentTier.NoUIModify = false;
      this.menuItemSetCurrentTier.OriginalText = "";
      this.menuItemSetCurrentTier.OwnerDraw = true;
      this.menuItemSetCurrentTier.Text = "&Set Current Tier";
      this.menuItemSetCurrentTier.Click += new EventHandler(this.menuItemSetCurrentTier_Click);
      this.menuItemCurrUpdateCourseMembers.ImageIndex = -1;
      this.menuItemCurrUpdateCourseMembers.ImageList = (ImageList) null;
      this.menuItemCurrUpdateCourseMembers.Index = 2;
      this.menuItemCurrUpdateCourseMembers.NoEdit = false;
      this.menuItemCurrUpdateCourseMembers.NoUIModify = false;
      this.menuItemCurrUpdateCourseMembers.OriginalText = "";
      this.menuItemCurrUpdateCourseMembers.OwnerDraw = true;
      this.menuItemCurrUpdateCourseMembers.Text = "&Update Course Memberships";
      this.menuItemCurrUpdateCourseMembers.Click += new EventHandler(this.menuItemCurrUpdateCourseMembers_Click);
      this.menuItemCurrCourseManagerBulkUpdate.Text = "&Bulk Update Courses";
      this.menuItemCurrCourseManagerBulkUpdate.Click += new EventHandler(this.menuItemCurrCourseManagerBulkUpdate_Click);
      this.menuItemCurrStudentCourseReport.Text = "&Student Courses Report";
      this.menuItemCurrStudentCourseReport.Click += new EventHandler(this.menuItemCurrStudentCourseReport_Click);
      this.menuItemCurrProgrammeOfStudy.Text = "Post-16 &Programmes of Study";
      this.menuItemCurrProgrammeOfStudy.Click += new EventHandler(this.menuItemCurrProgrammeOfStudy_Click);
      this.menuItemCurrCourseManagerSettings.Text = "&Course Manager Settings";
      this.menuItemCurrCourseManagerSettings.Click += new EventHandler(this.menuItemCurrCourseManagerSettings_Click);
      this.menuItemCurrAssignablePeople.ImageIndex = -1;
      this.menuItemCurrAssignablePeople.ImageList = (ImageList) null;
      this.menuItemCurrAssignablePeople.Index = 3;
      this.menuItemCurrAssignablePeople.NoEdit = false;
      this.menuItemCurrAssignablePeople.NoUIModify = false;
      this.menuItemCurrAssignablePeople.OriginalText = "";
      this.menuItemCurrAssignablePeople.OwnerDraw = true;
      this.menuItemCurrAssignablePeople.Text = "&Manage Classroom Staff";
      this.menuItemCurrAssignablePeople.Click += new EventHandler(this.menuItemCurrAssignablePeople_Click);
      this.menuItemCurrApplyTimetable.ImageIndex = -1;
      this.menuItemCurrApplyTimetable.ImageList = (ImageList) null;
      this.menuItemCurrApplyTimetable.Index = 1;
      this.menuItemCurrApplyTimetable.NoEdit = false;
      this.menuItemCurrApplyTimetable.NoUIModify = false;
      this.menuItemCurrApplyTimetable.OriginalText = "";
      this.menuItemCurrApplyTimetable.OwnerDraw = true;
      this.menuItemCurrApplyTimetable.Text = "&Apply Timetable";
      this.menuItemCurrApplyTimetable.Click += new EventHandler(this.menuItemCurrApplyTimetable_Click);
      this.menuItemCurrDefineTimetableCycle.ImageIndex = -1;
      this.menuItemCurrDefineTimetableCycle.ImageList = (ImageList) null;
      this.menuItemCurrDefineTimetableCycle.Index = 1;
      this.menuItemCurrDefineTimetableCycle.NoEdit = false;
      this.menuItemCurrDefineTimetableCycle.NoUIModify = false;
      this.menuItemCurrDefineTimetableCycle.OriginalText = "";
      this.menuItemCurrDefineTimetableCycle.OwnerDraw = true;
      this.menuItemCurrDefineTimetableCycle.Text = "&Define Timetable Cycle";
      this.menuItemCurrDefineTimetableCycle.Click += new EventHandler(this.menuItemCurrDefineTimetableCycle_Click);
      this.menuItemCurrSetup.ImageIndex = -1;
      this.menuItemCurrSetup.ImageList = (ImageList) null;
      this.menuItemCurrSetup.Index = 1;
      this.menuItemCurrSetup.NoEdit = false;
      this.menuItemCurrSetup.NoUIModify = false;
      this.menuItemCurrSetup.OriginalText = "";
      this.menuItemCurrSetup.OwnerDraw = true;
      this.menuItemCurrSetup.Text = "&Curriculum";
      this.menuItemCurrSetup.Click += new EventHandler(this.menuItemCurrSetup_Click);
      this.menuItemAcademicPromotion.ImageIndex = -1;
      this.menuItemAcademicPromotion.ImageList = (ImageList) null;
      this.menuItemAcademicPromotion.Index = 4;
      this.menuItemAcademicPromotion.NoEdit = false;
      this.menuItemAcademicPromotion.NoUIModify = false;
      this.menuItemAcademicPromotion.OriginalText = "";
      this.menuItemAcademicPromotion.OwnerDraw = true;
      this.menuItemAcademicPromotion.Text = "Academic &Promotion Rules";
      this.menuItemAcademicPromotion.Click += new EventHandler(this.MenuItemAcademicPromotion_Click);
      this.menuItemCourseManager.ImageIndex = -1;
      this.menuItemCourseManager.ImageList = (ImageList) null;
      this.menuItemCourseManager.NoEdit = false;
      this.menuItemCourseManager.NoUIModify = false;
      this.menuItemCourseManager.OriginalText = "";
      this.menuItemCourseManager.OwnerDraw = true;
      this.menuItemCourseManager.Text = "&Course Manager";
      this.menuItemCourseManager.Index = 2;
      this.menuItemMaintainCourse.Index = 0;
      this.menuItemMaintainCourse.Text = "&Maintain Course";
      this.menuItemMaintainCourse.ImageIndex = -1;
      this.menuItemMaintainCourse.ImageList = (ImageList) null;
      this.menuItemMaintainCourse.NoEdit = false;
      this.menuItemMaintainCourse.NoUIModify = false;
      this.menuItemMaintainCourse.OriginalText = "";
      this.menuItemMaintainCourse.OwnerDraw = true;
      this.menuItemMaintainCourse.Click += new EventHandler(this.menuItemMaintainCourse_Click);
      this.menuItemNewMaintainCourse.Index = 0;
      this.menuItemNewMaintainCourse.Text = "&Maintain Course";
      this.menuItemNewMaintainCourse.ImageIndex = -1;
      this.menuItemNewMaintainCourse.ImageList = (ImageList) null;
      this.menuItemNewMaintainCourse.NoEdit = false;
      this.menuItemNewMaintainCourse.NoUIModify = false;
      this.menuItemNewMaintainCourse.OriginalText = "";
      this.menuItemNewMaintainCourse.OwnerDraw = true;
      this.menuItemNewMaintainCourse.Click += new EventHandler(this.menuItemNewMaintainCourse_Click);
      this.menuItemMaintainCourseClassification.Index = 1;
      this.menuItemMaintainCourseClassification.Text = "Maintain &Course Classification";
      this.menuItemMaintainCourseClassification.ImageIndex = -1;
      this.menuItemMaintainCourseClassification.ImageList = (ImageList) null;
      this.menuItemMaintainCourseClassification.NoEdit = false;
      this.menuItemMaintainCourseClassification.NoUIModify = false;
      this.menuItemMaintainCourseClassification.OriginalText = "";
      this.menuItemMaintainCourseClassification.OwnerDraw = true;
      this.menuItemMaintainCourseClassification.Click += new EventHandler(this.menuItemMaintainCourseClassification_Click);
      this.menuItemCourseManagerSetup.ImageIndex = -1;
      this.menuItemCourseManagerSetup.ImageList = (ImageList) null;
      this.menuItemCourseManagerSetup.Index = 1;
      this.menuItemCourseManagerSetup.NoEdit = false;
      this.menuItemCourseManagerSetup.NoUIModify = false;
      this.menuItemCourseManagerSetup.OriginalText = "";
      this.menuItemCourseManagerSetup.OwnerDraw = true;
      this.menuItemCourseManagerSetup.Text = "Course &Manager Setup";
      this.menuItemCourseManagerSetup.Click += new EventHandler(this.menuItemCourseManagerSetup_Click);
      this.menuItemCourseManager.MenuItems.AddRange(new MenuItem[11]
      {
        (MenuItem) this.menuItemNewMaintainCourse,
        (MenuItem) this.menuItemMaintainCourse,
        (MenuItem) this.menuItemMaintainCourseClassification,
        (MenuItem) this.menuItemCurrProgrammeOfStudy,
        (MenuItem) this.menuItemCurrUpdateCourseMembers,
        (MenuItem) this.menuItemCurrCourseManagerBulkUpdate,
        (MenuItem) this.menuItemCurrStudentCourseReport,
        (MenuItem) this.menuItemDuplicateQANReport,
        (MenuItem) this.menuItemCurrCourseManagerSettings,
        (MenuItem) this.menuItemImportQWADForCM,
        (MenuItem) this.menuItemImportQansForCM
      });
      this.menuItemToolsCurriculum.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemCurrSetup,
        (MenuItem) this.menuItemCourseManagerSetup
      });
      this.menuItemPeople.MenuItems.Add((MenuItem) this.menuItemCurrAssignablePeople);
      this.helpDescAcademicMenus();
    }

    private void rebuildAcademicMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrSchemeDetails, new string[2]
      {
        "CurrSchemeBrowser",
        "CurrSchemeDetail"
      });
      string[] processNames1 = new string[2]
      {
        "CurrStudentBrowser",
        "CurrStudentDetail"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrStudentDetails, processNames1);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurricStudent, processNames1);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrSetAcademicYear, "SelectCurrAcademicYear");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrUpdateCourseMembers, "CurrUpdateCourseMembership");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrCourseManagerBulkUpdate, "CurrUpdateCourseMembership");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrStudentCourseReport, "CurrUpdateCourseMembership");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrProgrammeOfStudy, "CurrUpdateCourseMembership");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrCourseManagerSettings, "CurrUpdateCourseMembership");
      if (SystemConfigurationCache.LocaleCode != "ENG" && SystemConfigurationCache.LocaleCode != "WALES")
      {
        this.menuItemCurrProgrammeOfStudy.Visible = false;
        this.menuItemCurrCourseManagerBulkUpdate.Visible = false;
      }
      this.menuItemCurrAssignablePeople.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemCurrAssignablePeople.ImageIndex = 42;
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrAssignablePeople, "CovAssignableDetail");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrApplyTimetable, "CurrApplyTimetable");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrDefineTimetableCycle, new string[2]
      {
        "MultipleTimetables",
        "CurrDefineTimetableCycle"
      });
      this.menuItemSetCurrentTier.Visible = SIMS.Entities.Cache.Settings.ContainsKey("MultipleTimetables") && (SIMS.Entities.Cache.Settings["MultipleTimetables"] == "T" || SIMS.Entities.Cache.Settings["MultipleTimetables"] == "Used");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrEditScheme, new string[2]
      {
        "CurrSchemeBrowser",
        "CurrEditScheme"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrSetup, "CurrSetupDetail");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAcademicPromotion, new string[2]
      {
        "CurrPromotion",
        "CurrPromotionAcademicYear"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrWholeDetails, new string[2]
      {
        "CurrGroupBrowser",
        "CurrWholeDetail"
      });
      if (!new AttendanceUtilities().IsArchivedYear)
      {
        string[] processNames2 = new string[2]
        {
          "CurrBrowseLessons",
          "CurrEditLesson"
        };
        this.menuItemCurrEditLesson.Visible = true;
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrEditLesson, processNames2);
      }
      else
        this.menuItemCurrEditLesson.Visible = false;
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrRotateResources, new string[2]
      {
        "CurrSchemeBrowser",
        "CurrRotateResources"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMaintainCourseClassification, new string[1]
      {
        "ManageCourseClassification"
      });
      string[] processNames3 = new string[2]
      {
        "ManageCourse",
        "ViewCourse"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMaintainCourse, processNames3);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNewMaintainCourse, processNames3);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCourseManagerSetup, "CurrSetupCourseManager");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrViewLessonList, new string[2]
      {
        "CurrAltBrowseLessons",
        "CurrLessonMembers"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrStudentSummary, new string[2]
      {
        "CurrStudentSummaryRptBrowser",
        "CurrStudentSummaryRpt"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemToolsOptions, "LaunchOptions");
      this.menuItemMaintainCourse.Visible = false;
      this.menuItemCourseManagerSetup.Visible = false;
      this.rebuildOptionsOfferMenu();
      this.rebuildOptionsNGMenu();
      this.rebuildSimsParentMenu();
    }

    private void helpDescAcademicMenus()
    {
      string str1 = SIMS.Entities.CurrCache.Initialised ? SIMS.Entities.CurrCache.AcadYear.Description : UserOptionsCache.UserOptions.AcademicYearDescription;
      string str2 = !SIMS.Entities.CurrCache.Initialised || SIMS.Entities.CurrCache.AcadYear.EventInstanceID == UserOptionsCache.UserOptions.AcademicYearEventInstanceID ? "." : string.Format(" - restart {0} for {1}!", (object) SIMS.Entities.Cache.ApplicationName, (object) UserOptionsCache.UserOptions.AcademicYearDescription);
      this.menuItemCurricStudent.HelpDescription = string.Format("Perform {0} (for {1}){2}", (object) this.trueText(this.menuItemCurricStudent.Text), (object) str1, (object) str2);
      this.menuItemCurrSchemeDetails.HelpDescription = string.Format("Perform {0} (for {1}){2}", (object) this.trueText(this.menuItemCurrSchemeDetails.Text), (object) str1, (object) str2);
      this.menuItemCurrStudentDetails.HelpDescription = string.Format("Perform {0} (for {1}){2}", (object) this.trueText(this.menuItemCurrStudentDetails.Text), (object) str1, (object) str2);
      this.menuItemCurrWholeDetails.HelpDescription = string.Format("Perform {0} (for {1}){2}", (object) this.trueText(this.menuItemCurrWholeDetails.Text), (object) str1, (object) str2);
      this.menuItemCurrEditLesson.HelpDescription = string.Format("Perform {0} (for {1}){2}", (object) this.trueText(this.menuItemCurrEditLesson.Text), (object) str1, (object) str2);
      this.menuItemCurrRotateResources.HelpDescription = string.Format("Perform {0} (for {1}){2}", (object) this.trueText(this.menuItemCurrRotateResources.Text), (object) str1, (object) str2);
      this.menuItemCurrEditScheme.HelpDescription = string.Format("Perform {0} (for {1}){2}", (object) this.trueText(this.menuItemCurrEditScheme.Text), (object) str1, (object) str2);
      this.menuItemCurrViewLessonList.HelpDescription = string.Format("Perform {0} (for {1}){2}", (object) this.trueText(this.menuItemCurrViewLessonList.Text), (object) str1, (object) str2);
      this.menuItemCurrStudentSummary.HelpDescription = string.Format("Perform {0} (for {1}){2}", (object) this.trueText(this.menuItemCurrStudentSummary.Text), (object) str1, (object) str2);
    }

    private void menuItemCurrSchemeDetails_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCurrScheme());
    }

    private void menuItemMaintainCourse_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCourseBrowserDetail());
    }

    private void menuItemNewMaintainCourse_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CourseManagerMaintainBrowserDetail());
    }

    private void menuItemMaintainCourseClassification_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgMaintainCourseClassification courseClassification = new DlgMaintainCourseClassification())
      {
        int num = (int) courseClassification.ShowDialog();
      }
    }

    private void menuItemCurrWholeDetails_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCurrWhole());
    }

    private void menuItemCurrEditLesson_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CurrLessonContainer());
    }

    private void menuItemCurrRotateResources_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (CurrRotateResourcesDlg rotateResourcesDlg = new CurrRotateResourcesDlg())
      {
        int num = (int) rotateResourcesDlg.ShowDialog();
      }
    }

    private void menuItemCurrEditScheme_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CurrSchemeEditContainer());
    }

    private void menuItemCurrViewLessonList_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CurrLessonListContainer());
    }

    private void menuItemCurrStudentSummary_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CurrStudSummaryRptContainer());
    }

    private void menuItemCurrStudentDetails_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCurrStudent());
    }

    private void menuItemSetCurrentTier_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (SelectCurrentTier selectCurrentTier = new SelectCurrentTier())
      {
        int num = (int) selectCurrentTier.ShowDialog();
      }
    }

    private void menuItemCurrSetAcademicYear_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (SIMS.Entities.CurrCache.Initialised && (this.ComponentExists("SIMS.UserInterfaces.MaintainCurrScheme") != null || this.ComponentExists("SIMS.UserInterfaces.MaintainCurrStudent") != null || (this.ComponentExists("SIMS.UserInterfaces.MaintainCurrWhole") != null || this.ComponentExists("SIMS.UserInterfaces.CurrSchemeEditContainer") != null) || this.ComponentExists("SIMS.UserInterfaces.CurrLesonContainer") != null))
      {
        int num = (int) MessageBox.Show("You cannot change the Academic Year while any Curriculum windows are open.\r\n\r\nThe currently selected year is " + SIMS.Entities.CurrCache.AcadYear.Description, SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        using (SelectCurrAcademicYear currAcademicYear = new SelectCurrAcademicYear())
        {
          HomePageDetail homePageDetail = this.ComponentExists("SIMS.UserInterfaces.HomePageDetail") as HomePageDetail;
          if (homePageDetail != null)
            currAcademicYear.LinkLabelAY = homePageDetail.LinkLabelAY;
          if (currAcademicYear.ShowDialog() != DialogResult.OK)
            return;
          this.helpDescAcademicMenus();
        }
      }
    }

    private void menuItemCurrCourseManagerBulkUpdate_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CourseManagerBulkUpdate());
    }

    private void menuItemCurrStudentCourseReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new StudentCourseReport());
    }

    private void menuItemCurrProgrammeOfStudy_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainProgrammeOfStudy());
    }

    private void menuItemCurrCourseManagerSettings_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CourseManagerSettings());
    }

    private void menuItemCurrUpdateCourseMembers_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      InvokeProgressBarDelegatedforCM progressBarDelegate = new InvokeProgressBarDelegatedforCM(new CurrUpdateCourseMembership().Execute);
      SIMS.Processes.CurrCache.Populate();
      string text = "";
      if (SIMS.Entities.CurrCache.Initialised)
        text = "Academic Year " + SIMS.Entities.CurrCache.AcadYear.StartAttribute.Value.Year.ToString() + "/" + SIMS.Entities.CurrCache.AcadYear.EndAttribute.Value.Year.ToString() + "\n\n" + MaintainCourseBrowser.MSG_ASK_UPDATE_COURSE_MEMBERSHIP;
      if (MessageBox.Show(text, SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      CurrProgressStatus currProgressStatus = new CurrProgressStatus();
      try
      {
        SIMS.Entities.Cache.StatusMessage("Updating Course Memberships...", UserMessageEventEnum.Information);
        currProgressStatus.Owner = (System.Windows.Forms.Form) this;
        this.Enabled = false;
        currProgressStatus.Show();
        currProgressStatus.DisplayValidationProgressBar(progressBarDelegate);
      }
      finally
      {
        this.Enabled = true;
        currProgressStatus.Owner = (System.Windows.Forms.Form) null;
        currProgressStatus.Dispose();
      }
    }

    private void menuItemCurrAssignablePeople_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovAssignableContainer());
    }

    private void menuItemCurrApplyTimetable_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      new CurrApplyTimetable().Execute();
    }

    private void menuItemCurrDefineTimetableCycle_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgCurrDefineTimetableCycle defineTimetableCycle = new DlgCurrDefineTimetableCycle())
      {
        int num = (int) defineTimetableCycle.ShowDialog();
      }
    }

    private void MenuItemAcademicPromotion_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CurrPromotionSchemeGroups());
    }

    private void menuItemCurrSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CurrSetupDetail());
    }

    private void menuItemCourseManagerSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgCourseManagerSetup courseManagerSetup = new DlgCourseManagerSetup())
      {
        int num = (int) courseManagerSetup.ShowDialog();
      }
    }

    private void addAcademicContextLinks()
    {
      if (SIMS.Entities.Cache.ProcessVisible("CurrStudentDetail"))
        NavigationRouteCache.AddRoute(SIMS.Entities.Cache.UserInterfaceLabel("Student") + " Curriculum", new NavigationRouteDelegate(this.ContextStudentCurriculum), new int[1]
        {
          4
        }, typeof (CurrStudentDetail));
      if (!SIMS.Entities.Cache.ProcessVisible("CovAssignableDetail"))
        return;
      NavigationRouteCache.AddRoute("Classroom Staff Details", new NavigationRouteDatedDelegate(this.ContextClassroomStaff), new int[1]
      {
        28
      }, typeof (CovAssignableDetail), 28);
    }

    private void ContextStudentCurriculum(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (entityToDisplay != null)
        this.ShowContextControl(entityToDisplay, (BasicDetailControl) new CurrStudentDetail(entityToDisplay), showAsIndependentWindow);
      else
        SIMS.Entities.Cache.StatusMessage("No student selected.", UserMessageEventEnum.Information);
    }

    private void ContextClassroomStaff(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      if (entityToDisplay == null || entityToDisplay.ID == 0)
        SIMS.Entities.Cache.StatusMessage("No staff to display: ensure staff is saved before linking", UserMessageEventEnum.Information);
      else
        this.ShowContextControl((BasicDetailControl) new CovAssignableDetail(entityToDisplay, effectiveDate), showAsIndependentWindow);
    }

    private void initB2BMenus()
    {
      this.menuItemConfigureSetting = new UIMenuItem();
      this.menuItemMaintainTasks = new UIMenuItem();
      this.menuItemTaskLog = new UIMenuItem();
      this.menuItemSuspenseProcessing = new UIMenuItem();
      this.menuItemB2BPersonnel = new UIMenuItem();
      this.menuItemB2BStudent = new UIMenuItem();
      this.menuItemB2BFieldProcessing = new UIMenuItem();
      this.menuItemB2BAuthoriseChanges = new UIMenuItem();
      this.menuItemB2BSuspension = new UIMenuItem();
      this.menuItemB2BImportALLEmployee = new UIMenuItem();
      this.menuItemB2BExportALLEmployee = new UIMenuItem();
      this.menuItemB2B.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemConfigureSetting,
        (MenuItem) this.menuItemTaskLog,
        (MenuItem) this.menuItemMaintainTasks,
        (MenuItem) this.menuItemB2BStudent,
        (MenuItem) this.menuItemB2BPersonnel
      });
      this.menuItemB2B.NoEdit = false;
      this.menuItemB2B.NoUIModify = false;
      this.menuItemB2B.OriginalText = "";
      this.menuItemB2B.OwnerDraw = true;
      this.menuItemB2B.Text = "Data &Exchange";
      this.menuItemConfigureSetting.ImageIndex = -1;
      this.menuItemConfigureSetting.ImageList = (ImageList) null;
      this.menuItemConfigureSetting.Index = 0;
      this.menuItemConfigureSetting.NoEdit = false;
      this.menuItemConfigureSetting.NoUIModify = false;
      this.menuItemConfigureSetting.OriginalText = "";
      this.menuItemConfigureSetting.OwnerDraw = true;
      this.menuItemConfigureSetting.Text = "&Configuration";
      this.menuItemConfigureSetting.Click += new EventHandler(this.menuItemConfigureSetting_Click);
      this.menuItemMaintainTasks.ImageIndex = -1;
      this.menuItemMaintainTasks.ImageList = (ImageList) null;
      this.menuItemMaintainTasks.Index = 1;
      this.menuItemMaintainTasks.NoEdit = false;
      this.menuItemMaintainTasks.NoUIModify = false;
      this.menuItemMaintainTasks.OriginalText = "";
      this.menuItemMaintainTasks.OwnerDraw = true;
      this.menuItemMaintainTasks.Text = "&Manage Tasks";
      this.menuItemMaintainTasks.Click += new EventHandler(this.menuItemMaintainTasks_Click);
      this.menuItemSuspenseProcessing.ImageIndex = -1;
      this.menuItemSuspenseProcessing.ImageList = (ImageList) null;
      this.menuItemSuspenseProcessing.Index = 2;
      this.menuItemSuspenseProcessing.NoEdit = false;
      this.menuItemSuspenseProcessing.NoUIModify = false;
      this.menuItemSuspenseProcessing.OriginalText = "";
      this.menuItemSuspenseProcessing.OwnerDraw = true;
      this.menuItemSuspenseProcessing.Text = "&Suspense Processing";
      this.menuItemSuspenseProcessing.Click += new EventHandler(this.menuItemSuspenseProcessing_Click);
      this.menuItemTaskLog.ImageIndex = -1;
      this.menuItemTaskLog.ImageList = (ImageList) null;
      this.menuItemTaskLog.Index = 3;
      this.menuItemTaskLog.NoEdit = false;
      this.menuItemTaskLog.NoUIModify = false;
      this.menuItemTaskLog.OriginalText = "";
      this.menuItemTaskLog.OwnerDraw = true;
      this.menuItemTaskLog.Text = "&Task Log";
      this.menuItemTaskLog.Click += new EventHandler(this.menuItemTaskLog_Click);
      this.menuItemB2BStudent.ImageIndex = -1;
      this.menuItemB2BStudent.ImageList = (ImageList) null;
      this.menuItemB2BStudent.Index = 3;
      this.menuItemB2BStudent.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemSuspenseProcessing
      });
      this.menuItemB2BStudent.NoEdit = false;
      this.menuItemB2BStudent.NoUIModify = false;
      this.menuItemB2BStudent.OriginalText = "";
      this.menuItemB2BStudent.OwnerDraw = true;
      this.menuItemB2BStudent.Text = "B2B &Student";
      this.menuItemB2BPersonnel.ImageIndex = -1;
      this.menuItemB2BPersonnel.ImageList = (ImageList) null;
      this.menuItemB2BPersonnel.Index = 4;
      this.menuItemB2BPersonnel.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemB2BFieldProcessing,
        (MenuItem) this.menuItemB2BAuthoriseChanges,
        (MenuItem) this.menuItemB2BSuspension,
        (MenuItem) this.menuItemB2BImportALLEmployee,
        (MenuItem) this.menuItemB2BExportALLEmployee
      });
      this.menuItemB2BPersonnel.NoEdit = false;
      this.menuItemB2BPersonnel.NoUIModify = false;
      this.menuItemB2BPersonnel.OriginalText = "";
      this.menuItemB2BPersonnel.OwnerDraw = true;
      this.menuItemB2BPersonnel.Text = "B2B &Personnel";
      this.menuItemB2BFieldProcessing.ImageIndex = -1;
      this.menuItemB2BFieldProcessing.ImageList = (ImageList) null;
      this.menuItemB2BFieldProcessing.Index = 0;
      this.menuItemB2BFieldProcessing.NoEdit = false;
      this.menuItemB2BFieldProcessing.NoUIModify = false;
      this.menuItemB2BFieldProcessing.OriginalText = "";
      this.menuItemB2BFieldProcessing.OwnerDraw = true;
      this.menuItemB2BFieldProcessing.Text = "&Field Processing";
      this.menuItemB2BFieldProcessing.Click += new EventHandler(this.menuItemB2BFieldProcessing_Click);
      this.menuItemB2BAuthoriseChanges.ImageIndex = -1;
      this.menuItemB2BAuthoriseChanges.ImageList = (ImageList) null;
      this.menuItemB2BAuthoriseChanges.Index = 0;
      this.menuItemB2BAuthoriseChanges.NoEdit = false;
      this.menuItemB2BAuthoriseChanges.NoUIModify = false;
      this.menuItemB2BAuthoriseChanges.OriginalText = "";
      this.menuItemB2BAuthoriseChanges.OwnerDraw = true;
      this.menuItemB2BAuthoriseChanges.Text = "&Review Changes";
      this.menuItemB2BAuthoriseChanges.Click += new EventHandler(this.menuItemB2BAuthoriseChanges_Click);
      this.menuItemB2BSuspension.ImageIndex = -1;
      this.menuItemB2BSuspension.ImageList = (ImageList) null;
      this.menuItemB2BSuspension.Index = 2;
      this.menuItemB2BSuspension.NoEdit = false;
      this.menuItemB2BSuspension.NoUIModify = false;
      this.menuItemB2BSuspension.OriginalText = "";
      this.menuItemB2BSuspension.OwnerDraw = true;
      this.menuItemB2BSuspension.Text = "&Suspense Processing";
      this.menuItemB2BSuspension.Click += new EventHandler(this.menuItemB2BSuspension_Click);
      this.menuItemB2BImportALLEmployee.ImageIndex = -1;
      this.menuItemB2BImportALLEmployee.ImageList = (ImageList) null;
      this.menuItemB2BImportALLEmployee.Index = 3;
      this.menuItemB2BImportALLEmployee.NoEdit = false;
      this.menuItemB2BImportALLEmployee.NoUIModify = false;
      this.menuItemB2BImportALLEmployee.OriginalText = "";
      this.menuItemB2BImportALLEmployee.OwnerDraw = true;
      this.menuItemB2BImportALLEmployee.Text = "&Import ALL Employee Data";
      this.menuItemB2BImportALLEmployee.Click += new EventHandler(this.menuItemB2BImportALLEmployee_Click);
      this.menuItemB2BExportALLEmployee.ImageIndex = -1;
      this.menuItemB2BExportALLEmployee.ImageList = (ImageList) null;
      this.menuItemB2BExportALLEmployee.Index = 4;
      this.menuItemB2BExportALLEmployee.NoEdit = false;
      this.menuItemB2BExportALLEmployee.NoUIModify = false;
      this.menuItemB2BExportALLEmployee.OriginalText = "";
      this.menuItemB2BExportALLEmployee.OwnerDraw = true;
      this.menuItemB2BExportALLEmployee.Text = "&Export ALL Employee Data";
      this.menuItemB2BExportALLEmployee.Click += new EventHandler(this.menuItemB2BExportALLEmployee_Click);
    }

    private void rebuildB2BMenus()
    {
      string[] processNames1 = new string[4]
      {
        "Setup",
        "",
        "ImmediateTask",
        "ExportLog"
      };
      string[] processNames2 = new string[3]
      {
        "SuspenseBrowse",
        "SuspenseDetails",
        "FindNearestMatch"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemB2B, processNames1);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemConfigureSetting, "Setup");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMaintainTasks, "ImmediateTask");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSuspenseProcessing, processNames2);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemTaskLog, "ExportLog");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemB2BFieldProcessing, "B2BProcessRule");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemB2BImportALLEmployee, "ImportB2BData");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemB2BExportALLEmployee, "ExportB2BData");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemB2BAuthoriseChanges, new string[2]
      {
        "EditAuthorisation",
        "BrowseAuthorisation"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemB2BSuspension, new string[2]
      {
        "BrowseSuspense",
        "EditSuspense"
      });
    }

    private void customiseB2BMenus()
    {
    }

    private void menuItemConfigureSetting_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new BBSetup());
    }

    private void menuItemMaintainTasks_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainTaskInformation());
    }

    private void menuItemTaskLog_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainExportTaskLog());
    }

    private void menuItemSuspenseProcessing_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainSuspense());
    }

    private void menuItemB2BFieldProcessing_Click(object sender, EventArgs e)
    {
      if (!SIMS.Entities.Cache.EnableB2B)
      {
        int num = (int) MessageBox.Show((IWin32Window) this.ParentForm, "B2B:Personnel has not been activated.", "B2B:Personnel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
      }
      else
        this.DisplayComponent((Control) new MaintainB2BProcessRuleInformation());
    }

    private void menuItemB2BAuthoriseChanges_Click(object sender, EventArgs e)
    {
      if (!SIMS.Entities.Cache.EnableB2B)
      {
        int num = (int) MessageBox.Show((IWin32Window) this.ParentForm, "B2B:Personnel has not been activated.", "B2B:Personnel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
      }
      else
        this.DisplayComponent((Control) new MaintainB2BAuthoriseDataInformation());
    }

    private void menuItemB2BSuspension_Click(object sender, EventArgs e)
    {
      if (!SIMS.Entities.Cache.EnableB2B)
      {
        int num = (int) MessageBox.Show((IWin32Window) this.ParentForm, "B2B:Personnel has not been activated.", "B2B:Personnel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
      }
      else
        this.DisplayComponent((Control) new MaintainB2BSuspensionInformation());
    }

    private void menuItemB2BExportALLEmployee_Click(object sender, EventArgs e)
    {
      if (!SIMS.Entities.Cache.EnableB2B)
      {
        int num1 = (int) MessageBox.Show((IWin32Window) this.ParentForm, "B2B:Personnel has not been activated.", "B2B:Personnel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
      }
      else
      {
        int num2 = (int) new ExportAllEmployeeDialog().ShowDialog();
      }
    }

    private void menuItemB2BImportALLEmployee_Click(object sender, EventArgs e)
    {
      if (!SIMS.Entities.Cache.EnableB2B)
      {
        int num1 = (int) MessageBox.Show((IWin32Window) this.ParentForm, "B2B:Personnel has not been activated.", "B2B:Personnel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
      }
      else
      {
        int num2 = (int) new ImportAllEmployeeDialog().ShowDialog();
      }
    }

    private void initCTFMenus()
    {
      this.menuItemRunCTFExport = new UIMenuItem();
      this.menuItemCTFExportLog = new UIMenuItem();
      this.menuItemCTFImport = new UIMenuItem();
      this.menuItemCTFImportLog = new UIMenuItem();
      this.menuItemCTFout.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemRunCTFExport,
        (MenuItem) this.menuItemCTFExportLog
      });
      this.menuItemCTFin.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemCTFImport,
        (MenuItem) this.menuItemCTFImportLog
      });
      this.menuItemRunCTFExport.ImageIndex = -1;
      this.menuItemRunCTFExport.ImageList = (ImageList) null;
      this.menuItemRunCTFExport.Index = 0;
      this.menuItemRunCTFExport.NoEdit = false;
      this.menuItemRunCTFExport.NoUIModify = false;
      this.menuItemRunCTFExport.OriginalText = "";
      this.menuItemRunCTFExport.OwnerDraw = true;
      this.menuItemRunCTFExport.Text = "&Export CTF";
      this.menuItemRunCTFExport.Click += new EventHandler(this.menuItemRunCTFExport_Click);
      this.menuItemCTFExportLog.ImageIndex = -1;
      this.menuItemCTFExportLog.ImageList = (ImageList) null;
      this.menuItemCTFExportLog.Index = 1;
      this.menuItemCTFExportLog.NoEdit = false;
      this.menuItemCTFExportLog.NoUIModify = false;
      this.menuItemCTFExportLog.OriginalText = "";
      this.menuItemCTFExportLog.OwnerDraw = true;
      this.menuItemCTFExportLog.Text = "View E&xport History Log";
      this.menuItemCTFExportLog.Click += new EventHandler(this.menuItemCTFExportLog_Click);
      this.menuItemCTFImport.ImageIndex = -1;
      this.menuItemCTFImport.ImageList = (ImageList) null;
      this.menuItemCTFImport.Index = 0;
      this.menuItemCTFImport.NoEdit = false;
      this.menuItemCTFImport.NoUIModify = false;
      this.menuItemCTFImport.OriginalText = "";
      this.menuItemCTFImport.OwnerDraw = true;
      this.menuItemCTFImport.Text = "&Import CTF";
      this.menuItemCTFImport.Click += new EventHandler(this.menuItemCTFImport_Click);
      this.menuItemCTFImportLog.ImageIndex = -1;
      this.menuItemCTFImportLog.ImageList = (ImageList) null;
      this.menuItemCTFImportLog.Index = 1;
      this.menuItemCTFImportLog.NoEdit = false;
      this.menuItemCTFImportLog.NoUIModify = false;
      this.menuItemCTFImportLog.OriginalText = "";
      this.menuItemCTFImportLog.OwnerDraw = true;
      this.menuItemCTFImportLog.Text = "View Import &History Log";
      this.menuItemCTFImportLog.Click += new EventHandler(this.menuItemCTFImportLog_Click);
      this.menuItemCTFSetup.Click += new EventHandler(this.menuItemCTFSetup_Click);
    }

    private void rebuildCTFMenus()
    {
      string[] processNames1 = new string[2]
      {
        "BrowseCTFLog",
        "DetailCTFLog"
      };
      string[] processNames2 = new string[3]
      {
        "CTFImportLog",
        "CTFReportFormatter",
        "CTFPrintDocument"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemRunCTFExport, new string[2]
      {
        "CTFExport",
        "CTFPrintDocument"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCTFSetup, "CTFConfiguration");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCTFExportLog, processNames1);
      this.menuItemCTFImport.Visible = (SIMS.Entities.Cache.ProcessVisible("CTFAutoImport") || SIMS.Entities.Cache.ProcessVisible("CTFImport")) && SIMS.Entities.Cache.ProcessVisible("CTFPrintDocument");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCTFImportLog, processNames2);
    }

    private void customiseCTFMenus()
    {
      if (SIMS.Entities.Cache.ProcessVisible("CTFAutoImport") && !SIMS.Entities.Cache.ProcessVisible("CTFImport"))
      {
        this.menuItemCTFImport.Text = "&Import data from external system via CTF";
      }
      else
      {
        if (!SystemConfigurationCache.IsIndependentSchool)
          return;
        this.menuItemCTFImport.Text = "&Import Applicants from CTF";
      }
    }

    private void menuItemCTFExportLog_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CTFExportLogBrowserDetail());
    }

    private void menuItemRunCTFExport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      CTFSelectMenu ctfSelectMenu = new CTFSelectMenu("export");
      int num = (int) ctfSelectMenu.ShowDialog();
      if (ctfSelectMenu.IsWindowClosed)
        return;
      this.DisplayComponent((Control) new CTFExport(ctfSelectMenu.CTFSelectedTypeCode, ctfSelectMenu.CTFSelectedTypeDescription));
    }

    private void menuItemCTFSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CTFConfiguration());
    }

    private void menuItemCTFImport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      CTFSelectMenu ctfSelectMenu = new CTFSelectMenu("import");
      int num = (int) ctfSelectMenu.ShowDialog();
      if (ctfSelectMenu.IsWindowClosed)
        return;
      CTFImportDetail ctfImportDetail = new CTFImportDetail(ctfSelectMenu.CTFSelectedTypeCode, ctfSelectMenu.CTFSelectedTypeDescription);
      ctfImportDetail.NavigateToBrowsers += new EventHandler(this.ctfImportDetail_NavigateToBrowsers);
      this.DisplayComponent((Control) ctfImportDetail);
    }

    private void ctfImportDetail_NavigateToBrowsers(object sender, EventArgs e)
    {
      int int32 = Convert.ToInt32(sender.ToString());
      if (int32 <= 0)
        return;
      if (6 == int32)
        this.menuItemApplication.PerformClick();
      else
        this.MenuItemStudentEdit.PerformClick();
    }

    private void menuItemCTFImportLog_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CTFImportLogBrowser());
    }

    private void ContextSchools(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      MaintainExternalSchool maintainExternalSchool = new MaintainExternalSchool();
      maintainExternalSchool.Disposed += new EventHandler(this.ctfLinkComponentDisposed);
      this.DisplayComponent((Control) maintainExternalSchool);
    }

    private void ctfLinkComponentDisposed(object obj, EventArgs args)
    {
      SIMS.Entities.CTFExportCache.Initialised = false;
      SIMS.Processes.CTFExportCache.Populate();
      CTFExport.CacheUpdated = true;
    }

    private void ContextImportCTF(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
    }

    private void ContextCTF(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
    }

    private void initPlascMenus()
    {
      this.menuItemPlasc.Click += new EventHandler(this.menuItemPlasc_Click);
      this.menuItemUpdatePLASCClassType = new UIMenuItem();
      this.menuItemUpdateHoursAtSetting = new UIMenuItem();
      this.menuItemUpdateTopupFunding = new UIMenuItem();
      this.menuItemAdoptedFromCare = new UIMenuItem();
      this.menuItemPriorAttainment = new UIMenuItem();
      this.menuItemUpdateTimeInUnit = new UIMenuItem();
      this.menuItemUpdateProviderStatus = new UIMenuItem();
      this.menuItemAuthorisedCensus = new UIMenuItem();
      this.menuItemPlascBasicSkills = new UIMenuItem();
      this.menuItemPLASCTools.MenuItems.AddRange(new MenuItem[8]
      {
        (MenuItem) this.menuItemUpdatePLASCClassType,
        (MenuItem) this.menuItemPlascBasicSkills,
        (MenuItem) this.menuItemUpdateCourseClassification,
        (MenuItem) this.menuItemUpdateHoursAtSetting,
        (MenuItem) this.menuItemUpdateTopupFunding,
        (MenuItem) this.menuItemAdoptedFromCare,
        (MenuItem) this.menuItemPriorAttainment,
        (MenuItem) this.menuItemAuthorisedCensus
      });
      this.menuItemUpdatePLASCClassType.Text = "&Update Class Type";
      this.menuItemUpdatePLASCClassType.Click += new EventHandler(this.menuItemUpdatePLASCClassType_Click);
      this.menuItemPlascBasicSkills.Text = "&Fill Basic Skills Data";
      this.menuItemPlascBasicSkills.Click += new EventHandler(this.menuItemPlascBasicSkills_Click);
      this.menuItemUpdateCourseClassification.Text = "Update &Course Classification from Examinations Data";
      this.menuItemUpdateCourseClassification.Click += new EventHandler(this.menuItemUpdateCourseClassification_Click);
      this.menuItemImportQansForCM.Text = "Update &QANs and Discount Codes for Course Manager";
      this.menuItemImportQansForCM.Click += new EventHandler(this.menuItemImportQans_Click);
      this.menuItemDuplicateQANReport.Text = "Duplicate QAN Report";
      this.menuItemDuplicateQANReport.Click += new EventHandler(this.menuItemDuplicateQANReport_Click);
      this.menuItemImportQWADForCM.Text = "Update Q&WADs for Course Manager";
      this.menuItemImportQWADForCM.Click += new EventHandler(this.menuItemImportQWADForCM_Click);
      this.menuItemUpdateHoursAtSetting.Text = "Update &Early Years";
      this.menuItemUpdateHoursAtSetting.Click += new EventHandler(this.menuItemUpdateHoursAtSetting_Click);
      this.menuItemUpdateTopupFunding.Visible = false;
      this.menuItemUpdateTopupFunding.Text = "Update &Top-up Funding";
      this.menuItemUpdateTopupFunding.Click += new EventHandler(this.menuItemUpdateTopupFunding_Click);
      this.menuItemAdoptedFromCare.Visible = false;
      this.menuItemAdoptedFromCare.Text = "Update Post &Looked After Arrangements";
      this.menuItemAdoptedFromCare.Click += new EventHandler(this.menuItemAdoptedFromCare_Click);
      this.menuItemPriorAttainment.Visible = false;
      this.menuItemPriorAttainment.Text = "Update &Prior Attainment";
      this.menuItemPriorAttainment.Click += new EventHandler(this.menuItemPriorAttainment_Click);
      this.menuItemReconcileExamLA.Text = "&Reconcile Post-16 Course && Exam Results";
      this.menuItemReconcileExamLA.Click += new EventHandler(this.menuItemReconcileExamLA_Click);
      this.menuItemReconcileExamEntries.Text = "&Reconcile Post-16 Course && Exam Entries";
      this.menuItemReconcileExamEntries.Click += new EventHandler(this.menuItemReconcileExamEntries_Click);
      this.menuItemUpdateTimeInUnit.Text = "Update &Time in Unit";
      this.menuItemUpdateTimeInUnit.Click += new EventHandler(this.menuItemUpdateTimeInUnit_Click);
      this.menuItemUpdateProviderStatus.Text = "Update &Provider Status";
      this.menuItemUpdateProviderStatus.Click += new EventHandler(this.menuItemUpdateProviderStatus_Click);
      this.menuItemAuthorisedCensus.Text = "&Retrieve Authorised Census Return Files";
      this.menuItemAuthorisedCensus.Click += new EventHandler(this.menuItemAuthorisedCensus_Click);
    }

    private void rebuildPlascMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPlasc, new string[2]
      {
        "PLASCBrowser",
        "PLASCDetails"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPlascBasicSkills, "PLASCBasicSkills");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemELWAPlascDefaults, "ELWAConfigureDefault");
      this.menuItemUpdatePLASCClassType.Visible = SIMS.Entities.Cache.ProcessVisible("EditStudentPLASCClassType");
      PLASCEntity.EnumPLASCFlavour plascFlavourId = (PLASCEntity.EnumPLASCFlavour) SIMS.Entities.Cache.CurrentSchool.PLASCFlavourId;
      if (plascFlavourId == PLASCEntity.EnumPLASCFlavour.WelshSpecial || plascFlavourId == PLASCEntity.EnumPLASCFlavour.WelshMiddle || plascFlavourId == PLASCEntity.EnumPLASCFlavour.WelshSecondary)
        this.menuItemPlascBasicSkills.Visible = false;
      if (plascFlavourId != PLASCEntity.EnumPLASCFlavour.WelshNursery && plascFlavourId != PLASCEntity.EnumPLASCFlavour.WelshPrimary && (plascFlavourId != PLASCEntity.EnumPLASCFlavour.WelshSecondary && plascFlavourId != PLASCEntity.EnumPLASCFlavour.WelshMiddle) && (plascFlavourId != PLASCEntity.EnumPLASCFlavour.WelshSpecial && plascFlavourId != PLASCEntity.EnumPLASCFlavour.EnglishNursery && (plascFlavourId != PLASCEntity.EnumPLASCFlavour.EnglishMiddleDeemedPrimary && plascFlavourId != PLASCEntity.EnumPLASCFlavour.EnglishMiddleDeemedSecondary)))
        return;
      this.menuItemUpdatePLASCClassType.Visible = false;
    }

    private void menuItemUpdatePLASCClassType_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EditStudentClassType());
    }

    private void menuItemUpdateHoursAtSetting_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EditStudentUpdatHoursAtSetting());
    }

    private void menuItemUpdateTopupFunding_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      SIMS.Processes.CensusCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CensusUpdateTopupFunding());
    }

    private void menuItemAdoptedFromCare_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      SIMS.Processes.CensusCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CensusUpdateAdoptedFromCare());
    }

    private void menuItemPriorAttainment_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      SIMS.Processes.CensusCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CensusUpdatePriorAttainment());
    }

    private void menuItemUpdateTimeInUnit_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EditStudentTimeInUnit());
    }

    private void menuItemAuthorisedCensus_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PreviousCensusBrowser());
    }

    private void menuItemUpdateProviderStatus_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EditStudentProviderStatus());
    }

    private void doPLASCThread()
    {
      SIMS.Processes.PLASCCache.Populate();
    }

    private void doELWAThread()
    {
      SIMS.Processes.PLASCCache.Populate();
      SIMS.Processes.ELWACache.Populate(System.Windows.Forms.Application.StartupPath);
    }

    private void menuItemPlasc_Click(object sender, EventArgs e)
    {
      if (!this.plascloaded)
      {
        InvokeProgressBarDelegate progressBarDelegate = new InvokeProgressBarDelegate(this.doPLASCThread);
        PLASCStatusLoad plascStatusLoad = new PLASCStatusLoad();
        try
        {
          plascStatusLoad.Owner = (System.Windows.Forms.Form) this;
          this.Enabled = false;
          plascStatusLoad.Show();
          this.plascloaded = plascStatusLoad.DisplayValidationProgressBar(progressBarDelegate);
        }
        finally
        {
          this.Enabled = true;
          plascStatusLoad.Owner = (System.Windows.Forms.Form) null;
          plascStatusLoad.Dispose();
        }
      }
      this.recordMenuUsage(sender as UIMenuItem);
      if (SIMS.Entities.PLASCCache.PlascOutbox != "" && Directory.Exists(SIMS.Entities.PLASCCache.PlascOutbox))
      {
        this.DisplayComponent((Control) new PLASCBrowserDetail());
      }
      else
      {
        int num = (int) MessageBox.Show("Please use Tools | Statutory Return Tools | Folder Names and Security Message to setup a suitable folder for this statutory return.\nPlease ensure that authorised personnel only have access to this folder as it will contain sensitive data", "PLASC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void menuItemPlascBasicSkills_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PLASCEditBasicSkills());
    }

    private void setupPlascContextMenu()
    {
      if (SIMS.Entities.Cache.ProcessAvailable("EditStudentInformation"))
        NavigationRouteCache.AddRoute("Student Details", new NavigationRouteDelegate(this.ContextStudentReturn), new int[1]
        {
          41
        }, typeof (EditStudent), 41);
      if (SIMS.Entities.Cache.ProcessVisible("ViewSENStudent"))
        NavigationRouteCache.AddRoute("SEN", new NavigationRouteDelegate(this.ContextSENOverview), new int[1]
        {
          42
        }, typeof (EditSENStudent), 42);
      if (SIMS.Entities.Cache.ProcessAvailable("ViewExclusionDetails"))
        NavigationRouteCache.AddRoute(SIMS.Entities.Cache.UserInterfaceLabel("Exclusions"), new NavigationRouteDelegate(this.ContextExclusions), new int[1]
        {
          43
        }, typeof (ExclusionDetails), 43);
      if (SIMS.Entities.Cache.ProcessAvailable("EditStudentPLASCClassType"))
        NavigationRouteCache.AddRoute("ClassType", new NavigationRouteDelegate(this.ContextClassType), new int[1]
        {
          48
        }, typeof (EditStudentClassType), 48);
      if (SIMS.Entities.Cache.ProcessAvailable("EditStudentUpdateFundedHours"))
        NavigationRouteCache.AddRoute("Update Early Years", new NavigationRouteDelegate(this.ContextUpdateHoursAtSetting), new int[1]
        {
          67
        }, typeof (EditStudentUpdatHoursAtSetting), 67);
      if (SIMS.Entities.Cache.ProcessAvailable("PLASCBasicSkills"))
        NavigationRouteCache.AddRoute("BasicSkills", new NavigationRouteDelegate(this.ContextBasicSkills), new int[1]
        {
          57
        }, typeof (PLASCEditBasicSkills), 57);
      if (SIMS.Entities.Cache.ProcessAvailable("EditStudentTimeInUnit"))
        NavigationRouteCache.AddRoute("TimeinUnit", new NavigationRouteDelegate(this.ContextTimeInUnit), new int[1]
        {
          71
        }, typeof (EditStudentTimeInUnit), 71);
      if (!SIMS.Entities.Cache.ProcessAvailable("EditStudentProviderStatus"))
        return;
      NavigationRouteCache.AddRoute("ProviderStatus", new NavigationRouteDelegate(this.ContextProviderStatus), new int[1]
      {
        72
      }, typeof (EditStudentProviderStatus), 72);
    }

    private void ContextStudentReturn(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      SIMS.Processes.PLASCCache.Populate();
      EditStudent editStudent = new EditStudent(entityToDisplay);
      this.ShowContextControl((BasicDetailControl) editStudent, showAsIndependentWindow);
      editStudent.NavigateToPanel(entityToDisplay.Description);
    }

    private void ContextTeachersView(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      TeacherViewStudentDetail viewStudentDetail = new TeacherViewStudentDetail(entityToDisplay);
      this.ShowContextControl((BasicDetailControl) viewStudentDetail, showAsIndependentWindow);
      viewStudentDetail.BringToFront();
    }

    private void ContextPPODStudentView(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      Cursor.Current = Cursors.WaitCursor;
      int studentId = entityToDisplay is DetailedApplication ? ((DetailedApplication) entityToDisplay).PersonID : entityToDisplay.ID;
      ViewStudentPpodData viewStudentPpodData = new ViewStudentPpodData();
      if (viewStudentPpodData.DisplayStudentReport(studentId))
      {
        new DlgPPODReport(viewStudentPpodData.StudentReport, "PPOD Student Details").Show();
      }
      else
      {
        Cursor.Current = Cursors.Default;
        int num = (int) MessageBox.Show("PPOD details do not exist for this " + SIMS.Entities.Cache.UserInterfaceLabel("student"), SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      Cursor.Current = Cursors.Default;
    }

    private void ContextPPODSchoolDetailsView(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      ViewSchoolPpodData viewSchoolPpodData = new ViewSchoolPpodData();
      if (viewSchoolPpodData.DisplaySchoolReport(entityToDisplay.ID))
        new DlgPPODReport(viewSchoolPpodData.SchoolReport, "PPOD School Details").Show();
      else
        SIMS.Entities.Cache.StatusMessage("PPOD details do not exist", UserMessageEventEnum.Information);
    }

    private void ContextStudentCoursesDetail(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      if (entityToDisplay != null)
      {
        SIMS.Processes.PLASCCache.Populate();
        this.ShowContextControl(entityToDisplay, (BasicDetailControl) new StudentCoursesDetail(entityToDisplay), false);
      }
      else
        SIMS.Entities.Cache.StatusMessage("No student selected.", UserMessageEventEnum.Information);
    }

    private void ContextTier4Details(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (entityToDisplay == null)
        return;
      Cursor.Current = Cursors.WaitCursor;
      int personId = entityToDisplay is DetailedApplication ? ((DetailedApplication) entityToDisplay).PersonID : entityToDisplay.ID;
      EditStudentNationalityProcess process = new EditStudentNationalityProcess();
      bool flag = process.LoadTier4(personId);
      Cursor.Current = Cursors.Default;
      if (!flag && (process.ReadOnly || !process.EditingPermitted))
      {
        int num = (int) MessageBox.Show("There are no Tier 4 details for this " + SIMS.Entities.Cache.UserInterfaceLabel("student"), SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
        this.ShowContextControl(entityToDisplay, (BasicDetailControl) new StudentTier4Detail(process), false);
    }

    private void initCESEWCensusMenus()
    {
      this.menuItemSchoolsCESEWReturn = new UIMenuItem();
      this.menuItemSchoolsCESEWReturn.Text = "Schools C&ES Census";
      this.menuItemSchoolsCESEWReturn.Click += new EventHandler(this.menuItemSchoolsCESEWReturn_Click);
      this.menuItemStatutoryReturns.MenuItems.AddRange((MenuItem[]) new UIMenuItem[1]
      {
        this.menuItemSchoolsCESEWReturn
      });
      this.menuItemCESEWLookups = new UIMenuItem();
      this.menuItemCESEWLookups.Text = "Update &CES Census Lookups";
      this.menuItemCESEWLookups.Click += new EventHandler(this.menuItemCESEWLookups_Click);
      this.menuItemPLASCTools.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemCESEWLookups
      });
    }

    private void initSchoolWorkforceCensusDefaultMenu()
    {
      this.menuItemPLASCTools.MenuItems.AddRange((MenuItem[]) new UIMenuItem[1]
      {
        this.menuItemSchoolsWorkforceReturnDefaults
      });
    }

    private void initReconcileExamResultsMenu()
    {
      if (!(SystemConfigurationCache.LocaleCode == "ENG"))
        return;
      this.menuItemPLASCTools.MenuItems.AddRange((MenuItem[]) new UIMenuItem[1]
      {
        this.menuItemReconcileExamLA
      });
    }

    private void initReconcileExamEntriesMenu()
    {
      if (!(SystemConfigurationCache.LocaleCode == "ENG"))
        return;
      this.menuItemPLASCTools.MenuItems.AddRange((MenuItem[]) new UIMenuItem[1]
      {
        this.menuItemReconcileExamEntries
      });
    }

    private void initPRUMenu()
    {
      if (!(SystemConfigurationCache.LocaleCode == "ENG") || !SystemConfigurationCache.IsDeemedToBePRU)
        return;
      this.menuItemPLASCTools.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemUpdateTimeInUnit,
        (MenuItem) this.menuItemUpdateProviderStatus
      });
    }

    private void initSchoolCensusMenus()
    {
      this.menuItemSchoolCensus = new UIMenuItem();
      this.menuItemSchoolCensus.Text = "School &Census";
      this.menuItemSchoolCensus.Click += new EventHandler(this.menuItemSchoolCensus_Click);
      this.menuItemSchoolsWorkforceReturn = new UIMenuItem();
      this.menuItemSchoolsWorkforceReturn.Text = "School &Workforce Census";
      this.menuItemSchoolsWorkforceReturn.Click += new EventHandler(this.menuItemSchoolsWorkforceReturn_Click);
      this.menuItemSchoolsWorkforceReturnDefaults = new UIMenuItem();
      this.menuItemSchoolsWorkforceReturnDefaults.Text = "School Workforce Census &Settings";
      this.menuItemSchoolsWorkforceReturnDefaults.Click += new EventHandler(this.menuItemSchoolsWorkforceReturnDefaults_Click);
      this.menuItemStatutoryReturns.MenuItems.AddRange((MenuItem[]) new UIMenuItem[2]
      {
        this.menuItemSchoolCensus,
        this.menuItemSchoolsWorkforceReturn
      });
    }

    private void initPupilPremiumMenus()
    {
      if (!(SystemConfigurationCache.LocaleCode == "ENG") || !(SystemConfigurationCache.EditionCode != "INDPRIM") || (!(SystemConfigurationCache.EditionCode != "INDSEC") || !(SystemConfigurationCache.EditionCode != "INDSPEC")))
        return;
      this.toolsMenu.MenuItems.Add(this.menuItem12.Index - 1, (MenuItem) this.menuItemPupilPremium);
      this.menuItemPupilPremiumImport = new UIMenuItem();
      this.menuItemPupilPremiumImport.Text = "Import";
      this.menuItemPupilPremiumImport.Click += new EventHandler(this.menuItemPupilPremiumImport_Click);
      this.menuItemPupilPremiumMaintain = new UIMenuItem();
      this.menuItemPupilPremiumMaintain.Text = "Maintain";
      this.menuItemPupilPremiumMaintain.Click += new EventHandler(this.menuItemPupilPremiumMaintain_Click);
      this.menuItemPupilPremium.MenuItems.AddRange((MenuItem[]) new UIMenuItem[2]
      {
        this.menuItemPupilPremiumImport,
        this.menuItemPupilPremiumMaintain
      });
    }

    private void rebuildCESEWMenus()
    {
      string[] processNames = new string[2]
      {
        "CESEWBrowser",
        "CESEWDetail"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSchoolsCESEWReturn, processNames);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCESEWLookups, processNames);
    }

    private void rebuildSchoolCensusMenus()
    {
      PLASCEntity.EnumPLASCFlavour plascFlavourId = (PLASCEntity.EnumPLASCFlavour) SIMS.Entities.Cache.CurrentSchool.PLASCFlavourId;
      bool flag;
      switch (plascFlavourId)
      {
        case PLASCEntity.EnumPLASCFlavour.EnglishNursery:
        case PLASCEntity.EnumPLASCFlavour.EnglishPrimary:
        case PLASCEntity.EnumPLASCFlavour.EnglishMiddleDeemedPrimary:
        case PLASCEntity.EnumPLASCFlavour.EnglishMiddleDeemedSecondary:
        case PLASCEntity.EnumPLASCFlavour.EnglishSecondary:
        case PLASCEntity.EnumPLASCFlavour.EnglishSpecial:
          flag = true;
          this.menuItemUpdateHoursAtSetting.Visible = SIMS.Entities.Cache.ProcessVisible("EditStudentUpdateFundedHours");
          try
          {
            if (new SIMS.Processes.CensusDetailEngAT().GetEarlyYearsStudentsCount() == 0)
              this.menuItemUpdateHoursAtSetting.Visible = false;
          }
          catch
          {
            this.menuItemUpdateHoursAtSetting.Visible = false;
          }
          this.menuItemAdoptedFromCare.Visible = SIMS.Entities.Cache.ProcessVisible("CensusAdoptedFromcare");
          this.menuItemUpdateTopupFunding.Visible = SIMS.Entities.Cache.ProcessVisible("CensusTopupFunding");
          this.menuItemPlasc.Visible = false;
          this.menuItemELWAPlascDefaults.Visible = false;
          this.menuItemPlascBasicSkills.Visible = false;
          if (plascFlavourId != PLASCEntity.EnumPLASCFlavour.EnglishPrimary && plascFlavourId != PLASCEntity.EnumPLASCFlavour.EnglishAllThrough)
            this.menuItemUpdatePLASCClassType.Visible = false;
          this.menuItemPost16Autumn.Visible = false;
          this.menuItemPost16Summer.Visible = false;
          if (plascFlavourId == PLASCEntity.EnumPLASCFlavour.EnglishSecondary || plascFlavourId == PLASCEntity.EnumPLASCFlavour.EnglishAllThrough || SystemConfigurationCache.IsDeemedToBePRU)
          {
            this.menuItemPriorAttainment.Visible = SIMS.Entities.Cache.ProcessVisible("CensusPriorAttainment");
            break;
          }
          break;
        case PLASCEntity.EnumPLASCFlavour.EnglishAllThrough:
          if (!(SystemConfigurationCache.ExtendedRegionCode.ToUpper() != "EIR") || !(SystemConfigurationCache.ExtendedRegionCode.ToUpper() != "IND"))
            goto default;
          else
            goto case PLASCEntity.EnumPLASCFlavour.EnglishNursery;
        default:
          this.menuItemUpdateHoursAtSetting.Visible = false;
          flag = false;
          break;
      }
      if (plascFlavourId == (PLASCEntity.EnumPLASCFlavour) 0)
      {
        this.menuItemPlasc.Visible = false;
        this.menuItemELWAPlascDefaults.Visible = false;
        this.menuItemPlascBasicSkills.Visible = false;
        this.menuItemPost16Autumn.Visible = false;
        this.menuItemPost16Summer.Visible = false;
        this.menuItemUpdatePLASCClassType.Visible = false;
      }
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSchoolsWorkforceReturn, new string[3]
      {
        "Personnel_Full",
        "WorkforceBrowser",
        "WorkforceDetail"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSchoolsWorkforceReturnDefaults, new string[2]
      {
        "Personnel_Full",
        "WorkforceReturnFileSetting"
      });
      string[] processNames = new string[2]
      {
        "PLASCBrowser",
        "PLASCDetails"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSchoolCensus, processNames);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUpdateCourseClassification, processNames);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemImportQansForCM, processNames);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemDuplicateQANReport, processNames);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemImportQWADForCM, processNames);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemStudentCourses, "ViewCourse");
      this.menuItemUpdateCourseClassification.Visible = false;
      if (plascFlavourId != PLASCEntity.EnumPLASCFlavour.EnglishSecondary && plascFlavourId != PLASCEntity.EnumPLASCFlavour.WelshSecondary && (plascFlavourId != PLASCEntity.EnumPLASCFlavour.WelshMiddle && plascFlavourId != PLASCEntity.EnumPLASCFlavour.NIExams) && plascFlavourId != PLASCEntity.EnumPLASCFlavour.EnglishSpecial)
      {
        this.menuItemImportQansForCM.Visible = false;
        this.menuItemDuplicateQANReport.Visible = false;
      }
      this.menuItemImportQansForCM.Visible = SIMS.Entities.Cache.ProcessVisible("LaunchExamsOrganiser") && SIMS.Entities.Cache.ProcessVisible("UpdateQANCatalogue");
      this.menuItemDuplicateQANReport.Visible = SIMS.Entities.Cache.ProcessVisible("LaunchExamsOrganiser") && SIMS.Entities.Cache.ProcessVisible("UpdateQANCatalogue");
      if (!this.menuItemImportQansForCM.Visible)
        this.menuItemImportQansForCM.Visible = SIMS.Entities.Cache.ProcessVisible("ManageCourse");
      if (!this.menuItemDuplicateQANReport.Visible)
        this.menuItemDuplicateQANReport.Visible = SIMS.Entities.Cache.ProcessVisible("ManageCourse");
      this.menuItemImportQWADForCM.Visible = SIMS.Entities.Cache.ProcessVisible("LaunchExamsOrganiser");
      if (!this.menuItemImportQWADForCM.Visible)
        this.menuItemImportQWADForCM.Visible = SIMS.Entities.Cache.ProcessVisible("ManageCourse");
      if (plascFlavourId != PLASCEntity.EnumPLASCFlavour.WelshSecondary && plascFlavourId != PLASCEntity.EnumPLASCFlavour.WelshMiddle)
        this.menuItemImportQWADForCM.Visible = false;
      this.menuItemSchoolCensus.Visible = flag && this.menuItemSchoolCensus.Visible;
      this.menuItemSchoolsWorkforceReturn.Visible = flag && this.menuItemSchoolsWorkforceReturn.Visible;
      this.menuItemSchoolsWorkforceReturnDefaults.Visible = flag && this.menuItemSchoolsWorkforceReturnDefaults.Visible;
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemReconcileExamLA, "ViewReconcileLearningAimsAndResults");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemReconcileExamEntries, "ViewReconcileLearningAimsAndResults");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUpdateTimeInUnit, "EditStudentTimeInUnit");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUpdateProviderStatus, "EditStudentProviderStatus");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAuthorisedCensus, new string[2]
      {
        "AuthorisedCensusReturns",
        "PLASCBrowser"
      });
    }

    private void doCensusThread()
    {
      SIMS.Processes.PLASCCache.Populate();
      SIMS.Processes.CensusCache.Populate();
    }

    private void doSWCThread()
    {
      SIMS.Processes.PLASCCache.Populate();
      WorkforceLookupData.Populate();
    }

    private void censusFileLoad()
    {
      if (!this.m_SchoolCensusLoaded)
      {
        InvokeProgressBarDelegate progressBarDelegate = new InvokeProgressBarDelegate(this.doCensusThread);
        PLASCStatusLoad plascStatusLoad = new PLASCStatusLoad();
        plascStatusLoad.Text = "Census Loading...";
        plascStatusLoad.InfoValidationProcess = "Census files are being loaded...";
        try
        {
          plascStatusLoad.Owner = (System.Windows.Forms.Form) this;
          this.Enabled = false;
          plascStatusLoad.Show();
          this.m_SchoolCensusLoaded = plascStatusLoad.DisplayValidationProgressBar(progressBarDelegate);
        }
        finally
        {
          this.Enabled = true;
          plascStatusLoad.Owner = (System.Windows.Forms.Form) null;
          plascStatusLoad.Dispose();
        }
      }
      if (!string.IsNullOrEmpty(SIMS.Processes.PLASCCache.FileSetVersionErrorDescription) && !SIMS.Processes.PLASCCache.FileSetVersionErrorDescription.Contains("fileset number is too low"))
      {
        int num = (int) MessageBox.Show(SIMS.Processes.PLASCCache.FileSetVersionErrorDescription, "School Census", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      this.DisplayComponent((Control) new CensusBrowserDetail());
    }

    private void menuItemSchoolCensus_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      SIMS.Entities.CensusCache.is_PRU_Census = false;
      this.censusFileLoad();
    }

    private void menuItemPupilPremiumImport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ImportPupilPremium());
    }

    private void menuItemPupilPremiumMaintain_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainPupilPremium());
    }

    private void menuItemSchoolsWorkforceReturn_Click(object sender, EventArgs e)
    {
      if (!this.m_SWCLoaded)
      {
        PLASCStatusLoad plascStatusLoad = new PLASCStatusLoad();
        try
        {
          InvokeProgressBarDelegate progressBarDelegate = new InvokeProgressBarDelegate(this.doSWCThread);
          plascStatusLoad.Text = "SWC Loading...";
          plascStatusLoad.InfoValidationProcess = "SWC files are being loaded...";
          plascStatusLoad.Owner = (System.Windows.Forms.Form) this;
          this.Enabled = false;
          plascStatusLoad.Show();
          this.m_SWCLoaded = plascStatusLoad.DisplayValidationProgressBar(progressBarDelegate);
        }
        finally
        {
          this.Enabled = true;
          plascStatusLoad.Owner = (System.Windows.Forms.Form) null;
          plascStatusLoad.Dispose();
        }
      }
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new WorkforceBrowserDetail());
      if (!(WorkforceDetail.FileSetVersionErrorDescription != string.Empty) || WorkforceDetail.FileSetVersionErrorDescription.Contains("fileset number is too low"))
        return;
      int num = (int) MessageBox.Show(WorkforceDetail.FileSetVersionErrorDescription, "School Workforce Census", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }

    private void menuItemSchoolsCESEWReturn_Click(object sender, EventArgs e)
    {
      SIMS.Processes.CESEWCache.Populate();
      if (SIMS.Entities.CESEWCache.Region == "Wales" && (SIMS.Entities.CESEWCache.CESEWOutbox.Length == 0 || !Directory.Exists(SIMS.Entities.CESEWCache.CESEWOutbox)))
      {
        int num = (int) MessageBox.Show("Please use Tools | Statutory Return Tools | Folder Names and Security Message to setup a suitable folder for this statutory return.\nPlease ensure that authorised personnel only have access to this folder as it will contain sensitive data", SIMS.Entities.CESEWCache.CESEW_MESSAGE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        this.recordMenuUsage(sender as UIMenuItem);
        this.DisplayComponent((Control) new CESEWBrowserDetail());
      }
    }

    private void doAttendanceCollectionThread()
    {
      SIMS.Processes.PLASCCache.Populate();
      if (this.attendanceReturnRunMode == 1 || this.attendanceReturnRunMode == 2)
        SIMS.Processes.AttRetLookupData.UpdateLookupIFMiddle(this.attendanceReturnRunMode);
      SIMS.Processes.AttRetLookupData.Populate(System.Windows.Forms.Application.StartupPath);
    }

    private void menuItemWelshAttendanceCollection_Click(object sender, EventArgs e)
    {
      if (SIMS.Entities.Cache.CurrentSchool.PLASCFlavourId != 12)
        this.attendanceReturnRunMode = 0;
      this.attendanceCollectionLoad(sender, e, this.attendanceReturnRunMode);
    }

    private void menuItemAttendanceReturnSecondary_Click(object sender, EventArgs e)
    {
      if (this.findExistingComponent((IIDEntity) null, (Control) new AttRetBrowserDetail(1)) != null && this.attendanceReturnRunMode == 1)
      {
        int num = (int) MessageBox.Show("Primary and Secondary census collections cannot be open at the same time", "Attendance Collection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        this.attendanceReturnRunMode = 2;
        this.attendanceCollectionLoad(sender, e, this.attendanceReturnRunMode);
      }
    }

    private void menuItemAttendanceReturnPrimary_Click(object sender, EventArgs e)
    {
      if (this.findExistingComponent((IIDEntity) null, (Control) new AttRetBrowserDetail(2)) != null && this.attendanceReturnRunMode == 2)
      {
        int num = (int) MessageBox.Show("Primary and Secondary census collections cannot be open at the same time", "Attendance Collection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        this.attendanceReturnRunMode = 1;
        this.attendanceCollectionLoad(sender, e, this.attendanceReturnRunMode);
      }
    }

    private void attendanceCollectionLoad(object sender, EventArgs e, int runMode)
    {
      InvokeProgressBarDelegate progressBarDelegate = new InvokeProgressBarDelegate(this.doAttendanceCollectionThread);
      PLASCStatusLoad plascStatusLoad = new PLASCStatusLoad();
      plascStatusLoad.Text = "Attendance Loading..";
      plascStatusLoad.InfoValidationProcess = "Attendance files are being loaded..";
      try
      {
        plascStatusLoad.Owner = (System.Windows.Forms.Form) this;
        this.Enabled = false;
        plascStatusLoad.Show();
        plascStatusLoad.DisplayValidationProgressBar(progressBarDelegate);
      }
      finally
      {
        this.Enabled = true;
        plascStatusLoad.Owner = (System.Windows.Forms.Form) null;
        plascStatusLoad.Dispose();
      }
      if (SIMS.Entities.AttRetLookupData.AttRetReturnFolderAttribute.Value.Length > 0 && Directory.Exists(SIMS.Entities.AttRetLookupData.AttRetReturnFolderAttribute.Value))
      {
        this.recordMenuUsage(sender as UIMenuItem);
        this.DisplayComponent((Control) new AttRetBrowserDetail(runMode));
      }
      else
      {
        int num = (int) MessageBox.Show("Please use Tools | Statutory Return Tools | Folder Names and Security Message to setup a suitable folder for this statutory return.", "Attendance Collection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void menuItemSchoolsWorkforceReturnDefaults_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new WorkforceReturnFileSetting());
    }

    private void menuItemUpdateCatalogue_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Please confirm that your download is up to date.", "SIMS.net", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      SIMS.Processes.PLASCCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CensusImportCatalogue());
    }

    private void menuItemReconcileExamLA_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (CensusDlgReconcileExamResultLearningAims resultLearningAims = new CensusDlgReconcileExamResultLearningAims("Results"))
      {
        int num = (int) resultLearningAims.ShowDialog();
      }
    }

    private void menuItemReconcileExamEntries_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (CensusDlgReconcileExamResultLearningAims resultLearningAims = new CensusDlgReconcileExamResultLearningAims("Entries"))
      {
        int num = (int) resultLearningAims.ShowDialog();
      }
    }

    private void menuItemUpdateCourseClassification_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      if (MessageBox.Show("Please confirm that your Award structure in Examinations Organiser is ready for this operation", "SIMS.net", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      Cursor cursor = this.Cursor;
      this.Cursor = Cursors.WaitCursor;
      string str = new CensusUpdateCourseCalssificationFromEO().AutoUpdateCourseClassifications();
      SIMS.Entities.Cache.StatusMessage("Update done successfully.", UserMessageEventEnum.Information);
      if (str.ToString().Trim() != "")
      {
        int num = (int) new ASMDlgActivityLog()
        {
          ActivityText = str
        }.ShowDialog();
      }
      this.Cursor = cursor;
    }

    private void menuItemImportQans_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CensusImportQansForCM());
    }

    private void menuItemImportQWADForCM_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CensusImportQWADForCM());
    }

    private void menuItemCESEWLookups_Click(object sender, EventArgs e)
    {
      SIMS.Processes.CESEWCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CESEWToolsLookupsUpdate());
    }

    private void menuItemDuplicateQANReport_Click(object sender, EventArgs e)
    {
      using (CourseManagerDuplicateQANDetail duplicateQanDetail = new CourseManagerDuplicateQANDetail())
      {
        int num = (int) duplicateQanDetail.ShowDialog();
      }
    }

    private void menuItemStudentCourses_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new StudentCoursesBrowserDetail());
    }

    private void MenuItemStudentHomework_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new StudentHomeworkContainer());
    }

    private void initDENIMenus()
    {
      this.menuItemPrepareDENIReturn = new UIMenuItem();
      this.menuItemCreateDENIReturn = new UIMenuItem();
      this.menuItemCreateLeaversReturn = new UIMenuItem();
      this.menuItemViewDENILog = new UIMenuItem();
      this.menuItemDENISeparator = new UIMenuItem();
      this.menuItemChangeDrive = new UIMenuItem();
      this.menuItemPLASCDENI.MenuItems.AddRange(new MenuItem[6]
      {
        (MenuItem) this.menuItemPrepareDENIReturn,
        (MenuItem) this.menuItemCreateDENIReturn,
        (MenuItem) this.menuItemCreateLeaversReturn,
        (MenuItem) this.menuItemViewDENILog,
        (MenuItem) this.menuItemDENISeparator,
        (MenuItem) this.menuItemChangeDrive
      });
      this.menuItemCreateDENIReturn.Text = "&Create DENI Return";
      this.menuItemCreateDENIReturn.Click += new EventHandler(this.menuItemCreateDENIReturn_Click);
      this.menuItemCreateLeaversReturn.Text = "Create &Leavers Return";
      this.menuItemCreateLeaversReturn.Click += new EventHandler(this.menuItemCreateLeaversReturn_Click);
      this.menuItemPrepareDENIReturn.Text = "&Prepare DENI Return";
      this.menuItemPrepareDENIReturn.Click += new EventHandler(this.menuItemPrepareDENIReturn_Click);
      this.menuItemViewDENILog.Text = "&View DENI Log";
      this.menuItemViewDENILog.Click += new EventHandler(this.menuItemViewDENILog_Click);
      this.menuItemDENISeparator.Text = "-";
      this.menuItemChangeDrive.Text = "Change &Holding Drive";
      this.menuItemChangeDrive.Click += new EventHandler(this.menuItemChangeDrive_Click);
    }

    private void rebuildDENIMenus()
    {
      string[] processNames1 = new string[6]
      {
        "AddCensus",
        "BrowseCensusReturn",
        "EditCensusReturn",
        "BrowseLeaversReturn",
        "EditLeaversReturn",
        "BrowseDENILog"
      };
      string[] processNames2 = new string[2]
      {
        "BrowseCensusReturn",
        "EditCensusReturn"
      };
      string[] processNames3 = new string[2]
      {
        "BrowseLeaversReturn",
        "EditLeaversReturn"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPLASCDENI, processNames1);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPrepareDENIReturn, "AddCensus");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCreateDENIReturn, processNames2);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCreateLeaversReturn, processNames3);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemViewDENILog, "BrowseDENILog");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemChangeDrive, "AddCensus");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNIClosingReport, "ExportNDC");
    }

    private void menuItemPrepareDENIReturn_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!this.m_DENILoaded)
      {
        DENICache.Populate();
        this.m_DENILoaded = true;
      }
      if (DENICache.DENISetupFolderName != null && Directory.Exists(DENICache.DENISetupFolderName))
      {
        this.DisplayComponent((Control) new EditCensusPrepare());
      }
      else
      {
        int num = (int) MessageBox.Show("DENI holding drive does not exist.\nPlease go to Routines | Statutory Returns | DENI | Change Holding Drive and select a drive.", "DENI", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void menuItemCreateDENIReturn_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!this.m_DENILoaded)
      {
        DENICache.Populate();
        this.m_DENILoaded = true;
      }
      if (DENICache.DENISetupFolderName != null && Directory.Exists(DENICache.DENISetupFolderName))
      {
        this.DisplayComponent((Control) new CensusReturnUserInterface());
      }
      else
      {
        int num = (int) MessageBox.Show("DENI holding drive does not exist.\nPlease go to Routines | Statutory Returns | DENI | Change Holding Drive and select a drive.", "DENI", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void menuItemCreateLeaversReturn_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new LeaversReturnUserInterface());
    }

    private void menuItemViewDENILog_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new DENILogBrowser());
    }

    private void menuItemChangeDrive_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new DriveSelector().ShowDialog();
    }

    private void setupDeniContextMenu()
    {
      if (!SIMS.Entities.Cache.ProcessVisible(CensusReturnUserInterface.HostedProcessName()))
        return;
      NavigationRouteCache.AddRoute("Create Census Return", new NavigationRouteDatedDelegate(this.ContextCensusReturnDetails), new int[1]
      {
        9
      }, typeof (CensusReturnUserInterface), 9);
    }

    private void ContextCensusReturnDetails(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((AbstractContainerControl) new CensusReturnUserInterface(entityToDisplay), showAsIndependentWindow);
    }

    private void initEMAMenus()
    {
      string str = SystemConfigurationCache.LocaleCode == "NI" ? "SLC" : "APB";
      this.menuItemStudentEMADetails = new UIMenuItem();
      this.menuItemCreateAuthoriseWeeklyPayments = new UIMenuItem();
      this.menuItemCreateAuthoriseBonusPayments = new UIMenuItem();
      this.menuItemExportsToAPB = new UIMenuItem();
      this.menuItemEnrolmentExport = new UIMenuItem();
      this.menuItemWeeklyAuthorisationsExport = new UIMenuItem();
      this.menuItemBonusesExport = new UIMenuItem();
      this.menuItemPendingAPBResponse = new UIMenuItem();
      this.menuItemAuditSummary = new UIMenuItem();
      this.menuItemEMASetup.Click += new EventHandler(this.menuItemEMASetup_Click);
      this.menuItemEMA.MenuItems.AddRange(new MenuItem[6]
      {
        (MenuItem) this.menuItemStudentEMADetails,
        (MenuItem) this.menuItemCreateAuthoriseWeeklyPayments,
        (MenuItem) this.menuItemCreateAuthoriseBonusPayments,
        (MenuItem) this.menuItemExportsToAPB,
        (MenuItem) this.menuItemPendingAPBResponse,
        (MenuItem) this.menuItemAuditSummary
      });
      this.menuItemStudentEMADetails.ImageIndex = -1;
      this.menuItemStudentEMADetails.ImageList = (ImageList) null;
      this.menuItemStudentEMADetails.Index = 0;
      this.menuItemStudentEMADetails.NoEdit = false;
      this.menuItemStudentEMADetails.NoUIModify = false;
      this.menuItemStudentEMADetails.OriginalText = "";
      this.menuItemStudentEMADetails.OwnerDraw = true;
      this.menuItemStudentEMADetails.Text = "&Student EMA Details";
      this.menuItemStudentEMADetails.Click += new EventHandler(this.menuItemStudentEMADetails_Click);
      this.menuItemCreateAuthoriseWeeklyPayments.ImageIndex = -1;
      this.menuItemCreateAuthoriseWeeklyPayments.ImageList = (ImageList) null;
      this.menuItemCreateAuthoriseWeeklyPayments.Index = 1;
      this.menuItemCreateAuthoriseWeeklyPayments.NoEdit = false;
      this.menuItemCreateAuthoriseWeeklyPayments.NoUIModify = false;
      this.menuItemCreateAuthoriseWeeklyPayments.OriginalText = "";
      this.menuItemCreateAuthoriseWeeklyPayments.OwnerDraw = true;
      this.menuItemCreateAuthoriseWeeklyPayments.Text = "Create/Authorise &Weekly Payments";
      this.menuItemCreateAuthoriseWeeklyPayments.Click += new EventHandler(this.menuItemCreateAuthoriseWeeklyPayments_Click);
      this.menuItemCreateAuthoriseBonusPayments.ImageIndex = -1;
      this.menuItemCreateAuthoriseBonusPayments.ImageList = (ImageList) null;
      this.menuItemCreateAuthoriseBonusPayments.Index = 2;
      this.menuItemCreateAuthoriseBonusPayments.NoEdit = false;
      this.menuItemCreateAuthoriseBonusPayments.NoUIModify = false;
      this.menuItemCreateAuthoriseBonusPayments.OriginalText = "";
      this.menuItemCreateAuthoriseBonusPayments.OwnerDraw = true;
      this.menuItemCreateAuthoriseBonusPayments.Text = "Create/Authorise Bonus Payments";
      this.menuItemCreateAuthoriseBonusPayments.Click += new EventHandler(this.menuItemCreateAuthoriseBonusPayments_Click);
      this.menuItemExportsToAPB.ImageIndex = -1;
      this.menuItemExportsToAPB.ImageList = (ImageList) null;
      this.menuItemExportsToAPB.Index = 3;
      this.menuItemExportsToAPB.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) this.menuItemEnrolmentExport,
        (MenuItem) this.menuItemWeeklyAuthorisationsExport,
        (MenuItem) this.menuItemBonusesExport
      });
      this.menuItemExportsToAPB.NoEdit = false;
      this.menuItemExportsToAPB.NoUIModify = false;
      this.menuItemExportsToAPB.OriginalText = "";
      this.menuItemExportsToAPB.OwnerDraw = true;
      this.menuItemExportsToAPB.Text = "E&xports to " + str;
      this.menuItemEnrolmentExport.ImageIndex = -1;
      this.menuItemEnrolmentExport.ImageList = (ImageList) null;
      this.menuItemEnrolmentExport.Index = 0;
      this.menuItemEnrolmentExport.NoEdit = false;
      this.menuItemEnrolmentExport.NoUIModify = false;
      this.menuItemEnrolmentExport.OriginalText = "";
      this.menuItemEnrolmentExport.OwnerDraw = true;
      this.menuItemEnrolmentExport.Text = "&Enrolment";
      this.menuItemEnrolmentExport.Click += new EventHandler(this.menuItemEnrolmentExport_Click);
      this.menuItemWeeklyAuthorisationsExport.ImageIndex = -1;
      this.menuItemWeeklyAuthorisationsExport.ImageList = (ImageList) null;
      this.menuItemWeeklyAuthorisationsExport.Index = 1;
      this.menuItemWeeklyAuthorisationsExport.NoEdit = false;
      this.menuItemWeeklyAuthorisationsExport.NoUIModify = false;
      this.menuItemWeeklyAuthorisationsExport.OriginalText = "";
      this.menuItemWeeklyAuthorisationsExport.OwnerDraw = true;
      this.menuItemWeeklyAuthorisationsExport.Text = "&Weekly Authorisations";
      this.menuItemWeeklyAuthorisationsExport.Click += new EventHandler(this.menuItemWeeklyAuthorisationsExport_Click);
      this.menuItemBonusesExport.ImageIndex = -1;
      this.menuItemBonusesExport.ImageList = (ImageList) null;
      this.menuItemBonusesExport.Index = 2;
      this.menuItemBonusesExport.NoEdit = false;
      this.menuItemBonusesExport.NoUIModify = false;
      this.menuItemBonusesExport.OriginalText = "";
      this.menuItemBonusesExport.OwnerDraw = true;
      this.menuItemBonusesExport.Text = "B&onuses";
      this.menuItemBonusesExport.Click += new EventHandler(this.menuItemBonusesExport_Click);
      this.menuItemPendingAPBResponse.ImageIndex = -1;
      this.menuItemPendingAPBResponse.ImageList = (ImageList) null;
      this.menuItemPendingAPBResponse.Index = 4;
      this.menuItemPendingAPBResponse.NoEdit = false;
      this.menuItemPendingAPBResponse.NoUIModify = false;
      this.menuItemPendingAPBResponse.OriginalText = "";
      this.menuItemPendingAPBResponse.OwnerDraw = true;
      this.menuItemPendingAPBResponse.Text = "&Pending " + str + " Response";
      this.menuItemPendingAPBResponse.Click += new EventHandler(this.menuItemPendingAPBResponse_Click);
      this.menuItemAuditSummary.ImageIndex = -1;
      this.menuItemAuditSummary.ImageList = (ImageList) null;
      this.menuItemAuditSummary.Index = 5;
      this.menuItemAuditSummary.NoEdit = false;
      this.menuItemAuditSummary.NoUIModify = false;
      this.menuItemAuditSummary.OriginalText = "";
      this.menuItemAuditSummary.OwnerDraw = true;
      this.menuItemAuditSummary.Text = "EMA &Audit Summary";
      this.menuItemAuditSummary.Click += new EventHandler(this.menuItemAuditSummary_Click);
    }

    private void menuItemStudentEMADetails_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EMAStudentBrowseDetail());
    }

    private void menuItemCreateAuthoriseWeeklyPayments_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EMAWeeklyAuthorisationBrowseDetail());
    }

    private void menuItemCreateAuthoriseBonusPayments_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EMABonusAuthorisationBrowseDetail());
    }

    private void menuItemEnrolmentExport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (EMAEnrolmentExport emaEnrolmentExport = new EMAEnrolmentExport())
      {
        int num = (int) emaEnrolmentExport.DisplayWizard();
      }
    }

    private void menuItemWeeklyAuthorisationsExport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (EMAWeeklyAuthorisationExport authorisationExport = new EMAWeeklyAuthorisationExport())
      {
        int num = (int) authorisationExport.DisplayWizard();
      }
    }

    private void menuItemBonusesExport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (EMABonusAuthorisationExport authorisationExport = new EMABonusAuthorisationExport())
      {
        int num = (int) authorisationExport.DisplayWizard();
      }
    }

    private void menuItemPendingAPBResponse_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (EMAPendingAPBResponse pendingApbResponse = new EMAPendingAPBResponse())
      {
        int num = (int) pendingApbResponse.ShowDialog();
      }
    }

    private void menuItemAuditSummary_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EMAAuditSummaryBrowseDetail());
    }

    private void menuItemEMASetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EMASetup());
    }

    private void rebuildEMAMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemEMASetup, "EMASetup");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemStudentEMADetails, "EMAStudentBrowse");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCreateAuthoriseWeeklyPayments, "EMAWeeklyAuthorisationBrowse");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCreateAuthoriseBonusPayments, "EMABonusAuthorisationBrowse");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemEnrolmentExport, "EMAEnrolmentExport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemWeeklyAuthorisationsExport, "EMAWeeklyAuthorisationExport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBonusesExport, "EMABonusAuthorisationExport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPendingAPBResponse, "EMAPendingAPBResponse");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAuditSummary, "EMAAuditSummaryReport");
    }

    private void initELWAMenus()
    {
      this.menuItemELWAPlascDefaults = new UIMenuItem();
      this.menuItemPost16Autumn.Click += new EventHandler(this.menuItemPost16Autumn_Click);
      this.menuItemPost16Summer.Click += new EventHandler(this.menuItemPost16Summer_Click);
      this.menuItemPLASCTools.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemELWAPlascDefaults
      });
      this.menuItemELWAPlascDefaults.ImageIndex = -1;
      this.menuItemELWAPlascDefaults.ImageList = (ImageList) null;
      this.menuItemELWAPlascDefaults.Index = 0;
      this.menuItemELWAPlascDefaults.NoEdit = false;
      this.menuItemELWAPlascDefaults.NoUIModify = false;
      this.menuItemELWAPlascDefaults.OriginalText = "";
      this.menuItemELWAPlascDefaults.OwnerDraw = true;
      this.menuItemELWAPlascDefaults.Text = "Folder Names and Security Message";
      this.menuItemELWAPlascDefaults.Click += new EventHandler(this.menuItemELWAPlascDefaults_Click);
    }

    private void rebuildELWAMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPost16Summer, new string[2]
      {
        "ELWASummerBrowser",
        "ELWASummerDetail"
      });
      PLASCEntity.EnumPLASCFlavour plascFlavourId = (PLASCEntity.EnumPLASCFlavour) SIMS.Entities.Cache.CurrentSchool.PLASCFlavourId;
      switch (plascFlavourId)
      {
        case PLASCEntity.EnumPLASCFlavour.WelshPrimary:
        case PLASCEntity.EnumPLASCFlavour.WelshSecondary:
        case PLASCEntity.EnumPLASCFlavour.WelshMiddle:
          SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemWelshAttendanceCollection, new string[2]
          {
            "AttRetBrowser",
            "AttRetDetail"
          });
          SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemWelshAttendanceCollectionMiddle, new string[2]
          {
            "AttRetBrowser",
            "AttRetDetail"
          });
          SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAttendanceReturnSecondary, new string[2]
          {
            "AttRetBrowser",
            "AttRetDetail"
          });
          SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAttendanceReturnPrimary, new string[2]
          {
            "AttRetBrowser",
            "AttRetDetail"
          });
          break;
        default:
          this.menuItemWelshAttendanceCollection.Visible = false;
          break;
      }
      if (plascFlavourId == PLASCEntity.EnumPLASCFlavour.WelshMiddle)
      {
        this.menuItemWelshAttendanceCollection.Visible = false;
      }
      else
      {
        this.menuItemWelshAttendanceCollectionMiddle.Visible = false;
        this.menuItemAttendanceReturnSecondary.Visible = false;
        this.menuItemAttendanceReturnPrimary.Visible = false;
      }
      switch (plascFlavourId)
      {
        case PLASCEntity.EnumPLASCFlavour.WelshSecondary:
        case PLASCEntity.EnumPLASCFlavour.WelshMiddle:
          SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPost16Autumn, new string[2]
          {
            "ELWABrowser",
            "ELWADetail"
          });
          this.menuItemPost16Summer.Visible = false;
          break;
        case PLASCEntity.EnumPLASCFlavour.WelshSpecial:
          this.menuItemPost16Summer.Visible = false;
          this.menuItemPost16Autumn.Visible = false;
          break;
        default:
          this.menuItemPost16Summer.Visible = false;
          this.menuItemPost16Autumn.Visible = false;
          break;
      }
    }

    private void setupELWAContextMenu()
    {
    }

    private void menuItemPost16Autumn_Click(object sender, EventArgs e)
    {
      if (!this.elwaloaded)
      {
        InvokeProgressBarDelegate progressBarDelegate = new InvokeProgressBarDelegate(this.doELWAThread);
        ELWAStatusLoad elwaStatusLoad = new ELWAStatusLoad();
        try
        {
          elwaStatusLoad.Owner = (System.Windows.Forms.Form) this;
          this.Enabled = false;
          elwaStatusLoad.Show();
          this.elwaloaded = elwaStatusLoad.DisplayValidationProgressBar(progressBarDelegate);
        }
        finally
        {
          this.Enabled = true;
          elwaStatusLoad.Owner = (System.Windows.Forms.Form) null;
          elwaStatusLoad.Dispose();
        }
      }
      this.recordMenuUsage(sender as UIMenuItem);
      if (SIMS.Entities.ELWACache.ElwaOutbox != "" && Directory.Exists(SIMS.Entities.ELWACache.ElwaOutbox))
        this.DisplayComponent((Control) new ELWABrowserDetail());
      else if (SIMS.Entities.ELWACache.ElwaOutbox == "")
      {
        int num1 = (int) MessageBox.Show("Please use Tools | Statutory Return Tools | Folder Names and Security Message to setup a suitable folder for this statutory return. ", "Post 16 Autumn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        int num2 = (int) MessageBox.Show("Please use Tools | Statutory Return Tools | Folder Names and Security Message to setup a suitable folder for this statutory return ", "Post 16 Autumn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      if (!(SIMS.Entities.ELWACache.FileSetVersionErrorDescription != string.Empty) || SIMS.Entities.ELWACache.FileSetVersionErrorDescription.Contains("fileset number is too low"))
        return;
      string caption = "Post 16 Autumn";
      int num3 = (int) MessageBox.Show(SIMS.Entities.ELWACache.FileSetVersionErrorDescription, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }

    private void menuItemPost16Summer_Click(object sender, EventArgs e)
    {
      if (!this.elwaloaded)
      {
        InvokeProgressBarDelegate progressBarDelegate = new InvokeProgressBarDelegate(this.doELWAThread);
        ELWAStatusLoad elwaStatusLoad = new ELWAStatusLoad();
        try
        {
          elwaStatusLoad.Owner = (System.Windows.Forms.Form) this;
          this.Enabled = false;
          elwaStatusLoad.Show();
          this.elwaloaded = elwaStatusLoad.DisplayValidationProgressBar(progressBarDelegate);
        }
        finally
        {
          this.Enabled = true;
          elwaStatusLoad.Owner = (System.Windows.Forms.Form) null;
          elwaStatusLoad.Dispose();
        }
      }
      this.recordMenuUsage(sender as UIMenuItem);
      SIMS.Processes.PLASCCache.Populate();
      ELWASummerCache.Populate(System.Windows.Forms.Application.StartupPath);
      if (SIMS.Entities.ELWACache.ElwaSummerOutbox != "" && Directory.Exists(SIMS.Entities.ELWACache.ElwaSummerOutbox))
        return;
      int num = (int) MessageBox.Show("Please use Tools | Statutory Return Tools | Folder Names and Security Message to set up a suitable folder for this statutory return.\nPlease ensure that authorised personnel only have access to this folder as it will contain sensitive data", "Post 16 Summer", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }

    private void menuItemELWAPlascDefaults_Click(object sender, EventArgs e)
    {
      SIMS.Processes.PLASCCache.Populate();
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ELWAConfigureDefault());
    }

    private void initSystemDiagMenus()
    {
      this.menuItemRunSQLDiagnostics = new UIMenuItem();
      this.menuItemSysDiag.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemRunSQLDiagnostics
      });
      this.menuItemRunSQLDiagnostics.ImageIndex = -1;
      this.menuItemRunSQLDiagnostics.ImageList = (ImageList) null;
      this.menuItemRunSQLDiagnostics.Index = 0;
      this.menuItemRunSQLDiagnostics.NoEdit = false;
      this.menuItemRunSQLDiagnostics.NoUIModify = false;
      this.menuItemRunSQLDiagnostics.OriginalText = "";
      this.menuItemRunSQLDiagnostics.OwnerDraw = true;
      this.menuItemRunSQLDiagnostics.Text = "&Database Diagnostics";
      this.menuItemRunSQLDiagnostics.Click += new EventHandler(this.menuItemRunSQLDiagnostics_Click);
    }

    private void rebuildSystemDiagMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSysDiag, "DiagnosticProcess");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemRunSQLDiagnostics, "DiagnosticProcess");
    }

    private void menuItemRunSQLDiagnostics_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new DiagnosticExecute());
    }

    private void initTeachersDesktopMenus()
    {
      this.menuItemSynchronize = new UIMenuItem();
      this.menuItemManageConflicts = new UIMenuItem();
      this.menuItemUserProfileSetup = new UIMenuItem();
      this.menuItemOfflineDatabase = new UIMenuItem();
      this.menuItemCommentEntry.Click += new EventHandler(this.menuItemCommentEntry_Click);
      this.menuItemMarksheet.Click += new EventHandler(this.menuItemMarksheet_Click);
      this.menuItemSynchronize.ImageIndex = -1;
      this.menuItemSynchronize.ImageList = (ImageList) null;
      this.menuItemSynchronize.Index = 0;
      this.menuItemSynchronize.NoEdit = false;
      this.menuItemSynchronize.NoUIModify = false;
      this.menuItemSynchronize.OriginalText = "";
      this.menuItemSynchronize.OwnerDraw = true;
      this.menuItemSynchronize.Text = "S&ynchronise Data";
      this.menuItemSynchronize.Click += new EventHandler(this.menuItemSynchronize_Click);
      this.menuItemManageConflicts.ImageIndex = -1;
      this.menuItemManageConflicts.ImageList = (ImageList) null;
      this.menuItemManageConflicts.Index = 1;
      this.menuItemManageConflicts.NoEdit = false;
      this.menuItemManageConflicts.NoUIModify = false;
      this.menuItemManageConflicts.OriginalText = "";
      this.menuItemManageConflicts.OwnerDraw = true;
      this.menuItemManageConflicts.Text = "Manage &Conflicts";
      this.menuItemManageConflicts.Click += new EventHandler(this.menuItemManageConflicts_Click);
      this.menuItemUserProfileSetup.ImageIndex = -1;
      this.menuItemUserProfileSetup.ImageList = (ImageList) null;
      this.menuItemUserProfileSetup.Index = 2;
      this.menuItemUserProfileSetup.NoEdit = false;
      this.menuItemUserProfileSetup.NoUIModify = false;
      this.menuItemUserProfileSetup.OriginalText = "";
      this.menuItemUserProfileSetup.OwnerDraw = true;
      this.menuItemUserProfileSetup.Text = "User Profile &Setup";
      this.menuItemUserProfileSetup.Click += new EventHandler(this.menuItemUserProfileSetup_Click);
      this.menuItemOfflineDatabase.ImageIndex = -1;
      this.menuItemOfflineDatabase.ImageList = (ImageList) null;
      this.menuItemOfflineDatabase.Index = 3;
      this.menuItemOfflineDatabase.NoEdit = false;
      this.menuItemOfflineDatabase.NoUIModify = false;
      this.menuItemOfflineDatabase.OriginalText = "";
      this.menuItemOfflineDatabase.OwnerDraw = true;
      this.menuItemOfflineDatabase.Text = "&Offline Connection Setup";
      this.menuItemOfflineDatabase.Click += new EventHandler(this.menuItemOfflineDatabase_Click);
    }

    private void rebuildTeachersDesktopMenus()
    {
      string[] processNames1 = new string[2]
      {
        "CommentEntryBrowse",
        "CommentEntryDetail"
      };
      string[] processNames2 = new string[3]
      {
        "MarksheetBrowse",
        "MarksheetDetail",
        "ResultHistory"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSynchronize, "SynchronizeData");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemManageConflicts, "ErrorsAndConflicts");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUserProfileSetup, "UserProfileSetup");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCommentEntry, processNames1);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMarksheet, processNames2);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemOfflineDatabase, "AvailableDatabasesProcess");
    }

    private void menuItemSynchronize_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SynchronizeData());
    }

    private void menuItemManageConflicts_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ManageConflicts());
    }

    private void menuItemUserProfileSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new UserProfileSetUpDetails());
    }

    private void menuItemCommentEntry_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PRWTDListEntryBrowserDetail(true));
    }

    private void menuItemMarksheet_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ASMMyMarksheetBrowserDetail(true));
    }

    private void menuItemOfflineDatabase_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new AvailableDatabases());
    }

    private void addOfflineShortcutsToLauncher()
    {
      if (!SIMS.Entities.Cache.CurrentDatabase.IsOffline)
        return;
      ShortcutsPanel panel = this.launcher.Panel("Teachers' Desktop");
      if (SIMS.Entities.Cache.CurrentDatabase.IsOffline && panel != null)
      {
        this.launcher.ShortcutsPanelExpand(panel);
        if (SIMS.Entities.Cache.ProcessVisible(new string[2]
        {
          "SENStudentBrowse",
          "ViewSENStudent"
        }))
          this.launcher.AddInternalShortcut(this.menuItemStudentSEN.Text, this.menuItemStudentSEN.FullPath);
        if (SIMS.Entities.Cache.ProcessVisible(new string[2]
        {
          "CommentEntryBrowse",
          "CommentEntryDetail"
        }))
          this.launcher.AddInternalShortcut("List Entry", this.menuItemCommentEntry.FullPath);
        if (SIMS.Entities.Cache.ProcessVisible(new string[3]
        {
          "MarksheetBrowse",
          "MarksheetDetail",
          "ResultHistory"
        }))
          this.launcher.AddInternalShortcut(SIMS.Entities.Cache.UserInterfaceLabel("Marksheet Entry"), "&Marksheet Entry|&Focus");
        if (SIMS.Entities.Cache.ProcessVisible(new string[2]
        {
          "StudentBrowseProcess",
          "EditStudentInformationReadOnly"
        }))
          this.launcher.AddInternalShortcut(this.MenuItemStudentHistory.Text, this.MenuItemStudentHistory.FullPath);
        panel.ReadOnly = true;
        this.launcher.ShortcutsPanelExpand(panel);
      }
      else
      {
        if (panel == null)
          return;
        panel.Visible = false;
      }
    }

    private void hideExtranousMenuRoutesWhenOffline()
    {
      int num = SIMS.Entities.Cache.CurrentDatabase.IsOffline ? 1 : 0;
    }

    private void setTDMenuIcons()
    {
      this.menuItemCommentEntry.ImageList = this.imageListOfflineShortcuts;
      this.menuItemMarksheet.ImageList = this.imageListOfflineShortcuts;
      this.menuItemStudentSEN.ImageList = this.imageListOfflineShortcuts;
      this.MenuItemStudentHistory.ImageList = this.imageListOfflineShortcuts;
      this.menuItemCommentEntry.ImageIndex = 0;
      this.menuItemMarksheet.ImageIndex = 1;
      this.menuItemStudentSEN.ImageIndex = 2;
      this.MenuItemStudentHistory.ImageIndex = 3;
    }

    private bool closeTeachersDesktop()
    {
      bool flag = false;
      if (SIMS.Entities.Cache.CurrentDatabase.IsOffline)
        DocumentManagement.RemoveFiles_CacheCurrentDatabaseIsOffline();
      else if (DataSyncCache.ShowSyncMessage && MessageBox.Show(DataSyncCache.SyncMessage, SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        this.DisplayComponent((Control) new SynchronizeData());
        flag = true;
      }
      return flag;
    }

    private void initialiseTeachersDesktop()
    {
      if (!SIMS.Entities.Cache.CurrentDatabase.IsOffline)
        return;
      this.Text += SIMS.Entities.Cache.UserInterfaceLabel(" - [Offline]");
      DocumentManagement.InflateOfflineDocsCollection();
    }

    private void initNDCMenus()
    {
      this.menuItemNDCResultsKeyStage2 = new UIMenuItem();
      this.menuItemNDCResultsKeyStage3 = new UIMenuItem();
      this.menuItemNDCResultsFoundationOutcome = new UIMenuItem();
      this.menuItemNDCResults = new UIMenuItem();
      this.menuItemNDCResultsNRT = new UIMenuItem();
      this.menuItemNDCNIResultsImport = new UIMenuItem();
      this.menuItemNDCNIResultsExport = new UIMenuItem();
      this.menuItemNDCResultsNRTImport = new UIMenuItem();
      this.menuItemNDCResultsBaselineAssessment = new UIMenuItem();
      this.menuItemNDCWales.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemNDCResultsBaselineAssessment,
        (MenuItem) this.menuItemNDCResultsFoundationOutcome,
        (MenuItem) this.menuItemNDCResultsKeyStage2,
        (MenuItem) this.menuItemNDCResultsKeyStage3,
        (MenuItem) this.menuItemNDCResultsNRT
      });
      this.menuItemDataOut.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemNDCNIResultsExport
      });
      this.menuItemDataIn.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemNDCResults,
        (MenuItem) this.menuItemNDCNIResultsImport
      });
      this.menuItemNDCResultsFoundationOutcome.Text = "Foundation Phase &Outcomes";
      this.menuItemNDCResultsFoundationOutcome.Visible = false;
      this.menuItemNDCResultsFoundationOutcome.Click += new EventHandler(this.menuItemNDCResultsFoundationOutcome_Click);
      this.menuItemNDCResults.Text = "&NDC Results";
      this.menuItemNDCResults.Visible = false;
      this.menuItemNDCResults.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemNDCResultsNRTImport
      });
      this.menuItemNDCResultsNRT.Text = "&Welsh National Tests Results";
      this.menuItemNDCResultsNRT.Visible = false;
      this.menuItemNDCResultsNRT.Click += new EventHandler(this.menuItemNDCResultsNRT_Click);
      this.menuItemNDCResultsKeyStage2.Text = "Key Stage &2";
      this.menuItemNDCResultsKeyStage2.Visible = false;
      this.menuItemNDCResultsKeyStage2.Click += new EventHandler(this.menuItemNDCResultsKeyStage2_Click);
      this.menuItemNDCResultsKeyStage3.Text = "Key Stage &3";
      this.menuItemNDCResultsKeyStage3.Visible = false;
      this.menuItemNDCResultsKeyStage3.Click += new EventHandler(this.menuItemNDCResultsKeyStage3_Click);
      this.menuItemNDCNIResultsImport.Text = "&NI KS Results Import";
      this.menuItemNDCNIResultsImport.Visible = false;
      this.menuItemNDCNIResultsImport.Click += new EventHandler(this.menuItemNDCNIResultsImport_Click);
      this.menuItemNDCNIResultsExport.Text = "NI &KS Results Export";
      this.menuItemNDCNIResultsExport.Visible = false;
      this.menuItemNDCNIResultsExport.Click += new EventHandler(this.menuItemNDCNIResultsExport_Click);
      this.menuItemNDCResultsNRTImport.Text = "Import &Welsh National Tests";
      this.menuItemNDCResultsNRTImport.Visible = false;
      this.menuItemNDCResultsNRTImport.Click += new EventHandler(this.menuItemNDCResultsNRTImport_Click);
      this.menuItemNDCResultsBaselineAssessment.Text = "Foundation Phase &Baseline";
      this.menuItemNDCResultsBaselineAssessment.Visible = false;
      this.menuItemNDCResultsBaselineAssessment.Click += new EventHandler(this.menuItemNDCResultsBaselineAssessment_Click);
    }

    private void rebuildNDCMenus()
    {
      if (SystemConfigurationCache.LocaleCode == "WALES")
      {
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNDCWales, "ExportNDC");
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNDCResultsFoundationOutcome, "ExportNDC");
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNDCResults, "ExportNDC");
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNDCResultsNRT, "ExportNDC");
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNDCResultsKeyStage2, "ExportNDC");
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNDCResultsKeyStage3, "ExportNDC");
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNDCResults, "ExportNDC");
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNDCResultsNRTImport, "ExportNDC");
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNDCResultsBaselineAssessment, "ExportNDC");
        if (SIMS.Entities.Cache.CurrentSchool.SchoolPhase == "Primary" || SIMS.Entities.Cache.CurrentSchool.SchoolPhase == "Middle (Deemed Primary)")
        {
          this.menuItemNDCResultsKeyStage3.Visible = false;
        }
        else
        {
          if (!(SIMS.Entities.Cache.CurrentSchool.SchoolPhase == "Secondary") && !(SIMS.Entities.Cache.CurrentSchool.SchoolPhase == "Middle (Deemed Secondary)"))
            return;
          this.menuItemNDCResultsFoundationOutcome.Visible = false;
          this.menuItemNDCResultsKeyStage2.Visible = false;
          this.menuItemNDCResultsBaselineAssessment.Visible = false;
        }
      }
      else
      {
        if (!(SystemConfigurationCache.LocaleCode == "NI"))
          return;
        this.menuItemNDCNIResultsImport.Text = "&NI KS Results Import";
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNDCNIResultsExport, "ExportNDC");
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNDCNIResultsImport, "ExportNDC");
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemDataIn, new string[2]
        {
          "ExportNDC",
          "CTFIn"
        });
      }
    }

    private void menuItemNDCNIResultsExport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!(SystemConfigurationCache.LocaleCode == "NI"))
        return;
      this.DisplayComponent((Control) new ExportNINdcResultsUI());
    }

    private void menuItemNDCNIResultsImport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!(SystemConfigurationCache.LocaleCode == "NI"))
        return;
      this.DisplayComponent((Control) new ImportNDCResultsUI("NIlop"));
    }

    private void menuItemNDCResultsNRTImport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!(SystemConfigurationCache.LocaleCode == "WALES"))
        return;
      this.DisplayComponent((Control) new ImportNDCResultsUI("NRT"));
    }

    private void menuItemNIClosingReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!(SystemConfigurationCache.LocaleCode == "NI"))
        return;
      this.DisplayComponent((Control) new ExportNIClosingReportUI());
    }

    private void menuItemNDCResultsKeyStage2_Click(object sender, EventArgs e)
    {
      this.menuItemNDCResultsKeyStageClick(sender, NDCWelshStage.KeyStage2);
    }

    private void menuItemNDCResultsKeyStage3_Click(object sender, EventArgs e)
    {
      this.menuItemNDCResultsKeyStageClick(sender, NDCWelshStage.KeyStage3);
    }

    private void menuItemNDCResultsFoundationOutcome_Click(object sender, EventArgs e)
    {
      this.menuItemNDCResultsKeyStageClick(sender, NDCWelshStage.FoundationOutcome);
    }

    private void menuItemNDCResultsNRT_Click(object sender, EventArgs e)
    {
      this.menuItemNDCResultsKeyStageClick(sender, NDCWelshStage.NRT);
    }

    private void menuItemNDCResultsBaselineAssessment_Click(object sender, EventArgs e)
    {
      this.menuItemNDCResultsKeyStageClick(sender, NDCWelshStage.BaselineAssessment);
    }

    private void doExportNDCResultThread()
    {
      SIMS.Processes.ExportWelshNDCResultsCache.Populate();
    }

    private void menuItemNDCResultsKeyStageClick(object sender, NDCWelshStage keyStage)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!(SystemConfigurationCache.LocaleCode == "WALES"))
        return;
      ExportNDCResultDetailError resultDetailError = new ExportNDCResultDetailError(keyStage);
      bool flag = false;
      for (int index = 0; index < this.panelMain.Controls.Count; ++index)
      {
        Control control = this.panelMain.Controls[index];
        if (control is ExportNDCResultDetailError && ((ExportNDCResultDetailError) control).KeyStage == keyStage)
        {
          flag = true;
          this.activateItem(control);
        }
      }
      if (flag)
        return;
      if (!this.m_ExportNDCResultLoaded)
      {
        InvokeProgressBarDelegate progressBarDelegate = new InvokeProgressBarDelegate(this.doExportNDCResultThread);
        PLASCStatusLoad plascStatusLoad = new PLASCStatusLoad();
        plascStatusLoad.Text = "Export NDC Result Loading..";
        plascStatusLoad.InfoValidationProcess = "File Loading in Progress ...";
        try
        {
          plascStatusLoad.Owner = (System.Windows.Forms.Form) this;
          this.Enabled = false;
          plascStatusLoad.Show();
          this.m_ExportNDCResultLoaded = plascStatusLoad.DisplayValidationProgressBar(progressBarDelegate);
        }
        finally
        {
          this.Enabled = true;
          plascStatusLoad.Owner = (System.Windows.Forms.Form) null;
          plascStatusLoad.Dispose();
        }
      }
      this.DisplayNewComponent((Control) resultDetailError);
    }

    private void initIndependentMenus()
    {
      this.menuItemASCIS = new UIMenuItem();
      this.menuASCIS.Click += new EventHandler(this.menuItemASCIS_Click);
      this.menuItemISC = new UIMenuItem();
      this.menuISC.Click += new EventHandler(this.menuItemISC_Click);
      this.menuItemStatutoryReturns.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemASCIS,
        (MenuItem) this.menuItemISC
      });
      this.menuItemIndependentReturnDefaults = new UIMenuItem();
      this.menuItemPLASCTools.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemIndependentReturnDefaults
      });
      this.menuItemASCIS.ImageIndex = -1;
      this.menuItemASCIS.ImageList = (ImageList) null;
      this.menuItemASCIS.Index = 0;
      this.menuItemASCIS.NoEdit = false;
      this.menuItemASCIS.NoUIModify = false;
      this.menuItemASCIS.OriginalText = "";
      this.menuItemASCIS.OwnerDraw = true;
      this.menuItemASCIS.Text = "&SLASC";
      this.menuItemASCIS.Click += new EventHandler(this.menuItemASCIS_Click);
      this.menuItemISC.ImageIndex = -1;
      this.menuItemISC.ImageList = (ImageList) null;
      this.menuItemISC.Index = 0;
      this.menuItemISC.NoEdit = false;
      this.menuItemISC.NoUIModify = false;
      this.menuItemISC.OriginalText = "";
      this.menuItemISC.OwnerDraw = true;
      this.menuItemISC.Text = "&ISC";
      this.menuItemISC.Click += new EventHandler(this.menuItemISC_Click);
      this.menuItemIndependentReturnDefaults.ImageIndex = -1;
      this.menuItemIndependentReturnDefaults.ImageList = (ImageList) null;
      this.menuItemIndependentReturnDefaults.Index = 0;
      this.menuItemIndependentReturnDefaults.NoEdit = false;
      this.menuItemIndependentReturnDefaults.NoUIModify = false;
      this.menuItemIndependentReturnDefaults.OriginalText = "";
      this.menuItemIndependentReturnDefaults.OwnerDraw = true;
      this.menuItemIndependentReturnDefaults.Text = "&Independent Return Defaults";
      this.menuItemIndependentReturnDefaults.Click += new EventHandler(this.menuItemIndependentReturnDefaults_Click);
    }

    private void rebuildIndependentMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemASCIS, new string[9]
      {
        "ASCIS_Census_Return_Browse",
        "ASCIS_Census_Return_Detail",
        "ASCIS_SENStudentBrowse",
        "ASCIS_BrowseTeachers",
        "ASCIS_BrowseNonTeacherStaff",
        "Returns_ReportWriter",
        "ASCIS_BrowseTeacherLeavers",
        "ASCIS_BrowseNonTeacherStaffLeavers",
        "ConfigureDefaults"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemISC, new string[3]
      {
        "ISC_Census_Return_Browse",
        "ISC_Returns_ReportWriter",
        "ConfigureDefaults"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemIndependentReturnDefaults, new string[1]
      {
        "ConfigureDefaults"
      });
    }

    private void setupASCISContextMenu()
    {
    }

    private void menuItemASCIS_Click(object sender, EventArgs e)
    {
      SIMS.Processes.ConfigureDefaults.populateDefaultSENMapping();
      this.recordMenuUsage(sender as UIMenuItem);
      new SIMS.Processes.ConfigureDefaults().Populate();
      if (SIMS.Entities.ConfigureDefaults.ValidFolder != "" && Directory.Exists(SIMS.Entities.ConfigureDefaults.ValidFolder))
      {
        this.DisplayComponent((Control) new ASCIS_Census_Return_Container());
      }
      else
      {
        int num = (int) MessageBox.Show("Please use Tools | Statutory Return Tools | Independent Return Defaults to setup a suitable folder for the Independent Returns.\nPlease ensure that only authorised personnel have access to the folder locations as they contain sensitive data.", "SLASC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void menuItemISC_Click(object sender, EventArgs e)
    {
      SIMS.Processes.ConfigureDefaults.populateDefaultSENMapping();
      this.recordMenuUsage(sender as UIMenuItem);
      new SIMS.Processes.ConfigureDefaults().Populate();
      if (SIMS.Entities.ConfigureDefaults.ValidFolder != "" && Directory.Exists(SIMS.Entities.ConfigureDefaults.ValidFolder))
      {
        this.DisplayComponent((Control) new ISC_Census_Return_Container());
      }
      else
      {
        int num = (int) MessageBox.Show("Please use Tools | Statutory Return Tools | Independent Return Defaults to setup a suitable folder for the Independent Returns.\nPlease ensure that only authorised personnel have access to the folder locations as they contain sensitive data.", "ISC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void menuItemIndependentReturnDefaults_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ConfigureDefaults());
    }

    private void initVLEMenus()
    {
      this.menuItemVLEOut = new UIMenuItem();
      this.menuItemVLEExportLog = new UIMenuItem();
      this.menuItemDataOut.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemVLEOut
      });
      this.menuItemVLEOut.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemVLEExportLog
      });
      this.menuItemVLEOut.ImageIndex = -1;
      this.menuItemVLEOut.ImageList = (ImageList) null;
      this.menuItemVLEOut.Index = 2;
      this.menuItemVLEOut.NoEdit = false;
      this.menuItemVLEOut.NoUIModify = false;
      this.menuItemVLEOut.OriginalText = "";
      this.menuItemVLEOut.OwnerDraw = true;
      this.menuItemVLEOut.Text = "&VLE";
      this.menuItemVLEExportLog.ImageIndex = -1;
      this.menuItemVLEExportLog.ImageList = (ImageList) null;
      this.menuItemVLEExportLog.Index = 0;
      this.menuItemVLEExportLog.NoEdit = false;
      this.menuItemVLEExportLog.NoUIModify = false;
      this.menuItemVLEExportLog.OriginalText = "";
      this.menuItemVLEExportLog.OwnerDraw = true;
      this.menuItemVLEExportLog.Text = "Maintain E&xport History Log";
      this.menuItemVLEExportLog.Click += new EventHandler(this.menuItemVLEExportLog_Click);
    }

    private void rebuildVLEMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemVLEExportLog, new string[1]
      {
        "MaintainVLELogEntries"
      });
    }

    private void menuItemVLEExportLog_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new VLEExportLogContainer());
    }

    private void initPerformanceMenus()
    {
      this.menuItemASMMarksheetEntry = new UIMenuItem();
      this.menuItemASMOMREntry = new UIMenuItem();
      this.menuItemSeperator2 = new UIMenuItem();
      this.menuItemASMIndividualReport = new UIMenuItem();
      this.menuItemSeperator3 = new UIMenuItem();
      this.menuItemASMAspect = new UIMenuItem();
      this.menuItemASMGradeSet = new UIMenuItem();
      this.menuItemASMResultSet = new UIMenuItem();
      this.menuItemLookUpTables = new UIMenuItem();
      this.menuItemASMTemplate = new UIMenuItem();
      this.menuItemASMOMRTemplate = new UIMenuItem();
      this.menuItemFFTEstimates = new UIMenuItem();
      this.menuItemPAGroupAnalysis = new UIMenuItem();
      this.menuItemPAAspectAnalysis = new UIMenuItem();
      this.menuItemPAResultSetAnalysis = new UIMenuItem();
      this.menuItemPAChanceAnalysis = new UIMenuItem();
      this.menuItemSeperator4 = new UIMenuItem();
      this.menuItemPATrendAnalysis = new UIMenuItem();
      this.menuItemPATrendAnalysisReview = new UIMenuItem();
      this.menuItemPATrendAnalysisPrediction = new UIMenuItem();
      this.menuItemPATrackingSeparator = new UIMenuItem();
      this.menuItemPATrackingTemplate = new UIMenuItem();
      this.menuItemPATrackingGrid = new UIMenuItem();
      this.menuItemAPPGridTemplate = new UIMenuItem();
      this.menuItemAPPGridEntry = new UIMenuItem();
      this.menuItemTPPGridEntry = new UIMenuItem();
      this.menuItemPoSManagement = new UIMenuItem();
      this.menuItemPoSManagingContent = new UIMenuItem();
      this.menuItemPoSManagingGrades = new UIMenuItem();
      this.menuItemProfilesCommentBanks = new UIMenuItem();
      this.menuItemProfilesSessionManager = new UIMenuItem();
      this.menuItemProfilesDataEntry = new UIMenuItem();
      this.menuItemProfilesDataEntryListEntry = new UIMenuItem();
      this.menuItemProfilesDataEntryGridEntry = new UIMenuItem();
      this.menuItemProfilesDataEntryOMREntry = new UIMenuItem();
      this.menuItemProfilesStudentProfiles = new UIMenuItem();
      this.menuItemProfilesReviewProfiles = new UIMenuItem();
      this.menuItemProfilesUDG = new UIMenuItem();
      this.menuItemAssManUDG = new UIMenuItem();
      this.menuItemOMRSetup = new UIMenuItem();
      this.menuItemProfilesMissingComments = new UIMenuItem();
      this.menuItemProfilesCommentUsageAnalysis = new UIMenuItem();
      this.menuItemProfilesMissingEntriesReport = new UIMenuItem();
      this.menuItemProfilesAreasNotApprovedReport = new UIMenuItem();
      this.menuItemASMToolsCategory = new UIMenuItem();
      this.menuItemASMToolsTemplateConversion = new UIMenuItem();
      this.menuItemSeperator7 = new UIMenuItem();
      this.menuItemASMToolsSystemUtilities = new UIMenuItem();
      this.menuItemASMToolsSystemUtilitiesAspects = new UIMenuItem();
      this.menuItemASMToolsSystemUtilitiesGradeSets = new UIMenuItem();
      this.menuItemASMToolsSystemUtilitiesTemplates = new UIMenuItem();
      this.menuItemASMToolsSystemUtilitiesMarksheets = new UIMenuItem();
      this.menuItemASMToolsSystemUtilitiesResults = new UIMenuItem();
      this.menuItemASMToolsSystemUtilitiesOMRTemplates = new UIMenuItem();
      this.menuItemASMToolsSystemUtilitiesOMRSheets = new UIMenuItem();
      this.menuItemASMToolsSystemUtilitiesIndividualReports = new UIMenuItem();
      this.menuItemASMToolsSystemUtilitiesResultSets = new UIMenuItem();
      this.menuItemASMToolsSystemUtilitiesKSMWizards = new UIMenuItem();
      this.menuItemSeperator8 = new UIMenuItem();
      this.menuItemASMToolsWizardManager = new UIMenuItem();
      this.menuItemASMToolsAssessmentMapping = new UIMenuItem();
      this.menuItemASMToolsOptions = new UIMenuItem();
      this.menuItemASMToolsFFTOptions = new UIMenuItem();
      this.menuItemPAToolsValueAddedLines = new UIMenuItem();
      this.menuItemPAToolsProgressionLines = new UIMenuItem();
      this.menuItemSeperator9 = new UIMenuItem();
      this.menuItemPAToolsSystemUtilities = new UIMenuItem();
      this.menuItemSeperator10 = new UIMenuItem();
      this.menuItemPAToolsBuildExamAnalysis = new UIMenuItem();
      this.menuItemPAToolsDefineSettings = new UIMenuItem();
      this.menuItemProfilesToolsCompareCommentBanks = new UIMenuItem();
      this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets = new UIMenuItem();
      this.menuItemDataOutASMExport = new UIMenuItem();
      this.menuItemDataOutASMWResourceUtilityExport = new UIMenuItem();
      this.menuItemDataOutPAExport = new UIMenuItem();
      this.menuItemDataInASMImport = new UIMenuItem();
      this.menuItemDataInASMImportFromSpreadsheet = new UIMenuItem();
      this.menuItemDataInFFTImport = new UIMenuItem();
      this.menuItemDataInPAImport = new UIMenuItem();
      this.menuItemPAToolsSystemUtilitiesTrendLines = new UIMenuItem();
      this.menuItemPAToolsSystemUtilitiesTrackingTemplates = new UIMenuItem();
      this.menuItemPAToolsSystemUtilitiesTrackingGrids = new UIMenuItem();
      this.menuItemPAToolsSystemUtilitiesAnalysisResources = new UIMenuItem();
      this.menuItemAMPASep1 = new UIMenuItem();
      this.menuItemFFTSeparator = new UIMenuItem();
      this.menuItemProfilesToolsAddNamesToDictionary = new UIMenuItem();
      this.menuItemFocusASM.MenuItems.AddRange(new MenuItem[28]
      {
        (MenuItem) this.menuItemASMMarksheetEntry,
        (MenuItem) this.menuItemAPPGridEntry,
        (MenuItem) this.menuItemTPPGridEntry,
        (MenuItem) this.menuItemASMOMREntry,
        (MenuItem) this.menuItemSeperator2,
        (MenuItem) this.menuItemASMIndividualReport,
        (MenuItem) this.menuItemSeperator3,
        (MenuItem) this.menuItemASMAspect,
        (MenuItem) this.menuItemASMGradeSet,
        (MenuItem) this.menuItemASMResultSet,
        (MenuItem) this.menuItemLookUpTables,
        (MenuItem) this.menuItemASMTemplate,
        (MenuItem) this.menuItemAPPGridTemplate,
        (MenuItem) this.menuItemASMOMRTemplate,
        (MenuItem) this.menuItemPoSManagement,
        (MenuItem) this.menuItemAMPASep1,
        (MenuItem) this.menuItemFFTEstimates,
        (MenuItem) this.menuItemFFTSeparator,
        (MenuItem) this.menuItemPAGroupAnalysis,
        (MenuItem) this.menuItemPAAspectAnalysis,
        (MenuItem) this.menuItemPAResultSetAnalysis,
        (MenuItem) this.menuItemPAChanceAnalysis,
        (MenuItem) this.menuItemSeperator4,
        (MenuItem) this.menuItemPATrendAnalysis,
        (MenuItem) this.menuItemPATrackingSeparator,
        (MenuItem) this.menuItemPATrackingTemplate,
        (MenuItem) this.menuItemPATrackingGrid,
        (MenuItem) this.menuItemAssessmentPoSAnalysis
      });
      this.menuItemFocusProfiles.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemProfilesCommentBanks,
        (MenuItem) this.menuItemProfilesSessionManager,
        (MenuItem) this.menuItemProfilesDataEntry,
        (MenuItem) this.menuItemProfilesStudentProfiles,
        (MenuItem) this.menuItemProfilesReviewProfiles
      });
      this.menuItemGroups.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemProfilesUDG,
        (MenuItem) this.menuItemAssManUDG
      });
      this.menuItemSetups.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemOMRSetup
      });
      this.menuItemASMMarksheetEntry.ImageIndex = -1;
      this.menuItemASMMarksheetEntry.ImageList = (ImageList) null;
      this.menuItemASMMarksheetEntry.Index = 0;
      this.menuItemASMMarksheetEntry.NoEdit = false;
      this.menuItemASMMarksheetEntry.NoUIModify = false;
      this.menuItemASMMarksheetEntry.OriginalText = "";
      this.menuItemASMMarksheetEntry.OwnerDraw = true;
      this.menuItemASMMarksheetEntry.Text = "&Marksheet Entry";
      this.menuItemASMMarksheetEntry.Click += new EventHandler(this.menuItemASMMarksheetEntry_Click);
      this.menuItemAPPGridEntry.ImageIndex = -1;
      this.menuItemAPPGridEntry.ImageList = (ImageList) null;
      this.menuItemAPPGridEntry.Text = "Progress Grid &Entry";
      this.menuItemAPPGridEntry.Index = 1;
      this.menuItemAPPGridEntry.NoEdit = false;
      this.menuItemAPPGridEntry.NoUIModify = false;
      this.menuItemAPPGridEntry.OriginalText = "";
      this.menuItemAPPGridEntry.OwnerDraw = true;
      this.menuItemAPPGridEntry.Click += new EventHandler(this.menuItemAPPGridEntry_Click);
      this.menuItemTPPGridEntry.ImageIndex = -1;
      this.menuItemTPPGridEntry.ImageList = (ImageList) null;
      this.menuItemTPPGridEntry.Text = "Programme of Study Trac&king Entry";
      this.menuItemTPPGridEntry.Index = 2;
      this.menuItemTPPGridEntry.NoEdit = false;
      this.menuItemTPPGridEntry.NoUIModify = false;
      this.menuItemTPPGridEntry.OriginalText = "";
      this.menuItemTPPGridEntry.OwnerDraw = true;
      this.menuItemTPPGridEntry.Click += new EventHandler(this.menuItemTPPGridEntry_Click);
      this.menuItemASMOMREntry.ImageIndex = -1;
      this.menuItemASMOMREntry.ImageList = (ImageList) null;
      this.menuItemASMOMREntry.Index = 3;
      this.menuItemASMOMREntry.NoEdit = false;
      this.menuItemASMOMREntry.NoUIModify = false;
      this.menuItemASMOMREntry.OriginalText = "";
      this.menuItemASMOMREntry.OwnerDraw = true;
      this.menuItemASMOMREntry.Text = "&OMR Entry";
      this.menuItemASMOMREntry.Click += new EventHandler(this.menuItemASMOMREntry_Click);
      this.menuItemSeperator2.ImageIndex = -1;
      this.menuItemSeperator2.ImageList = (ImageList) null;
      this.menuItemSeperator2.Index = 4;
      this.menuItemSeperator2.NoEdit = false;
      this.menuItemSeperator2.NoUIModify = false;
      this.menuItemSeperator2.OriginalText = "";
      this.menuItemSeperator2.OwnerDraw = true;
      this.menuItemSeperator2.Text = "-";
      this.menuItemASMIndividualReport.ImageIndex = -1;
      this.menuItemASMIndividualReport.ImageList = (ImageList) null;
      this.menuItemASMIndividualReport.Index = 5;
      this.menuItemASMIndividualReport.NoEdit = false;
      this.menuItemASMIndividualReport.NoUIModify = false;
      this.menuItemASMIndividualReport.OriginalText = "";
      this.menuItemASMIndividualReport.OwnerDraw = true;
      this.menuItemASMIndividualReport.Text = "&Individual Report";
      this.menuItemASMIndividualReport.Click += new EventHandler(this.menuItemASMIndividualReport_Click);
      this.menuItemSeperator3.ImageIndex = -1;
      this.menuItemSeperator3.ImageList = (ImageList) null;
      this.menuItemSeperator3.Index = 6;
      this.menuItemSeperator3.NoEdit = false;
      this.menuItemSeperator3.NoUIModify = false;
      this.menuItemSeperator3.OriginalText = "";
      this.menuItemSeperator3.OwnerDraw = true;
      this.menuItemSeperator3.Text = "-";
      this.menuItemASMAspect.ImageIndex = -1;
      this.menuItemASMAspect.ImageList = (ImageList) null;
      this.menuItemASMAspect.Index = 7;
      this.menuItemASMAspect.NoEdit = false;
      this.menuItemASMAspect.NoUIModify = false;
      this.menuItemASMAspect.OriginalText = "";
      this.menuItemASMAspect.OwnerDraw = true;
      this.menuItemASMAspect.Text = "&Aspect";
      this.menuItemASMAspect.Click += new EventHandler(this.menuItemASMAspect_Click);
      this.menuItemASMGradeSet.ImageIndex = -1;
      this.menuItemASMGradeSet.ImageList = (ImageList) null;
      this.menuItemASMGradeSet.Index = 8;
      this.menuItemASMGradeSet.NoEdit = false;
      this.menuItemASMGradeSet.NoUIModify = false;
      this.menuItemASMGradeSet.OriginalText = "";
      this.menuItemASMGradeSet.OwnerDraw = true;
      this.menuItemASMGradeSet.Text = "&Grade Set";
      this.menuItemASMGradeSet.Click += new EventHandler(this.menuItemASMGradeSet_Click);
      this.menuItemASMResultSet.ImageIndex = -1;
      this.menuItemASMResultSet.ImageList = (ImageList) null;
      this.menuItemASMResultSet.Index = 9;
      this.menuItemASMResultSet.NoEdit = false;
      this.menuItemASMResultSet.NoUIModify = false;
      this.menuItemASMResultSet.OriginalText = "";
      this.menuItemASMResultSet.OwnerDraw = true;
      this.menuItemASMResultSet.Text = "&Result Set";
      this.menuItemASMResultSet.Click += new EventHandler(this.menuItemASMResultSet_Click);
      this.menuItemLookUpTables.ImageIndex = -1;
      this.menuItemLookUpTables.ImageList = (ImageList) null;
      this.menuItemLookUpTables.Index = 10;
      this.menuItemLookUpTables.NoEdit = false;
      this.menuItemLookUpTables.NoUIModify = false;
      this.menuItemLookUpTables.OriginalText = "";
      this.menuItemLookUpTables.OwnerDraw = true;
      this.menuItemLookUpTables.Text = "&Lookup Tables";
      this.menuItemLookUpTables.Click += new EventHandler(this.menuItemLookUpTables_Click);
      this.menuItemASMTemplate.ImageIndex = -1;
      this.menuItemASMTemplate.ImageList = (ImageList) null;
      this.menuItemASMTemplate.Index = 11;
      this.menuItemASMTemplate.NoEdit = false;
      this.menuItemASMTemplate.NoUIModify = false;
      this.menuItemASMTemplate.OriginalText = "";
      this.menuItemASMTemplate.OwnerDraw = true;
      this.menuItemASMTemplate.Text = "&Template";
      this.menuItemASMTemplate.Click += new EventHandler(this.menuItemASMTemplate_Click);
      this.menuItemAPPGridTemplate.Text = "&Progress Grid Template";
      this.menuItemAPPGridTemplate.Click += new EventHandler(this.menuItemAPPGridTemplate_Click);
      this.menuItemAPPGridTemplate.Index = 12;
      this.menuItemAPPGridTemplate.ImageIndex = -1;
      this.menuItemAPPGridTemplate.ImageList = (ImageList) null;
      this.menuItemAPPGridTemplate.NoEdit = false;
      this.menuItemAPPGridTemplate.NoUIModify = false;
      this.menuItemAPPGridTemplate.OriginalText = "";
      this.menuItemAPPGridTemplate.OwnerDraw = true;
      this.menuItemASMOMRTemplate.ImageIndex = -1;
      this.menuItemASMOMRTemplate.ImageList = (ImageList) null;
      this.menuItemASMOMRTemplate.Index = 13;
      this.menuItemASMOMRTemplate.NoEdit = false;
      this.menuItemASMOMRTemplate.NoUIModify = false;
      this.menuItemASMOMRTemplate.OriginalText = "";
      this.menuItemASMOMRTemplate.OwnerDraw = true;
      this.menuItemASMOMRTemplate.Text = "OMR Tem&plate";
      this.menuItemASMOMRTemplate.Click += new EventHandler(this.menuItemASMOMRTemplate_Click);
      this.menuItemPoSManagement.ImageIndex = -1;
      this.menuItemPoSManagement.ImageList = (ImageList) null;
      this.menuItemPoSManagement.Text = "Programme of Study &Management";
      this.menuItemPoSManagement.Index = 14;
      this.menuItemPoSManagement.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemPoSManagingContent,
        (MenuItem) this.menuItemPoSManagingGrades
      });
      this.menuItemPoSManagement.NoEdit = false;
      this.menuItemPoSManagement.NoUIModify = false;
      this.menuItemPoSManagement.OriginalText = "";
      this.menuItemPoSManagement.OwnerDraw = true;
      this.menuItemPoSManagement.Visible = false;
      this.menuItemPoSManagingContent.ImageIndex = -1;
      this.menuItemPoSManagingContent.ImageList = (ImageList) null;
      this.menuItemPoSManagingContent.Text = "Managing &Content";
      this.menuItemPoSManagingContent.Index = 0;
      this.menuItemPoSManagingContent.NoEdit = false;
      this.menuItemPoSManagingContent.NoUIModify = false;
      this.menuItemPoSManagingContent.OriginalText = "";
      this.menuItemPoSManagingContent.OwnerDraw = true;
      this.menuItemPoSManagingContent.Click += new EventHandler(this.menuItemPoSManagingContentClick);
      this.menuItemPoSManagingGrades.ImageIndex = -1;
      this.menuItemPoSManagingGrades.ImageList = (ImageList) null;
      this.menuItemPoSManagingGrades.Text = "Managing &Grades";
      this.menuItemPoSManagingGrades.Index = 1;
      this.menuItemPoSManagingGrades.NoEdit = false;
      this.menuItemPoSManagingGrades.NoUIModify = false;
      this.menuItemPoSManagingGrades.OriginalText = "";
      this.menuItemPoSManagingGrades.OwnerDraw = true;
      this.menuItemPoSManagingGrades.Visible = false;
      this.menuItemPoSManagingGrades.Click += new EventHandler(this.menuItemPoSManagingGradesClick);
      this.menuItemAMPASep1.ImageIndex = -1;
      this.menuItemAMPASep1.ImageList = (ImageList) null;
      this.menuItemAMPASep1.Index = 15;
      this.menuItemAMPASep1.NoEdit = false;
      this.menuItemAMPASep1.NoUIModify = false;
      this.menuItemAMPASep1.OriginalText = "";
      this.menuItemAMPASep1.OwnerDraw = true;
      this.menuItemAMPASep1.Text = "-";
      this.menuItemFFTEstimates.ImageIndex = -1;
      this.menuItemFFTEstimates.ImageList = (ImageList) null;
      this.menuItemFFTEstimates.Text = "&FFT Estimates";
      this.menuItemFFTEstimates.NoEdit = false;
      this.menuItemFFTEstimates.NoUIModify = false;
      this.menuItemFFTEstimates.OriginalText = "";
      this.menuItemFFTEstimates.OwnerDraw = true;
      this.menuItemFFTEstimates.Click += new EventHandler(this.menuItemFFTEstimates_Click);
      this.menuItemFFTSeparator.ImageIndex = -1;
      this.menuItemFFTSeparator.ImageList = (ImageList) null;
      this.menuItemFFTSeparator.NoEdit = false;
      this.menuItemFFTSeparator.NoUIModify = false;
      this.menuItemFFTSeparator.OriginalText = "";
      this.menuItemFFTSeparator.OwnerDraw = true;
      this.menuItemFFTSeparator.Text = "-";
      this.menuItemPAGroupAnalysis.ImageIndex = -1;
      this.menuItemPAGroupAnalysis.ImageList = (ImageList) null;
      this.menuItemPAGroupAnalysis.NoEdit = false;
      this.menuItemPAGroupAnalysis.NoUIModify = false;
      this.menuItemPAGroupAnalysis.OriginalText = "";
      this.menuItemPAGroupAnalysis.OwnerDraw = true;
      this.menuItemPAGroupAnalysis.Text = "&Group Analysis";
      this.menuItemPAGroupAnalysis.Click += new EventHandler(this.menuItemPAGroupAnalysis_Click);
      this.menuItemPAAspectAnalysis.ImageIndex = -1;
      this.menuItemPAAspectAnalysis.ImageList = (ImageList) null;
      this.menuItemPAAspectAnalysis.NoEdit = false;
      this.menuItemPAAspectAnalysis.NoUIModify = false;
      this.menuItemPAAspectAnalysis.OriginalText = "";
      this.menuItemPAAspectAnalysis.OwnerDraw = true;
      this.menuItemPAAspectAnalysis.Text = "&Aspect Analysis";
      this.menuItemPAAspectAnalysis.Click += new EventHandler(this.menuItemPAAspectAnalysis_Click);
      this.menuItemPAResultSetAnalysis.ImageIndex = -1;
      this.menuItemPAResultSetAnalysis.ImageList = (ImageList) null;
      this.menuItemPAResultSetAnalysis.NoEdit = false;
      this.menuItemPAResultSetAnalysis.NoUIModify = false;
      this.menuItemPAResultSetAnalysis.OriginalText = "";
      this.menuItemPAResultSetAnalysis.OwnerDraw = true;
      this.menuItemPAResultSetAnalysis.Text = "&Result Set Analysis";
      this.menuItemPAResultSetAnalysis.Click += new EventHandler(this.menuItemPAResultSetAnalysis_Click);
      this.menuItemPAChanceAnalysis.ImageIndex = -1;
      this.menuItemPAChanceAnalysis.ImageList = (ImageList) null;
      this.menuItemPAChanceAnalysis.NoEdit = false;
      this.menuItemPAChanceAnalysis.NoUIModify = false;
      this.menuItemPAChanceAnalysis.OriginalText = "";
      this.menuItemPAChanceAnalysis.OwnerDraw = true;
      this.menuItemPAChanceAnalysis.Text = "&Chance Analysis";
      this.menuItemPAChanceAnalysis.Click += new EventHandler(this.menuItemPAChanceAnalysis_Click);
      this.menuItemSeperator4.ImageIndex = -1;
      this.menuItemSeperator4.ImageList = (ImageList) null;
      this.menuItemSeperator4.NoEdit = false;
      this.menuItemSeperator4.NoUIModify = false;
      this.menuItemSeperator4.OriginalText = "";
      this.menuItemSeperator4.OwnerDraw = true;
      this.menuItemSeperator4.Text = "-";
      this.menuItemPATrendAnalysis.ImageIndex = -1;
      this.menuItemPATrendAnalysis.ImageList = (ImageList) null;
      this.menuItemPATrendAnalysis.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemPATrendAnalysisReview,
        (MenuItem) this.menuItemPATrendAnalysisPrediction
      });
      this.menuItemPATrendAnalysis.NoEdit = false;
      this.menuItemPATrendAnalysis.NoUIModify = false;
      this.menuItemPATrendAnalysis.OriginalText = "";
      this.menuItemPATrendAnalysis.OwnerDraw = true;
      this.menuItemPATrendAnalysis.Text = "&Trend Analysis";
      this.menuItemPATrendAnalysisReview.ImageIndex = -1;
      this.menuItemPATrendAnalysisReview.ImageList = (ImageList) null;
      this.menuItemPATrendAnalysisReview.Index = 0;
      this.menuItemPATrendAnalysisReview.NoEdit = false;
      this.menuItemPATrendAnalysisReview.NoUIModify = false;
      this.menuItemPATrendAnalysisReview.OriginalText = "";
      this.menuItemPATrendAnalysisReview.OwnerDraw = true;
      this.menuItemPATrendAnalysisReview.Text = "Re&view";
      this.menuItemPATrendAnalysisReview.Click += new EventHandler(this.menuItemPATrendAnalysisReview_Click);
      this.menuItemPATrendAnalysisPrediction.ImageIndex = -1;
      this.menuItemPATrendAnalysisPrediction.ImageList = (ImageList) null;
      this.menuItemPATrendAnalysisPrediction.Index = 1;
      this.menuItemPATrendAnalysisPrediction.NoEdit = false;
      this.menuItemPATrendAnalysisPrediction.NoUIModify = false;
      this.menuItemPATrendAnalysisPrediction.OriginalText = "";
      this.menuItemPATrendAnalysisPrediction.OwnerDraw = true;
      this.menuItemPATrendAnalysisPrediction.Text = "&Prediction";
      this.menuItemPATrendAnalysisPrediction.Click += new EventHandler(this.menuItemPATrendAnalysisPrediction_Click);
      this.menuItemPATrackingSeparator.Index = 20;
      this.menuItemPATrackingSeparator.Text = "-";
      this.menuItemPATrackingTemplate.Index = 21;
      this.menuItemPATrackingTemplate.Text = "Tracking Grid Templates";
      this.menuItemPATrackingTemplate.Click += new EventHandler(this.menuItemPATrackingTemplate_Click);
      this.menuItemPATrackingGrid.BaseName = "menuItemPATrackingGrid";
      this.menuItemPATrackingGrid.Index = 22;
      this.menuItemPATrackingGrid.Text = "Tracking Grids";
      this.menuItemPATrackingGrid.Click += new EventHandler(this.menuItemPATrackingGrid_Click);
      this.menuItemAssessmentPoSAnalysis.ImageIndex = -1;
      this.menuItemAssessmentPoSAnalysis.ImageList = (ImageList) null;
      this.menuItemAssessmentPoSAnalysis.Index = 26;
      this.menuItemAssessmentPoSAnalysis.MenuItems.AddRange(new MenuItem[4]
      {
        (MenuItem) this.menuItemPoSAnalysisSummativeAttainment,
        (MenuItem) this.menuItemPoSAnalysisSummativeProgress,
        (MenuItem) this.menuItemPoSAnalysisFormativeAttainment,
        (MenuItem) this.menuItemPoSAnalysisFormativeProgress
      });
      this.menuItemAssessmentPoSAnalysis.NoEdit = false;
      this.menuItemAssessmentPoSAnalysis.NoUIModify = false;
      this.menuItemAssessmentPoSAnalysis.OriginalText = "";
      this.menuItemAssessmentPoSAnalysis.OwnerDraw = true;
      this.menuItemAssessmentPoSAnalysis.Text = "Programme of &Study Analysis";
      this.menuItemPoSAnalysisSummativeAttainment.ImageIndex = -1;
      this.menuItemPoSAnalysisSummativeAttainment.ImageList = (ImageList) null;
      this.menuItemPoSAnalysisSummativeAttainment.Index = 0;
      this.menuItemPoSAnalysisSummativeAttainment.NoEdit = false;
      this.menuItemPoSAnalysisSummativeAttainment.NoUIModify = false;
      this.menuItemPoSAnalysisSummativeAttainment.OriginalText = "";
      this.menuItemPoSAnalysisSummativeAttainment.OwnerDraw = true;
      this.menuItemPoSAnalysisSummativeAttainment.Text = "&Summative Attainment";
      this.menuItemPoSAnalysisSummativeAttainment.Click += new EventHandler(this.menuItemPoSAnalysisSummativeAttainment_Click);
      this.menuItemPoSAnalysisSummativeProgress.ImageIndex = -1;
      this.menuItemPoSAnalysisSummativeProgress.ImageList = (ImageList) null;
      this.menuItemPoSAnalysisSummativeProgress.Index = 1;
      this.menuItemPoSAnalysisSummativeProgress.NoEdit = false;
      this.menuItemPoSAnalysisSummativeProgress.NoUIModify = false;
      this.menuItemPoSAnalysisSummativeProgress.OriginalText = "";
      this.menuItemPoSAnalysisSummativeProgress.OwnerDraw = true;
      this.menuItemPoSAnalysisSummativeProgress.Text = "Summative &Progress";
      this.menuItemPoSAnalysisSummativeProgress.Click += new EventHandler(this.menuItemPoSAnalysisSummativeProgress_Click);
      this.menuItemPoSAnalysisFormativeAttainment.ImageIndex = -1;
      this.menuItemPoSAnalysisFormativeAttainment.ImageList = (ImageList) null;
      this.menuItemPoSAnalysisFormativeAttainment.Index = 2;
      this.menuItemPoSAnalysisFormativeAttainment.NoEdit = false;
      this.menuItemPoSAnalysisFormativeAttainment.NoUIModify = false;
      this.menuItemPoSAnalysisFormativeAttainment.OriginalText = "";
      this.menuItemPoSAnalysisFormativeAttainment.OwnerDraw = true;
      this.menuItemPoSAnalysisFormativeAttainment.Text = "Formative &Attainment";
      this.menuItemPoSAnalysisFormativeAttainment.Click += new EventHandler(this.menuItemPoSAnalysisFormativeAttainment_Click);
      this.menuItemPoSAnalysisFormativeProgress.ImageIndex = -1;
      this.menuItemPoSAnalysisFormativeProgress.ImageList = (ImageList) null;
      this.menuItemPoSAnalysisFormativeProgress.Index = 3;
      this.menuItemPoSAnalysisFormativeProgress.NoEdit = false;
      this.menuItemPoSAnalysisFormativeProgress.NoUIModify = false;
      this.menuItemPoSAnalysisFormativeProgress.OriginalText = "";
      this.menuItemPoSAnalysisFormativeProgress.OwnerDraw = true;
      this.menuItemPoSAnalysisFormativeProgress.Text = "&Formative Progress";
      this.menuItemPoSAnalysisFormativeProgress.Click += new EventHandler(this.menuItemPoSAnalysisFormativeProgress_Click);
      this.menuItemProfilesCommentBanks.ImageIndex = -1;
      this.menuItemProfilesCommentBanks.ImageList = (ImageList) null;
      this.menuItemProfilesCommentBanks.Index = 0;
      this.menuItemProfilesCommentBanks.NoEdit = false;
      this.menuItemProfilesCommentBanks.NoUIModify = false;
      this.menuItemProfilesCommentBanks.OriginalText = "";
      this.menuItemProfilesCommentBanks.OwnerDraw = true;
      this.menuItemProfilesCommentBanks.Text = "&Comment Banks";
      this.menuItemProfilesCommentBanks.Click += new EventHandler(this.menuItemProfilesCommentBanks_Click);
      this.menuItemProfilesSessionManager.ImageIndex = -1;
      this.menuItemProfilesSessionManager.ImageList = (ImageList) null;
      this.menuItemProfilesSessionManager.Index = 1;
      this.menuItemProfilesSessionManager.NoEdit = false;
      this.menuItemProfilesSessionManager.NoUIModify = false;
      this.menuItemProfilesSessionManager.OriginalText = "";
      this.menuItemProfilesSessionManager.OwnerDraw = true;
      this.menuItemProfilesSessionManager.Text = "Session &Manager";
      this.menuItemProfilesSessionManager.Click += new EventHandler(this.menuItemProfilesSessionManager_Click);
      this.menuItemProfilesDataEntry.ImageIndex = -1;
      this.menuItemProfilesDataEntry.ImageList = (ImageList) null;
      this.menuItemProfilesDataEntry.Index = 2;
      this.menuItemProfilesDataEntry.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) this.menuItemProfilesDataEntryListEntry,
        (MenuItem) this.menuItemProfilesDataEntryGridEntry,
        (MenuItem) this.menuItemProfilesDataEntryOMREntry
      });
      this.menuItemProfilesDataEntry.NoEdit = false;
      this.menuItemProfilesDataEntry.NoUIModify = false;
      this.menuItemProfilesDataEntry.OriginalText = "";
      this.menuItemProfilesDataEntry.OwnerDraw = true;
      this.menuItemProfilesDataEntry.Text = "&Data Entry";
      this.menuItemProfilesDataEntryListEntry.ImageIndex = -1;
      this.menuItemProfilesDataEntryListEntry.ImageList = (ImageList) null;
      this.menuItemProfilesDataEntryListEntry.Index = 0;
      this.menuItemProfilesDataEntryListEntry.NoEdit = false;
      this.menuItemProfilesDataEntryListEntry.NoUIModify = false;
      this.menuItemProfilesDataEntryListEntry.OriginalText = "";
      this.menuItemProfilesDataEntryListEntry.OwnerDraw = true;
      this.menuItemProfilesDataEntryListEntry.Text = "&List Entry";
      this.menuItemProfilesDataEntryListEntry.Click += new EventHandler(this.menuItemProfilesDataEntryListEntry_Click);
      this.menuItemProfilesDataEntryGridEntry.ImageIndex = -1;
      this.menuItemProfilesDataEntryGridEntry.ImageList = (ImageList) null;
      this.menuItemProfilesDataEntryGridEntry.Index = 1;
      this.menuItemProfilesDataEntryGridEntry.NoEdit = false;
      this.menuItemProfilesDataEntryGridEntry.NoUIModify = false;
      this.menuItemProfilesDataEntryGridEntry.OriginalText = "";
      this.menuItemProfilesDataEntryGridEntry.OwnerDraw = true;
      this.menuItemProfilesDataEntryGridEntry.Text = "&Grid Entry";
      this.menuItemProfilesDataEntryGridEntry.Click += new EventHandler(this.menuItemProfilesDataEntryGridEntry_Click);
      this.menuItemProfilesDataEntryOMREntry.ImageIndex = -1;
      this.menuItemProfilesDataEntryOMREntry.ImageList = (ImageList) null;
      this.menuItemProfilesDataEntryOMREntry.Index = 2;
      this.menuItemProfilesDataEntryOMREntry.NoEdit = false;
      this.menuItemProfilesDataEntryOMREntry.NoUIModify = false;
      this.menuItemProfilesDataEntryOMREntry.OriginalText = "";
      this.menuItemProfilesDataEntryOMREntry.OwnerDraw = true;
      this.menuItemProfilesDataEntryOMREntry.Text = "&OMR Entry";
      this.menuItemProfilesDataEntryOMREntry.Click += new EventHandler(this.menuItemProfilesDataEntryOMREntry_Click);
      this.menuItemProfilesStudentProfiles.ImageIndex = -1;
      this.menuItemProfilesStudentProfiles.ImageList = (ImageList) null;
      this.menuItemProfilesStudentProfiles.Index = 4;
      this.menuItemProfilesStudentProfiles.NoEdit = false;
      this.menuItemProfilesStudentProfiles.NoUIModify = false;
      this.menuItemProfilesStudentProfiles.OriginalText = "";
      this.menuItemProfilesStudentProfiles.OwnerDraw = true;
      this.menuItemProfilesStudentProfiles.Text = "&Student Profiles";
      this.menuItemProfilesStudentProfiles.Click += new EventHandler(this.menuItemProfilesStudentProfiles_Click);
      this.menuItemProfilesReviewProfiles.ImageIndex = -1;
      this.menuItemProfilesReviewProfiles.ImageList = (ImageList) null;
      this.menuItemProfilesReviewProfiles.Index = 3;
      this.menuItemProfilesReviewProfiles.NoEdit = false;
      this.menuItemProfilesReviewProfiles.NoUIModify = false;
      this.menuItemProfilesReviewProfiles.OriginalText = "";
      this.menuItemProfilesReviewProfiles.OwnerDraw = true;
      this.menuItemProfilesReviewProfiles.Text = "&Review Profiles";
      this.menuItemProfilesReviewProfiles.Click += new EventHandler(this.menuItemProfilesReviewProfiles_Click);
      this.menuItemProfilesUDG.Index = 1;
      this.menuItemProfilesUDG.Text = "&Profiles User Defined Groups";
      this.menuItemProfilesUDG.Click += new EventHandler(this.menuItemProfilesUDG_Click);
      this.menuItemAssManUDG.BaseName = "menuItemAssManUDG";
      this.menuItemAssManUDG.Index = 2;
      this.menuItemAssManUDG.Text = "&Assessment Defined Groups";
      this.menuItemAssManUDG.Click += new EventHandler(this.menuItemAssManUDG_Click);
      this.menuItemOMRSetup.Index = 11;
      this.menuItemOMRSetup.Text = "OM&R";
      this.menuItemOMRSetup.Click += new EventHandler(this.menuItemOMRSetup_Click);
      this.menuItemReportProfiles.MenuItems.AddRange(new MenuItem[4]
      {
        (MenuItem) this.menuItemProfilesMissingComments,
        (MenuItem) this.menuItemProfilesCommentUsageAnalysis,
        (MenuItem) this.menuItemProfilesMissingEntriesReport,
        (MenuItem) this.menuItemProfilesAreasNotApprovedReport
      });
      this.menuItemProfilesMissingComments.ImageIndex = -1;
      this.menuItemProfilesMissingComments.ImageList = (ImageList) null;
      this.menuItemProfilesMissingComments.Index = 0;
      this.menuItemProfilesMissingComments.NoEdit = false;
      this.menuItemProfilesMissingComments.NoUIModify = false;
      this.menuItemProfilesMissingComments.OriginalText = "";
      this.menuItemProfilesMissingComments.OwnerDraw = true;
      this.menuItemProfilesMissingComments.Text = "&Missing Comments";
      this.menuItemProfilesMissingComments.Click += new EventHandler(this.menuItemProfilesMissingCommentsByStudents_Click);
      this.menuItemProfilesCommentUsageAnalysis.ImageIndex = -1;
      this.menuItemProfilesCommentUsageAnalysis.ImageList = (ImageList) null;
      this.menuItemProfilesCommentUsageAnalysis.Index = 1;
      this.menuItemProfilesCommentUsageAnalysis.NoEdit = false;
      this.menuItemProfilesCommentUsageAnalysis.NoUIModify = false;
      this.menuItemProfilesCommentUsageAnalysis.OriginalText = "";
      this.menuItemProfilesCommentUsageAnalysis.OwnerDraw = true;
      this.menuItemProfilesCommentUsageAnalysis.Text = "Comment &Usage Analysis";
      this.menuItemProfilesCommentUsageAnalysis.Click += new EventHandler(this.menuItemProfilesCommentUsageAnalysis_Click);
      this.menuItemProfilesMissingEntriesReport.ImageIndex = -1;
      this.menuItemProfilesMissingEntriesReport.ImageList = (ImageList) null;
      this.menuItemProfilesMissingEntriesReport.Index = 2;
      this.menuItemProfilesMissingEntriesReport.NoEdit = false;
      this.menuItemProfilesMissingEntriesReport.NoUIModify = false;
      this.menuItemProfilesMissingEntriesReport.OriginalText = "";
      this.menuItemProfilesMissingEntriesReport.OwnerDraw = true;
      this.menuItemProfilesMissingEntriesReport.Text = "Missing Entries &Report";
      this.menuItemProfilesMissingEntriesReport.Click += new EventHandler(this.menuItemProfilesMissingEntriesReport_Click);
      this.menuItemProfilesAreasNotApprovedReport.ImageIndex = -1;
      this.menuItemProfilesAreasNotApprovedReport.ImageList = (ImageList) null;
      this.menuItemProfilesAreasNotApprovedReport.Index = 3;
      this.menuItemProfilesAreasNotApprovedReport.NoEdit = false;
      this.menuItemProfilesAreasNotApprovedReport.NoUIModify = false;
      this.menuItemProfilesAreasNotApprovedReport.OriginalText = "";
      this.menuItemProfilesAreasNotApprovedReport.OwnerDraw = true;
      this.menuItemProfilesAreasNotApprovedReport.Text = "&Areas Not Approved Report";
      this.menuItemProfilesAreasNotApprovedReport.Click += new EventHandler(this.menuItemProfilesAreasNotApprovedReport_Click);
      this.menuItemASMToolsCategory.ImageIndex = -1;
      this.menuItemASMToolsCategory.ImageList = (ImageList) null;
      this.menuItemASMToolsCategory.Index = 0;
      this.menuItemASMToolsCategory.NoEdit = false;
      this.menuItemASMToolsCategory.NoUIModify = false;
      this.menuItemASMToolsCategory.OriginalText = "";
      this.menuItemASMToolsCategory.OwnerDraw = true;
      this.menuItemASMToolsCategory.Text = "&Category";
      this.menuItemASMToolsCategory.Click += new EventHandler(this.menuItemASMToolsCategory_Click);
      this.menuItemASMToolsTemplateConversion.ImageIndex = -1;
      this.menuItemASMToolsTemplateConversion.ImageList = (ImageList) null;
      this.menuItemASMToolsTemplateConversion.Index = 6;
      this.menuItemASMToolsTemplateConversion.NoEdit = false;
      this.menuItemASMToolsTemplateConversion.NoUIModify = false;
      this.menuItemASMToolsTemplateConversion.OriginalText = "";
      this.menuItemASMToolsTemplateConversion.OwnerDraw = true;
      this.menuItemASMToolsTemplateConversion.Text = "&Individual Report Template Conversion";
      this.menuItemASMToolsTemplateConversion.Click += new EventHandler(this.menuItemASMToolsTemplateConversion_Click);
      this.menuItemSeperator7.ImageIndex = -1;
      this.menuItemSeperator7.ImageList = (ImageList) null;
      this.menuItemSeperator7.Index = 1;
      this.menuItemSeperator7.NoEdit = false;
      this.menuItemSeperator7.NoUIModify = false;
      this.menuItemSeperator7.OriginalText = "";
      this.menuItemSeperator7.OwnerDraw = true;
      this.menuItemSeperator7.Text = "-";
      this.menuItemASMToolsSystemUtilities.ImageIndex = -1;
      this.menuItemASMToolsSystemUtilities.ImageList = (ImageList) null;
      this.menuItemASMToolsSystemUtilities.Index = 2;
      this.menuItemASMToolsSystemUtilities.MenuItems.AddRange(new MenuItem[10]
      {
        (MenuItem) this.menuItemASMToolsSystemUtilitiesAspects,
        (MenuItem) this.menuItemASMToolsSystemUtilitiesGradeSets,
        (MenuItem) this.menuItemASMToolsSystemUtilitiesTemplates,
        (MenuItem) this.menuItemASMToolsSystemUtilitiesMarksheets,
        (MenuItem) this.menuItemASMToolsSystemUtilitiesResults,
        (MenuItem) this.menuItemASMToolsSystemUtilitiesOMRTemplates,
        (MenuItem) this.menuItemASMToolsSystemUtilitiesOMRSheets,
        (MenuItem) this.menuItemASMToolsSystemUtilitiesIndividualReports,
        (MenuItem) this.menuItemASMToolsSystemUtilitiesResultSets,
        (MenuItem) this.menuItemASMToolsSystemUtilitiesKSMWizards
      });
      this.menuItemASMToolsSystemUtilities.NoEdit = false;
      this.menuItemASMToolsSystemUtilities.NoUIModify = false;
      this.menuItemASMToolsSystemUtilities.OriginalText = "";
      this.menuItemASMToolsSystemUtilities.OwnerDraw = true;
      this.menuItemASMToolsSystemUtilities.Text = "System &Utilities";
      this.menuItemASMToolsSystemUtilitiesAspects.ImageIndex = -1;
      this.menuItemASMToolsSystemUtilitiesAspects.ImageList = (ImageList) null;
      this.menuItemASMToolsSystemUtilitiesAspects.Index = 0;
      this.menuItemASMToolsSystemUtilitiesAspects.NoEdit = false;
      this.menuItemASMToolsSystemUtilitiesAspects.NoUIModify = false;
      this.menuItemASMToolsSystemUtilitiesAspects.OriginalText = "";
      this.menuItemASMToolsSystemUtilitiesAspects.OwnerDraw = true;
      this.menuItemASMToolsSystemUtilitiesAspects.Text = "&Aspects";
      this.menuItemASMToolsSystemUtilitiesAspects.Click += new EventHandler(this.menuItemASMToolsSystemUtilitiesAspects_Click);
      this.menuItemASMToolsSystemUtilitiesGradeSets.ImageIndex = -1;
      this.menuItemASMToolsSystemUtilitiesGradeSets.ImageList = (ImageList) null;
      this.menuItemASMToolsSystemUtilitiesGradeSets.Index = 1;
      this.menuItemASMToolsSystemUtilitiesGradeSets.NoEdit = false;
      this.menuItemASMToolsSystemUtilitiesGradeSets.NoUIModify = false;
      this.menuItemASMToolsSystemUtilitiesGradeSets.OriginalText = "";
      this.menuItemASMToolsSystemUtilitiesGradeSets.OwnerDraw = true;
      this.menuItemASMToolsSystemUtilitiesGradeSets.Text = "&Grade Sets";
      this.menuItemASMToolsSystemUtilitiesGradeSets.Click += new EventHandler(this.menuItemASMToolsSystemUtilitiesGradeSets_Click);
      this.menuItemASMToolsSystemUtilitiesTemplates.ImageIndex = -1;
      this.menuItemASMToolsSystemUtilitiesTemplates.ImageList = (ImageList) null;
      this.menuItemASMToolsSystemUtilitiesTemplates.Index = 2;
      this.menuItemASMToolsSystemUtilitiesTemplates.NoEdit = false;
      this.menuItemASMToolsSystemUtilitiesTemplates.NoUIModify = false;
      this.menuItemASMToolsSystemUtilitiesTemplates.OriginalText = "";
      this.menuItemASMToolsSystemUtilitiesTemplates.OwnerDraw = true;
      this.menuItemASMToolsSystemUtilitiesTemplates.Text = "&Templates";
      this.menuItemASMToolsSystemUtilitiesTemplates.Click += new EventHandler(this.menuItemASMToolsSystemUtilitiesTemplates_Click);
      this.menuItemASMToolsSystemUtilitiesMarksheets.ImageIndex = -1;
      this.menuItemASMToolsSystemUtilitiesMarksheets.ImageList = (ImageList) null;
      this.menuItemASMToolsSystemUtilitiesMarksheets.Index = 3;
      this.menuItemASMToolsSystemUtilitiesMarksheets.NoEdit = false;
      this.menuItemASMToolsSystemUtilitiesMarksheets.NoUIModify = false;
      this.menuItemASMToolsSystemUtilitiesMarksheets.OriginalText = "";
      this.menuItemASMToolsSystemUtilitiesMarksheets.OwnerDraw = true;
      this.menuItemASMToolsSystemUtilitiesMarksheets.Text = "&Marksheets";
      this.menuItemASMToolsSystemUtilitiesMarksheets.Click += new EventHandler(this.menuItemASMToolsSystemUtilitiesMarksheets_Click);
      this.menuItemASMToolsSystemUtilitiesResults.ImageIndex = -1;
      this.menuItemASMToolsSystemUtilitiesResults.ImageList = (ImageList) null;
      this.menuItemASMToolsSystemUtilitiesResults.Index = 4;
      this.menuItemASMToolsSystemUtilitiesResults.NoEdit = false;
      this.menuItemASMToolsSystemUtilitiesResults.NoUIModify = false;
      this.menuItemASMToolsSystemUtilitiesResults.OriginalText = "";
      this.menuItemASMToolsSystemUtilitiesResults.OwnerDraw = true;
      this.menuItemASMToolsSystemUtilitiesResults.Text = "&Results";
      this.menuItemASMToolsSystemUtilitiesResults.Click += new EventHandler(this.menuItemASMToolsSystemUtilitiesResults_Click);
      this.menuItemASMToolsSystemUtilitiesOMRTemplates.ImageIndex = -1;
      this.menuItemASMToolsSystemUtilitiesOMRTemplates.ImageList = (ImageList) null;
      this.menuItemASMToolsSystemUtilitiesOMRTemplates.Index = 5;
      this.menuItemASMToolsSystemUtilitiesOMRTemplates.NoEdit = false;
      this.menuItemASMToolsSystemUtilitiesOMRTemplates.NoUIModify = false;
      this.menuItemASMToolsSystemUtilitiesOMRTemplates.OriginalText = "";
      this.menuItemASMToolsSystemUtilitiesOMRTemplates.OwnerDraw = true;
      this.menuItemASMToolsSystemUtilitiesOMRTemplates.Text = "&OMR Templates";
      this.menuItemASMToolsSystemUtilitiesOMRTemplates.Click += new EventHandler(this.menuItemASMToolsSystemUtilitiesOMRTemplates_Click);
      this.menuItemASMToolsSystemUtilitiesOMRSheets.ImageIndex = -1;
      this.menuItemASMToolsSystemUtilitiesOMRSheets.ImageList = (ImageList) null;
      this.menuItemASMToolsSystemUtilitiesOMRSheets.Index = 6;
      this.menuItemASMToolsSystemUtilitiesOMRSheets.NoEdit = false;
      this.menuItemASMToolsSystemUtilitiesOMRSheets.NoUIModify = false;
      this.menuItemASMToolsSystemUtilitiesOMRSheets.OriginalText = "";
      this.menuItemASMToolsSystemUtilitiesOMRSheets.OwnerDraw = true;
      this.menuItemASMToolsSystemUtilitiesOMRSheets.Text = "OMR &Sheets";
      this.menuItemASMToolsSystemUtilitiesOMRSheets.Click += new EventHandler(this.menuItemASMToolsSystemUtilitiesOMRSheets_Click);
      this.menuItemASMToolsSystemUtilitiesIndividualReports.ImageIndex = -1;
      this.menuItemASMToolsSystemUtilitiesIndividualReports.ImageList = (ImageList) null;
      this.menuItemASMToolsSystemUtilitiesIndividualReports.Index = 7;
      this.menuItemASMToolsSystemUtilitiesIndividualReports.NoEdit = false;
      this.menuItemASMToolsSystemUtilitiesIndividualReports.NoUIModify = false;
      this.menuItemASMToolsSystemUtilitiesIndividualReports.OriginalText = "";
      this.menuItemASMToolsSystemUtilitiesIndividualReports.OwnerDraw = true;
      this.menuItemASMToolsSystemUtilitiesIndividualReports.Text = "&Individual Reports";
      this.menuItemASMToolsSystemUtilitiesIndividualReports.Click += new EventHandler(this.menuItemASMToolsSystemUtilitiesIndividualReports_Click);
      this.menuItemASMToolsSystemUtilitiesResultSets.ImageIndex = -1;
      this.menuItemASMToolsSystemUtilitiesResultSets.ImageList = (ImageList) null;
      this.menuItemASMToolsSystemUtilitiesResultSets.Index = 8;
      this.menuItemASMToolsSystemUtilitiesResultSets.NoEdit = false;
      this.menuItemASMToolsSystemUtilitiesResultSets.NoUIModify = false;
      this.menuItemASMToolsSystemUtilitiesResultSets.OriginalText = "";
      this.menuItemASMToolsSystemUtilitiesResultSets.OwnerDraw = true;
      this.menuItemASMToolsSystemUtilitiesResultSets.Text = "R&esult Sets";
      this.menuItemASMToolsSystemUtilitiesResultSets.Click += new EventHandler(this.menuItemASMToolsSystemUtilitiesResultSets_Click);
      this.menuItemASMToolsSystemUtilitiesKSMWizards.ImageIndex = -1;
      this.menuItemASMToolsSystemUtilitiesKSMWizards.ImageList = (ImageList) null;
      this.menuItemASMToolsSystemUtilitiesKSMWizards.Index = 9;
      this.menuItemASMToolsSystemUtilitiesKSMWizards.NoEdit = false;
      this.menuItemASMToolsSystemUtilitiesKSMWizards.NoUIModify = false;
      this.menuItemASMToolsSystemUtilitiesKSMWizards.OriginalText = "";
      this.menuItemASMToolsSystemUtilitiesKSMWizards.OwnerDraw = true;
      this.menuItemASMToolsSystemUtilitiesKSMWizards.Text = "&KSM Wizards";
      this.menuItemASMToolsSystemUtilitiesKSMWizards.Click += new EventHandler(this.menuItemASMToolsSystemUtilitiesKSMWizards_Click);
      this.menuItemSeperator8.ImageIndex = -1;
      this.menuItemSeperator8.ImageList = (ImageList) null;
      this.menuItemSeperator8.Index = 3;
      this.menuItemSeperator8.NoEdit = false;
      this.menuItemSeperator8.NoUIModify = false;
      this.menuItemSeperator8.OriginalText = "";
      this.menuItemSeperator8.OwnerDraw = true;
      this.menuItemSeperator8.Text = "-";
      this.menuItemASMToolsWizardManager.ImageIndex = -1;
      this.menuItemASMToolsWizardManager.ImageList = (ImageList) null;
      this.menuItemASMToolsWizardManager.Index = 4;
      this.menuItemASMToolsWizardManager.NoEdit = false;
      this.menuItemASMToolsWizardManager.NoUIModify = false;
      this.menuItemASMToolsWizardManager.OriginalText = "";
      this.menuItemASMToolsWizardManager.OwnerDraw = true;
      this.menuItemASMToolsWizardManager.Text = "&Wizard Manager";
      this.menuItemASMToolsWizardManager.Click += new EventHandler(this.menuItemASMToolsWizardManager_Click);
      this.menuItemASMToolsAssessmentMapping.ImageIndex = -1;
      this.menuItemASMToolsAssessmentMapping.ImageList = (ImageList) null;
      this.menuItemASMToolsAssessmentMapping.Index = 5;
      this.menuItemASMToolsAssessmentMapping.NoEdit = false;
      this.menuItemASMToolsAssessmentMapping.NoUIModify = false;
      this.menuItemASMToolsAssessmentMapping.OriginalText = "";
      this.menuItemASMToolsAssessmentMapping.OwnerDraw = true;
      this.menuItemASMToolsAssessmentMapping.Text = "&Assessment Mapping Tool";
      this.menuItemASMToolsAssessmentMapping.Click += new EventHandler(this.menuItemASMToolsAssessmentMapping_Click);
      this.menuItemASMToolsOptions.ImageIndex = -1;
      this.menuItemASMToolsOptions.ImageList = (ImageList) null;
      this.menuItemASMToolsOptions.Index = 5;
      this.menuItemASMToolsOptions.NoEdit = false;
      this.menuItemASMToolsOptions.NoUIModify = false;
      this.menuItemASMToolsOptions.OriginalText = "";
      this.menuItemASMToolsOptions.OwnerDraw = true;
      this.menuItemASMToolsOptions.Text = "&Options";
      this.menuItemASMToolsOptions.Click += new EventHandler(this.menuItemASMToolsOptions_Click);
      this.menuItemASMToolsFFTOptions.ImageIndex = -1;
      this.menuItemASMToolsFFTOptions.ImageList = (ImageList) null;
      this.menuItemASMToolsFFTOptions.Index = 6;
      this.menuItemASMToolsFFTOptions.NoEdit = false;
      this.menuItemASMToolsFFTOptions.NoUIModify = false;
      this.menuItemASMToolsFFTOptions.OriginalText = "";
      this.menuItemASMToolsFFTOptions.OwnerDraw = true;
      this.menuItemASMToolsFFTOptions.Text = "&FFT Options";
      this.menuItemASMToolsFFTOptions.Click += new EventHandler(this.menuItemASMToolsFFTOptions_Click);
      this.menuItemToolsPAAnalysis.BaseName = "menuItemToolsPAAnalysis";
      this.menuItemToolsPAAnalysis.ImageIndex = -1;
      this.menuItemToolsPAAnalysis.ImageList = (ImageList) null;
      this.menuItemToolsPAAnalysis.Index = 1;
      this.menuItemToolsPAAnalysis.NoEdit = false;
      this.menuItemToolsPAAnalysis.NoUIModify = false;
      this.menuItemToolsPAAnalysis.OriginalText = "";
      this.menuItemToolsPAAnalysis.OwnerDraw = true;
      this.menuItemToolsPAAnalysis.Text = "Analysis";
      this.menuItemToolsPATools.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemToolsASMTools,
        (MenuItem) this.menuItemToolsPAAnalysis,
        (MenuItem) this.menuItemToolsProfilesTools,
        (MenuItem) this.menuItemASMToolsOptions,
        (MenuItem) this.menuItemASMToolsFFTOptions
      });
      this.menuItemExamsA2CCommunications = new UIMenuItem();
      this.menuItemExamsA2CCommunications.BaseName = "A2C Communications";
      this.menuItemExamsA2CCommunications.ImageIndex = -1;
      this.menuItemExamsA2CCommunications.ImageList = (ImageList) null;
      this.menuItemExamsA2CCommunications.Index = 1;
      this.menuItemExamsA2CCommunications.NoEdit = false;
      this.menuItemExamsA2CCommunications.NoUIModify = false;
      this.menuItemExamsA2CCommunications.OriginalText = "";
      this.menuItemExamsA2CCommunications.OwnerDraw = true;
      this.menuItemExamsA2CCommunications.Text = "A2C Communications";
      this.menuItemExamsA2CCommunications.Click += new EventHandler(this.menuItemExamsA2CCommunications_Click);
      this.menuItemExamsA2CViewProductCatalogue = new UIMenuItem();
      this.menuItemExamsA2CViewProductCatalogue.BaseName = "A2C View Product Catalogue";
      this.menuItemExamsA2CViewProductCatalogue.ImageIndex = -1;
      this.menuItemExamsA2CViewProductCatalogue.ImageList = (ImageList) null;
      this.menuItemExamsA2CViewProductCatalogue.Index = 1;
      this.menuItemExamsA2CViewProductCatalogue.NoEdit = false;
      this.menuItemExamsA2CViewProductCatalogue.NoUIModify = false;
      this.menuItemExamsA2CViewProductCatalogue.OriginalText = "";
      this.menuItemExamsA2CViewProductCatalogue.OwnerDraw = true;
      this.menuItemExamsA2CViewProductCatalogue.Text = "A2C View Product Catalogue";
      this.menuItemExamsA2CViewProductCatalogue.Click += new EventHandler(this.menuItemExamsA2CViewProductCatalogue_Click);
      this.menuItemExamsA2CLoadProductCatalogue = new UIMenuItem();
      this.menuItemExamsA2CLoadProductCatalogue.BaseName = "A2C Load Product Catalogue From File";
      this.menuItemExamsA2CLoadProductCatalogue.ImageIndex = -1;
      this.menuItemExamsA2CLoadProductCatalogue.ImageList = (ImageList) null;
      this.menuItemExamsA2CLoadProductCatalogue.Index = 1;
      this.menuItemExamsA2CLoadProductCatalogue.NoEdit = false;
      this.menuItemExamsA2CLoadProductCatalogue.NoUIModify = false;
      this.menuItemExamsA2CLoadProductCatalogue.OriginalText = "";
      this.menuItemExamsA2CLoadProductCatalogue.OwnerDraw = true;
      this.menuItemExamsA2CLoadProductCatalogue.Text = "A2C Load Product Catalogue From File";
      this.menuItemExamsA2CLoadProductCatalogue.Click += new EventHandler(this.menuItemExamsA2CLoadProductCatalogue_Click);
      this.menuItemExamsA2CLoadResults = new UIMenuItem();
      this.menuItemExamsA2CLoadResults.BaseName = "A2C Load Results From File";
      this.menuItemExamsA2CLoadResults.ImageIndex = -1;
      this.menuItemExamsA2CLoadResults.ImageList = (ImageList) null;
      this.menuItemExamsA2CLoadResults.Index = 1;
      this.menuItemExamsA2CLoadResults.NoEdit = false;
      this.menuItemExamsA2CLoadResults.NoUIModify = false;
      this.menuItemExamsA2CLoadResults.OriginalText = "";
      this.menuItemExamsA2CLoadResults.OwnerDraw = true;
      this.menuItemExamsA2CLoadResults.Text = "A2C Load Results From File";
      this.menuItemExamsA2CLoadResults.Click += new EventHandler(this.menuItemExamsA2CLoadResults_Click);
      this.menuItemExamsA2CSettings = new UIMenuItem();
      this.menuItemExamsA2CSettings.BaseName = "A2C Load Results From File";
      this.menuItemExamsA2CSettings.ImageIndex = -1;
      this.menuItemExamsA2CSettings.ImageList = (ImageList) null;
      this.menuItemExamsA2CSettings.Index = 1;
      this.menuItemExamsA2CSettings.NoEdit = false;
      this.menuItemExamsA2CSettings.NoUIModify = false;
      this.menuItemExamsA2CSettings.OriginalText = "";
      this.menuItemExamsA2CSettings.OwnerDraw = true;
      this.menuItemExamsA2CSettings.Text = "A2C User Settings";
      this.menuItemExamsA2CSettings.Click += new EventHandler(this.menuItemExamsA2CSettings_Click);
      this.menuItemExamsA2CSubmitOrders = new UIMenuItem();
      this.menuItemExamsA2CSubmitOrders.BaseName = "A2C Submit Orders";
      this.menuItemExamsA2CSubmitOrders.ImageIndex = -1;
      this.menuItemExamsA2CSubmitOrders.ImageList = (ImageList) null;
      this.menuItemExamsA2CSubmitOrders.Index = 1;
      this.menuItemExamsA2CSubmitOrders.NoEdit = false;
      this.menuItemExamsA2CSubmitOrders.NoUIModify = false;
      this.menuItemExamsA2CSubmitOrders.OriginalText = "";
      this.menuItemExamsA2CSubmitOrders.OwnerDraw = true;
      this.menuItemExamsA2CSubmitOrders.Text = "A2C Submit Orders";
      this.menuItemExamsA2CSubmitOrders.Click += new EventHandler(this.menuItemExamsA2CSubmitOrders_Click);
      this.menuItemExamsA2CSubmitCoursework = new UIMenuItem();
      this.menuItemExamsA2CSubmitCoursework.BaseName = "A2C Submit Coursework";
      this.menuItemExamsA2CSubmitCoursework.ImageIndex = -1;
      this.menuItemExamsA2CSubmitCoursework.ImageList = (ImageList) null;
      this.menuItemExamsA2CSubmitCoursework.Index = 1;
      this.menuItemExamsA2CSubmitCoursework.NoEdit = false;
      this.menuItemExamsA2CSubmitCoursework.NoUIModify = false;
      this.menuItemExamsA2CSubmitCoursework.OriginalText = "";
      this.menuItemExamsA2CSubmitCoursework.OwnerDraw = true;
      this.menuItemExamsA2CSubmitCoursework.Text = "A2C Submit Coursework";
      this.menuItemExamsA2CSubmitCoursework.Click += new EventHandler(this.menuItemExamsA2CSubmitCoursework_Click);
      this.menuItemExamsA2CAmendLearnerDetails = new UIMenuItem();
      this.menuItemExamsA2CAmendLearnerDetails.BaseName = "A2C Amend Learner Details";
      this.menuItemExamsA2CAmendLearnerDetails.ImageIndex = -1;
      this.menuItemExamsA2CAmendLearnerDetails.ImageList = (ImageList) null;
      this.menuItemExamsA2CAmendLearnerDetails.Index = 1;
      this.menuItemExamsA2CAmendLearnerDetails.NoEdit = false;
      this.menuItemExamsA2CAmendLearnerDetails.NoUIModify = false;
      this.menuItemExamsA2CAmendLearnerDetails.OriginalText = "";
      this.menuItemExamsA2CAmendLearnerDetails.OwnerDraw = true;
      this.menuItemExamsA2CAmendLearnerDetails.Text = "A2C Amend Learner Details";
      this.menuItemExamsA2CAmendLearnerDetails.Click += new EventHandler(this.menuItemExamsA2CAmendLearnerDetails_Click);
      this.menuItemExamsA2CSummary = new UIMenuItem();
      this.menuItemExamsA2CSummary.BaseName = "A2C Summary";
      this.menuItemExamsA2CSummary.ImageIndex = -1;
      this.menuItemExamsA2CSummary.ImageList = (ImageList) null;
      this.menuItemExamsA2CSummary.NoEdit = false;
      this.menuItemExamsA2CSummary.NoUIModify = false;
      this.menuItemExamsA2CSummary.OriginalText = "";
      this.menuItemExamsA2CSummary.OwnerDraw = true;
      this.menuItemExamsA2CSummary.Text = "A2C Summary";
      this.menuItemExamsA2CSummary.Click += new EventHandler(this.menuItemExamsA2CSummary_Click);
      this.menuItemExamsA2CGRPProcesses = new UIMenuItem();
      this.menuItemExamsA2CGRPProcesses.BaseName = "A2C Processes";
      this.menuItemExamsA2CGRPProcesses.Text = "A2C Processes";
      this.menuItemExamsA2CGRPProcesses.OwnerDraw = true;
      this.menuItemExamsA2CGRPTools = new UIMenuItem();
      this.menuItemExamsA2CGRPTools.BaseName = "A2C Tools";
      this.menuItemExamsA2CGRPTools.Text = "A2C Tools";
      this.menuItemExamsA2CGRPTools.OwnerDraw = true;
      this.menuItemA2CSeparator.OwnerDraw = true;
      this.menuItemA2CSeparator.Text = "-";
      SIMS.UserInterfaces.Exams.MainContainerHelper.ExamsMainMenu.MenuItems.AddRange(new MenuItem[4]
      {
        (MenuItem) this.menuItemA2CSeparator,
        (MenuItem) this.menuItemExamsA2CCommunications,
        (MenuItem) this.menuItemExamsA2CGRPProcesses,
        (MenuItem) this.menuItemExamsA2CGRPTools
      });
      this.menuItemExamsA2CGRPProcesses.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemExamsA2CViewProductCatalogue,
        (MenuItem) this.menuItemExamsA2CSubmitOrders,
        (MenuItem) this.menuItemExamsA2CSubmitCoursework,
        (MenuItem) this.menuItemExamsA2CAmendLearnerDetails,
        (MenuItem) this.menuItemExamsA2CSummary
      });
      this.menuItemExamsA2CGRPTools.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) this.menuItemExamsA2CLoadProductCatalogue,
        (MenuItem) this.menuItemExamsA2CLoadResults,
        (MenuItem) this.menuItemExamsA2CSettings
      });
      this.menuItemToolsASMTools.MenuItems.AddRange(new MenuItem[7]
      {
        (MenuItem) this.menuItemASMToolsCategory,
        (MenuItem) this.menuItemSeperator7,
        (MenuItem) this.menuItemASMToolsSystemUtilities,
        (MenuItem) this.menuItemSeperator8,
        (MenuItem) this.menuItemASMToolsWizardManager,
        (MenuItem) this.menuItemASMToolsAssessmentMapping,
        (MenuItem) this.menuItemASMToolsTemplateConversion
      });
      this.menuItemToolsPAAnalysis.MenuItems.AddRange(new MenuItem[7]
      {
        (MenuItem) this.menuItemPAToolsValueAddedLines,
        (MenuItem) this.menuItemPAToolsProgressionLines,
        (MenuItem) this.menuItemSeperator9,
        (MenuItem) this.menuItemPAToolsSystemUtilities,
        (MenuItem) this.menuItemSeperator10,
        (MenuItem) this.menuItemPAToolsBuildExamAnalysis,
        (MenuItem) this.menuItemPAToolsDefineSettings
      });
      this.menuItemPAToolsValueAddedLines.ImageIndex = -1;
      this.menuItemPAToolsValueAddedLines.ImageList = (ImageList) null;
      this.menuItemPAToolsValueAddedLines.Index = 0;
      this.menuItemPAToolsValueAddedLines.NoEdit = false;
      this.menuItemPAToolsValueAddedLines.NoUIModify = false;
      this.menuItemPAToolsValueAddedLines.OriginalText = "";
      this.menuItemPAToolsValueAddedLines.OwnerDraw = true;
      this.menuItemPAToolsValueAddedLines.Text = "&Value Added Lines";
      this.menuItemPAToolsValueAddedLines.Click += new EventHandler(this.menuItemPAToolsValueAddedLines_Click);
      this.menuItemPAToolsProgressionLines.ImageIndex = -1;
      this.menuItemPAToolsProgressionLines.ImageList = (ImageList) null;
      this.menuItemPAToolsProgressionLines.Index = 1;
      this.menuItemPAToolsProgressionLines.NoEdit = false;
      this.menuItemPAToolsProgressionLines.NoUIModify = false;
      this.menuItemPAToolsProgressionLines.OriginalText = "";
      this.menuItemPAToolsProgressionLines.OwnerDraw = true;
      this.menuItemPAToolsProgressionLines.Text = "&Progression Lines";
      this.menuItemPAToolsProgressionLines.Click += new EventHandler(this.menuItemPAToolsProgressionLines_Click);
      this.menuItemSeperator9.ImageIndex = -1;
      this.menuItemSeperator9.ImageList = (ImageList) null;
      this.menuItemSeperator9.Index = 2;
      this.menuItemSeperator9.NoEdit = false;
      this.menuItemSeperator9.NoUIModify = false;
      this.menuItemSeperator9.OriginalText = "";
      this.menuItemSeperator9.OwnerDraw = true;
      this.menuItemSeperator9.Text = "-";
      this.menuItemPAToolsSystemUtilities.ImageIndex = -1;
      this.menuItemPAToolsSystemUtilities.ImageList = (ImageList) null;
      this.menuItemPAToolsSystemUtilities.Index = 3;
      this.menuItemPAToolsSystemUtilities.NoEdit = false;
      this.menuItemPAToolsSystemUtilities.NoUIModify = false;
      this.menuItemPAToolsSystemUtilities.OriginalText = "";
      this.menuItemPAToolsSystemUtilities.OwnerDraw = true;
      this.menuItemPAToolsSystemUtilities.Text = "&System Utilities";
      this.menuItemPAToolsSystemUtilities.MenuItems.AddRange(new MenuItem[4]
      {
        (MenuItem) this.menuItemPAToolsSystemUtilitiesTrendLines,
        (MenuItem) this.menuItemPAToolsSystemUtilitiesTrackingTemplates,
        (MenuItem) this.menuItemPAToolsSystemUtilitiesTrackingGrids,
        (MenuItem) this.menuItemPAToolsSystemUtilitiesAnalysisResources
      });
      this.menuItemPAToolsSystemUtilitiesTrendLines.ImageIndex = -1;
      this.menuItemPAToolsSystemUtilitiesTrendLines.ImageList = (ImageList) null;
      this.menuItemPAToolsSystemUtilitiesTrendLines.Index = 0;
      this.menuItemPAToolsSystemUtilitiesTrendLines.NoEdit = false;
      this.menuItemPAToolsSystemUtilitiesTrendLines.NoUIModify = false;
      this.menuItemPAToolsSystemUtilitiesTrendLines.OriginalText = "";
      this.menuItemPAToolsSystemUtilitiesTrendLines.OwnerDraw = true;
      this.menuItemPAToolsSystemUtilitiesTrendLines.Text = "Trend &Lines";
      this.menuItemPAToolsSystemUtilitiesTrendLines.Click += new EventHandler(this.menuItemPAToolsSystemUtilitiesTrendLines_Click);
      this.menuItemPAToolsSystemUtilitiesTrackingTemplates.ImageIndex = -1;
      this.menuItemPAToolsSystemUtilitiesTrackingTemplates.ImageList = (ImageList) null;
      this.menuItemPAToolsSystemUtilitiesTrackingTemplates.Index = 1;
      this.menuItemPAToolsSystemUtilitiesTrackingTemplates.NoEdit = false;
      this.menuItemPAToolsSystemUtilitiesTrackingTemplates.NoUIModify = false;
      this.menuItemPAToolsSystemUtilitiesTrackingTemplates.OriginalText = "";
      this.menuItemPAToolsSystemUtilitiesTrackingTemplates.OwnerDraw = true;
      this.menuItemPAToolsSystemUtilitiesTrackingTemplates.Text = "Tracking Grid &Templates";
      this.menuItemPAToolsSystemUtilitiesTrackingTemplates.Click += new EventHandler(this.menuItemPAToolsSystemUtilitiesTrackingTemplates_Click);
      this.menuItemPAToolsSystemUtilitiesTrackingGrids.ImageIndex = -1;
      this.menuItemPAToolsSystemUtilitiesTrackingGrids.ImageList = (ImageList) null;
      this.menuItemPAToolsSystemUtilitiesTrackingGrids.Index = 2;
      this.menuItemPAToolsSystemUtilitiesTrackingGrids.NoEdit = false;
      this.menuItemPAToolsSystemUtilitiesTrackingGrids.NoUIModify = false;
      this.menuItemPAToolsSystemUtilitiesTrackingGrids.OriginalText = "";
      this.menuItemPAToolsSystemUtilitiesTrackingGrids.OwnerDraw = true;
      this.menuItemPAToolsSystemUtilitiesTrackingGrids.Text = "Tracking &Grids";
      this.menuItemPAToolsSystemUtilitiesTrackingGrids.Click += new EventHandler(this.menuItemPAToolsSystemUtilitiesTrackingGrids_Click);
      this.menuItemPAToolsSystemUtilitiesAnalysisResources.ImageIndex = -1;
      this.menuItemPAToolsSystemUtilitiesAnalysisResources.ImageList = (ImageList) null;
      this.menuItemPAToolsSystemUtilitiesAnalysisResources.Index = 3;
      this.menuItemPAToolsSystemUtilitiesAnalysisResources.NoEdit = false;
      this.menuItemPAToolsSystemUtilitiesAnalysisResources.NoUIModify = false;
      this.menuItemPAToolsSystemUtilitiesAnalysisResources.OriginalText = "";
      this.menuItemPAToolsSystemUtilitiesAnalysisResources.OwnerDraw = true;
      this.menuItemPAToolsSystemUtilitiesAnalysisResources.Text = "&Analysis Resources";
      this.menuItemPAToolsSystemUtilitiesAnalysisResources.Click += new EventHandler(this.menuItemPAToolsSystemUtilitiesAnalysisResources_Click);
      this.menuItemSeperator10.ImageIndex = -1;
      this.menuItemSeperator10.ImageList = (ImageList) null;
      this.menuItemSeperator10.Index = 4;
      this.menuItemSeperator10.NoEdit = false;
      this.menuItemSeperator10.NoUIModify = false;
      this.menuItemSeperator10.OriginalText = "";
      this.menuItemSeperator10.OwnerDraw = true;
      this.menuItemSeperator10.Text = "-";
      this.menuItemPAToolsBuildExamAnalysis.ImageIndex = -1;
      this.menuItemPAToolsBuildExamAnalysis.ImageList = (ImageList) null;
      this.menuItemPAToolsBuildExamAnalysis.Index = 5;
      this.menuItemPAToolsBuildExamAnalysis.NoEdit = false;
      this.menuItemPAToolsBuildExamAnalysis.NoUIModify = false;
      this.menuItemPAToolsBuildExamAnalysis.OriginalText = "";
      this.menuItemPAToolsBuildExamAnalysis.OwnerDraw = true;
      this.menuItemPAToolsBuildExamAnalysis.Text = "E&xam Analyses";
      this.menuItemPAToolsBuildExamAnalysis.Click += new EventHandler(this.menuItemPAToolsBuildExamAnalysis_Click);
      this.menuItemPAToolsDefineSettings.BaseName = "menuItemPAToolsDefineSettings";
      this.menuItemPAToolsDefineSettings.ImageIndex = -1;
      this.menuItemPAToolsDefineSettings.ImageList = (ImageList) null;
      this.menuItemPAToolsDefineSettings.Index = 6;
      this.menuItemPAToolsDefineSettings.NoEdit = false;
      this.menuItemPAToolsDefineSettings.NoUIModify = false;
      this.menuItemPAToolsDefineSettings.OriginalText = "";
      this.menuItemPAToolsDefineSettings.OwnerDraw = true;
      this.menuItemPAToolsDefineSettings.Text = "Define Analysis &Settings";
      this.menuItemPAToolsDefineSettings.Click += new EventHandler(this.menuItemPAToolsDefineSettings_Click);
      this.menuItemToolsProfilesTools.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) this.menuItemProfilesToolsCompareCommentBanks,
        (MenuItem) this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets,
        (MenuItem) this.menuItemProfilesToolsAddNamesToDictionary
      });
      this.menuItemProfilesToolsCompareCommentBanks.ImageIndex = -1;
      this.menuItemProfilesToolsCompareCommentBanks.ImageList = (ImageList) null;
      this.menuItemProfilesToolsCompareCommentBanks.Index = 0;
      this.menuItemProfilesToolsCompareCommentBanks.NoEdit = false;
      this.menuItemProfilesToolsCompareCommentBanks.NoUIModify = false;
      this.menuItemProfilesToolsCompareCommentBanks.OriginalText = "";
      this.menuItemProfilesToolsCompareCommentBanks.OwnerDraw = true;
      this.menuItemProfilesToolsCompareCommentBanks.Text = "&Compare Comment Banks";
      this.menuItemProfilesToolsCompareCommentBanks.Click += new EventHandler(this.menuItemProfilesToolsCompareCommentBanks_Click);
      this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets.ImageIndex = -1;
      this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets.ImageList = (ImageList) null;
      this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets.Index = 1;
      this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets.NoEdit = false;
      this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets.NoUIModify = false;
      this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets.OriginalText = "";
      this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets.OwnerDraw = true;
      this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets.Text = "&Batch Printing of Class Check Sheets";
      this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets.Click += new EventHandler(this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets_Click);
      this.menuItemProfilesToolsAddNamesToDictionary.ImageIndex = -1;
      this.menuItemProfilesToolsAddNamesToDictionary.ImageList = (ImageList) null;
      this.menuItemProfilesToolsAddNamesToDictionary.Index = 2;
      this.menuItemProfilesToolsAddNamesToDictionary.NoEdit = false;
      this.menuItemProfilesToolsAddNamesToDictionary.NoUIModify = false;
      this.menuItemProfilesToolsAddNamesToDictionary.OriginalText = "";
      this.menuItemProfilesToolsAddNamesToDictionary.OwnerDraw = true;
      this.menuItemProfilesToolsAddNamesToDictionary.Text = "&Add Names to Dictionary";
      this.menuItemProfilesToolsAddNamesToDictionary.Click += new EventHandler(this.menuItemProfilesToolsAddNamesToDictionary_Click);
      this.menuItemDataOutASM.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemDataOutASMExport,
        (MenuItem) this.menuItemDataOutASMWResourceUtilityExport
      });
      this.menuItemDataOutASMExport.ImageIndex = -1;
      this.menuItemDataOutASMExport.ImageList = (ImageList) null;
      this.menuItemDataOutASMExport.Index = 0;
      this.menuItemDataOutASMExport.NoEdit = false;
      this.menuItemDataOutASMExport.NoUIModify = false;
      this.menuItemDataOutASMExport.OriginalText = "";
      this.menuItemDataOutASMExport.OwnerDraw = true;
      this.menuItemDataOutASMExport.Text = "&Export";
      this.menuItemDataOutASMExport.Click += new EventHandler(this.menuItemDataOutASMExport_Click);
      this.menuItemDataOutASMWResourceUtilityExport.ImageIndex = -1;
      this.menuItemDataOutASMWResourceUtilityExport.ImageList = (ImageList) null;
      this.menuItemDataOutASMWResourceUtilityExport.Index = 1;
      this.menuItemDataOutASMWResourceUtilityExport.NoEdit = false;
      this.menuItemDataOutASMWResourceUtilityExport.NoUIModify = false;
      this.menuItemDataOutASMWResourceUtilityExport.OriginalText = "";
      this.menuItemDataOutASMWResourceUtilityExport.OwnerDraw = true;
      this.menuItemDataOutASMWResourceUtilityExport.Text = "&Resource Utility";
      this.menuItemDataOutASMWResourceUtilityExport.Click += new EventHandler(this.menuItemDataOutASMWResourceUtilityExport_Click);
      this.menuItemDataOutPA.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemDataOutPAExport
      });
      this.menuItemDataOutPAExport.ImageIndex = -1;
      this.menuItemDataOutPAExport.ImageList = (ImageList) null;
      this.menuItemDataOutPAExport.Index = 0;
      this.menuItemDataOutPAExport.NoEdit = false;
      this.menuItemDataOutPAExport.NoUIModify = false;
      this.menuItemDataOutPAExport.OriginalText = "";
      this.menuItemDataOutPAExport.OwnerDraw = true;
      this.menuItemDataOutPAExport.Text = "&Export";
      this.menuItemDataOutPAExport.Click += new EventHandler(this.menuItemDataOutPAExport_Click);
      this.menuItemDataInASM.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) this.menuItemDataInASMImport,
        (MenuItem) this.menuItemDataInASMImportFromSpreadsheet,
        (MenuItem) this.menuItemDataInFFTImport
      });
      this.menuItemDataInASMImport.ImageIndex = -1;
      this.menuItemDataInASMImport.ImageList = (ImageList) null;
      this.menuItemDataInASMImport.Index = 0;
      this.menuItemDataInASMImport.NoEdit = false;
      this.menuItemDataInASMImport.NoUIModify = false;
      this.menuItemDataInASMImport.OriginalText = "";
      this.menuItemDataInASMImport.OwnerDraw = true;
      this.menuItemDataInASMImport.Text = "&Import";
      this.menuItemDataInASMImport.Click += new EventHandler(this.menuItemDataInASMImport_Click);
      this.menuItemDataInASMImportFromSpreadsheet.ImageIndex = -1;
      this.menuItemDataInASMImportFromSpreadsheet.ImageList = (ImageList) null;
      this.menuItemDataInASMImportFromSpreadsheet.Index = 1;
      this.menuItemDataInASMImportFromSpreadsheet.NoEdit = false;
      this.menuItemDataInASMImportFromSpreadsheet.NoUIModify = false;
      this.menuItemDataInASMImportFromSpreadsheet.OriginalText = "";
      this.menuItemDataInASMImportFromSpreadsheet.OwnerDraw = true;
      this.menuItemDataInASMImportFromSpreadsheet.Text = "Import From &Spreadsheet";
      this.menuItemDataInASMImportFromSpreadsheet.Click += new EventHandler(this.menuItemDataInASMImportFromSpreadsheet_Click);
      this.menuItemDataInFFTImport.ImageIndex = -1;
      this.menuItemDataInFFTImport.ImageList = (ImageList) null;
      this.menuItemDataInFFTImport.Index = 2;
      this.menuItemDataInFFTImport.NoEdit = false;
      this.menuItemDataInFFTImport.NoUIModify = false;
      this.menuItemDataInFFTImport.OriginalText = "";
      this.menuItemDataInFFTImport.OwnerDraw = true;
      this.menuItemDataInFFTImport.Text = "Import &FFT Basedata";
      this.menuItemDataInFFTImport.Click += new EventHandler(this.menuItemDataInFFTImport_Click);
      this.menuItemDataInPAImport.ImageIndex = -1;
      this.menuItemDataInPAImport.ImageList = (ImageList) null;
      this.menuItemDataInPAImport.Index = 0;
      this.menuItemDataInPAImport.NoEdit = false;
      this.menuItemDataInPAImport.NoUIModify = false;
      this.menuItemDataInPAImport.OriginalText = "";
      this.menuItemDataInPAImport.OwnerDraw = true;
      this.menuItemDataInPAImport.Text = "&Import";
      this.menuItemDataInPAImport.Click += new EventHandler(this.menuItemDataInPAImport_Click);
      this.menuItemDataInPA.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemDataInPAImport
      });
    }

    private void menuItemASMResultSet_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ASMResultSetBrowseDetail());
    }

    private void menuItemASMToolsCategory_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ASMCategoryDetail());
    }

    private void menuItemASMToolsTemplateConversion_Click(object sender, EventArgs e)
    {
      SIMS.Processes.ExternalApplication.SetupWord();
      if (!SIMS.Processes.ExternalApplication.IsWordAvailable)
      {
        int num1 = (int) MessageBox.Show("Unable to setup the Office path. Please associate the <.doc> files to Microsoft Word application and <.xls> files to Microsoft Excel application.", SIMS.Entities.Cache.ApplicationName);
      }
      else
      {
        int num2 = (int) new ASMWizTemplateConversion().ShowDialog();
      }
    }

    private void menuItemASMAspect_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ASMAspectBrowserDetail());
    }

    private void menuItemASMGradeSet_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ASMGradesetBrowseDetail());
    }

    private void menuItemASMToolsOptions_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (ASMDlgOption asmDlgOption = new ASMDlgOption())
      {
        int num = (int) asmDlgOption.ShowDialog();
      }
    }

    private void menuItemASMToolsFFTOptions_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EstimatesSetup());
    }

    private void menuItemExamsA2CCommunications_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new A2CCommunications());
    }

    private void menuItemExamsA2CLoadProductCatalogue_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new A2CLoadProdCatDlg().ShowDialog();
    }

    private void menuItemExamsA2CLoadResults_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new A2CLoadResultsDlg().ShowDialog();
    }

    private void menuItemExamsA2CSettings_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new A2CSettingsDlg().ShowDialog();
    }

    private void menuItemExamsA2CViewProductCatalogue_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new A2CProdCatContainer());
    }

    private void menuItemExamsA2CSubmitOrders_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new A2CSubmitEntriesContainer());
    }

    private void menuItemExamsA2CSubmitCoursework_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new A2CSubmitCourseworkContainer());
    }

    private void menuItemExamsA2CAmendLearnerDetails_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new A2CAmendLearnerDetails());
    }

    private void menuItemExamsA2CSummary_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new A2CSummary());
    }

    private void menuItemASMMarksheetEntry_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ASMMarksheetBrowserDetail());
    }

    private void menuItemASMOMRTemplate_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ASMOMRTemplateBrowserDetail());
    }

    private void menuItemASMTemplate_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ASMTemplateBrowserDetail());
    }

    private void menuItemASMIndividualReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      IndividualReportDetail individualReportDetail = new IndividualReportDetail();
      if (CheckDMSAvailability.CheckIsDMSAvailable())
      {
        if (!individualReportDetail.GetBaseTemplates())
        {
          int num1 = (int) MessageBox.Show("Unable to download the Base Template file. Please close the application and then open it again.", SIMS.Entities.Cache.ApplicationName);
        }
        else if (!individualReportDetail.DownloadDocument(this.base_template_file_dot, false))
        {
          int num2 = (int) MessageBox.Show("Unable to download the Base Template file. Please close the application and then open it again.", SIMS.Entities.Cache.ApplicationName);
        }
        else
          this.DisplayComponent((Control) new ASMIndividualReportBrowserDetail());
      }
      else
      {
        int num3 = (int) MessageBox.Show("Unable to find a document server. Please check in Tools, System Setup", SIMS.Entities.Cache.ApplicationName);
      }
    }

    private void menuItemProfilesSessionManager_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PRWSessionBrowserDetail());
    }

    private void menuItemProfilesCommentBanks_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PRWCommentBankDetail());
    }

    private void menuItemProfilesDataEntryListEntry_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PRWListEntryBrowserDetail());
    }

    private void menuItemProfilesStudentProfiles_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (CheckDMSAvailability.CheckIsDMSAvailable())
      {
        this.DisplayComponent((Control) new PRWStudentProfileBrowserDetail());
      }
      else
      {
        int num = (int) MessageBox.Show("Unable to find a document server. Please check in Tools, System Setup", SIMS.Entities.Cache.ApplicationName);
      }
    }

    private void menuItemProfilesReviewProfiles_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PRWCheckingScreenContainer("Review Profile Details"));
    }

    private void menuItemProfilesDataEntryGridEntry_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PRWGridEntryBrowserDetail());
    }

    private void menuItemProfilesMissingEntriesReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PRWMissingEntriesBrowserDetail());
    }

    private void menuItemProfilesAreasNotApprovedReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PRWAreasNotApprovedReportDetail());
    }

    private void menuItemProfilesToolsCompareCommentBanks_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new PRWDlgCompareCommentBanks().ShowDialog();
    }

    private void menuItemProfilesMissingCommentsByStudents_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PRWMissingCommentsReportDetail());
    }

    private void menuItemProfilesCommentUsageAnalysis_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PRWCommentUsageAnalysisBrowserDetail());
    }

    private void menuItemProfilesToolsBatchPrintingOfClassCheckSheets_Click(
      object sender,
      EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PRWGroupBrowserDetail());
    }

    private void menuItemProfilesUDG_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new MaintainUserDefinedGroups(UserGroupTypeEnum.Profiles));
    }

    private void MenuItemUDG_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new MaintainUserDefinedGroups(UserGroupTypeEnum.User));
    }

    private void menuItemAssManUDG_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new MaintainUserDefinedGroups(UserGroupTypeEnum.Assessment));
    }

    private void menuItemOMRSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      new CESOMRSetupClass().ShowSetup(this.Handle.ToInt32(), "");
    }

    private void menuItemPAGroupAnalysis_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PAGroupAnalysisBrowserDetail());
    }

    private void menuItemPAResultSetAnalysis_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PAResultSetAnalysisBrowserDetail());
    }

    private void menuItemPAAspectAnalysis_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PAAspectAnalysisBrowserDetail());
    }

    private void menuItemDataInASMImport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new ASMFileTransferImportWizard().ShowDialog();
    }

    private void menuItemDataInFFTImport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EstimatesImportDetail());
    }

    private void menuItemADMImportEnquiry_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ADMImportDetail());
    }

    private void menuItemADMImportApplication_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ADMImportApplicationDetail());
    }

    private void menuItemDataInPAImport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new PAFileTransferImportWizard().ShowDialog();
    }

    private void menuItemDataOutASMExport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new ASMFileTransferExportWizard().ShowDialog();
    }

    private void menuItemDataOutASMWResourceUtilityExport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new ResourceUtilityExportContainer().ShowDialog();
    }

    private void menuItemASMToolsWizardManager_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new ASMWizWizardManager()
      {
        WizardIcon = this.Icon
      }.ShowDialog();
    }

    private void menuItemASMToolsAssessmentMapping_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (!new ASMMappingDefinitionProcess().AssessmentMappingComponentExists())
      {
        int num = (int) MessageBox.Show(this.ASSESSMENT_MAPPING_COMPONENT_RESOURCE_NEEDED_MSG, SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
        this.DisplayComponent((Control) new ASMMappingBrowserDetail());
    }

    private void menuItemReportAssessmentMissingResults_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ASMMissingMarksheetReport());
    }

    private void menuItemReportPoSSubjectStrandIndividual_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgIndividualAnalysisReportDialog analysisReportDialog = new DlgIndividualAnalysisReportDialog())
      {
        int num = (int) analysisReportDialog.ShowDialog();
      }
    }

    private void menuItemPoSAnalysisSummativeAttainment_Click(object sender, EventArgs e)
    {
      string posAnalysisScreen = this.getNameofOpenPosAnalysisScreen();
      if (posAnalysisScreen != string.Empty)
      {
        int num = (int) MessageBox.Show(string.Format("Please close the {0} screen before opening this screen.", (object) posAnalysisScreen), SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        this.recordMenuUsage(sender as UIMenuItem);
        this.DisplayComponent((Control) new PoSSummativeAttainmentDetail());
      }
    }

    private void menuItemPoSAnalysisFormativeAttainment_Click(object sender, EventArgs e)
    {
      string posAnalysisScreen = this.getNameofOpenPosAnalysisScreen();
      if (posAnalysisScreen != string.Empty)
      {
        int num = (int) MessageBox.Show(string.Format("Please close the {0} screen before opening this screen.", (object) posAnalysisScreen), SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        this.recordMenuUsage(sender as UIMenuItem);
        this.DisplayComponent((Control) new PoSFormativeAttainmentDetail());
      }
    }

    private void menuItemPoSAnalysisSummativeProgress_Click(object sender, EventArgs e)
    {
      string posAnalysisScreen = this.getNameofOpenPosAnalysisScreen();
      if (posAnalysisScreen != string.Empty)
      {
        int num = (int) MessageBox.Show(string.Format("Please close the {0} screen before opening this screen.", (object) posAnalysisScreen), SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        this.recordMenuUsage(sender as UIMenuItem);
        this.DisplayComponent((Control) new PoSSummativeProgressDetail());
      }
    }

    private void menuItemPoSAnalysisFormativeProgress_Click(object sender, EventArgs e)
    {
      string posAnalysisScreen = this.getNameofOpenPosAnalysisScreen();
      if (posAnalysisScreen != string.Empty)
      {
        int num = (int) MessageBox.Show(string.Format("Please close the {0} screen before opening this screen.", (object) posAnalysisScreen), SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        this.recordMenuUsage(sender as UIMenuItem);
        this.DisplayComponent((Control) new PoSFormativeProgressDetail());
      }
    }

    private void menuItemASMToolsSystemUtilitiesAspects_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ASMWizSystemUtilityAspects systemUtilityAspects = new ASMWizSystemUtilityAspects();
      systemUtilityAspects.Icon = this.Icon;
      int num = (int) systemUtilityAspects.ShowDialog();
    }

    private void menuItemASMToolsSystemUtilitiesOMRSheets_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ASMWizSystemUtilityOMRSheets utilityOmrSheets = new ASMWizSystemUtilityOMRSheets();
      utilityOmrSheets.Icon = this.Icon;
      int num = (int) utilityOmrSheets.ShowDialog();
    }

    private void menuItemPAToolsProgressionLines_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PAPlineBrowserDetail());
    }

    private void menuItemASMToolsSystemUtilitiesMarksheets_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ASMWizMarksheetUtility marksheetUtility = new ASMWizMarksheetUtility();
      marksheetUtility.Icon = this.Icon;
      int num = (int) marksheetUtility.ShowDialog();
    }

    private void menuItemASMToolsSystemUtilitiesTemplates_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ASMWizTemplateUtility wizTemplateUtility = new ASMWizTemplateUtility();
      wizTemplateUtility.Icon = this.Icon;
      int num = (int) wizTemplateUtility.ShowDialog();
    }

    private void menuItemProfilesToolsAddNamesToDictionary_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("This will add all names to the Main dictionary. Do you wish to Continue?", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      Cursor cursor = this.Cursor;
      this.Cursor = Cursors.WaitCursor;
      new AddWordsToDictionary().AddStudentDataToDictionary();
      this.Cursor = cursor;
    }

    private void menuItemPATrackingTemplate_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PATrackingTemplateBrowserDetail());
    }

    private void menuItemPATrackingGrid_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PATrackingGridBrowserDetail());
    }

    private void menuItemAPPGridTemplate_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new APPGridTemplateBrowserDetail());
    }

    private void menuItemFFTEstimates_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EstimatesDetail());
    }

    private void menuItemAPPGridEntry_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new APPGridBrowserDetail());
    }

    private void menuItemTPPGridEntry_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new TPPGridDetail());
    }

    private void menuItemPoSManagingContentClick(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PoSManageContentDetail());
    }

    private void menuItemPoSManagingGradesClick(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PoSManageGradesDetail());
    }

    private void rebuildPerformanceMenus()
    {
      if (SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() == DatabaseModeEnum.Offline.ToString())
      {
        this.menuItemProfilesDataEntryOMREntry.Visible = false;
        this.menuItemProfilesDataEntryListEntry.Visible = false;
        this.menuItemProfilesDataEntryGridEntry.Visible = false;
      }
      else
      {
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesDataEntryOMREntry, ReadOMR.PermissionsRequired);
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesDataEntryListEntry, ListEntryDetail.PermissionsRequiredForMenu);
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesDataEntryGridEntry, GridEntryDetail.PermissionsRequired);
      }
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesToolsBatchPrintingOfClassCheckSheets, ClassGroupDetail.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesStudentProfiles, StudentProfileDetail.PermissionsRequiredForMenu);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesSessionManager, SessionBrowse.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesCommentUsageAnalysis, SessionBrowse.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesMissingEntriesReport, SessionBrowse.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesAreasNotApprovedReport, SessionBrowse.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesMissingComments, SessionBrowse.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesCommentBanks, CommentBankDetail.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesToolsCompareCommentBanks, CommentBankDetail.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemProfilesReviewProfiles, GridEntryBrowser.PermissionsRequiredForCheckingScreenMenu);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemProfilesToolsAddNamesToDictionary, "AddWordsToDictionary");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMAspect, SIMS.Processes.MaintainAspect.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMResultSet, MaintainResultset.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemLookUpTables, new string[2]
      {
        "LookupBrowser",
        "LookupDetail"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMGradeSet, MaintainGradeSet.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMTemplate, TemplateDetail.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMOMRTemplate, OMRTemplateDetail.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMIndividualReport, IndividualReportDetail.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsOptions, MaintainOption.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsCategory, MaintainCategory.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsTemplateConversion, TemplateConversion.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemDataInASMImport, FileTransferImport.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemDataOutASMExport, FileTransferExport.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemDataInASMImportFromSpreadsheet, OfficeMLResultImport.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsSystemUtilitiesGradeSets, SystemUtilityGradeSets.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsSystemUtilitiesIndividualReports, SystemUtilityGradeSets.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsSystemUtilitiesResultSets, SystemUtilityResultSets.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsSystemUtilitiesKSMWizards, SystemUtilityKSMWizards.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsSystemUtilitiesResults, ResultUtility.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsSystemUtilitiesOMRTemplates, SystemUtilityOMRTemplates.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsSystemUtilitiesAspects, SystemUtilityAspects.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMMarksheetEntry, SIMS.Processes.ASMMarksheetDetail.PermissionsRequiredForMenu);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMOMREntry, SIMS.Processes.ASMMarksheetDetail.PermissionsRequiredForMenu);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsSystemUtilitiesTemplates, SystemUtilityTemplates.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemASMToolsWizardManager, ASMWizWizardManager.HostedProcessName());
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemASMToolsAssessmentMapping, ASMMappingDefinitionProcess.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsSystemUtilitiesOMRSheets, SystemUtilityOMRSheets.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemASMToolsSystemUtilitiesMarksheets, SystemUtilityMarksheet.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemReportAssessmentMissingResults, ASMMissingMarksheetReport.HostedProcessName());
      this.rebuildFFTMenus();
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemDataOutASMWResourceUtilityExport, ResourceUtilityProcess.PermissionsRequired);
      this.menuItemReportAssessment.Visible = this.menuItemReportAssessmentMissingResults.Visible;
      string[] strArray1 = new string[2]
      {
        "ViewOwnUDGroup",
        "ViewUDGroup"
      };
      this.menuItemUserDefinedGroups.Visible = false;
      foreach (string processName in strArray1)
        this.menuItemUserDefinedGroups.Visible = this.menuItemUserDefinedGroups.Visible || SIMS.Entities.Cache.ProcessVisible(processName);
      string[] strArray2 = new string[2]
      {
        "ViewOwnPerformanceUDGroup",
        "ViewPerformanceUDGroup"
      };
      this.menuItemProfilesUDG.Visible = false;
      this.menuItemAssManUDG.Visible = false;
      foreach (string processName in strArray2)
      {
        this.menuItemAssManUDG.Visible = this.menuItemAssManUDG.Visible || SIMS.Entities.Cache.ProcessVisible(processName);
        this.menuItemProfilesUDG.Visible = this.menuItemProfilesUDG.Visible || SIMS.Entities.Cache.ProcessVisible(processName);
      }
      bool flag = false;
      foreach (string processName in TrendAnalysisReviewDetail.PermissionsRequired)
        flag = flag || SIMS.Entities.Cache.ProcessAvailable(processName);
      this.menuItemPAAspectAnalysis.Visible = flag;
      this.menuItemPAChanceAnalysis.Visible = flag;
      this.menuItemPAGroupAnalysis.Visible = flag;
      this.menuItemPAResultSetAnalysis.Visible = flag;
      this.menuItemPATrendAnalysisPrediction.Visible = flag;
      this.menuItemPATrendAnalysisReview.Visible = flag;
      this.menuItemPATrendAnalysis.Visible = flag;
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPATrackingGrid, TrackingGridDetail.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPATrackingTemplate, TrackingTemplateDetail.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemDataInPAImport, ImportAnalysis.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemDataOutPAExport, ExportAnalysis.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPAToolsBuildExamAnalysis, ExamAnalysis.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPAToolsDefineSettings, PerformanceAnalysisSettings.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPAToolsSystemUtilitiesTrendLines, SystemUtilityTrendLines.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPAToolsSystemUtilitiesTrackingTemplates, SystemUtilityTrackingTemplates.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPAToolsSystemUtilitiesTrackingGrids, SystemUtilityTrackingGrids.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPAToolsSystemUtilitiesAnalysisResources, SystemUtilityAnalysisResources.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemAPPGridTemplate, APPGridTemplateBrowse.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemAPPGridEntry, APPGridBrowse.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemTPPGridEntry, SIMS.Processes.TPPGridDetail.PermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPoSManagingContent, SIMS.Processes.TPPGridDetail.ManagePermissionsRequired);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemReportPoSSubjectStrandIndividual, "TPPGridViewAll");
      if (SystemConfigurationCache.LocaleCode == "ENG")
      {
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPoSManagingGrades, SIMS.Processes.TPPGridDetail.ManagePermissionsRequired);
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPoSAnalysisSummativeAttainment, "TPPGridViewAll");
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPoSAnalysisSummativeProgress, "TPPGridViewAll");
      }
      else
      {
        this.menuItemPoSAnalysisSummativeAttainment.Visible = false;
        this.menuItemPoSAnalysisSummativeProgress.Visible = false;
      }
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPoSAnalysisFormativeAttainment, "TPPGridViewAll");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPoSAnalysisFormativeProgress, "TPPGridViewAll");
      this.disableMenuRoutesNotImplemented();
      this.menuItemPAToolsValueAddedLines.Visible = flag;
      this.menuItemPAToolsProgressionLines.Visible = flag;
      this.menuItemProfilesDataEntry.Visible = this.menuItemProfilesDataEntryGridEntry.Visible || this.menuItemProfilesDataEntryListEntry.Visible || this.menuItemProfilesDataEntryOMREntry.Visible;
      this.menuItemASMToolsSystemUtilities.Visible = this.menuItemASMToolsSystemUtilitiesAspects.Visible || this.menuItemASMToolsSystemUtilitiesGradeSets.Visible || (this.menuItemASMToolsSystemUtilitiesTemplates.Visible || this.menuItemASMToolsSystemUtilitiesMarksheets.Visible) || (this.menuItemASMToolsSystemUtilitiesResults.Visible || this.menuItemASMToolsSystemUtilitiesOMRTemplates.Visible || (this.menuItemASMToolsSystemUtilitiesOMRSheets.Visible || this.menuItemASMToolsSystemUtilitiesIndividualReports.Visible)) || this.menuItemASMToolsSystemUtilitiesResultSets.Visible || this.menuItemASMToolsSystemUtilitiesKSMWizards.Visible;
      this.menuItemPAToolsSystemUtilities.Visible = this.menuItemPAToolsSystemUtilitiesTrendLines.Visible || this.menuItemPAToolsSystemUtilitiesTrackingTemplates.Visible || this.menuItemPAToolsSystemUtilitiesTrackingGrids.Visible || this.menuItemPAToolsSystemUtilitiesAnalysisResources.Visible;
      this.menuItemToolsASMTools.Visible = this.menuItemASMToolsCategory.Visible || this.menuItemASMToolsSystemUtilities.Visible || this.menuItemASMToolsWizardManager.Visible || this.menuItemASMToolsOptions.Visible;
      this.menuItemToolsPATools.Visible = this.menuItemPAToolsValueAddedLines.Visible || this.menuItemPAToolsProgressionLines.Visible || this.menuItemPAToolsSystemUtilities.Visible || this.menuItemPAToolsBuildExamAnalysis.Visible;
      this.menuItemFocusProfiles.Visible = this.menuItemProfilesDataEntry.Visible || this.menuItemProfilesStudentProfiles.Visible || this.menuItemProfilesSessionManager.Visible || this.menuItemProfilesCommentBanks.Visible;
      this.menuItemFocusProfiles.Visible = this.menuItemProfilesDataEntry.Visible || this.menuItemProfilesStudentProfiles.Visible || this.menuItemProfilesSessionManager.Visible || this.menuItemProfilesCommentBanks.Visible;
      this.menuItemFocusProfiles.Visible = this.menuItemProfilesDataEntry.Visible || this.menuItemProfilesStudentProfiles.Visible || this.menuItemProfilesSessionManager.Visible || this.menuItemProfilesCommentBanks.Visible;
      this.menuItemFocusASM.Visible = this.menuItemASMAspect.Visible || this.menuItemASMGradeSet.Visible || (this.menuItemASMIndividualReport.Visible || this.menuItemASMMarksheetEntry.Visible) || (this.menuItemASMOMREntry.Visible || this.menuItemASMOMRTemplate.Visible || (this.menuItemASMResultSet.Visible || this.menuItemASMTemplate.Visible)) || (this.menuItemPAAspectAnalysis.Visible || this.menuItemPAChanceAnalysis.Visible || (this.menuItemPAGroupAnalysis.Visible || this.menuItemPAResultSetAnalysis.Visible) || (this.menuItemPATrendAnalysis.Visible || this.menuItemFFTEstimates.Visible || this.menuItemTPPGridEntry.Visible)) || this.menuItemPoSManagement.Visible;
    }

    private void rebuildFFTMenus()
    {
      if (this.canShowFFTMenusForSchool())
      {
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemASMToolsFFTOptions, SIMS.Processes.EstimatesSetup.PermissionsRequired);
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemDataInFFTImport, SIMS.Processes.EstimatesImportDetail.PermissionsRequired);
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemFFTEstimates, SIMS.Processes.EstimatesDetail.PermissionsRequired);
      }
      else
      {
        this.menuItemFFTEstimates.Visible = false;
        this.menuItemASMToolsFFTOptions.Visible = false;
        this.menuItemDataInFFTImport.Visible = false;
      }
      this.menuItemFFTSeparator.Visible = this.menuItemFFTEstimates.Visible;
    }

    private bool canShowFFTMenusForSchool()
    {
      PLASCEntity.EnumPLASCFlavour plascFlavourId = (PLASCEntity.EnumPLASCFlavour) SIMS.Entities.Cache.CurrentSchool.PLASCFlavourId;
      switch (plascFlavourId)
      {
        case PLASCEntity.EnumPLASCFlavour.EnglishMiddleDeemedSecondary:
        case PLASCEntity.EnumPLASCFlavour.EnglishSecondary:
        case PLASCEntity.EnumPLASCFlavour.WelshSecondary:
        case PLASCEntity.EnumPLASCFlavour.EnglishAllThrough:
          return true;
        default:
          return plascFlavourId == PLASCEntity.EnumPLASCFlavour.WelshMiddle;
      }
    }

    private void disableMenuRoutesNotImplemented()
    {
    }

    private void menuItemPATrendAnalysisPrediction_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PATrendAnalysisPredictionBrowserDetail());
    }

    private void menuItemPATrendAnalysisReview_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PATrendAnalysisReviewBrowserDetail());
    }

    private void menuItemLookUpTables_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ASMLookupMasterBrowserDetail());
    }

    private void menuItemDataInASMImportFromSpreadsheet_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ASMImportOfficeMLWizard importOfficeMlWizard = new ASMImportOfficeMLWizard();
      importOfficeMlWizard.Icon = this.Icon;
      int num = (int) importOfficeMlWizard.ShowDialog();
    }

    private void menuItemProfilesDataEntryOMREntry_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      new PRWOMREntry(this.Handle.ToInt32()).OMRReading();
    }

    private void menuItemASMToolsSystemUtilitiesIndividualReports_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ASMWizIndividualReport individualReport = new ASMWizIndividualReport();
      individualReport.Icon = this.Icon;
      int num = (int) individualReport.ShowDialog();
    }

    private void menuItemASMToolsSystemUtilitiesResultSets_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ASMWizSystemUtilityResultSets utilityResultSets = new ASMWizSystemUtilityResultSets();
      utilityResultSets.Icon = this.Icon;
      int num = (int) utilityResultSets.ShowDialog();
    }

    private void menuItemASMToolsSystemUtilitiesKSMWizards_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ASMWizSystemUtilityKSMWizards utilityKsmWizards = new ASMWizSystemUtilityKSMWizards();
      utilityKsmWizards.Icon = this.Icon;
      int num = (int) utilityKsmWizards.ShowDialog();
    }

    private void menuItemDataOutPAExport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (PAWizExportAnalysis wizExportAnalysis = new PAWizExportAnalysis())
      {
        wizExportAnalysis.Icon = this.Icon;
        int num = (int) wizExportAnalysis.ShowDialog();
      }
    }

    private void menuItemASMToolsSystemUtilitiesResults_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ASMWizResults asmWizResults = new ASMWizResults();
      asmWizResults.Icon = this.Icon;
      int num = (int) asmWizResults.ShowDialog();
    }

    private void menuItemPAToolsSystemUtilitiesTrendLines_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (PAWizSystemUtilityTrendLines utilityTrendLines = new PAWizSystemUtilityTrendLines())
      {
        utilityTrendLines.Icon = this.Icon;
        int num = (int) utilityTrendLines.ShowDialog();
      }
    }

    private void menuItemPAToolsSystemUtilitiesTrackingTemplates_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (this.ComponentExists("SIMS.UserInterfaces.PATrackingTemplateBrowserDetail") != null || this.ComponentExists("SIMS.UserInterfaces.PATrackingGridBrowserDetail") != null)
      {
        int num1 = (int) MessageBox.Show("Please note that either the Tracking Grid Templates / Tracking Grids screens are currently open. \nRefresh the browser window after deletion of records to prevent inconsistency in the data displayed.", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      using (PAWizSystemUtilityTrackingTemplates trackingTemplates = new PAWizSystemUtilityTrackingTemplates())
      {
        trackingTemplates.Icon = this.Icon;
        int num2 = (int) trackingTemplates.ShowDialog();
      }
    }

    private void menuItemPAToolsSystemUtilitiesTrackingGrids_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (this.ComponentExists("SIMS.UserInterfaces.PATrackingGridBrowserDetail") != null)
      {
        int num1 = (int) MessageBox.Show("Please note that Tracking Grids screen is currently open. \nRefresh the browser window after deletion of records to prevent inconsistency in the data displayed.", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      using (PAWizSystemUtilityTrackingGrids utilityTrackingGrids = new PAWizSystemUtilityTrackingGrids())
      {
        utilityTrackingGrids.Icon = this.Icon;
        int num2 = (int) utilityTrackingGrids.ShowDialog();
      }
    }

    private void menuItemPAToolsSystemUtilitiesAnalysisResources_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if (this.ComponentExists("SIMS.UserInterfaces.PAGroupAnalysisBrowserDetail") != null || this.ComponentExists("SIMS.UserInterfaces.PAAspectAnalysisBrowserDetail") != null || (this.ComponentExists("SIMS.UserInterfaces.PAResultSetAnalysisBrowserDetail") != null || this.ComponentExists("SIMS.UserInterfaces.PAChanceAnalysisBrowserDetail") != null))
      {
        int num1 = (int) MessageBox.Show("Please note that an Analysis Resources screen is currently open. \nRefresh the browser window after deletion of records to prevent inconsistency in the data displayed.", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      using (PAWizSystemUtilityAnalysisResources analysisResources = new PAWizSystemUtilityAnalysisResources())
      {
        analysisResources.Icon = this.Icon;
        int num2 = (int) analysisResources.ShowDialog();
      }
    }

    private void menuItemASMToolsSystemUtilitiesGradeSets_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ASMWizSystemUtilityGradeSets utilityGradeSets = new ASMWizSystemUtilityGradeSets();
      utilityGradeSets.Icon = this.Icon;
      int num = (int) utilityGradeSets.ShowDialog();
    }

    private void menuItemASMOMREntry_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new ASMDlgOMRReadDate().ShowDialog();
    }

    private void menuItemASMToolsSystemUtilitiesOMRTemplates_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      ASMWizSystemUtilityOMRTemplate utilityOmrTemplate = new ASMWizSystemUtilityOMRTemplate();
      utilityOmrTemplate.Icon = this.Icon;
      int num = (int) utilityOmrTemplate.ShowDialog();
    }

    private void menuItemPAChanceAnalysis_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PAChanceAnalysisBrowserDetail());
    }

    private void menuItemPAToolsBuildExamAnalysis_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      PAWizExamAnalysis paWizExamAnalysis = new PAWizExamAnalysis();
      paWizExamAnalysis.Icon = this.Icon;
      int num = (int) paWizExamAnalysis.ShowDialog((IWin32Window) this);
    }

    private void menuItemPAToolsDefineSettings_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PADefineSettings());
    }

    private void menuItemPAToolsValueAddedLines_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PAVlineBrowserDetail());
    }

    private void initBehaviourMenus()
    {
      this.menuItemStudBehaviour = new UIMenuItem();
      this.menuItemAchievement = new UIMenuItem();
      this.menuItemBehaviourIncident = new UIMenuItem();
      this.menuItemDetention = new UIMenuItem();
      this.menuItemBehaviourType = new UIMenuItem();
      this.menuItemBehaviourManagement = new UIMenuItem();
      this.menuItemBehaviourRoleType = new UIMenuItem();
      this.menuItemAchievementType = new UIMenuItem();
      this.menuItemDetentionType = new UIMenuItem();
      this.menuItemReportCardTemplate = new UIMenuItem();
      this.menuItemReportCard = new UIMenuItem();
      this.menuItemAchievementNotifications = new UIMenuItem();
      this.menuItemBehaviourNotifications = new UIMenuItem();
      this.menuItemStudBehaviour.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemStudBehaviour.ImageIndex = 80;
      this.launcher.AddFocusBarItem(this.menuItemStudBehaviour);
      this.menuItemBehaviourMgmt.MenuItems.AddRange(new MenuItem[7]
      {
        (MenuItem) this.menuItemStudBehaviour,
        (MenuItem) this.menuItemAchievement,
        (MenuItem) this.menuItemBehaviourIncident,
        (MenuItem) this.menuItemDetention,
        (MenuItem) this.menuItemReportCard,
        (MenuItem) this.menuItemAchievementNotifications,
        (MenuItem) this.menuItemBehaviourNotifications
      });
      this.menuItemSetups.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemBehaviourManagement
      });
      this.menuItemBehaviourManagement.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemBehaviourType,
        (MenuItem) this.menuItemBehaviourRoleType,
        (MenuItem) this.menuItemAchievementType,
        (MenuItem) this.menuItemDetentionType,
        (MenuItem) this.menuItemReportCardTemplate
      });
      this.menuItemStudBehaviour.ImageIndex = -1;
      this.menuItemStudBehaviour.ImageList = (ImageList) null;
      this.menuItemStudBehaviour.Index = 0;
      this.menuItemStudBehaviour.NoEdit = false;
      this.menuItemStudBehaviour.NoUIModify = false;
      this.menuItemStudBehaviour.OriginalText = "";
      this.menuItemStudBehaviour.OwnerDraw = true;
      this.menuItemStudBehaviour.Text = "&Student Behaviour";
      this.menuItemStudBehaviour.Click += new EventHandler(this.menuItemStudBehaviour_Click);
      this.menuItemAchievement.ImageIndex = -1;
      this.menuItemAchievement.ImageList = (ImageList) null;
      this.menuItemAchievement.Index = 1;
      this.menuItemAchievement.NoEdit = false;
      this.menuItemAchievement.NoUIModify = false;
      this.menuItemAchievement.OriginalText = "";
      this.menuItemAchievement.OwnerDraw = true;
      this.menuItemAchievement.Text = "Maintain &Achievements";
      this.menuItemAchievement.Click += new EventHandler(this.menuItemAchievement_Click);
      this.menuItemBehaviourIncident.ImageIndex = -1;
      this.menuItemBehaviourIncident.ImageList = (ImageList) null;
      this.menuItemBehaviourIncident.Index = 2;
      this.menuItemBehaviourIncident.NoEdit = false;
      this.menuItemBehaviourIncident.NoUIModify = false;
      this.menuItemBehaviourIncident.OriginalText = "";
      this.menuItemBehaviourIncident.OwnerDraw = true;
      this.menuItemBehaviourIncident.Text = "Maintain &Behaviour Incidents";
      this.menuItemBehaviourIncident.Click += new EventHandler(this.menuItemBehaviourIncident_Click);
      this.menuItemDetention.ImageIndex = -1;
      this.menuItemDetention.ImageList = (ImageList) null;
      this.menuItemDetention.Index = 3;
      this.menuItemDetention.NoEdit = false;
      this.menuItemDetention.NoUIModify = false;
      this.menuItemDetention.OriginalText = "";
      this.menuItemDetention.OwnerDraw = true;
      this.menuItemDetention.Text = "Maintain &Detentions";
      this.menuItemDetention.Click += new EventHandler(this.menuItemDetention_Click);
      this.menuItemReportCard.ImageIndex = -1;
      this.menuItemReportCard.ImageList = (ImageList) null;
      this.menuItemReportCard.Index = 4;
      this.menuItemReportCard.NoEdit = false;
      this.menuItemReportCard.NoUIModify = false;
      this.menuItemReportCard.OriginalText = "";
      this.menuItemReportCard.OwnerDraw = true;
      this.menuItemReportCard.Text = "&Report Card";
      this.menuItemReportCard.Click += new EventHandler(this.menuItemReportCard_Click);
      this.menuItemAchievementNotifications.ImageIndex = -1;
      this.menuItemAchievementNotifications.ImageList = (ImageList) null;
      this.menuItemAchievementNotifications.Index = 5;
      this.menuItemAchievementNotifications.NoEdit = false;
      this.menuItemAchievementNotifications.NoUIModify = false;
      this.menuItemAchievementNotifications.OriginalText = "";
      this.menuItemAchievementNotifications.OwnerDraw = true;
      this.menuItemAchievementNotifications.Text = "Achievement &Notifications";
      this.menuItemAchievementNotifications.Click += new EventHandler(SIMS.UserInterfaces.InTouch.MainContainerHelper.menuItemAchievementNotifications_Click);
      this.menuItemBehaviourNotifications.ImageIndex = -1;
      this.menuItemBehaviourNotifications.ImageList = (ImageList) null;
      this.menuItemBehaviourNotifications.Index = 5;
      this.menuItemBehaviourNotifications.NoEdit = false;
      this.menuItemBehaviourNotifications.NoUIModify = false;
      this.menuItemBehaviourNotifications.OriginalText = "";
      this.menuItemBehaviourNotifications.OwnerDraw = true;
      this.menuItemBehaviourNotifications.Text = "Behaviou&r Notifications";
      this.menuItemBehaviourNotifications.Click += new EventHandler(SIMS.UserInterfaces.InTouch.MainContainerHelper.menuItemBehaviourNotifications_Click);
      this.menuItemBehaviourManagement.ImageIndex = -1;
      this.menuItemBehaviourManagement.ImageList = (ImageList) null;
      this.menuItemBehaviourManagement.Index = 11;
      this.menuItemBehaviourManagement.NoEdit = false;
      this.menuItemBehaviourManagement.NoUIModify = false;
      this.menuItemBehaviourManagement.OriginalText = "";
      this.menuItemBehaviourManagement.OwnerDraw = true;
      this.menuItemBehaviourManagement.Text = "&Behaviour Management";
      this.menuItemBehaviourType.ImageIndex = -1;
      this.menuItemBehaviourType.ImageList = (ImageList) null;
      this.menuItemBehaviourType.Index = 0;
      this.menuItemBehaviourType.NoEdit = false;
      this.menuItemBehaviourType.NoUIModify = false;
      this.menuItemBehaviourType.OriginalText = "";
      this.menuItemBehaviourType.OwnerDraw = true;
      this.menuItemBehaviourType.Text = "&Behaviour Type";
      this.menuItemBehaviourType.Click += new EventHandler(this.menuItemBehaviourType_Click);
      this.menuItemBehaviourRoleType.ImageIndex = -1;
      this.menuItemBehaviourRoleType.ImageList = (ImageList) null;
      this.menuItemBehaviourRoleType.Index = 1;
      this.menuItemBehaviourRoleType.NoEdit = false;
      this.menuItemBehaviourRoleType.NoUIModify = false;
      this.menuItemBehaviourRoleType.OriginalText = "";
      this.menuItemBehaviourRoleType.OwnerDraw = true;
      this.menuItemBehaviourRoleType.Text = "Be&haviour Role Type";
      this.menuItemBehaviourRoleType.Click += new EventHandler(this.menuItemBehaviourRoleType_Click);
      this.menuItemAchievementType.ImageIndex = -1;
      this.menuItemAchievementType.ImageList = (ImageList) null;
      this.menuItemAchievementType.Index = 2;
      this.menuItemAchievementType.NoEdit = false;
      this.menuItemAchievementType.NoUIModify = false;
      this.menuItemAchievementType.OriginalText = "";
      this.menuItemAchievementType.OwnerDraw = true;
      this.menuItemAchievementType.Text = "&Achievement Type";
      this.menuItemAchievementType.Click += new EventHandler(this.menuItemAchievementType_Click);
      this.menuItemDetentionType.ImageIndex = -1;
      this.menuItemDetentionType.ImageList = (ImageList) null;
      this.menuItemDetentionType.Index = 3;
      this.menuItemDetentionType.NoEdit = false;
      this.menuItemDetentionType.NoUIModify = false;
      this.menuItemDetentionType.OriginalText = "";
      this.menuItemDetentionType.OwnerDraw = true;
      this.menuItemDetentionType.Text = "Dete&ntion Type";
      this.menuItemDetentionType.Click += new EventHandler(this.menuItemDetentionType_Click);
      this.menuItemReportCardTemplate.ImageIndex = -1;
      this.menuItemReportCardTemplate.ImageList = (ImageList) null;
      this.menuItemReportCardTemplate.Index = 4;
      this.menuItemReportCardTemplate.NoEdit = false;
      this.menuItemReportCardTemplate.NoUIModify = false;
      this.menuItemReportCardTemplate.OriginalText = "";
      this.menuItemReportCardTemplate.OwnerDraw = true;
      this.menuItemReportCardTemplate.Text = "&Report Card Template";
      this.menuItemReportCardTemplate.Click += new EventHandler(this.menuItemReportCardTemplate_Click);
    }

    private void rebuildBehaviourMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemStudBehaviour, "MaintainBehaviourDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAchievement, "ViewAchievement");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBehaviourIncident, "ViewBehaviour");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemDetention, "ViewDetention");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemDetentionType, "DetentionTypeViewAll");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemReportCard, "ViewReportCard");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAchievementNotifications, "InTouch.SendAchievementNotificationMessageHost");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBehaviourNotifications, "InTouch.SendBehaviourNotificationMessageHost");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemReportsBehaviourRunReportCard, "ViewReportCard");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemReportCardTemplate, "ViewReportCardTemplate");
      if (this.menuItemReportsBehaviourRunReportCard.Visible)
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemReportsBehaviourRunReportCard, "EditReportCard");
      this.menuItemReportsBehaviour.Visible = this.menuItemReportsBehaviourRunReportCard.Visible;
      string[] processNames = new string[2]
      {
        "LookupTypeBrowser",
        "LookupTypeDetail"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBehaviourType, processNames);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBehaviourRoleType, processNames);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAchievementType, processNames);
      this.menuItemBehaviourManagement.Visible = this.menuItemBehaviourType.Visible || this.menuItemBehaviourRoleType.Visible || (this.menuItemAchievementType.Visible || this.menuItemDetentionType.Visible) || this.menuItemReportCardTemplate.Visible;
    }

    private void menuItemStudBehaviour_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new BehaviourEditor());
    }

    private void menuItemBehaviourIncident_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new BehaviourIncidentBrowseDetail());
    }

    private void menuItemAchievement_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new AchievementBrowseDetail());
    }

    private void menuItemDetention_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new DetentionBrowseDetail());
    }

    private void menuItemReportCard_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ReportCardBrowseDetail());
    }

    private void menuItemBehaviourType_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EditBehaviourType());
    }

    private void menuItemBehaviourRoleType_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EditBehaviourRoleType());
    }

    private void menuItemAchievementType_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EditAchievementType());
    }

    private void menuItemDetentionType_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new DetentionTypeUI());
    }

    private void menuItemReportCardTemplate_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ReportCardTemplate());
    }

    private void initInterventionsMenus()
    {
      this.menuItemIntervPlanIntervention = new UIMenuItem();
      this.menuItemIntervRunIntervention = new UIMenuItem();
      this.menuItemInterventions.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemInterventions.ImageIndex = -1;
      this.launcher.AddFocusBarItem(this.menuItemIntervRunIntervention);
      this.menuItemInterventions.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemIntervPlanIntervention,
        (MenuItem) this.menuItemIntervRunIntervention
      });
      this.menuItemIntervPlanIntervention.ImageIndex = -1;
      this.menuItemIntervPlanIntervention.ImageList = (ImageList) null;
      this.menuItemIntervPlanIntervention.Index = 0;
      this.menuItemIntervPlanIntervention.NoEdit = false;
      this.menuItemIntervPlanIntervention.NoUIModify = false;
      this.menuItemIntervPlanIntervention.OriginalText = "";
      this.menuItemIntervPlanIntervention.OwnerDraw = true;
      this.menuItemIntervPlanIntervention.Text = "&Plan Intervention";
      this.menuItemIntervPlanIntervention.Click += new EventHandler(this.menuItemIntervPlanIntervention_Click);
      this.menuItemIntervRunIntervention.ImageIndex = -1;
      this.menuItemIntervRunIntervention.ImageList = (ImageList) null;
      this.menuItemIntervRunIntervention.Index = 1;
      this.menuItemIntervRunIntervention.NoEdit = false;
      this.menuItemIntervRunIntervention.NoUIModify = false;
      this.menuItemIntervRunIntervention.OriginalText = "";
      this.menuItemIntervRunIntervention.OwnerDraw = true;
      this.menuItemIntervRunIntervention.Text = "&Run Intervention";
      this.menuItemIntervRunIntervention.Click += new EventHandler(this.menuItemIntervRunIntervention_Click);
      this.menuItemIntervSchoolInterventionReport = new UIMenuItem();
      this.menuItemIntervOutcomeAnalysisReport = new UIMenuItem();
      this.menuItemIntervStudentInterventionReport = new UIMenuItem();
      this.menuItemIntervCostAnalysisReport = new UIMenuItem();
      this.menuItemInterventionsReports.MenuItems.Add((MenuItem) this.menuItemIntervCostAnalysisReport);
      this.menuItemInterventionsReports.MenuItems.Add((MenuItem) this.menuItemIntervSchoolInterventionReport);
      this.menuItemInterventionsReports.MenuItems.Add((MenuItem) this.menuItemIntervOutcomeAnalysisReport);
      this.menuItemInterventionsReports.MenuItems.Add((MenuItem) this.menuItemIntervStudentInterventionReport);
      this.MenuItemReports.MenuItems.Add((MenuItem) this.menuItemInterventionsReports);
      this.menuItemIntervCostAnalysisReport.ImageIndex = -1;
      this.menuItemIntervCostAnalysisReport.ImageList = (ImageList) null;
      this.menuItemIntervCostAnalysisReport.Index = 0;
      this.menuItemIntervCostAnalysisReport.NoEdit = false;
      this.menuItemIntervCostAnalysisReport.NoUIModify = false;
      this.menuItemIntervCostAnalysisReport.OriginalText = "";
      this.menuItemIntervCostAnalysisReport.OwnerDraw = true;
      this.menuItemIntervCostAnalysisReport.Text = "Intervention &Cost Analysis";
      this.menuItemIntervCostAnalysisReport.Click += new EventHandler(this.menuItemIntervCostAnalysisReportClick);
      this.menuItemIntervOutcomeAnalysisReport.ImageIndex = -1;
      this.menuItemIntervOutcomeAnalysisReport.ImageList = (ImageList) null;
      this.menuItemIntervOutcomeAnalysisReport.Index = 1;
      this.menuItemIntervOutcomeAnalysisReport.NoEdit = false;
      this.menuItemIntervOutcomeAnalysisReport.NoUIModify = false;
      this.menuItemIntervOutcomeAnalysisReport.OriginalText = "";
      this.menuItemIntervOutcomeAnalysisReport.OwnerDraw = true;
      this.menuItemIntervOutcomeAnalysisReport.Text = "Intervention &Outcome Analysis";
      this.menuItemIntervOutcomeAnalysisReport.Click += new EventHandler(this.menuItemIntervOutcomeAnalysisReport_Click);
      this.menuItemIntervSchoolInterventionReport.ImageIndex = -1;
      this.menuItemIntervSchoolInterventionReport.ImageList = (ImageList) null;
      this.menuItemIntervSchoolInterventionReport.Index = 2;
      this.menuItemIntervSchoolInterventionReport.NoEdit = false;
      this.menuItemIntervSchoolInterventionReport.NoUIModify = false;
      this.menuItemIntervSchoolInterventionReport.OriginalText = "";
      this.menuItemIntervSchoolInterventionReport.OwnerDraw = true;
      this.menuItemIntervSchoolInterventionReport.Text = "&School Intervention Report";
      this.menuItemIntervSchoolInterventionReport.Click += new EventHandler(this.menuItemIntervSchoolInterventionReport_Click);
      this.menuItemIntervStudentInterventionReport.ImageIndex = -1;
      this.menuItemIntervStudentInterventionReport.ImageList = (ImageList) null;
      this.menuItemIntervStudentInterventionReport.Index = 3;
      this.menuItemIntervStudentInterventionReport.NoEdit = false;
      this.menuItemIntervStudentInterventionReport.NoUIModify = false;
      this.menuItemIntervStudentInterventionReport.OriginalText = "";
      this.menuItemIntervStudentInterventionReport.OwnerDraw = true;
      this.menuItemIntervStudentInterventionReport.Text = "Student &Intervention Report";
      this.menuItemIntervStudentInterventionReport.Click += new EventHandler(this.menuItemIntervStudentInterventionReport_Click);
    }

    private void rebuildInterventionsMenus()
    {
      string[] processNames1 = new string[2]
      {
        "IntervPlanViewAll",
        "IntervPlanManageAll"
      };
      string[] processNames2 = new string[3]
      {
        "IntervRunViewAll",
        "IntervRunEditAll",
        "IntervRunEditOwn"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemIntervPlanIntervention, processNames1);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemIntervRunIntervention, processNames2);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemIntervSchoolInterventionReport, processNames2);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemIntervOutcomeAnalysisReport, processNames2);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemIntervStudentInterventionReport, processNames2);
      this.setMenuItemInterventionsCostsVisibility();
      this.menuItemInterventions.Visible = this.menuItemIntervPlanIntervention.Visible || this.menuItemIntervRunIntervention.Visible;
    }

    private void setMenuItemInterventionsCostsVisibility()
    {
      this.menuItemIntervCostAnalysisReport.Visible = (SIMS.Entities.Cache.ProcessVisible("IntervPlanViewAll") || SIMS.Entities.Cache.ProcessVisible("IntervRunViewAll")) && (SIMS.Entities.Cache.ProcessVisible("IntervCostsViewAll") || SIMS.Entities.Cache.ProcessVisible("IntervCostsEditAll"));
    }

    private void menuItemIntervPlanIntervention_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new InterventionOverviewBrowseDetail());
    }

    private void menuItemIntervRunIntervention_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new InterventionInstanceBrowseDetail());
    }

    private void menuItemIntervStudentInterventionReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgInterventionStudentReport interventionStudentReport = new DlgInterventionStudentReport())
      {
        int num = (int) interventionStudentReport.ShowDialog();
      }
    }

    private void menuItemIntervSchoolInterventionReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new InterventionSchoolReportDetail());
    }

    private void menuItemIntervOutcomeAnalysisReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new InterventionOutcomeAnalysisReportDetail());
    }

    private void menuItemIntervCostAnalysisReportClick(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new InterventionCostAnalysisReportDetail());
    }

    private void initHousekeepingMenus()
    {
      this.menuItemDeleteUnlinkedContacts = new UIMenuItem();
      this.menuItemMergeAgencies = new UIMenuItem();
      this.menuItemMergeAgents = new UIMenuItem();
      this.menuItemHousekeepingGeneral = new UIMenuItem();
      this.menuItemHouseKeepingManageMessages = new UIMenuItem();
      this.menuItemHousekeeping.MenuItems.AddRange(new MenuItem[9]
      {
        (MenuItem) this.menuItemHousekeepingGeneral,
        (MenuItem) this.menuItemDeleteUnlinkedContacts,
        (MenuItem) this.menuItemMergeAgents,
        (MenuItem) this.menuItemMergeAgencies,
        (MenuItem) this.menuItemBulkAddressValidationScheduler,
        (MenuItem) this.menuItemBulkAddressTools,
        (MenuItem) this.menuItemToolMaintainDocuments,
        (MenuItem) this.menuItemToolsAttArchiving,
        (MenuItem) this.menuItemHouseKeepingManageMessages
      });
      this.menuItemHousekeepingGeneral.Index = 0;
      this.menuItemHousekeepingGeneral.Text = "&General";
      this.menuItemHousekeepingGeneral.Click += new EventHandler(this.menuItemHousekeepingGeneral_Click);
      this.menuItemDeleteUnlinkedContacts.Index = 1;
      this.menuItemDeleteUnlinkedContacts.Text = "&Delete Unlinked Contacts";
      this.menuItemDeleteUnlinkedContacts.Click += new EventHandler(this.menuItemDeleteUnlinkedContacts_Click);
      this.menuItemMergeAgencies.Index = 2;
      this.menuItemMergeAgencies.Text = "&Merge Agencies";
      this.menuItemMergeAgencies.Click += new EventHandler(this.menuItemMergeAgencies_Click);
      this.menuItemMergeAgents.Index = 3;
      this.menuItemMergeAgents.Text = "Merge &Agents";
      this.menuItemMergeAgents.Click += new EventHandler(this.menuItemMergeAgents_Click);
      this.menuItemBulkAddressTools.HelpDescription = (string) null;
      this.menuItemBulkAddressTools.ImageIndex = -1;
      this.menuItemBulkAddressTools.ImageList = (ImageList) null;
      this.menuItemBulkAddressTools.Index = 5;
      this.menuItemBulkAddressTools.MenuItems.AddRange(new MenuItem[4]
      {
        (MenuItem) this.menuItemBABulkAddressValidationSchedule,
        (MenuItem) this.menuItemBABulkAddressValidation,
        (MenuItem) this.menuItemTidyAndMergeAddresses,
        (MenuItem) this.menuItemUnmatchableAddressesReport
      });
      this.menuItemBulkAddressTools.NoEdit = false;
      this.menuItemBulkAddressTools.NoUIModify = false;
      this.menuItemBulkAddressTools.OriginalText = "";
      this.menuItemBulkAddressTools.OwnerDraw = true;
      this.menuItemBulkAddressTools.Text = "&Bulk Address Tools";
      this.menuItemBulkAddressValidationScheduler.HelpDescription = (string) null;
      this.menuItemBulkAddressValidationScheduler.ImageIndex = -1;
      this.menuItemBulkAddressValidationScheduler.ImageList = (ImageList) null;
      this.menuItemBulkAddressValidationScheduler.Index = 5;
      this.menuItemBulkAddressValidationScheduler.NoEdit = false;
      this.menuItemBulkAddressValidationScheduler.NoUIModify = false;
      this.menuItemBulkAddressValidationScheduler.OriginalText = "";
      this.menuItemBulkAddressValidationScheduler.OwnerDraw = true;
      this.menuItemBulkAddressValidationScheduler.Text = "Bulk Address Validation &Scheduler";
      this.menuItemBulkAddressValidationScheduler.Click += new EventHandler(this.menuItemBulkAddressValidationScheduler_Click);
      this.menuItemBABulkAddressValidationSchedule.HelpDescription = (string) null;
      this.menuItemBABulkAddressValidationSchedule.ImageIndex = -1;
      this.menuItemBABulkAddressValidationSchedule.ImageList = (ImageList) null;
      this.menuItemBABulkAddressValidationSchedule.Index = 0;
      this.menuItemBABulkAddressValidationSchedule.MenuItems.AddRange(new MenuItem[7]
      {
        (MenuItem) this.menuItemBAVStudentsAndContacts,
        (MenuItem) this.menuItemBAVApplicantsAndContacts,
        (MenuItem) this.menuItemBAVEnquierAddress,
        (MenuItem) this.menuItemBAVStaff,
        (MenuItem) this.menuItemBAVAgents,
        (MenuItem) this.menuItemBAVAgencies,
        (MenuItem) this.menuItemBAVOtherSchools
      });
      this.menuItemBABulkAddressValidationSchedule.NoEdit = false;
      this.menuItemBABulkAddressValidationSchedule.NoUIModify = false;
      this.menuItemBABulkAddressValidationSchedule.OriginalText = "";
      this.menuItemBABulkAddressValidationSchedule.OwnerDraw = true;
      this.menuItemBABulkAddressValidationSchedule.Text = "Bulk Address Validation &Export";
      this.menuItemBAVOtherSchools.HelpDescription = (string) null;
      this.menuItemBAVOtherSchools.ImageIndex = -1;
      this.menuItemBAVOtherSchools.ImageList = (ImageList) null;
      this.menuItemBAVOtherSchools.NoEdit = false;
      this.menuItemBAVOtherSchools.NoUIModify = false;
      this.menuItemBAVOtherSchools.OriginalText = "";
      this.menuItemBAVOtherSchools.OwnerDraw = true;
      this.menuItemBAVOtherSchools.Text = "&Other Schools";
      this.menuItemBAVOtherSchools.Click += new EventHandler(this.menuItemBAVOtherSchools_Click);
      this.menuItemBAVApplicantsAndContacts.HelpDescription = (string) null;
      this.menuItemBAVApplicantsAndContacts.ImageIndex = -1;
      this.menuItemBAVApplicantsAndContacts.ImageList = (ImageList) null;
      this.menuItemBAVApplicantsAndContacts.NoEdit = false;
      this.menuItemBAVApplicantsAndContacts.NoUIModify = false;
      this.menuItemBAVApplicantsAndContacts.OriginalText = "";
      this.menuItemBAVApplicantsAndContacts.OwnerDraw = true;
      this.menuItemBAVApplicantsAndContacts.Text = "&Applicants and Contacts";
      this.menuItemBAVApplicantsAndContacts.Click += new EventHandler(this.menuItemBAVApplicantsAndContacts_Click);
      this.menuItemBAVStudentsAndContacts.HelpDescription = (string) null;
      this.menuItemBAVStudentsAndContacts.ImageIndex = -1;
      this.menuItemBAVStudentsAndContacts.ImageList = (ImageList) null;
      this.menuItemBAVStudentsAndContacts.NoEdit = false;
      this.menuItemBAVStudentsAndContacts.NoUIModify = false;
      this.menuItemBAVStudentsAndContacts.OriginalText = "";
      this.menuItemBAVStudentsAndContacts.OwnerDraw = true;
      this.menuItemBAVStudentsAndContacts.Text = "&Students and Contacts";
      this.menuItemBAVStudentsAndContacts.Click += new EventHandler(this.menuItemBAVStudentsAndContacts_Click);
      this.menuItemBAVEnquierAddress.HelpDescription = (string) null;
      this.menuItemBAVEnquierAddress.ImageIndex = -1;
      this.menuItemBAVEnquierAddress.ImageList = (ImageList) null;
      this.menuItemBAVEnquierAddress.NoEdit = false;
      this.menuItemBAVEnquierAddress.NoUIModify = false;
      this.menuItemBAVEnquierAddress.OriginalText = "";
      this.menuItemBAVEnquierAddress.OwnerDraw = true;
      this.menuItemBAVEnquierAddress.Text = "&Enquirers";
      this.menuItemBAVEnquierAddress.Click += new EventHandler(this.menuItemBAVEnquierAddress_Click);
      this.menuItemBAVStaff.HelpDescription = (string) null;
      this.menuItemBAVStaff.ImageIndex = -1;
      this.menuItemBAVStaff.ImageList = (ImageList) null;
      this.menuItemBAVStaff.NoEdit = false;
      this.menuItemBAVStaff.NoUIModify = false;
      this.menuItemBAVStaff.OriginalText = "";
      this.menuItemBAVStaff.OwnerDraw = true;
      this.menuItemBAVStaff.Text = "Staf&f And Next of Kin";
      this.menuItemBAVStaff.Click += new EventHandler(this.menuItemBAVStaff_Click);
      this.menuItemBAVAgents.HelpDescription = (string) null;
      this.menuItemBAVAgents.ImageIndex = -1;
      this.menuItemBAVAgents.ImageList = (ImageList) null;
      this.menuItemBAVAgents.NoEdit = false;
      this.menuItemBAVAgents.NoUIModify = false;
      this.menuItemBAVAgents.OriginalText = "";
      this.menuItemBAVAgents.OwnerDraw = true;
      this.menuItemBAVAgents.Text = "Agen&ts";
      this.menuItemBAVAgents.Click += new EventHandler(this.menuItemBAVAgents_Click);
      this.menuItemBAVAgencies.HelpDescription = (string) null;
      this.menuItemBAVAgencies.ImageIndex = -1;
      this.menuItemBAVAgencies.ImageList = (ImageList) null;
      this.menuItemBAVAgencies.NoEdit = false;
      this.menuItemBAVAgencies.NoUIModify = false;
      this.menuItemBAVAgencies.OriginalText = "";
      this.menuItemBAVAgencies.OwnerDraw = true;
      this.menuItemBAVAgencies.Text = "Agen&cies";
      this.menuItemBAVAgencies.Click += new EventHandler(this.menuItemBAVAgencies_Click);
      this.menuItemBABulkAddressValidation.HelpDescription = (string) null;
      this.menuItemBABulkAddressValidation.ImageIndex = -1;
      this.menuItemBABulkAddressValidation.ImageList = (ImageList) null;
      this.menuItemBABulkAddressValidation.Index = 1;
      this.menuItemBABulkAddressValidation.NoEdit = false;
      this.menuItemBABulkAddressValidation.NoUIModify = false;
      this.menuItemBABulkAddressValidation.OriginalText = "";
      this.menuItemBABulkAddressValidation.OwnerDraw = true;
      this.menuItemBABulkAddressValidation.Text = "Bulk Address Validation &Import";
      this.menuItemBABulkAddressValidation.Click += new EventHandler(this.menuItemBAVBulkAddressValidation_Click);
      this.menuItemTidyAndMergeAddresses.HelpDescription = (string) null;
      this.menuItemTidyAndMergeAddresses.ImageIndex = -1;
      this.menuItemTidyAndMergeAddresses.ImageList = (ImageList) null;
      this.menuItemTidyAndMergeAddresses.Index = 2;
      this.menuItemTidyAndMergeAddresses.NoEdit = false;
      this.menuItemTidyAndMergeAddresses.NoUIModify = false;
      this.menuItemTidyAndMergeAddresses.OriginalText = "";
      this.menuItemTidyAndMergeAddresses.OwnerDraw = true;
      this.menuItemTidyAndMergeAddresses.Text = "Tidy and Merge Addresses";
      this.menuItemTidyAndMergeAddresses.Click += new EventHandler(this.menuItemTidyAndMergeAddresses_Click);
      this.menuItemUnmatchableAddressesReport.HelpDescription = (string) null;
      this.menuItemUnmatchableAddressesReport.ImageIndex = -1;
      this.menuItemUnmatchableAddressesReport.ImageList = (ImageList) null;
      this.menuItemUnmatchableAddressesReport.Index = 3;
      this.menuItemUnmatchableAddressesReport.NoEdit = false;
      this.menuItemUnmatchableAddressesReport.NoUIModify = false;
      this.menuItemUnmatchableAddressesReport.OriginalText = "";
      this.menuItemUnmatchableAddressesReport.OwnerDraw = true;
      this.menuItemUnmatchableAddressesReport.Text = "Unmatchable Addresses Report";
      this.menuItemUnmatchableAddressesReport.Click += new EventHandler(this.menuItemUnmatchableAddressesReport_Click);
      this.menuItemHouseKeepingManageMessages.Index = 8;
      this.menuItemHouseKeepingManageMessages.Text = "Manage M&essages";
      this.menuItemHouseKeepingManageMessages.Click += new EventHandler(this.menuItemHouseKeepingManageMessages_Click);
    }

    private void rebuildHousekeepingMenus()
    {
      this.menuItemHousekeepingGeneral.Visible = SIMS.Entities.Cache.ProcessAvailable("MaintainNameFormat") || SIMS.Entities.Cache.ProcessAvailable("ResetParentalBallotFlags") || SIMS.Entities.Cache.ProcessAvailable("UpdateMailingPoint");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemDeleteUnlinkedContacts, "DeleteUnLinkedContact");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMergeAgents, "MergeAgents");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMergeAgencies, "MergeAgencies");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemToolsAttArchivingArchive, ArchivingWizardContainer.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemToolsAttArchivingHistory, "ArchivingProcess");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemHouseKeepingManageMessages, new string[2]
      {
        "BrowseEmployeeAlertMessages",
        "MaintainAlertMessages"
      });
      SIMS.Processes.InTouch.Cache.Populate();
      if (!SIMS.Entities.InTouch.Cache.Licensed)
        return;
      this.menuItemHouseKeepingManageMessages.Visible = SIMS.Entities.InTouch.Cache.Licensed && SIMS.Entities.Cache.ProcessAvailable("InTouch.MaintainIntouchMessages");
    }

    private void menuItemDeleteUnlinkedContacts_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new UnlinkedContactUI());
    }

    private void menuItemMergeAgencies_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MergeAgencyDetail());
    }

    private void menuItemMergeAgents_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MergeAgentDetail());
    }

    private void menuItemBulkAddressValidationScheduler_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new BAVMaintainTaskInformation());
    }

    private void menuItemHousekeepingGeneral_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExistsLike("SIMS.UserInterfaces.NameFormatContainer", SIMS.Entities.Cache.UserInterfaceLabel("Housekeeping")) != null)
        return;
      this.DisplayNewComponent((Control) new NameFormatContainer());
    }

    private void initAttendanceMenus()
    {
      this.menuItemTakeRegister = new UIMenuItem();
      this.menuItemDisplayAttendanceMarks = new UIMenuItem();
      this.menuItemSeparatorAttendanceFocus = new UIMenuItem();
      this.menuItemLessonMonitorReportLaunch = new UIMenuItem();
      this.menuItemUnexplainedAbsences = new UIMenuItem();
      this.menuItemDisplayMissingMarks = new UIMenuItem();
      this.menuItemCodeOverDateRange = new UIMenuItem();
      this.menuItemEnterWeeklyPattern = new UIMenuItem();
      this.menuItemEditMarks = new UIMenuItem();
      this.menuItemConflictingLessonMarks = new UIMenuItem();
      this.menuItemLessonMonitorSetup = new UIMenuItem();
      this.menuItemEarliestMarksSetup = new UIMenuItem();
      this.menuItemExtraNames = new UIMenuItem();
      this.menuItemEditReasonForChange = new UIMenuItem();
      this.menuItemExceptionalCircumstances = new UIMenuItem();
      this.menuItemOMR = new UIMenuItem();
      this.menuItemPrintOMRRegistrationSheet = new UIMenuItem();
      this.menuItemPrintOMRRegistrationSheetWeekendSession = new UIMenuItem();
      this.menuItemPrintOMRAbsenceSheet = new UIMenuItem();
      this.menuItemReadOMRRegistrationSheet = new UIMenuItem();
      this.menuItemReadOMRAbsenceSheet = new UIMenuItem();
      this.menuItemConflictingSessionMarks = new UIMenuItem();
      this.menuItemIndividualStudentReports = new UIMenuItem();
      this.menuItemWholeGroupStudentReports = new UIMenuItem();
      this.menuItemSelectedStudentReports = new UIMenuItem();
      this.menuItemGroupReports = new UIMenuItem();
      this.menuItemModuleReports = new UIMenuItem();
      this.menuItemLetters = new UIMenuItem();
      this.menuItemManualEntry = new UIMenuItem();
      this.menuItemIndividualRegisterReport = new UIMenuItem();
      this.menuItemFullRegisterReport = new UIMenuItem();
      this.menuItemIndividualAttendanceSummary = new UIMenuItem();
      this.menuItemClassRegisterReport = new UIMenuItem();
      this.menuItemLessonMarksbyCategory = new UIMenuItem();
      this.menuItemGroupAnalysisByAttendanceCategory = new UIMenuItem();
      this.menuItemLessonAbsencesReport = new UIMenuItem();
      this.menuItemContinuousAbsenceReport = new UIMenuItem();
      this.menuItemSessionAbsencesReport = new UIMenuItem();
      this.menuItemFirstDayofAbsenceReport = new UIMenuItem();
      this.menuItemLessonAttendancebySubjects = new UIMenuItem();
      this.menuItemMinutesLateReport = new UIMenuItem();
      this.menuItemLessonAttendancebyClassesReport = new UIMenuItem();
      this.menuItemPercentageAttendanceReport = new UIMenuItem();
      this.menuItemCommentsReport = new UIMenuItem();
      this.menuItemPostRegAbsenceReport = new UIMenuItem();
      this.menuItemHistoryOfChangesReport = new UIMenuItem();
      this.menuItemStudentWeeklyLessonAttendanceReport = new UIMenuItem();
      this.menuItemPeriodsWithChosenCodeReport = new UIMenuItem();
      this.menuItemRegistersWithMissingMarksReport = new UIMenuItem();
      this.menuItemCompareMarksbyColumnReport = new UIMenuItem();
      this.menuItemTodaysRegisterReport = new UIMenuItem();
      this.menuItemGroupWeeklyLessonAttendanceReport = new UIMenuItem();
      this.menuItemNewAbsenteesReport = new UIMenuItem();
      this.menuItemJointAbsenceDetection = new UIMenuItem();
      this.menuItemSiblingAbsenceDetection = new UIMenuItem();
      this.menuItemSchoolProspectusAnalysis = new UIMenuItem();
      this.menuItemPupilsSchoolCareerAttendance = new UIMenuItem();
      this.menuItemSessionMissingMarks = new UIMenuItem();
      this.menuItemUnexplainedAbsencesReport = new UIMenuItem();
      this.menuItemRegisterCertificateReport = new UIMenuItem();
      this.menuItemOfficialRegisterReport = new UIMenuItem();
      this.menuItemIndividualSummaryReport = new UIMenuItem();
      this.menuItemGroupSessionSummary = new UIMenuItem();
      this.menuItemWelshSchoolPerformanceInformation = new UIMenuItem();
      this.menuItemPupilsYearlyAttendance = new UIMenuItem();
      this.menuItemPupilAnalysisByAMPM = new UIMenuItem();
      this.menuItemBrokenWeekReport = new UIMenuItem();
      this.menuItemGroupAnalysisbyCodeReport = new UIMenuItem();
      this.menuItemPupilAnalysisBySessionInWeek = new UIMenuItem();
      this.menuItemGroupWeeklyAnalysisReport = new UIMenuItem();
      this.menuItemPupilAnalysisByAttendanceCode = new UIMenuItem();
      this.menuItemGroupAnalysisbyAMPMReport = new UIMenuItem();
      this.menuItemMissedCurriculumReport = new UIMenuItem();
      this.menuItemGroupAnalysisBySessionInWeekReport = new UIMenuItem();
      this.menuItemPupilswithChosenCodeReport = new UIMenuItem();
      this.menuItemGroupAnalysisbySTARFieldReport = new UIMenuItem();
      this.menuItemGroupAnalysisbyVulnerabilityReport = new UIMenuItem();
      this.menuItemPrintLetters = new UIMenuItem();
      this.menuItemLettersCreated = new UIMenuItem();
      this.menuItemPrintRegistrationSheet = new UIMenuItem();
      this.menuItemPrintAbsenceSheet = new UIMenuItem();
      this.menuItemPersistentAbsenceReport = new UIMenuItem();
      this.menuItemPersistentAbsenceStudentThreshold = new UIMenuItem();
      this.menuItemMealListReport = new UIMenuItem();
      this.menuItemNIClosingReport = new UIMenuItem();
      this.menuItemAttendanceReportSeperator1 = new UIMenuItem();
      this.menuItemAttendanceReportSeperator2 = new UIMenuItem();
      this.menuItemAttendanceReportSeperator3 = new UIMenuItem();
      this.menuItemAttendanceReportSeperator4 = new UIMenuItem();
      this.menuItemAttendanceReportSeperator5 = new UIMenuItem();
      this.menuItemAttendanceReportSeperator6 = new UIMenuItem();
      this.menuItemAttendanceReportSeperator7 = new UIMenuItem();
      this.menuItemAttendanceReportSeperator8 = new UIMenuItem();
      this.menuItemAttendanceReportSeperator1.ImageIndex = -1;
      this.menuItemAttendanceReportSeperator1.ImageList = (ImageList) null;
      this.menuItemAttendanceReportSeperator1.Index = 0;
      this.menuItemAttendanceReportSeperator1.NoEdit = false;
      this.menuItemAttendanceReportSeperator1.NoUIModify = false;
      this.menuItemAttendanceReportSeperator1.OriginalText = "";
      this.menuItemAttendanceReportSeperator1.OwnerDraw = true;
      this.menuItemAttendanceReportSeperator1.Text = "-";
      this.menuItemAttendanceReportSeperator2.ImageIndex = -1;
      this.menuItemAttendanceReportSeperator2.ImageList = (ImageList) null;
      this.menuItemAttendanceReportSeperator2.Index = 0;
      this.menuItemAttendanceReportSeperator2.NoEdit = false;
      this.menuItemAttendanceReportSeperator2.NoUIModify = false;
      this.menuItemAttendanceReportSeperator2.OriginalText = "";
      this.menuItemAttendanceReportSeperator2.OwnerDraw = true;
      this.menuItemAttendanceReportSeperator2.Text = "-";
      this.menuItemAttendanceReportSeperator3.ImageIndex = -1;
      this.menuItemAttendanceReportSeperator3.ImageList = (ImageList) null;
      this.menuItemAttendanceReportSeperator3.Index = 0;
      this.menuItemAttendanceReportSeperator3.NoEdit = false;
      this.menuItemAttendanceReportSeperator3.NoUIModify = false;
      this.menuItemAttendanceReportSeperator3.OriginalText = "";
      this.menuItemAttendanceReportSeperator3.OwnerDraw = true;
      this.menuItemAttendanceReportSeperator3.Text = "-";
      this.menuItemAttendanceReportSeperator4.ImageIndex = -1;
      this.menuItemAttendanceReportSeperator4.ImageList = (ImageList) null;
      this.menuItemAttendanceReportSeperator4.Index = 0;
      this.menuItemAttendanceReportSeperator4.NoEdit = false;
      this.menuItemAttendanceReportSeperator4.NoUIModify = false;
      this.menuItemAttendanceReportSeperator4.OriginalText = "";
      this.menuItemAttendanceReportSeperator4.OwnerDraw = true;
      this.menuItemAttendanceReportSeperator4.Text = "-";
      this.menuItemAttendanceReportSeperator5.ImageIndex = -1;
      this.menuItemAttendanceReportSeperator5.ImageList = (ImageList) null;
      this.menuItemAttendanceReportSeperator5.Index = 0;
      this.menuItemAttendanceReportSeperator5.NoEdit = false;
      this.menuItemAttendanceReportSeperator5.NoUIModify = false;
      this.menuItemAttendanceReportSeperator5.OriginalText = "";
      this.menuItemAttendanceReportSeperator5.OwnerDraw = true;
      this.menuItemAttendanceReportSeperator5.Text = "-";
      this.menuItemAttendanceReportSeperator6.ImageIndex = -1;
      this.menuItemAttendanceReportSeperator6.ImageList = (ImageList) null;
      this.menuItemAttendanceReportSeperator6.Index = 0;
      this.menuItemAttendanceReportSeperator6.NoEdit = false;
      this.menuItemAttendanceReportSeperator6.NoUIModify = false;
      this.menuItemAttendanceReportSeperator6.OriginalText = "";
      this.menuItemAttendanceReportSeperator6.OwnerDraw = true;
      this.menuItemAttendanceReportSeperator6.Text = "-";
      this.menuItemAttendanceReportSeperator7.ImageIndex = -1;
      this.menuItemAttendanceReportSeperator7.ImageList = (ImageList) null;
      this.menuItemAttendanceReportSeperator7.Index = 0;
      this.menuItemAttendanceReportSeperator7.NoEdit = false;
      this.menuItemAttendanceReportSeperator7.NoUIModify = false;
      this.menuItemAttendanceReportSeperator7.OriginalText = "";
      this.menuItemAttendanceReportSeperator7.OwnerDraw = true;
      this.menuItemAttendanceReportSeperator7.Text = "-";
      this.menuItemAttendanceReportSeperator8.ImageIndex = -1;
      this.menuItemAttendanceReportSeperator8.ImageList = (ImageList) null;
      this.menuItemAttendanceReportSeperator8.Index = 0;
      this.menuItemAttendanceReportSeperator8.NoEdit = false;
      this.menuItemAttendanceReportSeperator8.NoUIModify = false;
      this.menuItemAttendanceReportSeperator8.OriginalText = "";
      this.menuItemAttendanceReportSeperator8.OwnerDraw = true;
      this.menuItemAttendanceReportSeperator8.Text = "-";
      this.menuItemNIClosingReport.Text = "Cl&osing School Attendance";
      this.menuItemNIClosingReport.Click += new EventHandler(this.menuItemNIClosingReport_Click);
      this.menuItemDisplayAttendanceMarks.ImageIndex = -1;
      this.menuItemDisplayAttendanceMarks.ImageList = (ImageList) null;
      this.menuItemDisplayAttendanceMarks.Index = 0;
      this.menuItemDisplayAttendanceMarks.NoEdit = false;
      this.menuItemDisplayAttendanceMarks.NoUIModify = false;
      this.menuItemDisplayAttendanceMarks.OriginalText = "";
      this.menuItemDisplayAttendanceMarks.OwnerDraw = true;
      this.menuItemDisplayAttendanceMarks.Text = "&Display Marks";
      this.menuItemDisplayAttendanceMarks.Click += new EventHandler(this.menuItemDisplayAttendanceMarks_Click);
      this.menuItemTakeRegister.ImageIndex = 94;
      this.menuItemTakeRegister.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemTakeRegister.Index = 1;
      this.menuItemTakeRegister.NoEdit = false;
      this.menuItemTakeRegister.NoUIModify = false;
      this.menuItemTakeRegister.OriginalText = "";
      this.menuItemTakeRegister.OwnerDraw = true;
      this.menuItemTakeRegister.Text = "&Take Register";
      this.menuItemTakeRegister.Click += new EventHandler(this.menuItemTakeRegister_Click);
      this.menuItemSeparatorAttendanceFocus.OriginalText = "-";
      this.menuItemSeparatorAttendanceFocus.Text = "-";
      this.menuItemLessonMonitorReportLaunch.ImageIndex = -1;
      this.menuItemLessonMonitorReportLaunch.ImageList = (ImageList) null;
      this.menuItemLessonMonitorReportLaunch.Index = 2;
      this.menuItemLessonMonitorReportLaunch.NoEdit = false;
      this.menuItemLessonMonitorReportLaunch.NoUIModify = false;
      this.menuItemLessonMonitorReportLaunch.OriginalText = "";
      this.menuItemLessonMonitorReportLaunch.OwnerDraw = true;
      this.menuItemLessonMonitorReportLaunch.Text = "&Minutes Late Report";
      this.menuItemLessonMonitorReportLaunch.Click += new EventHandler(this.menuItemLessonMonitorReportLaunch_Click);
      this.menuItemUnexplainedAbsences.ImageIndex = -1;
      this.menuItemUnexplainedAbsences.ImageList = (ImageList) null;
      this.menuItemUnexplainedAbsences.Index = 0;
      this.menuItemUnexplainedAbsences.NoEdit = false;
      this.menuItemUnexplainedAbsences.NoUIModify = false;
      this.menuItemUnexplainedAbsences.OriginalText = "";
      this.menuItemUnexplainedAbsences.OwnerDraw = true;
      this.menuItemUnexplainedAbsences.Text = "Deal with &Unexplained Absences";
      this.menuItemUnexplainedAbsences.Click += new EventHandler(this.menuItemUnexplainedAbsences_Click);
      this.menuItemDisplayMissingMarks.ImageIndex = -1;
      this.menuItemDisplayMissingMarks.ImageList = (ImageList) null;
      this.menuItemDisplayMissingMarks.Index = 0;
      this.menuItemDisplayMissingMarks.NoEdit = false;
      this.menuItemDisplayMissingMarks.NoUIModify = false;
      this.menuItemDisplayMissingMarks.OriginalText = "";
      this.menuItemDisplayMissingMarks.OwnerDraw = true;
      this.menuItemDisplayMissingMarks.Text = "Deal with &Missing Marks";
      this.menuItemDisplayMissingMarks.Click += new EventHandler(this.menuItemDisplayMissingMarks_Click);
      this.menuItemCodeOverDateRange.ImageIndex = -1;
      this.menuItemCodeOverDateRange.ImageList = (ImageList) null;
      this.menuItemCodeOverDateRange.Index = 0;
      this.menuItemCodeOverDateRange.NoEdit = false;
      this.menuItemCodeOverDateRange.NoUIModify = false;
      this.menuItemCodeOverDateRange.OriginalText = "";
      this.menuItemCodeOverDateRange.OwnerDraw = true;
      this.menuItemCodeOverDateRange.Text = "Enter a Code &over a Date Range";
      this.menuItemCodeOverDateRange.Click += new EventHandler(this.menuItemCodeOverDateRange_Click);
      this.menuItemEnterWeeklyPattern.ImageIndex = -1;
      this.menuItemEnterWeeklyPattern.ImageList = (ImageList) null;
      this.menuItemEnterWeeklyPattern.Index = 0;
      this.menuItemEnterWeeklyPattern.NoEdit = false;
      this.menuItemEnterWeeklyPattern.NoUIModify = false;
      this.menuItemEnterWeeklyPattern.OriginalText = "";
      this.menuItemEnterWeeklyPattern.OwnerDraw = true;
      this.menuItemEnterWeeklyPattern.Text = "Enter a &Weekly Pattern";
      this.menuItemEnterWeeklyPattern.Click += new EventHandler(this.menuItemEnterWeeklyPattern_Click);
      this.menuItemEditMarks.ImageIndex = -1;
      this.menuItemEditMarks.ImageList = (ImageList) null;
      this.menuItemEditMarks.Index = 0;
      this.menuItemEditMarks.NoEdit = false;
      this.menuItemEditMarks.NoUIModify = false;
      this.menuItemEditMarks.OriginalText = "";
      this.menuItemEditMarks.OwnerDraw = true;
      this.menuItemEditMarks.Text = "Edit Mar&ks";
      this.menuItemEditMarks.Click += new EventHandler(this.menuItemEditMarks_Click);
      this.menuItemConflictingLessonMarks.ImageIndex = -1;
      this.menuItemConflictingLessonMarks.ImageList = (ImageList) null;
      this.menuItemConflictingLessonMarks.Index = 0;
      this.menuItemConflictingLessonMarks.NoEdit = false;
      this.menuItemConflictingLessonMarks.NoUIModify = false;
      this.menuItemConflictingLessonMarks.OriginalText = "";
      this.menuItemConflictingLessonMarks.OwnerDraw = true;
      this.menuItemConflictingLessonMarks.Text = "&Resolve Conflicting Lesson Marks";
      this.menuItemConflictingLessonMarks.Click += new EventHandler(this.menuItemConflictingLessonMarks_Click);
      this.menuItemExtraNames.ImageIndex = -1;
      this.menuItemExtraNames.ImageList = (ImageList) null;
      this.menuItemExtraNames.Index = 0;
      this.menuItemExtraNames.NoEdit = false;
      this.menuItemExtraNames.NoUIModify = false;
      this.menuItemExtraNames.OriginalText = "";
      this.menuItemExtraNames.OwnerDraw = true;
      this.menuItemExtraNames.Text = "View &Extra Names";
      this.menuItemExtraNames.Click += new EventHandler(this.menuItemExtraNames_Click);
      this.menuItemEditReasonForChange.ImageIndex = -1;
      this.menuItemEditReasonForChange.ImageList = (ImageList) null;
      this.menuItemEditReasonForChange.Index = 0;
      this.menuItemEditReasonForChange.NoEdit = false;
      this.menuItemEditReasonForChange.NoUIModify = false;
      this.menuItemEditReasonForChange.OriginalText = "";
      this.menuItemEditReasonForChange.OwnerDraw = true;
      this.menuItemEditReasonForChange.Text = "Edit Reason For &Change";
      this.menuItemEditReasonForChange.Click += new EventHandler(this.menuItemEditReasonForChange_Click);
      this.menuItemExceptionalCircumstances.ImageIndex = -1;
      this.menuItemExceptionalCircumstances.ImageList = (ImageList) null;
      this.menuItemExceptionalCircumstances.Index = 0;
      this.menuItemExceptionalCircumstances.NoEdit = false;
      this.menuItemExceptionalCircumstances.NoUIModify = false;
      this.menuItemExceptionalCircumstances.OriginalText = "";
      this.menuItemExceptionalCircumstances.OwnerDraw = true;
      this.menuItemExceptionalCircumstances.Text = "E&xceptional Circumstances";
      this.menuItemExceptionalCircumstances.Click += new EventHandler(this.menuItemExceptionalCircumstances_Click);
      this.menuItemOMR.ImageIndex = -1;
      this.menuItemOMR.ImageList = (ImageList) null;
      this.menuItemOMR.Index = 0;
      this.menuItemOMR.NoEdit = false;
      this.menuItemOMR.NoUIModify = false;
      this.menuItemOMR.OriginalText = "";
      this.menuItemOMR.OwnerDraw = true;
      this.menuItemOMR.Text = "&OMR Entry";
      this.menuItemPrintOMRRegistrationSheet.ImageIndex = -1;
      this.menuItemPrintOMRRegistrationSheet.ImageList = (ImageList) null;
      this.menuItemPrintOMRRegistrationSheet.Index = 0;
      this.menuItemPrintOMRRegistrationSheet.NoEdit = false;
      this.menuItemPrintOMRRegistrationSheet.NoUIModify = false;
      this.menuItemPrintOMRRegistrationSheet.OriginalText = "";
      this.menuItemPrintOMRRegistrationSheet.OwnerDraw = true;
      this.menuItemPrintOMRRegistrationSheet.Text = "&Print OMR Registration Sheet";
      this.menuItemPrintOMRRegistrationSheet.Click += new EventHandler(this.menuItemPrintOMRRegistrationSheet_Click);
      this.menuItemPrintOMRRegistrationSheetWeekendSession.ImageIndex = -1;
      this.menuItemPrintOMRRegistrationSheetWeekendSession.ImageList = (ImageList) null;
      this.menuItemPrintOMRRegistrationSheetWeekendSession.Index = 0;
      this.menuItemPrintOMRRegistrationSheetWeekendSession.NoEdit = false;
      this.menuItemPrintOMRRegistrationSheetWeekendSession.NoUIModify = false;
      this.menuItemPrintOMRRegistrationSheetWeekendSession.OriginalText = "";
      this.menuItemPrintOMRRegistrationSheetWeekendSession.OwnerDraw = true;
      this.menuItemPrintOMRRegistrationSheetWeekendSession.Text = "Print OMR Registration Sheet &Weekend Sessions";
      this.menuItemPrintOMRRegistrationSheetWeekendSession.Click += new EventHandler(this.menuItemPrintOMRRegistrationSheetWeekendSession_Click);
      this.menuItemPrintOMRAbsenceSheet.ImageIndex = -1;
      this.menuItemPrintOMRAbsenceSheet.ImageList = (ImageList) null;
      this.menuItemPrintOMRAbsenceSheet.Index = 0;
      this.menuItemPrintOMRAbsenceSheet.NoEdit = false;
      this.menuItemPrintOMRAbsenceSheet.NoUIModify = false;
      this.menuItemPrintOMRAbsenceSheet.OriginalText = "";
      this.menuItemPrintOMRAbsenceSheet.OwnerDraw = true;
      this.menuItemPrintOMRAbsenceSheet.Text = "Print &OMR Absence Sheet";
      this.menuItemPrintOMRAbsenceSheet.Click += new EventHandler(this.menuItemPrintOMRAbsenceSheet_Click);
      this.menuItemReadOMRRegistrationSheet.ImageIndex = -1;
      this.menuItemReadOMRRegistrationSheet.ImageList = (ImageList) null;
      this.menuItemReadOMRRegistrationSheet.Index = 0;
      this.menuItemReadOMRRegistrationSheet.NoEdit = false;
      this.menuItemReadOMRRegistrationSheet.NoUIModify = false;
      this.menuItemReadOMRRegistrationSheet.OriginalText = "";
      this.menuItemReadOMRRegistrationSheet.OwnerDraw = true;
      this.menuItemReadOMRRegistrationSheet.Text = "&Read OMR Registration Sheet";
      this.menuItemReadOMRRegistrationSheet.Click += new EventHandler(this.menuItemReadOMRRegistrationSheet_Click);
      this.menuItemReadOMRAbsenceSheet.ImageIndex = -1;
      this.menuItemReadOMRAbsenceSheet.ImageList = (ImageList) null;
      this.menuItemReadOMRAbsenceSheet.Index = 0;
      this.menuItemReadOMRAbsenceSheet.NoEdit = false;
      this.menuItemReadOMRAbsenceSheet.NoUIModify = false;
      this.menuItemReadOMRAbsenceSheet.OriginalText = "";
      this.menuItemReadOMRAbsenceSheet.OwnerDraw = true;
      this.menuItemReadOMRAbsenceSheet.Text = "Read OMR &Absence Sheet";
      this.menuItemReadOMRAbsenceSheet.Click += new EventHandler(this.menuItemReadOMRAbsenceSheet_Click);
      this.menuItemConflictingSessionMarks.ImageIndex = -1;
      this.menuItemConflictingSessionMarks.ImageList = (ImageList) null;
      this.menuItemConflictingSessionMarks.Index = 0;
      this.menuItemConflictingSessionMarks.NoEdit = false;
      this.menuItemConflictingSessionMarks.NoUIModify = false;
      this.menuItemConflictingSessionMarks.OriginalText = "";
      this.menuItemConflictingSessionMarks.OwnerDraw = true;
      this.menuItemConflictingSessionMarks.Text = "Resolve Conflicting &Session Marks";
      this.menuItemConflictingSessionMarks.Click += new EventHandler(this.menuItemConflictingSessionMarks_Click);
      this.menuItemAttendance.MenuItems.AddRange(new MenuItem[9]
      {
        (MenuItem) this.menuItemTakeRegister,
        (MenuItem) this.menuItemDisplayAttendanceMarks,
        (MenuItem) this.menuItemSeparatorAttendanceFocus,
        (MenuItem) this.menuItemEditMarks,
        (MenuItem) this.menuItemUnexplainedAbsences,
        (MenuItem) this.menuItemDisplayMissingMarks,
        (MenuItem) this.menuItemCodeOverDateRange,
        (MenuItem) this.menuItemEnterWeeklyPattern,
        (MenuItem) this.menuItemExceptionalCircumstances
      });
      this.menuItemOMR.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemPrintOMRRegistrationSheet,
        (MenuItem) this.menuItemPrintOMRRegistrationSheetWeekendSession,
        (MenuItem) this.menuItemPrintOMRAbsenceSheet,
        (MenuItem) this.menuItemReadOMRRegistrationSheet,
        (MenuItem) this.menuItemReadOMRAbsenceSheet
      });
      this.menuItemAttendanceRoutines.MenuItems.AddRange(new MenuItem[4]
      {
        (MenuItem) this.menuItemConflictingLessonMarks,
        (MenuItem) this.menuItemExtraNames,
        (MenuItem) this.menuItemEditReasonForChange,
        (MenuItem) this.menuItemOMR
      });
      if (SIMS.Entities.Cache.Settings.ContainsKey("AllowAutomaticResolution") && SIMS.Entities.Cache.Settings["AllowAutomaticResolution"] == "F")
        this.menuItemAttendanceRoutines.MenuItems.Add((MenuItem) this.menuItemConflictingSessionMarks);
      if (SystemConfigurationCache.IsPrimarySchool || SystemConfigurationCache.IsIndependentSchool)
      {
        this.menuItemIndividualStudentReports.OriginalText = "&Individual Pupil Reports";
        this.menuItemIndividualStudentReports.Text = "&Individual Pupil Reports";
      }
      else
      {
        this.menuItemIndividualStudentReports.OriginalText = "&Individual Student Reports";
        this.menuItemIndividualStudentReports.Text = "&Individual Student Reports";
      }
      if (SystemConfigurationCache.IsPrimarySchool || SystemConfigurationCache.IsIndependentSchool)
      {
        this.menuItemWholeGroupStudentReports.OriginalText = "&Whole Group Pupil Reports";
        this.menuItemWholeGroupStudentReports.Text = "&Whole Group Pupil Reports";
      }
      else
      {
        this.menuItemWholeGroupStudentReports.OriginalText = "&Whole Group Student Reports";
        this.menuItemWholeGroupStudentReports.Text = "&Whole Group Student Reports";
      }
      if (SystemConfigurationCache.IsPrimarySchool || SystemConfigurationCache.IsIndependentSchool)
      {
        this.menuItemSelectedStudentReports.OriginalText = "&Selected Pupil Reports";
        this.menuItemSelectedStudentReports.Text = "&Selected Pupil Reports";
      }
      else
      {
        this.menuItemSelectedStudentReports.OriginalText = "&Selected Student Reports";
        this.menuItemSelectedStudentReports.Text = "&Selected Student Reports";
      }
      this.menuItemGroupReports.OriginalText = "&Group Reports";
      this.menuItemGroupReports.Text = "&Group Reports";
      this.menuItemGroupReports.Visible = false;
      this.menuItemModuleReports.OriginalText = "&Module Reports";
      this.menuItemModuleReports.Text = "&Module Reports";
      this.menuItemModuleReports.Visible = false;
      this.menuItemLetters.OriginalText = "&Letters";
      this.menuItemLetters.Text = "&Letters";
      this.menuItemLetters.Visible = false;
      this.menuItemManualEntry.OriginalText = "Manual &Entry";
      this.menuItemManualEntry.Text = "Manual &Entry";
      this.menuItemAttendanceReports.MenuItems.AddRange(new MenuItem[7]
      {
        (MenuItem) this.menuItemIndividualStudentReports,
        (MenuItem) this.menuItemWholeGroupStudentReports,
        (MenuItem) this.menuItemSelectedStudentReports,
        (MenuItem) this.menuItemGroupReports,
        (MenuItem) this.menuItemModuleReports,
        (MenuItem) this.menuItemLetters,
        (MenuItem) this.menuItemManualEntry
      });
      this.menuItemIndividualStudentReports.MenuItems.AddRange(new MenuItem[6]
      {
        (MenuItem) this.menuItemRegisterCertificateReport,
        (MenuItem) this.menuItemIndividualSummaryReport,
        (MenuItem) this.menuItemAttendanceReportSeperator1,
        (MenuItem) this.menuItemIndividualRegisterReport,
        (MenuItem) this.menuItemAttendanceReportSeperator8,
        (MenuItem) this.menuItemIndividualAttendanceSummary
      });
      this.menuItemWholeGroupStudentReports.MenuItems.AddRange(new MenuItem[17]
      {
        (MenuItem) this.menuItemPupilAnalysisByAttendanceCode,
        (MenuItem) this.menuItemAttendanceReportSeperator2,
        (MenuItem) this.menuItemTodaysRegisterReport,
        (MenuItem) this.menuItemPupilsSchoolCareerAttendance,
        (MenuItem) this.menuItemOfficialRegisterReport,
        (MenuItem) this.menuItemPupilAnalysisByAMPM,
        (MenuItem) this.menuItemPupilsYearlyAttendance,
        (MenuItem) this.menuItemPupilAnalysisBySessionInWeek,
        (MenuItem) this.menuItemPersistentAbsenceReport,
        (MenuItem) this.menuItemPersistentAbsenceStudentThreshold,
        (MenuItem) this.menuItemAttendanceReportSeperator3,
        (MenuItem) this.menuItemClassRegisterReport,
        (MenuItem) this.menuItemFullRegisterReport,
        (MenuItem) this.menuItemLessonAttendancebySubjects,
        (MenuItem) this.menuItemLessonMarksbyCategory,
        (MenuItem) this.menuItemLessonAttendancebyClassesReport,
        (MenuItem) this.menuItemStudentWeeklyLessonAttendanceReport
      });
      this.menuItemSelectedStudentReports.MenuItems.AddRange(new MenuItem[20]
      {
        (MenuItem) this.menuItemPercentageAttendanceReport,
        (MenuItem) this.menuItemAttendanceReportSeperator4,
        (MenuItem) this.menuItemContinuousAbsenceReport,
        (MenuItem) this.menuItemSessionAbsencesReport,
        (MenuItem) this.menuItemFirstDayofAbsenceReport,
        (MenuItem) this.menuItemSessionMissingMarks,
        (MenuItem) this.menuItemUnexplainedAbsencesReport,
        (MenuItem) this.menuItemJointAbsenceDetection,
        (MenuItem) this.menuItemSiblingAbsenceDetection,
        (MenuItem) this.menuItemBrokenWeekReport,
        (MenuItem) this.menuItemMissedCurriculumReport,
        (MenuItem) this.menuItemPupilswithChosenCodeReport,
        (MenuItem) this.menuItemAttendanceReportSeperator5,
        (MenuItem) this.menuItemNewAbsenteesReport,
        (MenuItem) this.menuItemLessonAbsencesReport,
        (MenuItem) this.menuItemMinutesLateReport,
        (MenuItem) this.menuItemCommentsReport,
        (MenuItem) this.menuItemCompareMarksbyColumnReport,
        (MenuItem) this.menuItemPeriodsWithChosenCodeReport,
        (MenuItem) this.menuItemMealListReport
      });
      this.menuItemGroupReports.MenuItems.AddRange(new MenuItem[15]
      {
        (MenuItem) this.menuItemGroupAnalysisByAttendanceCategory,
        (MenuItem) this.menuItemAttendanceReportSeperator6,
        (MenuItem) this.menuItemSchoolProspectusAnalysis,
        (MenuItem) this.menuItemGroupAnalysisbyCodeReport,
        (MenuItem) this.menuItemWelshSchoolPerformanceInformation,
        (MenuItem) this.menuItemGroupSessionSummary,
        (MenuItem) this.menuItemGroupWeeklyAnalysisReport,
        (MenuItem) this.menuItemGroupAnalysisbyAMPMReport,
        (MenuItem) this.menuItemGroupAnalysisBySessionInWeekReport,
        (MenuItem) this.menuItemGroupAnalysisbySTARFieldReport,
        (MenuItem) this.menuItemGroupAnalysisbyVulnerabilityReport,
        (MenuItem) this.menuItemAttendanceReportSeperator7,
        (MenuItem) this.menuItemPostRegAbsenceReport,
        (MenuItem) this.menuItemGroupWeeklyLessonAttendanceReport,
        (MenuItem) this.menuItemNIClosingReport
      });
      this.menuItemModuleReports.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemHistoryOfChangesReport,
        (MenuItem) this.menuItemRegistersWithMissingMarksReport
      });
      this.menuItemLetters.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemPrintLetters,
        (MenuItem) this.menuItemLettersCreated
      });
      this.menuItemManualEntry.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemPrintRegistrationSheet,
        (MenuItem) this.menuItemPrintAbsenceSheet
      });
      this.menuItemLessonMonitorOptions.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemLessonMonitorSetup,
        (MenuItem) this.menuItemEarliestMarksSetup
      });
      this.menuItemLessonMonitorSetup.OriginalText = "&Lesson Monitor Setup";
      this.menuItemLessonMonitorSetup.Text = "&Lesson Monitor Setup";
      this.menuItemLessonMonitorSetup.Click += new EventHandler(this.menuItemLessonMonitorSetup_Click);
      this.menuItemEarliestMarksSetup.OriginalText = "&Earliest Marks Setup";
      this.menuItemEarliestMarksSetup.Text = "&Earliest Marks Setup";
      this.menuItemEarliestMarksSetup.Click += new EventHandler(this.menuItemEarliestMarksSetup_Click);
      this.menuItemIndividualRegisterReport.Text = "&Individual Register Report";
      this.menuItemIndividualRegisterReport.Click += new EventHandler(this.menuItemIndividualRegisterReport_Click);
      this.menuItemFullRegisterReport.Text = "&Full Register Report";
      this.menuItemFullRegisterReport.Click += new EventHandler(this.menuItemFullRegisterReport_Click);
      this.menuItemIndividualAttendanceSummary.Text = "Individual &Subject Attendance Summary";
      this.menuItemIndividualAttendanceSummary.Click += new EventHandler(this.menuItemIndividualAttendanceSummary_Click);
      this.menuItemClassRegisterReport.Text = "&Class Register Report";
      this.menuItemClassRegisterReport.Click += new EventHandler(this.menuItemClassRegisterReport_Click);
      this.menuItemLessonMarksbyCategory.Text = SystemConfigurationCache.IsPrimarySchool || SystemConfigurationCache.IsIndependentSchool ? "&Pupil Analysis by Attendance Category Report" : "&Student Analysis by Attendance Category Report";
      this.menuItemLessonMarksbyCategory.Click += new EventHandler(this.menuItemLessonMarksbyCategory_Click);
      this.menuItemGroupAnalysisByAttendanceCategory.ImageIndex = -1;
      this.menuItemGroupAnalysisByAttendanceCategory.ImageList = (ImageList) null;
      this.menuItemGroupAnalysisByAttendanceCategory.NoEdit = false;
      this.menuItemGroupAnalysisByAttendanceCategory.NoUIModify = false;
      this.menuItemGroupAnalysisByAttendanceCategory.OriginalText = "";
      this.menuItemGroupAnalysisByAttendanceCategory.OwnerDraw = true;
      this.menuItemGroupAnalysisByAttendanceCategory.Text = "Group Analysis By Attendance Categor&y Report";
      this.menuItemGroupAnalysisByAttendanceCategory.Click += new EventHandler(this.menuItemGroupAnalysisByAttendanceCategory_Click);
      this.menuItemLessonAbsencesReport.Text = "Lesson &Absences Report";
      this.menuItemLessonAbsencesReport.Click += new EventHandler(this.menuItemLessonAbsencesReport_Click);
      this.menuItemContinuousAbsenceReport.Text = "Con&tinuous Absence Report";
      this.menuItemContinuousAbsenceReport.Click += new EventHandler(this.menuItemContinuousAbsenceReport_Click);
      this.menuItemSessionAbsencesReport.Text = "&Session Absences Report";
      this.menuItemSessionAbsencesReport.Click += new EventHandler(this.menuItemSessionAbsencesReport_Click);
      this.menuItemFirstDayofAbsenceReport.Text = "&First Day of Absence Report";
      this.menuItemFirstDayofAbsenceReport.Click += new EventHandler(this.menuItemFirstDayofAbsenceReport_Click);
      this.menuItemLessonAttendancebySubjects.Text = "&Lesson Attendance by Subjects";
      this.menuItemLessonAttendancebySubjects.Click += new EventHandler(this.menuItemLessonAttendancebySubjects_Click);
      this.menuItemMinutesLateReport.Text = "Minut&es Late Report";
      this.menuItemMinutesLateReport.Click += new EventHandler(this.menuItemMinutesLateReport_Click);
      this.menuItemLessonAttendancebyClassesReport.Text = "Lesson &Attendance by Classes";
      this.menuItemLessonAttendancebyClassesReport.Click += new EventHandler(this.menuItemLessonAttendancebyClassesReport_Click);
      this.menuItemCommentsReport.Text = "&Comments Report";
      this.menuItemCommentsReport.Click += new EventHandler(this.menuItemCommentsReport_Click);
      this.menuItemPercentageAttendanceReport.Text = "&Percentage Attendance Report";
      this.menuItemPercentageAttendanceReport.Click += new EventHandler(this.menuItemPercentageAttendanceReport_Click);
      this.menuItemPostRegAbsenceReport.Text = "&Post Registration Absence Report";
      this.menuItemPostRegAbsenceReport.Click += new EventHandler(this.menuItemPostRegAbsenceReport_Click);
      this.menuItemHistoryOfChangesReport.Text = "&History of Changes Report";
      this.menuItemHistoryOfChangesReport.Click += new EventHandler(this.menuItemHistoryOfChangesReport_Click);
      this.menuItemStudentWeeklyLessonAttendanceReport.Text = SystemConfigurationCache.IsPrimarySchool || SystemConfigurationCache.IsIndependentSchool ? "Pupil &Weekly Lesson Attendance Report" : "Student &Weekly Lesson Attendance Report";
      this.menuItemStudentWeeklyLessonAttendanceReport.Click += new EventHandler(this.menuItemStudentWeeklyLessonAttendanceReport_Click);
      this.menuItemPeriodsWithChosenCodeReport.Text = "Perio&ds With Chosen Code Report";
      this.menuItemPeriodsWithChosenCodeReport.Click += new EventHandler(this.menuItemPeriodsWithChosenCodeReport_Click);
      this.menuItemRegistersWithMissingMarksReport.Text = "&Registers with Missing Marks Report";
      this.menuItemRegistersWithMissingMarksReport.Click += new EventHandler(this.menuItemRegistersWithMissingMarksReport_Click);
      this.menuItemCompareMarksbyColumnReport.Text = "C&ompare Marks by Column Report";
      this.menuItemCompareMarksbyColumnReport.Click += new EventHandler(this.menuItemCompareMarksbyColumnReport_Click);
      this.menuItemTodaysRegisterReport.ImageIndex = -1;
      this.menuItemTodaysRegisterReport.ImageList = (ImageList) null;
      this.menuItemTodaysRegisterReport.Index = 2;
      this.menuItemTodaysRegisterReport.NoEdit = false;
      this.menuItemTodaysRegisterReport.NoUIModify = false;
      this.menuItemTodaysRegisterReport.OriginalText = "";
      this.menuItemTodaysRegisterReport.OwnerDraw = true;
      this.menuItemTodaysRegisterReport.Text = "&Today's Register Report";
      this.menuItemTodaysRegisterReport.Click += new EventHandler(this.menuItemTodaysRegisterReport_Click);
      this.menuItemGroupWeeklyLessonAttendanceReport.Text = "Group Weekly &Lesson Attendance Report";
      this.menuItemGroupWeeklyLessonAttendanceReport.Click += new EventHandler(this.menuItemGroupWeeklyLessonAttendanceReport_Click);
      this.menuItemNewAbsenteesReport.Text = "&New Absentees Report";
      this.menuItemNewAbsenteesReport.Click += new EventHandler(this.menuItemNewAbsenteesReport_Click);
      this.menuItemJointAbsenceDetection.Text = "&Joint Absence Detection Report";
      this.menuItemJointAbsenceDetection.Click += new EventHandler(this.menuItemJointAbsenceDetection_Click);
      this.menuItemSiblingAbsenceDetection.Text = "Siblin&g Absence Detection Report";
      this.menuItemSiblingAbsenceDetection.Click += new EventHandler(this.menuItemSiblingAbsenceDetection_Click);
      this.menuItemRegisterCertificateReport.Text = "&Registration Certificate Report";
      this.menuItemRegisterCertificateReport.Click += new EventHandler(this.menuItemRegisterCertificateReport_Click);
      this.menuItemIndividualSummaryReport.Text = "I&ndividual Session Summary Report";
      this.menuItemIndividualSummaryReport.Click += new EventHandler(this.menuItemIndividualSummaryReport_Click);
      this.menuItemUnexplainedAbsencesReport.Text = "&Unexplained Absences Report";
      this.menuItemUnexplainedAbsencesReport.Click += new EventHandler(this.menuItemUnexplainedAbsencesReport_Click);
      this.menuItemPupilsSchoolCareerAttendance.ImageIndex = -1;
      this.menuItemPupilsSchoolCareerAttendance.ImageList = (ImageList) null;
      this.menuItemPupilsSchoolCareerAttendance.NoEdit = false;
      this.menuItemPupilsSchoolCareerAttendance.NoUIModify = false;
      this.menuItemPupilsSchoolCareerAttendance.OriginalText = "";
      this.menuItemPupilsSchoolCareerAttendance.OwnerDraw = true;
      this.menuItemPupilsSchoolCareerAttendance.Text = SystemConfigurationCache.IsPrimarySchool || SystemConfigurationCache.IsIndependentSchool ? "P&upil's School Career Attendance Report" : "St&udent's School Career Attendance Report";
      this.menuItemPupilsSchoolCareerAttendance.Click += new EventHandler(this.menuItemPupilsSchoolCareerAttendance_Click);
      this.menuItemSessionMissingMarks.ImageIndex = -1;
      this.menuItemSessionMissingMarks.ImageList = (ImageList) null;
      this.menuItemSessionMissingMarks.Index = 2;
      this.menuItemSessionMissingMarks.NoEdit = false;
      this.menuItemSessionMissingMarks.NoUIModify = false;
      this.menuItemSessionMissingMarks.OriginalText = "";
      this.menuItemSessionMissingMarks.OwnerDraw = true;
      this.menuItemSessionMissingMarks.Text = "&Missing Session Marks Report";
      this.menuItemSessionMissingMarks.Click += new EventHandler(this.menuItemSessionMissingMarks_Click);
      this.menuItemSchoolProspectusAnalysis.Text = "&School Prospectus Analysis Report";
      this.menuItemSchoolProspectusAnalysis.Click += new EventHandler(this.menuItemSchoolProspectusAnalysis_Click);
      this.menuItemOfficialRegisterReport.Text = "&Official Register Report";
      this.menuItemOfficialRegisterReport.Click += new EventHandler(this.menuItemOfficialRegisterReport_Click);
      this.menuItemWelshSchoolPerformanceInformation.ImageIndex = -1;
      this.menuItemWelshSchoolPerformanceInformation.ImageList = (ImageList) null;
      this.menuItemWelshSchoolPerformanceInformation.NoEdit = false;
      this.menuItemWelshSchoolPerformanceInformation.NoUIModify = false;
      this.menuItemWelshSchoolPerformanceInformation.OriginalText = "";
      this.menuItemWelshSchoolPerformanceInformation.OwnerDraw = true;
      this.menuItemWelshSchoolPerformanceInformation.Text = "&Welsh School Performance Information Report";
      this.menuItemWelshSchoolPerformanceInformation.Click += new EventHandler(this.menuItemWelshSchoolPerformanceInformation_Click);
      this.menuItemGroupSessionSummary.ImageIndex = -1;
      this.menuItemGroupSessionSummary.ImageList = (ImageList) null;
      this.menuItemGroupSessionSummary.NoEdit = false;
      this.menuItemGroupSessionSummary.NoUIModify = false;
      this.menuItemGroupSessionSummary.OriginalText = "";
      this.menuItemGroupSessionSummary.OwnerDraw = true;
      this.menuItemGroupSessionSummary.Text = "Gro&up Session Summary Report";
      this.menuItemGroupSessionSummary.Click += new EventHandler(this.menuItemGroupSessionSummary_Click);
      this.menuItemPupilAnalysisByAMPM.ImageIndex = -1;
      this.menuItemPupilAnalysisByAMPM.ImageList = (ImageList) null;
      this.menuItemPupilAnalysisByAMPM.NoEdit = false;
      this.menuItemPupilAnalysisByAMPM.NoUIModify = false;
      this.menuItemPupilAnalysisByAMPM.OriginalText = "";
      this.menuItemPupilAnalysisByAMPM.OwnerDraw = true;
      this.menuItemPupilAnalysisByAMPM.Text = SystemConfigurationCache.IsPrimarySchool || SystemConfigurationCache.IsIndependentSchool ? "Pupil Analysis by AM/P&M Report" : "Student Analysis by AM/P&M Report";
      this.menuItemPupilAnalysisByAMPM.Click += new EventHandler(this.menuItemPupilAnalysisByAMPM_Click);
      this.menuItemPupilAnalysisByAttendanceCode.ImageIndex = -1;
      this.menuItemPupilAnalysisByAttendanceCode.ImageList = (ImageList) null;
      this.menuItemPupilAnalysisByAttendanceCode.NoEdit = false;
      this.menuItemPupilAnalysisByAttendanceCode.NoUIModify = false;
      this.menuItemPupilAnalysisByAttendanceCode.OriginalText = "";
      this.menuItemPupilAnalysisByAttendanceCode.OwnerDraw = true;
      this.menuItemPupilAnalysisByAttendanceCode.Text = SystemConfigurationCache.IsPrimarySchool || SystemConfigurationCache.IsIndependentSchool ? "Pupil Analysis &By Attendance Code Report" : "Student Analysis &By Attendance Code Report";
      this.menuItemPupilAnalysisByAttendanceCode.Click += new EventHandler(this.menuItemPupilAnalysisByAttendanceCode_Click);
      this.menuItemPupilAnalysisBySessionInWeek.ImageIndex = -1;
      this.menuItemPupilAnalysisBySessionInWeek.ImageList = (ImageList) null;
      this.menuItemPupilAnalysisBySessionInWeek.NoEdit = false;
      this.menuItemPupilAnalysisBySessionInWeek.NoUIModify = false;
      this.menuItemPupilAnalysisBySessionInWeek.OriginalText = "";
      this.menuItemPupilAnalysisBySessionInWeek.OwnerDraw = true;
      this.menuItemPupilAnalysisBySessionInWeek.Text = SystemConfigurationCache.IsPrimarySchool || SystemConfigurationCache.IsIndependentSchool ? "Pupil Analysis By Session &In Week Report" : "Student Analysis By Session &In Week Report";
      this.menuItemPupilAnalysisBySessionInWeek.Click += new EventHandler(this.menuItemPupilAnalysisBySessionInWeek_Click);
      this.menuItemPupilsYearlyAttendance.ImageIndex = -1;
      this.menuItemPupilsYearlyAttendance.ImageList = (ImageList) null;
      this.menuItemPupilsYearlyAttendance.NoEdit = false;
      this.menuItemPupilsYearlyAttendance.NoUIModify = false;
      this.menuItemPupilsYearlyAttendance.OriginalText = "";
      this.menuItemPupilsYearlyAttendance.OwnerDraw = true;
      this.menuItemPupilsYearlyAttendance.Text = SystemConfigurationCache.IsPrimarySchool || SystemConfigurationCache.IsIndependentSchool ? "Pupil &Yearly Attendance Report" : "Student &Yearly Attendance Report";
      this.menuItemPupilsYearlyAttendance.Click += new EventHandler(this.menuItemPupilsYearlyAttendance_Click);
      this.menuItemBrokenWeekReport.Text = "&Broken Weeks Report";
      this.menuItemBrokenWeekReport.Click += new EventHandler(this.menuItemBrokenWeekReport_Click);
      this.menuItemGroupAnalysisbyCodeReport.Text = "Group Analysis by &Code Report";
      this.menuItemGroupAnalysisbyCodeReport.Click += new EventHandler(this.menuItemGroupAnalysisbyCodeReport_Click);
      this.menuItemGroupWeeklyAnalysisReport.ImageIndex = -1;
      this.menuItemGroupWeeklyAnalysisReport.ImageList = (ImageList) null;
      this.menuItemGroupWeeklyAnalysisReport.NoEdit = false;
      this.menuItemGroupWeeklyAnalysisReport.NoUIModify = false;
      this.menuItemGroupWeeklyAnalysisReport.OriginalText = "";
      this.menuItemGroupWeeklyAnalysisReport.OwnerDraw = true;
      this.menuItemGroupWeeklyAnalysisReport.Text = "&Group Weekly Analysis Report";
      this.menuItemGroupWeeklyAnalysisReport.Click += new EventHandler(this.menuItemGroupWeeklyAnalysisReport_Click);
      this.menuItemMissedCurriculumReport.ImageIndex = -1;
      this.menuItemMissedCurriculumReport.ImageList = (ImageList) null;
      this.menuItemMissedCurriculumReport.NoEdit = false;
      this.menuItemMissedCurriculumReport.NoUIModify = false;
      this.menuItemMissedCurriculumReport.OriginalText = "";
      this.menuItemMissedCurriculumReport.OwnerDraw = true;
      this.menuItemMissedCurriculumReport.Text = "Missed Cu&rriculum Report";
      this.menuItemMissedCurriculumReport.Click += new EventHandler(this.menuItemMissedCurriculumReport_Click);
      this.menuItemGroupAnalysisbyAMPMReport.Text = "Group Analysis by &AM/PM Report";
      this.menuItemGroupAnalysisbyAMPMReport.Click += new EventHandler(this.menuItemGroupAnalysisbyAMPMReport_Click);
      this.menuItemGroupAnalysisBySessionInWeekReport.ImageIndex = -1;
      this.menuItemGroupAnalysisBySessionInWeekReport.ImageList = (ImageList) null;
      this.menuItemGroupAnalysisBySessionInWeekReport.NoEdit = false;
      this.menuItemGroupAnalysisBySessionInWeekReport.NoUIModify = false;
      this.menuItemGroupAnalysisBySessionInWeekReport.OriginalText = "";
      this.menuItemGroupAnalysisBySessionInWeekReport.OwnerDraw = true;
      this.menuItemGroupAnalysisBySessionInWeekReport.Text = "Group Analysis by Session in Wee&k Report";
      this.menuItemGroupAnalysisBySessionInWeekReport.Click += new EventHandler(this.menuItemGroupAnalysisBySessionInWeekReport_Click);
      this.menuItemPupilswithChosenCodeReport.Text = SystemConfigurationCache.IsPrimarySchool || SystemConfigurationCache.IsIndependentSchool ? "Pupils with &Chosen Code Report" : "Students with &Chosen Code Report";
      this.menuItemPupilswithChosenCodeReport.Click += new EventHandler(this.menuItemPupilswithChosenCodeReport_Click);
      this.menuItemGroupAnalysisbySTARFieldReport.Text = "Group Analysis by STAR &Field Report";
      this.menuItemGroupAnalysisbySTARFieldReport.Click += new EventHandler(this.menuItemGroupAnalysisbySTARFieldReport_Click);
      this.menuItemGroupAnalysisbyVulnerabilityReport.Text = "Group Analysis by &Vulnerability Report";
      this.menuItemGroupAnalysisbyVulnerabilityReport.Click += new EventHandler(this.menuItemGroupAnalysisbyVulnerabilityReport_Click);
      this.menuItemPrintLetters.Text = !SIMS.Entities.InTouch.Cache.IsLicensed ? "&Print Letters" : "&Print and Send Letters";
      this.menuItemPrintLetters.Click += new EventHandler(this.menuItemPrintLetters_Click);
      this.menuItemLettersCreated.Text = "Letters &Created Report";
      this.menuItemLettersCreated.Click += new EventHandler(this.menuItemLettersCreated_Click);
      this.menuItemPrintRegistrationSheet.Text = "Print &Registration Sheet";
      this.menuItemPrintRegistrationSheet.Click += new EventHandler(this.menuItemPrintRegistrationSheet_Click);
      this.menuItemPrintAbsenceSheet.Text = "Print &Absence Sheet";
      this.menuItemPrintAbsenceSheet.Click += new EventHandler(this.menuItemPrintAbsenceSheet_Click);
      this.menuItemPersistentAbsenceReport.Text = "Persiste&nt Absence Reports";
      this.menuItemPersistentAbsenceReport.Click += new EventHandler(this.menuItemPersistentAbsenceReport_Click);
      this.menuItemPersistentAbsenceStudentThreshold.Text = "Persistent Absence Report - Student T&hreshold";
      this.menuItemPersistentAbsenceStudentThreshold.Click += new EventHandler(this.menuItemPersistentAbsenceStudentThreshold_Click);
      this.menuItemMealListReport.ImageIndex = -1;
      this.menuItemMealListReport.ImageList = (ImageList) null;
      this.menuItemMealListReport.NoEdit = false;
      this.menuItemMealListReport.NoUIModify = false;
      this.menuItemMealListReport.OriginalText = "";
      this.menuItemMealListReport.OwnerDraw = true;
      this.menuItemMealListReport.Text = "Meal &List Report";
      this.menuItemMealListReport.Click += new EventHandler(this.menuItemMealListReport_Click);
    }

    private void menuItemPupilsYearlyAttendance_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PupilsYearlyAttendanceReportContainer());
    }

    private void menuItemPupilAnalysisByAMPM_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PupilAnalysisByAMPMContainer());
    }

    private void menuItemWelshSchoolPerformanceInformation_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new WelshSchoolPerformanceInformationContainer());
    }

    private void menuItemPupilAnalysisBySessionInWeek_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PupilAnalysisBySessionInWeekContainer());
    }

    private void menuItemGroupWeeklyAnalysisReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new GroupWeeklyAnalysisReportContainer());
    }

    private void menuItemGroupAnalysisBySessionInWeekReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new GroupAnalysisBySessionInWeekContainer());
    }

    private void menuItemPersistentAbsenceReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PersistentAbsenceReportContainer());
    }

    private void menuItemPersistentAbsenceStudentThreshold_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PersistentAbsenceThresholdReportContainer());
    }

    private void rebuildAttendanceMenus()
    {
      if (SystemConfigurationCache.LocaleCode == "WALES")
      {
        this.menuItemWelshSchoolPerformanceInformation.Visible = true;
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemWelshSchoolPerformanceInformation, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      }
      else if (SystemConfigurationCache.LocaleCode != "WALES")
        this.menuItemWelshSchoolPerformanceInformation.Visible = false;
      string[] processNames1 = new string[2]
      {
        "TakeRegisterLessonProcess",
        "TakeRegisterSessionProcess"
      };
      string[] processNames2 = new string[2]
      {
        "ViewLessonMonitorReports",
        "ViewAttendanceReports"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemTakeRegister, processNames1);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemAttendanceReports, processNames2);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemDisplayAttendanceMarks, StudentMarksContainer.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemLessonMonitorReportLaunch, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemCodeOverDateRange, CodeOverDateRangeBrowser.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemUnexplainedAbsences, UnexplainedAbsenceContainer.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemDisplayMissingMarks, MissingMarksContainer.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemEnterWeeklyPattern, EnterWeeklyPatternBrowser.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemIndividualRegisterReport, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemEditMarks, EditMarksContainer.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemAttendanceModuleSetup, AttendanceSetup.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemCodes, MaintainCodes.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemMaintainCodes, MaintainCodes.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemLateCodes, LateCodesSetup.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemExtraNames, ExtraNameContainer.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemLessonMonitorSetup, LessonMonitorSetup.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemEarliestMarksSetup, EarliestMarksDetail.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemConflictingLessonMarks, ConflictingLessonMarksContainer.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemConflictingSessionMarks, ConflictingSessionMarksContainer.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemIndividualAttendanceSummary, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemFullRegisterReport, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemClassRegisterReport, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemLessonAbsencesReport, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemContinuousAbsenceReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSessionAbsencesReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemFirstDayofAbsenceReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemLessonMarksbyCategory, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGroupAnalysisByAttendanceCategory, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemLessonAttendancebySubjects, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMinutesLateReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemLessonAttendancebyClassesReport, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPercentageAttendanceReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCommentsReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPostRegAbsenceReport, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemHistoryOfChangesReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemStudentWeeklyLessonAttendanceReport, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPeriodsWithChosenCodeReport, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemRegistersWithMissingMarksReport, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCompareMarksbyColumnReport, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemEditReasonForChange, ReasonForChangesDetail.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemTodaysRegisterReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGroupWeeklyLessonAttendanceReport, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNewAbsenteesReport, ATWXMLReportProcess.STRING_PROCESS_NAME);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemExceptionalCircumstances, typeof (ExceptionalCircumstanceProcess).Name);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemOMR, PrintOMRRegistrationSheetBrowser.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPrintOMRRegistrationSheet, PrintOMRRegistrationSheetBrowser.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPrintOMRRegistrationSheetWeekendSession, PrintOMRRegistrationSheetBrowser.HostedProcessName);
      this.menuItemPrintOMRRegistrationSheetWeekendSession.Visible &= SIMS.Entities.Cache.Settings["AttAdditionalSessionsExist"] == "T";
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPrintOMRAbsenceSheet, PrintOMRAbsenceSheetBrowser.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemReadOMRRegistrationSheet, PrintOMRRegistrationSheetBrowser.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemReadOMRAbsenceSheet, PrintOMRRegistrationSheetBrowser.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemATWRegistrationOrganisation, ATWSetupRegistrationOrganisationDialog.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAttendanceOMRSetup, ATWOMRSetupDialog.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemJointAbsenceDetection, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPartTimePupils, PartTimePupilsBrowser.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemRegisterCertificateReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSchoolProspectusAnalysis, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPupilsSchoolCareerAttendance, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSessionMissingMarks, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemOfficialRegisterReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemIndividualSummaryReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUnexplainedAbsencesReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPupilsYearlyAttendance, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPupilAnalysisByAMPM, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBrokenWeekReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGroupAnalysisbyCodeReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPupilAnalysisBySessionInWeek, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGroupWeeklyAnalysisReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPupilAnalysisByAttendanceCode, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGroupAnalysisbyAMPMReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMissedCurriculumReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPupilswithChosenCodeReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGroupSessionSummary, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGroupAnalysisbySTARFieldReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGroupAnalysisbyVulnerabilityReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSiblingAbsenceDetection, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGroupAnalysisBySessionInWeekReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemLetterDefinition, DefineLetters.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPrintLetters, PrintLettersWizard.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemLettersCreated, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      string[] processNames3 = new string[2]
      {
        ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS,
        typeof (ManualEntryProcess).Name
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPrintRegistrationSheet, processNames3);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPrintAbsenceSheet, processNames3);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNIClosingReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      this.menuItemNIClosingReport.Visible = SystemConfigurationCache.LocaleCode == "NI";
      this.menuItemEditQuickLetter.Visible = !SIMS.Entities.Cache.Settings.ContainsKey("ViewAddExternalShortcut") || !(SIMS.Entities.Cache.Settings["ViewAddExternalShortcut"] == "T");
      switch (SystemConfigurationCache.ExtendedRegionCode.ToUpper())
      {
        case "IND":
          this.menuItemSetSchoolWorkingDays.Visible = true;
          break;
        default:
          this.menuItemSetSchoolWorkingDays.Visible = false;
          break;
      }
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPersistentAbsenceReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      if (SystemConfigurationCache.LocaleCode == "ENG")
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPersistentAbsenceStudentThreshold, "PersistentAbsenceThresholdReportProcess");
      else
        this.menuItemPersistentAbsenceStudentThreshold.Visible = false;
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMealListReport, ATWAbstractXMLReport.STRING_ATTENDANCE_REPORT_PROCESS);
      if (SIMS.Entities.Cache.ProcessAvailable("TakeRegisterLessonProcess"))
      {
        this.menuItemAttendance.OriginalText = "Lesso&n Monitor";
        this.menuItemAttendance.Text = "Lesso&n Monitor";
        this.menuItemAttendanceRoutines.OriginalText = "Lesso&n Monitor";
        this.menuItemAttendanceRoutines.Text = "Lesso&n Monitor";
      }
      if (!SIMS.Entities.Cache.ProcessAvailable("ViewLessonMonitorReports"))
        return;
      this.menuItemAttendanceReports.OriginalText = "Lesso&n Monitor";
      this.menuItemAttendanceReports.Text = "Lesso&n Monitor";
    }

    private void menuItemTakeRegister_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new TakeRegisterContainer());
    }

    private void menuItemDisplayAttendanceMarks_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new StudentMarksContainer());
    }

    private void menuItemLessonMonitorReportLaunch_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainLateMinutesReport());
    }

    private void menuItemUnexplainedAbsences_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new UnexplainedAbsenceContainer());
    }

    private void menuItemDisplayMissingMarks_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MissingMarksContainer());
    }

    private void menuItemCodeOverDateRange_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CodeOverDateRangeContainer());
    }

    private void menuItemEnterWeeklyPattern_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EnterWeeklyPatternContainer());
    }

    private void menuItemEditMarks_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EditMarksContainer());
    }

    private void menuItemConflictingLessonMarks_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ConflictingLessonMarksContainer());
    }

    private void menuItemEditReasonForChange_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ReasonForChangesContainer());
    }

    private void menuItemLessonMonitorSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new LessonMonitorSetup());
    }

    private void menuItemAttendanceModuleSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new AttendanceSetup());
    }

    private void menuItemAttendanceOMRSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new ATWOMRSetupDialog().ShowDialog();
    }

    private void menuItemATWRegistrationOrganisation_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new ATWSetupRegistrationOrganisationDialog().ShowDialog();
    }

    private void menuItemMaintainCodes_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCodes());
    }

    private void menuItemLateCodes_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new LateCodesSetup());
    }

    private void menuItemPartTimePupils_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PartTimePupilsContainer());
    }

    private void menuItemLetterDefinition_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new DefineLetters().ShowDialog();
    }

    private void menuItemEditQuickLetter_Click(object sender, EventArgs e)
    {
      Cursor cursor = this.Cursor;
      this.recordMenuUsage(sender as UIMenuItem);
      string str = SIMS.Processes.PerformanceCache.ReadSIMSINI("Setup", "QuickLetterPath");
      OpenFileDialog openFileDialog = new OpenFileDialog();
      if (str.Length > 0)
        openFileDialog.InitialDirectory = str;
      else
        openFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
      openFileDialog.AddExtension = false;
      openFileDialog.Filter = "Word Documents|*.doc|Word 2007 Documents (*.docx)|*.docx";
      openFileDialog.RestoreDirectory = true;
      openFileDialog.Multiselect = false;
      openFileDialog.CheckFileExists = true;
      openFileDialog.CheckPathExists = true;
      openFileDialog.Title = "Select the Quick Letter Template file to be edited";
      DialogResult dialogResult = DialogResult.OK;
      try
      {
        dialogResult = openFileDialog.ShowDialog((IWin32Window) this);
      }
      catch (IOException ex)
      {
        SIMS.Entities.Cache.StatusMessage("The selected word document is not valid.", UserMessageEventEnum.Error);
      }
      if (dialogResult != DialogResult.OK)
        return;
      SIMS.Processes.ExternalApplication.SetupWord();
      if (!SIMS.Processes.ExternalApplication.IsWordAvailable)
        return;
      this.Cursor = Cursors.WaitCursor;
      bool flag = SIMS.Processes.ExternalApplication.Launch(openFileDialog.FileName.ToString(), OfficeDocumentTypeEnum.Word);
      this.Cursor = cursor;
      if (flag)
        return;
      SIMS.Entities.Cache.StatusMessage(PerformanceUtilities.GetMessage(MessagesEnum.OFFICE_LAUNCH_FAILED), UserMessageEventEnum.Information);
    }

    private void menuItemPrintLetters_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (PrintLettersWizard printLettersWizard = new PrintLettersWizard())
      {
        if (DialogResult.OK != printLettersWizard.ShowDialog() || !SIMS.Entities.InTouch.Cache.IsLicensed)
          return;
        SIMS.Entities.Cache.HostNewControl((IIDEntity) null, (object) new SIMS.UserInterfaces.InTouch.SendStudentAttendanceLettertMessageHost(printLettersWizard.DataForInTouchHost.StudentAttendanceReport, printLettersWizard.DataForInTouchHost.LetterType, printLettersWizard.DataForInTouchHost.SelectStudents, printLettersWizard.DataForInTouchHost.SelectContacts, printLettersWizard.DataForInTouchHost.SelectHeadsOfHouse, printLettersWizard.DataForInTouchHost.SelectHeadsOfYear, printLettersWizard.DataForInTouchHost.SelectRegTutors, printLettersWizard.DataForInTouchHost.Extension));
      }
    }

    private void menuItemLettersCreated_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new LettersReportContainer());
    }

    private void menuItemEarliestMarksSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EarliestMarksContainer());
    }

    private void menuItemIndividualRegisterReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new IndividualStudentReportContainer());
    }

    private void menuItemIndividualAttendanceSummary_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new IndividualAttendanceSummaryContainer());
    }

    private void menuItemExtraNames_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ExtraNameContainer());
    }

    private void menuItemExceptionalCircumstances_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new EditExceptionalCircumstanceContainer());
    }

    private void menuItemFullRegisterReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FullRegisterReportContainer());
    }

    private void menuItemClassRegisterReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ClassRegisterReportContainer());
    }

    private void menuItemLessonMarksbyCategory_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new LessonMarksbyCategoryReportContainer());
    }

    private void menuItemGroupAnalysisByAttendanceCategory_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new GroupLessonMarksByCategoryReportContainer());
    }

    private void menuItemLessonAttendancebySubjects_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new LessonAttendancebySubjectsContainer());
    }

    private void menuItemLessonAbsencesReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new LessonAbsencesReportContainer());
    }

    private void menuItemContinuousAbsenceReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ContinuousAbsenceContainer());
    }

    private void menuItemSessionAbsencesReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SessionAbsencesContainer());
    }

    private void menuItemFirstDayofAbsenceReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FirstDayofAbsenceContainer());
    }

    private void menuItemMinutesLateReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MinutesLateReportContainer());
    }

    private void menuItemLessonAttendancebyClassesReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new LessonAttendancebyClassesContainer());
    }

    private void menuItemPercentageAttendanceReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PercentageAttendanceReportContainer());
    }

    private void menuItemCommentsReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CommentsReportContainer());
    }

    private void menuItemPostRegAbsenceReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PostRegistrationAbsenceReportContainer());
    }

    private void menuItemHistoryOfChangesReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new HistoryOfChangesContainer());
    }

    private void menuItemStudentWeeklyLessonAttendanceReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new WeeklyLessonAttendanceReportContainer());
    }

    private void menuItemPeriodsWithChosenCodeReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PeriodswithChosenCodeReportContainer());
    }

    private void menuItemRegistersWithMissingMarksReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new RegistersWithMissingMarksReportContainer());
    }

    private void menuItemCompareMarksbyColumnReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CompareMarksbyColumnReportContainer());
    }

    private void menuItemTodaysRegisterReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      TodaysRegisterBrowser todaysRegisterBrowser = new TodaysRegisterBrowser();
      this.DisplayComponent((Control) todaysRegisterBrowser);
      todaysRegisterBrowser.Close((AbstractContainerControl) todaysRegisterBrowser);
    }

    private void menuItemNewAbsenteesReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new NewAbsenteesReportContainer());
    }

    private void menuItemGroupWeeklyLessonAttendanceReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new GroupWeeklyLessonAttendanceReportContainer());
    }

    private void menuItemPrintOMRRegistrationSheet_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PrintOMRRegistrationSheetContainer());
    }

    private void menuItemPrintOMRRegistrationSheetWeekendSession_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PrintOMRRegistrationSheetContainerWeekendSessions(OMRRegistrationSessionTypeEnum.Additional));
    }

    private void menuItemPrintOMRAbsenceSheet_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PrintOMRAbsenceSheetContainer());
    }

    private void menuItemReadOMRRegistrationSheet_Click(object sender, EventArgs e)
    {
      int int32 = this.Handle.ToInt32();
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new ReadOMRDialog(int32).ShowDialog();
    }

    private void menuItemReadOMRAbsenceSheet_Click(object sender, EventArgs e)
    {
      int int32 = this.Handle.ToInt32();
      this.recordMenuUsage(sender as UIMenuItem);
      ReadOMRDialog readOmrDialog = new ReadOMRDialog(int32);
      readOmrDialog.Visible = false;
      readOmrDialog.Width = 0;
      readOmrDialog.Height = 0;
      readOmrDialog.ReadAbsenceSheets();
      if (readOmrDialog == null)
        return;
      readOmrDialog.Close();
      readOmrDialog.Dispose();
    }

    private void menuItemConflictingSessionMarks_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ConflictingSessionMarksContainer());
    }

    private void menuItemJointAbsenceDetection_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new JointAbsDetectionWizardStart().ShowDialog();
    }

    private void menuItemSiblingAbsenceDetection_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new SiblingAbsDetectionWizardStart().ShowDialog();
    }

    private void menuItemRegisterCertificateReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new RegistrationCertificateContainer());
    }

    private void menuItemIndividualSummaryReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new IndividualSummaryContainer());
    }

    private void menuItemOfficialRegisterReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new OfficialRegisterContainer());
    }

    private void menuItemPupilsSchoolCareerAttendance_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PupilsSchoolCareerAttendanceReportContainer());
    }

    private void menuItemSessionMissingMarks_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SessionMissingMarksContainer());
    }

    private void menuItemSchoolProspectusAnalysis_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SchoolProspectusAnalysisReportContainer());
    }

    private void menuItemUnexplainedAbsencesReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new UnexplainedAbsencesContainer());
    }

    private void menuItemBrokenWeekReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new BrokenWeekContainer());
    }

    private void menuItemGroupAnalysisbyCodeReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new GroupAnalysisbyCodeContainer());
    }

    private void menuItemGroupAnalysisbyAMPMReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new GroupAnalysisbyAMPMContainer());
    }

    private void menuItemMissedCurriculumReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MissedCurriculumContainer());
    }

    private void menuItemPupilAnalysisByAttendanceCode_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PupilAnalysisByAttendanceCodeContainer());
    }

    private void menuItemGroupSessionSummary_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new GroupSessionSummaryContainer());
    }

    private void menuItemPupilswithChosenCodeReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PupilsWithChosenCodeContainer());
    }

    private void menuItemGroupAnalysisbySTARFieldReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new GroupAnalysisbySTARFieldContainer());
    }

    private void menuItemGroupAnalysisbyVulnerabilityReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new GroupAnalysisByVulnerabilityContainer());
    }

    private void menuItemPrintAbsenceSheet_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ManualAbsenceSheetContainer());
    }

    private void menuItemPrintRegistrationSheet_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ManualEntryRegisterContainer());
    }

    private void menuItemMealListReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MealListContainer());
    }

    private void initPersonnelMenus()
    {
      this.menuItemAbsenceAnalysis = new UIMenuItem();
      this.menuItemIndividualAbsence = new UIMenuItem();
      this.menuItemLongTermAbsenceAnalysis = new UIMenuItem();
      this.menuItemContractAnalysis = new UIMenuItem();
      this.menuItemContractInformation = new UIMenuItem();
      this.menuItemSalaryInformation = new UIMenuItem();
      this.menuItemStaffTraining = new UIMenuItem();
      this.menuItemTrainingCourse = new UIMenuItem();
      this.menuItemTerminatingContracts = new UIMenuItem();
      this.menuItemDeleteStaff = new UIMenuItem();
      this.menuItemTraining = new UIMenuItem();
      this.menuItemPayRelated = new UIMenuItem();
      this.menuItemAnnualIncrement = new UIMenuItem();
      this.menuItemSalaryRangeUpdate = new UIMenuItem();
      this.menuItemSuperannuation = new UIMenuItem();
      this.menuItemNationalInsuranceRates = new UIMenuItem();
      this.menuItemPayRelatedImport = new UIMenuItem();
      this.menuItemPayRelatedExport = new UIMenuItem();
      this.menuItemPerformanceManagement = new UIMenuItem();
      this.menuItemSPSchoolSetup = new UIMenuItem();
      this.menuItemLineManagementStructure = new UIMenuItem();
      this.menuItemAbsenceAnalysis.ImageIndex = -1;
      this.menuItemAbsenceAnalysis.ImageList = (ImageList) null;
      this.menuItemAbsenceAnalysis.Index = 0;
      this.menuItemAbsenceAnalysis.NoEdit = false;
      this.menuItemAbsenceAnalysis.NoUIModify = false;
      this.menuItemAbsenceAnalysis.OriginalText = "";
      this.menuItemAbsenceAnalysis.OwnerDraw = true;
      this.menuItemAbsenceAnalysis.Text = "&Absence Analysis";
      this.menuItemAbsenceAnalysis.Click += new EventHandler(this.menuItemAbsenceAnalysis_Click);
      this.menuItemIndividualAbsence.ImageIndex = -1;
      this.menuItemIndividualAbsence.ImageList = (ImageList) null;
      this.menuItemIndividualAbsence.Index = 1;
      this.menuItemIndividualAbsence.NoEdit = false;
      this.menuItemIndividualAbsence.NoUIModify = false;
      this.menuItemIndividualAbsence.OriginalText = "";
      this.menuItemIndividualAbsence.OwnerDraw = true;
      this.menuItemIndividualAbsence.Text = "&Individual Absence";
      this.menuItemIndividualAbsence.Click += new EventHandler(this.menuItemIndividualAbsence_Click);
      this.menuItemLongTermAbsenceAnalysis.ImageIndex = -1;
      this.menuItemLongTermAbsenceAnalysis.ImageList = (ImageList) null;
      this.menuItemLongTermAbsenceAnalysis.Index = 2;
      this.menuItemLongTermAbsenceAnalysis.NoEdit = false;
      this.menuItemLongTermAbsenceAnalysis.NoUIModify = false;
      this.menuItemLongTermAbsenceAnalysis.OriginalText = "";
      this.menuItemLongTermAbsenceAnalysis.OwnerDraw = true;
      this.menuItemLongTermAbsenceAnalysis.Text = "&Long Term Absence Analysis";
      this.menuItemLongTermAbsenceAnalysis.Click += new EventHandler(this.menuItemLongTermAbsenceAnalysis_Click);
      this.menuItemContractAnalysis.ImageIndex = -1;
      this.menuItemContractAnalysis.ImageList = (ImageList) null;
      this.menuItemContractAnalysis.Index = 3;
      this.menuItemContractAnalysis.NoEdit = false;
      this.menuItemContractAnalysis.NoUIModify = false;
      this.menuItemContractAnalysis.OriginalText = "";
      this.menuItemContractAnalysis.OwnerDraw = true;
      this.menuItemContractAnalysis.Text = "&Contract Analysis";
      this.menuItemContractAnalysis.Click += new EventHandler(this.menuItemContractAnalysis_Click);
      this.menuItemContractInformation.ImageIndex = -1;
      this.menuItemContractInformation.ImageList = (ImageList) null;
      this.menuItemContractInformation.Index = 4;
      this.menuItemContractInformation.NoEdit = false;
      this.menuItemContractInformation.NoUIModify = false;
      this.menuItemContractInformation.OriginalText = "";
      this.menuItemContractInformation.OwnerDraw = true;
      this.menuItemContractInformation.Text = "C&ontract Information";
      this.menuItemContractInformation.Click += new EventHandler(this.menuItemContractInformation_Click);
      this.menuItemSalaryInformation.ImageIndex = -1;
      this.menuItemSalaryInformation.ImageList = (ImageList) null;
      this.menuItemSalaryInformation.Index = 5;
      this.menuItemSalaryInformation.NoEdit = false;
      this.menuItemSalaryInformation.NoUIModify = false;
      this.menuItemSalaryInformation.OriginalText = "";
      this.menuItemSalaryInformation.OwnerDraw = true;
      this.menuItemSalaryInformation.Text = "&Salary Information";
      this.menuItemSalaryInformation.Click += new EventHandler(this.menuItemSalaryInformation_Click);
      this.menuItemStaffTraining.ImageIndex = -1;
      this.menuItemStaffTraining.ImageList = (ImageList) null;
      this.menuItemStaffTraining.Index = 6;
      this.menuItemStaffTraining.NoEdit = false;
      this.menuItemStaffTraining.NoUIModify = false;
      this.menuItemStaffTraining.OriginalText = "";
      this.menuItemStaffTraining.OwnerDraw = true;
      this.menuItemStaffTraining.Text = "Sta&ff Training";
      this.menuItemStaffTraining.Click += new EventHandler(this.menuItemStaffTraining_Click);
      this.menuItemStaffPerformanceReport.ImageIndex = -1;
      this.menuItemStaffPerformanceReport.ImageList = (ImageList) null;
      this.menuItemStaffPerformanceReport.Index = 7;
      this.menuItemStaffPerformanceReport.NoEdit = false;
      this.menuItemStaffPerformanceReport.NoUIModify = false;
      this.menuItemStaffPerformanceReport.OriginalText = "";
      this.menuItemStaffPerformanceReport.OwnerDraw = true;
      this.menuItemStaffPerformanceReport.Text = "Staff &Performance";
      this.menuItemStaffLineManagementReport.ImageIndex = -1;
      this.menuItemStaffLineManagementReport.ImageList = (ImageList) null;
      this.menuItemStaffLineManagementReport.Index = 1;
      this.menuItemStaffLineManagementReport.NoEdit = false;
      this.menuItemStaffLineManagementReport.NoUIModify = false;
      this.menuItemStaffLineManagementReport.OriginalText = "";
      this.menuItemStaffLineManagementReport.OwnerDraw = true;
      this.menuItemStaffLineManagementReport.Text = "Line &Management";
      this.menuItemStaffLineManagementReport.Click += new EventHandler(this.menuItemLineManagementReport_Click);
      this.menuItemStaffObservationsReport.ImageIndex = -1;
      this.menuItemStaffObservationsReport.ImageList = (ImageList) null;
      this.menuItemStaffObservationsReport.Index = 2;
      this.menuItemStaffObservationsReport.NoEdit = false;
      this.menuItemStaffObservationsReport.NoUIModify = false;
      this.menuItemStaffObservationsReport.OriginalText = "";
      this.menuItemStaffObservationsReport.OwnerDraw = true;
      this.menuItemStaffObservationsReport.Text = "Staff &Observations";
      this.menuItemStaffObservationsReport.Click += new EventHandler(this.menuItemStaffObservationsReport_Click);
      this.menuItemStaffAnalysisByGradeReport.ImageIndex = -1;
      this.menuItemStaffAnalysisByGradeReport.ImageList = (ImageList) null;
      this.menuItemStaffAnalysisByGradeReport.Index = 3;
      this.menuItemStaffAnalysisByGradeReport.NoEdit = false;
      this.menuItemStaffAnalysisByGradeReport.NoUIModify = false;
      this.menuItemStaffAnalysisByGradeReport.OriginalText = "";
      this.menuItemStaffAnalysisByGradeReport.OwnerDraw = true;
      this.menuItemStaffAnalysisByGradeReport.Text = "Staff Analysis by Overall &Grade";
      this.menuItemStaffAnalysisByGradeReport.Click += new EventHandler(this.menuItemStaffAnalysisByGradeReport_Click);
      this.menuItemStaffAnalysisByProfessionalStandardReport.ImageIndex = -1;
      this.menuItemStaffAnalysisByProfessionalStandardReport.ImageList = (ImageList) null;
      this.menuItemStaffAnalysisByProfessionalStandardReport.Index = 4;
      this.menuItemStaffAnalysisByProfessionalStandardReport.NoEdit = false;
      this.menuItemStaffAnalysisByProfessionalStandardReport.NoUIModify = false;
      this.menuItemStaffAnalysisByProfessionalStandardReport.OriginalText = "";
      this.menuItemStaffAnalysisByProfessionalStandardReport.OwnerDraw = true;
      this.menuItemStaffAnalysisByProfessionalStandardReport.Text = "Staff Analysis by Professional &Standards";
      this.menuItemStaffAnalysisByProfessionalStandardReport.Click += new EventHandler(this.menuItemStaffAnalysisByProfessionalStandardReport_Click);
      this.menuItemAuditLogReport.ImageIndex = -1;
      this.menuItemAuditLogReport.ImageList = (ImageList) null;
      this.menuItemAuditLogReport.Index = 8;
      this.menuItemAuditLogReport.NoEdit = false;
      this.menuItemAuditLogReport.NoUIModify = false;
      this.menuItemAuditLogReport.OriginalText = "";
      this.menuItemAuditLogReport.OwnerDraw = true;
      this.menuItemAuditLogReport.Text = "SP &Audit Log";
      this.menuItemAuditLogStaffPerformanceReport.ImageIndex = -1;
      this.menuItemAuditLogStaffPerformanceReport.ImageList = (ImageList) null;
      this.menuItemAuditLogStaffPerformanceReport.Index = 1;
      this.menuItemAuditLogStaffPerformanceReport.NoEdit = false;
      this.menuItemAuditLogStaffPerformanceReport.NoUIModify = false;
      this.menuItemAuditLogStaffPerformanceReport.OriginalText = "";
      this.menuItemAuditLogStaffPerformanceReport.OwnerDraw = true;
      this.menuItemAuditLogStaffPerformanceReport.Text = "&Appraisal Data";
      this.menuItemAuditLogStaffPerformanceReport.Click += new EventHandler(this.menuItemAuditLogStaffPerformanceReport_Click);
      this.menuItemAuditLogLineManagementReport.ImageIndex = -1;
      this.menuItemAuditLogLineManagementReport.ImageList = (ImageList) null;
      this.menuItemAuditLogLineManagementReport.Index = 2;
      this.menuItemAuditLogLineManagementReport.NoEdit = false;
      this.menuItemAuditLogLineManagementReport.NoUIModify = false;
      this.menuItemAuditLogLineManagementReport.OriginalText = "";
      this.menuItemAuditLogLineManagementReport.OwnerDraw = true;
      this.menuItemAuditLogLineManagementReport.Text = "&Line Management Structure";
      this.menuItemAuditLogLineManagementReport.Click += new EventHandler(this.menuItemAuditLogLineManagementReport_Click);
      this.menuItemTrainingCourse.ImageIndex = -1;
      this.menuItemTrainingCourse.ImageList = (ImageList) null;
      this.menuItemTrainingCourse.Index = 8;
      this.menuItemTrainingCourse.NoEdit = false;
      this.menuItemTrainingCourse.NoUIModify = false;
      this.menuItemTrainingCourse.OriginalText = "";
      this.menuItemTrainingCourse.OwnerDraw = true;
      this.menuItemTrainingCourse.Text = "&Training Course";
      this.menuItemTrainingCourse.Click += new EventHandler(this.menuItemTrainingCourse_Click);
      this.menuItemTerminatingContracts.ImageIndex = -1;
      this.menuItemTerminatingContracts.ImageList = (ImageList) null;
      this.menuItemTerminatingContracts.Index = 8;
      this.menuItemTerminatingContracts.NoEdit = false;
      this.menuItemTerminatingContracts.NoUIModify = false;
      this.menuItemTerminatingContracts.OriginalText = "";
      this.menuItemTerminatingContracts.OwnerDraw = true;
      this.menuItemTerminatingContracts.Text = "T&erminating Contracts";
      this.menuItemTerminatingContracts.Click += new EventHandler(this.menuItemTerminatingContracts_Click);
      this.menuItemDeleteStaff.ImageIndex = -1;
      this.menuItemDeleteStaff.ImageList = (ImageList) null;
      this.menuItemDeleteStaff.Index = 0;
      this.menuItemDeleteStaff.NoEdit = false;
      this.menuItemDeleteStaff.NoUIModify = false;
      this.menuItemDeleteStaff.OriginalText = "";
      this.menuItemDeleteStaff.OwnerDraw = true;
      this.menuItemDeleteStaff.Text = "&Delete Staff";
      this.menuItemDeleteStaff.Click += new EventHandler(this.menuItemDeleteStaff_Click);
      this.menuItemTraining.ImageIndex = -1;
      this.menuItemTraining.ImageList = (ImageList) null;
      this.menuItemTraining.Index = 0;
      this.menuItemTraining.NoEdit = false;
      this.menuItemTraining.NoUIModify = false;
      this.menuItemTraining.OriginalText = "";
      this.menuItemTraining.OwnerDraw = true;
      this.menuItemTraining.Text = "&Training";
      this.menuItemTraining.Click += new EventHandler(this.menuItemTraining_Click);
      this.menuItemPayRelated.ImageIndex = -1;
      this.menuItemPayRelated.ImageList = (ImageList) null;
      this.menuItemPayRelated.Index = 1;
      this.menuItemPayRelated.NoEdit = false;
      this.menuItemPayRelated.NoUIModify = false;
      this.menuItemPayRelated.OriginalText = "";
      this.menuItemPayRelated.OwnerDraw = true;
      this.menuItemPayRelated.Text = "&Pay Related";
      this.menuItemPayRelated.Click += new EventHandler(this.menuItemPayRelated_Click);
      this.menuItemPerformanceManagement.ImageIndex = -1;
      this.menuItemPerformanceManagement.ImageList = (ImageList) null;
      this.menuItemPerformanceManagement.Index = 1;
      this.menuItemPerformanceManagement.NoEdit = false;
      this.menuItemPerformanceManagement.NoUIModify = false;
      this.menuItemPerformanceManagement.OriginalText = "";
      this.menuItemPerformanceManagement.OwnerDraw = true;
      this.menuItemPerformanceManagement.Text = "Staff Perfor&mance ";
      this.menuItemPerformanceManagement.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemSPSchoolSetup,
        (MenuItem) this.menuItemLineManagementStructure
      });
      this.menuItemSPSchoolSetup.ImageIndex = -1;
      this.menuItemSPSchoolSetup.ImageList = (ImageList) null;
      this.menuItemSPSchoolSetup.Index = 0;
      this.menuItemSPSchoolSetup.NoEdit = false;
      this.menuItemSPSchoolSetup.NoUIModify = false;
      this.menuItemSPSchoolSetup.OriginalText = "";
      this.menuItemSPSchoolSetup.OwnerDraw = true;
      this.menuItemSPSchoolSetup.Text = "&Setup";
      this.menuItemSPSchoolSetup.Click += new EventHandler(this.menuItemSPSchoolSetup_Click);
      this.menuItemLineManagementStructure.ImageIndex = -1;
      this.menuItemLineManagementStructure.ImageList = (ImageList) null;
      this.menuItemLineManagementStructure.Index = 1;
      this.menuItemLineManagementStructure.NoEdit = false;
      this.menuItemLineManagementStructure.NoUIModify = false;
      this.menuItemLineManagementStructure.OriginalText = "";
      this.menuItemLineManagementStructure.OwnerDraw = true;
      this.menuItemLineManagementStructure.Text = "&Line Management Structure";
      this.menuItemLineManagementStructure.Click += new EventHandler(this.menuItemLineManagementStructure_Click);
      this.menuItemAnnualIncrement.ImageIndex = -1;
      this.menuItemAnnualIncrement.ImageList = (ImageList) null;
      this.menuItemAnnualIncrement.Index = 2;
      this.menuItemAnnualIncrement.NoEdit = false;
      this.menuItemAnnualIncrement.NoUIModify = false;
      this.menuItemAnnualIncrement.OriginalText = "";
      this.menuItemAnnualIncrement.OwnerDraw = true;
      this.menuItemAnnualIncrement.Text = "&Annual Increment";
      this.menuItemAnnualIncrement.Click += new EventHandler(this.menuItemAnnualIncrement_Click);
      this.menuItemSalaryRangeUpdate.ImageIndex = -1;
      this.menuItemSalaryRangeUpdate.ImageList = (ImageList) null;
      this.menuItemSalaryRangeUpdate.Index = 3;
      this.menuItemSalaryRangeUpdate.NoEdit = false;
      this.menuItemSalaryRangeUpdate.NoUIModify = false;
      this.menuItemSalaryRangeUpdate.OriginalText = "";
      this.menuItemSalaryRangeUpdate.OwnerDraw = true;
      this.menuItemSalaryRangeUpdate.Text = "Salary &Update";
      this.menuItemSalaryRangeUpdate.Click += new EventHandler(this.menuItemSalaryRangeUpdate_Click);
      this.menuItemSuperannuation.ImageIndex = -1;
      this.menuItemSuperannuation.ImageList = (ImageList) null;
      this.menuItemSuperannuation.Index = 4;
      this.menuItemSuperannuation.NoEdit = false;
      this.menuItemSuperannuation.NoUIModify = false;
      this.menuItemSuperannuation.OriginalText = "";
      this.menuItemSuperannuation.OwnerDraw = true;
      this.menuItemSuperannuation.Text = "&Superannuation";
      this.menuItemSuperannuation.Click += new EventHandler(this.menuItemSuperannuation_Click);
      this.menuItemPayRelatedImport.ImageIndex = -1;
      this.menuItemPayRelatedImport.ImageList = (ImageList) null;
      this.menuItemPayRelatedImport.Index = 6;
      this.menuItemPayRelatedImport.NoEdit = false;
      this.menuItemPayRelatedImport.NoUIModify = false;
      this.menuItemPayRelatedImport.OriginalText = "";
      this.menuItemPayRelatedImport.OwnerDraw = true;
      this.menuItemPayRelatedImport.Text = "Pay Related &Import";
      this.menuItemPayRelatedImport.Click += new EventHandler(this.menuItemPayRelatedImport_Click);
      this.menuItemPayRelatedExport.ImageIndex = -1;
      this.menuItemPayRelatedExport.ImageList = (ImageList) null;
      this.menuItemPayRelatedExport.Index = 7;
      this.menuItemPayRelatedExport.NoEdit = false;
      this.menuItemPayRelatedExport.NoUIModify = false;
      this.menuItemPayRelatedExport.OriginalText = "";
      this.menuItemPayRelatedExport.OwnerDraw = true;
      this.menuItemPayRelatedExport.Text = "Pay Related &Export";
      this.menuItemPayRelatedExport.Click += new EventHandler(this.menuItemPayRelatedExport_Click);
      this.menuItemNationalInsuranceRates.ImageIndex = -1;
      this.menuItemNationalInsuranceRates.ImageList = (ImageList) null;
      this.menuItemNationalInsuranceRates.Index = 5;
      this.menuItemNationalInsuranceRates.NoEdit = false;
      this.menuItemNationalInsuranceRates.NoUIModify = false;
      this.menuItemNationalInsuranceRates.OriginalText = "";
      this.menuItemNationalInsuranceRates.OwnerDraw = true;
      this.menuItemNationalInsuranceRates.Text = "&National Insurance Rates";
      this.menuItemNationalInsuranceRates.Click += new EventHandler(this.menuItemNationalInsuranceRates_Click);
      this.menuItemPersonnelReport.MenuItems.AddRange(new MenuItem[10]
      {
        (MenuItem) this.menuItemAbsenceAnalysis,
        (MenuItem) this.menuItemIndividualAbsence,
        (MenuItem) this.menuItemLongTermAbsenceAnalysis,
        (MenuItem) this.menuItemContractAnalysis,
        (MenuItem) this.menuItemContractInformation,
        (MenuItem) this.menuItemSalaryInformation,
        (MenuItem) this.menuItemStaffTraining,
        (MenuItem) this.menuItemTrainingCourse,
        (MenuItem) this.menuItemTerminatingContracts,
        (MenuItem) this.menuItemStaffPerformanceReport
      });
      this.menuItemStaffPerformanceReport.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemStaffLineManagementReport,
        (MenuItem) this.menuItemStaffObservationsReport,
        (MenuItem) this.menuItemAuditLogReport,
        (MenuItem) this.menuItemStaffAnalysisByGradeReport,
        (MenuItem) this.menuItemStaffAnalysisByProfessionalStandardReport
      });
      this.menuItemAuditLogReport.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemAuditLogStaffPerformanceReport,
        (MenuItem) this.menuItemAuditLogLineManagementReport
      });
      this.menuItemRoutinesStaffs.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemDeleteStaff
      });
      this.menuItemStaff.MenuItems.AddRange(new MenuItem[9]
      {
        (MenuItem) this.menuItemTraining,
        (MenuItem) this.menuItemPayRelated,
        (MenuItem) this.menuItemPerformanceManagement,
        (MenuItem) this.menuItemAnnualIncrement,
        (MenuItem) this.menuItemSalaryRangeUpdate,
        (MenuItem) this.menuItemSuperannuation,
        (MenuItem) this.menuItemNationalInsuranceRates,
        (MenuItem) this.menuItemPayRelatedImport,
        (MenuItem) this.menuItemPayRelatedExport
      });
    }

    private void menuItemStaffPerformanceReport_Click(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }

    private void menuItemAuditLogReport_Click(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }

    private void rebuildPersonnelMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemEmployeeDetails, new string[2]
      {
        "EditEmployee",
        "BrowseEmployee"
      });
      if (!this.menuItemEmployeeDetails.Visible)
        SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemEmployeeDetails, new string[2]
        {
          "SPEditSchoolSetup",
          "SPViewSchoolSetup"
        });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemTraining, new string[2]
      {
        "EditTraining",
        "BrowseTraining"
      });
      string[] processNames = new string[2]
      {
        "EditServiceTerm",
        "BrowseServiceTerm"
      };
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPayRelated, processNames);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemPerformanceManagement, processNames);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemSuperannuation, new string[2]
      {
        "EditSuperannuation",
        "BrowseSuperannuation"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemAnnualIncrement, new string[2]
      {
        "EditAnnualIncrement",
        "BrowseAnnualIncrement"
      });
      this.menuItemSalaryRangeUpdate.Visible = ServiceTermCache.IsSalaryRangeLicensed && SIMS.Entities.Cache.ProcessVisible("EditSalaryUpdate");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemNationalInsuranceRates, new string[2]
      {
        "EditNIRate",
        "BrowseNIRate"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemAbsenceAnalysis, new string[2]
      {
        "ARAbsenceAnalysisDetail",
        "ARAbsenceAnalysisSummary"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemIndividualAbsence, "ARIndividualAbsence");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemLongTermAbsenceAnalysis, "ARLongTermAbsenceAnalysis");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemContractAnalysis, "ARContractAnalysis");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemContractInformation, "ARContractInformation");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSalaryInformation, "ARSalaryInformation");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemStaffTraining, "ARStaffTraining");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemTrainingCourse, "ARTrainingCourse");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemTerminatingContracts, "ARTerminatingContracts");
      if (EmployeeCache.IsStaffPerformanceLicensed)
      {
        this.menuItemSPSchoolSetup.Visible = SIMS.Entities.Cache.ProcessVisible("SPEditSchoolSetup") || SIMS.Entities.Cache.ProcessVisible("SPViewSchoolSetup");
        this.menuItemLineManagementStructure.Visible = SIMS.Entities.Cache.ProcessVisible("SPViewLineManagerSetup") || SIMS.Entities.Cache.ProcessVisible("SPEditLineManagerSetup");
        this.menuItemStaffPerformanceReport.Visible = SIMS.Entities.Cache.ProcessVisible("SPRptStaffObservations") || SIMS.Entities.Cache.ProcessVisible("SPRptLineManagement") || (SIMS.Entities.Cache.ProcessVisible("SPRptStaffAnalysisByGrade") || SIMS.Entities.Cache.ProcessVisible("SPRptStaffAnalysisByStandard")) || SIMS.Entities.Cache.ProcessVisible("SPRptAuditLogStaffPerformance") || SIMS.Entities.Cache.ProcessVisible("SPRptAuditLogLineManagement");
        this.menuItemStaffLineManagementReport.Visible = SIMS.Entities.Cache.ProcessVisible("SPRptLineManagement");
        this.menuItemStaffObservationsReport.Visible = SIMS.Entities.Cache.ProcessVisible("SPRptStaffObservations");
        this.menuItemStaffAnalysisByGradeReport.Visible = SIMS.Entities.Cache.ProcessVisible("SPRptStaffAnalysisByGrade");
        this.menuItemStaffAnalysisByProfessionalStandardReport.Visible = SIMS.Entities.Cache.ProcessVisible("SPRptStaffAnalysisByStandard");
        this.menuItemAuditLogReport.Visible = SIMS.Entities.Cache.ProcessVisible("SPRptAuditLogStaffPerformance") || SIMS.Entities.Cache.ProcessVisible("SPRptAuditLogLineManagement");
        this.menuItemAuditLogStaffPerformanceReport.Visible = SIMS.Entities.Cache.ProcessVisible("SPRptAuditLogStaffPerformance");
        this.menuItemAuditLogLineManagementReport.Visible = SIMS.Entities.Cache.ProcessVisible("SPRptAuditLogLineManagement");
      }
      else
      {
        this.menuItemSPSchoolSetup.Visible = false;
        this.menuItemLineManagementStructure.Visible = false;
        this.menuItemStaffPerformanceReport.Visible = false;
        this.menuItemStaffLineManagementReport.Visible = false;
        this.menuItemStaffObservationsReport.Visible = false;
        this.menuItemStaffAnalysisByGradeReport.Visible = false;
        this.menuItemStaffAnalysisByProfessionalStandardReport.Visible = false;
        this.menuItemAuditLogReport.Visible = false;
        this.menuItemAuditLogStaffPerformanceReport.Visible = false;
        this.menuItemAuditLogLineManagementReport.Visible = false;
      }
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemDeleteStaff, "DeleteStaffRole");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPayRelatedExport, "PayRelatedExport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPayRelatedImport, "PayRelatedImport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemImportLookups, "ImportLookup");
    }

    private void MenuItemBrowseEmployee_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.ServiceTermContainerUI", "Service Term");
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.SuperannuationContainerUI", "Superannuation");
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.AnnualIncrementDetailUI", "Apply Annual Increment");
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.MaintainTrainingCourseInformation", "Training Course");
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.SalaryRangeUpdateDetailUI", "Apply Salary Update");
      this.DisplayComponent((Control) new MaintainEmployeeInformation());
    }

    private void menuItemTraining_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.MaintainEmployeeInformation", "Staff Details");
      this.DisplayComponent((Control) new MaintainTrainingCourseInformation());
    }

    private void menuItemPayRelated_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.MaintainEmployeeInformation", "Staff Details");
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.SalaryRangeUpdateDetailUI", "Apply Salary Update");
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.SuperannuationContainerUI", "Superannuation");
      this.DisplayComponent((Control) new ServiceTermContainerUI());
    }

    private void menuItemSPSchoolSetup_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new SPSchoolSetup());
    }

    private void menuItemLineManagementStructure_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SPLineManagerSetupUI());
    }

    private void menuItemSuperannuation_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.MaintainEmployeeInformation", "Staff Details");
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.ServiceTermContainerUI", "Service Term");
      this.DisplayComponent((Control) new SuperannuationContainerUI());
    }

    private void menuItemAnnualIncrement_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.MaintainEmployeeInformation", "Staff Details");
      this.DisplayComponent((Control) new AnnualIncrementDetailUI());
    }

    private void menuItemSalaryRangeUpdate_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.MaintainEmployeeInformation", "Staff Details");
      this.warningIfScreenIsOpen("SIMS.UserInterfaces.ServiceTermContainerUI", "Service Term");
      this.DisplayComponent((Control) new SalaryRangeUpdateDetailUI());
    }

    private void menuItemLetterContract_Click(object sender, EventArgs e)
    {
    }

    private void menuItemLetterSalaryReview_Click(object sender, EventArgs e)
    {
    }

    private void warningIfScreenIsOpen(string componentTypeName, string label)
    {
      if (this.ComponentExists(componentTypeName) == null)
        return;
      int num = (int) MessageBox.Show(string.Format("'{0}' screen is open. Please ensure that all users (including yourself) have closed the '{0}' window before continuing or they will not be able to save any edited data", (object) label), "SIMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void menuItemNationalInsuranceRates_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new MaintainNIRateInformation());
    }

    private void menuItemAbsenceAnalysis_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new MaintainAbsenceAnalysisReport());
    }

    private void menuItemIndividualAbsence_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new MaintainIndividualAbsenceReport());
    }

    private void menuItemLongTermAbsenceAnalysis_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new MaintainLongTermAbsenceAnalysisReport());
    }

    private void menuItemContractAnalysis_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new MaintainContractAnalysisReport());
    }

    private void menuItemContractInformation_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new MaintainContractInformationReport());
    }

    private void menuItemSalaryInformation_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new MaintainSalaryInformationReport());
    }

    private void menuItemStaffTraining_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new MaintainStaffTrainingReport());
    }

    private void menuItemTrainingCourse_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new MaintainTrainingCourseReport());
    }

    private void menuItemLineManagementReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (SPDialogLineManagement dialogLineManagement = new SPDialogLineManagement())
      {
        int num = (int) dialogLineManagement.ShowDialog();
      }
    }

    private void menuItemStaffObservationsReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (SPDialogStaffObservations staffObservations = new SPDialogStaffObservations())
      {
        int num = (int) staffObservations.ShowDialog();
      }
    }

    private void menuItemStaffAnalysisByGradeReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (SPDialogStaffAnalysis dialogStaffAnalysis = new SPDialogStaffAnalysis("Overall Grade"))
      {
        int num = (int) dialogStaffAnalysis.ShowDialog();
      }
    }

    private void menuItemStaffAnalysisByProfessionalStandardReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (SPDialogStaffAnalysis dialogStaffAnalysis = new SPDialogStaffAnalysis("Professional Standards"))
      {
        int num = (int) dialogStaffAnalysis.ShowDialog();
      }
    }

    private void menuItemAuditLogStaffPerformanceReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (SPDialogAuditLogStaffPerformance staffPerformance = new SPDialogAuditLogStaffPerformance())
      {
        int num = (int) staffPerformance.ShowDialog();
      }
    }

    private void menuItemAuditLogLineManagementReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (SPDialogAuditLogLineManagement logLineManagement = new SPDialogAuditLogLineManagement())
      {
        int num = (int) logLineManagement.ShowDialog();
      }
    }

    private void menuItemTerminatingContracts_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new MaintainTerminatingContractsReport());
    }

    private void menuItemPayRelatedImport_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new PayRelatedImport());
    }

    private void menuItemPayRelatedExport_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new PayRelatedExport());
    }

    private void menuItemDeleteStaff_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new DeletePersonRole("STAFF"));
    }

    private void menuItemImportLookups_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new ImportLookupsDetail());
    }

    private void initCLPMenus()
    {
      this.menuItemCurrLessPlannerFocus = new UIMenuItem();
      this.menuItemCLPStudyTopics = new UIMenuItem();
      this.menuItemCLPSchoolPlans = new UIMenuItem();
      this.menuItemCLPSubjectPlans = new UIMenuItem();
      this.menuItemCLPCohortPlans = new UIMenuItem();
      this.menuItemCLPLessonPlans = new UIMenuItem();
      this.menuItemCurrLessPlannerRoutines = new UIMenuItem();
      this.menuItemImportCLPStudyTopics = new UIMenuItem();
      this.menuItemImportCLPPoSRequirements = new UIMenuItem();
      this.menuItemImportCLPLearningObjectives = new UIMenuItem();
      this.menuItemCurrLessPlannerTools = new UIMenuItem();
      this.menuItemCLPSetup = new UIMenuItem();
      this.menuItemCLPSubjects = new UIMenuItem();
      this.menuItemCLPPlanningCohorts = new UIMenuItem();
      this.menuItemCLPPoSRequirements = new UIMenuItem();
      this.menuItemCLPLearningObjectives = new UIMenuItem();
      this.MenuItemSchool.MenuItems.Add(this.menuItemAcademicStructure.Index + 1, (MenuItem) this.menuItemCurrLessPlannerFocus);
      this.menuItemRoutines.MenuItems.Add(this.menuItemB2B.Index + 1, (MenuItem) this.menuItemCurrLessPlannerRoutines);
      this.toolsMenu.MenuItems.Add(this.menuItemPLASCTools.Index + 1, (MenuItem) this.menuItemCurrLessPlannerTools);
      this.menuItemSetups.MenuItems.Add((MenuItem) this.menuItemCLPSubjects);
      this.menuItemSetups.MenuItems.Add((MenuItem) this.menuItemAddressTidyAndMergeSetup);
      this.menuItemSetups.MenuItems.Add((MenuItem) this.menuItemSchoolOptions);
      this.menuItemCurrLessPlannerFocus.ImageIndex = -1;
      this.menuItemCurrLessPlannerFocus.ImageList = (ImageList) null;
      this.menuItemCurrLessPlannerFocus.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemCLPStudyTopics,
        (MenuItem) this.menuItemCLPSchoolPlans,
        (MenuItem) this.menuItemCLPSubjectPlans,
        (MenuItem) this.menuItemCLPCohortPlans,
        (MenuItem) this.menuItemCLPLessonPlans
      });
      this.menuItemCurrLessPlannerFocus.NoEdit = false;
      this.menuItemCurrLessPlannerFocus.NoUIModify = false;
      this.menuItemCurrLessPlannerFocus.OriginalText = "";
      this.menuItemCurrLessPlannerFocus.OwnerDraw = true;
      this.menuItemCurrLessPlannerFocus.Text = "&Curriculum && Lesson Planner";
      this.menuItemCLPStudyTopics.ImageIndex = -1;
      this.menuItemCLPStudyTopics.ImageList = (ImageList) null;
      this.menuItemCLPStudyTopics.Index = 0;
      this.menuItemCLPStudyTopics.NoEdit = false;
      this.menuItemCLPStudyTopics.NoUIModify = false;
      this.menuItemCLPStudyTopics.OriginalText = "";
      this.menuItemCLPStudyTopics.OwnerDraw = true;
      this.menuItemCLPStudyTopics.Text = "Study &Topics";
      this.menuItemCLPStudyTopics.Click += new EventHandler(this.menuItemCLPStudyTopics_Click);
      this.menuItemCLPSchoolPlans.ImageIndex = -1;
      this.menuItemCLPSchoolPlans.ImageList = (ImageList) null;
      this.menuItemCLPSchoolPlans.Index = 1;
      this.menuItemCLPSchoolPlans.NoEdit = false;
      this.menuItemCLPSchoolPlans.NoUIModify = false;
      this.menuItemCLPSchoolPlans.OriginalText = "";
      this.menuItemCLPSchoolPlans.OwnerDraw = true;
      this.menuItemCLPSchoolPlans.Text = "&School Plans";
      this.menuItemCLPSchoolPlans.Click += new EventHandler(this.menuItemCLPSchoolPlans_Click);
      this.menuItemCLPSubjectPlans.ImageIndex = -1;
      this.menuItemCLPSubjectPlans.ImageList = (ImageList) null;
      this.menuItemCLPSubjectPlans.Index = 2;
      this.menuItemCLPSubjectPlans.NoEdit = false;
      this.menuItemCLPSubjectPlans.NoUIModify = false;
      this.menuItemCLPSubjectPlans.OriginalText = "";
      this.menuItemCLPSubjectPlans.OwnerDraw = true;
      this.menuItemCLPSubjectPlans.Text = "S&ubject Plans";
      this.menuItemCLPSubjectPlans.Click += new EventHandler(this.menuItemCLPSubjectPlans_Click);
      this.menuItemCLPCohortPlans.ImageIndex = -1;
      this.menuItemCLPCohortPlans.ImageList = (ImageList) null;
      this.menuItemCLPCohortPlans.Index = 3;
      this.menuItemCLPCohortPlans.NoEdit = false;
      this.menuItemCLPCohortPlans.NoUIModify = false;
      this.menuItemCLPCohortPlans.OriginalText = "";
      this.menuItemCLPCohortPlans.OwnerDraw = true;
      this.menuItemCLPCohortPlans.Text = "&Cohort Plans";
      this.menuItemCLPCohortPlans.Click += new EventHandler(this.menuItemCLPCohortPlans_Click);
      this.menuItemCLPLessonPlans.ImageIndex = -1;
      this.menuItemCLPLessonPlans.ImageList = (ImageList) null;
      this.menuItemCLPLessonPlans.Index = 4;
      this.menuItemCLPLessonPlans.NoEdit = false;
      this.menuItemCLPLessonPlans.NoUIModify = false;
      this.menuItemCLPLessonPlans.OriginalText = "";
      this.menuItemCLPLessonPlans.OwnerDraw = true;
      this.menuItemCLPLessonPlans.Text = "&Lesson Plans (for Delivery)";
      this.menuItemCLPLessonPlans.Click += new EventHandler(this.menuItemCLPLessonPlans_Click);
      this.menuItemCurrLessPlannerRoutines.ImageIndex = -1;
      this.menuItemCurrLessPlannerRoutines.ImageList = (ImageList) null;
      this.menuItemCurrLessPlannerRoutines.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) this.menuItemImportCLPPoSRequirements,
        (MenuItem) this.menuItemImportCLPLearningObjectives,
        (MenuItem) this.menuItemImportCLPStudyTopics
      });
      this.menuItemCurrLessPlannerRoutines.NoEdit = false;
      this.menuItemCurrLessPlannerRoutines.NoUIModify = false;
      this.menuItemCurrLessPlannerRoutines.OriginalText = "";
      this.menuItemCurrLessPlannerRoutines.OwnerDraw = true;
      this.menuItemCurrLessPlannerRoutines.Text = "&Curriculum && Lesson Planner";
      this.menuItemImportCLPPoSRequirements.ImageIndex = -1;
      this.menuItemImportCLPPoSRequirements.ImageList = (ImageList) null;
      this.menuItemImportCLPPoSRequirements.Index = 0;
      this.menuItemImportCLPPoSRequirements.NoEdit = false;
      this.menuItemImportCLPPoSRequirements.NoUIModify = false;
      this.menuItemImportCLPPoSRequirements.OriginalText = "";
      this.menuItemImportCLPPoSRequirements.OwnerDraw = true;
      this.menuItemImportCLPPoSRequirements.Text = "Import PoS &Requirements";
      this.menuItemImportCLPPoSRequirements.Click += new EventHandler(this.menuItemImportCLPPoSRequirements_Click);
      this.menuItemImportCLPLearningObjectives.ImageIndex = -1;
      this.menuItemImportCLPLearningObjectives.ImageList = (ImageList) null;
      this.menuItemImportCLPLearningObjectives.Index = 1;
      this.menuItemImportCLPLearningObjectives.NoEdit = false;
      this.menuItemImportCLPLearningObjectives.NoUIModify = false;
      this.menuItemImportCLPLearningObjectives.OriginalText = "";
      this.menuItemImportCLPLearningObjectives.OwnerDraw = true;
      this.menuItemImportCLPLearningObjectives.Text = "Import Learning &Objectives";
      this.menuItemImportCLPLearningObjectives.Click += new EventHandler(this.menuItemImportCLPLearningObjectives_Click);
      this.menuItemImportCLPStudyTopics.ImageIndex = -1;
      this.menuItemImportCLPStudyTopics.ImageList = (ImageList) null;
      this.menuItemImportCLPStudyTopics.Index = 2;
      this.menuItemImportCLPStudyTopics.NoEdit = false;
      this.menuItemImportCLPStudyTopics.NoUIModify = false;
      this.menuItemImportCLPStudyTopics.OriginalText = "";
      this.menuItemImportCLPStudyTopics.OwnerDraw = true;
      this.menuItemImportCLPStudyTopics.Text = "Import &Study Topics (including Lesson Plans)";
      this.menuItemImportCLPStudyTopics.Click += new EventHandler(this.menuItemImportCLPStudyTopics_Click);
      this.menuItemCurrLessPlannerTools.BaseName = "menuItemCurrLessPlannerTools";
      this.menuItemCurrLessPlannerTools.ImageIndex = -1;
      this.menuItemCurrLessPlannerTools.ImageList = (ImageList) null;
      this.menuItemCurrLessPlannerTools.MenuItems.AddRange(new MenuItem[4]
      {
        (MenuItem) this.menuItemCLPSetup,
        (MenuItem) this.menuItemCLPPlanningCohorts,
        (MenuItem) this.menuItemCLPPoSRequirements,
        (MenuItem) this.menuItemCLPLearningObjectives
      });
      this.menuItemCurrLessPlannerTools.NoEdit = false;
      this.menuItemCurrLessPlannerTools.NoUIModify = false;
      this.menuItemCurrLessPlannerTools.OriginalText = "";
      this.menuItemCurrLessPlannerTools.OwnerDraw = true;
      this.menuItemCurrLessPlannerTools.Text = "&Curriculum && Lesson Planner";
      this.menuItemCLPSetup.ImageIndex = -1;
      this.menuItemCLPSetup.ImageList = (ImageList) null;
      this.menuItemCLPSetup.Index = 0;
      this.menuItemCLPSetup.NoEdit = false;
      this.menuItemCLPSetup.NoUIModify = false;
      this.menuItemCLPSetup.OriginalText = "";
      this.menuItemCLPSetup.OwnerDraw = true;
      this.menuItemCLPSetup.Text = "&Setup";
      this.menuItemCLPSetup.Click += new EventHandler(this.menuItemCLPSetup_Click);
      this.menuItemCLPSubjects.ImageIndex = -1;
      this.menuItemCLPSubjects.ImageList = (ImageList) null;
      this.menuItemCLPSubjects.NoEdit = false;
      this.menuItemCLPSubjects.NoUIModify = false;
      this.menuItemCLPSubjects.OriginalText = "";
      this.menuItemCLPSubjects.OwnerDraw = true;
      this.menuItemCLPSubjects.Text = "S&ubjects";
      this.menuItemCLPSubjects.Click += new EventHandler(this.menuItemCLPSubjects_Click);
      this.menuItemAddressTidyAndMergeSetup.ImageIndex = -1;
      this.menuItemAddressTidyAndMergeSetup.ImageList = (ImageList) null;
      this.menuItemAddressTidyAndMergeSetup.NoEdit = false;
      this.menuItemAddressTidyAndMergeSetup.NoUIModify = false;
      this.menuItemAddressTidyAndMergeSetup.OriginalText = "";
      this.menuItemAddressTidyAndMergeSetup.OwnerDraw = true;
      this.menuItemAddressTidyAndMergeSetup.Text = "Address T&idy and Merge Setup";
      this.menuItemAddressTidyAndMergeSetup.Click += new EventHandler(this.menuItemAddressTidyAndMergeSetup_Click);
      this.menuItemCLPPlanningCohorts.ImageIndex = -1;
      this.menuItemCLPPlanningCohorts.ImageList = (ImageList) null;
      this.menuItemCLPPlanningCohorts.Index = 1;
      this.menuItemCLPPlanningCohorts.NoEdit = false;
      this.menuItemCLPPlanningCohorts.NoUIModify = false;
      this.menuItemCLPPlanningCohorts.OriginalText = "";
      this.menuItemCLPPlanningCohorts.OwnerDraw = true;
      this.menuItemCLPPlanningCohorts.Text = "&Planning Cohorts";
      this.menuItemCLPPlanningCohorts.Click += new EventHandler(this.menuItemCLPPlanningCohorts_Click);
      this.menuItemCLPPoSRequirements.ImageIndex = -1;
      this.menuItemCLPPoSRequirements.ImageList = (ImageList) null;
      this.menuItemCLPPoSRequirements.Index = 2;
      this.menuItemCLPPoSRequirements.NoEdit = false;
      this.menuItemCLPPoSRequirements.NoUIModify = false;
      this.menuItemCLPPoSRequirements.OriginalText = "";
      this.menuItemCLPPoSRequirements.OwnerDraw = true;
      this.menuItemCLPPoSRequirements.Text = "PoS &Requirements";
      this.menuItemCLPPoSRequirements.Click += new EventHandler(this.menuItemCLPPoSRequirements_Click);
      this.menuItemCLPLearningObjectives.ImageIndex = -1;
      this.menuItemCLPLearningObjectives.ImageList = (ImageList) null;
      this.menuItemCLPLearningObjectives.Index = 3;
      this.menuItemCLPLearningObjectives.NoEdit = false;
      this.menuItemCLPLearningObjectives.NoUIModify = false;
      this.menuItemCLPLearningObjectives.OriginalText = "";
      this.menuItemCLPLearningObjectives.OwnerDraw = true;
      this.menuItemCLPLearningObjectives.Text = "Learning &Objectives";
      this.menuItemCLPLearningObjectives.Click += new EventHandler(this.menuItemCLPLearningObjectives_Click);
    }

    private void rebuildCLPMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCLPStudyTopics, new string[2]
      {
        typeof (CLPStudyTopicBrowser).Name,
        typeof (CLPStudyTopicDetail).Name
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCLPSchoolPlans, new string[2]
      {
        typeof (CLPSchoolPlanBrowser).Name,
        typeof (CLPSchoolPlanDetail).Name
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCLPSubjectPlans, new string[2]
      {
        typeof (CLPSubjectPlanBrowser).Name,
        typeof (CLPSubjectCohortPlanDetail).Name
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCLPCohortPlans, new string[2]
      {
        typeof (CLPCohortPlanBrowser).Name,
        typeof (CLPSubjectCohortPlanDetail).Name
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCLPLessonPlans, new string[2]
      {
        typeof (CLPLessonPlanBrowser).Name,
        typeof (CLPLessonPlanDetail).Name
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemImportCLPPoSRequirements, typeof (CLPImportPoSRequirementsWizard).Name);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemImportCLPLearningObjectives, typeof (CLPImportLearningObjectivesWizard).Name);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemImportCLPStudyTopics, typeof (CLPImportStudyTopicsWizard).Name);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCLPSetup, typeof (CLPSetupDetail).Name);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCLPSubjects, new string[2]
      {
        typeof (CLPSubjectBrowser).Name,
        typeof (CLPSubjectDetail).Name
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCLPPlanningCohorts, new string[2]
      {
        typeof (CLPPlanningCohortBrowser).Name,
        typeof (CLPPlanningCohortDetail).Name
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCLPPoSRequirements, new string[4]
      {
        typeof (CLPPoSRequirementBrowser).Name,
        typeof (CLPProgrammeOfStudyDetail).Name,
        typeof (CLPPoSHeadingDetail).Name,
        typeof (CLPPoSRequirementDetail).Name
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCLPLearningObjectives, new string[4]
      {
        typeof (CLPLearningObjectiveBrowser).Name,
        typeof (CLPTeachingStrategyDetail).Name,
        typeof (CLPStrategyHeadingDetail).Name,
        typeof (CLPLearningObjectiveDetail).Name
      });
    }

    private void menuItemCLPStudyTopics_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCLPStudyTopic());
    }

    private void menuItemCLPSchoolPlans_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCLPSchoolPlan());
    }

    private void menuItemCLPSubjectPlans_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCLPSubjectPlan());
    }

    private void menuItemCLPCohortPlans_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCLPCohortPlan());
    }

    private void menuItemCLPLessonPlans_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCLPLessonPlan());
    }

    private void menuItemImportCLPPoSRequirements_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (CLPImportPoSRequirementsWizard srequirementsWizard = new CLPImportPoSRequirementsWizard())
      {
        int num = (int) srequirementsWizard.ShowDialog();
      }
    }

    private void menuItemImportCLPLearningObjectives_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (CLPImportLearningObjectivesWizard objectivesWizard = new CLPImportLearningObjectivesWizard())
      {
        int num = (int) objectivesWizard.ShowDialog();
      }
    }

    private void menuItemImportCLPStudyTopics_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (CLPImportStudyTopicsWizard studyTopicsWizard = new CLPImportStudyTopicsWizard())
      {
        int num = (int) studyTopicsWizard.ShowDialog();
      }
    }

    private void menuItemCLPSetup_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CLPSetupDetail());
    }

    private void menuItemCLPSubjects_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCLPSubject());
    }

    private void menuItemAddressTidyAndMergeSetup_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new AddressTidySetup());
    }

    private void menuItemCLPPlanningCohorts_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCLPPlanningCohort());
    }

    private void menuItemCLPPoSRequirements_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCLPPoSRequirement());
    }

    private void menuItemCLPLearningObjectives_Click(object sender, EventArgs args)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainCLPLearningObjective());
    }

    private void initAlertsMenu()
    {
      this.menuItemAlertsSetupReminders = new UIMenuItem();
      this.menuItemPersonalTask = new UIMenuItem();
      this.menuItemGeneralMessages = new UIMenuItem();
      this.menuItemAlertsScheduleReports = new UIMenuItem();
      this.menuItemAlerts.BaseName = "menuItemAlerts";
      this.menuItemAlerts.Index = 11;
      this.menuItemAlerts.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemAlertsSetupReminders,
        (MenuItem) this.menuItemAlertsScheduleReports,
        (MenuItem) this.menuItemPersonalTask,
        (MenuItem) this.menuItemGeneralMessages,
        (MenuItem) this.menuItemSendEmergencyAlert
      });
      this.menuItemAlerts.Text = "A&lerts";
      this.menuItemAlertsSetupReminders.Index = 0;
      this.menuItemAlertsSetupReminders.Text = "&Setup Reminders";
      this.menuItemAlertsSetupReminders.Click += new EventHandler(this.menuItemAlertsSetupReminders_Click);
      this.menuItemPersonalTask.Index = 2;
      this.menuItemPersonalTask.Text = "&Personal Tasks";
      this.menuItemPersonalTask.Click += new EventHandler(this.menuItemPersonalTask_Click);
      this.menuItemGeneralMessages.Index = 3;
      this.menuItemGeneralMessages.Text = "&General Messages";
      this.menuItemGeneralMessages.Click += new EventHandler(this.menuItemGeneralMessages_Click);
      this.menuItemAlertsScheduleReports.Index = 1;
      this.menuItemAlertsScheduleReports.Text = "Schedule &Reports";
      this.menuItemAlertsScheduleReports.Click += new EventHandler(this.menuItemAlertsScheduleReports_Click);
    }

    private void menuItemAlertsSetupReminders_Click(object sender, EventArgs e)
    {
      int num = (int) new AlertsDlgMessage("REMINDER").ShowDialog((IWin32Window) this.Owner);
    }

    private void menuItemPersonalTask_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PersonalTaskDetails());
    }

    private void menuItemGeneralMessages_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new GeneralMessage());
    }

    private void menuItemSetupMessage_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SetupMessage());
    }

    private void menuItemDataChangeManagement_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new DataChangeManagement());
    }

    private void menuItemAlertsScheduleReports_Click(object sender, EventArgs e)
    {
      int num = (int) new AlertsDlgMessage("REPORT").ShowDialog((IWin32Window) this.Owner);
    }

    private void ContextSendMsg(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (entityToDisplay != null)
      {
        int num = (int) new AlertsDlgMessage("MESSAGE", this.panelMain.Controls.Count > 0 ? this.panelMain.Controls[0].Name : this.focusedControl().Name, entityToDisplay).ShowDialog((IWin32Window) this.Owner);
      }
      else
        SIMS.Entities.Cache.StatusMessage("No student selected.", UserMessageEventEnum.Information);
    }

    private void ContextSendStudentInTouchMsg(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.DisplayComponentWithInterfaces((Control) new SIMS.UserInterfaces.InTouch.SendStudentMessageHost(this.panelMain.Controls.Count > 0 ? this.panelMain.Controls[0].Name : this.focusedControl().Name, entityToDisplay));
    }

    protected void ContextSendApplicantInTouchMsg(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.DisplayComponentWithInterfaces((Control) new SendApplicationMessageHost(this.panelMain.Controls.Count > 0 ? this.panelMain.Controls[0].Name : this.focusedControl().Name, entityToDisplay));
    }

    private void rebuildAlertsMenu()
    {
      this.menuItemAlertsSetupReminders.Visible = SIMS.Entities.Cache.ProcessAvailable("SetupStudentReminders") || SIMS.Entities.Cache.ProcessAvailable("SetupSENReminders") || (SIMS.Entities.Cache.ProcessAvailable("SetupAdmissionsReminders") || SIMS.Entities.Cache.ProcessAvailable("SetupAttendanceReminders")) || SIMS.Entities.Cache.ProcessAvailable("SetupFeesReminders");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAlertsScheduleReports, "ScheduleReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPersonalTask, "PersonalTaskDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSetupMessage, "SetupMessage");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGeneralMessages, "SendMessage");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemDataChangeManagement, "DataChangeManagement");
      this.menuItemGeneralMessages.Visible &= !SIMS.Entities.InTouch.Cache.IsLicensed;
    }

    private void initSLGMenus()
    {
      this.menuItemSetupSLGUsers = new UIMenuItem();
      this.menuItemSLGExportUsers = new UIMenuItem();
      this.menuItemSLGExportingUsers = new UIMenuItem();
      this.menuItemSetups.MenuItems.AddRange((MenuItem[]) new UIMenuItem[1]
      {
        this.menuItemSetupSLGUsers
      });
      this.menuItemSetupSLGUsers.MenuItems.AddRange((MenuItem[]) new UIMenuItem[2]
      {
        this.menuItemSLGExportUsers,
        this.menuItemSLGExportingUsers
      });
      this.menuItemSetupSLGUsers.ImageIndex = -1;
      this.menuItemSetupSLGUsers.ImageList = (ImageList) null;
      this.menuItemSetupSLGUsers.Index = 15;
      this.menuItemSetupSLGUsers.NoEdit = false;
      this.menuItemSetupSLGUsers.NoUIModify = false;
      this.menuItemSetupSLGUsers.OriginalText = "";
      this.menuItemSetupSLGUsers.OwnerDraw = true;
      this.menuItemSetupSLGUsers.Text = "Setup SLG Users";
      this.menuItemSLGExportUsers.ImageIndex = -1;
      this.menuItemSLGExportUsers.ImageList = (ImageList) null;
      this.menuItemSLGExportUsers.Index = 0;
      this.menuItemSLGExportUsers.NoEdit = false;
      this.menuItemSLGExportUsers.NoUIModify = false;
      this.menuItemSLGExportUsers.OriginalText = "";
      this.menuItemSLGExportUsers.OwnerDraw = true;
      this.menuItemSLGExportUsers.Text = "&Manage SLG Users";
      this.menuItemSLGExportUsers.Click += new EventHandler(this.menuItemSLGExportUsers_Click);
      this.menuItemSLGExportingUsers.ImageIndex = -1;
      this.menuItemSLGExportingUsers.ImageList = (ImageList) null;
      this.menuItemSLGExportingUsers.Index = 1;
      this.menuItemSLGExportingUsers.NoEdit = false;
      this.menuItemSLGExportingUsers.NoUIModify = false;
      this.menuItemSLGExportingUsers.OriginalText = "";
      this.menuItemSLGExportingUsers.OwnerDraw = true;
      this.menuItemSLGExportingUsers.Text = "Manage In-&Process Exports";
      this.menuItemSLGExportingUsers.Click += new EventHandler(this.menuItemSLGExportingUsers_Click);
    }

    private void rebuildSLGMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSLGExportUsers, ManageSLGUsersContainer.HostedProcessName);
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSLGExportingUsers, SLGExportingUsersContainer.HostedProcessName);
    }

    private void menuItemSLGExportUsers_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new ManageSLGUsersContainer());
    }

    private void menuItemSLGExportingUsers_Click(object sender, EventArgs e)
    {
      this.DisplayComponent((Control) new SLGExportingUsersContainer());
    }

    private void initFeesLedgerMenus()
    {
      this.menuItemEditBillPayer = new UIMenuItem();
      this.menuItemFeesCharging = new UIMenuItem();
      this.menuItemApplyCharges = new UIMenuItem();
      this.menuItemSurchargeCalculation = new UIMenuItem();
      this.menuItemChargeBatchReport = new UIMenuItem();
      this.menuItemUpdateBills = new UIMenuItem();
      this.menuItemBreakFees1 = new UIMenuItem();
      this.menuItemGlobalUpdateOfCharges = new UIMenuItem();
      this.menuItemBreakFees2 = new UIMenuItem();
      this.menuItemAmendBillDetails = new UIMenuItem();
      this.menuItemBreakFees3 = new UIMenuItem();
      this.menuItemFeesBilling = new UIMenuItem();
      this.menuItemAssignBillNumbers = new UIMenuItem();
      this.menuItemBreakFees4 = new UIMenuItem();
      this.menuItemAddNotesToBill = new UIMenuItem();
      this.menuItemBreakFees5 = new UIMenuItem();
      this.menuItemPrintBills = new UIMenuItem();
      this.menuItemBreakFees6 = new UIMenuItem();
      this.menuItemCopyBills = new UIMenuItem();
      this.menuItemBreakFees7 = new UIMenuItem();
      this.menuItemMiscellaneousChargeSheet = new UIMenuItem();
      this.menuItemBreakFees8 = new UIMenuItem();
      this.menuItemPreviousBills = new UIMenuItem();
      this.menuItemFeesPeriodic = new UIMenuItem();
      this.menuItemTermEnd = new UIMenuItem();
      this.menuItemTransferBills = new UIMenuItem();
      this.menuItemFeesTransactions = new UIMenuItem();
      this.menuItem49menuItemProcessTransaction = new UIMenuItem();
      this.menuItemAuditReport = new UIMenuItem();
      this.menuItemUpdatePayers = new UIMenuItem();
      this.menuItemRefundCreditBalances = new UIMenuItem();
      this.menuItemBreakFees9 = new UIMenuItem();
      this.menuItemStandingOrders = new UIMenuItem();
      this.menuItemCancelBills = new UIMenuItem();
      this.menuItemCancelBillsReport = new UIMenuItem();
      this.menuItemBreakFees10 = new UIMenuItem();
      this.menuItemAllocateTransactions = new UIMenuItem();
      this.menuItemFeesBillingReports = new UIMenuItem();
      this.menuItemBillingReports = new UIMenuItem();
      this.menuItemBillAudit = new UIMenuItem();
      this.menuItemChargesAudit = new UIMenuItem();
      this.menuItemCrossReference = new UIMenuItem();
      this.menuItemException = new UIMenuItem();
      this.menuItemTransactionReports = new UIMenuItem();
      this.menuItemAgedDebtors = new UIMenuItem();
      this.menuItemControlAccount = new UIMenuItem();
      this.menuItemGLInterface = new UIMenuItem();
      this.menuItemGLReconcilation = new UIMenuItem();
      this.menuItemTransactionList = new UIMenuItem();
      this.menuItemStatementDetails = new UIMenuItem();
      this.menuItemUnallocatedTransactions = new UIMenuItem();
      this.menuItemSetUpReports = new UIMenuItem();
      this.menuItemTransactionTypes = new UIMenuItem();
      this.menuItemFiscalCalendar = new UIMenuItem();
      this.menuItemGLCodes = new UIMenuItem();
      this.menuItemVATCodes = new UIMenuItem();
      this.menuItemChargeCodes = new UIMenuItem();
      this.menuItemLogs = new UIMenuItem();
      this.menuItemDesignTemplates = new UIMenuItem();
      this.menuItemChargeBatchLog = new UIMenuItem();
      this.menuItemReceiptBatchLog = new UIMenuItem();
      this.menuItemAllocationLog = new UIMenuItem();
      this.menuItemChangesLog = new UIMenuItem();
      this.menuItemClearanceRoutines = new UIMenuItem();
      this.menuItemImportChartOfAccounts = new UIMenuItem();
      this.menuItemParameters = new UIMenuItem();
      this.menuItemChargeCodeSetup = new UIMenuItem();
      this.menuItemGeneralLedgerAccounts = new UIMenuItem();
      this.menuItemInterestRates = new UIMenuItem();
      this.menuItemVAT = new UIMenuItem();
      this.menuItemTransactionType = new UIMenuItem();
      this.menuItemFiscalYear = new UIMenuItem();
      this.menuItemPaymentType = new UIMenuItem();
      this.menuItemFeesInstalments = new UIMenuItem();
      this.menuItemDDInstalmentSchedule = new UIMenuItem();
      this.menuItemSOInstalmentSchedule = new UIMenuItem();
      this.menuItemBACSGeneration = new UIMenuItem();
      this.menuItemApplyRefund = new UIMenuItem();
      this.menuItemEditBillPayer.ImageIndex = -1;
      this.menuItemEditBillPayer.ImageList = (ImageList) null;
      this.menuItemEditBillPayer.Index = 3;
      this.menuItemEditBillPayer.NoEdit = false;
      this.menuItemEditBillPayer.NoUIModify = false;
      this.menuItemEditBillPayer.OriginalText = "";
      this.menuItemEditBillPayer.OwnerDraw = true;
      this.menuItemEditBillPayer.Text = "Bill &Payer";
      this.menuItemEditBillPayer.Click += new EventHandler(this.menuItemEditBillPayer_Click);
      this.menuItemPeople.MenuItems.Add((MenuItem) this.menuItemEditBillPayer);
      this.menuItemFees.BaseName = "menuItemFees";
      this.menuItemFees.ImageIndex = -1;
      this.menuItemFees.ImageList = (ImageList) null;
      this.menuItemFees.Index = 10;
      this.menuItemFees.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemFeesCharging,
        (MenuItem) this.menuItemFeesBilling,
        (MenuItem) this.menuItemFeesPeriodic,
        (MenuItem) this.menuItemFeesTransactions,
        (MenuItem) this.menuItemFeesInstalments
      });
      this.menuItemFees.NoEdit = false;
      this.menuItemFees.NoUIModify = false;
      this.menuItemFees.OriginalText = "";
      this.menuItemFees.OwnerDraw = true;
      this.menuItemFees.Text = "&Fees Billing";
      this.menuItemFeesCharging.ImageIndex = -1;
      this.menuItemFeesCharging.ImageList = (ImageList) null;
      this.menuItemFeesCharging.Index = 0;
      this.menuItemFeesCharging.MenuItems.AddRange(new MenuItem[10]
      {
        (MenuItem) this.menuItemApplyCharges,
        (MenuItem) this.menuItemChargeBatchReport,
        (MenuItem) this.menuItemUpdateBills,
        (MenuItem) this.menuItemBreakFees1,
        (MenuItem) this.menuItemGlobalUpdateOfCharges,
        (MenuItem) this.menuItemBreakFees2,
        (MenuItem) this.menuItemAmendBillDetails,
        (MenuItem) this.menuItemBreakFees3,
        (MenuItem) this.menuItemSurchargeCalculation,
        (MenuItem) this.menuItemApplyRefund
      });
      this.menuItemFeesCharging.NoEdit = false;
      this.menuItemFeesCharging.NoUIModify = false;
      this.menuItemFeesCharging.OriginalText = "";
      this.menuItemFeesCharging.OwnerDraw = true;
      this.menuItemFeesCharging.Text = "&Charging";
      this.menuItemApplyCharges.ImageIndex = -1;
      this.menuItemApplyCharges.ImageList = (ImageList) null;
      this.menuItemApplyCharges.Index = 0;
      this.menuItemApplyCharges.NoEdit = false;
      this.menuItemApplyCharges.NoUIModify = false;
      this.menuItemApplyCharges.OriginalText = "";
      this.menuItemApplyCharges.OwnerDraw = true;
      this.menuItemApplyCharges.Text = "&Apply Charges";
      this.menuItemApplyCharges.Click += new EventHandler(this.menuItemApplyCharges_Click);
      this.menuItemChargeBatchReport.ImageIndex = -1;
      this.menuItemChargeBatchReport.ImageList = (ImageList) null;
      this.menuItemChargeBatchReport.Index = 1;
      this.menuItemChargeBatchReport.NoEdit = false;
      this.menuItemChargeBatchReport.NoUIModify = false;
      this.menuItemChargeBatchReport.OriginalText = "";
      this.menuItemChargeBatchReport.OwnerDraw = true;
      this.menuItemChargeBatchReport.Text = "&Charge Batch Report";
      this.menuItemChargeBatchReport.Click += new EventHandler(this.menuItemChargeBatchReport_Click);
      this.menuItemUpdateBills.ImageIndex = -1;
      this.menuItemUpdateBills.ImageList = (ImageList) null;
      this.menuItemUpdateBills.Index = 2;
      this.menuItemUpdateBills.NoEdit = false;
      this.menuItemUpdateBills.NoUIModify = false;
      this.menuItemUpdateBills.OriginalText = "";
      this.menuItemUpdateBills.OwnerDraw = true;
      this.menuItemUpdateBills.Text = "&Update Bills";
      this.menuItemUpdateBills.Click += new EventHandler(this.menuItemUpdateBills_Click);
      this.menuItemBreakFees1.ImageIndex = -1;
      this.menuItemBreakFees1.ImageList = (ImageList) null;
      this.menuItemBreakFees1.Index = 3;
      this.menuItemBreakFees1.NoEdit = false;
      this.menuItemBreakFees1.NoUIModify = false;
      this.menuItemBreakFees1.OriginalText = "";
      this.menuItemBreakFees1.OwnerDraw = true;
      this.menuItemBreakFees1.Text = "-";
      this.menuItemGlobalUpdateOfCharges.ImageIndex = -1;
      this.menuItemGlobalUpdateOfCharges.ImageList = (ImageList) null;
      this.menuItemGlobalUpdateOfCharges.Index = 4;
      this.menuItemGlobalUpdateOfCharges.NoEdit = false;
      this.menuItemGlobalUpdateOfCharges.NoUIModify = false;
      this.menuItemGlobalUpdateOfCharges.OriginalText = "";
      this.menuItemGlobalUpdateOfCharges.OwnerDraw = true;
      this.menuItemGlobalUpdateOfCharges.Text = "&Global Update of Charges";
      this.menuItemGlobalUpdateOfCharges.Click += new EventHandler(this.menuItemGlobalUpdateOfCharges_Click);
      this.menuItemBreakFees2.ImageIndex = -1;
      this.menuItemBreakFees2.ImageList = (ImageList) null;
      this.menuItemBreakFees2.Index = 5;
      this.menuItemBreakFees2.NoEdit = false;
      this.menuItemBreakFees2.NoUIModify = false;
      this.menuItemBreakFees2.OriginalText = "";
      this.menuItemBreakFees2.OwnerDraw = true;
      this.menuItemBreakFees2.Text = "-";
      this.menuItemAmendBillDetails.ImageIndex = -1;
      this.menuItemAmendBillDetails.ImageList = (ImageList) null;
      this.menuItemAmendBillDetails.Index = 6;
      this.menuItemAmendBillDetails.NoEdit = false;
      this.menuItemAmendBillDetails.NoUIModify = false;
      this.menuItemAmendBillDetails.OriginalText = "";
      this.menuItemAmendBillDetails.OwnerDraw = true;
      this.menuItemAmendBillDetails.Text = "Amend &Bills";
      this.menuItemAmendBillDetails.Click += new EventHandler(this.menuItemAmendBillDetails_Click);
      this.menuItemBreakFees3.ImageIndex = -1;
      this.menuItemBreakFees3.ImageList = (ImageList) null;
      this.menuItemBreakFees3.Index = 7;
      this.menuItemBreakFees3.NoEdit = false;
      this.menuItemBreakFees3.NoUIModify = false;
      this.menuItemBreakFees3.OriginalText = "";
      this.menuItemBreakFees3.OwnerDraw = true;
      this.menuItemBreakFees3.Text = "-";
      this.menuItemSurchargeCalculation.ImageIndex = -1;
      this.menuItemSurchargeCalculation.ImageList = (ImageList) null;
      this.menuItemSurchargeCalculation.Index = 8;
      this.menuItemSurchargeCalculation.NoEdit = false;
      this.menuItemSurchargeCalculation.NoUIModify = false;
      this.menuItemSurchargeCalculation.OriginalText = "";
      this.menuItemSurchargeCalculation.OwnerDraw = true;
      this.menuItemSurchargeCalculation.Text = "Apply &Interest";
      this.menuItemSurchargeCalculation.Click += new EventHandler(this.menuItemSurchargeCalculation_Click);
      this.menuItemApplyRefund.ImageIndex = -1;
      this.menuItemApplyRefund.ImageList = (ImageList) null;
      this.menuItemApplyRefund.Index = 9;
      this.menuItemApplyRefund.NoEdit = false;
      this.menuItemApplyRefund.NoUIModify = false;
      this.menuItemApplyRefund.OriginalText = "";
      this.menuItemApplyRefund.OwnerDraw = true;
      this.menuItemApplyRefund.Text = "Apply &Refunds";
      this.menuItemApplyRefund.Click += new EventHandler(this.menuItemApplyRefund_Click);
      this.menuItemFeesBilling.ImageIndex = -1;
      this.menuItemFeesBilling.ImageList = (ImageList) null;
      this.menuItemFeesBilling.Index = 1;
      this.menuItemFeesBilling.MenuItems.AddRange(new MenuItem[13]
      {
        (MenuItem) this.menuItemAssignBillNumbers,
        (MenuItem) this.menuItemBreakFees4,
        (MenuItem) this.menuItemAddNotesToBill,
        (MenuItem) this.menuItemBreakFees5,
        (MenuItem) this.menuItemPrintBills,
        (MenuItem) this.menuItemBreakFees6,
        (MenuItem) this.menuItemCopyBills,
        (MenuItem) this.menuItemBreakFees7,
        (MenuItem) this.menuItemMiscellaneousChargeSheet,
        (MenuItem) this.menuItemBreakFees8,
        (MenuItem) this.menuItemPreviousBills,
        (MenuItem) this.menuItemBreakFees10,
        (MenuItem) this.menuItemCancelBills
      });
      this.menuItemFeesBilling.NoEdit = false;
      this.menuItemFeesBilling.NoUIModify = false;
      this.menuItemFeesBilling.OriginalText = "";
      this.menuItemFeesBilling.OwnerDraw = true;
      this.menuItemFeesBilling.Text = "&Billing";
      this.menuItemAssignBillNumbers.ImageIndex = -1;
      this.menuItemAssignBillNumbers.ImageList = (ImageList) null;
      this.menuItemAssignBillNumbers.Index = 0;
      this.menuItemAssignBillNumbers.NoEdit = false;
      this.menuItemAssignBillNumbers.NoUIModify = false;
      this.menuItemAssignBillNumbers.OriginalText = "";
      this.menuItemAssignBillNumbers.OwnerDraw = true;
      this.menuItemAssignBillNumbers.Text = "&Assign Bill Numbers";
      this.menuItemAssignBillNumbers.Click += new EventHandler(this.menuItemAssignBillNumbers_Click);
      this.menuItemBreakFees4.ImageIndex = -1;
      this.menuItemBreakFees4.ImageList = (ImageList) null;
      this.menuItemBreakFees4.Index = 1;
      this.menuItemBreakFees4.NoEdit = false;
      this.menuItemBreakFees4.NoUIModify = false;
      this.menuItemBreakFees4.OriginalText = "";
      this.menuItemBreakFees4.OwnerDraw = true;
      this.menuItemBreakFees4.Text = "-";
      this.menuItemAddNotesToBill.ImageIndex = -1;
      this.menuItemAddNotesToBill.ImageList = (ImageList) null;
      this.menuItemAddNotesToBill.Index = 2;
      this.menuItemAddNotesToBill.NoEdit = false;
      this.menuItemAddNotesToBill.NoUIModify = false;
      this.menuItemAddNotesToBill.OriginalText = "";
      this.menuItemAddNotesToBill.OwnerDraw = true;
      this.menuItemAddNotesToBill.Text = "Add &Note to Bills";
      this.menuItemAddNotesToBill.Click += new EventHandler(this.menuItemAddNotesToBill_Click);
      this.menuItemBreakFees5.ImageIndex = -1;
      this.menuItemBreakFees5.ImageList = (ImageList) null;
      this.menuItemBreakFees5.Index = 3;
      this.menuItemBreakFees5.NoEdit = false;
      this.menuItemBreakFees5.NoUIModify = false;
      this.menuItemBreakFees5.OriginalText = "";
      this.menuItemBreakFees5.OwnerDraw = true;
      this.menuItemBreakFees5.Text = "-";
      this.menuItemPrintBills.ImageIndex = -1;
      this.menuItemPrintBills.ImageList = (ImageList) null;
      this.menuItemPrintBills.Index = 4;
      this.menuItemPrintBills.NoEdit = false;
      this.menuItemPrintBills.NoUIModify = false;
      this.menuItemPrintBills.OriginalText = "";
      this.menuItemPrintBills.OwnerDraw = true;
      this.menuItemPrintBills.Text = "&Process Bills";
      this.menuItemPrintBills.Click += new EventHandler(this.menuItemPrintBills_Click);
      this.menuItemBreakFees6.ImageIndex = -1;
      this.menuItemBreakFees6.ImageList = (ImageList) null;
      this.menuItemBreakFees6.Index = 5;
      this.menuItemBreakFees6.NoEdit = false;
      this.menuItemBreakFees6.NoUIModify = false;
      this.menuItemBreakFees6.OriginalText = "";
      this.menuItemBreakFees6.OwnerDraw = true;
      this.menuItemBreakFees6.Text = "-";
      this.menuItemCopyBills.ImageIndex = -1;
      this.menuItemCopyBills.ImageList = (ImageList) null;
      this.menuItemCopyBills.Index = 6;
      this.menuItemCopyBills.NoEdit = false;
      this.menuItemCopyBills.NoUIModify = false;
      this.menuItemCopyBills.OriginalText = "";
      this.menuItemCopyBills.OwnerDraw = true;
      this.menuItemCopyBills.Text = "&Copy Bills";
      this.menuItemCopyBills.Click += new EventHandler(this.menuItemCopyBills_Click);
      this.menuItemBreakFees7.ImageIndex = -1;
      this.menuItemBreakFees7.ImageList = (ImageList) null;
      this.menuItemBreakFees7.Index = 7;
      this.menuItemBreakFees7.NoEdit = false;
      this.menuItemBreakFees7.NoUIModify = false;
      this.menuItemBreakFees7.OriginalText = "";
      this.menuItemBreakFees7.OwnerDraw = true;
      this.menuItemBreakFees7.Text = "-";
      this.menuItemMiscellaneousChargeSheet.ImageIndex = -1;
      this.menuItemMiscellaneousChargeSheet.ImageList = (ImageList) null;
      this.menuItemMiscellaneousChargeSheet.Index = 8;
      this.menuItemMiscellaneousChargeSheet.NoEdit = false;
      this.menuItemMiscellaneousChargeSheet.NoUIModify = false;
      this.menuItemMiscellaneousChargeSheet.OriginalText = "";
      this.menuItemMiscellaneousChargeSheet.OwnerDraw = true;
      this.menuItemMiscellaneousChargeSheet.Text = "&Miscellaneous Charge Sheet";
      this.menuItemMiscellaneousChargeSheet.Click += new EventHandler(this.menuItemMiscellaneousChargeSheet_Click);
      this.menuItemBreakFees8.ImageIndex = -1;
      this.menuItemBreakFees8.ImageList = (ImageList) null;
      this.menuItemBreakFees8.Index = 9;
      this.menuItemBreakFees8.NoEdit = false;
      this.menuItemBreakFees8.NoUIModify = false;
      this.menuItemBreakFees8.OriginalText = "";
      this.menuItemBreakFees8.OwnerDraw = true;
      this.menuItemBreakFees8.Text = "-";
      this.menuItemPreviousBills.ImageIndex = -1;
      this.menuItemPreviousBills.ImageList = (ImageList) null;
      this.menuItemPreviousBills.Index = 10;
      this.menuItemPreviousBills.NoEdit = false;
      this.menuItemPreviousBills.NoUIModify = false;
      this.menuItemPreviousBills.OriginalText = "";
      this.menuItemPreviousBills.OwnerDraw = true;
      this.menuItemPreviousBills.Text = "Reprint &Bills";
      this.menuItemPreviousBills.Click += new EventHandler(this.menuItemPreviousBills_Click);
      this.menuItemBreakFees10.ImageIndex = -1;
      this.menuItemBreakFees10.ImageList = (ImageList) null;
      this.menuItemBreakFees10.Index = 11;
      this.menuItemBreakFees10.NoEdit = false;
      this.menuItemBreakFees10.NoUIModify = false;
      this.menuItemBreakFees10.OriginalText = "";
      this.menuItemBreakFees10.OwnerDraw = true;
      this.menuItemBreakFees10.Text = "-";
      this.menuItemCancelBills.ImageIndex = -1;
      this.menuItemCancelBills.ImageList = (ImageList) null;
      this.menuItemCancelBills.Index = 12;
      this.menuItemCancelBills.NoEdit = false;
      this.menuItemCancelBills.NoUIModify = false;
      this.menuItemCancelBills.OriginalText = "";
      this.menuItemCancelBills.OwnerDraw = true;
      this.menuItemCancelBills.Text = "&Cancel Bills";
      this.menuItemCancelBills.Click += new EventHandler(this.menuItemCancelBills_Click);
      this.menuItemFeesPeriodic.ImageIndex = -1;
      this.menuItemFeesPeriodic.ImageList = (ImageList) null;
      this.menuItemFeesPeriodic.Index = 2;
      this.menuItemFeesPeriodic.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemTermEnd,
        (MenuItem) this.menuItemTransferBills
      });
      this.menuItemFeesPeriodic.NoEdit = false;
      this.menuItemFeesPeriodic.NoUIModify = false;
      this.menuItemFeesPeriodic.OriginalText = "";
      this.menuItemFeesPeriodic.OwnerDraw = true;
      this.menuItemFeesPeriodic.Text = "&Periodic";
      this.menuItemTermEnd.ImageIndex = -1;
      this.menuItemTermEnd.ImageList = (ImageList) null;
      this.menuItemTermEnd.Index = 0;
      this.menuItemTermEnd.NoEdit = false;
      this.menuItemTermEnd.NoUIModify = false;
      this.menuItemTermEnd.OriginalText = "";
      this.menuItemTermEnd.OwnerDraw = true;
      this.menuItemTermEnd.Text = "Period &End";
      this.menuItemTermEnd.Click += new EventHandler(this.menuItemTermEnd_Click);
      this.menuItemTransferBills.ImageIndex = -1;
      this.menuItemTransferBills.ImageList = (ImageList) null;
      this.menuItemTransferBills.Index = 1;
      this.menuItemTransferBills.NoEdit = false;
      this.menuItemTransferBills.NoUIModify = false;
      this.menuItemTransferBills.OriginalText = "";
      this.menuItemTransferBills.OwnerDraw = true;
      this.menuItemTransferBills.Text = "Transfer &Bills";
      this.menuItemTransferBills.Click += new EventHandler(this.menuItemTransferBills_Click);
      this.menuItemFeesTransactions.ImageIndex = -1;
      this.menuItemFeesTransactions.ImageList = (ImageList) null;
      this.menuItemFeesTransactions.Index = 3;
      this.menuItemFeesTransactions.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItem49menuItemProcessTransaction,
        (MenuItem) this.menuItemAuditReport,
        (MenuItem) this.menuItemUpdatePayers,
        (MenuItem) this.menuItemRefundCreditBalances,
        (MenuItem) this.menuItemAllocateTransactions
      });
      this.menuItemFeesTransactions.NoEdit = false;
      this.menuItemFeesTransactions.NoUIModify = false;
      this.menuItemFeesTransactions.OriginalText = "";
      this.menuItemFeesTransactions.OwnerDraw = true;
      this.menuItemFeesTransactions.Text = "&Transactions";
      this.menuItem49menuItemProcessTransaction.ImageIndex = -1;
      this.menuItem49menuItemProcessTransaction.ImageList = (ImageList) null;
      this.menuItem49menuItemProcessTransaction.Index = 0;
      this.menuItem49menuItemProcessTransaction.NoEdit = false;
      this.menuItem49menuItemProcessTransaction.NoUIModify = false;
      this.menuItem49menuItemProcessTransaction.OriginalText = "";
      this.menuItem49menuItemProcessTransaction.OwnerDraw = true;
      this.menuItem49menuItemProcessTransaction.Text = "&Process Transaction";
      this.menuItem49menuItemProcessTransaction.Click += new EventHandler(this.menuItemProcessTransaction_Click);
      this.menuItemAuditReport.ImageIndex = -1;
      this.menuItemAuditReport.ImageList = (ImageList) null;
      this.menuItemAuditReport.Index = 1;
      this.menuItemAuditReport.NoEdit = false;
      this.menuItemAuditReport.NoUIModify = false;
      this.menuItemAuditReport.OriginalText = "";
      this.menuItemAuditReport.OwnerDraw = true;
      this.menuItemAuditReport.Text = "Transaction Batch &Report";
      this.menuItemAuditReport.Click += new EventHandler(this.menuItemAuditReport_Click);
      this.menuItemUpdatePayers.ImageIndex = -1;
      this.menuItemUpdatePayers.ImageList = (ImageList) null;
      this.menuItemUpdatePayers.Index = 2;
      this.menuItemUpdatePayers.NoEdit = false;
      this.menuItemUpdatePayers.NoUIModify = false;
      this.menuItemUpdatePayers.OriginalText = "";
      this.menuItemUpdatePayers.OwnerDraw = true;
      this.menuItemUpdatePayers.Text = "&Update Payers";
      this.menuItemUpdatePayers.Click += new EventHandler(this.menuItemUpdatePayers_Click);
      this.menuItemRefundCreditBalances.ImageIndex = -1;
      this.menuItemRefundCreditBalances.ImageList = (ImageList) null;
      this.menuItemRefundCreditBalances.Index = 3;
      this.menuItemRefundCreditBalances.NoEdit = false;
      this.menuItemRefundCreditBalances.NoUIModify = false;
      this.menuItemRefundCreditBalances.OriginalText = "";
      this.menuItemRefundCreditBalances.OwnerDraw = true;
      this.menuItemRefundCreditBalances.Text = "&Credit Refunds";
      this.menuItemRefundCreditBalances.Click += new EventHandler(this.menuItemRefundCreditBalances_Click);
      this.menuItemBreakFees9.ImageIndex = -1;
      this.menuItemBreakFees9.ImageList = (ImageList) null;
      this.menuItemBreakFees9.Index = 3;
      this.menuItemBreakFees9.NoEdit = false;
      this.menuItemBreakFees9.NoUIModify = false;
      this.menuItemBreakFees9.OriginalText = "";
      this.menuItemBreakFees9.OwnerDraw = true;
      this.menuItemBreakFees9.Text = "-";
      this.menuItemAllocateTransactions.ImageIndex = -1;
      this.menuItemAllocateTransactions.ImageList = (ImageList) null;
      this.menuItemAllocateTransactions.Index = 3;
      this.menuItemAllocateTransactions.NoEdit = false;
      this.menuItemAllocateTransactions.NoUIModify = false;
      this.menuItemAllocateTransactions.OriginalText = "";
      this.menuItemAllocateTransactions.OwnerDraw = true;
      this.menuItemAllocateTransactions.Text = "Allocate &Transactions";
      this.menuItemAllocateTransactions.Click += new EventHandler(this.menuItemAllocateTransactions_Click);
      this.menuItemFeesInstalments.ImageIndex = -1;
      this.menuItemFeesInstalments.ImageList = (ImageList) null;
      this.menuItemFeesInstalments.Index = 4;
      this.menuItemFeesInstalments.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) this.menuItemDDInstalmentSchedule,
        (MenuItem) this.menuItemSOInstalmentSchedule,
        (MenuItem) this.menuItemBACSGeneration
      });
      this.menuItemFeesInstalments.NoEdit = false;
      this.menuItemFeesInstalments.NoUIModify = false;
      this.menuItemFeesInstalments.OriginalText = "";
      this.menuItemFeesInstalments.OwnerDraw = true;
      this.menuItemFeesInstalments.Text = "&Instalments";
      this.menuItemDDInstalmentSchedule.ImageIndex = -1;
      this.menuItemDDInstalmentSchedule.ImageList = (ImageList) null;
      this.menuItemDDInstalmentSchedule.Index = 0;
      this.menuItemDDInstalmentSchedule.NoEdit = false;
      this.menuItemDDInstalmentSchedule.NoUIModify = false;
      this.menuItemDDInstalmentSchedule.OriginalText = "";
      this.menuItemDDInstalmentSchedule.OwnerDraw = true;
      this.menuItemDDInstalmentSchedule.Text = "Direct &Debit";
      this.menuItemDDInstalmentSchedule.Click += new EventHandler(this.menuItemDDInstalmentSchedule_Click);
      this.menuItemSOInstalmentSchedule.ImageIndex = -1;
      this.menuItemSOInstalmentSchedule.ImageList = (ImageList) null;
      this.menuItemSOInstalmentSchedule.Index = 1;
      this.menuItemSOInstalmentSchedule.NoEdit = false;
      this.menuItemSOInstalmentSchedule.NoUIModify = false;
      this.menuItemSOInstalmentSchedule.OriginalText = "";
      this.menuItemSOInstalmentSchedule.OwnerDraw = true;
      this.menuItemSOInstalmentSchedule.Text = "Standing &Order";
      this.menuItemSOInstalmentSchedule.Click += new EventHandler(this.menuItemSOInstalmentSchedule_Click);
      this.menuItemBACSGeneration.ImageIndex = -1;
      this.menuItemBACSGeneration.ImageList = (ImageList) null;
      this.menuItemBACSGeneration.Index = 2;
      this.menuItemBACSGeneration.NoEdit = false;
      this.menuItemBACSGeneration.NoUIModify = false;
      this.menuItemBACSGeneration.OriginalText = "";
      this.menuItemBACSGeneration.OwnerDraw = true;
      this.menuItemBACSGeneration.Text = "BACS &Generation";
      this.menuItemBACSGeneration.Click += new EventHandler(this.menuItemFeesBACS_Click);
      this.menuItemFeesBillingReports.ImageIndex = -1;
      this.menuItemFeesBillingReports.ImageList = (ImageList) null;
      this.menuItemFeesBillingReports.Index = 0;
      this.menuItemFeesBillingReports.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemBillingReports,
        (MenuItem) this.menuItemTransactionReports,
        (MenuItem) this.menuItemSetUpReports,
        (MenuItem) this.menuItemLogs,
        (MenuItem) this.menuItemDesignTemplates
      });
      this.menuItemFeesBillingReports.NoEdit = false;
      this.menuItemFeesBillingReports.NoUIModify = false;
      this.menuItemFeesBillingReports.OriginalText = "";
      this.menuItemFeesBillingReports.OwnerDraw = true;
      this.menuItemFeesBillingReports.Text = "&Fees Billing";
      this.MenuItemReports.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemFeesBillingReports
      });
      this.menuItemBillingReports.ImageIndex = -1;
      this.menuItemBillingReports.ImageList = (ImageList) null;
      this.menuItemBillingReports.Index = 0;
      this.menuItemBillingReports.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemBillAudit,
        (MenuItem) this.menuItemChargesAudit,
        (MenuItem) this.menuItemCrossReference,
        (MenuItem) this.menuItemException,
        (MenuItem) this.menuItemCancelBillsReport
      });
      this.menuItemBillingReports.NoEdit = false;
      this.menuItemBillingReports.NoUIModify = false;
      this.menuItemBillingReports.OriginalText = "";
      this.menuItemBillingReports.OwnerDraw = true;
      this.menuItemBillingReports.Text = "&Billing";
      this.menuItemBillAudit.ImageIndex = -1;
      this.menuItemBillAudit.ImageList = (ImageList) null;
      this.menuItemBillAudit.Index = 0;
      this.menuItemBillAudit.NoEdit = false;
      this.menuItemBillAudit.NoUIModify = false;
      this.menuItemBillAudit.OriginalText = "";
      this.menuItemBillAudit.OwnerDraw = true;
      this.menuItemBillAudit.Text = "&Bill Audit";
      this.menuItemBillAudit.Click += new EventHandler(this.menuItemBillAudit_Click);
      this.menuItemChargesAudit.ImageIndex = -1;
      this.menuItemChargesAudit.ImageList = (ImageList) null;
      this.menuItemChargesAudit.Index = 1;
      this.menuItemChargesAudit.NoEdit = false;
      this.menuItemChargesAudit.NoUIModify = false;
      this.menuItemChargesAudit.OriginalText = "";
      this.menuItemChargesAudit.OwnerDraw = true;
      this.menuItemChargesAudit.Text = "&Charges Audit";
      this.menuItemChargesAudit.Click += new EventHandler(this.menuItemChargesAudit_Click);
      this.menuItemCrossReference.ImageIndex = -1;
      this.menuItemCrossReference.ImageList = (ImageList) null;
      this.menuItemCrossReference.Index = 2;
      this.menuItemCrossReference.NoEdit = false;
      this.menuItemCrossReference.NoUIModify = false;
      this.menuItemCrossReference.OriginalText = "";
      this.menuItemCrossReference.OwnerDraw = true;
      this.menuItemCrossReference.Text = "Cross &Reference";
      this.menuItemCrossReference.Click += new EventHandler(this.menuItemCrossReference_Click);
      this.menuItemException.ImageIndex = -1;
      this.menuItemException.ImageList = (ImageList) null;
      this.menuItemException.Index = 3;
      this.menuItemException.NoEdit = false;
      this.menuItemException.NoUIModify = false;
      this.menuItemException.OriginalText = "";
      this.menuItemException.OwnerDraw = true;
      this.menuItemException.Text = "&Exceptions";
      this.menuItemException.Click += new EventHandler(this.menuItemException_Click);
      this.menuItemCancelBillsReport.ImageIndex = -1;
      this.menuItemCancelBillsReport.ImageList = (ImageList) null;
      this.menuItemCancelBillsReport.Index = 4;
      this.menuItemCancelBillsReport.NoEdit = false;
      this.menuItemCancelBillsReport.NoUIModify = false;
      this.menuItemCancelBillsReport.OriginalText = "";
      this.menuItemCancelBillsReport.OwnerDraw = true;
      this.menuItemCancelBillsReport.Text = "Ca&ncelled Bills";
      this.menuItemCancelBillsReport.Click += new EventHandler(this.menuItemCancelBillsReport_Click);
      if (SIMS.Entities.Cache.Settings.ContainsKey("AllowFeesCancelBills") && SIMS.Entities.Cache.Settings["AllowFeesCancelBills"] == "F")
      {
        this.menuItemCancelBills.Enabled = false;
        this.menuItemCancelBillsReport.Enabled = false;
      }
      this.menuItemTransactionReports.ImageIndex = -1;
      this.menuItemTransactionReports.ImageList = (ImageList) null;
      this.menuItemTransactionReports.Index = 1;
      this.menuItemTransactionReports.MenuItems.AddRange(new MenuItem[7]
      {
        (MenuItem) this.menuItemAgedDebtors,
        (MenuItem) this.menuItemControlAccount,
        (MenuItem) this.menuItemGLInterface,
        (MenuItem) this.menuItemGLReconcilation,
        (MenuItem) this.menuItemTransactionList,
        (MenuItem) this.menuItemStatementDetails,
        (MenuItem) this.menuItemUnallocatedTransactions
      });
      this.menuItemTransactionReports.NoEdit = false;
      this.menuItemTransactionReports.NoUIModify = false;
      this.menuItemTransactionReports.OriginalText = "";
      this.menuItemTransactionReports.OwnerDraw = true;
      this.menuItemTransactionReports.Text = "&Transactions";
      this.menuItemAgedDebtors.ImageIndex = -1;
      this.menuItemAgedDebtors.ImageList = (ImageList) null;
      this.menuItemAgedDebtors.Index = 0;
      this.menuItemAgedDebtors.NoEdit = false;
      this.menuItemAgedDebtors.NoUIModify = false;
      this.menuItemAgedDebtors.OriginalText = "";
      this.menuItemAgedDebtors.OwnerDraw = true;
      this.menuItemAgedDebtors.Text = "&Aged Debtors";
      this.menuItemAgedDebtors.Click += new EventHandler(this.menuItemAgedDebtors_Click);
      this.menuItemControlAccount.ImageIndex = -1;
      this.menuItemControlAccount.ImageList = (ImageList) null;
      this.menuItemControlAccount.Index = 1;
      this.menuItemControlAccount.NoEdit = false;
      this.menuItemControlAccount.NoUIModify = false;
      this.menuItemControlAccount.OriginalText = "";
      this.menuItemControlAccount.OwnerDraw = true;
      this.menuItemControlAccount.Text = "&Control Account";
      this.menuItemControlAccount.Click += new EventHandler(this.menuItemControlAccount_Click);
      this.menuItemGLInterface.ImageIndex = -1;
      this.menuItemGLInterface.ImageList = (ImageList) null;
      this.menuItemGLInterface.Index = 2;
      this.menuItemGLInterface.NoEdit = false;
      this.menuItemGLInterface.NoUIModify = false;
      this.menuItemGLInterface.OriginalText = "";
      this.menuItemGLInterface.OwnerDraw = true;
      this.menuItemGLInterface.Text = "&GL Interface";
      this.menuItemGLInterface.Click += new EventHandler(this.menuItemGLInterface_Click);
      this.menuItemGLReconcilation.ImageIndex = -1;
      this.menuItemGLReconcilation.ImageList = (ImageList) null;
      this.menuItemGLReconcilation.Index = 3;
      this.menuItemGLReconcilation.NoEdit = false;
      this.menuItemGLReconcilation.NoUIModify = false;
      this.menuItemGLReconcilation.OriginalText = "";
      this.menuItemGLReconcilation.OwnerDraw = true;
      this.menuItemGLReconcilation.Text = "GL &Reconciliation";
      this.menuItemGLReconcilation.Click += new EventHandler(this.menuItemGLReconcilation_Click);
      this.menuItemTransactionList.ImageIndex = -1;
      this.menuItemTransactionList.ImageList = (ImageList) null;
      this.menuItemTransactionList.Index = 5;
      this.menuItemTransactionList.NoEdit = false;
      this.menuItemTransactionList.NoUIModify = false;
      this.menuItemTransactionList.OriginalText = "";
      this.menuItemTransactionList.OwnerDraw = true;
      this.menuItemTransactionList.Text = "&Transactions List";
      this.menuItemTransactionList.Click += new EventHandler(this.menuItemTransactionList_Click);
      this.menuItemStatementDetails.ImageIndex = -1;
      this.menuItemStatementDetails.ImageList = (ImageList) null;
      this.menuItemStatementDetails.Index = 4;
      this.menuItemStatementDetails.NoEdit = false;
      this.menuItemStatementDetails.NoUIModify = false;
      this.menuItemStatementDetails.OriginalText = "";
      this.menuItemStatementDetails.OwnerDraw = true;
      this.menuItemStatementDetails.Text = "&Statements";
      this.menuItemStatementDetails.Click += new EventHandler(this.menuItemStatementDetails_Click);
      this.menuItemUnallocatedTransactions.ImageIndex = -1;
      this.menuItemUnallocatedTransactions.ImageList = (ImageList) null;
      this.menuItemUnallocatedTransactions.Index = 6;
      this.menuItemUnallocatedTransactions.NoEdit = false;
      this.menuItemUnallocatedTransactions.NoUIModify = false;
      this.menuItemUnallocatedTransactions.OriginalText = "";
      this.menuItemUnallocatedTransactions.OwnerDraw = true;
      this.menuItemUnallocatedTransactions.Text = "&Unallocated Transactions";
      this.menuItemUnallocatedTransactions.Click += new EventHandler(this.menuItemUnallocatedTransactions_Click);
      this.menuItemSetUpReports.ImageIndex = -1;
      this.menuItemSetUpReports.ImageList = (ImageList) null;
      this.menuItemSetUpReports.Index = 2;
      this.menuItemSetUpReports.MenuItems.AddRange(new MenuItem[5]
      {
        (MenuItem) this.menuItemTransactionTypes,
        (MenuItem) this.menuItemFiscalCalendar,
        (MenuItem) this.menuItemGLCodes,
        (MenuItem) this.menuItemVATCodes,
        (MenuItem) this.menuItemChargeCodes
      });
      this.menuItemSetUpReports.NoEdit = false;
      this.menuItemSetUpReports.NoUIModify = false;
      this.menuItemSetUpReports.OriginalText = "";
      this.menuItemSetUpReports.OwnerDraw = true;
      this.menuItemSetUpReports.Text = "&Set Up";
      this.menuItemTransactionTypes.ImageIndex = -1;
      this.menuItemTransactionTypes.ImageList = (ImageList) null;
      this.menuItemTransactionTypes.Index = 0;
      this.menuItemTransactionTypes.NoEdit = false;
      this.menuItemTransactionTypes.NoUIModify = false;
      this.menuItemTransactionTypes.OriginalText = "";
      this.menuItemTransactionTypes.OwnerDraw = true;
      this.menuItemTransactionTypes.Text = "&Transaction Types";
      this.menuItemTransactionTypes.Click += new EventHandler(this.menuItemTransactionTypes_Click);
      this.menuItemFiscalCalendar.ImageIndex = -1;
      this.menuItemFiscalCalendar.ImageList = (ImageList) null;
      this.menuItemFiscalCalendar.Index = 1;
      this.menuItemFiscalCalendar.NoEdit = false;
      this.menuItemFiscalCalendar.NoUIModify = false;
      this.menuItemFiscalCalendar.OriginalText = "";
      this.menuItemFiscalCalendar.OwnerDraw = true;
      this.menuItemFiscalCalendar.Text = "&Fiscal Calendar";
      this.menuItemFiscalCalendar.Click += new EventHandler(this.menuItemFiscalCalendar_Click);
      this.menuItemGLCodes.ImageIndex = -1;
      this.menuItemGLCodes.ImageList = (ImageList) null;
      this.menuItemGLCodes.Index = 2;
      this.menuItemGLCodes.NoEdit = false;
      this.menuItemGLCodes.NoUIModify = false;
      this.menuItemGLCodes.OriginalText = "";
      this.menuItemGLCodes.OwnerDraw = true;
      this.menuItemGLCodes.Text = "&GL Codes";
      this.menuItemGLCodes.Click += new EventHandler(this.menuItemGLCodes_Click);
      this.menuItemVATCodes.ImageIndex = -1;
      this.menuItemVATCodes.ImageList = (ImageList) null;
      this.menuItemVATCodes.Index = 3;
      this.menuItemVATCodes.NoEdit = false;
      this.menuItemVATCodes.NoUIModify = false;
      this.menuItemVATCodes.OriginalText = "";
      this.menuItemVATCodes.OwnerDraw = true;
      this.menuItemVATCodes.Text = "&VAT Codes";
      this.menuItemVATCodes.Click += new EventHandler(this.menuItemVATCodes_Click);
      this.menuItemChargeCodes.ImageIndex = -1;
      this.menuItemChargeCodes.ImageList = (ImageList) null;
      this.menuItemChargeCodes.Index = 4;
      this.menuItemChargeCodes.NoEdit = false;
      this.menuItemChargeCodes.NoUIModify = false;
      this.menuItemChargeCodes.OriginalText = "";
      this.menuItemChargeCodes.OwnerDraw = true;
      this.menuItemChargeCodes.Text = "&Charge Codes";
      this.menuItemChargeCodes.Click += new EventHandler(this.menuItemChargeCodes_Click);
      this.menuItemLogs.ImageIndex = -1;
      this.menuItemLogs.ImageList = (ImageList) null;
      this.menuItemLogs.Index = 3;
      this.menuItemLogs.MenuItems.AddRange(new MenuItem[4]
      {
        (MenuItem) this.menuItemChargeBatchLog,
        (MenuItem) this.menuItemReceiptBatchLog,
        (MenuItem) this.menuItemAllocationLog,
        (MenuItem) this.menuItemChangesLog
      });
      this.menuItemLogs.NoEdit = false;
      this.menuItemLogs.NoUIModify = false;
      this.menuItemLogs.OriginalText = "";
      this.menuItemLogs.OwnerDraw = true;
      this.menuItemLogs.Text = "L&ogs";
      this.menuItemDesignTemplates.ImageIndex = -1;
      this.menuItemDesignTemplates.ImageList = (ImageList) null;
      this.menuItemDesignTemplates.Index = 4;
      this.menuItemDesignTemplates.NoEdit = false;
      this.menuItemDesignTemplates.NoUIModify = false;
      this.menuItemDesignTemplates.OriginalText = "";
      this.menuItemDesignTemplates.OwnerDraw = true;
      this.menuItemDesignTemplates.Text = "&Design Templates";
      this.menuItemDesignTemplates.Click += new EventHandler(this.menuItemDesignTemplates_Click);
      this.menuItemChargeBatchLog.ImageIndex = -1;
      this.menuItemChargeBatchLog.ImageList = (ImageList) null;
      this.menuItemChargeBatchLog.Index = 0;
      this.menuItemChargeBatchLog.NoEdit = false;
      this.menuItemChargeBatchLog.NoUIModify = false;
      this.menuItemChargeBatchLog.OriginalText = "";
      this.menuItemChargeBatchLog.OwnerDraw = true;
      this.menuItemChargeBatchLog.Text = "&Charge Batch";
      this.menuItemChargeBatchLog.Click += new EventHandler(this.menuItemChargeBatchLog_Click);
      this.menuItemReceiptBatchLog.ImageIndex = -1;
      this.menuItemReceiptBatchLog.ImageList = (ImageList) null;
      this.menuItemReceiptBatchLog.Index = 1;
      this.menuItemReceiptBatchLog.NoEdit = false;
      this.menuItemReceiptBatchLog.NoUIModify = false;
      this.menuItemReceiptBatchLog.OriginalText = "";
      this.menuItemReceiptBatchLog.OwnerDraw = true;
      this.menuItemReceiptBatchLog.Text = "&Transaction Batch";
      this.menuItemReceiptBatchLog.Click += new EventHandler(this.menuItemReceiptBatchLog_Click);
      this.menuItemAllocationLog.ImageIndex = -1;
      this.menuItemAllocationLog.ImageList = (ImageList) null;
      this.menuItemAllocationLog.Index = 2;
      this.menuItemAllocationLog.NoEdit = false;
      this.menuItemAllocationLog.NoUIModify = false;
      this.menuItemAllocationLog.OriginalText = "";
      this.menuItemAllocationLog.OwnerDraw = true;
      this.menuItemAllocationLog.Text = "&Allocation Log";
      this.menuItemAllocationLog.Click += new EventHandler(this.menuItemAllocationLog_Click);
      this.menuItemChangesLog.ImageIndex = -1;
      this.menuItemChangesLog.ImageList = (ImageList) null;
      this.menuItemChangesLog.Index = 3;
      this.menuItemChangesLog.NoEdit = false;
      this.menuItemChangesLog.NoUIModify = false;
      this.menuItemChangesLog.OriginalText = "";
      this.menuItemChangesLog.OwnerDraw = true;
      this.menuItemChangesLog.Text = "Chang&es";
      this.menuItemChangesLog.Click += new EventHandler(this.menuItemChangesLog_Click);
      this.menuItemFeesBillingRoutines.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemClearanceRoutines
      });
      this.menuItemClearanceRoutines.ImageIndex = -1;
      this.menuItemClearanceRoutines.ImageList = (ImageList) null;
      this.menuItemClearanceRoutines.Index = 0;
      this.menuItemClearanceRoutines.NoEdit = false;
      this.menuItemClearanceRoutines.NoUIModify = false;
      this.menuItemClearanceRoutines.OriginalText = "";
      this.menuItemClearanceRoutines.OwnerDraw = true;
      this.menuItemClearanceRoutines.Text = "&Clearance Routines";
      this.menuItemClearanceRoutines.Click += new EventHandler(this.menuItemClearanceRoutines_Click);
      this.menuItemClearanceRoutines.Visible = false;
      this.menuItemImportChartOfAccounts.ImageIndex = -1;
      this.menuItemImportChartOfAccounts.ImageList = (ImageList) null;
      this.menuItemImportChartOfAccounts.Index = 1;
      this.menuItemImportChartOfAccounts.NoEdit = false;
      this.menuItemImportChartOfAccounts.NoUIModify = false;
      this.menuItemImportChartOfAccounts.OriginalText = "";
      this.menuItemImportChartOfAccounts.OwnerDraw = true;
      this.menuItemImportChartOfAccounts.Text = "&Import Chart Of Accounts";
      this.menuItemImportChartOfAccounts.Click += new EventHandler(this.menuItemImportChartOfAccounts_Click);
      this.menuItemParameters.ImageIndex = -1;
      this.menuItemParameters.ImageList = (ImageList) null;
      this.menuItemParameters.Index = 0;
      this.menuItemParameters.NoEdit = false;
      this.menuItemParameters.NoUIModify = false;
      this.menuItemParameters.OriginalText = "";
      this.menuItemParameters.OwnerDraw = true;
      this.menuItemParameters.Text = "&Parameters";
      this.menuItemParameters.Click += new EventHandler(this.menuItemParameters_Click);
      this.menuItemChargeCodeSetup.ImageIndex = -1;
      this.menuItemChargeCodeSetup.ImageList = (ImageList) null;
      this.menuItemChargeCodeSetup.Index = 1;
      this.menuItemChargeCodeSetup.NoEdit = false;
      this.menuItemChargeCodeSetup.NoUIModify = false;
      this.menuItemChargeCodeSetup.OriginalText = "";
      this.menuItemChargeCodeSetup.OwnerDraw = true;
      this.menuItemChargeCodeSetup.Text = "&Charge Code";
      this.menuItemChargeCodeSetup.Click += new EventHandler(this.menuItemChargeCodeSetup_Click);
      this.menuItemGeneralLedgerAccounts.ImageIndex = -1;
      this.menuItemGeneralLedgerAccounts.ImageList = (ImageList) null;
      this.menuItemGeneralLedgerAccounts.Index = 2;
      this.menuItemGeneralLedgerAccounts.NoEdit = false;
      this.menuItemGeneralLedgerAccounts.NoUIModify = false;
      this.menuItemGeneralLedgerAccounts.OriginalText = "";
      this.menuItemGeneralLedgerAccounts.OwnerDraw = true;
      this.menuItemGeneralLedgerAccounts.Text = "&General Ledger Codes";
      this.menuItemGeneralLedgerAccounts.Click += new EventHandler(this.menuItemGeneralLedgerAccounts_Click);
      this.menuItemInterestRates.ImageIndex = -1;
      this.menuItemInterestRates.ImageList = (ImageList) null;
      this.menuItemInterestRates.Index = 3;
      this.menuItemInterestRates.NoEdit = false;
      this.menuItemInterestRates.NoUIModify = false;
      this.menuItemInterestRates.OriginalText = "";
      this.menuItemInterestRates.OwnerDraw = true;
      this.menuItemInterestRates.Text = "&Interest Rates";
      this.menuItemInterestRates.Click += new EventHandler(this.menuItemInterestRates_Click);
      this.menuItemVAT.ImageIndex = -1;
      this.menuItemVAT.ImageList = (ImageList) null;
      this.menuItemVAT.Index = 4;
      this.menuItemVAT.NoEdit = false;
      this.menuItemVAT.NoUIModify = false;
      this.menuItemVAT.OriginalText = "";
      this.menuItemVAT.OwnerDraw = true;
      this.menuItemVAT.Text = "&VAT";
      this.menuItemVAT.Click += new EventHandler(this.menuItemVAT_Click);
      this.menuItemTransactionType.ImageIndex = -1;
      this.menuItemTransactionType.ImageList = (ImageList) null;
      this.menuItemTransactionType.Index = 5;
      this.menuItemTransactionType.NoEdit = false;
      this.menuItemTransactionType.NoUIModify = false;
      this.menuItemTransactionType.OriginalText = "";
      this.menuItemTransactionType.OwnerDraw = true;
      this.menuItemTransactionType.Text = "&Transaction Type";
      this.menuItemTransactionType.Click += new EventHandler(this.menuItemTransactionType_Click);
      this.menuItemFiscalYear.ImageIndex = -1;
      this.menuItemFiscalYear.ImageList = (ImageList) null;
      this.menuItemFiscalYear.Index = 6;
      this.menuItemFiscalYear.NoEdit = false;
      this.menuItemFiscalYear.NoUIModify = false;
      this.menuItemFiscalYear.OriginalText = "";
      this.menuItemFiscalYear.OwnerDraw = true;
      this.menuItemFiscalYear.Text = "&Fiscal Calendar";
      this.menuItemFiscalYear.Click += new EventHandler(this.menuItemFiscalYear_Click);
      this.menuItemPaymentType.ImageIndex = -1;
      this.menuItemPaymentType.ImageList = (ImageList) null;
      this.menuItemPaymentType.Index = 7;
      this.menuItemPaymentType.NoEdit = false;
      this.menuItemPaymentType.NoUIModify = false;
      this.menuItemPaymentType.OriginalText = "";
      this.menuItemPaymentType.OwnerDraw = true;
      this.menuItemPaymentType.Text = "Pay&ment Type";
      this.menuItemPaymentType.Click += new EventHandler(this.menuItemPaymentType_Click);
      this.menuItemFeesBillingTools.MenuItems.AddRange(new MenuItem[8]
      {
        (MenuItem) this.menuItemParameters,
        (MenuItem) this.menuItemChargeCodeSetup,
        (MenuItem) this.menuItemGeneralLedgerAccounts,
        (MenuItem) this.menuItemVAT,
        (MenuItem) this.menuItemTransactionType,
        (MenuItem) this.menuItemFiscalYear,
        (MenuItem) this.menuItemPaymentType,
        (MenuItem) this.menuItemImportChartOfAccounts
      });
    }

    private void addFeesContextLinks()
    {
      if (SIMS.Entities.Cache.ProcessVisible("FeesDetailsView"))
      {
        NavigationRouteCache.AddRoute("Fees Details", new NavigationRouteDelegate(this.ContextFeesStudentDetailsOverview), new int[1]
        {
          44
        }, typeof (FeesStudentDetail), 44);
        if (SIMS.Entities.Cache.ProcessVisible("FeesFeesDetailsEdit"))
          NavigationRouteCache.AddRoute("Student Details", new NavigationRouteDelegate(this.ContextEditStudentDetailsOverview), new int[1]
          {
            44
          }, typeof (EditStudent));
        if (SIMS.Entities.Cache.ProcessVisible("FeesFeesDetailsEdit") && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
          NavigationRouteCache.AddRoute("Linked Documents", new NavigationRouteDocumentDelegate(this.ContextPersonLinkedDocuments), new int[1]
          {
            44
          }, typeof (ManageEntityDocuments));
        if (SIMS.Entities.Cache.ProcessVisible("RunReport") && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
          NavigationRouteCache.AddRoute("Reports", new NavigationRouteDelegate(this.ContextReportStudent), new int[1]
          {
            44
          }, typeof (ContextReport));
        if (SIMS.Entities.Cache.ProcessVisible("FeesFeesDetailsEdit") && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
          NavigationRouteCache.AddRoute("Linked Documents", new NavigationRouteDocumentDelegate(this.ContextPersonLinkedDocuments), new int[1]
          {
            45
          }, typeof (ManageEntityDocuments));
        if (SIMS.Entities.Cache.ProcessVisible("RunReport") && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
          NavigationRouteCache.AddRoute("Reports", new NavigationRouteDelegate(this.ContextReportStudent), new int[1]
          {
            45
          }, typeof (ContextReport));
        if (SIMS.Entities.Cache.ProcessVisible("FeesFeesDetailsEdit") && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
          NavigationRouteCache.AddRoute("Linked Documents", new NavigationRouteDocumentDelegate(this.ContextPersonLinkedDocuments), new int[1]
          {
            46
          }, typeof (ManageEntityDocuments));
        if (SIMS.Entities.Cache.ProcessVisible("RunReport") && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
          NavigationRouteCache.AddRoute("Reports", new NavigationRouteDelegate(this.ContextReportStudent), new int[1]
          {
            46
          }, typeof (ContextReport));
        if (SIMS.Entities.Cache.ProcessVisible("FeesAmendBillDetailRun"))
        {
          NavigationRouteCache.AddRoute("Amend Bill Details", new NavigationRouteDelegate(this.ContextFeesAmendBillDetailsOverview), new int[1]
          {
            46
          }, typeof (FeesAmendBillDetail));
          NavigationRouteCache.AddRoute("Amend Bill Details", new NavigationRouteDelegate(this.ContextFeesAmendBillDetailsOverview), new int[1]
          {
            45
          }, typeof (FeesAmendBillDetail));
        }
        if (SIMS.Entities.Cache.ProcessVisible("EditContact"))
          NavigationRouteCache.AddRoute("As Contact", new NavigationRouteDelegate(this.ContextContact), new int[1]
          {
            47
          }, typeof (ContactDetails), 3);
        if (SIMS.Entities.Cache.ProcessVisible("FeesFeesDetailsEdit") && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
          NavigationRouteCache.AddRoute("Linked Documents", new NavigationRouteDocumentDelegate(this.ContextPersonLinkedDocuments), new int[1]
          {
            47
          }, typeof (ManageEntityDocuments));
        if (SIMS.Entities.Cache.ProcessVisible("RunReport"))
          NavigationRouteCache.AddRoute("Quick Letter", new NavigationRouteDelegate(this.ContextLetterBillPayer), new int[1]
          {
            47
          }, typeof (ContextReport));
        if (SIMS.Entities.Cache.ProcessVisible("RunReport") && SIMS.Entities.Cache.CurrentDatabase.DatabaseMode.ToString() != DatabaseModeEnum.Offline.ToString())
          NavigationRouteCache.AddRoute("Reports", new NavigationRouteDelegate(this.ContextReportStudent), new int[1]
          {
            47
          }, typeof (ContextReport));
        if (SIMS.Entities.Cache.ProcessVisible("EditContact"))
          NavigationRouteCache.AddRoute("As Bill Payer", new NavigationRouteDelegate(this.ContextBillPayer), new int[1]
          {
            3
          }, typeof (FeesBillPayerDetail), 47);
        if (SIMS.Entities.Cache.ProcessVisible("ViewCommunications"))
          NavigationRouteCache.AddRoute("Communication", new NavigationRouteDelegate(this.ContextCommunication), new int[1]
          {
            44
          }, typeof (CommunicationContainer), 50);
        NavigationRouteCache.AddRoute("Fees Student Details", new NavigationRouteDelegate(this.ContextFeesStudentDetailsOverview), new int[1]
        {
          46
        }, typeof (FeesStudentDetail), 46);
        NavigationRouteCache.AddRoute("Fees Bill Payer Details", new NavigationRouteDelegate(this.ContextBillPayer), new int[1]
        {
          47
        }, typeof (FeesBillPayerDetail), 47);
        if (SIMS.Entities.FeesCache.ParameterGLAccountSetting.FeeControlAccountAttribute != null && SIMS.Entities.FeesCache.ParameterGLAccountSetting.FeeControlAccountAttribute.Value != null)
          NavigationRouteCache.AddRoute("Change Fees Control", new NavigationRouteDelegate(this.ContextFeesChangeControlAccount), new int[1]
          {
            74
          }, typeof (DlgChangeFeesControl), 74);
      }
      if (SIMS.Entities.Cache.ProcessAvailable("FeesApplyChargeView"))
        NavigationRouteCache.AddRoute("Fees Apply Charges Details", new NavigationRouteDelegate(this.ContextFeesApplyChargesDetailsOverview), new int[1]
        {
          79
        }, typeof (FeesApplyChargesDetailNew), 79);
      ActiveReportInterfaceManager.DisplayReport += new DisplayActiveReportDelegate(this.ActiveReportInterfaceManager_DisplayReport);
      CommunicationDetail.AddCommunicationContext("FEES STUDENT DETAILS", 46);
      CommunicationDetail.AddCommunicationContext("FEES BILL PAYER", 47);
    }

    private ActiveReportsViewerContainer ActiveReportInterfaceManager_DisplayReport(
      ActiveReport report,
      string caption)
    {
      ActiveReportsViewerContainer reportsViewerContainer = new ActiveReportsViewerContainer(report, caption);
      AbstractComponentWindow abstractComponentWindow = new AbstractComponentWindow((AbstractContainerControl) reportsViewerContainer);
      abstractComponentWindow.Visible = false;
      int num = (int) abstractComponentWindow.ShowDialog((IWin32Window) this);
      return reportsViewerContainer;
    }

    private void rebuildFeesMenus()
    {
      if (!SIMS.Entities.PersonCache.Initialised)
        SIMS.Processes.PersonCache.Populate();
      if (!SIMS.Entities.FeesCache.Initialised)
        SIMS.Processes.FeesCache.Populate();
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemFiscalYear, new string[1]
      {
        "FeesFiscalCalendarView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGeneralLedgerAccounts, new string[1]
      {
        "FeesGeneralLedgerView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPaymentType, new string[1]
      {
        "FeesPaymentTypeView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemTransactionType, new string[1]
      {
        "FeesTransactionTypeView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemInterestRates, new string[1]
      {
        "FeesInterestRateView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemVAT, new string[1]
      {
        "FeesVatCodeView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemParameters, new string[1]
      {
        "FeesParameterGeneralView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemChargeCodeSetup, new string[1]
      {
        "FeesChargeCodeView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemEditBillPayer, new string[1]
      {
        "FeesBillPayerView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemApplyCharges, new string[1]
      {
        "FeesApplyChargeView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemChargeBatchReport, new string[1]
      {
        "FeesChargeBatchReportView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUpdateBills, new string[1]
      {
        "FeesUpdateBillUpdate"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAmendBillDetails, new string[1]
      {
        "FeesAmendBillDetailRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGlobalUpdateOfCharges, new string[1]
      {
        "FeesGlobalUpdateUpdate"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSurchargeCalculation, new string[1]
      {
        "MaintainSurcharge"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemApplyRefund, new string[1]
      {
        "FeesApplyChargeView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAddNotesToBill, new string[1]
      {
        "FeesAddNotesToBillUpdate"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPrintBills, new string[1]
      {
        "FeesPrintBillRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCopyBills, new string[1]
      {
        "FeesCopyBillView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPreviousBills, new string[1]
      {
        "FeesPreviousBillView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCancelBills, new string[1]
      {
        "FeesCancelBillsEdit"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCancelBillsReport, new string[1]
      {
        "FeesCancelBillsReportEdit"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAssignBillNumbers, new string[1]
      {
        "FeesAssignBillNumberUpdate"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMiscellaneousChargeSheet, new string[1]
      {
        "FeesMiscellaneousChargeSheetView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemTransferBills, new string[1]
      {
        "FeesTransferBillRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemTermEnd, new string[1]
      {
        "FeesBillingTermAdd"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItem49menuItemProcessTransaction, new string[1]
      {
        "FeesTransactionBatchView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAuditReport, new string[1]
      {
        "FeesTransactionAuditReportView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAllocateTransactions, new string[1]
      {
        "FeesUnallocateTransactionView"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemDDInstalmentSchedule, new string[1]
      {
        "FeesParameterDDEdit"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSOInstalmentSchedule, new string[1]
      {
        "FeesParameterSOEdit"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBACSGeneration, new string[1]
      {
        "FeesParameterDDEdit"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUpdatePayers, new string[1]
      {
        "FeesUpdatePayersUpdate"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemRefundCreditBalances, new string[1]
      {
        "FeesCreditRefundDetail"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBillAudit, new string[1]
      {
        "FeesBillingAuditReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemChargesAudit, new string[1]
      {
        "FeesBillingAuditReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCrossReference, new string[1]
      {
        "FeesCrossReferenceReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemException, new string[1]
      {
        "FeesBillingExceptionReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemControlAccount, new string[1]
      {
        "FeesControlAccountReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAgedDebtors, new string[1]
      {
        "FeesAgedDebtorReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGLReconcilation, new string[1]
      {
        "FeesGlReconciliationReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemStatementDetails, new string[1]
      {
        "FeesProduceStatementRun"
      });
      if (SIMS.Entities.Cache.ProcessAvailable("FeesBillPayerView"))
      {
        SIMS.Processes.PersonCache.Populate();
        SIMS.Processes.FeesCache.Populate();
        if (SIMS.Entities.FeesCache.Initialised && !SIMS.Processes.FeesCache.ShowGlInterfaceReport())
          this.menuItemGLInterface.Visible = false;
      }
      else
        this.menuItemGLInterface.Visible = false;
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemTransactionList, new string[1]
      {
        "FeesTransactionReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUnallocatedTransactions, new string[1]
      {
        "FeesUnallocatedTransactionReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemTransactionTypes, new string[1]
      {
        "FeesTransactionTypeReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemFiscalCalendar, new string[1]
      {
        "FeesFiscalCalendarReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemGLCodes, new string[1]
      {
        "FeesGLCodeReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemVATCodes, new string[1]
      {
        "FeesVATReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemChargeCodes, new string[1]
      {
        "FeesChargeCodeReportRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemChargeBatchLog, new string[1]
      {
        "FeesChargesBatchLogRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemReceiptBatchLog, new string[1]
      {
        "FeesTransactionBatchLogRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAllocationLog, new string[1]
      {
        "FeesAllocationLogRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemChangesLog, new string[1]
      {
        "FeesChangesLogRun"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemDesignTemplates, new string[2]
      {
        "FeesDesignTemplateDelete",
        "FeesDesignTemplateEdit"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemImportChartOfAccounts, new string[1]
      {
        "FeesImportChartOfAccountImport"
      });
    }

    private void menuItemAgedDebtors_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesAgedDebtorsBrowserDetail());
    }

    private void menuItemVAT_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesVATBrowserDetail());
    }

    private void menuItemPaymentType_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesPaymentTypeBrowserDetail());
    }

    private void menuItemInterestRates_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesInterestRatesBrowserDetail());
    }

    private void menuItemFiscalYear_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesFiscalYearBrowserDetail());
    }

    private void menuItemApplyCharges_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesApplyChargesNewBrowserDetail());
    }

    private void menuItemSurchargeCalculation_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SurchargeConatiner());
    }

    private void menuItemApplyRefund_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesApplyRefundBrowserDetail());
    }

    private void menuItemChargeCodeSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesChargeCodeBrowserDetail());
    }

    private void menuItemGeneralLedgerAccounts_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesGLCodeBrowserDetail());
    }

    private void menuItemChargeBatchReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesChargeBatchReportBrowserDetail());
    }

    private void menuItemChargeBatchLog_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesChargeBatchLogDetail());
    }

    private void menuItemAssignBillNumbers_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesAssignBillNumberBrowserDetail());
    }

    private void menuItemGlobalUpdateOfCharges_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesGlobalUpdateChargesBrowserDetail());
    }

    private void menuItemTransactionTypes_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      FeesReportProcess feesReportProcess = new FeesReportProcess(FeesEntityReportEnum.TransactionTypes);
      feesReportProcess.Load();
      ActiveReportInterfaceManager.ShowReport((ActiveReport) new ActiveReportTrasactionTypes(feesReportProcess.ds), "Transaction Types Report");
    }

    private void menuItemFiscalCalendar_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesFiscalYearBrowser()
      {
        browserType = FeesFiscalYearBrowserEnum.FiscalYearReport
      });
    }

    private void menuItemGLCodes_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesGLCodeBrowser()
      {
        browserType = FeesGLCodeBrowserEnum.GLCodeReport
      });
    }

    private void menuItemVATCodes_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.Cursor = Cursors.WaitCursor;
      FeesReportProcess feesReportProcess = new FeesReportProcess(FeesEntityReportEnum.VATCodes);
      feesReportProcess.Load();
      ActiveReportInterfaceManager.ShowReport((ActiveReport) new ActiveReportVATCodes(feesReportProcess.ds), "VAT Codes Report");
      this.Cursor = Cursors.Default;
    }

    private void menuItemChargeCodes_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesChargeCodeBrowser()
      {
        browserType = FeesChargeCodeBrowserEnum.ChargeCodeReport
      });
    }

    private void menuItemDesignTemplates_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      SIMS.Processes.FeesCustomReportDetail customReportDetail = new SIMS.Processes.FeesCustomReportDetail();
      if (!SIMS.Entities.Cache.ProcessAvailable("EditDocumentServer"))
        SIMS.Entities.Cache.StatusMessage("You dont have permission to run a document server", UserMessageEventEnum.Error);
      else if (CheckDMSAvailability.CheckIsDMSAvailable())
      {
        if (!SIMS.Entities.FeesCache.ParameterBilling.UseTemplateV2)
        {
          if (!customReportDetail.GetBaseTemplates())
          {
            int num1 = (int) MessageBox.Show("Unable to download the Base Template file. Please close the application and then open it again.", SIMS.Entities.Cache.ApplicationName);
          }
          else if (!customReportDetail.GetAllBaseDotFiles())
          {
            int num2 = (int) MessageBox.Show("Unable to download the Base Template file. Please close the application and then open it again.", SIMS.Entities.Cache.ApplicationName);
          }
          else if (PrepareWord.InsertINIFileForWord(System.Windows.Forms.Application.StartupPath))
          {
            this.DisplayComponent((Control) new FeesCustomReportBrowserDetail());
          }
          else
          {
            int num3 = (int) MessageBox.Show("Unable to setup the Office path. Please associate the <.doc> files to Microsoft Word application and <.xls> files to Microsoft Excel application.", SIMS.Entities.Cache.ApplicationName);
          }
        }
        else
          this.DisplayComponent((Control) new FeesCustomReportBrowserDetail());
      }
      else
      {
        int num4 = (int) MessageBox.Show("Unable to find a document server. Please check in Tools, System Setup", SIMS.Entities.Cache.ApplicationName);
      }
    }

    private void menuItemMiscellaneousChargeSheet_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesMiscChargeSheetBrowserDetail());
    }

    private void menuItemPrintBills_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesPrintBillBrowserDetail());
    }

    private void menuItemUpdateBills_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesUpdateBillsBrowserDetail());
    }

    private void menuItemTransactionType_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesTransTypeBrowserDetail());
    }

    private void menuItemAmendBillDetails_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesAmendBillBrowserDetail());
    }

    private void menuItemAddNotesToBill_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesAddNotesBrowserDetail());
    }

    private void menuItemAddDDInstructionToBill_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesAddDirectDebitBrowserDetail());
    }

    private void menuItemCopyBills_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesCopyBillBrowserDetail());
    }

    private void menuItemPupil_Click(object sender, EventArgs e)
    {
    }

    private void menuItemReceiptBatchLog_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesReceiptsBatchLogDetail());
    }

    private void menuItemChangesLog_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesChangeLogDetail());
    }

    private void menuItemUpdatePayers_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesUpdatePayerBrowserDetail());
    }

    private void menuItemRefundCreditBalances_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesCreditRefundBrowserDetail());
    }

    private void menuItemProcessTransaction_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesProcessTransactionsBrowserDetail());
    }

    private void menuItemAllocationLog_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesAllocationLogBrowserDetail());
    }

    private void menuItemAuditReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesAuditReportBrowserDetail());
    }

    private void menuItemDirectDebitSchedules_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesDirectDebitPaymentScheduleBrowserDetail());
    }

    private void menuItemStatementDetails_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesStatementBrowserDetail());
    }

    private void menuItemAllocateTransactions_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesAllocateUnallocatedTransBrowserDetail());
    }

    private void menuItemPreviousBills_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesPreviousBillBrowserDetail());
    }

    private void menuItemCancelBills_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesCancelBillsBrowserDetail());
    }

    private void menuItemTermEnd_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesBillingTermDetail());
    }

    private void menuItemTransferBills_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesTransferBillsBrowserDetail());
    }

    private void menuItemEditBillPayer_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesBillPayerBrowserDetail());
    }

    private void menuItemTransactionList_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesTranscationListBrowserDetail());
    }

    private void menuItemParameters_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesParametersDetail());
    }

    private void menuItemCrossReference_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesCrossReferenceDetail());
    }

    private void menuItemProcessStandingOrders_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesProcessStandingOrdersBrowserDetail());
    }

    private void menuItemClearanceRoutines_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesClearanceDetail());
    }

    private void menuItemException_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesExceptionReportsBrowserDetail());
    }

    private void menuItemCancelBillsReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesCancelBillsReportBrowserDetail());
    }

    private void menuItemControlAccount_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.Cursor = Cursors.WaitCursor;
      FeesReportProcess feesReportProcess = new FeesReportProcess(FeesEntityReportEnum.ControlAccount);
      feesReportProcess.Load();
      if (SIMS.Entities.FeesCache.ParameterIncome.MonthEndProcessing)
        ActiveReportInterfaceManager.ShowReport((ActiveReport) new ActiveReportControlAccountWithMonthEnd(feesReportProcess.ds), "Control Account Report");
      else
        ActiveReportInterfaceManager.ShowReport((ActiveReport) new ActiveReportControlAccount(feesReportProcess.ds), "Control Account Report");
      this.Cursor = Cursors.Default;
    }

    private void menuItemDirectDebitMandate_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesDirectDebitMandateBrowserDetail("Direct Debit Mandate Letter", FeesDirectDebitReportEnum.MandateLetter));
    }

    private void menuItemProcessDirectDebit_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesDirectDebitBACSBrowserDetail());
    }

    private void menuItemDirectDebitCalculateInstalment_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesDirectDebitCalculationBrowserDetail());
    }

    private void menuItemListInstallments_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesDirectDebitListInstallmentsBrowserDetail("List Instalments", FeesDirectDebitReportEnum.ListInstallments));
    }

    private void menuItemListDirectDebtors_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesDirectDebitListDirectDebtorsBrowserDetail("List Direct Debits", FeesDirectDebitReportEnum.ListDirectDebtors));
    }

    private void menuItemUnallocatedTransactions_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesUnallocatedTransactionsBrowserDetail());
    }

    private void menuItemGLInterface_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.Cursor = Cursors.WaitCursor;
      FeesReportProcess feesReportProcess = new FeesReportProcess(FeesEntityReportEnum.GLInterface);
      feesReportProcess.Load();
      if (feesReportProcess.ds != null)
        ActiveReportInterfaceManager.ShowReport((ActiveReport) new ActiveReportGLInterface(feesReportProcess.ds, FeesEntityReportEnum.GLInterface), "GL Interface Report");
      this.Cursor = Cursors.Default;
    }

    private void menuItemGLReconcilation_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesGLReconcilationBrowserDetail());
    }

    private void menuItemImportChartOfAccounts_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesImportChartOfAccountsDetail());
    }

    private void menuItemDirectDebitClearInstallments_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesDirectDebitCancelInstallmentBrowserDetail());
    }

    private void menuItemDirectDebitAuddisSetUp_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesDirectDebitAuddisSetUpBrowserDetail());
    }

    private void menuItemDirectDebitAuddisFileGeneration_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesDirectDebitAuddisFileGenerationBrowserDetail());
    }

    private void menuItemBillAudit_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesBillAuditBrowserDetail());
    }

    private void menuItemChargesAudit_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesChargesAuditBrowserDetail());
    }

    private void menuItemBAVBulkAddressValidation_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new BAVAddressBrowserDetail());
    }

    private void menuItemBAVOtherSchools_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (BAV_DlgCreateBatch bavDlgCreateBatch = new BAV_DlgCreateBatch(enumBAVBrowserType.OtherSchool))
      {
        int num = (int) bavDlgCreateBatch.ShowDialog();
      }
    }

    private void menuItemBAVApplicantsAndContacts_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (BAV_DlgCreateBatch bavDlgCreateBatch = new BAV_DlgCreateBatch(enumBAVBrowserType.Application))
      {
        int num = (int) bavDlgCreateBatch.ShowDialog();
      }
    }

    private void menuItemBAVStudentsAndContacts_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (BAV_DlgCreateBatch bavDlgCreateBatch = new BAV_DlgCreateBatch(enumBAVBrowserType.Student))
      {
        int num = (int) bavDlgCreateBatch.ShowDialog();
      }
    }

    private void menuItemBAVEnquierAddress_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (BAV_DlgCreateBatch bavDlgCreateBatch = new BAV_DlgCreateBatch(enumBAVBrowserType.Enquiry))
      {
        int num = (int) bavDlgCreateBatch.ShowDialog();
      }
    }

    private void menuItemBAVStaff_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (BAV_DlgCreateBatch bavDlgCreateBatch = new BAV_DlgCreateBatch(enumBAVBrowserType.StaffContact))
      {
        int num = (int) bavDlgCreateBatch.ShowDialog();
      }
    }

    private void menuItemBAVAgents_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (BAV_DlgCreateBatch bavDlgCreateBatch = new BAV_DlgCreateBatch(enumBAVBrowserType.Agent))
      {
        int num = (int) bavDlgCreateBatch.ShowDialog();
      }
    }

    private void menuItemBAVAgencies_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (BAV_DlgCreateBatch bavDlgCreateBatch = new BAV_DlgCreateBatch(enumBAVBrowserType.Agency))
      {
        int num = (int) bavDlgCreateBatch.ShowDialog();
      }
    }

    private void menuItemTidyAndMergeAddresses_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new AddressTidyandMergeWizard().ShowDialog((IWin32Window) this);
    }

    private void menuItemUnmatchableAddressesReport_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      new AddressTidyandMergeWizard().unmatchedAddressReport();
    }

    private void ContextCommunicationAmendBills(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl(entityToDisplay, (AbstractContainerControl) new CommunicationContainer(), showAsIndependentWindow);
    }

    private void ContextLetterBillPayer(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      new ContextReport("BillPayer", entityToDisplay.ID).RunQuickLetter();
    }

    private void ContextEditStudentDetailsOverview(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new EditStudent(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextFeesStudentDetailsOverview(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new FeesStudentDetail(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextFeesStudentDetailsRAOverview(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new FeesApplicationDetail(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextFeesAmendBillDetailsOverview(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new FeesAmendBillDetail(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextFeesApplyChargesDetailsOverview(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      using (Control component = (Control) new FeesApplyChargesDetailNew())
      {
        if (this.findExistingComponent((IIDEntity) null, component) != null)
        {
          SIMS.Entities.Cache.StatusMessage("Please make sure the Apply Charges screen is closed", UserMessageEventEnum.Error);
          return;
        }
      }
      this.ShowContextControl((BasicDetailControl) new FeesApplyChargesDetailNew(entityToDisplay), showAsIndependentWindow);
    }

    private void ContextFeesChangeControlAccount(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new DlgChangeFeesControl(), showAsIndependentWindow);
    }

    private void ContextBillPayer(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      if (entityToDisplay == null || entityToDisplay.Description == string.Empty || entityToDisplay.ID == 0)
        SIMS.Entities.Cache.StatusMessage("Contact Details Required. Please save/open contact details.", UserMessageEventEnum.Information);
      else
        this.ShowContextControl((BasicDetailControl) new FeesBillPayerDetail(entityToDisplay), showAsIndependentWindow);
    }

    private void buildAdmissionFocusBar()
    {
      this.menuItemEnquiry.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemEnquiry.ImageIndex = 165;
      this.launcher.AddFocusBarItem(this.menuItemEnquiry);
      this.menuItemApplication.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemApplication.ImageIndex = 164;
      this.launcher.AddFocusBarItem(this.menuItemApplication);
    }

    private void buildFeesFocusBar()
    {
      this.menuItemEditBillPayer.ImageList = StandardIcons.Get(StandardIcons.IconSizes.Size16);
      this.menuItemEditBillPayer.ImageIndex = 148;
      this.launcher.AddFocusBarItem(this.menuItemEditBillPayer);
    }

    private void menuItemFeesBillingRoutines_Popup(object sender, EventArgs e)
    {
      this.menuItemImportChartOfAccounts.Visible = true;
    }

    private void menuItemFeesBACS_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FeesDirectDebitBACSInstalmentBrowserDetail());
    }

    private void menuItemDDInstalmentSchedule_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.FeesInstalmentScheduleBrowserDetail", "Maintain Direct Debit Schedule") != null)
        return;
      this.DisplayNewComponent((Control) new FeesInstalmentScheduleBrowserDetail(false, "Maintain Direct Debit Schedule"));
    }

    private void menuItemSOInstalmentSchedule_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.FeesInstalmentScheduleBrowserDetail", "Maintain Standing Order Schedule") != null)
        return;
      this.DisplayNewComponent((Control) new FeesInstalmentScheduleBrowserDetail(true, "Maintain Standing Order Schedule"));
    }

    private void initADPMenus()
    {
      this.menuItemADProvisioning = new UIMenuItem();
      this.menuItemADProvisionUsers = new UIMenuItem();
      this.menuItemADProvisionGroups = new UIMenuItem();
      this.menuItemADPStudent = new UIMenuItem();
      this.menuItemADPAddStudents = new UIMenuItem();
      this.menuItemADPRemoveStudents = new UIMenuItem();
      this.menuItemADPReProvisionStudents = new UIMenuItem();
      this.menuItemADPContact = new UIMenuItem();
      this.menuItemADPAddContacts = new UIMenuItem();
      this.menuItemADPRemoveContacts = new UIMenuItem();
      this.menuItemADPReProvisionContacts = new UIMenuItem();
      this.menuItemADPStaff = new UIMenuItem();
      this.menuItemADPAddStaff = new UIMenuItem();
      this.menuItemADPRemoveStaff = new UIMenuItem();
      this.menuItemADPReProvisionStaff = new UIMenuItem();
      this.menuItemADPAgent = new UIMenuItem();
      this.menuItemADPAddAgent = new UIMenuItem();
      this.menuItemADPRemoveAgent = new UIMenuItem();
      this.menuItemADPReProvisionAgent = new UIMenuItem();
      this.menuItemADPReProvisionGroups = new UIMenuItem();
      this.menuItemADRegisterProvisioningService = new UIMenuItem();
      this.menuItemADViewFailedRequests = new UIMenuItem();
      this.menuItemRoutines.MenuItems.Add((MenuItem) this.menuItemADProvisioning);
      this.menuItemADProvisioning.MenuItems.Add((MenuItem) this.menuItemADProvisionUsers);
      this.menuItemADProvisioning.MenuItems.Add((MenuItem) this.menuItemADProvisionGroups);
      this.menuItemADProvisionUsers.MenuItems.Add((MenuItem) this.menuItemADPAgent);
      this.menuItemADPAgent.MenuItems.Add((MenuItem) this.menuItemADPAddAgent);
      this.menuItemADPAgent.MenuItems.Add((MenuItem) this.menuItemADPRemoveAgent);
      this.menuItemADPAgent.MenuItems.Add((MenuItem) this.menuItemADPReProvisionAgent);
      this.menuItemADProvisionUsers.MenuItems.Add((MenuItem) this.menuItemADPStudent);
      this.menuItemADPStudent.MenuItems.Add((MenuItem) this.menuItemADPAddStudents);
      this.menuItemADPStudent.MenuItems.Add((MenuItem) this.menuItemADPRemoveStudents);
      this.menuItemADPStudent.MenuItems.Add((MenuItem) this.menuItemADPReProvisionStudents);
      this.menuItemADProvisionUsers.MenuItems.Add((MenuItem) this.menuItemADPContact);
      this.menuItemADPContact.MenuItems.Add((MenuItem) this.menuItemADPAddContacts);
      this.menuItemADPContact.MenuItems.Add((MenuItem) this.menuItemADPRemoveContacts);
      this.menuItemADPContact.MenuItems.Add((MenuItem) this.menuItemADPReProvisionContacts);
      this.menuItemADProvisionUsers.MenuItems.Add((MenuItem) this.menuItemADPStaff);
      this.menuItemADPStaff.MenuItems.Add((MenuItem) this.menuItemADPAddStaff);
      this.menuItemADPStaff.MenuItems.Add((MenuItem) this.menuItemADPRemoveStaff);
      this.menuItemADPStaff.MenuItems.Add((MenuItem) this.menuItemADPReProvisionStaff);
      this.menuItemADProvisionGroups.MenuItems.Add((MenuItem) this.menuItemADPReProvisionGroups);
      this.menuItemADProvisioning.MenuItems.Add((MenuItem) this.menuItemADRegisterProvisioningService);
      this.menuItemADProvisioning.MenuItems.Add((MenuItem) this.menuItemADViewFailedRequests);
      this.menuItemADProvisioning.Text = "&Active Directory Provisioning";
      this.menuItemADRegisterProvisioningService.Index = 0;
      this.menuItemADRegisterProvisioningService.Text = "&Register Provisioning Service";
      this.menuItemADRegisterProvisioningService.Click += new EventHandler(this.menuItemADRegisterProvisioningService_Click);
      this.menuItemADProvisionUsers.Index = 1;
      this.menuItemADProvisionUsers.Text = "Provision &Users";
      this.menuItemADProvisionGroups.Index = 2;
      this.menuItemADProvisionGroups.Text = "Provision &Groups";
      this.menuItemADViewFailedRequests.Index = 3;
      this.menuItemADViewFailedRequests.Text = "View &Failed Requests";
      this.menuItemADViewFailedRequests.Click += new EventHandler(this.menuItemADViewFailedRequests_Click);
      this.menuItemADPStudent.Text = "&Students";
      this.menuItemADPAddStudents.Index = 0;
      this.menuItemADPAddStudents.Text = "&Add Students";
      this.menuItemADPAddStudents.Click += new EventHandler(this.menuItemADPAddStudents_Click);
      this.menuItemADPRemoveStudents.Index = 1;
      this.menuItemADPRemoveStudents.Text = "&Remove Students";
      this.menuItemADPRemoveStudents.Click += new EventHandler(this.menuItemADPRemoveStudents_Click);
      this.menuItemADPReProvisionStudents.Index = 2;
      this.menuItemADPReProvisionStudents.Text = "Re&Provision Students";
      this.menuItemADPReProvisionStudents.Click += new EventHandler(this.menuItemADPReProvisionStudents_Click);
      this.menuItemADPContact.Text = "&Contacts / Parents";
      this.menuItemADPAddContacts.Index = 0;
      this.menuItemADPAddContacts.Text = "&Add Contacts";
      this.menuItemADPAddContacts.Click += new EventHandler(this.menuItemADPAddContacts_Click);
      this.menuItemADPRemoveContacts.Index = 1;
      this.menuItemADPRemoveContacts.Text = "&Remove Contacts";
      this.menuItemADPRemoveContacts.Click += new EventHandler(this.menuItemADPRemoveContacts_Click);
      this.menuItemADPReProvisionContacts.Index = 2;
      this.menuItemADPReProvisionContacts.Text = "Re&Provision Contacts";
      this.menuItemADPReProvisionContacts.Click += new EventHandler(this.menuItemADPReProvisionContacts_Click);
      this.menuItemADPStaff.Text = "S&taff";
      this.menuItemADPAddStaff.Index = 0;
      this.menuItemADPAddStaff.Text = "&Add Staff";
      this.menuItemADPAddStaff.Click += new EventHandler(this.menuItemADPAddStaff_Click);
      this.menuItemADPRemoveStaff.Index = 1;
      this.menuItemADPRemoveStaff.Text = "&Remove Staff";
      this.menuItemADPRemoveStaff.Click += new EventHandler(this.menuItemADPRemoveStaff_Click);
      this.menuItemADPReProvisionStaff.Index = 2;
      this.menuItemADPReProvisionStaff.Text = "Re&Provision Staff";
      this.menuItemADPReProvisionStaff.Click += new EventHandler(this.menuItemADPReProvisionStaff_Click);
      this.menuItemADPAgent.Text = "&Agents";
      this.menuItemADPAddAgent.Index = 0;
      this.menuItemADPAddAgent.Text = "&Add Agent";
      this.menuItemADPAddAgent.Click += new EventHandler(this.menuItemADPAddAgent_Click);
      this.menuItemADPRemoveAgent.Index = 1;
      this.menuItemADPRemoveAgent.Text = "&Remove Agent";
      this.menuItemADPRemoveAgent.Click += new EventHandler(this.menuItemADPRemoveAgent_Click);
      this.menuItemADPReProvisionAgent.Index = 2;
      this.menuItemADPReProvisionAgent.Text = "Re&Provision Agents";
      this.menuItemADPReProvisionAgent.Click += new EventHandler(this.menuItemADPReProvisionAgent_Click);
      this.menuItemADPReProvisionGroups.Index = 0;
      this.menuItemADPReProvisionGroups.Text = "Re&Provision Groups";
      this.menuItemADPReProvisionGroups.Click += new EventHandler(this.menuItemADPReProvisionGroups_Click);
    }

    private void rebuildADPMenus()
    {
      this.menuItemADPAddStudents.Visible = SIMS.Entities.Cache.ProcessVisible("ADProvisionStudents");
      this.menuItemADPRemoveStudents.Visible = SIMS.Entities.Cache.ProcessVisible("ADProvisionStudents");
      this.menuItemADPReProvisionStudents.Visible = SIMS.Entities.Cache.ProcessVisible("ADReProvisionStudents");
      this.menuItemADPAddContacts.Visible = SIMS.Entities.Cache.ProcessVisible("ADProvisionContacts");
      this.menuItemADPRemoveContacts.Visible = SIMS.Entities.Cache.ProcessVisible("ADProvisionContacts");
      this.menuItemADPReProvisionContacts.Visible = SIMS.Entities.Cache.ProcessVisible("ADReProvisionContacts");
      this.menuItemADPAddStaff.Visible = SIMS.Entities.Cache.ProcessVisible("ADProvisionStaff");
      this.menuItemADPRemoveStaff.Visible = SIMS.Entities.Cache.ProcessVisible("ADProvisionStaff");
      this.menuItemADPReProvisionStaff.Visible = SIMS.Entities.Cache.ProcessVisible("ADReProvisionStaff");
      this.menuItemADPAddAgent.Visible = SIMS.Entities.Cache.ProcessVisible("ADProvisionAgents");
      this.menuItemADPRemoveAgent.Visible = SIMS.Entities.Cache.ProcessVisible("ADProvisionAgents");
      this.menuItemADPReProvisionAgent.Visible = SIMS.Entities.Cache.ProcessVisible("ADReProvisionAgents");
      this.menuItemADPReProvisionGroups.Visible = SIMS.Entities.Cache.ProcessVisible("ADProvisionGroups");
      this.menuItemADRegisterProvisioningService.Visible = SIMS.Entities.Cache.ProcessVisible("ADRegisterProvisioningService");
      this.menuItemADViewFailedRequests.Visible = SIMS.Entities.Cache.ProcessVisible("ADViewFailedRequests");
    }

    private void menuItemADPAddStudents_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADAddStudentsContainer());
    }

    private void menuItemADPRemoveStudents_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADManageProvisionedStudentsContainer());
    }

    private void menuItemADPReProvisionStudents_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADManageProvisionedStudentsContainer(OperationStatusEnum.ReProvision));
    }

    private void menuItemADPAddContacts_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADAddContactsContainer());
    }

    private void menuItemADPAddStaff_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADAddEmployeesContainer());
    }

    private void menuItemADPRemoveStaff_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADManageProvisionedEmployeesContainer());
    }

    private void menuItemADPReProvisionStaff_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADManageProvisionedEmployeesContainer(OperationStatusEnum.ReProvision));
    }

    private void menuItemADPAddAgent_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADAddAgentsContainer());
    }

    private void menuItemADPRemoveAgent_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADManageProvisionedAgentsContainer());
    }

    private void menuItemADPReProvisionAgent_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADManageProvisionedAgentsContainer(OperationStatusEnum.ReProvision));
    }

    private void menuItemADPReProvisionGroups_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADManageProvisionedGroupsContainer(OperationStatusEnum.ReProvision));
    }

    private void menuItemADPRemoveContacts_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADManageProvisionedContactsContainer());
    }

    private void menuItemADPReProvisionContacts_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADManageProvisionedContactsContainer(OperationStatusEnum.ReProvision));
    }

    private void menuItemADRegisterProvisioningService_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADRegisterProvisioningServiceDetails());
    }

    private void menuItemADViewFailedRequests_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new ADViewFailedRequestsContainer());
    }

    private void initSLGReportsMenus()
    {
      this.menuItemSLG = new UIMenuItem();
      this.menuItemOnlineReports = new UIMenuItem();
      this.menuItemDataCollectionSheet = new UIMenuItem();
      this.menuItemAssessmentGraphSetup = new UIMenuItem();
      this.menuItemRoutines.MenuItems.Add((MenuItem) this.menuItemSLG);
      this.menuItemSLG.MenuItems.Add((MenuItem) this.menuItemOnlineReports);
      this.menuItemSLG.MenuItems.Add((MenuItem) this.menuItemDataCollectionSheet);
      this.menuItemSLG.MenuItems.Add((MenuItem) this.menuItemAssessmentGraphSetup);
      this.menuItemSLG.Text = "SL&G && SIMS Online";
      this.menuItemOnlineReports.Index = 0;
      this.menuItemOnlineReports.Text = "&Publish Documents";
      this.menuItemOnlineReports.Click += new EventHandler(this.menuItemOnlineReports_Click);
      this.menuItemDataCollectionSheet.Index = 1;
      this.menuItemDataCollectionSheet.Text = "&Data Collection Sheet";
      this.menuItemDataCollectionSheet.Click += new EventHandler(this.menuItemDataCollectionSheet_Click);
      this.menuItemAssessmentGraphSetup.Index = 1;
      this.menuItemAssessmentGraphSetup.Text = "&Assessment Chart Setup";
      this.menuItemAssessmentGraphSetup.Click += new EventHandler(this.menuItemAssessmentGraphSetup_Click);
    }

    private void rebuildSLGReportsMenus()
    {
      bool flag = SIMS.Entities.Cache.ProcessAvailable("DocumentPublishProcess") && (SIMS.Entities.Cache.ProcessVisible("AssessmentReportTemplateProcess") || SIMS.Entities.Cache.ProcessAvailable("ProfilesReportTemplateProcess"));
      this.menuItemOnlineReports.Visible = flag;
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemDataCollectionSheet, "EditDataCollectionDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAssessmentGraphSetup, "SLGAssessmentGraphSetupProcess");
      this.menuItemSLG.Visible = flag || this.menuItemDataCollectionSheet.Visible;
    }

    private void menuItemOnlineReports_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new SLGReportsContainer());
    }

    private void menuItemDataCollectionSheet_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new StudentDataCollectionContainer());
    }

    private void menuItemAssessmentGraphSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new AssessmentGraphSetupContainer());
    }

    private void CustomiseSTARMenus()
    {
      if (SystemConfigurationCache.IsPrimarySchool || SystemConfigurationCache.IsIndependentSchool)
      {
        this.menuItemRoutinesStudents.Text = "P&upil";
        this.menuItemDeleteStudent.Text = "&Delete Pupil";
        this.MenuItemStudent.Text = "P&upil";
        this.MenuItemStudentEdit.Text = "P&upil Details";
        this.menuItemB2BStudent.Text = "B2B &Pupil";
        this.menuItemTeachersView.Text = "Pupil Teacher &View";
        this.menuItemTeachersViewSetup.Text = "Pupil Teacher &View";
      }
      else
      {
        this.menuItemRoutinesStudents.Text = "St&udent";
        this.menuItemDeleteStudent.Text = "&Delete Student";
        this.MenuItemStudent.Text = "&Student";
        this.MenuItemStudentEdit.Text = "&Student Details";
        this.menuItemB2BStudent.Text = "B2B &Student";
      }
      if (SystemConfigurationCache.IsNISchool)
      {
        this.menuItemExclusions.Text = "Sus&pensions";
        this.menuItemExclusions.OriginalText = "Sus&pensions";
      }
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemBulkAddressTools, new string[2]
      {
        "AddressTidyMergeProcess",
        "BAVScheduleAddresses"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBulkAddressValidationScheduler, "ScheduleWindowsTask");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBABulkAddressValidationSchedule, "BAVScheduleAddresses");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBABulkAddressValidation, "BAVAddressDetail");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBAVOtherSchools, "BAVOtherSchoolBrowser");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBAVApplicantsAndContacts, new string[2]
      {
        "ADMViewApplications",
        "BAVApplicationBrowser"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBAVStudentsAndContacts, "BAVBrowseStudents");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBAVEnquierAddress, new string[2]
      {
        "ADMViewEnquiries",
        "BAVEnquiryBrowser"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBAVStaff, "BAVBrowseStaff");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBAVAgents, "BAVBrowseAgent");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemBAVAgencies, "BAVBrowseAgency");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemTidyAndMergeAddresses, "AddressTidyMergeProcess");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemUnmatchableAddressesReport, "AddressTidyMergeProcess");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAddressTidyAndMergeSetup, "AddressTidyMergeProcess");
      this.menuItemHousekeeping.Visible = false;
      foreach (MenuItem menuItem in this.menuItemHousekeeping.MenuItems)
      {
        if (menuItem.Visible)
        {
          this.menuItemHousekeeping.Visible = true;
          break;
        }
      }
    }

    private void initCoverMenus()
    {
      this.menuItemClosureReasons = new UIMenuItem();
      this.menuItemAbsenceReasons = new UIMenuItem();
      this.menuItemRegisterRoomClosure = new UIMenuItem();
      this.menuItemManageCoverRota = new UIMenuItem();
      this.menuItemEditRoomClosure = new UIMenuItem();
      this.menuItemNonClassCodeRule = new UIMenuItem();
      this.menuItemCoverDairy = new UIMenuItem();
      this.menuItemStaffWeighting = new UIMenuItem();
      this.menuItemIdentifySupplyStaff = new UIMenuItem();
      this.menuItemSuspensionRule = new UIMenuItem();
      this.menuItemCoverDairyForRegisterAbsence = new UIMenuItem();
      this.menuItemCoverStatistics = new UIMenuItem();
      this.menuItemCoverAbsenceStatistics = new UIMenuItem();
      this.menuItemCoverCoverStatistics = new UIMenuItem();
      this.menuItemCoverAbsenceImpactReports = new UIMenuItem();
      this.menuItemClassesImpactedByAbsence = new UIMenuItem();
      this.menuItemStudentsImpactedByAbsence = new UIMenuItem();
      this.menuItemGlobalSetting = new UIMenuItem();
      this.menuItemCoverCreditSetting = new UIMenuItem();
      this.menuItemDetectTimetableChanges = new UIMenuItem();
      this.menuItemCurrOrganisations = new UIMenuItem();
      this.menuItemCurrBookings = new UIMenuItem();
      this.menuItemCurrDefineTimes = new UIMenuItem();
      this.menuItemCoverOrgBookings = new UIMenuItem();
      this.menuItemEmploymentParam = new UIMenuItem();
      this.menuItemCoverImportExamData = new UIMenuItem();
      this.menuItemCoverManageStaffLeavers = new UIMenuItem();
      this.menuItemSetups.MenuItems.Add((MenuItem) this.menuItemEmploymentParam);
      this.MenuItemSchool.MenuItems.Add((MenuItem) this.menuItemCoverDairy);
      this.menuItemCoverDairy.Text = "Arrange Co&ver";
      this.menuItemCoverDairy.Click += new EventHandler(this.menuItemCoverDairy_Click);
      this.menuItemCoverTools.MenuItems.AddRange(new MenuItem[15]
      {
        (MenuItem) this.menuItemDetectTimetableChanges,
        (MenuItem) this.menuItemIdentifySupplyStaff,
        (MenuItem) this.menuItemManageCoverRota,
        (MenuItem) this.menuItemSuspensionRule,
        (MenuItem) this.menuItemStaffWeighting,
        (MenuItem) this.menuItemAbsenceReasons,
        (MenuItem) this.menuItemClosureReasons,
        (MenuItem) this.menuItemNonClassCodeRule,
        (MenuItem) this.menuItemGlobalSetting,
        (MenuItem) this.menuItemCoverCreditSetting,
        (MenuItem) this.menuItemCoverStatistics,
        (MenuItem) this.menuItemCoverAbsenceImpactReports,
        (MenuItem) this.menuItemCoverOrgBookings,
        (MenuItem) this.menuItemCoverImportExamData,
        (MenuItem) this.menuItemCoverManageStaffLeavers
      });
      this.menuItemDetectTimetableChanges.Index = 0;
      this.menuItemDetectTimetableChanges.Text = "&Detect Timetable Changes";
      this.menuItemDetectTimetableChanges.Click += new EventHandler(this.menuItemDetectTimetableChanges_Click);
      this.menuItemIdentifySupplyStaff.Index = 1;
      this.menuItemIdentifySupplyStaff.Text = "I&dentify Agency Supply Staff";
      this.menuItemIdentifySupplyStaff.Click += new EventHandler(this.menuItemIdentifySupplyStaff_Click);
      this.menuItemManageCoverRota.Index = 2;
      this.menuItemManageCoverRota.Text = "Manage &Rotas";
      this.menuItemManageCoverRota.Click += new EventHandler(this.menuItemManageCoverRota_Click);
      this.menuItemSuspensionRule.Index = 3;
      this.menuItemSuspensionRule.Text = "Manage &Suspension Rules";
      this.menuItemSuspensionRule.Click += new EventHandler(this.menuItemuSuspensionRule_Click);
      this.menuItemStaffWeighting.Index = 5;
      this.menuItemStaffWeighting.Text = "Manage Staff &Weightings and Offsets";
      this.menuItemStaffWeighting.Click += new EventHandler(this.menuItemStaffWeighting_Click);
      this.menuItemAbsenceReasons.Index = 6;
      this.menuItemAbsenceReasons.Text = "Reasons for &Absence";
      this.menuItemAbsenceReasons.Click += new EventHandler(this.menuItemAbsenceReasons_Click);
      this.menuItemClosureReasons.Index = 7;
      this.menuItemClosureReasons.Text = "Reasons for &Closure";
      this.menuItemClosureReasons.Click += new EventHandler(this.menuItemClosureReasons_Click);
      this.menuItemNonClassCodeRule.Index = 8;
      this.menuItemNonClassCodeRule.Text = "&Non-class codes Cover Settings";
      this.menuItemNonClassCodeRule.Click += new EventHandler(this.menuItemNonClassCodeRule_Click);
      this.menuItemGlobalSetting.Index = 9;
      this.menuItemGlobalSetting.Text = "&Global Settings";
      this.menuItemGlobalSetting.Click += new EventHandler(this.menuItemGlobalSetting_Click);
      this.menuItemCoverCreditSetting.Index = 10;
      this.menuItemCoverCreditSetting.Text = "C&over Credit Setting";
      this.menuItemCoverCreditSetting.Click += new EventHandler(this.menuItemCoverCreditSetting_Click);
      this.menuItemCoverStatistics.Index = 11;
      this.menuItemCoverStatistics.Text = "S&tatistics";
      this.menuItemCoverAbsenceImpactReports.Index = 12;
      this.menuItemCoverAbsenceImpactReports.Text = "I&mpact Summaries";
      this.menuItemCoverStatistics.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemCoverAbsenceStatistics,
        (MenuItem) this.menuItemCoverCoverStatistics
      });
      this.menuItemCoverAbsenceStatistics.Index = 0;
      this.menuItemCoverAbsenceStatistics.Text = "&Absence";
      this.menuItemCoverAbsenceStatistics.Click += new EventHandler(this.menuItemCoverAbsenceStatistics_Click);
      this.menuItemCoverCoverStatistics.Index = 1;
      this.menuItemCoverCoverStatistics.Text = "&Cover";
      this.menuItemCoverCoverStatistics.Click += new EventHandler(this.menuItemCoverCoverStatistics_Click);
      this.menuItemCoverAbsenceImpactReports.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemClassesImpactedByAbsence,
        (MenuItem) this.menuItemStudentsImpactedByAbsence
      });
      this.menuItemClassesImpactedByAbsence.Index = 0;
      this.menuItemClassesImpactedByAbsence.Text = "&Classes Impacted by Absence";
      this.menuItemClassesImpactedByAbsence.Click += new EventHandler(this.menuItemClassesImpactedByAbsence_Click);
      this.menuItemStudentsImpactedByAbsence.Index = 1;
      this.menuItemStudentsImpactedByAbsence.Text = "S&tudents Impacted By Absence";
      this.menuItemStudentsImpactedByAbsence.Click += new EventHandler(this.menuItemStudentsImpactedByAbsence_Click);
      this.menuItemCoverOrgBookings.Index = 4;
      this.menuItemCoverOrgBookings.Text = "Organisations and &Bookings";
      this.menuItemCurrOrganisations.Index = 0;
      this.menuItemCurrOrganisations.Text = "Manage &Organisations";
      this.menuItemCurrOrganisations.Click += new EventHandler(this.menuItemCurrOrganisations_Click);
      this.menuItemCurrBookings.Index = 1;
      this.menuItemCurrBookings.Text = "Manage &Bookings";
      this.menuItemCurrBookings.Click += new EventHandler(this.menuItemCurrBookings_Click);
      this.menuItemCurrDefineTimes.Index = 2;
      this.menuItemCurrDefineTimes.Text = "Define Named &Intervals";
      this.menuItemCurrDefineTimes.Click += new EventHandler(this.menuItemCurrDefineTimes_Click);
      this.menuItemCoverImportExamData.Index = 13;
      this.menuItemCoverImportExamData.Text = "Generate &Exam Room Closures";
      this.menuItemCoverImportExamData.Click += new EventHandler(this.menuItemCoverImportExamData_Click);
      this.menuItemCoverManageStaffLeavers.Index = 14;
      this.menuItemCoverManageStaffLeavers.Text = "Manage Staff Leavers";
      this.menuItemCoverManageStaffLeavers.Click += new EventHandler(this.menuItemCoverManageStaffLeavers_Click);
      this.menuItemEmploymentParam.ImageIndex = -1;
      this.menuItemEmploymentParam.ImageList = (ImageList) null;
      this.menuItemEmploymentParam.Index = 14;
      this.menuItemEmploymentParam.NoEdit = false;
      this.menuItemEmploymentParam.NoUIModify = false;
      this.menuItemEmploymentParam.OriginalText = "";
      this.menuItemEmploymentParam.OwnerDraw = true;
      this.menuItemEmploymentParam.Text = "Employment Parameters";
      this.menuItemEmploymentParam.Click += new EventHandler(this.menuItemEmploymentParam_Click);
      this.menuItemCoverOrgBookings.MenuItems.Add((MenuItem) this.menuItemCurrOrganisations);
      this.menuItemCoverOrgBookings.MenuItems.Add((MenuItem) this.menuItemCurrBookings);
      this.menuItemCoverOrgBookings.MenuItems.Add((MenuItem) this.menuItemCurrDefineTimes);
    }

    private void menuItemClosureReasons_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovClosureReasonContainer());
    }

    private void menuItemAbsenceReasons_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovAbsenceReasonContainer());
    }

    private void menuItemManageCoverRota_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovRotaContainer());
    }

    private void menuItemNonClassCodeRule_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovNonClassCodeContainer());
    }

    private void menuItemCoverDairy_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovCoverDiaryContainer());
    }

    private void menuItemCoverDairyForRegisterAbsence_Click(object sender, EventArgs e)
    {
    }

    private void menuItemStaffWeighting_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovManageStaffWeightingContainer());
    }

    private void menuItemIdentifySupplyStaff_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovIdentifySupplyStaffContainer());
    }

    private void menuItemuSuspensionRule_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovManageSuspensionRulesContainer());
    }

    private void menuItemClassesImpactedByAbsence_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovClassAbsenceImpactDetails());
    }

    private void menuItemCoverCoverStatistics_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovStaffCoverDetails());
    }

    private void menuItemCoverAbsenceStatistics_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovStaffAbsenceDetails());
    }

    private void menuItemGlobalSetting_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovGlobalSettingDetail());
    }

    private void menuItemCoverCreditSetting_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovCoverCreditContainer());
    }

    private void menuItemStudentsImpactedByAbsence_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovStudentsImpactedByAbsence());
    }

    private void menuItemDetectTimetableChanges_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new DlgSearchTimetableChanges().ShowDialog((IWin32Window) this.ParentForm);
    }

    private void menuItemCurrOrganisations_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovAgencyContainer());
    }

    private void menuItemCurrBookings_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovBookingContainer());
    }

    private void menuItemCurrDefineTimes_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovDefinedTimesForm());
    }

    private void menuItemEmploymentParam_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new FTEhourContainer());
    }

    private void menuItemSchoolOptions_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SchoolOptionsContainer());
    }

    private void menuItemCoverImportExamData_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      int num = (int) new DlgCovImportDataFromExams().ShowDialog((IWin32Window) this.ParentForm);
    }

    private void menuItemCoverManageStaffLeavers_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new CovStaffLeaverContainer());
    }

    private void rebuildCoverMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemClosureReasons, new string[2]
      {
        "CovViewRoomClosureReason",
        "CovEditRoomClosureReason"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemAbsenceReasons, new string[2]
      {
        "CovViewStaffAbsenceReason",
        "CovEditStaffAbsenceReason"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemManageCoverRota, new string[2]
      {
        "CovViewCoverRota",
        "CovEditCoverRota"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemGlobalSetting, new string[2]
      {
        "CovViewGlobalSettings",
        "CovEditGlobalSettings"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemNonClassCodeRule, new string[2]
      {
        "CovViewNCRActivities",
        "CovEditNCRActivities"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCoverDairy, "CovArrangeCover");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemStaffWeighting, new string[2]
      {
        "CovViewStaffWeightings",
        "CovEditStaffWeightings"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemIdentifySupplyStaff, "CovIdentifyAgencySupplyStaff");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemSuspensionRule, new string[2]
      {
        "CovViewSuspensions",
        "CovEditSuspensions"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCoverAbsenceStatistics, "CovAbsenceReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCoverCoverStatistics, "CovCoverReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemClassesImpactedByAbsence, "CovClassesImpactedByAbsence");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemStudentsImpactedByAbsence, "CovStudentsImpactedByAbsence");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemDetectTimetableChanges, "CovVerifyRecords");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrDefineTimes, "CovDefinedTimes");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrBookings, "CovBookingBrowse");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCurrOrganisations, "CovAgencyBrowse");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCoverCreditSetting, "CoverCredit");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCoverImportExamData, "CovExamsImport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemCoverManageStaffLeavers, "CovStaffLeaverDetail");
    }

    private void initTeachersViewMenus()
    {
      this.menuItemTeachersView = new UIMenuItem();
      this.menuItemTeachersViewSetup = new UIMenuItem();
      this.menuItemTeachersView.ImageIndex = -1;
      this.menuItemTeachersView.ImageList = (ImageList) null;
      this.menuItemTeachersView.Index = 7;
      this.menuItemTeachersView.NoEdit = false;
      this.menuItemTeachersView.NoUIModify = false;
      this.menuItemTeachersView.OriginalText = "";
      this.menuItemTeachersView.OwnerDraw = true;
      this.menuItemTeachersView.Text = SIMS.Entities.Cache.UserInterfaceLabel("Student") + " Teacher &View";
      this.menuItemTeachersView.Click += new EventHandler(this.menuItemTeachersView_Click);
      this.menuItemTeachersViewSetup.HelpDescription = (string) null;
      this.menuItemTeachersViewSetup.ImageIndex = -1;
      this.menuItemTeachersViewSetup.ImageList = (ImageList) null;
      this.menuItemTeachersViewSetup.Index = 14;
      this.menuItemTeachersViewSetup.NoEdit = false;
      this.menuItemTeachersViewSetup.NoUIModify = false;
      this.menuItemTeachersViewSetup.OriginalText = "";
      this.menuItemTeachersViewSetup.OwnerDraw = true;
      this.menuItemTeachersViewSetup.Text = SIMS.Entities.Cache.UserInterfaceLabel("Student") + " Teacher &View";
      this.menuItemTeachersViewSetup.Click += new EventHandler(this.menuItemTeachersViewSetup_Click);
      this.MenuItemStudent.MenuItems.Add(1, (MenuItem) this.menuItemTeachersView);
      this.menuItemSetups.MenuItems.Add((MenuItem) this.menuItemTeachersViewSetup);
    }

    private void menuItemTeachersView_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new TeacherViewBrowserDetail());
    }

    private void menuItemTeachersViewSetup_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new TeachersViewSetupDetail());
    }

    private void rebuildTeachersViewMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemTeachersView, "TeachersView");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemTeachersViewSetup, new string[2]
      {
        "TeachersViewSetup",
        "TeachersView"
      });
    }

    private void menuItemCapita_Click(object sender, EventArgs e)
    {
      this.navigateToExternalApplication("Capita", "HTTP://WWW.capita-sims.co.uk", "Capita");
    }

    private void menuItemSolus_Click(object sender, EventArgs e)
    {
      this.navigateToExternalApplication("SOLUS", "http://www.capitasolus.co.uk/", "SOLUS");
    }

    private void menuItemCapitamyAccount_Click(object sender, EventArgs e)
    {
      this.navigateToExternalApplication("Capita My Account", "https://myaccount.capita-cs.co.uk/login/", "Capita My Account");
    }

    private void navigateToExternalApplication(string description, string target, string toolTip)
    {
      Process.Start(new SIMS.Entities.ExternalApplication()
      {
        Description = description,
        Target = target,
        SIMSApplication = false,
        ToolTip = toolTip
      }.Target);
    }

    private void rebuildSipaAgentMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemConfigureSipaAgent, "SIPAConfigurationDetail");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSipaAgentSchedules, "SIPAViewScheduleEvents");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSipaAgentLogs, "SIPAViewManageEvents");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSipaSpare, "SIPAViewSpareMenu");
    }

    private void initSipaMenus()
    {
      this.menuItemConfigureSipaAgent = new UIMenuItem();
      this.menuItemConfigureSipaAgent.ImageIndex = -1;
      this.menuItemConfigureSipaAgent.ImageList = (ImageList) null;
      this.menuItemConfigureSipaAgent.Index = 1;
      this.menuItemConfigureSipaAgent.NoEdit = false;
      this.menuItemConfigureSipaAgent.NoUIModify = false;
      this.menuItemConfigureSipaAgent.OriginalText = "";
      this.menuItemConfigureSipaAgent.OwnerDraw = true;
      this.menuItemConfigureSipaAgent.Click += new EventHandler(this.menuItemConfigureSipaAgent_Click);
      this.menuItemSipaAgentSchedules = new UIMenuItem();
      this.menuItemSipaAgentSchedules.ImageIndex = -1;
      this.menuItemSipaAgentSchedules.ImageList = (ImageList) null;
      this.menuItemSipaAgentSchedules.Index = 2;
      this.menuItemSipaAgentSchedules.NoEdit = false;
      this.menuItemSipaAgentSchedules.NoUIModify = false;
      this.menuItemSipaAgentSchedules.OriginalText = "";
      this.menuItemSipaAgentSchedules.OwnerDraw = true;
      this.menuItemSipaAgentSchedules.Click += new EventHandler(this.menuItemSipaAgentSchedules_Click);
      this.menuItemSipaAgentLogs = new UIMenuItem();
      this.menuItemSipaAgentLogs.ImageIndex = -1;
      this.menuItemSipaAgentLogs.ImageList = (ImageList) null;
      this.menuItemSipaAgentLogs.Index = 3;
      this.menuItemSipaAgentLogs.NoEdit = false;
      this.menuItemSipaAgentLogs.NoUIModify = false;
      this.menuItemSipaAgentLogs.OriginalText = "";
      this.menuItemSipaAgentLogs.OwnerDraw = true;
      this.menuItemSipaAgentLogs.Click += new EventHandler(this.menuItemSipaAgentLogs_Click);
      this.menuItemSipaSpare = new UIMenuItem();
      this.menuItemSipaSpare.ImageIndex = -1;
      this.menuItemSipaSpare.ImageList = (ImageList) null;
      this.menuItemSipaSpare.Index = 4;
      this.menuItemSipaSpare.NoEdit = false;
      this.menuItemSipaSpare.NoUIModify = false;
      this.menuItemSipaSpare.OriginalText = "";
      this.menuItemSipaSpare.OwnerDraw = true;
      this.menuItemSipaSpare.Click += new EventHandler(this.menuItemSipaSpare_Click);
      this.menuItemSipaAgent = new UIMenuItem();
      this.menuItemSipaAgent.ImageIndex = -1;
      this.menuItemSipaAgent.ImageList = (ImageList) null;
      this.menuItemSipaAgent.Index = 11;
      this.menuItemSipaAgent.NoEdit = false;
      this.menuItemSipaAgent.NoUIModify = false;
      this.menuItemSipaAgent.OriginalText = "";
      this.menuItemSipaAgent.OwnerDraw = true;
      this.menuItemSipaAgent.Text = "Provisioning Agent";
      this.menuItemSipaAgent.MenuItems.Add((MenuItem) this.menuItemConfigureSipaAgent);
      this.menuItemSipaAgent.MenuItems.Add((MenuItem) this.menuItemSipaAgentSchedules);
      this.menuItemSipaAgent.MenuItems.Add((MenuItem) this.menuItemSipaAgentLogs);
      this.menuItemSipaAgent.MenuItems.Add((MenuItem) this.menuItemSipaSpare);
      this.MenuItemSchool.MenuItems.Add((MenuItem) this.menuItemSipaAgent);
      this.menuItemConfigureSipaAgent.Text = MenuItems.GetMenuText(this.menuItemConfigureSipaAgent.Index);
      this.menuItemSipaAgentLogs.Text = MenuItems.GetMenuText(this.menuItemSipaAgentLogs.Index);
      this.menuItemSipaAgentSchedules.Text = MenuItems.GetMenuText(this.menuItemSipaAgentSchedules.Index);
      this.menuItemSipaSpare.Text = MenuItems.GetMenuText(this.menuItemSipaSpare.Index);
    }

    private void menuItemConfigureSipaAgent_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SifAgentConfigurationDetail());
    }

    private void menuItemSipaAgentSchedules_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SifAgentScheduleEventsContainer());
    }

    private void menuItemSipaAgentLogs_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SifAgentLoggingDetail());
    }

    private void menuItemSipaSpare_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SifAgentSpareControl());
    }

    private void menuItemPartnerships_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PXChangeInstanceContainer());
    }

    private void menuItemConfigurePartnership_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PXChangeConfigurationDetail());
    }

    private void menuItemSchedules_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PxChangeScheduleEventsContainer());
    }

    private void menuItemPartnershipLogs_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new PXChangeLoggingDetail());
    }

    private void rebuildPartnershipMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemConfigurePartnership, "PXChangeConfigurationDetail");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSchedules, "PXChangeViewScheduleEvents");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPartnershipLogs, "PXChangeViewManageEvents");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPartnerships, new string[2]
      {
        "PXChangeViewInstanceBrowser",
        "PXChangeViewInstanceDetail"
      });
    }

    private void initPartnerShipMenus()
    {
      this.menuItemConfigurePartnership = new UIMenuItem();
      this.menuItemConfigurePartnership.ImageIndex = -1;
      this.menuItemConfigurePartnership.ImageList = (ImageList) null;
      this.menuItemConfigurePartnership.Index = 1;
      this.menuItemConfigurePartnership.NoEdit = false;
      this.menuItemConfigurePartnership.NoUIModify = false;
      this.menuItemConfigurePartnership.OriginalText = "";
      this.menuItemConfigurePartnership.OwnerDraw = true;
      this.menuItemConfigurePartnership.Text = "&Configure";
      this.menuItemConfigurePartnership.Click += new EventHandler(this.menuItemConfigurePartnership_Click);
      this.menuItemPartnerships = new UIMenuItem();
      this.menuItemPartnerships.ImageIndex = -1;
      this.menuItemPartnerships.ImageList = (ImageList) null;
      this.menuItemPartnerships.Index = 2;
      this.menuItemPartnerships.NoEdit = false;
      this.menuItemPartnerships.NoUIModify = false;
      this.menuItemPartnerships.OriginalText = "";
      this.menuItemPartnerships.OwnerDraw = true;
      this.menuItemPartnerships.Text = "&Partnerships";
      this.menuItemPartnerships.Click += new EventHandler(this.menuItemPartnerships_Click);
      this.menuItemSchedules = new UIMenuItem();
      this.menuItemSchedules.ImageIndex = -1;
      this.menuItemSchedules.ImageList = (ImageList) null;
      this.menuItemSchedules.Index = 3;
      this.menuItemSchedules.NoEdit = false;
      this.menuItemSchedules.NoUIModify = false;
      this.menuItemSchedules.OriginalText = "";
      this.menuItemSchedules.OwnerDraw = true;
      this.menuItemSchedules.Text = "&Schedules";
      this.menuItemSchedules.Click += new EventHandler(this.menuItemSchedules_Click);
      this.menuItemPartnershipLogs = new UIMenuItem();
      this.menuItemPartnershipLogs.ImageIndex = -1;
      this.menuItemPartnershipLogs.ImageList = (ImageList) null;
      this.menuItemPartnershipLogs.Index = 4;
      this.menuItemPartnershipLogs.NoEdit = false;
      this.menuItemPartnershipLogs.NoUIModify = false;
      this.menuItemPartnershipLogs.OriginalText = "";
      this.menuItemPartnershipLogs.OwnerDraw = true;
      this.menuItemPartnershipLogs.Text = "&Logs";
      this.menuItemPartnershipLogs.Click += new EventHandler(this.menuItemPartnershipLogs_Click);
      this.menuItemPartnership = new UIMenuItem();
      this.menuItemPartnership.ImageIndex = -1;
      this.menuItemPartnership.ImageList = (ImageList) null;
      this.menuItemPartnership.Index = 10;
      this.menuItemPartnership.NoEdit = false;
      this.menuItemPartnership.NoUIModify = false;
      this.menuItemPartnership.OriginalText = "";
      this.menuItemPartnership.OwnerDraw = true;
      this.menuItemPartnership.Text = "Par&tnership";
      this.menuItemPartnership.MenuItems.Add((MenuItem) this.menuItemConfigurePartnership);
      this.menuItemPartnership.MenuItems.Add((MenuItem) this.menuItemPartnerships);
      this.menuItemPartnership.MenuItems.Add((MenuItem) this.menuItemSchedules);
      this.menuItemPartnership.MenuItems.Add((MenuItem) this.menuItemPartnershipLogs);
      this.MenuItemSchool.MenuItems.Add((MenuItem) this.menuItemPartnership);
    }

    private void initDMSMenus()
    {
      this.menuItemPrivateDocuments = new UIMenuItem();
      this.menuItemPrivateDocuments.ImageIndex = -1;
      this.menuItemPrivateDocuments.ImageList = (ImageList) null;
      this.menuItemPrivateDocuments.NoEdit = false;
      this.menuItemPrivateDocuments.NoUIModify = false;
      this.menuItemPrivateDocuments.OriginalText = "";
      this.menuItemPrivateDocuments.OwnerDraw = true;
      this.menuItemPrivateDocuments.Text = "Manage &Private Documents of Staff Leavers";
      this.menuItemPrivateDocuments.Click += new EventHandler(this.menuItemPrivateDocuments_Click);
      this.menuItemToolMaintainDocuments.MenuItems.Add((MenuItem) this.menuItemPrivateDocuments);
    }

    private void rebuildDMSMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPrivateDocuments, "ManageLeaversPrivateDocuments");
    }

    private void menuItemPrivateDocuments_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ManageLeaversPrivateDocuments());
    }

    private void panelOptions_Resize(object sender, EventArgs e)
    {
      if (!this.isLoaded)
        return;
      UserOptionsCache.UserOptions.LauncherWidth = this.panelOptions.Width;
    }

    private void recordMenuUsage(UIMenuItem activatedMenu)
    {
      if (activatedMenu == null || !this.autoStartItemLaunched)
        return;
      SIMS.Entities.Cache.CurrentDatabase.DBLogUIActivity(activatedMenu.FullName, 6);
      this.launcher.MenuItemSelected(activatedMenu);
    }

    private void menuItemToolMaintainDocuments_Click(object sender, EventArgs e)
    {
      DocumentServers documentServers = new DocumentServers();
      Cursor.Current = Cursors.WaitCursor;
      try
      {
        if (documentServers.ServerCount != 0)
        {
          if (documentServers.Ping())
            goto label_5;
        }
        int num = (int) MessageBox.Show("The Document Management Server does not exist or is not running", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        return;
      }
      finally
      {
        Cursor.Current = Cursors.Default;
      }
label_5:
      DocumentServerProxy server = DocumentServerProxy.GetServer(SIMS.Entities.DocManagementCache.ServerDefinitions[0]);
      try
      {
        server.GetVersionInformation();
      }
      catch (System.Exception ex)
      {
        int num = (int) MessageBox.Show("Your Document Management Server is at version 1.10. Please deploy the latest version. Functionality will be unavailable unless you upgrade to the latest version of the Document Management Server", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new DocumentManagementDetail());
    }

    private void InitiateAMPARKImport()
    {
      new Thread(new ThreadStart(new ImportAmparkResources().ImportThreadStart)).Start();
    }

    private void initCurriculumnReportingMenus()
    {
      this.menuItemStudentList = new UIMenuItem();
      this.menuItemStudentList.ImageIndex = -1;
      this.menuItemStudentList.ImageList = (ImageList) null;
      this.menuItemStudentList.NoEdit = false;
      this.menuItemStudentList.NoUIModify = false;
      this.menuItemStudentList.OriginalText = "";
      this.menuItemStudentList.OwnerDraw = true;
      this.menuItemStudentList.Text = "&Student List";
      this.MenuItemReports.MenuItems.Add((MenuItem) this.menuItemStudentList);
      this.menuItemGeneralStudentList = new UIMenuItem();
      this.menuItemGeneralStudentList.ImageIndex = -1;
      this.menuItemGeneralStudentList.ImageList = (ImageList) null;
      this.menuItemGeneralStudentList.Index = 0;
      this.menuItemGeneralStudentList.NoEdit = false;
      this.menuItemGeneralStudentList.NoUIModify = false;
      this.menuItemGeneralStudentList.OriginalText = "";
      this.menuItemGeneralStudentList.OwnerDraw = true;
      this.menuItemGeneralStudentList.Text = "&General Student List";
      this.menuItemGeneralStudentList.Click += new EventHandler(this.menuItemGeneralStudentList_Click);
      this.menuItemStudentList.MenuItems.Add((MenuItem) this.menuItemGeneralStudentList);
      this.menuItemClassList = new UIMenuItem();
      this.menuItemClassList.ImageIndex = -1;
      this.menuItemClassList.ImageList = (ImageList) null;
      this.menuItemClassList.Index = 1;
      this.menuItemClassList.NoEdit = false;
      this.menuItemClassList.NoUIModify = false;
      this.menuItemClassList.OriginalText = "";
      this.menuItemClassList.OwnerDraw = true;
      this.menuItemClassList.Text = "&Class List";
      this.menuItemClassList.Click += new EventHandler(this.menuItemClassList_Click);
      this.menuItemStudentList.MenuItems.Add((MenuItem) this.menuItemClassList);
      this.menuItemRegGroupList = new UIMenuItem();
      this.menuItemRegGroupList.ImageIndex = -1;
      this.menuItemRegGroupList.ImageList = (ImageList) null;
      this.menuItemRegGroupList.Index = 2;
      this.menuItemRegGroupList.NoEdit = false;
      this.menuItemRegGroupList.NoUIModify = false;
      this.menuItemRegGroupList.OriginalText = "";
      this.menuItemRegGroupList.OwnerDraw = true;
      this.menuItemRegGroupList.Text = "&Registration Group List";
      this.menuItemRegGroupList.Click += new EventHandler(this.menuItemRegGroupList_Click);
      this.menuItemStudentList.MenuItems.Add((MenuItem) this.menuItemRegGroupList);
    }

    private void displayReportDetail(object sender, EventArgs e, CurrReportTypeEnum reportType)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExistsLike("SIMS.UserInterfaces.ReportDetails", this.trueText((sender as UIMenuItem).Text)) != null)
        return;
      this.DisplayComponent((Control) new ReportDetails(reportType, (ATWPeriod) null));
    }

    private void menuItemGeneralStudentList_Click(object sender, EventArgs e)
    {
      this.displayReportDetail(sender, e, CurrReportTypeEnum.GeneralStudentList);
    }

    private void menuItemClassList_Click(object sender, EventArgs e)
    {
      this.displayReportDetail(sender, e, CurrReportTypeEnum.ClassList);
    }

    private void menuItemRegGroupList_Click(object sender, EventArgs e)
    {
      this.displayReportDetail(sender, e, CurrReportTypeEnum.RegGroupList);
    }

    private void rebuildCurriculumReportMenus()
    {
      this.menuItemGeneralStudentList.Visible = SIMS.Entities.Cache.InformationDomains.ViewPermitted(InformationDomainEnum.StudentBasic);
      this.menuItemRegGroupList.Visible = SIMS.Entities.Cache.InformationDomains.ViewPermitted(InformationDomainEnum.StudentEnrolment);
      this.menuItemClassList.Visible = SIMS.Entities.Cache.InformationDomains.ViewPermitted(InformationDomainEnum.StudentBasic);
    }

    private void initTTPrintingMenus()
    {
      this.menuItemViewTimeTables = new UIMenuItem();
      this.menuItemViewTimeTables.ImageIndex = -1;
      this.menuItemViewTimeTables.ImageList = (ImageList) null;
      this.menuItemViewTimeTables.NoEdit = false;
      this.menuItemViewTimeTables.NoUIModify = false;
      this.menuItemViewTimeTables.OriginalText = "";
      this.menuItemViewTimeTables.OwnerDraw = true;
      this.menuItemViewTimeTables.Text = "&Timetables";
      this.MenuItemReports.MenuItems.Add((MenuItem) this.menuItemViewTimeTables);
      this.menuItemStaffTimetable = new UIMenuItem();
      this.menuItemStaffTimetable.ImageIndex = -1;
      this.menuItemStaffTimetable.ImageList = (ImageList) null;
      this.menuItemStaffTimetable.Index = 0;
      this.menuItemStaffTimetable.NoEdit = false;
      this.menuItemStaffTimetable.NoUIModify = false;
      this.menuItemStaffTimetable.OriginalText = "&Staff Timetable(s)";
      this.menuItemStaffTimetable.OwnerDraw = true;
      this.menuItemStaffTimetable.Text = "&Staff Timetable(s)";
      this.menuItemStaffTimetable.Click += new EventHandler(this.menuItemStaffTimetable_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemStaffTimetable);
      this.menuItemRoomTimetable = new UIMenuItem();
      this.menuItemRoomTimetable.ImageIndex = -1;
      this.menuItemRoomTimetable.ImageList = (ImageList) null;
      this.menuItemRoomTimetable.Index = 1;
      this.menuItemRoomTimetable.NoEdit = false;
      this.menuItemRoomTimetable.NoUIModify = false;
      this.menuItemRoomTimetable.OriginalText = "&Room Timetable(s)";
      this.menuItemRoomTimetable.OwnerDraw = true;
      this.menuItemRoomTimetable.Text = "&Room Timetable(s)";
      this.menuItemRoomTimetable.Click += new EventHandler(this.menuItemRoomTimetable_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemRoomTimetable);
      this.menuItemNonclasscodeTimetable = new UIMenuItem();
      this.menuItemNonclasscodeTimetable.ImageIndex = -1;
      this.menuItemNonclasscodeTimetable.ImageList = (ImageList) null;
      this.menuItemNonclasscodeTimetable.Index = 2;
      this.menuItemNonclasscodeTimetable.NoEdit = false;
      this.menuItemNonclasscodeTimetable.NoUIModify = false;
      this.menuItemNonclasscodeTimetable.OriginalText = "&Non-class code Timetable(s)";
      this.menuItemNonclasscodeTimetable.OwnerDraw = true;
      this.menuItemNonclasscodeTimetable.Text = "&Non-class code Timetable(s)";
      this.menuItemNonclasscodeTimetable.Click += new EventHandler(this.menuItemNonclasscodeTimetable_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemNonclasscodeTimetable);
      this.menuItemStudentTimetable = new UIMenuItem();
      this.menuItemStudentTimetable.ImageIndex = -1;
      this.menuItemStudentTimetable.ImageList = (ImageList) null;
      this.menuItemStudentTimetable.Index = 3;
      this.menuItemStudentTimetable.NoEdit = false;
      this.menuItemStudentTimetable.NoUIModify = false;
      this.menuItemStudentTimetable.OriginalText = "S&tudent Timetable(s)";
      this.menuItemStudentTimetable.OwnerDraw = true;
      this.menuItemStudentTimetable.Text = "S&tudent Timetable(s)";
      this.menuItemStudentTimetable.Click += new EventHandler(this.menuItemStudentTimetable_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemStudentTimetable);
      this.menuItemSeparator = new UIMenuItem();
      this.menuItemSeparator.ImageIndex = -1;
      this.menuItemSeparator.ImageList = (ImageList) null;
      this.menuItemSeparator.Index = 4;
      this.menuItemSeparator.NoEdit = false;
      this.menuItemSeparator.NoUIModify = false;
      this.menuItemSeparator.OriginalText = "";
      this.menuItemSeparator.OwnerDraw = true;
      this.menuItemSeparator.Text = "-";
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemSeparator);
      this.menuItemAllStaffTimetable = new UIMenuItem();
      this.menuItemAllStaffTimetable.ImageIndex = -1;
      this.menuItemAllStaffTimetable.ImageList = (ImageList) null;
      this.menuItemAllStaffTimetable.Index = 5;
      this.menuItemAllStaffTimetable.NoEdit = false;
      this.menuItemAllStaffTimetable.NoUIModify = false;
      this.menuItemAllStaffTimetable.OriginalText = "All Sta&ff Timetable";
      this.menuItemAllStaffTimetable.OwnerDraw = true;
      this.menuItemAllStaffTimetable.Text = "All Sta&ff Timetable";
      this.menuItemAllStaffTimetable.Click += new EventHandler(this.menuItemAllStaffTimetable_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemAllStaffTimetable);
      this.menuItemAllRoomTimetable = new UIMenuItem();
      this.menuItemAllRoomTimetable.ImageIndex = -1;
      this.menuItemAllRoomTimetable.ImageList = (ImageList) null;
      this.menuItemAllRoomTimetable.Index = 6;
      this.menuItemAllRoomTimetable.NoEdit = false;
      this.menuItemAllRoomTimetable.NoUIModify = false;
      this.menuItemAllRoomTimetable.OriginalText = "All Roo&ms Timetable";
      this.menuItemAllRoomTimetable.OwnerDraw = true;
      this.menuItemAllRoomTimetable.Text = "All Roo&ms Timetable";
      this.menuItemAllRoomTimetable.Click += new EventHandler(this.menuItemAllRoomTimetable_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemAllRoomTimetable);
      this.menuItemSelection = new UIMenuItem();
      this.menuItemSelection.ImageIndex = -1;
      this.menuItemSelection.ImageList = (ImageList) null;
      this.menuItemSelection.Index = 7;
      this.menuItemSelection.NoEdit = false;
      this.menuItemSelection.NoUIModify = false;
      this.menuItemSelection.OriginalText = "Se&lection Timetable";
      this.menuItemSelection.OwnerDraw = true;
      this.menuItemSelection.Text = "Se&lection Timetable";
      this.menuItemSelection.Click += new EventHandler(this.menuItemSelection_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemSelection);
      this.menuItemSeparator = new UIMenuItem();
      this.menuItemSeparator.ImageIndex = -1;
      this.menuItemSeparator.ImageList = (ImageList) null;
      this.menuItemSeparator.Index = 8;
      this.menuItemSeparator.NoEdit = false;
      this.menuItemSeparator.NoUIModify = false;
      this.menuItemSeparator.OriginalText = "";
      this.menuItemSeparator.OwnerDraw = true;
      this.menuItemSeparator.Text = "-";
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemSeparator);
      this.menuItemYearBand = new UIMenuItem();
      this.menuItemYearBand.ImageIndex = -1;
      this.menuItemYearBand.ImageList = (ImageList) null;
      this.menuItemYearBand.Index = 9;
      this.menuItemYearBand.NoEdit = false;
      this.menuItemYearBand.NoUIModify = false;
      this.menuItemYearBand.OriginalText = "&Year/Band Timetable";
      this.menuItemYearBand.OwnerDraw = true;
      this.menuItemYearBand.Text = "&Year/Band Timetable";
      this.menuItemYearBand.Click += new EventHandler(this.menuItemYearBand_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemYearBand);
      this.menuItemSubjects = new UIMenuItem();
      this.menuItemSubjects.ImageIndex = -1;
      this.menuItemSubjects.ImageList = (ImageList) null;
      this.menuItemSubjects.Index = 10;
      this.menuItemSubjects.NoEdit = false;
      this.menuItemSubjects.NoUIModify = false;
      this.menuItemSubjects.OriginalText = "Su&bjects Timetable";
      this.menuItemSubjects.OwnerDraw = true;
      this.menuItemSubjects.Text = "Su&bjects Timetable";
      this.menuItemSubjects.Click += new EventHandler(this.menuItemSubjects_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemSubjects);
      this.menuItemAllNonclassCodesTimetable = new UIMenuItem();
      this.menuItemAllNonclassCodesTimetable.ImageIndex = -1;
      this.menuItemAllNonclassCodesTimetable.ImageList = (ImageList) null;
      this.menuItemAllNonclassCodesTimetable.Index = 11;
      this.menuItemAllNonclassCodesTimetable.NoEdit = false;
      this.menuItemAllNonclassCodesTimetable.NoUIModify = false;
      this.menuItemAllNonclassCodesTimetable.OriginalText = "Non-class &codes Timetable";
      this.menuItemAllNonclassCodesTimetable.OwnerDraw = true;
      this.menuItemAllNonclassCodesTimetable.Text = "Non-class &codes Timetable";
      this.menuItemAllNonclassCodesTimetable.Click += new EventHandler(this.menuItemAllNonclassCodesTimetable_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemAllNonclassCodesTimetable);
      this.menuItemFreeStaff = new UIMenuItem();
      this.menuItemFreeStaff.ImageIndex = -1;
      this.menuItemFreeStaff.ImageList = (ImageList) null;
      this.menuItemFreeStaff.Index = 12;
      this.menuItemFreeStaff.NoEdit = false;
      this.menuItemFreeStaff.NoUIModify = false;
      this.menuItemFreeStaff.OriginalText = "Free St&aff Timetable";
      this.menuItemFreeStaff.OwnerDraw = true;
      this.menuItemFreeStaff.Text = "Free St&aff Timetable";
      this.menuItemFreeStaff.Click += new EventHandler(this.menuItemFreeStaff_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemFreeStaff);
      this.menuItemFreeRooms = new UIMenuItem();
      this.menuItemFreeRooms.ImageIndex = -1;
      this.menuItemFreeRooms.ImageList = (ImageList) null;
      this.menuItemFreeRooms.Index = 13;
      this.menuItemFreeRooms.NoEdit = false;
      this.menuItemFreeRooms.NoUIModify = false;
      this.menuItemFreeRooms.OriginalText = "Free R&ooms Timetable";
      this.menuItemFreeRooms.OwnerDraw = true;
      this.menuItemFreeRooms.Text = "Free R&ooms Timetable";
      this.menuItemFreeRooms.Click += new EventHandler(this.menuItemFreeRooms_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemFreeRooms);
      this.menuItemPeriods = new UIMenuItem();
      this.menuItemPeriods.ImageIndex = -1;
      this.menuItemPeriods.ImageList = (ImageList) null;
      this.menuItemPeriods.Index = 14;
      this.menuItemPeriods.NoEdit = false;
      this.menuItemPeriods.NoUIModify = false;
      this.menuItemPeriods.OriginalText = "&Periods Timetable";
      this.menuItemPeriods.OwnerDraw = true;
      this.menuItemPeriods.Text = "&Periods Timetable";
      this.menuItemPeriods.Click += new EventHandler(this.menuItemPeriods_Click);
      this.menuItemViewTimeTables.MenuItems.Add((MenuItem) this.menuItemPeriods);
    }

    private void rebuildTTPrintingMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemStaffTimetable, "StaffTTDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemRoomTimetable, "RoomTTDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemStudentTimetable, "StudentTTDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemNonclasscodeTimetable, "NonClassCodeTTDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAllStaffTimetable, "AllStaffTTDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAllRoomTimetable, "AllRoomsTTDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSelection, "SelectionTTDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemYearBand, "YearBandTTDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemSubjects, "SubjectsTTDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAllNonclassCodesTimetable, "AllNonclassCodesTTDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemFreeStaff, "FreeStaffTTDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemFreeRooms, "FreeRoomsTTDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPeriods, "PeriodsTTDetails");
    }

    private void menuItemStaffTimetable_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTPrintDetails") != null)
        return;
      this.DisplayComponent((Control) new TTStaffPrintDetails());
    }

    private void menuItemRoomTimetable_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTRoomPrintDetails") != null)
        return;
      this.DisplayComponent((Control) new TTRoomPrintDetails());
    }

    private void menuItemStudentTimetable_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTStudentPrintDetails") != null)
        return;
      this.DisplayComponent((Control) new TTStudentPrintDetails());
    }

    private void menuItemNonclasscodeTimetable_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTNonClassPrintDetails") != null)
        return;
      this.DisplayComponent((Control) new TTNonClassPrintDetails());
    }

    private void menuItemAllStaffTimetable_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTAllStaffPrintDetails") != null)
        return;
      this.DisplayComponent((Control) new TTAllStaffPrintDetails());
    }

    private void menuItemSelection_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTSelectionPrintDetails") != null)
        return;
      this.DisplayComponent((Control) new TTSelectionPrintDetails());
    }

    private void menuItemAllRoomTimetable_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTAllRoomPrintDetails") != null)
        return;
      this.DisplayComponent((Control) new TTAllRoomPrintDetails());
    }

    private void menuItemSubjects_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTSubjectsPrintDetails") != null)
        return;
      this.DisplayComponent((Control) new TTSubjectsPrintDetails());
    }

    private void menuItemAllNonclassCodesTimetable_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTAllNonclassCodesPrintDetails") != null)
        return;
      this.DisplayComponent((Control) new TTAllNonclassCodesPrintDetails());
    }

    private void menuItemFreeStaff_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTFreeStaff") != null)
        return;
      this.DisplayComponent((Control) new TTFreeStaff());
    }

    private void menuItemFreeRooms_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTFreeRooms") != null)
        return;
      this.DisplayComponent((Control) new TTFreeRooms());
    }

    private void menuItemPeriods_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTPeriodsPrintDetails") != null)
        return;
      this.DisplayComponent((Control) new TTPeriodsPrintDetails());
    }

    private void menuItemYearBand_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      if ((Component) this.ComponentExists("SIMS.UserInterfaces.TTYearBandPrintDetails") != null)
        return;
      this.DisplayComponent((Control) new TTYearBandPrintDetails());
    }

    private void setupViewTimetableContextMenu()
    {
      NavigationRouteCache.AddRoute("Staff Timetable", new NavigationRouteConditionalDatedDelegate(this.ContextPreviewStaffTimetableUI), new int[1]
      {
        68
      }, typeof (TTStaffPrintDetails), 68);
      NavigationRouteCache.AddRoute("Student Timetable", new NavigationRouteConditionalDatedDelegate(this.ContextPreviewStudentTimetableUI), new int[1]
      {
        69
      }, typeof (TTStudentPrintDetails), 69);
      if (!SIMS.Entities.Cache.ProcessAvailable("RoomTTDetails"))
        return;
      NavigationRouteCache.AddRoute("Room Timetable", new NavigationRouteDatedDelegate(this.ContextPreviewRoomTimetableUI), new int[1]
      {
        34
      }, typeof (TTRoomPrintDetails), 70);
    }

    private void ContextPreviewStaffTimetableUI(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow,
      bool autoProcess)
    {
      this.ShowContextControl((BasicDetailControl) new TTStaffPrintDetails(entityToDisplay, effectiveDate, autoProcess), showAsIndependentWindow);
    }

    private void ContextPreviewStudentTimetableUI(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow,
      bool autoProcess)
    {
      this.ShowContextControl((BasicDetailControl) new TTStudentPrintDetails(entityToDisplay, effectiveDate, autoProcess), showAsIndependentWindow);
    }

    private void ContextPreviewRoomTimetableUI(
      IIDEntity entityToDisplay,
      DateTime effectiveDate,
      bool showAsIndependentWindow)
    {
      this.ShowContextControl((BasicDetailControl) new TTRoomPrintDetails(entityToDisplay, effectiveDate), showAsIndependentWindow);
    }

    private void initStudentAnalysisMenus()
    {
      this.menuItemStudentAnalysis = new UIMenuItem();
      this.menuItemStudentAnalysis.BaseName = "menuItemStudentAnalysis";
      this.menuItemStudentAnalysis.ImageIndex = -1;
      this.menuItemStudentAnalysis.ImageList = (ImageList) null;
      this.menuItemStudentAnalysis.NoEdit = false;
      this.menuItemStudentAnalysis.NoUIModify = false;
      this.menuItemStudentAnalysis.OriginalText = "";
      this.menuItemStudentAnalysis.OwnerDraw = true;
      this.menuItemStudentAnalysis.Text = "Student &Analysis Reports";
      this.MenuItemReports.MenuItems.Add((MenuItem) this.menuItemStudentAnalysis);
      this.menuItemYearGroupTotals = new UIMenuItem();
      this.menuItemYearBandTotals = new UIMenuItem();
      this.menuItemYearRegTotals = new UIMenuItem();
      this.menuItemVertRegTotals = new UIMenuItem();
      this.menuItemAgeBreakTotals = new UIMenuItem();
      this.menuItemClassesYearTotals = new UIMenuItem();
      this.menuItemClassesPeriodTotals = new UIMenuItem();
      this.menuItemEachSubject = new UIMenuItem();
      this.menuItemPairingOne = new UIMenuItem();
      this.menuItemOrderedPairing = new UIMenuItem();
      this.menuItemYearGroupTotals.ImageIndex = -1;
      this.menuItemYearGroupTotals.ImageList = (ImageList) null;
      this.menuItemYearGroupTotals.Index = 0;
      this.menuItemYearGroupTotals.NoEdit = true;
      this.menuItemYearGroupTotals.NoUIModify = true;
      this.menuItemYearGroupTotals.OriginalText = "Student Totals for &Year Groups";
      this.menuItemYearGroupTotals.OwnerDraw = true;
      this.menuItemYearGroupTotals.Text = "Student Totals for &Year Groups";
      this.menuItemYearGroupTotals.Click += new EventHandler(this.menuItemYearGroupTotals_Click);
      this.menuItemYearBandTotals.ImageIndex = -1;
      this.menuItemYearBandTotals.ImageList = (ImageList) null;
      this.menuItemYearBandTotals.Index = 0;
      this.menuItemYearBandTotals.NoEdit = true;
      this.menuItemYearBandTotals.NoUIModify = true;
      this.menuItemYearBandTotals.OriginalText = "Student Totals for Years and &Bands";
      this.menuItemYearBandTotals.OwnerDraw = true;
      this.menuItemYearBandTotals.Text = "Student Totals for Years and &Bands";
      this.menuItemYearBandTotals.Click += new EventHandler(this.menuItemYearBandTotals_Click);
      this.menuItemYearRegTotals.ImageIndex = -1;
      this.menuItemYearRegTotals.ImageList = (ImageList) null;
      this.menuItemYearRegTotals.Index = 0;
      this.menuItemYearRegTotals.NoEdit = true;
      this.menuItemYearRegTotals.NoUIModify = true;
      this.menuItemYearRegTotals.OriginalText = "Student Totals for Year and &Registration Groups";
      this.menuItemYearRegTotals.OwnerDraw = true;
      this.menuItemYearRegTotals.Text = "Student Totals for Year and &Registration Groups";
      this.menuItemYearRegTotals.Click += new EventHandler(this.menuItemYearRegTotals_Click);
      this.menuItemVertRegTotals.ImageIndex = -1;
      this.menuItemVertRegTotals.ImageList = (ImageList) null;
      this.menuItemVertRegTotals.Index = 0;
      this.menuItemVertRegTotals.NoEdit = true;
      this.menuItemVertRegTotals.NoUIModify = true;
      this.menuItemVertRegTotals.OriginalText = "Student Totals for &Vertical Registration Groups";
      this.menuItemVertRegTotals.OwnerDraw = true;
      this.menuItemVertRegTotals.Text = "Student Totals for &Vertical Registration Groups";
      this.menuItemVertRegTotals.Click += new EventHandler(this.menuItemVertRegTotals_Click);
      this.menuItemAgeBreakTotals.ImageIndex = -1;
      this.menuItemAgeBreakTotals.ImageList = (ImageList) null;
      this.menuItemAgeBreakTotals.Index = 0;
      this.menuItemAgeBreakTotals.NoEdit = true;
      this.menuItemAgeBreakTotals.NoUIModify = true;
      this.menuItemAgeBreakTotals.OriginalText = "&Age Breakdown for Year Groups";
      this.menuItemAgeBreakTotals.OwnerDraw = true;
      this.menuItemAgeBreakTotals.Text = "&Age Breakdown for Year Groups";
      this.menuItemAgeBreakTotals.Click += new EventHandler(this.menuItemAgeBreakTotals_Click);
      this.menuItemClassesYearTotals.ImageIndex = -1;
      this.menuItemClassesYearTotals.ImageList = (ImageList) null;
      this.menuItemClassesYearTotals.Index = 0;
      this.menuItemClassesYearTotals.NoEdit = true;
      this.menuItemClassesYearTotals.NoUIModify = true;
      this.menuItemClassesYearTotals.OriginalText = "Student Totals for &Classes in a Year Group";
      this.menuItemClassesYearTotals.OwnerDraw = true;
      this.menuItemClassesYearTotals.Text = "Student Totals for &Classes in a Year Group";
      this.menuItemClassesYearTotals.Click += new EventHandler(this.menuItemClassesYearTotals_Click);
      this.menuItemClassesPeriodTotals.ImageIndex = -1;
      this.menuItemClassesPeriodTotals.ImageList = (ImageList) null;
      this.menuItemClassesPeriodTotals.Index = 0;
      this.menuItemClassesPeriodTotals.NoEdit = true;
      this.menuItemClassesPeriodTotals.NoUIModify = true;
      this.menuItemClassesPeriodTotals.OriginalText = "Classes Active on a Particular &Period";
      this.menuItemClassesPeriodTotals.OwnerDraw = true;
      this.menuItemClassesPeriodTotals.Text = "Classes Active on a Particular &Period";
      this.menuItemClassesPeriodTotals.Click += new EventHandler(this.menuItemClassesPeriodTotals_Click);
      this.menuItemEachSubject.ImageIndex = -1;
      this.menuItemEachSubject.ImageList = (ImageList) null;
      this.menuItemEachSubject.Index = 0;
      this.menuItemEachSubject.NoEdit = true;
      this.menuItemEachSubject.NoUIModify = true;
      this.menuItemEachSubject.OriginalText = "Student Totals for &Each Subject";
      this.menuItemEachSubject.OwnerDraw = true;
      this.menuItemEachSubject.Text = "Student Totals for &Each Subject";
      this.menuItemEachSubject.Click += new EventHandler(this.menuItemEachSubject_Click);
      this.menuItemPairingOne.ImageIndex = -1;
      this.menuItemPairingOne.ImageList = (ImageList) null;
      this.menuItemPairingOne.Index = 0;
      this.menuItemPairingOne.NoEdit = true;
      this.menuItemPairingOne.NoUIModify = true;
      this.menuItemPairingOne.OriginalText = "Pairings for &One Subject";
      this.menuItemPairingOne.OwnerDraw = true;
      this.menuItemPairingOne.Text = "Pairings for &One Subject";
      this.menuItemPairingOne.Click += new EventHandler(this.menuItemPairingOne_Click);
      this.menuItemOrderedPairing.ImageIndex = -1;
      this.menuItemOrderedPairing.ImageList = (ImageList) null;
      this.menuItemOrderedPairing.Index = 0;
      this.menuItemOrderedPairing.NoEdit = true;
      this.menuItemOrderedPairing.NoUIModify = true;
      this.menuItemOrderedPairing.OriginalText = "Ordered &Totals for Subject Pairings";
      this.menuItemOrderedPairing.OwnerDraw = true;
      this.menuItemOrderedPairing.Text = "Ordered &Totals for Subject Pairings";
      this.menuItemOrderedPairing.Click += new EventHandler(this.menuItemOrderedPairing_Click);
      this.menuItemStudentAnalysis.MenuItems.AddRange(new MenuItem[10]
      {
        (MenuItem) this.menuItemYearGroupTotals,
        (MenuItem) this.menuItemYearBandTotals,
        (MenuItem) this.menuItemYearRegTotals,
        (MenuItem) this.menuItemVertRegTotals,
        (MenuItem) this.menuItemAgeBreakTotals,
        (MenuItem) this.menuItemClassesYearTotals,
        (MenuItem) this.menuItemClassesPeriodTotals,
        (MenuItem) this.menuItemEachSubject,
        (MenuItem) this.menuItemPairingOne,
        (MenuItem) this.menuItemOrderedPairing
      });
      this.setStudentAnalysisMenuVisibility();
    }

    private void setStudentAnalysisMenuVisibility()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemYearGroupTotals, "RunStudentAnalysisReports");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemYearRegTotals, "RunStudentAnalysisReports");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemVertRegTotals, "RunStudentAnalysisReports");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemClassesYearTotals, "RunStudentAnalysisReports");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemStudentAnalysis, "RunStudentAnalysisReports");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemYearBandTotals, "RunStudentAnalysisReports");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemAgeBreakTotals, "RunStudentAnalysisReports");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemClassesPeriodTotals, "RunStudentAnalysisReports");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemOrderedPairing, "RunStudentAnalysisReports");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemEachSubject, "RunStudentAnalysisReports");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemPairingOne, "RunStudentAnalysisReports");
      bool flag = !SystemConfigurationCache.IsPrimarySchool;
      this.menuItemClassesYearTotals.Visible = this.menuItemYearBandTotals.Visible && flag;
      this.menuItemYearBandTotals.Visible = this.menuItemYearBandTotals.Visible && flag;
      this.menuItemClassesPeriodTotals.Visible = this.menuItemClassesPeriodTotals.Visible && flag;
      this.menuItemOrderedPairing.Visible = this.menuItemOrderedPairing.Visible && flag;
      this.menuItemEachSubject.Visible = this.menuItemEachSubject.Visible && flag;
      this.menuItemPairingOne.Visible = this.menuItemPairingOne.Visible && flag;
    }

    private void rebuildStudentAnalysisMenus()
    {
      this.setStudentAnalysisMenuVisibility();
      if (!SIMS.Entities.Cache.ProcessAvailable("RunStudentAnalysisReports"))
        return;
      this.menuItemYearGroupTotals.Text = "Student Totals for &Year Groups";
      this.menuItemYearGroupTotals.OriginalText = "Student Totals for &Year Groups";
      this.menuItemStudentAnalysis.Text = "Student &Analysis Reports";
      this.menuItemStudentAnalysis.OriginalText = "Student &Analysis Reports";
      this.menuItemYearBandTotals.Text = "Student Totals for Years and &Bands";
      this.menuItemYearBandTotals.OriginalText = "Student Totals for Years and &Bands";
      this.menuItemYearRegTotals.Text = "Student Totals for Year and &Registration Groups";
      this.menuItemYearRegTotals.OriginalText = "Student Totals for Year and &Registration Groups";
      this.menuItemVertRegTotals.Text = "Student Totals for &Vertical Registration Groups";
      this.menuItemVertRegTotals.OriginalText = "Student Totals for &Vertical Registration Groups";
      this.menuItemAgeBreakTotals.Text = "&Age Breakdown for Year Groups";
      this.menuItemAgeBreakTotals.OriginalText = "&Age Breakdown for Year Groups";
      this.menuItemClassesYearTotals.Text = "Student Totals for &Classes in a Year Group";
      this.menuItemClassesYearTotals.OriginalText = "Student Totals for &Classes in a Year Group";
      this.menuItemClassesPeriodTotals.Text = "Classes Active on a Particular &Period";
      this.menuItemClassesPeriodTotals.OriginalText = "Classes Active on a Particular &Period";
      this.menuItemEachSubject.Text = "Student Totals for &Each Subject";
      this.menuItemEachSubject.OriginalText = "Student Totals for &Each Subject";
      this.menuItemPairingOne.Text = "Pairings for &One Subject";
      this.menuItemPairingOne.OriginalText = "Pairings for &One Subject";
      this.menuItemOrderedPairing.Text = "Ordered &Totals for Subject Pairings";
      this.menuItemOrderedPairing.OriginalText = "Ordered &Totals for Subject Pairings";
    }

    private void menuItemYearGroupTotals_Click(object sender, EventArgs e)
    {
      this.openStudentAnalysisReport(sender, StudentAnalysisReportTypeEnum.YearGroupTotalsReport);
    }

    private void menuItemYearBandTotals_Click(object sender, EventArgs e)
    {
      this.openStudentAnalysisReport(sender, StudentAnalysisReportTypeEnum.YearBandTotalsReport);
    }

    private void menuItemYearRegTotals_Click(object sender, EventArgs e)
    {
      this.openStudentAnalysisReport(sender, StudentAnalysisReportTypeEnum.YearRegistrationTotalsReport);
    }

    private void menuItemVertRegTotals_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgVerticalRegistrationReport registrationReport = new DlgVerticalRegistrationReport())
      {
        int num = (int) registrationReport.ShowDialog();
      }
    }

    private void menuItemAgeBreakTotals_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgAgeBreakdownReport ageBreakdownReport = new DlgAgeBreakdownReport())
      {
        int num = (int) ageBreakdownReport.ShowDialog();
      }
    }

    private void menuItemClassesYearTotals_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgClassesInAYearReport classesInAyearReport = new DlgClassesInAYearReport())
      {
        int num = (int) classesInAyearReport.ShowDialog();
      }
    }

    private void menuItemClassesPeriodTotals_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgClassesInAPeriodReport classesInAperiodReport = new DlgClassesInAPeriodReport())
      {
        int num = (int) classesInAperiodReport.ShowDialog();
      }
    }

    private void menuItemEachSubject_Click(object sender, EventArgs e)
    {
      this.openStudentAnalysisReport(sender, StudentAnalysisReportTypeEnum.StudentTotalsForEachSubjectReport);
    }

    private void menuItemPairingOne_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgPairingsforOneSubject pairingsforOneSubject = new DlgPairingsforOneSubject())
      {
        int num = (int) pairingsforOneSubject.ShowDialog();
      }
    }

    private void menuItemOrderedPairing_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgOrderedSubjectPairings orderedSubjectPairings = new DlgOrderedSubjectPairings())
      {
        int num = (int) orderedSubjectPairings.ShowDialog();
      }
    }

    private void openStudentAnalysisReport(object sender, StudentAnalysisReportTypeEnum reportType)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgStudAnalysisReport studAnalysisReport = new DlgStudAnalysisReport(reportType))
      {
        int num = (int) studAnalysisReport.ShowDialog();
      }
    }

    private void initHomePageMenus()
    {
      this.menuItemHomePageGroup = new UIMenuItem();
      this.menuItemLockHomePageConfig = new UIMenuItem();
      this.menuItemHomePageGroupConfig = new UIMenuItem();
      this.menuItemHomePageTimelineConfig = new UIMenuItem();
      this.menuItemHomePageConfigSettingsReport = new UIMenuItem();
      this.menuItemHomePageGroup.Index = 0;
      this.menuItemHomePageGroup.Text = "&Home Page";
      this.menuItemHomePageGroupConfig.Index = 0;
      this.menuItemHomePageGroupConfig.Text = "Home Page &Group Configuration";
      this.menuItemHomePageGroupConfig.Click += new EventHandler(this.menuItemHPGroupConfiguration_Click);
      this.menuItemLockHomePageConfig.Index = 1;
      this.menuItemLockHomePageConfig.Text = "&Lock Home Page Configuration";
      this.menuItemLockHomePageConfig.Click += new EventHandler(this.menuItemLockHomePageConfig_Click);
      this.menuItemHomePageTimelineConfig.Index = 2;
      this.menuItemHomePageTimelineConfig.Text = "Home Page &Timeline Configuration";
      this.menuItemHomePageTimelineConfig.Click += new EventHandler(this.menuItemHomePageTimelineConfig_Click);
      this.menuItemHomePageConfigSettingsReport.Index = 3;
      this.menuItemHomePageConfigSettingsReport.Text = "Home Page &Configuration Settings Report";
      this.menuItemHomePageConfigSettingsReport.Click += new EventHandler(this.menuItemHomePageConfigSettingsReport_Click);
      this.menuItemRoutines.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemHomePageGroup
      });
      this.menuItemHomePageGroup.MenuItems.AddRange(new MenuItem[4]
      {
        (MenuItem) this.menuItemHomePageGroupConfig,
        (MenuItem) this.menuItemLockHomePageConfig,
        (MenuItem) this.menuItemHomePageTimelineConfig,
        (MenuItem) this.menuItemHomePageConfigSettingsReport
      });
    }

    private void menuItemLockHomePageConfig_Click(object sender, EventArgs e)
    {
      int num = (int) new DlgEditLockState().ShowDialog((IWin32Window) this.Owner);
    }

    private void menuItemHomePageTimelineConfig_Click(object sender, EventArgs e)
    {
      int num = (int) new DlgTimelineConfiguration().ShowDialog((IWin32Window) this.Owner);
    }

    private void menuItemHomePageConfigSettingsReport_Click(object sender, EventArgs e)
    {
      int num = (int) new DlgHomePageConfigSettingsReport().ShowDialog((IWin32Window) this.Owner);
    }

    private void menuItemHPGroupConfiguration_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new GroupConfigurationContainer());
    }

    private void menuItemHouseKeepingManageMessages_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new ManageMessageBrowserDetail());
    }

    private void rebuildHomePageMenus()
    {
      this.menuItemHomePage.Visible = SIMS.Entities.Cache.ProcessAvailable("GroupConfigurationDetail") || SIMS.Entities.Cache.ProcessAvailable("EditLockState") || SIMS.Entities.Cache.ProcessAvailable("TimelineConfigurationAll") || SIMS.Entities.Cache.ProcessAvailable("TimelineConfigurationOwn");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemHomePageGroupConfig, "GroupConfigurationDetail");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemLockHomePageConfig, "EditLockState");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemHomePageTimelineConfig, "TimelineConfigurationAll");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemHomePageConfigSettingsReport, "HomePageConfigSettingsReport");
    }

    private void initOptionsOfferMenu()
    {
      this.menuItemMaintainOffers = new UIMenuItem();
      this.menuItemMaintainOffers.Text = "Maintain &Offers";
      this.menuItemMaintainOffers.Index = 0;
      this.menuItemMaintainOffers.Click += new EventHandler(this.menuItemMaintainOffers_Click);
      this.menuItemStudentChoices = new UIMenuItem();
      this.menuItemStudentChoices.Text = "&Student Choices";
      this.menuItemStudentChoices.Index = 1;
      this.menuItemStudentChoices.Click += new EventHandler(this.menuItemStudentChoices_Click);
      this.menuItemOptionsOffer = new UIMenuItem();
      this.menuItemOptionsOffer.Text = "&Options Offer";
      this.menuItemOptionsOffer.Index = 3;
      this.menuItemOptionsOffer.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) this.menuItemMaintainOffers,
        (MenuItem) this.menuItemStudentChoices
      });
    }

    private void menuItemStudentChoices_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new OptStudentChoiceBrowserDetail());
    }

    private void menuItemMaintainOffers_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new OptOfferBrowserDetail());
    }

    private void rebuildOptionsOfferMenu()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemOptionsOffer, new string[4]
      {
        "OptViewOfferDetail",
        "OptViewOfferDetail",
        "OptViewStudentChoice",
        "OptEditStudentChoice"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemMaintainOffers, new string[2]
      {
        "OptViewOfferDetail",
        "OptEditOfferDetail"
      });
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibilityOR((MenuItem) this.menuItemStudentChoices, new string[2]
      {
        "OptViewStudentChoice",
        "OptEditStudentChoice"
      });
    }

    private void initOptionsNGMenu()
    {
      this.menuItemOptionsNGRun = new UIMenuItem();
      this.menuItemOptionsNGRun.Text = "&Options Online";
      this.menuItemOptionsNGRun.Index = 0;
      this.menuItemOptionsNGRun.Click += new EventHandler(this.menuItemOptionsNGRun_Click);
      this.focusMenu.MenuItems.Add((MenuItem) this.menuItemOptionsNGRun);
    }

    private void menuItemOptionsNGRun_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayNewComponent((Control) new CurrOptionsNGWindow());
    }

    private void rebuildOptionsNGMenu()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemOptionsNGRun, new string[1]
      {
        "CurrOptionsNGLaunch"
      });
    }

    private void initSimsParentMenu()
    {
      this.menuItemSimsParent = new UIMenuItem();
      this.menuItemSimsParent.Text = "SIMS Parent";
      this.menuItemSimsParent.Index = 1;
      this.menuItemSimsParent.Click += new EventHandler(this.menuItemSimsParent_Click);
      this.focusMenu.MenuItems.Add((MenuItem) this.menuItemSimsParent);
    }

    private void menuItemSimsParent_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      Process.Start("https://www.capita-sims.co.uk/products-and-services/sims-parent-lite-app");
    }

    private void rebuildSimsParentMenu()
    {
      this.menuItemSimsParent.Visible = !SIMS.Entities.OnlineServices.Cache.IsLicensed(OnlineServicesProducts.ParentApp) && SIMS.Entities.OnlineServices.Cache.IsLicensed(OnlineServicesProducts.ParentLiteInactive);
    }

    private void initNurseryHoursMenus()
    {
      this.menuItemMaintainEarlyYearProv = new UIMenuItem();
      this.menuItemMaintainEarlyYearProv.ImageIndex = -1;
      this.menuItemMaintainEarlyYearProv.ImageList = (ImageList) null;
      this.menuItemMaintainEarlyYearProv.NoEdit = false;
      this.menuItemMaintainEarlyYearProv.NoUIModify = false;
      this.menuItemMaintainEarlyYearProv.OriginalText = "";
      this.menuItemMaintainEarlyYearProv.OwnerDraw = true;
      this.menuItemMaintainEarlyYearProv.Visible = false;
      this.menuItemMaintainEarlyYearProv.Text = "&Early Years Provisions Setup";
      this.menuItemMaintainEarlyYearProv.Click += new EventHandler(this.menuItemMaintainEarlyYearProv_Click);
      this.menuItemAttendanceSetup.MenuItems.Add((MenuItem) this.menuItemMaintainEarlyYearProv);
    }

    private void menuItemMaintainEarlyYearProv_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new MaintainEarlyYearsProvisionContainer());
    }

    private void rebuildNurseryHoursMenus()
    {
      if (!(SIMS.Entities.Cache.Settings["ViewEarlyYearProvision"] == "T"))
        return;
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemMaintainEarlyYearProv, "EditEarlyYearProvision");
    }

    private void initAdmissionReportsMenus()
    {
      this.menuItemAdmissionReport = new UIMenuItem();
      this.menuItemAdmissionReport.BaseName = "menuItemAdmissionReport";
      this.menuItemAdmissionReport.ImageIndex = -1;
      this.menuItemAdmissionReport.ImageList = (ImageList) null;
      this.menuItemAdmissionReport.NoEdit = false;
      this.menuItemAdmissionReport.NoUIModify = false;
      this.menuItemAdmissionReport.OriginalText = "";
      this.menuItemAdmissionReport.OwnerDraw = true;
      this.menuItemAdmissionReport.Text = "Admissi&ons";
      this.MenuItemReports.MenuItems.Add((MenuItem) this.menuItemAdmissionReport);
      this.menuItemProjectedPupilNumbers = new UIMenuItem();
      this.menuItemProjectedPupilNumbers.BaseName = "menuItemProjectedPupilNumbers";
      this.menuItemProjectedPupilNumbers.ImageIndex = -1;
      this.menuItemProjectedPupilNumbers.ImageList = (ImageList) null;
      this.menuItemProjectedPupilNumbers.NoEdit = false;
      this.menuItemProjectedPupilNumbers.NoUIModify = false;
      this.menuItemProjectedPupilNumbers.OriginalText = "";
      this.menuItemProjectedPupilNumbers.OwnerDraw = true;
      this.menuItemProjectedPupilNumbers.Text = !SystemConfigurationCache.IsSecondarySchool ? "&Projected Pupil Numbers" : "&Projected Student Numbers";
      this.menuItemProjectedPupilNumbers.Click += new EventHandler(this.menuItemProjectedPupilNumbers_Click);
      this.menuItemAdmissionReport.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemProjectedPupilNumbers
      });
    }

    private void menuItemProjectedPupilNumbers_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      using (DlgProjectedPupilNumbers projectedPupilNumbers = new DlgProjectedPupilNumbers())
      {
        int num = (int) projectedPupilNumbers.ShowDialog();
      }
    }

    private void rebuildAdmissionReportMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemProjectedPupilNumbers, "ProjectedPupilNumbers");
    }

    private void setupAgentContextMenu()
    {
      if (!SIMS.Entities.Cache.ProcessVisible("ViewAgent"))
        return;
      NavigationRouteCache.AddRoute("Agent Details", new NavigationRouteDelegate(this.ContextAgent), new int[1]
      {
        2
      }, typeof (AgentDetailUI), 2);
    }

    private void contextDetentionUI(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      DetentionDetail detentionDetail = new DetentionDetail(entityToDisplay);
      detentionDetail.Text += "Unknown";
      this.ShowContextControl((BasicDetailControl) detentionDetail, showAsIndependentWindow);
      detentionDetail.Search(entityToDisplay.ID);
    }

    private void setupDetentionsContextMenu()
    {
      if (!SIMS.Entities.Cache.ProcessVisible("ViewDetention"))
        return;
      NavigationRouteCache.AddRoute("Detention Details", new NavigationRouteDelegate(this.contextDetentionUI), new int[1]
      {
        75
      }, typeof (DetentionDetail), 75);
    }

    private void initHomeworkMenus()
    {
      this.menuItemManageHomework = new UIMenuItem();
      this.menuItemManageHomework.BaseName = "menuItemManageHomework";
      this.menuItemManageHomework.ImageIndex = -1;
      this.menuItemManageHomework.ImageList = (ImageList) null;
      this.menuItemManageHomework.NoEdit = false;
      this.menuItemManageHomework.NoUIModify = false;
      this.menuItemManageHomework.OriginalText = "";
      this.menuItemManageHomework.OwnerDraw = true;
      this.menuItemManageHomework.Text = "&Manage Homework";
      this.menuItemManageHomework.Click += new EventHandler(this.menuItemManageHomework_Click);
      this.menuItemHomework.MenuItems.AddRange(new MenuItem[1]
      {
        (MenuItem) this.menuItemManageHomework
      });
    }

    private void menuItemManageHomework_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new StudentHomeworkContainer());
    }

    private void rebuildHomeworkMenus()
    {
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemManageHomework, "ViewOwnHomework");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) this.menuItemHomework, "ViewOwnHomework");
    }

    private void contextUDGUI(IIDEntity entityToDisplay, bool showAsIndependentWindow)
    {
      MaintainUserDefinedGroupsDetails definedGroupsDetails = new MaintainUserDefinedGroupsDetails(UserGroupTypeEnum.User);
      this.ShowContextControl((BasicDetailControl) definedGroupsDetails, showAsIndependentWindow);
      definedGroupsDetails.LoadDetails(entityToDisplay.ID);
    }

    private void setupUDGContextMenu()
    {
      if (!SIMS.Entities.Cache.ProcessVisible("UserGroupConfigure"))
        return;
      NavigationRouteCache.AddRoute("UDG Details", new NavigationRouteDelegate(this.contextUDGUI), new int[1]
      {
        78
      }, typeof (MaintainUserDefinedGroupsDetails), 78);
    }

    private void menuItemSetSchoolWorkingDays_Click(object sender, EventArgs e)
    {
      this.recordMenuUsage(sender as UIMenuItem);
      this.DisplayComponent((Control) new SetSchoolWorkingDays());
    }

    public delegate void functionPIvisibility(bool piVisible);

    private class IDShim : IIDEntity
    {
      private string m_Description = "";
      private int m_Id = -1;

      public void SetDescription(string description)
      {
        this.m_Description = description;
      }

      public string Description
      {
        get
        {
          return this.m_Description;
        }
      }

      public int ID
      {
        get
        {
          return this.m_Id;
        }
        set
        {
          this.m_Id = value;
        }
      }
    }
  }
}
