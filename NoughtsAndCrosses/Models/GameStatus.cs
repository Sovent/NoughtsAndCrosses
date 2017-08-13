using System;
using NoughtsAndCrosses.Domain;

namespace NoughtsAndCrosses.Models
{
  public class GameStatus
  {
    public GameStatus(
      Guid gameId, 
      string currentTurnPlayer, 
      int turnsCount, 
      string crossesPlayer,
      string noughtsPlayer,
      int[][] winnerRow, 
      string winnerPlayerName, 
      Sign[,] field)
    {
      GameId = gameId;
      CurrentTurnPlayer = currentTurnPlayer;
      TurnsCount = turnsCount;
      CrossesPlayer = crossesPlayer;
      NoughtsPlayer = noughtsPlayer;
      WinnerRow = winnerRow;
      WinnerPlayerName = winnerPlayerName;
      Field = field;
    }

    public Guid GameId { get; }
    public string CurrentTurnPlayer { get; }
    public int TurnsCount { get; }
    public string CrossesPlayer { get; }
    public string NoughtsPlayer { get; }
    public int[][] WinnerRow { get; }
    public string WinnerPlayerName { get; }
    public Sign[,] Field { get; }
  }
}