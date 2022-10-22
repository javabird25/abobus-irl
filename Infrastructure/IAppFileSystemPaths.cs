namespace Abobus.Infrastructure;

public interface IAppFileSystemPaths
{
    string GetMapFilePath(string mapName);

    string GetGameFilePath(string gameName);
    
    string GetGameConfigFilePath(string configName);
}
