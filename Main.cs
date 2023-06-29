using System;
using System.Windows.Forms;

namespace Sonas_Pictura
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Overlay o = new Overlay();
            o.Show();
            this.Hide();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sonus Pictura", "This applciation aims to provide aid to deaf and hard-of-hearing users by visualising in-game audio." +
                " This will give userts ifnormation such as direction of audio and their levels", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            //Open Settings
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sonus Pictura", "This application requires 7.1 audio in order to properly operate the 360 directional display." +
                "This can be done by accesing your audio driver settings and selecting 7.1/Surround-Sound audio." +
                "If 7.1 audio is not avaible, 3rd party programs such as Rzaer Sound are recommended.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
