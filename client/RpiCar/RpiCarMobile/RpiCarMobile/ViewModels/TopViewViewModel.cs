using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace RpiCarMobile.ViewModels
{
    public class TopViewViewModel : INotifyPropertyChanged
    {
        private static byte[][] ImgBytes;

        public event PropertyChangedEventHandler PropertyChanged;

        private PlotModel mPlotModel;
        public PlotModel PlotModel { get => mPlotModel; set { mPlotModel = value; OnPropertyChanged(nameof(PlotModel)); } }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        static TopViewViewModel()
        {
            ImgBytes = new byte[][]
            {
                GetImageFromFile("Sign2.png"),
                GetImageFromFile("Sign3.png"),
                GetImageFromFile("Sign1.png"),
                GetImageFromFile("Car.png"),
            };
        }

        private static byte[] GetImageFromFile(string fileName)
        {
            var applicationTypeInfo = Application.Current.GetType().GetTypeInfo();

            byte[] buffer = null;
            using (var stream = applicationTypeInfo.Assembly.GetManifestResourceStream($"{applicationTypeInfo.Namespace}.{fileName}"))
            {
                if (stream != null)
                {
                    long length = stream.Length;
                    buffer = new byte[length];
                    stream.Read(buffer, 0, (int)length);
                }
            }

            return buffer;
        }

        public TopViewViewModel()
        {
            var model = new PlotModel { Title = "Detections" };

            var imgAnnotation = new ImageAnnotation();
            imgAnnotation.ImageSource = new OxyImage(ImgBytes[2]);
            imgAnnotation.X = new PlotLength(-0.159364694116381, PlotLengthUnit.Data);
            imgAnnotation.Y = new PlotLength(0.661608947399751, PlotLengthUnit.Data);
            model.Annotations.Add(imgAnnotation);

            imgAnnotation = new ImageAnnotation();
            imgAnnotation.ImageSource = new OxyImage(ImgBytes[0]);
            imgAnnotation.X = new PlotLength(-0.016360978315527, PlotLengthUnit.Data);
            imgAnnotation.Y = new PlotLength(0.54785705993641, PlotLengthUnit.Data);
            model.Annotations.Add(imgAnnotation);

            imgAnnotation = new ImageAnnotation();
            imgAnnotation.ImageSource = new OxyImage(ImgBytes[1]);
            imgAnnotation.X = new PlotLength(0.0786561431606728, PlotLengthUnit.Data);
            imgAnnotation.Y = new PlotLength(0.690619035549329, PlotLengthUnit.Data);
            model.Annotations.Add(imgAnnotation);

            imgAnnotation = new ImageAnnotation();
            imgAnnotation.ImageSource = new OxyImage(ImgBytes[3]);
            imgAnnotation.X = new PlotLength(0, PlotLengthUnit.Data);
            imgAnnotation.Y = new PlotLength(0, PlotLengthUnit.Data);
            model.Annotations.Add(imgAnnotation);

            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });

            model.Axes[0].Minimum = -1.5;
            model.Axes[0].Maximum = 1.5;

            model.Axes[1].Minimum = -0.5;
            model.Axes[1].Maximum = 1.5;

            PlotModel = model;
        }
    }
}
