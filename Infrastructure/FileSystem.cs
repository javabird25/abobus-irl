namespace Abobus.Infrastructure;

public sealed class FileSystem : IFIleSystem
{
    public void CreateDirectoryIfNotExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    public string ReadFileContents(string path)
    {
        return File.ReadAllText(path);
    }

    public void WriteFileContents(string path, string contents)
    {
        File.WriteAllText(path, contents);
    }
}
