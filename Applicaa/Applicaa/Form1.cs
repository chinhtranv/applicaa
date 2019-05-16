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

namespace Applicaa
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog1;
        public Form1()
        {
            InitializeComponent();

            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "Select a xml file";
            openFileDialog1.Filter = "Text files (*.xml)|*.xml";
            openFileDialog1.Title = "Open xml file";
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;
                txtInfo.Text = File.ReadAllText(filePath);

                //TODO need to validate object

                //serialize object
                var atf = EmpObject(txtInfo.Text);
            }
        }



        public ATfile EmpObject(string xml)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                // serialise to object
                XmlSerializer serializer = new XmlSerializer(typeof(ATfile));
                stream = new StringReader(xml); // read xml data
                reader = new XmlTextReader(stream);  // create reader
                // covert reader to object
                return (ATfile)serializer.Deserialize(reader);
            }
            catch
            {
                return null;
            }
            finally
            {
                if (stream != null) stream.Close();
                if (reader != null) reader.Close();
            }
        }
    }
}
