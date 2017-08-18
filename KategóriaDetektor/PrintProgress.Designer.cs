namespace KategóriaDetektor
{
	partial class ConvertProgress
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
            this.progress = new System.Windows.Forms.ProgressBar();
            this.cancBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.downloadWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 45);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(268, 23);
            this.progress.TabIndex = 0;
            // 
            // cancBtn
            // 
            this.cancBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancBtn.Location = new System.Drawing.Point(103, 74);
            this.cancBtn.Name = "cancBtn";
            this.cancBtn.Size = new System.Drawing.Size(75, 23);
            this.cancBtn.TabIndex = 1;
            this.cancBtn.Text = "Mégse";
            this.cancBtn.UseVisualStyleBackColor = true;
            this.cancBtn.Click += new System.EventHandler(this.cancBtn_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "A munkalapok adatbázisba töltése folyamatban van. A művelet percekig is eltarthat" +
                "...";
            // 
            // downloadWorker
            // 
            this.downloadWorker.WorkerReportsProgress = true;
            this.downloadWorker.WorkerSupportsCancellation = true;
            this.downloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.downloadWorker_DoWork);
            this.downloadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.downloadWorker_RunWorkerCompleted);
            this.downloadWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.downloadWorker_ProgressChanged);
            // 
            // ConvertProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KategóriaDetektor.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cancBtn;
            this.ClientSize = new System.Drawing.Size(292, 100);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancBtn);
            this.Controls.Add(this.progress);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConvertProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Munkalapok konvertálása";
            this.Shown += new System.EventHandler(this.PrintProgress_Shown);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.Button cancBtn;
		private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker downloadWorker;
	}
}