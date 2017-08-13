using System;

namespace NoughtsAndCrosses.Domain
{
  public class Cell
  {
    public Cell(int row, int column, Sign sign)
    {
      Row = row;
      Column = column;
      Sign = sign;
    }

    public int Row { get; }
    public int Column { get; }
    public Sign Sign { get; private set; }

    public void ChangeSign(Sign newSign)
    {
      if (Sign != Sign.Empty)
      {
        throw new InvalidOperationException("Can not change non-empty cell value");
      }

      if (newSign == Sign.Empty)
      {
        throw new InvalidOperationException("Can not set empty sign to cell");
      }

      Sign = newSign;
    }

    protected bool Equals(Cell other)
    {
      return Row == other.Row && Column == other.Column && Sign == other.Sign;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Cell) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        var hashCode = Row;
        hashCode = (hashCode * 397) ^ Column;
        hashCode = (hashCode * 397) ^ (int) Sign;
        return hashCode;
      }
    }

    public static bool operator ==(Cell left, Cell right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Cell left, Cell right)
    {
      return !Equals(left, right);
    }
  }
}