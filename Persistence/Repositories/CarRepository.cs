using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CarRepository : EfRepositoryBase<Car, Guid, VtContext>, ICarRepository
    {
        public CarRepository(VtContext context) : base(context)
        {
        }
    }
}

