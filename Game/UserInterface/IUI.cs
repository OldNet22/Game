using Game.GameWorld;

namespace Game.UserInterface
{
    public interface IUI
    {
        void AddMessage(string message);
        void Clear();
        void Draw(IMap map);
        ConsoleKey GetKey();
        void PrintStats(string stats);
        void PrintLog();
    }

    //public class TestUI : IUI
    //{
    //    public void AddMessage(string message)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Clear()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Draw(Map map)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ConsoleKey GetKey()
    //    {
    //        return ConsoleKey.P;
    //    }

    //    public void PrintLog()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void PrintStats(string stats)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}