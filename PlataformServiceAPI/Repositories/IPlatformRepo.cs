using PlataformServiceAPI.Models;

namespace PlataformServiceAPI.Repositories;

public interface IPlatformRepo
{
    void CreatePlatform(Platform plat);
    IEnumerable<Platform> GetAllPlatforms();
    Platform GetPlatformById(int id);
    bool SaveChanges();
}
