using PlatformService.Models;

namespace PlatformService.Data
{

  public static class PrepDb
  {
    public static void PrepPopulation(IApplicationBuilder app, bool isProd)
    {
      using (var serviceScope = app.ApplicationServices.CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
        if (context == null)
        {
          throw new ArgumentNullException(nameof(context), "AppDbContext could not be resolved from the service provider.");
        }
        SeedData(context, isProd);
      }
    }

    private static void SeedData(AppDbContext context, bool isProd)
    {
      if (!context.Platforms.Any())
      {
        Console.WriteLine(" --> Seeding data...");

        context.Platforms.AddRange(
          new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
          new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
          new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
        );

        context.SaveChanges();
      }
      else
      {
        Console.WriteLine(" --> We already have data.");
      }
    }
  }
}