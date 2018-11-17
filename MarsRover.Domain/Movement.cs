using System.Collections.Generic;

namespace  MarsRover.Domain
{
    public class Movement
    {
        public static Dictionary<MovementEnum, int> Movements = new Dictionary<MovementEnum, int>()
        {
            { MovementEnum.Forward, 1 },
            { MovementEnum.Backward, -1 },
            { MovementEnum.Left, 1 },
            { MovementEnum.Right, 1 }       
        };
        private readonly Position position;
        private readonly MovementEnum movementType;
        public Movement(Position position, MovementEnum movementType) 
        {
            this.position = position;
            this.movementType = movementType;
        }

        public Position Move()
        {
            Position newPosition = CalculatePositionByMovement(movementType, position);
            return newPosition;
        }

        private DirectionEnum CalculateDirection(MovementEnum movement, Position position)
        {
            DirectionEnum direction;

            if(position.Direction == DirectionEnum.East && movement == MovementEnum.Left)
                direction = DirectionEnum.North;
            else if(position.Direction == DirectionEnum.West && movement == MovementEnum.Left)
                direction = DirectionEnum.South;
            else if(position.Direction == DirectionEnum.North && movement == MovementEnum.Left)
                direction = DirectionEnum.West;
            else if(position.Direction == DirectionEnum.South && movement == MovementEnum.Left)
                direction = DirectionEnum.East;
            else if(position.Direction == DirectionEnum.East && movement == MovementEnum.Right)
                direction = DirectionEnum.South;
            else if(position.Direction == DirectionEnum.West && movement == MovementEnum.Right)
                direction = DirectionEnum.North;
            else if(position.Direction == DirectionEnum.North && movement == MovementEnum.Right)
                direction = DirectionEnum.East;
            else if(position.Direction == DirectionEnum.South && movement == MovementEnum.Right)
                direction = DirectionEnum.West;
            else
                direction = position.Direction;

            return direction;
        }

        private Position CalculatePositionByMovement(MovementEnum movement, Position position)
        {
            int x = position.X;
            int y = position.Y;

            int increment = Movement.Movements[movement];

            switch (position.Direction)
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

            DirectionEnum direction = CalculateDirection(movement, position);

            var newPosition = new Position(x, y, direction);
            return newPosition;
        }

    }
}