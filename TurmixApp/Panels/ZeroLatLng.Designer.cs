namespace TurmixLog
{
    partial class ZeroLatLng
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
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.csoGrid = new TurmixLog.CarGrid();
            this.Cim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Megjegyzes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Koord = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.csoGrid)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(658, 50);
            this.panel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(571, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "A következő címek nem jeleníthetők meg a térképen. Itt lehetőség van a cím beállí" +
                "tására.";
            // 
            // csoGrid
            // 
            this.csoGrid.AllowUserToAddRows = false;
            this.csoGrid.AllowUserToDeleteRows = false;
            this.csoGrid.AllowUserToResizeRows = false;
            this.csoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.csoGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cim,
            this.Megjegyzes,
            this.Lat,
            this.Lng,
            this.Koord});
            this.csoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csoGrid.Location = new System.Drawing.Point(0, 50);
            this.csoGrid.Name = "csoGrid";
            this.csoGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.csoGrid.Size = new System.Drawing.Size(658, 272);
            this.csoGrid.TabIndex = 4;
            this.csoGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.csoGrid_CellFormatting);
            this.csoGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.csoGrid_CellEndEdit);
            this.csoGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.csoGrid_DataError);
            this.csoGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.csoGrid_CellContentClick);
            // 
            // Cim
            // 
            this.Cim.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cim.HeaderText = "Cím";
            this.Cim.Name = "Cim";
            this.Cim.ReadOnly = true;
            this.Cim.Width = 51;
            // 
            // Megjegyzes
            // 
            this.Megjegyzes.HeaderText = "Megjegyzés";
            this.Megjegyzes.Name = "Megjegyzes";
            this.Megjegyzes.ReadOnly = true;
            // 
            // Lat
            // 
            this.Lat.HeaderText = "Szélesség";
            this.Lat.Name = "Lat";
            this.Lat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Lng
            // 
            this.Lng.HeaderText = "Hosszúság";
            this.Lng.Name = "Lng";
            this.Lng.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Koord
            // 
            this.Koord.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Koord.HeaderText = "+";
            this.Koord.Name = "Koord";
            this.Koord.Text = "...";
            this.Koord.ToolTipText = "Koordináták megadása";
            this.Koord.UseColumnTextForButtonValue = true;
            this.Koord.Width = 5;
            // 
            // ZeroLatLng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 322);
            this.Controls.Add(this.csoGrid);
            this.Controls.Add(this.panel1);
            this.Name = "ZeroLatLng";
            this.Text = "Nem megjeleníthető címek";
            this.Load += new System.EventHandler(this.ZeroLatLng_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZeroLatLng_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.csoGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Megjegyzes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lng;
        private System.Windows.Forms.DataGridViewButtonColumn Koord;
        private CarGrid csoGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
    }
}