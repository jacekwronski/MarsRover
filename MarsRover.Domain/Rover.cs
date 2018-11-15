using System;

namespace MarsRover.Domain
{
    public class Rover
    {
        public Position Position { get; protected set;}
        public Rover(){ }

        public void Initialize(int x, int y, DirectionEnum direction)
        {
            this.Position = new Position(x, y, direction);
        }

        public void MoveForward()
        {
            this.Position = CalculatePositionByMovement(MovementEnum.Forward);
        }

        public void MoveBackward()
        {
            this.Position = CalculatePositionByMovement(MovementEnum.Backward);
        }

        public void MoveLeft() 
        {
            MovementEnum movementEnum = MovementEnum.Left;
            this.Position = CalculatePositionByMovement(movementEnum);
        }

        public void MoveRight()
        {
            MovementEnum movementEnum = MovementEnum.Right;
            this.Position = CalculatePositionByMovement(movementEnum);
        }

        private DirectionEnum CalculateDirection(MovementEnum movement)
        {
            DirectionEnum direction;

            if(this.Position.Direction == DirectionEnum.East && movement == MovementEnum.Left)
                direction = DirectionEnum.North;
            else if(this.Position.Direction == DirectionEnum.West && movement == MovementEnum.Left)
                direction = DirectionEnum.South;
            else if(this.Position.Direction == DirectionEnum.North && movement == MovementEnum.Left)
                direction = DirectionEnum.West;
            else if(this.Position.Direction == DirectionEnum.South && movement == MovementEnum.Left)
                direction = DirectionEnum.East;
            else if(this.Position.Direction == DirectionEnum.East && movement == MovementEnum.Right)
                direction = DirectionEnum.South;
            else if(this.Position.Direction == DirectionEnum.West && movement == MovementEnum.Right)
                direction = DirectionEnum.North;
            else if(this.Position.Direction == DirectionEnum.North && movement == MovementEnum.Right)
                direction = DirectionEnum.East;
            else if(this.Position.Direction == DirectionEnum.South && movement == MovementEnum.Right)
                direction = DirectionEnum.West;
            else
                direction = this.Position.Direction;

            return direction;
        }

        private Position CalculatePositionByMovement(MovementEnum movement)
        {
            int x = Position.X;
            int y = Position.Y;

            int increment = Movement.Movements[movement];

            switch (this.Position.Direction)
            {
                case DirectionEnum.East:
                if(movement == MovementEnum.Left)
                    y++;
                else if(movement == MovementEnum.Right)
                    y--;
                else
                    x+=increment;
                break;
                case DirectionEnum.North:
                if(movement == MovementEnum.Left)
                    x--;
                else if(movement == MovementEnum.Right)
                    x++;
                else
                    y+=increment;
                break;
                case DirectionEnum.West:
                if(movement == MovementEnum.Left)
                    y--;
                else if(movement == MovementEnum.Right)
                    y++;
                else
                    x-=increment;
                break;
                case DirectionEnum.South:
                if(movement == MovementEnum.Left)
                    x++;
                else if(movement == MovementEnum.Right)
                    x--;
                else
                    y-=increment;
                break;
            }

            DirectionEnum direction = CalculateDirection(movement);

            var position = new Position(x, y, direction);
            return position;
        }
    }
}