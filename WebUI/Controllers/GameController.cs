using Microsoft.AspNetCore.Mvc;

namespace Abobus.WebUI.Controllers;

using Application;
using Domain;

[ApiController]
[Route("[controller]/[action]")]
public sealed class GameController : ControllerBase
{
    private readonly IGameRepository _gameRepository;

    public GameController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    [HttpPost]
    public IActionResult Create(CreateGameRequest request)
    {
        var (game, password) = _gameRepository.CreateGame("default", request.GameConfigName);
        game.JoinPlayer(request.Name);
        _gameRepository.UpdateGame(game);
        return Ok(new CreateGameResponse { GamePassword = password });
    }

    [HttpPost]
    [Route("[controller]/[action]/{gamePassword:int}")]
    public IActionResult Join(JoinGameRequest request, int gamePassword)
    {
        var game = _gameRepository.GetGameByPassword(new GamePassword(gamePassword));
        game.JoinPlayer(request.Name);
        _gameRepository.UpdateGame(game);
        return Ok();
    }
}

public sealed class CreateGameRequest
{
    public string Name { get; set; }
    public string GameConfigName { get; set; }
}

public sealed class CreateGameResponse
{
    public required GamePassword GamePassword;
}

public sealed class JoinGameRequest
{
    public string Name { get; set; }
}
