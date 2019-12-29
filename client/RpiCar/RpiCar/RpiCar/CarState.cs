using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpiCar
{
    public class CarState
    {
        public double[] Pose { get; set; }
        public double RearDistance { get; set; }
        public int LeftBlackLine { get; set; }
        public int RightBlackLine { get; set; }
        public int Gear { get; set; }
    }
}
