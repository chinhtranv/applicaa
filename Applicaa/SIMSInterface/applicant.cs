﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using SIMS.Entities;
using SIMS.Entities.Admissions;
using SIMS.Processes.Admissions;

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

    public class Applicant
    {
        static ApplicationBrowser applicationBrowser = new ApplicationBrowser();
        static MaintainApplication mainApplication = new MaintainApplication();


        public static bool CreateApplicants(ATfilePupil[] pupils, ATfileHeader header)
        {            
            SIMS.Processes.GroupCache.Populate();
            foreach (var pupil in pupils)
            {
                var rs = CreateApplicant(pupil, header);
            }

            return true;
        }

        private static ApplicantResult CreateApplicant(ATfilePupil pupil, ATfileHeader header)
        {
            Cache.LogFile = @"D:\Upwork\TimDixon\src\applicaa\Applicaa\Applicaa\bin\Debug\log.txt";

            if (pupil == null) return new ApplicantResult
            {
                Status = Status.Failed,
                Message = "Pupil can not be null"
            };
            
            bool success = true;
            var errors = new SIMS.Entities.ValidationErrors();
            var person = new Person();

            
            var ethic =(Ethnicity) GroupCache.Ethnicities.ItemByCode(pupil.BasicDetails.Ethnicity);
            var ethicDataSource = GroupCache.EthnicDataSources.Item(pupil.BasicDetails.EthnicitySource);
            
            //TODO Get NationID By Country of Birth
            //var countryOfBirth = new Nationality { NationCode = pupil.BasicDetails.CountryofBirth, NationID = 1 };
            var countryOfBirth = new Nationality { NationCode = "CAN", NationID = 30 };
            var language = (LanguageSource) GroupCache.LanguageSources.ItemByCode(pupil.BasicDetails.Languages.Type.Language);
            var phones = new TelephoneCollection(InformationDomainEnum.ApplicationTelephoneEmail);
            phones.Add(new Telephone {
                Number = pupil.Phones.Phone.PhoneNo ,
                Description = pupil.Phones.Phone.TelephoneType,
                
            });

            var schoolHistory = new SchoolHistoryCollection
            {
                new SchoolHistory
                {
                    ID = 1,
                    StartDate = pupil.SchoolHistory.School.EntryDate,
                    School = new SIMS.Entities.School
                    {
                        LEANumber = pupil.SchoolHistory.School.LEA.ToString(),
                        Name = pupil.SchoolHistory.School.SchoolName,
                        
                    },
                    DateOfLeaving = pupil.SchoolHistory.School.LeavingDate,
                    ReasonForLeaving = new LeavingReason
                    {
                        Description = pupil.SchoolHistory.School.LeavingReason
                    },
                }
            };


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
            table.Rows.Add(pupil.Email);
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
            mainApplication.DetailedApplication.UniquePupilNo = pupil.UPN;                                  
            mainApplication.DetailedApplication.Ethnicity = ethic;
            mainApplication.DetailedApplication.EthnicDataSource = ethicDataSource;
            //need an example
            //The number you have entered does not match the formula used for allocating Unique Learner Numbers
            //mainApplication.DetailedApplication.ULN = pupil.UniqueLearnerNumber.ToString();
            mainApplication.DetailedApplication.CountryOfBirth = countryOfBirth;
            //mainApplication.DetailedApplication.LanguageSource = language; //need to ask
            //mainApplication.DetailedApplication.FSMReviewDate = pupil.FSMhistory.FSMreviewDate;
            //mainApplication.DetailedApplication.ApplicantFreeSchoolMeals = fsm; //need to ask FSM

            //mainApplication.DetailedApplication.Telephones = phones;
            //mainApplication.DetailedApplication.SchoolHistory = schoolHistory;
            //mainApplication.DetailedApplication.ApplicantDisabilities = disability;
            //mainApplication.DetailedApplication.MedicalPractices = medicalPractices;

            mainApplication.DetailedApplication.EMails = emails;



            //mainApplication.DetailedApplication.Relations = relations; //relation not belong to contacts


            //mainApplication.DetailedApplication.Contacts = ;
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
            mainApplication.DetailedApplication.EnrollmentMode = (SIMS.Entities.DFESEnrolmentStatus)SIMS.Entities.LookupCache.DFESEnrolmentStatuses.Item(0);
            mainApplication.DetailedApplication.YearTaughtIn = SIMS.Entities.GroupCache.NationalCurriculumYears.Item(0);

            if (mainApplication.DetailedApplication.Valid())
            {
                DataTable dtMessages = new DataTable();
                if (!(mainApplication.Save(true, out dtMessages)))
                {                 
                    success = false;
                }
            }
            else
            {
                success = false;                
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
                    Errors = errors
                };
            }
        }
    }
}