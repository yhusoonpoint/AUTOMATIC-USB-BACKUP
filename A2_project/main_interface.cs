using Copy_Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Management;
using System.Security.AccessControl;
using System.Diagnostics;

namespace A2_project
{
    public partial class main_interface : Form
    {
        // Assigns the variable with a path in the registry that holds startup programms. 
        Microsoft.Win32.RegistryKey check_registry = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public main_interface()
        {
            // sets up the form
            InitializeComponent();
            // removes border
            // sets border edges to be curve
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(variables.CreateRoundRectRgn(50, 0, Width, Height, 50, 50));
            // makes the buttons border color transparent.
            move_button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            fb_button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            // Assigns the notification properties
            notification_tray.Text = "AUTOMATIC USB BACKUP";
            notification_tray.Icon = this.Icon;
            // checks if the file exist
            if (!File.Exists(variables.file_path))
            {
                // if the file doesnt exist, create it and add text to it.
                File.Create(variables.file_path).Dispose();
                using (TextWriter write_new_file = new StreamWriter(variables.file_path))
                {
                    // .writeline writes line to the text file
                    write_new_file.WriteLine("RUN_AT_STARTUP_TRUE", true);
                    write_new_file.WriteLine("BACKUP_SILENTLY_FALSE", true);
                    write_new_file.WriteLine("AUTOMATIC_LOCK_FOLDER_FALSE", true);
                    write_new_file.WriteLine("AUTOMATIC_BACKUP_TRUE", true);
                    write_new_file.WriteLine("OVERWRITE_FILES_TRUE", true);
                    write_new_file.WriteLine("SAVE_LOG_FILES_TRUE", true);
                    write_new_file.WriteLine("DIRECTORY_" + AppDomain.CurrentDomain.BaseDirectory + @"backups\", true); variables.target_directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"backups\");
                    write_new_file.Close();
                }
            }
            else if (File.Exists(variables.file_path))
            {
                // gets how many lines are there in file
                string[] lines = File.ReadAllLines(variables.file_path);
                for (int i = 0; i < lines.Length; i++)
                {
                    // Calls a function
                    assigning_variables(i, "SAVE_LOG_FILES_TRUE", "SAVE_LOG_FILES_FALSE", variables.save_log_file);
                    /*
                    // THIS CODE ISN'T NEEDED IN THIS SESSION BUT WHAT IT DOES IS ASSIGNING THE VARIABLE ACCORDING TO THE FILE TEXT
                     assigning_variables(i, "AUTOMATIC_BACKUP_TRUE", "AUTOMATIC_BACKUP_FALSE", variables.automatic_backup);
                     assigning_variables(i, "RUN_AT_STARTUP_TRUE", "RUN_AT_STARTUP_FALSE", variables.run_at_startup);
                     assigning_variables(i, "BACKUP_SILENTLY_TRUE", "BACKUP_SILENTLY_FALSE", variables.backup_silently);
                     assigning_variables(i, "AUTOMATIC_LOCK_FOLDER_TRUE", "AUTOMATIC_LOCK_FOLDER_FALSE", variables.automatic_lock_folder);
                     assigning_variables(i, "OVERWRITE_FILES_TRUE", "OVERWRITE_FILES_TRUE_FALSE", variables.overwrite_files);
                     assigning_variables(i, "SAVE_LOG_FILES_TRUE", "SAVE_LOG_FILES_FALSE", variables.save_log_file);*/
                    if (lines[i].Contains("DIRECTORY_"))
                    {
                        variables.target_directory = new DirectoryInfo(lines[i].Remove(0, 10));
                    }
                }
                // if file exists, it checks if this text exists.
                confirm_if_text_exist("RUN_AT_STARTUP_TRUE", "RUN_AT_STARTUP_FALSE", variables.run_at_startup, true);
                confirm_if_text_exist("BACKUP_SILENTLY_FALSE", "BACKUP_SILENTLY_TRUE", variables.backup_silently, false);
                confirm_if_text_exist("AUTOMATIC_LOCK_FOLDER_FALSE", "AUTOMATIC_LOCK_FOLDER_TRUE", variables.automatic_lock_folder, false);
                confirm_if_text_exist("AUTOMATIC_BACKUP_TRUE", "AUTOMATIC_BACKUP_FALSE", variables.automatic_backup, true);
                confirm_if_text_exist("OVERWRITE_FILES_TRUE", "OVERWRITE_FILES_FALSE", variables.overwrite_files, true);
                confirm_if_text_exist("SAVE_LOG_FILES_TRUE", "SAVE_LOG_FILES_FALSE", variables.save_log_file, true);
                // checks if theres a text that contains the directory

                string all_file = File.ReadAllText(variables.file_path);
                //checks if directory exist in the file
                if (!all_file.Contains("DIRECTORY_"))
                {
                    StreamWriter write_new_file = new StreamWriter(variables.file_path, true);
                    write_new_file.WriteLine(string.Empty);
                    write_new_file.WriteLine("DIRECTORY_" + AppDomain.CurrentDomain.BaseDirectory + "backups");
                    variables.target_directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "backups");
                    write_new_file.Close();
                    write_new_file.Dispose();
                }
            }

            //
            // checks if other text exist in the file 
            if (!File.Exists(variables.log_path))
            {
                File.Create(variables.log_path).Dispose();
            }
            string all_files = File.ReadAllText(variables.file_path);
            // checks if directories exist
            if (!Directory.Exists(variables.target_directory.ToString()))
            {
                Directory.CreateDirectory(variables.target_directory.ToString());
            }
            if (all_files.Contains("AUTOMATIC_BACKUP_TRUE"))
            {
                usbchecker_timer.Enabled = true;
            }
            else if (all_files.Contains("AUTOMATIC_BACKUP_FALSE"))
            {
                usbchecker_timer.Enabled = false;
            }
            if (check_registry.GetValue("AUTOMATIC_BACKUP_USB") == null && all_files.Contains("RUN_AT_STARTUP_TRUE"))
            {
                // The value doesn't exist, the application is not set to run at startup
                check_registry.SetValue("AUTOMATIC_BACKUP_USB", Application.ExecutablePath.ToString());
            }
            else if (check_registry.GetValue("AUTOMATIC_BACKUP_USB") != null && all_files.Contains("RUN_AT_STARTUP_FALSE"))
            {
                // The value exists, the application is set to run at startup
                check_registry.DeleteValue("AUTOMATIC_BACKUP_USB", false);
            }
        }
        // The function below assigns a value to a variable
        private void assigning_variables(int i, string first_check, string second_check, bool what_checkbox)
        {
            string[] lines = File.ReadAllLines(variables.file_path);
            // It checks if the text exist and the assign the value to the variable that needs to hold this information
            if (lines[i].Contains(first_check))
            {
                what_checkbox = true;
            }
            else if ((lines[i].Contains(second_check)))
            {
                what_checkbox = false;
            }
        }
        // This function that checks if a property of the setting exist
        private void confirm_if_text_exist(string first_check, string second_check, bool what_checkbox, bool check)
        {
            string all_files = File.ReadAllText(variables.file_path);
            // if it doesnt exist it creates the text
            if (!(all_files.Contains(first_check) || all_files.Contains(second_check)))
            {
                // StreamWriter reads the file, (its like notepad but it's not visible) 
                // writline writes new text to a new line
                // closes closes the file and dispose stops the process
                StreamWriter write_new_file = new StreamWriter(variables.file_path, true);
                write_new_file.WriteLine(string.Empty);
                write_new_file.WriteLine(first_check);
                write_new_file.Close();
                write_new_file.Dispose();
                what_checkbox = check;
            }
        }
        // This function calls the extion that will start the backing up process
        private void process_copy()
        {
            // Confirms if theres usb that needs to be backed up
            if (variables.checkcount != variables.count)
            {
                // loop to open multiple dialog if theres more than one usb insert
                for (int i = variables.checkcount; i < variables.list_to_copy.Count; i++)
                {
                    variables.usbdirectory = new DirectoryInfo(variables.list_to_copy[i]);
                    variables.backing_up_interface = new backing_up_interface();
                    variables.backing_up_interface.assign(new DirectoryInfo(variables.usbdirectory.FullName), new DirectoryInfo(variables.list_to_copy2[i]));
                    // calling the extension file to perform backup
                    Copy_Extension.Copy_Extension call_interface = new Copy_Extension.Copy_Extension(variables.usbdirectory.FullName, variables.list_to_copy2[i]);
                    variables.backing_up_interface.SynchronizationObject = this;
                    call_interface.CopyAsync(variables.backing_up_interface);
                    //variables.backing_up_interface.Show(this);
                }
                // makes it not loop again
                variables.checkcount = variables.count;
            }
        }
        private void settings_button_Click(object sender, EventArgs e)
        {
            // calling up the settings interface and hiding this form and showing it after its closed
            variables.settings_interface = new settings_interface();
            this.Hide();
            variables.settings_interface.Left = this.Left;
            variables.settings_interface.Top = this.Top;
            variables.settings_interface.Location = this.Location;
            variables.settings_interface.ShowDialog();
            this.Show();
        }
        private void move_button_MouseDown(object sender, MouseEventArgs e)
        {
            variables.mouseDown = true;
            //saves last location of the form
            variables.lastLocation = e.Location;
        }
        private void move_button_MouseMove(object sender, MouseEventArgs e)
        {
            if (variables.mouseDown)
            {
                // changes form location
                this.Location = new Point(
                    (this.Location.X - variables.lastLocation.X) + e.X, (this.Location.Y - variables.lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void move_button_MouseUp(object sender, MouseEventArgs e)
        {
            variables.mouseDown = false;
        }
        // The function below  updates the timer function incase the settings changes
        public void update_usbchecker(bool message)
        {
            usbchecker_timer.Enabled = message;
        }
        private void usbchecker_timer_Tick(object sender, EventArgs e)
        {
            // Looks for every USB that is removeable and ready to use
            foreach (DriveInfo usbname in DriveInfo.GetDrives().Where(usbproperty => usbproperty.DriveType == DriveType.Removable && usbproperty.IsReady))
            {
                #region ASSIGNING TARGET INFORMATION
                // managementobjectsearcher is a database that contains the serial number of the USB
                ManagementObjectSearcher moSearch = new ManagementObjectSearcher("Select * from Win32_LogicalDisk where Name='" + usbname.Name.Remove(usbname.ToString().Length - 1) + "'");
                variables.usbdirectory = new DirectoryInfo(usbname.Name);
                try
                {
                    foreach (var mo in moSearch.Get())
                    {
                        // ASSINGING the variable with the the information of he usb 
                        if (usbname.VolumeLabel == string.Empty)
                        {
                            variables.remaining_of_target = @"\[No name] [" + mo["VolumeSerialNumber"].ToString() + "]";
                        }
                        else
                        {
                            variables.remaining_of_target = @"\[" + usbname.VolumeLabel + "] [" + mo["VolumeSerialNumber"].ToString() + "]";
                        }
                    }
                }
                catch (Exception MSG)
                {
                    // removes the usb name from the list so it can re backed up if inserted
                    remove_frrm_list(variables.target_directory.Name, usbname.Name);
                    WriteCharacters(string.Format("AN ERROR OCCURED - {0}", MSG.Message), variables.save_log_file);
                    break;
                }
                moSearch.Dispose();
                #endregion
                #region IF DIRECTORY DOESNT EXIST, THEN CREATE ONE
                if (!Directory.Exists(variables.target_directory + variables.remaining_of_target) && !variables.list_to_copy.Contains(usbname.Name))
                {
                    Directory.CreateDirectory(variables.target_directory + variables.remaining_of_target);
                    // Adds the USB path to a list
                    variables.list_to_copy.Add(usbname.Name);
                    variables.list_to_copy2.Add(variables.target_directory.ToString() + variables.remaining_of_target);
                    variables.newfilesfound = true;
                }
                else if (Directory.Exists(variables.target_directory.ToString() + variables.remaining_of_target) && !variables.list_to_copy.Contains(usbname.Name))
                {
                    #region ASSIGNING_VARIABLES
                    variables.directoryCount = System.IO.Directory.GetDirectories(variables.target_directory.ToString()).Length;
                    variables.usbfile_size = 0;
                    variables.pcfile_Size = 0;
                    variables.usbfiles = Directory.GetFiles(usbname.Name, "*.*", SearchOption.AllDirectories);
                    variables.pcfile = Directory.GetFiles(variables.target_directory.ToString() + variables.remaining_of_target + @"\", "*.*", SearchOption.AllDirectories);
                    //Console.WriteLine(variables.target_directory.ToString() + variables.remaining_of_target + "       "+usbname.Name);
                    #endregion
                    try
                    {
                        #region LOOP_FOR_GETTING_FOLDER_SIZE
                        // Gets the size of the folder and USB to compare it. 
                        foreach (string name in variables.usbfiles)
                        {
                            variables.info = new FileInfo(name);
                            // Checks if the file isnt a folder
                            if (!name.EndsWith("."))
                            {
                                // adds up the size of all files
                                variables.usbfile_size += variables.info.Length;
                            }
                        }
                        foreach (string name in variables.pcfile)
                        {
                            variables.info = new FileInfo(name);
                            if (!name.EndsWith("."))
                            {
                                variables.pcfile_Size += variables.info.Length;
                            }
                        }
                        #endregion
                        #region CHECKING_IF_THERES_NEW_FILES
                        if (variables.pcfile_Size == variables.usbfile_size)
                        {
                            variables.newfilesfound = false;
                        }
                        else if (variables.pcfile_Size != variables.usbfile_size && !variables.list_to_copy.Contains(usbname.Name))
                        {
                            variables.list_to_copy.Add(usbname.Name);
                            variables.list_to_copy2.Add(variables.target_directory.ToString() + variables.remaining_of_target);
                            variables.newfilesfound = true;
                        }
                        #endregion
                    }
                    catch (Exception msg)
                    {
                        // Adds the error to log
                        WriteCharacters(string.Format("THIS ERROR OCCURED - {0}", msg.Message), variables.save_log_file);
                    }
                }
                #endregion
            }
            #region CONTINUE WHENN FILES ARE FOUND
            if (variables.newfilesfound == true)
            {
                variables.count = variables.list_to_copy.Count();
                // Calls the continuation function
                process_copy();
                variables.newfilesfound = false;
            }
            #endregion
            if (variables.list_to_copy.Count < 1)
            {
                for (int i = 0; i < variables.list_to_copy.Count; i++)
                {
                    if (!Directory.Exists(variables.list_to_copy[i]))
                    //continue here
                    {
                        variables.list_to_copy.Remove(variables.list_to_copy[i]);
                        variables.list_to_copy.Remove(variables.list_to_copy2[i]);
                        variables.checkcount = variables.count = variables.list_to_copy.Count;

                    }
                }
            }
        }
        private void close_button_Click(object sender, EventArgs e)
        {
            // checks if 'Alt' is held down
            if (Control.ModifierKeys == Keys.Alt)
            {
                // disables the notification tray
                // removes the event that stops it from closing
                // it ends the process and closes the progrsm
                notification_tray.Visible = false;
                this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.main_interface_FormClosing);
                this.Close();
            }
            else
            {
                //hides the from and make the notification tray visible and show a quick information for 2 seconds
                notification_tray.Visible = true;
                notification_tray.ShowBalloonTip(2000); this.Hide();
            }
        }
        private void force_close_Click(object sender, EventArgs e)
        {
            // closes the form and ends the process
            notification_tray.Visible = false;
            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.main_interface_FormClosing);
            this.Close();
        }
        private void force_backup_Click(object sender, EventArgs e)
        {
            // starts the maunal backup
            force_start();
        }
        private void main_interface_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stops the form from closing and hides it
            e.Cancel = true;
            this.Hide();
        }
        private void notification_tray_MouseClick(object sender, MouseEventArgs e)
        {
            // checks what button on the mouse is pressed 
            if (e.Button == MouseButtons.Left)
            {
                // since it's left then it shows the main screen 
                // it hides the notification tray
                this.Show();
                this.WindowState = FormWindowState.Normal;
                notification_tray.Visible = false;
            }
        }
        public void remove_frrm_list(string target, string source)
        {
            variables.list_to_copy.Remove(target);
            variables.list_to_copy.Remove(source);
            variables.count = variables.list_to_copy.Count;
            variables.checkcount = variables.count;
        }
        private void io(string dir)
        {
            string[] folders;
            try
            {
                folders = Directory.GetDirectories(dir);
            }
            catch (Exception)
            {
                string folderPath = dir;
                string adminUserName = Environment.UserName;// getting your adminUserName
                DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);

                string path = dir;
                var accessControlList = Directory.GetAccessControl(path);
                var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

                foreach (FileSystemAccessRule rule in accessRules)
                {
                    if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

                    //if (rule.AccessControlType == AccessControlType.Allow)
                    //{
                    //    ds.AddAccessRule(fsa);
                    //    Directory.SetAccessControl(folderPath, ds);
                    //    break;
                    //}
                    //else 
                    if (rule.AccessControlType == AccessControlType.Deny)
                    {
                        ds.RemoveAccessRule(fsa);
                        Directory.SetAccessControl(folderPath, ds);
                        break;
                    }
                }
                folders = Directory.GetDirectories(dir);
            }
            foreach (string single in folders)
            {

                string folderPath = single;
                string adminUserName = Environment.UserName;// getting your adminUserName
                DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);

                string path = single;
                var accessControlList = Directory.GetAccessControl(path);
                var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

                foreach (FileSystemAccessRule rule in accessRules)
                {
                    if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

                    //if (rule.AccessControlType == AccessControlType.Allow)
                    //{
                    //    ds.AddAccessRule(fsa);
                    //    Directory.SetAccessControl(folderPath, ds);
                    //    break;
                    //}
                    //else 
                    if (rule.AccessControlType == AccessControlType.Deny)
                    {

                        ds.RemoveAccessRule(fsa);
                        Directory.SetAccessControl(folderPath, ds);
                        break;
                    }
                }
            }
            // recurssion occurs here
            foreach (DirectoryInfo diSourceSubDir in new DirectoryInfo(dir).GetDirectories())
            {
                io(diSourceSubDir.FullName);
            }
        }
        private void iofiles(string dir)
        {
            string[] folders = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
            foreach (string single in folders)
            {

                string folderPath = single;
                string adminUserName = Environment.UserName;// getting your adminUserName
                DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);

                string path = single;
                var accessControlList = Directory.GetAccessControl(path);
                var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

                foreach (FileSystemAccessRule rule in accessRules)
                {
                    if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

                    if (rule.AccessControlType == AccessControlType.Allow)
                    {
                        ds.AddAccessRule(fsa);
                        Directory.SetAccessControl(folderPath, ds);
                        break;
                    }
                    else if (rule.AccessControlType == AccessControlType.Deny)
                    {

                        ds.RemoveAccessRule(fsa);
                        Directory.SetAccessControl(folderPath, ds);
                        break;
                    }
                }
            }

        }
        private void security_settings(String all_files)
        {
            string[] allfiles = Directory.GetFiles(all_files, "*.*", SearchOption.AllDirectories);
            string[] alldir = Directory.GetDirectories(all_files, "*.*", SearchOption.AllDirectories);
            string adminUserName = Environment.UserName;// getting your adminUserName
            foreach (string each_file in allfiles)
            {
                DirectorySecurity ds = Directory.GetAccessControl(each_file);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
                var accessControlList = Directory.GetAccessControl(each_file);
                var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

                foreach (FileSystemAccessRule rule in accessRules)
                {
                    if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

                    if (rule.AccessControlType == AccessControlType.Allow)
                    {
                        ds.AddAccessRule(fsa);
                        Directory.SetAccessControl(each_file, ds);
                    }
                    else if (rule.AccessControlType == AccessControlType.Deny)
                    {
                        ds.RemoveAccessRule(fsa);
                        Directory.SetAccessControl(each_file, ds);
                    }
                }
            }
            foreach (string each_file in alldir)
            {
                DirectorySecurity ds = Directory.GetAccessControl(each_file);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
                var accessControlList = Directory.GetAccessControl(each_file);
                var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

                foreach (FileSystemAccessRule rule in accessRules)
                {
                    if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

                    if (rule.AccessControlType == AccessControlType.Allow)
                    {
                        ds.AddAccessRule(fsa);
                        Directory.SetAccessControl(each_file, ds);
                    }
                    else if (rule.AccessControlType == AccessControlType.Deny)
                    {
                        ds.RemoveAccessRule(fsa);
                        Directory.SetAccessControl(each_file, ds);
                    }
                }
            }
        }
        private void security_button_Click(object sender, EventArgs e)
        {
            lock_folder_dialog.Description = "SELECT A FOLDER";
            lock_folder_dialog.SelectedPath = variables.target_directory.FullName;
            lock_folder_dialog.ShowDialog();
            string folderPath = lock_folder_dialog.SelectedPath;
            string adminUserName = Environment.UserName;// getting your adminUserName
            DirectorySecurity ds = Directory.GetAccessControl(folderPath);
            FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
            var accessControlList = Directory.GetAccessControl(folderPath);
            var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

            foreach (FileSystemAccessRule rule in accessRules)
            {
                if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

                if (rule.AccessControlType == AccessControlType.Allow)
                {
                    switch (MessageBox.Show("DO YOU WANT TO LOCK FOLDER?", "CONTINUE WITH LOCKING", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        case DialogResult.Yes:
                            security_settings(folderPath);
                            ds.AddAccessRule(fsa);
                            Directory.SetAccessControl(folderPath, ds);
                            WriteCharacters(string.Format("LOCKED {0}.", folderPath), variables.save_log_file);
                            MessageBox.Show("LOCKED FOLDER");
                            break;
                        case DialogResult.No:
                        default:
                            break;
                    }
                    break;
                }
                else if (rule.AccessControlType == AccessControlType.Deny)
                {
                    switch (MessageBox.Show("DO YOU WANT TO UNLOCK FOLDER?", "CONTINUE WITH UNLOCKING", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        case DialogResult.Yes:
                            ds.RemoveAccessRule(fsa);
                            Directory.SetAccessControl(folderPath, ds);
                            // security_settings(folderPath);
                            io(folderPath);
                            iofiles(folderPath);
                            WriteCharacters(string.Format("UNLOCKED {0}.", folderPath), variables.save_log_file);
                            MessageBox.Show("UNLOCKED FOLDER");
                            System.Diagnostics.Process.Start(folderPath);
                            break;
                        case DialogResult.No:
                        default:
                            break;
                    }
                    break;
                }
            }
        }

        private void log_button_Click(object sender, EventArgs e)
        {
            Process.Start(variables.log_path);
        }

        private void backup_folder_button_Click(object sender, EventArgs e)
        {
            Process.Start(variables.target_directory.FullName);
        }

        private void fb_button_Click(object sender, EventArgs e)
        {
            force_start();
        }
        private void force_start()
        {
            foreach (DriveInfo usbname in DriveInfo.GetDrives().Where(usbproperty => usbproperty.DriveType == DriveType.Removable && usbproperty.IsReady))
            {
                #region ASSIGNING TARGET INFORMATION
                ManagementObjectSearcher moSearch = new ManagementObjectSearcher("Select * from Win32_LogicalDisk where Name='" + usbname.Name.Remove(usbname.ToString().Length - 1) + "'");
                variables.usbdirectory = new DirectoryInfo(usbname.Name);
                try
                {
                    foreach (var mo in moSearch.Get())
                    {
                        if (usbname.VolumeLabel == string.Empty)
                        {
                            variables.remaining_of_target = @"\[No name] [" + mo["VolumeSerialNumber"].ToString() + "]";
                        }
                        else
                        {
                            variables.remaining_of_target = @"\[" + usbname.VolumeLabel + "] [" + mo["VolumeSerialNumber"].ToString() + "]";
                        }
                    }
                }
                catch (Exception)
                {
                    remove_frrm_list(variables.target_directory.Name, usbname.Name);
                    break;
                }
                moSearch.Dispose();
                #endregion
                if (!Directory.Exists(variables.target_directory + variables.remaining_of_target) && !variables.list_to_copy.Contains(usbname.Name))
                {
                    Directory.CreateDirectory(variables.target_directory + variables.remaining_of_target);
                }
                variables.list_to_copy.Add(usbname.Name);
                variables.list_to_copy2.Add(variables.target_directory.ToString() + variables.remaining_of_target);
                variables.count = variables.list_to_copy.Count();
                process_copy();
                variables.newfilesfound = false;
            }
        }
        // responsible for saving log files
        private async void WriteCharacters(string text, bool log_status)
        {
            if (log_status == true)
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
                {
                    using (StreamWriter writer = new StreamWriter(variables.log_path, true))
                    {
                        WriteCharacters(ee.Message, log_status);
                    }
                }
            }
            else return;
        }
    }
}
