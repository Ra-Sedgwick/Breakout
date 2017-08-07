using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Breakout.GameElements;

namespace Breakout
{

    public partial class Form1 : Form
    {
        private Logic Logic;

        public Form1()
        {
            InitializeComponent();
            



            // Use double buffering to reduce flicker.
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            this.UpdateStyles();

            Logic = new Logic(GameBoard);
            
        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            Ball Ball = Logic.State.Ball;

            if (Ball.Position.X < Logic.Board.Left)
            {
                Ball.Position.X += Ball.Direction.DeltaX;
            }
            else
            {
                Ball.Direction.DeltaX *= -1;
                Ball.Position.X += Ball.Direction.DeltaX;
            }

            if (Ball.Position.X > Logic.Board.Left)
            {
                Ball.Position.X += Ball.Direction.DeltaX;
            }
            else
            {
                Ball.Direction.DeltaX *= -1;
                Ball.Position.X += Ball.Direction.DeltaX;
            }

            if (Ball.Position.Y > Logic.Board.Bottom)
            {
                Ball.Position.Y += Ball.Direction.DeltaY;
            }
            else
            {
                Ball.Position.Y *= -1;
                Ball.Position.Y += Ball.Direction.DeltaX;
            }

            if (Ball.Position.Y < Logic.Board.Top)
            {
                Ball.Position.Y += Ball.Direction.DeltaY;
            }
            else
            {
                Ball.Position.Y *= -1;
                Ball.Position.Y += Ball.Direction.DeltaX;
            }

            Logic.State.Update(Logic.Graphics);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Logic.InitializeBoard();
            // Sets the timer interval to 5 seconds.
            timer1.Interval = 10;
            timer1.Start();
        }

        
    }
}
