using System;
using AutoMapper;

namespace WebXantaquaApi.Services.Mapping.AutoMapper
{
	public class AutoMapperConfig : Profile
	{
		public static MapperConfiguration RegisterMappings()
		{
			return new MapperConfiguration(profiles =>
			{
				profiles.AddProfile(new MappingDtoToEntity());
				profiles.AddProfile(new MappingEntityToDto());
			});
		}
	}
}