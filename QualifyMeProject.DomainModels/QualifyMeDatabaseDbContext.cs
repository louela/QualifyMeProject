using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QualifyMeProject.DomainModels
{
    public class QualifyMeDatabaseDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
