namespace Abobus.Domain.Tests;

public class GameTest
{
    private readonly Game _game;

    public GameTest()
    {
        var map = new Mock<IMap>();
        var config = new Mock<IGameConfig>();
        _game = new Game(1, map.Object, config.Object);
    }

    [Fact]
    public void AddPlayer_AddsPlayer()
    {
        var player = new Player(1, "Nikita");

        _game.AddPlayer(player);

        _game.Players[0].Should().Be(player);
    }

    [Fact]
    public void Start_ChangesGameStateToPlaying()
    {
        _game.GameStateChanged += state => state.Id.Should().Be("playing");

        _game.Start();
    }
}
