namespace WebApplication1.Repositories.Interface
{
    public interface IUnitOfWork
    {
        IPatientRepository Patient { get; }
        IDoctorRepository Doctor { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
}
