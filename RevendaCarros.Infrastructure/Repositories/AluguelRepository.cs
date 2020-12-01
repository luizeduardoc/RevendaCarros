using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RevendaCarros.Infrastructure.Repositories
{
    public class AluguelRepository : Repository<Aluguel>, IAluguelRepository
    {
        public AluguelRepository(RevendaCarrosContext context) : base(context)
        {
        }

        public IList<Aluguel> GetAll()
        {
            return Query().ToList();
        }

        public Aluguel CreateAluguel(AluguelDto aluguelDto)
        {
            var novoAluguel = new Aluguel(aluguelDto.IdVeiculo,
                                          aluguelDto.ValorMensal,
                                          aluguelDto.Nome,
                                          aluguelDto.DataEntrega,
                                          aluguelDto.DataRetirada);

            var result = Insert(novoAluguel);
            return result;
        }
    }
}