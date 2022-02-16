namespace A2_project
{
    partial class settings_interface
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
            this.label1 = new System.Windows.Forms.Label();
            this.move_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.directory_textbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.ras_checkbox = new System.Windows.Forms.CheckBox();
            this.alf_checkbox = new System.Windows.Forms.CheckBox();
            this.bs_silently = new System.Windows.Forms.CheckBox();
            this.of_checkbox = new System.Windows.Forms.CheckBox();
            this.ab_checkbox = new System.Windows.Forms.CheckBox();
            this.slf_checkbox = new System.Windows.Forms.CheckBox();
            this.two_curve_edge_picturebox1 = new A2_project.two_curve_edge_picturebox();
            this.folderdialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.two_curve_edge_picturebox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(256, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "SETTINGS";
            // 
            // move_button
            // 
            this.move_button.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.move_button.FlatAppearance.BorderSize = 0;
            this.move_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.move_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.move_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.move_button.Location = new System.Drawing.Point(-3, -2);
            this.move_button.Name = "move_button";
            this.move_button.Size = new System.Drawing.Size(694, 23);
            this.move_button.TabIndex = 12;
            this.move_button.UseVisualStyleBackColor = true;
            this.move_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.move_button_MouseDown);
            this.move_button.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move_button_MouseMove);
            this.move_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.move_button_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(269, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "DIRECTORY";
            // 
            // directory_textbox
            // 
            this.directory_textbox.Location = new System.Drawing.Point(242, 220);
            this.directory_textbox.Name = "directory_textbox";
            this.directory_textbox.Size = new System.Drawing.Size(186, 20);
            this.directory_textbox.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(256, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "BROWSE DIRECTORY";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // close_button
            // 
            this.close_button.BackColor = System.Drawing.Color.FloralWhite;
            this.close_button.ForeColor = System.Drawing.Color.RoyalBlue;
            this.close_button.Location = new System.Drawing.Point(304, 377);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(77, 23);
            this.close_button.TabIndex = 22;
            this.close_button.Text = "CLOSE";
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // ras_checkbox
            // 
            this.ras_checkbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ras_checkbox.AutoSize = true;
            this.ras_checkbox.Checked = true;
            this.ras_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ras_checkbox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ras_checkbox.Location = new System.Drawing.Point(80, 92);
            this.ras_checkbox.Name = "ras_checkbox";
            this.ras_checkbox.Size = new System.Drawing.Size(112, 23);
            this.ras_checkbox.TabIndex = 23;
            this.ras_checkbox.Text = "RUN AT STARTUP";
            this.ras_checkbox.UseVisualStyleBackColor = true;
            // 
            // alf_checkbox
            // 
            this.alf_checkbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.alf_checkbox.AutoSize = true;
            this.alf_checkbox.Checked = true;
            this.alf_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alf_checkbox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.alf_checkbox.Location = new System.Drawing.Point(441, 92);
            this.alf_checkbox.Name = "alf_checkbox";
            this.alf_checkbox.Size = new System.Drawing.Size(157, 23);
            this.alf_checkbox.TabIndex = 24;
            this.alf_checkbox.Text = "AUTOMATIC LOCK FOLDER";
            this.alf_checkbox.UseVisualStyleBackColor = true;
            // 
            // bs_silently
            // 
            this.bs_silently.Appearance = System.Windows.Forms.Appearance.Button;
            this.bs_silently.AutoSize = true;
            this.bs_silently.Checked = true;
            this.bs_silently.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bs_silently.ForeColor = System.Drawing.Color.RoyalBlue;
            this.bs_silently.Location = new System.Drawing.Point(80, 218);
            this.bs_silently.Name = "bs_silently";
            this.bs_silently.Size = new System.Drawing.Size(114, 23);
            this.bs_silently.TabIndex = 25;
            this.bs_silently.Text = "BACKUP SILENTLY";
            this.bs_silently.UseVisualStyleBackColor = true;
            // 
            // of_checkbox
            // 
            this.of_checkbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.of_checkbox.AutoSize = true;
            this.of_checkbox.Checked = true;
            this.of_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.of_checkbox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.of_checkbox.Location = new System.Drawing.Point(483, 218);
            this.of_checkbox.Name = "of_checkbox";
            this.of_checkbox.Size = new System.Drawing.Size(115, 23);
            this.of_checkbox.TabIndex = 26;
            this.of_checkbox.Text = "OVERWRITE FILES";
            this.of_checkbox.UseVisualStyleBackColor = true;
            // 
            // ab_checkbox
            // 
            this.ab_checkbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ab_checkbox.AutoSize = true;
            this.ab_checkbox.Checked = true;
            this.ab_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ab_checkbox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ab_checkbox.Location = new System.Drawing.Point(80, 342);
            this.ab_checkbox.Name = "ab_checkbox";
            this.ab_checkbox.Size = new System.Drawing.Size(126, 23);
            this.ab_checkbox.TabIndex = 27;
            this.ab_checkbox.Text = "AUTOMATIC BACKUP";
            this.ab_checkbox.UseVisualStyleBackColor = true;
            // 
            // slf_checkbox
            // 
            this.slf_checkbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.slf_checkbox.AutoSize = true;
            this.slf_checkbox.Checked = true;
            this.slf_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.slf_checkbox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.slf_checkbox.Location = new System.Drawing.Point(496, 342);
            this.slf_checkbox.Name = "slf_checkbox";
            this.slf_checkbox.Size = new System.Drawing.Size(102, 23);
            this.slf_checkbox.TabIndex = 28;
            this.slf_checkbox.Text = "SAVE LOG FILES";
            this.slf_checkbox.UseVisualStyleBackColor = true;
            // 
            // two_curve_edge_picturebox1
            // 
            this.two_curve_edge_picturebox1.BackColor = System.Drawing.Color.SlateGray;
            this.two_curve_edge_picturebox1.Location = new System.Drawing.Point(80, 12);
            this.two_curve_edge_picturebox1.Name = "two_curve_edge_picturebox1";
            this.two_curve_edge_picturebox1.Size = new System.Drawing.Size(518, 45);
            this.two_curve_edge_picturebox1.TabIndex = 14;
            this.two_curve_edge_picturebox1.TabStop = false;
            // 
            // settings_interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(623, 427);
            this.Controls.Add(this.slf_checkbox);
            this.Controls.Add(this.ab_checkbox);
            this.Controls.Add(this.of_checkbox);
            this.Controls.Add(this.bs_silently);
            this.Controls.Add(this.alf_checkbox);
            this.Controls.Add(this.ras_checkbox);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.directory_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.move_button);
            this.Controls.Add(this.two_curve_edge_picturebox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(623, 427);
            this.MinimumSize = new System.Drawing.Size(623, 427);
            this.Name = "settings_interface";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.settings_interface_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.two_curve_edge_picturebox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button move_button;
        private two_curve_edge_picturebox two_curve_edge_picturebox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox directory_textbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.CheckBox ras_checkbox;
        private System.Windows.Forms.CheckBox alf_checkbox;
        private System.Windows.Forms.CheckBox bs_silently;
        private System.Windows.Forms.CheckBox of_checkbox;
        private System.Windows.Forms.CheckBox ab_checkbox;
        private System.Windows.Forms.CheckBox slf_checkbox;
        private System.Windows.Forms.FolderBrowserDialog folderdialog;
    }
}