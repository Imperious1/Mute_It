using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mute_It_
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
            Form1 form = new Form1();
            ProcessMonitor monitor = new ProcessMonitor(form);
            monitor.startMonitor();
            Application.Run(form);
            //ExecuteCommand("nircmd.exe mutesysvolume 1");
        }
    }
}
