using RevendaCarros.Domain.Entities;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Repositories
{
    public interface IImpostoRepository : IRepository<Imposto>
    {
        IList<Imposto> GetAll();
    }
}
