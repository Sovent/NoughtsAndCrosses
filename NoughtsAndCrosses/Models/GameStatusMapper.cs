using System.Linq;
using NoughtsAndCrosses.Application;
using NoughtsAndCrosses.Domain;

namespace NoughtsAndCrosses.Models
{
  public static class GameStatusMapper
  {
    public static GameStatus ToApiModel(this GameSessionStatus gameSessionStatus)
    {
      if (gameSessionStatus == null)
      {
        return null;
      }

      var crossesPlayer = gameSessionStatus.Players.First(pair => pair.Value == Sign.Crosses).Key;
      var noughtsPlayer = gameSessionStatus.Players.First(pair => pair.Value == Sign.Noughts).Key;
      var winnerRow = gameSessionStatus.WinnerRow?.Cells
        .Select(row => new[] {row.Row, row.Column})
        .ToArray();
      var winnerSign = gameSessionStatus.WinnerRow?.GetWinnerSign();
      string winner;
      switch (winnerSign)
      {
          case Sign.Crosses:
            winner = crossesPlayer;
            break;
          case Sign.Noughts:
            winner = noughtsPlayer;
            break;
          default:
            winner = null;
            break;
      }
      var gameStatus = new GameStatus(
        gameSessionStatus.GameId, 
        gameSessionStatus.CurrentTurnPlayer, 
        gameSessionStatus.TurnsCount,
        crossesPlayer,
        noughtsPlayer,
        winnerRow,
        winner,
        gameSessionStatus.Field);

      return gameStatus;
    }
  }
}