using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesSystem.CLASSES.SysNotification
{
    class Notification
    {
        public static void ShowMessageBoxArgs(string caption,string text)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 5000;
            args.Caption = caption;
            args.Text = text;
            args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            XtraMessageBox.Show(args).ToString();
        }

        //public static void MessageBoxWarning(string caption)
        //{

        //    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default,caption, "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
        //}
        public static void MessageBoxWarning(string caption)
        {
            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
            args.Icon = System.Drawing.SystemIcons.Warning;
            args.Caption = caption;
            args.Text = "Warning";
            args.Buttons = new[] { DialogResult.OK };
           // args.Appearance.BackColor = System.Drawing.Color.White; // تعيين لون الخلفية المطلوب
            //args.Appearance.ForeColor = System.Drawing.Color.Black; // تعيين لون النص المطلوب
            DevExpress.XtraEditors.XtraMessageBox.Show(args);
        }


        public static void MessageBoxError(string caption)
        {
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default,$"{ caption}", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        public static void MessageBoxInformation(string caption)
        {
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, caption, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void MessageBoxExclamation(string caption)
        {
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, caption, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static DialogResult MessageBoxQuestion(string caption)
        {
            return XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, caption, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
