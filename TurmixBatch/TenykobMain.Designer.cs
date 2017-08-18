namespace TurmixBatch
{
    partial class TenykobMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenykobMain));
            this.openDir = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openDirTx = new System.Windows.Forms.TextBox();
            this.settingBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.historyBox = new System.Windows.Forms.ListBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openDir
            // 
            this.openDir.Location = new System.Drawing.Point(319, 31);
            this.openDir.Name = "openDir";
            this.openDir.Size = new System.Drawing.Size(31, 20);
            this.openDir.TabIndex = 3;
            this.openDir.Text = "...";
            this.openDir.UseVisualStyleBackColor = true;
            this.openDir.Click += new System.EventHandler(this.openDir_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(19, 57);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 26);
            this.okBtn.TabIndex = 10;
            this.okBtn.Text = "Feldolgozás";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.okBtn);
            this.groupBox2.Controls.Add(this.openDir);
            this.groupBox2.Controls.Add(this.openDirTx);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 102);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Válassza ki a CSV állományt";
            // 
            // openDirTx
            // 
            this.openDirTx.Location = new System.Drawing.Point(19, 31);
            this.openDirTx.Name = "openDirTx";
            this.openDirTx.Size = new System.Drawing.Size(294, 20);
            this.openDirTx.TabIndex = 2;
            // 
            // settingBtn
            // 
            this.settingBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.settingBtn.Location = new System.Drawing.Point(3, 221);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(75, 26);
            this.settingBtn.TabIndex = 11;
            this.settingBtn.Text = "Beállítások";
            this.settingBtn.UseVisualStyleBackColor = true;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.historyBox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 116);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Történet";
            // 
            // historyBox
            // 
            this.historyBox.FormattingEnabled = true;
            this.historyBox.Location = new System.Drawing.Point(19, 21);
            this.historyBox.Name = "historyBox";
            this.historyBox.Size = new System.Drawing.Size(331, 82);
            this.historyBox.TabIndex = 0;
            // 
            // TenykobMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 250);
            this.Controls.Add(this.settingBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TenykobMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turmix Logisztika tényleges m3 modul";
            this.Load += new System.EventHandler(this.TenykobMain_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openDir;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox openDirTx;
        private System.Windows.Forms.Button settingBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox historyBox;

    }
}

