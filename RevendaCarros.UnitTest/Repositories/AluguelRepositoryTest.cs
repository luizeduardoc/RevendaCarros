using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Enums;
using RevendaCarros.Infrastructure.Repositories;
using System;
using System.Collections.Generic;

namespace RevendaCarros.UnitTest.Repositories
{
    [TestClass]
    public class AluguelRepositoryTest : BaseRepositoryTest
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
            var listaAlugueis = new List<Aluguel>
            {
                new Aluguel(1, 1000, "Nome", DateTime.Now, DateTime.Now)
            };

            AddRange(listaAlugueis);

            //Act
            var result = repository.GetAll();

            //Assert
            result.Should().NotBeEmpty();
            result.Should().Equals(listaAlugueis);
        }

        [TestMethod]
        public void CreateShouldReturnAluguel()
        {
            //Arrange
            var aluguelDto = new AluguelDto
            {
                IdVeiculo = 10,   
                ValorMensal = 100,
                Nome = "Comprador",
                DataEntrega = DateTime.Now,
                DataRetirada = DateTime.Now
            };

            var aluguel = new Aluguel(10, 100, "Comprador", DateTime.Now, DateTime.Now);

            //Act
            var result = repository.CreateAluguel(aluguelDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().Equals(aluguel);

        }
    }
}