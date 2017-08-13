using System.ComponentModel.DataAnnotations;

namespace NoughtsAndCrosses.Models
{
  public class InitiateNewGameRequest
  {
    [Required]
    [MaxLength(20)]
    public string NoughtsPlayerName { get; set; }

    [Required]
    [MaxLength(20)]
    public string CrossesPlayerName { get; set; }
  }
}