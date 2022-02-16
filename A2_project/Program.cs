using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                if (!singleton.WaitOne(TimeSpan.Zero, true))
                {
                    MessageBox.Show("THIS PROGRAM IS ALREADY RUNNING", "AUTOMATIC BACKUP", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new main_interface());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COULD NOT LAUNCH, PLEASE RESTART THE PROGRAM AND IF ERROR KEEPS SHOWING, PLEASE RESTART YOUR COMPUTER.");
            }

            //string appGuid = "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}";
            //
            //    MessageBox.Show("THIS PROGRAM IS ALREADY RUNNING", "AUTOMATIC BACKUP", MessageBoxButtons.OK);
            //    return;
            //}
            //else
            //{
            //}
            //}
            //using (Mutex mutex = new Mutex(false, appGuid))
            //{
            //    if (!mutex.WaitOne(0, false))
            //    {
            //        MessageBox.Show("THIS PROGRAM IS ALREADY RUNNING","AUTOMATIC BACKUP",MessageBoxButtons.OK);
            //        return;
            //    }
            //}
        }
        static System.Threading.Mutex singleton = new Mutex(true, "My App Name");
    }
}
