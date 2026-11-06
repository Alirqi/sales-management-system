using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;


namespace SalesSystem.FR
{
    public partial class For_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CLASSES.FormFunction.FormsSetup fh = new CLASSES.FormFunction.FormsSetup();
        public For_Main()
        {
            InitializeComponent();
            CLASSES.FormFunction.splashScreenManager spm = new CLASSES.FormFunction.splashScreenManager(this);
        }

        private void For_Main_Load(object sender, System.EventArgs e)
        {
            //// احصل على جميع الأنواع في البرنامج
            //Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            //// احصل على أسماء الفورمات
            //foreach (Type type in types)
            //{
            //    // تحقق مما إذا كانت النوع يرث من فورم
            //    if (type.BaseType == typeof(System.Windows.Forms.Form))
            //    {
            //        Console.WriteLine(type.Name);
            //    }
            //}

            // احصل على جميع الأنواع في البرنامج
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            // احصل على أسماء الفورمات من نوع DevExpress.XtraEditors.XtraForm
            foreach (Type type in types)
            {
                // تحقق مما إذا كانت النوع يرث من DevExpress.XtraEditors.XtraForm
                if (type.IsSubclassOf(typeof(XtraForm)))
                {
                    Console.WriteLine(type.Name);
                }
            }

            For_Accounts fm = new For_Accounts();
            // قم بإضافة الأدوات إلى myForm هنا

           
            // قم بإضافة الأدوات إلى myForm هنا

            List<string> buttonNames = GetControlNamesByType<DevExpress.XtraEditors.SimpleButton>(fm);
            List<string> textEditNames = GetControlNamesByType<DevExpress.XtraEditors.TextEdit>(fm);

            Console.WriteLine("SimpleButton Names:");
            foreach (string name in buttonNames)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("TextEdit Names:");
            foreach (string name in textEditNames)
            {
                Console.WriteLine(name);
            }

            DevExpress.XtraEditors.XtraForm myForm = new DevExpress.XtraEditors.XtraForm();
            // قم بإضافة الأدوات إلى myForm هنا

            List<string> buttonNames2 = GetControlNamesByType<DevExpress.XtraEditors.SimpleButton>(myForm);
            List<string> textEditNames2 = GetControlNamesByType<DevExpress.XtraEditors.TextEdit>(myForm);

            Console.WriteLine("SimpleButton Names:");
            foreach (string name in buttonNames2)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("TextEdit Names:");
            foreach (string name in textEditNames2)
            {
                Console.WriteLine(name);
            }


        }
        public List<string> GetControlNamesByType<T>(DevExpress.XtraEditors.XtraForm form) where T : BaseControl
        {
            List<string> controlNames = new List<string>();

            foreach (var control in form.Controls)
            {
                if (control is T)
                {
                    controlNames.Add(((T)control).Name);
                }
            }

            return controlNames;
        }


        private void For_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("F1");
            }
            if (e.KeyCode == Keys.H && Control.ModifierKeys == Keys.Control)
            {
                MessageBox.Show("Control + H");
            }
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Shift)
            {
                fh.HandleForm(new For_ConnectDb(), xtraTabControl1);
            }
        }

        private void For_Main_FormClosing(object sender, FormClosingEventArgs e)
        {          
            Application.Exit();
        }



        private void barButtonItemSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.ShowWaitForm();
            
            fh.HandleForm(new For_Options(), xtraTabControl1);
        }

        private void barButtonItemLgin_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
            new For_Login().ShowDialog();
        }

        private void barButtonItemLgout_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItemHome_ItemClick(object sender, ItemClickEventArgs e)
        {

            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.ShowWaitForm();
        
            fh.HandleForm(new For_ConnectDb(), xtraTabControl1);
        }


        private void xtraTabControl1_CloseButtonClick(object sender, System.EventArgs e)
        {
            ClosTap(e);
        }

        public void ClosTap(System.EventArgs e)
        {
            ClosePageButtonEventArgs args = e as ClosePageButtonEventArgs;
            if (args != null)
            {
                XtraTabPage tabPage = args.Page as XtraTabPage;
                if (tabPage != null)
                {
                    // إغلاق الفورم الموجودة داخل TabPage إذا كانت مفتوحة
                    Form form = tabPage.Controls.OfType<Form>().FirstOrDefault();
                    if (form != null)
                    {
                        form.Close();
                        form.Dispose();
                    }

                    int selectedIndex = xtraTabControl1.SelectedTabPageIndex;
                    xtraTabControl1.TabPages.Remove(tabPage);
                    if (selectedIndex >= xtraTabControl1.TabPages.Count)
                    {
                        selectedIndex = xtraTabControl1.TabPages.Count - 1;
                    }
                    xtraTabControl1.SelectedTabPageIndex = selectedIndex;
                }
            }
        }
        public void ClosTap()
        {
            if (xtraTabControl1.SelectedTabPage != xtraTabControl1.TabPages[0])
            {
                xtraTabControl1.TabPages.Remove(xtraTabControl1.SelectedTabPage);
                xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages.Last();
            }
        }

       

        private void barButtonItemCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.ShowWaitForm();          
            fh.HandleForm(new For_Category(), xtraTabControl1);

        }

        private void barButtonItemUnits_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.ShowWaitForm();                     
            fh.HandleForm(new For_Units(), xtraTabControl1);


        }

        private void barButtonItemProducts_ItemClick(object sender, ItemClickEventArgs e)
        {

            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.ShowWaitForm();         
            fh.HandleForm(new For_Product(), xtraTabControl1);

           
        }

        private void barButtonItemCustomers_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.ShowWaitForm();           
            fh.HandleForm(new For_Customers(), xtraTabControl1);
        }

        private void barButtonItemSuppliers_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.ShowWaitForm();           
            fh.HandleForm(new For_Supplier(), xtraTabControl1);
        }

        private void barButtonItemStor_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.ShowWaitForm();           
            fh.HandleForm(new For_Stores(), xtraTabControl1);
        }

        private void barButtonItemPrcing_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.ShowWaitForm();           
            fh.HandleForm(new For_Pricing(), xtraTabControl1);
        }

        private void barButtonItemAccounting_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.ShowWaitForm();
            fh.HandleForm(new For_Accounts(), xtraTabControl1);
        }

        private void barButtonItemUsers_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.ShowWaitForm();
            fh.HandleForm(new For_Mang_Users(), xtraTabControl1);
        }

        private void barButtonItemCurrencies_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.ShowWaitForm();
            fh.HandleForm(new For_Currency(), xtraTabControl1);
        }
    }
}