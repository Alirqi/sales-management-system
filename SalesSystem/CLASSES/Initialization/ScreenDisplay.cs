using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.CLASSES.Initialization
{
    class ScreenDisplay
    {
        public static bool ShowDilge = Properties.Settings.Default.ScreenDisplay;

        [Category("ScreenDisplay")]
        [Description("The setting of the Fonts.")]
        public bool Diloge
        {
            get { return ShowDilge; }
            set { ShowDilge = value; }
        }
    }
}
