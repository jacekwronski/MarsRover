using System;
using MarsRover.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;


namespace MarsRover.Test
{
    [TestClass]
    public class MarsRoverTest
    {
        private IWorld GetDefault5x5World()
        {
            var world = Substitute.For<IWorld>();

            world.GetTopEdgeYCoordinates().Returns(4);
            world.GetBottomEdgeYCoordinates().Returns(0);

            world.GetLeftEdgeXCoordinates().Returns(0);
            world.GetRightEdgeXCoordinates().Returns(4);

            return world;
        }

        private IWorld Get4x4WorldWithObstacles()
        {
            var world = Substitute.For<IWorld>();

            world.GetTopEdgeYCoordinates().Returns(4);
            world.GetBottomEdgeYCoordinates().Returns(0);

            world.GetLeftEdgeXCoordinates().Returns(0);
            world.GetRightEdgeXCoordinates().Returns(4);

            world.HasObstacleOnCoordinates(Arg.Is(1), Arg.Is(2)).Returns(true);

            return world;
        }

        [TestMethod]
        public void MarsRoverTest_CanInstantiateClass()
        {
            Assert.IsNotNull(new Rover());
        }

        [TestMethod]
        public void MarsRoverTest_InitializPosition0_0_E_InitialiPositionPoint0_0_Direction_E()
        {
            Rover rover = new Rover();

            IWorld world = GetDefault5x5World();
            rover.Initialize(0, 0, DirectionEnum.East, world);

            Assert.AreEqual(0, rover.Position.X);
            Assert.AreEqual(0, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.East, rover.Position.Direction);
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition00E_MoveForward_FinalPosition10E()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
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
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
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
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionWest()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveForward();

            Assert.AreEqual(rover.Position.X, 1);
            Assert.AreEqual(rover.Position.Y, 2);
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.West);
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22S_MoveForward_FinalPosition21S()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionSouth()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveForward();

            Assert.AreEqual(rover.Position.X, 2);
            Assert.AreEqual(rover.Position.Y, 1);
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.South);
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22E_MoveBackward_FinalPosition12E()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionEast()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveBackward();

