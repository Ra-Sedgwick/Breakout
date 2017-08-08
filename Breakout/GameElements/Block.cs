using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.GameElements
{
    class Block
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Brush FillColor { get; set; }
        public Position Position { get; set; }
        public bool Moving { get; set; }
        public int Speed { get; set; }

        public Block()
        {
            this.Height = 15;
            this.Width = 65;
            this.FillColor = new SolidBrush(Color.FromArgb(29, 17, 96));
            this.Position = new Position();
            this.Moving = false;
            this.Speed = 2;
        }

        public Block(Position position)
        {
            this.Height = 15;
            this.Width = 65;
            this.FillColor = new SolidBrush(Color.FromArgb(29, 17, 96));
            this.Position = position;
            this.Moving = false;
            this.Speed = 2;
        }

        public Block(int height, int width, Brush color, int speed)
        {
            this.Height = height;
            this.Width = width;
            this.FillColor = color;
            this.Position = new Position();
            this.Moving = false;
            this.Speed = speed;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(FillColor, this.Position.X, this.Position.Y, this.Width, this.Height);

        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(FillColor, this.Position.X, this.Position.Y, this.Width, this.Height);

        }

        public void MoveRight(PictureBox pb)
        {
            if (Position.X + Speed > pb.Width - Width)
            {
                // Hit Wall
            }
            else
            {
                Position.X += Speed;
            }
        }

        public void MoveLeft(PictureBox pb)
        {
            if (Position.X - Speed < 0)
            {
                // Hit Wall
            }
            else
            {
                Position.X -= Speed;
            }
        }
    }
}
