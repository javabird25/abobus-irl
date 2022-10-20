namespace Abobus.Domain.Actions;

public interface IAction
{
    Player? Sender { get; init; }
    bool Validate(IGame game);
}
