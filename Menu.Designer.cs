namespace SpaceShooterGame
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.space_shooter_title = new System.Windows.Forms.PictureBox();
            this.play_pic = new System.Windows.Forms.PictureBox();
            this.pic_records = new System.Windows.Forms.PictureBox();
            this.about_pic = new System.Windows.Forms.PictureBox();
            this.pic_exit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.space_shooter_title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.play_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_records)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.about_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_exit)).BeginInit();
            this.SuspendLayout();
            // 
            // space_shooter_title
            // 
            this.space_shooter_title.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("space_shooter_title.BackgroundImage")));
            this.space_shooter_title.ErrorImage = ((System.Drawing.Image)(resources.GetObject("space_shooter_title.ErrorImage")));
            this.space_shooter_title.Image = ((System.Drawing.Image)(resources.GetObject("space_shooter_title.Image")));
            this.space_shooter_title.Location = new System.Drawing.Point(23, 32);
            this.space_shooter_title.Name = "space_shooter_title";
            this.space_shooter_title.Size = new System.Drawing.Size(615, 191);
            this.space_shooter_title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.space_shooter_title.TabIndex = 0;
            this.space_shooter_title.TabStop = false;
            // 
            // play_pic
            // 
            this.play_pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.play_pic.Image = ((System.Drawing.Image)(resources.GetObject("play_pic.Image")));
            this.play_pic.Location = new System.Drawing.Point(159, 263);
            this.play_pic.Name = "play_pic";
            this.play_pic.Size = new System.Drawing.Size(350, 60);
            this.play_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.play_pic.TabIndex = 1;
            this.play_pic.TabStop = false;
            this.play_pic.Click += new System.EventHandler(this.play_pic_Click);
            this.play_pic.MouseEnter += new System.EventHandler(this.play_pic_MouseEnter);
            this.play_pic.MouseLeave += new System.EventHandler(this.play_pic_MouseLeave);
            // 
            // pic_records
            // 
            this.pic_records.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_records.Image = ((System.Drawing.Image)(resources.GetObject("pic_records.Image")));
            this.pic_records.Location = new System.Drawing.Point(159, 361);
            this.pic_records.Name = "pic_records";
            this.pic_records.Size = new System.Drawing.Size(350, 60);
            this.pic_records.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_records.TabIndex = 2;
            this.pic_records.TabStop = false;
            this.pic_records.MouseEnter += new System.EventHandler(this.pic_records_MouseEnter);
            this.pic_records.MouseLeave += new System.EventHandler(this.pic_records_MouseLeave);
            // 
            // about_pic
            // 
            this.about_pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.about_pic.Image = ((System.Drawing.Image)(resources.GetObject("about_pic.Image")));
            this.about_pic.Location = new System.Drawing.Point(159, 461);
            this.about_pic.Name = "about_pic";
            this.about_pic.Size = new System.Drawing.Size(350, 60);
            this.about_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.about_pic.TabIndex = 3;
            this.about_pic.TabStop = false;
            this.about_pic.MouseEnter += new System.EventHandler(this.about_pic_MouseEnter);
            this.about_pic.MouseLeave += new System.EventHandler(this.about_pic_MouseLeave);
            // 
            // pic_exit
            // 
            this.pic_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_exit.Image = ((System.Drawing.Image)(resources.GetObject("pic_exit.Image")));
            this.pic_exit.Location = new System.Drawing.Point(159, 560);
            this.pic_exit.Name = "pic_exit";
            this.pic_exit.Size = new System.Drawing.Size(350, 60);
            this.pic_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_exit.TabIndex = 4;
            this.pic_exit.TabStop = false;
            this.pic_exit.Click += new System.EventHandler(this.pic_exit_Click);
            this.pic_exit.MouseEnter += new System.EventHandler(this.pic_exit_MouseEnter);
            this.pic_exit.MouseLeave += new System.EventHandler(this.pic_exit_MouseLeave);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(665, 654);
            this.Controls.Add(this.pic_exit);
            this.Controls.Add(this.about_pic);
            this.Controls.Add(this.pic_records);
            this.Controls.Add(this.play_pic);
            this.Controls.Add(this.space_shooter_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            ((System.ComponentModel.ISupportInitialize)(this.space_shooter_title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.play_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_records)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.about_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox space_shooter_title;
        private System.Windows.Forms.PictureBox play_pic;
        private System.Windows.Forms.PictureBox pic_records;
        private System.Windows.Forms.PictureBox about_pic;
        private System.Windows.Forms.PictureBox pic_exit;
    }
}