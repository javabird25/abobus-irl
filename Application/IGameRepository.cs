namespace Abobus.Application;

using Domain;

public interface IGameRepository
{
    public (IGame, GamePassword) CreateGame(string mapName, string configName);
    public IGame GetGameByPassword(GamePassword password);
    public void UpdateGame(IGame game);
}
