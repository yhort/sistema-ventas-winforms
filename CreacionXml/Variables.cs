using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace CreacionXml
{
    public class Variables
    {
        public static string PrettyXML(string xmlString)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xw.Formatting = Formatting.Indented;
            xw.Indentation = 4;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            doc.Save(xw);

            return sw.ToString();
        }

    }
}
