namespace Abobus.Domain;

public sealed class Game
{
    public int Id { get; init; }
    public List<Player> Players { get; init; } = new();
    public Dictionary<Player, PlayerRole> Roles = new();
    public IMap Map { get; init; }
    public IGameState GameState { get; private set; } = new LobbyGameState();
    private readonly IGameConfig _config;

    public Game(int id, IMap map, IGameConfig config)
    {
        Id = id;
        Map = map;
        _config = config;
    }

    public void AddPlayer(Player player)
    {
        Players.Add(player);
    }
}
