using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator
{
    public class RefrigeratorLarge : IProduct
    {
        public double Volume()
        {
            return 1.3;
        }
        public double Loading()
        {
            return 0.2;
        }

        public double Unloading()
        {
            return 0.15;
        }
    }
}
