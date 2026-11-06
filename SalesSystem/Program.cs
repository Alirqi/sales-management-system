using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraRichEdit.Model;

namespace SalesSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ThemStyle();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            

            Application.Run(new FR.For_Login());
        }

        public static void ThemStyle()
        {
            // تعيين الثيم المطلوب
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.ThemName);
        }
    }
}




