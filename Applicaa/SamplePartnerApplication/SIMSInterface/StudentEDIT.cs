using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMSInterface
{
    public class StudentEDIT
    {
        public static void editStudent(int personID)
        {
            // Grenetta Abbey - some records may need to be added via SIMS .net...

            SIMS.Entities.IIDEntity identityINV = new SIMS.Entities.Person(8404);
            SIMS.Processes.StudentBrowseProcess studentBrowse = new SIMS.Processes.StudentBrowseProcess();
            SIMS.Processes.EditStudentInformation editStudINV = new SIMS.Processes.EditStudentInformation();

            editStudINV.Load(identityINV, System.DateTime.Now);

            editStudINV.Student.Surname = "Abbey6";
            editStudINV.Student.MiddleName = "Tom";
            foreach (SIMS.Entities.House grp in studentBrowse.Houses)
            {   //Insert Code here 
                if (grp.Description == "Hooke")
                {
                    editStudINV.Student.House = grp;
                    break;

                }
            }
            editStudINV.Save();
            return;
            {

            }

            // NHS Number, Emergency Consent,

            string editStudINVStudentNHSNumber = editStudINV.Student.NHSNumberAttribute.Value.ToString();

            string editStudINVStudentEmergencyConsent = editStudINV.Student.EmergencyConsentAttribute.Value.ToString();

            string editStudINVStudentMedicalDetailsPupilPregnant = editStudINV.Student.MedicalDetails.PupilPregnantAttribute.Value.ToString();



            // Paramedical Support

            foreach (SIMS.Entities.ParamedicalSupport paraSupportINV in editStudINV.Student.MedicalDetails.ParamedicalSupportsAttribute.Value)
            { }
            //{

            //    string paraSupportCodeINV = paraSupportINV.CodeAttribute.Value.ToString();

            //    string paraSupportDescriptionINV = paraSupportINV.DescriptionAttribute.Value.ToString();

            //    //...

            //}



            // Medical Practises

            foreach (SIMS.Entities.AgencyLinkedStudent medPractiseINV in editStudINV.Student.MedicalPractises.Value)

            {

                string medPractiseINVName = medPractiseINV.AgencySummary.AgencyNameAttribute.Value.ToString();

                string medPractiseINVType = medPractiseINV.AgencySummary.AgencyTypeAttribute.Value.ToString();

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
            { }
            //{

            //    string dietNeedDescriptionINV = dietNeedINV.DescriptionAttribute.Value.ToString();

            //    string dietNeedCodeINV = dietNeedINV.CodeAttribute.Value.ToString();

            //    //...

            //}



            // Medical Condition

            foreach (SIMS.Entities.StudentMedicalCondition medConINV in editStudINV.Student.MedicalConditions.Value)

            {

                string medConCondDescriptionINV = medConINV.ConditionDescription.ToString();

                string medConInformationReceivedOnINV = medConINV.InformationReceivedOnAttribute.ToString();

                //string paramdic =



                //medConINV.Documents.

                //...

            }



            //// Medical Notes

            //foreach (SIMS.Entities.Document noteINV in editStudINV.Student.MedicalNotes.Documents)

            //{

            //    string noteINVNote = noteINV.NoteAttribute.Value.ToString();

            //    string noteINVCreatedByName = noteINV.CreatedByNameAttribute.Value.ToString();

            //    string noteINVLastModificationDate = noteINV.LastModificationDate.ToString();

            //    string noteINVLastModifiedByName = noteINV.LastModifiedByNameAttribute.Value.ToString();

            //    string noteINVSummary = noteINV.SummaryAttribute.Value.ToString();

            //    //...

            //    string noteINVAttachmentName = noteINV.AttachmentNameAttribute.Value.ToString();



            //}
        }
    }
}
