using Aplication_Programming_Interface_01.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aplication_Programming_Interface_01.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }
    }
}
