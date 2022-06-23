using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualifyMeProject.DomainModels;
using QualifyMeProject.Repositories;
using QualifyMeProject.ViewModels;



namespace QualifyMeProject.Repositories
{
    public interface ICoursesRepository
    {
        void AddCourse(Course c);
        void UpdateCourseDetails(Course c);
        void DeleteCourse(int cid);
        List<Course> GetCourses();
        int GetLatestCourseID();
        List<Course> GetCoursesByCourseName(string CourseName);
        List<Course> GetCoursesByDepartmentName(string DepartmentName);



    }

    public class CoursesRepository : ICoursesRepository
    {
        QualifyMeDatabaseDbContext db;

        public CoursesRepository()
        {
            db = new QualifyMeDatabaseDbContext();
        }
        public void AddCourse(Course c)
        {
            db.Courses.Add(c);
            db.SaveChanges();
        }

        public void UpdateCourseDetails(Course c)
        {
            Course co = db.Courses.Where(temp => temp.CourseID == c.CourseID).FirstOrDefault();
            if (co != null)
            {
                co.DepartmentName = c.DepartmentName;
                co.CourseName = c.CourseName;
                db.SaveChanges();

            }
        }

        public void DeleteCourse(int cid)
        {
            Course co = db.Courses.Where(temp => temp.CourseID == cid).FirstOrDefault();
            if (co != null)
            {
                db.Courses.Remove(co);
                db.SaveChanges();

            }
        }

        public List<Course> GetCourses()
        {
            List<Course> co = db.Courses.OrderByDescending(temp => temp.CourseName).ToList();
            return co;
        }

        public int GetLatestCourseID()
        {
            int cid = db.Courses.Select(temp => temp.CourseID).Max();
            return cid;
        }

        public List<Course> GetCoursesByCourseName(string CourseName)
        {
            List<Course> co = db.Courses.Where(temp => temp.CourseName == CourseName).ToList();
            return co;
        }

        public List<Course> GetCoursesByDepartmentName(string DepartmentName)
        {
            List<Course> co = db.Courses.Where(temp => temp.DepartmentName == DepartmentName ).OrderByDescending(temp => temp.DepartmentName).ToList();
            return co;
        }


    }
}
