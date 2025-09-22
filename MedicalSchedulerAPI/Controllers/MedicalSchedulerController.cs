using Microsoft.AspNetCore.Mvc;

namespace MedicalschedulerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalschedulerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