            Assert.AreEqual(rover.Position.X, 1);
            Assert.AreEqual(rover.Position.Y, 2);
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.East);
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22W_MoveBackward_FinalPosition32W()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionWest()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveBackward();

            Assert.AreEqual(rover.Position.X, 3);
            Assert.AreEqual(rover.Position.Y, 2);
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.West);
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22N_MoveBackward_FinalPosition21N()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionNorth()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveBackward();

            Assert.AreEqual(rover.Position.X, 2);
            Assert.AreEqual(rover.Position.Y, 1);
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.North);
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22S_MoveBackward_FinalPosition23S()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionSouth()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveBackward();

            Assert.AreEqual(rover.Position.X, 2);
            Assert.AreEqual(rover.Position.Y, 3);
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.South);
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22E_MoveLeft_FinalPosition23N()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionEast()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveLeft();

            Assert.AreEqual(rover.Position.X, 2);
            Assert.AreEqual(rover.Position.Y, 3);
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.North);
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22W_MoveLeft_FinalPosition21S()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionWest()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveLeft();

            Assert.AreEqual(rover.Position.X, 2);
            Assert.AreEqual(rover.Position.Y, 1);
            Assert.AreEqual(rover.Position.Direction, DirectionEnum.South);
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22N_MoveLeft_FinalPosition12W()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionNorth()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveLeft();

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.West, rover.Position.Direction);
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition22S_MoveLeft_FinalPosition32E()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionSouth()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveLeft();

            Assert.AreEqual(3, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.East, rover.Position.Direction);
        }

        [TestMethod]
        public void MarsRoverTest_InitialiPosition22E_MoveRight_FinalPosition21S()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionEast()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveRight();

            Assert.AreEqual(2, rover.Position.X);
            Assert.AreEqual(1, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.South, rover.Position.Direction);
        }

        [TestMethod]
        public void MarsRoverTest_InitialiPosition22W_MoveRight_FinalPosition23N()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionWest()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveRight();

            Assert.AreEqual(2, rover.Position.X);
            Assert.AreEqual(3, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.North, rover.Position.Direction);
        }

        [TestMethod]
        public void MarsRoverTest_InitialiPosition22N_MoveRight_FinalPosition32E()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionNorth()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveRight();

            Assert.AreEqual(3, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.East, rover.Position.Direction);
        }

        [TestMethod]
        public void MarsRoverTest_InitialiPosition22South_MoveRight_FinalPosition12W()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                   .WithInitialDirectionSouth()
                                   .WithInitialPosition(2, 2)
                                   .Build();

            rover.MoveRight();

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.West, rover.Position.Direction);
        }

        [TestMethod]
        public void MarsRoverTest_TopEdgeMoveForward_RoverStepInBottomEdge()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                .WithInitialDirectionNorth()
                                .WithInitialPosition(4, world.GetTopEdgeYCoordinates())
                                .Build();

            rover.MoveForward();
            Assert.AreEqual(world.GetBottomEdgeYCoordinates(), rover.Position.Y);
        }


        [TestMethod]
        public void MarsRoverTest_ButtomEdgeDirSouth_MoveForward_RoverStepInTopEdge()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                .WithInitialDirectionSouth()
                                .WithInitialPosition(0, world.GetBottomEdgeYCoordinates())
                                .Build();

            rover.MoveForward();
            Assert.AreEqual(world.GetTopEdgeYCoordinates(), rover.Position.Y);
        }

        [TestMethod]
        public void MarsRoverTest_ButtomEdgeDirEast_Moveright_RoverStepInTopEdge()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                   .WithWorld(world)
                                .WithInitialDirectionEast()
                                .WithInitialPosition(0, world.GetBottomEdgeYCoordinates())
                                .Build();

            rover.MoveRight();
            Assert.AreEqual(world.GetTopEdgeYCoordinates(), rover.Position.Y);
        }

        [TestMethod]
        public void MarsRoverTest_ButtomEdgeDirWest_MoveLeft_RoverStepInTopEdge()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionWest()
                                .WithInitialPosition(0, world.GetBottomEdgeYCoordinates())
                                .Build();

            rover.MoveLeft();
            Assert.AreEqual(world.GetTopEdgeYCoordinates(), rover.Position.Y);
        }

        [TestMethod]
        public void MarsRoverTest_TopEdgeDirEast_MoveLeft_RoverStepInBottomEdge()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionEast()
                                .WithInitialPosition(0, world.GetTopEdgeYCoordinates())
                                .Build();

            rover.MoveLeft();
            Assert.AreEqual(world.GetBottomEdgeYCoordinates(), rover.Position.Y);
        }

        [TestMethod]
        public void MarsRoverTest_TopEdgeDirWest_MoveRight_RoverStepInBottomEdge()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionWest()
                                .WithInitialPosition(0, world.GetTopEdgeYCoordinates())
                                .Build();

            rover.MoveRight();
            Assert.AreEqual(world.GetBottomEdgeYCoordinates(), rover.Position.Y);
        }

        [TestMethod]
        public void MarsRoverTest_LeftEdgeDirWest_MoveForward_RoverStepInRightEdge()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionWest()
                                .WithInitialPosition(world.GetLeftEdgeXCoordinates(), 3)
                                .Build();

            rover.MoveForward();
            Assert.AreEqual(world.GetRightEdgeXCoordinates(), rover.Position.X);
        }

        [TestMethod]
        public void MarsRoverTest_RightEdgeDirEast_MoveForward_RoverStepInLeftEdge()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionEast()
                                .WithInitialPosition(world.GetRightEdgeXCoordinates(), 3)
                                .Build();

            rover.MoveForward();
            Assert.AreEqual(world.GetLeftEdgeXCoordinates(), rover.Position.X);
        }

        [TestMethod]
        public void MarsRoverTest_LeftEdgeDirNorth_MoveLeft_RoverStepInRightEdge()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionNorth()
                                .WithInitialPosition(world.GetLeftEdgeXCoordinates(), 3)
                                .Build();

            rover.MoveLeft();
            Assert.AreEqual(world.GetRightEdgeXCoordinates(), rover.Position.X);
        }

        [TestMethod]
        public void MarsRoverTest_LeftEdgeDirSouth_MoveRight_RoverStepInRightEdge()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionSouth()
                                .WithInitialPosition(world.GetLeftEdgeXCoordinates(), 3)
                                .Build();

            rover.MoveRight();
            Assert.AreEqual(world.GetRightEdgeXCoordinates(), rover.Position.X);
        }

        [TestMethod]
        public void MarsRoverTest_RightEdgeDirNorth_MoveRight_RoverStepInLeftEdge()
        {
            IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionNorth()
                                .WithInitialPosition(world.GetRightEdgeXCoordinates(), 3)
                                .Build();

            rover.MoveRight();
            Assert.AreEqual(world.GetLeftEdgeXCoordinates(), rover.Position.X);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MarsRoverTest_MoveLeft_ObstacleEncountred()
        {
            IWorld world = Get4x4WorldWithObstacles();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionNorth()
                                .WithInitialPosition(2, 2)
                                .Build();

            rover.MoveLeft();
        }

        [TestMethod]
        public void MarsRoverTest_InitialPosition11DirE_SendCommands_LFFR_FinalPosition_32E()
        {
             IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionEast()
                                .WithInitialPosition(1, 1)
                                .Build();

            string[] movements = { "L", "F", "F", "R" };

            
            rover.Move(movements);

            Assert.AreEqual(2, rover.Position.X);
            Assert.AreEqual(4, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.East, rover.Position.Direction);
        }

        [TestMethod]
         public void MarsRoverTest_InitialPosition11DirE_SendCommands_LRFFFF_FinalPosition_12E()
        {
             IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionEast()
                                .WithInitialPosition(1, 1)
                                .Build();

            string[] movements = { "L", "R", "F", "F", "F" };

            
            rover.Move(movements);

            Assert.AreEqual(0, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.East, rover.Position.Direction);
        }

        [TestMethod]
         public void MarsRoverTest_InitialPosition11DirE_SendCommands_LRFFFFF_FinalPosition_12E()
        {
             IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionEast()
                                .WithInitialPosition(1, 1)
                                .Build();

            string[] movements = { "L", "R", "F", "F", "F", "F" };

            
            rover.Move(movements);

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.East, rover.Position.Direction);
        }

        [TestMethod]
         public void MarsRoverTest_InitialPosition11DirE_SendCommands_LRFFFFFL_FinalPosition_13N()
        {
             IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionEast()
                                .WithInitialPosition(1, 1)
                                .Build();

            string[] movements = { "L", "R", "F", "F", "F", "F", "L" };

            
            rover.Move(movements);

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(3, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.North, rover.Position.Direction);
        }

        [TestMethod]
         public void MarsRoverTest_InitialPosition11DirE_SendCommands_LRFFFFFLR_FinalPosition_23E()
        {
             IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionEast()
                                .WithInitialPosition(1, 1)
                                .Build();

            string[] movements = { "L", "R", "F", "F", "F", "F", "L", "R" };

            
            rover.Move(movements);

            Assert.AreEqual(2, rover.Position.X);
            Assert.AreEqual(3, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.East, rover.Position.Direction);
        }

        [TestMethod]
         public void MarsRoverTest_InitialPosition11DirE_SendCommands_LRFFFFFLRL_FinalPosition_24N()
        {
             IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionEast()
                                .WithInitialPosition(1, 1)
                                .Build();

            string[] movements = { "L", "R", "F", "F", "F", "F", "L", "R", "L" };

            
            rover.Move(movements);

            Assert.AreEqual(2, rover.Position.X);
            Assert.AreEqual(4, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.North, rover.Position.Direction);
        }

        [TestMethod]
         public void MarsRoverTest_InitialPosition11DirE_SendCommands_LRFFFFFLRLF_FinalPosition_20N()
        {
             IWorld world = GetDefault5x5World();

            Rover rover = new RoverBuilder()
                                .WithWorld(world)
                                .WithInitialDirectionEast()
                                .WithInitialPosition(1, 1)
                                .Build();

            string[] movements = { "L", "R", "F", "F", "F", "F", "L", "R", "L", "F" };

            
            rover.Move(movements);

            Assert.AreEqual(2, rover.Position.X);
            Assert.AreEqual(0, rover.Position.Y);
            Assert.AreEqual(DirectionEnum.North, rover.Position.Direction);
        }
    }
}