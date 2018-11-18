namespace MarsRover.Domain
{
    public interface IMarsService
    {
        Position LandRover(int x, int y, DirectionEnum direction);

        Position MoveRover(string[] commands);
    }
}