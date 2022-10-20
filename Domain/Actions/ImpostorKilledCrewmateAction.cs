namespace Abobus.Domain.Actions;

public sealed class ImpostorKilledCrewmateAction : IAction
{
    public Player? Sender { get; init; }
    public Player? Victim { get; init; }

    public bool Validate(IGame game) =>
        Sender != null
        && Victim != null
        && game.RoleMap.RoleOf(Sender).IsImpostor
        && game.RoleMap.RoleOf(Victim).IsCrewmate;
}
