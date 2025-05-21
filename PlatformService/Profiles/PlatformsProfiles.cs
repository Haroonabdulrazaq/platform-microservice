namespace PlatformService.Profiles
{
  using AutoMapper;
  using PlatformService.Dtos;
  using PlatformService.Models;

  public class PlatformsProfiles : Profile
  {
    public PlatformsProfiles()
    {
      // Source -> Target
      CreateMap<Platform, PlatformReadDto>();
      CreateMap<PlatformCreateDto, Platform>();
      CreateMap<PlatformUpdateDto, Platform>();
    }
  }

  public class PlatformReadDto
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public string Cost { get; set; } = string.Empty;
  }
}