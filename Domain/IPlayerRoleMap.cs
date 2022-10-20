namespace Abobus.Domain;

public interface IPlayerRoleMap
{
    IPlayerRole RoleOf(Player player);
}
