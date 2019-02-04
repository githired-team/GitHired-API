using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHiredApi.Models
{
    public class JobPosting
    {


        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string WageRange { get; set; }

        public JobPosting(Job job, string[] skills)
        {
            JobTitle = job.JobTitle;
            Description = job.Description;
            Location = job.Location;
            WageRange = job.WageRange;
        }
    }
}
