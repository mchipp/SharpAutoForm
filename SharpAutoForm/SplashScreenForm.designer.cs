namespace SplashScreen
{
    partial class SplashScreenForm
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
            this.SplashScreenTimer = new System.Windows.Forms.Timer(this.components);
            this.TitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SplashScreenTimer
            // 
            this.SplashScreenTimer.Enabled = true;
            this.SplashScreenTimer.Interval = 3000;
            this.SplashScreenTimer.Tick += new System.EventHandler(this.SplashScreenTimer_Tick);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Corbel", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(75, 55);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(440, 59);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Mark\'s Splash Screen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code that always hits the Mark!";
            // 
            // SplashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreenForm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash Screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer SplashScreenTimer;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label label1;
    }
}

