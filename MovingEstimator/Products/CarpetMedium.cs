using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class CarpetMedium : IProduct
    {
        public double Volume()
        {
            return 0.1;
        }

        public double Loading()
        {
            return 0.02;
        }

        public double Unloading()
        {
            return 0.01;
        }
    }
}
