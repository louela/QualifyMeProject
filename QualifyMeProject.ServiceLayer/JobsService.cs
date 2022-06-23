using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualifyMeProject.ViewModels;

namespace QualifyMeProject.ServiceLayer
{
    public interface IJobsService
    {
        int AddJobs(AddCourseViewModel acvm);
        void UpdateCompanyUserDetails(EditCourseDetailsViewModel ecdvm);
        void DeleteCourse(int cid);
        List<CourseViewModel> GetCourses();
        List<CourseViewModel> GetCoursesBySpecification(string CourseSpecification);
        CourseViewModel GetCoursesByCourseID(int CourseID);
    }
    public class JobsService
    {
    }
}
