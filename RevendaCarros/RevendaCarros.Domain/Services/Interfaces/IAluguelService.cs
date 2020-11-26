using System.Collections.Generic;
using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;

namespace RevendaCarros.Domain.Services.Interfaces
{
    public interface IAluguelService
    {
        IList<Alugueis> GetAll();

        Alugueis Create(AluguelDto aluguelDto);
    }

    

}
