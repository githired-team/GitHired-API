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
            modelBuilder.Entity<RequiredSkill>().HasKey(ce => new { ce.SkillID, ce.JobID });
            modelBuilder.Entity<Company>().HasData(
                
                
                new Company
                {   ID=1,
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

                  });


            modelBuilder.Entity<Job>().HasData(

                new Job
                {
                    ID = 1,
                    CompanyID = 1,
                    JobTitle = "C# Back-End Developer",
                    Description = " Solid understanding of Object Oriented Programming and some other stuff, experience with SQL",
                    Location = "Kirkland,WA",
                    WageRange = "8k monthly",
                    ApplicationUrl = "www.TechCompanyThatShouldTotallyHireRick.com/BestEverJobs/Apply"

                },
                new Job
                {
                    ID = 2,
                    CompanyID = 1,
                    JobTitle = "Front-end Developer",
                    Description = "1+ years of experience with React.js. Gotta be a cool cat and like other cool cats, and CSS.",
                    Location = "Bellevue,WA",
                    WageRange = "5k monthly",
                    ApplicationUrl = "www.RickSuxNeverHireHim.com/IfIWorkedOnFrontEnd"

                },
                 new Job
                 {
                     ID = 3,
                     CompanyID = 2,
                     JobTitle = "GIGASENIOR MECHA-DEVELOPER",
                     Description = "Solid understanding of Object Oriented Programming principles, 4000+ years of experience with latest frameworks. GIANT ROBOT BODY a must. Lazer eyes a plus!!",
                     Location = "Secret Lunar Base, WV",
                     WageRange = "5-6 Xolthar-Class Power Crystals/Month, DOE",
                     ApplicationUrl = "www.WayCoolerThanYourTechCompany.com/N00bCrushers/apply"

                 },
                 new Job
                 {
                     ID = 4,
                     CompanyID = 2,
                     JobTitle = "CSS Master",
                     Description = "Be able to CSS a website like a dog show groomer",
                     Location = "Seattle,WA",
                     WageRange = "2k monthly",
                     ApplicationUrl = "www.AmazeCats.com/CatsAmazingOnFrontEnd"

                 },
                 new Job
                 {
                     ID = 5,
                     CompanyID = 3,
                     JobTitle = "Java Expert",
                     Description = "30+ years of experience with Java",
                     Location = "Spokane,WA",
                     WageRange = "15k monthly",
                     ApplicationUrl = "www.hto.com/bob"

                 },
                 new Job
                 {
                     ID = 6,
                     CompanyID = 3,
                     JobTitle = "Javascript Guru",
                     Description = "1+ years of experience with React.js. Gotta be a cool cat and like other cool cats, and CSS.",
                     Location = "Tacoma,WA",
                     WageRange = "5k monthly",
                     ApplicationUrl = "www.Something.com/Funny"

                 },
                 new Job
                 {
                     ID = 7,
                     CompanyID = 2,
                     JobTitle = "C# Know-It-All",
                     Description = "11+ years of experience with C#. Must LOVE cats!!!",
                     Location = "Mercer Island,WA",
                     WageRange = "50k monthly",
                     ApplicationUrl = "www.Cool.com/Cats"

                 },
                 new Job
                 {
                     ID = 8,
                     CompanyID = 3,
                     JobTitle = "C# Intern",
                     Description = "No years of experience with C#.",
                     Location = "Kent,WA",
                     WageRange = "1k monthly",
                     ApplicationUrl = "www.Banana.com/Slug"

                 },
                 new Job
                 {
                     ID = 9,
                     CompanyID = 2,
                     JobTitle = "Python Wrangler",
                     Description = "1+ years of experience with React.js. Gotta be a cool cat and like other cool cats, and CSS.",
                     Location = "Renton,WA",
                     WageRange = "5k monthly",
                     ApplicationUrl = "www.NotSnakes.com/Python code"

                 },
                 new Job
                 {
                     ID = 10,
                     CompanyID = 1,
                     JobTitle = "Ruby on Rails Cross Continent",
                     Description = "13+ years of experience with Ruby and not the jewlery type.",
                     Location = "Shoreline,WA",
                     WageRange = "5k monthly",
                     ApplicationUrl = "www.OMG.com/NotDiamonds"

                 }
                 );

            modelBuilder.Entity<Skill>().HasData(
                new Skill
                {
                    ID = 1,
                    SkillName = "Java"
                },
                new Skill
                {
                    ID = 2,
                    SkillName = "C#"
                },
                new Skill
                {
                    ID = 3,
                    SkillName = "C++"
                },
                new Skill
                {
                    ID = 4,
                    SkillName = "React.js"
                },
                new Skill
                {
                    ID = 5,
                    SkillName = "JavaScript"
                },
                new Skill
                {
                    ID = 6,
                    SkillName = "SQL"
                },
                new Skill
                {
                    ID = 7,
                    SkillName = "CSS"
                },
                new Skill
                {
                    ID = 8,
                    SkillName = "Project Management"
                });

            modelBuilder.Entity<RequiredSkill>().HasData(
                new RequiredSkill
                {
                    SkillID = 4,
                    JobID = 3
                },
                new RequiredSkill
                {
                    SkillID = 7,
                    JobID = 2
                },
                new RequiredSkill
                {
                    SkillID = 2,
                    JobID = 1
                },
                new RequiredSkill
                {
                    SkillID = 6,
                    JobID= 1
                },
                new RequiredSkill
                {
                    SkillID = 6,
                    JobID = 2
                });
        }
      
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<RequiredSkill> RequiredSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
    
    }
}
