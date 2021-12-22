using Game.Entities.Creatures;
using Game.Extensions;
using Game.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Game.GameWorld;

public class Map : IMap
{
    private Cell[,] cells;
    public int Width { get; }
    public int Height { get; }

    public List<Creature> Creatures { get; set; } = new List<Creature>();

    public Map(IConfiguration config/*, MapSettings settings, IOptions<MapSettings> options,*/ /*IMapService mapService*/)//int width, int height)
    {
        var width = config.GetMapSizeFor("x");
        var height = config.GetMapSizeFor("y");
        //Width = width;
        //Height = height; 

        //var width = settings.X;
        //var height = settings.Y;
        //Width = width;
        //Height = height;

        //var width = options.Value.X;
        //var height = options.Value.Y;
        //Width = width;
        //Height = height; 

        // var (width, height) = mapService.GetMap();
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
