using System;
using System.Collections.Generic;

namespace MarsRover.Domain
{
    public class Movement
    {
        public readonly Dictionary<DirectionEnum, Dictionary<MovementEnum, Func<Position, Position>>> MovementsActuator;

        private readonly Position position;
        private readonly MovementEnum movementType;

        private readonly IWorld world;
        public Movement(Position position, MovementEnum movementType, IWorld world)
        {
            this.position = position;
            this.movementType = movementType;
            this.world = world;

            this.MovementsActuator = GenerateMovementActuator();
        }

        private Dictionary<DirectionEnum, Dictionary<MovementEnum, Func<Position, Position>>> GenerateMovementActuator()
        {
            return new Dictionary<DirectionEnum, Dictionary<MovementEnum, Func<Position, Position>>>()
            {
                {
                    DirectionEnum.North, new Dictionary<MovementEnum, Func<Position, Position>>()
                    {
                        { MovementEnum.Forward, (actualPos) => { return CalculatePosition(actualPos.X, actualPos.Y+1, DirectionEnum.North);} },
                        { MovementEnum.Backward, (actualPos) => { return CalculatePosition(actualPos.X, actualPos.Y-1, DirectionEnum.North);} },
                        { MovementEnum.Left, (actualPos) => { return CalculatePosition(actualPos.X-1, actualPos.Y, DirectionEnum.West);} },
                        { MovementEnum.Right, (actualPos) => { return CalculatePosition(actualPos.X+1, actualPos.Y, DirectionEnum.East); } }
                    }
            },
                {
                    DirectionEnum.East, new Dictionary<MovementEnum, Func<Position, Position>>()
                    {
                        { MovementEnum.Forward, (actualPos) => { return CalculatePosition(actualPos.X + 1, actualPos.Y, DirectionEnum.East); } },
                        { MovementEnum.Backward, (actualPos) => { return CalculatePosition(actualPos.X - 1, actualPos.Y, DirectionEnum.East);} },
                        { MovementEnum.Left, (actualPos) => { return CalculatePosition(actualPos.X, actualPos.Y + 1, DirectionEnum.North);} },
                        { MovementEnum.Right, (actualPos) => { return CalculatePosition(actualPos.X, actualPos.Y - 1, DirectionEnum.South); } }
                    }
                },
                {
                    DirectionEnum.South, new Dictionary<MovementEnum, Func<Position, Position>>()
                    {
                        { MovementEnum.Forward, (actualPos) => { return CalculatePosition(actualPos.X, actualPos.Y - 1, DirectionEnum.South); } },
                        { MovementEnum.Backward, (actualPos) => { return CalculatePosition(actualPos.X, actualPos.Y + 1, DirectionEnum.South); } },
                        { MovementEnum.Left, (actualPos) => { return CalculatePosition(actualPos.X + 1, actualPos.Y, DirectionEnum.East); } },
                        { MovementEnum.Right, (actualPos) => { return CalculatePosition(actualPos.X - 1, actualPos.Y, DirectionEnum.West); } }
                    }
                },
                {
                    DirectionEnum.West, new Dictionary<MovementEnum, Func<Position, Position>>()
                    {
                        { MovementEnum.Forward, (actualPos) => { return CalculatePosition(actualPos.X - 1, actualPos.Y, DirectionEnum.West); } },
                        { MovementEnum.Backward, (actualPos) => { return CalculatePosition(actualPos.X + 1, actualPos.Y, DirectionEnum.West); } },
                        { MovementEnum.Left, (actualPos) => { return CalculatePosition(actualPos.X, actualPos.Y - 1, DirectionEnum.South); } },
                        { MovementEnum.Right, (actualPos) => { return CalculatePosition(actualPos.X, actualPos.Y + 1, DirectionEnum.North); } }
                    }
                }
            };
        }


        public Position Move()
        {
            Position newPosition = CalculatePositionByMovement(movementType, position);
            return newPosition;
        }

        private Position CalculatePositionByMovement(MovementEnum movement, Position position)
        {
            Position newPosition = null;

            if (MovementsActuator.ContainsKey(position.Direction) && MovementsActuator[position.Direction].ContainsKey(movement))
                newPosition = MovementsActuator[position.Direction][movement].Invoke(position);

            ValidateMove(newPosition.X, newPosition.Y);

            return newPosition;
        }

        private Position CalculatePosition(int x, int y, DirectionEnum direction)
        {
            y = RecalculateYEdges(y);
            x = RecalculateXEdges(x);

            var newPosition = new Position(x, y, direction);

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