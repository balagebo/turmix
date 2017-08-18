namespace TurmixLog
{
	partial class NapszakCorrector
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
			this.okBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.info = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.napszak = new System.Windows.Forms.ComboBox();
			this.cimBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// okBtn
			// 
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Location = new System.Drawing.Point(122, 279);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 37;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(273, 31);
			this.label1.TabIndex = 39;
			this.label1.Text = "Az adatbázisban levő napszak hibás! Kérem válaszza ki a megfelelő napszakot!";
			// 
			// info
			// 
			this.info.Location = new System.Drawing.Point(12, 113);
			this.info.Multiline = true;
			this.info.Name = "info";
			this.info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.info.Size = new System.Drawing.Size(299, 92);
			this.info.TabIndex = 41;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(12, 218);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 13);
			this.label2.TabIndex = 42;
			this.label2.Text = "A kiválasztott napszak:";
			// 
			// napszak
			// 
			this.napszak.FormattingEnabled = true;
			this.napszak.Items.AddRange(new object[] {
            "Első fuvar",
            "Délelőtt",
            "Délután"});
			this.napszak.Location = new System.Drawing.Point(15, 234);
			this.napszak.Name = "napszak";
			this.napszak.Size = new System.Drawing.Size(299, 21);
			this.napszak.TabIndex = 43;
			this.napszak.Text = "Első fuvar";
			// 
			// cimBox
			// 
			this.cimBox.Location = new System.Drawing.Point(12, 55);
			this.cimBox.Multiline = true;
			this.cimBox.Name = "cimBox";
			this.cimBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.cimBox.Size = new System.Drawing.Size(299, 35);
			this.cimBox.TabIndex = 44;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(12, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 45;
			this.label3.Text = "Cím:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Location = new System.Drawing.Point(12, 97);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 13);
			this.label4.TabIndex = 46;
			this.label4.Text = "Info:";
			// 
			// NapszakCorrector
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::TurmixLog.Properties.Resources.back;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(325, 314);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cimBox);
			this.Controls.Add(this.napszak);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.info);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.okBtn);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NapszakCorrector";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Hibás napszak";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NapszakCorrector_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox info;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox napszak;
		private System.Windows.Forms.TextBox cimBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}