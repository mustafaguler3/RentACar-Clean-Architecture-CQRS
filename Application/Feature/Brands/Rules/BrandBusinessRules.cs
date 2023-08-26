using System;
using Application.Feature.Brands.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions.Types;
using Domain.Entities;

namespace Application.Feature.Brands.Rules
{
	public class BrandBusinessRules : BaseBusinessRules
	{
		private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
        {
            Brand? result = await _brandRepository.GetAsync(predicate: b => b.Name.ToLower() == name.ToLower());

            if(result != null)
            {
                throw new BusinessException(BrandMessages.BrandNameExists);
            }
        }
    }
}

