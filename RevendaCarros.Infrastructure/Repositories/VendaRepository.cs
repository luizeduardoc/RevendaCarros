using LibraryManager.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RevendaCarros.Infrastructure.Repositories
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(RevendaCarrosContext context) : base(context)
        {
        }

        public IList<Venda> GetAll()
        {
            return Query().Include(v => v.Veiculo).ToList();
        }
    }
}