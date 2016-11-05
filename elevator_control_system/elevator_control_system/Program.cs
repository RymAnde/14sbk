using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elevator_control_system
{
    static class Program
    {
        static class Data
        {
            public static int Value { get; set; }
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
