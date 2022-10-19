namespace Abobus.Domain;

public class Vote
{
    public Dictionary<Player, Player?> Votes { get; init; }

    public Vote(Dictionary<Player, Player?> votes)
    {
        Votes = votes;
    }
}
