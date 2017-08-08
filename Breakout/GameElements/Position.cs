namespace Breakout.GameElements
{
    class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
