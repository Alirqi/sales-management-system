using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesSystem.CLASSES.FormFunction
{
    class FormsSetup
    {

        public void HandleForm(Form form, XtraTabControl tabControl=null)
        {
            IFormDisplay formDisplay = GetFormDisplay();


            if (form is FR.For_Main fm)
            {
                SetFonts(fm);                
                fm.Show();
            }
            if (form is FR.For_Options fo)
            {
                SetFonts(fo);
                if (Properties.Settings.Default.ScreenDisplay)
                {
                    formDisplay.ShowFormDialog(fo);
                }
                else
                {
                    formDisplay.AddFormToTabControl(fo, tabControl);
                }
            }
            else if (form is FR.For_ConnectDb fc)
            {

                if (Properties.Settings.Default.ScreenDisplay)
                {
                    formDisplay.ShowFormDialog(fc);
                }
                else
                {
                    formDisplay.AddFormToTabControl(fc, tabControl);
                }
            }
            else if (form is FR.For_Category fca)
            {
                SetFonts(fca);
                if (Properties.Settings.Default.ScreenDisplay)
                {
                    formDisplay.ShowFormDialog(fca);
                }
                else
                {
                    formDisplay.AddFormToTabControl(fca, tabControl);
                }
            }
            else if (form is FR.For_Units fu)
            {
                SetFonts(fu);
                if (Properties.Settings.Default.ScreenDisplay)
                {
                    formDisplay.ShowFormDialog(fu);
                }
                else
                {
                    formDisplay.AddFormToTabControl(fu, tabControl);
                }
            }
            else if (form is FR.For_Product fp)
            {
                SetFonts(fp);
                if (Properties.Settings.Default.ScreenDisplay)
                {
                    formDisplay.ShowFormDialog(fp);
                }
                else
                {
                    formDisplay.AddFormToTabControl(fp, tabControl);
                }
            }
            else if (form is FR.For_Customers fcu)
            {
                SetFonts(fcu);
                if (Properties.Settings.Default.ScreenDisplay)
                {
                    formDisplay.ShowFormDialog(fcu);
                }
                else
                {
                    formDisplay.AddFormToTabControl(fcu, tabControl);
                }
            }
            else if (form is FR.For_Supplier fsup)
            {
                SetFonts(fsup);
                if (Properties.Settings.Default.ScreenDisplay)
                {
                    formDisplay.ShowFormDialog(fsup);
                }
                else
                {
                    formDisplay.AddFormToTabControl(fsup, tabControl);
                }
            }
            else if (form is FR.For_Stores fsto)
            {
                SetFonts(fsto);
                if (Properties.Settings.Default.ScreenDisplay)
                {
                    formDisplay.ShowFormDialog(fsto);
                }
                else
                {
                    formDisplay.AddFormToTabControl(fsto, tabControl);
                }
            }
            else if (form is FR.For_Pricing fpric)
            {
                SetFonts(fpric);
                if (Properties.Settings.Default.ScreenDisplay)
                {
                    formDisplay.ShowFormDialog(fpric);
                }
                else
                {
                    formDisplay.AddFormToTabControl(fpric, tabControl);
                }
            }
            else if (form is FR.For_Accounts facc)
            {
                SetFonts(facc);
                if (Properties.Settings.Default.ScreenDisplay)
                {
                    formDisplay.ShowFormDialog(facc);
                }
                else
                {
                    formDisplay.AddFormToTabControl(facc, tabControl);
                }
            }
            else if (form is FR.For_Mang_Users fmgus)
            {
                SetFonts(fmgus);
                if (Properties.Settings.Default.ScreenDisplay)
                {
                    formDisplay.ShowFormDialog(fmgus);
                }
                else
                {
                    formDisplay.AddFormToTabControl(fmgus, tabControl);
                }
            }
            else if (form is FR.For_Currency fcurr)
            {
                SetFonts(fcurr);
                if (Properties.Settings.Default.ScreenDisplay)
                {
                    formDisplay.ShowFormDialog(fcurr);
                }
                else
                {
                    formDisplay.AddFormToTabControl(fcurr, tabControl);
                }
            }
        }

        public static void SetFonts(Form form)
        {
            if (form is FR.For_Main fm)
            {
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fm.ribbonPageHome, fm.ribbonPage_Sales, fm.ribbonPage_Purchase, fm.ribbonPage_WareHouses, fm.ribbonPage_Accounts, fm.barButtonItemHome, fm.barButtonItemCategory, fm.barButtonItemUnits, fm.barButtonItemProducts, fm.barButtonItemLgin, fm.barButtonItemLgout, fm.barButtonItemSetting, fm.barSubItemSetting, fm.barButtonItemCustomers, fm.barButtonItemSuppliers, fm.barButtonItemStor, fm.barButtonItemPrcing, fm.xtraTabPageHome,fm.barButtonItemAccounting,fm.barButtonItemUsers,fm.ribbonPage_MangSystem,fm.barButtonItemCurrencies);
            }

            if (form is FR.For_Options fo)
            {
                CLASSES.Setting.SetFonts.SetFont(fo.treeList1, fo.simpleButton_Ok, fo.simpleButton_Concel, fo.tex_Filter_Tree);               
            }
           

            if (form is FR.For_Category fca)
            {
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fca.layoutControlGroup1, fca.layoutControlGroup2, fca.layoutControlGroup3, fca.new_btn, fca.back_btn, fca.add_btn, fca.delete_btn, fca.edit_btn, fca.layoutControlItem1, fca.layoutControlItem2, fca.categoryDetailsText, fca.categoryNameText);
               
            }
            if (form is FR.For_Units fu)
            {
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fu.new_btn, fu.back_btn, fu.add_btn, fu.delete_btn,fu.edit_btn, fu.layoutControlItem1, fu.layoutControlGroup1, fu.layoutControlGroup2, fu.layoutControlGroup3, fu.layoutControlGroup2, fu.unitNameText);

            }
            if (form is FR.For_Product fp)
            {
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fp.new_btn, fp.back_btn, fp.add_btn, fp.delete_btn, fp.edit_btn,fp.getImageBtn, fp.new_btn1, fp.back_btn1, fp.add_btn1, fp.delete_btn1, fp.edit_btn1, fp.layoutControlItem1, fp.layoutControlItem2, fp.layoutControlItem3, fp.layoutControlItem4, fp.layoutControlItem21, fp.layoutControlItem6, fp.layoutControlItem8, fp.layoutControlItem22, fp.productNumberText, fp.productCodText, fp.categoryNameText, fp.productNameText, fp.productNameTextSr, fp.productNameText1, fp.productUnitsText, fp.productUnitNumber, fp.layoutControlGroup8, fp.layoutControlGroup2);              

            }
            if (form is FR.For_Customers fcu)
            {
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fcu.new_btn, fcu.back_btn, fcu.add_btn, fcu.delete_btn, fcu.edit_btn, fcu.getImageBtn, fcu.new_btn1, fcu.back_btn1, fcu.add_btn1, fcu.delete_btn1, fcu.edit_btn1, fcu.layoutControlItem1, fcu.layoutControlItem2, fcu.layoutControlItem3, fcu.layoutControlItem4, fcu.layoutControlItem8, fcu.layoutControlItem2, fcu.layoutControlItem23, fcu.layoutControlItem9, fcu.layoutControlItem10, fcu.layoutControlItem5, fcu.customerNumberText, fcu.customerNameText, fcu.customerAdressText, fcu.customerGmailText, fcu.customerStorAdressText, fcu.customerPhoneNoteText, fcu.customerPhoneText, fcu.customerNameText1, fcu.layoutControlGroup4, fcu.layoutControlGroup1, fcu.layoutControlGroup5, fcu.layoutControlGroup2);
               
            }
            if (form is FR.For_Supplier fsup)
            {
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fsup.new_btn, fsup.back_btn, fsup.add_btn, fsup.delete_btn, fsup.edit_btn, fsup.layoutControlItem1, fsup.layoutControlItem2, fsup.layoutControlItem3, fsup.layoutControlItem4, fsup.layoutControlItem2, fsup.layoutControlItem11, fsup.supplierPhoneText, fsup.supplierNumberText, fsup.supplierNameText, fsup.supplierEmailText, fsup.supplierAddressText, fsup.layoutControlGroup1, fsup.layoutControlGroup2, fsup.layoutControlGroup3);
              
            }
            if (form is FR.For_Stores fsto)
            {
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fsto.new_btn, fsto.back_btn, fsto.add_btn, fsto.delete_btn, fsto.edit_btn);
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fsto.layoutControlItem1, fsto.layoutControlItem2, fsto.layoutControlItem3, fsto.layoutControlItem4, fsto.layoutControlItem2);
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fsto.storePhoneText, fsto.storeNumberText, fsto.storeNameText, fsto.storAdressText);
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fsto.layoutControlGroup1, fsto.layoutControlGroup2, fsto.layoutControlGroup3);
            }
            if (form is FR.For_Pricing fpric)
            {
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fpric.new_btn, fpric.back_btn, fpric.save_btn);
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fpric.layoutControlItem1);
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fpric.productSearchText);
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fpric.layoutControlGroup1, fpric.layoutControlGroup2, fpric.layoutControlGroup3);
            }
            if (form is FR.For_Accounts facc)
            {
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(facc.new_btn, facc.back_btn, facc.add_btn, facc.delete_btn,facc.edit_btn); 
            }
            if (form is FR.For_Mang_Users fmgus)
            {
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fmgus.new_btn, fmgus.back_btn, fmgus.add_btn, fmgus.delete_btn, fmgus.edit_btn);
            }
            if (form is FR.For_Currency fcurr)
            {
                SalesSystem.CLASSES.Setting.SetFonts.SetFont(fcurr.new_btn, fcurr.back_btn, fcurr.add_btn, fcurr.delete_btn, fcurr.edit_btn);
            }
        }       

        private IFormDisplay GetFormDisplay()
        {
            return new CLASSES.FormFunction.ViewForms();
        }
    }


}
