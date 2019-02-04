using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHiredApi.Models;
using Microsoft.AspNetCore.Mvc;

 //using GitHiredApi.Data;

namespace GitHiredApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetJobsController : ControllerBase
    {
        //private GitHiredApiDbContext _context;

        //public GetJobsController(GitHiredApiDbContext context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        public ActionResult<IEnumerable<JobPosting>> Jobs()
        {
            Job sampleJob = new Job();
            sampleJob.ID = 100;
            sampleJob.JobTitle = "Software Dev";
            sampleJob.CompanyID = 100;
            sampleJob.Description = "Literally ur dream jopb plus free puppies every day";
            sampleJob.Location = "Antarctica";
            sampleJob.WageRange = "$0 to $1 yearly salary, DOE";

            string[] sampleSkills = new string[] { "C#", ".NET Core", "Building APIs" };

            JobPosting samplePosting = new JobPosting(sampleJob, sampleSkills);

            JobsResponse sampleResponse = new JobsResponse(new JobPosting[] { samplePosting });


            return Ok(sampleResponse);
        }

    }
}
