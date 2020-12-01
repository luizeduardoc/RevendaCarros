using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Domain.Services;
using RevendaCarros.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace RevendaCarros.UnitTest.Services
{
    [TestClass]
    class AluguelServiceTest
    {
        private readonly IAluguelaRepository aluguelRepository = Substitute.For<IAluguelaRepository>();
        private IAluguelaRepository service;

        [TestInitialize]
        public void Initialize()
        {
            service = new AluguelService(serviceRepository);
        }

        [TestMethod]
        public void GetAllShouldReturnAluguelList()
        {
            //Arrange
            var listaAluguel = new List<Aluguel>
            {
                new Aluguel(10, 100, "Comprador", 12/12/2020, 15/01/2021)
            };

            aluguelRepository.GetAll().Returns(listaAluguel);

            //Act
            var result = service.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().Equals(listaAluguel);
            aluguelRepository.Received().GetAll();
        }

        [TestMethod]
        public void CreateShouldReturnVenda()
        {
            // Arrange     
            var aluguelDto = new AluguelDto
            {
                IdVeiculo = 10,              //corrigir aqui   
                ValorMensal = 100,
                Nome = "Comprador",
                DataDevolucao = 12 / 12 / 2020,
                DataRetirada = 15 / 01 / 2021
            };

            var aluguel = new Aluguel(10, 100, "Comprador", 12 / 12 / 2020, 15 / 01 / 2021);
            aluguelRepository.Create(aluguelDto).Returns(aluguel);

            // Act
            var result = service.Create(aluguelDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().Equals(aluguel);
            aluguelRepository.Received().Create(aluguelDto);
        }
    }
}