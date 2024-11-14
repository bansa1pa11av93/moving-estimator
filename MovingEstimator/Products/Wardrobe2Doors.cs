﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Products
{
    public class Wardrobe2Doors : IProduct
    {
        public double Volume()
        {
            return 0.8;
        }

        public double Loading()
        {
            return 0.12;
        }

        public double Unloading()
        {
            return 0.05;
        }
    }
}
