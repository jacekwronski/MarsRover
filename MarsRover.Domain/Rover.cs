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
            this.Position = CalculateGridPoint(MovementEnum.Forward);
        }

        public void MoveBackward()
        {
            this.Position = CalculateGridPoint(MovementEnum.Backward);
        }

        private GridPoint CalculateGridPoint(MovementEnum movement)
        {
            int x = Position.X;
            int y = Position.Y;

            int increment = Movement.Movements[movement];

            switch (this.Direction)
            {
                case Direction.East:
                    x+=increment;
                break;
                case Direction.North:
                    y+=increment;
                break;
                case Direction.West:
                    x-=increment;
                break;
                case Direction.South:
                    y-=increment;
                break;
            }

            var position = new GridPoint(x, y);

            return position;
        }
    }
}