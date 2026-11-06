using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.CLASSES.Initialization
{
    class LanguageSettings
    {
        public static string Languag = Properties.Settings.Default.Language;

        [Category("General")]
        [DisplayName("Language")]
        [TypeConverter(typeof(MyPropertyTypeConverter))]
        [Description("Select the language for the application.")]
        public string Language { get { return Languag; } set { Languag = value; } }

        [Category("General")]
        [DisplayName("Font Size")]
        [Description("Select the font size for the application.")]
        public int FontSize { get; set; }

        [Category("General")]
        [DisplayName("Theme")]
        [Description("Select the theme for the application.")]
        public string Theme { get; set; }

        public LanguageSettings()
        {
            Language = Properties.Settings.Default.Language;
            FontSize = (int)Properties.Settings.Default.fontSize;
            Theme = Properties.Settings.Default.ThemName;
        }
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

                // قم بإنشاء قائمة لتخزين أسماء الثيمات
                List<string> lang = new List<string>();
                lang.Add("English");
                lang.Add("Arabic");

                return new StandardValuesCollection(lang);
            }
        }

    }
}
