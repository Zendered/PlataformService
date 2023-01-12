using AutoMapper;
using CommandsServiceAPI.Data;
using CommandsServiceAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandsServiceAPI.Controllers;
[Route("api/c/platforms/{platformId}[controller]")]
[ApiController]
public class CommandsController : ControllerBase
{
    private readonly ICommandRepo repo;
    private readonly IMapper mapper;

    public CommandsController(ICommandRepo repo, IMapper mapper)
    {
        this.repo = repo;
        this.mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId)
    {
        Console.WriteLine($"--> Hit GetCommandsForPlatform: {platformId}");
        bool repoExists = repo.PlatformExists(platformId);
        if (!repoExists)
        {
            return NotFound();
        }

        var commands = repo.GetCommandsForPlatform(platformId);
        var res = mapper.Map<IEnumerable<CommandReadDto>>(commands);
        return Ok(res);
    }
}
