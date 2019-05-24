using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
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
            
            SIMSDllResolution.AddSIMSDllResolution();

            if (LoginHelper.SIMSlogin(AppSetting.Server, 
                                    AppSetting.Database, 
                                    AppSetting.User, 
                                    AppSetting.Password))
            {
                //serialize object
                var atf = ConvertToObject<ATfile>(txtInfo.Text);                
                //Applicant.AspectSummary();
                //Applicant.Assessment_Export();
                //Applicant.MaintainGradesetsSummary();
                //Applicant.GradesAndValues();                

                var re = Applicant.CreateApplicants(atf.ATFpupilData, atf.Header);
                if (re.Any(x => x.SimsResult.Status == Status.Failed))
                {
                    MessageBox.Show("Import Applicant failed ...", "Applicaa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Import applicant successfully !","Applicaa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
