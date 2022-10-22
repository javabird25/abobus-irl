namespace Abobus.Infrastructure;

using System.Text.Json;
using Application;
using Domain;

public sealed class GameRepository : IGameRepository
{
    private static readonly string PasswordToGameIdMapFilePath = "/tmp/abobus/passwordToGameIdMap.json";

    private readonly IFIleSystem _fileSystem;
    private readonly IGameConfigRepository _gameConfigRepository;
    private readonly IMapRepository _mapRepository;

    public GameRepository(IFIleSystem fileSystem, IMapRepository mapRepository,
        IGameConfigRepository gameConfigRepository)
    {
        _fileSystem = fileSystem;
        _gameConfigRepository = gameConfigRepository;
        _mapRepository = mapRepository;
    }

    public (IGame, GamePassword) CreateGame(string mapName, string configName)
    {
        _fileSystem.CreateDirectoryIfNotExists("/tmp/abobus");
        var passwordToGameIdMap = LoadPasswordToGameIdMap();
        var gameConfig = _gameConfigRepository.GetGameConfigByName(configName);
        var map = _mapRepository.GetMap(mapName);
        var game = new Game(map, gameConfig);
        var password = GamePassword.Generate();
        passwordToGameIdMap.Add(password, game.Id);
        SavePasswordToGameIdMap(passwordToGameIdMap);
        SaveGame(game);
        return (game, password);
    }

    private void SaveGame(IGame game)
    {
        _fileSystem.WriteFileContents(GetGameFilePath(game.Id), JsonSerializer.Serialize(game));
    }

    private string GetGameFilePath(Guid gameId)
    {
        return $"/tmp/abobus/{gameId}.json";
    }

    private PasswordToGameIdMap LoadPasswordToGameIdMap()
    {
        var passwordToGameIdMap = _fileSystem.ReadFileContents(PasswordToGameIdMapFilePath);
        return JsonSerializer.Deserialize<PasswordToGameIdMap>(passwordToGameIdMap) ?? new PasswordToGameIdMap();
    }

    private void SavePasswordToGameIdMap(PasswordToGameIdMap passwordToGameIdMap)
    {
        var json = JsonSerializer.Serialize(passwordToGameIdMap);
        _fileSystem.WriteFileContents(PasswordToGameIdMapFilePath, json);
    }

    public IGame GetGameByPassword(GamePassword password)
    {
        var passwordToGameIdMap = LoadPasswordToGameIdMap();
        var gameId = passwordToGameIdMap.GetGameId(password);
        var gameJson = _fileSystem.ReadFileContents(GetGameFilePath(gameId));
        return JsonSerializer.Deserialize<Game>(gameJson);
    }

    public void UpdateGame(IGame game)
    {
        SaveGame(game);
    }
}

internal sealed class PasswordToGameIdMap
{
    private readonly Dictionary<GamePassword, Guid> _map = new();

    public Guid GetGameId(GamePassword password)
    {
        return _map[password];
    }

    public void Add(GamePassword password, Guid gameId)
    {
        _map.Add(password, gameId);
    }
}
