using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ValidateXML
{
    public class XmlHelper
    {
        public static T ConvertToObject<T>(string xml, out string messages)
        {
            messages = string.Empty;

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
            catch (Exception ex)
            {
                messages = ex.Message;
                if (ex.InnerException != null)
                {
                    messages += " [ " + ex.InnerException.Message + " ]";
                }                
                return default(T);
            }
            finally
            {
                stream?.Close();
                reader?.Close();
            }
        }
    }
}
