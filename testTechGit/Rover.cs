using System;
using System.Collections.Generic;
using System.Linq;

namespace testTechGit
{
    public class Rover
    {
        private const RoverFacing RoverDefaultFacing = RoverFacing.North;

        public Rover()
        {
            RoverPosition = new Position();
            RoverFacing = RoverDefaultFacing;
            Commands = new Dictionary<string, ICommand>
            {
                { "R", new RotateRoverRightCommand(this) },
                { "L", new RotateRoverLeftCommand(this) },
                { "F", new MoveRoverForwardCommand(this) }
            };
        }
        public Rover(RoverFacing roverFacing, Position roverPosition) : this()
        {
            RoverPosition = roverPosition;
            RoverFacing = roverFacing;
        }

        public RoverFacing RoverFacing { get; private set; }
        public Position RoverPosition { get; private set; }
        public Dictionary<string, ICommand> Commands { get; private set; }

        public void RotateRight()
        {
            RoverFacing = RoverFacing == RoverFacing.West ? RoverFacing.North : (RoverFacing)((int)RoverFacing + 1);
            Console.WriteLine($"Rover is now at {RoverPosition.RoverPositionX}, {RoverPosition.RoverPositionY} - facing {RoverFacing}");
        }

        public void RotateLeft()
        {
            RoverFacing = RoverFacing == RoverFacing.North ? RoverFacing.West : (RoverFacing)((int)RoverFacing - 1);
            Console.WriteLine($"Rover is now at {RoverPosition.RoverPositionX}, {RoverPosition.RoverPositionY} - facing {RoverFacing}");

        }

        public void MoveForward()
        {
            switch (RoverFacing)
            {
                case RoverFacing.North:
                    RoverPosition.MoveRoverUp(RoverPosition);
                    break;
                case RoverFacing.East:
                    RoverPosition.MoveRoverForward(RoverPosition);
                    break;
                case RoverFacing.South:
                    RoverPosition.MoveRoverDown(RoverPosition);
                    break;
                case RoverFacing.West:
                    RoverPosition.MoveRoverBack(RoverPosition);
                    break;
                default:
                    throw new ArgumentException("Invalid Rover Facing");
            }
            Console.WriteLine($"Rover is now at {RoverPosition.RoverPositionX}, {RoverPosition.RoverPositionY} - facing {RoverFacing}");

        }

        public void Execute(string command)
        {
            if (Commands.ContainsKey(command))
            {
                Commands[command].Execute();
            }
            else
            {
                throw new ArgumentException("Invalid Command");
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Rover;

            if (other == null)
                return false;

            if (RoverFacing != other.RoverFacing || Commands.OrderBy(kvp => kvp.Key)
                    .SequenceEqual(other.Commands.OrderBy(kvp => kvp.Key)) || !RoverPosition.Equals(other.RoverPosition))
                return false;

            return true;
        }

        public override string ToString()
        {
            return $"Rover is now at {RoverPosition.RoverPositionX}, {RoverPosition.RoverPositionY} - facing {RoverFacing}";
        }
    }
}


