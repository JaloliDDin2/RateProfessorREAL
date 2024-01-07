using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyRateApp2.Models;

namespace MyRateApp2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MyRateApp2.Models.Professor>? Professor { get; set; }
        public DbSet<MyRateApp2.Models.University>? University { get; set; }
        public DbSet<MyRateApp2.Models.User>? User { get; set; }
        public DbSet<MyRateApp2.Models.ProfessorRating>? ProfessorRating { get; set; }
        public DbSet<MyRateApp2.Models.UniversityRating>? UniversityRating { get; set; }
        public DbSet<MyRateApp2.Models.UserProfessorRating>? UserProfessorRating { get; set; }
        public DbSet<MyRateApp2.Models.UserUniversityRating>? UserUniversityRating { get; set; }
    }
}
