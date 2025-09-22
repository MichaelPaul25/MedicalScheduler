using MedicalschedulerAPI.Data;
using MedicalschedulerAPI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MedicalschedulerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("login-google")]
        public IActionResult LoginGoogle(string returnUrl = "/")
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleCallback", new { returnUrl }) };
            return Challenge(properties, "Google");
        }

        [HttpGet("google-callback")]
        public async Task<IActionResult> GoogleCallback(string returnUrl = "/")
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded) return BadRequest();

            var email = result.Principal.FindFirstValue(ClaimTypes.Email);
            var name = result.Principal.FindFirstValue(ClaimTypes.Name);
            var googleId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

            // Simpan user ke DB jika belum ada
            var user = _context.Users.FirstOrDefault(u => u.email == email);
            if (user == null)
            {
                user = new user
                {
                    email = email,
                    displayname = name,
                    googleid = googleId,
                    ispasswordset = false
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            return Redirect(returnUrl);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello from Medical Scheduler API");
        }
    }
}
