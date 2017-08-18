namespace TurmixReport
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel4 = new System.Windows.Forms.Panel();
            this.atlagFogyEgy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.setBtn = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.atlagFogyEgy);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 59);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(308, 253);
            this.panel4.TabIndex = 4;
            // 
            // atlagFogyEgy
            // 
            this.atlagFogyEgy.BackColor = System.Drawing.Color.White;
            this.atlagFogyEgy.Dock = System.Windows.Forms.DockStyle.Top;
            this.atlagFogyEgy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.atlagFogyEgy.Image = global::TurmixReport.Properties.Resources.fogyido;
            this.atlagFogyEgy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.atlagFogyEgy.Location = new System.Drawing.Point(5, 5);
            this.atlagFogyEgy.Name = "atlagFogyEgy";
            this.atlagFogyEgy.Size = new System.Drawing.Size(298, 64);
            this.atlagFogyEgy.TabIndex = 0;
            this.atlagFogyEgy.Text = "Időszakos átlagfogyasztás";
            this.atlagFogyEgy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.atlagFogyEgy.UseVisualStyleBackColor = false;
            this.atlagFogyEgy.Click += new System.EventHandler(this.atlagFogyEgy_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "A kezdéshez kérem válasszon egy feladatot az alábbiak közül!";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 59);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.setBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 312);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 31);
            this.panel2.TabIndex = 5;
            // 
            // setBtn
            // 
            this.setBtn.Location = new System.Drawing.Point(228, 5);
            this.setBtn.Name = "setBtn";
            this.setBtn.Size = new System.Drawing.Size(75, 23);
            this.setBtn.TabIndex = 0;
            this.setBtn.Text = "Beállítások";
            this.setBtn.UseVisualStyleBackColor = true;
            this.setBtn.Click += new System.EventHandler(this.setBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TurmixReport.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(308, 343);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turmix Riporter Modul";
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button atlagFogyEgy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button setBtn;



    }
}

