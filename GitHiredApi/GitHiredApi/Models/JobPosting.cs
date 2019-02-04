using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHiredApi.Models
{
    public class JobPosting
    {
        public Job Job { get; set; }
        public string[] Skills { get; set; }

        public JobPosting(Job job, string[] skills)
        {
            Job = job;
            Skills = skills;
        }
    }
}
