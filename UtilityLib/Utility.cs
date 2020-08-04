using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilityLib
{
    public class Utility
    {
        public static void CleanTextBoxes(Control.ControlCollection ct)
        {
            foreach (Control item in ct)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
        }
    }
}
