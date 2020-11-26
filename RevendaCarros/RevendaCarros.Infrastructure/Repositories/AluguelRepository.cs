using LibraryManager.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RevendaCarros.Infrastructure.Repositories
{
    public class AluguelRepository : Repository<Alugueis>, IAluguelRepository
    {
        public AluguelRepository(RevendaCarrosContext context) : base(context)
        {
        }
        public IList<Alugueis> GetAll()
        {
            return Query().Include(a => a.Veiculo).ToList();
        }
    }
}