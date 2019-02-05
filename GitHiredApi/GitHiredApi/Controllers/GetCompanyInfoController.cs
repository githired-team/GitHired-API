using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHiredApi.Data;
using GitHiredApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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


        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult> GetCompanies()
        {
            List<Company> companies = await _context.Companies
                  .ToListAsync();

            //foreach (var item in companies)
            //{
            //    item.Jobs = await _context.Jobs.Where(jo => jo.CompanyID == item.ID).ToListAsync();

            //}


            return Ok (new { companies });

        }



        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task <ActionResult> GetCompany(int id)
        {
            var company = await _context.Jobs.Where(jo => jo.CompanyID == id).ToListAsync();

                
            if (company== null)
            {
                return NotFound();
            }

            return Ok(new { company });
        }


    }
}