using System;
using Application.Feature.Brands.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Feature.Brands.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Brand, CreateBrandCommand>().ReverseMap();
			CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
		}
	}
}

