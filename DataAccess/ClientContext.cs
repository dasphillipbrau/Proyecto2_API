using Microsoft.EntityFrameworkCore;
using Proyecto2_AppWeb.Models;

namespace Proyecto2_API.DataAccess
{
    public class ClientContext : DbContext
    {
        public DbSet<Client> Cliente { get; set; }
        public DbSet<Prospect> Prospecto { get; set; }
        public DbSet<BadProspect> MalProspecto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=PRO-74;Database=ISAACGARRO_PROYECTO2; User Id=sa; Password=uneduned;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>().
                Property(p => p.Discount).
                HasConversion(
                v => v ? 1 : 0,
                v => (v == 1));


        }
    }
}