using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator
{
    public class BoxspringKing : IProduct
    {
        public double Volume()
        {
            return 0.2;
        }

        public double Loading()
        {
            return 0.03;
        }

        public double Unloading()
        {
            return 0.02;
        }
    }
}
