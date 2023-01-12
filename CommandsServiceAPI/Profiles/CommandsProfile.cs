using AutoMapper;
using CommandsServiceAPI.Dtos;
using CommandsServiceAPI.Models;

namespace CommandsServiceAPI.Profiles;

public class CommandsProfile : Profile
{
	public CommandsProfile()
	{
		//platforms
		CreateMap<Platform, PlatformReadDto>();

		//commands
		CreateMap<CommandCreateDto, Command>();
		CreateMap<Command, CommandReadDto>();
	}
}
