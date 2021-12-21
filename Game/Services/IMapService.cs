namespace Game.Services
{
    public interface IMapService
    {
        (int width, int height) GetMap();
    }
}