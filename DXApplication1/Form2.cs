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
    public partial class Form2 : Form
    {
        public FormMain main;
        public int rowHandle { get; set; }

        public Form2()
        {
            InitializeComponent();
            main = new FormMain();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            try
            {
                //проверяем является ли введенное значение для номера телефона числом
                Convert.ToInt32(textBox2.Text);  

                if (this.Text.Contains("Бажаєте додати контакт?"))
                {
                    //добавляем данные в новую строку
                    main.data.PhoneBook.NewRow();
                    main.data.PhoneBook.Rows.Add(textBox1.Text, textBox2.Text);

                    //вносим изменения в исходний XML-файл
                    main.ToRewritingXML();

                    ////отображаем новые данные на экране
                    //main.PhoneBookControl.DataSource = main.data.PhoneBook;
                    this.Hide();
                   // main.ShowDialog();
                }
                else if (this.Text.Contains("Бажаєте редагувати контакт?"))
                {
                    //вносим изменения в grid
                    main.data.PhoneBook.Rows[rowHandle].ItemArray = new string[2] { textBox1.Text, textBox2.Text };

                    //если пользователь очистил textBox, вызываем MessageBox для подтверждения желания удалить контакт
                    if (this.textBox1.Text == "")
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
                            main.data.PhoneBook.Rows[rowHandle].Delete();

                            //переписываем исходный XML-файл
                            main.ToRewritingXML();

                            ////отображаем новые данные на экране
                            //main.PhoneBookControl.DataSource = main.data.PhoneBook;
                            this.Hide();
                           // main.ShowDialog();
                        }
                    }
                    else
                    {
                        //переписываем исходный XML-файл
                        main.ToRewritingXML();

                        ////отображаем новые данные на экране
                        //main.PhoneBookControl.DataSource = main.PhoneBookXML.Tables[0];
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
          //  main.ShowDialog();
        }
    }
}
