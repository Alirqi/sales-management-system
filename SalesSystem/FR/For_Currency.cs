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
using DevExpress.XtraLayout.Utils;
using SalesSystem.FormFunction;
using SalesSystem.CLASSES.SysNotification;

namespace SalesSystem.FR
{
    public partial class For_Currency : DevExpress.XtraEditors.XtraForm
    {
        public DataTable T;
        process pross = new process();
       public CLASSES.Checkups.ReadOnley settext = new CLASSES.Checkups.ReadOnley();
        public CLASSES.Checkups.SetButtons setbotton = new CLASSES.Checkups.SetButtons();

        public For_Currency()
        {
            InitializeComponent();
        }

        private void For_Currency_Load(object sender, EventArgs e)
        {
            T = pross.SELECT_ALL_CURRENCIES();
            currenceisGridControl.DataSource = T;
            currencyNameText.DataBindings.Add("Text", T, "اسم العملة");
            shortcutCurrencyText.DataBindings.Add("Text", T, "اختصار العملة");
            conversionPriceText.DataBindings.Add("Editvalue", T, "سعر التحويل");
            topConversionPriceText.DataBindings.Add("Editvalue", T, "اعلى سعر تحويل");
            lowestConversionPriceText.DataBindings.Add("Editvalue", T, "ادنى سعر تحويل");
            currrencyRadioGroup.DataBindings.Add("Editvalue", T, "نوع العملة");
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();
        }

        private void CurrrencyRadioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currrencyRadioGroup.SelectedIndex == 1)
            {
                topConversionPriceLayout.Visibility = LayoutVisibility.Always;
                conversionPriceLayout.Visibility = LayoutVisibility.Always;
                lowestConversionPriceTLayout.Visibility = LayoutVisibility.Always;

            }
            else if(currrencyRadioGroup.SelectedIndex == 0)
            {
                topConversionPriceLayout.Visibility = LayoutVisibility.Never;
                conversionPriceLayout.Visibility = LayoutVisibility.Never;
                lowestConversionPriceTLayout.Visibility = LayoutVisibility.Never;
                try
                {
                    for (int i = 0; i < currenceisGridControlvi.RowCount; i++)
                    {
                        if (currenceisGridControlvi.GetRowCellValue(i, "نوع العملة").ToString().Equals("Local") && currrencyRadioGroup.ReadOnly!=true && !currenceisGridControlvi.GetRowCellValue(i, "نوع العملة").Equals(currenceisGridControlvi.GetRowCellValue(currenceisGridControlvi.FocusedRowHandle, "نوع العملة")))
                        {
                            Notification.MessageBoxError("يوجد عملة محلية مسبقاً");
                            currrencyRadioGroup.SelectedIndex = 1;
                            break;
                        }
                    }
                }
                catch { } 
            }
           
        }
        private void TopConversionPriceText_Leave(object sender, EventArgs e)
        {
            if(!topConversionPriceText.Text.Equals(""))
            {
                try
                {
                    if ((decimal)topConversionPriceText.EditValue <= (decimal)conversionPriceText.EditValue)
                    {
                        Notification.MessageBoxWarning("يجب ان تكون القيمة اعلى من سعر العملة");
                        topConversionPriceText.Focus();
                    }
                }
                catch { }
               
            }
           
        }

        private void ConversionPriceText_Leave(object sender, EventArgs e)
        {
            if(!conversionPriceText.Text.Equals(""))
            {
                try
                {
                    if ((decimal)conversionPriceText.EditValue <= 0)
                    {
                        Notification.MessageBoxWarning("لا يجب ان تكون القيمة صفر او اقل من الصفر ");
                        conversionPriceText.ResetText();
                        conversionPriceText.Focus();
                        return;
                    }
                }
                catch { }
               
            }
        }

        private void LowestConversionPriceText_Leave(object sender, EventArgs e)
        {
            if(!lowestConversionPriceText.Text.Equals(""))
            {
                try
                {
                    if ((decimal)lowestConversionPriceText.EditValue >= (decimal)conversionPriceText.EditValue)
                    {
                        Notification.MessageBoxWarning("يجب ان تكون القيمة اقل من سعر العملة");
                        lowestConversionPriceText.Focus();
                    }
                }
                catch
                {

                }
               
            }
            
        }
        private void New_btn_Click(object sender, EventArgs e)
        {

            topConversionPriceLayout.Visibility = LayoutVisibility.Never;
            conversionPriceLayout.Visibility = LayoutVisibility.Never;
            lowestConversionPriceTLayout.Visibility = LayoutVisibility.Never;
            currencyNameText.Focus();
            settext.readonley(false, currencyNameText, shortcutCurrencyText, currrencyRadioGroup, conversionPriceText, topConversionPriceText, lowestConversionPriceText);
            setbotton.ToggleButtons(true, add_btn, back_btn);
            setbotton.ToggleButtons(false, new_btn);
            BindingContext[T].AddNew();
            currenceisGridControl.Enabled = false;
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {

            pross.ADD_CURRENCY(this);
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            BindingContext[T].CancelCurrentEdit();
            currencyNameText.Focus();
            setbotton.ToggleButtons(false, add_btn, back_btn,edit_btn,delete_btn);
            setbotton.ToggleButtons(true, new_btn);
            currenceisGridControl.Enabled = true;
            settext.readonley(true, currencyNameText, shortcutCurrencyText, currrencyRadioGroup, conversionPriceText, topConversionPriceText, lowestConversionPriceText);
            currenceisGridControl.Enabled = true;
           
        }

        private void CurrenceisGridControl_DoubleClick(object sender, EventArgs e)
        {
            currencyNameText.Focus();
            settext.readonley(false, currencyNameText, shortcutCurrencyText, currrencyRadioGroup, conversionPriceText, topConversionPriceText, lowestConversionPriceText);
            setbotton.ToggleButtons(true, delete_btn, edit_btn,back_btn);
            setbotton.ToggleButtons(false, new_btn);
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            string name = currenceisGridControlvi.GetRowCellValue(currenceisGridControlvi.FocusedRowHandle, "اسم العملة").ToString();
            if (Notification.MessageBoxQuestion("هل تريد بالفعل حذف العملة "+name+"").Equals(DialogResult.Yes))
            {
                pross.DELETE_CURRENCY(this);
            }
        }

        private void Edit_btn_Click(object sender, EventArgs e)
        {
            pross.UPDATE_CURRNCY(this);
        }

        private void Delete_btn1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string name = currenceisGridControlvi.GetRowCellValue(currenceisGridControlvi.FocusedRowHandle, "اسم العملة").ToString();
            if (Notification.MessageBoxQuestion("هل تريد بالفعل حذف العملة " + name + "").Equals(DialogResult.Yes))
            {
                pross.DELETE_CURRENCY(this);
            }
        }
    }
}