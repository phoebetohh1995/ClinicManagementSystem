using WebApplication1.Models;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private WebApp1Context _db;
        public PatientRepository(WebApp1Context db) : base(db)
        {
            _db = db;
        }
        public void Update(Patient obj)
        {
            _db.Patients.Update(obj);
        }
    }
}
