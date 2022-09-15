using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Controllers
{
    public class PatientController : Controller
    {
        private readonly  WebApp1Context _db;

        public PatientController(WebApp1Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Patient> objPatientList = _db.Patients;
           
            return View(objPatientList);

        }
        //GET
        public IActionResult Create()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient obj)
        {

            _db.Patients.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Patient created successfully";
            return RedirectToAction("Index");
            
           
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var patientFromDb = _db.Patients.FirstOrDefault();
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (patientFromDb == null)
            {
                return NotFound();
            }
            return View(patientFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Patient obj)
        {

            if (ModelState.IsValid)
            {

                _db.Patients.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Patient updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

    }
}
