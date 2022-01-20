using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DXApplication1.Model
{
    [Serializable]
    [XmlRoot("ArrayOfContact")]
    public class Contact
    {
        public string fullName { get; set; }
        public string Phone { get; set; }
        public int id { get; set; }

        public Contact()
        {
        }

        public Contact(string name, string phone)
        {
            this.fullName = name;
            this.Phone = phone;
        }
    }
}
