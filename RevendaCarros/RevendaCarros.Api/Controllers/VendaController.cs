using Microsoft.AspNetCore.Mvc;
using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Services.Interfaces;

namespace RevendaCarros.Api.Controllers
{
    [Route("api/[controller]")]
    public class VendaController : Controller
    {
        private readonly IVendaService service;

        public VendaController(IVendaService service)
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
        public IActionResult Create([FromBody] VendaDto vendaDto)
        {
            var result = service.Create(vendaDto);
            return Ok(result);
        }
    }
}
