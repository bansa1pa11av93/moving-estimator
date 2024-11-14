using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator
{
    public class RefrigeratorSmall : IProduct
    {
        public double Volume()
        {
            return 0.5;
        }

        public double Loading()
        {
            return 0.15;
        }

        public double Unloading()
        {
            return 0.1;
        }
    }
}
