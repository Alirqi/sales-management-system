using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesSystem.CLASSES.Checkups
{
    class Clear
    {
        public static void ClearText(params object[] Textedit)
        {
            foreach (var text in Textedit)
            {
                if (text is TextEdit texte)
                {
                    texte.ResetText();
                }                
            }

        }
        public static void ClearLockUp(params object[] locupedi)
        {
            foreach (var loc in locupedi)
            {
                if (loc is LookUpEdit lockup)
                {
                    lockup.EditValue = null;
                }
            }

        }
    }
}
