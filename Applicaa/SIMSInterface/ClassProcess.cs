using System;
using System.Collections.Generic;
using SIMS.Entities;
using SIMS.Processes;

namespace SIMSInterface
{
    public enum SchemeType
    {
        Bands,
        Block,
        Cluster,
        Alternative
    }

    public class ClassProcess
    {

        public static List<ClassesMappingItem> LoadClasses()
        {
            var scatter = new ExternalPopulation();
            return scatter.LoadClasses();

        }

        /// <summary>
        /// AttachClassToStudent
        /// </summary>
        /// <param name="schemeType"></param>
        /// <param name="schemaName"></param>
        /// <param name="admissionNumber"></param>
        /// <param name="className"></param>
        public static SimsResult AttachClassToStudent(string schemeType,string schemaName, string admissionNumber, string className)
        {
            var scatter = new ExternalPopulation();
            string messages = string.Empty;
            bool success = false;
            if (scatter.LoadScheme(schemeType: schemeType, schemeName: schemaName))
            {
                scatter.Process.Strict = false;
                scatter.CreateMember(studentAdno: admissionNumber, groupName: className);
                scatter.Save();
                messages = "Attach student to class " + className + " successfully";
                success = true;
            }
            else
            {
                messages = "Could not load scheme : "+ schemaName + " - scheme Type : "+schemeType ;
            }

            if (success)
            {
                return new SimsResult
                {
                    Status = Status.Success,
                    Message = messages
                };
            }
            else
            {
                return new SimsResult
                {
                    Status = Status.Failed,
                    Message = messages
                };
            }
        }

        public void CreateMembershipWithAScheme()
        {
            string bandName = "10a";
            string studentName = "Jamie Barnett";
            string schemeName = "10ab Block B";
            string groupName = "10B/Bi1";

            //Find the Band with the currently loaded Academic Year
            IIDEntity keyBand = null;
            for (int g = 0; g < SIMS.Entities.CurrCache.Curriculum.GroupCount; g++)
            {

                CurrGroup grp = SIMS.Entities.CurrCache.Curriculum.Group(g);
                if (grp.GroupType == "Band" && grp.Description == bandName) keyBand = grp;
            }

            //check that band exists
            if (keyBand != null)
            {
                //start the process, and load the data for the selected band
                SIMS.Processes.CurrWholeDetail cwdProcess = new CurrWholeDetail();
                cwdProcess.Load(keyBand);

                //find the scheme by name
                CurrStudents schemeStudents = null;
                CurrSchemeSummary scheme = null;
                for (int s = 0; s < cwdProcess.SchemeStudents.Length; s++)
                {
                    CurrSchemeSummary sch = cwdProcess.SchemeStudents[s].Scheme;
                    if (sch.Name == schemeName)
                    {
                        schemeStudents = cwdProcess.SchemeStudents[s];
                        scheme = cwdProcess.Scheme;
                    }
                }

                //Check that the scheme exist
                if (scheme != null)
                {
                    //find the student (for the purposes of the demo this is by 'Full Name'!)
                    CurrStudent existingStudent = null;
                    for (int s = 0; s < cwdProcess.Students.Count; s++)
                    {
                        CurrStudent stud = cwdProcess.Students[s];
                        if (stud.FullName == studentName) existingStudent = schemeStudents.StudentByID(stud.ID);
                    }

                    //check that the Student exists
                    if (existingStudent != null)
                    {
                        //find the required group - by name
                        //find the required group (for the purposes of the demo this is by name!)
                        CurrGroup group = null;
                        for (int g = 0; g < scheme.DestinationGroups.Count; g++)
                        {
                            CurrGroup grp = scheme.DestinationGroups[g].Group;
                            if (grp.Description == groupName) group = grp;
                        }

                        //Check that the Group exists
                        if (group != null)
                        {
                            //start the update : add the student to the new group
                            cwdProcess.BeginUpdate(false);
                            try
                            {
                                CurrStudent newStudent = new CurrStudent(existingStudent);
                                CurrGroup oldGroup;

                                cwdProcess.IsEditable(scheme, existingStudent, out oldGroup);
                                newStudent.RemoveFromGroup(oldGroup, cwdProcess.EDR, cwdProcess.Strict);
                                newStudent.AssignToGroup(group, cwdProcess.EDR, cwdProcess.Strict);
                                cwdProcess.UpdateStudent(scheme, existingStudent, newStudent);

                                //we could of course make many more changes here!

                            }
                            finally
                            {
                                cwdProcess.EndUpdate(false);
                            }
                            cwdProcess.Save();
                        }




                    }
                }


            }




        }

    }
}