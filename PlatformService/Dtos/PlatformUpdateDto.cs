using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
  public class PlatformUpdateDto
  {
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Publisher { get; set; } = string.Empty;
    [Required]
    public string Cost { get; set; } = string.Empty;
  }
}
// This code defines a data transfer object (DTO) for reading platform information.