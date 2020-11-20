using LibraryManager.Infrastructure.Core;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RevendaCarros.Infrastructure.Repositories
{
    public class ImpostoRepository : Repository<Impostos>, IImpostoRepository
    {
        public ImpostoRepository(RevendaCarrosContext context)
            : base(context)
        {
        }

        public IList<Impostos> GetAll()
        {
            return Query().ToList();
        }
    }
}
