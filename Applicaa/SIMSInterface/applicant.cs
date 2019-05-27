using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SIMS.Entities;
using SIMS.Entities.Admissions;
using SIMS.Entities.DinnerMoney;
using SIMS.Processes;
using SIMS.Processes.Admissions;
using Cache = SIMS.Entities.Cache;
using Country = SIMS.Entities.Country;
using Ethnicity = SIMS.Entities.Ethnicity;
using GroupCache = SIMS.Entities.GroupCache;
using LookupCache = SIMS.Entities.LookupCache;
using StudentCache = SIMS.Entities.StudentCache;
using UPNEnum = SIMS.Entities.AcademicPerson.UPNEnum;

namespace SIMSInterface
{
    public class Applicant
    {
        static ApplicationBrowser applicationBrowser = new ApplicationBrowser();
        static MaintainApplication mainApplication = new MaintainApplication();
        public static List<CacheMessage> CacheMessages { get; set; }

       
        public static List<CreateEntityResult> CreateApplicants(ATfilePupil[] pupils, ATfileHeader header)
        {
            ConfigLogging();
            SIMS.Processes.GroupCache.Populate();
            SIMS.Processes.ExamCache.Populate();
            SIMS.Processes.PersonCache.Populate();
            SIMS.Processes.StudentCache.Populate();
            //SIMS.Processes.SchoolCache.;
            //SIMS.Processes.ContactCache.Populate();

            var entityResults = new List<CreateEntityResult>();
            foreach (var pupil in pupils)
            {
                var createApplicantResult = CreateApplicant(pupil, header);
                entityResults.Add(new CreateEntityResult
                {
                    EntityName = pupil.ApplicationReference + " - " + pupil.Forename + " " + pupil.Surname,
                    SimsResult = createApplicantResult,
                    Type = EntityType.Applicant
                });
            }

            return entityResults;
        }

