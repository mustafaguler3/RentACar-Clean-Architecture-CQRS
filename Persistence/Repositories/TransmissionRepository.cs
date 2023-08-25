using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class TransmissionRepository : EfRepositoryBase<Transmission, Guid, VtContext>, ITransmissionRepository
    {
        public TransmissionRepository(VtContext context) : base(context)
        {
        }
    }
}

