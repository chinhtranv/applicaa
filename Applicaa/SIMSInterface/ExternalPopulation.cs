using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Entities;
using SIMS.Processes;

namespace SIMSInterface
{
    public class ExternalPopulation

    {
        private SIMS.Processes.CurrSchemeDetail csdProcess;
        private System.Collections.Generic.SortedList<string, CurrSchemeSummary> schemesByName;
        private System.Collections.Generic.SortedList<string, CurrStudentSummary> studentsByAdno;
        private System.Collections.Generic.SortedList<string, CurrStudent> schemeStudentsByAdno = new System.Collections.Generic.SortedList<string, CurrStudent>();
        public SIMS.Processes.CurrSchemeDetail Process { get { return this.csdProcess; } }

        public ExternalPopulation()

        {
            this.schemesByName = LoadSchemes();
            this.studentsByAdno = LoadStudents();
        }


        public bool LoadScheme(string schemeType, string schemeName)
        {

            this.csdProcess = null;
            this.schemeStudentsByAdno.Clear();
            string key = schemeType.ToUpper() + "|" + schemeName;
            if (this.schemesByName.ContainsKey(key))
            {

                this.csdProcess = new SIMS.Processes.CurrSchemeDetail();
                CurrSchemeSummary schemeSummary = schemesByName[key];
                this.csdProcess.Load(schemeSummary);
                foreach (CurrStudent student in csdProcess.Students)
                {
                    if (!schemeStudentsByAdno.ContainsKey(student.AdmissionNumber)) schemeStudentsByAdno.Add(student.AdmissionNumber, student);
                }

                return true;
            }
            return false;
        }

        public bool CreateMember(string studentAdno, string groupName)
        {
            if (this.csdProcess != null)
            {
                CurrGroup group = null;
                for (int g = 0; g < csdProcess.Scheme.DestinationGroups.Count; g++)
                {
                    CurrGroup grp = csdProcess.Scheme.DestinationGroups[g].Group;
                    if (grp.Description == groupName) group = grp;
                }

                if (group != null)
                {
                    CurrStudent existingStudent = null;
                    if (schemeStudentsByAdno.ContainsKey(studentAdno))
                    {
                        existingStudent = schemeStudentsByAdno[studentAdno];
                    }
                    else
                    {
                        if (studentsByAdno.ContainsKey(studentAdno))
                        {
                            CurrStudentSummary studentSummary = studentsByAdno[studentAdno];
                            existingStudent = csdProcess.AddStudent(studentSummary);
                            schemeStudentsByAdno.Add(studentAdno, existingStudent);
                        }
                    }
                    CurrStudent newStudent = new CurrStudent(existingStudent);
                    newStudent.AssignToGroup(group, csdProcess.EDR, csdProcess.Strict);
                    csdProcess.UpdateStudent(existingStudent, newStudent);
                    return true;
                }
                else
                {
                    throw new System.Exception("Group is NULL");
                }
            }
            return false;
        }

        public void Save()
        {
            if (csdProcess.Valid())
            {
                if (this.csdProcess != null)
                {
                    //bool isChanged = this.csdProcess.Changed();
                    var success = this.csdProcess.Save();
                    if (!success)
                    {
                        throw new System.Exception("cdsProcess is failed ...");
                    }
                }
            }
            else
            {
                throw new System.Exception("cdsProcess is not valid .");
            }
        }

        private System.Collections.Generic.SortedList<string, CurrStudentSummary> LoadStudents()
        {
            SIMS.Processes.CurrStudentBrowser sProcess = new SIMS.Processes.CurrStudentBrowser();
            CurrStudentSummarys studentList = sProcess.Browse("", "", null, null, null, null, null, null, null, DateTime.Today, false);
            System.Collections.Generic.SortedList<string, CurrStudentSummary> studentsDictionary = new System.Collections.Generic.SortedList<string, CurrStudentSummary>();
            foreach (CurrStudentSummary s in studentList)
            {
                if (!studentsDictionary.ContainsKey(s.AdmissionNumber)) studentsDictionary.Add(s.AdmissionNumber, s);

            }

            return studentsDictionary;

        }

        private System.Collections.Generic.SortedList<string, CurrSchemeSummary> LoadSchemes()
        {
            System.Collections.Generic.SortedList<string, CurrSchemeSummary> schemeDictionary = new System.Collections.Generic.SortedList<string, CurrSchemeSummary>();
            for (int s = 0; s < SIMS.Entities.CurrCache.Curriculum.SchemeCount; s++)
            {
                CurrSchemeSummary scheme = SIMS.Entities.CurrCache.Curriculum.Scheme(s);
                string key = scheme.SchemeType.ToUpper() + "|" + scheme.Name;
                if (!schemeDictionary.ContainsKey(key)) schemeDictionary.Add(key, scheme);
            }
            return schemeDictionary;
        }
    }
}
