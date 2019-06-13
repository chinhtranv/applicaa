namespace Applicaa
{
    partial class FrmStudentSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.studentsGrid = new System.Windows.Forms.DataGridView();
            this.btnNext = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.studentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Import student info from Addmission+ to SIMS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select students";
            // 
            // studentsGrid
            // 
            this.studentsGrid.AllowUserToAddRows = false;
            this.studentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FirstName,
            this.LastName,
            this.Class,
            this.SchoolName,
            this.Age,
            this.Select});
            this.studentsGrid.Location = new System.Drawing.Point(33, 84);
            this.studentsGrid.Name = "studentsGrid";
            this.studentsGrid.RowTemplate.Height = 24;
            this.studentsGrid.Size = new System.Drawing.Size(692, 319);
            this.studentsGrid.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(624, 428);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 34);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "first_name";
            this.FirstName.HeaderText = "First name";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "last_name";
            this.LastName.HeaderText = "Last name";
            this.LastName.Name = "LastName";
            // 
            // Class
            // 
            this.Class.DataPropertyName = "class_list";
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            this.Class.Width = 200;
            // 
            // SchoolName
            // 
            this.SchoolName.DataPropertyName = "application_reference_number";
            this.SchoolName.HeaderText = "Application Reference Number";
            this.SchoolName.Name = "SchoolName";
            this.SchoolName.Width = 200;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "age";
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            // 
            // Select
            // 
            this.Select.DataPropertyName = "selected";
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // FrmStudentSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 497);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.studentsGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmStudentSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admission+";
            this.Load += new System.EventHandler(this.StudentSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView studentsGrid;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
    }
}