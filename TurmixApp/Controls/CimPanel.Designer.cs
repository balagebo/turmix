namespace TurmixLog
{
	partial class CimPanel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.select = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.info = new System.Windows.Forms.TextBox();
			this.cim = new System.Windows.Forms.TextBox();
			this.cimTip = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.panel1.Controls.Add(this.select);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(28, 49);
			this.panel1.TabIndex = 0;
			this.panel1.MouseLeave += new System.EventHandler(this.CimPanel_MouseLeave);
			this.panel1.Click += new System.EventHandler(this.info_Click);
			this.panel1.MouseEnter += new System.EventHandler(this.CimPanel_MouseEnter);
			// 
			// select
			// 
			this.select.AutoSize = true;
			this.select.Location = new System.Drawing.Point(10, 10);
			this.select.Name = "select";
			this.select.Size = new System.Drawing.Size(15, 14);
			this.select.TabIndex = 0;
			this.select.UseVisualStyleBackColor = true;
			this.select.CheckedChanged += new System.EventHandler(this.select_CheckedChanged);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.info);
			this.panel2.Controls.Add(this.cim);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(30, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(250, 49);
			this.panel2.TabIndex = 1;
			// 
			// info
			// 
			this.info.BackColor = System.Drawing.Color.White;
			this.info.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.info.Cursor = System.Windows.Forms.Cursors.Hand;
			this.info.Dock = System.Windows.Forms.DockStyle.Fill;
			this.info.Location = new System.Drawing.Point(0, 14);
			this.info.Margin = new System.Windows.Forms.Padding(5);
			this.info.Multiline = true;
			this.info.Name = "info";
			this.info.ReadOnly = true;
			this.info.Size = new System.Drawing.Size(250, 35);
			this.info.TabIndex = 3;
			this.info.MouseLeave += new System.EventHandler(this.CimPanel_MouseLeave);
			this.info.Click += new System.EventHandler(this.info_Click);
			this.info.MouseEnter += new System.EventHandler(this.CimPanel_MouseEnter);
			// 
			// cim
			// 
			this.cim.BackColor = System.Drawing.Color.White;
			this.cim.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cim.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cim.Dock = System.Windows.Forms.DockStyle.Top;
			this.cim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cim.Location = new System.Drawing.Point(0, 0);
			this.cim.Margin = new System.Windows.Forms.Padding(5);
			this.cim.Multiline = true;
			this.cim.Name = "cim";
			this.cim.ReadOnly = true;
			this.cim.Size = new System.Drawing.Size(250, 14);
			this.cim.TabIndex = 2;
			this.cim.Text = "Kékszőlő u 9 [10/10] - Csh : 8 soksoksoskosksoskoskossk";
			this.cim.MouseLeave += new System.EventHandler(this.CimPanel_MouseLeave);
			this.cim.Click += new System.EventHandler(this.info_Click);
			this.cim.MouseEnter += new System.EventHandler(this.CimPanel_MouseEnter);
			// 
			// cimTip
			// 
			this.cimTip.AutoPopDelay = 5000;
			this.cimTip.InitialDelay = 100;
			this.cimTip.ReshowDelay = 100;
			// 
			// CimPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "CimPanel";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Size = new System.Drawing.Size(282, 53);
			this.MouseLeave += new System.EventHandler(this.CimPanel_MouseLeave);
			this.MouseEnter += new System.EventHandler(this.CimPanel_MouseEnter);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox select;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox info;
		private System.Windows.Forms.TextBox cim;
		private System.Windows.Forms.ToolTip cimTip;

	}
}
