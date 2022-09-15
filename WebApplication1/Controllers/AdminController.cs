using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private readonly WebApp1Context _db;

        public AdminController(WebApp1Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Admin> objAdminList = _db.Admins;
            return View(objAdminList);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Admin obj)
        {

            _db.Admins.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Admin created successfully";
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var adminFromDb = _db.Admins.FirstOrDefault();

            if (adminFromDb == null)
            {
                return NotFound();
            }
            return View(adminFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Admin obj)
        {

            if (ModelState.IsValid)
            {
                _db.Admins.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Admin updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var adminFromDb = _db.Admins.SingleOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (adminFromDb == null)
            {
                return NotFound();
            }

            return View(adminFromDb);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Admins.SingleOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Admins.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Admin deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
