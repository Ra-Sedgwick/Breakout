using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public bool Move(PictureBox pb)
        {
            
            if ( Position.X + Direction.X > pb.Width - Radius ||
                 Position.X + Direction.X < 0)
            {
                Direction.X *= -1;
            }

            if ( Position.Y + Direction.Y > pb.Height + 100 ||
                 Position.Y + Direction.Y < 0)
            {
                return true;
            }

            Position.X += Direction.X;
            Position.Y += Direction.Y;
            return false;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(this.FillColor, this.Position.X, this.Position.Y, this.Radius, this.Radius);
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(this.FillColor, this.Position.X, this.Position.Y, this.Radius, this.Radius);
        }
    }
}
