using PlataformServiceAPI.Dtos;

namespace PlataformServiceAPI.SyncDateService.Http;

public interface ICommandDataClient
{
    Task SendPlatformToCommand(PlatformReadDto plat);
}
