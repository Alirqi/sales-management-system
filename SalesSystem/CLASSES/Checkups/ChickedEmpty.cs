using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace SalesSystem.CLASSES.Checkups
{
    interface ChickedEmpty
    {
        bool CheckControls(string Messag , params object[] controls);

    }
    class Checek_Rusalt : ChickedEmpty
    {

        public bool CheckControls(string Messag,params object[] controls)
        {
            foreach (var control in controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        if(Messag.Equals(""))
                        {
                            Messag = $"{textBox.Tag} Is Empty";
                        }
                        //MessageBox.Show($"{textBox.Name} فارغ");
                        CLASSES.SysNotification.Notification.MessageBoxError(Messag);
                        return true;
                    }

                }
                else if (control is PictureBox pictureBox)
                {
                    if (pictureBox.Image == null)
                    {
                        if (Messag.Equals(""))
                        {
                            Messag = $"{pictureBox.Tag} Is Empty";
                        }
                        //MessageBox.Show($"{pictureBox.Name} لا يحتوي على صورة");
                        CLASSES.SysNotification.Notification.MessageBoxError(Messag);
                        return true;
                    }
                }
                else if (control is TextEdit textEdit)
                {
                    if (string.IsNullOrEmpty(textEdit.Text))
                    {
                        if (Messag.Equals(""))
                        {
                            Messag = $"{textEdit.Tag} Is Empty";
                        }
                        //MessageBox.Show($"{textEdit.Name} فارغ");
                        CLASSES.SysNotification.Notification.MessageBoxError(Messag);
                        return true;
                    }
                }
               
            }
            return false;
        }

    }
}
