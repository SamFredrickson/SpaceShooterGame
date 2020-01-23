namespace SpaceShooterGame
{
    partial class NameAndDiffChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NameAndDiffChoice));
            this.label_name = new System.Windows.Forms.Label();
            this.text_name = new System.Windows.Forms.TextBox();
            this.lab_diff = new System.Windows.Forms.Label();
            this.diff_combo = new System.Windows.Forms.ComboBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.BackColor = System.Drawing.Color.Transparent;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_name.Location = new System.Drawing.Point(66, 17);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(144, 24);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "Выберите имя:";
            // 
            // text_name
            // 
            this.text_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_name.Location = new System.Drawing.Point(70, 45);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(235, 32);
            this.text_name.TabIndex = 1;
            // 
            // lab_diff
            // 
            this.lab_diff.AutoSize = true;
            this.lab_diff.BackColor = System.Drawing.Color.Transparent;
            this.lab_diff.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_diff.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lab_diff.Location = new System.Drawing.Point(66, 94);
            this.lab_diff.Name = "lab_diff";
            this.lab_diff.Size = new System.Drawing.Size(208, 24);
            this.lab_diff.TabIndex = 2;
            this.lab_diff.Text = "Выберите сложность:";
            // 
            // diff_combo
            // 
            this.diff_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.diff_combo.FormattingEnabled = true;
            this.diff_combo.Items.AddRange(new object[] {
            "Легко",
            "Средне",
            "Тяжело",
            "Очень тяжело"});
            this.diff_combo.Location = new System.Drawing.Point(70, 124);
            this.diff_combo.Name = "diff_combo";
            this.diff_combo.Size = new System.Drawing.Size(235, 33);
            this.diff_combo.TabIndex = 5;
            this.diff_combo.Text = "Легко";
            // 
            // btn_confirm
            // 
            this.btn_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_confirm.Location = new System.Drawing.Point(70, 176);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(235, 48);
            this.btn_confirm.TabIndex = 4;
            this.btn_confirm.Text = "Подтвердить";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // NameAndDiffChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(378, 246);
            this.Controls.Add(this.diff_combo);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.lab_diff);
            this.Controls.Add(this.text_name);
            this.Controls.Add(this.label_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NameAndDiffChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор имени и сложности";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NameAndDiffChoice_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox text_name;
        private System.Windows.Forms.Label lab_diff;
        private System.Windows.Forms.ComboBox diff_combo;
        private System.Windows.Forms.Button btn_confirm;
    }
}