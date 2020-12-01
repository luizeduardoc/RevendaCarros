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
    public class VendaServiceTest
    {
        private readonly IVendaRepository vendaRepository = Substitute.For<IVendaRepository>();
        private IVendaService service;

        [TestInitialize]
        public void Initialize()
        {
            service = new VendaService(vendaRepository);
        }

        [TestMethod]
        public void GetAllShouldReturnVendaList()
        {
            // Arrange            
            var listaVenda = new List<Venda>
            {
                new Venda(1, 80000.00, "Comprador")
            };

            vendaRepository.GetAll().Returns(listaVenda);

            // Act
            var result = service.GetAll();

            // Assert
            result.Should().NotBeNull();
            result.Should().Equals(listaVenda);
            vendaRepository.Received().GetAll();
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
            vendaRepository.Create(vendaDto).Returns(venda);

            // Act
            var result = service.Create(vendaDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().Equals(venda);
            vendaRepository.Received().Create(vendaDto);
        }
    }
}
