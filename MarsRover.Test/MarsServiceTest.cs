using System;
using MarsRover.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;


namespace MarsRover.Test
{
    [TestClass]
    public class MarsServiceTest
    {
        [TestMethod]
        public void MarsServiceTest_CanInstantiate()
        {
            IWorld world = WorldBuilder.GetDefault5x5World();
            Assert.IsNotNull(new MarsService(world));
        }

        [TestMethod]
        public void MarsServiceTest_LandRover_Position23DirE()
        {
            IWorld world = WorldBuilder.GetDefault5x5World();
            var marsService = Substitute.For<MarsService>(world);

            Position position = marsService.LandRover(2, 3, DirectionEnum.East);

            Assert.AreEqual(2, position.X);
            Assert.AreEqual(3, position.Y);
            Assert.AreEqual(DirectionEnum.East, position.Direction);
        }

        [TestMethod]
        public void MarsServiceTest_MoveRoverFFRRLLBB_Start23E_End21E()
        {
            IWorld world = WorldBuilder.GetDefault5x5World();
            var marsService = Substitute.For<MarsService>(world);
            marsService.LandRover(2, 3, DirectionEnum.East);

            string[] commands = { "F", "F", "R", "R", "L", "L", "B", "B" };

            Position position = marsService.MoveRover(commands);

            Assert.AreEqual(2, position.X);
            Assert.AreEqual(1, position.Y);
            Assert.AreEqual(DirectionEnum.East, position.Direction);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MarsServiceTest_MoveRoverFFRRLLBB_Start23E_ObstacleDetected_ExpectedException()
        {
            IWorld world = WorldBuilder.Get4x4WorldWithObstacles();
            var marsService = Substitute.For<MarsService>(world);
            marsService.LandRover(0, 0, DirectionEnum.East);

            string[] commands = { "F", "L", "F" };

            Position position = marsService.MoveRover(commands);
        }
    }
}