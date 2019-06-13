using System;
using System.Windows.Forms;
using Applicaa.Helper;
using Common;
using Common.RestApi;

namespace Applicaa
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
#if DEBUG
            txtUserName.Text = "admin@applicaa.com";
            txtPassword.Text = "Mrbean2020!";
#endif

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            var serializer = new JsonSerializer();
            var errorLogger = new ErrorLogger();
            var loginClient = new AdmissionLoginClient(serializer, errorLogger);
            var user = loginClient.LogIn(txtUserName.Text, txtPassword.Text);

            if (user.status == "success")
            {
                MisCache.UserToken = user.user_token;
                MisCache.UserEmail = user.user_email;

                var frmHome = new FrmHome();
                frmHome.Show();
                this.Hide();
            }
            else
            {
                MisCache.UserToken = null;
                MisCache.UserEmail = null;
                MessageBoxHelper.ShowError(user.message ?? "Invalid user name or password.");
                btnLogin.Enabled = true;
            }

        }
    }
}
