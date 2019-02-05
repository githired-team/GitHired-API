﻿using GitHiredApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHiredApi.Data
{
    public class GitHiredApiDbContext : DbContext
    {
        public GitHiredApiDbContext(DbContextOptions<GitHiredApiDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequiredSkills>().HasKey(ce => new { ce.Skill, ce.JobID });
            modelBuilder.Entity<Company>().HasData(
                
                
                new Company
                { ID=1,
                  Name="Redfin",
                  Website="www.Redfin.com",

                  Industry="Real Estate",
                  Headline="a"

                },
                 new Company
                 {
                     ID = 2,
                     Name = "Microsoft",
                     Website = "www.Microsoft.com",
                     Industry = "Technology",
                     Headline = "b"

                 },
                  new Company
                  {
                      ID = 3,
                      Name = "Groupon",
                      Website = "www.Groupon.com",
                      Industry = "e-commerce Market",
                      Headline = "c"

                  }


                  Industry="a",
                  Headline="b"
                }
              

                );


            modelBuilder.Entity<Job>().HasData(

                new Job
                {
                    ID = 1,
                    CompanyID = 1,
                    JobTitle = "Java Developer",
                    Description = " Solid understanding of Object Oriented Programming",
                    Location = "Kirkland,WA",
                    WageRange = "8k monthly"

                },
                new Job
                {
                    ID = 2,
                    CompanyID = 1,
                    JobTitle = "Front-end Developer",
                    Description = "Solid understanding of Object Oriented Programming,Outstanding verbal and written communication skills",
                    Location = "Bellevue,WA",
                    WageRange = "5k monthly"

                },
                 new Job
                 {
                     ID = 3,
                     CompanyID = 2,
                     JobTitle = "Front-end Developer",
                     Description = "Solid understanding of Object Oriented Programming,Outstanding verbal and written communication skills",
                     Location = "Bellevue,WA",
                     WageRange = "5k monthly"

                 });

            modelBuilder.Entity<RequiredSkills>().HasData(
                new RequiredSkills
                {
                    Skill = Skills.Java,
                    JobID = 1
                },
                new RequiredSkills
                {
                    Skill = Skills.UnitTesting,
                    JobID = 2
                },
                new RequiredSkills
                {
                    Skill = Skills.cPlusPlus,
                    JobID = 2
                }
                );
        }

    
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<RequiredSkills> RequiredSkills { get; set; }
    
    }
}
