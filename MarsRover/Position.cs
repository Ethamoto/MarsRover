using mars_rover.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mars_rover
{
    public class Position
    {
        public CompassDirection DirectionFacing { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set;}
    }
}
