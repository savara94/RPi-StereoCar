using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RpiCarMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StreamPage : ContentPage
    {
        public StreamPage()
        {
            InitializeComponent();

            leftCam.PaintSurface += PaintSurface;
            rightCam.PaintSurface += PaintSurface;
        }

        private void PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Red,
                StrokeWidth = 50
            };

            canvas.DrawRect(new SKRect(50, 50, 200, 200), paint);
        }
    }
}