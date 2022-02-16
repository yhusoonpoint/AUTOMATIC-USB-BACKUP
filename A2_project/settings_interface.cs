using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2_project
{
    public partial class settings_interface : Form
    {
        // The path to the key where Windows looks for startup applications
        RegistryKey check_registry = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public settings_interface()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(variables.CreateRoundRectRgn(50, 0, Width, Height, 50, 50));
            move_button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            string[] lines = File.ReadAllLines(variables.file_path);
            for (int i = 0; i < lines.Length; i++)
            {
                assigning_variables(i, "RUN_AT_STARTUP_TRUE", "RUN_AT_STARTUP_FALSE", ras_checkbox, variables.run_at_startup);
                assigning_variables(i, "BACKUP_SILENTLY_TRUE", "BACKUP_SILENTLY_FALSE", bs_silently, variables.backup_silently);
                assigning_variables(i, "AUTOMATIC_LOCK_FOLDER_TRUE", "AUTOMATIC_LOCK_FOLDER_FALSE", alf_checkbox, variables.automatic_lock_folder);
                assigning_variables(i, "AUTOMATIC_BACKUP_TRUE", "AUTOMATIC_BACKUP_FALSE", ab_checkbox, variables.automatic_backup);
                assigning_variables(i, "OVERWRITE_FILES_TRUE", "OVERWRITE_FILES_FALSE", of_checkbox, variables.overwrite_files);
                assigning_variables(i, "SAVE_LOG_FILES_TRUE", "SAVE_LOG_FILES_FALSE", slf_checkbox, variables.save_log_file);
                if (lines[i].Contains("DIRECTORY_"))
                {
                    variables.target_directory = new DirectoryInfo(lines[i].Remove(0, 10));
                }
            }
            directory_textbox.Text = variables.target_directory.ToString();
        }
        string[] lines = File.ReadAllLines(variables.file_path);
        private void assigning_variables(int i, string first_check, string second_check, CheckBox what_checkbox,bool checkbox)
        {
            if (lines[i].Contains(first_check))
            {
                what_checkbox.Checked = true;
                checkbox = true;
            }
            else if ((lines[i].Contains(second_check)))
            {
                what_checkbox.Checked = false;
                checkbox = false;
            }
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

        private void close_button_Click(object sender, EventArgs e)
        {
            save_changes(ras_checkbox,variables.run_at_startup, "RUN_AT_STARTUP_TRUE", "RUN_AT_STARTUP_FALSE");
            save_changes(bs_silently, variables.backup_silently, "BACKUP_SILENTLY_TRUE","BACKUP_SILENTLY_FALSE");
            save_changes(alf_checkbox,variables.automatic_lock_folder, "AUTOMATIC_LOCK_FOLDER_TRUE", "AUTOMATIC_LOCK_FOLDER_FALSE");
            save_changes(ab_checkbox,variables.automatic_backup, "AUTOMATIC_BACKUP_TRUE", "AUTOMATIC_BACKUP_FALSE");
            save_changes(of_checkbox,variables.overwrite_files, "OVERWRITE_FILES_TRUE", "OVERWRITE_FILES_FALSE");
            save_changes(slf_checkbox,variables.save_log_file,"SAVE_LOG_FILES_TRUE", "SAVE_LOG_FILES_FALSE"); 
            if(!directory_textbox.Text.Contains("backup"))
            {
                directory_textbox.Text += directory_textbox.Text + @"\backup";
            }
            if(directory_textbox.Text != variables.target_directory.ToString())
            {
                if (!Directory.Exists(directory_textbox.Text))
                {
                    try
                    {
                        Directory.CreateDirectory(directory_textbox.Text);
                    }
                    catch(Exception)
                    { MessageBox.Show("DIRECTORY DOESN'T EXIST AND CAN'T BE CREATED");directory_textbox.Text = variables.target_directory.ToString(); }
                }
                string text_to_replace = File.ReadAllText(variables.file_path);
                string[] lines = File.ReadAllLines(variables.file_path);
                int line =0;
                for(int i = 0; i<lines.Count(); i++)
                {
                    if (lines[i].Contains("DIRECTORY_"))
                    {
                        line = i;
                        break;
                    }
                }
                text_to_replace = text_to_replace.Replace(lines[line], "DIRECTORY_"+directory_textbox.Text);
                File.WriteAllText(variables.file_path, text_to_replace);   
            }
            main_interface mi = new main_interface();
            string all_files = File.ReadAllText(variables.file_path);
            if (all_files.Contains("AUTOMATIC_BACKUP_TRUE"))
            {
                mi.update_usbchecker(true);
                mi.Update();
            }
            else if (all_files.Contains("AUTOMATIC_BACKUP_FALSE"))
            {
                mi.update_usbchecker(false);
                mi.Update();
            }
            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.settings_interface_FormClosing);
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
            this.Close();
        }
        private void save_changes(CheckBox checkbox, bool what_checkbox, string text_name, string text_name2)
        {
            // replaces tect in the file
            string text_to_replace = File.ReadAllText(variables.file_path);
            if (text_to_replace.Contains(text_name) && checkbox.Checked == false)
            {
                text_to_replace = text_to_replace.Replace(text_name, text_name2);
                File.WriteAllText(variables.file_path, text_to_replace); what_checkbox = false; ;
            }
            else if (text_to_replace.Contains(text_name) && checkbox.Checked == true)
            {
                text_to_replace = text_to_replace.Replace(text_name, text_name);
                File.WriteAllText(variables.file_path, text_to_replace); what_checkbox = true;
            }
            else if (text_to_replace.Contains(text_name2) && checkbox.Checked == true)
            {
                text_to_replace = text_to_replace.Replace(text_name2, text_name);
                File.WriteAllText(variables.file_path, text_to_replace); what_checkbox = true;
            }
            else if (text_to_replace.Contains(text_name2) && checkbox.Checked == false)
            {
                text_to_replace = text_to_replace.Replace(text_name2, text_name2);
                File.WriteAllText(variables.file_path, text_to_replace); what_checkbox = true;
            }

            if (!text_to_replace.Contains(text_name) && !text_to_replace.Contains(text_name2))
            {
                what_checkbox = Convert.ToBoolean(checkbox.CheckState);
                StreamWriter write_new_file = new StreamWriter(variables.file_path, true);
                write_new_file.WriteLine(string.Empty);
                write_new_file.WriteLine(text_name.Replace("TRUE" ?? "FALSE", checkbox.Checked.ToString().ToUpper()), true);
                write_new_file.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderdialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                directory_textbox.Text = folderdialog.SelectedPath;
            }
        }

        private void settings_interface_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

    }
}
