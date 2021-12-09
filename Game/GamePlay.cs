
using Game.GameWorld;

namespace Game;

internal class GamePlay
{
    //ToDo: Fix ?
    private Map? map;
    private Hero? hero;

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
       
    }

    private void Initialize()
    {
        //ToDo: Read from config
        map = new Map(width: 10, height: 10);
        hero = new Hero();
    }
}