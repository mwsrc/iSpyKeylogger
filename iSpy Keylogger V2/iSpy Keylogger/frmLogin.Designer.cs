namespace iSpy_Keylogger
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.themeMain = new iSpy_Keylogger.RedemptionForm();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.redemptionLabel5 = new iSpy_Keylogger.RedemptionLabel();
            this.redemptionLabel4 = new iSpy_Keylogger.RedemptionLabel();
            this.redemptionLabel3 = new iSpy_Keylogger.RedemptionLabel();
            this.tbHWID = new iSpy_Keylogger.RedemptionTextBox();
            this.tbPassword = new iSpy_Keylogger.RedemptionTextBox();
            this.tbUsername = new iSpy_Keylogger.RedemptionTextBox();
            this.btnLogin = new iSpy_Keylogger.RedemptionButton();
            this.cbAutoLogin = new iSpy_Keylogger.RedemptionRoundedToggle();
            this.lblAutoLogin = new iSpy_Keylogger.RedemptionLabel();
            this.cbRememberMe = new iSpy_Keylogger.RedemptionRoundedToggle();
            this.lblRememberMe = new iSpy_Keylogger.RedemptionLabel();
            this.btnControl = new iSpy_Keylogger.RedemptionControlBox();
            this.themeMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // themeMain
            // 
            this.themeMain.BackgroundNoise = true;
            this.themeMain.Controls.Add(this.pictureBox3);
            this.themeMain.Controls.Add(this.pictureBox2);
            this.themeMain.Controls.Add(this.pictureBox1);
            this.themeMain.Controls.Add(this.redemptionLabel5);
            this.themeMain.Controls.Add(this.redemptionLabel4);
            this.themeMain.Controls.Add(this.redemptionLabel3);
            this.themeMain.Controls.Add(this.tbHWID);
            this.themeMain.Controls.Add(this.tbPassword);
            this.themeMain.Controls.Add(this.tbUsername);
            this.themeMain.Controls.Add(this.btnLogin);
            this.themeMain.Controls.Add(this.cbAutoLogin);
            this.themeMain.Controls.Add(this.lblAutoLogin);
            this.themeMain.Controls.Add(this.cbRememberMe);
            this.themeMain.Controls.Add(this.lblRememberMe);
            this.themeMain.Controls.Add(this.btnControl);
            this.themeMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.themeMain.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themeMain.ForeColor = System.Drawing.Color.White;
            this.themeMain.Location = new System.Drawing.Point(0, 0);
            this.themeMain.Name = "themeMain";
            this.themeMain.Size = new System.Drawing.Size(486, 269);
            this.themeMain.TabIndex = 0;
            this.themeMain.Text = "iSpy Keylogger Login System";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(40, 138);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(17, 17);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(40, 104);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 17);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(40, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // redemptionLabel5
            // 
            this.redemptionLabel5.BackColor = System.Drawing.Color.Transparent;
            this.redemptionLabel5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redemptionLabel5.ForeColor = System.Drawing.Color.White;
            this.redemptionLabel5.Location = new System.Drawing.Point(63, 136);
            this.redemptionLabel5.Name = "redemptionLabel5";
            this.redemptionLabel5.Size = new System.Drawing.Size(72, 23);
            this.redemptionLabel5.TabIndex = 13;
            this.redemptionLabel5.Text = "HWID:";
            // 
            // redemptionLabel4
            // 
            this.redemptionLabel4.BackColor = System.Drawing.Color.Transparent;
            this.redemptionLabel4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redemptionLabel4.ForeColor = System.Drawing.Color.White;
            this.redemptionLabel4.Location = new System.Drawing.Point(61, 100);
            this.redemptionLabel4.Name = "redemptionLabel4";
            this.redemptionLabel4.Size = new System.Drawing.Size(76, 23);
            this.redemptionLabel4.TabIndex = 12;
            this.redemptionLabel4.Text = "Password:";
            // 
            // redemptionLabel3
            // 
            this.redemptionLabel3.BackColor = System.Drawing.Color.Transparent;
            this.redemptionLabel3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redemptionLabel3.ForeColor = System.Drawing.Color.White;
            this.redemptionLabel3.Location = new System.Drawing.Point(61, 64);
            this.redemptionLabel3.Name = "redemptionLabel3";
            this.redemptionLabel3.Size = new System.Drawing.Size(74, 23);
            this.redemptionLabel3.TabIndex = 11;
            this.redemptionLabel3.Text = "Username:";
            // 
            // tbHWID
            // 
            this.tbHWID.BackColor = System.Drawing.Color.Transparent;
            this.tbHWID.Enabled = false;
            this.tbHWID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHWID.ForeColor = System.Drawing.Color.White;
            this.tbHWID.Location = new System.Drawing.Point(143, 136);
            this.tbHWID.MaxLength = 32767;
            this.tbHWID.MultiLine = false;
            this.tbHWID.Name = "tbHWID";
            this.tbHWID.Size = new System.Drawing.Size(305, 24);
            this.tbHWID.TabIndex = 10;
            this.tbHWID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbHWID.UseSystemPasswordChar = false;
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.Transparent;
            this.tbPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.ForeColor = System.Drawing.Color.White;
            this.tbPassword.Location = new System.Drawing.Point(143, 100);
            this.tbPassword.MaxLength = 32767;
            this.tbPassword.MultiLine = false;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(305, 24);
            this.tbPassword.TabIndex = 9;
            this.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.Color.Transparent;
            this.tbUsername.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.ForeColor = System.Drawing.Color.White;
            this.tbUsername.Location = new System.Drawing.Point(143, 64);
            this.tbUsername.MaxLength = 32767;
            this.tbUsername.MultiLine = false;
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(305, 24);
            this.tbUsername.TabIndex = 8;
            this.tbUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbUsername.UseSystemPasswordChar = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(231, 195);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(217, 40);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextAlign = iSpy_Keylogger.RedemptionButton.HorizontalAlignment.Center;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cbAutoLogin
            // 
            this.cbAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.cbAutoLogin.Checked = false;
            this.cbAutoLogin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutoLogin.ForeColor = System.Drawing.Color.White;
            this.cbAutoLogin.Location = new System.Drawing.Point(143, 219);
            this.cbAutoLogin.Name = "cbAutoLogin";
            this.cbAutoLogin.Size = new System.Drawing.Size(34, 21);
            this.cbAutoLogin.TabIndex = 6;
            this.cbAutoLogin.Text = "redemptionRoundedToggle2";
            // 
            // lblAutoLogin
            // 
            this.lblAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoLogin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoLogin.ForeColor = System.Drawing.Color.White;
            this.lblAutoLogin.Location = new System.Drawing.Point(60, 217);
            this.lblAutoLogin.Name = "lblAutoLogin";
            this.lblAutoLogin.Size = new System.Drawing.Size(77, 23);
            this.lblAutoLogin.TabIndex = 5;
            this.lblAutoLogin.Text = "Auto Login";
            // 
            // cbRememberMe
            // 
            this.cbRememberMe.BackColor = System.Drawing.Color.Transparent;
            this.cbRememberMe.Checked = false;
            this.cbRememberMe.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRememberMe.ForeColor = System.Drawing.Color.White;
            this.cbRememberMe.Location = new System.Drawing.Point(143, 191);
            this.cbRememberMe.Name = "cbRememberMe";
            this.cbRememberMe.Size = new System.Drawing.Size(34, 21);
            this.cbRememberMe.TabIndex = 4;
            this.cbRememberMe.Text = "redemptionRoundedToggle1";
            // 
            // lblRememberMe
            // 
            this.lblRememberMe.BackColor = System.Drawing.Color.Transparent;
            this.lblRememberMe.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRememberMe.ForeColor = System.Drawing.Color.White;
            this.lblRememberMe.Location = new System.Drawing.Point(37, 191);
            this.lblRememberMe.Name = "lblRememberMe";
            this.lblRememberMe.Size = new System.Drawing.Size(100, 23);
            this.lblRememberMe.TabIndex = 2;
            this.lblRememberMe.Text = "Remember Me";
            // 
            // btnControl
            // 
            this.btnControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnControl.BackColor = System.Drawing.Color.Transparent;
            this.btnControl.ForeColor = System.Drawing.Color.White;
            this.btnControl.Location = new System.Drawing.Point(423, 1);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(60, 25);
            this.btnControl.TabIndex = 0;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(486, 269);
            this.Controls.Add(this.themeMain);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.themeMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RedemptionForm themeMain;
        private RedemptionControlBox btnControl;
        private RedemptionLabel lblRememberMe;
        private RedemptionRoundedToggle cbRememberMe;
        private RedemptionRoundedToggle cbAutoLogin;
        private RedemptionLabel lblAutoLogin;
        private RedemptionTextBox tbHWID;
        private RedemptionLabel redemptionLabel5;
        private RedemptionLabel redemptionLabel4;
        private RedemptionLabel redemptionLabel3;
        public RedemptionTextBox tbPassword;
        public RedemptionTextBox tbUsername;
        public RedemptionButton btnLogin;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;



    }
}