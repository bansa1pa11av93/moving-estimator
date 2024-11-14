using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class Wardrobe1Door : IProduct
    {
        public double Volume()
        {
            return 0.3;
        }

        public double Loading()
        {
            return 0.05;
        }

        public double Unloading()
        {
            return 0.03;
        }
    }
}
