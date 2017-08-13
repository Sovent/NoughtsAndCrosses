using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoughtsAndCrosses.Application;
using NoughtsAndCrosses.Domain;
using NoughtsAndCrosses.Filters;
using NoughtsAndCrosses.Models;

namespace NoughtsAndCrosses.Controllers
{
  [Produces("application/json")]
  [GameExceptionFilter]
  public class GameController : Controller
  {
    public GameController(IGameFacade gameFacade)
    {
      _gameFacade = gameFacade ?? throw new ArgumentNullException(nameof(gameFacade));
    }

    [HttpPost]
    [Route("game")]
    public async Task<IActionResult> StartGame([FromBody] InitiateNewGameRequest request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var gameSessionStatus = await _gameFacade.StartGameSessionAsync(new Dictionary<string, Sign>
      {
        [request.CrossesPlayerName] = Sign.Crosses,
        [request.NoughtsPlayerName] = Sign.Noughts
      });
      return Ok(gameSessionStatus.ToApiModel());
    }

    [HttpGet]
    [Route("game/{gameId}")]
    public async Task<IActionResult> GetGameStatus([FromRoute] Guid gameId)
    {
      var gameSessionStatus = await _gameFacade.GetGameSessionStatusAsync(gameId);

      return Ok(gameSessionStatus.ToApiModel());
    }

    [HttpPost]
    [Route("game/{gameId}/turn")]
    public async Task<IActionResult> MakeTurn([FromRoute]Guid gameId, [FromBody] MakeTurnRequest request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      await _gameFacade.MakeTurnAsync(
        gameId, 
        request.PlayerName,
        request.Row, 
        request.Column);
      var gameSessionStatus = await _gameFacade.GetGameSessionStatusAsync(gameId);
      return Ok(gameSessionStatus.ToApiModel());
    }

    private readonly IGameFacade _gameFacade;
  }
}