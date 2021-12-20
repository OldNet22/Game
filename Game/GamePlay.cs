using Game.Entities.Creatures;
using Game.Entities.Items;
using Game.Extensions;
using Game.GameWorld;
using Game.UserInterface;

namespace Game;

internal class GamePlay
{
    //ToDo: Fix ?
    private Map map = null!;
    private Hero hero = null!;
    private bool gameInProgress;

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        gameInProgress = true;
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
            //case ConsoleKey.P:
            //    PickUp();
            //    break; 
            //case ConsoleKey.I:
            //    Inventory();
            //    break;
            default:
                break;
        }

        var actionMeny = new Dictionary<ConsoleKey, Action>()
        {
            {ConsoleKey.P, PickUp },
            {ConsoleKey.I, Inventory },
            {ConsoleKey.D, Drop },
            {ConsoleKey.Q, Quit }
        };

        if(actionMeny.ContainsKey(keyPressed))
            actionMeny[keyPressed]?.Invoke();
    }

    private void Quit()
    {
        Environment.Exit(0);
    }

    private void Drop()
    {
        var item = hero.BackPack.FirstOrDefault();

        if (item != null && hero.BackPack.Remove(item))
        {
            hero.Cell.Items.Add(item);
            UI.AddMessage($"Hero dropped the {item}");
        }
        else
            UI.AddMessage("Backpack is empty");
    }

    private void Inventory()
    {
        UI.AddMessage("Inventory");
        for (int i = 0; i < hero.BackPack.Count; i++)
        {
            UI.AddMessage($"{i + 1}: {hero.BackPack[i]}");
        }
    }

    private void PickUp()
    {
        if (hero.BackPack.IsFull)
        {
            UI.AddMessage("BackPack is full");
            return;
        }

        var items = hero.Cell.Items;
        var item = items.FirstOrDefault();
        if (item is null) return;

        if (hero.BackPack.Add(item))
        {
            UI.AddMessage($"Hero pick up {item}");
            items.Remove(item);
        }
    }

    private void Move(Position movement)
    {
        Position newPosition = hero.Cell.Position + movement;
        Cell? newCell = map.GetCell(newPosition);

        var opponent = map.CreatureAt(newCell) as Creature;
        if (opponent != null) hero.Attack(opponent);

        gameInProgress = !hero.IsDead;

        if (newCell != null)
        {
            hero.Cell = newCell;
            if (newCell.Items.Any())
                UI.AddMessage("You see " + string.Join(", ", newCell.Items.Select(i => i.ToString())));
        }
    }

    private void DrawMap()
    {
        UI.Clear();
        UI.Draw(map);
        UI.PrintStats($"Health: {hero.Health}, Enemys: {map.Creatures.Count -1}");
        UI.PrintLog();
    }

  

    private void Initialize()
    {
        //ToDo: Read from config
        map = new Map(width: 10, height: 10);
        var heroCell = map.GetCell(0, 0);
        var defaultCreatureCell = map.GetCell(5, 5);

        ArgumentNullException.ThrowIfNull(heroCell);
        ArgumentNullException.ThrowIfNull(defaultCreatureCell);

        hero = new Hero(heroCell, UI.AddMessage);
        map.Creatures.Add(hero);

        var r = new Random();

        map.GetCell(RH(r), RW(r))?.Items.Add(Item.Coin());
        map.GetCell(RH(r), RW(r))?.Items.Add(Item.Coin());
        map.GetCell(RH(r), RW(r))?.Items.Add(Item.Stone());
        map.GetCell(RH(r), RW(r))?.Items.Add(Item.Stone());
        map.GetCell(RH(r), RW(r))?.Items.Add(Item.Coin());
        map.GetCell(RH(r), RW(r))?.Items.AddRange(new List<Item> { Item.Coin(), Item.Coin() });

        map.Place(new Orc(      map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell ,   120, UI.AddMessage));
        map.Place(new Orc(      map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell ,   120, UI.AddMessage));
        map.Place(new Troll(    map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell ,   160, UI.AddMessage));
        map.Place(new Troll(    map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell ,   160, UI.AddMessage));
        map.Place(new Goblin(   map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell ,   200, UI.AddMessage));
        map.Place(new Goblin(   map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell ,   200, UI.AddMessage));

        int RW(Random r)
        {
            return r.Next(0, map.Width);
        }

        int RH(Random r)
        {
            return r.Next(0, map.Height);
        }
    }
}