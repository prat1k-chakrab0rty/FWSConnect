using FlatworldConnectWeb.data;
using FlatworldConnectWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatworldConnectWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult Forgot()
        {
            return View();
        }

        // POST: api/Logins
        [HttpPost]
        public ActionResult<Login> Forgot(Login login)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Confirmation");

            }
            return View(login);
        }

        public IActionResult LoggedIn()
        {
            TempData["status"] = "LoggedIn";
            TempData["role"] = TempData["role"];
            return View();
        }


        // POST: api/Logins
        [HttpPost]
        public async Task<ActionResult<Customer>> Index(Login login)
        {
            var userr = await _context.Customers.Where(x => x.Email == login.Email).FirstOrDefaultAsync();
            if (userr != null && userr.Password == login.Password)
            {
                TempData["role"] = userr.Role;
                return RedirectToAction("LoggedIn");
            }
            else
                return NoContent();
        }
    }
}
