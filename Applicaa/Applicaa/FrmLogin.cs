using System;
using System.Windows.Forms;
using Applicaa.Helper;
using Common;
using Common.RestApi;
using SIMSInterface;

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

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBoxHelper.ShowError("Please enter the username ...");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBoxHelper.ShowError("Please enter the password ...");
                return;
            }

            btnLogin.Enabled = false;
            var serializer = new JsonSerializer();
            var errorLogger = new ErrorLogger();
            var loginClient = new AdmissionLoginClient(serializer, errorLogger);
            var user = loginClient.LogIn(txtUserName.Text, txtPassword.Text);

            if (user.status == "success")
            {
                MisCache.UserToken = user.user_token;
                MisCache.UserEmail = user.user_email;

                SIMSDllResolution.AddSIMSDllResolution();
                if (!LoginHelper.SIMSlogin(AppSetting.Server,
                    AppSetting.Database,
                    AppSetting.User,
                    AppSetting.Password))
                {
                    MessageBoxHelper.ShowError("Could not access to SIMS. Please check the SIMS user / password.");
                    return;
                }
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

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
