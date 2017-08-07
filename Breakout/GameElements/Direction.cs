﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.GameElements
{
    class Direction
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Direction()
        {
            X = Y = 0;
        }

        public Direction(int xy)
        {
            X = Y = xy;
        }

        public Direction(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
