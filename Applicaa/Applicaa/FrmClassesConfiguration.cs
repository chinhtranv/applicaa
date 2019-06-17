using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Applicaa.Helper;
using Common;
using Common.DataModel;
using Common.RestApi;
using SIMSInterface;
using JsonSerializer = RestSharp.Serialization.Json.JsonSerializer;

namespace Applicaa
{
    public partial class FrmClassesConfiguration : Form
    {
        private List<ClassesItem> _admisionApiClassMappingConfig = new List<ClassesItem>();
        public FrmClassesConfiguration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FrmClassesConfiguration control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmClassesConfiguration_Load(object sender, EventArgs e)
        {
            lblTotalRows.Text = string.Empty;
            LoadAdmissionForms();

            //Schema types combobox
            LoadSchemaTypeData();

            LoadClassMappingConfigFromAdmissionApi();

            LoadClassesDataFromSims();
        }


        public void LoadAdmissionForms()
        {
            AdmissionPlusHelper.LoadApplicationForm(cboApplicationForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var row = classMappingGrid.SelectedRows[0];
            var id = int.Parse(row.Cells["SimsClassId"].Value.ToString());
            var frm = new FrmClassMappingConfigItem(id);
            frm.Show();
            classMappingGrid.DataSource = MisCache.ClassesMapping;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var frm = new FrmStudentSelection();
            frm.Show();

            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var frm = new FrmImportTypes();
            frm.Show();
            this.Hide();
        }


        #region HELPER METHOD


        private void LoadSchemaTypeData()
        {
            var schemaTypes = new List<CboItem>
            {
                new CboItem("", ""),
                new CboItem("Bands", "Bands"),
                new CboItem("Block", "Block"),
                new CboItem("Cluster", "Cluster"),
                new CboItem("Alternative", "Alternative")
            };
            cboSchemaType.DataSource = schemaTypes;
            cboSchemaType.DisplayMember = "Name";
            cboSchemaType.ValueMember = "Value";
        }

        private void LoadClassesDataFromSims()
        {
            var classes = PoulateClassesMappingItems();
            MisCache.ClassesMapping = classes;
            var dataForGrid = classes;
            //filter data
            var selectedSchemaType = cboSchemaType.SelectedValue.ToString();
            var keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(selectedSchemaType))
            {
                dataForGrid = dataForGrid.Where(x => x.SchemaType == selectedSchemaType).ToList();
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                dataForGrid = dataForGrid.Where(x => x.ClassName.Contains(keyword)).ToList();
            }

            classMappingGrid.DataSource = dataForGrid;
            lblTotalRows.Text = dataForGrid.Count + " match found";
        }

        private List<ClassesMappingItem> PoulateClassesMappingItems()
        {
            List<ClassesMappingItem> classes = Applicant.LoadClasses();
            
            foreach (var item in classes)
            {
                var simsClassId = item.SimsClassId;
                var admissionClass = _admisionApiClassMappingConfig.Where(x => x.sims_class_id.HasValue).FirstOrDefault(x => x.sims_class_id == simsClassId);

                if (admissionClass != null)
                {
                    item.AdmissionClassId = admissionClass.id;
                    item.AdmissionClassName = admissionClass.name;
                    item.ApplicationFormId = admissionClass.application_form_id;
                }
            }
            
            return classes;
        }

        public void LoadClassMappingConfigFromAdmissionApi()
        {
            var serializer = new JsonSerializer();
            var errorLogger = new ErrorLogger();
            var cache = new InMemoryCache();
            var client = new AdmissionClassesClient(cache, serializer, errorLogger);
            int appFormId = (int)cboApplicationForm.SelectedValue;
            _admisionApiClassMappingConfig = client.GetClasses(appFormId, MisCache.UserEmail, MisCache.UserToken);
        }


        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            LoadClassesDataFromSims();
            
        }
    }
}
