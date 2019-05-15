// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.InTouch.MainContainerHelper
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using SIMS.Entities;
using SIMS.Entities.InTouch;
using SIMS.Processes.InTouch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SIMS.UserInterfaces.InTouch
{
  public static class MainContainerHelper
  {
    private static Scope scopeIndividualStudents = new Scope(InformationDomainEnum.StudentAttendance, "INDIVL", "Individual Students");
    private const string MSG_INFO_SERVICE_DETAILS_MISSING = "This feature is unavailable because you have not completed the InTouch Service Setup screen.";
    internal const string FORMAT_INFO_INCOMPATIBLE_SERVICES = "There is a problem with your InTouch services.\r\n\r\nPlease contact your local support unit.\r\n\r\n({0})";
    internal const string MSG_WARNING_QUEUING_MESSAGES = "InTouch alert messages are currently being queued. Please try again in a short while.";
    private const string MSG_WARNING_BEHAVIOUR_INCIDENT_NOT_FOUND = "The requested behaviour incident could not be found.  It may have been deleted.";
    private const string MSG_WARNING_ACHIEVEMENT_NOT_FOUND = "The requested achievement could not be found.  It may have been deleted.";
    private const string MSG_INTOUCH_PERMISSIONS_UNAVAILABLE = "You do not have permission to load this screen.";
    private static RecordMenuUsageDelegate recordMenuUsage;
    private static DisplayComponentDelegate displayComponent;
    private static ComponentExistsDelegate componentExists;
    private static DisplayComponentWithInterfacesDelegate displayComponentWithInterfaces;
    private static UIMenuItem menuItemFocusInTouch;
    internal static UIMenuItem MenuItemInTouchSendMessage;
    internal static UIMenuItem MenuItemInTouchShowMessages;
    private static UIMenuItem menuItemFeesBillingSendMessage;
    private static UIMenuItem menuItemStudentSendStudentMessage;
    private static UIMenuItem menuItemReportsInTouch;
    private static UIMenuItem menuItemFailedOutboundMessages;
    private static UIMenuItem menuItemContactDetailsVerification;
    private static UIMenuItem menuItemMessagingAudit;
    private static UIMenuItem menuItemReportsInTouchExams;
    private static UIMenuItem menuItemSendExamTimetableMessages;
    private static UIMenuItem menuItemSendExamResultsMessages;
    private static UIMenuItem menuItemRoutinesInTouch;
    private static UIMenuItem menuItemExportContactDetails;
    private static UIMenuItem menuItemToolsInTouch;
    private static UIMenuItem menuItemInTouchServiceSetup;
    private static UIMenuItem menuItemInTouchModuleSetup;
    private static UIMenuItem menuItemInTouchDefaultsSetup;
    private static UIMenuItem menuItemInTouchMessageTypeDefaultsSetup;
    private static UIMenuItem menuItemInTouchTemplatesSetup;
    private static UIMenuItem menuItemInTouchAchievementAlertsSetup;
    private static UIMenuItem menuItemInTouchBehaviourIncidentAlertsSetup;
    private static UIMenuItem menuItemInTouchCumulativeAchievementAlertsSetup;
    private static UIMenuItem menuItemToolsPrimaryContactDetails;
    private static UIMenuItem menuItemToolsPrimaryContactDetailsContactsStudents;
    private static UIMenuItem menuItemToolsPrimaryContactDetailsContactsApplicants;
    private static UIMenuItem menuItemToolsPrimaryContactDetailsStudents;
    private static UIMenuItem menuItemInTouchMissingResultsAlertsSetup;
    private static UIMenuItem menuItemInTouchExamReminderAlertsSetup;
    private static UIMenuItem menuItemInTouchExamResultsSetup;

    private static object launch_Host(object control)
    {
      if (MainContainerHelper.checkInTouchServiceSetup())
        return (object) MainContainerHelper.displayComponentWithInterfaces((Control) control);
      return (object) null;
    }

    public static void InitialiseMenus(
      MainMenu mainMenu,
      RecordMenuUsageDelegate recordMenuUsage,
      DisplayComponentDelegate displayComponent,
      DisplayComponentWithInterfacesDelegate displayComponentWithInterfaces,
      ComponentExistsDelegate componentExists,
      EventHandler hostedComponent_TitleChanged)
    {
      if (mainMenu == null)
        throw new ArgumentNullException(nameof (mainMenu));
      if (recordMenuUsage == null)
        throw new ArgumentNullException(nameof (recordMenuUsage));
      if (displayComponent == null)
        throw new ArgumentNullException(nameof (displayComponent));
      if (displayComponentWithInterfaces == null)
        throw new ArgumentNullException(nameof (displayComponentWithInterfaces));
      if (hostedComponent_TitleChanged == null)
        throw new ArgumentNullException(nameof (hostedComponent_TitleChanged));
      MainContainerHelper.recordMenuUsage = recordMenuUsage;
      MainContainerHelper.displayComponent = displayComponent;
      MainContainerHelper.displayComponentWithInterfaces = displayComponentWithInterfaces;
      MainContainerHelper.componentExists = componentExists;
      SIMS.Entities.InTouch.Cache.TitleChanged += hostedComponent_TitleChanged;
      SIMS.Entities.InTouch.Cache.DisplayGeneralMessage = new CacheDisplayGeneralMessageDelegate(MainContainerHelper.cache_DisplayGeneralMessage);
      SIMS.Entities.InTouch.Cache.DisplaySenEvent = new CacheDisplaySenEventDelegate(MainContainerHelper.cache_DisplaySenEvent);
      SIMS.Entities.InTouch.Cache.DisplaySenProvision = new CacheDisplaySenProvisionDelegate(MainContainerHelper.cache_DisplaySenProvision);
      SIMS.Entities.InTouch.Cache.DisplaySenReview = new CacheDisplaySenReviewDelegate(MainContainerHelper.cache_DisplaySenReview);
      SIMS.Entities.InTouch.Cache.CreateSenEvent = new CacheCreateSenEventDelegate(MainContainerHelper.cache_CreateSenEvent);
      SIMS.Entities.InTouch.Cache.CreateSenProvision = new CacheCreateSenProvisionDelegate(MainContainerHelper.cache_CreateSenProvision);
      SIMS.Entities.InTouch.Cache.CreateSenReview = new CacheCreateSenReviewDelegate(MainContainerHelper.cache_CreateSenReview);
      SIMS.Entities.InTouch.Cache.StudentDetails = new CacheStudentDetailsDelegate(MainContainerHelper.cache_StudentDetails);
      SIMS.Entities.InTouch.Cache.TakeAttRegister = new CacheTakeAttRegisterDelegate(MainContainerHelper.cache_TakeAttRegister);
      SIMS.Entities.InTouch.Cache.EditAttMarks = new CacheEditAttMarksDelegate(MainContainerHelper.cache_EditAttMarks);
      SIMS.Entities.InTouch.Cache.EmployeeDetails = new CacheEmployeeDetailsDelegate(MainContainerHelper.cache_EmployeeDetails);
      SIMS.Entities.InTouch.Cache.BehaviourIncidentDetails = new CacheBehaviourIncidentDetailsDelegate(MainContainerHelper.cache_BehaviourIncidentDetails);
      SIMS.Entities.InTouch.Cache.AchievementDetails = new CacheAchievementDetailsDelegate(MainContainerHelper.cache_AchievementDetails);
      SIMS.Entities.InTouch.Cache.LaunchHost += new LaunchHostDelegate(MainContainerHelper.launch_Host);
      UIMenuItem menuItem1 = mainMenu.MenuItems["focusMenu"] as UIMenuItem;
      UIMenuItem menuItem2 = menuItem1.MenuItems["menuItemFees"] as UIMenuItem;
      UIMenuItem menuItem3 = menuItem1.MenuItems["menuItemAlerts"] as UIMenuItem;
      UIMenuItem menuItem4 = mainMenu.MenuItems["MenuItemReports"] as UIMenuItem;
      UIMenuItem menuItem5 = menuItem4.MenuItems["menuItemAdmissionReport"] as UIMenuItem;
      UIMenuItem menuItem6 = (mainMenu.MenuItems["menuItemRoutines"] as UIMenuItem).MenuItems["menuItemDataOut"] as UIMenuItem;
      UIMenuItem menuItem7 = menuItem6.MenuItems["menuItemCBAExport"] as UIMenuItem;
      UIMenuItem menuItem8 = mainMenu.MenuItems["toolsMenu"] as UIMenuItem;
      UIMenuItem menuItem9 = menuItem8.MenuItems["menuItemToolsHousekeeping"] as UIMenuItem;
      UIMenuItem menuItem10 = menuItem8.MenuItems["menuItemToolsDinnerMoney"] as UIMenuItem;
      UIMenuItem menuItem11 = menuItem9.MenuItems["menuItemToolsAttArchiving"] as UIMenuItem;
      UIMenuItem menuItem12 = menuItem1.MenuItems["MenuItemStudent"] as UIMenuItem;
      MainContainerHelper.menuItemFocusInTouch = new UIMenuItem();
      MainContainerHelper.MenuItemInTouchSendMessage = new UIMenuItem();
      MainContainerHelper.MenuItemInTouchShowMessages = new UIMenuItem();
      MainContainerHelper.menuItemFeesBillingSendMessage = new UIMenuItem();
      MainContainerHelper.menuItemStudentSendStudentMessage = new UIMenuItem();
      MainContainerHelper.menuItemReportsInTouch = new UIMenuItem();
      MainContainerHelper.menuItemFailedOutboundMessages = new UIMenuItem();
      MainContainerHelper.menuItemContactDetailsVerification = new UIMenuItem();
      MainContainerHelper.menuItemMessagingAudit = new UIMenuItem();
      MainContainerHelper.menuItemReportsInTouchExams = new UIMenuItem();
      MainContainerHelper.menuItemSendExamTimetableMessages = new UIMenuItem();
      MainContainerHelper.menuItemSendExamResultsMessages = new UIMenuItem();
      MainContainerHelper.menuItemRoutinesInTouch = new UIMenuItem();
      MainContainerHelper.menuItemExportContactDetails = new UIMenuItem();
      MainContainerHelper.menuItemToolsInTouch = new UIMenuItem();
      MainContainerHelper.menuItemInTouchServiceSetup = new UIMenuItem();
      MainContainerHelper.menuItemInTouchModuleSetup = new UIMenuItem();
      MainContainerHelper.menuItemInTouchDefaultsSetup = new UIMenuItem();
      MainContainerHelper.menuItemInTouchMessageTypeDefaultsSetup = new UIMenuItem();
      MainContainerHelper.menuItemInTouchTemplatesSetup = new UIMenuItem();
      MainContainerHelper.menuItemInTouchAchievementAlertsSetup = new UIMenuItem();
      MainContainerHelper.menuItemInTouchBehaviourIncidentAlertsSetup = new UIMenuItem();
      MainContainerHelper.menuItemInTouchCumulativeAchievementAlertsSetup = new UIMenuItem();
      MainContainerHelper.menuItemInTouchMissingResultsAlertsSetup = new UIMenuItem();
      MainContainerHelper.menuItemInTouchExamReminderAlertsSetup = new UIMenuItem();
      MainContainerHelper.menuItemInTouchExamResultsSetup = new UIMenuItem();
      MainContainerHelper.menuItemToolsPrimaryContactDetails = new UIMenuItem();
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudents = new UIMenuItem();
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicants = new UIMenuItem();
      MainContainerHelper.menuItemToolsPrimaryContactDetailsStudents = new UIMenuItem();
      menuItem1.MenuItems.Add(menuItem3.Index + 1, (MenuItem) MainContainerHelper.menuItemFocusInTouch);
      menuItem4.MenuItems.Add(menuItem5.Index + 1, (MenuItem) MainContainerHelper.menuItemReportsInTouch);
      menuItem4.MenuItems.Add(MainContainerHelper.menuItemReportsInTouch.Index + 1, (MenuItem) MainContainerHelper.menuItemReportsInTouchExams);
      menuItem6.MenuItems.Add(menuItem7.Index + 1, (MenuItem) MainContainerHelper.menuItemRoutinesInTouch);
      menuItem8.MenuItems.Add(menuItem10.Index + 1, (MenuItem) MainContainerHelper.menuItemToolsInTouch);
      menuItem9.MenuItems.Add(menuItem11.Index + 1, (MenuItem) MainContainerHelper.menuItemToolsPrimaryContactDetails);
      menuItem2.MenuItems.Add((MenuItem) MainContainerHelper.menuItemFeesBillingSendMessage);
      menuItem12.MenuItems.Add((MenuItem) MainContainerHelper.menuItemStudentSendStudentMessage);
      MainContainerHelper.menuItemFocusInTouch.ImageIndex = -1;
      MainContainerHelper.menuItemFocusInTouch.ImageList = (ImageList) null;
      MainContainerHelper.menuItemFocusInTouch.MenuItems.Add((MenuItem) MainContainerHelper.MenuItemInTouchSendMessage);
      MainContainerHelper.menuItemFocusInTouch.MenuItems.Add((MenuItem) MainContainerHelper.MenuItemInTouchShowMessages);
      MainContainerHelper.menuItemFocusInTouch.NoEdit = false;
      MainContainerHelper.menuItemFocusInTouch.NoUIModify = false;
      MainContainerHelper.menuItemFocusInTouch.OriginalText = "";
      MainContainerHelper.menuItemFocusInTouch.OwnerDraw = true;
      MainContainerHelper.menuItemFocusInTouch.Text = "&InTouch";
      MainContainerHelper.MenuItemInTouchSendMessage.ImageIndex = -1;
      MainContainerHelper.MenuItemInTouchSendMessage.ImageList = (ImageList) null;
      MainContainerHelper.MenuItemInTouchSendMessage.NoEdit = false;
      MainContainerHelper.MenuItemInTouchSendMessage.NoUIModify = false;
      MainContainerHelper.MenuItemInTouchSendMessage.OriginalText = "";
      MainContainerHelper.MenuItemInTouchSendMessage.OwnerDraw = true;
      MainContainerHelper.MenuItemInTouchSendMessage.Text = "&Send Message";
      MainContainerHelper.MenuItemInTouchSendMessage.Click += new EventHandler(MainContainerHelper.menuItemInTouchSendMessage_Click);
      MainContainerHelper.MenuItemInTouchShowMessages.ImageIndex = -1;
      MainContainerHelper.MenuItemInTouchShowMessages.ImageList = (ImageList) null;
      MainContainerHelper.MenuItemInTouchShowMessages.NoEdit = false;
      MainContainerHelper.MenuItemInTouchShowMessages.NoUIModify = false;
      MainContainerHelper.MenuItemInTouchShowMessages.OriginalText = "";
      MainContainerHelper.MenuItemInTouchShowMessages.OwnerDraw = true;
      MainContainerHelper.MenuItemInTouchShowMessages.Text = "Show &Messages";
      MainContainerHelper.MenuItemInTouchShowMessages.Click += new EventHandler(MainContainerHelper.menuItemInTouchShowMessagesClick);
      MainContainerHelper.menuItemFeesBillingSendMessage.ImageIndex = 161;
      MainContainerHelper.menuItemFeesBillingSendMessage.ImageList = StandardIcons.Get();
      MainContainerHelper.menuItemFeesBillingSendMessage.NoEdit = false;
      MainContainerHelper.menuItemFeesBillingSendMessage.NoUIModify = false;
      MainContainerHelper.menuItemFeesBillingSendMessage.OriginalText = "";
      MainContainerHelper.menuItemFeesBillingSendMessage.OwnerDraw = true;
      MainContainerHelper.menuItemFeesBillingSendMessage.Text = "&Send Message";
      MainContainerHelper.menuItemFeesBillingSendMessage.Click += new EventHandler(MainContainerHelper.menuItemFeesBillingSendMessage_Click);
      MainContainerHelper.menuItemStudentSendStudentMessage.ImageIndex = -1;
      MainContainerHelper.menuItemStudentSendStudentMessage.ImageList = (ImageList) null;
      MainContainerHelper.menuItemStudentSendStudentMessage.NoEdit = false;
      MainContainerHelper.menuItemStudentSendStudentMessage.NoUIModify = false;
      MainContainerHelper.menuItemStudentSendStudentMessage.OriginalText = "";
      MainContainerHelper.menuItemStudentSendStudentMessage.OwnerDraw = true;
      MainContainerHelper.menuItemStudentSendStudentMessage.Text = Text.ReplaceTexts("Send Student &Message");
      MainContainerHelper.menuItemStudentSendStudentMessage.Click += new EventHandler(MainContainerHelper.menuItemStudentSendStudentMessage_Click);
      MainContainerHelper.menuItemReportsInTouch.ImageIndex = -1;
      MainContainerHelper.menuItemReportsInTouch.ImageList = (ImageList) null;
      MainContainerHelper.menuItemReportsInTouch.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) MainContainerHelper.menuItemFailedOutboundMessages,
        (MenuItem) MainContainerHelper.menuItemContactDetailsVerification,
        (MenuItem) MainContainerHelper.menuItemMessagingAudit
      });
      MainContainerHelper.menuItemReportsInTouch.NoEdit = false;
      MainContainerHelper.menuItemReportsInTouch.NoUIModify = false;
      MainContainerHelper.menuItemReportsInTouch.OriginalText = "";
      MainContainerHelper.menuItemReportsInTouch.OwnerDraw = true;
      MainContainerHelper.menuItemReportsInTouch.Text = "InT&ouch";
      MainContainerHelper.menuItemFailedOutboundMessages.ImageIndex = -1;
      MainContainerHelper.menuItemFailedOutboundMessages.ImageList = (ImageList) null;
      MainContainerHelper.menuItemFailedOutboundMessages.NoEdit = false;
      MainContainerHelper.menuItemFailedOutboundMessages.NoUIModify = false;
      MainContainerHelper.menuItemFailedOutboundMessages.OriginalText = "";
      MainContainerHelper.menuItemFailedOutboundMessages.OwnerDraw = true;
      MainContainerHelper.menuItemFailedOutboundMessages.Text = "&Failed Outbound Messages";
      MainContainerHelper.menuItemFailedOutboundMessages.Click += new EventHandler(MainContainerHelper.menuItemFailedOutboundMessages_Click);
      MainContainerHelper.menuItemContactDetailsVerification.ImageIndex = -1;
      MainContainerHelper.menuItemContactDetailsVerification.ImageList = (ImageList) null;
      MainContainerHelper.menuItemContactDetailsVerification.NoEdit = false;
      MainContainerHelper.menuItemContactDetailsVerification.NoUIModify = false;
      MainContainerHelper.menuItemContactDetailsVerification.OriginalText = "";
      MainContainerHelper.menuItemContactDetailsVerification.OwnerDraw = true;
      MainContainerHelper.menuItemContactDetailsVerification.Text = "&Contact Details Verification";
      MainContainerHelper.menuItemContactDetailsVerification.Click += new EventHandler(MainContainerHelper.menuItemContactDetailsVerification_Click);
      MainContainerHelper.menuItemContactDetailsVerification.Visible = false;
      MainContainerHelper.menuItemMessagingAudit.ImageIndex = -1;
      MainContainerHelper.menuItemMessagingAudit.ImageList = (ImageList) null;
      MainContainerHelper.menuItemMessagingAudit.NoEdit = false;
      MainContainerHelper.menuItemMessagingAudit.NoUIModify = false;
      MainContainerHelper.menuItemMessagingAudit.OriginalText = "";
      MainContainerHelper.menuItemMessagingAudit.OwnerDraw = true;
      MainContainerHelper.menuItemMessagingAudit.Text = "&Messaging Audit";
      MainContainerHelper.menuItemMessagingAudit.Click += new EventHandler(MainContainerHelper.menuItemMessagingAudit_Click);
      MainContainerHelper.menuItemReportsInTouchExams.ImageIndex = -1;
      MainContainerHelper.menuItemReportsInTouchExams.ImageList = (ImageList) null;
      MainContainerHelper.menuItemReportsInTouchExams.MenuItems.AddRange(new MenuItem[2]
      {
        (MenuItem) MainContainerHelper.menuItemSendExamTimetableMessages,
        (MenuItem) MainContainerHelper.menuItemSendExamResultsMessages
      });
      MainContainerHelper.menuItemReportsInTouchExams.NoEdit = false;
      MainContainerHelper.menuItemReportsInTouchExams.NoUIModify = false;
      MainContainerHelper.menuItemReportsInTouchExams.OriginalText = "";
      MainContainerHelper.menuItemReportsInTouchExams.OwnerDraw = true;
      MainContainerHelper.menuItemReportsInTouchExams.Text = "E&xams";
      MainContainerHelper.menuItemSendExamTimetableMessages.ImageIndex = -1;
      MainContainerHelper.menuItemSendExamTimetableMessages.ImageList = (ImageList) null;
      MainContainerHelper.menuItemSendExamTimetableMessages.NoEdit = false;
      MainContainerHelper.menuItemSendExamTimetableMessages.NoUIModify = false;
      MainContainerHelper.menuItemSendExamTimetableMessages.OriginalText = "";
      MainContainerHelper.menuItemSendExamTimetableMessages.OwnerDraw = true;
      MainContainerHelper.menuItemSendExamTimetableMessages.Text = "Send Timetable&s";
      MainContainerHelper.menuItemSendExamTimetableMessages.Click += new EventHandler(MainContainerHelper.menuItemSendExamTimetableMessages_Click);
      MainContainerHelper.menuItemSendExamResultsMessages.ImageIndex = -1;
      MainContainerHelper.menuItemSendExamResultsMessages.ImageList = (ImageList) null;
      MainContainerHelper.menuItemSendExamResultsMessages.NoEdit = false;
      MainContainerHelper.menuItemSendExamResultsMessages.NoUIModify = false;
      MainContainerHelper.menuItemSendExamTimetableMessages.OriginalText = "";
      MainContainerHelper.menuItemSendExamResultsMessages.OwnerDraw = true;
      MainContainerHelper.menuItemSendExamResultsMessages.Text = "Send Exam &Results";
      MainContainerHelper.menuItemSendExamResultsMessages.Click += new EventHandler(MainContainerHelper.menuItemReportsInTouchExams_Click);
      MainContainerHelper.menuItemRoutinesInTouch.ImageIndex = -1;
      MainContainerHelper.menuItemRoutinesInTouch.ImageList = (ImageList) null;
      MainContainerHelper.menuItemRoutinesInTouch.MenuItems.Add((MenuItem) MainContainerHelper.menuItemExportContactDetails);
      MainContainerHelper.menuItemRoutinesInTouch.NoEdit = false;
      MainContainerHelper.menuItemRoutinesInTouch.NoUIModify = false;
      MainContainerHelper.menuItemRoutinesInTouch.OriginalText = "";
      MainContainerHelper.menuItemRoutinesInTouch.OwnerDraw = true;
      MainContainerHelper.menuItemRoutinesInTouch.Text = "&InTouch";
      MainContainerHelper.menuItemExportContactDetails.ImageIndex = -1;
      MainContainerHelper.menuItemExportContactDetails.ImageList = (ImageList) null;
      MainContainerHelper.menuItemExportContactDetails.NoEdit = false;
      MainContainerHelper.menuItemExportContactDetails.NoUIModify = false;
      MainContainerHelper.menuItemExportContactDetails.OriginalText = "";
      MainContainerHelper.menuItemExportContactDetails.OwnerDraw = true;
      MainContainerHelper.menuItemExportContactDetails.Text = "&Export Contact Details";
      MainContainerHelper.menuItemExportContactDetails.Click += new EventHandler(MainContainerHelper.menuItemExportContactDetails_Click);
      MainContainerHelper.menuItemToolsInTouch.ImageIndex = -1;
      MainContainerHelper.menuItemToolsInTouch.ImageList = (ImageList) null;
      MainContainerHelper.menuItemToolsInTouch.MenuItems.Add((MenuItem) MainContainerHelper.menuItemInTouchServiceSetup);
      MainContainerHelper.menuItemToolsInTouch.MenuItems.Add((MenuItem) MainContainerHelper.menuItemInTouchModuleSetup);
      MainContainerHelper.menuItemToolsInTouch.MenuItems.Add((MenuItem) MainContainerHelper.menuItemInTouchDefaultsSetup);
      MainContainerHelper.menuItemToolsInTouch.MenuItems.Add((MenuItem) MainContainerHelper.menuItemInTouchMessageTypeDefaultsSetup);
      MainContainerHelper.menuItemToolsInTouch.MenuItems.Add((MenuItem) MainContainerHelper.menuItemInTouchTemplatesSetup);
      MainContainerHelper.menuItemToolsInTouch.MenuItems.Add((MenuItem) MainContainerHelper.menuItemInTouchAchievementAlertsSetup);
      MainContainerHelper.menuItemToolsInTouch.MenuItems.Add((MenuItem) MainContainerHelper.menuItemInTouchBehaviourIncidentAlertsSetup);
      MainContainerHelper.menuItemToolsInTouch.MenuItems.Add((MenuItem) MainContainerHelper.menuItemInTouchCumulativeAchievementAlertsSetup);
      MainContainerHelper.menuItemToolsInTouch.MenuItems.Add((MenuItem) MainContainerHelper.menuItemInTouchMissingResultsAlertsSetup);
      MainContainerHelper.menuItemToolsInTouch.MenuItems.Add((MenuItem) MainContainerHelper.menuItemInTouchExamReminderAlertsSetup);
      MainContainerHelper.menuItemToolsInTouch.MenuItems.Add((MenuItem) MainContainerHelper.menuItemInTouchExamResultsSetup);
      MainContainerHelper.menuItemToolsInTouch.NoEdit = false;
      MainContainerHelper.menuItemToolsInTouch.NoUIModify = false;
      MainContainerHelper.menuItemToolsInTouch.OriginalText = "";
      MainContainerHelper.menuItemToolsInTouch.OwnerDraw = true;
      MainContainerHelper.menuItemToolsInTouch.Text = "&InTouch";
      MainContainerHelper.menuItemInTouchServiceSetup.ImageIndex = -1;
      MainContainerHelper.menuItemInTouchServiceSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemInTouchServiceSetup.NoEdit = false;
      MainContainerHelper.menuItemInTouchServiceSetup.NoUIModify = false;
      MainContainerHelper.menuItemInTouchServiceSetup.OriginalText = "";
      MainContainerHelper.menuItemInTouchServiceSetup.OwnerDraw = true;
      MainContainerHelper.menuItemInTouchServiceSetup.Text = "&Service Setup";
      MainContainerHelper.menuItemInTouchServiceSetup.Click += new EventHandler(MainContainerHelper.menuItemInTouchServiceSetup_Click);
      MainContainerHelper.menuItemInTouchModuleSetup.ImageIndex = -1;
      MainContainerHelper.menuItemInTouchModuleSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemInTouchModuleSetup.NoEdit = false;
      MainContainerHelper.menuItemInTouchModuleSetup.NoUIModify = false;
      MainContainerHelper.menuItemInTouchModuleSetup.OriginalText = "";
      MainContainerHelper.menuItemInTouchModuleSetup.OwnerDraw = true;
      MainContainerHelper.menuItemInTouchModuleSetup.Text = "&Module Setup";
      MainContainerHelper.menuItemInTouchModuleSetup.Click += new EventHandler(MainContainerHelper.menuItemInTouchModuleSetup_Click);
      MainContainerHelper.menuItemInTouchDefaultsSetup.ImageIndex = -1;
      MainContainerHelper.menuItemInTouchDefaultsSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemInTouchDefaultsSetup.NoEdit = false;
      MainContainerHelper.menuItemInTouchDefaultsSetup.NoUIModify = false;
      MainContainerHelper.menuItemInTouchDefaultsSetup.OriginalText = "";
      MainContainerHelper.menuItemInTouchDefaultsSetup.OwnerDraw = true;
      MainContainerHelper.menuItemInTouchDefaultsSetup.Text = "&Defaults Setup";
      MainContainerHelper.menuItemInTouchDefaultsSetup.Click += new EventHandler(MainContainerHelper.menuItemInTouchDefaultsSetup_Click);
      MainContainerHelper.menuItemInTouchMessageTypeDefaultsSetup.ImageIndex = -1;
      MainContainerHelper.menuItemInTouchMessageTypeDefaultsSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemInTouchMessageTypeDefaultsSetup.NoEdit = false;
      MainContainerHelper.menuItemInTouchMessageTypeDefaultsSetup.NoUIModify = false;
      MainContainerHelper.menuItemInTouchMessageTypeDefaultsSetup.OriginalText = "";
      MainContainerHelper.menuItemInTouchMessageTypeDefaultsSetup.OwnerDraw = true;
      MainContainerHelper.menuItemInTouchMessageTypeDefaultsSetup.Text = "Message T&ype Defaults Setup";
      MainContainerHelper.menuItemInTouchMessageTypeDefaultsSetup.Click += new EventHandler(MainContainerHelper.menuItemInTouchMessageTypeDefaultsSetup_Click);
      MainContainerHelper.menuItemInTouchTemplatesSetup.ImageIndex = -1;
      MainContainerHelper.menuItemInTouchTemplatesSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemInTouchTemplatesSetup.NoEdit = false;
      MainContainerHelper.menuItemInTouchTemplatesSetup.NoUIModify = false;
      MainContainerHelper.menuItemInTouchTemplatesSetup.OriginalText = "";
      MainContainerHelper.menuItemInTouchTemplatesSetup.OwnerDraw = true;
      MainContainerHelper.menuItemInTouchTemplatesSetup.Text = "&Templates Setup";
      MainContainerHelper.menuItemInTouchTemplatesSetup.Click += new EventHandler(MainContainerHelper.menuItemInTouchTemplatesSetup_Click);
      MainContainerHelper.menuItemInTouchAchievementAlertsSetup.ImageIndex = -1;
      MainContainerHelper.menuItemInTouchAchievementAlertsSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemInTouchAchievementAlertsSetup.NoEdit = false;
      MainContainerHelper.menuItemInTouchAchievementAlertsSetup.NoUIModify = false;
      MainContainerHelper.menuItemInTouchAchievementAlertsSetup.OriginalText = "";
      MainContainerHelper.menuItemInTouchAchievementAlertsSetup.OwnerDraw = true;
      MainContainerHelper.menuItemInTouchAchievementAlertsSetup.Text = "&Achievement Alerts Setup";
      MainContainerHelper.menuItemInTouchAchievementAlertsSetup.Click += new EventHandler(MainContainerHelper.menuItemInTouchAchievementAlertsSetupClick);
      MainContainerHelper.menuItemInTouchBehaviourIncidentAlertsSetup.ImageIndex = -1;
      MainContainerHelper.menuItemInTouchBehaviourIncidentAlertsSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemInTouchBehaviourIncidentAlertsSetup.NoEdit = false;
      MainContainerHelper.menuItemInTouchBehaviourIncidentAlertsSetup.NoUIModify = false;
      MainContainerHelper.menuItemInTouchBehaviourIncidentAlertsSetup.OriginalText = "";
      MainContainerHelper.menuItemInTouchBehaviourIncidentAlertsSetup.OwnerDraw = true;
      MainContainerHelper.menuItemInTouchBehaviourIncidentAlertsSetup.Text = "&Behaviour Incident Alerts Setup";
      MainContainerHelper.menuItemInTouchBehaviourIncidentAlertsSetup.Click += new EventHandler(MainContainerHelper.menuItemInTouchBehaviourIncidentAlertsSetupClick);
      MainContainerHelper.menuItemInTouchCumulativeAchievementAlertsSetup.ImageIndex = -1;
      MainContainerHelper.menuItemInTouchCumulativeAchievementAlertsSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemInTouchCumulativeAchievementAlertsSetup.NoEdit = false;
      MainContainerHelper.menuItemInTouchCumulativeAchievementAlertsSetup.NoUIModify = false;
      MainContainerHelper.menuItemInTouchCumulativeAchievementAlertsSetup.OriginalText = "";
      MainContainerHelper.menuItemInTouchCumulativeAchievementAlertsSetup.OwnerDraw = true;
      MainContainerHelper.menuItemInTouchCumulativeAchievementAlertsSetup.Text = "&Cumulative Achievement Alerts Setup";
      MainContainerHelper.menuItemInTouchCumulativeAchievementAlertsSetup.Click += new EventHandler(MainContainerHelper.menuItemInTouchCumulativeAchievementAlertsSetupClick);
      MainContainerHelper.menuItemInTouchMissingResultsAlertsSetup.ImageIndex = -1;
      MainContainerHelper.menuItemInTouchMissingResultsAlertsSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemInTouchMissingResultsAlertsSetup.NoEdit = false;
      MainContainerHelper.menuItemInTouchMissingResultsAlertsSetup.NoUIModify = false;
      MainContainerHelper.menuItemInTouchMissingResultsAlertsSetup.OriginalText = "";
      MainContainerHelper.menuItemInTouchMissingResultsAlertsSetup.OwnerDraw = true;
      MainContainerHelper.menuItemInTouchMissingResultsAlertsSetup.Text = "M&issing Marksheets Alerts Setup";
      MainContainerHelper.menuItemInTouchMissingResultsAlertsSetup.Click += new EventHandler(MainContainerHelper.menuItemInTouchMissingResultsAlertsSetupClick);
      MainContainerHelper.menuItemInTouchExamReminderAlertsSetup.ImageIndex = -1;
      MainContainerHelper.menuItemInTouchExamReminderAlertsSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemInTouchExamReminderAlertsSetup.NoEdit = false;
      MainContainerHelper.menuItemInTouchExamReminderAlertsSetup.NoUIModify = false;
      MainContainerHelper.menuItemInTouchExamReminderAlertsSetup.OriginalText = "";
      MainContainerHelper.menuItemInTouchExamReminderAlertsSetup.OwnerDraw = true;
      MainContainerHelper.menuItemInTouchExamReminderAlertsSetup.Text = "&Exam Reminder Alerts Setup";
      MainContainerHelper.menuItemInTouchExamReminderAlertsSetup.Click += new EventHandler(MainContainerHelper.menuItemInTouchExamReminderAlertsSetupClick);
      MainContainerHelper.menuItemInTouchExamResultsSetup.ImageIndex = -1;
      MainContainerHelper.menuItemInTouchExamResultsSetup.ImageList = (ImageList) null;
      MainContainerHelper.menuItemInTouchExamResultsSetup.NoEdit = false;
      MainContainerHelper.menuItemInTouchExamResultsSetup.NoUIModify = false;
      MainContainerHelper.menuItemInTouchExamResultsSetup.OriginalText = "";
      MainContainerHelper.menuItemInTouchExamResultsSetup.OwnerDraw = true;
      MainContainerHelper.menuItemInTouchExamResultsSetup.Text = "Exam &Results Setup";
      MainContainerHelper.menuItemInTouchExamResultsSetup.Click += new EventHandler(MainContainerHelper.menuItemInTouchExamResultsSetupClick);
      MainContainerHelper.menuItemToolsPrimaryContactDetails.ImageIndex = -1;
      MainContainerHelper.menuItemToolsPrimaryContactDetails.ImageList = (ImageList) null;
      MainContainerHelper.menuItemToolsPrimaryContactDetails.NoEdit = false;
      MainContainerHelper.menuItemToolsPrimaryContactDetails.NoUIModify = false;
      MainContainerHelper.menuItemToolsPrimaryContactDetails.OriginalText = "";
      MainContainerHelper.menuItemToolsPrimaryContactDetails.OwnerDraw = true;
      MainContainerHelper.menuItemToolsPrimaryContactDetails.Text = "Primary &Contact Details";
      MainContainerHelper.menuItemToolsPrimaryContactDetails.MenuItems.AddRange(new MenuItem[3]
      {
        (MenuItem) MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudents,
        (MenuItem) MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicants,
        (MenuItem) MainContainerHelper.menuItemToolsPrimaryContactDetailsStudents
      });
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudents.ImageIndex = -1;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudents.ImageList = (ImageList) null;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudents.Index = 0;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudents.NoEdit = false;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudents.NoUIModify = false;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudents.OriginalText = "";
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudents.OwnerDraw = true;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudents.Text = "&Contacts of Students";
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudents.Click += new EventHandler(MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudentsClick);
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicants.ImageIndex = -1;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicants.ImageList = (ImageList) null;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicants.Index = 1;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicants.NoEdit = false;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicants.NoUIModify = false;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicants.OriginalText = "";
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicants.OwnerDraw = true;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicants.Text = "Contacts of &Applicants";
      MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicants.Click += new EventHandler(MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicantsClick);
      MainContainerHelper.menuItemToolsPrimaryContactDetailsStudents.ImageIndex = -1;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsStudents.ImageList = (ImageList) null;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsStudents.Index = 2;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsStudents.NoEdit = false;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsStudents.NoUIModify = false;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsStudents.OriginalText = "";
      MainContainerHelper.menuItemToolsPrimaryContactDetailsStudents.OwnerDraw = true;
      MainContainerHelper.menuItemToolsPrimaryContactDetailsStudents.Text = "&Students";
      MainContainerHelper.menuItemToolsPrimaryContactDetailsStudents.Click += new EventHandler(MainContainerHelper.menuItemToolsPrimaryContactDetailsStudentsClick);
      Utilities.ReplaceAllTexts((System.Windows.Forms.Form) null, (IEnumerable<Control>) null, (IEnumerable<Menu>) new Menu[6]
      {
        (Menu) MainContainerHelper.menuItemFocusInTouch,
        (Menu) MainContainerHelper.menuItemReportsInTouch,
        (Menu) MainContainerHelper.menuItemReportsInTouchExams,
        (Menu) MainContainerHelper.menuItemRoutinesInTouch,
        (Menu) MainContainerHelper.menuItemToolsInTouch,
        (Menu) MainContainerHelper.menuItemToolsPrimaryContactDetails
      }, (IEnumerable<System.Windows.Forms.ToolBar>) null);
    }

    public static void RebuildMenus()
    {
      MainContainerHelper.MenuItemInTouchSendMessage.Visible = SIMS.Entities.InTouch.Cache.IsLicensed && SIMS.Entities.Cache.ProcessVisible("InTouch.SendGeneralMessageHost");
      MainContainerHelper.menuItemStudentSendStudentMessage.Visible = SIMS.Entities.InTouch.Cache.IsLicensed && SIMS.Entities.Cache.ProcessVisible("InTouch.SendStudentMessageHost");
      MainContainerHelper.MenuItemInTouchShowMessages.Visible = SIMS.Entities.InTouch.Cache.IsLicensed && SIMS.Entities.Cache.ProcessVisible("HPViewMyMessages");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemFeesBillingSendMessage, "InTouch.SendBillPayerMessageHost");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemFailedOutboundMessages, "InTouch.ViewFailedOutboundMessagesReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemMessagingAudit, "InTouch.ViewMessagingAuditReport");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemExportContactDetails, "InTouch.ExportContactDetails");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemInTouchServiceSetup, "InTouch.ServiceDetail");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemInTouchModuleSetup, "InTouch.SetupDetail");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemInTouchDefaultsSetup, "InTouch.RecipientCommunicationDefaultDetail");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemInTouchMessageTypeDefaultsSetup, "InTouch.RecipientCommunicationDefaultDetail");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemInTouchTemplatesSetup, "InTouch.TemplatesDetailHost");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemInTouchAchievementAlertsSetup, "InTouch.AchievementAlertDefinitionView");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemInTouchBehaviourIncidentAlertsSetup, "InTouch.BehaviourIncidentAlertDefinitionView");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemInTouchCumulativeAchievementAlertsSetup, "InTouch.CumulativeAchievementAlertDefinitionView");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsStudents, "InTouch.StudentContactPrimaryContactsEdit");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemToolsPrimaryContactDetailsContactsApplicants, "InTouch.ApplicantContactPrimaryContactsEdit");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemToolsPrimaryContactDetailsStudents, "InTouch.StudentPrimaryContactsEdit");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemInTouchMissingResultsAlertsSetup, "InTouch.MissingResultsAlertDefinitionView");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemInTouchExamReminderAlertsSetup, "InTouch.ExamReminderAlertDefinitionView");
      SIMS.UserInterfaces.Utilities.SetMenuItemVisibility((MenuItem) MainContainerHelper.menuItemStudentSendStudentMessage, "InTouch.SendStudentMessageHost");
      MainContainerHelper.menuItemSendExamTimetableMessages.Visible = SIMS.Entities.InTouch.Cache.IsLicensed && SIMS.Entities.Cache.ProcessVisible("InTouch.StudentExamTTDetails");
      MainContainerHelper.menuItemInTouchExamResultsSetup.Visible = SIMS.Entities.InTouch.Cache.IsLicensed && SIMS.Entities.Cache.ProcessVisible("InTouch.ExamResultsDefinitionView");
      MainContainerHelper.menuItemSendExamResultsMessages.Visible = SIMS.Entities.InTouch.Cache.IsLicensed && SIMS.Entities.Cache.ProcessVisible("InTouch.SendStudentExamResults");
    }

    public static void SetupContextMenus()
    {
      if (!SIMS.Entities.InTouch.Cache.IsLicensed)
        return;
      if (SIMS.Entities.Cache.ProcessVisible("InTouch.SendGeneralMessageHost"))
        NavigationRouteCache.AddRoute("Send Message", new NavigationRouteDelegate(MainContainerHelper.contextSendEmployeeMessage), new int[1]
        {
          28
        }, typeof (SendGeneralMessageHost));
      if (SIMS.Entities.Cache.ProcessVisible("InTouch.SendGeneralMessageHost"))
        NavigationRouteCache.AddRoute("Send Message", new NavigationRouteDelegate(MainContainerHelper.contextSendAgentMessage), new int[1]
        {
          2
        }, typeof (SendGeneralMessageHost));
      if (!SIMS.Entities.Cache.ProcessVisible("InTouch.SendBillPayerMessageHost"))
        return;
      NavigationRouteCache.AddRoute("Send Message", new NavigationRouteDelegate(MainContainerHelper.contextSendBillPayerMessage), new int[1]
      {
        47
      }, typeof (SendBillPayerMessageHost));
    }

    private static Control DisplayComponent(Control component)
    {
      return MainContainerHelper.displayComponent((IIDEntity) null, component);
    }

    private static Control ExistsComponent(string componentName)
    {
      return MainContainerHelper.componentExists(componentName);
    }

    internal static void CheckInTouchServices()
    {
      if (!SIMS.Entities.InTouch.Cache.IsLicensed || !SIMS.Entities.Cache.UpgradeHelpRequired)
        return;
      ServicesStatus servicesStatus = SchoolServices.Check();
      if (servicesStatus.IsCompatible)
        return;
      int num = (int) MessageBox.Show(string.Format("There is a problem with your InTouch services.\r\n\r\nPlease contact your local support unit.\r\n\r\n({0})", (object) servicesStatus.ErrorMessage), SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    internal static bool CanPulsarClose()
    {
      if (!SaveQueuedMessages.IsProcessing())
        return true;
      int num = (int) MessageBox.Show("InTouch alert messages are currently being queued. Please try again in a short while.", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      return false;
    }

    private static void menuItemInTouchSendMessage_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new SendGeneralMessageHost());
    }

    private static void menuItemStudentSendStudentMessage_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup() || (Component) MainContainerHelper.ExistsComponent("SIMS.UserInterfaces.InTouch.SendStudentMessageHost") != null)
        return;
      DlgStudentBrowse dlgStudentBrowse = new DlgStudentBrowse()
      {
        MultiSelect = true
      };
      if (dlgStudentBrowse.ShowDialog() != DialogResult.OK)
        return;
      SIMS.Entities.Cache.HostNewControl((IIDEntity) null, (object) new SendStudentMessageHost(dlgStudentBrowse.Name, dlgStudentBrowse.SelectedStudents.Select<Student, int>((Func<Student, int>) (s => s.PersonID)).ToArray<int>(), (string) null, (string) null));
    }

    public static void menuItemInTouchShowMessagesClick(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new MessageDetail());
    }

    private static void menuItemFeesBillingSendMessage_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new SendBillPayerMessageHost());
    }

    public static void menuItemUnexplainedAbsence_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new SendUnexplainedAbsenceMessageHost());
    }

    public static void menuItemIntouchPercentageAttendanceNotification_Click(
      object sender,
      EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new SendPercentageAttendanceMessageHost());
    }

    public static void menuItemAchievementNotifications_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new SendAchievementNotificationMessageHost());
    }

    public static void menuItemBehaviourNotifications_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new SendBehaviourNotificationMessageHost());
    }

    public static void menuItemLateNotification_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new SendLateNotificationMessageHost());
    }

    private static void menuItemFailedOutboundMessages_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ViewFailedOutboundMessagesReport outboundMessagesReport = new ViewFailedOutboundMessagesReport())
      {
        int num = (int) outboundMessagesReport.ShowDialog();
      }
    }

    private static void menuItemContactDetailsVerification_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ViewContactDetailsVerificationReport verificationReport = new ViewContactDetailsVerificationReport())
      {
        int num = (int) verificationReport.ShowDialog();
      }
    }

    private static void menuItemMessagingAudit_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      using (ViewMessagingAuditReport messagingAuditReport = new ViewMessagingAuditReport())
      {
        int num = (int) messagingAuditReport.ShowDialog();
      }
    }

    private static void menuItemSendExamTimetableMessages_Click(object sender, EventArgs e)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup() || (Component) MainContainerHelper.ExistsComponent("SIMS.UserInterfaces.DlgExamTTStudentSelection") != null)
        return;
      DlgExamTTStudentSelection studentSelection = new DlgExamTTStudentSelection();
      if (studentSelection.ShowDialog() != DialogResult.OK)
        return;
      SIMS.Entities.Cache.HostNewControl((IIDEntity) null, (object) new SendStudentExamTimetableMessageHost(studentSelection.DlgSendTimetable.DataForInTouchHost.Item1, studentSelection.SelectedSeason.ID, studentSelection.DlgSendTimetable.DataForInTouchHost.Item3, studentSelection.DlgSendTimetable.DataForInTouchHost.Item4, studentSelection.DlgSendTimetable.DataForInTouchHost.Item5, studentSelection.DlgSendTimetable.DataForInTouchHost.Item6, studentSelection.DlgSendTimetable.DataForInTouchHost.Item7));
    }

    private static void menuItemReportsInTouchExams_Click(object sender, EventArgs e)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup() || (Component) MainContainerHelper.ExistsComponent("SIMS.UserInterfaces.DlgSendExamResults") != null)
        return;
      int num = (int) new DlgSendExamResults().ShowDialog();
    }

    private static void menuItemExportContactDetails_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      ExportContactDetails.Execute();
    }

    private static void menuItemInTouchServiceSetup_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new ServiceDetail());
    }

    private static void menuItemInTouchModuleSetup_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new SetupDetail());
    }

    private static void menuItemInTouchDefaultsSetup_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new RecipientCommunicationDefaultDetail());
    }

    private static void menuItemInTouchMessageTypeDefaultsSetup_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new MessageTypeDefaultMaintain());
    }

    private static void menuItemInTouchTemplatesSetup_Click(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new TemplatesDetailHost());
    }

    private static void menuItemInTouchAchievementAlertsSetupClick(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new AchievementAlertDefinitionMaintain());
    }

    private static void menuItemInTouchBehaviourIncidentAlertsSetupClick(
      object sender,
      EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new BehaviourIncidentAlertDefinitionMaintain());
    }

    private static void menuItemInTouchCumulativeAchievementAlertsSetupClick(
      object sender,
      EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new CumulativeAchievementAlertDefinitionMaintain());
    }

    private static void menuItemInTouchMissingResultsAlertsSetupClick(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new MissingResultsAlertDefinitionMaintain());
    }

    private static void menuItemInTouchExamReminderAlertsSetupClick(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new ExamReminderAlertDefinitionMaintain());
    }

    private static void menuItemInTouchExamResultsSetupClick(object sender, EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      MainContainerHelper.DisplayComponent((Control) new ExamResultsDefinitionMaintain());
    }

    private static void menuItemToolsPrimaryContactDetailsContactsStudentsClick(
      object sender,
      EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new StudentContactPrimaryContactsMaintain());
    }

    private static void menuItemToolsPrimaryContactDetailsContactsApplicantsClick(
      object sender,
      EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new ApplicantContactPrimaryContactsMaintain());
    }

    private static void menuItemToolsPrimaryContactDetailsStudentsClick(
      object sender,
      EventArgs args)
    {
      MainContainerHelper.recordMenuUsage(sender as UIMenuItem);
      MainContainerHelper.DisplayComponent((Control) new StudentPrimaryContactsMaintain());
    }

    private static bool checkInTouchServiceSetup()
    {
      SIMS.Processes.InTouch.Cache.Populate();
      if (!SIMS.Entities.InTouch.Cache.ServiceDetailsAvailable)
      {
        int num = (int) MessageBox.Show("This feature is unavailable because you have not completed the InTouch Service Setup screen.", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        return false;
      }
      ServicesStatus servicesStatus = SchoolServices.Check();
      if (servicesStatus.IsCompatible)
        return true;
      int num1 = (int) MessageBox.Show(string.Format("There is a problem with your InTouch services.\r\n\r\nPlease contact your local support unit.\r\n\r\n({0})", (object) servicesStatus.ErrorMessage), SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      return false;
    }

    private static void contextSendEmployeeMessage(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      Control control = MainContainerHelper.displayComponentWithInterfaces((Control) new SendEmployeeMessageHost(entityToDisplay));
    }

    private static void contextSendAgentMessage(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      Control control = MainContainerHelper.displayComponentWithInterfaces((Control) new SendAgentMessageHost(entityToDisplay));
    }

    private static void contextSendBillPayerMessage(
      IIDEntity entityToDisplay,
      bool showAsIndependentWindow)
    {
      if (!MainContainerHelper.checkInTouchServiceSetup())
        return;
      Control control = MainContainerHelper.displayComponentWithInterfaces((Control) new SendBillPayerMessageHost(entityToDisplay));
    }

    private static void cache_DisplayGeneralMessage(object message)
    {
      object obj = SIMS.Entities.InTouch.Cache.LaunchHost((object) new SendGeneralMessageHost(message));
    }

    private static void cache_StudentDetails(int personID)
    {
      MainContainerHelper.IDEntity idEntity = new MainContainerHelper.IDEntity(personID);
      if (!SIMS.Entities.Cache.Settings.ContainsKey("TeacherViewDefaultScreen") ? SIMS.Entities.Cache.Settings.ContainsKey("TeacherViewTeachingStaff") && SIMS.Entities.Cache.Settings["TeacherViewTeachingStaff"] == "T" && SIMS.Entities.Cache.ProcessAvailable("TeachersView") : SIMS.Entities.Cache.Settings["TeacherViewDefaultScreen"] == "1" && SIMS.Entities.Cache.ProcessAvailable("TeachersView"))
        SIMS.Entities.Cache.HostNewControl((IIDEntity) idEntity, (object) new TeacherViewStudentDetail((IIDEntity) idEntity));
      else
        SIMS.Entities.Cache.HostNewControl((IIDEntity) idEntity, (object) new EditStudent((IIDEntity) idEntity));
    }

    private static void cache_DisplaySenEvent(int studentID, int eventID)
    {
      MainContainerHelper.IDEntity idEntity = new MainContainerHelper.IDEntity(studentID);
      using (EditSENStudent component = new EditSENStudent((IIDEntity) idEntity))
      {
        component.Size = new Size(1, 1);
        component.MaximumSize = component.Size;
        component.Visible = false;
        component.VisibleChanged += (EventHandler) ((s, e) => component.Visible = false);
        MainContainerHelper.DisplayComponent((Control) component);
        component.DisplayEvent(eventID);
        component.Close((AbstractContainerControl) component);
      }
    }

    private static void cache_DisplaySenProvision(int studentID, int provisionID)
    {
      MainContainerHelper.IDEntity idEntity = new MainContainerHelper.IDEntity(studentID);
      using (EditSENStudent component = new EditSENStudent((IIDEntity) idEntity))
      {
        component.Size = new Size(1, 1);
        component.MaximumSize = component.Size;
        component.Visible = false;
        component.VisibleChanged += (EventHandler) ((s, e) => component.Visible = false);
        MainContainerHelper.DisplayComponent((Control) component);
        component.DisplayProvision(provisionID);
        component.Close((AbstractContainerControl) component);
      }
    }

    private static void cache_DisplaySenReview(int studentID, int reviewID)
    {
      MainContainerHelper.IDEntity idEntity = new MainContainerHelper.IDEntity(studentID);
      using (EditSENStudent component = new EditSENStudent((IIDEntity) idEntity))
      {
        component.Size = new Size(1, 1);
        component.MaximumSize = component.Size;
        component.Visible = false;
        component.VisibleChanged += (EventHandler) ((s, e) => component.Visible = false);
        MainContainerHelper.DisplayComponent((Control) component);
        component.DisplayReview(reviewID);
        component.Close((AbstractContainerControl) component);
      }
    }

    private static void cache_CreateSenEvent(int studentID, int? senderID, string comments)
    {
      MainContainerHelper.IDEntity idEntity = new MainContainerHelper.IDEntity(studentID);
      using (EditSENStudent component = new EditSENStudent((IIDEntity) idEntity))
      {
        component.Size = new Size(1, 1);
        component.MaximumSize = component.Size;
        component.Visible = false;
        component.VisibleChanged += (EventHandler) ((s, e) => component.Visible = false);
        MainContainerHelper.DisplayComponent((Control) component);
        component.CreateEvent(senderID, comments);
        component.Close((AbstractContainerControl) component);
      }
    }

    private static void cache_CreateSenProvision(int studentID, int? senderID, string comments)
    {
      MainContainerHelper.IDEntity idEntity = new MainContainerHelper.IDEntity(studentID);
      using (EditSENStudent component = new EditSENStudent((IIDEntity) idEntity))
      {
        component.Size = new Size(1, 1);
        component.MaximumSize = component.Size;
        component.Visible = false;
        component.VisibleChanged += (EventHandler) ((s, e) => component.Visible = false);
        MainContainerHelper.DisplayComponent((Control) component);
        component.CreateProvision(senderID, comments);
        component.Close((AbstractContainerControl) component);
      }
    }

    private static void cache_CreateSenReview(int studentID, int? senderID, string comments)
    {
      MainContainerHelper.IDEntity idEntity = new MainContainerHelper.IDEntity(studentID);
      using (EditSENStudent component = new EditSENStudent((IIDEntity) idEntity))
      {
        component.Size = new Size(1, 1);
        component.MaximumSize = component.Size;
        component.Visible = false;
        component.VisibleChanged += (EventHandler) ((s, e) => component.Visible = false);
        MainContainerHelper.DisplayComponent((Control) component);
        component.CreateReview(senderID, comments);
        component.Close((AbstractContainerControl) component);
      }
    }

    private static void cache_TakeAttRegister()
    {
      new ContextMenuLink().ExecuteRecommendedNavigationRoute(66, 0, (System.Type) null, true);
    }

    private static void cache_EditAttMarks(
      int personID,
      DateTime startDate,
      DateTime endDate,
      bool sessionsOnly)
    {
      EditMarksDetail editMarksDetail = new EditMarksDetail();
      DateRangeAndScope dras = new DateRangeAndScope(InformationDomainEnum.StudentAttendance, DRASScopeTypeEnum.DetailScreen)
      {
        StartDate = startDate,
        EndDate = endDate,
        DateSelectionType = DRASDateSelectionTypeEnum.Weeks,
        IncludeAcceptedApplicants = false,
        IncludeGuestStudents = true,
        UserID = SIMS.Entities.Cache.CurrentUser.UserID,
        PersonID = SIMS.Entities.Cache.CurrentUser.PersonID,
        SelectedScope = MainContainerHelper.scopeIndividualStudents,
        SelectedBrowserGroups = (IATWBrowserGroups) new ATWAttendees()
        {
          new ATWAttendee(InformationDomainEnum.StudentAttendance)
          {
            StudentIDAttribute = {
              Value = personID
            }
          }
        },
        SingleDate = true
      };
      ViewTypeEnum viewType = sessionsOnly ? ViewTypeEnum.viewSessions : ViewTypeEnum.viewSessionsLessons;
      editMarksDetail.LoadData(dras, viewType);
      SIMS.Entities.Cache.HostNewControl((IIDEntity) null, (object) editMarksDetail);
    }

    private static void cache_EmployeeDetails(int personID)
    {
      MainContainerHelper.IDEntity idEntity = new MainContainerHelper.IDEntity(personID);
      SIMS.Entities.Cache.HostNewControl((IIDEntity) idEntity, (object) new EmployeeDetailUI((IIDEntity) idEntity));
    }

    private static void cache_BehaviourIncidentDetails(int behaviourID)
    {
      if (!SIMS.Entities.Cache.ProcessAvailable("InTouch.MainContainerHelper"))
      {
        int num1 = (int) MessageBox.Show("You do not have permission to load this screen.", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (!new SIMS.Processes.InTouch.MainContainerHelper().BehaviourIncidentExists(behaviourID))
      {
        int num2 = (int) MessageBox.Show("The requested behaviour incident could not be found.  It may have been deleted.", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        MainContainerHelper.IDEntity idEntity = new MainContainerHelper.IDEntity(behaviourID);
        SIMS.Entities.Cache.HostNewControl((IIDEntity) idEntity, (object) new BehaviourIncidentDetail((IIDEntity) idEntity));
      }
    }

    private static void cache_AchievementDetails(int achievementID)
    {
      if (!SIMS.Entities.Cache.ProcessAvailable("InTouch.MainContainerHelper"))
      {
        int num1 = (int) MessageBox.Show("You do not have permission to load this screen.", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (!new SIMS.Processes.InTouch.MainContainerHelper().AchievementExists(achievementID))
      {
        int num2 = (int) MessageBox.Show("The requested achievement could not be found.  It may have been deleted.", SIMS.Entities.Cache.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        MainContainerHelper.IDEntity idEntity = new MainContainerHelper.IDEntity(achievementID);
        SIMS.Entities.Cache.HostNewControl((IIDEntity) idEntity, (object) new AchievementDetail((IIDEntity) idEntity));
      }
    }

    private class IDEntity : IIDEntity
    {
      private int id;

      int IIDEntity.ID
      {
        get
        {
          return this.id;
        }
        set
        {
        }
      }

      string IIDEntity.Description
      {
        get
        {
          return (string) null;
        }
      }

      public IDEntity(int id)
      {
        this.id = id;
      }
    }
  }
}
