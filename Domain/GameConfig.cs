namespace Abobus.Domain;

using ConfigDictionary = Dictionary<string, string>;

public sealed class GameConfig : IGameConfig
{
    private readonly ConfigDictionary _dictionary;

    public GameConfig(string name, ConfigDictionary dictionary)
    {
        _dictionary = dictionary;
        Name = name;
    }

    public string Name { get; }

    public T Get<T>(string key, T fallback) where T : notnull
    {
        var success = _dictionary.TryGetValue(key, out var valueString);
        if (!success)
        {
            return fallback;
        }

        var targetType = typeof(T);
        var converted = Convert.ChangeType(valueString, targetType);
        if (converted is null)
        {
            throw new InvalidCastException($"Could not convert config value \"{valueString}\" to {targetType}");
        }

        return (T)converted;
    }
}
