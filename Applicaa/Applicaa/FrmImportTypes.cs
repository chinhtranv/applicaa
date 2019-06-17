using System;
using System.Windows.Forms;
using Common;

namespace Applicaa
{
    public partial class FrmImportTypes : Form
    {
        public FrmImportTypes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// BACK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new FrmHome();
            frm.Show();

            this.Hide();
        }

        /// <summary>
        /// NEXT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = false;
            MisCache.IsImportClasses = chkClassess.Checked;
            MisCache.IsImportExamResults = chkExamResults.Checked;

            var frmClassesConfiguration = new FrmClassesConfiguration();
            frmClassesConfiguration.Show();

            this.Hide();
        }

        private void FrmImportTypes_Load(object sender, EventArgs e)
        {
            chkClassess.Checked = true;
            chkExamResults.Checked = true;
        }
    }
}
