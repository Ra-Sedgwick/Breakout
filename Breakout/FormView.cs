using Breakout.GameElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public partial class FormView : Form
    {

        Ball Ball = new Ball();
        Block Paddle = new Block(15, 80, Brushes.Black, 12);
        Block PrototypeBlock = new Block();
        List<Block> Blocks = new List<Block>();
        int BallCount = 0;

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
            bool OutOfBounds = Ball.Move(PlayArea);

            if (OutOfBounds)
                ResetBall();

            BlockCollisionDetection();


            if (Blocks.Count == 0)
                Win();

            PlayArea.Invalidate();
        }

        private void Win()
        {
            Result.Text = "Winner!";
            DrawTimer.Stop();
        }

        private void BlockCollisionDetection()
        {
            

            if (Ball.Position.Y + Ball.Direction.Y < Ball.Radius)
            {
               
                Ball.Direction.Y *= -1;
            }
            else if (Ball.Position.Y + Ball.Direction.Y > PlayArea.Height - Ball.Radius -10)
            {
                if (Ball.Position.X > Paddle.Position.X && Ball.Position.X < Paddle.Position.X + Paddle.Width)
                {
                    if (Paddle.Moving)
                    {
                        if (Ball.Direction.Y > 0)
                        {
                            Ball.Direction.Y += 1;
                        }
                        else
                        {
                            Ball.Direction.Y -= 1;
                        }
                        if (Ball.Direction.X > 0)
                        {
                            Ball.Direction.X += 1;
                        }
                        else
                        {
                            Ball.Direction.X -= 1;

                        }
                    }
                    else
                    {
                        if (Ball.Direction.X >= 0)
                        {
                            Ball.Direction.X -= 1;
                        }
                        if (Ball.Direction.Y >= 3)
                        {
                            Ball.Direction.Y -= 1;
                        }

                    }
                    
                    Ball.Direction.Y *= -1;
                }
            }


            



            for (int i = 0; i < Blocks.Count; i++)
            {
                if (Ball.Position.X > Blocks[i].Position.X &&
                    Ball.Position.X < Blocks[i].Position.X  + PrototypeBlock.Width &&
                    Ball.Position.Y > Blocks[i].Position.Y &&
                    Ball.Position.Y < Blocks[i].Position.Y + Blocks[i].Height)
                {
                    Ball.Direction.Y *= -1;
                    Blocks.Remove(Blocks[i]);
                    break;
                }


            }
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

        private void ResetBall()
        {
            BallCount++;
            Result.Text = "Ball: " + BallCount;
            Random r = new Random();

            int X = (PlayArea.Width / 2) - (Ball.Radius / 2);
            int Y = (PlayArea.Height / 2) - (Ball.Radius / 2);
            Ball.Position = new Position(X, Y);
            Y = r.Next(-4, 4);
            Ball.Direction = new Direction(Y, 2);
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
            Ball.Direction = new Direction(0, 2);

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

            Result.Text = "Ball: " + BallCount;
            Instructions.Text = "Move paddle with arrow, or A & D Keys.";
        }

        private void FormView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                Paddle.MoveRight(PlayArea);
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                Paddle.Moving = true;
                Paddle.MoveLeft(PlayArea);
            }
        }

        private void FormView_KeyUp(object sender, KeyEventArgs e)
        {
            Paddle.Moving = false;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            DrawTimer.Start();
            PlayArea.Focus();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            DrawTimer.Stop();
        }
    }
}
