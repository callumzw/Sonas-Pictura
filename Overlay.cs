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
            Bitmap radar = new Bitmap(205, 205);
            SolidBrush radarBrush = new SolidBrush(Color.Red);
            User s = new User();

            Graphics frontLeft = Graphics.FromImage(radar);
            Graphics frontRight = Graphics.FromImage(radar);
            Graphics left = Graphics.FromImage(radar);
            Graphics right = Graphics.FromImage(radar);
            Graphics backLeft = Graphics.FromImage(radar);
            Graphics backRight = Graphics.FromImage(radar);

            // Left Indicator
            if (l >= 5)
            {
                left.FillPolygon(radarBrush, new Point[] { new Point(2, 50), new Point(100, 100), new Point(2, 150) });
            }
            else
            {
                left = null;
            }

            // Right Indicator
            if (r >= 5)
            {
                right.FillPolygon(radarBrush, new Point[] { new Point(200, 50), new Point(100, 100), new Point(200, 150) });
            }
            else
            {
                right = null;
            }

            // Front Left Indicator
            if (fl >= 5 | f >= 5)
            {
                frontLeft.FillPolygon(radarBrush, new Point[] { new Point(2, 50), new Point(100, 100), new Point(100, 2) });
            }
            else
            {
                frontLeft = null;
            }

            // Front Right Indicator
            if (fr >= 5 | f >= 5)
            {
                frontRight.FillPolygon(radarBrush, new Point[] { new Point(100, 2), new Point(100, 100), new Point(200, 50) });
            }
            else
            {
                frontRight = null;  
            }

            // Back left Indicator
            if (bl >= 5)
            {
                backLeft.FillPolygon(radarBrush, new Point[] { new Point(2, 150), new Point(100, 100), new Point(100, 200) });
            }
            else
            {
                backLeft = null;
            }

            // Back right Indicator
            if (br >= 5)
            {
                backRight.FillPolygon(radarBrush, new Point[] { new Point(100, 200), new Point(100, 100), new Point(200, 150) });
            }
            else
            {
                backRight = null;
            }

            pictureBox1.Image = radar;
            DrawHexagon(radar);

        }
        public void DrawHexagon( Bitmap map)
        {
            User u = new User();
            Point[] hexPoints = new Point[7];
            hexPoints[0] = new Point(100,3);
            hexPoints[1] = new Point(200, 50);
            hexPoints[2] = new Point(200, 150);
            hexPoints[3] = new Point(100, 200);
            hexPoints[4] = new Point(3, 150);
            hexPoints[5] = new Point(3, 50);
            hexPoints[6] = new Point(100, 3);

            Graphics hex = Graphics.FromImage(map);
            Pen pen = new Pen(Brushes.Black, 3);
            hex.DrawPolygon(pen, hexPoints);
            bool x = u.RadarLines;
            if (x == true)
                    {
                hex.DrawLine(pen, new Point(100, 3), new Point(100, 200));
                hex.DrawLine(pen, new Point(3, 50), new Point(200, 150));
                hex.DrawLine(pen, new Point(200, 50), new Point(3, 150)); 
            }

        }


        }
}
