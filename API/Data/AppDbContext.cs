using API.Models;
using Microsoft.EntityFrameworkCore;


namespace OrangeHub.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Apontamento> Apontamentos { get; set; }

        public DbSet<Escritorio> Escritorios { get; set; }
    }
}
