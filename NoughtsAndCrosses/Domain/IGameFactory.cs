using System.Collections.Generic;

namespace NoughtsAndCrosses.Domain
{
  public interface IGameFactory
  {
    Game CreateGame(Dictionary<string, Sign> players);
  }
}