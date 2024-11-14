using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class Cradle : IProduct
    {
        public double Volume()
        {
            return 0.4;
        }

        public double Loading()
        {
            return 0.08;
        }

        public double Unloading()
        {
            return 0.05;
        }
    }
}
