using Game.GameWorld;

namespace Game.Entities
{
    internal class Creature : IDrawable
    {
        public string Symbol { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
        public Cell Cell { get; }

        public Creature(Cell cell, string symbol)
        {
            Cell = cell;
            Symbol = symbol;
        }

    }
}