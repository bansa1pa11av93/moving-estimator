using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class TVStandLarge : IProduct
    {
        public double Volume()
        {
            return 1.2;
        }

        public double Loading()
        {
            return 0.3;
        }

        public double Unloading()
        {
            return 0.2;
        }
    }
}
