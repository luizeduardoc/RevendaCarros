﻿using Microsoft.AspNetCore.Mvc;
using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Services.Interfaces;

namespace RevendaCarros.Api.Controllers
{
    [Route("api/[controller]")]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoService service;

        public VeiculoController(IVeiculoService service)
        {
            this.service = service;
        }

        [HttpGet("vendas")]
        public IActionResult GetVendas()
        {
            var result = service.GetVendas();
            return Ok(result);
        }

        [HttpGet("alugueis")]
        public IActionResult GetAlgueis()
        {
            var result = service.GetAlugueis();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = service.GetAll();
            return Ok(result);
        }

        [HttpGet("filter")]
        public IActionResult GetByQuery([FromQuery] VeiculoQueryDto queryFilter)
        {
            var result = service.FindByQuery(queryFilter);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateVeiculoDto veiculo)
        {
            var result = service.Create(veiculo);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = service.GetById(id);
            return Ok(result);
        }
    }
}
