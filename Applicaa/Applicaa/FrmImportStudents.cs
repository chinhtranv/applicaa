using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Applicaa.Helper;
using Common;
using SIMS.Entities;
using SIMSInterface;
using StudentItem = Common.DataModel.StudentItem;

namespace Applicaa
{
    public partial class FrmImportStudents : Form
    {

        int TotalRecords;
        private Dictionary<string, string> studentReferenceMapping;

        public FrmImportStudents()
        {
            InitializeComponent();
            lblTotalRows.Text = string.Empty;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        public List<StudentItem> GetStudents()
        {
            var ids = MisCache.SelectedStudents.Select(x => x.Id).ToList();
            List<StudentItem> dataForProcess = MisCache.Students.Where(x => ids.Contains(x.id)).ToList();
            return dataForProcess;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var obj = (MyWorkerClass) e.Argument;
            ProcessData(obj);
        }

        public void ProcessData(MyWorkerClass obj)
        {
            List<StudentItem> students = GetStudents();
            int i = 0;
            if (obj.classes == null)
            {
                obj.classes = new List<ClassWorkerItem>();
            }
            foreach (StudentItem student in students)
            {
                obj.Name = student.first_name + " " + student.last_name;
                obj.PersonId = student.id;
                var referenceNumber = student.application_reference_number;
                string admissionNumber = string.Empty;
                
                if (studentReferenceMapping.ContainsKey(referenceNumber))
                {
                    admissionNumber = studentReferenceMapping[referenceNumber];
                }
                obj.classes.Clear();
                //loop each class of student
                foreach (var classItem in student.clazzs)
                {
                    var classworkerItem = new ClassWorkerItem();
                    int admissionClassId = classItem.id;
                    var classMappingConfig = MisCache.ClassesMapping.FirstOrDefault(x => x.AdmissionClassId == admissionClassId);
                    

                    classworkerItem.className = admissionClassId + " - " + classItem.name + "-" + classItem.code;
                    if (classMappingConfig != null)
                    {
                        var simsClassName = classMappingConfig.SchemaType + " - " + classMappingConfig.SchemaName + " - " + classMappingConfig.ClassName;
                        classworkerItem.className += " - SIMS class :  (" + simsClassName + ") ";
                        SimsResult addClassResult = ClassProcess.AttachClassToStudent(classMappingConfig.SchemaType, classMappingConfig.SchemaName, admissionNumber, classMappingConfig.ClassName);
                        classworkerItem.result = addClassResult;
                    }
                    else
                    {
                        classworkerItem.message = "FAILED: class [" + classworkerItem.className + "]  is not config in class mapping.";
                    }
                    obj.classes.Add(classworkerItem);
                }
                

                backgroundWorker1.ReportProgress(i, obj);
                i++;
                Thread.Sleep(100);
            }
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
                var obj = (MyWorkerClass) e.UserState;
                txtLogging.AppendText("\n");
                txtLogging.AppendText(" --- "+obj.PersonId + " - " +obj.Name + " processed ...");
                foreach (var clsItem in obj.classes)
                {
                    txtLogging.AppendText("\n");
                    if (!string.IsNullOrEmpty(clsItem.message))
                    {
                        txtLogging.AppendText(clsItem.message);
                    }

                    if (clsItem.result != null)
                    {
                        txtLogging.AppendText("Import class " + clsItem.className +" is "+ clsItem.result.Status);
                        if (string.IsNullOrEmpty(clsItem.result.Message))
                        {
                            txtLogging.AppendText(clsItem.result.Message);
                        }

                        if (clsItem.result.Errors != null)
                        {
                            string validationError = string.Join(", ", clsItem.result.Errors.Cast<ValidationError>().ToList().Select(x => x.Message).ToList());
                            txtLogging.AppendText(validationError);
                        }
                    }
                }
                progressBar1.Value = e.ProgressPercentage;
                lblTotalRows.Text = @"Students processed : " + e.ProgressPercentage + 1;

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lblTotalRows.Text = "All data proceessed !";
            btnFinish.Enabled = true;
            btnFinish.Text = "Close";
            Log.Info(txtLogging.Text);
        }

        private void FrmImportStudents_Load(object sender, EventArgs e)
        {
            var references = MisCache.SelectedStudents.Select(x => x.Reference).ToList();
            studentReferenceMapping = Students.GetStudentsByRef(references).ToDictionary(v => v.Reference, v => v.AdmissionNumber);
            if (!studentReferenceMapping.Any())
            {
                MessageBoxHelper.ShowError("System can not mapp student by aplication reference number");
                btnFinish.Enabled = false;
                return;
            }
            var obj = new MyWorkerClass();
            if (!backgroundWorker1.IsBusy)
            {
                TotalRecords = GetStudents().Count;
                progressBar1.Maximum = TotalRecords;
                backgroundWorker1.RunWorkerAsync(obj);
                btnFinish.Enabled = false;
                btnFinish.Text = "Processing ...";
            }
        }
    }



    public class MyWorkerClass
    {
        public string Name;
        public int PersonId;
        public List<ClassWorkerItem> classes;
    }

    public class ClassWorkerItem
    {
        public string message;
        public string className;
        public SimsResult result;
    }
}
