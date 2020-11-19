using Microsoft.AspNetCore.Mvc;

namespace RevendaCarros.Api.Controllers
{
    [Route("api/[controller]")]
    public class VendaController : Controller
    {        
        public VendaController()
        {            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = "Ok";
            return Ok(result);
        }
    }
}
