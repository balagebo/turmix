namespace TurmixBatch
{
    partial class DataForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancBtn = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.AutoCim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tm3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.okBtn);
            this.panel1.Controls.Add(this.cancBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 472);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(651, 43);
            this.panel1.TabIndex = 1;
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.okBtn.Location = new System.Drawing.Point(568, 8);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 27);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "Mehet!";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancBtn
            // 
            this.cancBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.cancBtn.Location = new System.Drawing.Point(8, 8);
            this.cancBtn.Name = "cancBtn";
            this.cancBtn.Size = new System.Drawing.Size(75, 27);
            this.cancBtn.TabIndex = 0;
            this.cancBtn.Text = "Mégse";
            this.cancBtn.UseVisualStyleBackColor = true;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AutoCim,
            this.Tm3});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(651, 472);
            this.dataGrid.TabIndex = 2;
            this.dataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellEndEdit);
            // 
            // AutoCim
            // 
            dataGridViewCellStyle2.NullValue = "0";
            this.AutoCim.DefaultCellStyle = dataGridViewCellStyle2;
            this.AutoCim.HeaderText = "Címek";
            this.AutoCim.Name = "AutoCim";
            this.AutoCim.ReadOnly = true;
            this.AutoCim.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Tm3
            // 
            this.Tm3.HeaderText = "Tényleges m3";
            this.Tm3.Name = "Tm3";
            this.Tm3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancBtn;
            this.ClientSize = new System.Drawing.Size(651, 515);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Előnézet";
            this.Load += new System.EventHandler(this.DataForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataForm_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancBtn;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutoCim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tm3;
    }
}