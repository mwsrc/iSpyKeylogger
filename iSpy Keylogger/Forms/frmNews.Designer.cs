namespace Galaxy_Logger.Forms
{
    partial class frmNews
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
            this.slcClose1 = new MonoFlat.MonoFlat_ControlBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.slcTheme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // slcTheme1
            // 
            this.slcTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(57)))), ((int)(((byte)(72)))));
            this.slcTheme1.Controls.Add(this.slcClose1);
            this.slcTheme1.Controls.Add(this.listView1);
            this.slcTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slcTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.slcTheme1.Location = new System.Drawing.Point(0, 0);
            this.slcTheme1.Name = "slcTheme1";
            this.slcTheme1.Padding = new System.Windows.Forms.Padding(10, 70, 10, 9);
            this.slcTheme1.RoundCorners = true;
            this.slcTheme1.Sizable = true;
            this.slcTheme1.Size = new System.Drawing.Size(407, 358);
            this.slcTheme1.SmartBounds = true;
            this.slcTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.slcTheme1.TabIndex = 0;
            this.slcTheme1.Text = "News";
            // 
            // slcClose1
            // 
            this.slcClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.slcClose1.EnableHoverHighlight = false;
            this.slcClose1.EnableMaximizeButton = false;
            this.slcClose1.EnableMinimizeButton = false;
            this.slcClose1.Font = new System.Drawing.Font("Verdana", 8F);
            this.slcClose1.Location = new System.Drawing.Point(295, 15);
            this.slcClose1.Name = "slcClose1";
            this.slcClose1.Size = new System.Drawing.Size(100, 25);
            this.slcClose1.TabIndex = 7;
            this.slcClose1.Text = "slcClose1";
            this.slcClose1.Click += new System.EventHandler(this.slcClose1_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Location = new System.Drawing.Point(12, 65);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(378, 249);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "News Post";
            this.columnHeader1.Width = 323;
            // 
            // frmNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 358);
            this.Controls.Add(this.slcTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNews";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNews";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.frmNews_Load);
            this.slcTheme1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MonoFlat.MonoFlat_ThemeContainer slcTheme1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private MonoFlat.MonoFlat_ControlBox slcClose1;
    }
}