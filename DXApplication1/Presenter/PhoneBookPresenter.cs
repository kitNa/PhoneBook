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
using DXApplication1.View;
using DXApplication1.Model;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace DXApplication1.Presenter
{
    public class PhoneBookPresenter
    {
        private readonly FormForChanges formForChanges;
        private readonly CheckedListBox checkedList;
        private readonly IView _view;
        private readonly IRepository _repository;

        private readonly BindingSource bindingSource = new BindingSource();

        public PhoneBookPresenter(IView view, IRepository repository)
        {
            this.formForChanges = new FormForChanges(this);
            this.checkedList = new CheckedListBox();

            _view = view;
            view.Presenter = this;
            _repository = repository;
            bindingSource.DataSource = _repository.GetAllContacts();

            UpdateContactListView();
        }
        
        public void UpdateContactListView()
        {
            _view.PhoneBook = (DataTable)bindingSource.DataSource;
        }

        public void ToDeleteContact(int focusedRowHandle)
        {
            _repository.PhoneBook.Rows[focusedRowHandle].Delete();
            _repository.ToRewritingXML();
            UpdateContactListView();
        }
        public void ToSort()
        {
            _repository.PhoneBook = _view.PhoneBook.CreateDataReader().GetSchemaTable();
        }

        public void ToFilter(Regex phone_operator, DataTable FilterPhoneBook)
        {
            for (int i = 0; i < _repository.PhoneBook.Rows.Count; i++)
            {
                object[] values = _repository.PhoneBook.Rows[i].ItemArray;

                if (phone_operator.IsMatch(values[1].ToString()))
                {
                    FilterPhoneBook.NewRow();
                    FilterPhoneBook.Rows.Add(values);
                }
            }

            UpdateContactListView();
        }

        public void ToFilterGrid()
        {
            //создаем новую таблицу данных для grid, исходя из заданных параметров фильтра
            DataTable FilterPhoneBook = new DataTable();

            //заполняем заголовок новой таблицы
            FilterPhoneBook.Columns.Add(_repository.PhoneBook.Columns[0].ColumnName);
            FilterPhoneBook.Columns.Add(_repository.PhoneBook.Columns[1].ColumnName);

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

                UpdateContactListView();
        }

        public void ToAddContact(string textBox1, string textBox2)
        {
            _repository.PhoneBook.NewRow();
            _repository.PhoneBook.Rows.Add(textBox1, textBox2);

            _repository.ToRewritingXML();
            UpdateContactListView();
        }

        public void ToChangeContact(int rowHandle, string textBox1, string textBox2)
        {
            _repository.PhoneBook.Rows[rowHandle].ItemArray = new string[2] { textBox1, textBox2 };

            _repository.ToRewritingXML();
            UpdateContactListView();
        }
    }
}
