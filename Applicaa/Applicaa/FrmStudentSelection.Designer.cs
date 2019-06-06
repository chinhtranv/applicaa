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
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.studentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Import student info from Addmission+ to SIMS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select students";
            // 
            // studentsGrid
            // 
            this.studentsGrid.AllowUserToAddRows = false;
            this.studentsGrid.AllowUserToDeleteRows = false;
            this.studentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.LastName,
            this.SchoolName,
            this.Age,
            this.Select});
            this.studentsGrid.Location = new System.Drawing.Point(37, 110);
            this.studentsGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.studentsGrid.Name = "studentsGrid";
            this.studentsGrid.RowTemplate.Height = 24;
            this.studentsGrid.Size = new System.Drawing.Size(778, 399);
            this.studentsGrid.TabIndex = 1;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "First name";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last name";
            this.LastName.Name = "LastName";
            // 
            // SchoolName
            // 
            this.SchoolName.DataPropertyName = "SchoolName";
            this.SchoolName.HeaderText = "School";
            this.SchoolName.Name = "SchoolName";
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            // 
            // Select
            // 
            this.Select.DataPropertyName = "Selected";
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(702, 535);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(114, 42);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // FrmStudentSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 621);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.studentsGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
    }
}