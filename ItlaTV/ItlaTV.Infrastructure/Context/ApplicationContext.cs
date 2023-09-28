using ItlaTV.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItlaTV.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Productora> Productoras { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Serie> Series { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables
            modelBuilder.Entity<Productora>().ToTable("Productora");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<Serie>().ToTable("Series");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Productora>().HasKey(p => p.ProductoraId);
            modelBuilder.Entity<Genero>().HasKey(g => g.GeneroId);
            modelBuilder.Entity<Serie>().HasKey(s => s.SerieId);
            #endregion

            #region relationships
            modelBuilder.Entity<Productora>()
                .HasMany<Serie>(p => p.Series)
                .WithOne(s => s.Productora)
                .HasForeignKey(p => p.ProductoraId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                .HasOne(s => s.Genero)
                .WithMany(g => g.Series)
                .HasForeignKey(s => s.GeneroId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                .HasOne(s => s.SGenero)
                .WithMany()
                .HasForeignKey(s => s.SGeneroId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
