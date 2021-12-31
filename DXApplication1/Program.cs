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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var repository = new Model.Repository(Application.StartupPath);
            var view_main = new FormMain();

            var presenter = new Presenter.PhoneBookPresenter(view_main, repository);

            BonusSkins.Register();
            Application.Run(view_main);
        }
    }
}
