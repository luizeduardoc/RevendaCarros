using RevendaCarros.Domain.Entities;
using System.Collections.Generic;
using RevendaCarros.Domain.Dtos;


namespace RevendaCarros.Domain.Repositories
{
    public interface IAluguelaRepository : IRepository<Aluguel>
    {
        IList<Aluguel> GetAll();
        Aluguel Create(AluguelDto vendaDto);
    }
}
