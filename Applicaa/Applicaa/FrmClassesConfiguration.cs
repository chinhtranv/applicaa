using System;
using System.Windows.Forms;
using Common;
using SIMSInterface;

namespace Applicaa
{
    public partial class FrmClassesConfiguration : Form
    {
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
                classMappingGrid.DataSource = classes;
                MisCache.ClassesMapping = classes;
            }
        }

        private void FrmClassesConfiguration_Load(object sender, EventArgs e)
        {
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

        }
    }
}
