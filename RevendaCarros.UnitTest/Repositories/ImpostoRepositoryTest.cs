﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Infrastructure.Repositories;
using System.Collections.Generic;

namespace RevendaCarros.UnitTest.Repositories
{
    [TestClass]
    public class ImpostoRepositoryTest : BaseRepositoryTest
    {
        private IImpostoRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new ImpostoRepository(DbContext);
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

            AddRange(listaImpostos);

            // Act
            var result = repository.GetAll();

            // Assert
            result.Should().Equals(listaImpostos);
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [TestMethod]
        public void GetShouldReturnImposto()
        {
            // Arrange
            var nomeImposto = "NomeImposto";
            var imposto = new List<Imposto>
            {
                new Imposto
                {
                    Descricao = "Descricao imposto",
                    Nome = "NomeImposto",
                    Valor = 10000
                }
            };

            AddRange(imposto);

            // Act
            var result = repository.Get(nomeImposto);

            // Assert
            result.Should().Equals(imposto);
            result.Should().NotBeNull();
        }
    }
}
