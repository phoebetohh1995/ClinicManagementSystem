using WebApplication1.Models;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private WebApp1Context _db;
        public UnitOfWork(WebApp1Context db)
        {
            _db = db;
            Patient = new PatientRepository(_db);
            Doctor = new DoctoryRepository(_db);
            ApplicationUser  = new ApplicationUserRepository (_db);

        }
        public IPatientRepository Patient { get; private set; }
        public IDoctorRepository Doctor { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
