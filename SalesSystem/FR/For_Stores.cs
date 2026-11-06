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
    public partial class For_Stores : DevExpress.XtraEditors.XtraForm
    {
        public DataTable T;
        FormFunction.process pross = new FormFunction.process();
        public CLASSES.Checkups.SetButtons setbuton = new CLASSES.Checkups.SetButtons();
        public CLASSES.Checkups.ReadOnley settext = new CLASSES.Checkups.ReadOnley();
        public For_Stores()
        {
            InitializeComponent();
        }

        private void Stores_Form_Load(object sender, EventArgs e)
        {
            pross.SELECT_ALL_STORES(this);
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();
        }

        private void New_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(false, storeNameText, storAdressText, storePhoneText);
            setbuton.ToggleButtons(true, back_btn, add_btn);
            setbuton.ToggleButtons(false, new_btn);
            BindingContext[T].AddNew();
            storGridControl.Enabled = false;
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(true, storeNameText, storAdressText, storePhoneText);
            setbuton.ToggleButtons(false, back_btn, add_btn,edit_btn,delete_btn);
            setbuton.ToggleButtons(true, new_btn);
            BindingContext[T].CancelCurrentEdit();
            storGridControl.Enabled = true;
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            pross.ADD_STOR(this);
        }

        private void StorGridControl_DoubleClick(object sender, EventArgs e)
        {
            settext.readonley(false, storeNameText, storAdressText, storePhoneText);
            setbuton.ToggleButtons(true,back_btn, edit_btn, delete_btn);
            setbuton.ToggleButtons(false, new_btn);
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            string name = storGridControlvi.GetRowCellValue(storGridControlvi.FocusedRowHandle, "اسم المخزن").ToString();
            if(XtraMessageBox.Show(" هل تريد حذف المخزن "+name+"", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals(DialogResult.Yes))
            {
                pross.DELETE_STOR(this);
            }
        }

        private void Edit_btn_Click(object sender, EventArgs e)
        {
            pross.UPDATE_STOR(this);
        }
    }
}