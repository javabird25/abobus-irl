namespace Abobus.Domain;

public sealed class Impostor : Player
{
    public DateTime CanKillAfter { get; init; }

    public Impostor(int id, string name) : base(id, name)
    {
    }
}
