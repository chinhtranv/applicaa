            //create a membership for a group within a scheme for a single student
            //this process works off a "key band"
            //update memberships for any students of that band, for groups of any schemes served by that band
            
            string bandName = "10a";
            string studentName = "Jamie Barnett";
            string schemeName = "10ab Block B";
            string groupName = "10B/Bi1";

            //Find the Band within the currently loaded Academic Year
            IIDEntity keyBand = null;
            for (int g=0; g<SIMS.Entities.CurrCache.Curriculum.GroupCount; g++)
            {
                CurrGroup grp = SIMS.Entities.CurrCache.Curriculum.Group(g);
                if (grp.GroupType == "Band" && grp.Description == bandName) keyBand = grp;
            }
            //Check that the band exists
            if (keyBand != null)
            {
                //Start the process, and load the data for the selected band
                SIMS.Processes.CurrWholeDetail cwdProcess = new Processes.CurrWholeDetail();
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
                        scheme = schemeStudents.Scheme;
                    }
                }

                //Check that the scheme exists
                if (scheme != null)
                {
                    //find the student (for the purposes of the demo this is by 'Full Name'!)
                    CurrStudent existingStudent = null;
                    for (int s = 0; s < cwdProcess.Students.Count; s++)
                    {
                        CurrStudent stud = cwdProcess.Students[s];
                        if (stud.FullName == studentName) existingStudent = schemeStudents.StudentByID(stud.ID);
                    }
                    //Check that the Student exists
                    if (existingStudent != null)
                    {
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


