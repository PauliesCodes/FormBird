namespace FormBird
{
    partial class MainMenu
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.title_Label = new System.Windows.Forms.Label();
            this.play_Button = new System.Windows.Forms.Button();
            this.bird_color_Label = new System.Windows.Forms.Label();
            this.pipe_color_Label = new System.Windows.Forms.Label();
            this.url_PictureBox = new System.Windows.Forms.PictureBox();
            this.gitHub_PictureBox = new System.Windows.Forms.PictureBox();
            this.pipe_color_PictureBox = new System.Windows.Forms.PictureBox();
            this.bird_color_PictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clear_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.url_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gitHub_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipe_color_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bird_color_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // title_Label
            // 
            this.title_Label.AutoSize = true;
            this.title_Label.Font = new System.Drawing.Font("Yu Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.title_Label.ForeColor = System.Drawing.Color.White;
            this.title_Label.Location = new System.Drawing.Point(21, 23);
            this.title_Label.Name = "title_Label";
            this.title_Label.Size = new System.Drawing.Size(339, 82);
            this.title_Label.TabIndex = 0;
            this.title_Label.Text = "Form Bird";
            // 
            // play_Button
            // 
            this.play_Button.BackColor = System.Drawing.SystemColors.Window;
            this.play_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.play_Button.Font = new System.Drawing.Font("Yu Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.play_Button.Location = new System.Drawing.Point(35, 108);
            this.play_Button.Name = "play_Button";
            this.play_Button.Size = new System.Drawing.Size(146, 58);
            this.play_Button.TabIndex = 1;
            this.play_Button.Text = "PLAY";
            this.play_Button.UseVisualStyleBackColor = false;
            this.play_Button.Click += new System.EventHandler(this.play_Button_Click);
            // 
            // bird_color_Label
            // 
            this.bird_color_Label.AutoSize = true;
            this.bird_color_Label.Font = new System.Drawing.Font("Yu Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.bird_color_Label.ForeColor = System.Drawing.Color.White;
            this.bird_color_Label.Location = new System.Drawing.Point(12, 187);
            this.bird_color_Label.Name = "bird_color_Label";
            this.bird_color_Label.Size = new System.Drawing.Size(133, 31);
            this.bird_color_Label.TabIndex = 2;
            this.bird_color_Label.Text = "Bird color:";
            // 
            // pipe_color_Label
            // 
            this.pipe_color_Label.AutoSize = true;
            this.pipe_color_Label.Font = new System.Drawing.Font("Yu Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.pipe_color_Label.ForeColor = System.Drawing.Color.White;
            this.pipe_color_Label.Location = new System.Drawing.Point(12, 243);
            this.pipe_color_Label.Name = "pipe_color_Label";
            this.pipe_color_Label.Size = new System.Drawing.Size(138, 31);
            this.pipe_color_Label.TabIndex = 4;
            this.pipe_color_Label.Text = "Pipe color:";
            // 
            // url_PictureBox
            // 
            this.url_PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.url_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.url_PictureBox.Image = global::FormBird.Properties.Resources.urrll_removebg_preview;
            this.url_PictureBox.Location = new System.Drawing.Point(270, 235);
            this.url_PictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.url_PictureBox.Name = "url_PictureBox";
            this.url_PictureBox.Size = new System.Drawing.Size(50, 50);
            this.url_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.url_PictureBox.TabIndex = 7;
            this.url_PictureBox.TabStop = false;
            this.url_PictureBox.Click += new System.EventHandler(this.url_PictureBox_Click);
            // 
            // gitHub_PictureBox
            // 
            this.gitHub_PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.gitHub_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gitHub_PictureBox.Image = global::FormBird.Properties.Resources.github__1_;
            this.gitHub_PictureBox.Location = new System.Drawing.Point(326, 235);
            this.gitHub_PictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.gitHub_PictureBox.Name = "gitHub_PictureBox";
            this.gitHub_PictureBox.Size = new System.Drawing.Size(50, 50);
            this.gitHub_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gitHub_PictureBox.TabIndex = 6;
            this.gitHub_PictureBox.TabStop = false;
            this.gitHub_PictureBox.Click += new System.EventHandler(this.gitHub_PictureBox_Click);
            // 
            // pipe_color_PictureBox
            // 
            this.pipe_color_PictureBox.BackColor = System.Drawing.Color.Green;
            this.pipe_color_PictureBox.Location = new System.Drawing.Point(150, 235);
            this.pipe_color_PictureBox.Name = "pipe_color_PictureBox";
            this.pipe_color_PictureBox.Size = new System.Drawing.Size(50, 50);
            this.pipe_color_PictureBox.TabIndex = 5;
            this.pipe_color_PictureBox.TabStop = false;
            this.pipe_color_PictureBox.Click += new System.EventHandler(this.pipe_color_PictureBox_Click);
            // 
            // bird_color_PictureBox
            // 
            this.bird_color_PictureBox.BackColor = System.Drawing.Color.Yellow;
            this.bird_color_PictureBox.Location = new System.Drawing.Point(150, 179);
            this.bird_color_PictureBox.Name = "bird_color_PictureBox";
            this.bird_color_PictureBox.Size = new System.Drawing.Size(50, 50);
            this.bird_color_PictureBox.TabIndex = 3;
            this.bird_color_PictureBox.TabStop = false;
            this.bird_color_PictureBox.Click += new System.EventHandler(this.bird_color_PictureBox_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // clear_Button
            // 
            this.clear_Button.BackColor = System.Drawing.SystemColors.Window;
            this.clear_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clear_Button.Font = new System.Drawing.Font("Yu Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.clear_Button.Location = new System.Drawing.Point(194, 108);
            this.clear_Button.Name = "clear_Button";
            this.clear_Button.Size = new System.Drawing.Size(146, 58);
            this.clear_Button.TabIndex = 8;
            this.clear_Button.Text = "CLEAR";
            this.clear_Button.UseVisualStyleBackColor = false;
            this.clear_Button.Click += new System.EventHandler(this.clear_Button_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(381, 290);
            this.Controls.Add(this.clear_Button);
            this.Controls.Add(this.url_PictureBox);
            this.Controls.Add(this.gitHub_PictureBox);
            this.Controls.Add(this.pipe_color_PictureBox);
            this.Controls.Add(this.pipe_color_Label);
            this.Controls.Add(this.bird_color_PictureBox);
            this.Controls.Add(this.bird_color_Label);
            this.Controls.Add(this.play_Button);
            this.Controls.Add(this.title_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "FormBird";
            ((System.ComponentModel.ISupportInitialize)(this.url_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gitHub_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipe_color_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bird_color_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_Label;
        private System.Windows.Forms.Button play_Button;
        private System.Windows.Forms.Label bird_color_Label;
        private System.Windows.Forms.PictureBox bird_color_PictureBox;
        private System.Windows.Forms.PictureBox pipe_color_PictureBox;
        private System.Windows.Forms.Label pipe_color_Label;
        private System.Windows.Forms.PictureBox gitHub_PictureBox;
        private System.Windows.Forms.PictureBox url_PictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button clear_Button;
    }
}

