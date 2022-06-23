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
    public interface IJobsService
    {
        int AddJobs(AddJobViewModel ajm);
       // void UpdateJobDetails(EditJobViewModel ejm);
        void DeleteJob(int jid);
        List<JobViewModel> GetJobs();
        JobViewModel GetJobsByJobID(int JobID);
    }
    public class JobsService: IJobsService
    {
        IJobsRepository jor;

        public JobsService()
        {
            jor = new JobsRepository();
        }
        public int AddJobs(AddJobViewModel ajm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddJobViewModel, Job>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Job jo = mapper.Map<AddJobViewModel, Job>(ajm);
            jor.AddJob(jo);
            int jid = jor.GetLatestJobID();
            return jid;
        }

        public void DeleteJob(int jid)
        {
            jor.DeleteJob(jid);
        }

        public List<JobViewModel> GetJobs()
        {
            List<Job> jo = jor.GetJobs();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Job, JobViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<JobViewModel> jvm = mapper.Map<List<Job>, List<JobViewModel>>(jo);
            return jvm;
        }

        public JobViewModel GetJobsByJobID(int JobID)
        {
            Job jo = jor.GetJobsByJobID(JobID).FirstOrDefault();
            JobViewModel jvm = null;
            if (jo != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Job, JobViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                jvm = mapper.Map<Job, JobViewModel>(jo);

            }
            return jvm;
        }
    }
}
