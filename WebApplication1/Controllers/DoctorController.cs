using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Controllers
{
    public class DoctorController : Controller
    {
        private readonly WebApp1Context _db;

        public DoctorController(WebApp1Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Doctor> objDoctorList = _db.Doctors;
            return View(objDoctorList);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor obj)
        {

            _db.Doctors.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Doctor created successfully";
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var doctorFromDb = _db.Doctors.FirstOrDefault();

            if (doctorFromDb == null)
            {
                return NotFound();
            }
            return View(doctorFromDb);
        }

      
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Doctor obj)
        {
           
            if (ModelState.IsValid)
            {
                _db.Doctors.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Doctor updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
