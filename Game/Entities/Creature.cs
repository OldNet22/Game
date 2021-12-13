using Game.GameWorld;

namespace Game.Entities
{
    internal class Creature : IDrawable
    {
        private Cell cell;
        public string Symbol { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
        public Cell Cell 
        { 
            get => cell;
            set
            {
                ArgumentNullException.ThrowIfNull(nameof(value));
                cell = value;
            }
        }

        public Creature(Cell cell, string symbol)
        {
            ArgumentNullException.ThrowIfNull(nameof(cell));
            this.cell = cell;
            Symbol = symbol;
        }

    }
}