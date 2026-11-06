using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesSystem.CLASSES.FormFunction
{
    class splashScreenManager
    {
         public static DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;

        public splashScreenManager(Form fm)
        {
            splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(fm, typeof(global::SalesSystem.FR.For_Wait), true, true);
            splashScreenManager1.ClosingDelay = 1000;
        }
    }
}
