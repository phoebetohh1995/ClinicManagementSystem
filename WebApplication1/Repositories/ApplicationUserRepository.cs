using WebApplication1.Models;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Repositories
{
    public class ApplicationUserRepository: Repository<ApplicationUser>, IApplicationUserRepository
    {
        private WebApp1Context _db;

        public ApplicationUserRepository(WebApp1Context db) : base(db)
        {
            _db = db;
        }
    }
}
