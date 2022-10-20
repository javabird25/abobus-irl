namespace Abobus.Domain;

public interface IGameState
{
}

public class LobbyGameState : IGameState
{
}

public class PlayingGameState : IGameState
{
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
}
