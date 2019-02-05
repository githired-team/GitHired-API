using GitHiredApi.Models;
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
                     CompanyID = 1,
                     JobTitle = "Front-end Developer",
                     Description = "Solid understanding of Object Oriented Programming,Outstanding verbal and written communication skills",
                     Location = "Bellevue,WA",
                     WageRange = "5k monthly"

                 }

           );
        }

    
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<RequiredSkills> RequiredSkills { get; set; }
    
    }
}
