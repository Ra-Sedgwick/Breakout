using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.GameElements
{
    class Logic
    {
        public State State { get; set; }        
        public Panel Board { get; set; }
        public Graphics Graphics { get; set; }
        public int SpacerX { get; set; }                // Space Between Blocks
        public int SpacerY { get; set; }

        public Logic(Panel panel)
        {
            State = new State();
            Board = panel;
            SpacerX = 1;
            SpacerY = 1;
            Graphics = Board.CreateGraphics();
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            // Draw Elements In Start Postiions

            // Set Ball Position
            int X = (Board.Width / 2) - (State.Ball.Radius / 2);
            int Y = (Board.Height / 2) - (State.Ball.Radius / 2);
            State.Ball.Position = new Position(X, Y);
            State.Ball.Direction = new Direction(-1, -1, 1);

            // Set Draw Paddle
            X = (Board.Bounds.Width / 2) -( State.Paddle.Width / 2);
            Y = Board.Bounds.Height - State.Paddle.Height;
            State.Paddle.Position = new Position(X, Y);

            // Draw
            State.Ball.Draw(Graphics);
            State.Paddle.Draw(Graphics);

            // X & Y Boundaries For Blocks
            int XLimit = Board.Bounds.Width - State.PrototypeBlock.Width - SpacerX;
            int YLimit = (Board.Bounds.Height / 2) - State.PrototypeBlock.Height - SpacerY;

            // Fill Top Of Board With Blocks
            for (X = SpacerX; X < XLimit; X += (SpacerX + State.PrototypeBlock.Width))
            {
                for (Y = SpacerY; Y < YLimit; Y += (SpacerY + State.PrototypeBlock.Height))
                {
                    Block Block = new Block(new Position(X, Y));
                    State.Blocks.Add(Block);
                    Block.Draw(Graphics);
                }
            }
            

        }
    }
}
