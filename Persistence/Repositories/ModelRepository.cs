using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ModelRepository : EfRepositoryBase<Model, Guid, VtContext>, IModelRepository
    {
        public ModelRepository(VtContext context) : base(context)
        {
        }
    }
}

