using Microsoft.AspNetCore.Mvc;
using RevendaCarros.Domain.Services.Interfaces;

namespace RevendaCarros.Api.Controllers
{
    [Route("api/[controller]")]
    public class ImpostoController : Controller
    {
        private readonly IImpostoService service;

        public ImpostoController(IImpostoService service)
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
