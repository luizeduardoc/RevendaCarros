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
        private readonly IImpostoRepository impostoRepository = Substitute.For<IImpostoRepository>();
        private IVendaService service;

        [TestInitialize]
        public void Initialize()
        {
            service = new VendaService(vendaRepository, impostoRepository);
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

            var imposto = new Imposto
            {
                Id = 1,
                Descricao = "Imposto teste",
                Nome = "NomeImposto",
                Valor = 1250.00
            };

            var venda = new Venda(1, 300000.00, "Comprador");
            vendaRepository.Create(vendaDto).Returns(venda);
            impostoRepository.Get(Arg.Any<string>()).Returns(imposto);

            // Act
            var result = service.Create(vendaDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().Equals(venda);
            vendaRepository.Received().Create(vendaDto);
        }
    }
}
