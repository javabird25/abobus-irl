namespace Abobus.Infrastructure;

using Microsoft.Extensions.Configuration;

public sealed class AppFileSystemPaths : IAppFileSystemPaths
{
    private static readonly string FileExtension = ".json";

    private readonly IConfiguration _config;

    public AppFileSystemPaths(IConfiguration config)
    {
        _config = config;
    }

    private string MapsDirectoryPath => _config["Paths:MapsDirectoryPath"] ?? "/var/lib/abobus/maps";

    private string GamesDirectoryPath => _config["Paths:GamesDirectoryPath"] ?? "/var/lib/abobus/games";

    private string GameConfigsDirectoryPath =>
        _config["Paths:GameConfigsDirectoryPath"] ?? "/var/lib/abobus/game-configs";

    public string GetMapFilePath(string mapName) => Path.Join(MapsDirectoryPath, mapName + FileExtension);

    public string GetGameFilePath(string gameName) => Path.Join(GamesDirectoryPath, gameName + FileExtension);

    public string GetGameConfigFilePath(string configName) =>
        Path.Join(GameConfigsDirectoryPath, configName + FileExtension);
}
