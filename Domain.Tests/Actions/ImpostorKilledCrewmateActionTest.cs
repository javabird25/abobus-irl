namespace Abobus.Domain.Tests.Actions;

using Domain.Actions;

public sealed class ImpostorKilledCrewmateActionTest
{
    [Fact]
    public void Validate_ReturnsTrueOnMatchingRoles()
    {
        var killer = new Player(1, "Killer");
        var victim = new Player(2, "Victim");
        var game = new Mock<IGame>();
        game.Setup(g => g.RoleMap.RoleOf(killer)).Returns(new ImpostorPlayerRole());
        game.Setup(g => g.RoleMap.RoleOf(victim)).Returns(new CrewmatePlayerRole(new TaskList()));
        var action = new ImpostorKilledCrewmateAction { Sender = killer, Victim = victim };

        var result = action.Validate(game.Object);

        result.Should().BeTrue();
    }
}
