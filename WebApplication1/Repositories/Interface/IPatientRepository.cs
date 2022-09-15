using WebApplication1.Models;

namespace WebApplication1.Repositories.Interface
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Update(Patient obj);
    }
}
