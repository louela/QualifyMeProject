using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualifyMeProject.DomainModels;
using QualifyMeProject.ViewModels;
using AutoMapper.Configuration;
using AutoMapper;
using QualifyMeProject.Repositories;

namespace QualifyMeProject.ServiceLayer
{
    public interface ICompanyUsersService
    {
        int InsertCompanyUser(AddCompanyViewModel acm);
        void UpdateCompanyUserDetails(EditCompanyUserDetailsViewModel ecdvm);
        void DeleteCompanyUser(int cid);
        List<CompanyUserViewModel> GetCompanyUsers();
        CompanyUserViewModel GetCompanyUsersByEmailAndPassword(string CompanyEmail, string CompanyPassword);
        CompanyUserViewModel GetCompanyUsersByCompanyID(int CompanyID);
    }

    public class CompanyUsersService : ICompanyUsersService
    {
         ICompanyUsersRepository cr;

        public CompanyUsersService()
        {
            cr = new CompanyUsersRepository();
        }

        public int InsertCompanyUser(AddCompanyViewModel acm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddCompanyViewModel, CompanyUser>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            CompanyUser cu = mapper.Map<AddCompanyViewModel, CompanyUser>(acm);
            cu.CompanyPasswordHash = SHA256HashGenerator.GenerateHash(acm.CompanyPassword);
            cr.InsertCompanyUser(cu);
            int cid = cr.GetLatestCompanyUserID();
            return cid;
        }

        public void UpdateCompanyUserDetails(EditCompanyUserDetailsViewModel ecdvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditCompanyUserDetailsViewModel, CompanyUser>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            CompanyUser cu = mapper.Map<EditCompanyUserDetailsViewModel, CompanyUser>(ecdvm);
            cr.UpdateCompanyUserDetails(cu);
        }

        public void DeleteCompanyUser(int cid)
        {
            cr.DeleteCompanyUser(cid);
        }

        public List<CompanyUserViewModel> GetCompanyUsers()
        {
            List<CompanyUser> cu = cr.GetCompanyUsers();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CompanyUser, CompanyUserViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<CompanyUserViewModel> cvm = mapper.Map<List<CompanyUser>, List<CompanyUserViewModel>>(cu);
            return cvm;
        }

        public CompanyUserViewModel GetCompanyUsersByEmailAndPassword(string CompanyEmail, string CompanyPassword)
        {
            CompanyUser cu = cr.GetCompanyUsersByEmailAndPassword(CompanyEmail, SHA256HashGenerator.GenerateHash(CompanyPassword)).FirstOrDefault();
            CompanyUserViewModel cvm = null;
            if (cu != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<CompanyUser, CompanyUserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                cvm = mapper.Map<CompanyUser, CompanyUserViewModel>(cu);
            }
            return cvm;
        }

        public CompanyUserViewModel GetCompanyUsersByCompanyID(int CompanyID)
        {
            CompanyUser cu = cr.GetCompanyUsersByCompanyID(CompanyID).FirstOrDefault();
            CompanyUserViewModel cvm = null;
            if (cu != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<CompanyUser, CompanyUserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                cvm = mapper.Map<CompanyUser, CompanyUserViewModel>(cu);

            }
            return cvm;
        }
    }
}
