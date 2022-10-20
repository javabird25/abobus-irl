namespace Abobus.Domain;

public interface IGameState
{
    string Id { get; }
}

public sealed class LobbyGameState : IGameState
{
    public string Id => "lobby";
}

public sealed class PlayingGameState : IGameState
{
    public string Id => "playing";
}

public sealed class VotingGameState : IGameState
{
    public Vote Vote { get; init; }
    public Player Initiator { get; init; }
    public Player? FoundDead { get; init; }

    public VotingGameState(Vote vote, Player initiator, Player? foundDead)
    {
        Vote = vote;
        Initiator = initiator;
        FoundDead = foundDead;
    }

    public string Id => "voting";
}
