using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpiCar
{
    public class Detection
    {
        public double Confidence { get; set; }
        public string Class { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public DateTime Timestamp { get; set; }
        public int Camera { get; set; }

        public override string ToString()
        {
            return $"{Confidence} {Class} {Left} {Top} {Width} {Height}";
        }
    }
}
