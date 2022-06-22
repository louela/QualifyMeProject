﻿using System;
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
        void InsertCourse(Course c);
        void UpdateCourseDetails(Course c);
        void DeleteCourse(int cid);
        List<Course> GetCourses();
        int GetLatestCourseID();
        List<Course> GetCoursesByCourseID(int CourseID);
        List<Course> GetCoursesBySpecification(string CourseSpecification);



    }

    public class CoursesRepository : ICoursesRepository
    {
        QualifyMeDatabaseDbContext db;

        public CoursesRepository()
        {
            db = new QualifyMeDatabaseDbContext();
        }
        public void InsertCourse(Course c)
        {
            db.Courses.Add(c);
            db.SaveChanges();
        }

        public void UpdateCourseDetails(Course c)
        {
            Course co = db.Courses.Where(temp => temp.CourseID == c.CourseID).FirstOrDefault();
            if (co != null)
            {
                co.CourseDepartment = c.CourseDepartment;
                co.CourseSpecification = c.CourseSpecification;
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
            List<Course> co = db.Courses.OrderByDescending(temp => temp.CourseDepartment).ToList();
            return co;
        }

        public int GetLatestCourseID()
        {
            int cid = db.Courses.Select(temp => temp.CourseID).Max();
            return cid;
        }

        public List<Course> GetCoursesByCourseID(int CourseID)
        {
            List<Course> co = db.Courses.Where(temp => temp.CourseID == CourseID).ToList();
            return co;
        }

        public List<Course> GetCoursesBySpecification(string CourseSpecification)
        {
            List<Course> co = db.Courses.Where(temp => temp.CourseSpecification == CourseSpecification ).OrderByDescending(temp => temp.CourseSpecification).ToList();
            return co;
        }


    }
}
