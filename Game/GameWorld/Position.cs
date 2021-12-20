using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameWorld
{
    //internal struct Position
    //{
    //    public int X { get; }
    //    public int Y { get; }

    //    public Position(int y, int x)
    //    {
    //        Y = y;
    //        X = x;
    //    }

    //    public void Deconstruct(out int x, out int y)
    //    {
    //        x = X;
    //        y = Y;
    //    }

    //    public static Position operator + (Position p1, Position p2) => 
    //        new Position(p1.Y + p2.Y, p1.X + p2.X); 
    //}

    public record Position(int Y, int X)
    {
        public static Position operator + (Position p1, Position p2) => 
            new Position(p1.Y + p2.Y, p1.X + p2.X);

    }

}
