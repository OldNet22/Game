using Game.Entities.Items;
using Game.GameWorld;
using Game.LimitedList;

namespace Game.Entities.Creatures
{
    internal class Hero : Creature
    {
        public LimitedList<Item> BackPack { get; }


        public Hero(Cell cell, Action<String> addMessage) : base(cell, "H ", 100, addMessage)
        {
            Color = ConsoleColor.Yellow;
            BackPack = new LimitedList<Item>(3); //ToDo Read from config
        }
    }
}