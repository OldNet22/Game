namespace Game.GameWorld
{
    internal class Direction
    {
        public static Position West => new Position(0, -1);
        public static Position East => new Position(0, 1);
        public static Position North => new Position(-1, 0);
        public static Position South => new Position(1, 0);
    }
}