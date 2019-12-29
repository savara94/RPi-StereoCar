using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Imaging;

namespace RpiCar
{
    public partial class MainForm : Form
    {
        private IEnumerable<Detection> Detections;
        private IEnumerable<Sign> Signs;
        private Dictionary<string, PictureBox[]> Displays;
        private Dictionary<string, CameraParameters> CamParams;
        private RpiCar RpiCar;
        private Dictionary<string, Bitmap> SignImages;

        public MainForm()
        {
            InitializeComponent();
            InitializeApp();
        }

        public void InitializeApp()
        {
            Displays = new Dictionary<string, PictureBox[]>();
            CamParams = new Dictionary<string, CameraParameters>();

            Displays["left"] = new PictureBox[] { pictureBoxLeftMosaicCamera, pictureBoxLeftCamera };
            CamParams["left"] = new CameraParameters
            {
                Fx = 698.4,
                //Fx = 724.0,
                Fy = 698.9,
                Cx = 325.5,
                Cy = 259.9,
                Skew = 0
            };

            Displays["right"] = new PictureBox[] { pictureBoxRightMosaicCamera, pictureBoxRightCamera };
            CamParams["right"] = new CameraParameters
            {
                Fx = 705.23549,
                //Fx = 724.0,
                Fy = 706.47721,
                Cx = 317.47812,
                Cy = 268.77874,
                Skew = 0
            };

            chartTopView.ChartAreas[0].AxisX.Minimum = -1.5;
            chartTopView.ChartAreas[0].AxisX.Maximum = 1.5;

            chartTopView.ChartAreas[0].AxisY.Minimum = -0.5;
            chartTopView.ChartAreas[0].AxisY.Maximum = 1.5;

            SignImages = new Dictionary<string, Bitmap>();
            SignImages["0"] = new Bitmap("stop.png");
            SignImages["2"] = new Bitmap("priority.png");
            SignImages["1"] = new Bitmap("roundabout.png");
            SignImages["car"] = new Bitmap("car.png");
        }

        private string MapCamIdToString(int id)
        {
            switch (id)
            {
                case 0:
                    return "left";
                case 1:
                    return "right";
                default:
                    throw new ArgumentException("Should not happen!");
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var succ = false;
            do
            {
                try
                {
                    var ipForm = new IPForm();
                    ipForm.IPAdress = Properties.Settings.Default.URL;

                    var dialogResult = ipForm.ShowDialog();
                    if (dialogResult != DialogResult.OK)
                    {
                        Close();
                        break;
                    }

                    RpiCar = new RpiCar(ipForm.IPAdress, 5000, 0.14, CamParams["left"], CamParams["right"]);
                    succ = await RpiCar.IsAliveAsync();

                    if (succ)
                    {
                        Properties.Settings.Default.URL = ipForm.IPAdress;
                        Properties.Settings.Default.Save();
                    }

                }
                catch
                {

                }
            } while (!succ);

            timerVideoFeedLeft.Enabled = true;
            timerVideoFeedRight.Enabled = true;
            timerDetections.Enabled = true;
            timerInformation.Enabled = true;
        }

        private async void TimerVideoFeed_Tick(object sender, EventArgs e)
        {
            var timer = (Timer)sender;

            timer.Enabled = false;

            var id = int.Parse(timer.Tag.ToString());
            var device = (CameraDevice)id;

            var img = await RpiCar.GetCameraFeedAsync(device);

            switch (device)
            {
                case CameraDevice.LEFT:
                    pictureBoxLeftCamera.Image = img;
                    pictureBoxLeftMosaicCamera.Image = img;
                    break;
                case CameraDevice.RIGHT:
                    pictureBoxRightCamera.Image = img;
                    pictureBoxRightMosaicCamera.Image = img;
                    break;
            }

            timer.Enabled = true;
        }

        private async void TimerInformation_Tick(object sender, EventArgs e)
        {
            timerInformation.Enabled = false;

            // TODO LATER
            var carState = await RpiCar.GetCarStateAsync();

            if (carState == null)
            {
                return;
            }

            toolStripStatusLabelRearDistance.Text = $"Rear clearance: {carState.RearDistance} cm";
            toolStripStatusLabelLeftLine.Text = $"Left line: {carState.LeftBlackLine}";
            toolStripStatusLabelRightLine.Text = $"Right line: {carState.RightBlackLine}";
            toolStripStatusLabelGear.Text = $"Gear: {carState.Gear}";

            timerInformation.Enabled = true;
        }

        private async void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //KeyDown -= MainForm_KeyDown;

            switch (e.KeyData)
            {
                case Keys.W:
                    await RpiCar.Move(MoveCommand.FORWARD);
                    break;
                case Keys.S:
                    await RpiCar.Move(MoveCommand.Backward);
                    break;
                case Keys.A:
                    await RpiCar.Move(MoveCommand.Left);
                    break;
                case Keys.D:
                    await RpiCar.Move(MoveCommand.Right);
                    break;
                case Keys.T:
                    await RpiCar.TrackAsync();
                    break;
            }

            //KeyDown += MainForm_KeyDown;
        }

