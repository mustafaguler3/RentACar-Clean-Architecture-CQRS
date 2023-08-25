using System;
using Application.Feature.Brands.Commands.Update;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Brands.Commands.Delete
{
	public class DeleteBrandCommand : IRequest<DeleteBrandResponse>
	{
		public Guid Id { get; set; }
	}

    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<DeleteBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            //db den kalıcı olarak silmicek - permanent = false ,soft delete
            await _brandRepository.DeleteAsync(brand);
            
            DeleteBrandResponse response = _mapper.Map<DeleteBrandResponse>(brand);

            return response;
        }
    }
}

