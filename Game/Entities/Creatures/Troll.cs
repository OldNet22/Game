using Game.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities.Creatures
{
    internal class Troll : Creature
    {
        public Troll(Cell cell, int maxHealth, Action<string> addMessage) : base(cell, "T ", maxHealth, addMessage)
        {
            Damage = 30;
            Color = ConsoleColor.DarkBlue;
        }
    }
}
