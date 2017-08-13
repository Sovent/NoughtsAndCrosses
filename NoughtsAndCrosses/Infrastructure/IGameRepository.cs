using System;
using System.Threading.Tasks;
using NoughtsAndCrosses.Domain;

namespace NoughtsAndCrosses.Infrastructure
{
  public interface IGameRepository
  {
    Task<Game> TryGetGameAsync(Guid gameId);
    Task SaveGameAsync(Game game);
  }
}