using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;

namespace DXApplication1
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        private BindingSource bindingSource = new BindingSource();

        public Data data { get; set; }

        public FormMain()
        {
            InitializeComponent();
            data = new Data();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //привязываем данные из класса Data к Grid  
            bindingSource.DataSource = data.PhoneBook;
            PhoneBookControl.DataSource = bindingSource;
        }

        private void ContactList_DoubleClick(object sender, EventArgs e)
        {
            ChangeContact();
        }

        //закрываение всех открытых форм при окончании сеанса программы
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormCollection forms = Application.OpenForms;
            foreach (Form form in forms)
                form.Hide();
        }

        private void ContactList_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {

        }

        //метод для получения данных из XML
        public DataSet GetData()
        {
            //создаем дата-сет для grid
            DataSet data = new DataSet();
            data.Tables.Add("ListOfContacts");

            //загружаем XML документ
            var document = new XmlDocument();
            document.Load("PhoneBook.xml");
            XmlNode root = document.DocumentElement;

            //заполняем таблицу дата-сета
            foreach (XmlNode contact in root.ChildNodes)
            {
                if (contact.Name.Equals("Header"))
                {
                    foreach (XmlNode node in contact.ChildNodes)
                    {
                        data.Tables[0].Columns.Add(node.InnerText);
                    }
                }
                else
                {
                    string[] rows = new string[data.Tables[0].Columns.Count];

                    int i = 0;

                    foreach (XmlNode row in contact.ChildNodes)
                    {
                        rows[i] = row.InnerText;
                        i++;
                    }
                    data.Tables[0].Rows.Add(rows);
                }
            }
            return data;
        }
        //метод для перезаписи в XML-файл после изменения grid
        public void ToRewritingXML()
        {
            var xmlWriter = new XmlTextWriter("PhoneBook.xml", null);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("ListOfContacts");

            //записываем название столбцов в XML-файл
            xmlWriter.WriteStartElement("Header");
            xmlWriter.WriteStartElement("Name");
            xmlWriter.WriteString(data.PhoneBook.Columns[0].ColumnName);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Phone");
            xmlWriter.WriteString(data.PhoneBook.Columns[1].ColumnName);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            //записываем значения рядков в XML-файл
            for (int j = 0; j < data.PhoneBook.Rows.Count; j++)
            {
                object[] value = data.PhoneBook.Rows[j].ItemArray;

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
        //метод для редактирования контакта
        public void ChangeContact()
        {
            //вызываем форму для изменения строки
            Form2 change_contact = new Form2();
            change_contact.Text = "Бажаєте редагувати контакт?";

            //Получаем данные из строки, на которую указывает указатель
            change_contact.rowHandle = ContactList.FocusedRowHandle;
            object[] values = ContactList.GetDataRow(change_contact.rowHandle).ItemArray;

            //заполняем исходные данные формы изменения строки
            change_contact.textBox1.Text = values[0].ToString();
            change_contact.textBox2.Text = values[1].ToString();

            //выводим форму на экран
           // this.Hide();
            change_contact.ShowDialog();
        }
        //метод для добавление контакта
        public void AddContact()
        {
            //вызываем форму для добавления строки
            Form2 add_person = new Form2();
            add_person.Text = "Бажаєте додати контакт?";
            add_person.ShowDialog();
        }
        //метод для удаления контакта
        public void DeleteContact()
        {
            //вызываем MessageBox с необходимыми параметрами
            DialogResult result = MessageBox.Show("Ви точно бажаєте видалити цей контакт?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                //удаляем выделенный ряд
                data.PhoneBook.Rows[ContactList.FocusedRowHandle].Delete();

                //фиксируем изменение в XML-файл 
                ToRewritingXML();
            }
        }
        //Додати
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddContact();
        }
        //Редагувати
        private void редагуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeContact();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChangeContact();
        }
        //Видалити
        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }
        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }
        //фильтрация отображаемых данных
        private void button1_Click(object sender, EventArgs e)
        {
            //создаем новую таблицу данных для grid, исходя из заданных параметров фильтра
            DataTable FilterPhoneBook = new DataTable();

            //заполняем заголовок новой таблицы
            FilterPhoneBook.Columns.Add(data.PhoneBook.Columns[0].ColumnName);
            FilterPhoneBook.Columns.Add(data.PhoneBook.Columns[1].ColumnName);

            //создаем регулярные выражения для фильтрации
            var MTS = new Regex("^[0][6][6]|^[0][9][5]|^[0][5][0]|^[0][9][9]");
            var Life = new Regex("^[0][6][3]|^[0][9][3]|^[0][7][3]");
            var Kyivstar = new Regex("^[0][6][7]|^[0][6][8]|^[0][9][8]|^[0][9][7]|^[0][9][6]");

            if (checkedList.GetItemChecked(0))
            {
                ToFilter(MTS, FilterPhoneBook);
            }
            if (checkedList.GetItemChecked(1))
            {
                ToFilter(Life, FilterPhoneBook);
            }
            if (checkedList.GetItemChecked(2))
            {
                ToFilter(Kyivstar, FilterPhoneBook);
            }          
            if (checkedList.GetItemChecked(0) == false && checkedList.GetItemChecked(1) == false &&
                checkedList.GetItemChecked(2) == false)
            {
                PhoneBookControl.DataSource = data.PhoneBook;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PhoneBookControl.DataSource = data.PhoneBook;
        }
        //метод для фильтрации отображаемых данных
        public void ToFilter(Regex phone_operator, DataTable FilterPhoneBook)
        {
            for (int i = 0; i < data.PhoneBook.Rows.Count; i++)
            {
                object[] values = data.PhoneBook.Rows[i].ItemArray;

                if (phone_operator.IsMatch(values[1].ToString()))
                {
                    FilterPhoneBook.NewRow();
                    FilterPhoneBook.Rows.Add(values);
                }
            }

            //привязываем новую таблицу к grid
            PhoneBookControl.DataSource = FilterPhoneBook;
        }

        private void PhoneBookControl_Click(object sender, EventArgs e)
        {

        }
    }  
}
