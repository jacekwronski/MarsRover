using NSubstitute;
using MarsRover.Domain;

namespace MarsRover.Test
{
    public class WorldBuilder
    {
        public static IWorld GetDefault5x5World()
        {
            var world = Substitute.For<IWorld>();

            world.GetTopEdgeYCoordinates().Returns(4);
            world.GetBottomEdgeYCoordinates().Returns(0);

            world.GetLeftEdgeXCoordinates().Returns(0);
            world.GetRightEdgeXCoordinates().Returns(4);

            return world;
        }

        public static IWorld Get4x4WorldWithObstacles()
        {
            var world = Substitute.For<IWorld>();

            world.GetTopEdgeYCoordinates().Returns(4);
            world.GetBottomEdgeYCoordinates().Returns(0);

            world.GetLeftEdgeXCoordinates().Returns(0);
            world.GetRightEdgeXCoordinates().Returns(4);

            world.HasObstacleOnCoordinates(Arg.Is(1), Arg.Is(2)).Returns(true);

            return world;
        }
    }
}