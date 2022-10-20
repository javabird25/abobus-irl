namespace Abobus.Domain;

public interface IPlayerRole
{
    string Id { get; }
    bool IsCrewmate { get; }
    bool IsImpostor => !IsCrewmate;
}

public sealed class CrewmatePlayerRole : IPlayerRole
{
    public TaskList Tasks { get; init; }
    public LifeState LifeState { get; init; } = LifeState.Alive;

    public CrewmatePlayerRole(TaskList tasks)
    {
        Tasks = tasks;
    }

    public string Id => "crewmate";
    public bool IsCrewmate => true;
}

public sealed class ImpostorPlayerRole : IPlayerRole
{
    public DateTime CanKillAfter { get; init; } = DateTime.UnixEpoch;
    public string Id => "impostor";
    public bool IsCrewmate => false;
}
