namespace Abobus.Application;

using Domain;

public sealed class GameNotFoundException : Exception
{
    public GameNotFoundException(GamePassword password) : base($"Game with password {password} not found")
    {
    }
}
