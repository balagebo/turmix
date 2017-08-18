namespace TurmixLog
{
	partial class MissingData
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
			this.errorbox = new System.Windows.Forms.ListBox();
			this.yesBtn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(339, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "A következő címekhez nincs jármű rendelve, vagy a hozzárendelés hibás.";
			// 
			// errorbox
			// 
			this.errorbox.FormattingEnabled = true;
			this.errorbox.HorizontalScrollbar = true;
			this.errorbox.Location = new System.Drawing.Point(6, 43);
			this.errorbox.Name = "errorbox";
			this.errorbox.Size = new System.Drawing.Size(401, 199);
			this.errorbox.TabIndex = 1;
			// 
			// yesBtn
			// 
			this.yesBtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.yesBtn.Location = new System.Drawing.Point(332, 248);
			this.yesBtn.Name = "yesBtn";
			this.yesBtn.Size = new System.Drawing.Size(75, 23);
			this.yesBtn.TabIndex = 3;
			this.yesBtn.Text = "OK";
			this.yesBtn.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(3, 248);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "label2";
			// 
			// MissingData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::TurmixLog.Properties.Resources.back;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(419, 282);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.yesBtn);
			this.Controls.Add(this.errorbox);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MissingData";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Hiányzó hozzárendelések";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox errorbox;
		private System.Windows.Forms.Button yesBtn;
		private System.Windows.Forms.Label label2;
	}
}