namespace Abobus.Infrastructure;

using System.Text.Json;
using Application;
using Domain;

public sealed class GameConfigRepository : IGameConfigRepository
{
    private readonly IFIleSystem _fileSystem;
    private readonly IAppFileSystemPaths _paths;

    public GameConfigRepository(IFIleSystem fileSystem, IAppFileSystemPaths paths)
    {
        _fileSystem = fileSystem;
        _paths = paths;
    }

    public IGameConfig GetGameConfigByName(string name)
    {
        var json = _fileSystem.ReadFileContents(_paths.GetGameConfigFilePath(name));
        return new GameConfig(name, JsonSerializer.Deserialize<Dictionary<string, string?>>(json));
    }
}
