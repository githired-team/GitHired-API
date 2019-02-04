using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHiredApi.Models
{
    public class JobsResponse
    {
        public JobPosting[] JobPostings { get; set; }


        public JobsResponse(JobPosting[] postings)
        {
            JobPostings = postings;
        }
    }
}