        private async void ToolStripButtonReset_Click(object sender, EventArgs e)
        {
            await RpiCar.ResetAsync();
        }

        private async void ToolStripButtonGearUp_Click(object sender, EventArgs e)
        {
            await RpiCar.ChangeGearAsync(GearCommand.Up);
        }

        private async void ToolStripButton4_Click(object sender, EventArgs e)
        {
            await RpiCar.ChangeGearAsync(GearCommand.Down);
        }

        private async void TimerDetections_Tick(object sender, EventArgs e)
        {
            timerDetections.Enabled = false;

            Detections = await RpiCar.GetDetectionsAsync();
            Signs = RpiCar.DetectionsToWorldCoords(Detections);

            chartTopView.Series["Signs"].Points.Clear();
            chartTopView.Images.Clear();
            chartTopView.Annotations.Clear();

            InsertInTopView(0, 0, SignImages["car"]);

            foreach (var sign in Signs)
            {
                InsertInTopView(sign.X, sign.Y, SignImages[sign.Name]);
            }

            timerDetections.Enabled = true;
        }

        private void InsertInTopView(double x, double y, Bitmap img)
        {
            var id = chartTopView.Series["Signs"].Points.Count;
            var dataPoint = new DataPoint(x, y);
            chartTopView.Series["Signs"].Points.Add(dataPoint);
            var namedImg = new NamedImage($"sign_{id}", img);
            chartTopView.Images.Add(namedImg);

            ImageAnnotation ia = new ImageAnnotation()
            {
                AnchorDataPoint = dataPoint,
            };

            ia.Image = namedImg.Name;
            ia.AllowMoving = false;
            chartTopView.Annotations.Add(ia);
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            var tmp = Displays["right"];
            Displays["right"] = Displays["left"];
            Displays["left"] = tmp;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            var dets = Detections;
            var signs = Signs;
            var pictureBox = (PictureBox)sender;

            if (dets == null || pictureBox.Image == null)
            {
                return;
            }

            var xRatio = 1.0 * pictureBox.Width / pictureBox.Image.Width;
            var yRatio = 1.0 * pictureBox.Height / pictureBox.Image.Height;

            var detsForThisPictureBox = dets.Where(x => Displays[MapCamIdToString(x.Camera)].Contains(pictureBox));

            foreach (var det in detsForThisPictureBox)
            {
                var camId = det.Camera;
                var className = det.Class;

                var x = det.Left * xRatio;
                var y = det.Top * yRatio;
                var width = det.Width * xRatio;
                var height = det.Height * yRatio;

                e.Graphics.DrawRectangle(Pens.Red, new Rectangle((int)x, (int)y, (int)width, (int)height));

                var sign = signs.FirstOrDefault(s => s.Name == det.Class);
                if (sign == null)
                {
                    continue;
                }

                var dist = Math.Sqrt(sign.X * sign.X + sign.Y * sign.Y) * 100;
                e.Graphics.DrawString($"{dist.ToString("0.00")} cm", DefaultFont, Brushes.Blue, (int)x - 15, (int)y - 15);
            }
        }

        private async void toolStripButton2_Click(object sender, EventArgs e)
        {
            await RpiCar.TrackAsync();
        }
    }
}
