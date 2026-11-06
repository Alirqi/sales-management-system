using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalesSystem.FR
{
    public partial class For_SplashScreen : SplashScreen
    {
        public For_SplashScreen()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © 1998-" + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
            Close, // إغلاق شاشة التحميل
            UpdateText, // تحديث النص المعروض على شاشة التحميل
            UpdateProgress // تحديث شريط التقدم على شاشة التحميل
        }

        public void UpdateProgress(int progress)
        {
            // تحديث شريط التقدم بناءً على القيمة المحددة
            progressBarControl.EditValue = progress;
            
        }      

    }
}
