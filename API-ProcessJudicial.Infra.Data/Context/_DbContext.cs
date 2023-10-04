using API_ProcessJudicial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud_API.Models
{
    public class _DbContext : DbContext
    {

        public DbSet<Users> users { get; set; }
        public DbSet<JudicialProcess> judicialprocesses { get; set; }
        public DbSet<Documents> documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("PROCESSOJUDICIAL_CONNECTION");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}