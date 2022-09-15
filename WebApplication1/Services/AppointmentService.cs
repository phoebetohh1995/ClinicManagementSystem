using Microsoft.AspNetCore.Identity.UI.Services;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;
using WebApplication1.Utlity;

namespace WebApplication1.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly WebApp1Context _db;
        private readonly IEmailSender _emailSender;
        public AppointmentService(WebApp1Context db, IEmailSender emailSender)
        {
            _db = db;
            _emailSender = emailSender;

        }
        public async Task<int> AddUpdate(AppointmentVM model)
        {
            var startDate = DateTime.Parse(model.StartDate);
            var endDate = DateTime.Parse(model.StartDate).AddMinutes(Convert.ToDouble(model.Duration));
            var patient = _db.Users.FirstOrDefault(u => u.Id == model.PatientId);
            var doctor = _db.Users.FirstOrDefault(u => u.Id == model.DoctorId);
            if (model != null && model.Id > 0)
            {
                //update
                var appointment = _db.Appointments.FirstOrDefault(x => x.Id == model.Id);
                appointment.Title = model.Title;
                appointment.Description = model.Description;
                appointment.StartDate = startDate;
                appointment.EndDate = endDate;
                appointment.Duration = model.Duration;
                appointment.DoctorId = model.DoctorId;
                appointment.PatientId = model.PatientId;
                appointment.IsDoctorApproved = false;
                appointment.AdminId = model.AdminId;
                await _db.SaveChangesAsync();
                return 1;
            }
            else
            {
                //create
                Appointment appointment = new Appointment()
                {
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = startDate,
                    EndDate = endDate,
                    Duration = model.Duration,
                    DoctorId = model.DoctorId,
                    PatientId = model.PatientId,
                    IsDoctorApproved = false,
                    AdminId = model.AdminId
                };
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return 2;
            }

        }

        public Task<int> ConfirmEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppointmentVM> DoctorsEventsById(string doctorId)
        {
            throw new NotImplementedException();
        }

        public AppointmentVM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctorList()
        {
            var doctors = (from user in _db.Users
                           join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                           join roles in _db.Roles.Where(x => x.Name == Helper.Doctor) on userRoles.RoleId equals roles.Id
                           select new Doctor
                           {
                               Id = Convert.ToInt32(user.Id),
                               Name = user.UserName
                           }
                           ).ToList();

            return doctors;
        }


        public List<Patient> GetPatientList()
        {
            var patients = (from user in _db.Users
                            join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                            join roles in _db.Roles.Where(x => x.Name == Helper.Patient) on userRoles.RoleId equals roles.Id
                            select new Patient
                            {
                                Id = Convert.ToInt32(user.Id),
                                Name = user.UserName
                            }
                           ).ToList();

            return patients;
        }

        public List<AppointmentVM> PatientsEventsById(string patientId)
        {
            throw new NotImplementedException();
        }
    }
}   

