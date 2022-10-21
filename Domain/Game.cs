namespace Abobus.Domain;

public sealed class Game : IGame
{
    public Guid Id { get; init; }
    public List<Player> Players { get; init; } = new();
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

    public Game(Guid id, IMap map, IGameConfig config)
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
