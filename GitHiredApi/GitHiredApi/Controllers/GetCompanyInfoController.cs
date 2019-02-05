using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHiredApi.Data;
using GitHiredApi.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IEnumerable<Company> GetCompaniess()
        {
            return _context.Companies.ToList();
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