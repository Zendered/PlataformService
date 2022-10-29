using PlataformServiceAPI.Data;
using PlataformServiceAPI.Models;

namespace PlataformServiceAPI.Repositories;

public class PlatformRepo : IPlatformRepo
{
    private readonly AppDbContext ctx;

    public PlatformRepo(AppDbContext ctx)
    {
        this.ctx = ctx;
    }

    public void CreatePlatform(Platform plat)
    {
        if (plat is null) throw new ArgumentNullException(nameof(plat));

        ctx.Platforms.Add(plat);
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return ctx.Platforms.ToList();
    }

    public Platform GetPlatformById(int id)
    {
        return ctx.Platforms.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
        return ctx.SaveChanges() >= 0;
    }
}
