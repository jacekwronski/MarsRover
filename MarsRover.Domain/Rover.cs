using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Domain
{
    public class Rover
    {
        private const string LEFT = "L";
        private const string RIGHT = "R";
        private const string FORWARD = "F";
        private const string BACKWARD = "B";
        
        public Position Position { get; protected set;}

        private IWorld myWorld;
        
        public Rover() { }

        public void Initialize(int x, int y, DirectionEnum direction, IWorld world)
        {
            this.Position = new Position(x, y, direction);
            this.myWorld = world;
        }

        public void MoveForward()
        {
            Movement movement = new Movement(this.Position, MovementEnum.Forward, myWorld);
            this.Position = movement.Move();
        }

        public void MoveBackward()
        {
            Movement movement = new Movement(this.Position, MovementEnum.Backward, myWorld);
            this.Position = movement.Move();
        }

        public void MoveLeft() 
        {
            Movement movement = new Movement(this.Position, MovementEnum.Left, myWorld);
            this.Position = movement.Move();
        }

        public void MoveRight()
        {
            Movement movement = new Movement(this.Position, MovementEnum.Right, myWorld);
            this.Position = movement.Move();
        }

        public void Move(string[] movements)
        {
            List<MovementEnum> movementsList = GetMovementsByString(movements);

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

        private List<MovementEnum> GetMovementsByString(string[] movements)
        {
           List<MovementEnum> movementEnumList = new List<MovementEnum>();

            movements.ToList().ForEach(x => {
            if(x.ToUpper() == FORWARD)
                movementEnumList.Add(MovementEnum.Forward);
             if(x.ToUpper() == BACKWARD)
                movementEnumList.Add(MovementEnum.Backward);
             if(x.ToUpper() == LEFT)
                movementEnumList.Add(MovementEnum.Left);
             if(x.ToUpper() == RIGHT)
                movementEnumList.Add(MovementEnum.Right);
            });

            return movementEnumList;
        }
    }
}