using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.GameElements
{
    class State
    {
        public Ball Ball { get; set; }
        public Block Paddle { get; set; }
        public Block PrototypeBlock { get; set; }   // Template for all other blocks
        public List<Block> Blocks { get; set; }     // Blocks visible on board

        public State()
        {
            Ball = new Ball();
            Paddle = new Block(15, 80, Brushes.Black);
            PrototypeBlock = new Block();
            Blocks = new List<Block>();
        }

        public void Update(Graphics graphics)
        {
            Ball.Draw(graphics);
            Paddle.Draw(graphics);
            Blocks.ForEach(b => b.Draw(graphics)); // Lambdas!!

        }
    }

}
