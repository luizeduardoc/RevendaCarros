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

        [TestMethod]
        public void CreateShouldReturnVeiculo()
        {
            // Arrange
            var veiculoDto = new CreateVeiculoDto
            {
                ArCondicionado = true,
                Automatico = true,
                Cor = "Azul",
                Marca = "Fiat",
                Modelo = "Uno",
                Placa = "ASD3245",
                Preco = 10000.00,
                TipoOperacao = "Venda",
                TipoVeiculo = TipoVeiculo.Caminhao
            };

            var veiculo = new Veiculo("ASD3245","Azul", 10000.00, true, true, "Fiat", "Uno", TipoVeiculo.Caminhao, "Venda");            

            // Act
            var result = repository.Create(veiculoDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().Equals(veiculo);
        }

        [TestMethod]
        public void GetByIdShouldReturnVeiculo()
        {
            // Arrange
            var id = 1;
            var veiculo = new List<Veiculo> 
            {
                new Veiculo("ASD3245", "Azul", 10000.00, true, true, "Fiat", "Uno", TipoVeiculo.Caminhao, "Venda")
            };

            AddRange(veiculo);

            // Act
            var result = repository.GetById(id);

            // Assert
            result.Should().Equals(veiculo);
            result.Should().NotBeNull();            
        }

        [TestMethod]
        public void UpdateVeiculoShouldUpdateExistingVeiculo()
        {
            // Arrange
            var veiculo = new List<Veiculo>
            {
                new Veiculo("ASD3245", "Azul", 10000.00, true, true, "Fiat", "Uno", TipoVeiculo.Caminhao, "Venda")
            };

            AddRange(veiculo);

            var veiculoModificado = new Veiculo("AFE3245", "Verde", 10000.00, false, true, "Fiat", "Uno", TipoVeiculo.Caminhao, "Venda");

            // Act
            var result = repository.UpdateVeiculo(veiculoModificado);

            // Assert
            result.Should().Equals(veiculoModificado);
            result.Should().NotBe(veiculo);
        }
    }
}
