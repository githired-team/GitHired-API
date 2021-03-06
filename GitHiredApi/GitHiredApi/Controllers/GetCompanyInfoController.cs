﻿using System.Collections.Generic;
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
        private GitHiredApiDbContext _context;

        public GetCompanyInfoController(GitHiredApiDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// get all companies from the database return a company list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetCompanies()
        {
            List<Company> companies = await _context.Companies.Include(r => r.Jobs)
                                                              .ToListAsync();
            return  Ok(companies);

        }




        /// <summary>
        /// pass in an id to query the sepcific company in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task <ActionResult<Company>> GetCompany(int id)
        {


            Company company = await _context.Companies.Where(c => c.ID == id)
                                                      .Include(c => c.Jobs)
                                                      .FirstOrDefaultAsync();
            if (company == null)

            {
                return NotFound();
            }

            return  company ;
        }


    }
}