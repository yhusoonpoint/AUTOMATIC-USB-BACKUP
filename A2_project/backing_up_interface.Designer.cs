using System;

namespace A2_project
{
    partial class backing_up_interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(backing_up_interface));
            this.all_file_progressbar = new System.Windows.Forms.ProgressBar();
            this.file_info_label = new System.Windows.Forms.Label();
            this.total_files_percentage_label = new System.Windows.Forms.Label();
            this.cancel_button = new System.Windows.Forms.Button();
            this.pg_button = new System.Windows.Forms.Button();
            this.hide_button = new System.Windows.Forms.Button();
            this.move_button = new System.Windows.Forms.Button();
            this.notification_tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.total_files_label = new System.Windows.Forms.Label();
            this.current_file_progressbar = new System.Windows.Forms.ProgressBar();
            this.current_file_percentage_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // all_file_progressbar
            // 
            this.all_file_progressbar.ForeColor = System.Drawing.Color.DimGray;
            this.all_file_progressbar.Location = new System.Drawing.Point(28, 34);
            this.all_file_progressbar.Name = "all_file_progressbar";
            this.all_file_progressbar.Size = new System.Drawing.Size(366, 23);
            this.all_file_progressbar.TabIndex = 4;
            // 
            // file_info_label
            // 
            this.file_info_label.AutoSize = true;
            this.file_info_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file_info_label.ForeColor = System.Drawing.Color.White;
            this.file_info_label.Location = new System.Drawing.Point(28, 61);
            this.file_info_label.Name = "file_info_label";
            this.file_info_label.Size = new System.Drawing.Size(158, 13);
            this.file_info_label.TabIndex = 5;
            this.file_info_label.Text = "COPYING .......................";
            // 
            // total_files_percentage_label
            // 
            this.total_files_percentage_label.AutoSize = true;
            this.total_files_percentage_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_files_percentage_label.ForeColor = System.Drawing.Color.White;
            this.total_files_percentage_label.Location = new System.Drawing.Point(392, 38);
            this.total_files_percentage_label.Name = "total_files_percentage_label";
            this.total_files_percentage_label.Size = new System.Drawing.Size(48, 17);
            this.total_files_percentage_label.TabIndex = 6;
            this.total_files_percentage_label.Text = "100%";
            // 
            // cancel_button
            // 
            this.cancel_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_button.ForeColor = System.Drawing.Color.DimGray;
            this.cancel_button.Location = new System.Drawing.Point(28, 109);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(87, 23);
            this.cancel_button.TabIndex = 7;
            this.cancel_button.Text = "CANCEL";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // pg_button
            // 
            this.pg_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pg_button.ForeColor = System.Drawing.Color.DimGray;
            this.pg_button.Location = new System.Drawing.Point(337, 109);
            this.pg_button.Name = "pg_button";
            this.pg_button.Size = new System.Drawing.Size(90, 23);
            this.pg_button.TabIndex = 8;
            this.pg_button.Text = "PLAY GAME";
            this.pg_button.UseVisualStyleBackColor = true;
            this.pg_button.Click += new System.EventHandler(this.pg_button_Click);
            // 
            // hide_button
            // 
            this.hide_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hide_button.ForeColor = System.Drawing.Color.DimGray;
            this.hide_button.Location = new System.Drawing.Point(185, 109);
            this.hide_button.Name = "hide_button";
            this.hide_button.Size = new System.Drawing.Size(75, 23);
            this.hide_button.TabIndex = 9;
            this.hide_button.Text = "HIDE";
            this.hide_button.UseVisualStyleBackColor = true;
            this.hide_button.Click += new System.EventHandler(this.hide_button_Click);
            // 
            // move_button
            // 
            this.move_button.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.move_button.FlatAppearance.BorderSize = 0;
            this.move_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.move_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.move_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.move_button.Location = new System.Drawing.Point(-124, -7);
            this.move_button.Name = "move_button";
            this.move_button.Size = new System.Drawing.Size(694, 23);
            this.move_button.TabIndex = 13;
            this.move_button.UseVisualStyleBackColor = true;
            this.move_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.move_button_MouseDown);
            this.move_button.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move_button_MouseMove);
            this.move_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.move_button_MouseUp);
            // 
            // notification_tray
            // 
            this.notification_tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notification_tray.BalloonTipText = "BACKUP COMPLETED";
            this.notification_tray.BalloonTipTitle = "AUTOMATIC USB BACKUP";
            this.notification_tray.Icon = ((System.Drawing.Icon)(resources.GetObject("notification_tray.Icon")));
            this.notification_tray.Text = "notification_tray";
            // 
            // total_files_label
            // 
            this.total_files_label.AutoSize = true;
            this.total_files_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_files_label.ForeColor = System.Drawing.Color.White;
            this.total_files_label.Location = new System.Drawing.Point(28, 18);
            this.total_files_label.Name = "total_files_label";
            this.total_files_label.Size = new System.Drawing.Size(158, 13);
            this.total_files_label.TabIndex = 14;
            this.total_files_label.Text = "COPYING .......................";
            // 
            // current_file_progressbar
            // 
            this.current_file_progressbar.ForeColor = System.Drawing.Color.DimGray;
            this.current_file_progressbar.Location = new System.Drawing.Point(28, 76);
            this.current_file_progressbar.Name = "current_file_progressbar";
            this.current_file_progressbar.Size = new System.Drawing.Size(366, 23);
            this.current_file_progressbar.TabIndex = 15;
            // 
            // current_file_percentage_label
            // 
            this.current_file_percentage_label.AutoSize = true;
            this.current_file_percentage_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current_file_percentage_label.ForeColor = System.Drawing.Color.White;
            this.current_file_percentage_label.Location = new System.Drawing.Point(392, 79);
            this.current_file_percentage_label.Name = "current_file_percentage_label";
            this.current_file_percentage_label.Size = new System.Drawing.Size(48, 17);
            this.current_file_percentage_label.TabIndex = 16;
            this.current_file_percentage_label.Text = "100%";
            // 
            // backing_up_interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(446, 143);
            this.Controls.Add(this.current_file_progressbar);
            this.Controls.Add(this.all_file_progressbar);
            this.Controls.Add(this.current_file_percentage_label);
            this.Controls.Add(this.total_files_label);
            this.Controls.Add(this.move_button);
            this.Controls.Add(this.hide_button);
            this.Controls.Add(this.pg_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.total_files_percentage_label);
            this.Controls.Add(this.file_info_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(446, 113);
            this.Name = "backing_up_interface";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "backing_up_interface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.backing_up_interface_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar all_file_progressbar;
        private System.Windows.Forms.Label file_info_label;
        private System.Windows.Forms.Label total_files_percentage_label;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button pg_button;
        private System.Windows.Forms.Button hide_button;
        private System.Windows.Forms.Button move_button;
        private System.Windows.Forms.NotifyIcon notification_tray;
        private System.Windows.Forms.Label total_files_label;
        private System.Windows.Forms.ProgressBar current_file_progressbar;
        private System.Windows.Forms.Label current_file_percentage_label;
    }
}