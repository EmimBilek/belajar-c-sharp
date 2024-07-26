using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarEvent3_ObserverDesignPattern
{
    public static class OutputFormatter
    {
        public enum ThemeFormat
        {
            Security,
            Normal,
            Employee
        }

        public static void ChangeTheme(ThemeFormat format)
        {
            if (format == ThemeFormat.Employee)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (format == ThemeFormat.Security)
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            else
            {
                Console.ResetColor();
            }
        }
    }
}
