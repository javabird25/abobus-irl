namespace Abobus.Domain;

public sealed class Player
{
    public Guid Id { get; } = new();

    public string Name { get; init; }

    private IPlayerGameState _gameState = new InLobbyPlayerGameState();

    public Player(string name)
    {
        Name = name;
    }

    public bool IsCrewmate => _gameState is CrewmatePlayerGameState;

    public bool IsImpostor => _gameState is ImpostorPlayerGameState;

    public bool IsAlive => _gameState is ImpostorPlayerGameState || (_gameState is CrewmatePlayerGameState state &&
                                                                     state.LifeState ==
                                                                     LifeState.Alive);

    public void MakeCrewmate(TaskList tasks)
    {
        _gameState = new CrewmatePlayerGameState(tasks);
    }

    public void MakeImpostor(IGameConfig config)
    {
        _gameState = new ImpostorPlayerGameState(config);
    }

    public void Kill(Player victim)
    {
        if (!IsImpostor)
        {
            throw new InvalidOperationException("Only impostors can kill.");
        }

        victim.MakeDead();
        ((ImpostorPlayerGameState)_gameState).PerformKill();
    }

    public void MakeDead()
    {
        if (!IsCrewmate)
        {
            throw new InvalidOperationException("Only crewmates can be killed.");
        }

        ((CrewmatePlayerGameState)_gameState).Die();
    }
}
