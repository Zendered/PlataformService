using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlataformServiceAPI.Dtos;
using PlataformServiceAPI.Models;
using PlataformServiceAPI.Repositories;

namespace PlataformServiceAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
	private readonly IPlatformRepo repo;
	private readonly IMapper mapper;

	public PlatformsController(IPlatformRepo repo, IMapper mapper)
	{
		this.repo = repo;
		this.mapper = mapper;
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
	public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto newPlatform)
	{
		Console.WriteLine("Creating platform...");
		var platform = mapper.Map<Platform>(newPlatform);
		repo.CreatePlatform(platform);
		repo.SaveChanges();

		var returnPlatform = mapper.Map<PlatformReadDto>(platform);
		return CreatedAtAction(nameof(GetPlatformsById), new { platformId = returnPlatform.Id }, returnPlatform);
	}
}
