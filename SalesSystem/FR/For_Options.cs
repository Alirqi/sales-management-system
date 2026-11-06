using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.LookAndFeel;
using System.Linq;
using System.Activities.Expressions;
using System.IO;
using System.ComponentModel;
using DevExpress.XtraVerticalGrid;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;

namespace SalesSystem.FR
{
    public partial class For_Options : DevExpress.XtraEditors.XtraForm
    {
        CLASSES.Initialization.AppearanceFonts fp = new CLASSES.Initialization.AppearanceFonts();

        object d = new CLASSES.Initialization.AppearanceFonts();
        public String lang;

        public For_Options()
        {
            InitializeComponent();
            lang = CLASSES.Initialization.LanguageSettings.Languag;
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void For_Options_Load(object sender, EventArgs e)
        {
            treeList1.DataSource = CLASSES.Initialization.TreeOption.CreateData();
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "ParentID";
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();
        }

        private void tex_Filter_Tree_EditValueChanged(object sender, EventArgs e)
        {
            // Get the text from the TextEdit control
            string filterText = tex_Filter_Tree.Text;

            // Apply the filter to the TreeList
            treeList1.ActiveFilterString = $"[Name] LIKE '%{filterText}%'";

        }



        private void treeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Node == treeList1.FocusedNode)
            {
                e.Appearance.BackColor = Color.Blue;
                e.Appearance.ForeColor = Color.White;
            }
        }

        void SetSelectedObject<T>() where T : new()
        {
            T instance = new T();
            propertyGridControl1.SelectedObject = instance;
        }
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {


            if (e.Node != null)
            {
                TreeListNode focusedNode = e.Node;
                if (focusedNode != null)
                {
                    int itemName = (Int32)focusedNode.GetValue("ID");


                    switch (itemName)
                    {
                        case 1:
                            {

                                SetSelectedObject<CLASSES.Initialization.AppearanceFonts>();

                            }
                            break;
                        case 2:
                            {

                                SetSelectedObject<CLASSES.Initialization.AppearanceFonts>();

                            }
                            break;
                        case 3:
                            {
                                SetSelectedObject<CLASSES.Initialization.AppearanceTheme>();
                            }
                            break;
                        case 4:
                            {

                                SetSelectedObject<CLASSES.Initialization.ScreenDisplay>();
                            }
                            break;
                        case 5:
                            {
                                //SetSelectedObject<CLASSES.CLSETIN.MyPropertyClass>();                             

                            }
                            break;
                        case 6:
                            {
                                //SetSelectedObject<CLASSES.CLSETIN.Setting_Fonts>();

                            }
                            break;
                        case 7:
                            {
                                //SetSelectedObject<CLASSES.CLSETIN.Setting_Fonts>();
                            }
                            break;
                        case 8:
                            {
                                // SetSelectedObject<CLASSES.CLSETIN.Setting_Fonts>();
                            }
                            break;
                        case 9:
                            {
                                //SetSelectedObject<CLASSES.CLSETIN.Setting_Fonts>();
                            }
                            break;
                        case 10:
                            {
                                SetSelectedObject<CLASSES.Initialization.ServerSetting>();
                            }
                            break;
                        case 11:
                            {
                                SetSelectedObject<CLASSES.Initialization.ServerSetting>();
                            }
                            break;
                        case 12:
                            {
                                //SetSelectedObject<CLASSES.CLSETIN.Setting_Fonts>();
                            }
                            break;
                        case 17:
                            {
                                SetSelectedObject<CLASSES.Initialization.SystemInformation>();
                            }
                            break;
                        case 18:
                            {
                                SetSelectedObject<CLASSES.Initialization.SystemInformation>();
                            }
                            break;
                        case 23:
                            {
                                SetSelectedObject<CLASSES.Initialization.LanguageSettings>();
                            }
                            break;
                        case 24:
                            {
                                SetSelectedObject<CLASSES.Initialization.LanguageSettings>();
                            }
                            break;
                    }
                }
            }


        }





        private void propertyGridControl1_FocusedRowChanged(object sender, DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventArgs e)
        {
            //if (e.Row != null && e.Row.Tag is CLASSES.CLSETIN.MyPropertyClass selectedObject)
            //{
            //    // قم بتحديث Label1 لعرض وصف العنصر المحدد
            //    var descriptionAttribute = (DescriptionAttribute)TypeDescriptor.GetProperties(selectedObject)[e.Row.Properties.FieldName].Attributes[typeof(DescriptionAttribute)];
            //    string tec = descriptionAttribute.Description;
            //    MessageBox.Show(tec);
            //}
        }


