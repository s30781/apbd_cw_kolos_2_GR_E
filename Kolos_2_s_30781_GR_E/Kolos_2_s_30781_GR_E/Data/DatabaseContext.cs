using Kolos_2_s_30781_GR_E.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolos_2_s_30781_GR_E.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<Species> Species { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Batch> Batches { get; set; }
    public DbSet<EmployeeBatch> EmployeeBatches { get; set; }

    public DatabaseContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeBatch>()
            .HasKey(eb => new { eb.EmployeeId, eb.BatchId });

        modelBuilder.Entity<EmployeeBatch>()
            .HasOne(eb => eb.Employee)
            .WithMany(e => e.EmployeeBatches)
            .HasForeignKey(eb => eb.EmployeeId);

        modelBuilder.Entity<EmployeeBatch>()
            .HasOne(eb => eb.Batch)
            .WithMany(b => b.EmployeeBatches)
            .HasForeignKey(eb => eb.BatchId);

        modelBuilder.Entity<Nursery>().HasData(
            new Nursery { Id = 1, Name = "Green Forest Nursery", EstablishedDate = new DateTime(2005, 5, 10) }
        );

        modelBuilder.Entity<Species>().HasData(
            new Species { Id = 1, LatinName = "Quercus robur", GrowthTimeInYears = 5 }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, FirstName = "Anna", LastName = "Kowalska" },
            new Employee { Id = 3, FirstName = "Jan", LastName = "Nowak" }
        );
    }
}