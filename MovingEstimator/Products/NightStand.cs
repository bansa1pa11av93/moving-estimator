using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class NightStand : IProduct
    {
        public double Volume()
        {
            return 0.3;
        }

        public double Loading()
        {
            return 0.07;
        }

        public double Unloading()
        {
            return 0.05;
        }
    }
}
