using System;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Brands.Queries.GetList
{
	public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandListItemDto>>,ICacheableRequest
	{
		public PageRequest PageRequest { get; set; }

        public string CacheKEy => $"GetListBrandQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

        public string CacheKey => throw new NotImplementedException();

        public bool ByPassCache { get; }
        public TimeSpan? SlidingExpiration { get; set; }

        public string? CacheGroupKey => "GetBrands";
    }

    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandListItemDto>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetListBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<GetListResponse<GetListBrandListItemDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            Paginate<Brand> brands = await _brandRepository.GetListAsync(
                index:request.PageRequest.PageIndex,
                size:request.PageRequest.PageSize,
                cancellationToken:cancellationToken);

            GetListResponse<GetListBrandListItemDto> response = _mapper.Map<GetListResponse<GetListBrandListItemDto>>(brands);
            return response;

        }
    }
}

