using GenericAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericPersistence.DataAccess;

public class GenericDbContext : DbContext
{
    public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options) { }
    
    public DbSet<GuitarModel> Guitars { get; set; }
    public DbSet<SellerModel> Sellers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SellerModel>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GuitarModel>(entity =>
        {
            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        });
    }
}