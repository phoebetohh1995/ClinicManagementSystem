using WebApplication1.Models;

namespace WebApplication1.Repositories.Interface
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        void Update(Doctor obj);
    }
}
