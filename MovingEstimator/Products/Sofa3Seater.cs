using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class Sofa3Seater : IProduct
    {
        public double Volume()
        {
            return 1.3;
        }

        public double Loading()
        {
            return 0.15;
        }

        public double Unloading()
        {
            return 0.10;
        }
    }
}
