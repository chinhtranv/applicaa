using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Applicaa.Helper;
using Common.DataModel;

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
            var students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student
                {
                    FirstName = "First name "+i,
                    LastName = "Last name "+i,
                    SchoolName = "School name "+i,
                    Age = 10 + i,
                    Selected = true
                });
            }
            studentsGrid.DataSource = students;
        }

        public void GetSelectedItems()
        {
            var selectedStudent = new List<Student>();
            foreach (DataGridViewRow row in studentsGrid.Rows)
            {
               
                var selected = row.Cells[SelectColumnIndex] as DataGridViewCheckBoxCell;
                if ((bool) selected.Value)
                {
                    var firstName = row.Cells[FirstNameColumnIndex] as DataGridViewTextBoxCell;
                    var lastName = row.Cells[LastNameColumnIndex] as DataGridViewTextBoxCell;
                    var schoolName = row.Cells[SchoolNameColumnIndex] as DataGridViewTextBoxCell;
                    var age = row.Cells[AgeColumnIndex] as DataGridViewTextBoxCell;
                    selectedStudent.Add(new Student
                    {
                        FirstName = firstName?.Value.ToString(),
                        LastName = lastName?.Value.ToString(),
                        SchoolName = schoolName?.Value.ToString(),
                        Age = age == null? 0 : int.Parse(age.Value.ToString())
                    });
                }
            }

            if (!selectedStudent.Any())
            {
                MessageBoxHelper.ShowInfo(@"Please select at least one student");
            }


        }

        private void StudentSelection_Load(object sender, EventArgs e)
        {
            studentsGrid.AutoGenerateColumns = false;
            studentsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //AddCheckboxHeader();
            LoadData();
        }


        #region Header select columns

        private const int FirstNameColumnIndex = 0;
        private const int LastNameColumnIndex = 1;
        private const int SchoolNameColumnIndex = 2;
        private const int AgeColumnIndex = 3;
        private const int SelectColumnIndex = 4;

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
            var frmImportType = new  FrmImportTypes();
            frmImportType.Show();

            this.Hide();

        }
    }
}
