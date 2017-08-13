using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoughtsAndCrosses.Domain;

namespace NoughtsAndCrosses.UnitTests
{
  [TestClass]
  public class CellTests
  {
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void ChangeNonEmptyCellSign_ThrowsException()
    {
      var cell = new Cell(1, 1, Sign.Crosses);

      cell.ChangeSign(Sign.Noughts);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void ChangeCellToEmpty_ThrowsException()
    {
      var cell = new Cell(0,0, Sign.Empty);
      
      cell.ChangeSign(Sign.Empty);
    }

    [TestMethod]
    public void ChangeEmptyCellToNonEmpty_ChangesSign()
    {
      var cell = new Cell(0, 0, Sign.Empty);

      cell.ChangeSign(Sign.Crosses);

      Assert.AreEqual(Sign.Crosses, cell.Sign);
    }
  }
}
