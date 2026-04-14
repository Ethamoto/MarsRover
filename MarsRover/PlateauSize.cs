using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace mars_rover
{
    internal class PlateauSize
    {
        public int XBoundry { get; set; } = 0;
        public int YBoundry { get; set; } = 0;

        public PlateauSize(int xBoundry, int yBoundry) 
        {
            XBoundry = xBoundry;
            YBoundry = yBoundry;
        
        }
    }
}
