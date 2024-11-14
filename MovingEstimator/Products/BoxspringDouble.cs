﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class BoxspringDouble : IProduct
    {
        public double Volume()
        {
            return 0.25;
        }

        public double Loading()
        {
            return 0.04;
        }

        public double Unloading()
        {
            return 0.03;
        }
    }
}
