using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Enums;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Domain.Services;
using RevendaCarros.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace RevendaCarros.UnitTest.Services
{
    [TestClass]
    public class AluguelServiceTest
    {
        private readonly IAluguelRepository aluguelRepository = Substitute.For<IAluguelRepository>();
        private readonly IVeiculoRepository veiculoRepository = Substitute.For<IVeiculoRepository>();
        private IAluguelService service;

        [TestInitialize]
        public void Initialize()
        {
            service = new AluguelService(aluguelRepository, veiculoRepository);
        }

        [TestMethod]
        public void GetAllShouldReturnAluguelList()
        {
            //Arrange
            var listaAluguel = new List<Aluguel>
            {
                new Aluguel(10, 100, "Comprador", DateTime.Now, DateTime.Now)
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
        public void CreateWithValidVeiculoShouldReturnAluguel()
        {
            // Arrange
            var id = 0;
            var veiculo = new Veiculo("IKG6861", "Verde", 100.00, true, true, "Hyundai", "HB20", TipoVeiculo.Carro, "Aluguel");
            var aluguelDto = new AluguelDto
            {
                IdVeiculo = id,
                ValorMensal = 100,
                Nome = "Comprador",
                DataEntrega = DateTime.Now,
                DataRetirada = DateTime.Now
            };

            var aluguel = new Aluguel(id, 100, "Comprador", DateTime.Now, DateTime.Now);
            veiculoRepository.GetById(id).Returns(veiculo);
            aluguelRepository.CreateAluguel(aluguelDto).Returns(aluguel);

            // Act
            var result = service.Create(aluguelDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().Equals(aluguel);
            aluguelRepository.Received().CreateAluguel(aluguelDto);
        }

        [TestMethod]
        public void CreateWithInvalidVeiculoShouldThrowError()
        {
            // Arrange
            var veiculo = new Veiculo("IKG6861", "Verde", 100.00, true, true, "Hyundai", "HB20", TipoVeiculo.Carro, "Venda");
            var dataEntrega = DateTime.Now;
            var dataRetirada = DateTime.Now;

            var aluguelDto = new AluguelDto
            {
                IdVeiculo = 0,
                ValorMensal = 100.00,
                Nome = "Comprador",
                DataEntrega = dataEntrega,
                DataRetirada = dataRetirada
            };

            var aluguel = new Aluguel(0, 100.00, "Comprador", dataEntrega, dataRetirada);
            veiculoRepository.GetById(aluguel.IdVeiculo).Returns(veiculo);

            // Act
            Action act = () => service.Create(aluguelDto);

            // Assert
            act.Should().Throw<InvalidOperationException>();
            veiculoRepository.Received().GetById(aluguel.IdVeiculo);
        }

        [TestMethod]
        public void DevolveVeiculoShouldSetDisponibilidadeToTrue()
        {
            // Ararnge
            var placa = "IKG6861";
            var veiculo = new Veiculo(placa, "Verde", 100.00, true, true, "Hyundai", "HB20", TipoVeiculo.Carro, "Venda");
            veiculo.ChangeDisponibilidade();
            veiculoRepository.GetByPlaca(Arg.Any<string>()).Returns(veiculo);

            // Act
            var result = service.DevolveVeiculo(placa);

            // Assert
            result.Should().Equals(veiculo);
            veiculoRepository.Received().GetByPlaca(placa);
            veiculoRepository.Received().UpdateVeiculo(veiculo);
        }
    }
}