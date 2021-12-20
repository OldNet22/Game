using Game.GameWorld;

namespace Game.Entities.Creatures
{
    internal class Creature : IDrawable
    {
        private Cell cell;
        private int health;
        private string name => this.GetType().Name;

        public string Symbol { get; set; }
        public int MaxHealth { get; }
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
        public int Health
        {
            get => health < 0 ? 0 : health;
            set
            {
                health = value >= MaxHealth ? MaxHealth : value;
            }
        }

        public int Damage { get; set; } = 50;

        public bool IsDead => health <= 0;

        public Action<string> AddMessage { get; set; }

        public Cell Cell
        {
            get => cell;
            set
            {
                ArgumentNullException.ThrowIfNull(nameof(value));
                cell = value;
            }
        }

        public Creature(Cell cell, string symbol, int maxHealth, Action<string> addMessage)
        {
            ArgumentNullException.ThrowIfNull(nameof(cell));
            this.cell = cell;
            Symbol = symbol;
            MaxHealth = maxHealth;
            AddMessage = addMessage;
        }
    }
}