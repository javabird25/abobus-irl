namespace Abobus.Domain.Actions;

public sealed class ImpostorKilledCrewmateAction : IAction
{
    public required Player Sender { get; init; }

    public required Player Victim { get; init; }

    public void ModifyGame()
    {
        Sender.Kill(Victim);
    }
}
