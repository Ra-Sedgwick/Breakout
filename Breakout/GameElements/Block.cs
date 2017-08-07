using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.GameElements
{

    class Block
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Brush FillColor { get; set; }
        public Position Position { get; set; }

        public Block()
        {
            this.Height = 15;
            this.Width = 65;
            this.FillColor = new SolidBrush(Color.FromArgb(29, 17, 96));
            this.Position = new Position();
        }

        public Block(Position position)
        {
            this.Height = 15;
            this.Width = 65;
            this.FillColor = new SolidBrush(Color.FromArgb(29, 17, 96));
            this.Position = position;
        }

        public Block(int height, int width, Brush color)
        {
            this.Height = height;
            this.Width = width;
            this.FillColor = color;
            this.Position = new Position();
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(FillColor, this.Position.X, this.Position.Y, this.Width, this.Height);

        }
    }
}
