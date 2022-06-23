using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualifyMeProject.DomainModels;

namespace QualifyMeProject.Repositories
{
    public interface IJobsRepository
    {
        void AddJob(Job j);
        void UpdateJobDetails(Job j);
        void DeleteJob(int jid);
        List<Job> GetJobs();
        int GetLatestJobID();
        List<Job> GetJobsByJobID(int JobID);



    }
    public class JobsRepository : IJobsRepository
    {
        QualifyMeDatabaseDbContext db;

        public JobsRepository()
        {
            db = new QualifyMeDatabaseDbContext();
        }

        public void AddJob(Job j)
        {
            db.Jobs.Add(j);
            db.SaveChanges();
        }

        public void UpdateJobDetails(Job j)
        {
            Job jo = db.Jobs.Where(temp => temp.JobID == j.JobID).FirstOrDefault();
            if (jo != null)
            {
                jo.JobDescription = j.JobDescription;
                jo.JobTitle = j.JobTitle;
                db.SaveChanges();

            }
        }

        public void DeleteJob(int jid)
        {
            Job jo = db.Jobs.Where(temp => temp.JobID == jid).FirstOrDefault();
            if (jo != null)
            {
                db.Jobs.Remove(jo);
                db.SaveChanges();

            }
        }

        public List<Job> GetJobs()
        {
            List<Job> jo = db.Jobs.OrderByDescending(temp => temp.JobID).ToList();
            return jo;
        }

        public int GetLatestJobID()
        {
            int jid = db.Jobs.Select(temp => temp.JobID).Max();
            return jid;
        }

        public List<Job> GetJobsByJobID(int JobID)
        {
            List<Job> jo = db.Jobs.Where(temp => temp.JobID == JobID).ToList();
            return jo;
        }

    }

       
    
}
