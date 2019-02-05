using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHiredApi.Data;
using GitHiredApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            List<Job> jobs;

            if (query == null || query == "")
            {
                jobs = await _context.Jobs.Include(job => job.Company)
                                          .Include(job => job.RequiredSkills)
                                          .ToListAsync();
            } else
            {
                query = query.ToLower();

                jobs = await _context.Jobs.Where(j => j.JobTitle.ToLower().Contains(query)
                                                   || j.Description.ToLower().Contains(query))
                                          .Include(job => job.Company)
                                          .Include(job => job.RequiredSkills)
                                          .ToListAsync();
            }

            return Ok(new { jobs });

        }

       
    }
}


