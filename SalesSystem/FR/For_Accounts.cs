using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Data;

namespace SalesSystem.FR
{
    public partial class For_Accounts : DevExpress.XtraEditors.XtraForm
    {
        FormFunction.ACCOUNTING acc = new FormFunction.ACCOUNTING();

        public CLASSES.Checkups.SetButtons setbuton = new CLASSES.Checkups.SetButtons();
        public CLASSES.Checkups.ReadOnley settext = new CLASSES.Checkups.ReadOnley();
        public For_Accounts()
        {
            InitializeComponent();
        }

        private void For_Accounts_Load(object sender, EventArgs e)
        {
            acc.SELECT_ALL_ACCOUNTING(this);
            acc.GET_ACCOUNTING_TYPE(this);

            layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem12.TextVisible = false;
            layoutControlItem13.TextVisible = false;
            accountMaxText.Visible = false;
            accountMinText.Visible = false;

            layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;           
            layoutControlItem5.TextVisible = false;
            layoutControlItem4.TextVisible = false;
            layoutControlItem3.TextVisible = false;
            accountCreditorText.Visible = false;
            accountDebitsText.Visible = false;
            accountBalanceText.Visible = false;
            


          //  accountsGridControlvi.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
           // accountsGridControlvi.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            //accountsGridControlvi.OptionsSelection.CheckBoxSelectorField = "رقم الحساب";
             CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            acc.Insert(this);
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(false, accountNumberText, accountType, accountNameText, accountDebitsText, accountCreditorText, accountBalanceText, accountMaxText, accountMinText);
            setbuton.ToggleButtons(true, add_btn, back_btn);
            setbuton.ToggleButtons(false, new_btn);
            accountsGridControl.Enabled = false;
            BindingContext[AccountbindingSource].AddNew();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(true, accountNumberText, accountType, accountNameText, accountDebitsText, accountCreditorText, accountBalanceText, accountMaxText, accountMinText);
            setbuton.ToggleButtons(false, add_btn, back_btn, edit_btn);
            setbuton.ToggleButtons(true, new_btn);
            accountsGridControl.Enabled = true;
            BindingContext[AccountbindingSource].CancelCurrentEdit();
        }

        private void accountsGridControl_DoubleClick(object sender, EventArgs e)
        {
            settext.readonley(false,accountType, accountNameText, accountDebitsText, accountCreditorText, accountBalanceText, accountMaxText, accountMinText);
            setbuton.ToggleButtons(true, edit_btn, back_btn);
            setbuton.ToggleButtons(false, new_btn);
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            acc.Update(this);
        }

        private void accountType_EditValueChanged(object sender, EventArgs e)
        {

            if (accountType.EditValue == null || string.IsNullOrEmpty(accountType.EditValue.ToString()))
            {
                return;
            }
            else
            {
                if (Convert.ToInt32(accountType.EditValue.ToString()) == 0)
                {
                    layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem12.TextVisible = false;
                    layoutControlItem13.TextVisible = false;
                    accountMaxText.Visible = false;
                    accountMinText.Visible = false;
                }
                else
                {
                    layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem12.TextVisible = true;
                    layoutControlItem13.TextVisible = true;
                    accountMaxText.Visible = true;
                    accountMinText.Visible = true;
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            acc.Delete(this);
        }
    }
}