
using Game.Entities;
using Game.Extensions;
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
            GetInput();
            //Act
            //DrawMap
            //EnemyAction
            //DrawMap

            //Console.ReadKey();

        } while (gameInProgress);
    }

    private void GetInput()
    {
        var keyPressed = UI.GetKey();

        switch (keyPressed)
        {
            case ConsoleKey.LeftArrow:
                Move(Direction.West);
                break;
            case ConsoleKey.RightArrow:
                Move(Direction.East);
                break;
            case ConsoleKey.UpArrow:
                Move(Direction.North);
                break;
            case ConsoleKey.DownArrow:
                Move(Direction.South);
                break;
            default:
                break;
        }
    }

    private void Move(Position movement)
    {
        Position newPosition = hero.Cell.Position + movement;
        Cell newCell = map.GetCell(newPosition)!;
        if (newCell != null) hero.Cell = newCell;
    }

    private void DrawMap()
    {
        UI.Clear();

        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                Cell? cell = map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell);
                IDrawable drawable = map.Creatures.CreatureAtExtension(cell);

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