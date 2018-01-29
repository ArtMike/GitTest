using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testTechGit;

namespace testTechGitTest
{
    [TestClass]
    public class RoverTest
    {
        private Rover _rover;
        private Position _roverPosition;

        [TestInitialize]
        public void TestInitialize()
        {
            _rover = new Rover();
            _roverPosition = new Position();
        }

        [DataTestMethod]
        [DataRow(1, RoverFacing.East)]
        [DataRow(2, RoverFacing.South)]
        [DataRow(3, RoverFacing.West)]
        [DataRow(4, RoverFacing.North)]
        public void Rotate_right_test(int index, RoverFacing roverFacing)
        {
            // Arrange
            var expectedRoverFacing = roverFacing;
            var rover = _rover;

            // Act
            for (var i = 0; i < index; i++)
            {
                rover.RotateRight();
            }

            // Assert
            Assert.AreEqual(rover.RoverFacing, expectedRoverFacing);
        }

        [DataTestMethod]
        [DataRow(1, RoverFacing.West)]
        [DataRow(2, RoverFacing.South)]
        [DataRow(3, RoverFacing.East)]
        [DataRow(4, RoverFacing.North)]
        public void Rotate_left_test(int index, RoverFacing roverFacing)
        {
            // Arrange
            var expectedRoverFacing = roverFacing;
            var rover = _rover;

            // Act
            for (var i = 0; i < index; i++)
            {
                rover.RotateLeft();
            }

            // Assert
            Assert.AreEqual(rover.RoverFacing, expectedRoverFacing);
        }

        [DataTestMethod]
        [DataRow(1, 0, 1)]
        [DataRow(2, 0, 1)]
        [DataRow(3, 0, 1)]
        [DataRow(4, 0, 1)]
        public void Move_forward_test(int index, int roverPositionX, int roverPositionY)
        {
            // Arrange
            var expectedRoverPosition = new Position(roverPositionX, roverPositionY);
            var rover = _rover;


            // Act
            for (var i = 0; i < index; i++)
            {
                rover.MoveForward();
            }

            // Assert
            Assert.AreEqual(rover.RoverPosition, expectedRoverPosition);
        }

        [DataTestMethod]
        [DataRow(1, 0, 1)]
        [DataRow(2, 0, 1)]
        [DataRow(3, 0, 1)]
        [DataRow(4, 0, 1)]
        [DataRow(5, 0, 1)]
        public void Position_moveRoverUp_test(int iterationIndex, int expectedRoverPositionX, int expectedRoverPositionY)
        {
            // Arrange
            var startPosition = new Position();
            var expectedPosition = new Position(expectedRoverPositionX, expectedRoverPositionY);
            // Act
            for (int i = 0; i < iterationIndex; i++)
            {
                startPosition.MoveRoverUp(startPosition);
            }
            // Assert
            Assert.AreEqual(expectedPosition, startPosition);
        }

