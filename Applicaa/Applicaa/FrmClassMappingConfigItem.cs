using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Applicaa.Helper;
using Common;
using Common.RestApi;

namespace Applicaa
{
    public partial class FrmClassMappingConfigItem : Form
    {
        private int simsClassId;
        public FrmClassMappingConfigItem()
        {
            InitializeComponent();
        }
        public FrmClassMappingConfigItem(int id)
        {
            InitializeComponent();
            simsClassId = id;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboAdmissionClasses.SelectedValue == null)
            {
                MessageBoxHelper.ShowError("Please select Admission+ class ..");
                return;
            }
            var classMappingConfig = MisCache.ClassesMapping.FirstOrDefault(x => x.SimsClassId == simsClassId);
            if (classMappingConfig != null)
            {
                var selectedValue = cboAdmissionClasses.SelectedValue.ToString();
                classMappingConfig.AdmissionClassId = Int32.Parse(selectedValue);
                classMappingConfig.AdmissionClassName = cboAdmissionClasses.Text;
            }

            var serializer = new JsonSerializer();
            var errorLogger = new ErrorLogger();
            var cache = new InMemoryCache();
            var client = new AdmissionClassesClient(cache, serializer, errorLogger);
            //(string email, string token, int clazzId, string name,int simsClassId,string simsClassName,string simsClassSchemaType)
            int classId = classMappingConfig.AdmissionClassId.Value;
            string name = classMappingConfig.AdmissionClassName;
            
            string simsClassName = txtClassName.Text;
            string simsClassSchemaType = txtSchemaType.Text;

            var classes = client.UpdateClassConfig(MisCache.UserEmail, MisCache.UserToken, classId, name, simsClassId, simsClassName, simsClassSchemaType);

            this.Hide();
        }

        private void ClassMappingItem_Load(object sender, EventArgs e)
        {
            LoadAdmissionClassesData();

            LoadClassConfig();
        }

        private void LoadClassConfig()
        {
            var classMappingConfig = MisCache.ClassesMapping.FirstOrDefault(x => x.SimsClassId == simsClassId);
            if (classMappingConfig == null)
            {
                MessageBoxHelper.ShowError("Sims class is not existed .");
                return;
            }

            txtSimsClassId.Text = simsClassId.ToString();
            txtSchemaType.Text = classMappingConfig.SchemaType;
            txtClassName.Text = classMappingConfig.ClassName;
            if (classMappingConfig.AdmissionClassId != null)
            {
                cboAdmissionClasses.SelectedValue = classMappingConfig.AdmissionClassId;
            }
            
        }


        private void LoadAdmissionClassesData()
        {
            var serializer = new JsonSerializer();
            var errorLogger = new ErrorLogger();
            var cache = new InMemoryCache();
            var client = new AdmissionClassesClient(cache, serializer, errorLogger);
#if DEBUG
            //MisCache.UserEmail = "admin@applicaa.com";
            //MisCache.UserEmail = "VyQ8QsNGJB-XPrLawz6hf7zfX3ZyKTes";
#endif
            var classes = client.GetClasses(MisCache.UserEmail, MisCache.UserToken);
            cboAdmissionClasses.DataSource = classes;
            cboAdmissionClasses.DisplayMember = "name";
            cboAdmissionClasses.ValueMember = "id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
