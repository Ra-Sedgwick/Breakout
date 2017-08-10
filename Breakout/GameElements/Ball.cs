// Robert Adam Sedgwick

using System.Drawing;
using System.Windows.Forms;

namespace Breakout.GameElements
{
    class Ball
    {
        public int Radius { get; set; }
        public Brush FillColor { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        // Constructors
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

        // Uses Position and Direction to calcualte ball movement and detect collisions. 
        // Returns false is ball stayed withing game boundries.
        // Return true if ball moved out of bounds. 
        public bool Move(PictureBox pb)
        {

            bool outOfBounds = false;

            // Bounce off left and right boundries.
            if (Position.X + Direction.X > pb.Width - Radius ||
                Position.X + Direction.X < 0)
            {
                Direction.X *= -1;
            }

            // Bounce off top bounder. 
            if (Position.Y + Direction.Y > pb.Height + 100)
            {
                outOfBounds = true;

            }

            if (Position.Y + Direction.Y < 0)
            {
                Direction.Y *= -1;
            }

            // Update Position
            Position.X += Direction.X;
            Position.Y += Direction.Y;
            return outOfBounds;
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
