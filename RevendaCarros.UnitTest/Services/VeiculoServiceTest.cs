using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Enums;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Domain.Services;
using System;
using System.Collections.Generic;

namespace RevendaCarros.UnitTest.Services
{
    [TestClass]
    public class VeiculoServiceTest
    {
        private readonly IVeiculoRepository veiculoRepository = Substitute.For<IVeiculoRepository>();
        private VeiculoService service;
        private Veiculo veiculo;
        private List<Veiculo> listaVeiculo;
        private EstoqueDto estoque;
        private List<EstoqueDto> expected;

        [TestInitialize]
        public void Initialize()
        {
            service = new VeiculoService(veiculoRepository);

            veiculo = new Veiculo("IKG6861", "Verde", 100.00, true, true, "Hyundai", "HB20", TipoVeiculo.Carro, "Venda");            

            listaVeiculo = new List<Veiculo> { veiculo };

            estoque = new EstoqueDto(veiculo.Id,
                                     veiculo.Placa,
                                     veiculo.Cor,
                                     veiculo.Preco,
                                     Enum.GetName(typeof(TipoVeiculo), veiculo.TipoVeiculo),
                                     veiculo.TipoOperacao,
                                     veiculo.ArCondicionado,
                                     veiculo.Automatico,
                                     veiculo.Marca,
                                     veiculo.Modelo,
                                     veiculo.Disponivel);

            expected = new List<EstoqueDto> { estoque };
        }

        [TestMethod]
        public void FindByQueryShouldReturnEstoqueDtoList()
        {
            // Arrange            
            var query = new VeiculoQueryDto();
            veiculoRepository.FindByQuery(query).Returns(listaVeiculo);

            // Act
            var result = service.FindByQuery(query);

            // Assert
            result.Should().Equals(expected);
            veiculoRepository.Received().FindByQuery(query);
        }

        [TestMethod]
        public void GetAllShouldReturnEstoqueDtoList()
        {
            // Arrange            
            veiculoRepository.GetAll().Returns(listaVeiculo);

            // Act
            var result = service.GetAll();

            // Assert
            result.Should().Equals(expected);
            veiculoRepository.Received().GetAll();
        }

        [TestMethod]
        public void GetVendasShouldReturnEstoqueDtoList()
        {
            // Arrange            
            veiculoRepository.GetVendas().Returns(listaVeiculo);

            // Act
            var result = service.GetVendas();

            // Assert
            result.Should().Equals(expected);
            veiculoRepository.Received().GetVendas();
        }

        [TestMethod]
        public void GetAlugueisShouldReturnEstoqueDtoList()
        {
            // Arrange            
            veiculoRepository.GetAlugueis().Returns(listaVeiculo);

            // Act
            var result = service.GetAlugueis();

            // Assert
            result.Should().Equals(expected);
            veiculoRepository.Received().GetAlugueis();
        }

        [TestMethod]
        public void CreateShouldReturnVeiculo()
        {
            // Arrange
            var createVeiculoDto = new CreateVeiculoDto
            {
                ArCondicionado = true,
                Automatico = true,
                Cor = "Verde",
                Marca = "Hyundai",
                Modelo = "HB20",
                Placa = "IKG6861",
                Preco = 100.00,
                TipoOperacao = "Venda",
                TipoVeiculo = TipoVeiculo.Carro
            };
            
            var result = veiculoRepository.Create(createVeiculoDto).Returns(veiculo);

            // Act
            service.Create(createVeiculoDto);

            // Assert
            result.Should().Equals(result);
            result.Should().NotBeNull();
            veiculoRepository.Received().Create(createVeiculoDto);
        }

        [TestMethod]
        public void GetByIdShouldReturnVeiculo()
        {
            // Arrange
            var id = 1;
            veiculoRepository.GetById(id).Returns(veiculo);

            // Act
            service.GetById(id);

            // Assert
            veiculoRepository.Received().GetById(id);
        }
    }
}
