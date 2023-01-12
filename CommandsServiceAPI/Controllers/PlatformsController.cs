using AutoMapper;
using CommandsServiceAPI.Data;
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

	[HttpPost]
	public ActionResult TestInboundConnection()
	{
		Console.WriteLine("--> Inbound POST # Command Service");

		return Ok("Inbound test of from Platforms Controller");
	}
}
