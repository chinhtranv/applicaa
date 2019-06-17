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
        private Dictionary<string, SIMSInterface.StudentItem> studentReferenceMapping;

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
            
            foreach (StudentItem student in students)
            {
                obj.Name = student.first_name + " " + student.last_name;
                obj.PersonId = student.id;
                obj.Index = i;
                var referenceNumber = student.application_reference_number;
                obj.classes = new List<ClassWorkerItem>();
                obj.exams = new List<ExaminationWorkerItem>();

                #region import external 

                if (MisCache.IsImportExamResults && student.exam_results != null && student.exam_results.Any())
                {
                    if (studentReferenceMapping.ContainsKey(referenceNumber))
                    {
                        var studentId = studentReferenceMapping[referenceNumber].PersonId;

                        //loop each exams of student
                        foreach (var exam in student.exam_results)
                        {
                            var workerItem = new ExaminationWorkerItem();
                            workerItem.name = exam.qan + " - "+ exam.subject_code + " - " + exam.board_code+ " - " + exam.level;
                            //for testing 
                            exam.level = "ABQ/B";
                            exam.result = "P";
                            SimsResult addExamResult = ExternalExamination.AddResult(
                                                            int.Parse(exam.year),
                                                            exam.subject_code, 
                                                            exam.board_code,
                                                            exam.level, 
                                                            exam.qan, 
                                                            exam.result_type, 
                                                            exam.result, 
                                                            exam.school, 
                                                            studentId);

                            workerItem.result = addExamResult;
                            obj.exams.Add(workerItem);

                        }
                    }
                    else
                    {
                        var workerItem = new ExaminationWorkerItem();
                        workerItem.message = "Exam - Could not mapping REFERENCE NUMBER for " + student.first_name +
                                                  " " + student.last_name + "( " +
                                                  student.application_reference_number + " )";
                        obj.exams.Add(workerItem);
                    }
                }

                #endregion

                #region import classes data

                if (MisCache.IsImportClasses && student.clazzs != null && student.clazzs.Any())
                {

                    string admissionNumber = string.Empty;

                    if (studentReferenceMapping.ContainsKey(referenceNumber))
                    {
                        admissionNumber = studentReferenceMapping[referenceNumber].Reference;
                        //loop each class of student
                        foreach (var classItem in student.clazzs)
                        {

                            int admissionClassId = classItem.id;
                            var classMappingConfig =
                                MisCache.ClassesMapping.FirstOrDefault(x => x.AdmissionClassId == admissionClassId);

                            var workerItem = new ClassWorkerItem();
                            workerItem.name = admissionClassId + " - " + classItem.name + "-" + classItem.code;
                            if (classMappingConfig != null)
                            {
                                var simsClassName = classMappingConfig.SchemaType + " - " +
                                                    classMappingConfig.SchemaName + " - " +
                                                    classMappingConfig.ClassName;
                                workerItem.name += " - SIMS class :  (" + simsClassName + ") ";
                                SimsResult addClassResult = ClassProcess.AttachClassToStudent(
                                    classMappingConfig.SchemaType, classMappingConfig.SchemaName, admissionNumber,
                                    classMappingConfig.ClassName);
                                workerItem.result = addClassResult;
                            }
                            else
                            {
                                workerItem.message = "FAILED: class [" + workerItem.name + "]  is not config in class mapping.";

                            }

                            obj.classes.Add(workerItem);
                        }
                    }
                    else
                    {
                        var workerItem = new ClassWorkerItem();
                        workerItem.message = "Classes - Could not mapping REFERENCE NUMBER for " + student.first_name +
                                                  " " + student.last_name + "( " +
                                                  student.application_reference_number + " )";
                        obj.classes.Add(workerItem);
                    }


                }

                #endregion

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
                txtLogging.AppendText(obj.Index + " -- "+obj.PersonId + " - [" +obj.Name + "] processed ...");
                if (obj.classes.Any())
                {
                    foreach (var clsItem in obj.classes)
                    {
                        txtLogging.AppendText("\n");
                        if (!string.IsNullOrEmpty(clsItem.message))
                        {
                            txtLogging.AppendText(clsItem.message);
                        }

                        if (clsItem.result != null)
                        {
                            txtLogging.AppendText(">> Import CLASS " + clsItem.name + " is " + clsItem.result.Status +"\n");
                            if (!string.IsNullOrEmpty(clsItem.result.Message))
                            {
                                txtLogging.AppendText(clsItem.result.Message);
                            }

                            if (clsItem.result.Errors != null)
                            {
                                string validationError = string.Join(", \n", clsItem.result.Errors.Cast<ValidationError>().ToList().Select(x => x.Message).ToList());
                                txtLogging.AppendText(validationError);
                            }
                        }
                    }
                }

                if (obj.exams.Any())
                {
                    foreach (var clsItem in obj.exams)
                    {
                        txtLogging.AppendText("\n");
                        if (!string.IsNullOrEmpty(clsItem.message))
                        {
                            txtLogging.AppendText(clsItem.message);
                        }

                        if (clsItem.result != null)
                        {
                            txtLogging.AppendText(">> Import EXAM " + clsItem.name + " is " + clsItem.result.Status + "\n");
                            if (!string.IsNullOrEmpty(clsItem.result.Message))
                            {
                                txtLogging.AppendText(clsItem.result.Message);
                            }

                            if (clsItem.result.Errors != null)
                            {
                                string validationError = string.Join(", \n", clsItem.result.Errors.Cast<ValidationError>().ToList().Select(x => x.Message).ToList());
                                txtLogging.AppendText(validationError);
                            }
                        }
                    }
                }

                txtLogging.AppendText("\n");
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
            ExternalExamination.ExamCachePopulate();

            var references = MisCache.SelectedStudents.Select(x => x.Reference).ToList();
            studentReferenceMapping = Students.GetStudentsByRef(references).ToDictionary(v => v.Reference, v => v);
            if (!studentReferenceMapping.Any())
            {
                MessageBoxHelper.ShowError("System can not mapp student by aplication reference number. Please accept/admit your application");
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            var frmStudentSelection = new FrmStudentSelection();
            frmStudentSelection.Show();

            this.Hide();
        }
    }



    public class MyWorkerClass
    {
        public string Name;
        public int PersonId;
        public int Index;

        public List<ClassWorkerItem> classes;
        public List<ExaminationWorkerItem> exams;
    }

    public class ClassWorkerItem
    {
        public string message;
        public string name;
        public SimsResult result;
    }

    public class ExaminationWorkerItem
    {
        public string message;
        public string name;
        public SimsResult result;
    }
}
