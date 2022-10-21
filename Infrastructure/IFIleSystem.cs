namespace Abobus.Infrastructure;

public interface IFIleSystem
{
    void CreateDirectoryIfNotExists(string path);
    string ReadFileContents(string path);
    void WriteFileContents(string path, string contents);
}
