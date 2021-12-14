
using Game;
using Game.Entities;
using Game.GameWorld;

//List<int> list = new List<int>();
//List<string> list2 = new List<string>();

//Dictionary<string, Creature> list3 = new Dictionary<string, Creature>();

//Test<int> test = new Test<int>();
//Test<string> test2 = new Test<string>();
//Test<Hero> test23 = new Test<Hero>();

GamePlay game = new();
game.Run();

Console.WriteLine("Thanks for playing");
Console.ReadLine();


//class Test<T> where T : IDrawable
//{
//    private T x;

//    public T X
//    {
//        get { return x; }
//        set { x = value; }
//    }

//    public T MyProperty { get; set; }
//}