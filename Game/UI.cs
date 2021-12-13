using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class UI
    {
        internal static void Clear()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;
        //{
        //    return Console.ReadKey(intercept: true).Key;
        //}
    }
}
