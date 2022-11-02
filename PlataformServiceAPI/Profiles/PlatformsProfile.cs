using AutoMapper;
using PlataformServiceAPI.Dtos;
using PlataformServiceAPI.Models;

namespace PlataformServiceAPI.Profiles;

public class PlatformsProfile : Profile
{
	public PlatformsProfile()
	{
		CreateMap<Platform, PlatformCreateDto>().ReverseMap();
		CreateMap<Platform, PlatformReadDto>().ReverseMap();
	}
}
