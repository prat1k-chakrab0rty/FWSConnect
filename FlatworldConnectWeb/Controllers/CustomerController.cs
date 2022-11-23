using FlatworldConnectWeb.data;
using FlatworldConnectWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatworldConnectWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            TempData["status"] = "LoggedIn";
            TempData["role"] = TempData["role"];
            IEnumerable<Customer> customers = _context.Customers.Where(x => x.Role == "customer").ToList();
            return View(customers);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer obj)
        {
           // if(obj.Name == obj.Email.ToString())
         ///   {
            //    ModelState.AddModelError("name", "does not match");
         //   }
            if (ModelState.IsValid)
            {
                var student = await _context.Customers.Where(x => x.Email == obj.Email).FirstOrDefaultAsync();
                if(student == null)
                {
                    _context.Customers.Add(obj);
                    _context.SaveChanges();
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewData["UserExist"] =
                    "User exists try some new data.";
                }
                
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            TempData["status"] = "LoggedIn";
            TempData["role"] = TempData["role"];
            if (id==null || id==0)
            {
                return NotFound();
            }
            var customerFromDb = _context.Customers.Find(id);
        //    var customerFromDbFirst = _context.Customers.FirstOrDefault(x=>x.Id==id);

            if(customerFromDb == null)
            {
                return NotFound();
            }
            return View(customerFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer obj)
        {
            if (ModelState.IsValid)
            {
                    _context.Customers.Update(obj);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
            }
            return View(obj);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var student = await _context.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (student == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
          

        }
    }
}
