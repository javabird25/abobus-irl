namespace Abobus.Domain;

public sealed class Game : IGame
{
    public Guid Id { get; } = new();
    public List<Player> Players { get; init; } = new();
    public IMap Map { get; init; }

    public IGameState GameState
    {
        get => _gameState;
        private set
        {
            _gameState = value;
            OnGameStateChange?.Invoke(value);
        }
    }

    private IGameState _gameState = new LobbyGameState();

    public event Action<IGameState>? OnGameStateChange;
    private readonly IGameConfig _config;

    public Game(IMap map, IGameConfig config)
    {
        Map = map;
        _config = config;
    }

    public Guid JoinPlayer(string name)
    {
        if (GameState is not LobbyGameState)
        {
            throw new InvalidOperationException("Game is already started");
        }

        var player = new Player(name);
        Players.Add(player);
        return player.Id;
    }

    public void Start()
    {
        GameState = new PlayingGameState();
    }
}
