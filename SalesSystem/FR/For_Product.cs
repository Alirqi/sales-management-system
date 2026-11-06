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
using System.Data.SqlClient;

namespace SalesSystem.FR
{
    public partial class For_Product : DevExpress.XtraEditors.XtraForm
    {
        public DataTable T,ta,tt;
        FormFunction.process pross = new FormFunction.process();
        public CLASSES.Checkups.SetButtons setbuton = new CLASSES.Checkups.SetButtons();
        public CLASSES.Checkups.ReadOnley settext = new CLASSES.Checkups.ReadOnley();
       public int x = 0;
        public For_Product()
        {
            InitializeComponent();
            T = new DataTable();
            ta = new DataTable();
            

        }

        private void GridControl1_Click(object sender, EventArgs e)
        {

        }

        private void RadioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddUnitsBtn_Click(object sender, EventArgs e)
        {
           
           
          
         
            //unitsGridControl.Refresh();

        }

        private void Product_Form_Load(object sender, EventArgs e)
        {
            pross.SELECT_ALL_PRODUCTS(this);
            pross.SELECT_ALL_CATEGORY(this);
            pross.SELECT_ALL_PRODUCT_UNITS(this);
            productUnitsText.Properties.DataSource= pross.con.GetData("SELECT_ALL_UNITS");
            productUnitsText.Properties.PopulateColumns();
         
            productUnitsText.Properties.DisplayMember = "اسم الوحدة";
            productUnitsText.Properties.ValueMember = "رقم الوحدة";
            productUnitsText.Properties.ShowHeader = false;
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();

        }

        private void New_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(false, productCodText,categoryNameText, categoryNameText, productNameText,productUnitNumber );
            setbuton.ToggleButtons(true, add_btn, back_btn,getImageBtn);
            setbuton.ToggleButtons(false, new_btn);
            productsGridControl.Enabled = false;
            this.BindingContext[this.T].AddNew();
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            this.BindingContext[this.T].CancelCurrentEdit();
            settext.readonley(true, productCodText, categoryNameText, productNameText, productUnitNumber);
            setbuton.ToggleButtons(false, add_btn, back_btn, getImageBtn,delete_btn,edit_btn);
            setbuton.ToggleButtons(true, new_btn);
          
            productsGridControl.Enabled = true;

        }

        private void GetImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            
            if(d.ShowDialog().Equals(DialogResult.OK))
            {
                productPictureEdit.Image = Image.FromFile(d.FileName);
            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            pross.ADD_PRODUCT(this);
            //((product_Form)Application.OpenForms["product_Form"]);
            productNameTextSr.Refresh();
        }

        private void UnitsTab_Shown(object sender, EventArgs e)
        {            
            bindingSource1.DataSource = pross.con.GetData("SELECT_ALL_PRODUCTS");
            productNameText1.Properties.DataSource=productNameTextSr.Properties.DataSource = bindingSource1;
            productNameText1.Properties.PopulateColumns();
            productNameTextSr.Properties.PopulateColumns();
            productNameText1.Properties.ShowHeader= productNameTextSr.Properties.ShowHeader = false;
            productNameText1.Properties.DisplayMember= productNameTextSr.Properties.DisplayMember = "اسم المنتج";
            productNameText1.Properties.ValueMember= productNameTextSr.Properties.ValueMember = "رقم المنتج";

        }

        private void ProductNameText1_BeforePopup(object sender, EventArgs e)
        {
            productNameTextSr.Properties.Columns[0].Visible = false;
            productNameTextSr.Properties.Columns[1].Visible = false;
            productNameTextSr.Properties.Columns[2].Visible = false;
            productNameTextSr.Properties.Columns[4].Visible = false;
        }

        private void CategoryNameText_BeforePopup(object sender, EventArgs e)
        {
            categoryNameText.Properties.Columns["رقم الصنف"].Visible = false;
            categoryNameText.Properties.Columns["تفاصيل الصنف"].Visible = false;
        }

