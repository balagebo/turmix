namespace TurmixLog
{
	partial class MunkalapSelector
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
			this.lista = new System.Windows.Forms.TreeView();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.okBtn = new System.Windows.Forms.Button();
			this.nonebtn = new System.Windows.Forms.Button();
			this.allbtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lista
			// 
			this.lista.CheckBoxes = true;
			this.lista.Dock = System.Windows.Forms.DockStyle.Top;
			this.lista.Location = new System.Drawing.Point(0, 0);
			this.lista.Name = "lista";
			this.lista.Size = new System.Drawing.Size(528, 343);
			this.lista.TabIndex = 0;
			this.lista.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.lista_AfterCheck);
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(441, 349);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 3;
			this.cancelBtn.Text = "Mégse";
			this.cancelBtn.UseVisualStyleBackColor = true;
			// 
			// okBtn
			// 
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Location = new System.Drawing.Point(351, 349);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 2;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			// 
			// nonebtn
			// 
			this.nonebtn.Location = new System.Drawing.Point(102, 349);
			this.nonebtn.Name = "nonebtn";
			this.nonebtn.Size = new System.Drawing.Size(75, 23);
			this.nonebtn.TabIndex = 5;
			this.nonebtn.Text = "Semelyik";
			this.nonebtn.UseVisualStyleBackColor = true;
			this.nonebtn.Click += new System.EventHandler(this.nonebtn_Click);
			// 
			// allbtn
			// 
			this.allbtn.Location = new System.Drawing.Point(12, 349);
			this.allbtn.Name = "allbtn";
			this.allbtn.Size = new System.Drawing.Size(75, 23);
			this.allbtn.TabIndex = 4;
			this.allbtn.Text = "Mind";
			this.allbtn.UseVisualStyleBackColor = true;
			this.allbtn.Click += new System.EventHandler(this.allbtn_Click);
			// 
			// MunkalapSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::TurmixLog.Properties.Resources.back;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(528, 381);
			this.Controls.Add(this.nonebtn);
			this.Controls.Add(this.allbtn);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.lista);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MunkalapSelector";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Munkalapok kiválasztása";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MunkalapSelector_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView lista;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button nonebtn;
		private System.Windows.Forms.Button allbtn;
	}
}