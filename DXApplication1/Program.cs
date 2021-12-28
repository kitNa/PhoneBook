using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace DXApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //записываем исходный txt файл

            //StreamWriter writer = new StreamWriter("Phone_book.txt");

            //writer.WriteLine("Прізвище та ім'я,Номер телефону");
            //writer.WriteLine("Головач Маргарита,0667798945");
            //writer.WriteLine("Радченко Катерина,0634567898");
            //writer.WriteLine("Вишняківський Дмитро,0934567896");

            //writer.Close();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

//            MessageBoxManager.Register();

            BonusSkins.Register();
            Application.Run(new FormMain());
        }
    }
}
