using System;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Models.Queries.GetList
{
	public class GetListModelQuery : IRequest<GetListResponse<GetListModelListItemDto>>
	{
        public PageRequest PageRequest { get; set; }
    }

    public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, GetListResponse<GetListModelListItemDto>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetListModelQueryHandler(IMapper mapper, IModelRepository modelRepository)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
        }

        public async Task<GetListResponse<GetListModelListItemDto>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
        {
            Paginate<Model> models = await _modelRepository.GetListAsync(
               include: m => m.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),//join yaptık, Eager loading
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize);

            var response = _mapper.Map<GetListResponse<GetListModelListItemDto>>(models);

            return response;
        }
    }
}

