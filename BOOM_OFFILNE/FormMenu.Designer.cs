namespace BOOM_OFFILNE
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.pnTitle = new System.Windows.Forms.Panel();
            this.picMinus = new System.Windows.Forms.PictureBox();
            this.picMultiply = new System.Windows.Forms.PictureBox();
            this.btnAboutUs = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.frmMenu = new System.Windows.Forms.Panel();
            this.pnAboutUs = new System.Windows.Forms.Panel();
            this.btnAboutUsMenu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMultiply)).BeginInit();
            this.frmMenu.SuspendLayout();
            this.pnAboutUs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnTitle.Controls.Add(this.picMinus);
            this.pnTitle.Controls.Add(this.picMultiply);
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(1067, 38);
            this.pnTitle.TabIndex = 27;
            this.pnTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTitle_MouseDown);
            this.pnTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnTitle_MouseMove);
            // 
            // picMinus
            // 
            this.picMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinus.Image = ((System.Drawing.Image)(resources.GetObject("picMinus.Image")));
            this.picMinus.Location = new System.Drawing.Point(1004, 4);
            this.picMinus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMinus.Name = "picMinus";
            this.picMinus.Size = new System.Drawing.Size(27, 24);
            this.picMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinus.TabIndex = 2;
            this.picMinus.TabStop = false;
            this.picMinus.Click += new System.EventHandler(this.picMinus_Click);
            this.picMinus.MouseEnter += new System.EventHandler(this.picMinus_MouseEnter);
            this.picMinus.MouseLeave += new System.EventHandler(this.picMinus_MouseLeave);
            // 
            // picMultiply
            // 
            this.picMultiply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMultiply.Image = ((System.Drawing.Image)(resources.GetObject("picMultiply.Image")));
            this.picMultiply.Location = new System.Drawing.Point(1037, 4);
            this.picMultiply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMultiply.Name = "picMultiply";
            this.picMultiply.Size = new System.Drawing.Size(27, 24);
            this.picMultiply.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMultiply.TabIndex = 0;
            this.picMultiply.TabStop = false;
            this.picMultiply.Click += new System.EventHandler(this.picMultiply_Click);
            this.picMultiply.MouseEnter += new System.EventHandler(this.picMultiply_MouseEnter);
            this.picMultiply.MouseLeave += new System.EventHandler(this.picMultiply_MouseLeave);
            // 
            // btnAboutUs
            // 
            this.btnAboutUs.BackColor = System.Drawing.Color.CadetBlue;
            this.btnAboutUs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAboutUs.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAboutUs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnAboutUs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAboutUs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAboutUs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAboutUs.ForeColor = System.Drawing.Color.Black;
            this.btnAboutUs.Location = new System.Drawing.Point(59, 460);
            this.btnAboutUs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAboutUs.Name = "btnAboutUs";
            this.btnAboutUs.Size = new System.Drawing.Size(248, 63);
            this.btnAboutUs.TabIndex = 3;
            this.btnAboutUs.TabStop = false;
            this.btnAboutUs.Text = "ABOUT US";
            this.btnAboutUs.UseVisualStyleBackColor = false;
            this.btnAboutUs.Click += new System.EventHandler(this.btnAboutUs_Click_1);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.CadetBlue;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(807, 460);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(248, 63);
            this.btnExit.TabIndex = 4;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmMenu
            // 
            this.frmMenu.BackColor = System.Drawing.Color.White;
            this.frmMenu.Controls.Add(this.pnAboutUs);
            this.frmMenu.Controls.Add(this.pnTitle);
            this.frmMenu.Controls.Add(this.btnPlay);
            this.frmMenu.Controls.Add(this.btnExit);
            this.frmMenu.Controls.Add(this.btnAboutUs);
            this.frmMenu.Controls.Add(this.pictureBox6);
            this.frmMenu.Location = new System.Drawing.Point(0, 0);
            this.frmMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.frmMenu.Name = "frmMenu";
            this.frmMenu.Size = new System.Drawing.Size(1067, 576);
            this.frmMenu.TabIndex = 28;
            // 
            // pnAboutUs
            // 
            this.pnAboutUs.BackColor = System.Drawing.Color.DarkCyan;
            this.pnAboutUs.Controls.Add(this.btnAboutUsMenu);
            this.pnAboutUs.Controls.Add(this.label3);
            this.pnAboutUs.Controls.Add(this.label4);
            this.pnAboutUs.Location = new System.Drawing.Point(1244, 32);
            this.pnAboutUs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnAboutUs.Name = "pnAboutUs";
            this.pnAboutUs.Size = new System.Drawing.Size(1067, 543);
            this.pnAboutUs.TabIndex = 24;
            // 
            // btnAboutUsMenu
            // 
            this.btnAboutUsMenu.BackColor = System.Drawing.Color.LightGray;
            this.btnAboutUsMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAboutUsMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAboutUsMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnAboutUsMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAboutUsMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAboutUsMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAboutUsMenu.ForeColor = System.Drawing.Color.Black;
            this.btnAboutUsMenu.Location = new System.Drawing.Point(438, 434);
            this.btnAboutUsMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAboutUsMenu.Name = "btnAboutUsMenu";
            this.btnAboutUsMenu.Size = new System.Drawing.Size(132, 45);
            this.btnAboutUsMenu.TabIndex = 25;
            this.btnAboutUsMenu.TabStop = false;
            this.btnAboutUsMenu.Text = "Menu";
            this.btnAboutUsMenu.UseVisualStyleBackColor = false;
            this.btnAboutUsMenu.Click += new System.EventHandler(this.btnAboutUsMenu_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Elephant", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Linen;
            this.label3.Location = new System.Drawing.Point(255, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(519, 274);
            this.label3.TabIndex = 1;
            this.label3.Text = "   Game được thành lập bởi :\r\n\r\n          Phạm Văn Bảo An\r\n\r\n             Phạm Gi" +
    "a Huy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(428, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 37);
            this.label4.TabIndex = 0;
            this.label4.Text = "About Us";
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.CadetBlue;
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.Color.Black;
            this.btnPlay.Location = new System.Drawing.Point(428, 448);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(248, 63);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.TabStop = false;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::BOOM_OFFILNE.Properties.Resources.sontinh;
            this.pictureBox6.Location = new System.Drawing.Point(0, 33);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(1067, 543);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 26;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1067, 576);
            this.Controls.Add(this.frmMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMenu";
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMultiply)).EndInit();
            this.frmMenu.ResumeLayout(false);
            this.pnAboutUs.ResumeLayout(false);
            this.pnAboutUs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.PictureBox picMinus;
        private System.Windows.Forms.PictureBox picMultiply;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button btnAboutUs;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Panel frmMenu;
        private System.Windows.Forms.Panel pnAboutUs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAboutUsMenu;
    }
}