using System;

namespace testTechGit
{
    public class RotateRoverRightCommand : ICommand
    {
        public RotateRoverRightCommand(Rover rover)
        {
            Rover = rover;
        }

        protected Rover Rover { get; set; }

        public void Execute()
        {
            Rover.RotateRight();
        }
    }
}