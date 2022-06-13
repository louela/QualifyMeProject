using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using QualifyMeProject.DomainModels;
using QualifyMeProject.Repositories;
using QualifyMeProject.ViewModels;

namespace QualifyMeProject.ServiceLayer
{
    public interface ICoursesService
    {
        int InsertCourse(AddCourseViewModel acvm);
        void UpdateCompanyUserDetails(EditCourseDetailsViewModel ecdvm);
        void DeleteCourse(int cid);
        List<CourseViewModel> GetCourses();
        CourseViewModel GetCoursesByCourseID(int CourseID);
    }

    public class CoursesService: ICoursesService
    {
        ICoursesRepository cor;

        public CoursesService()
        {
            cor = new CoursesRepository();
        }
        public int InsertCourse(AddCourseViewModel acvm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddCourseViewModel, Course>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Course co = mapper.Map<AddCourseViewModel, Course>(acvm);
            cor.InsertCourse(co);
            int cid = cor.GetLatestCourseID();
            return cid;
        }

        public void UpdateCompanyUserDetails(EditCourseDetailsViewModel ecdvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditCourseDetailsViewModel, Course>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Course co = mapper.Map<EditCourseDetailsViewModel, Course>(ecdvm);
            cor.UpdateCourseDetails(co);
        }

        public void DeleteCourse(int cid)
        {
            cor.DeleteCourse(cid);
        }

        public List<CourseViewModel> GetCourses()
        {
            List<Course> co = cor.GetCoursesByDepartment();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Course, CourseViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<CourseViewModel> cvm = mapper.Map<List<Course>, List<CourseViewModel>>(co);
            return cvm;
        }

        public CourseViewModel GetCoursesByCourseID(int CourseID)
        {
            Course co = cor.GetCoursesByCourseID(CourseID).FirstOrDefault();
            CourseViewModel cvm = null;
            if (co != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Course, CourseViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                cvm = mapper.Map<Course, CourseViewModel>(co);

            }
            return cvm;
        }
    }
}
