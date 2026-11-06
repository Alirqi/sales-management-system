using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;


namespace SalesSystem.CLASSES.Initialization
{
    class AppearanceFonts
    {

        public static string Name = Properties.Settings.Default.fontName;

        [Category("FontSetting")]
        [Description("The setting of the Fonts.")]
        [TypeConverter(typeof(MyPropertyTypeConverter))]
        [DefaultValue("Default Value")]
        public string FontName
        {
            get { return Name; }
            set { Name = value; }
        }            

        public static float Size = Properties.Settings.Default.fontSize;

        [Category("FontSize")]
        [Description("The name of the person.")]
        public float FontSize
        {
            get { return Size; }
            set { Size = value; }
        }


        public static bool fontBold = Properties.Settings.Default.fontBold;

        [Category("FontSetting")]
        [Description("The setting of the Fonts.")]
        public bool Bold
        {
            get { return fontBold; }
            set { fontBold = value; }
        }

        public static bool fontItalic = Properties.Settings.Default.fontItalic;
        [Category("FontSetting")]
        [Description("The setting of the Fonts.")]
        public bool Italic
        {
            get { return fontItalic; }
            set { fontItalic = value; }
        }


        public static bool fontUnderline = Properties.Settings.Default.fontUnderline;
        [Category("FontSetting")]
        [Description("The setting of the Fonts.")]
        public bool Underline
        {
            get { return fontUnderline; }
            set { fontUnderline = value; }
        }

        [Category("FontSetting")]
        [Description("The setting of the Fonts.")]
        public bool Strikeout { get; set; }


    public class MyPropertyTypeConverter : StringConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                // يجعل الخاصية غير قابلة للكتابة
                return true;
            }

            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                List<String> item = new List<string>();

                InstalledFontCollection installedFonts = new InstalledFontCollection();

                foreach (var fontFamily in installedFonts.Families)
                {
                    item.Add(fontFamily.Name);
                }

                return new StandardValuesCollection(item);
            }
        }

    }




}
