namespace DurenOffline
{
    partial class StartWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartWindow));
            this.newGame = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.rules = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newGame
            // 
            this.newGame.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newGame.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.newGame.Location = new System.Drawing.Point(31, 23);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(220, 60);
            this.newGame.TabIndex = 1;
            this.newGame.Text = "Нова гра";
            this.newGame.UseVisualStyleBackColor = false;
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Black;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.exit.Location = new System.Drawing.Point(31, 254);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(220, 60);
            this.exit.TabIndex = 2;
            this.exit.Text = "Вийти";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // rules
            // 
            this.rules.BackColor = System.Drawing.Color.Black;
            this.rules.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rules.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rules.Location = new System.Drawing.Point(31, 179);
            this.rules.Name = "rules";
            this.rules.Size = new System.Drawing.Size(220, 60);
            this.rules.TabIndex = 3;
            this.rules.Text = "Правила гри";
            this.rules.UseVisualStyleBackColor = false;
            this.rules.Click += new System.EventHandler(this.rules_Click);
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.Black;
            this.settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settings.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.settings.Location = new System.Drawing.Point(31, 101);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(220, 60);
            this.settings.TabIndex = 4;
            this.settings.Text = "Налаштування";
            this.settings.UseVisualStyleBackColor = false;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(278, 358);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.rules);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.newGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartWindow";
            this.Text = "Стартове вікно";
            this.Load += new System.EventHandler(this.StartWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newGame;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button rules;
        private System.Windows.Forms.Button settings;
    }
}

