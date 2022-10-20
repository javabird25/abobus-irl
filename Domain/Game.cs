namespace Abobus.Domain;

public sealed class Game : IGame
{
    public int Id { get; init; }
    public List<Player> Players { get; init; } = new();
    public IPlayerRoleMap RoleMap { get; init; } = new PlayerRoleMap();
    public IMap Map { get; init; }

    public IGameState GameState
    {
        get => _gameState;
        private set
        {
            _gameState = value;
            GameStateChanged?.Invoke(value);
        }
    }

    private IGameState _gameState = new LobbyGameState();

    public event Action<IGameState>? GameStateChanged;
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

    public void Start()
    {
        GameState = new PlayingGameState();
    }
}
