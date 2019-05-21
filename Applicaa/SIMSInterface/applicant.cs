using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using System.Xml;
using SIMS.Entities;
using SIMS.Entities.Admissions;
using SIMS.Entities.ThirdParty;
using SIMS.Entities.ThirdParty.SIF;
using SIMS.Processes;
using SIMS.Processes.Admissions;
using SIMS.Processes.ThirdParty;
using SIMS.UserInterfaces;
using Ethnicity = SIMS.Entities.Ethnicity;
using GroupCache = SIMS.Entities.GroupCache;
using LookupCache = SIMS.Entities.LookupCache;

using StudentCache = SIMS.Entities.StudentCache;
using Telephone = SIMS.Entities.Telephone;

namespace SIMSInterface
{
    public enum Status
    {
        Failed,
        Success
    }

    public class ApplicantResult
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public ValidationErrors Errors { get; set; }
    }

    public class CreateApplicantsResult
    {
        public string StudentName { get; set; }
        public ApplicantResult ApplicantResult { get; set; }
    }

    public class Applicant
    {
        static ApplicationBrowser applicationBrowser = new ApplicationBrowser();
        static MaintainApplication mainApplication = new MaintainApplication();


        public static List<CreateApplicantsResult> CreateApplicants(ATfilePupil[] pupils, ATfileHeader header)
        {
            ConfigLogging();
            SIMS.Processes.GroupCache.Populate();
            //SchoolCache.
            //StudentCache.Populate();
            //SIMS.Processes.PersonCache.Populate();
            //SIMS.Processes.ContactCache.Populate();

            var rs = new List<CreateApplicantsResult>();
            foreach (var pupil in pupils)
            {
                var applicant = CreateApplicant(pupil, header);
                rs.Add(new CreateApplicantsResult
                {
                    StudentName = pupil.ApplicationReference + " - " + pupil.Forename + " " + pupil.Surname,
                    ApplicantResult = applicant
                });
            }

            return rs;
        }

        public static void ConfigLogging()
        {
            //Cache.LogFile = @"D:\Upwork\TimDixon\src\applicaa\Applicaa\Applicaa\bin\Debug\log.txt";
            // Set the  SIMS log file path (not used?)
            Cache.LogFile = (Environment.SpecialFolder.CommonApplicationData) + "\\SIMS_Log.txt";
        }

        private static ApplicantResult CreateApplicant(ATfilePupil pupil, ATfileHeader header)
        {
            string message = string.Empty;

            if (pupil == null) return new ApplicantResult
            {
                Status = Status.Failed,
                Message = "Pupil can not be null"
            };
            var enrollmentMode = (SIMS.Entities.DFESEnrolmentStatus)SIMS.Entities.LookupCache.DFESEnrolmentStatuses.Item(0);
            bool success = true;
            var errors = new SIMS.Entities.ValidationErrors();
            var person = new Person();

            
            var ethic = (Ethnicity) GroupCache.Ethnicities.ItemByCode(pupil.BasicDetails.Ethnicity);
            var ethicDataSource = GroupCache.EthnicDataSources.Item(pupil.BasicDetails.EthnicitySource);
            var leavingReason = (LeavingReason)LookupCache.LeavingReasons.ItemByCode(pupil.SchoolHistory.School.LeavingReason);

            //TODO Get NationID By Country of Birth

            //var countryOfBirth = new Nationality { NationCode = pupil.BasicDetails.CountryofBirth, NationID = 1 };
            var countryOfBirth = (Nation) LookupCache.Nations.ItemByCode(pupil.BasicDetails.CountryofBirth);
            var language = (LanguageSource) GroupCache.LanguageSources.ItemByCode(pupil.BasicDetails.Languages.Type.Language);

            


            #region populate schoolhistory

            var school = new SIMS.Entities.School();
            school.Assign(Cache.CurrentSchool);
            school.LEANumber = pupil.SchoolHistory.School.LEA.ToString();
            school.Name = pupil.SchoolHistory.School.SchoolName;

            var schoolHistory = new SchoolHistoryCollection
            {
                new SchoolHistory
                {                    
                    StartDate = pupil.SchoolHistory.School.EntryDate,
                    School = school,                                              
                    IsCurrentSchool = false,                    
                    DateOfLeaving = pupil.SchoolHistory.School.LeavingDate,
                    ReasonForLeaving = leavingReason,
                    EnrollmentMode = enrollmentMode
                }
            };
            #endregion


            var disability = new StudentDisabilities(1);
            var medicalPractices = new AgencyLinkedStudents();
            var fsm = new ApplicationFreeSchoolMeals();
            foreach (var freeMealSchool in pupil.FSMhistory.FSMinstance)
            {
                fsm.Add(new ApplicationFreeSchoolMeal
                {
                    StartDate = freeMealSchool.FSMstartDate,
                    EndDate = freeMealSchool.FSMendDate, 
                    
                                    
                });
            }
            var table  = new DataTable();
            table.Columns.Add("email_address", typeof(string));
            var row = table.NewRow();
            row["email_address"] = pupil.Email;
            table.Rows.Add(row);
            //m_Email, main, location is required
            var emails = new EMailCollection(InformationDomainEnum.ApplicationTelephoneEmail, table);

            //relation


            medicalPractices.Add(new AgencyLinkedStudent{});
            person.Forename = pupil.Forename;            
            person.Surname = pupil.Surname;
            person.MiddleName = pupil.BasicDetails.MiddleNames;
            person.Gender = (Gender) LookupCache.Genders.ItemByCode(pupil.Gender);
            person.DateOfBirth = DateTime.ParseExact(pupil.DOB, "yyyy-mm-dd", CultureInfo.InvariantCulture);

            mainApplication.CreateApplicationFromPerson(person);

            #region Telephones
            //(IIDCodeDescriptionEntity) new CodeDescriptionEntity(-1, "XXX", "XXXXXXXXXX"))
            //IDFactory.GetID();

            var telephoneTable = new DataTable();
            telephoneTable.Columns.Add("telephone_id", typeof(int));
            telephoneTable.Columns.Add("person_id", typeof(int));
            telephoneTable.Columns.Add("device", typeof(int));
            telephoneTable.Columns.Add("location", typeof(int));
            telephoneTable.Columns.Add("number", typeof(string));
            telephoneTable.Columns.Add("main", typeof(string));
            telephoneTable.Columns.Add("primary", typeof(string));
            telephoneTable.Columns.Add("notes", typeof(string));
            var rowTelephone = telephoneTable.NewRow();
            telephoneTable.Rows.Add(rowTelephone);
            rowTelephone["telephone_id"] = 1;
            rowTelephone["person_id"] = person.ID;
            rowTelephone["number"] = pupil.Phones.Phone.PhoneNo;
            rowTelephone["notes"] = pupil.Phones.Phone.TelephoneType;
            rowTelephone["main"] = "T";
            rowTelephone["primary"] = "T";
            rowTelephone["device"] = 1; //Telephone
            rowTelephone["location"] = 1; //Home

            var phones = new TelephoneCollection(telephoneTable, InformationDomainEnum.ApplicationTelephoneEmail);

            #endregion

            mainApplication.DetailedApplication.UniquePupilNo = pupil.UPN;                                  
            mainApplication.DetailedApplication.Ethnicity = ethic;
            mainApplication.DetailedApplication.EthnicDataSource = ethicDataSource;
            //need an example
            //The number you have entered does not match the formula used for allocating Unique Learner Numbers
            //mainApplication.DetailedApplication.ULN = pupil.UniqueLearnerNumber.ToString();
            mainApplication.DetailedApplication.CountryOfBirth = new Nationality
            {
                NationCode = countryOfBirth.Code,
                NationID = countryOfBirth.ID
            };
            mainApplication.DetailedApplication.SchoolHistory = schoolHistory;
            mainApplication.DetailedApplication.Telephones = phones;
            //mainApplication.DetailedApplication.EMails = emails;


            //mainApplication.DetailedApplication.FSMReviewDate = pupil.FSMhistory.FSMreviewDate;
            //mainApplication.DetailedApplication.ApplicantFreeSchoolMeals = fsm; //need to ask FSM

            //mainApplication.DetailedApplication.ApplicantDisabilities = disability;
            //mainApplication.DetailedApplication.MedicalPractices = medicalPractices;
            //mainApplication.DetailedApplication.Relations = relations; //relation not belong to contacts
            //mainApplication.DetailedApplication.Contacts = ;
            //mainApplication.DetailedApplication.Address = ;

            //mainApplication.DetailedApplication.LanguageSource = language; //need to ask
            //mainApplication.DetailedApplication.LookedAfter = ;
            //mainApplication.DetailedApplication.BS7666Address = ;
            //mainApplication.DetailedApplication.AddressLines = ;            
            //mainApplication.DetailedApplication.ServiceChild = ;
            //mainApplication.DetailedApplication.MedicalFlag = ;            
            //mainApplication.DetailedApplication.EnglishProficiencies = ;
            //mainApplication.DetailedApplication.ProficiencyInEnglishDetailsCollection = schoolHistory;
            //mainApplication.DetailedApplication.PopulateApplicationProficiencyInEnglish(new DataTable()); cannot populate - private method
            //mainApplication.DetailedApplication.ApplicationReferenceNumber = pupil.ApplicationReference;
            //mainApplication.DetailedApplication.UCI = pupil.UCI;

            mainApplication.DetailedApplication.AppliedIntakeGroup = applicationBrowser.IntakeGroups[0];
            mainApplication.DetailedApplication.Status = (SIMS.Entities.Admissions.ApplicationStatus)applicationBrowser.ApplicationStatusCollection.ItemByDescription("Applied");
            mainApplication.DetailedApplication.AppliedAdmissionGroup = applicationBrowser.AdmissionGroups[0];
            mainApplication.DetailedApplication.AdmissionDate = header.DateTime;
            mainApplication.DetailedApplication.EnrollmentMode = enrollmentMode;
            mainApplication.DetailedApplication.YearTaughtIn = SIMS.Entities.GroupCache.NationalCurriculumYears.Item(0);

            if (mainApplication.DetailedApplication.Valid())
            {
                DataTable dtMessages = new DataTable();
                if (!(mainApplication.Save(true, out dtMessages)))
                {
                    message = "Could not save the database .";
                    success = false;
                }
            }
            else
            {
                success = false;
                message = "Applicant validation failed ...";
                mainApplication.DetailedApplication.ValidationErrors(errors);            
            }

            if (success)
            {
                return new ApplicantResult
                {
                    Status = Status.Success
                };
            }
            else
            {
                return new ApplicantResult
                {
                    Status = Status.Failed,
                    Errors = errors,
                    Message = message
                };
            }
        }




        public static void Assessment_Export()
        {
            SIMSAssessmentMessage sdo = new SIMSAssessmentMessage();

            //ASSESSMENTRESULTCOMPONENT refers to Aspect
            //ASSESSMENTRESULTGRADESET refers to GradeSets
            //LEARNERASSESSMENTRESULTSET refers to ResultSets
            //LEARNERASSESSMENTRESULT refers to Results in SIMS Assessment Manager


            //noted : use homeSchoolId : 3a09f631-9103-47f1-8349-4be3438a3198

            //var x = GuidToSifRefID(new Guid("3a09f631-9103-47f1-8349-4be3438a3198")); //remove hyphen
            Dictionary<string, string> paramOptions = sdo.GetParamOptions(SIMSAssessmentMessage.ASSESSMENTRESULTCOMPONENT);


            // The parameter passed to GetParamOptions will vary
            // depending of what has been requested for export from Assessment
            // WriteBack interfaces.
            var xmlString = @"<SIMSAssessmentMessage>
                                    <Header>
                                        <MessageType>REQUEST</MessageType>
                                        <MessageID>895339910C94496AAD7C8C16C5E8F3CE</MessageID>
                                        <SourceID>PartnerTest</SourceID>
                                        <DestinationID>3A09F631910347F183494BE3438A3198</DestinationID>
                                    </Header>
                                    <QueryObject
                                        Type=""LEARNERASSESSMENTRESULTSET"">
                                        <RequestParameters />
                                    </QueryObject>
                                    </SIMSAssessmentMessage>";
            var request = new XmlDocument {InnerXml = xmlString};
            XmlDocument data = sdo.Export(request);

        }


        public static string GuidToSifRefID(Guid? guid)
        {
            if (!guid.HasValue)
                return (string)null;
            return guid.Value.ToString("N").ToUpper();
        }

        public void Assessment_Import()
        {
            SIMSAssessmentMessage sdo = new SIMSAssessmentMessage();
            Dictionary<string, string> paramOptions = sdo.GetParamOptions(SIMSAssessmentMessage.LEARNERASSESSMENTRESULT);

            // The parameter passed to
            // GetParamOptions will vary depending of what has been requested
            // for importing data using Assessment WriteBack interfaces.
            var xmlString = @"<?xml version=""1.0"" encoding=""UTF-8""
                                    standalone=""yes""?>
                                    <SIMSAssessmentMessage
                                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                    <Header>
                                    <MessageType>UPDATE</MessageType>
                                    <MessageID>4F59D43BE9EC41F2A11EBD247352ADC8</MessageID>
                                    <SourceID>PartnerTest</SourceID>
                                    <DestinationID>A7BCF7D4E4224965A153A3EDA4243601
                                    </DestinationID>
                                    <Status>OK</Status>
                                    </Header>
                                    <DataObjects>
                                    <LearnerAssessmentResult
                                    RefId=""0BD7DE6C0D824686A751AEA426228303""
                                    AssessmentComponentRefId=""48E292692A8842128D1E69ED707614ED""
                                    LearnerPersonalRefId=""884D121CE6E549F3A67858336FCD3086"">
                                    <SchoolInfoRefId>A7BCF7D4E4224965A153A3EDA4243601</SchoolInfoRefId>
                                    <AchievementDate>2009-08-26</AchievementDate>
                                    <Result>1</Result>
                                    <ResultStatus>R</ResultStatus>
                                    </LearnerAssessmentResult>
                                    </DataObjects>
                                    </SIMSAssessmentMessage>";
            var request = new XmlDocument();
            request.InnerText = xmlString;
            var rs = sdo.Import(request);

        }

        //API used internally by SIMS
        public static void AspectSummary()
        {
            string aspectname = "";
            string columnheader = "";
            string aspecttype = "u";
            int owner = 0;
            int module = 0;
            string category_xml = "<root></root>";
            string activeStatusCode = "";
            SIMS.Processes.AspectSummary asmAspectSummary = new AspectSummary();

            //[Obsolete("This method is deprecated and will not be available in future releases. Use the method PopulateAspects(string aspectName, string columnHeader, string aspectType, int owner, string category_xml, string activeStatusCode) instead.")]
            asmAspectSummary.PopulateAspects(aspectname, columnheader, aspecttype, owner, module, category_xml);

            //the error : Object not set reference is throwing ...
            //ASMAspectSummary.PopulateAspects(aspectname, columnheader, aspecttype, owner,category_xml,activeStatusCode);
        }

        public void MaintainAspect()
        {

            int personId = 447;
            SIMS.Processes.MaintainAspect ASMMaintainAspect = new MaintainAspect();
            ASMMaintainAspect.Populate(new SIMS.Entities.Person(personId));
            ASMMaintainAspect.AspectEntity.AspectDescriptionAttribute.Value = "Dang 1";
            ////saving AspectEntity
            //bool isvalid = ASMMaintainAspect.Valid();
            //if (isvalid == true)
            //{
            //    ASMMaintainAspect.Save(new PerformanceCategorys());
            //}
        }

        public static void MaintainGradesetsSummary()
        {
            int moduleID = 0;
            string suppliername = "";
            string gradesetName = "";

            SIMS.Processes.MaintainGradesetSummary ASMMaintainGradeSetSummary = new MaintainGradesetSummary();
            ASMMaintainGradeSetSummary.Populate(moduleID, suppliername, gradesetName);
            foreach (SIMS.Entities.ASMGradeSetSummary gradeSetSummary in ASMMaintainGradeSetSummary.asmGradeSetSummarys)
            {
                //gradeSetSummary.NameAttribute;
            }
        }

        public void MaintainGradeSet()
        {
            int gradeSetId = 12;
            SIMS.Processes.MaintainGradeSet ASMMaintainGradeSet = new MaintainGradeSet();
            ASMMaintainGradeSet.Populate(gradeSetId);
            ASMMaintainGradeSet.ASMGradeset.DescriptionAttribute.Value = "";

            //saving ASMGradeset Entity
            bool isvalid = ASMMaintainGradeSet.Valid();
            if(isvalid == true)
            {
                ASMMaintainGradeSet.Save();
            }
        }

        public static void GradesAndValues()
        {
            int gradeSetId = 12;
            SIMS.Processes.MaintainGradeSet ASMMaintainGradeSet = new MaintainGradeSet();
            ASMMaintainGradeSet.Populate(gradeSetId);
            foreach (SIMS.Entities.ASMGradeSetHistory asmGradeSetHistory in ASMMaintainGradeSet.ASMGradeset.AsmGradesetHistorys.Value)
            {
                //insert code here to extract data
                //asmGradeSetHistory.ASMGradesValues
                //asmGradeSetHistory.GradesetID
            }

        }


    }
}
