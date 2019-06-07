using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Applicaa.Helper;
using Common.DataModel;

namespace Applicaa
{
    public partial class FrmImportStudents : Form
    {

        int TotalRecords;
        public FrmImportStudents()
        {
            InitializeComponent();
            lblTotalRows.Text = string.Empty;

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var obj = new MyWorkerClass();
            if (!backgroundWorker1.IsBusy)
            {
                TotalRecords = GetStudents().Count;
                progressBar1.Maximum = TotalRecords;
                backgroundWorker1.RunWorkerAsync(obj);
                btnFinish.Enabled = false;
                btnFinish.Text = "Loading...";
                
            }
        }


        public List<Student> GetStudents()
        {
            var students = new List<Student>();
            for (int i = 0; i < 335; i++)
            {
                students.Add(new Student
                {
                    FirstName = "First name ",
                    LastName = "Last name " + i,
                    SchoolName = "School name " + i,
                    Age = 10 + i,
                    Selected = true
                });
            }

            return students;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var obj = (MyWorkerClass) e.Argument;
            ProcessData(obj);
        }

        public void ProcessData(MyWorkerClass obj)
        {
            
            int i = 0;
            foreach (var student in GetStudents())
            {
                obj.Name = student.FirstName + " " + student.LastName;
                obj.PersonId = student.Age;
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
                txtLogging.AppendText(obj.Name + " processed ...");
                progressBar1.Value = e.ProgressPercentage;
                lblTotalRows.Text = @"Students processed : " + e.ProgressPercentage + 1;

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lblTotalRows.Text = "All data proceessed !";
            btnFinish.Enabled = true;
            btnFinish.Text = "Finish";
        }
    }



    public class MyWorkerClass
    {
        public string Name;
        public int PersonId;
    }
}