        private static SimsResult CreateApplicant(ATfilePupil pupil, ATfileHeader header)
        {
            string message = string.Empty;

            if (pupil == null) return new SimsResult
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
            //var language = (LanguageSource) GroupCache.LanguageSources.ItemByCode(pupil.BasicDetails.Languages[0].LanguageType);

            var schoolHistory = PopulateSchoolHistory(pupil, enrollmentMode);
            var disability = PopulateStudentDisabilities(pupil, person);
            var freeSchoolMeals = PopulateFreeSchoolMeals(pupil);
            var emails = PopulateEMail(pupil, person);
            var phones = PopulateTelephone(pupil, person);
            var residence = PopulateAddress(pupil);
            var countryOfBirthValue = PopulateCountryOfBirth(pupil);


            //relation
            var medicalPractices = new AgencyLinkedStudents();
            medicalPractices.Add(new AgencyLinkedStudent{});

            person.Forename = pupil.Forename;            
            person.Surname = pupil.Surname;
            person.MiddleName = pupil.BasicDetails.MiddleNames;
            person.Gender = (Gender) LookupCache.Genders.ItemByCode(pupil.Gender);           
            person.DateOfBirth = pupil.DOB;

            mainApplication.CreateApplicationFromPerson(person);
            mainApplication.DetailedApplication.IssueUPN = UPNEnum.IssuePermanent; //hackfor dumpData                                 
            mainApplication.DetailedApplication.UniquePupilNo = pupil.UPN + Guid.NewGuid().ToString("N");                                  
            mainApplication.DetailedApplication.Ethnicity = ethic;
            mainApplication.DetailedApplication.EthnicDataSource = ethicDataSource;
            //need an example
            //The number you have entered does not match the formula used for allocating Unique Learner Numbers
            //mainApplication.DetailedApplication.ULN = pupil.UniqueLearnerNumber.ToString();
            mainApplication.DetailedApplication.CountryOfBirth = countryOfBirthValue;
            mainApplication.DetailedApplication.SchoolHistory = schoolHistory;
            mainApplication.DetailedApplication.Telephones = phones;
            mainApplication.DetailedApplication.EMails = emails;
            mainApplication.DetailedApplication.FSMReviewDate = pupil.FSMhistory.FSMreviewDate;
            mainApplication.DetailedApplication.ApplicantFreeSchoolMeals = freeSchoolMeals; 
            mainApplication.DetailedApplication.Residencies = residence; //Student Address
            mainApplication.DetailedApplication.ApplicantDisabilities = disability;
            
            //SENStudentProcess
            //mainApplication.DetailedApplication.MedicalPractices = medicalPractices; //not belong to Medical Detail
            //mainApplication.DetailedApplication.Relations = relations; //relation not belong to contacts
            //mainApplication.DetailedApplication.Contacts = ;
            //mainApplication.DetailedApplication.LanguageSource = language; //need to ask
            //mainApplication.DetailedApplication.LookedAfter = ;                      
            //mainApplication.DetailedApplication.ServiceChild = ;
            //mainApplication.DetailedApplication.MedicalFlag = ;            
            //mainApplication.DetailedApplication.EnglishProficiencies = ;           
            //mainApplication.DetailedApplication.UCI = pupil.UCI;

            var intakeGroups = applicationBrowser.IntakeGroups.Cast<IntakeGroup>().ToList();
            var intake = intakeGroups.FirstOrDefault(x => x.Name == "2018/2019 - Autumn Year  7");
            
            var admissionGroup = applicationBrowser.AdmissionGroups.Cast<AdmissionGroup>().ToList()
                .FirstOrDefault(x => x.Name == "2018/2019 - Autumn Year  7 (A)");

            var yearTaughtIn = SIMS.Entities.GroupCache.NationalCurriculumYears.Item(0);
            var admitted = (SIMS.Entities.Admissions.ApplicationStatus)applicationBrowser.ApplicationStatusCollection.ItemByDescription("Admitted");
            mainApplication.DetailedApplication.AppliedIntakeGroup = intake;
            mainApplication.DetailedApplication.Status = admitted;
            mainApplication.DetailedApplication.AppliedAdmissionGroup = admissionGroup;
            mainApplication.DetailedApplication.AdmissionDate = header.DateTime;
            mainApplication.DetailedApplication.EnrollmentMode = enrollmentMode;
            mainApplication.DetailedApplication.YearTaughtIn = yearTaughtIn;
           
            //return new SimsResult();
            if (mainApplication.DetailedApplication.Valid())
            {                
                if (!(mainApplication.Save(true, out _)))
                {
                    message = "Could not save the database .";
                    success = false;
                }
                else 
                {
                    //if success then create external examination
                    //we can use this id for Assessment
                    var insertedPersonalId = mainApplication.DetailedApplication.PersonID;
                    var createExternalExamiantion = ExternalExamination.AddResults(pupil, insertedPersonalId);
                    if(createExternalExamiantion.Any(x => x.SimsResult.Status == Status.Failed))
                    {
                        return new SimsResult
                        {
                            Status = Status.Failed,
                            Errors = new ValidationErrors(),
                            Message = "Create examination failed ... "
                        };
                    }
                    else
                    {
                        return new SimsResult
                        {
                            Status = Status.Success,
                            Errors = new ValidationErrors(),
                            Message = string.Empty
                        };
                    }
                    
                }


                return new SimsResult
                {
                    Status = Status.Failed,
                    Errors = errors,
                    Message = message
                };
            }
            else
            { // Failed validation
                success = false;
                message = "Applicant validation failed ...";
                mainApplication.DetailedApplication.ValidationErrors(errors);

                return new SimsResult
                {
                    Status = Status.Failed,
                    Errors = errors,
                    Message = message
                };
            }


        }

