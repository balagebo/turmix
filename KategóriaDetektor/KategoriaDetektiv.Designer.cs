namespace KategóriaDetektor
{
    partial class KategoriaDetektiv
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
            this.isWeb = new System.Windows.Forms.RadioButton();
            this.setBtn = new System.Windows.Forms.Button();
            this.errorGrid = new System.Windows.Forms.DataGridView();
            this.Fkod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hiba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goBtn = new System.Windows.Forms.Button();
            this.isXls = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.locationTx = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.startfrom = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errorGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startfrom)).BeginInit();
            this.SuspendLayout();
            // 
            // isWeb
            // 
            this.isWeb.AutoSize = true;
            this.isWeb.Checked = true;
            this.isWeb.Location = new System.Drawing.Point(25, 14);
            this.isWeb.Name = "isWeb";
            this.isWeb.Size = new System.Drawing.Size(48, 17);
            this.isWeb.TabIndex = 0;
            this.isWeb.TabStop = true;
            this.isWeb.Text = "Web";
            this.isWeb.UseVisualStyleBackColor = true;
            // 
            // setBtn
            // 
            this.setBtn.Location = new System.Drawing.Point(307, 41);
            this.setBtn.Name = "setBtn";
            this.setBtn.Size = new System.Drawing.Size(75, 23);
            this.setBtn.TabIndex = 5;
            this.setBtn.Text = "Beállítások";
            this.setBtn.UseVisualStyleBackColor = true;
            this.setBtn.Click += new System.EventHandler(this.setBtn_Click);
            // 
            // errorGrid
            // 
            this.errorGrid.AllowUserToAddRows = false;
            this.errorGrid.AllowUserToDeleteRows = false;
            this.errorGrid.AllowUserToResizeRows = false;
            this.errorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fkod,
            this.Hiba});
            this.errorGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorGrid.Location = new System.Drawing.Point(0, 106);
            this.errorGrid.Name = "errorGrid";
            this.errorGrid.ReadOnly = true;
            this.errorGrid.RowHeadersVisible = false;
            this.errorGrid.Size = new System.Drawing.Size(388, 279);
            this.errorGrid.TabIndex = 5;
            // 
            // Fkod
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Fkod.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fkod.HeaderText = "F.kód";
            this.Fkod.Name = "Fkod";
            this.Fkod.ReadOnly = true;
            // 
            // Hiba
            // 
            this.Hiba.HeaderText = "Hiba";
            this.Hiba.Name = "Hiba";
            this.Hiba.ReadOnly = true;
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(226, 41);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 23);
            this.goBtn.TabIndex = 3;
            this.goBtn.Text = "Mehet!";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // isXls
            // 
            this.isXls.AutoSize = true;
            this.isXls.Location = new System.Drawing.Point(112, 14);
            this.isXls.Name = "isXls";
            this.isXls.Size = new System.Drawing.Size(75, 17);
            this.isXls.TabIndex = 1;
            this.isXls.Text = "XLS (CSV)";
            this.isXls.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.startfrom);
            this.groupBox1.Controls.Add(this.locationTx);
            this.groupBox1.Controls.Add(this.browseBtn);
            this.groupBox1.Controls.Add(this.setBtn);
            this.groupBox1.Controls.Add(this.goBtn);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 106);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adatok";
            // 
            // locationTx
            // 
            this.locationTx.Location = new System.Drawing.Point(21, 19);
            this.locationTx.Name = "locationTx";
            this.locationTx.Size = new System.Drawing.Size(311, 20);
            this.locationTx.TabIndex = 6;
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(338, 17);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(25, 23);
            this.browseBtn.TabIndex = 7;
            this.browseBtn.Text = "...";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.isXls);
            this.groupBox2.Controls.Add(this.isWeb);
            this.groupBox2.Location = new System.Drawing.Point(21, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 37);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adatok típusa";
            // 
            // startfrom
            // 
            this.startfrom.Location = new System.Drawing.Point(21, 44);
            this.startfrom.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.startfrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startfrom.Name = "startfrom";
            this.startfrom.Size = new System.Drawing.Size(120, 20);
            this.startfrom.TabIndex = 2;
            this.startfrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // KategoriaDetektiv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 385);
            this.Controls.Add(this.errorGrid);
            this.Controls.Add(this.groupBox1);
            this.Name = "KategoriaDetektiv";
            this.Text = "Kapacitás Detektív";
            ((System.ComponentModel.ISupportInitialize)(this.errorGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startfrom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton isWeb;
        private System.Windows.Forms.Button setBtn;
        private System.Windows.Forms.DataGridView errorGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fkod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hiba;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.RadioButton isXls;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox locationTx;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.NumericUpDown startfrom;
    }
}

