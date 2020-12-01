using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Services.Interfaces
{
    public interface IVeiculoService
    {
        IList<EstoqueDto> GetVendas();
        IList<EstoqueDto> GetAlugueis();
        IList<EstoqueDto> GetAll();
        IList<Veiculo> FindByQuery(VeiculoQueryDto queryFilter);
        Veiculo Create(CreateVeiculoDto veiculo);
        Veiculo GetById(int id);
    }
}
