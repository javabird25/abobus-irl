namespace Abobus.Domain;

public interface IGame
{
    Guid Id { get; init; }
    List<Player> Players { get; init; }
    IMap Map { get; init; }
    IGameState GameState { get; }
    event Action<IGameState>? GameStateChanged;
    void AddPlayer(Player player);
    void Start();
}
