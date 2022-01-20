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

namespace DXApplication1
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm, IView
    {
        public CheckedListBox checkedListBox { get; set; }
        public Contact focusedContact { get; set; }
        public Presenter.PhoneBookPresenter Presenter { private get; set; }

        public BindingSource bindingSource
        {
            get { return this.contactsBindingSource; }
            set { this.contactsBindingSource = bindingSource; }
        }

        public FormMain()
        {
            InitializeComponent();
            checkedListBox = this.checkedList;
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void редагуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeContact();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChangeContact();
        }

        private void ContactList_DoubleClick(object sender, EventArgs e)
        {
            ChangeContact();
        }

        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presenter.FilterGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Presenter.UpdateContactListView();
        }

        public void ChangeContact()
        {
            FormForChanges change_contact = new FormForChanges(Presenter);
            change_contact.Text = "Бажаєте редагувати контакт?";

            focusedContact = (Contact)ContactList.GetRow(ContactList.FocusedRowHandle);

            change_contact.focusedContactId = focusedContact.id;
            change_contact.textBox1.Text = focusedContact.fullName;
            change_contact.textBox2.Text = focusedContact.Phone;

            change_contact.ShowDialog();
        }

        public void AddContact()
        {
            FormForChanges add_person = new FormForChanges(Presenter);
            add_person.Text = "Бажаєте додати контакт?";
            add_person.ShowDialog();
        }

        public void DeleteContact()
        {
            DialogResult result = ShowMassageBox();

            if (result == DialogResult.Yes)
            {
                Contact focusedContact = (Contact)ContactList.GetRow(ContactList.FocusedRowHandle);
                Presenter.DeleteContact(focusedContact.id);
            }
        }

        public DialogResult ShowMassageBox()
        {
            DialogResult result = MessageBox.Show("Ви точно бажаєте видалити цей контакт?",
               "Підтвердження",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);

            return result;
        }
    }
}
