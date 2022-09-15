using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MedicineController : Controller
    {
        private readonly WebApp1Context _db;

        public MedicineController(WebApp1Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Medicine> objMedList = _db.Medicines;
            return View(objMedList);
        }
        public IActionResult Create()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medicine obj)
        {

            _db.Medicines.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Medicine created successfully";
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var medcineFromDb = _db.Medicines.FirstOrDefault();

            if (medcineFromDb == null)
            {
                return NotFound();
            }
            return View(medcineFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Medicine obj)
        {

            if (ModelState.IsValid)
            {
                _db.Medicines.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Medicine updated successfully";
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
            var medcineFromDb = _db.Medicines.SingleOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (medcineFromDb == null)
            {
                return NotFound();
            }

            return View(medcineFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Medicines.SingleOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Medicines.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Medicine deleted successfully";
            return RedirectToAction("Index");

        }

    }
}
