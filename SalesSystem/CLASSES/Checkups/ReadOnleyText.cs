using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Threading.Tasks;

namespace SalesSystem.CLASSES.Checkups
{
    interface ReadOnleyText
    {
        void readonley(bool isReadonley, params object[] text);
    }
    
    

   public  class ReadOnley : ReadOnleyText
    {
        public void readonley(bool isReadonley, params object[] text)
        {
            foreach(var item in text)
            {
                if(item is TextEdit texted)
                {
                    texted.ReadOnly = isReadonley;
                }

                if (item is RadioGroup redio)
                {
                    redio.ReadOnly = isReadonley;
                }
            }
        }
    }
}
