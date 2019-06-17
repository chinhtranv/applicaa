namespace Applicaa
{
    partial class FrmClassesConfiguration
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
            this.label2 = new System.Windows.Forms.Label();
            this.classMappingGrid = new System.Windows.Forms.DataGridView();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cboSchemaType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.cboApplicationForm = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.classMappingGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mapping classes";
            // 
            // classMappingGrid
            // 
            this.classMappingGrid.AllowUserToAddRows = false;
            this.classMappingGrid.AllowUserToDeleteRows = false;
            this.classMappingGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.classMappingGrid.Location = new System.Drawing.Point(23, 114);
            this.classMappingGrid.Name = "classMappingGrid";
            this.classMappingGrid.RowTemplate.Height = 24;
            this.classMappingGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.classMappingGrid.Size = new System.Drawing.Size(749, 319);
            this.classMappingGrid.TabIndex = 5;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(671, 470);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 34);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(23, 470);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(101, 34);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(671, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Config ...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboSchemaType
            // 
            this.cboSchemaType.FormattingEnabled = true;
            this.cboSchemaType.Location = new System.Drawing.Point(157, 67);
            this.cboSchemaType.Name = "cboSchemaType";
            this.cboSchemaType.Size = new System.Drawing.Size(119, 24);
            this.cboSchemaType.TabIndex = 8;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(282, 67);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(154, 26);
            this.txtSearch.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(442, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 29);
            this.button2.TabIndex = 10;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Location = new System.Drawing.Point(548, 75);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(86, 17);
            this.lblTotalRows.TabIndex = 11;
            this.lblTotalRows.Text = "match found";
            // 
            // cboApplicationForm
            // 
            this.cboApplicationForm.FormattingEnabled = true;
            this.cboApplicationForm.Location = new System.Drawing.Point(23, 67);
            this.cboApplicationForm.Name = "cboApplicationForm";
            this.cboApplicationForm.Size = new System.Drawing.Size(119, 24);
            this.cboApplicationForm.TabIndex = 12;
            // 
            // FrmClassesConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.cboApplicationForm);
            this.Controls.Add(this.lblTotalRows);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cboSchemaType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.classMappingGrid);
            this.Controls.Add(this.label2);
            this.Name = "FrmClassesConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admission+";
            this.Load += new System.EventHandler(this.FrmClassesConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.classMappingGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView classMappingGrid;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboSchemaType;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.ComboBox cboApplicationForm;
    }
}