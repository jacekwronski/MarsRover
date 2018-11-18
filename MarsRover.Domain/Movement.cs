using System;
using System.Collections.Generic;

namespace MarsRover.Domain
{
    internal class Movement
    {
        private readonly Dictionary<DirectionEnum, Dictionary<MovementEnum, Func<Position, Position>>> MovementsActuator;

        private readonly Position position;
        private readonly MovementEnum movementType;

        private readonly IWorld world;
        internal Movement(Position position, MovementEnum movementType, IWorld world)
        {
            #region  Validazioni
            if(position == null)
                throw new ArgumentNullException(nameof(position));
            if(world == null)
                throw new ArgumentNullException(nameof(world));
            #endregion

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


        internal Position Move()
        {
            Position newPosition = CalculatePositionByMovement(movementType, position);
            return newPosition;
        }

        internal Position CalculatePositionByMovement(MovementEnum movement, Position position)
        {
            #region Validations
            if(position == null)
                throw new ArgumentNullException(nameof(position));
            #endregion

            Position newPosition = null;

            if (MovementsActuator.ContainsKey(position.Direction) && MovementsActuator[position.Direction].ContainsKey(movement))
                newPosition = MovementsActuator[position.Direction][movement].Invoke(position);

            ValidateMove(newPosition);

            return newPosition;
        }

        private Position CalculatePosition(int x, int y, DirectionEnum direction)
        {
            y = RecalculateYEdges(y);
            x = RecalculateXEdges(x);

            var newPosition = new Position(x, y, direction);

            return newPosition;
        }

        private void ValidateMove(Position newPosition)
        {
            #region Validatios
            if(newPosition == null)
                throw new ArgumentNullException(nameof(newPosition));
            #endregion

            if (this.world.HasObstacleOnCoordinates(newPosition.X, newPosition.Y))
                throw new RoverException("Obstacle detected!!!!", this.position);
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