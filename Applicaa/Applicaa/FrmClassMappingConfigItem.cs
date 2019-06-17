using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// SAVE
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(cboAdmissionClasses.SelectedValue.ToString()))
            {
                MessageBoxHelper.ShowError("Please select the class ...");
                return;

            }
            var classMappingConfig = MisCache.ClassesMapping.FirstOrDefault(x => x.SimsClassId == simsClassId);
            if (classMappingConfig != null)
            {
                var selectedValue = cboAdmissionClasses.SelectedValue.ToString();
                classMappingConfig.AdmissionClassId = Int32.Parse(selectedValue);
                classMappingConfig.AdmissionClassName = cboAdmissionClasses.Text;
            }

            var client = AdmissionClassesClient();

            int? classId = classMappingConfig.AdmissionClassId;
            string name = classMappingConfig.AdmissionClassName;
            
            string simsClassName = txtClassName.Text;
            string simsClassSchemaType = txtSchemaType.Text;
            //API is not allowed post classId null
            var classes = client.UpdateClassConfig(MisCache.UserEmail, MisCache.UserToken, classId, name, simsClassId, simsClassName, simsClassSchemaType);

            this.Hide();
        }

        private static AdmissionClassesClient AdmissionClassesClient()
        {
            var serializer = new JsonSerializer();
            var errorLogger = new ErrorLogger();
            var cache = new InMemoryCache();
            var client = new AdmissionClassesClient(cache, serializer, errorLogger);
            return client;
        }

        private void ClassMappingItem_Load(object sender, EventArgs e)
        {

            LoadAdmissionForms();
            LoadAdmissionClassesData();
            LoadClassConfig();

        }

        public void LoadAdmissionForms()
        {
            AdmissionPlusHelper.LoadApplicationForm(cboApplicationForm);
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
            txtSupervisor.Text = classMappingConfig.Supervisor;

            if (classMappingConfig.AdmissionClassId != null)
            {
                cboAdmissionClasses.SelectedValue = classMappingConfig.AdmissionClassId.ToString();
            }
            
        }


        private void LoadAdmissionClassesData()
        {
            var serializer = new JsonSerializer();
            var errorLogger = new ErrorLogger();
            var cache = new InMemoryCache();
            var client = new AdmissionClassesClient(cache, serializer, errorLogger);

            int appFormId = (int)cboApplicationForm.SelectedValue;
            var classes = client.GetCachedClasses(appFormId, MisCache.UserEmail, MisCache.UserToken);

            var dataForCombobox = new List<CboItem>();
            //dataForCombobox.Add(new CboItem(string.Empty,string.Empty));
            foreach (var item in classes)
            {
                dataForCombobox.Add(new CboItem(item.name,item.id.ToString()));
            }
            cboAdmissionClasses.DataSource = dataForCombobox;
            cboAdmissionClasses.DisplayMember = "Name";
            cboAdmissionClasses.ValueMember = "Value";
            
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdmissionForm_Click(object sender, EventArgs e)
        {
            LoadAdmissionClassesData();
        }
    }
}
