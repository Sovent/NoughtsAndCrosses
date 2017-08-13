using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoughtsAndCrosses.Domain;
using NoughtsAndCrosses.Infrastructure;

namespace NoughtsAndCrosses.Application
{
  public class GameFacade : IGameFacade
  {
    public GameFacade(IGameFactory gameFactory, IGameRepository gameRepository)
    {
      _gameFactory = gameFactory ?? throw new ArgumentNullException(nameof(gameFactory));
      _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
      _games = new ConcurrentDictionary<Guid, Game>();
    }

    public async Task<GameSessionStatus> GetGameSessionStatusAsync(Guid gameSessionId)
    {
      var game = await TryGetGameAsync(gameSessionId);

      return game?.GetStatus();
    }

    public async Task<GameSessionStatus> StartGameSessionAsync(Dictionary<string, Sign> playerNames)
    {
      var game = _gameFactory.CreateGame(playerNames);
      _games.TryAdd(game.GameId, game);
      await _gameRepository.SaveGameAsync(game);
      return game.GetStatus();
    }

    public async Task MakeTurnAsync(Guid gameSessionId, string playerName, int xcord, int ycord)
    {
      var game = await TryGetGameAsync(gameSessionId);
      game.MakeTurn(playerName, xcord, ycord);
      _games.TryUpdate(gameSessionId, game, game);
      await _gameRepository.SaveGameAsync(game);
    }

    private async Task<Game> TryGetGameAsync(Guid gameId)
    {
      Game game;
      if (_games.TryGetValue(gameId, out game))
      {
        return game;
      }

      game = await _gameRepository.TryGetGameAsync(gameId);
      if (game != null)
      {
        _games.AddOrUpdate(
          gameId,
          game,
          (id, existingGame) => existingGame.TurnsCount >= game.TurnsCount ? existingGame : game);
        return game;
      }

      return null;
    }

    private readonly IGameFactory _gameFactory;
    private readonly IGameRepository _gameRepository;
    private readonly ConcurrentDictionary<Guid, Game> _games;
  }
}