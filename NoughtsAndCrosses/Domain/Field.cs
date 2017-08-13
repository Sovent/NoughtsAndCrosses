using System;
using System.Collections.Generic;

namespace NoughtsAndCrosses.Domain
{
  public class Field
  {
    public Field(Cell[,] cells)
    {
      Cells = cells ?? throw new ArgumentNullException(nameof(cells));
      if (cells.GetLength(0) != cells.GetLength(1))
      {
        throw new ArgumentException("Field should have equal number of rows and columns");
      }

      _fieldSize = cells.GetLength(0);
    }

    public Cell[,] Cells { get; }

    public void ChangeSign(int row, int column, Sign sign)
    {
      if (row < 0 || row >= _fieldSize || column < 0 || column >= _fieldSize)
      {
        throw new ArgumentOutOfRangeException("Coordinates are out of range of field");
      }

      Cells[row,column].ChangeSign(sign);
    }

    public IEnumerable<Row> GetRows()
    {
      for (var row = 0; row < _fieldSize; row++)
      {
        var currentRow = new Cell[_fieldSize];
        for (var column = 0; column < _fieldSize; column++)
        {
          currentRow[column] = Cells[row, column];
        }
        yield return new Row(currentRow);
      }

      for (var column = 0; column < _fieldSize; column++)
      {
        var currentColumn = new Cell[_fieldSize];
        for (var row = 0; row < _fieldSize; row++)
        {
          currentColumn[row] = Cells[row, column];
        }
        yield return new Row(currentColumn);
      }

      var firstDiagonal = new Cell[_fieldSize];
      for (var index = 0; index < _fieldSize; index++)
      {
        firstDiagonal[index] = Cells[index, index];
      }
      yield return new Row(firstDiagonal);

      var secondDiagonal = new Cell[_fieldSize];
      for (int rowCursor = _fieldSize - 1, columnCursor = 0; columnCursor < _fieldSize; rowCursor--, columnCursor++)
      {
        secondDiagonal[columnCursor] = Cells[rowCursor, columnCursor];
      }
      yield return new Row(secondDiagonal);
    }

    private readonly int _fieldSize;
  }
}