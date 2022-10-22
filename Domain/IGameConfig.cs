namespace Abobus.Domain;

public interface IGameConfig
{
    string Name { get; }

    T Get<T>(string key, T fallback) where T : notnull;
}
