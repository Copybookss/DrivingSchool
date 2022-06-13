namespace Driving.Auth
{
    partial class Frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewAcc = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tW1 = new System.Windows.Forms.TextBox();
            this.tW2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnInst7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(2)))), ((int)(((byte)(93)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 450);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 24F);
            this.label1.Location = new System.Drawing.Point(80, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome";
            // 
            // btnNewAcc
            // 
            this.btnNewAcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(2)))), ((int)(((byte)(93)))));
            this.btnNewAcc.Font = new System.Drawing.Font("Britannic Bold", 10.8F);
            this.btnNewAcc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewAcc.Location = new System.Drawing.Point(372, 384);
            this.btnNewAcc.Name = "btnNewAcc";
            this.btnNewAcc.Size = new System.Drawing.Size(128, 40);
            this.btnNewAcc.TabIndex = 5;
            this.btnNewAcc.Text = "New Accaunt";
            this.btnNewAcc.UseVisualStyleBackColor = false;
            this.btnNewAcc.Click += new System.EventHandler(this.btnNewAcc_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(2)))), ((int)(((byte)(93)))));
            this.btnLogin.Font = new System.Drawing.Font("Britannic Bold", 10.8F);
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.Location = new System.Drawing.Point(530, 384);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(125, 40);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tW1
            // 
            this.tW1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tW1.BackColor = System.Drawing.SystemColors.GrayText;
            this.tW1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tW1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tW1.ForeColor = System.Drawing.Color.GhostWhite;
            this.tW1.Location = new System.Drawing.Point(205, 231);
            this.tW1.Name = "tW1";
            this.tW1.Size = new System.Drawing.Size(235, 21);
            this.tW1.TabIndex = 7;
            this.tW1.Text = "Username";
            this.tW1.Click += new System.EventHandler(this.tW1_Click);
            this.tW1.TextChanged += new System.EventHandler(this.tW1_TextChanged);
            // 
            // tW2
            // 
            this.tW2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tW2.BackColor = System.Drawing.SystemColors.GrayText;
            this.tW2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tW2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tW2.ForeColor = System.Drawing.Color.GhostWhite;
            this.tW2.Location = new System.Drawing.Point(205, 283);
            this.tW2.Name = "tW2";
            this.tW2.Size = new System.Drawing.Size(235, 21);
            this.tW2.TabIndex = 8;
            this.tW2.Text = "Password";
            this.tW2.Click += new System.EventHandler(this.tW2_Click);
            this.tW2.TextChanged += new System.EventHandler(this.tW2_TextChanged);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Britannic Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(153, 276);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 30);
            this.button3.TabIndex = 10;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Britannic Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(153, 224);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 30);
            this.button5.TabIndex = 9;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(79, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(2)))), ((int)(((byte)(93)))));
            this.panel2.Controls.Add(this.btnInst7);
            this.panel2.Location = new System.Drawing.Point(671, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(29, 25);
            this.panel2.TabIndex = 11;
            // 
            // btnInst7
            // 
            this.btnInst7.FlatAppearance.BorderSize = 0;
            this.btnInst7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInst7.Font = new System.Drawing.Font("Britannic Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInst7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInst7.Image = ((System.Drawing.Image)(resources.GetObject("btnInst7.Image")));
            this.btnInst7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInst7.Location = new System.Drawing.Point(-3, 0);
            this.btnInst7.Name = "btnInst7";
            this.btnInst7.Size = new System.Drawing.Size(29, 27);
            this.btnInst7.TabIndex = 8;
            this.btnInst7.UseVisualStyleBackColor = true;
            this.btnInst7.Click += new System.EventHandler(this.btnInst7_Click);
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tW2);
            this.Controls.Add(this.tW1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnNewAcc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Login";
            this.Text = "Frm_Login";
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewAcc;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tW1;
        private System.Windows.Forms.TextBox tW2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnInst7;
    }
}