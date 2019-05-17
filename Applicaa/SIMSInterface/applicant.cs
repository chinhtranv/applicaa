using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SIMSInterface
{
    public class applicant
    {
        public  static bool CreateApplicant()
        {

            SIMS.Processes.GroupCache.Populate();
            //                Console.WriteLine("Running Create Applicant");

            bool success = true;

            SIMS.Processes.Admissions.ApplicationBrowser applicationBrowser = new SIMS.Processes.Admissions.ApplicationBrowser();
            SIMS.Processes.Admissions.MaintainApplication mainApplication = new SIMS.Processes.Admissions.MaintainApplication();
            SIMS.Entities.Person person = new SIMS.Entities.Person();

            person.Forename = "Test Dang ApplicantForename " + "TEST" + " Upgrade Upgrade";
            person.Surname = "Test Dang ApplicantSurname " + "TEST" + " Upgrade Upgrade";
            person.Gender = (SIMS.Entities.Gender)SIMS.Entities.LookupCache.Genders.ItemByCode("M");
            person.DateOfBirth = new System.DateTime(1987, 7, 7);

            mainApplication.CreateApplicationFromPerson(person);

            mainApplication.DetailedApplication.AppliedIntakeGroup = applicationBrowser.IntakeGroups[0];
            mainApplication.DetailedApplication.Status = (SIMS.Entities.Admissions.ApplicationStatus)applicationBrowser.ApplicationStatusCollection.ItemByDescription("Applied");
            mainApplication.DetailedApplication.AppliedAdmissionGroup = applicationBrowser.AdmissionGroups[0];
            mainApplication.DetailedApplication.AdmissionDate = new System.DateTime(2016, 09, 05);
            mainApplication.DetailedApplication.EnrollmentMode = (SIMS.Entities.DFESEnrolmentStatus)SIMS.Entities.LookupCache.DFESEnrolmentStatuses.Item(0);
            mainApplication.DetailedApplication.YearTaughtIn = (SIMS.Entities.NationalCurriculumYear)SIMS.Entities.GroupCache.NationalCurriculumYears.Item(0);



            if (mainApplication.DetailedApplication.Valid())
            {
                DataTable dtMessages = new DataTable();
                if (!(mainApplication.Save(true, out dtMessages)))
                {
                    success = false;

                    Console.WriteLine("Applicant with could not be saved in ApplicantTestCase.CreateApplicant()");
                    //ManageLogging.LogMessage("Applicant with could not be saved in ApplicantTestCase.CreateApplicant()", "");

                }
            }
            else
            {
                success = false;
                SIMS.Entities.ValidationErrors errors = new SIMS.Entities.ValidationErrors();
                mainApplication.DetailedApplication.ValidationErrors(errors);

                //CommonSIMS.WriteErrorsToLog(errors);
            }
            return success;

        }


    }
}
