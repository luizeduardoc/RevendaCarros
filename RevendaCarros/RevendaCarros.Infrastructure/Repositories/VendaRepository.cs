using LibraryManager.Infrastructure.Core;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RevendaCarros.Infrastructure.Repositories
{
    public class VendaRepository : Repository<Vendas>, IVendaRepository
    {
        public VendaRepository(RevendaCarrosContext context) : base(context)
        {
        }
        public IList<Vendas> GetAll()
        {
            return Query().ToList();
        }
    }
}