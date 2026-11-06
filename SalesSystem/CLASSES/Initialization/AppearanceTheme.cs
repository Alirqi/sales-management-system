using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Skins;

namespace SalesSystem.CLASSES.Initialization
{
    class AppearanceTheme
    {


        public static string ApperancThems = Properties.Settings.Default.ThemName;

        [Category("ThemesStyle")]
        [TypeConverter(typeof(MyPropertyTypeConverter))]
        [DefaultValue("Default Value")]
        public string Thems
        {
            get { return ApperancThems; }
            set { ApperancThems = value; }
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
                List<string> themes = new List<string>();
                foreach (SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
                {
                    themes.Add(skin.SkinName);
                }

                return new StandardValuesCollection(themes);
            }
        }
    }
}
