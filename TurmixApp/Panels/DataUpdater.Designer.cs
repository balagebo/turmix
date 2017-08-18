namespace TurmixLog
{
    partial class DataUpdater
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
            this.updateWorker = new System.ComponentModel.BackgroundWorker();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.cancBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Az adatok letöltése folyamatban van...";
            // 
            // updateWorker
            // 
            this.updateWorker.WorkerSupportsCancellation = true;
            this.updateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateWorker_DoWork);
            this.updateWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.updateWorker_RunWorkerCompleted);
            this.updateWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.updateWorker_ProgressChanged);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 34);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(251, 23);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progress.TabIndex = 1;
            // 
            // cancBtn
            // 
            this.cancBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancBtn.Location = new System.Drawing.Point(102, 63);
            this.cancBtn.Name = "cancBtn";
            this.cancBtn.Size = new System.Drawing.Size(75, 23);
            this.cancBtn.TabIndex = 2;
            this.cancBtn.Text = "Mégse";
            this.cancBtn.UseVisualStyleBackColor = true;
            this.cancBtn.Click += new System.EventHandler(this.cancBtn_Click);
            // 
            // DataUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TurmixLog.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(275, 91);
            this.Controls.Add(this.cancBtn);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DataUpdater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adatok letöltése";
            this.Shown += new System.EventHandler(this.DataUpdater_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataUpdater_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
		private System.ComponentModel.BackgroundWorker updateWorker;
		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.Button cancBtn;
    }
}