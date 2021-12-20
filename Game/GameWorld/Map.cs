using Game.Entities.Creatures;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Game.GameWorld;

public class Map : IMap
{
    private Cell[,] cells;
    public int Width { get; }
    public int Height { get; }

    public List<Creature> Creatures { get; set; } = new List<Creature>();

    public Map(int width, int height)
    {
        Width = width;
        Height = height;

        cells = new Cell[Height, Width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                cells[y, x] = new Cell(new Position(y, x));
            }
        }
    }

    //[return: MaybeNull]
    public Cell? GetCell(int y, int x)
    {
        //ToDo: Fix! 
        if (x < 0 || x >= Width || y < 0 || y >= Height)
        {
            return null;
        }

        return cells[y, x];
    }

    //[return: MaybeNull]
    public Cell? GetCell(Position newPosition)
    {
        return GetCell(newPosition.Y, newPosition.X);
    }

    public void Place(Creature creature)
    {
        if (Creatures.Where(c => c.Cell == creature.Cell).Count() >= 1) return;
        Creatures.Add(creature);
    }

    public IDrawable? CreatureAt(Cell? cell)
    {
        return Creatures.FirstOrDefault(creature => creature.Cell == cell);
    }
}
