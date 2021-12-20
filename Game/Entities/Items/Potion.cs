using Game.Entities.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities.Items
{
    internal class Potion : Item, IUsable
    {
        public Potion(string symbol, ConsoleColor color, string name) : base(symbol, color, name) { }

        public void Use(Creature creature) => creature.Health += 25;

        public static Potion HealthPortion() => new Potion("p ", ConsoleColor.DarkCyan, "Portion");
    }
}
