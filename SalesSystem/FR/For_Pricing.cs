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
    public partial class For_Pricing : DevExpress.XtraEditors.XtraForm
    {
        public CLASSES.Checkups.ReadOnley settext = new CLASSES.Checkups.ReadOnley();
        public CLASSES.Checkups.SetButtons setbuton = new CLASSES.Checkups.SetButtons();
        FormFunction.process pross = new FormFunction.process();
        public For_Pricing()
        {
            InitializeComponent();
          
        }

        private void New_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(false, productSearchText);
            setbuton.ToggleButtons(true, back_btn, save_btn);
            setbuton.ToggleButtons(false, new_btn);
            productNonPriceCheck.Enabled = true;
           
        }

        private void For_Pricing_Load(object sender, EventArgs e)
        {
            pross.SELECT_PRODCTS_HAVE_UNITS(this);
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();
        }

        private void ProductSearchText_EditValueChanged(object sender, EventArgs e)
        {
            pross.GET_PRODUCT_UNITS(this);
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(true, productSearchText);
            productPriceGridControlvi.SelectRows(0,productPriceGridControlvi.RowCount-1);
            productPriceGridControlvi.DeleteSelectedRows();
            setbuton.ToggleButtons(false, back_btn, save_btn);
            setbuton.ToggleButtons(true, new_btn);
            productNonPriceCheck.Enabled = false;
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            pross.ADD_PRICE_TO_PRODUCT(this);
        }

        private void ProductNonPriceCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(productNonPriceCheck.Checked==true)
            {
                pross.SELECT_PRODCTS_HAVE_UNITS_NON_PRICE(this);
            }
            else
            {
                pross.SELECT_PRODCTS_HAVE_UNITS(this);
            }
        }
    }
}