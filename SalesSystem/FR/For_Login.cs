using System;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Drawing;

namespace SalesSystem.FR
{
    public partial class For_Login : DevExpress.XtraEditors.XtraForm
    {
        CLASSES.Checkups.ChickedEmpty chek =new CLASSES.Checkups.Checek_Rusalt();
        For_Main fm=new For_Main();
       


        public For_Login()
        {
            SplashScreenManager.ShowForm(this, typeof(For_SplashScreen));
            Thread thred = new Thread(DownloadFiles);
            thred.Start();            

            InitializeComponent();           
        }

        private void For_Login_Load(object sender, EventArgs e)
        {
            
            // بدء عملية التحميل الرئيسية في الخلفية

            SalesSystem.CLASSES.Setting.SetFonts.SetFont(this.simpleButton_Close, this.simpleButton_login, this.textEdit_UserName, this.textEdit_Password, this.layoutControlItem2, this.layoutControlItem3);
           

           CLASSES.DAL.DbInterfaceMediator.DatabaseManager con = new CLASSES.DAL.DbInterfaceMediator.DatabaseManager();
            DataTable dt = new DataTable();

            dt= con.GetData("SELECT_SYSTEM_INFORMATION");
            picEditLogin.Image=CLASSES.Transfers.ByteArrayToImage((byte[])dt.Rows[0][2]);          

            labelControl1.Text = dt.Rows[0][1].ToString();
            labelControl3.Text = dt.Rows[0][3].ToString();
            labelControl5.Text = dt.Rows[0][4].ToString();

            //Thread thread = new Thread(() =>
            //{
            //    // قم بتعيين قيم المتغيرات هنا
            //    int variable1 = 10;
            //    string variable2 = "Hello";


            //    // استدعاء الدالة وتمرير المتغيرات إليها
            //    DownloadFiles(variable1, variable2);
            //});

            //thread.Start();           

        }
        private void DownloadFiles()
        {            
            // محاكاة عملية التحميل
            Thread.Sleep(1000);
            for (int i = 0; i <10000; i++)
            {
                // تحديث شريط التقدم على شاشة التحميل
                int progress = (i + 1) * 100 / 10000;                                
            }
            // اكتمال عملية التحميل
            // إغلاق شاشة التحميل
            SplashScreenManager.CloseForm();
        }
      

        private void simpleButton_login_Click(object sender, EventArgs e)
        {  
                        
            if (!chek.CheckControls("",textEdit_UserName, textEdit_Password))
            {                
                this.Hide();
                CLASSES.FormFunction.FormsSetup fh = new CLASSES.FormFunction.FormsSetup();
                fh.HandleForm(fm);               
            }
            else
            {
                return;
            }
        }

        private void textEdit_Password_Enter(object sender, EventArgs e)
        {
            textEdit_Password.Properties.PasswordChar = '*';
            
        }

        private void simpleButtonIconPass_Click(object sender, EventArgs e)
        {
            if (textEdit_Password.Properties.PasswordChar =='*' )
            {               
                textEdit_Password.Properties.PasswordChar = default;                             
            }
            else
            {                
                textEdit_Password.Properties.PasswordChar = '*';             
            }

        }

        private void simpleButton_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
   
    }
  
    
}
