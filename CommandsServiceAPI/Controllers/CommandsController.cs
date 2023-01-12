using AutoMapper;
using CommandsServiceAPI.Data;
using CommandsServiceAPI.Dtos;
using CommandsServiceAPI.Models;
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

    [HttpGet("{commandId}", Name = "GetCommandForPlatform")]
    public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId, int commandId)
    {
        Console.WriteLine($"--> Hit GetCommandForPlatform: {platformId} / {commandId}");

        bool repoExists = repo.PlatformExists(platformId);
        var command = repo.GetCommand(platformId, commandId);
        if (!repoExists || command is null)
        {
            return NotFound();
        }

        var res = mapper.Map<CommandReadDto>(command);

        return Ok(res);
    }

    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto commandDto)
    {
        Console.WriteLine($"--> Hit CreateCommandForPlatform: {platformId}");
        bool repoExists = repo.PlatformExists(platformId);
        if (!repoExists)
        {
            return NotFound();
        }

        var command = mapper.Map<Command>(commandDto);
        repo.CreateCommand(platformId, command);
        repo.SaveChanges();

        var commandReadDto = mapper.Map<CommandReadDto>(command);

        return CreatedAtRoute(nameof(GetCommandForPlatform), new { platformId, commandId = commandReadDto.Id, commandReadDto });
    }
}
