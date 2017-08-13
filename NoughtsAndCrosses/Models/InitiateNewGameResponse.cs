using System;

namespace NoughtsAndCrosses.Models
{
  public class InitiateNewGameResponse
  {
    public InitiateNewGameResponse(Guid gameId)
    {
      GameId = gameId;
    }

    public Guid GameId { get; }
  }
}