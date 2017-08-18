namespace TurmixLog
{
	partial class ProblemAddressPanel
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.okBtn = new System.Windows.Forms.Button();
			this.cancBtn = new System.Windows.Forms.Button();
			this.streetGrid = new System.Windows.Forms.DataGridView();
			this.Munkalap = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Cim = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Problematic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.streetGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.okBtn);
			this.panel1.Controls.Add(this.cancBtn);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(543, 36);
			this.panel1.TabIndex = 0;
			// 
			// okBtn
			// 
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.okBtn.Location = new System.Drawing.Point(389, 4);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 28);
			this.okBtn.TabIndex = 1;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			// 
			// cancBtn
			// 
			this.cancBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.cancBtn.Location = new System.Drawing.Point(464, 4);
			this.cancBtn.Name = "cancBtn";
			this.cancBtn.Size = new System.Drawing.Size(75, 28);
			this.cancBtn.TabIndex = 0;
			this.cancBtn.Text = "Mégse";
			this.cancBtn.UseVisualStyleBackColor = true;
			// 
			// streetGrid
			// 
			this.streetGrid.AllowUserToAddRows = false;
			this.streetGrid.AllowUserToDeleteRows = false;
			this.streetGrid.AllowUserToResizeRows = false;
			this.streetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.streetGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Munkalap,
            this.Cim,
            this.Info,
            this.Problematic});
			this.streetGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.streetGrid.Location = new System.Drawing.Point(0, 36);
			this.streetGrid.MultiSelect = false;
			this.streetGrid.Name = "streetGrid";
			this.streetGrid.RowHeadersVisible = false;
			this.streetGrid.Size = new System.Drawing.Size(543, 300);
			this.streetGrid.TabIndex = 1;
			this.streetGrid.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.streetGrid_SortCompare);
			// 
			// Munkalap
			// 
			this.Munkalap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.Munkalap.HeaderText = "Munkalapszám";
			this.Munkalap.Name = "Munkalap";
			this.Munkalap.Width = 5;
			// 
			// Cim
			// 
			this.Cim.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.Cim.HeaderText = "Cím";
			this.Cim.Name = "Cim";
			this.Cim.Width = 5;
			// 
			// Info
			// 
			this.Info.HeaderText = "Info";
			this.Info.Name = "Info";
			this.Info.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Info.Width = 468;
			// 
			// Problematic
			// 
			this.Problematic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Problematic.HeaderText = "Problémás";
			this.Problematic.Name = "Problematic";
			this.Problematic.Width = 62;
			// 
			// ProblemAddressPanel
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::TurmixLog.Properties.Resources.back;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.CancelButton = this.cancBtn;
			this.ClientSize = new System.Drawing.Size(543, 336);
			this.Controls.Add(this.streetGrid);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.Name = "ProblemAddressPanel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Címek szerkesztése";
			this.Load += new System.EventHandler(this.ProblemAddressPanel_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProblemAddressPanel_FormClosing);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.streetGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView streetGrid;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancBtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn Munkalap;
		private System.Windows.Forms.DataGridViewTextBoxColumn Cim;
		private System.Windows.Forms.DataGridViewTextBoxColumn Info;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Problematic;
	}
}