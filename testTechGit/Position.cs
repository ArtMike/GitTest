namespace testTechGit
{
    public class Position
    {
        private const int DefaultRoverPositionX = 1;
        private const int DefaultRoverPositionY = 1;
        private const int DefaultLeftLimit = 0;
        private const int DefaultRightLimit = 4;
        private const int DefaultTopLimit = 0;
        private const int DefaultBottomLimit = 4;

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
            RoverPositionX = position.RoverPositionX < DefaultBottomLimit ? ++position.RoverPositionX : position.RoverPositionX;
        }

        public void MoveRoverUp(Position position)
        {
            RoverPositionX = position.RoverPositionX != DefaultTopLimit ? --position.RoverPositionX : position.RoverPositionX;
        }

        public void MoveRoverForward(Position position)
        {
            RoverPositionY = position.RoverPositionY < DefaultRightLimit ? ++position.RoverPositionY : position.RoverPositionY;
        }

        public void MoveRoverBack(Position position)
        {
            RoverPositionY = position.RoverPositionY > DefaultLeftLimit ? --position.RoverPositionY : position.RoverPositionY;
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

        public override int GetHashCode()
        {
            var hashCode = -1297045493;
            hashCode = hashCode * -1521134295 + RoverPositionX.GetHashCode();
            hashCode = hashCode * -1521134295 + RoverPositionY.GetHashCode();
            return hashCode;
        }
    }
}