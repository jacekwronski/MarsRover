namespace MarsRover.Domain
{
    public class Position
    {
        public int X { get; protected set; }

        public int Y { get; protected set; }

        public DirectionEnum Direction { get; protected set; }
        
        public Position(int x, int y, DirectionEnum direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }
    }
}