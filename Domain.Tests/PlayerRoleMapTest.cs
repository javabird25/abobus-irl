namespace Abobus.Domain.Tests;

using System;

public class PlayerRoleMapTest
{
    [Fact]
    public void SetRoleOf_ShouldSetRoleOfPlayer()
    {
        var player = new Player(1, "Nikita");
        var role = new ImpostorPlayerRole();
        var playerRoleMap = new PlayerRoleMap();

        playerRoleMap.SetRoleOf(player, role);

        playerRoleMap.RoleOf(player).Id.Should().Be("impostor");
    }

    [Fact]
    public void RoleOf_MissingPlayer_ShouldThrowException()
    {
        var player = new Player(1, "Nikita");
        var playerRoleMap = new PlayerRoleMap();

        Action action = () => playerRoleMap.RoleOf(player);

        action.Should().Throw<NoSuchPlayerException>();
    }
}
