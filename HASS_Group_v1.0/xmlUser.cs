using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HASS_Group_v1._0
{
    public class xmlUser
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

    }
    [XmlRoot("Users")]
    public class UsersCollections
    {
        [XmlElement("User")]
        public List<xmlUser> Users { get; set; }
    }
}
