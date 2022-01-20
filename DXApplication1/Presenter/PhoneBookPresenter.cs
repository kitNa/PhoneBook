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
        private readonly IView view;
        private readonly IRepository repository;
        BindingList<Contact> viewContacts;

        public PhoneBookPresenter(IView view, IRepository repository)
        {
            this.formForChanges = new FormForChanges(this);
            this.view = view;
            view.Presenter = this;
            this.repository = repository;
            UpdateContactListView();
        }

        public void UpdateContactListView()
        {
            viewContacts = repository.GetAllContacts();
            view.bindingSource.DataSource = viewContacts;
        }

        public void DeleteContact(int focusedContactId)
        {
            for (int i = 0; i < repository.contacts.Count; i++)
            {
                if (repository.contacts[i].id == focusedContactId)
                {
                    repository.contacts.RemoveAt(i);
                }
            }

            for (int i = 0; i < viewContacts.Count; i++)
            {
                if (viewContacts[i].id == focusedContactId)
                {
                    viewContacts.RemoveAt(i);
                }
            }

            repository.RewriteXML();
        }

        public void FilterGrid()
        {
            viewContacts.Clear();

            var MTS = new Regex("^[0][6][6]|^[0][9][5]|^[0][5][0]|^[0][9][9]");
            var Life = new Regex("^[0][6][3]|^[0][9][3]|^[0][7][3]");
            var Kyivstar = new Regex("^[0][6][7]|^[0][6][8]|^[0][9][8]|^[0][9][7]|^[0][9][6]");

            if (view.checkedListBox.GetItemChecked(0))
            {
                Filter(MTS);
            }
            if (view.checkedListBox.GetItemChecked(1))
            {
                Filter(Life);
            }
            if (view.checkedListBox.GetItemChecked(2))
            {
                Filter(Kyivstar);
            }
            if (view.checkedListBox.GetItemChecked(0) == false && view.checkedListBox.GetItemChecked(1) == false &&
                view.checkedListBox.GetItemChecked(2) == false)
            {
                this.viewContacts = repository.contacts;
            }
        }

        public void Filter(Regex phone_operator)
        {
            for (int i = 0; i < repository.contacts.Count; i++)
            {
                Contact contact = repository.contacts[i];

                if (phone_operator.IsMatch(contact.Phone.ToString()))
                {
                    viewContacts.Add(contact);
                }
            }
        }

        public void AddContact(string textBox1, string textBox2)
        {
            repository.contacts.Add(new Contact
            {
                fullName = textBox1,
                Phone = textBox2,
                id = repository.contacts[repository.contacts.Count - 1].id + 1
            });

            viewContacts.Add(new Contact
            {
                fullName = textBox1,
                Phone = textBox2,
                id = repository.contacts[repository.contacts.Count - 1].id + 1
            });

            repository.RewriteXML();
        }

        public void ChangeContact(int focusedContactId, string name, string phone)
        {
            foreach (Contact contact in repository.contacts)
            {
                if (contact.id == focusedContactId)
                {
                    contact.fullName = name;
                    contact.Phone = phone;
                }
            }

            for (int i = 0; i < viewContacts.Count; i++)
            {
                if (viewContacts[i].id == focusedContactId)
                {
                    viewContacts[i].fullName = name;
                    viewContacts[i].Phone = phone;
                }
            }

            repository.RewriteXML();
        }
    }
}
