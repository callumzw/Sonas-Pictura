using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sonas_Pictura
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Bitmap bitmp = Properties.Resources.Sonas_Logo;
            this.Icon = Icon.FromHandle(bitmp.GetHicon());
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Overlay o = new Overlay();
            o.Show();
            this.Hide();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This applciation aims to provide aid to deaf and hard-of-hearing users by visualising in-game audio. \n" +
                "This will give users information such as direction of audio and their levels","Sonus Pictura", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn3_Click(object sender, EventArgs e)
        {
           SettingsMenu settingsMenu = new SettingsMenu();
            settingsMenu.ShowDialog();
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application requires 7.1 audio in order to properly operate the 360 directional display.\n" +
                "This can be done by accesing your audio driver settings and selecting 7.1/Surround-Sound audio.\n" +
                "If 7.1 audio is not available, 3rd party programs such as Razer Sound are recommended.", "Sonus Pictura", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
    }
}
