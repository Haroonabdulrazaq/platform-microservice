using PlatformService.Models;

namespace PlatformService.Data

{
  public class PlatformRepository : IPlatformRepository
  {
    private readonly AppDbContext _context;

    public PlatformRepository(AppDbContext context)
    {
      _context = context;
    }
    public void CreatePlatform(Platform plat)
    {
      if (plat == null)
      {
        throw new ArgumentNullException(nameof(plat));
      }

      _context.Platforms.Add(plat);
      _context.SaveChanges();
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
      return _context.Platforms.ToList();
    }

    public Platform? GetPlatformById(int id)
    {
      return _context.Platforms.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return _context.SaveChanges() >= 0;
    }
  }
}