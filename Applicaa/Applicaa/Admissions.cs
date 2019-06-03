using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIMS.Entities;
using SIMSInterface;
using Common;
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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Log.Info("====================================================================== ");
            Log.Info("====================================================================== ");
            Log.Info("Start to import ATFfile ... ");
            btnProcess.Enabled = false;
            SIMSDllResolution.AddSIMSDllResolution();

            if (LoginHelper.SIMSlogin(AppSetting.Server, 
                                    AppSetting.Database, 
                                    AppSetting.User, 
                                    AppSetting.Password))
            {

                //public static void AttachClassToStudent(string schemeType, string schemaName, string admissionNumber, string className)
                //{
                //    //schemaType : Block,Brand,Cluster,Alternative
                //    //schemeName : 10x English
                //    //admissionNumber : 005152 --Dang Dinh Dang
                //    //class name : 10x/En1, 11A/Ps

                //ClassProcess.AttachClassToStudent(SchemeType.Block.ToString(), "11xy PSE", "005152", "11B/Ps"); //only one class on the schema Type
                //ClassProcess.AttachClassToStudent(schemeType :SchemeType.Bands.ToString(),schemaName: "Base bands in Year 10",admissionNumber: "005152",className: "10x");
                //ClassProcess.AttachClassToStudent(schemeType :SchemeType.Cluster.ToString(),schemaName: "10B/Ar1a", admissionNumber: "005152",className: "10B/Ar1a");
                //ClassProcess.AttachClassToStudent(schemeType :SchemeType.Block.ToString(),schemaName: "7x Maths", admissionNumber: "005152",className: "7x/Ma1");
                //return;

                Log.Info("import is starting ... ");
                var atf = XmlHelper.ConvertToObject<ATfile>(txtInfo.Text);

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
                    foreach (var message in Applicant.CacheMessages)
                    {
                        strError.AppendLine(message.Type + " : " + message.Messages);
                    }

                    txtInfo.Text = strError.ToString();

                    Log.Info("Importing applicant failed : ");
                    Log.Info(strError.ToString());
                    MessageBox.Show(@"Import applicant failed ...", @"Applicaa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Log.Info("Importing successfully. ");                   
                    MessageBox.Show(@"Import applicant successfully !",@"Applicaa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnProcess.Enabled = true;
                }
            }
            else
            {

                Log.Info("Login to SIMS.net failed ... ");
                MessageBox.Show(LoginHelper.ErrorMessage);
            }
            

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;
                txtInfo.Text = File.ReadAllText(filePath);

                //TODO need to validate object
                btnProcess.Enabled = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
