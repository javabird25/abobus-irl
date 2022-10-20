namespace Abobus.Domain.Tests;

public class GameTest
{
    [Fact]
    public void AddPlayer()
    {
        var map = new Mock<IMap>();
        var config = new Mock<IGameConfig>();
        var game = new Game(1, map.Object, config.Object);
        var player = new Player(1, "Nikita");

        game.AddPlayer(player);

        game.Players[0].Should().Be(player);
    }
}
