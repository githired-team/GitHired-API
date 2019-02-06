using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHiredApi.Data;
using GitHiredApi.Helpers;
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

        // Takes in a search query and returns an object containing a list of all jobs whose title or description
        //   contains the given query string.
        //  If no query string is provided, or the query string is empty, data for all jobs in our database 
        //   is returned. 
        [HttpGet]
        public async Task<ActionResult> Search(string query)
        {
            List<JobPosting> jobs;

            if (query == null || query == "")
            {
                jobs = await _context.Jobs.Include(j => j.Company)
                                          .Include(j => j.RequiredSkills)
                                            .ThenInclude(rs => rs.Skill)
                                          .Select(j => new JobPosting(j))
                                          .ToListAsync();
            } else
            {
                string[] searchTerms = query.Split(" ");

                jobs = await _context.Jobs.Where(j => searchTerms.Any(j.JobTitle.ToLower().Contains)
                                                   || searchTerms.Any(j.Description.ToLower().Contains))
                                          .Include(j => j.Company)
                                          .Include(j => j.RequiredSkills)
                                            .ThenInclude(rs => rs.Skill)
                                          .Select(j => new JobPosting(j))
                                          .ToListAsync();
            }

            return Ok(jobs);
        }

       
    }
}


