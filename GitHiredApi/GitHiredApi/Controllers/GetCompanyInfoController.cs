using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHiredApi.Data;
using GitHiredApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GitHiredApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCompanyInfoController : ControllerBase
    {
        private GitHiredApiDbContext  _context;

        public GetCompanyInfoController(GitHiredApiDbContext context)
        {
            _context = context;
        }

        public async Task <ActionResult<IEnumerable<Company>>> GetCompanies()
        {
          var companies =await _context.Companies
                .Include(r => r.Jobs)
                .ToArrayAsync();
            foreach (var item in companies)
            {
                //item.Jobs = await _context.Jobs.Where(jo => jo.CompanyID == item.ID).ToArrayAsync();
                item.Jobs = item.Jobs.ToArray();

            }

            return Ok(new { results=companies });
        }

    

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company== null)
            {
                return NotFound();
            }

            return company;
        }


    }
}