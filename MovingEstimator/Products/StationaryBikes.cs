using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class StationaryBikes : IProduct
    {
        public double Volume()
        {
            return 1;
        }

        public double Loading()
        {
            return 0.1;
        }

        public double Unloading()
        {
            return 0.1;
        }
    }
}
