using PlataformServiceAPI.Models;

namespace PlataformServiceAPI.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
    }

    private static void SeedData(AppDbContext ctx)
    {
        if (!ctx.Platforms.Any())
        {
            Console.WriteLine("--> Seeding Data");
            ctx.Platforms.AddRange(
            new Platform() { Name = "Dot NET", Publisher = "Microsoft", Cost = "free" },
            new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "free" },
            new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "free" }
            );

            ctx.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> Already have data");
        }
    }
}
