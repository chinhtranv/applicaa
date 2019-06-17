using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Applicaa.Helper;
using Common;
using Common.DataModel;
using Common.RestApi;
using JsonSerializer = RestSharp.Serialization.Json.JsonSerializer;

namespace Applicaa
{
    public partial class FrmStudentSelection : Form
    {

        private const int IdColumnIndex = 0;
        private const int ReferenceColumnIndex = 4;
        private const int SelectColumnIndex = 6;

        public FrmStudentSelection()
        {
            InitializeComponent();
        }

        public void LoadAdmissionForms()
        {
            AdmissionPlusHelper.LoadApplicationForm(cboApplicationForm);
        }

        public void LoadStudents(int appFormId)
        {
            var serializer = new JsonSerializer();
            var errorLogger = new ErrorLogger();
            var client = new AdmissionStudentsClient(serializer, errorLogger);
            
            var students = client.GetStudents(appFormId,MisCache.UserEmail, MisCache.UserToken);
            //var studentsGridDataSource = students.Where(x => !string.IsNullOrEmpty(x.class_list)).ToList();
            var studentsGridDataSource = students;
            studentsGrid.DataSource = studentsGridDataSource;
            MisCache.Students = studentsGridDataSource;
        }

        public void GetSelectedItems()
        {
            var selectedStudent = new List<Student>();
            foreach (DataGridViewRow row in studentsGrid.Rows)
            {

                var selected = row.Cells[SelectColumnIndex] as DataGridViewCheckBoxCell;
                if ((bool)selected.Value)
                {
                    var idCell = row.Cells[IdColumnIndex] as DataGridViewTextBoxCell;
                    var refCell = row.Cells[ReferenceColumnIndex] as DataGridViewTextBoxCell;
                    
                    selectedStudent.Add(new Student
                    {
                        Id = int.Parse(idCell?.Value.ToString()),
                        Reference = refCell?.Value.ToString()
                    });
                }
            }

            if (!selectedStudent.Any())
            {
                MessageBoxHelper.ShowInfo(@"Please select at least one student");
            }

            MisCache.SelectedStudents = selectedStudent;
        }

        private void StudentSelection_Load(object sender, EventArgs e)
        {
            studentsGrid.AutoGenerateColumns = false;
            LoadAdmissionForms();
            LoadStudents((int)cboApplicationForm.SelectedValue);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            GetSelectedItems();
            var frmImportStudents = new FrmImportStudents();
            frmImportStudents.Show();

            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new FrmClassesConfiguration();
            frm.Show();

            this.Hide();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadStudents((int) cboApplicationForm.SelectedValue);
        }
    }
}
