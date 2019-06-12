using System;
using System.Windows.Forms;

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
            var frmImportStudent = new FrmImportStudents();
            frmImportStudent.Show();

            this.Hide();
        }
    }
}
