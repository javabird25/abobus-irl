namespace Abobus.Domain;

public sealed class Game
{
    public int Id { get; init; }
    public List<Player> Players { get; init; }
    public Map Map { get; init; }
    public IGameState GameState { get; private set; }
    private readonly IGameConfig _config;

    public Game(int id, List<Player> players, Map map, IGameConfig config)
    {
        Id = id;
        Players = players;
        Map = map;
        _config = config;
        GameState = new LobbyGameState();
    }
}
