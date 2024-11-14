using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class Suitcases : IProduct
    {
        public double Volume()
        {
            return 0.2;
        }

        public double Loading()
        {
            return 0.01;
        }

        public double Unloading()
        {
            return 0.01;
        }
    }
}
