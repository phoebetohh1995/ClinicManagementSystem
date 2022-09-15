using WebApplication1.Models;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Repositories
{
    public class DoctoryRepository:Repository<Doctor>, IDoctorRepository
    {
        private WebApp1Context _db;
        public DoctoryRepository(WebApp1Context db):base(db)
        {
            _db = db;
        }

       
        public void Update(Doctor obj)
        {
            _db.Doctors.Update(obj);
        }
    }
}
