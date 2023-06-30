using GLib;
using System.Windows.Forms;

namespace Sonas_Pictura
{
    partial class SettingsMenu
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.input1 = new System.Windows.Forms.TextBox();
            this.text1 = new System.Windows.Forms.RichTextBox();
            this.input2 = new System.Windows.Forms.TextBox();
            this.text2 = new System.Windows.Forms.RichTextBox();
            this.input3 = new System.Windows.Forms.TextBox();
            this.input4 = new System.Windows.Forms.TextBox();
            this.btn1 = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.input1);
            this.groupBox.Controls.Add(this.text1);
            this.groupBox.Controls.Add(this.input2);
            this.groupBox.Controls.Add(this.text2);
            this.groupBox.Controls.Add(this.input3);
            this.groupBox.Controls.Add(this.input4);
            this.groupBox.Controls.Add(this.btn1);
            this.groupBox.Location = new System.Drawing.Point(20, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(383, 250);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // input1
            // 
            this.input1.Location = new System.Drawing.Point(239, 19);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(100, 20);
            this.input1.TabIndex = 0;
            this.input1.Text = "150";
            this.input1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.input1.Click += new System.EventHandler(this.btn1_Click);
            this.input1.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // text1
            // 
            this.text1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text1.Location = new System.Drawing.Point(3, 16);
            this.text1.Name = "text1";
            this.text1.ReadOnly = true;
            this.text1.Size = new System.Drawing.Size(200, 20);
            this.text1.TabIndex = 1;
            this.text1.Text = "Size of Overlay radar (in bits)";
            // 
            // input2
            // 
            this.input2.Location = new System.Drawing.Point(239, 55);
            this.input2.Name = "input2";
            this.input2.Size = new System.Drawing.Size(100, 20);
            this.input2.TabIndex = 1;
            this.input2.Text = "Red";
            this.input2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.input2.Click += new System.EventHandler(this.btn2_Click);
            this.input2.TextChanged += new System.EventHandler(this.input2_TextChanged);
            // 
            // text2
            // 
            this.text2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text2.Location = new System.Drawing.Point(3, 55);
            this.text2.Name = "text2";
            this.text2.ReadOnly = true;
            this.text2.Size = new System.Drawing.Size(221, 20);
            this.text2.TabIndex = 1;
            this.text2.Text = "Colour of Overlay radar (in name of Colour)";
            // 
            // input3
            // 
            this.input3.Location = new System.Drawing.Point(239, 95);
            this.input3.Name = "input3";
            this.input3.Size = new System.Drawing.Size(100, 20);
            this.input3.TabIndex = 2;
            this.input3.Text = "0.5";
            this.input3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.input3.Click += new System.EventHandler(this.btn3_Click);
            this.input3.TextChanged += new System.EventHandler(this.input3_TextChanged);
            // 
            // input4
            // 
            this.input4.Location = new System.Drawing.Point(239, 134);
            this.input4.Name = "input4";
            this.input4.Size = new System.Drawing.Size(100, 20);
            this.input4.TabIndex = 1;
            this.input4.Text = "False";
            this.input4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.input4.Click += new System.EventHandler(this.btn4_Click);
            this.input4.TextChanged += new System.EventHandler(this.input4_TextChanged);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(144, 210);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(100, 20);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "Save";
            this.btn1.TextChanged += new System.EventHandler(this.input4_TextChanged);
            this.btn1.Click += new System.EventHandler(this.btn4_Click);
            // 
            // SettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 269);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sonus Pictura";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox input1;
        private System.Windows.Forms.RichTextBox text1;
        private System.Windows.Forms.TextBox input2;
        private System.Windows.Forms.RichTextBox text2;
        private System.Windows.Forms.TextBox input3;
        private System.Windows.Forms.TextBox input4;
        private System.Windows.Forms.Button btn1;
    }
}