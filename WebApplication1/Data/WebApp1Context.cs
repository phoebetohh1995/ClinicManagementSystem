using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Models;

public class WebApp1Context : IdentityDbContext
{
    public WebApp1Context(DbContextOptions<WebApp1Context> options)
        : base(options)
    {
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Nurse> Nurses { get; set; }
    public DbSet<Admin> Admins { get; set; }

   

}
