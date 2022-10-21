namespace Abobus.Domain.Tests.Actions;

using System;
using Domain.Actions;

public sealed class ImpostorKilledCrewmateActionTest
{
    [Fact]
    public void ModifyGame_MarksCrewmateAsKilled()
    {
        var crewmate = new Player(1, "Crewmate");
        crewmate.MakeCrewmate(new TaskList());
        var impostor = new Player(2, "Impostor");
        var config = new Mock<IGameConfig>();
        config.Setup(c => c.Get("killCooldown", It.IsAny<TimeSpan>())).Returns(TimeSpan.FromMinutes(2));
        impostor.MakeImpostor(config.Object);
        var action = new ImpostorKilledCrewmateAction { Sender = impostor, Victim = crewmate };

        action.ModifyGame();

        crewmate.IsAlive.Should().BeFalse();
    }
}
