using System;

namespace testTechGit
{
    public class Rover
    {
        public Rover()
        {
            RoverPosition = new Position(1,1);
        }

        public static void Main()
        {
            var roverPositionX = 0;
            var roverPositionY = 0;
            var roverFacing = RoverFacing.North;

            while (true)
            {
                var command = Console.ReadLine();
                if (command != "L" && command != "R" && command != "F")
                    throw new Exception("invalid command");

                switch (command)
                {
                    case "L":

                        //roverFacing = roverFacing == RoverFacing.North ? RoverFacing.West : (RoverFacing)((int)roverFacing - 1);
                        //Console.WriteLine($"Rover is now at {roverPositionX}, {roverPositionY} - facing {roverFacing}");
                        //break;
                    case "R":
                        roverFacing = roverFacing == RoverFacing.West ? RoverFacing.North : (RoverFacing)((int)roverFacing + 1);
                        Console.WriteLine($"Rover is now at {roverPositionX}, {roverPositionY} - facing {roverFacing}");
                        break;
                    case "F":
                        switch (roverFacing)
                        {
                            case RoverFacing.North:
                                roverPositionX++;
                                break;
                            case RoverFacing.East:
                                roverPositionY++;
                                break;
                            case RoverFacing.South:
                                roverPositionX--;
                                break;
                            case RoverFacing.West:
                                roverPositionY--;
                                break;
                        }
                        Console.WriteLine($"Rover is now at {roverPositionX}, {roverPositionY} - facing {roverFacing}");
                        break;
                    default:
                        throw new Exception("invalid command");
                }
            }
        }

        public RoverFacing RoverFacing { get; private set; }
        public Position RoverPosition { get; private set; }

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
            }
            Console.WriteLine($"Rover is now at {RoverPosition.RoverPositionX}, {RoverPosition.RoverPositionY} - facing {RoverFacing}");

        }
    }
}


