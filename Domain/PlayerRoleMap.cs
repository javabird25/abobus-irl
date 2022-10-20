namespace Abobus.Domain;

public sealed class PlayerRoleMap : IPlayerRoleMap
{
    private readonly Dictionary<Player, IPlayerRole> _roles = new();

    public IPlayerRole RoleOf(Player player)
    {
        try
        {
            return _roles[player];
        }
        catch (KeyNotFoundException e)
        {
            throw new NoSuchPlayerException(player);
        }
    }

    public void SetRoleOf(Player player, IPlayerRole role)
    {
        _roles.Add(player, role);
    }
}

public sealed class NoSuchPlayerException : Exception
{
    public NoSuchPlayerException(Player player) : base($"No such player: {player}")
    {
    }
}
