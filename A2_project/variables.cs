using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace A2_project
{
    class variables
    {
        public static bool mouseDown, newfilesfound = false, run_at_startup, backup_silently, automatic_lock_folder, 
                           automatic_backup, overwrite_files, save_log_file;
        public static Point lastLocation;
        public static List<string> list_to_copy = new List<string>();
        public static List<string> list_to_copy2 = new List<string>();
        public static DirectoryInfo usbdirectory, target_directory;
        public static backing_up_interface backing_up_interface;
        public static settings_interface settings_interface;
        public static int directoryCount = 0, count = 0, checkcount = 0;
        public static long usbfile_size, pcfile_Size;
        public static string[] usbfiles, pcfile;
        public static string file_path = AppDomain.CurrentDomain.BaseDirectory.ToString() + "config.ddvs";
        public static string log_path = AppDomain.CurrentDomain.BaseDirectory.ToString() + "log.ddvs";
        public static string remaining_of_target;
        public static FileInfo info;
        public static ContextMenuStrip TrayIconContextMenu;
        public static ToolStripMenuItem CloseMenuItem;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect, // x-coordinate of upper-left corner
           int nTopRect, // y-coordinate of upper-left corner
           int nRightRect, // x-coordinate of lower-right corner
           int nBottomRect, // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
        );
    }
}
