using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Enums;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Infrastructure.Repositories;
using System.Collections.Generic;

namespace RevendaCarros.UnitTest.Repositories
{
    [TestClass]
    public class VeiculoRepositoryTest : BaseRepositoryTest
    {
        private IVeiculoRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new VeiculoRepository(DbContext);
        }

        [TestMethod]
        public void GetAllVeiculosShouldReturnListWithVeiculos()
        {
            // Arrange
            var veiculo = new Veiculo("IKG6861", "Verde", 100.00, true, true, "Hyundai", "HB20", TipoVeiculo.Carro, "Venda");            

            var listaVeiculos = new List<Veiculo>
            {
                veiculo
            };

            AddRange(listaVeiculos);

            // Act
            var result = repository.GetAll();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveSameCount(listaVeiculos);
            result.Should().Equals(listaVeiculos);
        }

        [TestMethod]
        public void GetAllVeiculosShouldReturnEmptyListWhenThereIsNoVeiculo()
        {
            // Arrange
            var listaVeiculo = new List<Veiculo>();

            // Act
            var result = repository.GetAll();

            // Arrange
            result.Should().BeEmpty();
            result.Should().Equals(listaVeiculo);
        }

        [TestMethod]
        public void GetVendasShouldReturnJustVeiculosForSale()
        {
            // Arrange
            var veiculo1 = new Veiculo("IKG6861", "Verde", 100.00, true, true, "Hyundai", "HB20", TipoVeiculo.Carro, "Venda");
            var veiculo2 = new Veiculo("IKG6821", "Azul", 180.00, false, false, "Hyundai", "HB20", TipoVeiculo.Carro, "Aluguel");

            var listaVeiculos = new List<Veiculo>
            {
                veiculo1,
                veiculo2
            };

            var expected = new List<Veiculo> { veiculo1 };

            AddRange(listaVeiculos);

            // Act
            var result = repository.GetVendas();

            // Assert            
            result.Should().Equals(expected);
            result.Should().NotHaveSameCount(listaVeiculos);
        }

        [TestMethod]
        public void GetAlugueisShouldReturnJustVeiculosForSale()
        {
            // Arrange
            var veiculo1 = new Veiculo("IKG6861", "Verde", 100.00, true, true, "Hyundai", "HB20", TipoVeiculo.Carro, "Venda");
            var veiculo2 = new Veiculo("IKG6821", "Azul", 180.00, false, false, "Hyundai", "HB20", TipoVeiculo.Carro, "Aluguel");

            var listaVeiculos = new List<Veiculo>
            {
                veiculo1,
                veiculo2
            };

            var expected = new List<Veiculo> { veiculo2 };

            AddRange(listaVeiculos);

            // Act
            var result = repository.GetAlugueis();

            // Assert            
            result.Should().Equals(expected);
            result.Should().NotHaveSameCount(listaVeiculos);
        }

        [TestMethod]
        public void FindByQueryShouldReturnVeiculoList()
        {
            // Arrange
            var listaVeiculos = new List<Veiculo>
            {
                new Veiculo("IKG6861", "Verde", 100.00, true, true, "Hyundai", "HB20", TipoVeiculo.Carro, "Venda")
            };

            AddRange(listaVeiculos);

            var query = new VeiculoQueryDto
            {
                ArCondicionado = true,
                Automatico = true,
                Marca = "Hyundai",
                Modelo = "HB20",
                Cor = "Verde",
                Take = 1,
                Number = 1
            };

            // Act
            var result = repository.FindByQuery(query);

            // Assert
            result.Should().NotBeEmpty();
            result.Should().Equals(listaVeiculos);
        }

        [TestMethod]
        public void FindByQueryWithNullQueryShouldReturnEmptyVeiculoList()
        {
            // Arrange
            var listaVeiculos = new List<Veiculo>();
            VeiculoQueryDto query = null;

            // Act
            var result = repository.FindByQuery(query);

            // Assert
            result.Should().Equals(listaVeiculos);
            query.Should().BeNull();
        }
    }
}
