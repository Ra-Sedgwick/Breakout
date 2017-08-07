using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.GameElements
{
    class Ball
    {
        public int Radius { get; set; }
        public Brush FillColor { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }


        public Ball()
        {
            this.Radius = 15;
            this.FillColor = Brushes.OrangeRed;
            this.Position = new Position();
            this.Direction = new Direction();
        }

        public Ball(int radius, Brush color)
        {
            this.Radius = radius;
            this.FillColor = color;
            this.Position = new Position();
            this.Direction = new Direction();
        }

        public void Draw(Graphics graphic)
        {
            graphic.FillEllipse(this.FillColor, this.Position.X, this.Position.Y, this.Radius, this.Radius);
        }
    }
}
