namespace Game.GameWorld;

internal class Cell : IDrawable
{
    public Position Position { get; set; }
    public string Symbol => ". ";
    public ConsoleColor Color { get; set; }

    public Cell(Position position)
    {
        Color = ConsoleColor.Red;
        Position = position;
    }
}
