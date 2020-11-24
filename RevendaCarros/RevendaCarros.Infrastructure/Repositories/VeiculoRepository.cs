using LibraryManager.Infrastructure.Core;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RevendaCarros.Infrastructure.Repositories
{
    public class VeiculoRepository : Repository<Veiculos>, IVeiculoRepository
    {
        public VeiculoRepository(RevendaCarrosContext context)
            : base(context)
        {
        }

        public IList<Veiculos> GetAll()
        {
            return Query().ToList();
        }
    }
}
