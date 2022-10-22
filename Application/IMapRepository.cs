namespace Abobus.Application;

using Domain;

public interface IMapRepository
{
    IMap GetMap(string name);
}
