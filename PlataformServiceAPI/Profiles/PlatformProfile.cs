using AutoMapper;
using PlataformServiceAPI.Dtos;
using PlataformServiceAPI.Models;

namespace PlataformServiceAPI.Profiles;

public class PlatformProfile : Profile
{
	public PlatformProfile()
	{
		CreateMap<Platform, PlatformCreateDto>().ReverseMap();
		CreateMap<Platform, PlatformReadDto>().ReverseMap();
	}
}
