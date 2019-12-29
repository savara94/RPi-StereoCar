using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RpiCar
{
    public enum GearCommand
    {
        Up,
        Down
    }

    public enum MoveCommand
    {
        FORWARD,
        Backward,
        Left,
        Right
    }

    public enum CameraDevice
    {
        LEFT,
        RIGHT
    }

    public class RpiCar
    {
        private string IpAddress;
        private string URL;
        private double Baseline;
        private HttpClient HttpClient;
        private CameraParameters LeftCamParams;
        private CameraParameters RightCamParams;

        public RpiCar(string ipAddress, int port, double baseline, CameraParameters leftCam, CameraParameters rightCam)
        {
            IpAddress = ipAddress;
            URL = $"http://{IpAddress}:{port}";
            HttpClient = new HttpClient();

            LeftCamParams = leftCam;
            RightCamParams = rightCam;

            Baseline = baseline;
        }

        public async Task<bool> IsAliveAsync()
        {
            using (var response = await HttpClient.GetAsync(URL))
            {
                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(jsonString);

                    if (json["message"].ToString() == "OK")
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public async Task<JObject> TrackAsync()
        {
            try
            {
                var uri = $"{URL}/car/track";
                var content = new StringContent("{}", Encoding.UTF8, "application/json");
                var response = await HttpClient.PostAsync(uri, content);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(jsonResponse);
                return json;
            }
            catch
            {
                return null;
            }
        }

        public async Task<JObject> ResetAsync()
        {
            try
            {
                var uri = $"{URL}/car/reset";
                var content = new StringContent("{}", Encoding.UTF8, "application/json");
                var response = await HttpClient.PostAsync(uri, content);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(jsonResponse);
                return json;
            }
            catch
            {
                return null;
            }
        }

        public async Task<JObject> ChangeGearAsync(GearCommand cmd)
        {
            var gear = string.Empty;

            switch (cmd)
            {
                case GearCommand.Up:
                    gear = "gear_up";
                    break;
                case GearCommand.Down:
                    gear = "gear_down";
                    break;
                default:
                    throw new ArgumentException();
            }

            try
            {
                var json = JObject.Parse($"{{'gear':'{gear}'}}");
                var uri = $"{URL}/car/gear";
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                var response = await HttpClient.PostAsync(uri, content);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                json = JObject.Parse(jsonResponse);
                return json;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Bitmap> GetCameraFeedAsync(CameraDevice cam)
        {
            var id = (int)cam;
            var uri = $"{URL}/car/video_feed/{id}";
            var img = await LoadImage(new Uri(uri));

            return img;
        }

        private async Task<Bitmap> LoadImage(Uri uri)
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
            catch
            {

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

        public async Task<bool> Move(MoveCommand cmd)
        {
            var parameter = string.Empty;

            switch (cmd)
            {
                case MoveCommand.FORWARD:
                    parameter = "forward";
                    break;
                case MoveCommand.Backward:
                    parameter = "backward";
                    break;
                case MoveCommand.Left:
                    parameter = "left";
                    break;
                case MoveCommand.Right:
                    parameter = "right";
                    break;
            }

            try
            {
                var json = JObject.Parse($"{{'direction':'{parameter}'}}");
                var uri = $"{URL}/car/move";
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                var response = await HttpClient.PostAsync(uri, content);
                return true;
            }
            catch
            {
                return false;
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

        public async Task<IEnumerable<Detection>> GetDetectionsAsync()
        {
            var uri = $"{URL}/car/detections";
            var list = new List<Detection>();

            var json = await IssueRequest(uri);
            if (json != null)
            {
                var camDetections = (JArray)json["detections"];
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
            }

            return list;
        }

        public IEnumerable<Sign> DetectionsToWorldCoords(IEnumerable<Detection> detections)
        {
            var list = new List<Sign>();

            var leftDetections = detections.Where(x => x.Camera == (int)CameraDevice.LEFT).ToList();
            var rightDetections = detections.Where(x => x.Camera == (int)CameraDevice.RIGHT).ToList();

            foreach(var leftDetection in leftDetections)
            {
                var rightDetection = rightDetections.FirstOrDefault(x => x.Class == leftDetection.Class);

                if (rightDetection == null)
                {
                    continue;
                }

                double k1, k2, n1, n2;

                GetLineEquationDetection(leftDetection, out k1, out n1);
                GetLineEquationDetection(rightDetection, out k2, out n2);

                double posX, posY;

                if (Intersection(k1, n1, k2,n2, out posX, out posY))
                {
                    list.Add(new Sign
                    {
                        Name = leftDetection.Class,
                        X = posX,
                        Y = posY
                    });
                }
            }

            return list;
        }

        private bool Intersection(double k1, double n1, double k2, double n2, out double x, out double y)
        {
            x = double.NaN;
            y = double.NaN;

            var determinant = k2 - k1;
            if (determinant == 0)
            {
                return false;
            }

            x = -(n2 - n1) / determinant;
            y = k1 * x + n1;
            return true;
        }

        private void GetLineEquationDetection(Detection det, out double k, out double n)
        {
            var camParams = det.Camera == (int)CameraDevice.LEFT ? LeftCamParams : RightCamParams;
            var camSide = det.Camera == (int)CameraDevice.LEFT ? -1 : 1;
            var offset = Baseline / 2 * camSide;
            var pixelX = det.Left + det.Width / 2;

            k = Math.Tan(Math.PI / 2 - Math.Atan((pixelX - camParams.Cx)/ camParams.Fx));
            n = -k * offset;
        }

        public async Task<CarState> GetCarStateAsync()
        {
            var uri = $"{URL}/car/information";

            var dict = new Dictionary<string, object>();

            var json = await IssueRequest(uri);
            if (json != null)
            {
                try
                {
                    var carState = new CarState
                    {
                        Gear = json["arexx"]["gear"].ToObject<int>(),
                        LeftBlackLine = json["arexx"]["left_line"].ToObject<int>(),
                        RightBlackLine = json["arexx"]["right_line"].ToObject<int>(),
                        Pose = json["arexx"]["pose"].ToObject<double[]>(),
                        RearDistance = json["arexx"]["distances"][0].ToObject<double>()
                    };

                    return carState;
                }
                catch
                {

                }
            }

            return null;
        }
    }
}
