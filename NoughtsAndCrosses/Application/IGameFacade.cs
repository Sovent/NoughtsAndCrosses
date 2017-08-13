using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoughtsAndCrosses.Domain;

namespace NoughtsAndCrosses.Application
{
  public interface IGameFacade
  {
    Task<GameSessionStatus> GetGameSessionStatusAsync(Guid gameSessionId);
    Task<GameSessionStatus> StartGameSessionAsync(Dictionary<string, Sign> playerNames);
    Task MakeTurnAsync(Guid gameSessionId, string playerName, int xcord, int ycord);
  }
}