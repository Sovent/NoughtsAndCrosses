using System.ComponentModel.DataAnnotations;

namespace NoughtsAndCrosses.Models
{
  public class MakeTurnRequest
  {
    [Required]
    [MaxLength(20)]
    public string PlayerName { get; set; }
    [Required]
    [Range(0, 2)]
    public int Row { get; set; }
    [Required]
    [Range(0, 2)]
    public int Column { get; set; }
  }
}