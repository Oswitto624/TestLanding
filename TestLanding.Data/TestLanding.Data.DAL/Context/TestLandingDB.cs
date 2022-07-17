using Microsoft.EntityFrameworkCore;
using TestLanding.Domain;

namespace TestLanding.DAL.Context;

public class TestLandingDB : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }

    public TestLandingDB(DbContextOptions<TestLandingDB> options) : base(options) { }

}
