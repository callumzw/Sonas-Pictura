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
        public Overlay()
        {
            InitializeComponent(Properties.Settings.Default.radarSize) ;
        }
        private void Overlay_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.White;
            this.BackColor = Color.White;

            this.WindowState = FormWindowState.Maximized;
            this.Opacity = Properties.Settings.Default.overlayOpacity;
            Thread t = new Thread(AudioReader);
            t.Start();
        }
        public void AudioReader()
        {
            enumerator = new MMDeviceEnumerator();
            device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);

            if (device.AudioMeterInformation.PeakValues.Count < 8)
            {
                System.Windows.MessageBox.Show("A 7.1 audio device required. Review setup guide again please.", "Error! No 7.1 audio detected!", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(-1);
            }

            while (true)
            {
                float leftCh = device.AudioMeterInformation.PeakValues[6] * 100;
                float rightCh = device.AudioMeterInformation.PeakValues[7] * 100;
                float leftFrCh = device.AudioMeterInformation.PeakValues[0] * 100;
                float rightFrCh = device.AudioMeterInformation.PeakValues[1] * 100;
                float leftBckCh = device.AudioMeterInformation.PeakValues[4] * 100;
                float rightBckCh = device.AudioMeterInformation.PeakValues[5] * 100;
                float frontCh = device.AudioMeterInformation.PeakValues[2] * 100;

                RunOverlay(leftCh, rightCh, leftFrCh, rightFrCh, leftBckCh, rightBckCh, frontCh);

                Thread.Sleep(10);
            }
        }
        public void RunOverlay(double l, double r, double fl, double fr, double bl, double br, double f)
        {
            var user = Properties.Settings.Default;
            Bitmap radar = new Bitmap(user.radarSize + 5, user.radarSize + 5);
            SolidBrush radarBrush = new SolidBrush(user.radarCol);
            int size75 = (int)(user.radarSize * 0.75);
            int size50 = user.radarSize / 2;
            int size25 = (int)(user.radarSize * 0.25);

            Graphics frontLeft = Graphics.FromImage(radar);
            Graphics frontRight = Graphics.FromImage(radar);
            Graphics left = Graphics.FromImage(radar);
            Graphics right = Graphics.FromImage(radar);
            Graphics backLeft = Graphics.FromImage(radar);
            Graphics backRight = Graphics.FromImage(radar);

            // Left Indicator
            if (l >= 5)
            {
                left.FillPolygon(radarBrush, new Point[] { new Point(2, size25), new Point(size50, size50), new Point(2, size75) });
            }
            else
            {
                left = null;
            }

            // Right Indicator
            if (r >= 5)
            {
                right.FillPolygon(radarBrush, new Point[] { new Point(user.radarSize, size25), new Point(size50, size50), new Point(user.radarSize, size75) });
            }
            else
            {
                right = null;
            }

            // Front Left Indicator
            if (fl >= 5 | f >= 5)
            {
                frontLeft.FillPolygon(radarBrush, new Point[] { new Point(2, size25), new Point(size50, size50), new Point(size50, 2) });
            }
            else
            {
                frontLeft = null;
            }

            // Front Right Indicator
            if (fr >= 5 | f >= 5)
            {
                frontRight.FillPolygon(radarBrush, new Point[] { new Point(size50, 2), new Point(size50, size50), new Point(user.radarSize, size25) });
            }
            else
            {
                frontRight = null;  
            }

            // Back left Indicator
            if (bl >= 5)
            {
                backLeft.FillPolygon(radarBrush, new Point[] { new Point(2, size75), new Point(size50, size50), new Point(size50, user.radarSize) });
            }
            else
            {
                backLeft = null;
            }

            // Back right Indicator
            if (br >= 5)
            {
                backRight.FillPolygon(radarBrush, new Point[] { new Point(size50, user.radarSize), new Point(size50, size50), new Point(user.radarSize, size75) });
            }
            else
            {
                backRight = null;
            }
            DrawHexagon(radar);
            pictureBox1.Image = radar;
            

        }
        public void DrawHexagon( Bitmap map)
        {
            var user = Properties.Settings.Default;
            int size75 = (int)(user.radarSize * 0.75);
            int size50 = user.radarSize / 2;
            int size25 = (int)(user.radarSize * 0.25);

            Point[] hexPoints = new Point[7];
            hexPoints[0] = new Point(size50,3);
            hexPoints[1] = new Point(user.radarSize, size25);
            hexPoints[2] = new Point(user.radarSize, size75);
            hexPoints[3] = new Point(size50, user.radarSize);
            hexPoints[4] = new Point(3, size75);
            hexPoints[5] = new Point(3, size25);
            hexPoints[6] = new Point(size50, 3);

            Graphics hex = Graphics.FromImage(map);
            Pen pen = new Pen(Brushes.Black, 3);
            hex.DrawPolygon(pen, hexPoints);
            bool x = user.radarLines;
            if (x == true)
                    {
                hex.DrawLine(pen, new Point(size50, 3), new Point(size50, user.radarSize));
                hex.DrawLine(pen, new Point(3, size25), new Point(user.radarSize, size75));
                hex.DrawLine(pen, new Point(user.radarSize, size25), new Point(3, size75)); 
            }

        }

    }
}
