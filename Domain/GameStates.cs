namespace Abobus.Domain;

public interface IGameState
{
    string Id { get; }
}

public class LobbyGameState : IGameState
{
    public string Id => "lobby";
}

public class PlayingGameState : IGameState
{
    public string Id => "playing";
}

public class VotingGameState : IGameState
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
