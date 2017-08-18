namespace TurmixReport
{
    partial class SetterPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetterPanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label37 = new System.Windows.Forms.Label();
            this.dbname = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.dbpass = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.dbuser = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.dbserver = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label37);
            this.panel1.Controls.Add(this.dbname);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.dbpass);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.dbuser);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.dbserver);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 229);
            this.panel1.TabIndex = 0;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(50, 57);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(80, 13);
            this.label37.TabIndex = 32;
            this.label37.Text = "Adatbázis neve";
            // 
            // dbname
            // 
            this.dbname.BackColor = System.Drawing.Color.White;
            this.dbname.Location = new System.Drawing.Point(146, 54);
            this.dbname.Name = "dbname";
            this.dbname.Size = new System.Drawing.Size(313, 20);
            this.dbname.TabIndex = 1;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(94, 137);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(36, 13);
            this.label34.TabIndex = 30;
            this.label34.Text = "Jelszó";
            // 
            // dbpass
            // 
            this.dbpass.Location = new System.Drawing.Point(146, 134);
            this.dbpass.Name = "dbpass";
            this.dbpass.Size = new System.Drawing.Size(137, 20);
            this.dbpass.TabIndex = 3;
            this.dbpass.UseSystemPasswordChar = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(43, 111);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(86, 13);
            this.label35.TabIndex = 28;
            this.label35.Text = "Felhasználói név";
            // 
            // dbuser
            // 
            this.dbuser.Location = new System.Drawing.Point(146, 108);
            this.dbuser.Name = "dbuser";
            this.dbuser.Size = new System.Drawing.Size(137, 20);
            this.dbuser.TabIndex = 2;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(31, 31);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(97, 13);
            this.label36.TabIndex = 26;
            this.label36.Text = "Szerver (gép neve)";
            // 
            // dbserver
            // 
            this.dbserver.BackColor = System.Drawing.Color.White;
            this.dbserver.Location = new System.Drawing.Point(146, 28);
            this.dbserver.Name = "dbserver";
            this.dbserver.Size = new System.Drawing.Size(313, 20);
            this.dbserver.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.okBtn);
            this.panel2.Controls.Add(this.cancelBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 229);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(509, 33);
            this.panel2.TabIndex = 1;
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.okBtn.Location = new System.Drawing.Point(355, 4);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 25);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.cancelBtn.Location = new System.Drawing.Point(430, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 25);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Mégse";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // SetterPanel
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(509, 262);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetterPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adatbázis beállítása";
            this.Load += new System.EventHandler(this.SetterPanel_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetterPanel_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox dbname;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox dbpass;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox dbuser;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox dbserver;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}