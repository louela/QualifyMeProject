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
    public interface IDepartmentsService
    {
        int AddDepartment(AddDepartmentViewModel advm);
       // void UpdateDepartmentDetails(EditCourseDetailsViewModel ecdvm);
        void DeleteDepartment(int did);
        List<DepartmentViewModel> GetDepartments();
        DepartmentViewModel GetDepartmentsByDepartmentID(int DeptID);
    }
    public class DepartmentsService : IDepartmentsService
    {
        IDepartmentsRepository dor;

        public DepartmentsService()
        {
            dor = new DepartmentsRepository();
        }
        public int AddDepartment(AddDepartmentViewModel advm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddDepartmentViewModel, Department>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Department de = mapper.Map<AddDepartmentViewModel, Department>(advm);
            dor.AddDepartment(de);
            int did = dor.GetLatestDepartmentID();
            return did;
        }

        public void DeleteDepartment(int did)
        {
            dor.DeleteDepartment(did);
        }

        public List<DepartmentViewModel> GetDepartments()
        {
            List<Department> de = dor.GetDepartments();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Department, DepartmentViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<DepartmentViewModel> dvm = mapper.Map<List<Department>, List<DepartmentViewModel>>(de);
            return dvm;
        }

        public DepartmentViewModel GetDepartmentsByDepartmentID(int DeptID)
        {
            Department de = dor.GetDepartmentsByDepartmentID(DeptID).FirstOrDefault();
            DepartmentViewModel dvm = null;
            if (de != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Department, DepartmentViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                dvm = mapper.Map<Department, DepartmentViewModel>(de);

            }
            return dvm;
        }
    }
}
