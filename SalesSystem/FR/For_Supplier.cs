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

namespace SalesSystem.FR
{
    public partial class For_Supplier : DevExpress.XtraEditors.XtraForm
    {
        public DataTable T;
        FormFunction.process pross = new FormFunction.process();
        public CLASSES.Checkups.SetButtons setbuton = new CLASSES.Checkups.SetButtons();
        public CLASSES.Checkups.ReadOnley settext = new CLASSES.Checkups.ReadOnley();
        public For_Supplier()
        {
            InitializeComponent();
            
        }
        private void Suppliers_Form_Load(object sender, EventArgs e)
        {
            pross.SELECT_ALL_SUPPLIERS(this);
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();
        }
        private void New_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(false, supplierNameText, supplierPhoneText, supplierEmailText,supplierAddressText);
            setbuton.ToggleButtons(true, back_btn, add_btn);
            setbuton.ToggleButtons(false, new_btn);
            BindingContext[T].AddNew();
            supplierNameText.Focus();
            supplierGridControl.Enabled = false;
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(true, supplierNameText, supplierPhoneText, supplierEmailText, supplierAddressText);
            setbuton.ToggleButtons(false, back_btn, add_btn,edit_btn,delete_btn);
            setbuton.ToggleButtons(true, new_btn);
            BindingContext[T].CancelCurrentEdit();
            supplierGridControl.Enabled = true;
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            pross.ADD_SUPPLIER(this);
        }

        private void SupplierGridControl_DoubleClick(object sender, EventArgs e)
        {
            settext.readonley(false, supplierNameText, supplierPhoneText, supplierEmailText, supplierAddressText);
            setbuton.ToggleButtons(true, edit_btn, delete_btn, back_btn);
            setbuton.ToggleButtons(false,new_btn);
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            string name = supplierGridControlvi.GetRowCellValue(supplierGridControlvi.FocusedRowHandle, "اسم المورد").ToString();
            if(CLASSES.SysNotification.Notification.MessageBoxQuestion("هل تريد حذف المورد "+name+"").Equals(DialogResult.Yes))
            {
                pross.DELETE_SUPPLIER(this);
            }
        }

        private void Edit_btn_Click(object sender, EventArgs e)
        {
            pross.UPDATE_SUPPLIER(this);
        }
    }
}