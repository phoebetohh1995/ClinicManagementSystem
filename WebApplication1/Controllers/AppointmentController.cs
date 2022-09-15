using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Utlity;

namespace WebApplication1.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly WebApp1Context _db;
        public AppointmentController(WebApp1Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var webapp1Context = _db.Appointments.Include(a => a.Doctor).Include(a => a.Patient);
            return View(webapp1Context.ToList());
            
        }
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_db.Doctors, "Id", "Name");
            ViewData["PatientId"] = new SelectList(_db.Patients, "Id", "Name");
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment obj)
        {
            
                _db.Appointments.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Appointment created successfully";
                return RedirectToAction("Index");

        }
        // GET: Appointments/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = _db.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            ViewData["DoctorId"] = new SelectList(_db.Doctors, "Id", "Name",appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_db.Patients, "Id", "Name",appointment.PatientId);
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,DoctorId,PatientId,ApptDateTime")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            
                try
                {
                    _db.Update(appointment);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            
         
            ViewData["DoctorId"] = new SelectList(_db.Doctors, "Id", "Name", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_db.Patients, "Id", "Name", appointment.PatientId);
            return View(appointment);
        }
        // GET: Appointments/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var appointment =  _db.Appointments
               .Include(a => a.Doctor)
               .Include(a => a.Patient)
               .FirstOrDefault(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var appointment = _db.Appointments.Find(id);
            _db.Appointments.Remove(appointment);
            _db.SaveChanges();
            TempData["success"] = "Appointment deleted successfully";
            return RedirectToAction("Index");
        }

        private bool AppointmentExists(int id)
        {
            return _db.Appointments.Any(e => e.Id == id);
        }


    }
}
