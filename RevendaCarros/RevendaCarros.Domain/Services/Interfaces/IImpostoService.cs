using RevendaCarros.Domain.Entities;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Services.Interfaces
{
    public interface IImpostoService
    {
        IList<Impostos> GetAll();
    }
}
