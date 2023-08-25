using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class FuelRepository : EfRepositoryBase<Fuel, Guid, VtContext>, IFuelRepository
    {
        public FuelRepository(VtContext context) : base(context)
        {
        }
    }
}

