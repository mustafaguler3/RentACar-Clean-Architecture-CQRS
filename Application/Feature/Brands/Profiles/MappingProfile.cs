using System;
using Application.Feature.Brands.Commands.Create;
using Application.Feature.Brands.Commands.Update;
using Application.Feature.Brands.Queries.GetById;
using Application.Feature.Brands.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Feature.Brands.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, CreatedBrandResponse>().ReverseMap();


            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdateBrandResponse>().ReverseMap();

            CreateMap<Brand, GetListBrandListItemDto>().ReverseMap();
			CreateMap<Brand, GetByIdBrandResponse>();
            CreateMap<Paginate<Brand>, GetListResponse<GetListBrandListItemDto>>().ReverseMap();
		}
	}
}

