using Sonas_Pictura.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using VisioForge.Libs.NAudio.CoreAudioApi;

namespace Sonas_Pictura
{
    public partial class Overlay : Form
    {
        MMDeviceEnumerator enumerator;
        MMDevice device;
        int multiplier = 100;
        public Overlay()
        {
            InitializeComponent();
        }
        private void Overlay_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.White;
            this.BackColor = Color.White;

            this.WindowState = FormWindowState.Maximized;
            this.Opacity = 0.5;
            Thread t = new Thread(AudioReader);
            t.Start();
        }
        public void AudioReader()
        {
            enumerator = new MMDeviceEnumerator();
            device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            int multiplier = 100;

            if (device.AudioMeterInformation.PeakValues.Count < 8)
            {
                System.Windows.MessageBox.Show("A 7.1 audio device required. Review setup guide again please.", "Error! No 7.1 audio detected!", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(-1);
            }

            while (true)
            {
                float leftCh = device.AudioMeterInformation.PeakValues[6] * multiplier;
                float rightCh = device.AudioMeterInformation.PeakValues[7] * multiplier;
                float leftFrCh = device.AudioMeterInformation.PeakValues[0] * multiplier;
                float rightFrCh = device.AudioMeterInformation.PeakValues[1] * multiplier;
                float leftBckCh = device.AudioMeterInformation.PeakValues[4] * multiplier;
                float rightBckCh = device.AudioMeterInformation.PeakValues[5] * multiplier;
                float frontCh = device.AudioMeterInformation.PeakValues[2] * multiplier;

                RunOverlay(leftCh, rightCh, leftFrCh, rightFrCh, leftBckCh, rightBckCh, frontCh);

                Thread.Sleep(10);
            }
        }
        public void RunOverlay(double l, double r, double fl, double fr, double bl, double br, double f)
        {
            Bitmap radar = new Bitmap(150, 150);
            Graphics graph = Graphics.FromImage(radar);
            SolidBrush radarBrush = new SolidBrush(Color.Red);
            graph.FillPolygon(Brushes.LightGray, new Point[] { new Point(150, 100), new Point(100, 150), new Point(150, 150) });

            Settings s = new Settings();
            string radarColour; //= s.RadarCol;
            // Left Indicator
            if (l >= 5)
            {
                //leftFill.Color = (Color)ColorConverter.ConvertFromString(radarColour);
            }
            else
            {
                // leftFill.Color = (Color)ColorConverter.ConvertFromString("Transparent");
                //leftFill.Opacity = s.RadarOpacity;
            }

            // Right Indicator
            if (r >= 5)
            {
                // rightFill.Color = (Color)ColorConverter.ConvertFromString(radarColour);
            }
            else
            {
                // rightFill.Color = (Color)ColorConverter.ConvertFromString("Transparent");
                // rightFill.Opacity = s.RadarOpacity;
            }

            // Front Left Indicator
            if (fl >= 5 | f >= 5)
            {
                pictureBox1.Image = radar;
                //topLeftFill.Color = (Color)ColorConverter.ConvertFromString(radarColour);
            }
            else
            {
                // topLeftFill.Color = (Color)ColorConverter.ConvertFromString("Transparent");
                // topLeftFill.Opacity = s.RadarOpacity;
            }

            // Front Right Indicator
            if (fr >= 5 | f >= 5)
            {
                //topRightFill.Color = (Color)ColorConverter.ConvertFromString(radarColour);
            }
            else
            {
                //topRightFill.Color = (Color)ColorConverter.ConvertFromString("Transparent");
                //topRightFill.Opacity = s.RadarOpacity;
            }

            // Back left Indicator
            if (bl >= 5)
            {
                // downLeftFill.Color = (Color)ColorConverter.ConvertFromString(radarColour);
            }
            else
            {
                //downLeftFill.Color = (Color)ColorConverter.ConvertFromString("Transparent");
            }

            // Back right Indicator
            if (br >= 5)
            {
                //downRightFill.Color = (Color)ColorConverter.ConvertFromString(radarColour);
            }
            else
            {
                //downRightFill.Color = (Color)ColorConverter.ConvertFromString("Transparent");
                //downRightFill.Opacity = s.RadarOpacity;
            }
        }


        }
}
