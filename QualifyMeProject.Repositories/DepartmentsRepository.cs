using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualifyMeProject.DomainModels;

namespace QualifyMeProject.Repositories
{
    public interface IDepartmentsRepository
    {
        void AddDepartment(Department d);
        void UpdateDepartmentDetails(Department d);
        void DeleteDepartment(int did);
        List<Department> GetDepartments();
        int GetLatestDepartmentID();
        List<Department> GetDepartmentsByDepartmentID(int DeptID);
       





    }
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private QualifyMeDatabaseDbContext db;
        public DepartmentsRepository()
        {
            db = new QualifyMeDatabaseDbContext();
        }
        public void AddDepartment(Department d)
        {
            db.Departments.Add(d);
            db.SaveChanges();
        }

        public void UpdateDepartmentDetails(Department d)
        {
            Department de = db.Departments.Where(temp => temp.DeptID == d.DeptID).FirstOrDefault();
            if (de != null)
            {
                de.DepartmentName = d.DepartmentName;
                db.SaveChanges();

            }
        }

        public void DeleteDepartment(int did)
        {
            Department de = db.Departments.Where(temp => temp.DeptID == did).FirstOrDefault();
            if (de != null)
            {
                db.Departments.Remove(de);
                db.SaveChanges();

            }
        }

        public List<Department> GetDepartments()
        {
            List<Department> de = db.Departments.ToList();
            return de;
        }

        public int GetLatestDepartmentID()
        {
            int did = db.Departments.Select(temp => temp.DeptID).Max();
            return did;
        }

        public List<Department> GetDepartmentsByDepartmentID(int DeptID)
        {
            List<Department> de = db.Departments.Where(temp => temp.DeptID == DeptID).ToList();
            return de;
        }
    }
}
