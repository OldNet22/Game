using Game.GameWorld;
using System;

namespace Game.Entities
{
    public class Item : IDrawable
    {
        private readonly string name;
        public string Symbol { get; }
        public ConsoleColor Color { get; set; }

        public Item(string symbol, ConsoleColor color, string name)
        {
            Symbol = symbol;
            Color = color;
            this.name = name;
        }

        public override string ToString() => name;

        public static Item Coin() => new Item("c ", ConsoleColor.Yellow, "Coin");
        public static Item Stone() => new Item("s ", ConsoleColor.Gray, "Stone");
       
    }
}