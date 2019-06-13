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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// NEXT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MisCache.IsImportClasses = chkClassess.Checked;

            var frmClassesConfiguration = new FrmClassesConfiguration();
            frmClassesConfiguration.Show();

            this.Hide();
        }

        private void FrmImportTypes_Load(object sender, EventArgs e)
        {
            chkClassess.Checked = true;
        }
    }
}
