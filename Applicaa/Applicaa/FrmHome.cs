using System;
using System.Windows.Forms;
using Common;

namespace Applicaa
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var frmImportTypes = new FrmImportTypes();
            frmImportTypes.Show();
            
        }

        private void FrmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            MisCache.Students = null;
            MisCache.ClassesMapping = null;
            MisCache.SelectedStudents = null;
            
            Application.Exit();
        }

        private void btnSyncData_Click(object sender, EventArgs e)
        {
            var frmSyncData = new FrmSyncData();
            frmSyncData.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MisCache.UserEmail = null;
            MisCache.UserToken = null;

            var frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }
    }
}
