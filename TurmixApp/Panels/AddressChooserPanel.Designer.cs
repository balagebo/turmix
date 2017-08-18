namespace TurmixLog
{
	partial class MultiChoice
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
			this.cancelBtn = new System.Windows.Forms.Button();
			this.cimek = new TurmixLog.CimGyujto();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackgroundImage = global::TurmixLog.Properties.Resources.back;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.okBtn);
			this.panel1.Controls.Add(this.cancelBtn);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(514, 30);
			this.panel1.TabIndex = 1;
			// 
			// okBtn
			// 
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.okBtn.Location = new System.Drawing.Point(361, 3);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 24);
			this.okBtn.TabIndex = 0;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.cancelBtn.Location = new System.Drawing.Point(436, 3);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 24);
			this.cancelBtn.TabIndex = 1;
			this.cancelBtn.Text = "Mégse";
			this.cancelBtn.UseVisualStyleBackColor = true;
			// 
			// cimek
			// 
			this.cimek.AutoScroll = true;
			this.cimek.BackColor = System.Drawing.SystemColors.ControlDark;
			this.cimek.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cimek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cimek.Location = new System.Drawing.Point(0, 30);
			this.cimek.Name = "cimek";
			this.cimek.Padding = new System.Windows.Forms.Padding(3);
			this.cimek.Size = new System.Drawing.Size(514, 283);
			this.cimek.TabIndex = 2;
			// 
			// MultiChoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(514, 313);
			this.Controls.Add(this.cimek);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.Name = "MultiChoice";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Válassza ki a címeket";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okBtn;
		private TurmixLog.CimGyujto cimek;

	}
}