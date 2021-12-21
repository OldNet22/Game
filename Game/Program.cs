

using Game.GameWorld;
using Microsoft.Extensions.Configuration;

//IConfiguration config = new ConfigurationBuilder()
//                    .SetBasePath(Environment.CurrentDirectory)
//                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true )
//                    .Build();

//var ui = config.GetSection("game:ui").Value;
//var x = config.GetSection("game:mapsettings:x").Value;
//var mapSettings = config.GetSection("game:mapsettings").GetChildren();

//IUI ui2;
//switch (ui)
//{
//    case "console":
//        ui2 = new ConsoleUI();
//        break;
//    default:
//        break;
//}

var startup = new StartUp();
startup.SetUp();


//GamePlay game = new(new ConsoleUI(), new Map(config));
//game.Run();

Console.WriteLine("Thanks for playing");
Console.ReadLine();
