using Microsoft.EntityFrameworkCore;
namespace CRUD_CodeFirstApproach_EFCore.Models
{
    public class Employee_DB_Context : DbContext
    {
        public Employee_DB_Context(DbContextOptions<Employee_DB_Context> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
