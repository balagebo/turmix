namespace TurmixReport
{
    partial class FogyasztasPanel
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
            this.kezdo = new System.Windows.Forms.DateTimePicker();
            this.veg = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kezdo
            // 
            this.kezdo.Location = new System.Drawing.Point(7, 20);
            this.kezdo.Name = "kezdo";
            this.kezdo.Size = new System.Drawing.Size(200, 20);
            this.kezdo.TabIndex = 0;
            // 
            // veg
            // 
            this.veg.Location = new System.Drawing.Point(7, 74);
            this.veg.Name = "veg";
            this.veg.Size = new System.Drawing.Size(200, 20);
            this.veg.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mettől";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Meddig";
            // 
            // FogyasztasPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.veg);
            this.Controls.Add(this.kezdo);
            this.Name = "FogyasztasPanel";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(221, 127);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker kezdo;
        private System.Windows.Forms.DateTimePicker veg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
