using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Xml;
using System.ComponentModel;

namespace DXApplication1.Model
{
    public class Repository : IRepository
    {
        private readonly string xmlFile;

        public BindingList<Contact> contacts { get; set; }

        BindingList<Contact> allContacts = new BindingList<Contact>();

        XmlSerializer formatter = new XmlSerializer(typeof(BindingList<Contact>));

        public Repository(string fullPath)
        {
            xmlFile = fullPath + @"\PhoneBook.xml";
            contacts = GetAllContacts();
        }

        public BindingList<Contact> GetAllContacts()
        {
            using (FileStream fs = new FileStream(xmlFile, FileMode.Open))
            {
                allContacts = (BindingList<Contact>)formatter.Deserialize(fs);
            }

            return allContacts;
        }

        public void RewriteXML()
        {
            using (FileStream fs = new FileStream(xmlFile, FileMode.Create))
            {
                formatter.Serialize(fs, contacts);
            }
        }
    }
}
