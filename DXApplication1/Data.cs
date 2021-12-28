using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Runtime.CompilerServices;

namespace DXApplication1
{
    public class Data : INotifyPropertyChanged
    {
        public DataTable PhoneBook{ get; set; }
        private string fullName;
        private string phoneNumber;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Data()
        {
            //загружаем XML документ
            var document = new XmlDocument();
            document.Load("PhoneBook.XML");
            XmlNode root = document.DocumentElement;
            PhoneBook = new DataTable();

            //заполняем таблицу дата-сета
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

                    //изменяем поля для автоматического отображения обновлений 
                    this.Name = rows[0];
                    this.PhoneNumber = rows[1];

                    PhoneBook.Rows.Add(rows);
                }
            }
        }
        public string Name
        {
            get
            {
                return this.fullName;
            }

            set
            {
                if (value != this.fullName)
                {
                    this.fullName = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                if (value != this.phoneNumber)
                {
                    this.phoneNumber = value;
                    NotifyPropertyChanged("PhoneNumber");
                }
            }
        }
    //    public DataTable PhoneBook
    //    {
    //        get
    //        {
    //            return this.phoneBook;
    //        }

    //        set
    //        {
    //            if (value != this.phoneBook)
    //            {
    //                this.PhoneBook = value;
    //                NotifyPropertyChanged("phoneBook");
    //            }
    //        }
    //    }
    }
}
        

