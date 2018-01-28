using System;
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
        public void Rotate_forward_test(int index, int roverPositionX, int roverPositionY)
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
    }
}
