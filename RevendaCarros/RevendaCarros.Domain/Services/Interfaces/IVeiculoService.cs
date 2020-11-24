using RevendaCarros.Domain.Dtos;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Services.Interfaces
{
    public interface IVeiculoService
    {
        IList<EstoqueDto> GetAll();
    }
}
