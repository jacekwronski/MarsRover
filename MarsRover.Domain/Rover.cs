using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MarsRover.Test")]
namespace MarsRover.Domain
{
    public class Rover
    {
        public Position Position { get; protected set;}

        private IWorld myWorld;
        
        public Rover() { }

        internal void Initialize(int x, int y, DirectionEnum direction, IWorld world)
        {
            #region Validations
            if(world == null)
                throw new ArgumentNullException(nameof(world));

            if(AreInitialiCoordinatesValid(x, y, world) == false)
                throw new ArgumentException("Initial position not valid!!!");
            #endregion

            this.Position = new Position(x, y, direction);
            this.myWorld = world;
        }

        private bool AreInitialiCoordinatesValid(int x, int y, IWorld world)
        {
            return x >= world.GetLeftEdgeXCoordinates() && y >= world.GetBottomEdgeYCoordinates() 
            && y <= world.GetTopEdgeYCoordinates() && x <= world.GetRightEdgeXCoordinates();
        }

        internal void MoveForward()
        {
            Movement movement = new Movement(this.Position, MovementEnum.Forward, myWorld);
            this.Position = movement.Move();
        }

        internal void MoveBackward()
        {
            Movement movement = new Movement(this.Position, MovementEnum.Backward, myWorld);
            this.Position = movement.Move();
        }

        internal void MoveLeft() 
        {
            Movement movement = new Movement(this.Position, MovementEnum.Left, myWorld);
            this.Position = movement.Move();
        }

        internal void MoveRight()
        {
            Movement movement = new Movement(this.Position, MovementEnum.Right, myWorld);
            this.Position = movement.Move();
        }

        internal void Move(string[] movements)
        {
            #region Validations
            if(movements == null)
                throw new ArgumentNullException(nameof(movements));
            #endregion

            List<MovementEnum> movementsList = movements.TranslateToMovementsList();

            movementsList.ForEach(x => {
                if(x == MovementEnum.Forward)
                    this.MoveForward();
                if(x == MovementEnum.Backward)
                    this.MoveBackward();
                if(x == MovementEnum.Left)
                    this.MoveLeft();
                if(x == MovementEnum.Right)
                    this.MoveRight();
            });
        }
    }
}