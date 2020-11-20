using LibraryManager.Infrastructure.Core;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RevendaCarros.Infrastructure.Repositories
{
    public class AluguelRepository : Repository<Alugueis>, IAluguelaRepository
    {
        public AluguelRepository(RevendaCarrosContext context) : base(context)
        {
        }
        public IList<Alugueis> GetAll()
        {
            return Query().ToList();
        }
    }
}