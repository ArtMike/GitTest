using System;

namespace testTechGit
{
    public class MoveRoverForwardCommand : ICommand
    {
        public MoveRoverForwardCommand(Rover rover)
        {
            Rover = rover;
        }

        protected Rover Rover { get; set; }

        public void Execute()
        {
            Rover.MoveForward();
        }
    }
}