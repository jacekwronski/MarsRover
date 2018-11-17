using System;
using System.Collections.Generic;

namespace MarsRover.Domain
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


        public static Dictionary<DirectionEnum, Dictionary<MovementEnum, Func<Position, Position>>> MovementsActuator =
                    new Dictionary<DirectionEnum, Dictionary<MovementEnum, Func<Position, Position>>>()
        {
            {
                DirectionEnum.North, new Dictionary<MovementEnum, Func<Position, Position>>()
                {
                    { MovementEnum.Forward, (actualPos) => new Position(actualPos.X, actualPos.Y+1, DirectionEnum.North) },
                    { MovementEnum.Backward, (actualPos) => new Position(actualPos.X, actualPos.Y-1, DirectionEnum.North) },
                    { MovementEnum.Left, (actualPos) => new Position(actualPos.X-1, actualPos.Y, DirectionEnum.West) },
                    { MovementEnum.Right, (actualPos) => new Position(actualPos.X+1, actualPos.Y, DirectionEnum.East) }
                }
            },
            {
                DirectionEnum.East, new Dictionary<MovementEnum, Func<Position, Position>>()
                {
                    { MovementEnum.Forward, (actualPos) => new Position(actualPos.X + 1, actualPos.Y, DirectionEnum.East) },
                    { MovementEnum.Backward, (actualPos) => new Position(actualPos.X - 1, actualPos.Y, DirectionEnum.East) },
                    { MovementEnum.Left, (actualPos) => new Position(actualPos.X, actualPos.Y + 1, DirectionEnum.North) },
                    { MovementEnum.Right, (actualPos) => new Position(actualPos.X, actualPos.Y - 1, DirectionEnum.South) }
                }
            }
        };

        private readonly Position position;
        private readonly MovementEnum movementType;

        private readonly IWorld world;
        public Movement(Position position, MovementEnum movementType, IWorld world)
        {
            this.position = position;
            this.movementType = movementType;
            this.world = world;
        }

        public Position Move()
        {
            Position newPosition = CalculatePositionByMovement(movementType, position);
            return newPosition;
        }

        private DirectionEnum CalculateDirection(MovementEnum movement, Position position)
        {
            DirectionEnum direction;

            if (position.Direction == DirectionEnum.East && movement == MovementEnum.Left)
                direction = DirectionEnum.North;
            else if (position.Direction == DirectionEnum.West && movement == MovementEnum.Left)
                direction = DirectionEnum.South;
            else if (position.Direction == DirectionEnum.North && movement == MovementEnum.Left)
                direction = DirectionEnum.West;
            else if (position.Direction == DirectionEnum.South && movement == MovementEnum.Left)
                direction = DirectionEnum.East;
            else if (position.Direction == DirectionEnum.East && movement == MovementEnum.Right)
                direction = DirectionEnum.South;
            else if (position.Direction == DirectionEnum.West && movement == MovementEnum.Right)
                direction = DirectionEnum.North;
            else if (position.Direction == DirectionEnum.North && movement == MovementEnum.Right)
                direction = DirectionEnum.East;
            else if (position.Direction == DirectionEnum.South && movement == MovementEnum.Right)
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

            Position newPosition = null;

            if (MovementsActuator.ContainsKey(position.Direction) && MovementsActuator[position.Direction].ContainsKey(movement))
                newPosition = MovementsActuator[position.Direction][movement].Invoke(position);

            switch (position.Direction)
            {
                case DirectionEnum.East:
                   break;
                case DirectionEnum.North:
                    break;
                case DirectionEnum.West:
                    if (movement == MovementEnum.Left)
                        y--;
                    else if (movement == MovementEnum.Right)
                        y++;
                    else
                        x -= increment;
                    break;
                case DirectionEnum.South:
                    if (movement == MovementEnum.Left)
                        x++;
                    else if (movement == MovementEnum.Right)
                        x--;
                    else
                        y -= increment;
                    break;
            }

            if (newPosition != null)
            {
                x = newPosition.X;
                y = newPosition.Y;
            }
            y = RecalculateYEdges(y);
            x = RecalculateXEdges(x);

            ValidateMove(x, y);

            DirectionEnum direction = CalculateDirection(movement, position);

            newPosition = new Position(x, y, direction);

            return newPosition;
        }

        private void ValidateMove(int x, int y)
        {
            if (this.world.HasObstacleOnCoordinates(x, y))
                throw new System.Exception("Obstacle detected!!!!");
        }

        private int RecalculateYEdges(int y)
        {
            if (this.world.GetTopEdgeYCoordinates() < y)
                y = this.world.GetBottomEdgeYCoordinates();
            if (this.world.GetBottomEdgeYCoordinates() > y)
                y = this.world.GetTopEdgeYCoordinates();

            return y;
        }

        private int RecalculateXEdges(int x)
        {
            if (this.world.GetLeftEdgeXCoordinates() > x)
                x = this.world.GetRightEdgeXCoordinates();
            if (this.world.GetRightEdgeXCoordinates() < x)
                x = this.world.GetLeftEdgeXCoordinates();

            return x;
        }

    }
}