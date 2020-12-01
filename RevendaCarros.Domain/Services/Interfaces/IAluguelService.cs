using System.Collections.Generic;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Dtos;

namespace RevendaCarros.Domain.Services.Interfaces
{
    public interface IAluguelService
    {
        IList<Aluguel> GetAll();
        Aluguel Create(AluguelDto aluguelDto);
        Veiculo DevolveVeiculo(string placa);
    }
}
