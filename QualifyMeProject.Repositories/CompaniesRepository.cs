using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualifyMeProject.DomainModels;

namespace QualifyMeProject.Repositories
{
    
        public interface ICompaniesRepository
        {
           
            void UpdateCompanyDetails(CompanyUser c);
            void UpdateCompanyPassword(CompanyUser c);

            void DeleteCompany(int cid);
            List<CompanyUser> GetCompanies();
            int GetLatestCompanyID();
            List<CompanyUser> GetCompaniesByEmailAndPassword(string CompanyEmail, string CompanyPasswordHash);
        }
        public class CompaniesRepository : ICompaniesRepository
        {
            QualifyMeDatabaseDbContext db;

            public CompaniesRepository()
            {
                db = new QualifyMeDatabaseDbContext();
            }
        public void UpdateCompanyDetails(CompanyUser c)
            {
            CompanyUser co = db.Companies.Where(temp => temp.CompanyID == c.CompanyID).FirstOrDefault();
            if (co != null)
            {
                co.CompanyName = c.CompanyName;
                co.CompanyMobile = c.CompanyMobile;
                co.CompanyAddress = c.CompanyAddress;
                co.CompanyDescription = c.CompanyDescription;
                db.SaveChanges();

            }
        }

            public void UpdateCompanyPassword(CompanyUser c)
            {
                CompanyUser co = db.Companies.Where(temp => temp.CompanyID == c.CompanyID).FirstOrDefault();
                if (co != null)
            {
                co.CompanyPasswordHash = c.CompanyPasswordHash;

                db.SaveChanges();

            }
        }

            public void DeleteCompany(int cid)
            {
            CompanyUser co = db.Companies.Where(temp => temp.CompanyID == cid).FirstOrDefault();
            if (co != null)
            {
                db.Companies.Remove(co);
                db.SaveChanges();

            }
        }

            public List<CompanyUser> GetCompanies()
            {
            List<CompanyUser> co = db.Companies.Where(temp => temp.IsAdmin == false).OrderBy(temp => temp.CompanyName).ToList();
            return co;
        }

            public int GetLatestCompanyID()
            {
            int cid = db.Companies.Select(temp => temp.CompanyID).Max();
            return cid;
        }

            public List<CompanyUser> GetCompaniesByEmailAndPassword(string CompanyEmail, string CompanyPasswordHash)
            {
            List<CompanyUser> co = db.Companies.Where(temp => temp.CompanyEmail == CompanyEmail && temp.CompanyPasswordHash == CompanyPasswordHash).ToList();
            return co;
        }
        }
}
