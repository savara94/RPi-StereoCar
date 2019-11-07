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
        class Detection
        {
            public double Confidence;
            public string Class;
            public int Left;
            public int Top;
            public int Width;
            public int Height;
            public DateTime Timestamp;
            public int Camera;

            public override string ToString()
            {
                return $"{Confidence} {Class} {Left} {Top} {Width} {Height}";
            }
        }

        private HttpClient HttpClient;
        private string URL;
        private List<Detection> Detections;
        private List<PictureBox[]> PictureBoxes;
        private bool SwitchCams;

        public MainForm()
        {
            InitializeComponent();
            InitializeApp();
        }

        public void InitializeApp()
        {
            HttpClient = new HttpClient();
            PictureBoxes = new List<PictureBox[]>();
            PictureBoxes.Add(new PictureBox[] { pictureBoxLeft, pictureBoxFrontCamera });
            PictureBoxes.Add(new PictureBox[] { pictureBoxRight, pictureBoxRearCamera });
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var succ = false;
            do
            {
                try
                {
                    var urlForm = new URLForm();
                    urlForm.URL = Properties.Settings.Default.URL;

                    var dialogResult = urlForm.ShowDialog();
                    if (dialogResult != DialogResult.OK)
                    {
                        Close();
                        break;
                    }

                    using (var response = await HttpClient.GetAsync(urlForm.URL))
                    {
                        if (response != null)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            var json = JObject.Parse(jsonString);

                            if (json["message"].ToString() == "OK")
                            {
                                succ = true;
                                Properties.Settings.Default.URL = urlForm.URL;
                                Properties.Settings.Default.Save();
                            }
                        }
                    }
                }
                catch
                {

                }
            } while (!succ);

            URL = Properties.Settings.Default.URL;
            timerVideoFeed.Enabled = true;
            timerDetections.Enabled = true;
            timerInformation.Enabled = true;
        }

        private async void TimerVideoFeed_Tick(object sender, EventArgs e)
        {
            timerVideoFeed.Enabled = false;
            var count = 2;
            var feeds = new Bitmap[count];

            for (int i = 0; i < count; i++)
            {
                var uri = $"{URL}/car/video_feed/{i}";
                var img = await LoadImage(new Uri(uri));

                var index = SwitchCams ? (count - 1) - i : i;
                PictureBoxes[index][0].Image = img;
                PictureBoxes[index][1].Image = img;

                feeds[i] = img;
            }


            timerVideoFeed.Enabled = true;
        }

        private async void TimerInformation_Tick(object sender, EventArgs e)
        {
            timerInformation.Enabled = false;

            var uri = $"{URL}/car/information";

            var json = await IssueRequest(uri);
            if (json != null)
            {
                try
                {
                    //var pose = json["arexx"]["pose"].ToObject<float[]>();
                    //var newPt = new DataPoint(pose[0], pose[1]);
                    //var points = chartMap.Series[0].Points;

                    //if (points.Count > 0)
                    //{
                    //    if (!newPt.Equals(points[points.Count - 1]))
                    //    {
                    //        points.Add(newPt);
                    //    }
                    //}
                    //else
                    //{
                    //    points.Add(newPt);
                    //}
                }
                catch
                {

                }
            }

            timerInformation.Enabled = true;
        }

        public async Task<Bitmap> LoadImage(Uri uri)
        {
            BitmapImage bitmapImage = new BitmapImage();

            try
            {
                using (var response = await HttpClient.GetAsync(uri))
                {
                    response.EnsureSuccessStatusCode();

                    using (var inputStream = await response.Content.ReadAsStreamAsync())
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = inputStream;
                        bitmapImage.EndInit();
                    }
                }

                return BitmapImage2Bitmap(bitmapImage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to load the image: {0}", ex.Message);
            }

            return null;
        }

        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        private async Task<JObject> IssueRequest(string uri)
        {
            try
            {
                using (var response = await HttpClient.GetAsync(uri))
                {
                    if (response != null)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var json = JObject.Parse(jsonString);

                        return json;
                    }
                }
            }
            catch
            {

            }

            return null;
        }

        private async void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown -= MainForm_KeyDown;

            var cmd = string.Empty;

            switch (e.KeyData)
            {
                case Keys.W:
                    cmd = "forward";
                    break;
                case Keys.S:
                    cmd = "backward";
                    break;
                case Keys.A:
                    cmd = "left";
                    break;
                case Keys.D:
                    cmd = "right";
                    break;
            }

            if (cmd != string.Empty)
            {
                try
                {
                    var json = JObject.Parse($"{{'direction':'{cmd}'}}");
                    var uri = $"{URL}/car/move";
                    var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                    var response = await HttpClient.PostAsync(uri, content);
                }
                catch (Exception exc)
                {

                }
            }

            KeyDown += MainForm_KeyDown;
        }

        private async void ToolStripButtonReset_Click(object sender, EventArgs e)
        {
            try
            {
                var uri = $"{URL}/car/reset";
                var content = new StringContent("{}", Encoding.UTF8, "application/json");
                var response = await HttpClient.PostAsync(uri, content);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(jsonResponse);
                richTextBoxLog.AppendText(json.ToString());
            }
            catch (Exception exc)
            {

            }
        }

        private async void SendGearCommand(string cmd)
        {
            try
            {
                var json = JObject.Parse($"{{'gear':'{cmd}'}}");
                var uri = $"{URL}/car/gear";
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                var response = await HttpClient.PostAsync(uri, content);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                json = JObject.Parse(jsonResponse);
                richTextBoxLog.AppendText(json.ToString());
            }
            catch (Exception exc)
            {

            }
        }

        private void ToolStripButtonGearUp_Click(object sender, EventArgs e)
        {
            SendGearCommand("gear_up");
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            SendGearCommand("gear_down");
        }

        private async void TimerDetections_Tick(object sender, EventArgs e)
        {
            timerDetections.Enabled = false;

            var uri = $"{URL}/car/detections";

            var json = await IssueRequest(uri);
            if (json != null)
            {
                var camDetections = (JArray)json["detections"];
                var list = new List<Detection>();
                try
                {
                    for (int i = 0; i < camDetections.Count; i++)
                    {
                        var camDetection = camDetections[i];
                        foreach (var detection in camDetection)
                        {
                            list.Add(new Detection
                            {
                                Confidence = (double)detection[0],
                                Class = ((int)detection[1]).ToString(),
                                Left = (int)detection[2][0],
                                Top = (int)detection[2][1],
                                Width = (int)detection[2][2],
                                Height = (int)detection[2][3],
                                Timestamp = DateTime.Now,
                                Camera = i
                            });
                        }
                    }
                }
                catch
                {

                }

                Detections = list;
                //richTextBoxLog.AppendText(json.ToString());
            }

            timerDetections.Enabled = true;
        }



        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            SwitchCams = !SwitchCams;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            var dets = Detections;
            var pictureBox = (PictureBox)sender;

            if (dets == null || pictureBox.Image == null)
            {
                return;
            }

            var pictureBoxIndex = PictureBoxes.FindIndex(x => x.FirstOrDefault(y => y == pictureBox) != null);

            var xRatio = 1.0 * pictureBox.Width / pictureBox.Image.Width;
            var yRatio = 1.0 * pictureBox.Height / pictureBox.Image.Height;

            foreach (var det in dets)
            {
                var camId = det.Camera;
                var className = det.Class;

                if (pictureBoxIndex != camId)
                {
                    continue;
                }


                var x = det.Left * xRatio;
                var y = det.Top * yRatio;
                var width = det.Width * xRatio;
                var height = det.Height * yRatio;

                e.Graphics.DrawRectangle(Pens.Red, new Rectangle((int)x, (int)y, (int)width, (int)height));

                var detectionOnSecondCam = dets.FirstOrDefault(detection => detection.Class == className && camId != detection.Camera);
                if (detectionOnSecondCam == null)
                {
                    continue;
                }

                double k1, k2, n1, n2;

                GetLineEquationDetection(det, out k1, out n1);
                GetLineEquationDetection(detectionOnSecondCam, out k2, out n2);

                var determinant = k2 - k1;
                if (determinant != 0)
                {
                    var spaceX = (n2 - n1) / determinant;
                    var spaceY = k1 * spaceX + n1;
                    var dist = Math.Sqrt(spaceX * spaceX + spaceY * spaceY) * 100;

                    e.Graphics.DrawString($"{dist.ToString("0.00")} cm", DefaultFont, Brushes.Blue, (int)x - 10, (int)y - 10);
                }

            }
        }

        private void GetLineEquationDetection(Detection det, out double k, out double n)
        {
            // Angle of View ( horizontally) = 34 Degrees
            var horizontalAngleOfViewDeg = 33.0;
            var horizontalAngleOfView = horizontalAngleOfViewDeg * Math.PI / 180;
            // Distance between two cameras = 8 centimeters
            var distanceBetweenCameras = 0.08;
            // Image width is 640
            var imgWidth = 640;
            // Center of detection
            var centerX = det.Left + det.Width / 2;

            var objAngle = horizontalAngleOfView / imgWidth * centerX - horizontalAngleOfView / 2;

            n = det.Camera == 0 ? -distanceBetweenCameras / 2 : distanceBetweenCameras / 2;
            k = Math.Tan(objAngle);
        }
    }
}
