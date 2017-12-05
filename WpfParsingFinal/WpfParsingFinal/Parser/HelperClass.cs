using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfParsingFinal.Parser
{
    public static class HelperClass
    {
        public static SolidColorBrush ToColorConverter(bool a)
        {
            if (a)
            {
                return new SolidColorBrush(System.Windows.Media.Colors.Blue);
            }
            else
            {
                return new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
        }

        public static bool ToBoolConverter(SolidColorBrush b)
        {
            string color = b.Color.ToString();
            if (color.Equals("#0000FF"))
            {
                return true;
            }
            else return false;
        }


    }
}
