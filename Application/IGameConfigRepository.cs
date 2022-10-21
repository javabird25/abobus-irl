namespace Abobus.Application;

using Domain;

public interface IGameConfigRepository
{
    IGameConfig GetGameConfigByName(string name);
}
