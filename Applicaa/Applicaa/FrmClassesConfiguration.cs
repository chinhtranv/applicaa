using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIMSInterface;

namespace Applicaa
{
    public partial class FrmClassesConfiguration : Form
    {
        public FrmClassesConfiguration()
        {
            InitializeComponent();
        }

        private void LoadClassDataFromSIMS()
        {

        }

        private void FrmClassesConfiguration_Load(object sender, EventArgs e)
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
            }
        }
    }
}