        private void simpleButton_Ok_Click(object sender, EventArgs e)
        {


            // خاص بتهيئة اعدادات التهيئة موقف موقتا
            //Image image = CLASSES.Initialization.SystemInformation.image; 
            //byte[] imageBytes = CLASSES.Transfers.ImageToByteArray(image);

            Properties.Settings.Default.fontName = CLASSES.Initialization.AppearanceFonts.Name;
            Properties.Settings.Default.fontSize = CLASSES.Initialization.AppearanceFonts.Size;
            Properties.Settings.Default.fontBold = CLASSES.Initialization.AppearanceFonts.fontBold;
            Properties.Settings.Default.fontItalic = CLASSES.Initialization.AppearanceFonts.fontItalic;
            Properties.Settings.Default.fontUnderline = CLASSES.Initialization.AppearanceFonts.fontUnderline;
            Properties.Settings.Default.ThemName = CLASSES.Initialization.AppearanceTheme.ApperancThems;
            Properties.Settings.Default.ScreenDisplay = CLASSES.Initialization.ScreenDisplay.ShowDilge;
            Properties.Settings.Default.Server = CLASSES.Initialization.ServerSetting.serverName;
            Properties.Settings.Default.DataBase = CLASSES.Initialization.ServerSetting.databaseName;
            if (!CLASSES.Initialization.ServerSetting.isMod)
            {
                Properties.Settings.Default.Mode = "SQL";
                Properties.Settings.Default.Username = CLASSES.Initialization.ServerSetting.userName;
                Properties.Settings.Default.Password = CLASSES.Initialization.ServerSetting.password;
            }
            else
            {
                Properties.Settings.Default.Mode = "Mode";
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
            }

            if (CLASSES.Initialization.SystemInformation._imageBytes != null)
            {
                MessageBox.Show("Yess");
            }

            Properties.Settings.Default.Save();

            //CLASSES.DAL.DbInterfaceMediator.DatabaseManager con = new CLASSES.DAL.DbInterfaceMediator.DatabaseManager();
            //SqlParameter[] pr = new SqlParameter[4];
            //string sys_name = CLASSES.Initialization.SystemInformation.Name;
            //pr[0] = new SqlParameter("@sys_name", SqlDbType.NVarChar, 200);
            //pr[0].Value = sys_name;

            //byte[] sys_imag = CLASSES.Initialization.SystemInformation._imageBytes;
            //pr[1] = new SqlParameter("@sys_image", SqlDbType.Image);
            //pr[1].Value = sys_imag;

            //string sys_addresses = CLASSES.Initialization.SystemInformation.Address;
            //pr[2] = new SqlParameter("@sys_addresses", SqlDbType.NVarChar, 50);
            //pr[2].Value = sys_addresses;

            //int sys_phoneNumber = Convert.ToInt32(CLASSES.Initialization.SystemInformation.phoneNumber.ToString().Replace(",", string.Empty));
            //pr[3] = new SqlParameter("@sys_phoneNumber", SqlDbType.Int);
            //pr[3].Value = sys_phoneNumber;

            //con.ExecuteNonQuery("UPDATE_SYSTEM_INFORMATION", pr);



            // الحصول على جميع الفورمات في المشروع
            FormCollection forms = Application.OpenForms;

            // تحديث كل فورم
            foreach (Form form in forms)
            {
                if (form != null)
                {
                    if (form.Name == "For_Main")
                        CLASSES.FormFunction.FormsSetup.SetFonts(form);
                    else if (form.Name == "For_Options")
                        CLASSES.FormFunction.FormsSetup.SetFonts(form);
                }
            }

            Program.ThemStyle();
            //XtraMessageBox.Show(LookAndFeel.ActiveLookAndFeel, "لتطبيق التغيرات يرجاء اعادة تشغيل النظام","jhjhsds",MessageBoxButtons.OK,MessageBoxIcon.Warning);                        

            if (!Properties.Settings.Default.Language.Equals(lang))
            {
                Properties.Settings.Default.Language = CLASSES.Initialization.LanguageSettings.Languag;

                if (Properties.Settings.Default.Language.Equals("Arabic"))
                {
                    // تغيير لغة العرض إلى العربية
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("ar");

                    // تغيير لغة النظام إلى العربية
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
                }
                else
                {
                    // تغيير لغة العرض إلى العربية
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en");

                    // تغيير لغة النظام إلى العربية
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                }


                // إعادة تشغيل التطبيق لتحديث اللغة
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                Environment.Exit(0);
            }
            this.Close();

            ((For_Main)Application.OpenForms["For_Main"]).ClosTap();
        }

        private void simpleButton_Concel_Click(object sender, EventArgs e)
        {
            this.Close();
            ((For_Main)Application.OpenForms["For_Main"]).ClosTap();
        }


    }

}



