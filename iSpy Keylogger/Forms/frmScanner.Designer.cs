namespace Galaxy_Logger.Forms
{
    partial class frmScanner
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
            this.slcTheme1 = new MonoFlat.MonoFlat_ThemeContainer();
            this.label2 = new MonoFlat.MonoFlat_Label();
            this.slcTextBox2 = new MonoFlat.MonoFlat_TextBox();
            this.label1 = new MonoFlat.MonoFlat_Label();
            this.slcTextBox1 = new MonoFlat.MonoFlat_TextBox();
            this.slCbtn1 = new MonoFlat.MonoFlat_Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.slcClose1 = new MonoFlat.MonoFlat_ControlBox();
            this.slcTheme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // slcTheme1
            // 
            this.slcTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(57)))), ((int)(((byte)(72)))));
            this.slcTheme1.Controls.Add(this.label2);
            this.slcTheme1.Controls.Add(this.slcTextBox2);
            this.slcTheme1.Controls.Add(this.label1);
            this.slcTheme1.Controls.Add(this.slcTextBox1);
            this.slcTheme1.Controls.Add(this.slCbtn1);
            this.slcTheme1.Controls.Add(this.listView1);
            this.slcTheme1.Controls.Add(this.slcClose1);
            this.slcTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slcTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.slcTheme1.Location = new System.Drawing.Point(0, 0);
            this.slcTheme1.Name = "slcTheme1";
            this.slcTheme1.Padding = new System.Windows.Forms.Padding(10, 70, 10, 9);
            this.slcTheme1.RoundCorners = true;
            this.slcTheme1.Sizable = true;
            this.slcTheme1.Size = new System.Drawing.Size(406, 434);
            this.slcTheme1.SmartBounds = true;
            this.slcTheme1.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.slcTheme1.TabIndex = 0;
            this.slcTheme1.Text = "AV Scanner";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(57)))), ((int)(((byte)(72)))));
            this.label2.Location = new System.Drawing.Point(12, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Link:";
            // 
            // slcTextBox2
            // 
            this.slcTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.slcTextBox2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.slcTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(183)))), ((int)(((byte)(191)))));
            this.slcTextBox2.Image = null;
            this.slcTextBox2.Location = new System.Drawing.Point(56, 369);
            this.slcTextBox2.MaxLength = 3276799;
            this.slcTextBox2.Multiline = false;
            this.slcTextBox2.Name = "slcTextBox2";
            this.slcTextBox2.ReadOnly = true;
            this.slcTextBox2.Size = new System.Drawing.Size(255, 41);
            this.slcTextBox2.TabIndex = 9;
            this.slcTextBox2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.slcTextBox2.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(57)))), ((int)(((byte)(72)))));
            this.label1.Location = new System.Drawing.Point(12, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Rate:";
            // 
            // slcTextBox1
            // 
            this.slcTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.slcTextBox1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.slcTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(183)))), ((int)(((byte)(191)))));
            this.slcTextBox1.Image = null;
            this.slcTextBox1.Location = new System.Drawing.Point(56, 323);
            this.slcTextBox1.MaxLength = 3276799;
            this.slcTextBox1.Multiline = false;
            this.slcTextBox1.Name = "slcTextBox1";
            this.slcTextBox1.ReadOnly = true;
            this.slcTextBox1.Size = new System.Drawing.Size(255, 41);
            this.slcTextBox1.TabIndex = 7;
            this.slcTextBox1.Text = "0/35";
            this.slcTextBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.slcTextBox1.UseSystemPasswordChar = false;
            // 
            // slCbtn1
            // 
            this.slCbtn1.BackColor = System.Drawing.Color.Transparent;
            this.slCbtn1.Font = new System.Drawing.Font("Verdana", 8F);
            this.slCbtn1.Image = null;
            this.slCbtn1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slCbtn1.Location = new System.Drawing.Point(317, 323);
            this.slCbtn1.Name = "slCbtn1";
            this.slCbtn1.Size = new System.Drawing.Size(75, 23);
            this.slCbtn1.TabIndex = 6;
            this.slCbtn1.Text = "Scan...";
            this.slCbtn1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.slCbtn1.Click += new System.EventHandler(this.slCbtn1_Click_1);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(14, 68);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(378, 249);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Antivirus";
            this.columnHeader1.Width = 172;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Result";
            this.columnHeader2.Width = 186;
            // 
            // slcClose1
            // 
            this.slcClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.slcClose1.EnableHoverHighlight = false;
            this.slcClose1.EnableMaximizeButton = false;
            this.slcClose1.EnableMinimizeButton = false;
            this.slcClose1.Font = new System.Drawing.Font("Verdana", 8F);
            this.slcClose1.Location = new System.Drawing.Point(294, 15);
            this.slcClose1.Name = "slcClose1";
            this.slcClose1.Size = new System.Drawing.Size(100, 25);
            this.slcClose1.TabIndex = 0;
            this.slcClose1.Text = "slcClose1";
            this.slcClose1.Click += new System.EventHandler(this.slcClose1_Click_1);
            // 
            // frmScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 434);
            this.Controls.Add(this.slcTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmScanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmScanner";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.slcTheme1.ResumeLayout(false);
            this.slcTheme1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MonoFlat.MonoFlat_ThemeContainer slcTheme1;
        private MonoFlat.MonoFlat_ControlBox slcClose1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private MonoFlat.MonoFlat_Button slCbtn1;
        private MonoFlat.MonoFlat_Label label2;
        private MonoFlat.MonoFlat_TextBox slcTextBox2;
        private MonoFlat.MonoFlat_Label label1;
        private MonoFlat.MonoFlat_TextBox slcTextBox1;
    }
}