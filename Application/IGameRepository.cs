namespace Abobus.Application;

using Domain;

public interface IGameRepository
{
    (IGame, GamePassword) CreateGame(string mapName, string configName);
    IGame GetGameByPassword(GamePassword password);
    void UpdateGame(IGame game);
}
