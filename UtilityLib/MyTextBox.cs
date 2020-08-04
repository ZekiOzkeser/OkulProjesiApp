using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilityLib
{
    public class MyTextBox : TextBox
    {
        public enum CalismaMod
        {
            Rakam,
            Harf,
            Normal
        }

        public CalismaMod Calismamodu { get; set; }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch (Calismamodu)
            {
                case CalismaMod.Rakam:
                    if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != ('+'))
                    {
                        e.Handled = true;
                    }
                    break;
                case CalismaMod.Harf:
                    if (!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
                    {
                        e.Handled = true;
                    }
                    break;
                case CalismaMod.Normal:
                    base.OnKeyPress(e);
                    break;
                default:
                    break;
            }
        }
    }
}
