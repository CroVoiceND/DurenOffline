namespace DurenOffline
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.myName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.WinLose = new System.Windows.Forms.Label();
            this.Draw = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.myMoneySet = new System.Windows.Forms.NumericUpDown();
            this.save = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.agree = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myMoneySet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ім\'я";
            // 
            // myName
            // 
            this.myName.Location = new System.Drawing.Point(97, 28);
            this.myName.Name = "myName";
            this.myName.Size = new System.Drawing.Size(225, 35);
            this.myName.TabIndex = 1;
            this.myName.Text = "Я";
            this.myName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Кількість карт";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(211, 85);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 33);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "36";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(274, 85);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 33);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "52";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ваша ставка";
            // 
            // WinLose
            // 
            this.WinLose.AutoSize = true;
            this.WinLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WinLose.Location = new System.Drawing.Point(12, 210);
            this.WinLose.Name = "WinLose";
            this.WinLose.Size = new System.Drawing.Size(173, 24);
            this.WinLose.TabIndex = 3;
            this.WinLose.Text = "Переміг: Програв:";
            // 
            // Draw
            // 
            this.Draw.AutoSize = true;
            this.Draw.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Draw.Location = new System.Drawing.Point(49, 239);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(144, 24);
            this.Draw.TabIndex = 3;
            this.Draw.Text = "Зіграв в нічию:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ваш банк = 100 грн";
            // 
            // myMoneySet
            // 
            this.myMoneySet.Location = new System.Drawing.Point(202, 162);
            this.myMoneySet.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.myMoneySet.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.myMoneySet.Name = "myMoneySet";
            this.myMoneySet.Size = new System.Drawing.Size(120, 35);
            this.myMoneySet.TabIndex = 4;
            this.myMoneySet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.myMoneySet.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.save.Location = new System.Drawing.Point(26, 276);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(296, 46);
            this.save.TabIndex = 5;
            this.save.Text = "Зберегти профіль";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // open
            // 
            this.open.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.open.Location = new System.Drawing.Point(26, 332);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(296, 46);
            this.open.TabIndex = 5;
            this.open.Text = "Відобразити профіль";
            this.open.UseVisualStyleBackColor = false;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // agree
            // 
            this.agree.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.agree.Location = new System.Drawing.Point(26, 389);
            this.agree.Name = "agree";
            this.agree.Size = new System.Drawing.Size(296, 46);
            this.agree.TabIndex = 5;
            this.agree.Text = "Підтвердити";
            this.agree.UseVisualStyleBackColor = false;
            this.agree.Click += new System.EventHandler(this.agree_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(356, 459);
            this.Controls.Add(this.agree);
            this.Controls.Add(this.open);
            this.Controls.Add(this.save);
            this.Controls.Add(this.myMoneySet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Draw);
            this.Controls.Add(this.WinLose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.myName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "Settings";
            this.Text = "Налаштування";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myMoneySet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox myName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label WinLose;
        private System.Windows.Forms.Label Draw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown myMoneySet;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button agree;
    }
}