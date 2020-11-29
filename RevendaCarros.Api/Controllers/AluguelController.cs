using Microsoft.AspNetCore.Mvc;

namespace RevendaCarros.Api.Controllers
{
    [Route("api/[controller]")]
    public class AluguelController : Controller
    {
        public AluguelController()
        {

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = "ok";
            return Ok(result);
        }
    }
}