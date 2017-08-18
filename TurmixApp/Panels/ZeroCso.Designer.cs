namespace TurmixLog
{
	partial class ZeroCso
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.csoGrid = new TurmixLog.CarGrid();
            this.Cim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CsoStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValosCim = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ValosHsz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValosCsohossz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.csoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "A következő címekhez nincs megadva csőhossz, vagy a megadott érték nem szám. A hi" +
                "ányzó értékek itt pótolhatóak.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::TurmixLog.Properties.Resources.back;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 50);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(642, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // csoGrid
            // 
            this.csoGrid.AllowUserToAddRows = false;
            this.csoGrid.AllowUserToDeleteRows = false;
            this.csoGrid.AllowUserToResizeRows = false;
            this.csoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.csoGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cim,
            this.CsoStr,
            this.ValosCim,
            this.ValosHsz,
            this.ValosCsohossz});
            this.csoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csoGrid.Location = new System.Drawing.Point(0, 50);
            this.csoGrid.Name = "csoGrid";
            this.csoGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.csoGrid.Size = new System.Drawing.Size(729, 348);
            this.csoGrid.TabIndex = 2;
            this.csoGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.csoGrid_CellFormatting);
            this.csoGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.csoGrid_CellEndEdit);
            this.csoGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.csoGrid_DataError);
            // 
            // Cim
            // 
            this.Cim.HeaderText = "Cím";
            this.Cim.Name = "Cim";
            this.Cim.ReadOnly = true;
            this.Cim.Width = 150;
            // 
            // CsoStr
            // 
            this.CsoStr.HeaderText = "Csőhossz adat";
            this.CsoStr.Name = "CsoStr";
            this.CsoStr.ReadOnly = true;
            // 
            // ValosCim
            // 
            this.ValosCim.HeaderText = "Valós utca";
            this.ValosCim.Name = "ValosCim";
            this.ValosCim.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ValosCim.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ValosCim.Width = 150;
            // 
            // ValosHsz
            // 
            this.ValosHsz.HeaderText = "Valós házszám";
            this.ValosHsz.Name = "ValosHsz";
            // 
            // ValosCsohossz
            // 
            this.ValosCsohossz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ValosCsohossz.HeaderText = "Valós csőhossz (m)";
            this.ValosCsohossz.Name = "ValosCsohossz";
            this.ValosCsohossz.Width = 99;
            // 
            // ZeroCso
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(729, 398);
            this.Controls.Add(this.csoGrid);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ZeroCso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Csőhossz nélküli címek";
            this.Load += new System.EventHandler(this.ZeroCso_Load);
            this.Shown += new System.EventHandler(this.ZeroCso_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZeroCso_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.csoGrid)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private CarGrid csoGrid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cim;
        private System.Windows.Forms.DataGridViewTextBoxColumn CsoStr;
        private System.Windows.Forms.DataGridViewComboBoxColumn ValosCim;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValosHsz;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValosCsohossz;
	}
}