using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator
{
    internal interface IProduct
    {
        double Volume();
        double Loading();
        double Unloading();
    }
}
