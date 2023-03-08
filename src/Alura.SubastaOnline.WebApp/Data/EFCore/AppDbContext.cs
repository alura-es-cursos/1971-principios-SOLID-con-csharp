using Microsoft.EntityFrameworkCore;
using Alura.SubastaOnline.WebApp.Models;

namespace Alura.SubastaOnline.WebApp.Data.EFCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Subasta> Subastas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AluraSubastasDB;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subasta>()
                .HasOne(l => l.Categoria)
                .WithMany(c => c.Subastas)
                .HasForeignKey(l => l.IdCategoria);
        }
    }
}