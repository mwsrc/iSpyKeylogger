namespace Galaxy_Logger.Forms
{
    partial class frmTOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTOS));
            this.slcTheme1 = new MonoFlat.MonoFlat_ThemeContainer();
            this.slCbtn2 = new Divine_Theme.Class1.DivineButton();
            this.slCbtn1 = new Divine_Theme.Class1.DivineButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.slcTheme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // slcTheme1
            // 
            this.slcTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(57)))), ((int)(((byte)(72)))));
            this.slcTheme1.Controls.Add(this.slCbtn2);
            this.slcTheme1.Controls.Add(this.slCbtn1);
            this.slcTheme1.Controls.Add(this.textBox1);
            this.slcTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slcTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.slcTheme1.Location = new System.Drawing.Point(0, 0);
            this.slcTheme1.Name = "slcTheme1";
            this.slcTheme1.Padding = new System.Windows.Forms.Padding(8, 57, 8, 7);
            this.slcTheme1.RoundCorners = true;
            this.slcTheme1.Sizable = true;
            this.slcTheme1.Size = new System.Drawing.Size(971, 668);
            this.slcTheme1.SmartBounds = true;
            this.slcTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.slcTheme1.TabIndex = 0;
            this.slcTheme1.Text = "Terms of Service";
            // 
            // slCbtn2
            // 
            this.slCbtn2.EnabledCalc = true;
            this.slCbtn2.Font = new System.Drawing.Font("Verdana", 8F);
            this.slCbtn2.Location = new System.Drawing.Point(505, 613);
            this.slCbtn2.Name = "slCbtn2";
            this.slCbtn2.Size = new System.Drawing.Size(441, 23);
            this.slCbtn2.TabIndex = 2;
            this.slCbtn2.Text = "I Decline";
            this.slCbtn2.Click += new Divine_Theme.Class1.DivineButton.ClickEventHandler(this.slCbtn2_Click_1);
            // 
            // slCbtn1
            // 
            this.slCbtn1.EnabledCalc = true;
            this.slCbtn1.Font = new System.Drawing.Font("Verdana", 8F);
            this.slCbtn1.Location = new System.Drawing.Point(24, 614);
            this.slCbtn1.Name = "slCbtn1";
            this.slCbtn1.Size = new System.Drawing.Size(475, 23);
            this.slCbtn1.TabIndex = 1;
            this.slCbtn1.Text = "I Accept";
            this.slCbtn1.Click += new Divine_Theme.Class1.DivineButton.ClickEventHandler(this.slCbtn1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 77);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(922, 530);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // frmTOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 668);
            this.Controls.Add(this.slcTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battle Keylogger Terms of Service";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.slcTheme1.ResumeLayout(false);
            this.slcTheme1.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private MonoFlat.MonoFlat_ThemeContainer slcTheme1;
        private System.Windows.Forms.TextBox textBox1;
        private Divine_Theme.Class1.DivineButton slCbtn2;
        private Divine_Theme.Class1.DivineButton slCbtn1;
    }
}