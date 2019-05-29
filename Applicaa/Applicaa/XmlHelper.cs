using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Applicaa
{
    public class XmlHelper
    {

        public static T ConvertToObject<T>(string xml)
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
    }
}
