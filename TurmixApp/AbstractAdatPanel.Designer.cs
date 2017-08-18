namespace TurmixLog
{
	partial class AbstarctAdatPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbstarctAdatPanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchTx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancBtn = new System.Windows.Forms.Button();
            this.autoGrid = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.okBtn);
            this.panel1.Controls.Add(this.cancBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(545, 35);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.searchTx);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 25);
            this.panel2.TabIndex = 2;
            // 
            // searchTx
            // 
            this.searchTx.Location = new System.Drawing.Point(66, 2);
            this.searchTx.Name = "searchTx";
            this.searchTx.Size = new System.Drawing.Size(175, 20);
            this.searchTx.TabIndex = 1;
            this.searchTx.TextChanged += new System.EventHandler(this.searchTx_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Keresés:";
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.okBtn.Location = new System.Drawing.Point(390, 5);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 25);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancBtn
            // 
            this.cancBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.cancBtn.Location = new System.Drawing.Point(465, 5);
            this.cancBtn.Name = "cancBtn";
            this.cancBtn.Size = new System.Drawing.Size(75, 25);
            this.cancBtn.TabIndex = 0;
            this.cancBtn.Text = "Mégse";
            this.cancBtn.UseVisualStyleBackColor = true;
            // 
            // autoGrid
            // 
            this.autoGrid.AllowUserToResizeRows = false;
            this.autoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.autoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoGrid.Location = new System.Drawing.Point(0, 35);
            this.autoGrid.Name = "autoGrid";
            this.autoGrid.Size = new System.Drawing.Size(545, 317);
            this.autoGrid.TabIndex = 1;
            this.autoGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.autoGrid_CellEndEdit);
            this.autoGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.autoGrid_DataError);
            // 
            // AbstarctAdatPanel
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TurmixLog.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cancBtn;
            this.ClientSize = new System.Drawing.Size(545, 352);
            this.Controls.Add(this.autoGrid);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AbstarctAdatPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Járművek adattáblája";
            this.Load += new System.EventHandler(this.AbstarctAdatPanel_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoAdatPanel_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoGrid)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		protected System.Windows.Forms.Panel panel1;
		protected System.Windows.Forms.Button okBtn;
		protected System.Windows.Forms.Button cancBtn;
        protected System.Windows.Forms.DataGridView autoGrid;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox searchTx;
        private System.Windows.Forms.Panel panel2;

	}
}