using System;
using System.Collections.Generic;
using NoughtsAndCrosses.Domain;

namespace NoughtsAndCrosses.Application
{
  public class GameSessionStatus
  {
    public GameSessionStatus(
      Guid gameId, 
      string currentTurnPlayer, 
      int turnsCount, 
      IReadOnlyDictionary<string, Sign> players, 
      Row winnerRow, 
      Sign[,] field)
    {
      GameId = gameId;
      CurrentTurnPlayer = currentTurnPlayer ?? throw new ArgumentNullException(nameof(currentTurnPlayer));
      TurnsCount = turnsCount;
      Players = players ?? throw new ArgumentNullException(nameof(players));
      WinnerRow = winnerRow;
      Field = field ?? throw new ArgumentNullException(nameof(field));
    }

    public Guid GameId { get; }
    public string CurrentTurnPlayer { get; }
    public int TurnsCount { get; }
    public IReadOnlyDictionary<string, Sign> Players { get; }
    public Row WinnerRow { get; }
    public Sign[,] Field { get; }
  }
}