namespace Abobus.Domain;

public interface IGameConfig
{
    public string Name { get; }

    public T Get<T>(string key, T fallback) where T : notnull;
}
