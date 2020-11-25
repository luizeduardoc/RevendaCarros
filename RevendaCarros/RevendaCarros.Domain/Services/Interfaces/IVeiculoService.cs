using RevendaCarros.Domain.Dtos;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Services.Interfaces
{
    public interface IVeiculoService
    {
        IList<EstoqueDto> GetVendas();
        IList<EstoqueDto> GetAlugueis();
        IList<EstoqueDto> GetAll();
    }
}
