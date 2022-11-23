using FlatworldConnectWeb.data;
using FlatworldConnectWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatworldConnectWeb.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext db)
        {
            _context = db;
        }
        public async Task<IActionResult> Index(string sortOrder, string searchString)

        //  public IActionResult Index()
        {
            ViewData["CurrentFilter"] = searchString;
            TempData["status"] = "LoggedIn";
            IEnumerable<Project> projects = _context.Projects;
            return View(projects);
        }
        public async Task<IActionResult> Details(int? id)
        {
            TempData["status"] = "LoggedIn";
            var student = await _context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(student);
        }
        //Get
        public IActionResult Create()
        {
            TempData["status"] = "LoggedIn";

            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project obj)
        {

            if (ModelState.IsValid)
            {
                _context.Projects.Add(obj);
                //return RedirectToAction("Index");
                return View(obj);
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            TempData["status"] = "LoggedIn";
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var customerFromDb = _context.Projects.Find(id);
            //    var customerFromDbFirst = _context.Customers.FirstOrDefault(x=>x.Id==id);



            if (customerFromDb == null)
            {
                return NotFound();
            }
            return View(customerFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Project obj)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var student = await _context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (student == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
