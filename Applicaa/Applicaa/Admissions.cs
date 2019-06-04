using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIMS.Entities;
using SIMSInterface;
using Common;
using Common.Validation;
using FluentValidation.Results;

namespace Applicaa
{
    public partial class Admissions : Form
    {
        private OpenFileDialog openFileDialog1;
        public Admissions()
        {
            InitializeComponent();

            openFileDialog1 = new OpenFileDialog
            {
                FileName = "Select a xml file",
                Filter = "Text files (*.xml)|*.xml",
                Title = "Open xml file"
            };
        }

        private const string Applicaa = "Applicaa";
        private void btnProcess_Click(object sender, EventArgs e)
        {
            Log.Info("====================================================================== ");
            Log.Info("Start to import ATFfile ... ");
            btnProcess.Enabled = false;
            SIMSDllResolution.AddSIMSDllResolution();

            if (LoginHelper.SIMSlogin(AppSetting.Server, 
                                    AppSetting.Database, 
                                    AppSetting.User, 
                                    AppSetting.Password))
            {
                var atf = XmlHelper.ConvertToObject<ATfile>(txtInfo.Text, out var errorMessages);
                if (atf == null)
                {
                    MessageBox.Show(@"Xml content is not valid", Applicaa, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInfo.Text = errorMessages;
                    Log.Info(@"Xml content is not valid" + errorMessages);
                    return;
                }

                if (!ValidationATFile(atf, out var validationMessages))
                {
                    MessageBox.Show(@"ATFile validation error" ,Applicaa, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInfo.Text = validationMessages;
                    Log.Info(@"ATFile validation error : " + validationMessages);
                    return;
                }
                
                Log.Info("XML content file : ");
                Log.Info(txtInfo.Text);

                Log.Info("Serialized content data :");
                Log.Info(atf.ATFpupilData);
                
                var results = Applicant.CreateApplicants(atf.ATFpupilData, atf.Header);
                               
                if (results.Any(x => x.SimsResult.Status == Status.Failed))
                {                    
                    var strError = new StringBuilder();                                       
                    foreach (var result in results)
                    {
                        string validationError = string.Empty;

                        if (result.SimsResult.Errors != null)                       
                           validationError = string.Join(", ", result.SimsResult.Errors.Cast<ValidationError>().ToList().Select(x => x.Message).ToList());
                        strError.AppendLine(result.EntityName + " : " + result.SimsResult.Status + " - "+ validationError);
                    }

                    strError.AppendLine(string.Empty);
                    foreach (var message in Applicant.CacheMessages.Where(x => !string.IsNullOrEmpty(x.Messages)))
                    {
                        strError.AppendLine(message.Type + " : " + message.Messages);
                    }

                    txtInfo.Text = strError.ToString();

                    Log.Info("Importing applicant failed : ");
                    Log.Info(strError.ToString());
                    MessageBox.Show(@"Import applicant failed ...", Applicaa, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Log.Info("Importing successfully. ");
                    var strMsg = new StringBuilder();
                    foreach (var result in results)
                    {
                        strMsg.AppendLine(result.EntityName + " : " + result.SimsResult.Status);
                    }
                    txtInfo.Text = strMsg.ToString();

                    MessageBox.Show(@"Import applicant successfully !", Applicaa, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnProcess.Enabled = true;
                }
            }
            else
            {

                Log.Info("Login to SIMS.net failed ... ");
                MessageBox.Show(LoginHelper.ErrorMessage);
            }
        }

        private static bool ValidationATFile(ATfile atf,out string messages)
        {
            var validator = new ATfileValidator();
            ValidationResult validationResult = validator.Validate(atf);
            var strError = new StringBuilder();
            bool flag = true;
            if (!validationResult.IsValid)
            {
                strError.AppendLine("ATFile validation failed ...");
                foreach (var failure in validationResult.Errors)
                {
                    strError.AppendLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);

                }
                flag = false;
            }
            else
            {
                //if success the validate each pupil
                foreach (var atfPupil in atf.ATFpupilData)
                {
                    var pupilATfilePupiValidator = new ATfilePupiValidator();
                    ValidationResult pupilValidatorResult = pupilATfilePupiValidator.Validate(atfPupil);
                    if (!pupilValidatorResult.IsValid)
                    {
                        strError.AppendLine("Student " + atfPupil.Forename + " " + atfPupil.Surname + " validation failed ...");
                        int index = 1;
                        foreach (var failure in pupilValidatorResult.Errors)
                        {
                            strError.AppendLine(index + " - Property [" + failure.PropertyName + "] failed validation. Error was: " + failure.ErrorMessage);
                            index++;
                        }

                        flag = false;
                    }
                }

                if (flag)
                {
                    strError.AppendLine("Student has no error..");
                }
            }

            messages = strError.ToString();
            return flag;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;
                txtInfo.Text = File.ReadAllText(filePath);

                
                btnProcess.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
