using Microsoft.EntityFrameworkCore;
using TestLanding.Domain;

namespace TestLanding.DAL;

public class TestLandingDB : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;

    public DbSet<Department> Departments { get; set; } = null!;

    public TestLandingDB(DbContextOptions<TestLandingDB> options) : base(options) { }

}
