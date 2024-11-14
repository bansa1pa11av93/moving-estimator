﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class WardrobeBoxes4Provided : IProduct
    {
        public double Volume()
        {
            return 0.6;
        }

        public double Loading()
        {
            return 0.075;
        }

        public double Unloading()
        {
            return 0.03;
        }
    }
}