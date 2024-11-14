using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class YourBoxesApproximate : IProduct
    {
        public double Volume()
        {
            return 0.15;
        }

        public double Loading()
        {
            return 0.015;
        }

        public double Unloading()
        {
            return 0.01;
        }
    }
}
