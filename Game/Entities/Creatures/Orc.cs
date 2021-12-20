using Game.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities.Creatures
{
    internal class Orc :Creature
    {
        public Orc(Cell cell, int maxHealth, Action<string> addMessage) : base(cell, "O ", maxHealth, addMessage)
        {
            Damage = 40;
            Color = ConsoleColor.Green;
        }
    }
}
