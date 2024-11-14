using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class PianoLarge : IProduct
    {
        public double Volume()
        {
            return 1.2;
        }

        public double Loading()
        {
            return 1.5;
        }

        public double Unloading()
        {
            return 0.5;
        }
    }
}
