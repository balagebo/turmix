namespace TurmixReport
{
    partial class ReportViewerPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportViewerPanel));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportSplit = new System.Windows.Forms.SplitContainer();
            this.plainReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.chartReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.infoText = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nézetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.táblázatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grafikonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mindkettőToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oszlopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sordiagramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.területToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.körToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.körsávToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.reportSplit.Panel1.SuspendLayout();
            this.reportSplit.Panel2.SuspendLayout();
            this.reportSplit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2.Controls.Add(this.contentPanel);
            this.splitContainer2.Size = new System.Drawing.Size(1008, 706);
            this.splitContainer2.SplitterDistance = 777;
            this.splitContainer2.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(777, 706);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(769, 680);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Adatok";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(3, 3);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.Size = new System.Drawing.Size(763, 674);
            this.dataGrid.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportSplit);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(769, 680);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Riportok";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reportSplit
            // 
            this.reportSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportSplit.Location = new System.Drawing.Point(3, 3);
            this.reportSplit.Name = "reportSplit";
            // 
            // reportSplit.Panel1
            // 
            this.reportSplit.Panel1.Controls.Add(this.plainReport);
            // 
            // reportSplit.Panel2
            // 
            this.reportSplit.Panel2.Controls.Add(this.chartReport);
            this.reportSplit.Size = new System.Drawing.Size(763, 674);
            this.reportSplit.SplitterDistance = 374;
            this.reportSplit.TabIndex = 1;
            // 
            // plainReport
            // 
            this.plainReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plainReport.Location = new System.Drawing.Point(0, 0);
            this.plainReport.Name = "plainReport";
            this.plainReport.ShowDocumentMapButton = false;
            this.plainReport.Size = new System.Drawing.Size(374, 674);
            this.plainReport.TabIndex = 2;
            // 
            // chartReport
            // 
            this.chartReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartReport.Location = new System.Drawing.Point(0, 0);
            this.chartReport.Name = "chartReport";
            this.chartReport.ShowDocumentMapButton = false;
            this.chartReport.Size = new System.Drawing.Size(385, 674);
            this.chartReport.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 332);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 332);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.infoPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 31);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(227, 301);
            this.panel3.TabIndex = 2;
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.White;
            this.infoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoPanel.Controls.Add(this.infoText);
            this.infoPanel.Controls.Add(this.button1);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoPanel.Location = new System.Drawing.Point(5, 5);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(217, 291);
            this.infoPanel.TabIndex = 0;
            // 
            // infoText
            // 
            this.infoText.AllowWebBrowserDrop = false;
            this.infoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoText.IsWebBrowserContextMenuEnabled = false;
            this.infoText.Location = new System.Drawing.Point(0, 32);
            this.infoText.MinimumSize = new System.Drawing.Size(20, 20);
            this.infoText.Name = "infoText";
            this.infoText.ScriptErrorsSuppressed = true;
            this.infoText.Size = new System.Drawing.Size(215, 257);
            this.infoText.TabIndex = 2;
            this.infoText.WebBrowserShortcutsEnabled = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::TurmixReport.Properties.Resources.infotop;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::TurmixReport.Properties.Resources.info;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Információ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.refreshBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(227, 31);
            this.panel2.TabIndex = 1;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.refreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.refreshBtn.Location = new System.Drawing.Point(149, 3);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 25);
            this.refreshBtn.TabIndex = 0;
            this.refreshBtn.Text = "Frissít!";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(3);
            this.contentPanel.Size = new System.Drawing.Size(227, 332);
            this.contentPanel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::TurmixReport.Properties.Resources.back;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nézetToolStripMenuItem,
            this.diagramToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nézetToolStripMenuItem
            // 
            this.nézetToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.nézetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.táblázatToolStripMenuItem,
            this.grafikonToolStripMenuItem,
            this.mindkettőToolStripMenuItem});
            this.nézetToolStripMenuItem.Name = "nézetToolStripMenuItem";
            this.nézetToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.nézetToolStripMenuItem.Text = "Nézet";
            // 
            // táblázatToolStripMenuItem
            // 
            this.táblázatToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.táblázatToolStripMenuItem.CheckOnClick = true;
            this.táblázatToolStripMenuItem.Name = "táblázatToolStripMenuItem";
            this.táblázatToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.táblázatToolStripMenuItem.Text = "Táblázat";
            this.táblázatToolStripMenuItem.Click += new System.EventHandler(this.táblázatToolStripMenuItem_Click);
            // 
            // grafikonToolStripMenuItem
            // 
            this.grafikonToolStripMenuItem.CheckOnClick = true;
            this.grafikonToolStripMenuItem.Name = "grafikonToolStripMenuItem";
            this.grafikonToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.grafikonToolStripMenuItem.Text = "Grafikon";
            this.grafikonToolStripMenuItem.Click += new System.EventHandler(this.táblázatToolStripMenuItem_Click);
            // 
            // mindkettőToolStripMenuItem
            // 
            this.mindkettőToolStripMenuItem.Checked = true;
            this.mindkettőToolStripMenuItem.CheckOnClick = true;
            this.mindkettőToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mindkettőToolStripMenuItem.Name = "mindkettőToolStripMenuItem";
            this.mindkettőToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.mindkettőToolStripMenuItem.Text = "Mindkettő";
            this.mindkettőToolStripMenuItem.Click += new System.EventHandler(this.táblázatToolStripMenuItem_Click);
            // 
            // diagramToolStripMenuItem
            // 
            this.diagramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oszlopToolStripMenuItem,
            this.sordiagramToolStripMenuItem,
            this.területToolStripMenuItem,
            this.vonalToolStripMenuItem,
            this.körToolStripMenuItem,
            this.körsávToolStripMenuItem});
            this.diagramToolStripMenuItem.Name = "diagramToolStripMenuItem";
            this.diagramToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.diagramToolStripMenuItem.Text = "Diagram";
            // 
            // oszlopToolStripMenuItem
            // 
            this.oszlopToolStripMenuItem.Checked = true;
            this.oszlopToolStripMenuItem.CheckOnClick = true;
            this.oszlopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.oszlopToolStripMenuItem.Name = "oszlopToolStripMenuItem";
            this.oszlopToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.oszlopToolStripMenuItem.Text = "Oszlopdiagram";
            this.oszlopToolStripMenuItem.Click += new System.EventHandler(this.oszlopToolStripMenuItem_Click);
            // 
            // sordiagramToolStripMenuItem
            // 
            this.sordiagramToolStripMenuItem.CheckOnClick = true;
            this.sordiagramToolStripMenuItem.Name = "sordiagramToolStripMenuItem";
            this.sordiagramToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.sordiagramToolStripMenuItem.Text = "Sordiagram";
            this.sordiagramToolStripMenuItem.Click += new System.EventHandler(this.oszlopToolStripMenuItem_Click);
            // 
            // területToolStripMenuItem
            // 
            this.területToolStripMenuItem.CheckOnClick = true;
            this.területToolStripMenuItem.Name = "területToolStripMenuItem";
            this.területToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.területToolStripMenuItem.Text = "Terület";
            this.területToolStripMenuItem.Click += new System.EventHandler(this.oszlopToolStripMenuItem_Click);
            // 
            // vonalToolStripMenuItem
            // 
            this.vonalToolStripMenuItem.CheckOnClick = true;
            this.vonalToolStripMenuItem.Name = "vonalToolStripMenuItem";
            this.vonalToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.vonalToolStripMenuItem.Text = "Vonal";
            this.vonalToolStripMenuItem.Click += new System.EventHandler(this.oszlopToolStripMenuItem_Click);
            // 
            // körToolStripMenuItem
            // 
            this.körToolStripMenuItem.CheckOnClick = true;
            this.körToolStripMenuItem.Name = "körToolStripMenuItem";
            this.körToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.körToolStripMenuItem.Text = "Kör";
            this.körToolStripMenuItem.Click += new System.EventHandler(this.oszlopToolStripMenuItem_Click);
            // 
            // körsávToolStripMenuItem
            // 
            this.körsávToolStripMenuItem.CheckOnClick = true;
            this.körsávToolStripMenuItem.Name = "körsávToolStripMenuItem";
            this.körsávToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.körsávToolStripMenuItem.Text = "Körsáv";
            this.körsávToolStripMenuItem.Click += new System.EventHandler(this.oszlopToolStripMenuItem_Click);
            // 
            // ReportViewerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TurmixReport.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReportViewerPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turmix Riporter Modul";
            this.Load += new System.EventHandler(this.ReportViewerPanel_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.reportSplit.Panel1.ResumeLayout(false);
            this.reportSplit.Panel2.ResumeLayout(false);
            this.reportSplit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nézetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem táblázatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grafikonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mindkettőToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oszlopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sordiagramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem területToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vonalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem körToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem körsávToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer reportSplit;
        private Microsoft.Reporting.WinForms.ReportViewer chartReport;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGrid;
        private Microsoft.Reporting.WinForms.ReportViewer plainReport;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser infoText;
    }
}