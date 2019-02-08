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
    public class SkillsController : ControllerBase
    {
        private GitHiredApiDbContext _context;

        public SkillsController(GitHiredApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> SkillsData()
        {
            List<SkillCount> skillCounts = await _context.Skills.Include(s => s.RequiredSkills)
                                                         .Select(s => new SkillCount(s.RequiredSkills.Count, s.SkillName))
                                                         .ToListAsync();

            return Ok(new { skillCounts });
        }

        
    }
}



