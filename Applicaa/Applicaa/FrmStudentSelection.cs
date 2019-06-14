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
        public FrmStudentSelection()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            var serializer = new JsonSerializer();
            var errorLogger = new ErrorLogger();
            var client = new AdmissionStudentsClient(serializer, errorLogger);
            var students = client.GetStudents(MisCache.UserEmail, MisCache.UserToken);
            var studentsGridDataSource = students.Where(x => !string.IsNullOrEmpty(x.class_list)).ToList();
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
            //studentsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //AddCheckboxHeader();
            LoadData();
        }


        #region Header select columns

        private const int IdColumnIndex = 0;
        private const int ReferenceColumnIndex = 4;
        private const int LastNameColumnIndex = 1;
        private const int AgeColumnIndex = 3;
        private const int SelectColumnIndex = 6;

        private void AddCheckboxHeader()
        {
            // customize dataviewgrid, add checkbox column
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.Width = 30;
            checkboxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            studentsGrid.Columns.Insert(SelectColumnIndex, checkboxColumn);

            // add checkbox header
            Rectangle rect = studentsGrid.GetCellDisplayRectangle(SelectColumnIndex, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position correctly.
            rect.X = rect.Location.X + (rect.Width / 4);

            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);

            studentsGrid.Controls.Add(checkboxHeader);

        }


        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < studentsGrid.RowCount; i++)
            {
                studentsGrid[SelectColumnIndex, i].Value = ((CheckBox)studentsGrid.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
            studentsGrid.EndEdit();
        }

        #endregion

        private void btnNext_Click(object sender, EventArgs e)
        {
            GetSelectedItems();
            var frmImportStudents = new FrmImportStudents();
            frmImportStudents.Show();

            this.Hide();

        }
    }
}
