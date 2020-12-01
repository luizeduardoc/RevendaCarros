using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RevendaCarros.Infrastructure.Repositories
{
    public class ImpostoRepository : Repository<Imposto>, IImpostoRepository
    {
        public ImpostoRepository(RevendaCarrosContext context)
            : base(context)
        {
        }

        public IList<Imposto> GetAll()
        {
            return Query().ToList();
        }
    }
}
