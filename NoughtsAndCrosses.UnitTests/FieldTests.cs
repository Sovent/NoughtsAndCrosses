using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoughtsAndCrosses.Domain;

namespace NoughtsAndCrosses.UnitTests
{
  [TestClass]
  public class FieldTests
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ChangeSignOfCellOutOfFieldRange_ThrowsException()
    {
      var field = new Field(new[,]
      {
          { new Cell(0, 0, Sign.Empty) }
      });

      field.ChangeSign(1, 1, Sign.Crosses);
    }

    [TestMethod]
    public void ChangeSignOfCell_CellChanged()
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

      field.ChangeSign(1, 0, Sign.Crosses);

      Assert.AreEqual(Sign.Crosses, field.Cells[1,0].Sign);
    }

    [TestMethod]
    public void GetFieldRows_ReturnsAllRows()
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
      void AssertContainsRowWithCells(IEnumerable<Row> rows, params Cell[] cells)
      {
        Assert.IsTrue(rows.Any(row => !row.Cells.Except(cells).Any()));
      }

      AssertContainsRowWithCells(field.GetRows(), new Cell(0, 0, Sign.Empty), new Cell(0, 1, Sign.Empty));
      AssertContainsRowWithCells(field.GetRows(), new Cell(0, 0, Sign.Empty), new Cell(1, 0, Sign.Empty));
      AssertContainsRowWithCells(field.GetRows(), new Cell(0, 0, Sign.Empty), new Cell(1, 1, Sign.Empty));
      AssertContainsRowWithCells(field.GetRows(), new Cell(1, 0, Sign.Empty), new Cell(0, 1, Sign.Empty));
      AssertContainsRowWithCells(field.GetRows(), new Cell(0, 1, Sign.Empty), new Cell(1, 1, Sign.Empty));
      AssertContainsRowWithCells(field.GetRows(), new Cell(1, 0, Sign.Empty), new Cell(1, 1, Sign.Empty));
    }
  }
}