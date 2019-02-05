using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHiredApi.Data;
using GitHiredApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GitHiredApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetJobsController : ControllerBase
    {
        private GitHiredApiDbContext _context;

        public GetJobsController(GitHiredApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<JobsResponse>> Get()
        {
            List<Job> allJobs = await _context.Jobs.Include(job => job.Company)
                                                   .Include(job => job.RequiredSkills)
                                                   .ToListAsync();

            if (allJobs == null)
            {
                return new JobsResponse(new JobPosting[] { });
            }

            List<JobPosting> allPostings = new List<JobPosting>();

            foreach(Job job in allJobs)
            {
                
                string[] skills = new string[] { };

                if (job.RequiredSkills != null)
                {
                    skills = job.RequiredSkills.Select(rs => rs.Skill.ToString()).ToArray();

                }

                string company = "";

                if (job.Company != null)
                {
                    company = job.Company.Name;
                }

                allPostings.Add(new JobPosting(job, skills, company));
            }

            
            return new JobsResponse(allPostings.ToArray());
        }



        

    }
}
