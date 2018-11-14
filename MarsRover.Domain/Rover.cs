using System;

namespace MarsRover.Domain
{
    public class Rover
    {
        public GridPoint Position { get; protected set;}
        public Direction Direction { get; protected set; }

        public Rover(){ }

        public void Initialize(int x, int y, Direction direction)
        {
            Position = new GridPoint(x, y);
            this.Direction = direction;
        }

        public void MoveForward()
        {
            int x = Position.X;
            int y = Position.Y;

            switch (this.Direction)
            {
                case Direction.East:
                    x++;
                break;
                case Direction.North:
                    y++;
                break;
                case Direction.West:
                    x--;
                break;
                case Direction.South:
                    y--;
                break;
            }

            this.Position = new GridPoint(x, y);
        }
    }
}