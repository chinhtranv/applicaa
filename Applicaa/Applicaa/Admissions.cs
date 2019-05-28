using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using SIMS.Entities;
using SIMSInterface;

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
            btnProcess.Enabled = false;
            SIMSDllResolution.AddSIMSDllResolution();

            if (LoginHelper.SIMSlogin(AppSetting.Server, 
                                    AppSetting.Database, 
                                    AppSetting.User, 
                                    AppSetting.Password))
            {

                //var student = Students.SeekingStudent(uln: "", upn: "G823432110124", uci: "");
                //return;

                //serialize object
                var atf = ConvertToObject<ATfile>(txtInfo.Text);                               
                var results = Applicant.CreateApplicants(atf.ATFpupilData, atf.Header);

                if (results.Any(x => x.SimsResult.Status == Status.Failed))
                {
                    var strError = new StringBuilder();
                                       
                    foreach (var result in results)
                    {                        
                        string validationError = string.Join(", ", result.SimsResult.Errors.Cast<ValidationError>().ToList().Select(x => x.Message).ToList());
                        strError.AppendLine(result.EntityName + " : " + result.SimsResult.Status + validationError);
                    }

                    strError.AppendLine(string.Empty);
                    foreach (var message in Applicant.CacheMessages)
                    {
                        strError.AppendLine(message.Type + " : " + message.Messages);
                    }

                    txtInfo.Text = strError.ToString();
                    MessageBox.Show(@"Import applicant failed ...", @"Applicaa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(@"Import applicant successfully !",@"Applicaa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnProcess.Enabled = true;
                }
            }
            else
            {
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



        public T ConvertToObject<T>(string xml)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                // serialise to object
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                stream = new StringReader(xml); // read xml data
                reader = new XmlTextReader(stream);  // create reader
                // covert reader to object
                return (T)serializer.Deserialize(reader);
            }
            catch
            {
                return default(T);
            }
            finally
            {
                stream?.Close();
                reader?.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
