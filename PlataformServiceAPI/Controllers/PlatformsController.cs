using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlataformServiceAPI.Dtos;
using PlataformServiceAPI.Models;
using PlataformServiceAPI.Repositories;
using PlataformServiceAPI.SyncDateService.Http;

namespace PlataformServiceAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
	private readonly IPlatformRepo repo;
	private readonly IMapper mapper;
	private readonly ICommandDataClient commandDataClient;

	public PlatformsController(IPlatformRepo repo, IMapper mapper, ICommandDataClient commandDataClient)
	{
		this.repo = repo;
		this.mapper = mapper;
		this.commandDataClient = commandDataClient;
	}

	[HttpGet]
	public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
	{
		Console.WriteLine("Getting platforms...");
		var platforms = repo.GetAllPlatforms();

		return Ok(mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
	}

	[HttpGet("{platformId}")]
	public ActionResult<PlatformReadDto> GetPlatformsById(int platformId)
	{
		Console.WriteLine("Getting platform...");
		var platform = repo.GetPlatformById(platformId);
		var res = mapper.Map<PlatformReadDto>(platform);

		return platform is not null ? Ok(res) : NotFound();
	}

	[HttpPost]
	public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto newPlatform)
	{
		Console.WriteLine("Creating platform...");
		var platform = mapper.Map<Platform>(newPlatform);
		repo.CreatePlatform(platform);
		repo.SaveChanges();

		var returnPlatform = mapper.Map<PlatformReadDto>(platform);

		try
		{
			await commandDataClient.SendPlatformToCommand(returnPlatform);
		}
		catch (Exception ex)
		{

			Console.WriteLine($"--> Could not send Synchronously: {ex.Message}");
		}

		return CreatedAtAction(nameof(GetPlatformsById), new { platformId = returnPlatform.Id }, returnPlatform);
	}
}
