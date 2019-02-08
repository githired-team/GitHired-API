﻿using System.Collections.Generic;
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


        /// <summary>
        /// Takes in a search query and returns an object containing a list of all jobs whose title or description
        ///contains the given query string.
         /// If no query string is provided, or the query string is empty, data for all jobs in our database 
         ///  is returned.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Search(string query)
        {
            List<JobPosting> jobs;

            if (query == null || query == "")
            {
                jobs = await _context.Jobs.Include("Company")
                                          .Include("RequiredSkills.Skill")
                                          .Select(j => new JobPosting(j))
                                          .ToListAsync();
            } else
            {
                query = query.ToLower();

                jobs = await _context.Jobs.Where(j => j.JobTitle.ToLower().Contains(query)
                                                   || j.Description.ToLower().Contains(query))
                                           .Include("Company")
                                           .Include("RequiredSkills.Skill")
                                           .Select(j => new JobPosting(j))
                                           .ToListAsync();
            }

            return Ok(new { jobs, query });
        }

       
    }
}


