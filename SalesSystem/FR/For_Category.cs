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
    public partial class For_Category : DevExpress.XtraEditors.XtraForm
    {
        
        public DataTable T;
        FormFunction.CATEGORY categ = new FormFunction.CATEGORY();
        
        public CLASSES.Checkups.SetButtons setbuton = new CLASSES.Checkups.SetButtons();
        public CLASSES.Checkups.ReadOnley settext = new CLASSES.Checkups.ReadOnley();
        public For_Category()
        {
            InitializeComponent();
            T = new DataTable();
        }

      

        private void Category_Form_Load(object sender, EventArgs e)
        {
            categ.SELECT_ALL_CATEGORY(this);
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;
        }
  

        private void CategoryGridControl_Click(object sender, EventArgs e)
        {

        }

        private void New_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(false, categoryNameText, categoryDetailsText);
            setbuton.ToggleButtons(true, add_btn, back_btn);
            setbuton.ToggleButtons(false, new_btn);
            categoryGridControl.Enabled = false;
            BindingContext[T].AddNew();
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(true, categoryNameText, categoryDetailsText);
            setbuton.ToggleButtons(false, add_btn, back_btn,delete_btn,edit_btn);
            setbuton.ToggleButtons(true, new_btn);
            categoryGridControl.Enabled = true;
            BindingContext[T].CancelCurrentEdit();
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            categ.Insert(this);
        }

        private void CategoryGridControlvi_DoubleClick(object sender, EventArgs e)
        {
            setbuton.ToggleButtons(false, new_btn,add_btn);
            setbuton.ToggleButtons(true, delete_btn, edit_btn, back_btn);
            settext.readonley(false, categoryNameText, categoryDetailsText);
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            string name = categoryGridControlvi.GetRowCellValue(categoryGridControlvi.FocusedRowHandle, "اسم الصنف").ToString();
            
          if ( XtraMessageBox.Show(  "  هل تريد حذف الصنف "+name, "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)==DialogResult.Yes)
            {
                categ.Delete(this);
                categoryGridControl.Refresh();
                setbuton.ToggleButtons(false, delete_btn, edit_btn,back_btn);
                settext.readonley(true, categoryNameText, categoryDetailsText);
                setbuton.ToggleButtons(true, new_btn);
            }
          
        }

        private void Edit_btn_Click(object sender, EventArgs e)
        {
            categ.Update(this);           
        }
    }
}