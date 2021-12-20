using Game.GameWorld;

namespace Game.Entities.Creatures
{
    internal class Creature : IDrawable
    {
        private Cell cell;
        private int health;
        private ConsoleColor color;

        private string name => this.GetType().Name;

        public string Symbol { get; set; }
        public int MaxHealth { get; }
        public ConsoleColor Color
        {
            get => IsDead ? ConsoleColor.Gray : color;
            set => color = value;
        }
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
            health = maxHealth;
            AddMessage = addMessage;
            Color = ConsoleColor.Green;
        }

        public void Attack(Creature target)
        {
            if (target.IsDead) return;

            var thisName = this.name;
            var targetName = target.name;

            target.Health -= Damage;
            AddMessage?.Invoke($"The {thisName} attacks the {targetName} for {this.Damage}");

            if (target.IsDead)
            {
                AddMessage?.Invoke($"The {targetName} is dead");
                return;
            }

            Health -= target.Damage;
            AddMessage?.Invoke($"The {targetName} attacks the {thisName} for {target.Damage}");

            if (IsDead)
            {
                AddMessage?.Invoke($"The {thisName} is dead");
                return;
            }

        }

    }
}