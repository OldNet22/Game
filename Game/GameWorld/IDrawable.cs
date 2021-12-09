namespace Game.GameWorld
{
    public interface IDrawable
    {
         string Symbol { get; }
         ConsoleColor Color { get; set; }
    }
}