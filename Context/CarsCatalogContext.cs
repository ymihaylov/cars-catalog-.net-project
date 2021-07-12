using System;
using CarsCatalog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CarsCatalog.Context
{
    public class CarsCatalogContext : IdentityDbContext
    {
        public CarsCatalogContext(DbContextOptions<CarsCatalogContext> options) : base(options)
        {
        }

        public DbSet<CarMake> CarMake { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<Comment> Comments{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.CarModel)
                .WithMany(c => c.Comments)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
