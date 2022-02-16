using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2_project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appGuid = "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}";

            using (Mutex mutex = new Mutex(false, appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("THIS PROGRAM IS ALREADY RUNNING","AUTOMATIC BACKUP",MessageBoxButtons.OK);
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new main_interface());
            }
        }
    }
}
