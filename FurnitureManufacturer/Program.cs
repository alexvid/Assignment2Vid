using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FurnitureManufacturer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var log = new Login();

            var logP = new LoginPresenter(log);

            //Application.Run(new Admin());
            Application.Run(log);
        }
    }
}
