using EF_ADO_EmployeeRecordMgt.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_ADO_EmployeeRecordMgt.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options) { }

        public DbSet<DepartmentMaster> departmentMasters { get; set; }

        public DbSet<DesignationMaster> designationMasters { get; set; }

        public DbSet<EmployeeMaster> employeeMasters { get; set; }

    }
}
