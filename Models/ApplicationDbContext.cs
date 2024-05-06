using Microsoft.EntityFrameworkCore;

namespace TestProjectApi.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions option):base(option)
        {

        }
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<MainStock> MainStock { get; set; }
        public DbSet<SalesInfo> SalesInfo {  get; set; }
    }
}
