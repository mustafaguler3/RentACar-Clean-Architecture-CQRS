using System;
using Application.Feature.Models.Queries.GetList;
using Application.Feature.Models.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Feature.Models.Profiles
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Model, GetListModelListItemDto>()
				.ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))//c.BrandName' im var onu git c.Brand.Name ' den al dedik
				.ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
				.ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name));

            CreateMap<Model, GetListByDynamicModelListItemDto>()
                .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))//c.BrandName' im var onu git c.Brand.Name ' den al dedik
                .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
                .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name));
            CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();

            CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListItemDto>>().ReverseMap();
        }
	}
}

