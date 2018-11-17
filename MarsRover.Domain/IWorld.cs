namespace MarsRover.Domain
{
    public interface IWorld
    {
        int GetTopEdgeYCoordinates();

        int GetBottomEdgeYCoordinates();

        int GetLeftEdgeXCoordinates();

        int GetRightEdgeXCoordinates();

        bool HasObstacleOnCoordinates(int x, int y);
    }
}