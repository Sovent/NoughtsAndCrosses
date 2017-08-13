using System;
using System.Linq;

namespace NoughtsAndCrosses.Domain
{
  public class Row
  {
    public Row(Cell[] cells)
    {
      Cells = cells ?? throw new ArgumentNullException(nameof(cells));
    }

    public Cell[] Cells { get; }

    public Sign GetWinnerSign()
    {
      return Cells
        .Select(cell => cell.Sign)
        .Aggregate((winningSign, currentSign) => winningSign == currentSign ? winningSign : Sign.Empty);
    }
  }
}