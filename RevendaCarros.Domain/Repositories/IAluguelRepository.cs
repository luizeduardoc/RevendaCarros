using RevendaCarros.Domain.Entities;
using System.Collections.Generic;
using RevendaCarros.Domain.Dtos;


namespace RevendaCarros.Domain.Repositories
{
    public interface IAluguelRepository : IRepository<Aluguel>
    {
        IList<Aluguel> GetAll();
        Aluguel CreateAluguel(AluguelDto aluguelDto);
    }
}
