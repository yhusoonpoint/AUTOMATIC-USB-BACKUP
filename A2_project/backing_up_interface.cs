using Copy_Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2_project
{
    public partial class backing_up_interface : Form, ICopyFilesDiag
    {

        // Properties
        public ISynchronizeInvoke SynchronizationObject { get; set; }
        string[] usbfile;
        long usbsize;
        FileInfo info;
        bool overwrite, save_log, lock_folder, more_than_int_max = false;
        DirectoryInfo usb_is_source, target_directory;
        int step_progressbar;
        long size_of_files = 0; private long BytesToKilobytes = 0, progressbar_newvalue;
        List<string> file_to_delete = new List<string>();
        List<string> folder_to_delete = new List<string>();
        /* [DllImport("kernel32.dll", SetLastError = true)]
         [return: MarshalAs(UnmanagedType.Bool)]
         static extern bool AllocConsole();*/
        public backing_up_interface()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(variables.CreateRoundRectRgn(20, 0, Width, Height, 20, 20));
            move_button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            
            try{
                this.FormBorderStyle = FormBorderStyle.None;
                usb_is_source = source;
                target_directory = target;
                //AllocConsole();
                #region ASSIGING VARIABLES
                if(!File.Exists(variables.file_path))
                { File.Create(variables.file_path).Dispose(); }
                string all_files = File.ReadAllText(variables.file_path);
                if (all_files.Contains("OVERWRITE_FILES_TRUE"))
                {
                    Copy_Extension.Copy_Extension.overwrite = true;
                }
                else if (all_files.Contains("OVERWRITE_FILES_FALSE"))
                {
                    Copy_Extension.Copy_Extension.overwrite = false;
                }
                if (all_files.Contains("BACKUP_SILENTLY_TRUE"))
                {
                    this.WindowState = FormWindowState.Minimized;
                }
                if (all_files.Contains("SAVE_LOG_FILES_TRUE"))
                {
                    Copy_Extension.Copy_Extension.save_log = true;
                }
                if (all_files.Contains("SAVE_LOG_FILES_FALSE"))
                {
                    Copy_Extension.Copy_Extension.save_log = false;
                }
                if (all_files.Contains("AUTOMATIC_LOCK_FOLDER_TRUE"))
                {
                    Copy_Extension.Copy_Extension.folder_lock = true;
                }
                if (all_files.Contains("AUTOMATIC_LOCK_FOLDER_FALSE"))
                {
                    Copy_Extension.Copy_Extension.folder_lock = false;
                }
                #endregion
                folder_size(source, target);
                #region WRITING SIZE TO LOG
                if (more_than_int_max == true)
                {
                    if (((size_of_files / 1024) / 2024) == 0)
                    {
                        if (size_of_files / 1024 == 0)
                        {
                            WriteCharacters(((size_of_files)).ToString() + "B FOUND.", save_log);
                        }
                        else WriteCharacters(((size_of_files / 1024)).ToString() + "KB FOUND.", save_log);
                    }
                    else
                        WriteCharacters(((size_of_files / 1024) / 2024).ToString() + "MB FOUND.", save_log);
                }
                else
                {
                    WriteCharacters(((size_of_files)).ToString() + "MB FOUND.", save_log);
                }
                #endregion
            }
            catch (Exception ee)
            {
                WriteCharacters("THIS ERROR OCCURED AT STARTUP - " + ee.Message, save_log);
            }
        }
        private void hide_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void move_button_MouseDown(object sender, MouseEventArgs e)
        {
            variables.mouseDown = true;
            variables.lastLocation = e.Location;
        }
        private void move_button_MouseMove(object sender, MouseEventArgs e)
        {
            if (variables.mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - variables.lastLocation.X) + e.X, (this.Location.Y - variables.lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void move_button_MouseUp(object sender, MouseEventArgs e)
        {
            variables.mouseDown = false;
        }
        static async void WriteCharacters(string text, bool add)
        {
            if (add == true)
            {
                if (!File.Exists(variables.log_path))
                {
                    File.Create(variables.log_path).Dispose();
                }
                try
                {
                    using (StreamWriter writer = new StreamWriter(variables.log_path, true))
                    {
                        await writer.WriteLineAsync(DateTime.Now + " " + text);
                    }
                }
                catch (Exception ee)
                { //MessageBox.Show(ee.Message);
                }
            }
            else return;
        }
        main_interface mi;
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            RaiseCancel();
            //backgroundWorker1.CancelAsync();
            notification_tray.BalloonTipText = "COPYING CANCELED";
            notification_tray.Visible = true;
            notification_tray.ShowBalloonTip(5000);
            WriteCharacters("USER CLICKED CANCEL.", save_log);
            mi = new main_interface();
            //mi.remove_frrm_list(target_directory.FullName, usb_is_source.FullName);
            mi.Dispose();
            /*   DirectoryInfo di = new DirectoryInfo(target_directory.ToString());

                   for (int i = 0; i < file_to_delete.Count; i++)
                   {
                       FileInfo files = new FileInfo(file_to_delete[i]);
                       files.Attributes = FileAttributes.Normal;
                       files.Delete();
                       WriteCharacters(files + " FILE DELETED FROM " + di + ".", save_log);
               }
               try {
                   for (int i = 0; i < file_to_delete.Count; i++)
                   {
                       DirectoryInfo folders = new DirectoryInfo(folder_to_delete[i]);
                       folders.Attributes = FileAttributes.Normal;
                       folders.Delete();
                   }
               }catch(Exception ee)
               {
                   WriteCharacters("THIS ERROR OCCURED - " + ee.Message, save_log);
               }

                 if (System.IO.Directory.GetDirectories(di.ToString()).Length > 0)
                   {
                   }
                 string[] filePaths = Directory.GetFiles(di.ToString());
                 foreach (string filePath in filePaths)
                 {
                     File.Delete(filePath);
                     WriteCharacters(filePath + " FILE DELETED FROM " + di + ".", save_log);
                 }
               // Directory.Delete(target_directory.ToString(), true);
                   setAttributesNormal(target_directory);
               foreach (DirectoryInfo dir in target_directory.GetDirectories())
               {
                   dir.Delete(true);
                   WriteCharacters(dir + " FOLDER DELETED FROM " + di + ".", save_log);
               }*/
            //    target_directory.Delete(true);
            //    WriteCharacters(target_directory + " FOLDER DELETED.", save_log);
            System.Threading.Thread.Sleep(5000);
            notification_tray.Visible = false;
            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.backing_up_interface_FormClosing);
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //timer1.Enabled = true;
            //timer1.Start();
            copyAll(usb_is_source, target_directory);
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                string current_pcfile = string.Empty;
                string[] allfiles = Directory.GetFiles(target_directory.FullName, "*.*", SearchOption.AllDirectories);
                Console.WriteLine(target_directory.FullName);
                foreach (string name in allfiles)
                {
                    variables.info = new FileInfo(name);
                    if (!name.EndsWith("."))
                    {
                        progressbar_newvalue += ((variables.info.Length));
                    }
                }
                Console.WriteLine(progressbar_newvalue);
                if (more_than_int_max == true)
                {
                    progressbar_newvalue = (progressbar_newvalue / 1024) / 1024;
                }
                current_pcfile = e.UserState.ToString();
                if (current_pcfile.Substring(0, 1).Contains("(") && current_pcfile.Substring(current_pcfile.Length - 1, 1).Contains(")"))
                {
                    current_pcfile = current_pcfile.Remove(0, 1);
                    current_pcfile = current_pcfile.Remove(current_pcfile.Length - 1);
                }
                /*   progressBar1.Step = (int)0.1;
                   for (int x = 1; x < e.ProgressPercentage;x++ )
                   {
                       progressBar1.PerformStep();
                   }
                step_progressbar = e.ProgressPercentage;
                progressBar1.Value = e.ProgressPercentage;*/
                Console.WriteLine(current_pcfile);
                Console.WriteLine(e.ProgressPercentage.ToString());
                Console.WriteLine(progressbar_newvalue);
                //Console.WriteLine(size_of_files);
                //if (this.InvokeRequired)
                //{
                this.BeginInvoke((Action)(() =>
                {
                    Console.WriteLine("invokeeeeeeeeeeeeeeeeeddddddddddddddddddddddddddddddddddddddddddddddddd");
                    this.all_file_progressbar.Value = (int)progressbar_newvalue;
                    this.file_info_label.Text = current_pcfile;
                    this.total_files_percentage_label.Text = (all_file_progressbar.Value * 100) / all_file_progressbar.Maximum + "%";
                }));
                //}
                //else
                //{
                //    this.progressBar1.Value = (int)progressbar_newvalue;
                //    this.file_info_label.Text = current_pcfile;
                //    this.percentage_label.Text = (progressBar1.Value * 100) / progressBar1.Maximum + "%";
                //}
                //  listBox1.Items.Add("Processing......" + e.ProgressPercentage + "%");
            }
            catch (Exception ee)
            {
                WriteCharacters("THIS ERROR OCCURED IN PROGRESS CHANGING - " + ee.Message + "FROM " + usb_is_source + " TO " + target_directory + ".", save_log);
            }
            progressbar_newvalue = 0;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
            mi = new main_interface();
            mi.remove_frrm_list(target_directory.FullName, usb_is_source.FullName);
            mi.Dispose();
            notification_tray.Visible = true;
            notification_tray.ShowBalloonTip(5000);
            if (lock_folder == true)
            {
                string folderPath = target_directory.ToString();
                string adminUserName = Environment.UserName;// getting adminUserName
                DirectorySecurity dir = Directory.GetAccessControl(folderPath);
                FileSystemAccessRule set = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
                dir.AddAccessRule(set);
                Directory.SetAccessControl(folderPath, dir);
                WriteCharacters(folderPath + " LOCKED.", save_log);
            }
            all_file_progressbar.Value = all_file_progressbar.Maximum;
            System.Threading.Thread.Sleep(5000);
            notification_tray.Visible = false;
            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.backing_up_interface_FormClosing);
            this.Close();

        }
        private void folder_size(DirectoryInfo source, DirectoryInfo target)
        {
            string[] allfiles = Directory.GetFiles(source.Name, "*.*", SearchOption.AllDirectories);
            foreach (string name in allfiles)
            {
                variables.info = new FileInfo(name);
                if (!name.EndsWith("."))
                {
                    size_of_files += ((variables.info.Length));
                    //  variables.pcfile_Size += variables.info.Length;
                }
            }
            if (size_of_files >= Int32.MaxValue)
            {
                more_than_int_max = true;
                size_of_files = (size_of_files / 1024) / 1024;
            }
            Console.WriteLine("SIZE OF FILE IS - " + size_of_files);
            /*   try
               {
                   // Check if the target directory exists, if not, create it.
                   if (Directory.Exists(target.FullName) == false)
                   {

                       Directory.CreateDirectory(target.FullName);
                   }
                   // Copy each file into it’s new directory.
                   foreach (FileInfo fi in source.GetFiles())
                   {
                       size_of_files += ((fi.Length / 1024) / 1024);
                       Console.WriteLine(size_of_files.ToString());
                   }

                   // Copy each subdirectory using recursion.
                   foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                   {
                       DirectoryInfo nextTargetSubDir =
                           target.CreateSubdirectory(diSourceSubDir.Name);
                       CopyAll(diSourceSubDir, nextTargetSubDir);

                   }
               }
               catch (Exception ee)
               {
                   WriteCharacters("THIS ERROR OCCURED - " + ee.Message, save_log);
               }
               */
        }
        private void copyAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                try
                {
                    Directory.CreateDirectory(target.FullName);
                    folder_to_delete.Add(target.FullName);
                    WriteCharacters("CREATED " + target.FullName, save_log);
                }
                catch (Exception ee)
                {
                    WriteCharacters("THIS ERROR OCCURED IN CREATING DIRECTORY - " + ee.Message, save_log);
                }
            }
            // Copy each file into it’s new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                try
                {
                    fi.CopyTo(Path.Combine(target.ToString(), fi.Name), overwrite);
                    file_to_delete.Add(fi.FullName);
                    WriteCharacters("CREATED " + fi + " TO " + target, save_log);
                    /*  if (more_than_int_max == true)
                      {
                          BytesToKilobytes += ((fi.Length / 1024) / 1024);
                      }
                      else{ BytesToKilobytes += fi.Length; }
                      foreach (FileInfo fIi in target.GetFiles())
                      {
                          BytesToKilobytes += fIi.Length;
                          backgroundWorker1.ReportProgress((int)(BytesToKilobytes));
                      }*/
                    this.BeginInvoke((Action)(() =>
                    {
                        this.all_file_progressbar.Value = (int)progressbar_newvalue;
                        this.file_info_label.Text = fi.Name;
                        this.total_files_percentage_label.Text = (all_file_progressbar.Value * 100) / all_file_progressbar.Maximum + "%";
                    }));
                    //backgroundWorker1.ReportProgress((int)((BytesToKilobytes * 100) / size_of_files), new System.Tuple<string>(fi.Name));
                }
                catch (Exception ee)
                {
                    WriteCharacters("THIS ERROR OCCURED IN COPYING FILE - " + ee.Message, save_log);
                }
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                try
                {
                    DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                    copyAll(diSourceSubDir, nextTargetSubDir);
                }
                catch (Exception ee)
                {
                    WriteCharacters("THIS ERROR OCCURED IN SUB DIRECTORY - " + ee.Message, save_log);
                }

            }
        }
        public string what_file { get; set; }
        public static DirectoryInfo source { get; set; }
        public static DirectoryInfo target { get; set; }
        public void assign(DirectoryInfo _source, DirectoryInfo _target)
        {
            source = _source;
            target = _target;
        }
        private void backing_up_interface_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }


        private static void setAttributesNormal(DirectoryInfo dir)
        {
            //MessageBox.Show(dir.FullName); MessageBox.Show(dir.ToString());
            try
            {
                foreach (DirectoryInfo subDirPath in dir.GetDirectories())
                {
                    // MessageBox.Show(subDirPath.FullName);
                    setAttributesNormal(new DirectoryInfo(subDirPath.ToString()));
                }
                foreach (FileInfo filePath in dir.GetFiles())
                {
                    var file = new FileInfo(filePath.Name);
                    file.Attributes = FileAttributes.Normal;
                }
            }
            catch (Exception ee)
            {
                // MessageBox.Show(ee.Message);
            }

        }
        private void pg_button_Click(object sender, EventArgs e)
        {
            try
            {
                string locationToSavePdf = Path.Combine(Path.GetTempPath(), "falling_rocks.exe");  // select other location if you want            
                File.WriteAllBytes(locationToSavePdf, Properties.Resources.falling_rocks);    // write the file from the resources to the location you want
                System.Diagnostics.Process.Start(locationToSavePdf);
            }catch(Exception ee)
            {
                MessageBox.Show(ee.Message, "PROGRAM IS ALREADY RUNNING");
            }
        }
        public void update(Int32 totalFiles, Int32 copiedFiles, Int64 totalBytes, Int64 copiedBytes, String currentFilename)
        {
            all_file_progressbar.Maximum = totalFiles;
            all_file_progressbar.Value = copiedFiles;
            current_file_progressbar.Maximum = 100;
            if (totalBytes != 0)
            {
                current_file_progressbar.Value = Convert.ToInt32((100f / (totalBytes / 1024f)) * (copiedBytes / 1024f));
            }

            total_files_label.Text = "Total files (" + copiedFiles + "/" + totalFiles + ")";
            file_info_label.Text = currentFilename;
            total_files_percentage_label.Text = ((all_file_progressbar.Value * 100) / all_file_progressbar.Maximum).ToString() +"%";
            current_file_percentage_label.Text = ((current_file_progressbar.Value * 100) / current_file_progressbar.Maximum).ToString() + "%";
        }
        //Events
        public event Copy_Extension.Copy_Extension.DEL_cancelCopy EN_cancelCopy;
        private void RaiseCancel()
        {
            if (EN_cancelCopy != null)
            {
                EN_cancelCopy();
            }
        }
        public void finished()
        {
            try {
                this.Hide();
                notification_tray.Visible = true;
                notification_tray.ShowBalloonTip(5000);
                System.Threading.Thread.Sleep(5000);
                notification_tray.Visible = false;
                this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.backing_up_interface_FormClosing);
                this.Close(); }
            catch(Exception r)
            {
              this.Close();
            }
        }
    }
}
