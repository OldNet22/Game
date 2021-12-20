using Game.Entities.Creatures;

namespace Game.Entities.Items
{
    internal interface IUsable
    {
        void Use(Creature creature);
    }
}