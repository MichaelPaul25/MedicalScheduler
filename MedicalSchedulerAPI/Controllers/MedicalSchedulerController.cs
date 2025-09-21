using Microsoft.AspNetCore.Mvc;

namespace MedicalSchedulerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalSchedulerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
