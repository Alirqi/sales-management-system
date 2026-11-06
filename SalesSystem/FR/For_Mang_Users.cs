using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesSystem.FR
{
    public partial class For_Mang_Users : DevExpress.XtraEditors.XtraForm
    {
        FormFunction.USERES us = new FormFunction.USERES();
        public CLASSES.Checkups.SetButtons setbuton = new CLASSES.Checkups.SetButtons();
        public CLASSES.Checkups.ReadOnley settext = new CLASSES.Checkups.ReadOnley();

        public For_Mang_Users()
        {
            InitializeComponent();
        }

        private void For_Mang_Users_Load(object sender, EventArgs e)
        {
            us.SELECT_ALL_USERS(this);
            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem3.TextVisible = false;
            layoutControlItem4.TextVisible = false;
            userPasswordNewText.Visible = false;
            userPasswordOledText.Visible = false;            

            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {            
            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem3.TextVisible = true;
            layoutControlItem4.TextVisible = true;
            userPasswordNewText.Visible = true;
            userPasswordOledText.Visible = true;

            settext.readonley(false, userIdText, userNameText, userPasswordNewText, userPasswordOledText);
            setbuton.ToggleButtons(true, add_btn, back_btn);
            setbuton.ToggleButtons(false, new_btn);
            userGridControl.Enabled = false;
            BindingContext[UserBindingSource].AddNew();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem3.TextVisible = false;
            layoutControlItem4.TextVisible = false;
            userPasswordNewText.Visible = false;
            userPasswordOledText.Visible = false;

            settext.readonley(true, userIdText, userNameText, userPasswordNewText, userPasswordOledText);
            setbuton.ToggleButtons(false, add_btn, back_btn, edit_btn);
            setbuton.ToggleButtons(true, new_btn);
            userGridControl.Enabled = true;
            BindingContext[UserBindingSource].CancelCurrentEdit();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            us.Insert(this);
        }

        private void CheckEdit2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}