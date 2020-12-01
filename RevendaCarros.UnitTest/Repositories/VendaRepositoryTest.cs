using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Enums;
using RevendaCarros.Infrastructure.Repositories;
using System.Collections.Generic;

namespace RevendaCarros.UnitTest.Repositories
{
    [TestClass]
    public class VendaRepositoryTest : BaseRepositoryTest
    {
        private VendaRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new VendaRepository(DbContext);
        }

        [TestMethod]
        public void GetAllShouldReturnVendaList()
        {
            // Arrange
            var veiculo = new List<Veiculo>
            {
                new Veiculo("IKG6861", "Verde", 100.00, true, true, "Hyundai", "HB20", TipoVeiculo.Carro, "Venda")          
            };

            AddRange(veiculo);

            var listaVenda = new List<Venda>
            {
                new Venda(1, 80000.00, "Comprador")
            };

            AddRange(listaVenda);

            // Act
            var result = repository.GetAll();

            // Assert
            result.Should().NotBeEmpty();
            result.Should().Equals(result);
        }

        [TestMethod]
        public void CreateShouldReturnVenda()
        {
            // Arrange
            var vendaDto = new VendaDto
            {
                IdVeiculo = 1,
                Valor = 300000.00,
                NomeComprador = "Comprador"
            };

            var venda = new Venda(1, 300000.00, "Comprador");

            // Act
            var result = repository.Create(vendaDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().Equals(venda);
        }
    }
}
