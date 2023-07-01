using System.Windows.Forms;

namespace Sonas_Pictura
{
    partial class Overlay
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
            var user = Properties.Settings.Default;
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Location = new System.Drawing.Point(960 - (user.radarSize /2 ), 810 - (user.radarSize / 2));
            this.pictureBox1.Size = new System.Drawing.Size(user.radarSize + 5, user.radarSize + 5);;
            // 
            // Overlay
            // 
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(user.radarSize + 5, user.radarSize + 5);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle =FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Overlay";
            this.ShowInTaskbar = false;
            this.Text = "Sonus Overlay";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Overlay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}