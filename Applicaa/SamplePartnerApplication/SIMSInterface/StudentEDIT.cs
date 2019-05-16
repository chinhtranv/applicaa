using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Entities;
using SIMS.Processes;

namespace SIMSInterface
{
    public class StudentEDIT
    {
        public static void editStudent(int personID)
        {
            SIMS.Processes.GroupCache.Populate();
            var yearGroups = SIMS.Entities.GroupCache.YearGroups;
            var nationalCurriculumYear = SIMS.Entities.GroupCache.NationalCurriculumYears;

            // Grenetta Abbey - some records may need to be added via SIMS .net...
            SIMS.Entities.IIDEntity identityINV = new SIMS.Entities.Person(personID);
            SIMS.Processes.StudentBrowseProcess studentBrowse = new SIMS.Processes.StudentBrowseProcess();
            SIMS.Processes.EditStudentInformation editStudINV = new SIMS.Processes.EditStudentInformation();
            

            editStudINV.Load(identityINV, System.DateTime.Now);

            editStudINV.Student.Surname = "Abbey6 DANG";
            editStudINV.Student.DateOfBirth = new DateTime(1987,7,7);
            editStudINV.Student.MiddleName = "Tom DANG";
            editStudINV.Student.YearGroup = yearGroups.Item(0);
            editStudINV.Student.NationalCurriculumYear = nationalCurriculumYear.Item(0);

            foreach (SIMS.Entities.House grp in studentBrowse.Houses)
            {   //Insert Code here 
                if (grp.Description == "Hooke")
                {
                    editStudINV.Student.House = grp;
                    break;

                }
            }
            var result = editStudINV.Save();
            if (result == StudentEditResult.Success)
            {
                Console.WriteLine("Success !");
            }
            else if (result == StudentEditResult.Failure)
            {
                var errors = editStudINV.Student.ValidationErrors;
                Console.WriteLine("Failure ");
            }
            return;
            

            // NHS Number, Emergency Consent,
            string editStudINVStudentNHSNumber = editStudINV.Student.NHSNumberAttribute.Value;
            string editStudINVStudentEmergencyConsent = editStudINV.Student.EmergencyConsentAttribute.Value.ToString();
            string editStudINVStudentMedicalDetailsPupilPregnant = editStudINV.Student.MedicalDetails.PupilPregnantAttribute.Value.ToString();


            // Paramedical Support
            foreach (SIMS.Entities.ParamedicalSupport paraSupportINV in editStudINV.Student.MedicalDetails.ParamedicalSupportsAttribute.Value)            
            {
                string paraSupportCodeINV = paraSupportINV.CodeAttribute.Value;
                string paraSupportDescriptionINV = paraSupportINV.DescriptionAttribute.Value;

                //...

            }



            // Medical Practises
            foreach (SIMS.Entities.AgencyLinkedStudent medPractiseINV in editStudINV.Student.MedicalPractises.Value)
            {
                string medPractiseINVName = medPractiseINV.AgencySummary.AgencyNameAttribute.Value;
                string medPractiseINVType = medPractiseINV.AgencySummary.AgencyTypeAttribute.Value;

                //...

            }



            // Medical Events
            foreach (SIMS.Entities.StudentMedicalEvent medEventINV in editStudINV.Student.MedicalEvents.Value)
            {
                string medEventDescriptionINV = medEventINV.EventDescriptionAttribute.Value.ToString();
                string medEventTypeINV = medEventINV.EventTypeDescriptionAttribute.Value.ToString();
                string medEventDateINV = medEventINV.EventDateAttribute.Value.ToString();

                //...               

            }



            //Dietary Needs
            foreach (SIMS.Entities.DietaryNeed dietNeedINV in editStudINV.Student.DietaryNeedsAttribute.Value)
            {
                string dietNeedDescriptionINV = dietNeedINV.DescriptionAttribute.Value;
                string dietNeedCodeINV = dietNeedINV.CodeAttribute.Value;

                //...

            }



            // Medical Condition

            foreach (SIMS.Entities.StudentMedicalCondition medConINV in editStudINV.Student.MedicalConditions.Value)
            {
                string medConCondDescriptionINV = medConINV.ConditionDescription.ToString();
                string medConInformationReceivedOnINV = medConINV.InformationReceivedOnAttribute.ToString();

                //string paramdic =



                //medConINV.Documents.

                //...

            }



            // Medical Notes

            foreach (SIMS.Entities.Document noteINV in editStudINV.Student.MedicalNotes.Documents)
            {
                string noteINVNote = noteINV.NoteAttribute.Value;
                string noteINVCreatedByName = noteINV.CreatedByNameAttribute.Value;
                string noteINVLastModificationDate = noteINV.LastModificationDate.ToString();
                string noteINVLastModifiedByName = noteINV.LastModifiedByNameAttribute.Value;
                string noteINVSummary = noteINV.SummaryAttribute.Value;

                //...

                string noteINVAttachmentName = noteINV.AttachmentNameAttribute.Value;



            }
        }
    }
}
