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
using SalesSystem.FormFunction;


namespace SalesSystem.FR
{
    public partial class For_Customers : DevExpress.XtraEditors.XtraForm
    {
        public DataTable T, ta, tt;
        process pross = new process();
        public CLASSES.Checkups.SetButtons setbuton = new CLASSES.Checkups.SetButtons();
        public CLASSES.Checkups.ReadOnley settext = new CLASSES.Checkups.ReadOnley();

     

        public For_Customers()
        {
            InitializeComponent();
            ta = new DataTable();
        }

        private void Customers_Form_Load(object sender, EventArgs e)
        {
            
            pross.SELECT_ALL_CUSTOMERS(this);
            pross.SELECT_ALL_CUSTOMERS_PHONS(this);
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();
        }

        

        private void New_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(false, customerNameText, customerAdressText, customerStorAdressText, customerGmailText);
            setbuton.ToggleButtons(true, add_btn, back_btn, getImageBtn);
            BindingContext[T].AddNew();
            customersGridControl.Enabled = false;
        }

       
        private void Back_btn_Click(object sender, EventArgs e)
        {
            settext.readonley(true, customerNameText, customerAdressText, customerStorAdressText, customerGmailText);
            setbuton.ToggleButtons(false, add_btn, back_btn, getImageBtn,edit_btn,delete_btn);
            setbuton.ToggleButtons(true, new_btn);
            BindingContext[T].CancelCurrentEdit();
            customersGridControl.Enabled = true;
        }

        private void GetImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog p = new OpenFileDialog();
            if(p.ShowDialog().Equals(DialogResult.OK))
            {
                customerPictureEdit.Image = Image.FromFile(p.FileName);
            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            pross.ADD_CUSTOMER(this);
        }
 
        private void CustomersGridControl_DoubleClick(object sender, EventArgs e)
        {
           
                settext.readonley(false, customerNameText, customerAdressText, customerStorAdressText, customerGmailText);
                setbuton.ToggleButtons(true, delete_btn, back_btn, edit_btn, getImageBtn);
                setbuton.ToggleButtons(false, add_btn, new_btn);
            
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            var name = customersGridControlvi.GetRowCellValue(customersGridControlvi.FocusedRowHandle, "اسم العميل");
            if (XtraMessageBox.Show("هل تريد حذف العميل " + name + "  ", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2).Equals(DialogResult.Yes))
            {
                pross.DELETE_CUSTOMER(this);
                BindingContext[T].RemoveAt(BindingContext[T].Position);
                settext.readonley(true, customerNameText, customerAdressText, customerStorAdressText, customerGmailText);
                setbuton.ToggleButtons(false, add_btn, back_btn, getImageBtn, edit_btn, delete_btn);
                setbuton.ToggleButtons(true, new_btn);
            }
        }

        private void Edit_btn_Click(object sender, EventArgs e)
        {
            pross.UPDATE_CUSTOMER(this);
        }

        private void Phone_Tab_Shown(object sender, EventArgs e)
        {
            customerNameText1.Properties.DataSource = customerNameTextSr.Properties.DataSource = pross.con.GetData("SELECT_ALL_CUSTOMERS");
            customerNameTextSr.Properties.PopulateColumns();
            customerNameText1.Properties.PopulateColumns();
            customerNameText1.Properties.DisplayMember = customerNameTextSr.Properties.DisplayMember = "اسم العميل";
            customerNameText1.Properties.ValueMember = customerNameTextSr.Properties.ValueMember = "رقم العميل";
            customerNameText1.Properties.ShowHeader = customerNameTextSr.Properties.ShowHeader = false;

        }

        private void CustomerNameTextSr_BeforePopup(object sender, EventArgs e)
        {
            customerNameTextSr.Properties.Columns[0].Visible = false;
            customerNameTextSr.Properties.Columns[2].Visible = false;
            customerNameTextSr.Properties.Columns[3].Visible = false;
            customerNameTextSr.Properties.Columns[4].Visible = false;
            customerNameTextSr.Properties.Columns[5].Visible = false;
        }

        private void CustomerNameTextSr_EditValueChanged(object sender, EventArgs e)
        {
            customerNameText1.EditValue = customerNameTextSr.EditValue;
        }

        private void New_btn1_Click(object sender, EventArgs e)
        {
            setbuton.ToggleButtons(true, add_btn1, back_btn1);
            setbuton.ToggleButtons(false, new_btn1);
            settext.readonley(false, customerNameTextSr, customerPhoneText, customerPhoneNoteText);
            customersPhoneGridControl.Enabled = false;
            BindingContext[ta].AddNew();
            customerNameText1.EditValue = customerNameTextSr.EditValue;

        }

        private void Back_btn1_Click(object sender, EventArgs e)
        {
            setbuton.ToggleButtons(false, add_btn1, back_btn1,delete_btn1,edit_btn1);
            setbuton.ToggleButtons(true, new_btn1);
            settext.readonley(true, customerNameTextSr, customerPhoneText, customerPhoneNoteText);
            BindingContext[ta].CancelCurrentEdit();
            customersPhoneGridControl.Enabled = true;
        }

        private void Add_btn1_Click(object sender, EventArgs e)
        {
            pross.ADD_PHONE_TO_CUSTOMER(this);
        }

        private void CustomersPhoneGridControl_DoubleClick(object sender, EventArgs e)
        {
            setbuton.ToggleButtons(true, delete_btn1, edit_btn1,back_btn1);
            setbuton.ToggleButtons(false, new_btn1);
            settext.readonley(false, customerNameTextSr, customerPhoneText, customerPhoneNoteText);
        }

        private void Delete_btn1_Click(object sender, EventArgs e)
        {
            string no = customerPhoneText.EditValue.ToString();
            string name = customerNameText1.Text;
            if(XtraMessageBox.Show("هل تريد حذف رقم الهاتف "+no+" التابع للعميل "+name+"  ", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2).Equals(DialogResult.Yes))
            {
                pross.DELETE_CUSTOMER_PHONE(this);
                setbuton.ToggleButtons(false,  edit_btn1,delete_btn1, back_btn1);
                setbuton.ToggleButtons(true, new_btn1);
                settext.readonley(true, customerNameTextSr, customerPhoneText, customerPhoneNoteText);

            }
        }

        private void Edit_btn1_Click(object sender, EventArgs e)
        {
            pross.UPDATE_CUSTOMER_PHONE(this);
        }


    }

}
