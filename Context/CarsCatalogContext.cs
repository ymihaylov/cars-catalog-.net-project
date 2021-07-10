using System;
using CarsCatalog.Models;
using Microsoft.EntityFrameworkCore;


namespace CarsCatalog.Context
{
    public class CarsCatalogContext : DbContext
    {
        public CarsCatalogContext(DbContextOptions<CarsCatalogContext> options) : base(options)
        {
        }

        public DbSet<CarMake> CarMake { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<Comment> Comments{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
