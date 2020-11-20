using LibraryManager.Domain.Repositories.Core;
using RevendaCarros.Domain.Entities;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Repositories
{
    public interface IImpostoRepository : IRepository<Impostos>
    {
        IList<Impostos> GetAll();
    }
}
