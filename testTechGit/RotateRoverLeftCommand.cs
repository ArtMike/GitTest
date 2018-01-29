namespace testTechGit
{
    public class RotateRoverLeftCommand : ICommand
    {
        protected Rover Rover { get; set; }

        public RotateRoverLeftCommand(Rover rover)
        {
            Rover = rover;
        }

        public void Execute()
        {
            Rover.RotateLeft();
        }
    }
}