        private static ApplicationResidencyCollection PopulateAddress(ATfilePupil pupil)
        {
            var countries = LookupCache.Countries.Cast<Country>().ToList();
            var country = countries.FirstOrDefault(x => x.Code == pupil.Address.Country);

            var addressTypes = SIMS.Entities.PersonCache.AddressTypes.Cast<AddressType>().ToList();
            var residence = new ApplicationResidencyCollection();
            var addressLines = string.Format("{0} {1} {2} {3} {4}", pupil.Address.AddressLines.AddressLine1,
                pupil.Address.AddressLines.AddressLine2,
                pupil.Address.AddressLines.AddressLine3,
                pupil.Address.AddressLines.AddressLine4,
                pupil.Address.AddressLines.AddressLine5
            );
            string street = string.Empty,
                apartment = string.Empty,
                houseNumber = string.Empty,
                town = string.Empty,
                houseName = string.Empty;


            if (pupil.Address.BS7666Address != null)
            {
                street = pupil.Address.BS7666Address.Street;
                apartment = pupil.Address.BS7666Address.SAON;
                houseNumber = pupil.Address.BS7666Address.PAON.ToString();
                town = pupil.Address.BS7666Address.Town;
                houseName = pupil.Address.BS7666Address.UniquePropertyReferenceNumber.ToString();
            }

            residence.Add(new ApplicationResidency
            {
                Address = new Address
                {
                    Country = country,
                    HouseName = houseName,
                    Postcode = pupil.Address.PostCode,
                    Easting = pupil.Address.Easting.ToString(),
                    Northing = pupil.Address.Northing.ToString(),
                    County = pupil.Address.County,
                    OSAPR = "",
                    IsBFPO = false,
                    Apartment = apartment,
                    HouseNumber = houseNumber,
                    Town = town,
                    Street = street,
                },
                AddressType = addressTypes.First() //Home
            });
            return residence;
        }

        #region HELPER Method
        public static void ConfigLogging()
        {
            //Cache.LogFile = @"D:\Upwork\TimDixon\src\applicaa\Applicaa\Applicaa\bin\Debug\log.txt";
            // Set the  SIMS log file path (not used?)
            CacheMessages = new List<CacheMessage>();
            Cache.LogFile = (Environment.SpecialFolder.CommonApplicationData) + "\\SIMS_Log.txt";
            SIMS.Entities.Cache.ShowUserMessage += Cache_ShowUserMessage;
        }

        private static void Cache_ShowUserMessage(object sender, UserMessageEventArgs args)
        {
            CacheMessages.Add(new CacheMessage
            {
                Messages = args.Message,
                Type = args.MessageType
            });

        }
        #endregion




        private static Nationality PopulateCountryOfBirth(ATfilePupil pupil)
        {
            var countryOfBirth = (Nation) LookupCache.Nations.ItemByCode(pupil.BasicDetails.CountryofBirth);
            var countryOfBirthValue = new Nationality
            {
                NationCode = countryOfBirth.Code,
                NationID = countryOfBirth.ID
            };
            return countryOfBirthValue;
        }

        private static TelephoneCollection PopulateTelephone(ATfilePupil pupil, Person person)
        {
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
            if(pupil.Phones == null)
                return new TelephoneCollection(telephoneTable, InformationDomainEnum.ApplicationTelephoneEmail);

            var rowTelephone = telephoneTable.NewRow();
            telephoneTable.Rows.Add(rowTelephone);
            rowTelephone["telephone_id"] = 1;
            rowTelephone["person_id"] = person.ID;
            rowTelephone["number"] = pupil.Phones.Phone.PhoneNo;
            rowTelephone["notes"] = pupil.Phones.Phone.TelephoneType;
            rowTelephone["main"] = "T"; //true
            rowTelephone["primary"] = "T";
            rowTelephone["device"] = 1; //Telephone
            rowTelephone["location"] = 1; //Home

            var phones = new TelephoneCollection(telephoneTable, InformationDomainEnum.ApplicationTelephoneEmail);
            return phones;
        }

        private static EMailCollection PopulateEMail(ATfilePupil pupil, Person person)
        {
            var table = new DataTable();
            table.Columns.Add("email_id", typeof(string));
            table.Columns.Add("person_id", typeof(string));
            table.Columns.Add("location", typeof(int));
            table.Columns.Add("main", typeof(string));
            table.Columns.Add("primary", typeof(string));
            table.Columns.Add("email_address", typeof(string));
            table.Columns.Add("notes", typeof(string));
            table.Columns.Add("use_for_fees_documents", typeof(bool));

            if(string.IsNullOrEmpty(pupil.Email))
                return new EMailCollection(InformationDomainEnum.ApplicationTelephoneEmail, table);

            var row = table.NewRow();
            row["email_id"] = IDFactory.GetID();
            row["person_id"] = person.ID;
            row["location"] = 1;
            row["main"] = "T";
            row["primary"] = "T";
            row["email_address"] = pupil.Email;
            row["notes"] = string.Empty;
            row["use_for_fees_documents"] = false;
            table.Rows.Add(row);
            //m_Email, main, location is required
            var emails = new EMailCollection(InformationDomainEnum.ApplicationTelephoneEmail, table);
            return emails;
        }

