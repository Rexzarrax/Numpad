using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numpadcipher
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
            Application.Run(new Form1());
            Convertholder converter = new Convertholder();
        }
    }
    //42 81 81 71 74 54 11 11 41 43 81 42 82 22 12 23 63 61 11 73 32 92 94 21 73 73 21 92 11 62 82 61 71 21 31 
}
