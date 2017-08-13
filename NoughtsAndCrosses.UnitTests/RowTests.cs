using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoughtsAndCrosses.Domain;

namespace NoughtsAndCrosses.UnitTests
{
  [TestClass]
  public class RowTests
  {
    [TestMethod]
    public void WhenContainsOnlyEmptyCells_WinnerSignIsEmpty()
    {
      var row = new Row(new[]
      {
        new Cell(0, 0, Sign.Empty),
        new Cell(1, 0, Sign.Empty),
        new Cell(2, 0, Sign.Empty)
      });

      var winnerSign = row.GetWinnerSign();

      Assert.AreEqual(Sign.Empty, winnerSign);
    }

    [TestMethod]
    public void WhenContainsAtLeastOneEmptyCell_WinnerSignIsEmpty()
    {
      var row = new Row(new[]
      {
        new Cell(1, 0, Sign.Empty),
        new Cell(1, 1, Sign.Crosses),
        new Cell(1, 2, Sign.Noughts)
      });

      var winnerSign = row.GetWinnerSign();

      Assert.AreEqual(Sign.Empty, winnerSign);
    }

    [TestMethod]
    public void WhenContainsAllCrosses_WinnerSignIsCross()
    {
      var row = new Row(new[]
      {
        new Cell(0, 0, Sign.Crosses),
        new Cell(1, 1, Sign.Crosses),
        new Cell(2, 2, Sign.Crosses)
      });

      var winnerSign = row.GetWinnerSign();

      Assert.AreEqual(Sign.Crosses, winnerSign);
    }

    [TestMethod]
    public void WhenCointainsAllNoughts_WinnerSignIsNoughts()
    {
      var row = new Row(new[]
      {
        new Cell(2, 0, Sign.Noughts),
        new Cell(1, 1, Sign.Noughts),
        new Cell(0, 2, Sign.Noughts)
      });

      var winnerSign = row.GetWinnerSign();

      Assert.AreEqual(Sign.Noughts, winnerSign);
    }

    [TestMethod]
    public void WhenCointainsMixedNoughtsAndCrosses_WinnerSignIsEmpty()
    {
      var row = new Row(new[]
      {
        new Cell(2, 0, Sign.Noughts),
        new Cell(2, 1, Sign.Crosses),
        new Cell(2, 2, Sign.Noughts)
      });

      var winnerSign = row.GetWinnerSign();

      Assert.AreEqual(Sign.Empty, winnerSign);
    }
  }
}