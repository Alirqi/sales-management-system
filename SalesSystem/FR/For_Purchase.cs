using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using SalesSystem.CLASSES.Initialization;

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
    public partial class For_Purchase : DevExpress.XtraEditors.XtraForm
    {
        FormFunction.process pross = new FormFunction.process();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        List<InvosPurchaseProduct> products = new List<InvosPurchaseProduct>();
        BindingSource bind = new BindingSource();
        public For_Purchase()
        {
            InitializeComponent();
        }

        private void For_Purchase_Load(object sender, EventArgs e)
        {
            // products.Add(new InvosPurchaseProduct { ProductId = (int)productLookUpEdit.EditValue, Category = textEdit2.Text, ProductName = productLookUpEdit.Text, Unit = unitLookUpEdit.Text, Warehouse = storLookUpEdit.Text, Price = Convert.ToInt32(textEdit6.Text), Quantity = Convert.ToInt32(textEdit4.Text), Total = Convert.ToDecimal(textEdit7.Text) });
            bind.DataSource = products;
            prachesGridControl.DataSource = bind;
            //  prachesGridControl.DataSource = dt;

            //for (int i = 0; i < dt2.Rows.Count - 1; i++)
            //{
            //    DataRow r = dt.NewRow();
            //    r[0] = dt2.Rows[i][0].ToString();
            //    r[1] = dt2.Rows[i][1].ToString();
            //    r[2] = dt2.Rows[i][2].ToString();
            //    r[3] = dt2.Rows[i][3].ToString();

            //    dt.Rows.Add(r);
            ////}
            //  prachesGridControlvi.AddNewRow();
            // productLookUpEdit.DataSource = pross.GET_ALL_PROUDUCTS();
            //productLookUpEdit.PopulateColumns();
            //productLookUpEdit.Columns[1].Visible = false;
            //productLookUpEdit.Columns[2].Visible = false;
            //productLookUpEdit.Columns[1].Visible = false;
            //productLookUpEdit.Columns[4].Visible = false;
            productLookUpEdit.Properties.DataSource = pross.GET_ALL_PROUDUCTS();
            productLookUpEdit.Properties.DisplayMember = "pro_name";
            productLookUpEdit.Properties.ValueMember = "pro_id";

            storLookUpEdit.Properties.DataSource = pross.SELECT_ALL_STORES();
            storLookUpEdit.Properties.DisplayMember = "اسم المخزن";
            storLookUpEdit.Properties.ValueMember = "رقم المخزن";


            supplierNameText.Properties.DataSource = pross.SELECT_ALL_SUPPLIERS();
            supplierNameText.Properties.DisplayMember = "اسم المورد";
            supplierNameText.Properties.ValueMember = "رقم المورد";

            invoDateText.EditValue = DateTime.Now;

            InvoTypeText.Properties.DataSource = pross.GET_TYPE_INVOS();
            InvoTypeText.Properties.DisplayMember = "type_name";
            InvoTypeText.Properties.ValueMember = "type_id";
        }



        private void productLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            // BindingContext[dt].EndCurrentEdit();
            //string id =productLookUpEdit.pr;
            // MessageBox.Show();
            //  unitLookUpEdit.DataSource = pross.GET_PRODUCT_UNITS(1);
            // unitLookUpEdit.DisplayMember = "unit_name";
            //  unitLookUpEdit.ValueMember = "unit_id";
            //DataRow r = dt.NewRow();
            //r[0] = prachesGridControlvi.GetRowCellValue(prachesGridControlvi.FocusedRowHandle, "name").ToString();
            //r[1] = prachesGridControlvi.GetRowCellValue(prachesGridControlvi.FocusedRowHandle, "name").ToString();
            // prachesGridControlvi.SetRowCellValue(prachesGridControlvi.FocusedRowHandle, "id","dfdfdf");
            // dt.Rows.Add(r);

            LookUpEdit productLookUpEdit = sender as LookUpEdit;
            if (productLookUpEdit != null)
            {
                object selectedValue = productLookUpEdit.EditValue;
                // تعيين القيمة المحددة لـ LookUpEdit الثاني
                //productLookUpEdit.EditValue = selectedValue;

                // MessageBox.Show(productLookUpEdit.EditValue.ToString());
                // dt.Rows[0][1] = productLookUpEdit.EditValue;
                unitLookUpEdit.Properties.DataSource = pross.GET_PRODUCT_UNITS_IDNAME(Convert.ToInt32(productLookUpEdit.EditValue));
                unitLookUpEdit.Properties.DisplayMember = "unit_name";
                unitLookUpEdit.Properties.ValueMember = "unit_id";
            }
        }

        private void add_indgv_btn_Click(object sender, EventArgs e)
        {
            CLASSES.Checkups.ChickedEmpty chek = new CLASSES.Checkups.Checek_Rusalt();
            if (!chek.CheckControls("", productLookUpEdit, textEdit2, unitLookUpEdit, textEdit4, storLookUpEdit, textEdit6, textEdit7))
            {
                prachesGridControlvi.AddNewRow();
                prachesGridControlvi.SetRowCellValue(GridControl.NewItemRowHandle, "ProductId", (int)productLookUpEdit.EditValue);
                prachesGridControlvi.SetRowCellValue(GridControl.NewItemRowHandle, "ProductName", productLookUpEdit.Text);
                prachesGridControlvi.SetRowCellValue(GridControl.NewItemRowHandle, "Category", textEdit2.Text);
                prachesGridControlvi.SetRowCellValue(GridControl.NewItemRowHandle, "Unit", unitLookUpEdit.Text);
                prachesGridControlvi.SetRowCellValue(GridControl.NewItemRowHandle, "Quantity", Convert.ToInt32(textEdit6.Text));
                prachesGridControlvi.SetRowCellValue(GridControl.NewItemRowHandle, "Warehouse", storLookUpEdit.Text);
                prachesGridControlvi.SetRowCellValue(GridControl.NewItemRowHandle, "Price", Convert.ToInt32(textEdit4.Text));
                prachesGridControlvi.SetRowCellValue(GridControl.NewItemRowHandle, "Total", Convert.ToDecimal(textEdit7.Text));

                SalesSystem.CLASSES.Checkups.Clear.ClearText(textEdit2, textEdit6, textEdit4, textEdit7);
                SalesSystem.CLASSES.Checkups.Clear.ClearLockUp(productLookUpEdit, unitLookUpEdit, storLookUpEdit);
            }
        }
    }
}