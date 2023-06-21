using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Case_Study
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string Restaurant;
        public static string Location;
        public static string City;
        public static string FoodItem;
        public static int Total;
        public static string UserId;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FoodOnBuzz());
        }
    }
}
