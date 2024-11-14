using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator
{
    public class DoubleBedBase : IProduct
    {
        public double Volume()
        {
            return 0.3;
        }

        public double Loading()
        {
            return 0.11;
        }

        public double Unloading()
        {
            return 0.08;
        }
    }
}
