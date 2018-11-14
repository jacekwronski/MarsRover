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
            rover.Initialize(0, 0, Direction.East);

            Assert.AreEqual(rover.Position.X, 0);
            Assert.AreEqual(rover.Position.Y, 0);
            Assert.AreEqual(rover.Direction, Direction.East);
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
            Assert.AreEqual(rover.Direction, Direction.East);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition00N_MoveForward_FinalPosition01N()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialStateLeftBottomNorth()
                                    .Build();

            rover.MoveForward();

            Assert.AreEqual(rover.Position.X, 0);
            Assert.AreEqual(rover.Position.Y, 1);
            Assert.AreEqual(rover.Direction, Direction.North);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22W_MoveForward_FinalPosition12W()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionWest()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveForward();

            Assert.AreEqual(rover.Position.X, 1);
            Assert.AreEqual(rover.Position.Y, 2);
            Assert.AreEqual(rover.Direction, Direction.West);            
        }

         [TestMethod]
        public void MarsRoverTest_InitialPosition22S_MoveForward_FinalPosition21S()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionSouth()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveForward();

            Assert.AreEqual(rover.Position.X, 2);
            Assert.AreEqual(rover.Position.Y, 1);
            Assert.AreEqual(rover.Direction, Direction.South);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22E_MoveBackward_FinalPosition12E()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionEast()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveBackward();

            Assert.AreEqual(rover.Position.X, 1);
            Assert.AreEqual(rover.Position.Y, 2);
            Assert.AreEqual(rover.Direction, Direction.East);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22W_MoveBackward_FinalPosition32W()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionWest()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveBackward();

            Assert.AreEqual(rover.Position.X, 3);
            Assert.AreEqual(rover.Position.Y, 2);
            Assert.AreEqual(rover.Direction, Direction.West);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22N_MoveBackward_FinalPosition21N()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionNorth()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveBackward();

            Assert.AreEqual(rover.Position.X, 2);
            Assert.AreEqual(rover.Position.Y, 1);
            Assert.AreEqual(rover.Direction, Direction.North);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22S_MoveBackward_FinalPosition23S()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionSouth()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveBackward();

            Assert.AreEqual(rover.Position.X, 2);
            Assert.AreEqual(rover.Position.Y, 3);
            Assert.AreEqual(rover.Direction, Direction.South);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22E_MoveLeft_FinalPosition23N()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionEast()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveLeft();

            Assert.AreEqual(rover.Position.X, 2);
            Assert.AreEqual(rover.Position.Y, 3);
            Assert.AreEqual(rover.Direction, Direction.North);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22W_MoveLeft_FinalPosition21S()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionWest()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveLeft();

            Assert.AreEqual(rover.Position.X, 2);
            Assert.AreEqual(rover.Position.Y, 1);
            Assert.AreEqual(rover.Direction, Direction.South);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22N_MoveLeft_FinalPosition12W()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionNorth()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveLeft();

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(Direction.West, rover.Direction);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22S_MoveLeft_FinalPosition32E()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionSouth()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveLeft();

            Assert.AreEqual(3, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(Direction.East, rover.Direction);            
        }
    }
}