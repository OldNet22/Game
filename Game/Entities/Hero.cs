using Game.GameWorld;

namespace Game.Entities
{
    internal class Hero : Creature
    {
        public Hero(Cell cell) : base(cell, "H ")
        {
            Color = ConsoleColor.Yellow;
        }
    }
}