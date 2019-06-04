using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BilledEditor
{
  public class User
    {
        [XmlElement("x")]
        public double X { get; set; }

        [XmlElement("y")]
        public double Y { get; set; }

        [XmlElement("tip")]
        public String TIP { get; set; }

        [XmlElement("sti")]
        public String STI { get; set; }
    }
}
