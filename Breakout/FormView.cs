using Breakout.GameElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public partial class FormView : Form
    {

        Ball Ball = new Ball();
        Block Paddle = new Block(15, 80, Brushes.Black);
        Block PrototypeBlock = new Block();
        List<Block> Blocks = new List<Block>();

        public FormView()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }

        private void PlayArea_Paint(object sender, PaintEventArgs e)
        {
            Update(e);

        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            Ball.Move(PlayArea);
            PlayArea.Invalidate();
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            InitializeBoard();
        }

        private void Update(PaintEventArgs e)
        {
            Ball.Draw(e);
            Paddle.Draw(e);
            foreach (Block b in Blocks)
            {
                b.Draw(e);
            }
        }



        private void InitializeBoard()
        {
            Graphics Graphics = PlayArea.CreateGraphics();
            int SpacerX = 1;
            int SpacerY = 1;

            // Set Ball Position
            int X = (PlayArea.Width / 2) - (Ball.Radius / 2);
            int Y = (PlayArea.Height / 2) - (Ball.Radius / 2);
            Ball.Position = new Position(X, Y);
            Ball.Direction = new Direction(2, 2);

            // Set Draw Paddle
            X = (PlayArea.Bounds.Width / 2) - (Paddle.Width / 2);
            Y = PlayArea.Bounds.Height - Paddle.Height;
            Paddle.Position = new Position(X, Y);

            // Draw
            Ball.Draw(Graphics);
            Paddle.Draw(Graphics);

            // X & Y Boundaries For Blocks
            int XLimit = PlayArea.Bounds.Width - PrototypeBlock.Width - SpacerX;
            int YLimit = (PlayArea.Bounds.Height / 2) - PrototypeBlock.Height - SpacerY;

            // Fill Top Of PlayArea With Blocks
            for (X = SpacerX; X < XLimit; X += (SpacerX + PrototypeBlock.Width))
            {
                for (Y = SpacerY; Y < YLimit; Y += (SpacerY + PrototypeBlock.Height))
                {
                    Block Block = new Block(new Position(X, Y));
                    Blocks.Add(Block);
                    Block.Draw(Graphics);
                }
            }
        }
    }
}
