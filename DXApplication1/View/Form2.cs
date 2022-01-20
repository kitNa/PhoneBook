using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using DXApplication1;
using DXApplication1.Presenter;

namespace DXApplication1
{
    public partial class FormForChanges : Form
    {
        public PhoneBookPresenter presenter { private get; set; }
        public int focusedContactId { get; set; }
        public int focusedContactRow { get; set; }

        public FormForChanges(PhoneBookPresenter presenter)
        {
            this.presenter = presenter;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox2.Text);

                if (this.Text.Contains("Бажаєте додати контакт?"))
                {
                    presenter.AddContact(textBox1.Text, textBox2.Text);
                }
                else if (this.Text.Contains("Бажаєте редагувати контакт?"))
                {
                    //если пользователь очистил textBox, вызываем MessageBox для подтверждения желания удалить контакт
                    if (this.textBox1.Text == "")
                    {
                        DialogResult result = ShowMassageBox();

                        if (result == DialogResult.Yes)
                        {
                            presenter.DeleteContact(focusedContactId);
                        }
                    }
                    else
                    {
                        presenter.ChangeContact(focusedContactId, textBox1.Text, textBox2.Text);
                    }
                }

                this.Close();
            }
            catch
            {
                MessageBox.Show("Номер телефону має бути заповненний та може включати лише цифри", "Недопустиме значення!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
