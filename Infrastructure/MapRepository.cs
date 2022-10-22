namespace Abobus.Infrastructure;

using System.Text.Json;
using Application;
using Domain;

public sealed class MapRepository : IMapRepository
{
    private readonly IAppFileSystemPaths _paths;
    private readonly IFIleSystem _fileSystem;

    public MapRepository(IAppFileSystemPaths paths, IFIleSystem fileSystem)
    {
        _paths = paths;
        _fileSystem = fileSystem;
    }

    public IMap GetMap(string name)
    {
        var json = _fileSystem.ReadFileContents(_paths.GetMapFilePath(name));
        return JsonSerializer.Deserialize<Map>(json);
    }
}
