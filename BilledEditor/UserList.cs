using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BilledEditor
{
    [XmlRoot("user_list")]
   public class UserList
    {
        public UserList() { Items = new List<User>(); }
        [XmlElement("mark")]
        public List<User> Items { get; set; }
    }


}
