using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NoughtsAndCrosses.Domain;

namespace NoughtsAndCrosses.Infrastructure
{
  public class GameFileRepository : IGameRepository
  {
    public GameFileRepository(string gamesFilePath)
    {
      _gamesFilePath = gamesFilePath ?? throw new ArgumentNullException(nameof(gamesFilePath));
    }

    public async Task<Game> TryGetGameAsync(Guid gameId)
    {
      var gameFilePath = GetGameFilePath(gameId);
      if (!File.Exists(gameFilePath))
      {
        return null;
      }

      using (var streamReader = new StreamReader(
        new FileStream(gameFilePath, FileMode.Open, FileAccess.Read)))
      {
        var serializedGame = await streamReader.ReadToEndAsync();
        return JsonConvert.DeserializeObject<Game>(serializedGame);
      }
    }

    public async Task SaveGameAsync(Game game)
    {
      if (game == null) throw new ArgumentNullException(nameof(game));

      var gameFilePath = GetGameFilePath(game.GameId);
      var serializedGame = JsonConvert.SerializeObject(game);
      using (var streamWriter = new StreamWriter(
        new FileStream(gameFilePath, FileMode.Create, FileAccess.Write)))
      {
        await streamWriter.WriteAsync(serializedGame);
      }
    }

    private string GetGameFilePath(Guid gameId)
    {
      return Path.Combine(_gamesFilePath, $"{gameId:N}.game");
    }

    private readonly string _gamesFilePath;
  }
}