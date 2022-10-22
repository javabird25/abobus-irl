namespace Abobus.Domain;

public interface IGame
{
    Guid Id { get; }

    List<Player> Players { get; init; }

    IMap Map { get; init; }

    IGameState GameState { get; }

    event Action<IGameState>? OnGameStateChange;

    Guid JoinPlayer(string name);

    void Start();
}
