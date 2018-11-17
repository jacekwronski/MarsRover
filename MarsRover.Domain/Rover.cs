using System;

namespace MarsRover.Domain
{
    public class Rover
    {
        public Position Position { get; protected set;}
        public Rover() { }

        public void Initialize(int x, int y, DirectionEnum direction)
        {
            this.Position = new Position(x, y, direction);
        }

        public void MoveForward()
        {
            Movement movement = new Movement(this.Position, MovementEnum.Forward);
            this.Position = movement.Move();
        }

        public void MoveBackward()
        {
            Movement movement = new Movement(this.Position, MovementEnum.Backward);
            this.Position = movement.Move();
        }

        public void MoveLeft() 
        {
            Movement movement = new Movement(this.Position, MovementEnum.Left);
            this.Position = movement.Move();
        }

        public void MoveRight()
        {
            Movement movement = new Movement(this.Position, MovementEnum.Right);
            this.Position = movement.Move();
        }
    }
}