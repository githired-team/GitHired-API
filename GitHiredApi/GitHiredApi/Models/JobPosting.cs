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
        public string [] RequiredSkills { get; set; }
        public string Company { get; set; }

        public JobPosting(Job job, string[] skills, string company)
        {
            JobTitle = job.JobTitle;
            Description = job.Description;
            Location = job.Location;
            WageRange = job.WageRange;
            RequiredSkills = skills;
            Company = company;
        }
    }
}
