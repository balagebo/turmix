namespace TurmixLog
{
    partial class MainForm : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fájlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.megnyitásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktuálisÁllapotMentéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mentésMáToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bezárásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.munkalapszámLátszikAListábanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.térképVisszaállításaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eszközökToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoÜzemmódToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koordinátákFelvételeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.földútpontokMódosításaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.munkalapAdatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.címekSzerkesztéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.járművekAdataiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beállításokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adatbázisTáblákToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.problémásCímekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.állandóProblémásUtcákToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.járművekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koordinátákToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ténylegesM3AdatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.súgóToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turmixLogisztikaSúgóToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aTurmixLogisztikaNévjegyeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bottomSplit = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.leftTab = new System.Windows.Forms.TabControl();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statview = new System.Windows.Forms.DataGridView();
            this.statrendszam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statm3Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statcim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statkm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csoves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statkoltseg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cumiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.munkaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rendezmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eredetiRendezésVisszaállításaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cimTab = new System.Windows.Forms.TabPage();
            this.cimGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.de_rad = new System.Windows.Forms.RadioButton();
            this.du_rad = new System.Windows.Forms.RadioButton();
            this.fp_rad = new System.Windows.Forms.RadioButton();
            this.workTree = new System.Windows.Forms.TreeView();
            this.browser = new System.Windows.Forms.WebBrowser();
            this.detailPanel = new System.Windows.Forms.Panel();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.sumM3 = new System.Windows.Forms.Label();
            this.sumOssz = new System.Windows.Forms.Label();
            this.sumEF = new System.Windows.Forms.Label();
            this.sumDU = new System.Windows.Forms.Label();
            this.sumDE = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.allM3Jo = new System.Windows.Forms.Label();
            this.allOsszJo = new System.Windows.Forms.Label();
            this.allEFJo = new System.Windows.Forms.Label();
            this.allDUJo = new System.Windows.Forms.Label();
            this.allToGoEFJo = new System.Windows.Forms.Label();
            this.allToGoDUJo = new System.Windows.Forms.Label();
            this.allDEJo = new System.Windows.Forms.Label();
            this.allToGoDEJo = new System.Windows.Forms.Label();
            this.allToGoOsszJo = new System.Windows.Forms.Label();
            this.allToGoM3Jo = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.bigM3Jo = new System.Windows.Forms.Label();
            this.bigOsszJo = new System.Windows.Forms.Label();
            this.bigEFJo = new System.Windows.Forms.Label();
            this.bigDUJo = new System.Windows.Forms.Label();
            this.bigDEJo = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.bigToGoDEJo = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.bigToGoEFJo = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.bigToGoOsszJo = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.bigToGoDUJo = new System.Windows.Forms.Label();
            this.bigToGoM3Jo = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.smallToGoEFJo = new System.Windows.Forms.Label();
            this.smallToGoDEJo = new System.Windows.Forms.Label();
            this.smallToGoDUJo = new System.Windows.Forms.Label();
            this.smallToGoOsszJo = new System.Windows.Forms.Label();
            this.smallToGoM3Jo = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.smallEFJo = new System.Windows.Forms.Label();
            this.smallDEJo = new System.Windows.Forms.Label();
            this.smallDUJo = new System.Windows.Forms.Label();
            this.smallOsszJo = new System.Windows.Forms.Label();
            this.smallM3Jo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.allDUDeb = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.allOsszDeb = new System.Windows.Forms.Label();
            this.allToGoEFDeb = new System.Windows.Forms.Label();
            this.allToGoOsszDeb = new System.Windows.Forms.Label();
            this.allToGoM3Deb = new System.Windows.Forms.Label();
            this.allToGoDUDeb = new System.Windows.Forms.Label();
            this.allDEDeb = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.allEFDeb = new System.Windows.Forms.Label();
            this.allM3Deb = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.allToGoDEDeb = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.bigToGoEFDeb = new System.Windows.Forms.Label();
            this.bigToGoM3Deb = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.bigM3Deb = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.bigToGoDEDeb = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.bigOsszDeb = new System.Windows.Forms.Label();
            this.bigDEDeb = new System.Windows.Forms.Label();
            this.bigToGoDUDeb = new System.Windows.Forms.Label();
            this.bigToGoOsszDeb = new System.Windows.Forms.Label();
            this.bigEFDeb = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.bigDUDeb = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.smallM3Deb = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.smallToGoOsszDeb = new System.Windows.Forms.Label();
            this.smallOsszDeb = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.smallToGoDUDeb = new System.Windows.Forms.Label();
            this.smallDUDeb = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.smallToGoEFDeb = new System.Windows.Forms.Label();
            this.smallToGoDEDeb = new System.Windows.Forms.Label();
            this.smallEFDeb = new System.Windows.Forms.Label();
            this.smallDEDeb = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.smallToGoM3Deb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Forduló = new System.Windows.Forms.GroupBox();
            this.driverTxt = new System.Windows.Forms.Label();
            this.helperTxt = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Sofőr = new System.Windows.Forms.Label();
            this.availableWorkTxt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.fixateBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.fajcso = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fajlagosIdo = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.fajlagosTav = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.infotext = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.allkoltseg = new System.Windows.Forms.Label();
            this.atlagMunkaVege = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cumiteny = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.fullTav = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clickedGroup = new System.Windows.Forms.ListBox();
            this.datePanel = new System.Windows.Forms.Panel();
            this.nomapButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dateRevBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.osszauto_rad = new System.Windows.Forms.ToolStripButton();
            this.kisauto_rad = new System.Windows.Forms.ToolStripButton();
            this.nagyauto_rad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.alertGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.soundButton = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.munkaPrintBtn = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.statPdf = new System.Windows.Forms.Button();
            this.statprn = new System.Windows.Forms.Button();
            this.statprev = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.sideBtn = new System.Windows.Forms.Button();
            this.prBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.fontBtn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.csvBtn = new System.Windows.Forms.Button();
            this.errorStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kiválasztToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lezárToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mutatATérképenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fuvarTörléseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mutatATérképenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gyujtoPDFBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.bottomSplit.Panel1.SuspendLayout();
            this.bottomSplit.Panel2.SuspendLayout();
            this.bottomSplit.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.leftTab.SuspendLayout();
            this.infoTab.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statview)).BeginInit();
            this.rendezmenu.SuspendLayout();
            this.cimTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cimGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.detailPanel.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Forduló.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.datePanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.errorStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fájlToolStripMenuItem,
            this.nToolStripMenuItem,
            this.eszközökToolStripMenuItem,
            this.adatbázisTáblákToolStripMenuItem,
            this.súgóToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1272, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fájlToolStripMenuItem
            // 
            this.fájlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.megnyitásToolStripMenuItem,
            this.aktuálisÁllapotMentéseToolStripMenuItem,
            this.mentésMáToolStripMenuItem,
            this.toolStripSeparator4,
            this.bezárásToolStripMenuItem});
            this.fájlToolStripMenuItem.Name = "fájlToolStripMenuItem";
            this.fájlToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fájlToolStripMenuItem.Text = "Fájl";
            // 
            // megnyitásToolStripMenuItem
            // 
            this.megnyitásToolStripMenuItem.Name = "megnyitásToolStripMenuItem";
            this.megnyitásToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.megnyitásToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.megnyitásToolStripMenuItem.Text = "Megnyitás";
            this.megnyitásToolStripMenuItem.Click += new System.EventHandler(this.megnyitásToolStripMenuItem_Click);
            // 
            // aktuálisÁllapotMentéseToolStripMenuItem
            // 
            this.aktuálisÁllapotMentéseToolStripMenuItem.Enabled = false;
            this.aktuálisÁllapotMentéseToolStripMenuItem.Name = "aktuálisÁllapotMentéseToolStripMenuItem";
            this.aktuálisÁllapotMentéseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.aktuálisÁllapotMentéseToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.aktuálisÁllapotMentéseToolStripMenuItem.Text = "Mentés";
            this.aktuálisÁllapotMentéseToolStripMenuItem.Click += new System.EventHandler(this.aktuálisÁllapotMentéseToolStripMenuItem_Click);
            // 
            // mentésMáToolStripMenuItem
            // 
            this.mentésMáToolStripMenuItem.Enabled = false;
            this.mentésMáToolStripMenuItem.Name = "mentésMáToolStripMenuItem";
            this.mentésMáToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.mentésMáToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.mentésMáToolStripMenuItem.Text = "Mentés másként";
            this.mentésMáToolStripMenuItem.Click += new System.EventHandler(this.mentésMáToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(230, 6);
            // 
            // bezárásToolStripMenuItem
            // 
            this.bezárásToolStripMenuItem.Name = "bezárásToolStripMenuItem";
            this.bezárásToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.bezárásToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.bezárásToolStripMenuItem.Text = "Bezárás";
            this.bezárásToolStripMenuItem.Click += new System.EventHandler(this.bezárásToolStripMenuItem_Click);
            // 
            // nToolStripMenuItem
            // 
            this.nToolStripMenuItem.CheckOnClick = true;
            this.nToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.munkalapszámLátszikAListábanToolStripMenuItem,
            this.térképVisszaállításaToolStripMenuItem});
            this.nToolStripMenuItem.Name = "nToolStripMenuItem";
            this.nToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.nToolStripMenuItem.Text = "Nézet";
            // 
            // munkalapszámLátszikAListábanToolStripMenuItem
            // 
            this.munkalapszámLátszikAListábanToolStripMenuItem.CheckOnClick = true;
            this.munkalapszámLátszikAListábanToolStripMenuItem.Enabled = false;
            this.munkalapszámLátszikAListábanToolStripMenuItem.Name = "munkalapszámLátszikAListábanToolStripMenuItem";
            this.munkalapszámLátszikAListábanToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.munkalapszámLátszikAListábanToolStripMenuItem.Text = "Munkalapszám látszik a listában";
            this.munkalapszámLátszikAListábanToolStripMenuItem.Click += new System.EventHandler(this.munkalapszámLátszikAListábanToolStripMenuItem_Click);
            // 
            // térképVisszaállításaToolStripMenuItem
            // 
            this.térképVisszaállításaToolStripMenuItem.Name = "térképVisszaállításaToolStripMenuItem";
            this.térképVisszaállításaToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.térképVisszaállításaToolStripMenuItem.Text = "Térkép visszaállítása";
            this.térképVisszaállításaToolStripMenuItem.Click += new System.EventHandler(this.térképVisszaállításaToolStripMenuItem_Click);
            // 
            // eszközökToolStripMenuItem
            // 
            this.eszközökToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoÜzemmódToolStripMenuItem,
            this.koordinátákFelvételeToolStripMenuItem,
            this.földútpontokMódosításaToolStripMenuItem,
            this.toolStripSeparator5,
            this.munkalapAdatokToolStripMenuItem,
            this.címekSzerkesztéseToolStripMenuItem,
            this.járművekAdataiToolStripMenuItem,
            this.beállításokToolStripMenuItem});
            this.eszközökToolStripMenuItem.Name = "eszközökToolStripMenuItem";
            this.eszközökToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.eszközökToolStripMenuItem.Text = "Eszközök";
            // 
            // infoÜzemmódToolStripMenuItem
            // 
            this.infoÜzemmódToolStripMenuItem.CheckOnClick = true;
            this.infoÜzemmódToolStripMenuItem.Enabled = false;
            this.infoÜzemmódToolStripMenuItem.Name = "infoÜzemmódToolStripMenuItem";
            this.infoÜzemmódToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.infoÜzemmódToolStripMenuItem.Text = "Info üzemmód";
            this.infoÜzemmódToolStripMenuItem.Click += new System.EventHandler(this.infoÜzemmódToolStripMenuItem_Click);
            // 
            // koordinátákFelvételeToolStripMenuItem
            // 
            this.koordinátákFelvételeToolStripMenuItem.Name = "koordinátákFelvételeToolStripMenuItem";
            this.koordinátákFelvételeToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.koordinátákFelvételeToolStripMenuItem.Text = "Koordináták módosítása";
            this.koordinátákFelvételeToolStripMenuItem.Click += new System.EventHandler(this.koordinátákFelvételeToolStripMenuItem_Click);
            // 
            // földútpontokMódosításaToolStripMenuItem
            // 
            this.földútpontokMódosításaToolStripMenuItem.CheckOnClick = true;
            this.földútpontokMódosításaToolStripMenuItem.Name = "földútpontokMódosításaToolStripMenuItem";
            this.földútpontokMódosításaToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.földútpontokMódosításaToolStripMenuItem.Text = "Földútpontok módosítása";
            this.földútpontokMódosításaToolStripMenuItem.Click += new System.EventHandler(this.földútpontokMódosításaToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(207, 6);
            // 
            // munkalapAdatokToolStripMenuItem
            // 
            this.munkalapAdatokToolStripMenuItem.Enabled = false;
            this.munkalapAdatokToolStripMenuItem.Name = "munkalapAdatokToolStripMenuItem";
            this.munkalapAdatokToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.munkalapAdatokToolStripMenuItem.Text = "Munkalap adatok";
            this.munkalapAdatokToolStripMenuItem.Visible = false;
            this.munkalapAdatokToolStripMenuItem.Click += new System.EventHandler(this.munkalapAdatokToolStripMenuItem_Click);
            // 
            // címekSzerkesztéseToolStripMenuItem
            // 
            this.címekSzerkesztéseToolStripMenuItem.Enabled = false;
            this.címekSzerkesztéseToolStripMenuItem.Name = "címekSzerkesztéseToolStripMenuItem";
            this.címekSzerkesztéseToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.címekSzerkesztéseToolStripMenuItem.Text = "Problémás címek";
            this.címekSzerkesztéseToolStripMenuItem.Click += new System.EventHandler(this.címekSzerkesztéseToolStripMenuItem_Click);
            // 
            // járművekAdataiToolStripMenuItem
            // 
            this.járművekAdataiToolStripMenuItem.Enabled = false;
            this.járművekAdataiToolStripMenuItem.Name = "járművekAdataiToolStripMenuItem";
            this.járművekAdataiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.járművekAdataiToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.járművekAdataiToolStripMenuItem.Text = "Járművek adatai";
            this.járművekAdataiToolStripMenuItem.Click += new System.EventHandler(this.járművekBeállításaToolStripMenuItem_Click);
            // 
            // beállításokToolStripMenuItem
            // 
            this.beállításokToolStripMenuItem.Name = "beállításokToolStripMenuItem";
            this.beállításokToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.beállításokToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.beállításokToolStripMenuItem.Text = "Beállítások";
            this.beállításokToolStripMenuItem.Click += new System.EventHandler(this.beállításokToolStripMenuItem1_Click);
            // 
            // adatbázisTáblákToolStripMenuItem
            // 
            this.adatbázisTáblákToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.problémásCímekToolStripMenuItem,
            this.állandóProblémásUtcákToolStripMenuItem,
            this.járművekToolStripMenuItem,
            this.koordinátákToolStripMenuItem,
            this.ténylegesM3AdatokToolStripMenuItem});
            this.adatbázisTáblákToolStripMenuItem.Name = "adatbázisTáblákToolStripMenuItem";
            this.adatbázisTáblákToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.adatbázisTáblákToolStripMenuItem.Text = "Adatbázis táblák";
            // 
            // problémásCímekToolStripMenuItem
            // 
            this.problémásCímekToolStripMenuItem.Name = "problémásCímekToolStripMenuItem";
            this.problémásCímekToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.problémásCímekToolStripMenuItem.Text = "Állandó problémás címek";
            this.problémásCímekToolStripMenuItem.Click += new System.EventHandler(this.problémásCímekToolStripMenuItem_Click);
            // 
            // állandóProblémásUtcákToolStripMenuItem
            // 
            this.állandóProblémásUtcákToolStripMenuItem.Name = "állandóProblémásUtcákToolStripMenuItem";
            this.állandóProblémásUtcákToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.állandóProblémásUtcákToolStripMenuItem.Text = "Állandó problémás utcák";
            this.állandóProblémásUtcákToolStripMenuItem.Click += new System.EventHandler(this.állandóProblémásUtcákToolStripMenuItem_Click);
            // 
            // járművekToolStripMenuItem
            // 
            this.járművekToolStripMenuItem.Name = "járművekToolStripMenuItem";
            this.járművekToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.járművekToolStripMenuItem.Text = "Járművek";
            this.járművekToolStripMenuItem.Click += new System.EventHandler(this.járművekToolStripMenuItem_Click);
            // 
            // koordinátákToolStripMenuItem
            // 
            this.koordinátákToolStripMenuItem.Name = "koordinátákToolStripMenuItem";
            this.koordinátákToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.koordinátákToolStripMenuItem.Text = "Koordináták";
            this.koordinátákToolStripMenuItem.Click += new System.EventHandler(this.koordinátákToolStripMenuItem_Click);
            // 
            // ténylegesM3AdatokToolStripMenuItem
            // 
            this.ténylegesM3AdatokToolStripMenuItem.Name = "ténylegesM3AdatokToolStripMenuItem";
            this.ténylegesM3AdatokToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.ténylegesM3AdatokToolStripMenuItem.Text = "Tényleges m3 adatok";
            this.ténylegesM3AdatokToolStripMenuItem.Click += new System.EventHandler(this.ténylegesM3AdatokToolStripMenuItem_Click);
            // 
            // súgóToolStripMenuItem
            // 
            this.súgóToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.turmixLogisztikaSúgóToolStripMenuItem,
            this.aTurmixLogisztikaNévjegyeToolStripMenuItem});
            this.súgóToolStripMenuItem.Name = "súgóToolStripMenuItem";
            this.súgóToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.súgóToolStripMenuItem.Text = "Súgó";
            // 
            // turmixLogisztikaSúgóToolStripMenuItem
            // 
            this.turmixLogisztikaSúgóToolStripMenuItem.Name = "turmixLogisztikaSúgóToolStripMenuItem";
            this.turmixLogisztikaSúgóToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.turmixLogisztikaSúgóToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.turmixLogisztikaSúgóToolStripMenuItem.Text = "Turmix Logisztika Súgó";
            this.turmixLogisztikaSúgóToolStripMenuItem.Click += new System.EventHandler(this.turmixLogisztikaSúgóToolStripMenuItem_Click);
            // 
            // aTurmixLogisztikaNévjegyeToolStripMenuItem
            // 
            this.aTurmixLogisztikaNévjegyeToolStripMenuItem.Name = "aTurmixLogisztikaNévjegyeToolStripMenuItem";
            this.aTurmixLogisztikaNévjegyeToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.aTurmixLogisztikaNévjegyeToolStripMenuItem.Text = "A Turmix Logisztika névjegye";
            this.aTurmixLogisztikaNévjegyeToolStripMenuItem.Click += new System.EventHandler(this.aTurmixLogisztikaNévjegyeToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1272, 720);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Controls.Add(this.datePanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1264, 694);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kiosztás";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 43);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bottomSplit);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(1258, 648);
            this.splitContainer1.SplitterDistance = 555;
            this.splitContainer1.TabIndex = 7;
            // 
            // bottomSplit
            // 
            this.bottomSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.bottomSplit.Location = new System.Drawing.Point(0, 0);
            this.bottomSplit.Name = "bottomSplit";
            // 
            // bottomSplit.Panel1
            // 
            this.bottomSplit.Panel1.Controls.Add(this.splitContainer2);
            this.bottomSplit.Panel1MinSize = 0;
            // 
            // bottomSplit.Panel2
            // 
            this.bottomSplit.Panel2.Controls.Add(this.browser);
            this.bottomSplit.Panel2.Controls.Add(this.detailPanel);
            this.bottomSplit.Panel2MinSize = 0;
            this.bottomSplit.Size = new System.Drawing.Size(1258, 555);
            this.bottomSplit.SplitterDistance = 323;
            this.bottomSplit.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer2.Panel1.Controls.Add(this.leftTab);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.workTree);
            this.splitContainer2.Size = new System.Drawing.Size(323, 555);
            this.splitContainer2.SplitterDistance = 336;
            this.splitContainer2.TabIndex = 8;
            // 
            // leftTab
            // 
            this.leftTab.Controls.Add(this.infoTab);
            this.leftTab.Controls.Add(this.cimTab);
            this.leftTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTab.Location = new System.Drawing.Point(0, 47);
            this.leftTab.Name = "leftTab";
            this.leftTab.SelectedIndex = 0;
            this.leftTab.Size = new System.Drawing.Size(323, 289);
            this.leftTab.TabIndex = 0;
            this.leftTab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.leftTab_Selecting);
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.panel2);
            this.infoTab.Location = new System.Drawing.Point(4, 22);
            this.infoTab.Name = "infoTab";
            this.infoTab.Padding = new System.Windows.Forms.Padding(3);
            this.infoTab.Size = new System.Drawing.Size(315, 263);
            this.infoTab.TabIndex = 0;
            this.infoTab.Text = "Statisztika";
            this.infoTab.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.statview);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 257);
            this.panel2.TabIndex = 6;
            // 
            // statview
            // 
            this.statview.AllowUserToAddRows = false;
            this.statview.AllowUserToDeleteRows = false;
            this.statview.AllowUserToResizeRows = false;
            this.statview.BackgroundColor = System.Drawing.SystemColors.Window;
            this.statview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.statview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statrendszam,
            this.statm3Column,
            this.statcim,
            this.statkm,
            this.csoves,
            this.statkoltseg,
            this.cumiColumn,
            this.munkaColumn});
            this.statview.ContextMenuStrip = this.rendezmenu;
            this.statview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statview.Location = new System.Drawing.Point(0, 0);
            this.statview.MultiSelect = false;
            this.statview.Name = "statview";
            this.statview.ReadOnly = true;
            this.statview.RowHeadersVisible = false;
            this.statview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.statview.Size = new System.Drawing.Size(309, 257);
            this.statview.TabIndex = 0;
            this.statview.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.statview_SortCompare);
            this.statview.SelectionChanged += new System.EventHandler(this.statview_SelectionChanged);
            // 
            // statrendszam
            // 
            this.statrendszam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statrendszam.HeaderText = "Rendszám";
            this.statrendszam.Name = "statrendszam";
            this.statrendszam.ReadOnly = true;
            this.statrendszam.Width = 82;
            // 
            // statm3Column
            // 
            this.statm3Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.statm3Column.HeaderText = "M3";
            this.statm3Column.Name = "statm3Column";
            this.statm3Column.ReadOnly = true;
            this.statm3Column.Width = 5;
            // 
            // statcim
            // 
            this.statcim.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.statcim.HeaderText = "Cím";
            this.statcim.Name = "statcim";
            this.statcim.ReadOnly = true;
            this.statcim.Width = 5;
            // 
            // statkm
            // 
            this.statkm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.statkm.HeaderText = "Km";
            this.statkm.Name = "statkm";
            this.statkm.ReadOnly = true;
            this.statkm.Width = 5;
            // 
            // csoves
            // 
            this.csoves.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.csoves.HeaderText = "CsH";
            this.csoves.Name = "csoves";
            this.csoves.ReadOnly = true;
            this.csoves.Width = 5;
            // 
            // statkoltseg
            // 
            this.statkoltseg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statkoltseg.HeaderText = "Ktg";
            this.statkoltseg.Name = "statkoltseg";
            this.statkoltseg.ReadOnly = true;
            this.statkoltseg.Width = 48;
            // 
            // cumiColumn
            // 
            this.cumiColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.cumiColumn.HeaderText = "CT";
            this.cumiColumn.Name = "cumiColumn";
            this.cumiColumn.ReadOnly = true;
            this.cumiColumn.Width = 5;
            // 
            // munkaColumn
            // 
            this.munkaColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.munkaColumn.HeaderText = "Idő";
            this.munkaColumn.Name = "munkaColumn";
            this.munkaColumn.ReadOnly = true;
            this.munkaColumn.Width = 47;
            // 
            // rendezmenu
            // 
            this.rendezmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eredetiRendezésVisszaállításaToolStripMenuItem});
            this.rendezmenu.Name = "rendezmenu";
            this.rendezmenu.Size = new System.Drawing.Size(229, 26);
            // 
            // eredetiRendezésVisszaállításaToolStripMenuItem
            // 
            this.eredetiRendezésVisszaállításaToolStripMenuItem.Name = "eredetiRendezésVisszaállításaToolStripMenuItem";
            this.eredetiRendezésVisszaállításaToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.eredetiRendezésVisszaállításaToolStripMenuItem.Text = "Eredeti rendezés visszaállítása";
            this.eredetiRendezésVisszaállításaToolStripMenuItem.Click += new System.EventHandler(this.eredetiRendezésVisszaállításaToolStripMenuItem_Click);
            // 
            // cimTab
            // 
            this.cimTab.Controls.Add(this.cimGrid);
            this.cimTab.Location = new System.Drawing.Point(4, 22);
            this.cimTab.Name = "cimTab";
            this.cimTab.Padding = new System.Windows.Forms.Padding(3);
            this.cimTab.Size = new System.Drawing.Size(315, 263);
            this.cimTab.TabIndex = 1;
            this.cimTab.Text = "Címlista";
            this.cimTab.UseVisualStyleBackColor = true;
            // 
            // cimGrid
            // 
            this.cimGrid.AllowUserToAddRows = false;
            this.cimGrid.AllowUserToDeleteRows = false;
            this.cimGrid.AllowUserToResizeRows = false;
            this.cimGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.cimGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cimGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.cimGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cimGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.cimGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cimGrid.Location = new System.Drawing.Point(3, 3);
            this.cimGrid.MultiSelect = false;
            this.cimGrid.Name = "cimGrid";
            this.cimGrid.ReadOnly = true;
            this.cimGrid.RowHeadersVisible = false;
            this.cimGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cimGrid.Size = new System.Drawing.Size(309, 257);
            this.cimGrid.TabIndex = 0;
            this.cimGrid.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.cimGrid_SortCompare);
            this.cimGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cimGrid_MouseClick);
            this.cimGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.cimGrid_CellFormatting);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Cím";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "m3";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 46;
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Controls.Add(this.de_rad);
            this.groupBox2.Controls.Add(this.du_rad);
            this.groupBox2.Controls.Add(this.fp_rad);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 47);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Napszak";
            // 
            // de_rad
            // 
            this.de_rad.AutoSize = true;
            this.de_rad.Location = new System.Drawing.Point(109, 19);
            this.de_rad.Name = "de_rad";
            this.de_rad.Size = new System.Drawing.Size(61, 17);
            this.de_rad.TabIndex = 1;
            this.de_rad.Text = "Délelőtt";
            this.de_rad.UseVisualStyleBackColor = true;
            this.de_rad.Click += new System.EventHandler(this.de_rad_Click);
            // 
            // du_rad
            // 
            this.du_rad.AutoSize = true;
            this.du_rad.Location = new System.Drawing.Point(180, 19);
            this.du_rad.Name = "du_rad";
            this.du_rad.Size = new System.Drawing.Size(62, 17);
            this.du_rad.TabIndex = 2;
            this.du_rad.Text = "Délután";
            this.du_rad.UseVisualStyleBackColor = true;
            this.du_rad.Click += new System.EventHandler(this.du_rad_Click);
            // 
            // fp_rad
            // 
            this.fp_rad.AutoSize = true;
            this.fp_rad.Checked = true;
            this.fp_rad.Location = new System.Drawing.Point(25, 19);
            this.fp_rad.Name = "fp_rad";
            this.fp_rad.Size = new System.Drawing.Size(72, 17);
            this.fp_rad.TabIndex = 0;
            this.fp_rad.TabStop = true;
            this.fp_rad.Text = "Első fuvar";
            this.fp_rad.UseVisualStyleBackColor = true;
            this.fp_rad.Click += new System.EventHandler(this.elso_rad_Click);
            // 
            // workTree
            // 
            this.workTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workTree.FullRowSelect = true;
            this.workTree.Location = new System.Drawing.Point(0, 0);
            this.workTree.Name = "workTree";
            this.workTree.ShowLines = false;
            this.workTree.Size = new System.Drawing.Size(323, 215);
            this.workTree.TabIndex = 0;
            this.workTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.workTree_NodeMouseClick_1);
            // 
            // browser
            // 
            this.browser.AllowWebBrowserDrop = false;
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.IsWebBrowserContextMenuEnabled = false;
            this.browser.Location = new System.Drawing.Point(0, 128);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.ScriptErrorsSuppressed = true;
            this.browser.Size = new System.Drawing.Size(931, 427);
            this.browser.TabIndex = 0;
            this.browser.WebBrowserShortcutsEnabled = false;
            this.browser.NewWindow += new System.ComponentModel.CancelEventHandler(this.browser_NewWindow);
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
            // 
            // detailPanel
            // 
            this.detailPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("detailPanel.BackgroundImage")));
            this.detailPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.detailPanel.Controls.Add(this.groupBox13);
            this.detailPanel.Controls.Add(this.panel3);
            this.detailPanel.Controls.Add(this.panel1);
            this.detailPanel.Controls.Add(this.Forduló);
            this.detailPanel.Controls.Add(this.panel5);
            this.detailPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.detailPanel.Location = new System.Drawing.Point(0, 0);
            this.detailPanel.Name = "detailPanel";
            this.detailPanel.Size = new System.Drawing.Size(931, 128);
            this.detailPanel.TabIndex = 7;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.sumM3);
            this.groupBox13.Controls.Add(this.sumOssz);
            this.groupBox13.Controls.Add(this.sumEF);
            this.groupBox13.Controls.Add(this.sumDU);
            this.groupBox13.Controls.Add(this.sumDE);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox13.Location = new System.Drawing.Point(766, 0);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(84, 128);
            this.groupBox13.TabIndex = 32;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Összes cím";
            // 
            // sumM3
            // 
            this.sumM3.AutoSize = true;
            this.sumM3.Location = new System.Drawing.Point(30, 108);
            this.sumM3.Name = "sumM3";
            this.sumM3.Size = new System.Drawing.Size(13, 13);
            this.sumM3.TabIndex = 180;
            this.sumM3.Text = "0";
            // 
            // sumOssz
            // 
            this.sumOssz.AutoSize = true;
            this.sumOssz.Location = new System.Drawing.Point(30, 89);
            this.sumOssz.Name = "sumOssz";
            this.sumOssz.Size = new System.Drawing.Size(13, 13);
            this.sumOssz.TabIndex = 179;
            this.sumOssz.Text = "0";
            // 
            // sumEF
            // 
            this.sumEF.AutoSize = true;
            this.sumEF.Location = new System.Drawing.Point(30, 31);
            this.sumEF.Name = "sumEF";
            this.sumEF.Size = new System.Drawing.Size(13, 13);
            this.sumEF.TabIndex = 176;
            this.sumEF.Text = "0";
            // 
            // sumDU
            // 
            this.sumDU.AutoSize = true;
            this.sumDU.Location = new System.Drawing.Point(30, 67);
            this.sumDU.Name = "sumDU";
            this.sumDU.Size = new System.Drawing.Size(13, 13);
            this.sumDU.TabIndex = 178;
            this.sumDU.Text = "0";
            // 
            // sumDE
            // 
            this.sumDE.AutoSize = true;
            this.sumDE.Location = new System.Drawing.Point(30, 49);
            this.sumDE.Name = "sumDE";
            this.sumDE.Size = new System.Drawing.Size(13, 13);
            this.sumDE.TabIndex = 177;
            this.sumDE.Text = "0";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox10);
            this.panel3.Controls.Add(this.groupBox11);
            this.panel3.Controls.Add(this.groupBox12);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.ForeColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(459, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(307, 128);
            this.panel3.TabIndex = 31;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.allM3Jo);
            this.groupBox10.Controls.Add(this.allOsszJo);
            this.groupBox10.Controls.Add(this.allEFJo);
            this.groupBox10.Controls.Add(this.allDUJo);
            this.groupBox10.Controls.Add(this.allToGoEFJo);
            this.groupBox10.Controls.Add(this.allToGoDUJo);
            this.groupBox10.Controls.Add(this.allDEJo);
            this.groupBox10.Controls.Add(this.allToGoDEJo);
            this.groupBox10.Controls.Add(this.allToGoOsszJo);
            this.groupBox10.Controls.Add(this.allToGoM3Jo);
            this.groupBox10.Controls.Add(this.label12);
            this.groupBox10.Controls.Add(this.label38);
            this.groupBox10.Controls.Add(this.label46);
            this.groupBox10.Controls.Add(this.label51);
            this.groupBox10.Controls.Add(this.label58);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(201, 0);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(106, 128);
            this.groupBox10.TabIndex = 30;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Össz. józsai";
            // 
            // allM3Jo
            // 
            this.allM3Jo.AutoSize = true;
            this.allM3Jo.Location = new System.Drawing.Point(59, 108);
            this.allM3Jo.Name = "allM3Jo";
            this.allM3Jo.Size = new System.Drawing.Size(13, 13);
            this.allM3Jo.TabIndex = 175;
            this.allM3Jo.Text = "0";
            // 
            // allOsszJo
            // 
            this.allOsszJo.AutoSize = true;
            this.allOsszJo.Location = new System.Drawing.Point(59, 89);
            this.allOsszJo.Name = "allOsszJo";
            this.allOsszJo.Size = new System.Drawing.Size(13, 13);
            this.allOsszJo.TabIndex = 173;
            this.allOsszJo.Text = "0";
            // 
            // allEFJo
            // 
            this.allEFJo.AutoSize = true;
            this.allEFJo.Location = new System.Drawing.Point(59, 31);
            this.allEFJo.Name = "allEFJo";
            this.allEFJo.Size = new System.Drawing.Size(13, 13);
            this.allEFJo.TabIndex = 167;
            this.allEFJo.Text = "0";
            // 
            // allDUJo
            // 
            this.allDUJo.AutoSize = true;
            this.allDUJo.Location = new System.Drawing.Point(59, 67);
            this.allDUJo.Name = "allDUJo";
            this.allDUJo.Size = new System.Drawing.Size(13, 13);
            this.allDUJo.TabIndex = 171;
            this.allDUJo.Text = "0";
            // 
            // allToGoEFJo
            // 
            this.allToGoEFJo.AutoSize = true;
            this.allToGoEFJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.allToGoEFJo.Location = new System.Drawing.Point(21, 31);
            this.allToGoEFJo.Name = "allToGoEFJo";
            this.allToGoEFJo.Size = new System.Drawing.Size(14, 13);
            this.allToGoEFJo.TabIndex = 157;
            this.allToGoEFJo.Text = "0";
            // 
            // allToGoDUJo
            // 
            this.allToGoDUJo.AutoSize = true;
            this.allToGoDUJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.allToGoDUJo.Location = new System.Drawing.Point(21, 67);
            this.allToGoDUJo.Name = "allToGoDUJo";
            this.allToGoDUJo.Size = new System.Drawing.Size(14, 13);
            this.allToGoDUJo.TabIndex = 161;
            this.allToGoDUJo.Text = "0";
            // 
            // allDEJo
            // 
            this.allDEJo.AutoSize = true;
            this.allDEJo.Location = new System.Drawing.Point(59, 49);
            this.allDEJo.Name = "allDEJo";
            this.allDEJo.Size = new System.Drawing.Size(13, 13);
            this.allDEJo.TabIndex = 169;
            this.allDEJo.Text = "0";
            // 
            // allToGoDEJo
            // 
            this.allToGoDEJo.AutoSize = true;
            this.allToGoDEJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.allToGoDEJo.Location = new System.Drawing.Point(21, 49);
            this.allToGoDEJo.Name = "allToGoDEJo";
            this.allToGoDEJo.Size = new System.Drawing.Size(14, 13);
            this.allToGoDEJo.TabIndex = 159;
            this.allToGoDEJo.Text = "0";
            // 
            // allToGoOsszJo
            // 
            this.allToGoOsszJo.AutoSize = true;
            this.allToGoOsszJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.allToGoOsszJo.Location = new System.Drawing.Point(21, 89);
            this.allToGoOsszJo.Name = "allToGoOsszJo";
            this.allToGoOsszJo.Size = new System.Drawing.Size(14, 13);
            this.allToGoOsszJo.TabIndex = 163;
            this.allToGoOsszJo.Text = "0";
            // 
            // allToGoM3Jo
            // 
            this.allToGoM3Jo.AutoSize = true;
            this.allToGoM3Jo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.allToGoM3Jo.Location = new System.Drawing.Point(21, 108);
            this.allToGoM3Jo.Name = "allToGoM3Jo";
            this.allToGoM3Jo.Size = new System.Drawing.Size(14, 13);
            this.allToGoM3Jo.TabIndex = 165;
            this.allToGoM3Jo.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 13);
            this.label12.TabIndex = 152;
            this.label12.Text = "/";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(45, 49);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(12, 13);
            this.label38.TabIndex = 146;
            this.label38.Text = "/";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(45, 67);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(12, 13);
            this.label46.TabIndex = 149;
            this.label46.Text = "/";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(45, 31);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(12, 13);
            this.label51.TabIndex = 145;
            this.label51.Text = "/";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(45, 108);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(12, 13);
            this.label58.TabIndex = 155;
            this.label58.Text = "/";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.bigM3Jo);
            this.groupBox11.Controls.Add(this.bigOsszJo);
            this.groupBox11.Controls.Add(this.bigEFJo);
            this.groupBox11.Controls.Add(this.bigDUJo);
            this.groupBox11.Controls.Add(this.bigDEJo);
            this.groupBox11.Controls.Add(this.label66);
            this.groupBox11.Controls.Add(this.bigToGoDEJo);
            this.groupBox11.Controls.Add(this.label72);
            this.groupBox11.Controls.Add(this.bigToGoEFJo);
            this.groupBox11.Controls.Add(this.label74);
            this.groupBox11.Controls.Add(this.bigToGoOsszJo);
            this.groupBox11.Controls.Add(this.label81);
            this.groupBox11.Controls.Add(this.label88);
            this.groupBox11.Controls.Add(this.bigToGoDUJo);
            this.groupBox11.Controls.Add(this.bigToGoM3Jo);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox11.Location = new System.Drawing.Point(110, 0);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(91, 128);
            this.groupBox11.TabIndex = 31;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Nagy józsai";
            // 
            // bigM3Jo
            // 
            this.bigM3Jo.AutoSize = true;
            this.bigM3Jo.Location = new System.Drawing.Point(62, 108);
            this.bigM3Jo.Name = "bigM3Jo";
            this.bigM3Jo.Size = new System.Drawing.Size(13, 13);
            this.bigM3Jo.TabIndex = 145;
            this.bigM3Jo.Text = "0";
            // 
            // bigOsszJo
            // 
            this.bigOsszJo.AutoSize = true;
            this.bigOsszJo.Location = new System.Drawing.Point(62, 89);
            this.bigOsszJo.Name = "bigOsszJo";
            this.bigOsszJo.Size = new System.Drawing.Size(13, 13);
            this.bigOsszJo.TabIndex = 144;
            this.bigOsszJo.Text = "0";
            // 
            // bigEFJo
            // 
            this.bigEFJo.AutoSize = true;
            this.bigEFJo.Location = new System.Drawing.Point(62, 31);
            this.bigEFJo.Name = "bigEFJo";
            this.bigEFJo.Size = new System.Drawing.Size(13, 13);
            this.bigEFJo.TabIndex = 141;
            this.bigEFJo.Text = "0";
            // 
            // bigDUJo
            // 
            this.bigDUJo.AutoSize = true;
            this.bigDUJo.Location = new System.Drawing.Point(62, 67);
            this.bigDUJo.Name = "bigDUJo";
            this.bigDUJo.Size = new System.Drawing.Size(13, 13);
            this.bigDUJo.TabIndex = 143;
            this.bigDUJo.Text = "0";
            // 
            // bigDEJo
            // 
            this.bigDEJo.AutoSize = true;
            this.bigDEJo.Location = new System.Drawing.Point(62, 49);
            this.bigDEJo.Name = "bigDEJo";
            this.bigDEJo.Size = new System.Drawing.Size(13, 13);
            this.bigDEJo.TabIndex = 142;
            this.bigDEJo.Text = "0";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(44, 49);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(12, 13);
            this.label66.TabIndex = 111;
            this.label66.Text = "/";
            // 
            // bigToGoDEJo
            // 
            this.bigToGoDEJo.AutoSize = true;
            this.bigToGoDEJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bigToGoDEJo.Location = new System.Drawing.Point(19, 49);
            this.bigToGoDEJo.Name = "bigToGoDEJo";
            this.bigToGoDEJo.Size = new System.Drawing.Size(14, 13);
            this.bigToGoDEJo.TabIndex = 109;
            this.bigToGoDEJo.Text = "0";
            this.bigToGoDEJo.TextChanged += new System.EventHandler(this.bigToGoEFJo_TextChanged);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(44, 31);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(12, 13);
            this.label72.TabIndex = 110;
            this.label72.Text = "/";
            // 
            // bigToGoEFJo
            // 
            this.bigToGoEFJo.AutoSize = true;
            this.bigToGoEFJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bigToGoEFJo.Location = new System.Drawing.Point(19, 31);
            this.bigToGoEFJo.Name = "bigToGoEFJo";
            this.bigToGoEFJo.Size = new System.Drawing.Size(14, 13);
            this.bigToGoEFJo.TabIndex = 108;
            this.bigToGoEFJo.Text = "0";
            this.bigToGoEFJo.TextChanged += new System.EventHandler(this.bigToGoEFJo_TextChanged);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(44, 108);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(12, 13);
            this.label74.TabIndex = 120;
            this.label74.Text = "/";
            // 
            // bigToGoOsszJo
            // 
            this.bigToGoOsszJo.AutoSize = true;
            this.bigToGoOsszJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bigToGoOsszJo.Location = new System.Drawing.Point(19, 89);
            this.bigToGoOsszJo.Name = "bigToGoOsszJo";
            this.bigToGoOsszJo.Size = new System.Drawing.Size(14, 13);
            this.bigToGoOsszJo.TabIndex = 116;
            this.bigToGoOsszJo.Text = "0";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(44, 67);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(12, 13);
            this.label81.TabIndex = 114;
            this.label81.Text = "/";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(44, 89);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(12, 13);
            this.label88.TabIndex = 117;
            this.label88.Text = "/";
            // 
            // bigToGoDUJo
            // 
            this.bigToGoDUJo.AutoSize = true;
            this.bigToGoDUJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bigToGoDUJo.Location = new System.Drawing.Point(19, 67);
            this.bigToGoDUJo.Name = "bigToGoDUJo";
            this.bigToGoDUJo.Size = new System.Drawing.Size(14, 13);
            this.bigToGoDUJo.TabIndex = 113;
            this.bigToGoDUJo.Text = "0";
            this.bigToGoDUJo.TextChanged += new System.EventHandler(this.bigToGoEFJo_TextChanged);
            // 
            // bigToGoM3Jo
            // 
            this.bigToGoM3Jo.AutoSize = true;
            this.bigToGoM3Jo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bigToGoM3Jo.Location = new System.Drawing.Point(19, 108);
            this.bigToGoM3Jo.Name = "bigToGoM3Jo";
            this.bigToGoM3Jo.Size = new System.Drawing.Size(14, 13);
            this.bigToGoM3Jo.TabIndex = 119;
            this.bigToGoM3Jo.Text = "0";
            this.bigToGoM3Jo.TextChanged += new System.EventHandler(this.smallToGoM3Jo_TextChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.smallToGoEFJo);
            this.groupBox12.Controls.Add(this.smallToGoDEJo);
            this.groupBox12.Controls.Add(this.smallToGoDUJo);
            this.groupBox12.Controls.Add(this.smallToGoOsszJo);
            this.groupBox12.Controls.Add(this.smallToGoM3Jo);
            this.groupBox12.Controls.Add(this.label90);
            this.groupBox12.Controls.Add(this.label92);
            this.groupBox12.Controls.Add(this.label94);
            this.groupBox12.Controls.Add(this.label96);
            this.groupBox12.Controls.Add(this.label98);
            this.groupBox12.Controls.Add(this.label100);
            this.groupBox12.Controls.Add(this.label103);
            this.groupBox12.Controls.Add(this.label105);
            this.groupBox12.Controls.Add(this.label107);
            this.groupBox12.Controls.Add(this.label108);
            this.groupBox12.Controls.Add(this.smallEFJo);
            this.groupBox12.Controls.Add(this.smallDEJo);
            this.groupBox12.Controls.Add(this.smallDUJo);
            this.groupBox12.Controls.Add(this.smallOsszJo);
            this.groupBox12.Controls.Add(this.smallM3Jo);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox12.Location = new System.Drawing.Point(0, 0);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(110, 128);
            this.groupBox12.TabIndex = 29;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Kis józsai";
            // 
            // smallToGoEFJo
            // 
            this.smallToGoEFJo.AutoSize = true;
            this.smallToGoEFJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.smallToGoEFJo.Location = new System.Drawing.Point(32, 31);
            this.smallToGoEFJo.Name = "smallToGoEFJo";
            this.smallToGoEFJo.Size = new System.Drawing.Size(14, 13);
            this.smallToGoEFJo.TabIndex = 106;
            this.smallToGoEFJo.Text = "0";
            this.smallToGoEFJo.TextChanged += new System.EventHandler(this.smallToGoEFJo_TextChanged);
            // 
            // smallToGoDEJo
            // 
            this.smallToGoDEJo.AutoSize = true;
            this.smallToGoDEJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.smallToGoDEJo.Location = new System.Drawing.Point(32, 49);
            this.smallToGoDEJo.Name = "smallToGoDEJo";
            this.smallToGoDEJo.Size = new System.Drawing.Size(14, 13);
            this.smallToGoDEJo.TabIndex = 107;
            this.smallToGoDEJo.Text = "0";
            this.smallToGoDEJo.TextChanged += new System.EventHandler(this.smallToGoEFJo_TextChanged);
            // 
            // smallToGoDUJo
            // 
            this.smallToGoDUJo.AutoSize = true;
            this.smallToGoDUJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.smallToGoDUJo.Location = new System.Drawing.Point(32, 67);
            this.smallToGoDUJo.Name = "smallToGoDUJo";
            this.smallToGoDUJo.Size = new System.Drawing.Size(14, 13);
            this.smallToGoDUJo.TabIndex = 108;
            this.smallToGoDUJo.Text = "0";
            this.smallToGoDUJo.TextChanged += new System.EventHandler(this.smallToGoEFJo_TextChanged);
            // 
            // smallToGoOsszJo
            // 
            this.smallToGoOsszJo.AutoSize = true;
            this.smallToGoOsszJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.smallToGoOsszJo.Location = new System.Drawing.Point(32, 89);
            this.smallToGoOsszJo.Name = "smallToGoOsszJo";
            this.smallToGoOsszJo.Size = new System.Drawing.Size(14, 13);
            this.smallToGoOsszJo.TabIndex = 109;
            this.smallToGoOsszJo.Text = "0";
            // 
            // smallToGoM3Jo
            // 
            this.smallToGoM3Jo.AutoSize = true;
            this.smallToGoM3Jo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.smallToGoM3Jo.Location = new System.Drawing.Point(32, 108);
            this.smallToGoM3Jo.Name = "smallToGoM3Jo";
            this.smallToGoM3Jo.Size = new System.Drawing.Size(14, 13);
            this.smallToGoM3Jo.TabIndex = 110;
            this.smallToGoM3Jo.Text = "0";
            this.smallToGoM3Jo.TextChanged += new System.EventHandler(this.smallToGoM3Jo_TextChanged);
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(59, 108);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(12, 13);
            this.label90.TabIndex = 31;
            this.label90.Text = "/";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(6, 109);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(21, 13);
            this.label92.TabIndex = 28;
            this.label92.Text = "m3";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(59, 89);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(12, 13);
            this.label94.TabIndex = 27;
            this.label94.Text = "/";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(5, 90);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(33, 13);
            this.label96.TabIndex = 24;
            this.label96.Text = "Össz.";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(59, 67);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(12, 13);
            this.label98.TabIndex = 17;
            this.label98.Text = "/";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(6, 68);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(21, 13);
            this.label100.TabIndex = 14;
            this.label100.Text = "Du";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(59, 31);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(12, 13);
            this.label103.TabIndex = 12;
            this.label103.Text = "/";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(59, 49);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(12, 13);
            this.label105.TabIndex = 13;
            this.label105.Text = "/";
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(6, 32);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(20, 13);
            this.label107.TabIndex = 6;
            this.label107.Text = "EF";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(6, 50);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(21, 13);
            this.label108.TabIndex = 7;
            this.label108.Text = "De";
            // 
            // smallEFJo
            // 
            this.smallEFJo.AutoSize = true;
            this.smallEFJo.Location = new System.Drawing.Point(73, 31);
            this.smallEFJo.Name = "smallEFJo";
            this.smallEFJo.Size = new System.Drawing.Size(13, 13);
            this.smallEFJo.TabIndex = 97;
            this.smallEFJo.Text = "0";
            // 
            // smallDEJo
            // 
            this.smallDEJo.AutoSize = true;
            this.smallDEJo.Location = new System.Drawing.Point(73, 49);
            this.smallDEJo.Name = "smallDEJo";
            this.smallDEJo.Size = new System.Drawing.Size(13, 13);
            this.smallDEJo.TabIndex = 99;
            this.smallDEJo.Text = "0";
            // 
            // smallDUJo
            // 
            this.smallDUJo.AutoSize = true;
            this.smallDUJo.Location = new System.Drawing.Point(73, 67);
            this.smallDUJo.Name = "smallDUJo";
            this.smallDUJo.Size = new System.Drawing.Size(13, 13);
            this.smallDUJo.TabIndex = 101;
            this.smallDUJo.Text = "0";
            // 
            // smallOsszJo
            // 
            this.smallOsszJo.AutoSize = true;
            this.smallOsszJo.Location = new System.Drawing.Point(73, 89);
            this.smallOsszJo.Name = "smallOsszJo";
            this.smallOsszJo.Size = new System.Drawing.Size(13, 13);
            this.smallOsszJo.TabIndex = 103;
            this.smallOsszJo.Text = "0";
            // 
            // smallM3Jo
            // 
            this.smallM3Jo.AutoSize = true;
            this.smallM3Jo.Location = new System.Drawing.Point(73, 108);
            this.smallM3Jo.Name = "smallM3Jo";
            this.smallM3Jo.Size = new System.Drawing.Size(13, 13);
            this.smallM3Jo.TabIndex = 105;
            this.smallM3Jo.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox9);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(161, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 128);
            this.panel1.TabIndex = 30;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.allDUDeb);
            this.groupBox4.Controls.Add(this.label83);
            this.groupBox4.Controls.Add(this.allOsszDeb);
            this.groupBox4.Controls.Add(this.allToGoEFDeb);
            this.groupBox4.Controls.Add(this.allToGoOsszDeb);
            this.groupBox4.Controls.Add(this.allToGoM3Deb);
            this.groupBox4.Controls.Add(this.allToGoDUDeb);
            this.groupBox4.Controls.Add(this.allDEDeb);
            this.groupBox4.Controls.Add(this.label42);
            this.groupBox4.Controls.Add(this.label69);
            this.groupBox4.Controls.Add(this.allEFDeb);
            this.groupBox4.Controls.Add(this.allM3Deb);
            this.groupBox4.Controls.Add(this.label55);
            this.groupBox4.Controls.Add(this.allToGoDEDeb);
            this.groupBox4.Controls.Add(this.label59);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(201, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(97, 128);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Össz. Deb";
            // 
            // allDUDeb
            // 
            this.allDUDeb.AutoSize = true;
            this.allDUDeb.Location = new System.Drawing.Point(60, 66);
            this.allDUDeb.Name = "allDUDeb";
            this.allDUDeb.Size = new System.Drawing.Size(13, 13);
            this.allDUDeb.TabIndex = 148;
            this.allDUDeb.Text = "0";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(47, 89);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(12, 13);
            this.label83.TabIndex = 152;
            this.label83.Text = "/";
            // 
            // allOsszDeb
            // 
            this.allOsszDeb.AutoSize = true;
            this.allOsszDeb.Location = new System.Drawing.Point(60, 88);
            this.allOsszDeb.Name = "allOsszDeb";
            this.allOsszDeb.Size = new System.Drawing.Size(13, 13);
            this.allOsszDeb.TabIndex = 151;
            this.allOsszDeb.Text = "0";
            // 
            // allToGoEFDeb
            // 
            this.allToGoEFDeb.AutoSize = true;
            this.allToGoEFDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allToGoEFDeb.Location = new System.Drawing.Point(20, 30);
            this.allToGoEFDeb.Name = "allToGoEFDeb";
            this.allToGoEFDeb.Size = new System.Drawing.Size(14, 13);
            this.allToGoEFDeb.TabIndex = 141;
            this.allToGoEFDeb.Text = "0";
            this.allToGoEFDeb.TextChanged += new System.EventHandler(this.allToGoEFDeb_TextChanged);
            // 
            // allToGoOsszDeb
            // 
            this.allToGoOsszDeb.AutoSize = true;
            this.allToGoOsszDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allToGoOsszDeb.ForeColor = System.Drawing.Color.Black;
            this.allToGoOsszDeb.Location = new System.Drawing.Point(20, 88);
            this.allToGoOsszDeb.Name = "allToGoOsszDeb";
            this.allToGoOsszDeb.Size = new System.Drawing.Size(14, 13);
            this.allToGoOsszDeb.TabIndex = 150;
            this.allToGoOsszDeb.Text = "0";
            // 
            // allToGoM3Deb
            // 
            this.allToGoM3Deb.AutoSize = true;
            this.allToGoM3Deb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allToGoM3Deb.ForeColor = System.Drawing.Color.Black;
            this.allToGoM3Deb.Location = new System.Drawing.Point(20, 107);
            this.allToGoM3Deb.Name = "allToGoM3Deb";
            this.allToGoM3Deb.Size = new System.Drawing.Size(14, 13);
            this.allToGoM3Deb.TabIndex = 153;
            this.allToGoM3Deb.Text = "0";
            // 
            // allToGoDUDeb
            // 
            this.allToGoDUDeb.AutoSize = true;
            this.allToGoDUDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allToGoDUDeb.ForeColor = System.Drawing.Color.Black;
            this.allToGoDUDeb.Location = new System.Drawing.Point(20, 66);
            this.allToGoDUDeb.Name = "allToGoDUDeb";
            this.allToGoDUDeb.Size = new System.Drawing.Size(14, 13);
            this.allToGoDUDeb.TabIndex = 147;
            this.allToGoDUDeb.Text = "0";
            // 
            // allDEDeb
            // 
            this.allDEDeb.AutoSize = true;
            this.allDEDeb.Location = new System.Drawing.Point(60, 48);
            this.allDEDeb.Name = "allDEDeb";
            this.allDEDeb.Size = new System.Drawing.Size(13, 13);
            this.allDEDeb.TabIndex = 144;
            this.allDEDeb.Text = "0";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(47, 49);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(12, 13);
            this.label42.TabIndex = 146;
            this.label42.Text = "/";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(47, 67);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(12, 13);
            this.label69.TabIndex = 149;
            this.label69.Text = "/";
            // 
            // allEFDeb
            // 
            this.allEFDeb.AutoSize = true;
            this.allEFDeb.Location = new System.Drawing.Point(60, 30);
            this.allEFDeb.Name = "allEFDeb";
            this.allEFDeb.Size = new System.Drawing.Size(13, 13);
            this.allEFDeb.TabIndex = 143;
            this.allEFDeb.Text = "0";
            // 
            // allM3Deb
            // 
            this.allM3Deb.AutoSize = true;
            this.allM3Deb.Location = new System.Drawing.Point(60, 107);
            this.allM3Deb.Name = "allM3Deb";
            this.allM3Deb.Size = new System.Drawing.Size(13, 13);
            this.allM3Deb.TabIndex = 154;
            this.allM3Deb.Text = "0";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(47, 31);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(12, 13);
            this.label55.TabIndex = 145;
            this.label55.Text = "/";
            // 
            // allToGoDEDeb
            // 
            this.allToGoDEDeb.AutoSize = true;
            this.allToGoDEDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allToGoDEDeb.ForeColor = System.Drawing.Color.Black;
            this.allToGoDEDeb.Location = new System.Drawing.Point(20, 48);
            this.allToGoDEDeb.Name = "allToGoDEDeb";
            this.allToGoDEDeb.Size = new System.Drawing.Size(14, 13);
            this.allToGoDEDeb.TabIndex = 142;
            this.allToGoDEDeb.Text = "0";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(47, 108);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(12, 13);
            this.label59.TabIndex = 155;
            this.label59.Text = "/";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.bigToGoEFDeb);
            this.groupBox9.Controls.Add(this.bigToGoM3Deb);
            this.groupBox9.Controls.Add(this.label77);
            this.groupBox9.Controls.Add(this.bigM3Deb);
            this.groupBox9.Controls.Add(this.label75);
            this.groupBox9.Controls.Add(this.label52);
            this.groupBox9.Controls.Add(this.bigToGoDEDeb);
            this.groupBox9.Controls.Add(this.label71);
            this.groupBox9.Controls.Add(this.bigOsszDeb);
            this.groupBox9.Controls.Add(this.bigDEDeb);
            this.groupBox9.Controls.Add(this.bigToGoDUDeb);
            this.groupBox9.Controls.Add(this.bigToGoOsszDeb);
            this.groupBox9.Controls.Add(this.bigEFDeb);
            this.groupBox9.Controls.Add(this.label64);
            this.groupBox9.Controls.Add(this.bigDUDeb);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox9.Location = new System.Drawing.Point(110, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(91, 128);
            this.groupBox9.TabIndex = 28;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Nagy Debr.";
            // 
            // bigToGoEFDeb
            // 
            this.bigToGoEFDeb.AutoSize = true;
            this.bigToGoEFDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigToGoEFDeb.Location = new System.Drawing.Point(16, 31);
            this.bigToGoEFDeb.Name = "bigToGoEFDeb";
            this.bigToGoEFDeb.Size = new System.Drawing.Size(14, 13);
            this.bigToGoEFDeb.TabIndex = 106;
            this.bigToGoEFDeb.Text = "0";
            this.bigToGoEFDeb.TextChanged += new System.EventHandler(this.bigToGoEFDeb_TextChanged);
            // 
            // bigToGoM3Deb
            // 
            this.bigToGoM3Deb.AutoSize = true;
            this.bigToGoM3Deb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigToGoM3Deb.ForeColor = System.Drawing.Color.Black;
            this.bigToGoM3Deb.Location = new System.Drawing.Point(16, 108);
            this.bigToGoM3Deb.Name = "bigToGoM3Deb";
            this.bigToGoM3Deb.Size = new System.Drawing.Size(14, 13);
            this.bigToGoM3Deb.TabIndex = 118;
            this.bigToGoM3Deb.Text = "0";
            this.bigToGoM3Deb.TextChanged += new System.EventHandler(this.kism3Unmap_TextChanged);
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(45, 49);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(12, 13);
            this.label77.TabIndex = 111;
            this.label77.Text = "/";
            // 
            // bigM3Deb
            // 
            this.bigM3Deb.AutoSize = true;
            this.bigM3Deb.Location = new System.Drawing.Point(56, 108);
            this.bigM3Deb.Name = "bigM3Deb";
            this.bigM3Deb.Size = new System.Drawing.Size(13, 13);
            this.bigM3Deb.TabIndex = 130;
            this.bigM3Deb.Text = "0";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(45, 31);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(12, 13);
            this.label75.TabIndex = 110;
            this.label75.Text = "/";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(45, 108);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(12, 13);
            this.label52.TabIndex = 120;
            this.label52.Text = "/";
            // 
            // bigToGoDEDeb
            // 
            this.bigToGoDEDeb.AutoSize = true;
            this.bigToGoDEDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigToGoDEDeb.ForeColor = System.Drawing.Color.Black;
            this.bigToGoDEDeb.Location = new System.Drawing.Point(16, 49);
            this.bigToGoDEDeb.Name = "bigToGoDEDeb";
            this.bigToGoDEDeb.Size = new System.Drawing.Size(14, 13);
            this.bigToGoDEDeb.TabIndex = 107;
            this.bigToGoDEDeb.Text = "0";
            this.bigToGoDEDeb.TextChanged += new System.EventHandler(this.bigToGoEFDeb_TextChanged);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(45, 67);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(12, 13);
            this.label71.TabIndex = 114;
            this.label71.Text = "/";
            // 
            // bigOsszDeb
            // 
            this.bigOsszDeb.AutoSize = true;
            this.bigOsszDeb.Location = new System.Drawing.Point(56, 89);
            this.bigOsszDeb.Name = "bigOsszDeb";
            this.bigOsszDeb.Size = new System.Drawing.Size(13, 13);
            this.bigOsszDeb.TabIndex = 128;
            this.bigOsszDeb.Text = "0";
            // 
            // bigDEDeb
            // 
            this.bigDEDeb.AutoSize = true;
            this.bigDEDeb.Location = new System.Drawing.Point(56, 49);
            this.bigDEDeb.Name = "bigDEDeb";
            this.bigDEDeb.Size = new System.Drawing.Size(13, 13);
            this.bigDEDeb.TabIndex = 124;
            this.bigDEDeb.Text = "0";
            // 
            // bigToGoDUDeb
            // 
            this.bigToGoDUDeb.AutoSize = true;
            this.bigToGoDUDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigToGoDUDeb.ForeColor = System.Drawing.Color.Black;
            this.bigToGoDUDeb.Location = new System.Drawing.Point(16, 67);
            this.bigToGoDUDeb.Name = "bigToGoDUDeb";
            this.bigToGoDUDeb.Size = new System.Drawing.Size(14, 13);
            this.bigToGoDUDeb.TabIndex = 112;
            this.bigToGoDUDeb.Text = "0";
            this.bigToGoDUDeb.TextChanged += new System.EventHandler(this.bigToGoEFDeb_TextChanged);
            // 
            // bigToGoOsszDeb
            // 
            this.bigToGoOsszDeb.AutoSize = true;
            this.bigToGoOsszDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigToGoOsszDeb.ForeColor = System.Drawing.Color.Black;
            this.bigToGoOsszDeb.Location = new System.Drawing.Point(16, 89);
            this.bigToGoOsszDeb.Name = "bigToGoOsszDeb";
            this.bigToGoOsszDeb.Size = new System.Drawing.Size(14, 13);
            this.bigToGoOsszDeb.TabIndex = 115;
            this.bigToGoOsszDeb.Text = "0";
            // 
            // bigEFDeb
            // 
            this.bigEFDeb.AutoSize = true;
            this.bigEFDeb.Location = new System.Drawing.Point(56, 31);
            this.bigEFDeb.Name = "bigEFDeb";
            this.bigEFDeb.Size = new System.Drawing.Size(13, 13);
            this.bigEFDeb.TabIndex = 122;
            this.bigEFDeb.Text = "0";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(45, 89);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(12, 13);
            this.label64.TabIndex = 117;
            this.label64.Text = "/";
            // 
            // bigDUDeb
            // 
            this.bigDUDeb.AutoSize = true;
            this.bigDUDeb.Location = new System.Drawing.Point(56, 67);
            this.bigDUDeb.Name = "bigDUDeb";
            this.bigDUDeb.Size = new System.Drawing.Size(13, 13);
            this.bigDUDeb.TabIndex = 126;
            this.bigDUDeb.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.smallM3Deb);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.smallToGoOsszDeb);
            this.groupBox3.Controls.Add(this.smallOsszDeb);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.smallToGoDUDeb);
            this.groupBox3.Controls.Add(this.smallDUDeb);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.smallToGoEFDeb);
            this.groupBox3.Controls.Add(this.smallToGoDEDeb);
            this.groupBox3.Controls.Add(this.smallEFDeb);
            this.groupBox3.Controls.Add(this.smallDEDeb);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.smallToGoM3Deb);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(110, 128);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kis Debr.";
            // 
            // smallM3Deb
            // 
            this.smallM3Deb.AutoSize = true;
            this.smallM3Deb.Location = new System.Drawing.Point(78, 108);
            this.smallM3Deb.Name = "smallM3Deb";
            this.smallM3Deb.Size = new System.Drawing.Size(13, 13);
            this.smallM3Deb.TabIndex = 30;
            this.smallM3Deb.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "m3";
            // 
            // smallToGoOsszDeb
            // 
            this.smallToGoOsszDeb.AutoSize = true;
            this.smallToGoOsszDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smallToGoOsszDeb.ForeColor = System.Drawing.Color.Black;
            this.smallToGoOsszDeb.Location = new System.Drawing.Point(41, 89);
            this.smallToGoOsszDeb.Name = "smallToGoOsszDeb";
            this.smallToGoOsszDeb.Size = new System.Drawing.Size(14, 13);
            this.smallToGoOsszDeb.TabIndex = 25;
            this.smallToGoOsszDeb.Text = "0";
            // 
            // smallOsszDeb
            // 
            this.smallOsszDeb.AutoSize = true;
            this.smallOsszDeb.Location = new System.Drawing.Point(78, 89);
            this.smallOsszDeb.Name = "smallOsszDeb";
            this.smallOsszDeb.Size = new System.Drawing.Size(13, 13);
            this.smallOsszDeb.TabIndex = 26;
            this.smallOsszDeb.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(5, 90);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(33, 13);
            this.label26.TabIndex = 24;
            this.label26.Text = "Össz.";
            // 
            // smallToGoDUDeb
            // 
            this.smallToGoDUDeb.AutoSize = true;
            this.smallToGoDUDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smallToGoDUDeb.ForeColor = System.Drawing.Color.Black;
            this.smallToGoDUDeb.Location = new System.Drawing.Point(41, 67);
            this.smallToGoDUDeb.Name = "smallToGoDUDeb";
            this.smallToGoDUDeb.Size = new System.Drawing.Size(14, 13);
            this.smallToGoDUDeb.TabIndex = 15;
            this.smallToGoDUDeb.Text = "0";
            this.smallToGoDUDeb.TextChanged += new System.EventHandler(this.smallToGoEFDeb_TextChanged);
            // 
            // smallDUDeb
            // 
            this.smallDUDeb.AutoSize = true;
            this.smallDUDeb.Location = new System.Drawing.Point(78, 67);
            this.smallDUDeb.Name = "smallDUDeb";
            this.smallDUDeb.Size = new System.Drawing.Size(13, 13);
            this.smallDUDeb.TabIndex = 16;
            this.smallDUDeb.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 68);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 14;
            this.label20.Text = "Du";
            // 
            // smallToGoEFDeb
            // 
            this.smallToGoEFDeb.AutoSize = true;
            this.smallToGoEFDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smallToGoEFDeb.Location = new System.Drawing.Point(41, 31);
            this.smallToGoEFDeb.Name = "smallToGoEFDeb";
            this.smallToGoEFDeb.Size = new System.Drawing.Size(14, 13);
            this.smallToGoEFDeb.TabIndex = 8;
            this.smallToGoEFDeb.Text = "0";
            this.smallToGoEFDeb.TextChanged += new System.EventHandler(this.smallToGoEFDeb_TextChanged);
            // 
            // smallToGoDEDeb
            // 
            this.smallToGoDEDeb.AutoSize = true;
            this.smallToGoDEDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smallToGoDEDeb.ForeColor = System.Drawing.Color.Black;
            this.smallToGoDEDeb.Location = new System.Drawing.Point(41, 49);
            this.smallToGoDEDeb.Name = "smallToGoDEDeb";
            this.smallToGoDEDeb.Size = new System.Drawing.Size(14, 13);
            this.smallToGoDEDeb.TabIndex = 9;
            this.smallToGoDEDeb.Text = "0";
            this.smallToGoDEDeb.TextChanged += new System.EventHandler(this.smallToGoEFDeb_TextChanged);
            // 
            // smallEFDeb
            // 
            this.smallEFDeb.AutoSize = true;
            this.smallEFDeb.Location = new System.Drawing.Point(78, 31);
            this.smallEFDeb.Name = "smallEFDeb";
            this.smallEFDeb.Size = new System.Drawing.Size(13, 13);
            this.smallEFDeb.TabIndex = 10;
            this.smallEFDeb.Text = "0";
            // 
            // smallDEDeb
            // 
            this.smallDEDeb.AutoSize = true;
            this.smallDEDeb.Location = new System.Drawing.Point(78, 49);
            this.smallDEDeb.Name = "smallDEDeb";
            this.smallDEDeb.Size = new System.Drawing.Size(13, 13);
            this.smallDEDeb.TabIndex = 11;
            this.smallDEDeb.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "EF";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "De";
            // 
            // smallToGoM3Deb
            // 
            this.smallToGoM3Deb.AutoSize = true;
            this.smallToGoM3Deb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smallToGoM3Deb.ForeColor = System.Drawing.Color.Black;
            this.smallToGoM3Deb.Location = new System.Drawing.Point(41, 108);
            this.smallToGoM3Deb.Name = "smallToGoM3Deb";
            this.smallToGoM3Deb.Size = new System.Drawing.Size(14, 13);
            this.smallToGoM3Deb.TabIndex = 29;
            this.smallToGoM3Deb.Text = "0";
            this.smallToGoM3Deb.TextChanged += new System.EventHandler(this.kism3Unmap_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "/";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(66, 89);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(12, 13);
            this.label24.TabIndex = 27;
            this.label24.Text = "/";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(66, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(12, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "/";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(66, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "/";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(66, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "/";
            // 
            // Forduló
            // 
            this.Forduló.Controls.Add(this.driverTxt);
            this.Forduló.Controls.Add(this.helperTxt);
            this.Forduló.Controls.Add(this.label14);
            this.Forduló.Controls.Add(this.Sofőr);
            this.Forduló.Controls.Add(this.availableWorkTxt);
            this.Forduló.Controls.Add(this.label5);
            this.Forduló.Dock = System.Windows.Forms.DockStyle.Left;
            this.Forduló.Location = new System.Drawing.Point(0, 0);
            this.Forduló.Name = "Forduló";
            this.Forduló.Size = new System.Drawing.Size(161, 128);
            this.Forduló.TabIndex = 6;
            this.Forduló.TabStop = false;
            // 
            // driverTxt
            // 
            this.driverTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driverTxt.Location = new System.Drawing.Point(58, 45);
            this.driverTxt.Name = "driverTxt";
            this.driverTxt.Size = new System.Drawing.Size(97, 26);
            this.driverTxt.TabIndex = 8;
            // 
            // helperTxt
            // 
            this.helperTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helperTxt.Location = new System.Drawing.Point(58, 92);
            this.helperTxt.Name = "helperTxt";
            this.helperTxt.Size = new System.Drawing.Size(97, 26);
            this.helperTxt.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Segéd";
            // 
            // Sofőr
            // 
            this.Sofőr.AutoSize = true;
            this.Sofőr.Location = new System.Drawing.Point(18, 45);
            this.Sofőr.Name = "Sofőr";
            this.Sofőr.Size = new System.Drawing.Size(32, 13);
            this.Sofőr.TabIndex = 2;
            this.Sofőr.Text = "Sofőr";
            // 
            // availableWorkTxt
            // 
            this.availableWorkTxt.AutoSize = true;
            this.availableWorkTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableWorkTxt.Location = new System.Drawing.Point(117, 16);
            this.availableWorkTxt.Name = "availableWorkTxt";
            this.availableWorkTxt.Size = new System.Drawing.Size(14, 13);
            this.availableWorkTxt.TabIndex = 1;
            this.availableWorkTxt.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Szabad címek";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.fixateBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(850, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(81, 128);
            this.panel5.TabIndex = 29;
            // 
            // fixateBtn
            // 
            this.fixateBtn.Location = new System.Drawing.Point(3, 34);
            this.fixateBtn.Name = "fixateBtn";
            this.fixateBtn.Size = new System.Drawing.Size(75, 58);
            this.fixateBtn.TabIndex = 0;
            this.fixateBtn.Text = "Lezár";
            this.fixateBtn.UseVisualStyleBackColor = true;
            this.fixateBtn.Click += new System.EventHandler(this.fixateBtn_Click);
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.fajcso);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.fajlagosIdo);
            this.panel4.Controls.Add(this.label28);
            this.panel4.Controls.Add(this.fajlagosTav);
            this.panel4.Controls.Add(this.label32);
            this.panel4.Controls.Add(this.infotext);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.allkoltseg);
            this.panel4.Controls.Add(this.atlagMunkaVege);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.cumiteny);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.fullTav);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(4);
            this.panel4.Size = new System.Drawing.Size(1258, 89);
            this.panel4.TabIndex = 7;
            // 
            // fajcso
            // 
            this.fajcso.AutoSize = true;
            this.fajcso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fajcso.ForeColor = System.Drawing.Color.Black;
            this.fajcso.Location = new System.Drawing.Point(181, 63);
            this.fajcso.Name = "fajcso";
            this.fajcso.Size = new System.Drawing.Size(17, 17);
            this.fajcso.TabIndex = 18;
            this.fajcso.Text = "0";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(13, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "Fajlagos csőhossz [m/cím] :";
            // 
            // fajlagosIdo
            // 
            this.fajlagosIdo.AutoSize = true;
            this.fajlagosIdo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fajlagosIdo.ForeColor = System.Drawing.Color.Black;
            this.fajlagosIdo.Location = new System.Drawing.Point(390, 28);
            this.fajlagosIdo.Name = "fajlagosIdo";
            this.fajlagosIdo.Size = new System.Drawing.Size(63, 17);
            this.fajlagosIdo.TabIndex = 16;
            this.fajlagosIdo.Text = "0:00:00";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(239, 28);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(140, 14);
            this.label28.TabIndex = 15;
            this.label28.Text = "Fajlagos idő [ó:p:mp/cím]:";
            // 
            // fajlagosTav
            // 
            this.fajlagosTav.AutoSize = true;
            this.fajlagosTav.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fajlagosTav.ForeColor = System.Drawing.Color.Black;
            this.fajlagosTav.Location = new System.Drawing.Point(181, 46);
            this.fajlagosTav.Name = "fajlagosTav";
            this.fajlagosTav.Size = new System.Drawing.Size(17, 17);
            this.fajlagosTav.TabIndex = 14;
            this.fajlagosTav.Text = "0";
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(13, 46);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(141, 14);
            this.label32.TabIndex = 13;
            this.label32.Text = "Fajlagos táv [km/cím]:";
            // 
            // infotext
            // 
            this.infotext.BackColor = System.Drawing.Color.White;
            this.infotext.Dock = System.Windows.Forms.DockStyle.Right;
            this.infotext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infotext.Location = new System.Drawing.Point(521, 4);
            this.infotext.Multiline = true;
            this.infotext.Name = "infotext";
            this.infotext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infotext.Size = new System.Drawing.Size(490, 81);
            this.infotext.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(489, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Info:";
            // 
            // allkoltseg
            // 
            this.allkoltseg.AutoSize = true;
            this.allkoltseg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allkoltseg.ForeColor = System.Drawing.Color.Black;
            this.allkoltseg.Location = new System.Drawing.Point(181, 28);
            this.allkoltseg.Name = "allkoltseg";
            this.allkoltseg.Size = new System.Drawing.Size(17, 17);
            this.allkoltseg.TabIndex = 5;
            this.allkoltseg.Text = "0";
            // 
            // atlagMunkaVege
            // 
            this.atlagMunkaVege.AutoSize = true;
            this.atlagMunkaVege.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atlagMunkaVege.ForeColor = System.Drawing.Color.Red;
            this.atlagMunkaVege.Location = new System.Drawing.Point(390, 46);
            this.atlagMunkaVege.Name = "atlagMunkaVege";
            this.atlagMunkaVege.Size = new System.Drawing.Size(49, 17);
            this.atlagMunkaVege.TabIndex = 9;
            this.atlagMunkaVege.Text = "06:00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(239, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Átlagos munkaidő vége:";
            // 
            // cumiteny
            // 
            this.cumiteny.AutoSize = true;
            this.cumiteny.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cumiteny.ForeColor = System.Drawing.Color.Red;
            this.cumiteny.Location = new System.Drawing.Point(390, 9);
            this.cumiteny.Name = "cumiteny";
            this.cumiteny.Size = new System.Drawing.Size(63, 17);
            this.cumiteny.TabIndex = 7;
            this.cumiteny.Text = "0:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Átlagos időtényező [ó:p:mp]:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Összköltség:";
            // 
            // fullTav
            // 
            this.fullTav.AutoSize = true;
            this.fullTav.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullTav.ForeColor = System.Drawing.Color.Black;
            this.fullTav.Location = new System.Drawing.Point(181, 9);
            this.fullTav.Name = "fullTav";
            this.fullTav.Size = new System.Drawing.Size(17, 17);
            this.fullTav.TabIndex = 3;
            this.fullTav.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Össz.táv:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clickedGroup);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(1011, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 81);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kiválasztott címek";
            // 
            // clickedGroup
            // 
            this.clickedGroup.BackColor = System.Drawing.SystemColors.Window;
            this.clickedGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clickedGroup.FormattingEnabled = true;
            this.clickedGroup.HorizontalScrollbar = true;
            this.clickedGroup.Location = new System.Drawing.Point(3, 16);
            this.clickedGroup.Name = "clickedGroup";
            this.clickedGroup.Size = new System.Drawing.Size(237, 56);
            this.clickedGroup.TabIndex = 0;
            this.clickedGroup.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.aktivak_MouseDoubleClick);
            this.clickedGroup.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.aktivak_Format);
            // 
            // datePanel
            // 
            this.datePanel.BackgroundImage = global::TurmixLog.Properties.Resources.back;
            this.datePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.datePanel.Controls.Add(this.nomapButton);
            this.datePanel.Controls.Add(this.toolStrip1);
            this.datePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.datePanel.Location = new System.Drawing.Point(3, 3);
            this.datePanel.Name = "datePanel";
            this.datePanel.Size = new System.Drawing.Size(1258, 40);
            this.datePanel.TabIndex = 4;
            // 
            // nomapButton
            // 
            this.nomapButton.BackgroundImage = global::TurmixLog.Properties.Resources.warning;
            this.nomapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.nomapButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.nomapButton.Location = new System.Drawing.Point(1210, 0);
            this.nomapButton.Name = "nomapButton";
            this.nomapButton.Size = new System.Drawing.Size(48, 40);
            this.nomapButton.TabIndex = 1;
            this.toolTip1.SetToolTip(this.nomapButton, "Nem megjeleníthető címek kezelése");
            this.nomapButton.UseVisualStyleBackColor = true;
            this.nomapButton.Visible = false;
            this.nomapButton.Click += new System.EventHandler(this.nemMegjeleníthetőCímekToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::TurmixLog.Properties.Resources.back;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.dateRevBtn,
            this.toolStripSeparator1,
            this.osszauto_rad,
            this.kisauto_rad,
            this.nagyauto_rad,
            this.toolStripSeparator3,
            this.alertGroup,
            this.toolStripSeparator7,
            this.toolStripButton2,
            this.saveButton,
            this.toolStripSeparator2,
            this.settingsButton,
            this.toolStripButton3,
            this.toolStripSeparator6,
            this.soundButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(521, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 37);
            this.toolStripLabel1.Text = "Kiosztás dátuma:";
            // 
            // dateRevBtn
            // 
            this.dateRevBtn.AutoSize = false;
            this.dateRevBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dateRevBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.dateRevBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dateRevBtn.Name = "dateRevBtn";
            this.dateRevBtn.Size = new System.Drawing.Size(60, 37);
            this.dateRevBtn.Text = "Indít!";
            this.dateRevBtn.ToolTipText = "Kiosztás indítása";
            this.dateRevBtn.Click += new System.EventHandler(this.dateRevBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // osszauto_rad
            // 
            this.osszauto_rad.Checked = true;
            this.osszauto_rad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.osszauto_rad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.osszauto_rad.Image = ((System.Drawing.Image)(resources.GetObject("osszauto_rad.Image")));
            this.osszauto_rad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.osszauto_rad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.osszauto_rad.Name = "osszauto_rad";
            this.osszauto_rad.Size = new System.Drawing.Size(38, 37);
            this.osszauto_rad.Text = "toolStripButton1";
            this.osszauto_rad.ToolTipText = "Összes cím";
            this.osszauto_rad.Click += new System.EventHandler(this.nagyauto_rad_Click);
            // 
            // kisauto_rad
            // 
            this.kisauto_rad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kisauto_rad.Image = ((System.Drawing.Image)(resources.GetObject("kisauto_rad.Image")));
            this.kisauto_rad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.kisauto_rad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kisauto_rad.Name = "kisauto_rad";
            this.kisauto_rad.Size = new System.Drawing.Size(37, 37);
            this.kisauto_rad.Text = "toolStripButton1";
            this.kisauto_rad.ToolTipText = "Kis címek";
            this.kisauto_rad.Click += new System.EventHandler(this.nagyauto_rad_Click);
            // 
            // nagyauto_rad
            // 
            this.nagyauto_rad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nagyauto_rad.Image = ((System.Drawing.Image)(resources.GetObject("nagyauto_rad.Image")));
            this.nagyauto_rad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nagyauto_rad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nagyauto_rad.Name = "nagyauto_rad";
            this.nagyauto_rad.Size = new System.Drawing.Size(38, 37);
            this.nagyauto_rad.Text = "toolStripButton1";
            this.nagyauto_rad.ToolTipText = "Nagy címek";
            this.nagyauto_rad.Click += new System.EventHandler(this.nagyauto_rad_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // alertGroup
            // 
            this.alertGroup.CheckOnClick = true;
            this.alertGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.alertGroup.Image = global::TurmixLog.Properties.Resources.alert;
            this.alertGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.alertGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alertGroup.Name = "alertGroup";
            this.alertGroup.Size = new System.Drawing.Size(34, 37);
            this.alertGroup.ToolTipText = "Problémás címek";
            this.alertGroup.Click += new System.EventHandler(this.alertGroup_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(26, 37);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Megnyitás";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Enabled = false;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(34, 37);
            this.saveButton.Text = "toolStripButton1";
            this.saveButton.ToolTipText = "Mentés";
            this.saveButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // settingsButton
            // 
            this.settingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsButton.Enabled = false;
            this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
            this.settingsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(44, 37);
            this.settingsButton.Text = "toolStripButton4";
            this.settingsButton.ToolTipText = "Járművek adatai";
            this.settingsButton.Click += new System.EventHandler(this.settings_btn_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 37);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Beállítások";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 40);
            // 
            // soundButton
            // 
            this.soundButton.Checked = true;
            this.soundButton.CheckOnClick = true;
            this.soundButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.soundButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.soundButton.Image = global::TurmixLog.Properties.Resources.hang;
            this.soundButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.soundButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.soundButton.Name = "soundButton";
            this.soundButton.Size = new System.Drawing.Size(36, 37);
            this.soundButton.Text = "Hangok engedélyezése/letiltása";
            this.soundButton.Click += new System.EventHandler(this.soundButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1264, 694);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Nyomtatás";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.munkaPrintBtn);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox8.Location = new System.Drawing.Point(3, 464);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1258, 227);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Munkalapok";
            // 
            // munkaPrintBtn
            // 
            this.munkaPrintBtn.Location = new System.Drawing.Point(33, 42);
            this.munkaPrintBtn.Name = "munkaPrintBtn";
            this.munkaPrintBtn.Size = new System.Drawing.Size(94, 23);
            this.munkaPrintBtn.TabIndex = 7;
            this.munkaPrintBtn.Text = "Nyomtatás";
            this.munkaPrintBtn.UseVisualStyleBackColor = true;
            this.munkaPrintBtn.Click += new System.EventHandler(this.munkaPrintBtn_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.statPdf);
            this.groupBox7.Controls.Add(this.statprn);
            this.groupBox7.Controls.Add(this.statprev);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 308);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1258, 156);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Járműstatisztika";
            // 
            // statPdf
            // 
            this.statPdf.Location = new System.Drawing.Point(33, 102);
            this.statPdf.Name = "statPdf";
            this.statPdf.Size = new System.Drawing.Size(94, 23);
            this.statPdf.TabIndex = 7;
            this.statPdf.Text = "Mentés PDF-be";
            this.statPdf.UseVisualStyleBackColor = true;
            this.statPdf.Click += new System.EventHandler(this.statPdf_Click);
            // 
            // statprn
            // 
            this.statprn.Location = new System.Drawing.Point(33, 73);
            this.statprn.Name = "statprn";
            this.statprn.Size = new System.Drawing.Size(94, 23);
            this.statprn.TabIndex = 6;
            this.statprn.Text = "Nyomtatás";
            this.statprn.UseVisualStyleBackColor = true;
            this.statprn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // statprev
            // 
            this.statprev.Location = new System.Drawing.Point(33, 44);
            this.statprev.Name = "statprev";
            this.statprev.Size = new System.Drawing.Size(94, 23);
            this.statprev.TabIndex = 5;
            this.statprev.Text = "Előnézet";
            this.statprev.UseVisualStyleBackColor = true;
            this.statprev.Click += new System.EventHandler(this.statprev_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.gyujtoPDFBtn);
            this.groupBox6.Controls.Add(this.sideBtn);
            this.groupBox6.Controls.Add(this.prBtn);
            this.groupBox6.Controls.Add(this.printBtn);
            this.groupBox6.Controls.Add(this.fontBtn);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 108);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1258, 200);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Gyűjtők";
            // 
            // sideBtn
            // 
            this.sideBtn.Location = new System.Drawing.Point(33, 64);
            this.sideBtn.Name = "sideBtn";
            this.sideBtn.Size = new System.Drawing.Size(94, 23);
            this.sideBtn.TabIndex = 4;
            this.sideBtn.Text = "Oldalbeállítás";
            this.sideBtn.UseVisualStyleBackColor = true;
            this.sideBtn.Click += new System.EventHandler(this.sideBtn_Click);
            // 
            // prBtn
            // 
            this.prBtn.Location = new System.Drawing.Point(33, 122);
            this.prBtn.Name = "prBtn";
            this.prBtn.Size = new System.Drawing.Size(94, 23);
            this.prBtn.TabIndex = 3;
            this.prBtn.Text = "Nyomtatás";
            this.prBtn.UseVisualStyleBackColor = true;
            this.prBtn.Click += new System.EventHandler(this.prBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(33, 93);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(94, 23);
            this.printBtn.TabIndex = 2;
            this.printBtn.Text = "Előnézet";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printGyujtoBtn_Click);
            // 
            // fontBtn
            // 
            this.fontBtn.Location = new System.Drawing.Point(33, 35);
            this.fontBtn.Name = "fontBtn";
            this.fontBtn.Size = new System.Drawing.Size(94, 23);
            this.fontBtn.TabIndex = 1;
            this.fontBtn.Text = "Betűtípus";
            this.fontBtn.UseVisualStyleBackColor = true;
            this.fontBtn.Click += new System.EventHandler(this.fontBtn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.csvBtn);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1258, 105);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "CSV";
            // 
            // csvBtn
            // 
            this.csvBtn.Location = new System.Drawing.Point(33, 37);
            this.csvBtn.Name = "csvBtn";
            this.csvBtn.Size = new System.Drawing.Size(94, 23);
            this.csvBtn.TabIndex = 4;
            this.csvBtn.Text = "CSV generálása";
            this.csvBtn.UseVisualStyleBackColor = true;
            this.csvBtn.Click += new System.EventHandler(this.csvBtn_Click);
            // 
            // errorStrip
            // 
            this.errorStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kiválasztToolStripMenuItem,
            this.lezárToolStripMenuItem,
            this.mutatATérképenToolStripMenuItem});
            this.errorStrip.Name = "errorStrip";
            this.errorStrip.Size = new System.Drawing.Size(165, 70);
            // 
            // kiválasztToolStripMenuItem
            // 
            this.kiválasztToolStripMenuItem.Name = "kiválasztToolStripMenuItem";
            this.kiválasztToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.kiválasztToolStripMenuItem.Text = "Kiválaszt";
            this.kiválasztToolStripMenuItem.Click += new System.EventHandler(this.kiválasztToolStripMenuItem_Click);
            // 
            // lezárToolStripMenuItem
            // 
            this.lezárToolStripMenuItem.Name = "lezárToolStripMenuItem";
            this.lezárToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.lezárToolStripMenuItem.Text = "Lezár";
            this.lezárToolStripMenuItem.Click += new System.EventHandler(this.lezárToolStripMenuItem_Click);
            // 
            // mutatATérképenToolStripMenuItem
            // 
            this.mutatATérképenToolStripMenuItem.Name = "mutatATérképenToolStripMenuItem";
            this.mutatATérképenToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.mutatATérképenToolStripMenuItem.Text = "Mutat a térképen";
            this.mutatATérképenToolStripMenuItem.Click += new System.EventHandler(this.mutatATérképenToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fuvarTörléseToolStripMenuItem,
            this.mutatATérképenToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 48);
            // 
            // fuvarTörléseToolStripMenuItem
            // 
            this.fuvarTörléseToolStripMenuItem.Name = "fuvarTörléseToolStripMenuItem";
            this.fuvarTörléseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.fuvarTörléseToolStripMenuItem.Text = "Újraszervezés";
            this.fuvarTörléseToolStripMenuItem.Click += new System.EventHandler(this.fuvarTörléseToolStripMenuItem_Click);
            // 
            // mutatATérképenToolStripMenuItem1
            // 
            this.mutatATérképenToolStripMenuItem1.Name = "mutatATérképenToolStripMenuItem1";
            this.mutatATérképenToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.mutatATérképenToolStripMenuItem1.Text = "Mutat a térképen";
            this.mutatATérképenToolStripMenuItem1.Visible = false;
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.Transparent;
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statlabel});
            this.status.Location = new System.Drawing.Point(0, 744);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1272, 22);
            this.status.TabIndex = 2;
            // 
            // statlabel
            // 
            this.statlabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statlabel.Name = "statlabel";
            this.statlabel.Size = new System.Drawing.Size(30, 17);
            this.statlabel.Text = "Kész";
            // 
            // gyujtoPDFBtn
            // 
            this.gyujtoPDFBtn.Location = new System.Drawing.Point(33, 151);
            this.gyujtoPDFBtn.Name = "gyujtoPDFBtn";
            this.gyujtoPDFBtn.Size = new System.Drawing.Size(94, 23);
            this.gyujtoPDFBtn.TabIndex = 5;
            this.gyujtoPDFBtn.Text = "Mentés PDF-be";
            this.gyujtoPDFBtn.UseVisualStyleBackColor = true;
            this.gyujtoPDFBtn.Click += new System.EventHandler(this.gyujtoPDFBtn_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.fixateBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1272, 766);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.status);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Turmix Logisztika 2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Form1_HelpRequested);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.bottomSplit.Panel1.ResumeLayout(false);
            this.bottomSplit.Panel2.ResumeLayout(false);
            this.bottomSplit.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.leftTab.ResumeLayout(false);
            this.infoTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statview)).EndInit();
            this.rendezmenu.ResumeLayout(false);
            this.cimTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cimGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.detailPanel.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Forduló.ResumeLayout(false);
            this.Forduló.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.datePanel.ResumeLayout(false);
            this.datePanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.errorStrip.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fájlToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fuvarTörléseToolStripMenuItem;
		private System.Windows.Forms.Panel datePanel;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ToolStripMenuItem nToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip errorStrip;
		private System.Windows.Forms.Button csvBtn;
		private System.Windows.Forms.ToolStripMenuItem bezárásToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aktuálisÁllapotMentéseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem megnyitásToolStripMenuItem;
		private System.Windows.Forms.StatusStrip status;
		private System.Windows.Forms.ToolStripStatusLabel statlabel;
		private System.Windows.Forms.ToolStripMenuItem mentésMáToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator ltoolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem kiválasztToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lezárToolStripMenuItem;
		private System.Windows.Forms.SplitContainer bottomSplit;
		private System.Windows.Forms.TabControl leftTab;
		private System.Windows.Forms.TabPage infoTab;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView statview;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label allkoltseg;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label fullTav;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TabPage cimTab;
		private System.Windows.Forms.DataGridView cimGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.WebBrowser browser;
		private System.Windows.Forms.Panel detailPanel;
        private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label smallToGoOsszDeb;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label smallOsszDeb;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label smallToGoDUDeb;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label smallDUDeb;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label smallToGoEFDeb;
		private System.Windows.Forms.Label smallToGoDEDeb;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label smallEFDeb;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label smallDEDeb;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListBox clickedGroup;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton de_rad;
		private System.Windows.Forms.RadioButton du_rad;
        private System.Windows.Forms.RadioButton fp_rad;
		private System.Windows.Forms.ToolStripMenuItem mutatATérképenToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip rendezmenu;
		private System.Windows.Forms.ToolStripMenuItem eredetiRendezésVisszaállításaToolStripMenuItem;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button fixateBtn;
		private System.Windows.Forms.ToolStripMenuItem súgóToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem turmixLogisztikaSúgóToolStripMenuItem;
		private System.Windows.Forms.GroupBox Forduló;
		private System.Windows.Forms.Label availableWorkTxt;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label smallM3Deb;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label smallToGoM3Deb;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label Sofőr;
		private System.Windows.Forms.ToolStripMenuItem munkalapszámLátszikAListábanToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Button statprn;
		private System.Windows.Forms.Button statprev;
		private System.Windows.Forms.Button prBtn;
		private System.Windows.Forms.Button printBtn;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Button munkaPrintBtn;
		private System.Windows.Forms.TreeView workTree;
		private System.Windows.Forms.ToolStripMenuItem mutatATérképenToolStripMenuItem1;
		private System.Windows.Forms.Label cumiteny;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label atlagMunkaVege;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.DataGridViewTextBoxColumn statrendszam;
		private System.Windows.Forms.DataGridViewTextBoxColumn statm3Column;
		private System.Windows.Forms.DataGridViewTextBoxColumn statcim;
		private System.Windows.Forms.DataGridViewTextBoxColumn statkm;
		private System.Windows.Forms.DataGridViewTextBoxColumn csoves;
		private System.Windows.Forms.DataGridViewTextBoxColumn statkoltseg;
		private System.Windows.Forms.DataGridViewTextBoxColumn cumiColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn munkaColumn;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox infotext;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripButton dateRevBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton osszauto_rad;
		private System.Windows.Forms.ToolStripButton kisauto_rad;
		private System.Windows.Forms.ToolStripButton nagyauto_rad;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton settingsButton;
		private System.Windows.Forms.ToolStripButton saveButton;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.Label driverTxt;
		private System.Windows.Forms.Label helperTxt;
		private System.Windows.Forms.Label fajlagosIdo;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label fajlagosTav;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.ToolStripMenuItem aTurmixLogisztikaNévjegyeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eszközökToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem beállításokToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem infoÜzemmódToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem címekSzerkesztéseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem járművekAdataiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem térképVisszaállításaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem adatbázisTáblákToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem járművekToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem koordinátákToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem problémásCímekToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ténylegesM3AdatokToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton alertGroup;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem állandóProblémásUtcákToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton soundButton;
        private System.Windows.Forms.ToolStripMenuItem munkalapAdatokToolStripMenuItem;
        private System.Windows.Forms.Button sideBtn;
        private System.Windows.Forms.Button fontBtn;
        private System.Windows.Forms.Label smallM3Jo;
        private System.Windows.Forms.Label smallOsszJo;
        private System.Windows.Forms.Label smallEFJo;
        private System.Windows.Forms.Label smallDUJo;
        private System.Windows.Forms.Label smallDEJo;
        private System.Windows.Forms.Label bigToGoDEJo;
        private System.Windows.Forms.Label bigToGoEFJo;
        private System.Windows.Forms.Label bigToGoDUJo;
        private System.Windows.Forms.Label bigToGoM3Jo;
        private System.Windows.Forms.Label bigToGoOsszJo;
        private System.Windows.Forms.Label allM3Jo;
        private System.Windows.Forms.Label allDUDeb;
        private System.Windows.Forms.Label allToGoDUJo;
        private System.Windows.Forms.Label allOsszJo;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label allOsszDeb;
        private System.Windows.Forms.Label allToGoEFJo;
        private System.Windows.Forms.Label allEFJo;
        private System.Windows.Forms.Label allToGoEFDeb;
        private System.Windows.Forms.Label allToGoOsszDeb;
        private System.Windows.Forms.Label allDUJo;
        private System.Windows.Forms.Label allToGoM3Deb;
        private System.Windows.Forms.Label allToGoDUDeb;
        private System.Windows.Forms.Label allDEDeb;
        private System.Windows.Forms.Label allToGoDEJo;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label allToGoOsszJo;
        private System.Windows.Forms.Label allDEJo;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label allEFDeb;
        private System.Windows.Forms.Label allM3Deb;
        private System.Windows.Forms.Label allToGoM3Jo;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label allToGoDEDeb;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label bigToGoEFDeb;
        private System.Windows.Forms.Label bigToGoM3Deb;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label bigM3Deb;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label bigToGoDEDeb;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label bigOsszDeb;
        private System.Windows.Forms.Label bigDEDeb;
        private System.Windows.Forms.Label bigToGoDUDeb;
        private System.Windows.Forms.Label bigToGoOsszDeb;
        private System.Windows.Forms.Label bigEFDeb;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label bigDUDeb;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.Label bigM3Jo;
        private System.Windows.Forms.Label bigOsszJo;
        private System.Windows.Forms.Label bigEFJo;
        private System.Windows.Forms.Label bigDUJo;
        private System.Windows.Forms.Label bigDEJo;
        private System.Windows.Forms.Label smallToGoEFJo;
        private System.Windows.Forms.Label smallToGoDEJo;
        private System.Windows.Forms.Label smallToGoDUJo;
        private System.Windows.Forms.Label smallToGoOsszJo;
        private System.Windows.Forms.Label smallToGoM3Jo;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label sumM3;
        private System.Windows.Forms.Label sumOssz;
        private System.Windows.Forms.Label sumEF;
        private System.Windows.Forms.Label sumDU;
        private System.Windows.Forms.Label sumDE;
        private System.Windows.Forms.Label fajcso;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button nomapButton;
        private System.Windows.Forms.ToolStripMenuItem koordinátákFelvételeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem földútpontokMódosításaToolStripMenuItem;
        private System.Windows.Forms.Button statPdf;
        private System.Windows.Forms.Button gyujtoPDFBtn;
    }
}

