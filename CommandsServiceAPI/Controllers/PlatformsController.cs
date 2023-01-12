using AutoMapper;
using CommandsServiceAPI.Data;
using CommandsServiceAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandsServiceAPI.Controllers;
[Route("api/c/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
	private readonly ICommandRepo repo;
	private readonly IMapper mapper;

	public PlatformsController(ICommandRepo repo, IMapper mapper)
	{
		this.repo = repo;
		this.mapper = mapper;
	}

	[HttpGet]
	public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
	{
		Console.WriteLine("--> Getting Platforms from CommandsService");

		var platformItems = repo.GetAllPlatforms();
		var res = mapper.Map<IEnumerable<PlatformReadDto>>(platformItems);

		return Ok(res);
	}

	[HttpPost]
	public ActionResult TestInboundConnection()
	{
		Console.WriteLine("--> Inbound POST # Command Service");

		return Ok("Inbound test of from Platforms Controller");
	}
}
