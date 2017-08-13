using System;
using NoughtsAndCrosses.Application;
using NoughtsAndCrosses.Domain;

namespace NoughtsAndCrosses.Infrastructure
{
  public static class GameStatusProviderExtensions
  {
    public static GameSessionStatus GetStatus(this Game game)
    {
      if (game == null) throw new ArgumentNullException(nameof(game));

      var fieldSize = game.Field.Cells.GetLength(0);
      var field = new Sign[fieldSize, fieldSize];
      foreach (var cell in game.Field.Cells)
      {
        field[cell.Row, cell.Column] = cell.Sign;
      }

      return new GameSessionStatus(
        game.GameId, 
        game.CurrentMovePlayer, 
        game.TurnsCount, 
        game.Players, 
        game.GetWinner(),
        field);
    }
  }
}