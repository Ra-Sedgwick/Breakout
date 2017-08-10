// Robert Adam Sedgwick

using Breakout.GameElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Breakout
{

    // Class FormView
    // Represents GUI and state of game
    public partial class FormView : Form
    {
        int BallCount = 0;                                      // Number of balls used this game.                                  
        Ball Ball = new Ball();
        Block Paddle = new Block(15, 80, Brushes.Black, 12);
        Block PrototypeBlock = new Block();                    // Base Block all Blocks are built from. 
        List<Block> Blocks = new List<Block>();



        // Set Up Form.
        public FormView()
        {
            InitializeComponent();                                      // Draw inital state of game.
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);        // Reduces Flickering.
        }

        // On Load Draw Initial Game State.
        private void FormView_Load(object sender, EventArgs e)
        {
            InitializeBoard();
        }

        // Update Game State Ever Timer Tick.
        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            // Did The Ball Move Off Screen?
            bool OutOfBounds = Ball.Move(PlayArea);

            if (OutOfBounds)
                ResetBall();

            // Check For Ball/Block Collision & Remove Blocks.
            BlockCollisionDetection();

            // If All Blocks Are Gone, Game Won.
            if (Blocks.Count == 0)
                Win();

            // Triggers PlayArea_Paint():
            PlayArea.Invalidate();
        }

        // Redraw Game Elements.
        private void PlayArea_Paint(object sender, PaintEventArgs e)
        {
            Update(e);
        }


        // Check For Ball/Block Collision, Remove Block If Positive.
        private void BlockCollisionDetection()
        {
            // Check For Collision With Paddel.
            if (Ball.Position.Y + Ball.Direction.Y < Ball.Radius)
            {
                Ball.Direction.Y *= -1;
            }
            else if (Ball.Position.Y + Ball.Direction.Y > PlayArea.Height - Ball.Radius - 10)
            {
                if (Ball.Position.X > Paddle.Position.X && Ball.Position.X < Paddle.Position.X + Paddle.Width)
                {
                    // If Paddle is Moving Speed Ball Up, Else Slow It Down. 
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


            // Check for Block Collisions
            for (int i = 0; i < Blocks.Count; i++)
            {
                if (Ball.Position.X > Blocks[i].Position.X &&
                    Ball.Position.X < Blocks[i].Position.X + PrototypeBlock.Width &&
                    Ball.Position.Y > Blocks[i].Position.Y &&
                    Ball.Position.Y < Blocks[i].Position.Y + Blocks[i].Height)
                {
                    Ball.Direction.Y *= -1;
                    Blocks.Remove(Blocks[i]);
                    break;
                }


            }
        }

        // If Winning State, Update Result Test And Stop Game. 
        private void Win()
        {
            Result.Text = "Winner!";
            DrawTimer.Stop();
        }


        // Redraw Game Elements
        private void Update(PaintEventArgs e)
        {
            Ball.Draw(e);
            Paddle.Draw(e);
            foreach (Block b in Blocks)
            {
                b.Draw(e);
            }
        }

        // Reset ball With Start Position and Random Direction.
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


        // Set up Initial game State. 
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

            // Set Paddle Position
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

            // Set up Text labels. 
            Result.Text = "Ball: " + BallCount;
            Instructions.Text = "Move paddle with arrow, or A and D Keys.";
        }

        // Move Paddel. 
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

        // Reset Movment Flag. 
        private void FormView_KeyUp(object sender, KeyEventArgs e)
        {
            Paddle.Moving = false;
        }

        // Start Game When Clicked. 
        private void Start_Click(object sender, EventArgs e)
        {
            DrawTimer.Start();
            PlayArea.Focus();
        }

        // Pause Game When Clicked. 
        private void Pause_Click(object sender, EventArgs e)
        {
            DrawTimer.Stop();
        }
    }
}
