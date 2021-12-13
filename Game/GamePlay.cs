
using Game.Entities;
using Game.GameWorld;

namespace Game;

internal class GamePlay
{
    //ToDo: Fix ?
    private Map map = null!;
    private Hero hero = null!;

    //public GamePlay()
    //{
    //    map = new Map(width: 10, height: 10);
    //    Cell heroCell = map.GetCell(0, 0)!;
    //    ArgumentNullException.ThrowIfNull(heroCell);
    //    hero = new Hero(heroCell);
    //    map.Creatures.Add(hero);
    //}

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        bool gameInProgress = true;
        do
        {
            //DrawMap
            DrawMap();
            //GetCommand
            //Act
            //DrawMap
            //EnemyAction
            //DrawMap

            Console.ReadKey();

        } while (gameInProgress);
    }

    private void DrawMap()
    {
        Console.Clear();

        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                Cell? cell = map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell);
                IDrawable drawable = cell;

                foreach (Creature creature in map.Creatures)
                {
                    if(creature.Cell == cell)
                    {
                        drawable = creature;
                        break;
                    }
                }

                Console.ForegroundColor = drawable.Color;  //drawable?.Color ?? ConsoleColor.White;
                Console.Write(drawable.Symbol);
            }
            Console.WriteLine();
        }
        Console.ForegroundColor= ConsoleColor.White;
    }

    private void Initialize()
    {
        //ToDo: Read from config
        //ToDo: Random position
        map = new Map(width: 10, height: 10);
        var heroCell = map.GetCell(0, 0);
        ArgumentNullException.ThrowIfNull(heroCell);
        hero = new Hero(heroCell);
        map.Creatures.Add(hero);
    }
}