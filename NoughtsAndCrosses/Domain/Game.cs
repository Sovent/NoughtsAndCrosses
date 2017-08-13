using System;
using System.Collections.Generic;
using System.Linq;

namespace NoughtsAndCrosses.Domain
{
  public class Game
  {
    public Game(Guid gameId, Dictionary<string, Sign> players, Field field, int turnsCount, string currentMovePlayer)
    {
      GameId = gameId;
      Players = players ?? throw new ArgumentNullException(nameof(players));
      Field = field ?? throw new ArgumentNullException(nameof(field));
      TurnsCount = turnsCount;
      CurrentMovePlayer = currentMovePlayer ?? throw new ArgumentNullException(nameof(currentMovePlayer));
    }

    public Guid GameId { get; }
    public Dictionary<string, Sign> Players { get; }
    public Field Field { get; }
    public int TurnsCount { get; private set; }
    public string CurrentMovePlayer { get; private set; }

    public void MakeTurn(string player, int row, int column)
    {
      if (GetWinner() != null)
      {
        throw new InvalidOperationException($"Game is finished, winner is {GetWinner()}");  
      }

      if (CurrentMovePlayer != player)
      {
        throw new InvalidOperationException($"It is turn of player {CurrentMovePlayer}");
      }

      var playerSign = Players[player];
      Field.ChangeSign(row, column, playerSign);
      MovePlayerTurn();
      TurnsCount++;
    }

    public Row GetWinner() => Field.GetRows().FirstOrDefault(row => row.GetWinnerSign() != Sign.Empty);

    private void MovePlayerTurn()
    {
      var players = Players.Keys.ToArray();
      var currentPlayerIndex = Array.IndexOf(players, CurrentMovePlayer);
      var nextPlayerIndex = currentPlayerIndex == (players.Length - 1) ? 0 : (currentPlayerIndex + 1);
      CurrentMovePlayer = players[nextPlayerIndex];
    }
  }
}