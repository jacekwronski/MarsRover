using System;

namespace MarsRover.Domain
{
    public class Rover
    {
        public GridPoint Position { get; protected set;}
        public string Direction { get; protected set; }

        public Rover(){ }

        public void Initialize(int x, int y, string direction)
        {
            Position = new GridPoint(x, y);
            this.Direction = direction;
        }

        public void MoveForward()
        {
            int x = Position.X;
            int y = Position.Y;

            switch (this.Direction)
            {
                case "E":
                    x++;
                break;
            }

            this.Position = new GridPoint(x, y);

        }
    }
}