        [TestMethod]
        public void Position_equal_method_test()
        {
            // Arrange
            var position = new Position();
            var samePosition = new Position();

            // Act
            var result = samePosition.Equals(position);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Position_not_equal_method_test()
        {
            // Arrange
            var position = new Position();
            var anotherPosition = new Position(0, 1);

            // Act
            var result = anotherPosition.Equals(position);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Position_isEqual_test()
        {
            // Arrange
            const int roverPositionX = 1;
            const int roverPositionY = 1;
            var roverPosition = new Position(roverPositionX, roverPositionY);
            var sameRoverPosition = new Position(roverPositionX, roverPositionY);

            // Act
            var result = roverPosition.Equals(sameRoverPosition);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Position_isNotEqual_test()
        {
            // Arrange
            const int roverPositionX = 1;
            const int roverPositionY = 1;
            const int anotherRoverPositionX = 0;
            const int anotherRoverPositionY = 0;
            var roverPosition = new Position(roverPositionX, roverPositionY);
            var anotherRoverPosition = new Position(anotherRoverPositionX, anotherRoverPositionY);

            // Act
            var result = roverPosition.Equals(anotherRoverPosition);

            // Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow(1, 2, 1)]
        [DataRow(2, 3, 1)]
        [DataRow(3, 4, 1)]
        [DataRow(4, 4, 1)]
        [DataRow(5, 4, 1)]
        public void Position_moveRoverDown_test(int iterationIndex, int expectedRoverPositionX, int expectedRoverPositionY)
        {
            // Arrange
            var startPosition = new Position();
            var expectedPosition = new Position(expectedRoverPositionX, expectedRoverPositionY);
            // Act
            for (int i = 0; i < iterationIndex; i++)
            {
                startPosition.MoveRoverDown(startPosition);
            }
            // Assert
            Assert.AreEqual(expectedPosition, startPosition);
        }

        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(2, 1, 3)]
        [DataRow(3, 1, 4)]
        [DataRow(4, 1, 4)]
        [DataRow(5, 1, 4)]
        public void Position_moveRoverForward_test(int iterationIndex, int expectedRoverPositionX, int expectedRoverPositionY)
        {
            // Arrange
            var startPosition = new Position();
            var expectedPosition = new Position(expectedRoverPositionX, expectedRoverPositionY);
            // Act
            for (int i = 0; i < iterationIndex; i++)
            {
                startPosition.MoveRoverForward(startPosition);
            }
            // Assert
            Assert.AreEqual(expectedPosition, startPosition);
        }

        [DataTestMethod]
        [DataRow(1, 1, 0)]
        [DataRow(2, 1, 0)]
        [DataRow(3, 1, 0)]
        [DataRow(4, 1, 0)]
        public void Position_moveRoverBack_test(int iterationIndex, int expectedRoverPositionX, int expectedRoverPositionY)
        {
            // Arrange
            var startPosition = new Position();
            var expectedPosition = new Position(expectedRoverPositionX, expectedRoverPositionY);
            // Act
            for (int i = 0; i < iterationIndex; i++)
            {
                startPosition.MoveRoverBack(startPosition);
            }
            // Assert
            Assert.AreEqual(expectedPosition, startPosition);
        }

        [DataTestMethod]
        [DataRow(1, RoverFacing.East)]
        [DataRow(2, RoverFacing.South)]
        [DataRow(3, RoverFacing.West)]
        [DataRow(4, RoverFacing.North)]
        public void Rotate_right_command_test(int index, RoverFacing roverFacing)
        {
            // Arrange
            var expectedRoverFacing = roverFacing;
            var rover = _rover;
            var rotateRoverRightCommand = new RotateRoverRightCommand(rover);

            // Act
            for (var i = 0; i < index; i++)
            {
                rotateRoverRightCommand.Execute();
            }

            // Assert
            Assert.AreEqual(rover.RoverFacing, expectedRoverFacing);
        }

        [DataTestMethod]
        [DataRow(1, RoverFacing.West)]
        [DataRow(2, RoverFacing.South)]
        [DataRow(3, RoverFacing.East)]
        [DataRow(4, RoverFacing.North)]
        public void Rotate_left_command_test(int index, RoverFacing roverFacing)
        {
            // Arrange
            var expectedRoverFacing = roverFacing;
            var rover = _rover;
            var rotateRoverLeftCommand = new RotateRoverLeftCommand(rover);

            // Act
            for (var i = 0; i < index; i++)
            {
                rotateRoverLeftCommand.Execute();
            }

            // Assert
            Assert.AreEqual(rover.RoverFacing, expectedRoverFacing);
        }

        [DataTestMethod]
        [DataRow(1, 0, 1)]
        [DataRow(2, 0, 1)]
        [DataRow(3, 0, 1)]
        [DataRow(4, 0, 1)]
        public void Move_forward_command_test(int index, int roverPositionX, int roverPositionY)
        {
            // Arrange
            var expectedRoverPosition = new Position(roverPositionX, roverPositionY);
            var rover = _rover;
            var motateRoverLeftCommand = new MoveRoverForwardCommand(rover);


            // Act
            for (var i = 0; i < index; i++)
            {
                motateRoverLeftCommand.Execute();
            }

            // Assert
            Assert.AreEqual(rover.RoverPosition, expectedRoverPosition);
        }

        [TestMethod]
        public void Check_command_test()
        {
            // Arrange
            var rover = _rover;
            var expectedCommandDictionary = new Dictionary<string, ICommand>()
            {
                {"R", new RotateRoverRightCommand(rover)},
                {"L", new RotateRoverLeftCommand(rover)},
                {"F", new MoveRoverForwardCommand(rover)}
            };
            // Act
            // Assert
            Assert.IsInstanceOfType(expectedCommandDictionary["R"], typeof(RotateRoverRightCommand));
            Assert.IsInstanceOfType(expectedCommandDictionary["L"], typeof(RotateRoverLeftCommand));
            Assert.IsInstanceOfType(expectedCommandDictionary["F"], typeof(MoveRoverForwardCommand));
        }

        [DataTestMethod]
        [DataRow("R", RoverFacing.East, 1, 1)]
        [DataRow("RR", RoverFacing.South, 1, 1)]
        [DataRow("RRR", RoverFacing.West, 1, 1)]
        [DataRow("RRRR", RoverFacing.North, 1, 1)]
        public void Execute_rotate_rover_right_command_test(string commands, RoverFacing expectedRoverFacing, int expectedRoverPositionX, int expectedRroverPositionY)
        {

            // Arrange
            var expectedRover = new Rover(expectedRoverFacing, new Position(expectedRoverPositionX, expectedRroverPositionY));
            var rover = _rover;

            // Act
            foreach (var command in commands.ToCharArray())
            {
                rover.Execute(command.ToString());
            }

            // Assert
            Assert.AreEqual(expectedRover.RoverPosition, _rover.RoverPosition);
            Assert.AreEqual(expectedRover.RoverFacing, _rover.RoverFacing);
            Assert.IsInstanceOfType(expectedRover.Commands["R"], _rover.Commands["R"].GetType());
            Assert.IsInstanceOfType(expectedRover.Commands["L"], _rover.Commands["L"].GetType());
            Assert.IsInstanceOfType(expectedRover.Commands["F"], _rover.Commands["F"].GetType());
        }

        [TestMethod]
        public void Rover_equal_method_test()
        {
            // Arrange
            var rover = new Rover();
            var sameRover = new Rover();

            // Act
            var result = sameRover.Equals(rover);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rover_equal_method_with_facing_and_position_test()
        {
            // Arrange
            var rover = new Rover(RoverFacing.North, new Position());
            var sameRover = new Rover(RoverFacing.North, new Position());

            // Act
            var result = sameRover.Equals(rover);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rover_not_equal_method_test()
        {
            // Arrange
            var rover = new Rover();
            var anotherRover = new Rover(RoverFacing.East, new Position());

            // Act
            var result = anotherRover.Equals(rover);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rover_not_equal_with_position_and_facing_method_test()
        {
            // Arrange
            var rover = new Rover();
            var anotherRover = new Rover(RoverFacing.East, new Position(1, 2));

            // Act
            var result = anotherRover.Equals(rover);

            // Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow("L", RoverFacing.West, 1, 1)]
        [DataRow("LL", RoverFacing.South, 1, 1)]
        [DataRow("LLL", RoverFacing.East, 1, 1)]
        [DataRow("LLLL", RoverFacing.North, 1, 1)]
        public void Execute_rotate_rover_left_command_test(string commands, RoverFacing expectedRoverFacing, int expectedRoverPositionX, int expectedRroverPositionY)
        {

            // Arrange
            var expectedRover = new Rover(expectedRoverFacing, new Position(expectedRoverPositionX, expectedRroverPositionY));
            var rover = _rover;

            // Act
            foreach (var command in commands.ToCharArray())
            {
                rover.Execute(command.ToString());
            }

            // Assert
            Assert.AreEqual(expectedRover, _rover);
        }

        [DataTestMethod]
        [DataRow("F", RoverFacing.North, 0, 1)]
        [DataRow("FF", RoverFacing.North, 0, 1)]
        [DataRow("FFFFFFFF", RoverFacing.North, 0, 1)]
        public void Execute_command_north_forward(string commands, RoverFacing expectedRoverFacing, int expectedRoverPositionX, int expectedRroverPositionY)
        {
            // Arrange
            var expectedRover = new Rover(expectedRoverFacing, new Position(expectedRoverPositionX, expectedRroverPositionY));
            var rover = _rover;

            // Act
            foreach (var command in commands.ToCharArray())
            {
                rover.Execute(command.ToString());
            }

            // Assert
            Assert.AreEqual(expectedRover, _rover);
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("K")]
        public void Execute_invalid_command(string command)
        {
            // Arrange
            var rover = _rover;

            // Act
            rover.Execute(command);

            // Assert
            //Assert.AreEqual(rover, _rover);
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("")]
        public void Execute_without_command(string command)
        {
            // Arrange
            var rover = _rover;

            // Act
            rover.Execute(command);

            // Assert
        }

        [TestMethod]
        public void Rover_toString_method_test()
        {
            // Arrange
            var rover = new Rover(RoverFacing.East, new Position(1, 2));

            // Act
            var result = rover.ToString();

            // Assert
            Assert.AreEqual(result, "Rover is now at 1, 2 - facing East");
        }
    }
}
