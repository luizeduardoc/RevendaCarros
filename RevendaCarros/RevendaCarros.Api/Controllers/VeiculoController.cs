using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = service.GetAll();
            return Ok(result);
        }
    }
}
