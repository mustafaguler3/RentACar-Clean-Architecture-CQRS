using System;
using MediatR;

namespace Application.Feature.Brands.Commands.Create
{	//brand nesnesinin kendisi aslında,her commandin bir handler ı olmalı
	public class CreateBrandCommand : IRequest<CreatedBrandResponse>
	{
		public string Name { get; set; }
	}

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        public Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
            createdBrandResponse.Name = request.Name;
            createdBrandResponse.Id = new Guid();

            return null;
        }
    }
}

