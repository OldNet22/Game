using Game.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities.Creatures
{
    internal class Goblin : Creature
    {
        public Goblin(Cell cell, int maxHealth, Action<string> addMessage) : base(cell, "G ", maxHealth, addMessage)
        {
            Damage = 15;
            Color = ConsoleColor.DarkMagenta;
        }

      
    }
}
