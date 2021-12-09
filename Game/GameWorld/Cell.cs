namespace Game.GameWorld;

public class Cell : IDrawable
{
    public string Symbol => ". ";
    public ConsoleColor Color { get; set; } 

    public Cell()
    {
        Color = ConsoleColor.Red;
    }
}