        private void ProductsGridControl_DoubleClick(object sender, EventArgs e)
        {
            settext.readonley(false, productCodText, categoryNameText, productNameText, productUnitNumber);
            setbuton.ToggleButtons(false, add_btn,  new_btn);
            setbuton.ToggleButtons(true, back_btn, getImageBtn,delete_btn,edit_btn);
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            string name = productsGridControlvi.GetRowCellValue(productsGridControlvi.FocusedRowHandle, "اسم المنتج").ToString();

            if (XtraMessageBox.Show("  هل تريد حذف المنتج " + name, "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                pross.DELETE_PRODUCT(this);
                settext.readonley(true, productCodText, categoryNameText, productNameText, productUnitNumber);
                setbuton.ToggleButtons(true, new_btn);
                setbuton.ToggleButtons(false, back_btn, getImageBtn, delete_btn, edit_btn);
            }
          
        }

        private void Edit_btn_Click(object sender, EventArgs e)
        {
            pross.UPDATE_PRODUCT(this);
            settext.readonley(true, productCodText, categoryNameText, productNameText, productUnitNumber);
            setbuton.ToggleButtons(true, new_btn);
            setbuton.ToggleButtons(false, back_btn, getImageBtn, delete_btn, edit_btn);
        }

        private void New_btn1_Click(object sender, EventArgs e)
        {
            setbuton.ToggleButtons(true, back_btn1, add_btn1);
            setbuton.ToggleButtons(false, new_btn1);
            settext.readonley(false,  productUnitsText, productUnitNumber,productNameTextSr);
            BindingContext[ta].AddNew();
            ProductUnitsGridControl.Enabled = false;
            productNameText1.EditValue = productNameTextSr.EditValue;
        }

        private void Back_btn1_Click(object sender, EventArgs e)
        {
            BindingContext[ta].CancelCurrentEdit();
            productNameTextSr.ResetText();
            setbuton.ToggleButtons(false, back_btn1, add_btn1,edit_btn1,delete_btn1);
            settext.readonley(true, productNameTextSr,productUnitsText, productUnitNumber);
            setbuton.ToggleButtons(true, new_btn1);
           
            ProductUnitsGridControl.Enabled = true;
        }

        private void ProductNameTextSr_EditValueChanged(object sender, EventArgs e)
        {
            productNameText1.EditValue = productNameTextSr.EditValue;
        }

        private void Delete_btn1_Click(object sender, EventArgs e)
        {
            string pro = productNameText1.Text;
            string unit = productUnitsText.Text;

             if (XtraMessageBox.Show(" هل تريد حذف الوحدة "+ unit + " التابعة للمنتج "+pro+"", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals(DialogResult.Yes))
            {
                pross.DELETE_PRODUCT_UNIT(this);
            }
               
        }

        private void ProductUnitsGridControl_DoubleClick(object sender, EventArgs e)
        {
            settext.readonley(false, productUnitsText, productUnitNumber);
            setbuton.ToggleButtons(true, edit_btn1, delete_btn1,back_btn1);
            setbuton.ToggleButtons(false, new_btn1);
        }

        private void Edit_btn1_Click(object sender, EventArgs e)
        {
            pross.UPDATE_PRODUCT_UNIT(this);
        }

        private void productUnitsText_BeforePopup(object sender, EventArgs e)
        {
             productUnitsText.Properties.Columns[0].Visible = false;
        }

        private void Add_btn1_Click(object sender, EventArgs e)
        {
            pross.ADD_UNIT_TO_PRODUCT(this);
           
        }

        private void ProductNameText1_EditValueChanged(object sender, EventArgs e)
        {

        //    SqlParameter[] p = new SqlParameter[1];
        //    p[0] = new SqlParameter("@pro_id", SqlDbType.Int);
        //    p[0].Value = productNameText1.EditValue;
        //    ta = pross.con.GetData("SELECT_PRODUCT_UNITS", p);
        //    ProductUnitsGridControl.DataSource = ta;
            //ProductUnitsGridControlvi.OptionsFind.FindFilterColumns = "رقم المنتج";
            //ProductUnitsGridControlvi.FindFilterText = productNameText1.EditValue.ToString();
        }
    }
}