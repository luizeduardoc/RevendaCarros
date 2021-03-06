﻿using Microsoft.AspNetCore.Mvc;
using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Services.Interfaces;

namespace RevendaCarros.Api.Controllers
{
    [Route("api/[controller]")]
    public class AluguelController : Controller
    {
        private readonly IAluguelService service;

        public AluguelController(IAluguelService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = service.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AluguelDto aluguelDto)
        {
            var result = service.Create(aluguelDto);
            return Ok(result);
        }

        [HttpPost("devolve")]
        public IActionResult DevolveVeiculo([FromQuery] string placa)
        {
            service.DevolveVeiculo(placa);
            return Ok($"Veiculo com placa {placa} foi devolvido");
        }
    }
}