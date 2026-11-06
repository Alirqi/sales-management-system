using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using SalesSystem.FR;
using DevExpress.Utils;
using System.Drawing;
using DevExpress.LookAndFeel;
using SalesSystem.CLASSES.SysNotification;


namespace SalesSystem.FormFunction
{

    interface AllProces
    {
        void Delete(Form f);
        void Update(Form f);
        void Insert(Form f);
    }

    class CATEGORY : AllProces
    {
        public CLASSES.DAL.DbInterfaceMediator.DatabaseManager con = new CLASSES.DAL.DbInterfaceMediator.DatabaseManager();
        public SqlParameter[] pr;
        public CLASSES.Checkups.ChickedEmpty check = new CLASSES.Checkups.Checek_Rusalt();

        public void Insert(Form fm)
        {
            For_Category f = fm as For_Category;
            int x = 1;

            for (int i = 0; i < f.categoryGridControlvi.RowCount; i++)
            {
                if (f.categoryNameText.Text.Trim().Equals(f.categoryGridControlvi.GetRowCellValue(i, "اسم الصنف")))
                {
                    x = 0;
                    break;
                }
            }
            if (check.CheckControls("ادخل اسم الصنف", f.categoryNameText))
            {
                return;
            }

            else if (x == 0)
            {
                Notification.MessageBoxError("يوجد صنف بهذا الاسم ");
            }
            else
            {
                pr = new SqlParameter[2];
                string cat_name = f.categoryNameText.Text.Trim();
                string cat_detailes = f.categoryDetailsText.Text.Trim();
                pr[0] = new SqlParameter("@cat_name", SqlDbType.NVarChar, 50);
                pr[0].Value = cat_name;
                pr[1] = new SqlParameter("@cat_details", SqlDbType.NVarChar);
                pr[1].Value = cat_detailes;
                con.ExecuteNonQuery("ADD_CATEGORY", pr);
                f.BindingContext[f.T].EndCurrentEdit();
                Notification.MessageBoxInformation("تم الاظافة بنجاح");
                f.settext.readonley(true, f.categoryNameText, f.categoryDetailsText);
                f.setbuton.ToggleButtons(false, f.back_btn, f.add_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
                f.categoryGridControl.Enabled = true;
            }

        }
        public void Update(Form fm)
        {
            For_Category f = fm as For_Category;
            int x = 1;

            for (int i = 0; i < f.categoryGridControlvi.RowCount; i++)
            {
                if (f.categoryGridControlvi.GetRowCellValue(f.categoryGridControlvi.FocusedRowHandle, "رقم الصنف").ToString().Trim() == f.categoryGridControlvi.GetRowCellValue(i, "رقم الصنف").ToString().Trim())
                {
                    continue;
                }
                else
                {

                    if (f.categoryNameText.Text.Trim().Equals(f.categoryGridControlvi.GetRowCellValue(i, "اسم الصنف")))
                    {
                        x = 0;
                        break;
                    }
                }
            }
            if (check.CheckControls("ادخل اسم الصنف ", f.categoryNameText))
            {
                return;
            }
            else if (x == 0)
            {
                Notification.MessageBoxError("يوجد صنف بهذا الاسم ");
            }
            else
            {
                pr = new SqlParameter[3];
                pr[0] = new SqlParameter("@cat_id", SqlDbType.Int);
                pr[0].Value = f.categoryGridControlvi.GetRowCellValue(f.categoryGridControlvi.FocusedRowHandle, "رقم الصنف");
                pr[1] = new SqlParameter("@cat_name", SqlDbType.NVarChar);
                pr[1].Value = f.categoryNameText.Text.Trim();
                pr[2] = new SqlParameter("@cat_detailes", SqlDbType.NVarChar);
                pr[2].Value = f.categoryDetailsText.Text.Trim();
                con.ExecuteNonQuery("UPDATE_CATEGORY", pr);
                f.BindingContext[f.T].EndCurrentEdit();
                Notification.MessageBoxInformation("تم التعديل بنجاح ");
                f.settext.readonley(true, f.categoryNameText, f.categoryDetailsText);
                f.setbuton.ToggleButtons(false, f.delete_btn, f.edit_btn, f.back_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
            }

        }
        public void Delete(Form fm)
        {
            For_Category f = fm as For_Category;
            pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@cat_id", SqlDbType.Int);
            pr[0].Value = f.categoryGridControlvi.GetRowCellValue(f.categoryGridControlvi.FocusedRowHandle, "رقم الصنف");
            con.ExecuteNonQuery("DELETE_CATEGORY", pr);
            f.BindingContext[f.T].RemoveAt(f.BindingContext[f.T].Position);
            Notification.MessageBoxInformation("تم الحذف بنجاح");
        }

        public void SELECT_ALL_CATEGORY(For_Category f)
        {
            f.T = con.GetData("selectAllCategories");
            f.categoryBindingSource.DataSource = f.T;
            f.categoryGridControl.DataSource = f.T;
            f.categoryNameText.DataBindings.Add("Text", f.T, "اسم الصنف");
            f.categoryDetailsText.DataBindings.Add("Text", f.T, "تفاصيل الصنف");
        }

    }


    public class ACCOUNTING : AllProces
    {
        public CLASSES.DAL.DbInterfaceMediator.DatabaseManager con = new CLASSES.DAL.DbInterfaceMediator.DatabaseManager();
        public SqlParameter[] pr;

        CLASSES.Checkups.ChickedEmpty check = new CLASSES.Checkups.Checek_Rusalt();
        public void Insert(Form fm)
        {
           
            For_Accounts f = fm as For_Accounts;
            int x = 1;

            for (int i = 0; i < f.accountsGridControlvi.RowCount-1; i++)
            {
                if (f.accountNumberText.Text.Trim().Equals(f.accountsGridControlvi.GetRowCellValue(i, "رقم الحساب").ToString()))
                {
                    x = 0;
                    break;
                }
            }
            if (check.CheckControls("", f.accountNumberText,f.accountNameText,f.accountType))
            {
                return;
            }

            else if (x == 0)
            {
                Notification.MessageBoxError("هاذا الحساب موجود سابقا ");
                return;
            }
            else
            {
                pr = new SqlParameter[5];
                int acc_num = Convert.ToInt32(f.accountNumberText.Text.Trim());
                int acc_type = Convert.ToInt32(f.accountType.EditValue);
                string acc_name = f.accountNameText.Text.Trim();
                //decimal acc_Creditor = Convert.ToDecimal(f.accountCreditorText.Text.Trim());
                //decimal acc_Debit = Convert.ToDecimal(f.accountDebitsText.Text.Trim());
                //decimal acc_Balance = Convert.ToDecimal(f.accountBalanceText.Text.Trim());
                decimal? acc_Max;
                decimal? acc_min;
                if (string.IsNullOrEmpty(f.accountMaxText.Text.Trim())|| string.IsNullOrEmpty(f.accountMinText.Text.Trim()))
                {
                     acc_Max = null;
                     acc_min = null;
                }
                else
                {
                     acc_Max = Convert.ToDecimal(f.accountMaxText.Text.Trim());
                     acc_min = Convert.ToDecimal(f.accountMinText.Text.Trim());
                }
                

                pr[0] = new SqlParameter("@acc_num", SqlDbType.Int);
                pr[0].Value = acc_num;

                pr[1] = new SqlParameter("@acc_type", SqlDbType.Int);
                pr[1].Value = acc_type;

                pr[2] = new SqlParameter("@acc_name", SqlDbType.NVarChar, 50);
                pr[2].Value = acc_name;

                //pr[3] = new SqlParameter("@acc_Creditor", SqlDbType.Decimal, 20);
                //pr[3].Value = acc_Creditor;

                //pr[4] = new SqlParameter("@acc_Debit", SqlDbType.Decimal, 20);
                //pr[4].Value = acc_Debit;

                //pr[5] = new SqlParameter("@acc_Balance", SqlDbType.Decimal, 20);
                //pr[5].Value = acc_Balance;

                //pr[6] = new SqlParameter("@acc_Max", SqlDbType.Decimal, 10);
                //pr[6].Value = acc_Max;

                //pr[7] = new SqlParameter("@acc_min", SqlDbType.Decimal, 10);
                //pr[7].Value = acc_min;

                pr[3] = new SqlParameter("@acc_Max", SqlDbType.Decimal, 10);
                pr[3].Value = (acc_Max == null) ? (object)DBNull.Value : acc_Max;

                pr[4] = new SqlParameter("@acc_min", SqlDbType.Decimal, 10);
                pr[4].Value = (acc_min == null) ? (object)DBNull.Value : acc_min;

                con.ExecuteNonQuery("ADD_ACCOUNTING", pr);

                f.BindingContext[f.AccountbindingSource].EndCurrentEdit();
                Notification.MessageBoxInformation("تم الاضافة بنجاح");
                f.settext.readonley(true, f.accountNumberText, f.accountType, f.accountNameText, f.accountDebitsText, f.accountCreditorText, f.accountBalanceText, f.accountMaxText, f.accountMinText);
                f.setbuton.ToggleButtons(false, f.add_btn, f.back_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
                f.accountsGridControl.Enabled = true;
            }

        }
        public void Update(Form fm)
        {           
            For_Accounts f = fm as For_Accounts;
            int x = 1;
           
            for (int i = 0; i < f.accountsGridControlvi.RowCount; i++)
            {
                if (f.accountsGridControlvi.GetRowCellValue(f.accountsGridControlvi.FocusedRowHandle, "رقم الحساب").ToString().Trim() == f.accountsGridControlvi.GetRowCellValue(i, "رقم الحساب").ToString().Trim())
                {
                    continue;
                }
                else
                {
                    if (f.accountNameText.Text.Trim().Equals(f.accountsGridControlvi.GetRowCellValue(i, "اسم الحساب")))
                    {
                        x = 0;
                        break;
                    }       
                  
                }
            }
            if (check.CheckControls("ادخل اسم الحساب", f.accountNameText))
            {
                return;
            }
            else if (x == 0)
            {
                Notification.MessageBoxError("يوجد حساب بهذا الاسم ");
                return;
            }           
            else
            {
                pr = new SqlParameter[5];
                int acc_num = (int)f.accountsGridControlvi.GetRowCellValue(f.accountsGridControlvi.FocusedRowHandle, "رقم الحساب");
                int acc_type = Convert.ToInt32(f.accountType.EditValue);
                string acc_name = f.accountNameText.Text.Trim();

                //decimal? acc_Creditor = Convert.ToDecimal(f.accountCreditorText.Text.Trim());
                //decimal? acc_Debit = Convert.ToDecimal(f.accountDebitsText.Text.Trim());
                //decimal? acc_Balance = Convert.ToDecimal(f.accountBalanceText.Text.Trim());

                decimal? acc_Max;
                decimal? acc_min;

                if (string.IsNullOrEmpty(f.accountMaxText.Text.Trim()) || string.IsNullOrEmpty(f.accountMinText.Text.Trim()))
                {
                    acc_Max = null;
                    acc_min = null;
                }
                else
                {
                    acc_Max = Convert.ToDecimal(f.accountMaxText.Text.Trim());
                    acc_min = Convert.ToDecimal(f.accountMinText.Text.Trim());
                }
               
                pr[0] = new SqlParameter("@acc_num", SqlDbType.Int);
                pr[0].Value = acc_num;

                pr[1] = new SqlParameter("@acc_type", SqlDbType.Int);
                pr[1].Value = acc_type;

                pr[2] = new SqlParameter("@acc_name", SqlDbType.NVarChar, 50);
                pr[2].Value = acc_name;

                //pr[3] = new SqlParameter("@acc_Creditor", SqlDbType.Decimal, 20);
                //pr[3].Value = acc_Creditor;

                //pr[4] = new SqlParameter("@acc_Debit", SqlDbType.Decimal, 20);
                //pr[4].Value = acc_Debit;

                //pr[5] = new SqlParameter("@acc_Balance", SqlDbType.Decimal, 20);
                //pr[5].Value = acc_Balance;               

                pr[3] = new SqlParameter("@acc_Max", SqlDbType.Decimal, 10);
                pr[3].Value = (acc_Max == null) ? (object)DBNull.Value : acc_Max;

                pr[4] = new SqlParameter("@acc_min", SqlDbType.Decimal, 10);
                pr[4].Value = (acc_min == null) ? (object)DBNull.Value : acc_min;
              
                con.ExecuteNonQuery("UPDATE_ACCOUNTING", pr);
                f.BindingContext[f.AccountbindingSource].EndCurrentEdit();
                Notification.MessageBoxInformation("تم التعديل بنجاح ");
                f.settext.readonley(true, f.accountNumberText, f.accountType, f.accountNameText, f.accountDebitsText, f.accountCreditorText, f.accountBalanceText, f.accountMaxText, f.accountMinText);                               
                f.setbuton.ToggleButtons(false, f.delete_btn, f.edit_btn, f.back_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
            }


           

        }
        public void Delete(Form fm)
        {
            For_Accounts f = fm as For_Accounts;
            if (f.accountsGridControlvi.SelectedRowsCount > 0)
            {
                // قم بحذف العناصر المحددة
                int[] selectedRows = f.accountsGridControlvi.GetSelectedRows();
                List<object> selectedValues = new List<object>();

                foreach (int rowHandle in selectedRows)
                {
                    object value = f.accountsGridControlvi.GetRowCellValue(rowHandle, "رقم الحساب");
                    selectedValues.Add(value);
                }


                // استخدم selectedValues كما تريد
                foreach (object value in selectedValues)
                {
                    if (CLASSES.SysNotification.Notification.MessageBoxQuestion($" Are you sur delet this item:{value.ToString()}") == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        pr = new SqlParameter[1];
                        pr[0] = new SqlParameter("@acc_num", SqlDbType.Int);
                        pr[0].Value =(int)value;
                        con.ExecuteNonQuery("DELETE_ACCOUNTING", pr);
                    }
                }
                f.accountsGridControlvi.DeleteSelectedRows();
            }
            else
            {
                MessageBox.Show("الرجاء تحديد عنصر لحذفه");
            }
           
            Notification.MessageBoxInformation("تم الحذف بنجاح");
        }

        public void SELECT_ALL_ACCOUNTING(For_Accounts f)
        {
            f.AccountbindingSource.DataSource = con.GetData("SELECT_ALL_ACCOUNTING");
            //f.AccountbindingSource.DataSource = f.AccountbindingSource;
            f.accountsGridControl.DataSource = f.AccountbindingSource;
            f.accountNumberText.DataBindings.Add("Text", f.AccountbindingSource, "رقم الحساب");
            f.accountType.DataBindings.Add("EditValue", f.AccountbindingSource, "نوع الحساب");
            f.accountNameText.DataBindings.Add("Text", f.AccountbindingSource, "اسم الحساب");
            f.accountCreditorText.DataBindings.Add("Text", f.AccountbindingSource, "دائن");
            f.accountDebitsText.DataBindings.Add("Text", f.AccountbindingSource, "مدين");
            f.accountBalanceText.DataBindings.Add("Text", f.AccountbindingSource, "الحساب");
            f.accountMaxText.DataBindings.Add("Text", f.AccountbindingSource, "الحد الاعلى");
            f.accountMinText.DataBindings.Add("Text", f.AccountbindingSource, "الحد الادنى");
        }
        public void GET_ACCOUNTING_TYPE(For_Accounts f)
        {
            DataTable dt = new DataTable();
            dt = con.GetData("GET_ACCOUNTING_TYPE");
            f.accountType.Properties.DataSource = dt;            
            f.accountType.Properties.DisplayMember= "acc_type_name";
            f.accountType.Properties.ValueMember = "acc_type_id";
        }
    }

    class USERES : AllProces
    {
        public CLASSES.DAL.DbInterfaceMediator.DatabaseManager con = new CLASSES.DAL.DbInterfaceMediator.DatabaseManager();
        public SqlParameter[] pr;
        public CLASSES.Checkups.ChickedEmpty check = new CLASSES.Checkups.Checek_Rusalt();

      

        public void Insert(Form fm)
        {
            For_Mang_Users f = fm as For_Mang_Users;
            int x = 1;

            for (int i = 0; i < f.userGridControlvi.RowCount - 1; i++)
            {
                if (f.userIdText.Text.Trim().Equals(f.userGridControlvi.GetRowCellValue(i, "user_id").ToString()))
                {
                    x = 0;
                    break;
                }
            }
            if (check.CheckControls("", f.userIdText, f.userNameText, f.userPasswordNewText, f.userPasswordOledText))
            {
                return;
            }

            else if (x == 0)
            {
                Notification.MessageBoxError("هاذا المستخدم موجود مسبقا ");
                return;
            }
            else
            {
                pr = new SqlParameter[4];
                int us_id = Convert.ToInt32(f.userIdText.Text.Trim());
                string us_name = f.userNameText.Text.Trim();
                string us_pass = f.userPasswordNewText.Text.Trim();
                int us_stat= f.userCheckEdit.Checked ? 1 : 0;


                pr[0] = new SqlParameter("@us_id", SqlDbType.Int);
                pr[0].Value = us_id;

                pr[1] = new SqlParameter("@us_name", SqlDbType.NVarChar, 50);
                pr[1].Value = us_name;

                pr[2] = new SqlParameter("@us_pass", SqlDbType.NVarChar, 50);
                pr[2].Value = us_pass;

                pr[3] = new SqlParameter("@state", SqlDbType.Bit);
                pr[3].Value = us_stat;

                con.ExecuteNonQuery("ADD_USER", pr);

                f.BindingContext[f.UserBindingSource].EndCurrentEdit();
                Notification.MessageBoxInformation("تم الاضافة بنجاح");
                f.settext.readonley(true, f.userIdText, f.userNameText, f.userPasswordNewText, f.userPasswordOledText);
                f.setbuton.ToggleButtons(false, f.add_btn, f.back_btn,f.edit_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
                f.userGridControl.Enabled = true;
            }

        }

        public void Update(Form fm)
        {
            For_Mang_Users f = fm as For_Mang_Users;
           
        }
        public void Delete(Form fm)
        {
            For_Mang_Users f = fm as For_Mang_Users;

        }
        public void SELECT_ALL_USERS(For_Mang_Users f)
        {
            f.UserBindingSource.DataSource = con.GetData("SELECT_ALL_USERS");            
            f.userGridControl.DataSource = f.UserBindingSource;
            f.userIdText.DataBindings.Add("Text", f.UserBindingSource, "user_id");
            f.userNameText.DataBindings.Add("EditValue", f.UserBindingSource, "user_name");
            f.userPasswordNewText.DataBindings.Add("Text", f.UserBindingSource, "user_password");
            f.userCheckEdit.DataBindings.Add("Checked", f.UserBindingSource, "user_state", true, DataSourceUpdateMode.OnPropertyChanged);
        }

    }
    class process
    {
        public CLASSES.DAL.DbInterfaceMediator.DatabaseManager con = new CLASSES.DAL.DbInterfaceMediator.DatabaseManager();
        public SqlParameter[] pr;
        public CLASSES.Checkups.ChickedEmpty check = new CLASSES.Checkups.Checek_Rusalt();
        //public void SELECT_ALL_CATEGORY(For_Category f)
        //{
        //    f.T = con.GetData("selectAllCategories");
        //    f.categoryBindingSource.DataSource = f.T;
        //    f.categoryGridControl.DataSource = f.T;
        //    f.categoryNameText.DataBindings.Add("Text", f.T, "اسم الصنف");
        //    f.categoryDetailsText.DataBindings.Add("Text", f.T, "تفاصيل الصنف");
        //}

        //public void ADD_CATEGORY(For_Category f)
        //{
        //    int x = 1;

        //    for (int i = 0; i < f.categoryGridControlvi.RowCount; i++)
        //    {
        //        if (f.categoryNameText.Text.Trim().Equals(f.categoryGridControlvi.GetRowCellValue(i, "اسم الصنف")))
        //        {
        //            x = 0;
        //            break;
        //        }
        //    }
        //    if (check.CheckControls("ادخل اسم الصنف", f.categoryNameText))
        //    {
        //        return;
        //    }

        //    else if (x == 0)
        //    {
        //        Notification.MessageBoxError("يوجد صنف بهذا الاسم ");
        //    }
        //    else
        //    {
        //        pr = new SqlParameter[2];
        //        string cat_name = f.categoryNameText.Text.Trim();
        //        string cat_detailes = f.categoryDetailsText.Text.Trim();
        //        pr[0] = new SqlParameter("@cat_name", SqlDbType.NVarChar, 50);
        //        pr[0].Value = cat_name;
        //        pr[1] = new SqlParameter("@cat_details", SqlDbType.NVarChar);
        //        pr[1].Value = cat_detailes;
        //        con.ExecuteNonQuery("ADD_CATEGORY", pr);
        //        f.BindingContext[f.T].EndCurrentEdit();
        //        Notification.MessageBoxInformation("تم الاظافة بنجاح");
        //        f.settext.readonley(true, f.categoryNameText, f.categoryDetailsText);
        //        f.setbuton.ToggleButtons(false, f.back_btn, f.add_btn);
        //        f.setbuton.ToggleButtons(true, f.new_btn);
        //        f.categoryGridControl.Enabled = true;
        //    }
        //}

        //public void DELETE_CATEGORY(For_Category f)
        //{
        //    pr = new SqlParameter[1];
        //    pr[0] = new SqlParameter("@cat_id", SqlDbType.Int);
        //    pr[0].Value = f.categoryGridControlvi.GetRowCellValue(f.categoryGridControlvi.FocusedRowHandle, "رقم الصنف");
        //    con.ExecuteNonQuery("DELETE_CATEGORY", pr);
        //    f.BindingContext[f.T].RemoveAt(f.BindingContext[f.T].Position);
        //    Notification.MessageBoxInformation("تم الحذف بنجاح");
        //}

        //public void UPDATE_CATEGORY(For_Category f)
        //{
        //    int x = 1;

        //    for (int i = 0; i < f.categoryGridControlvi.RowCount; i++)
        //    {
        //        if (f.categoryGridControlvi.GetRowCellValue(f.categoryGridControlvi.FocusedRowHandle, "رقم الصنف").ToString().Trim() == f.categoryGridControlvi.GetRowCellValue(i, "رقم الصنف").ToString().Trim())
        //        {
        //            continue;
        //        }
        //        else
        //        {

        //            if (f.categoryNameText.Text.Trim().Equals(f.categoryGridControlvi.GetRowCellValue(i, "اسم الصنف")))
        //            {
        //                x = 0;
        //                break;
        //            }
        //        }
        //    }
        //    if (check.CheckControls("ادخل اسم الصنف ", f.categoryNameText))
        //    {
        //        return;
        //    }
        //    else if (x == 0)
        //    {
        //        Notification.MessageBoxError("يوجد صنف بهذا الاسم ");
        //    }
        //    else
        //    {
        //        pr = new SqlParameter[3];
        //        pr[0] = new SqlParameter("@cat_id", SqlDbType.Int);
        //        pr[0].Value = f.categoryGridControlvi.GetRowCellValue(f.categoryGridControlvi.FocusedRowHandle, "رقم الصنف");
        //        pr[1] = new SqlParameter("@cat_name", SqlDbType.NVarChar);
        //        pr[1].Value = f.categoryNameText.Text.Trim();
        //        pr[2] = new SqlParameter("@cat_detailes", SqlDbType.NVarChar);
        //        pr[2].Value = f.categoryDetailsText.Text.Trim();
        //        con.ExecuteNonQuery("UPDATE_CATEGORY", pr);
        //        f.BindingContext[f.T].EndCurrentEdit();
        //        Notification.MessageBoxInformation("تم التعديل بنجاح ");
        //        f.settext.readonley(true, f.categoryNameText, f.categoryDetailsText);
        //        f.setbuton.ToggleButtons(false, f.delete_btn, f.edit_btn, f.back_btn);
        //        f.setbuton.ToggleButtons(true, f.new_btn);
        //    }
        //}

        ////////////////////////////////////////////////////////



        public void SELECT_ALL_UNITS(For_Units f)
        {
            f.T = con.GetData("SELECT_ALL_UNITS");
            f.unitGridControl.DataSource = f.T;
            f.unitNameText.DataBindings.Add("Text", f.T, "اسم الوحدة");
        }

        public void ADD_UNIT(For_Units f)
        {
            int x = 1;

            for (int i = 0; i < f.unitGridControlvi.RowCount; i++)
            {
                if (f.unitNameText.Text.Trim().Equals(f.unitGridControlvi.GetRowCellValue(i, "اسم الوحدة")))
                {
                    x = 0;
                    break;
                }
            }
            if (check.CheckControls("ادخل اسم الوحدة ", f.unitNameText))
            {
                return;
            }
            else if (x == 0)
            {
                Notification.MessageBoxError("يوجد وحدة بهذا الاسم ");
            }
            else
            {
                pr = new SqlParameter[1];
                string unit_name = f.unitNameText.Text.Trim();
                pr[0] = new SqlParameter("@unit_name", SqlDbType.NVarChar, 50);
                pr[0].Value = unit_name;
                con.ExecuteNonQuery("ADD_UNIT", pr);
                f.BindingContext[f.T].EndCurrentEdit();
                Notification.MessageBoxInformation("تم الاظافة بنجاح");
                f.settext.readonley(true, f.unitNameText);
                f.setbuton.ToggleButtons(false, f.back_btn, f.add_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
                f.unitGridControl.Enabled = true;
            }
        }

        public void DELETE_UNIT(For_Units f)
        {

            pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@unit_id", SqlDbType.Int);
            pr[0].Value = f.unitGridControlvi.GetRowCellValue(f.unitGridControlvi.FocusedRowHandle, "رقم الوحدة");
            con.ExecuteNonQuery("DELETE_UNIT", pr);
            f.BindingContext[f.T].RemoveAt(f.BindingContext[f.T].Position);
            Notification.MessageBoxInformation("تم الحذف بنجاح ");
        }

        public void UPDATE_UNIT(For_Units f)
        {

            int x = 1;

            for (int i = 0; i < f.unitGridControlvi.RowCount; i++)
            {
                if (f.unitGridControlvi.GetRowCellValue(f.unitGridControlvi.FocusedRowHandle, "رقم الوحدة").ToString().Trim() == f.unitGridControlvi.GetRowCellValue(i, "رقم الوحدة").ToString().Trim())
                {
                    continue;
                }
                else
                {

                    if (f.unitNameText.Text.Trim().Equals(f.unitGridControlvi.GetRowCellValue(i, "اسم الوحدة")))
                    {
                        x = 0;
                        break;
                    }
                }
            }
            if (check.CheckControls("ادخل اسم الوحدة ", f.unitNameText))
            {
                return;
            }
            else if (x == 0)
            {
                Notification.MessageBoxError("يوجد وحدة بهذا الاسم ");
            }
            else
            {
                pr = new SqlParameter[2];
                pr[0] = new SqlParameter("@unit_id", SqlDbType.Int);
                pr[0].Value = f.unitGridControlvi.GetRowCellValue(f.unitGridControlvi.FocusedRowHandle, "رقم الوحدة");
                pr[1] = new SqlParameter("@unit_name", SqlDbType.NVarChar);
                pr[1].Value = f.unitNameText.Text.Trim();
                con.ExecuteNonQuery("UPDATE_UNIT", pr);
                f.BindingContext[f.T].EndCurrentEdit();
                Notification.MessageBoxInformation("تم التعديل بنجاح ");
                f.settext.readonley(true, f.unitNameText);
                f.setbuton.ToggleButtons(false, f.delete_btn, f.edit_btn, f.back_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
            }
        }

        //////////////////////////////////////////////////////

        public void SELECT_ALL_PRODUCTS(For_Product f)
        {
            f.T = con.GetData("SELECT_ALL_PRODUCTS");
            f.bindingSource1.DataSource = f.T;
            f.productsGridControl.DataSource = f.T;
            f.productNumberText.DataBindings.Add("Text", f.T, "رقم المنتج");
            f.productCodText.DataBindings.Add("Text", f.T, "كود المنتج");
            f.categoryNameText.DataBindings.Add("EditValue", f.T, "رقم الصنف");
            f.productNameText.DataBindings.Add("Text", f.T, "اسم المنتج");
            f.productPictureEdit.DataBindings.Add("Image", f.T, "صورة المنتج", true);
        }

        public void SELECT_ALL_CATEGORY(For_Product f)
        {
            f.categoryNameText.Properties.DataSource = con.GetData("SELECTALLCATEGORIES");
            f.categoryNameText.Properties.PopulateColumns();
            f.categoryNameText.Properties.DisplayMember = "اسم الصنف";
            f.categoryNameText.Properties.ValueMember = "رقم الصنف";
            f.categoryNameText.Properties.ShowHeader = false;
        }

        public void ADD_PRODUCT(For_Product f)
        {
            int x = 1;

            for (int i = 0; i < f.productsGridControlvi.RowCount; i++)
            {
                if (f.productNameText.Text.Trim().Equals(f.productsGridControlvi.GetRowCellValue(i, "اسم المنتج")) && f.categoryNameText.EditValue.Equals(f.productsGridControlvi.GetRowCellValue(i, "رقم الصنف")))
                {
                    x = 0;
                    break;
                }
            }
            if (check.CheckControls("ادخل اسم الصنف", f.categoryNameText))
            {
                return;
            }
            else if (check.CheckControls("ادخل اسم المنتج", f.productNameText))
            {
                return;
            }
            else if (x == 0)
            {
                Notification.MessageBoxError("يوجد منتج بهذا الاسم تحت نفس التصنيف ");
            }
            else
            {
                pr = new SqlParameter[4];
                pr[0] = new SqlParameter("@cat_id", SqlDbType.Int);
                pr[0].Value = (Int32)f.categoryNameText.EditValue;
                pr[1] = new SqlParameter("@pro_code", SqlDbType.NVarChar);
                pr[1].Value = f.productCodText.Text.Trim();
                pr[2] = new SqlParameter("@pro_name", SqlDbType.NVarChar);
                pr[2].Value = f.productNameText.Text.Trim();
                MemoryStream ms = new MemoryStream();
                f.productPictureEdit.Image.Save(ms, f.productPictureEdit.Image.RawFormat);
                Byte[] pic;
                pic = ms.ToArray();
                pr[3] = new SqlParameter("@pro_image", SqlDbType.Image);
                pr[3].Value = pic;
                con.ExecuteNonQuery("ADD_PRODUCT", pr);
                f.BindingContext[f.T].EndCurrentEdit();
                Notification.MessageBoxInformation("تم الاظافة بنجاح");
                f.settext.readonley(true, f.productCodText, f.categoryNameText, f.productNameText, f.productUnitNumber);
                f.setbuton.ToggleButtons(false, f.add_btn, f.back_btn, f.getImageBtn);
                f.setbuton.ToggleButtons(true, f.new_btn);
                f.productsGridControl.Enabled = true;
            }
        }

        public void DELETE_PRODUCT(For_Product f)
        {
            pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@pro_id", SqlDbType.Int);
            pr[0].Value = f.productsGridControlvi.GetRowCellValue(f.productsGridControlvi.FocusedRowHandle, "رقم المنتج");
            con.ExecuteNonQuery("DELETE_PRODUCT", pr);
            f.BindingContext[f.T].RemoveAt(f.BindingContext[f.T].Position);
            Notification.MessageBoxInformation("تم الحذف بنجاح ");
        }

        public void UPDATE_PRODUCT(For_Product f)
        {
            int x = 1;

            for (int i = 0; i < f.productsGridControlvi.RowCount; i++)
            {
                if (f.productsGridControlvi.GetRowCellValue(f.productsGridControlvi.FocusedRowHandle, "رقم المنتج").ToString().Trim() == f.productsGridControlvi.GetRowCellValue(i, "رقم المنتج").ToString().Trim())
                {
                    continue;
                }
                else
                {

                    if (f.productNameText.Text.Trim().Equals(f.productsGridControlvi.GetRowCellValue(i, "اسم المنتج")) && f.categoryNameText.EditValue.Equals(f.productsGridControlvi.GetRowCellValue(i, "رقم الصنف")))
                    {
                        x = 0;
                        break;
                    }
                }
            }
            if (check.CheckControls("ادخل اسم الصنف ", f.categoryNameText))
            {
                return;
            }
            else if (check.CheckControls("ادخل اسم المنتج ", f.productNameText))
            {
                return;
            }
            else if (x == 0)
            {
                Notification.MessageBoxError("يوجد منتج بهذا الاسم تحت نفس التصنيف ");
            }
            else
            {
                pr = new SqlParameter[5];
                pr[0] = new SqlParameter("@pro_id", SqlDbType.Int);
                pr[0].Value = f.productNumberText.Text;
                pr[1] = new SqlParameter("@cat_id", SqlDbType.Int);
                pr[1].Value = (Int32)f.categoryNameText.EditValue;
                pr[2] = new SqlParameter("@pro_code", SqlDbType.NVarChar);
                pr[2].Value = f.productCodText.Text.Trim();
                pr[3] = new SqlParameter("@pro_name", SqlDbType.NVarChar);
                pr[3].Value = f.productNameText.Text.Trim();
                MemoryStream ms = new MemoryStream();
                f.productPictureEdit.Image.Save(ms, f.productPictureEdit.Image.RawFormat);
                Byte[] pic;
                pic = ms.ToArray();
                pr[4] = new SqlParameter("@pro_image", SqlDbType.Image);
                pr[4].Value = pic;
                con.ExecuteNonQuery("UPDATE_PRODUCT", pr);
                f.BindingContext[f.T].EndCurrentEdit();
                Notification.MessageBoxInformation("تم التعديل بنجاح ");
            }
        }

        public void SELECT_ALL_PRODUCT_UNITS(For_Product f)
        {
            f.ta = con.GetData("SELECT_ALL_PRODUCT_UNITS");
            f.ProductUnitsGridControl.DataSource = f.ta;
            f.productNameText1.DataBindings.Add("EditValue", f.ta, "رقم المنتج");
            f.productUnitsText.DataBindings.Add("EditValue", f.ta, "رقم الوحدة");
            f.productUnitNumber.DataBindings.Add("EditValue", f.ta, "العدد");
            f.ProductUnitsGridControlvi.Columns[0].Visible = false;
        }

        public void ADD_UNIT_TO_PRODUCT(For_Product f)
        {
            int x = 1;
            if (check.CheckControls("ادخل اسم المنتج ", f.productNameText1))
            {
                return;
            }
            else
            {
                for (int i = 0; i < f.ProductUnitsGridControlvi.RowCount; i++)
                {
                    if (f.productNameText1.EditValue.Equals(f.ProductUnitsGridControlvi.GetRowCellValue(i, "رقم المنتج")) && f.productUnitsText.EditValue.Equals(f.ProductUnitsGridControlvi.GetRowCellValue(i, "رقم الوحدة")))
                    {
                        x = 0;
                        break;
                    }
                }
            }
            //int n = Convert.ToInt32(f.productNumberText.Text);

            if (check.CheckControls("ادخل اسم المنتج ", f.productNameText1))
            {
                return;
            }
            else if (check.CheckControls("ادخل اسم الوحدة ", f.productUnitsText))
            {
                return;
            }
            else if (check.CheckControls("", f.productUnitNumber) || f.productUnitNumber.Text == "0")
            {
                Notification.MessageBoxError("ادخل اسم الوحدة ");
                return;
            }
            else if (x == 0)
            {
                Notification.MessageBoxError("يوجد للمنتج '" + f.productNameText1.Text + "' وحدة بهذا الاسم ");
            }
            else
            {
                pr = new SqlParameter[3];
                pr[0] = new SqlParameter("@pro_id", SqlDbType.Int);
                pr[0].Value = (Int32)f.productNameText1.EditValue;
                pr[1] = new SqlParameter("@unit_id", SqlDbType.Int);
                pr[1].Value = (Int32)f.productUnitsText.EditValue;
                pr[2] = new SqlParameter("@unit_quantity", SqlDbType.NVarChar);
                pr[2].Value = f.productUnitNumber.Text;
                MemoryStream ms = new MemoryStream();
                con.ExecuteNonQuery("ADD_UNIT_TO_PRODUCT", pr);
                f.BindingContext[f.ta].EndCurrentEdit();
                Notification.MessageBoxInformation("تم الاظافة بنجاح");
                f.ProductUnitsGridControl.Enabled = true;
                f.productNameTextSr.ResetText();
                f.setbuton.ToggleButtons(true, f.new_btn1);
                f.setbuton.ToggleButtons(false, f.back_btn1, f.add_btn1);
                f.settext.readonley(true, f.productNameTextSr, f.productUnitsText, f.productUnitNumber);

            }
        }



        public void DELETE_PRODUCT_UNIT(For_Product f)
        {
            pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@id", SqlDbType.Int);
            pr[0].Value = f.ProductUnitsGridControlvi.GetRowCellValue(f.ProductUnitsGridControlvi.FocusedRowHandle, "المعرف");
            pr[1] = new SqlParameter("@pro_id", SqlDbType.Int);
            pr[1].Value = f.productNameText1.EditValue;
            con.ExecuteNonQuery("DELETE_PRODUCT_UNIT", pr);
            f.BindingContext[f.ta].RemoveAt(f.BindingContext[f.ta].Position);
            Notification.MessageBoxInformation("تم الحذف  بنجاح ");
            f.settext.readonley(true, f.productNameTextSr, f.productUnitsText, f.productUnitNumber);
            f.setbuton.ToggleButtons(true, f.new_btn1);
            f.setbuton.ToggleButtons(false, f.delete_btn1, f.edit_btn1, f.back_btn1);
        }

        public void UPDATE_PRODUCT_UNIT(For_Product f)
        {
            int x = 1;
            for (int i = 0; i < f.ProductUnitsGridControlvi.RowCount; i++)
            {
                if (f.ProductUnitsGridControlvi.GetRowCellValue(f.ProductUnitsGridControlvi.FocusedRowHandle, "رقم الوحدة").ToString() == f.ProductUnitsGridControlvi.GetRowCellValue(i, "رقم الوحدة").ToString() && f.ProductUnitsGridControlvi.GetRowCellValue(i, "رقم الوحدة").ToString() == f.productNameText1.EditValue.ToString())
                {
                    continue;
                }
                else
                {
                    if (f.productNameText1.EditValue.Equals(f.ProductUnitsGridControlvi.GetRowCellValue(i, "رقم المنتج")) && f.productUnitsText.EditValue.Equals(f.ProductUnitsGridControlvi.GetRowCellValue(i, "رقم الوحدة")))
                    {
                        x = 0;
                        break;
                    }
                }

            }
            if (check.CheckControls("ادخل اسم المنتج ", f.productNameText1))
            {
                return;
            }
            else if (check.CheckControls("ادخل اسم الوحدة ", f.productUnitsText))
            {
                return;
            }
            else if (check.CheckControls("", f.productUnitNumber) || f.productUnitNumber.Text == "0")
            {
                Notification.MessageBoxError("ادخل العدد ");
            }
            else if (x == 0)
            {
                Notification.MessageBoxError("يوجد للمنتج '" + f.productNameText1.Text + "' وحدة بهذا الاسم ");
            }
            else
            {
                pr = new SqlParameter[4];
                pr[0] = new SqlParameter("@id", SqlDbType.Int);
                pr[0].Value = f.ProductUnitsGridControlvi.GetRowCellValue(f.ProductUnitsGridControlvi.FocusedRowHandle, "المعرف");
                pr[1] = new SqlParameter("@pro_id", SqlDbType.Int);
                pr[1].Value = (Int32)f.productNameText1.EditValue;
                pr[2] = new SqlParameter("@unit_id", SqlDbType.Int);
                pr[2].Value = (Int32)f.productUnitsText.EditValue;
                pr[3] = new SqlParameter("@unit_quantity", SqlDbType.NVarChar);
                pr[3].Value = f.productUnitNumber.Text;
                con.ExecuteNonQuery("UPDATE_PRODUCT_UNIT", pr);
                f.BindingContext[f.ta].EndCurrentEdit();
                Notification.MessageBoxInformation("تم التعديل بنجاح ");
                f.settext.readonley(true, f.productNameTextSr, f.productUnitsText, f.productUnitNumber);
                f.setbuton.ToggleButtons(true, f.new_btn1);
                f.setbuton.ToggleButtons(false, f.delete_btn1, f.edit_btn1, f.back_btn1);
            }
        }



        //////////////////////////////////////////////////////////

        public void SELECT_ALL_CUSTOMERS(For_Customers f)
        {
            f.T = con.GetData("SELECT_ALL_CUSTOMERS");
            f.customersGridControl.DataSource = f.T;
            f.customerNumberText.DataBindings.Add("Text", f.T, "رقم العميل");
            f.customerNameText.DataBindings.Add("Text", f.T, "اسم العميل");
            f.customerAdressText.DataBindings.Add("Text", f.T, "عنوان السكن");
            f.customerStorAdressText.DataBindings.Add("Text", f.T, "عنوان العمل");
            f.customerGmailText.DataBindings.Add("Text", f.T, "البريد الالكتروني");
            f.customerPictureEdit.DataBindings.Add("image", f.T, "صورة العميل", true);

        }

        public void ADD_CUSTOMER(For_Customers f)
        {
            int x = 0;
            for (int i = 0; i < f.customersGridControlvi.RowCount; i++)
            {
                if (f.customerNameText.Text.Trim().Equals(f.customersGridControlvi.GetRowCellValue(i, "اسم العميل")))
                    x = 1;
            }
            if (x == 1)
            {
                Notification.MessageBoxError(" يوجد عميل بهذا الاسم");
            }
            else if (check.CheckControls("ادخل اسم العميل", f.customerNameText))
            {
                return;
            }
            else if (check.CheckControls("ادخل  عنوان السكن للعميل ", f.customerAdressText))
            {
                return;
            }
            else if (check.CheckControls("ادخل  عنوان العمل للعميل ", f.customerStorAdressText))
            {
                return;
            }
            else
            {
                pr = new SqlParameter[5];
                pr[0] = new SqlParameter("@cust_name", SqlDbType.NVarChar);
                pr[0].Value = f.customerNameText.Text.Trim();
                pr[1] = new SqlParameter("@cust_adress", SqlDbType.NVarChar);
                pr[1].Value = f.customerAdressText.Text.Trim();
                pr[2] = new SqlParameter("@cust_stor_address", SqlDbType.NVarChar);
                pr[2].Value = f.customerStorAdressText.Text.Trim();
                pr[3] = new SqlParameter("@cust_email", SqlDbType.NVarChar);
                pr[3].Value = f.customerGmailText.Text.Trim();
                MemoryStream ms = new MemoryStream();
                f.customerPictureEdit.Image.Save(ms, f.customerPictureEdit.Image.RawFormat);
                Byte[] pic;
                pic = ms.ToArray();
                pr[4] = new SqlParameter("@cust_image", SqlDbType.Image);
                pr[4].Value = pic;
                con.ExecuteNonQuery("ADD_CUSTOMER", pr);
                f.BindingContext[f.T].EndCurrentEdit();
                Notification.MessageBoxInformation("تم الاضافة بنجاح");
                f.settext.readonley(true, f.customerNameText, f.customerAdressText, f.customerStorAdressText, f.customerGmailText);
                f.setbuton.ToggleButtons(false, f.add_btn, f.back_btn, f.getImageBtn);
                f.setbuton.ToggleButtons(true, f.new_btn);
                f.customersGridControl.Enabled = true;
            }
        }

        public void DELETE_CUSTOMER(For_Customers f)
        {
            pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@cust_id", SqlDbType.Int);
            pr[0].Value = f.customersGridControlvi.GetRowCellValue(f.customersGridControlvi.FocusedRowHandle, "رقم العميل");
            con.ExecuteNonQuery("DELETE_CUSTOMER", pr);
            Notification.MessageBoxInformation("تم الحذف بنجاح ");
        }

        public void UPDATE_CUSTOMER(For_Customers f)
        {
            int x = 1;

            for (int i = 0; i < f.customersGridControlvi.RowCount; i++)
            {
                if (f.customersGridControlvi.GetRowCellValue(f.customersGridControlvi.FocusedRowHandle, "رقم العميل").ToString().Trim() == f.customersGridControlvi.GetRowCellValue(i, "رقم العميل").ToString().Trim())
                {
                    continue;
                }
                else
                {

                    if (f.customerNameText.Text.Trim().Equals(f.customersGridControlvi.GetRowCellValue(i, "اسم العميل")))
                    {
                        x = 0;
                        break;
                    }
                }
            }

            if (x == 0)
            {
                Notification.MessageBoxError(" يوجد عميل بهذا الاسم");
            }
            else if (check.CheckControls("ادخل اسم العميل", f.customerNameText))
            {
                return;
            }
            else if (check.CheckControls("ادخل  عنوان السكن للعميل ", f.customerAdressText))
            {
                return;
            }
            else if (check.CheckControls("ادخل  عنوان العمل للعميل ", f.customerStorAdressText))
            {
                return;
            }
            else
            {
                pr = new SqlParameter[6];
                pr[0] = new SqlParameter("@cust_id", SqlDbType.Int);
                pr[0].Value = f.customersGridControlvi.GetRowCellValue(f.customersGridControlvi.FocusedRowHandle, "رقم العميل");
                pr[1] = new SqlParameter("@cust_name", SqlDbType.NVarChar);
                pr[1].Value = f.customerNameText.Text.Trim();
                pr[2] = new SqlParameter("@cust_adress", SqlDbType.NVarChar);
                pr[2].Value = f.customerAdressText.Text.Trim();
                pr[3] = new SqlParameter("@cust_stor_address", SqlDbType.NVarChar);
                pr[3].Value = f.customerStorAdressText.Text.Trim();
                pr[4] = new SqlParameter("@cust_email", SqlDbType.NVarChar);
                pr[4].Value = f.customerGmailText.Text.Trim();
                MemoryStream ms = new MemoryStream();
                f.customerPictureEdit.Image.Save(ms, f.customerPictureEdit.Image.RawFormat);
                Byte[] pic;
                pic = ms.ToArray();
                pr[5] = new SqlParameter("@cust_image", SqlDbType.Image);
                pr[5].Value = pic;
                con.ExecuteNonQuery("UPDATE_CUSTOMER", pr);
                f.BindingContext[f.T].EndCurrentEdit();
                Notification.MessageBoxInformation("تم التعديل بنجاح ");
                f.settext.readonley(true, f.customerNameText, f.customerAdressText, f.customerStorAdressText, f.customerGmailText);
                f.setbuton.ToggleButtons(false, f.add_btn, f.back_btn, f.getImageBtn, f.edit_btn, f.delete_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
            }
        }

        public void SELECT_ALL_CUSTOMERS_PHONS(For_Customers f)
        {
            f.ta = con.GetData("SELECT_ALL_CUSTOMERS_PHONS");
            f.customersPhoneGridControl.DataSource = f.ta;
            f.customerNameText1.DataBindings.Add("EditValue", f.ta, "رقم العميل");
            f.customerPhoneText.DataBindings.Add("EditValue", f.ta, "رقم الهاتف");
            f.customerPhoneNoteText.DataBindings.Add("Text", f.ta, "ملاحظة");
            f.customersPhoneGridControlvi.Columns[0].Visible = false;
        }

        public void ADD_PHONE_TO_CUSTOMER(For_Customers f)
        {
            int y = 0;
            int x = 0;
            if (check.CheckControls("ادخل اسم العميل ", f.customerNameText1))
            {
                return;
            }
            else
            {
                for (int i = 0; i < f.customersPhoneGridControlvi.RowCount; i++)
                {
                    if (f.customerNameText1.EditValue.Equals(f.customersPhoneGridControlvi.GetRowCellValue(i, "رقم العميل")) && f.customerPhoneText.EditValue.Equals(f.customersPhoneGridControlvi.GetRowCellValue(i, "رقم الهاتف")))
                    { x = 1; break; }
                    if (f.customerPhoneText.EditValue.Equals(f.customersPhoneGridControlvi.GetRowCellValue(i, "رقم الهاتف")))
                    { y = 1; break; }
                }
            }

            if (y == 1)
            {
                Notification.MessageBoxError(" رقم الهاتف موجود مسبقاً");
            }
            else if (x == 1)
            {
                Notification.MessageBoxError(" رقم الهاتف موجود مسبقاً للعميل  " + f.customerNameText1.Text + "  ");
            }
            else if (check.CheckControls("ادخل اسم العميل ", f.customerNameText1))
            {
                return;
            }
            else if (check.CheckControls("ادخل   رقم هاتف العميل ", f.customerPhoneText))
            {
                return;
            }
            else
            {
                pr = new SqlParameter[3];
                pr[0] = new SqlParameter("@cust_id", SqlDbType.Int);
                pr[0].Value = f.customerNameText1.EditValue;
                pr[1] = new SqlParameter("@tell_number", SqlDbType.NVarChar);
                pr[1].Value = f.customerPhoneText.EditValue;
                pr[2] = new SqlParameter("@tell_notes", SqlDbType.NVarChar);
                pr[2].Value = f.customerPhoneNoteText.Text;
                con.ExecuteNonQuery("ADD_PHONE_TO_CUSTOMER", pr);
                f.BindingContext[f.ta].EndCurrentEdit();
                Notification.MessageBoxInformation("تم الاضافة بنجاح ");
                f.setbuton.ToggleButtons(false, f.add_btn1, f.back_btn1, f.delete_btn1, f.edit_btn1);
                f.setbuton.ToggleButtons(true, f.new_btn1);
                f.settext.readonley(true, f.customerNameTextSr, f.customerPhoneText, f.customerPhoneNoteText);
                f.customersPhoneGridControl.Enabled = true;
            }
        }

        public void DELETE_CUSTOMER_PHONE(For_Customers f)
        {
            pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@tell_id", SqlDbType.Int);
            pr[0].Value = f.customersPhoneGridControlvi.GetRowCellValue(f.customersPhoneGridControlvi.FocusedRowHandle, "المعرف");
            pr[1] = new SqlParameter("@cust_id", SqlDbType.Int);
            pr[1].Value = f.customerNameText1.EditValue;
            con.ExecuteNonQuery("DELETE_CUSTOMER_PHONE", pr);
            f.BindingContext[f.ta].RemoveAt(f.BindingContext[f.ta].Position);
            Notification.MessageBoxInformation("تم الحذف بنجاح ");
        }

        public void UPDATE_CUSTOMER_PHONE(For_Customers f)
        {
            int y = 0;
            int x = 0;
            for (int i = 0; i < f.customersPhoneGridControlvi.RowCount; i++)
            {
                if (f.customersPhoneGridControlvi.GetRowCellValue(i, "رقم الهاتف") == f.customersPhoneGridControlvi.GetRowCellValue(f.customersPhoneGridControlvi.FocusedRowHandle, "رقم الهاتف"))
                { continue; }
                else
                {
                    if (f.customerNameText1.EditValue.Equals(f.customersPhoneGridControlvi.GetRowCellValue(i, "رقم العميل")) && f.customerPhoneText.EditValue.Equals(f.customersPhoneGridControlvi.GetRowCellValue(i, "رقم الهاتف")))
                    { x = 1; break; }
                    if (f.customerPhoneText.EditValue.Equals(f.customersPhoneGridControlvi.GetRowCellValue(i, "رقم الهاتف")))
                    { y = 1; break; }
                }

            }
            if (y == 1)
            {
                Notification.MessageBoxError(" رقم الهاتف موجود مسبقاً");
            }
            else if (x == 1)
            {
                Notification.MessageBoxError(" رقم الهاتف موجود مسبقاً للعميل  " + f.customerNameText1.Text + "  ");
            }
            else if (check.CheckControls("ادخل اسم العميل ", f.customerNameText1))
            {
                return;
            }
            else if (check.CheckControls("ادخل   رقم هاتف العميل ", f.customerPhoneText))
            {
                return;
            }
            else
            {
                pr = new SqlParameter[4];
                pr[0] = new SqlParameter("@tell_id", SqlDbType.Int);
                pr[0].Value = f.customersPhoneGridControlvi.GetRowCellValue(f.customersPhoneGridControlvi.FocusedRowHandle, "المعرف");
                pr[1] = new SqlParameter("@cust_id", SqlDbType.Int);
                pr[1].Value = f.customerNameText1.EditValue;
                pr[2] = new SqlParameter("@tell_number", SqlDbType.NVarChar);
                pr[2].Value = f.customerPhoneText.EditValue;
                pr[3] = new SqlParameter("@tell_notes", SqlDbType.NVarChar);
                pr[3].Value = f.customerPhoneNoteText.Text;
                con.ExecuteNonQuery("UPDATE_CUSTOMER_PHONE", pr);
                f.BindingContext[f.ta].EndCurrentEdit();
                Notification.MessageBoxInformation("تم التعديل بنجاح ");
                f.setbuton.ToggleButtons(false, f.edit_btn1, f.delete_btn1, f.back_btn1);
                f.setbuton.ToggleButtons(true, f.new_btn1);
                f.settext.readonley(true, f.customerNameTextSr, f.customerPhoneText, f.customerPhoneNoteText);
            }
        }

        /////////////////////////////////////////////////////////////

        public void SELECT_ALL_STORES(For_Stores f)
        {
            f.T = con.GetData("SELECT_ALL_STORES");
            f.storGridControl.DataSource = f.T;
            f.storeNumberText.DataBindings.Add("EditValue", f.T, "رقم المخزن");
            f.storeNameText.DataBindings.Add("Text", f.T, "اسم المخزن");
            f.storAdressText.DataBindings.Add("Text", f.T, "عنوان المخزن");
            f.storePhoneText.DataBindings.Add("EditValue", f.T, "رقم الهاتف");
        }
        public DataTable SELECT_ALL_STORES()
        {
            DataTable dt = con.GetData("SELECT_ALL_STORES");

            return dt;
        }

        public void ADD_STOR(For_Stores f)
        {
            int x = 0;
            for (int i = 0; i < f.storGridControlvi.RowCount; i++)
            {
                if (f.storeNameText.Text.Trim().Equals(f.storGridControlvi.GetRowCellValue(i, "اسم المخزن")))
                {
                    x = 1;
                    break;
                }

            }
            if (x == 1)
            {
                Notification.MessageBoxError(" يوجد مخزن بهذا الاسم  ");
            }
            else if (check.CheckControls(" ادخل اسم المخزن ", f.storeNameText))
            {
                return;
            }
            else if (check.CheckControls("ادخل  عنوان  المخزن  ", f.storAdressText))
            {
                return;
            }
            else if (check.CheckControls("ادخل رقم هاتف المخزن", f.storePhoneText))
            {
                return;
            }
            else
            {
                pr = new SqlParameter[3];
                pr[0] = new SqlParameter("@stor_name", SqlDbType.NVarChar);
                pr[0].Value = f.storeNameText.Text.Trim();
                pr[1] = new SqlParameter("@stor_address", SqlDbType.NVarChar);
                pr[1].Value = f.storAdressText.Text.Trim();
                pr[2] = new SqlParameter("@stor_phone", SqlDbType.NVarChar);
                pr[2].Value = f.storePhoneText.EditValue;
                con.ExecuteNonQuery("ADD_STOR", pr);
                f.BindingContext[f.T].EndCurrentEdit();
                Notification.MessageBoxInformation("تم الاظافة بنجاح ");
                f.settext.readonley(true, f.storeNameText, f.storAdressText, f.storePhoneText);
                f.setbuton.ToggleButtons(false, f.back_btn, f.add_btn, f.edit_btn, f.delete_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
                f.storGridControl.Enabled = true;

            }
        }

        public void DELETE_STOR(For_Stores f)
        {
            pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@stor_id", SqlDbType.Int);
            pr[0].Value = f.storeNumberText.EditValue;
            con.ExecuteNonQuery("DELETE_STOR", pr);
            f.BindingContext[f.T].RemoveAt(f.BindingContext[f.T].Position);
            Notification.MessageBoxInformation("تم الحذف بنجاح");
            f.settext.readonley(true, f.storeNameText, f.storAdressText, f.storePhoneText);
            f.setbuton.ToggleButtons(false, f.edit_btn, f.delete_btn, f.back_btn);
            f.setbuton.ToggleButtons(true, f.new_btn);
        }

        public void UPDATE_STOR(For_Stores f)
        {
            int x = 0;
            for (int i = 0; i < f.storGridControlvi.RowCount; i++)
            {
                if (f.storGridControlvi.GetRowCellValue(i, "رقم المخزن") == f.storGridControlvi.GetRowCellValue(f.storGridControlvi.FocusedRowHandle, "رقم المخزن"))
                {
                    continue;
                }
                else
                {
                    if (f.storeNameText.Text.Trim().Equals(f.storGridControlvi.GetRowCellValue(i, "اسم المخزن")))
                    {
                        x = 1;
                        break;
                    }
                }

            }
            if (x == 1)
            {
                Notification.MessageBoxError(" يوجد مخزن بهذا الاسم  ");
            }
            else if (check.CheckControls(" ادخل اسم المخزن ", f.storeNameText))
            {
                return;
            }
            else if (check.CheckControls("ادخل  عنوان  المخزن  ", f.storAdressText))
            {
                return;
            }
            else if (check.CheckControls("ادخل رقم هاتف المخزن", f.storePhoneText))
            {
                return;
            }
            else
            {
                pr = new SqlParameter[4];
                pr[0] = new SqlParameter("@stor_id", SqlDbType.Int);
                pr[0].Value = f.storeNumberText.EditValue;
                pr[1] = new SqlParameter("@stor_name", SqlDbType.NVarChar);
                pr[1].Value = f.storeNameText.Text.Trim();
                pr[2] = new SqlParameter("@stor_address", SqlDbType.NVarChar);
                pr[2].Value = f.storAdressText.Text.Trim();
                pr[3] = new SqlParameter("@stor_phone", SqlDbType.NVarChar);
                pr[3].Value = f.storePhoneText.EditValue;
                con.ExecuteNonQuery("UPDATE_STOR", pr);
                f.BindingContext[f.T].EndCurrentEdit();
                Notification.MessageBoxInformation("تم التعديل بنجاح");
                f.settext.readonley(true, f.storeNameText, f.storAdressText, f.storePhoneText);
                f.setbuton.ToggleButtons(false, f.back_btn, f.add_btn, f.edit_btn, f.delete_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
                f.storGridControl.Enabled = true;

            }
        }

        ///////////////////////////////////////////////////////////

        public void SELECT_ALL_SUPPLIERS(For_Supplier f)
        {
            f.T = con.GetData("SELECT_ALL_SUPPLIERS");
            f.supplierGridControl.DataSource = f.T;
            f.supplierNumberText.DataBindings.Add("EditValue", f.T, "رقم المورد");
            f.supplierNameText.DataBindings.Add("Text", f.T, "اسم المورد");
            f.supplierPhoneText.DataBindings.Add("EditValue", f.T, "رقم الهاتف");
            f.supplierEmailText.DataBindings.Add("Text", f.T, "البريد الالكتروني");
            f.supplierAddressText.DataBindings.Add("Text", f.T, "العنوان");
        }

        public DataTable SELECT_ALL_SUPPLIERS()
        {
            DataTable dt = con.GetData("SELECT_ALL_SUPPLIERS");
            return dt;
        }

        public DataTable GET_TYPE_INVOS()
        {
            DataTable dt = con.GetData("GET_TYPE_INVOS");
            return dt;
        }

        public void ADD_SUPPLIER(For_Supplier f)
        {
            int x = 0;

            for (int i = 0; i < f.supplierGridControlvi.RowCount; i++)
            {
                if (f.supplierNameText.Text.Trim().Equals(f.supplierGridControlvi.GetRowCellValue(i, "اسم المورد")))
                {
                    x = 1;
                    break;
                }

            }
            if (x == 1)
            {
                Notification.MessageBoxError(" يوجد مورد بهذا الاسم  ");
            }
            else if (check.CheckControls(" ادخل اسم المورد ", f.supplierNameText))
            {
                return;
            }
            else if (check.CheckControls("ادخل  رقم  الهاتف  ", f.supplierPhoneText))
            {
                return;
            }
            else if (check.CheckControls("ادخل عنوان المورد", f.supplierAddressText))
            {
                return;
            }
            else
            {
                pr = new SqlParameter[4];
                pr[0] = new SqlParameter("@sup_name", SqlDbType.NVarChar);
                pr[0].Value = f.supplierNameText.Text.Trim();
                pr[1] = new SqlParameter("@sup_phone", SqlDbType.NVarChar);
                pr[1].Value = f.supplierPhoneText.Text.Trim();
                pr[2] = new SqlParameter("@sup_email", SqlDbType.NVarChar);
                pr[2].Value = f.supplierEmailText.Text;
                pr[3] = new SqlParameter("@sup_address", SqlDbType.NVarChar);
                pr[3].Value = f.supplierAddressText.Text;
                con.ExecuteNonQuery("ADD_SUPPLIER", pr);
                f.BindingContext[f.T].EndCurrentEdit();
                Notification.MessageBoxInformation("تم الاضافة بنجاح");
                f.settext.readonley(true, f.supplierNameText, f.supplierPhoneText, f.supplierEmailText, f.supplierAddressText);
                f.setbuton.ToggleButtons(false, f.back_btn, f.add_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
                f.supplierGridControl.Enabled = true;
            }

        }

        public void DELETE_SUPPLIER(For_Supplier f)
        {
            pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@sup_id", SqlDbType.Int);
            pr[0].Value = f.supplierNumberText.Text;
            con.ExecuteNonQuery("DELETE_SUPPLIER", pr);
            f.BindingContext[f.T].RemoveAt(f.BindingContext[f.T].Position);
            Notification.MessageBoxInformation("تم الحذف بنجاح");
            f.settext.readonley(true, f.supplierNameText, f.supplierPhoneText, f.supplierEmailText, f.supplierAddressText);
            f.setbuton.ToggleButtons(false, f.back_btn, f.add_btn, f.edit_btn, f.delete_btn);
            f.setbuton.ToggleButtons(true, f.new_btn);
        }

        public void UPDATE_SUPPLIER(For_Supplier f)
        {
            int x = 0;

            for (int i = 0; i < f.supplierGridControlvi.RowCount; i++)
            {
                if (f.supplierGridControlvi.GetRowCellValue(i, "رقم المورد").ToString() == f.supplierGridControlvi.GetRowCellValue(f.supplierGridControlvi.FocusedRowHandle, "رقم المورد").ToString())
                {
                    continue;
                }
                else
                {
                    if (f.supplierNameText.Text.Trim().Equals(f.supplierGridControlvi.GetRowCellValue(i, "اسم المورد")))
                    {
                        x = 1;
                        break;
                    }
                }
            }
            if (x == 1)
            {
                Notification.MessageBoxError(" يوجد مورد بهذا الاسم  ");
            }
            else if (check.CheckControls(" ادخل اسم المورد ", f.supplierNameText))
            {
                return;
            }
            else if (check.CheckControls("ادخل  رقم  الهاتف  ", f.supplierPhoneText))
            {
                return;
            }
            else if (check.CheckControls("ادخل عنوان المورد", f.supplierAddressText))
            {
                return;
            }
            else
            {
                pr = new SqlParameter[5];
                pr[0] = new SqlParameter("@sup_id", SqlDbType.Int);
                pr[0].Value = f.supplierNumberText.Text;
                pr[1] = new SqlParameter("@sup_name", SqlDbType.NVarChar);
                pr[1].Value = f.supplierNameText.Text.Trim();
                pr[2] = new SqlParameter("@sup_phone", SqlDbType.NVarChar);
                pr[2].Value = f.supplierPhoneText.Text.Trim();
                pr[3] = new SqlParameter("@sup_email", SqlDbType.NVarChar);
                pr[3].Value = f.supplierEmailText.Text;
                pr[4] = new SqlParameter("@sup_address", SqlDbType.NVarChar);
                pr[4].Value = f.supplierAddressText.Text;
                con.ExecuteNonQuery("UPDATE_SUPPLIER", pr);
                f.BindingContext[f.T].EndCurrentEdit();
                Notification.MessageBoxInformation("تم التعديل بنجاح");
                f.settext.readonley(true, f.supplierNameText, f.supplierPhoneText, f.supplierEmailText, f.supplierAddressText);
                f.setbuton.ToggleButtons(false, f.back_btn, f.add_btn, f.edit_btn, f.delete_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
            }
        }

        //////////////////////////////////////////////////////////

        public void SELECT_PRODCTS_HAVE_UNITS(For_Pricing f)
        {
            f.productSearchText.Properties.DataSource = con.GetData("SELECT_PRODCTS_HAVE_UNITS");
            f.productSearchText.Properties.PopulateColumns();
            f.productSearchText.Properties.DisplayMember = "اسم المنتج";
            f.productSearchText.Properties.ValueMember = "رقم المنتج";
        }

        public void GET_PRODUCT_UNITS(For_Pricing f)
        {
            pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@pro_id", SqlDbType.Int);
            pr[0].Value = f.productSearchText.EditValue;
            f.productPriceGridControl.DataSource = con.GetData("GET_PRODUCT_UNITS", pr);
        }
        public DataTable GET_PRODUCT_UNITS_IDNAME(int pro_id)
        {
            pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@pro_id", SqlDbType.Int);
            pr[0].Value = pro_id;
            return con.GetData("GET_PRODUCT_UNITS_IDNAME", pr);
        }

        public void ADD_PRICE_TO_PRODUCT(For_Pricing f)
        {
            int x = 0;
            if (check.CheckControls("ادخل اسم  المنتج", f.productSearchText))
            {
                return;
            }
            for (int i = 0; i < f.productPriceGridControlvi.RowCount; i++)
            {
                if (String.IsNullOrEmpty(f.productPriceGridControlvi.GetRowCellValue(i, "سعر الشراء").ToString()) || (decimal)f.productPriceGridControlvi.GetRowCellValue(i, "سعر الشراء") <= 0)
                {
                    string name = f.productPriceGridControlvi.GetRowCellValue(i, "اسم الوحدة").ToString();
                    Notification.MessageBoxError("ادخل سعر الشراء للوحدة " + name + "");
                    return;
                }
                else if (String.IsNullOrEmpty(f.productPriceGridControlvi.GetRowCellValue(i, "سعر البيع").ToString()) || (decimal)f.productPriceGridControlvi.GetRowCellValue(i, "سعر البيع") <= 0)
                {
                    string name = f.productPriceGridControlvi.GetRowCellValue(i, "اسم الوحدة").ToString();
                    Notification.MessageBoxError("ادخل سعر البيع للوحدة " + name + "");
                    return;
                }
                else
                {
                    x = 1;
                }
            }
            if (x == 1)
            {

                for (int i = 0; i < f.productPriceGridControlvi.RowCount; i++)
                {
                    pr = new SqlParameter[4];
                    pr[0] = new SqlParameter("@pro_id", SqlDbType.Int);
                    pr[0].Value = f.productPriceGridControlvi.GetRowCellValue(0, "رقم المنتج");
                    pr[1] = new SqlParameter("@unit_id", SqlDbType.Int);
                    pr[2] = new SqlParameter("@unit_purchasing_price", SqlDbType.Decimal);
                    pr[3] = new SqlParameter("@unit_sale_price", SqlDbType.Decimal);
                    pr[1].Value = f.productPriceGridControlvi.GetRowCellValue(i, "رقم الوحدة");
                    pr[2].Value = (decimal)f.productPriceGridControlvi.GetRowCellValue(i, "سعر الشراء");
                    pr[3].Value = (decimal)f.productPriceGridControlvi.GetRowCellValue(i, "سعر البيع");
                    con.ExecuteNonQuery("ADD_PRICE_TO_PRODUCT", pr);
                }
                Notification.MessageBoxInformation("تم الحفظ بنجاح");
                f.settext.readonley(true, f.productSearchText);
                f.productPriceGridControlvi.SelectRows(0, f.productPriceGridControlvi.RowCount - 1);
                f.productPriceGridControlvi.DeleteSelectedRows();
                f.setbuton.ToggleButtons(false, f.back_btn, f.save_btn);
                f.setbuton.ToggleButtons(true, f.new_btn);
                f.productNonPriceCheck.Enabled = false;
                //f.productSearchText.EditValue = null;
            }
        }

        public void SELECT_PRODCTS_HAVE_UNITS_NON_PRICE(For_Pricing f)
        {
            f.productSearchText.Properties.DataSource = con.GetData("SELECT_PRODCTS_HAVE_UNITS_NON_PRICE");
            f.productSearchText.Properties.PopulateColumns();
            f.productSearchText.Properties.DisplayMember = "اسم المنتج";
            f.productSearchText.Properties.ValueMember = "رقم المنتج";
        }

        public DataTable GET_ALL_PROUDUCTS()
        {
            return con.GetData("GET_ALL_PROUDUCTS");
        }
        public DataTable SELECT_ALL_CURRENCIES()
        {
            return con.GetData("SELECT_ALL_CURRENCIES");
        }

        public void ADD_CURRENCY(For_Currency f)
        {

            int x, y, z; x = y = z = 0;
            if (check.CheckControls("ادخل اسم العملة", f.currencyNameText))
            {
                f.currencyNameText.Focus();
                return;
            }
            else if (check.CheckControls("ادخل اختصارالعملة", f.shortcutCurrencyText))
            {
                f.shortcutCurrencyText.Focus();
                return;
            }
            else
            {
                try
                {
                    for (int i = 0; i < f.currenceisGridControlvi.RowCount; i++)
                    {
                        if (f.currencyNameText.Text.Equals(f.currenceisGridControlvi.GetRowCellValue(i, "اسم العملة").ToString()))
                        {
                            x = 1;
                            break;
                        }
                        if (f.shortcutCurrencyText.Text.Equals(f.currenceisGridControlvi.GetRowCellValue(i, "اختصار العملة").ToString()))
                        {
                            y = 1;
                            break;
                        }
                    }
                }
                catch { }

            }

            if (x == 1)
            {
                Notification.MessageBoxError("توجد عملة بهذا الاسم مسبقا");
                f.currencyNameText.Focus();
                return;
            }
            else if (y == 1)
            {
                Notification.MessageBoxError("يوجد هذا الاختصار من قبل");
                f.shortcutCurrencyText.Focus();
                return;
            }
            else if (check.CheckControls("ادخل اسم العملة", f.currencyNameText))
            {
                f.currencyNameText.Focus();
                return;
            }
            else if (check.CheckControls("ادخل اختصارالعملة", f.shortcutCurrencyText))
            {
                f.shortcutCurrencyText.Focus();
                return;
            }
            else if (f.currrencyRadioGroup.SelectedIndex == -1)
            {
                Notification.MessageBoxError("يجب اختيار نوع العملة");
            }
            else if (f.currrencyRadioGroup.SelectedIndex == 1)
            {
                if (check.CheckControls("ادخل سعر التحويل", f.conversionPriceText))
                {
                    f.conversionPriceText.Focus();
                    return;
                }
                else if (check.CheckControls("ادخل اعلى سعر تحويل", f.topConversionPriceText))
                {
                    f.topConversionPriceText.Focus();
                    return;
                }
                else if (check.CheckControls("ادخل اقل سعر تحويل", f.lowestConversionPriceText))
                {
                    f.lowestConversionPriceText.Focus();
                }
                else if ((decimal)f.topConversionPriceText.EditValue <= (decimal)f.conversionPriceText.EditValue)
                {
                    Notification.MessageBoxWarning("يجب ان يكون اعلى سغر تحويل اكبر من سعر العملة");
                    f.topConversionPriceText.Focus();
                    return;
                }
                else if ((decimal)f.conversionPriceText.EditValue <= 0)
                {
                    Notification.MessageBoxWarning("لا يجب ان يكون سعر التحويل صفر او اقل من الصفر ");
                    f.conversionPriceText.Focus();
                    return;
                }
                else if ((decimal)f.lowestConversionPriceText.EditValue >= (decimal)f.conversionPriceText.EditValue)
                {
                    Notification.MessageBoxWarning("يجب ان يكون ادنى سعر تحويل اقل من سعر العملة");
                    f.lowestConversionPriceText.Focus();
                    return;
                }
                else
                {
                    pr = new SqlParameter[6];
                    pr[0] = new SqlParameter("@curr_name", SqlDbType.NVarChar);
                    pr[0].Value = f.currencyNameText.Text;
                    pr[1] = new SqlParameter("@curr_shortcut", SqlDbType.NVarChar);
                    pr[1].Value = f.shortcutCurrencyText.Text;
                    pr[2] = new SqlParameter("@curr_type", SqlDbType.NVarChar);
                    pr[2].Value = f.currrencyRadioGroup.EditValue;
                    pr[3] = new SqlParameter("@curr_price", SqlDbType.Decimal);
                    pr[4] = new SqlParameter("@curr_top_price", SqlDbType.Decimal);
                    pr[5] = new SqlParameter("@curr_low_price", SqlDbType.Decimal);
                    pr[3].Value = f.conversionPriceText.EditValue;
                    pr[4].Value = f.topConversionPriceText.EditValue;
                    pr[5].Value = f.lowestConversionPriceText.EditValue;
                    con.ExecuteNonQuery("ADD_CURRENCY", pr);
                    Notification.MessageBoxInformation("تم الاضافة بنجاح");
                    f.BindingContext[f.T].EndCurrentEdit();
                    f.settext.readonley(true, f.currencyNameText, f.shortcutCurrencyText, f.currrencyRadioGroup, f.conversionPriceText, f.topConversionPriceText, f.lowestConversionPriceText);
                    f.currencyNameText.Focus();
                    f.setbotton.ToggleButtons(false, f.add_btn, f.back_btn);
                    f.setbotton.ToggleButtons(true, f.new_btn);
                    f.currenceisGridControl.RefreshDataSource();
                    f.currenceisGridControl.Enabled = true;
                }
            }
            else
            {
                pr = new SqlParameter[6];
                pr[0] = new SqlParameter("@curr_name", SqlDbType.NVarChar);
                pr[0].Value = f.currencyNameText.Text;
                pr[1] = new SqlParameter("@curr_shortcut", SqlDbType.NVarChar);
                pr[1].Value = f.shortcutCurrencyText.Text;
                pr[2] = new SqlParameter("@curr_type", SqlDbType.NVarChar);
                pr[2].Value = f.currrencyRadioGroup.EditValue;
                pr[3] = new SqlParameter("@curr_price", SqlDbType.Decimal);
                pr[4] = new SqlParameter("@curr_top_price", SqlDbType.Decimal);
                pr[5] = new SqlParameter("@curr_low_price", SqlDbType.Decimal);
                pr[3].Value = 1;
                pr[4].Value = 1;
                pr[5].Value = 1;
                con.ExecuteNonQuery("ADD_CURRENCY", pr);
                Notification.MessageBoxInformation("تم الاضافة بنجاح");
                f.BindingContext[f.T].EndCurrentEdit();
                f.settext.readonley(true, f.currencyNameText, f.shortcutCurrencyText, f.currrencyRadioGroup, f.conversionPriceText, f.topConversionPriceText, f.lowestConversionPriceText);
                f.currencyNameText.Focus();
                f.setbotton.ToggleButtons(false, f.add_btn, f.back_btn);
                f.setbotton.ToggleButtons(true, f.new_btn);
                f.currenceisGridControl.RefreshDataSource();
                f.currenceisGridControl.Enabled = true;
            }
        }
        public void DELETE_CURRENCY(For_Currency f)
        {
            pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@curr_id", SqlDbType.Int);
            pr[0].Value = (int)f.currenceisGridControlvi.GetRowCellValue(f.currenceisGridControlvi.FocusedRowHandle, "رقم العملة");
            con.ExecuteNonQuery("DELETE_CURRENCY", pr);
            f.BindingContext[f.T].RemoveAt(f.BindingContext[f.T].Position);
            Notification.MessageBoxInformation("تم الحذف بنجاح");
            f.settext.readonley(true, f.currencyNameText, f.shortcutCurrencyText, f.currrencyRadioGroup, f.conversionPriceText, f.topConversionPriceText, f.lowestConversionPriceText);
            f.currencyNameText.Focus();
            f.setbotton.ToggleButtons(false, f.add_btn, f.back_btn, f.delete_btn, f.edit_btn);
            f.setbotton.ToggleButtons(true, f.new_btn);
        }

        public void UPDATE_CURRNCY(For_Currency f)
        {
            int x, y, z; x = y = z = 0;
            if (check.CheckControls("ادخل اسم العملة", f.currencyNameText))
            {
                f.currencyNameText.Focus();
                return;
            }
            else if (check.CheckControls("ادخل اختصارالعملة", f.shortcutCurrencyText))
            {
                f.shortcutCurrencyText.Focus();
                return;
            }
            else
            {
                try
                {
                    for (int i = 0; i < f.currenceisGridControlvi.RowCount; i++)
                    {
                        if ((f.currenceisGridControlvi.GetRowCellValue(i, "اسم العملة").Equals(f.currenceisGridControlvi.GetRowCellValue(f.currenceisGridControlvi.FocusedRowHandle, "اسم العملة")) && f.currenceisGridControlvi.GetRowCellValue(i, "اختصار العملة").Equals(f.currenceisGridControlvi.GetRowCellValue(f.currenceisGridControlvi.FocusedRowHandle, "اختصار العملة"))))
                        {
                            continue;
                        }
                        else
                        {
                            if (f.currencyNameText.Text.Equals(f.currenceisGridControlvi.GetRowCellValue(i, "اسم العملة")))
                            {
                                x = 1;
                                break;
                            }
                            if (f.shortcutCurrencyText.Text.Equals(f.currenceisGridControlvi.GetRowCellValue(i, "اختصار العملة")))
                            {
                                y = 1;
                                break;
                            }
                        }

                    }
                }
                catch { }

            }

            if (x == 1)
            {
                Notification.MessageBoxError("توجد عملة بهذا الاسم مسبقا");
                f.currencyNameText.Focus();
                return;
            }
            else if (y == 1)
            {
                Notification.MessageBoxError("يوجد هذا الاختصار من قبل");
                f.shortcutCurrencyText.Focus();
                return;
            }
            else if (check.CheckControls("ادخل اسم العملة", f.currencyNameText))
            {
                f.currencyNameText.Focus();
                return;
            }
            else if (check.CheckControls("ادخل اختصارالعملة", f.shortcutCurrencyText))
            {
                f.shortcutCurrencyText.Focus();
                return;
            }
            else if (f.currrencyRadioGroup.SelectedIndex == -1)
            {
                Notification.MessageBoxError("يجب اختيار نوع العملة");
            }
            else if (f.currrencyRadioGroup.SelectedIndex == 1)
            {
                if (check.CheckControls("ادخل سعر التحويل", f.conversionPriceText))
                {
                    f.conversionPriceText.Focus();
                    return;
                }
                else if (check.CheckControls("ادخل اعلى سعر تحويل", f.topConversionPriceText))
                {
                    f.topConversionPriceText.Focus();
                    return;
                }
                else if (check.CheckControls("ادخل اقل سعر تحويل", f.lowestConversionPriceText))
                {
                    f.lowestConversionPriceText.Focus();
                }
                else if ((decimal)f.topConversionPriceText.EditValue <= (decimal)f.conversionPriceText.EditValue)
                {
                    Notification.MessageBoxWarning("يجب ان يكون اعلى سغر تحويل اكبر من سعر العملة");
                    f.topConversionPriceText.Focus();
                    return;
                }
                else if ((decimal)f.conversionPriceText.EditValue <= 0)
                {
                    Notification.MessageBoxWarning("لا يجب ان يكون سعر التحويل صفر او اقل من الصفر ");
                    f.conversionPriceText.Focus();
                    return;
                }
                else if ((decimal)f.lowestConversionPriceText.EditValue >= (decimal)f.conversionPriceText.EditValue)
                {
                    Notification.MessageBoxWarning("يجب ان يكون ادنى سعر تحويل اقل من سعر العملة");
                    f.lowestConversionPriceText.Focus();
                    return;
                }
                else
                {
                    pr = new SqlParameter[7];
                    pr[0] = new SqlParameter("curr_id", SqlDbType.Int);
                    pr[0].Value = (int)f.currenceisGridControlvi.GetRowCellValue(f.currenceisGridControlvi.FocusedRowHandle, "رقم العملة");
                    pr[1] = new SqlParameter("@curr_name", SqlDbType.NVarChar);
                    pr[1].Value = f.currencyNameText.Text;
                    pr[2] = new SqlParameter("@curr_shortcut", SqlDbType.NVarChar);
                    pr[2].Value = f.shortcutCurrencyText.Text;
                    pr[3] = new SqlParameter("@curr_type", SqlDbType.NVarChar);
                    pr[3].Value = f.currrencyRadioGroup.EditValue;
                    pr[4] = new SqlParameter("@curr_price", SqlDbType.Decimal);
                    pr[5] = new SqlParameter("@curr_top_price", SqlDbType.Decimal);
                    pr[6] = new SqlParameter("@curr_low_price", SqlDbType.Decimal);
                    pr[4].Value = f.conversionPriceText.EditValue;
                    pr[5].Value = f.topConversionPriceText.EditValue;
                    pr[6].Value = f.lowestConversionPriceText.EditValue;
                    con.ExecuteNonQuery("UPDATE_CURRNCY", pr);
                    Notification.MessageBoxInformation("تم التعديل بنجاح");
                    f.BindingContext[f.T].EndCurrentEdit();
                    f.settext.readonley(true, f.currencyNameText, f.shortcutCurrencyText, f.currrencyRadioGroup, f.conversionPriceText, f.topConversionPriceText, f.lowestConversionPriceText);
                    f.currencyNameText.Focus();
                    f.setbotton.ToggleButtons(false, f.add_btn, f.back_btn);
                    f.setbotton.ToggleButtons(true, f.new_btn);
                    f.currenceisGridControl.RefreshDataSource();
                    f.currenceisGridControl.Enabled = true;
                }
            }
            else
            {
                pr = new SqlParameter[7];
                pr[0] = new SqlParameter("curr_id", SqlDbType.Int);
                pr[0].Value = (int)f.currenceisGridControlvi.GetRowCellValue(f.currenceisGridControlvi.FocusedRowHandle, "رقم العملة");
                pr[1] = new SqlParameter("@curr_name", SqlDbType.NVarChar);
                pr[1].Value = f.currencyNameText.Text;
                pr[2] = new SqlParameter("@curr_shortcut", SqlDbType.NVarChar);
                pr[2].Value = f.shortcutCurrencyText.Text;
                pr[3] = new SqlParameter("@curr_type", SqlDbType.NVarChar);
                pr[3].Value = f.currrencyRadioGroup.EditValue;
                pr[4] = new SqlParameter("@curr_price", SqlDbType.Decimal);
                pr[5] = new SqlParameter("@curr_top_price", SqlDbType.Decimal);
                pr[6] = new SqlParameter("@curr_low_price", SqlDbType.Decimal);
                pr[4].Value = 1;
                pr[5].Value = 1;
                pr[6].Value = 1;
                con.ExecuteNonQuery("UPDATE_CURRNCY", pr);
                Notification.MessageBoxInformation("تم التعديل بنجاح");
                f.BindingContext[f.T].EndCurrentEdit();
                f.settext.readonley(true, f.currencyNameText, f.shortcutCurrencyText, f.currrencyRadioGroup, f.conversionPriceText, f.topConversionPriceText, f.lowestConversionPriceText);
                f.currencyNameText.Focus();
                f.setbotton.ToggleButtons(false, f.add_btn, f.back_btn);
                f.setbotton.ToggleButtons(true, f.new_btn);
                f.currenceisGridControl.RefreshDataSource();
                f.currenceisGridControl.Enabled = true;
            }
        }

    }

}

