using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlatformsController : ControllerBase
  {
    private readonly IPlatformRepository _platformRepository;
    private readonly IMapper _mapper;

    public PlatformsController(IPlatformRepository platformRepository, IMapper mapper)
    {
      _platformRepository = platformRepository;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
      Console.WriteLine("--> Getting Platforms from PlatformService");
      return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(_platformRepository.GetAllPlatforms()));
    }

    [HttpGet("{id}")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
      Console.WriteLine("--> Getting Platform by Id from PlatformService");
      var platform = _platformRepository.GetPlatformById(id);

      if (platform == null)
      {
        return NotFound();
      }

      return Ok(_mapper.Map<PlatformReadDto>(platform));
    }

    [HttpPost]
    public IActionResult CreatePlatform(PlatformCreateDto platformCreateDto)
    {
      var platformModel = _mapper.Map<PlatformCreateDto, Platform>(platformCreateDto);
      _platformRepository.CreatePlatform(platformModel);
      _platformRepository.SaveChanges();

      var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

      return Created(platformReadDto.Id.ToString(), platformReadDto);
    }
  }
}