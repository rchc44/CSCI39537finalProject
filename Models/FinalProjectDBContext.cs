using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace FinalProject.Models
{
    public class FinalProjectDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public FinalProjectDBContext(DbContextOptions<FinalProjectDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("FinalProject");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Seat> Seats { get; set; } = null!;
    }
}



