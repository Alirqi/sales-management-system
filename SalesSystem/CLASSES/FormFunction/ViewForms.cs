using DevExpress.XtraTab;
using SalesSystem.FR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesSystem.CLASSES.FormFunction
{
    public interface IFormDisplay
    {
        void AddFormToTabControl(Form form, XtraTabControl tabControl);
        void ShowFormDialog(Form form);
    }
    public class ViewForms : IFormDisplay
    {
        public void AddFormToTabControl(Form form, XtraTabControl tabControl)
        {
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Text == form.Text)
                {                   
                    tabControl.SelectedTabPage = tabControl.TabPages[i];
                    CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();
                    return;
                }
            }
            XtraTabPage tabPage = new XtraTabPage();
            tabPage.Text = form.Text;

            // تعيين الأيقونة المرتبطة بـ XtraTabPage
         //    tabPage.ImageOptions.Image = Image.FromFile(@"icon\cashing.jpg"); // حيث "path/to/icon1.png" هو مسار الصورة المخصصة
          
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            tabPage.Controls.Add(form);
            tabControl.TabPages.Add(tabPage);

            form.Show();
            tabControl.SelectedTabPage = tabPage;

            SalesSystem.CLASSES.Setting.SetFonts.SetFont(tabPage);
        }

        public void ShowFormDialog(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }

        
}
