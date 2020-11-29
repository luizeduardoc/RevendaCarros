using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Services
{
    public class ImpostoService : IImpostoService
    {
        private readonly IImpostoRepository repository;

        public ImpostoService(IImpostoRepository repository)
        {
            this.repository = repository;
        }

        public IList<Imposto> GetAll()
        {
            return repository.GetAll();
        }
    }
}
