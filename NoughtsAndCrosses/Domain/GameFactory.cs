using System;
using System.Collections.Generic;
using System.Linq;

namespace NoughtsAndCrosses.Domain
{
  public class GameFactory : IGameFactory
  {
    public Game CreateGame(Dictionary<string, Sign> players)
    {
      var gameId = Guid.NewGuid();
      var field = InitiateField();
      var firstMovePlayer = ChooseFirstTurnPlayer(players.Keys);
      var game = new Game(gameId, players, field, 0, firstMovePlayer);
      return game;
    }

    private static Field InitiateField()
    {
      var cells = new Cell[FieldSize, FieldSize];
      for (var row = 0; row < FieldSize; row++)
      {
        for (var column = 0; column < FieldSize; column++)
        {
          cells[row, column] = new Cell(row, column, Sign.Empty);
        }
      }

      return new Field(cells);
    }

    private static string ChooseFirstTurnPlayer(IEnumerable<string> players)
    {
      return players.OrderBy(_ => Guid.NewGuid()).First();
    }

    private const int FieldSize = 3;
  }
}