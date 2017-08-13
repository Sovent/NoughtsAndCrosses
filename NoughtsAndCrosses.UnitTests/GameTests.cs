using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoughtsAndCrosses.Domain;

namespace NoughtsAndCrosses.UnitTests
{
  [TestClass]
  public class GameTests
  {
    [TestInitialize]
    public void SetUp()
    {
      var field = new Field(new[,]
      {
        {
          new Cell(0, 0, Sign.Empty),
          new Cell(0, 1, Sign.Empty)
        },
        {
          new Cell(1, 0, Sign.Empty),
          new Cell(1, 1, Sign.Empty)
        }
      });
      _game = new Game(
        Guid.NewGuid(), 
        new Dictionary<string, Sign>
        {
          ["Max"] = Sign.Crosses,
          ["Steve"] = Sign.Noughts
        },
        field,
        0,
        "Max");
    }

    [TestMethod]
    public void MakeTurn_ShiftsCurrentPlayerToNext()
    {
      _game.MakeTurn("Max", 0, 0);

      Assert.AreEqual("Steve", _game.CurrentMovePlayer);
    }

    [TestMethod]
    public void MakeTwoTurns_ShiftsCurrentPlayerToSamePlayer()
    {
      _game.MakeTurn("Max", 0, 0);
      _game.MakeTurn("Steve", 1, 0);

      Assert.AreEqual("Max", _game.CurrentMovePlayer);
    }

    [TestMethod]
    public void MakeTurn_IncrementTurnsCount()
    {
      _game.MakeTurn("Max", 1, 0);

      Assert.AreEqual(1, _game.TurnsCount);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void MakeTurnForNotCurrentTurnPlayer_ThrowsException()
    {
      _game.MakeTurn("Steve", 1, 1);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void MakeTurnWhenWinnerIsDetermined_ThrowsException()
    {
      var field = new Field(new[,]
      {
        {
          new Cell(0, 0, Sign.Crosses),
          new Cell(0, 1, Sign.Crosses)
        },
        {
          new Cell(1, 0, Sign.Noughts),
          new Cell(1, 1, Sign.Empty)
        }
      });
      _game = new Game(
        Guid.NewGuid(),
        new Dictionary<string, Sign>
        {
          ["Max"] = Sign.Crosses,
          ["Steve"] = Sign.Noughts
        },
        field,
        3,
        "Steve");

      _game.MakeTurn("Steve", 1, 1);
    }

    [TestMethod]
    public void WhenWinnerIsNotDetermined_WinnerReturnsNull()
    {
      Assert.IsNull(_game.GetWinner());
    }

    [TestMethod]
    public void WhenWinnerIsDetermined_WinnerReturnsProperRow()
    {
      var field = new Field(new[,]
      {
        {
          new Cell(0, 0, Sign.Crosses),
          new Cell(0, 1, Sign.Crosses)
        },
        {
          new Cell(1, 0, Sign.Noughts),
          new Cell(1, 1, Sign.Empty)
        }
      });
      _game = new Game(
        Guid.NewGuid(),
        new Dictionary<string, Sign>
        {
          ["Max"] = Sign.Crosses,
          ["Steve"] = Sign.Noughts
        },
        field,
        3,
        "Steve");

      var winnerRow = _game.GetWinner();

      Assert.AreEqual(Sign.Crosses, winnerRow.GetWinnerSign());
      Assert.IsTrue(winnerRow.Cells.SequenceEqual(new[]
      {
        new Cell(0, 0, Sign.Crosses),
        new Cell(0, 1, Sign.Crosses)
      }));
    }

    private Game _game;
  }
}