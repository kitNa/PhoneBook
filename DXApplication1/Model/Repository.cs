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

namespace DXApplication1.Model
{
    public class Repository : IRepository
    {
        private readonly string xmlFile;

        public ObservableCollection<Contact> contacts { get; set; }

        ObservableCollection<Contact> allContacts = new ObservableCollection<Contact>();

        XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Contact>));

        public Repository(string fullPath)
        {
            xmlFile = fullPath + @"\PhoneBook.xml";
            contacts = GetAllContacts();
        }

        public ObservableCollection<Contact> GetAllContacts()
        {
            
            using (FileStream fs = new FileStream(xmlFile, FileMode.Open))
            {
                allContacts = (ObservableCollection<Contact>)formatter.Deserialize(fs);
            }

            return allContacts;
        }

        public void ToRewritingXML()
        {
            using (FileStream fs = new FileStream(xmlFile, FileMode.Create))
            {             
                formatter.Serialize(fs, contacts);
            }
        }
    }
}
