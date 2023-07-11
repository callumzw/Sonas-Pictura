using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Libs.DirectShowLib;

namespace Sonas_Pictura
{
    public partial class SettingsMenu : Form
    {
        public SettingsMenu()
        {
            InitializeComponent();
            Bitmap bitmp = Properties.Resources.Sonas_Logo;
            this.Icon = Icon.FromHandle(bitmp.GetHicon());
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            bool error = false;
            try
            {
                Properties.Settings.Default.radarSize = Int32.Parse(input1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show( "Radar size entered incompatible, please enter an integer number (e.g 150)","Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
            try
            {
                Properties.Settings.Default.radarCol = ColorTranslator.FromHtml(input2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Radar Color entered incompatible, please enter a valid color name or Hex/RGB code (e.g Red or #FF0000)", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
            try
            {
                Properties.Settings.Default.overlayOpacity = Double.Parse(input3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Overlay Opacity entered entered incompatible, please enter a valid digit number (e.g 0.5)", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }

            try
            {
                Properties.Settings.Default.radarLines = bool.Parse(input4.Text);
            }
            catch (Exception) { 
                MessageBox.Show("Radar Lines choice entered entered incompatible, please enter a valid bool (e.g true or false)", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }

            Properties.Settings.Default.Save();

            if (error == false) 
            {
                Main main = new Main();
                main.Show();
                this.Close();
            }
        }

        private void SettingsMenu_Closed(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
