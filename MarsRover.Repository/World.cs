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
            return this.worldMatrix.GetLength(1) - 1;
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
            return this.worldMatrix.GetLength(0) - 1;
        }

        public bool HasObstacleOnCoordinates(int x, int y)
        {
            /* Le coordinate hanno il punto 0,0 in basso a sinistra invece la matrice ha il punto 0,0 in alto a sinistra
            per cui devo convertire la y */

            y = (worldMatrix.GetLength(1) - 1) - y;

            string value = worldMatrix[x, y];

            return value == obstacleValue;
        }
    }
}
