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

        public void MoveLeft() 
        {
            MovementEnum movementEnum = MovementEnum.Left;

            this.Position = CalculateGridPoint(movementEnum);
            this.Direction = CalculateDirection(movementEnum);
        }

        public void MoveRight()
        {
            MovementEnum movementEnum = MovementEnum.Right;

            this.Position = CalculateGridPoint(movementEnum);
            this.Direction = CalculateDirection(movementEnum);
        }

        private Direction CalculateDirection(MovementEnum movement)
        {
            Direction direction = Direction.Null;

            if(this.Direction == Direction.East && movement == MovementEnum.Left)
                direction = Direction.North;
            else if(this.Direction == Direction.West && movement == MovementEnum.Left)
                direction = Direction.South;
            else if(this.Direction == Direction.North && movement == MovementEnum.Left)
                direction = Direction.West;
            else if(this.Direction == Direction.South && movement == MovementEnum.Left)
                direction = Direction.East;
            else if(this.Direction == Direction.East && movement == MovementEnum.Right)
                direction = Direction.South;
            else if(this.Direction == Direction.West && movement == MovementEnum.Right)
                direction = Direction.North;
             else if(this.Direction == Direction.North && movement == MovementEnum.Right)
                direction = Direction.East;
            else if(this.Direction == Direction.South && movement == MovementEnum.Right)
                direction = Direction.West;

            return direction;
        }

        private GridPoint CalculateGridPoint(MovementEnum movement)
        {
            int x = Position.X;
            int y = Position.Y;

            int increment = Movement.Movements[movement];

            switch (this.Direction)
            {
                case Direction.East:
                if(movement == MovementEnum.Left)
                    y++;
                else if(movement == MovementEnum.Right)
                    y--;
                else
                    x+=increment;
                break;
                case Direction.North:
                if(movement == MovementEnum.Left)
                    x--;
                else if(movement == MovementEnum.Right)
                    x++;
                else
                    y+=increment;
                break;
                case Direction.West:
                if(movement == MovementEnum.Left)
                    y--;
                else if(movement == MovementEnum.Right)
                    y++;
                else
                    x-=increment;
                break;
                case Direction.South:
                 if(movement == MovementEnum.Left)
                    x++;
                else if(movement == MovementEnum.Right)
                    x--;
                else
                    y-=increment;
                break;
            }

            var position = new GridPoint(x, y);

            return position;
        }
    }
}