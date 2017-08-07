using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.GameElements
{
    class Direction
    {
        public int DeltaX { get; set; }
        public int DeltaY { get; set; }
        public int Speed { get; set; }

        public Direction()
        {
            DeltaX = DeltaY = Speed = 0;
        }

        public Direction(int deltaX, int deltaY)
        {
            DeltaX = deltaX;
            DeltaY = DeltaY;
            Speed = 0;
        }

        public Direction(int deltaX, int deltaY, int speed)
        {
            DeltaX = deltaX;
            DeltaY = deltaY;
            Speed = speed;
        }
    }
}
