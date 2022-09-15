using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NurseController : Controller
    {
        private readonly WebApp1Context _db;

        public NurseController(WebApp1Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Nurse> objNurseList = _db.Nurses;
            return View(objNurseList);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Nurse obj)
        {

            _db.Nurses.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Nurse created successfully";
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var nurseFromDb = _db.Nurses.FirstOrDefault();

            if (nurseFromDb == null)
            {
                return NotFound();
            }
            return View(nurseFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Nurse obj)
        {

            if (ModelState.IsValid)
            {
                _db.Nurses.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Nurse updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
