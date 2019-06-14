using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Common;
using Common.DataModel;
using Common.RestApi;
using SIMSInterface;
using JsonSerializer = RestSharp.Serialization.Json.JsonSerializer;

namespace Applicaa
{
    public partial class FrmClassesConfiguration : Form
    {
        private List<ClassesItem> admisionApiClassMappingConfig;
        public FrmClassesConfiguration()
        {
            InitializeComponent();
        }

        private void LoadClassesDataFromSims()
        {
            SIMSDllResolution.AddSIMSDllResolution();
            if (LoginHelper.SIMSlogin(AppSetting.Server,
                AppSetting.Database,
                AppSetting.User,
                AppSetting.Password))
            {
                //Applicant.
                var classes = Applicant.LoadClasses();
                foreach (var item in classes)
                {
                    var simsClassId = item.SimsClassId;
                    var admissionClass = admisionApiClassMappingConfig.Where(x => x.sims_class_id.HasValue)
                        .FirstOrDefault(x => x.sims_class_id == simsClassId);
                    if (admissionClass != null)
                    {
                        item.AdmissionClassId = admissionClass.id;
                        item.AdmissionClassName = admissionClass.name;
                    }
                }
                classMappingGrid.DataSource = classes;
                MisCache.ClassesMapping = classes;
            }
        }

        public void LoadClassMappingConfigFromAdmissionApi()
        {
            var serializer = new JsonSerializer();
            var errorLogger = new ErrorLogger();
            var cache = new InMemoryCache();
            var client = new AdmissionClassesClient(cache, serializer, errorLogger);

            admisionApiClassMappingConfig = client.GetClasses(MisCache.UserEmail, MisCache.UserToken);
        }

        private void FrmClassesConfiguration_Load(object sender, EventArgs e)
        {
            LoadClassMappingConfigFromAdmissionApi();

            LoadClassesDataFromSims();
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
            var frm= new FrmStudentSelection();
            frm.Show();

            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var frm = new FrmImportTypes();
            frm.Show();

            this.Hide();

        }
    }
}
