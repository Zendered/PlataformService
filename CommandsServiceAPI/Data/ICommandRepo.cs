using CommandsServiceAPI.Models;

namespace CommandsServiceAPI.Data;

public interface ICommandRepo
{
    bool SaveChanges();

    // platform
    IEnumerable<Platform> GetAllPlatforms();
    void CreatePlatform(Platform plat);
    bool PlatformExists(int platformId);

    // command
    IEnumerable<Command> GetCommandsForPlatform(int platformId);
    Command GetCommand(int platformId, int commandId);
    void CreateCommand(int platformId, Command command);
}
