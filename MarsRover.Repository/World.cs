using System;
using MarsRover.Domain;

namespace MarsRover.Repository
{
    public class World : IWorld
    {
        string obstacleValue = "*";
        string[,] worldMatrix;

        public World(string[,] worldMatrix)
        {
            this.worldMatrix = worldMatrix;
        }

        public int GetTopEdgeYCoordinates()
        {
            return this.worldMatrix.GetLength(1);
        }

        public int GetBottomEdgeYCoordinates()
        {
            return 0;
        }

        public int GetLeftEdgeXCoordinates()
        {
            return 0;
        }

        public int GetRightEdgeXCoordinates()
        {
            return this.worldMatrix.GetLength(0);
        }

        public bool HasObstacleOnCoordinates(int x, int y)
        {
            y = (worldMatrix.GetLength(1) - 1) - y;

            string value = worldMatrix[x,y];

            return value == obstacleValue;
        }
    }
}
