namespace TurmixLog
{
	partial class StaffPane
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
			this.seged = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.sofor = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cancBtn = new System.Windows.Forms.Button();
			this.okBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// seged
			// 
			this.seged.Location = new System.Drawing.Point(102, 49);
			this.seged.Name = "seged";
			this.seged.Size = new System.Drawing.Size(161, 20);
			this.seged.TabIndex = 34;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(21, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 33;
			this.label2.Text = "Segéd:";
			// 
			// sofor
			// 
			this.sofor.Location = new System.Drawing.Point(102, 23);
			this.sofor.Name = "sofor";
			this.sofor.Size = new System.Drawing.Size(161, 20);
			this.sofor.TabIndex = 32;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(21, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 31;
			this.label1.Text = "Sofőr:";
			// 
			// cancBtn
			// 
			this.cancBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancBtn.Location = new System.Drawing.Point(155, 85);
			this.cancBtn.Name = "cancBtn";
			this.cancBtn.Size = new System.Drawing.Size(75, 23);
			this.cancBtn.TabIndex = 36;
			this.cancBtn.Text = "Mégse";
			this.cancBtn.UseVisualStyleBackColor = true;
			// 
			// okBtn
			// 
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Location = new System.Drawing.Point(55, 85);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 35;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			// 
			// StaffPane
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::TurmixLog.Properties.Resources.back;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.CancelButton = this.cancBtn;
			this.ClientSize = new System.Drawing.Size(285, 121);
			this.Controls.Add(this.cancBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.seged);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.sofor);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "StaffPane";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Személyzet";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StaffPane_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox seged;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox sofor;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cancBtn;
		private System.Windows.Forms.Button okBtn;
	}
}