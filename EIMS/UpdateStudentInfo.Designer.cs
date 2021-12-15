namespace EIMS
{
    partial class UpdateInfo
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
            this.label = new MetroFramework.Controls.MetroLabel();
            this.InfoTextBox = new MetroFramework.Controls.MetroTextBox();
            this.UpdateButton = new MetroFramework.Controls.MetroButton();
            this.cancellButton = new MetroFramework.Controls.MetroButton();
            this.DateTime = new MetroFramework.Controls.MetroDateTime();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.label.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.label.Location = new System.Drawing.Point(33, 97);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(111, 25);
            this.label.TabIndex = 0;
            this.label.Text = "metroLabel1";
            // 
            // InfoTextBox
            // 
            // 
            // 
            // 
            this.InfoTextBox.CustomButton.Image = null;
            this.InfoTextBox.CustomButton.Location = new System.Drawing.Point(256, 1);
            this.InfoTextBox.CustomButton.Name = "";
            this.InfoTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.InfoTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.InfoTextBox.CustomButton.TabIndex = 1;
            this.InfoTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.InfoTextBox.CustomButton.UseSelectable = true;
            this.InfoTextBox.CustomButton.Visible = false;
            this.InfoTextBox.Lines = new string[0];
            this.InfoTextBox.Location = new System.Drawing.Point(317, 97);
            this.InfoTextBox.MaxLength = 50;
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.PasswordChar = '\0';
            this.InfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.InfoTextBox.SelectedText = "";
            this.InfoTextBox.SelectionLength = 0;
            this.InfoTextBox.SelectionStart = 0;
            this.InfoTextBox.ShortcutsEnabled = true;
            this.InfoTextBox.Size = new System.Drawing.Size(278, 23);
            this.InfoTextBox.TabIndex = 1;
            this.InfoTextBox.UseSelectable = true;
            this.InfoTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.InfoTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(104, 171);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(129, 23);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseSelectable = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // cancellButton
            // 
            this.cancellButton.Location = new System.Drawing.Point(317, 171);
            this.cancellButton.Name = "cancellButton";
            this.cancellButton.Size = new System.Drawing.Size(125, 23);
            this.cancellButton.TabIndex = 3;
            this.cancellButton.Text = "Cancell";
            this.cancellButton.UseSelectable = true;
            this.cancellButton.Click += new System.EventHandler(this.cancellButton_Click);
            // 
            // DateTime
            // 
            this.DateTime.Location = new System.Drawing.Point(317, 91);
            this.DateTime.MinimumSize = new System.Drawing.Size(0, 29);
            this.DateTime.Name = "DateTime";
            this.DateTime.Size = new System.Drawing.Size(220, 29);
            this.DateTime.TabIndex = 4;
            this.DateTime.Visible = false;
            // 
            // UpdateInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 217);
            this.Controls.Add(this.DateTime);
            this.Controls.Add(this.cancellButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.InfoTextBox);
            this.Controls.Add(this.label);
            this.Name = "UpdateInfo";
            this.Text = "Update Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel label;
        private MetroFramework.Controls.MetroTextBox InfoTextBox;
        private MetroFramework.Controls.MetroButton UpdateButton;
        private MetroFramework.Controls.MetroButton cancellButton;
        private MetroFramework.Controls.MetroDateTime DateTime;
    }
}