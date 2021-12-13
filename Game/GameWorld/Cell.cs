namespace Game.GameWorld;

public class Cell : IDrawable
{
    public int Y { get; }
    public int X { get; }
    public string Symbol => ". ";
    public ConsoleColor Color { get; set; }

    public Cell(int y, int x)
    {
        Color = ConsoleColor.Red;
        Y = y;
        X = x;
    }
}
