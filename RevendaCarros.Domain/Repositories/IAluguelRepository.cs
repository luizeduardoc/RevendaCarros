using RevendaCarros.Domain.Entities;
using System.Collections.Generic;


namespace RevendaCarros.Domain.Repositories
{
    public interface IAluguelaRepository : IRepository<Aluguel>
    {
        IList<Aluguel> GetAll();
    }
}
