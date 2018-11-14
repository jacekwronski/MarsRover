using MarsRover.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test
{
    [TestClass]
    public class MarsRoverTest 
    {
        [TestMethod]
        public void MarsRoverTest_CanInstantiateClass()
        {
            Assert.IsNotNull(new Rover());
        }

        [TestMethod]
        public void MarsRoverTest_InitializPosition0_0_E_InitialiPositionPoint0_0_Direction_E()
        {
            Rover rover = new Rover();
            rover.Initialize(0, 0, "E");

            Assert.AreEqual(rover.Position.X, 0);
            Assert.AreEqual(rover.Position.Y, 0);
            Assert.AreEqual(rover.Direction, "E");
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition00E_MoveForward_FinalPosition10E()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialStateLeftBottomEast()
                                    .Build();

            rover.MoveForward();

            Assert.AreEqual(rover.Position.X, 1);
            Assert.AreEqual(rover.Position.Y, 0);
            Assert.AreEqual(rover.Direction, "E");            
        }
    }
}