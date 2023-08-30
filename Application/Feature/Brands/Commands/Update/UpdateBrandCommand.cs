using System;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Brands.Commands.Update
{
	public class UpdateBrandCommand : IRequest<UpdateBrandResponse>,ICacheRemoverRequest
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

        public string? CacheKey => "";

        public bool ByPassCache => false;

        public string? CacheGroupKey => "GetBrands";
    }

    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            brand = _mapper.Map(request, brand);

            await _brandRepository.UpdateAsync(brand);

            UpdateBrandResponse response = _mapper.Map<UpdateBrandResponse>(brand);

            return response;
        }
    }
}

