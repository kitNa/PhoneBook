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
        private readonly string _xmlFile;

        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));

        private readonly Lazy<ObservableCollection<Contact>> _contacts;

        public DataTable PhoneBook { get; set; }

        public Repository(string fullPath)
        {
            _xmlFile = fullPath + @"\PhoneBook.xml";

            if (!File.Exists(_xmlFile))
                CreateContactsXml();

            _contacts = new Lazy<ObservableCollection<Contact>>(() =>
            {
                using (var reader = new StreamReader(_xmlFile))
                {
                    return (ObservableCollection<Contact>)_serializer.Deserialize(reader);
                }
            });
        }

        private void CreateContactsXml()
        {
            var stubContactsCollection = new ObservableCollection<Contact> {
                new Contact {Name = "Коломієць Максим", Phone = "06627302029"},
                new Contact {Name = "Головач Меланія", Phone = "0634891234"},
                new Contact {Name = "Радченко Катерина", Phone = "0504567878"}
            };
            SaveContactsCollection(stubContactsCollection);
        }

        private void SaveContactsCollection(ObservableCollection<Contact> contacts)
        {
            using (var writer = new StreamWriter(_xmlFile, false))
            {
                _serializer.Serialize(writer, contacts);
            }
        }

        public DataTable GetAllContacts()
        {
            PhoneBook = new DataTable();
            var document = new XmlDocument();
            document.Load("PhoneBook.XML");
            XmlNode root = document.DocumentElement;

            foreach (XmlNode contact in root.ChildNodes)
            {
                if (contact.Name.Equals("Header"))
                {
                    foreach (XmlNode node in contact.ChildNodes)
                    {
                        PhoneBook.Columns.Add(node.InnerText);
                    }
                }
                else
                {
                    string[] rows = new string[PhoneBook.Columns.Count];

                    int i = 0;

                    foreach (XmlNode row in contact.ChildNodes)
                    {
                        rows[i] = row.InnerText;
                        i++;
                    }

                    Contact newContact = new Contact();

                    PhoneBook.Rows.Add(rows);
                }
            }

            return PhoneBook;
        }

        public void ToRewritingXML()
        {
            var xmlWriter = new XmlTextWriter(_xmlFile, null);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("ListOfContacts");

            xmlWriter.WriteStartElement("Header");
            xmlWriter.WriteStartElement("Name");
            xmlWriter.WriteString(PhoneBook.Columns[0].ColumnName);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Phone");
            xmlWriter.WriteString(PhoneBook.Columns[1].ColumnName);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            for (int j = 0; j < PhoneBook.Rows.Count; j++)
            {
                object[] value = PhoneBook.Rows[j].ItemArray;

                xmlWriter.WriteStartElement("Contact");
                xmlWriter.WriteStartElement("Name");
                xmlWriter.WriteString(value[0].ToString());
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("Phone");
                xmlWriter.WriteString(value[1].ToString());
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
            }

            xmlWriter.Close();
        }
    }
}
