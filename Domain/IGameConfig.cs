namespace Abobus.Domain;

public interface IGameConfig
{
    public T Get<T>(string key);
}
