using Mooey.Core.Musical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mooey
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MusicalNote n = new MusicalNote();


            //n.ImportToBinary(3, 2, 4, true, true, false, false, 0, 0);

            Console.WriteLine(n.AsEncoded());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
