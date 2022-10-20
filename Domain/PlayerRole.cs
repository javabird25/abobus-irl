namespace Abobus.Domain;

public abstract class PlayerRole
{
}

public sealed class CrewmatePlayerRole : PlayerRole
{
    public TaskList Tasks { get; init; }
    public LifeState LifeState { get; init; } = LifeState.Alive;

    public CrewmatePlayerRole(TaskList tasks)
    {
        Tasks = tasks;
    }
}

public sealed class ImpostorPlayerRole : PlayerRole
{
    public DateTime CanKillAfter { get; init; } = DateTime.UnixEpoch;
}
