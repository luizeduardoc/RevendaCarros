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
    class AluguelRepositoryTest : BaseRepositoryTest
    {
        private AluguelRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new AluguelRepository(DbContext);
        }

        [TestMethod]
        public void GetAllShouldReturnAluguelList()
        {
            //Arrange
            var veiculo = new List<Veiculo>
            {
                new Veiculo
                {
                    Id = 1,                 //ver como eh aluguel
                    Placa = "IKG6861",
                    Cor = "Verde",
                    Preco = 100.00,
                    ArCondicionado = true,
                    Automatico = true,
                    Marca = "Hyundai",
                    Modelo = "HB20",
                    TipoOperacao = "Aluguel",
                    TipoVeiculo = TipoVeiculo.Carro
                }
            };
            AddRange(veiculo);

            var listaAluguel = new List<Aluguel>
            {
                new Aluguel(10, 100, "Comprador", 12/12/2020, 15/01/2021) //corrigir aqui   
            };

            AddRange(listaAluguel);

            //Act
            var result = repository.GetAll();

            //Assert
            result.Should().NotBeEmpty();
            result.Should().Equals(result);
        }

        [TestMethod]
        public void CreateShouldReturnAluguel()
        {
            //Arrange
            var aluguelDto = new AluguelDto
            {
                IdVeiculo = 10,              //corrigir aqui   
                ValorMensal = 100,
                Nome = "Comprador",
                DataDevolucao = 12 / 12 / 2020,
                DataRetirada = 15 / 01 / 2021
            };

            var aluguel = new Aluguel(10, 100, "Comprador", 12 / 12 / 2020, 15 / 01 / 2021); //corrigir aqui 

            //Act
            var result = repository.Create(aluguelDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().Equals(aluguel);

        }
    }
}