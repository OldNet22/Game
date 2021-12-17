using Game.Extensions;
using Game.GameWorld;
using Game.LimitedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class UI
    {

        private static MessageLog<string> messageLog = new(6);

        internal static void Clear()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;
        //{
        //    return Console.ReadKey(intercept: true).Key;
        //}
        internal static void Draw(Map map)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell? cell = map.GetCell(y, x);
                    ArgumentNullException.ThrowIfNull(cell);
                    IDrawable drawable = map.Creatures.CreatureAtExtension2(cell) ?? cell.Items.FirstOrDefault() as IDrawable ?? cell;

                    Console.ForegroundColor = drawable.Color;  //drawable?.Color ?? ConsoleColor.White;
                    Console.Write(drawable.Symbol);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        //ToDo: Check return bool
        internal static void AddMessage(string message) => messageLog.Add(message);

        internal static  void PrintLog()
        {
            messageLog.Print(m => Console.WriteLine(m + new string(' ', Console.WindowWidth - m.Length )));
            //messageLog.Print(Something);
            //messageLog.Print(Console.WriteLine);
        }

        public static  void PrintStats(string stats)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stats);
            Console.ForegroundColor = ConsoleColor.White;
        }     
        
        public static  void Something(string message)
        {
            Console.WriteLine(message);
        }
     
        
    }
}
