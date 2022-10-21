namespace Abobus.Application;

using Domain;

public interface IGameRepository
{
    public GamePassword CreateGame(string mapName, string configName);
    public Game GetGameByPassword(GamePassword password);
}