        private static ApplicationFreeSchoolMeals PopulateFreeSchoolMeals(ATfilePupil pupil)
        {
            int baseGroupId = 60; // Free Meals
            int baseGroupTypeId = 18; //Free School Meal
            var freeSchoolMeals = new ApplicationFreeSchoolMeals();
            if (pupil.FSMhistory == null || !pupil.FSMhistory.FSMinstance.Any())
                return freeSchoolMeals;
            foreach (var freeMealSchool in pupil.FSMhistory.FSMinstance)
            {
                freeSchoolMeals.Add(new ApplicationFreeSchoolMeal
                {
                    StartDate = freeMealSchool.FSMstartDate,
                    EndDate = freeMealSchool.FSMendDate,
                    BaseGroupID = baseGroupId, 
                    BaseGroupTypeID = baseGroupTypeId                   
                });
            }

            return freeSchoolMeals;
        }

        private static StudentDisabilities PopulateStudentDisabilities(ATfilePupil pupil, Person person)
        {
            int personId = 0;
            var disability = new StudentDisabilities(personId, InformationDomainEnum.None);
            var disabilityDataTable = new DataTable();
            disabilityDataTable.Columns.Add("record_id", typeof(string));
            disabilityDataTable.Columns.Add("person_id", typeof(string));
            disabilityDataTable.Columns.Add("start_date", typeof(DateTime));
            disabilityDataTable.Columns.Add("end_date", typeof(DateTime));
            disabilityDataTable.Columns.Add("disability_id", typeof(int));
            disabilityDataTable.Columns.Add("comment", typeof(string));
            if (pupil.BasicDetails == null || !pupil.BasicDetails.Disabilities.Any())
                return disability;

            foreach (var pupilDisability in pupil.BasicDetails.Disabilities)
            {
                var disabilityType = StudentCache.StudentDisaibilities.ItemByCode(pupilDisability);
                var rowD = disabilityDataTable.NewRow();
                rowD["record_id"] = IDFactory.GetID();
                rowD["person_id"] = person.ID;
                rowD["start_date"] = DateTime.Now;
                //rowD["end_date"] = DateTime.Now; //set end date is null
                rowD["disability_id"] = disabilityType.ID;
                rowD["comment"] = "";

                disabilityDataTable.Rows.Add(rowD);
            }

            
            foreach (DataRow rowDis in disabilityDataTable.Rows)
            {
                var stu = new StudentDisability(personId, rowDis, InformationDomainEnum.None)
                    {Status = StatusEnum.New};
                disability.Add(stu);
            }

            return disability;
        }

        private static SchoolHistoryCollection PopulateSchoolHistory(ATfilePupil pupil,             
            DFESEnrolmentStatus enrollmentMode)
        {
            var schoolBrowse = new SchoolsBrowse();
            schoolBrowse.GetSchools(string.Empty);
            var leavingReason = (LeavingReason) LookupCache.LeavingReasons.ItemByCode(pupil.SchoolHistory.School.LeavingReason);

            //find school by name
            string schoolName = "Green Abbey School";
            var listSchool = schoolBrowse.Schools.Cast<SIMS.Entities.School>().ToList();
            var school = listSchool.FirstOrDefault(x => x.Name == schoolName);

            var schoolHistories = new SchoolHistoryCollection();
            if (pupil.SchoolHistory == null)
                return schoolHistories;

            schoolHistories.Add(new SchoolHistory
            {
                StartDate = pupil.SchoolHistory.School.EntryDate,
                School = school,
                IsCurrentSchool = false,
                DateOfLeaving = pupil.SchoolHistory.School.LeavingDate,
                ReasonForLeaving = leavingReason,
                EnrollmentMode = enrollmentMode
            });
            
            return schoolHistories;
        }


    }
}
