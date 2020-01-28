namespace SpaceShooterGame
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlGameBoard = new System.Windows.Forms.Panel();
            this.label_exit = new System.Windows.Forms.Label();
            this.label_timer = new System.Windows.Forms.Label();
            this.label_diff = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_time_gameover = new System.Windows.Forms.Label();
            this.label_gameover = new System.Windows.Forms.Label();
            this.timer_record = new System.Windows.Forms.Timer(this.components);
            this.label_pause_game = new System.Windows.Forms.Label();
            this.pnlGameBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 50;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // pnlGameBoard
            // 
            this.pnlGameBoard.BackColor = System.Drawing.Color.Black;
            this.pnlGameBoard.Controls.Add(this.label_pause_game);
            this.pnlGameBoard.Controls.Add(this.label_exit);
            this.pnlGameBoard.Controls.Add(this.label_timer);
            this.pnlGameBoard.Controls.Add(this.label_diff);
            this.pnlGameBoard.Controls.Add(this.label_name);
            this.pnlGameBoard.Controls.Add(this.label_time_gameover);
            this.pnlGameBoard.Controls.Add(this.label_gameover);
            this.pnlGameBoard.Location = new System.Drawing.Point(2, 2);
            this.pnlGameBoard.Name = "pnlGameBoard";
            this.pnlGameBoard.Size = new System.Drawing.Size(1024, 574);
            this.pnlGameBoard.TabIndex = 0;
            // 
            // label_exit
            // 
            this.label_exit.AutoSize = true;
            this.label_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_exit.ForeColor = System.Drawing.Color.White;
            this.label_exit.Location = new System.Drawing.Point(192, 504);
            this.label_exit.Name = "label_exit";
            this.label_exit.Size = new System.Drawing.Size(662, 46);
            this.label_exit.TabIndex = 5;
            this.label_exit.Text = "Нажмите Enter чтобы продолжить";
            this.label_exit.Visible = false;
            // 
            // label_timer
            // 
            this.label_timer.AutoSize = true;
            this.label_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_timer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_timer.Location = new System.Drawing.Point(2, 82);
            this.label_timer.Name = "label_timer";
            this.label_timer.Size = new System.Drawing.Size(73, 20);
            this.label_timer.TabIndex = 4;
            this.label_timer.Text = "Время: ";
            this.label_timer.Visible = false;
            // 
            // label_diff
            // 
            this.label_diff.AutoSize = true;
            this.label_diff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_diff.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_diff.Location = new System.Drawing.Point(2, 56);
            this.label_diff.Name = "label_diff";
            this.label_diff.Size = new System.Drawing.Size(113, 20);
            this.label_diff.TabIndex = 3;
            this.label_diff.Text = "Сложность: ";
            this.label_diff.Visible = false;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_name.Location = new System.Drawing.Point(2, 31);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(113, 20);
            this.label_name.TabIndex = 2;
            this.label_name.Text = "Игрок: David";
            this.label_name.Visible = false;
            // 
            // label_time_gameover
            // 
            this.label_time_gameover.AutoSize = true;
            this.label_time_gameover.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_time_gameover.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label_time_gameover.Location = new System.Drawing.Point(454, 304);
            this.label_time_gameover.Name = "label_time_gameover";
            this.label_time_gameover.Size = new System.Drawing.Size(128, 31);
            this.label_time_gameover.TabIndex = 1;
            this.label_time_gameover.Text = "00:05:02";
            this.label_time_gameover.Visible = false;
            this.label_time_gameover.Click += new System.EventHandler(this.label_time_gameover_Click);
            // 
            // label_gameover
            // 
            this.label_gameover.AutoSize = true;
            this.label_gameover.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_gameover.ForeColor = System.Drawing.Color.Red;
            this.label_gameover.Location = new System.Drawing.Point(355, 249);
            this.label_gameover.Name = "label_gameover";
            this.label_gameover.Size = new System.Drawing.Size(322, 46);
            this.label_gameover.TabIndex = 0;
            this.label_gameover.Text = "Игра окончена!";
            this.label_gameover.Visible = false;
            // 
            // timer_record
            // 
            this.timer_record.Enabled = true;
            this.timer_record.Interval = 1000;
            this.timer_record.Tick += new System.EventHandler(this.timer_record_Tick);
            // 
            // label_pause_game
            // 
            this.label_pause_game.AutoSize = true;
            this.label_pause_game.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_pause_game.ForeColor = System.Drawing.Color.Red;
            this.label_pause_game.Location = new System.Drawing.Point(371, 249);
            this.label_pause_game.Name = "label_pause_game";
            this.label_pause_game.Size = new System.Drawing.Size(306, 46);
            this.label_pause_game.TabIndex = 6;
            this.label_pause_game.Text = "Игра на паузе!";
            this.label_pause_game.Visible = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 580);
            this.Controls.Add(this.pnlGameBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_FormClosed);
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.pnlGameBoard.ResumeLayout(false);
            this.pnlGameBoard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGameBoard;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label label_time_gameover;
        private System.Windows.Forms.Label label_gameover;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_diff;
        private System.Windows.Forms.Label label_timer;
        private System.Windows.Forms.Timer timer_record;
        private System.Windows.Forms.Label label_exit;
        private System.Windows.Forms.Label label_pause_game;
    }
}

