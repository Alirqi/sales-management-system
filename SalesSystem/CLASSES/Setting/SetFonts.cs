using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraTreeList;


namespace SalesSystem.CLASSES.Setting
{
    class SetFonts
    {
        public static System.Drawing.Font fotns()
        {
            System.Drawing.FontStyle fontStyle = Properties.Settings.Default.fontBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular;

            if (Properties.Settings.Default.fontItalic)
            {
                fontStyle |= System.Drawing.FontStyle.Italic;
            }

            if (Properties.Settings.Default.fontUnderline)
            {
                fontStyle |= System.Drawing.FontStyle.Underline;
            }

            System.Drawing.Font newFont = new System.Drawing.Font(Properties.Settings.Default.fontName, Properties.Settings.Default.fontSize, fontStyle);

            return newFont;

        }

        public static void SetFont(params object[] controls)
        {
            foreach (var control in controls)
            {
                if (control is BarItem bari)
                {
                    bari.Appearance.Font = fotns();
                }

                if (control is LayoutControlGroup layoutcg)
                {
                    layoutcg.AppearanceGroup.Font = fotns();
                }
                if (control is LayoutControlItem layoutc)
                {
                    layoutc.AppearanceItemCaption.Font = fotns();
                }
                if (control is DevExpress.XtraTab.XtraTabPage tabpag)
                {
                    tabpag.Appearance.Header.Font = fotns();
                }
                if (control is TextEdit ted)
                {
                    
                    ted.Properties.Appearance.Font = fotns();
                }
                if (control is SimpleButton sbtn)
                {
                    sbtn.Appearance.Font = fotns();
                }
                if (control is RibbonPage ripag)
                {
                    ripag.Appearance.Font = fotns();
                }
                if (control is TreeList tli)
                {
                    tli.Appearance.Caption.Font = fotns();
                }

            }
        }

        //public static void SetFont(params BarItem[] items)
        //{
        //    foreach (var item in items)
        //    {
        //        item.Appearance.Font = fotns();
        //    }
        //}

        //public static void SetFont(params LayoutControlGroup[] items)
        //{
        //    foreach (var item in items)
        //    {
        //        item.AppearanceGroup.Font = fotns();
        //    }
        //}

        //public static void SetFont(params LayoutControlItem[] items)
        //{
        //    foreach (var item in items)
        //    {
        //        item.AppearanceItemCaption.Font = fotns();
        //    }
        //}

        //public static void SetFont(params DevExpress.XtraTab.XtraTabPage[] items)
        //{
        //    foreach (var item in items)
        //    {
        //        item.Appearance.Header.Font = fotns();
        //    }
        //}

        //public static void SetFont(params TextEdit[] items)
        //{
        //    foreach (var item in items)
        //    {
        //        item.Properties.Appearance.Font = fotns();
        //    }
        //}
        //public static void SetFont(params SimpleButton[] items)
        //{
        //    foreach (var item in items)
        //    {
        //        item.Appearance.Font = fotns();
        //    }
        //}

        //public static void SetFont(params RibbonPage[] pages)
        //{
        //    foreach (var page in pages)
        //    {
        //        page.Appearance.Font = fotns();
        //    }
        //}

        //public static void SetFont(params TreeList[] pages)
        //{
        //    foreach (var page in pages)
        //    {
        //        page.Appearance.Caption.Font = fotns();
        //    }
        //}
    }
}
