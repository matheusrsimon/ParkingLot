using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ParkingLot.Server.Models;
using System.Reflection.Metadata;

namespace ParkingLot.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ParkingSection> ParkingSections { get; set; }
        public DbSet<SpotSize> SpotSizes { get; set; }
        public DbSet<SpotSizeUsage> SpotSizeUsages { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ParkingLot;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpotSize>().HasMany(x => x.VehicleUsage).WithOne(x => x.VehicleSize).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SpotSize>().HasMany(x => x.SpotUsage).WithOne(x => x.SpotSize).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SpotSize>().HasData(new SpotSize { Id = 1, Name = "Small" });
            modelBuilder.Entity<SpotSize>().HasData(new SpotSize { Id = 2, Name = "Medium" });
            modelBuilder.Entity<SpotSize>().HasData(new SpotSize { Id = 3, Name = "Large" });

            modelBuilder.Entity<ParkingSection>().HasData(new ParkingSection { Id = 1, Count = 10, SizeId = 1 });
            modelBuilder.Entity<ParkingSection>().HasData(new ParkingSection { Id = 2, Count = 10, SizeId = 2 });
            modelBuilder.Entity<ParkingSection>().HasData(new ParkingSection { Id = 3, Count = 10, SizeId = 3 });

            modelBuilder.Entity<VehicleType>().HasData(new VehicleType { Id = 1, Name = "Motorcycle", SizeId = 1 });
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType { Id = 2, Name = "Car", SizeId = 2 });
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType { Id = 3, Name = "Van", SizeId = 3 });

            modelBuilder.Entity<SpotSizeUsage>().HasData(new SpotSizeUsage { Id = 1, VehicleSizeId = 1, SpotSizeId = 1, Usage = 1 });
            modelBuilder.Entity<SpotSizeUsage>().HasData(new SpotSizeUsage { Id = 2, VehicleSizeId = 1, SpotSizeId = 2, Usage = 1 });
            modelBuilder.Entity<SpotSizeUsage>().HasData(new SpotSizeUsage { Id = 3, VehicleSizeId = 1, SpotSizeId = 3, Usage = 1 });

            modelBuilder.Entity<SpotSizeUsage>().HasData(new SpotSizeUsage { Id = 4, VehicleSizeId = 2, SpotSizeId = 2, Usage = 1 });
            modelBuilder.Entity<SpotSizeUsage>().HasData(new SpotSizeUsage { Id = 5, VehicleSizeId = 2, SpotSizeId = 3, Usage = 1 });

            modelBuilder.Entity<SpotSizeUsage>().HasData(new SpotSizeUsage { Id = 6, VehicleSizeId = 3, SpotSizeId = 2, Usage = 3 });
            modelBuilder.Entity<SpotSizeUsage>().HasData(new SpotSizeUsage { Id = 7, VehicleSizeId = 3, SpotSizeId = 3, Usage = 1 });
        }
    }
}