using System.Drawing;

namespace A2_project
{
    partial class main_interface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_interface));
            this.move_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.usbchecker_timer = new System.Windows.Forms.Timer(this.components);
            this.close_button = new System.Windows.Forms.Button();
            this.notification_tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.force_close = new System.Windows.Forms.ToolStripMenuItem();
            this.force_backup = new System.Windows.Forms.ToolStripMenuItem();
            this.lock_folder_dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.two_curve_edge_picturebox1 = new A2_project.two_curve_edge_picturebox();
            this.security_button = new A2_project.roundbutton();
            this.log_button = new A2_project.roundbutton();
            this.backup_folder_button = new A2_project.roundbutton();
            this.settings_button = new A2_project.roundbutton();
            this.fb_button = new A2_project.roundbutton();
            this.straight__line_edge_picturebox2 = new A2_project.straight__line_edge_picturebox();
            this.straight__line_edge_picturebox1 = new A2_project.straight__line_edge_picturebox();
            this.TrayIconContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.two_curve_edge_picturebox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.straight__line_edge_picturebox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.straight__line_edge_picturebox1)).BeginInit();
            this.SuspendLayout();
            // 
            // move_button
            // 
            this.move_button.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.move_button.FlatAppearance.BorderSize = 0;
            this.move_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.move_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.move_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.move_button.Location = new System.Drawing.Point(0, 0);
            this.move_button.Name = "move_button";
            this.move_button.Size = new System.Drawing.Size(694, 23);
            this.move_button.TabIndex = 0;
            this.move_button.TabStop = false;
            this.move_button.UseVisualStyleBackColor = true;
            this.move_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.move_button_MouseDown);
            this.move_button.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move_button_MouseMove);
            this.move_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.move_button_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(149, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "AUTOMATIC USB BACKUP";
            // 
            // usbchecker_timer
            // 
            this.usbchecker_timer.Interval = 1000;
            this.usbchecker_timer.Tick += new System.EventHandler(this.usbchecker_timer_Tick);
            // 
            // close_button
            // 
            this.close_button.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.close_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_button.ForeColor = System.Drawing.Color.White;
            this.close_button.Location = new System.Drawing.Point(592, 0);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(19, 23);
            this.close_button.TabIndex = 12;
            this.close_button.Text = "X";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // notification_tray
            // 
            this.notification_tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notification_tray.BalloonTipText = "MINIMIZED TO NOTIFICATION PANEL";
            this.notification_tray.BalloonTipTitle = "AUTOMATIC USB BACKUP";
            this.notification_tray.ContextMenuStrip = this.TrayIconContextMenu;
            this.notification_tray.Icon = ((System.Drawing.Icon)(resources.GetObject("notification_tray.Icon")));
            this.notification_tray.Text = "notifyIcon1";
            this.notification_tray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notification_tray_MouseClick);
            // 
            // TrayIconContextMenu
            // 
            this.TrayIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.force_close,
            this.force_backup});
            this.TrayIconContextMenu.Name = "TrayIconContextMenu";
            this.TrayIconContextMenu.Size = new System.Drawing.Size(159, 48);
            // 
            // force_close
            // 
            this.force_close.Name = "force_close";
            this.force_close.Size = new System.Drawing.Size(158, 22);
            this.force_close.Text = "FORCE CLOSE";
            this.force_close.Click += new System.EventHandler(this.force_close_Click);
            // 
            // force_backup
            // 
            this.force_backup.Name = "force_backup";
            this.force_backup.Size = new System.Drawing.Size(158, 22);
            this.force_backup.Text = "FORCE BACKUP";
            this.force_backup.Click += new System.EventHandler(this.force_backup_Click);
            // 
            // two_curve_edge_picturebox1
            // 
            this.two_curve_edge_picturebox1.BackColor = System.Drawing.Color.SlateGray;
            this.two_curve_edge_picturebox1.Location = new System.Drawing.Point(80, 12);
            this.two_curve_edge_picturebox1.Name = "two_curve_edge_picturebox1";
            this.two_curve_edge_picturebox1.Size = new System.Drawing.Size(518, 45);
            this.two_curve_edge_picturebox1.TabIndex = 11;
            this.two_curve_edge_picturebox1.TabStop = false;
            // 
            // security_button
            // 
            this.security_button.BackColor = System.Drawing.Color.RoyalBlue;
            this.security_button.FlatAppearance.BorderSize = 0;
            this.security_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.security_button.Location = new System.Drawing.Point(463, 98);
            this.security_button.Name = "security_button";
            this.security_button.Size = new System.Drawing.Size(64, 64);
            this.security_button.TabIndex = 9;
            this.security_button.Text = "LOCK OR UNLOCK FOLDER";
            this.security_button.UseVisualStyleBackColor = false;
            this.security_button.Click += new System.EventHandler(this.security_button_Click);
            // 
            // log_button
            // 
            this.log_button.BackColor = System.Drawing.Color.RoyalBlue;
            this.log_button.FlatAppearance.BorderSize = 0;
            this.log_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.log_button.Location = new System.Drawing.Point(295, 98);
            this.log_button.Name = "log_button";
            this.log_button.Size = new System.Drawing.Size(64, 64);
            this.log_button.TabIndex = 8;
            this.log_button.Text = "VIEW LOG FILES";
            this.log_button.UseVisualStyleBackColor = false;
            this.log_button.Click += new System.EventHandler(this.log_button_Click);
            // 
            // backup_folder_button
            // 
            this.backup_folder_button.BackColor = System.Drawing.Color.RoyalBlue;
            this.backup_folder_button.FlatAppearance.BorderSize = 0;
            this.backup_folder_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backup_folder_button.Location = new System.Drawing.Point(138, 98);
            this.backup_folder_button.Name = "backup_folder_button";
            this.backup_folder_button.Size = new System.Drawing.Size(64, 64);
            this.backup_folder_button.TabIndex = 7;
            this.backup_folder_button.Text = "VIEW BACKUP FOLDER";
            this.backup_folder_button.UseVisualStyleBackColor = false;
            this.backup_folder_button.Click += new System.EventHandler(this.backup_folder_button_Click);
            // 
            // settings_button
            // 
            this.settings_button.BackColor = System.Drawing.Color.RoyalBlue;
            this.settings_button.FlatAppearance.BorderSize = 0;
            this.settings_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings_button.Location = new System.Drawing.Point(427, 215);
            this.settings_button.Name = "settings_button";
            this.settings_button.Size = new System.Drawing.Size(100, 100);
            this.settings_button.TabIndex = 6;
            this.settings_button.Text = "SETTINGS";
            this.settings_button.UseVisualStyleBackColor = false;
            this.settings_button.Click += new System.EventHandler(this.settings_button_Click);
            // 
            // fb_button
            // 
            this.fb_button.BackColor = System.Drawing.Color.RoyalBlue;
            this.fb_button.FlatAppearance.BorderSize = 0;
            this.fb_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fb_button.Location = new System.Drawing.Point(138, 215);
            this.fb_button.Name = "fb_button";
            this.fb_button.Size = new System.Drawing.Size(100, 100);
            this.fb_button.TabIndex = 5;
            this.fb_button.Text = "FORCE BACKUP";
            this.fb_button.UseVisualStyleBackColor = false;
            this.fb_button.Click += new System.EventHandler(this.fb_button_Click);
            // 
            // straight__line_edge_picturebox2
            // 
            this.straight__line_edge_picturebox2.BackColor = System.Drawing.Color.SlateGray;
            this.straight__line_edge_picturebox2.Location = new System.Drawing.Point(380, 187);
            this.straight__line_edge_picturebox2.Name = "straight__line_edge_picturebox2";
            this.straight__line_edge_picturebox2.Size = new System.Drawing.Size(198, 165);
            this.straight__line_edge_picturebox2.TabIndex = 4;
            this.straight__line_edge_picturebox2.TabStop = false;
            // 
            // straight__line_edge_picturebox1
            // 
            this.straight__line_edge_picturebox1.BackColor = System.Drawing.Color.SlateGray;
            this.straight__line_edge_picturebox1.Location = new System.Drawing.Point(93, 187);
            this.straight__line_edge_picturebox1.Name = "straight__line_edge_picturebox1";
            this.straight__line_edge_picturebox1.Size = new System.Drawing.Size(198, 165);
            this.straight__line_edge_picturebox1.TabIndex = 3;
            this.straight__line_edge_picturebox1.TabStop = false;
            // 
            // main_interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(623, 427);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.move_button);
            this.Controls.Add(this.two_curve_edge_picturebox1);
            this.Controls.Add(this.security_button);
            this.Controls.Add(this.log_button);
            this.Controls.Add(this.backup_folder_button);
            this.Controls.Add(this.settings_button);
            this.Controls.Add(this.fb_button);
            this.Controls.Add(this.straight__line_edge_picturebox2);
            this.Controls.Add(this.straight__line_edge_picturebox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(623, 427);
            this.MinimumSize = new System.Drawing.Size(623, 427);
            this.Name = "main_interface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatic Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_interface_FormClosing);
            this.TrayIconContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.two_curve_edge_picturebox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.straight__line_edge_picturebox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.straight__line_edge_picturebox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button move_button;
        private straight__line_edge_picturebox straight__line_edge_picturebox1;
        private straight__line_edge_picturebox straight__line_edge_picturebox2;
        private roundbutton fb_button;
        private roundbutton settings_button;
        private roundbutton backup_folder_button;
        private roundbutton log_button;
        private roundbutton security_button;
        private System.Windows.Forms.Label label1;
        private two_curve_edge_picturebox two_curve_edge_picturebox1;
        private System.Windows.Forms.Timer usbchecker_timer;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.NotifyIcon notification_tray;
        private System.Windows.Forms.ContextMenuStrip TrayIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem force_close;
        private System.Windows.Forms.ToolStripMenuItem force_backup;
        private System.Windows.Forms.FolderBrowserDialog lock_folder_dialog;
    }
}

