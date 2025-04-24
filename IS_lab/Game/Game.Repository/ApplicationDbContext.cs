using Game.Domain.DomainModels;
using Game.Domain.Idenity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Game.Repository
{
    public class ApplicationDbContext : IdentityDbContext<AthletesApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<AthletesApplicationUser> Users { get; set; }
    }
}
