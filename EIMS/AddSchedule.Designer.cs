namespace EIMS
{
    partial class AddSchedule
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.time1ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.Day = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.room1TextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.scheduleGrid = new MetroFramework.Controls.MetroGrid();
            this.gridDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day1TextBox1 = new MetroFramework.Controls.MetroComboBox();
            this.nameLabel = new MetroFramework.Controls.MetroLabel();
            this.batchLabel = new MetroFramework.Controls.MetroLabel();
            this.seassionLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // time1ComboBox
            // 
            this.time1ComboBox.FormattingEnabled = true;
            this.time1ComboBox.ItemHeight = 23;
            this.time1ComboBox.Items.AddRange(new object[] {
            "8.01   -  9.00",
            "9.01   -  10.00",
            "10.01 -  11.00",
            "11.01 -  12.00",
            "1.01   -  2.00",
            "3.01   -  4.00",
            "4.01   -  5.00"});
            this.time1ComboBox.Location = new System.Drawing.Point(119, 228);
            this.time1ComboBox.Name = "time1ComboBox";
            this.time1ComboBox.Size = new System.Drawing.Size(208, 29);
            this.time1ComboBox.TabIndex = 35;
            this.time1ComboBox.UseSelectable = true;
            // 
            // Day
            // 
            this.Day.AutoSize = true;
            this.Day.Location = new System.Drawing.Point(46, 195);
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(40, 19);
            this.Day.TabIndex = 34;
            this.Day.Text = "Day 1";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(46, 273);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(45, 19);
            this.metroLabel5.TabIndex = 32;
            this.metroLabel5.Text = "Room";
            // 
            // room1TextBox
            // 
            // 
            // 
            // 
            this.room1TextBox.CustomButton.Image = null;
            this.room1TextBox.CustomButton.Location = new System.Drawing.Point(186, 1);
            this.room1TextBox.CustomButton.Name = "";
            this.room1TextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.room1TextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.room1TextBox.CustomButton.TabIndex = 1;
            this.room1TextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.room1TextBox.CustomButton.UseSelectable = true;
            this.room1TextBox.CustomButton.Visible = false;
            this.room1TextBox.Lines = new string[0];
            this.room1TextBox.Location = new System.Drawing.Point(119, 269);
            this.room1TextBox.MaxLength = 50;
            this.room1TextBox.Name = "room1TextBox";
            this.room1TextBox.PasswordChar = '\0';
            this.room1TextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.room1TextBox.SelectedText = "";
            this.room1TextBox.SelectionLength = 0;
            this.room1TextBox.SelectionStart = 0;
            this.room1TextBox.ShortcutsEnabled = true;
            this.room1TextBox.Size = new System.Drawing.Size(208, 23);
            this.room1TextBox.TabIndex = 31;
            this.room1TextBox.UseSelectable = true;
            this.room1TextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.room1TextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(46, 233);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(38, 19);
            this.metroLabel4.TabIndex = 30;
            this.metroLabel4.Text = "Time";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(168, 330);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(103, 51);
            this.metroButton1.TabIndex = 36;
            this.metroButton1.Text = "Add Schedule";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // scheduleGrid
            // 
            this.scheduleGrid.AllowUserToResizeRows = false;
            this.scheduleGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.scheduleGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scheduleGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.scheduleGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.scheduleGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.scheduleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scheduleGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridDay,
            this.gridTime,
            this.gridroom});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.scheduleGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.scheduleGrid.EnableHeadersVisualStyles = false;
            this.scheduleGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.scheduleGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.scheduleGrid.Location = new System.Drawing.Point(409, 171);
            this.scheduleGrid.Name = "scheduleGrid";
            this.scheduleGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.scheduleGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.scheduleGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.scheduleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scheduleGrid.Size = new System.Drawing.Size(347, 284);
            this.scheduleGrid.TabIndex = 37;
            this.scheduleGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellContentClick);
            // 
            // gridDay
            // 
            this.gridDay.HeaderText = "Day";
            this.gridDay.Name = "gridDay";
            // 
            // gridTime
            // 
            this.gridTime.HeaderText = "Time";
            this.gridTime.Name = "gridTime";
            // 
            // gridroom
            // 
            this.gridroom.HeaderText = "Room";
            this.gridroom.Name = "gridroom";
            // 
            // day1TextBox1
            // 
            this.day1TextBox1.FormattingEnabled = true;
            this.day1TextBox1.ItemHeight = 23;
            this.day1TextBox1.Items.AddRange(new object[] {
            "Saturday",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday"});
            this.day1TextBox1.Location = new System.Drawing.Point(119, 185);
            this.day1TextBox1.Name = "day1TextBox1";
            this.day1TextBox1.Size = new System.Drawing.Size(208, 29);
            this.day1TextBox1.TabIndex = 38;
            this.day1TextBox1.UseSelectable = true;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(46, 89);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(81, 19);
            this.nameLabel.TabIndex = 39;
            this.nameLabel.Text = "metroLabel1";
            // 
            // batchLabel
            // 
            this.batchLabel.AutoSize = true;
            this.batchLabel.Location = new System.Drawing.Point(255, 89);
            this.batchLabel.Name = "batchLabel";
            this.batchLabel.Size = new System.Drawing.Size(83, 19);
            this.batchLabel.TabIndex = 40;
            this.batchLabel.Text = "metroLabel2";
            // 
            // seassionLabel
            // 
            this.seassionLabel.AutoSize = true;
            this.seassionLabel.Location = new System.Drawing.Point(523, 89);
            this.seassionLabel.Name = "seassionLabel";
            this.seassionLabel.Size = new System.Drawing.Size(83, 19);
            this.seassionLabel.TabIndex = 42;
            this.seassionLabel.Text = "metroLabel6";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(512, 149);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(109, 19);
            this.metroLabel1.TabIndex = 43;
            this.metroLabel1.Text = "Current Schedule";
            // 
            // AddSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 480);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.seassionLabel);
            this.Controls.Add(this.batchLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.day1TextBox1);
            this.Controls.Add(this.scheduleGrid);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.time1ComboBox);
            this.Controls.Add(this.Day);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.room1TextBox);
            this.Controls.Add(this.metroLabel4);
            this.Name = "AddSchedule";
            this.Text = "AddSchedule";
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox time1ComboBox;
        private MetroFramework.Controls.MetroLabel Day;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox room1TextBox;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroGrid scheduleGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridroom;
        private MetroFramework.Controls.MetroComboBox day1TextBox1;
        private MetroFramework.Controls.MetroLabel nameLabel;
        private MetroFramework.Controls.MetroLabel batchLabel;
        private MetroFramework.Controls.MetroLabel seassionLabel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}