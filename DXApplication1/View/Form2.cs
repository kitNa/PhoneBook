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

namespace DXApplication1
{
    public partial class FormForChanges : Form
    {
        public Presenter.PhoneBookPresenter Presenter { private get; set; }

        public int rowHandle { get; set; }

        public FormForChanges(Presenter.PhoneBookPresenter Presenter)
        {
            this.Presenter = Presenter;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            try
            {
                Convert.ToInt32(textBox2.Text);  

                if (this.Text.Contains("Бажаєте додати контакт?"))
                {
                    Presenter.ToAddContact(textBox1.Text, textBox2.Text);
                    this.Hide();
                }
                else if (this.Text.Contains("Бажаєте редагувати контакт?"))
                {
                    //если пользователь очистил textBox, вызываем MessageBox для подтверждения желания удалить контакт
                    if (this.textBox1.Text == "")
                    {
                        DialogResult result = MessageBox.Show("Ви точно бажаєте видалити цей контакт?",
                            "Підтвердження",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2,
                            MessageBoxOptions.DefaultDesktopOnly);

                        if (result == DialogResult.Yes)
                        {
                            Presenter.ToDeleteContact(rowHandle);
                            this.Hide();
                        }
                    }
                    else
                    {
                        Presenter.ToChangeContact(rowHandle, textBox1.Text, textBox2.Text);
                        this.Hide();
                    }
                }
            }
            catch
            {
               MessageBox.Show("Номер телефону має бути заповненний та може включати лише цифри", "Недопустиме значення!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
