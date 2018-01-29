namespace testTechGit
{
    public class Position
    {
        private const int DefaultRoverPositionX = 1;
        private const int DefaultRoverPositionY = 1;

        public Position() : this(DefaultRoverPositionX, DefaultRoverPositionY)
        {
        }

        public Position(int roverPositionX, int roverPositionY)
        {
            RoverPositionX = roverPositionX;
            RoverPositionY = roverPositionY;
        }

        public int RoverPositionX { get; private set; }
        public int RoverPositionY { get; private set; }

        public void MoveRoverDown(Position position)
        {
            RoverPositionX = position.RoverPositionX < 4 ? ++position.RoverPositionX : position.RoverPositionX;
        }

        public void MoveRoverUp(Position position)
        {
            RoverPositionX = position.RoverPositionX != 0 ? --position.RoverPositionX : position.RoverPositionX;
        }

        public void MoveRoverForward(Position position)
        {
            RoverPositionY = position.RoverPositionY < 4 ? ++position.RoverPositionY : position.RoverPositionY;
        }

        public void MoveRoverBack(Position position)
        {
            RoverPositionY = position.RoverPositionY > 0 ? --position.RoverPositionY : position.RoverPositionY;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Position;

            if (other == null)
                return false;

            if (RoverPositionX != other.RoverPositionX || RoverPositionY != other.RoverPositionY)
                return false;

            return true;
        }
    }
}