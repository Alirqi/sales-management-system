using System;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SalesSystem.CLASSES.Checkups
{

    public interface EnabledButtons
    {
        void ToggleButtons(bool isEnabled,params object[] buttons);                
    }

    public class SetButtons : EnabledButtons
    {
        public void ToggleButtons(bool isEnabled, params object[] buttons)
        {
            foreach (var button in buttons)
            {
                if(button is SimpleButton sbtn)
                {
                    sbtn.Enabled = isEnabled;
                }               
            }
            
        }              
    }
}
