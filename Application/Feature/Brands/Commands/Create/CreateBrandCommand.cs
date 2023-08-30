using System;
using Application.Feature.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Brands.Commands.Create;
	public class CreateBrandCommand : IRequest<CreatedBrandResponse>,ITransactionRequest,ICacheRemoverRequest,ILoggableRequest
	{

	public string Name { get; set; }

    public string CacheKey => "";

    public bool ByPassCache => false;

    public string? CacheGroupKey => "GetBrands";
}

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {

        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;

    public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {

        await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);

            Brand brand = _mapper.Map<Brand>(request);
            brand.Id = Guid.NewGuid();

        //Brand brand2 = _mapper.Map<Brand>(request);
        //brand2.Id = Guid.NewGuid();

        await _brandRepository.AddAsyn(brand);
        //await _brandRepository.AddAsyn(brand2);

        CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);

            return createdBrandResponse;
        }
    }


