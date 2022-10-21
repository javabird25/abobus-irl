namespace Abobus.Domain.Actions;

public interface IAction
{
    Player Sender { get; init; }

    void ModifyGame();
}
