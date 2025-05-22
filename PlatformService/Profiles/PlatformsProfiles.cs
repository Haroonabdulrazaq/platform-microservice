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
}