using System;
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BrandRepository : EfRepositoryBase<Brand, Guid, VtContext>,IBrandRepository
    {
        public BrandRepository(VtContext context) : base(context)
        {
        }
    }
}

