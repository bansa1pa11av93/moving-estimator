using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class PoolTable : IProduct
    {
        public double Volume()
        {
            return 15;
        }

        public double Loading()
        {
            return 3;
        }

        public double Unloading()
        {
            return 3;
        }
    }
}
