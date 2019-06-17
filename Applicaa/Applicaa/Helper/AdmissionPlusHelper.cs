using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Common.DataModel;
using Common.RestApi;
using JsonSerializer = RestSharp.Serialization.Json.JsonSerializer;

namespace Applicaa.Helper
{
    public class AdmissionPlusHelper
    {
        public static void LoadApplicationForm(ComboBox cboApplicationForm)
        {
            var serializer = new JsonSerializer();
            var errorLogger = new ErrorLogger();
            var client = new AdmissionApplicationFormClient(serializer, errorLogger);
            List<ApplicationFormsItem> appForms = client.GetApplicationForms(MisCache.UserEmail, MisCache.UserToken);
            cboApplicationForm.DataSource = appForms;
            cboApplicationForm.ValueMember = "id";
            cboApplicationForm.DisplayMember = "name";


            cboApplicationForm.SelectedValue = 1;
        }
    }
}
