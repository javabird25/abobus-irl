namespace Abobus.Domain;

public interface IPlayerGameState
{
    string Id { get; }
}

public sealed class InLobbyPlayerGameState : IPlayerGameState
{
    public string Id { get; }
}

public sealed class CrewmatePlayerGameState : IPlayerGameState
{
    public TaskList Tasks { get; init; }
    public LifeState LifeState { get; private set; } = LifeState.Alive;

    public CrewmatePlayerGameState(TaskList tasks)
    {
        Tasks = tasks;
    }

    public string Id => "crewmate";

    public void Die()
    {
        LifeState = LifeState.KilledInThisRound;
    }
}

public sealed class ImpostorPlayerGameState : IPlayerGameState
{
    public string Id => "impostor";

    private readonly IGameConfig _config;

    private DateTime _canKillAfter = DateTime.UnixEpoch;

    public bool CanKill => _canKillAfter < DateTime.Now;

    public ImpostorPlayerGameState(IGameConfig config)
    {
        _config = config;
    }

    public void PerformKill()
    {
        if (!CanKill)
        {
            throw new InvalidOperationException($"Cannot kill yet: cooldown will be over at {_canKillAfter}");
        }

        _canKillAfter = DateTime.Now + _config.Get("killCooldown", TimeSpan.FromMinutes(1));
    }
}
