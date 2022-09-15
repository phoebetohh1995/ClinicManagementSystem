using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Services
{
    public interface IAppointmentService
    {
        public List<Doctor> GetDoctorList();
        public List<Patient> GetPatientList();

        public Task<int> AddUpdate(AppointmentVM model);
        public List<AppointmentVM> DoctorsEventsById(string doctorId);

        public List<AppointmentVM> PatientsEventsById(string patientId);

        public AppointmentVM GetById(int id);

        public Task<int> Delete(int id);

        public Task<int> ConfirmEvent(int id);
    }
}
