namespace GeocodeProgress
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.statusLabel = new System.Windows.Forms.Label();
			this.pBar = new System.Windows.Forms.ProgressBar();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// statusLabel
			// 
			this.statusLabel.AllowDrop = true;
			this.statusLabel.AutoSize = true;
			this.statusLabel.Font = new System.Drawing.Font("Futura Md BT", 10F);
			this.statusLabel.Location = new System.Drawing.Point(14, 23);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(73, 16);
			this.statusLabel.TabIndex = 0;
			this.statusLabel.Text = "Working...";
			this.statusLabel.UseWaitCursor = true;
			// 
			// pBar
			// 
			this.pBar.Location = new System.Drawing.Point(12, 125);
			this.pBar.Name = "pBar";
			this.pBar.Size = new System.Drawing.Size(331, 41);
			this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.pBar.TabIndex = 1;
			this.pBar.UseWaitCursor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(112, 11);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(230, 100);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.UseWaitCursor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 178);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.pBar);
			this.Controls.Add(this.statusLabel);
			this.Font = new System.Drawing.Font("Futura Md BT", 10F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Progress";
			this.TopMost = true;
			this.UseWaitCursor = true;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

