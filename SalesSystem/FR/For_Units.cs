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
using System.Data;
using SalesSystem.FormFunction;

namespace SalesSystem.FR
{
    public partial class For_Units : DevExpress.XtraEditors.XtraForm
    {
        public DataTable T;
        process pross = new process();
        
        public CLASSES.Checkups.SetButtons setbuton = new CLASSES.Checkups.SetButtons();
        public CLASSES.Checkups.ReadOnley settext = new CLASSES.Checkups.ReadOnley();
        public For_Units()
        {
            InitializeComponent();
            T = new DataTable();
        }

        private void Units_form_Load(object sender, EventArgs e)
        {
            pross.SELECT_ALL_UNITS(this);
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();
        }

        private void New_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(false, unitNameText);
            setbuton.ToggleButtons(true, add_btn, back_btn);
            setbuton.ToggleButtons(false, new_btn);
            unitGridControl.Enabled = false;
            BindingContext[T].AddNew();
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(true, unitNameText);
            setbuton.ToggleButtons(false, add_btn, back_btn, delete_btn, edit_btn);
            setbuton.ToggleButtons(true, new_btn);
            unitGridControl.Enabled = true;
            BindingContext[T].CancelCurrentEdit();
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            pross.ADD_UNIT(this);
        }

        private void UnitGridControlvi_DoubleClick(object sender, EventArgs e)
        {
            setbuton.ToggleButtons(false, new_btn, add_btn);
            setbuton.ToggleButtons(true, delete_btn, edit_btn, back_btn);
            settext.readonley(false, unitNameText);
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            string name = unitGridControlvi.GetRowCellValue(unitGridControlvi.FocusedRowHandle, "اسم الوحدة").ToString();

            if (MessageBox.Show(this, "  هل تريد حذف الوحدة " + name, "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                pross.DELETE_UNIT(this);
                unitGridControl.Refresh();
                setbuton.ToggleButtons(false, delete_btn, edit_btn, back_btn);
                settext.readonley(true, unitNameText);
                setbuton.ToggleButtons(true, new_btn);
            }
        }

        private void Edit_btn_Click(object sender, EventArgs e)
        {
            pross.UPDATE_UNIT(this);
        }
    }
}