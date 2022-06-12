using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualifyMeProject.DomainModels;

namespace QualifyMeProject.Repositories
{
    public interface ICompanyUsersRepository
    {
            
            void InsertCompanyUser(CompanyUser cu);
            void UpdateCompanyUserDetails(CompanyUser cu);
            void UpdateCompanyUserPassword(CompanyUser cu);

            void DeleteCompanyUser(int cid);
            List<CompanyUser> GetCompanyUsers();
            int GetLatestCompanyUserID();
            List<CompanyUser> GetCompanyUsersByEmailAndPassword(string CompanyEmail, string CompanyPasswordHash);
            List<CompanyUser> GetCompanyUsersByCompanyID(int CompanyID);

    }

    public class CompanyUsersRepository : ICompanyUsersRepository
    {
         QualifyMeDatabaseDbContext db;

         public CompanyUsersRepository()
         {
             db = new QualifyMeDatabaseDbContext();
         }

         public void InsertCompanyUser(CompanyUser c)
        {
            db.CompanyUsers.Add(c);
            db.SaveChanges();
        }

        public void UpdateCompanyUserDetails(CompanyUser c)
        {
            CompanyUser cu = db.CompanyUsers.Where(temp => temp.CompanyID == c.CompanyID).FirstOrDefault();
            if (cu != null)
            {
                cu.CompanyName = c.CompanyName;
                cu.CompanyMobile = c.CompanyMobile;
                cu.CompanyAddress = c.CompanyAddress;
                cu.CompanyDescription = c.CompanyDescription;
                db.SaveChanges();

            }
        }

        public void UpdateCompanyUserPassword(CompanyUser c)
        {
            CompanyUser cu = db.CompanyUsers.Where(temp => temp.CompanyID == c.CompanyID).FirstOrDefault();
            if (cu != null)
            {
                cu.CompanyPasswordHash = c.CompanyPasswordHash;

                db.SaveChanges();

            }
        }

        public void DeleteCompanyUser(int cid)
        {
            CompanyUser cu = db.CompanyUsers.Where(temp => temp.CompanyID == cid).FirstOrDefault();
            if (cu != null)
            {
                db.CompanyUsers.Remove(cu);
                db.SaveChanges();

            }
        }

        public List<CompanyUser> GetCompanyUsers()
        {
            List<CompanyUser> cu = db.CompanyUsers.Where(temp => temp.IsAdmin == false).OrderBy(temp => temp.CompanyName).ToList();
            return cu;
        }

        public int GetLatestCompanyUserID()
        {
            int cid = db.CompanyUsers.Select(temp => temp.CompanyID).Max();
            return cid;
        }

        public List<CompanyUser> GetCompanyUsersByEmailAndPassword(string CompanyEmail, string CompanyPasswordHash)
        {
            List<CompanyUser> cu = db.CompanyUsers.Where(temp => temp.CompanyEmail == CompanyEmail && temp.CompanyPasswordHash == CompanyPasswordHash).ToList();
            return cu;
        }

        public List<CompanyUser> GetCompanyUsersByCompanyID(int CompanyID)
        {
            List<CompanyUser> cu = db.CompanyUsers.Where(temp => temp.CompanyID == CompanyID).ToList();
            return cu;
        }
    }
}
