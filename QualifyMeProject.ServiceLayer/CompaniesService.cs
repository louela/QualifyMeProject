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
    
        public interface ICompaniesService
        {
           

            void DeleteCompany(int cid);
            List<CompanyUserViewModel> GetCompanies();
            CompanyUserViewModel GetCompaniesByEmailAndPassword(string CompanyEmail, string CompanyPassword);

        }
        public class CompaniesService :ICompaniesService
        {
            CompaniesRepository cs;

            public CompaniesService()
            {
                cs = new CompaniesRepository();
            }
        public void DeleteCompany(int cid)
            {
            cs.DeleteCompany(cid);
        }

            public List<CompanyUserViewModel> GetCompanies()
            {
            List<CompanyUser> c = cs.GetCompanies();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CompanyUser, CompanyUserViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<CompanyUserViewModel> cvm = mapper.Map<List<CompanyUser>, List<CompanyUserViewModel>>(c);
            return cvm;
        }

            public CompanyUserViewModel GetCompaniesByEmailAndPassword(string CompanyEmail, string CompanyPassword)
            {
            CompanyUser c = cs.GetCompaniesByEmailAndPassword(CompanyEmail, SHA256HashGenerator.GenerateHash(CompanyPassword)).FirstOrDefault();
            CompanyUserViewModel cvm = null;
            if (c != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<CompanyUser, CompanyUserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                cvm = mapper.Map<CompanyUser, CompanyUserViewModel>(c);
            }
            return cvm;
        }
        }
}
