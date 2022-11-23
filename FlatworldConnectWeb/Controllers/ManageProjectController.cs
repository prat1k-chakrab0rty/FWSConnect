using FlatworldConnectWeb.data;
using FlatworldConnectWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatworldConnectWeb.Controllers
{
    public class ManageProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageProjectController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            TempData["status"] = "LoggedIn";
            IEnumerable<ManageProject> projects = _context.ManageProjects;
            return View(projects);
        }
        public IActionResult IndexClosed()
        {
            TempData["status"] = "LoggedIn";
            IEnumerable<ManageProject> projects = _context.ManageProjects.Where(x=>x.Status=="closed");
            return View(projects);
        }
        public IActionResult IndexOpen()
        {
            TempData["status"] = "LoggedIn";
            IEnumerable<ManageProject> projects = _context.ManageProjects.Where(x => x.Status == "open");
            return View(projects);
        }
        public IActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ManageProject obj)
        {
            _context.ManageProjects.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            TempData["status"] = "LoggedIn";
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var customerFromDb = _context.ManageProjects.Find(id);
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
        public IActionResult Edit(ManageProject obj)
        {
            if (ModelState.IsValid)
            {
                _context.ManageProjects.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
