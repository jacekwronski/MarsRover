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
            rover.Initialize(0, 0, DirectionEnum.East);

            Assert.AreEqual(0, rover.Position.X);
            Assert.AreEqual(0, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.East, rover.Position.Direction);
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition00E_MoveForward_FinalPosition10E()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialStateLeftBottomEast()
                                    .Build();

            rover.MoveForward();

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(0, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.East, rover.Position.Direction);            
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
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.North);            
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
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.West);            
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
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.South);            
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
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.East);            
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
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.West);            
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
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.North);            
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
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.South);            
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
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.North);            
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
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.South);            
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
            Assert.AreEqual(DirectionEnum.West, rover.Position.Direction);            
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
            Assert.AreEqual(DirectionEnum.East, rover.Position.Direction);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialiPosition22E_MoveRight_FinalPosition21S()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionEast()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveRight();

            Assert.AreEqual(2, rover.Position.X);
            Assert.AreEqual(1, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.South, rover.Position.Direction);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialiPosition22W_MoveRight_FinalPosition23N()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionWest()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveRight();

            Assert.AreEqual(2, rover.Position.X);
            Assert.AreEqual(3, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.North, rover.Position.Direction);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialiPosition22N_MoveRight_FinalPosition32E()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionNorth()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveRight();

            Assert.AreEqual(3, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.East, rover.Position.Direction);            
        }

        [TestMethod]
        public void MarsRoverTest_InitialiPosition22South_MoveRight_FinalPosition12W()
        {
             Rover rover = new RoverBuilder()
                                    .WithInitialDirectionSouth()
                                    .WithInitialPosition(2,2)
                                    .Build();

            rover.MoveRight();

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.West, rover.Position.Direction);            
        }
    }
}