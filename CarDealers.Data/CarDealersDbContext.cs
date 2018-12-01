using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Data.Migration;
using CarDealers.Data.Models;

namespace CarDealersWeb.Data 
{
    public class CarDealersDbContext : IdentityDbContext<User>
    {
        public CarDealersDbContext()
        {

        }

        public CarDealersDbContext(DbContextOptions<CarDealersDbContext> options)
            : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Part> Parts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<PartCar>()
                .HasKey(pc => new { pc.CarId, pc.PartId});

            builder.Entity<PartCar>()
                .HasOne(p => p.Car)
                .WithMany(c => c.Parts)
                .HasForeignKey(c => c.CarId);

            builder.Entity<PartCar>()
                .HasOne(p => p.Part)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.PartId);


            builder
                 .Entity<Sale>()
                 .HasOne(s => s.Car)
                 .WithMany(c => c.Sales)
                 .HasForeignKey(s => s.CarId);

            builder
                .Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

            builder
                .Entity<Supplier>()
                .HasMany(s => s.Parts)
                .WithOne(c => c.Supplier)
                .HasForeignKey(p => p.SupplierId);
           

            base.OnModelCreating(builder);
             
        }
    }
}
