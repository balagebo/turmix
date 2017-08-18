namespace TurmixBatch
{
    partial class DataProgress
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
            this.dataWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 35);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(268, 23);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progress.TabIndex = 0;
            // 
            // cancBtn
            // 
            this.cancBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancBtn.Location = new System.Drawing.Point(103, 64);
            this.cancBtn.Name = "cancBtn";
            this.cancBtn.Size = new System.Drawing.Size(75, 23);
            this.cancBtn.TabIndex = 1;
            this.cancBtn.Text = "Mégse";
            this.cancBtn.UseVisualStyleBackColor = true;
            this.cancBtn.Click += new System.EventHandler(this.cancBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "A feldolgozás folyamatban van...";
            // 
            // dataWorker
            // 
            this.dataWorker.WorkerReportsProgress = true;
            this.dataWorker.WorkerSupportsCancellation = true;
            this.dataWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dataWorker_DoWork);
            this.dataWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dataWorker_RunWorkerCompleted);
            this.dataWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.dataWorker_ProgressChanged);
            // 
            // DataProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TurmixBatch.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cancBtn;
            this.ClientSize = new System.Drawing.Size(292, 100);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancBtn);
            this.Controls.Add(this.progress);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DataProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adatok feldolgozása";
            this.Shown += new System.EventHandler(this.DataProgress_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.Button cancBtn;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.BackgroundWorker dataWorker;
	}
}