using CommandsServiceAPI.Models;

namespace CommandsServiceAPI.Data;

public class CommandRepo : ICommandRepo
{
    private readonly AppDbContext ctx;

    public CommandRepo(AppDbContext ctx)
    {
        this.ctx = ctx;
    }

    public void CreateCommand(int platformId, Command command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        command.PlatformId = platformId;
        ctx.Commands.Add(command);
    }

    public void CreatePlatform(Platform plat)
    {
        if (plat == null)
        {
            throw new ArgumentNullException(nameof(plat));
        }

        ctx.Platforms.Add(plat);
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return ctx.Platforms.ToList();
    }

    public Command GetCommand(int platformId, int commandId)
    {
        return ctx.Commands
            .Where(c => c.PlatformId == platformId && c.Id == commandId)
            .FirstOrDefault();

    }

    public IEnumerable<Command> GetCommandsForPlatform(int platformId)
    {
        return ctx.Commands
            .Where(c => c.PlatformId == platformId)
            .OrderBy(c => c.Platform.Name);
    }

    public bool PlatformExists(int platformId)
    {
        return ctx.Platforms.Any(p => p.Id == platformId);
    }

    public bool SaveChanges()
    {
        return ctx.SaveChanges() >= 0;
    }
}
