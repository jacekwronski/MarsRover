namespace MarsRover.Domain
{
    public class GridPoint
    {
        public int X { get; protected set; }

        public int Y { get; protected set; }
        
        public GridPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}