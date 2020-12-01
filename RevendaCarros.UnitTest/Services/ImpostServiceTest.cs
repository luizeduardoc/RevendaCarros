using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Domain.Services;
using RevendaCarros.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace RevendaCarros.UnitTest.Services
{
    [TestClass]
    public class ImpostoServiceTest
    {
        private readonly IImpostoRepository impostoRepository = Substitute.For<IImpostoRepository>();
        private IImpostoService service;

        [TestInitialize]
        public void Initialize()
        {
            service = new ImpostoService(impostoRepository);
        }

        [TestMethod]
        public void GetAllShouldReturnImpostoList()
        {
            // Arrange
            var listaImpostos = new List<Imposto>
            {
                new Imposto
                {
                    Id = 0,
                    Valor = 800.00
                }
            };

            impostoRepository.GetAll().Returns(listaImpostos);

            // Act
            var result = service.GetAll();

            // Assert
            result.Should().Equals(listaImpostos);
            impostoRepository.Received().GetAll();
        }
    }
}
