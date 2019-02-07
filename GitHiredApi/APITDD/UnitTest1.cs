using System;
using Xunit;
using GitHiredApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using GitHiredApi.Models;
using GitHiredApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace APITDD
{
    
    public class UnitTest1
    {
        DbContextOptions<GitHiredApiDbContext> options = new DbContextOptionsBuilder<GitHiredApiDbContext>()
                                                                     .UseInMemoryDatabase(databaseName: "CanGetCompany").Options;
        //[Fact]
        //public async void CanGetCompany()
        //{
        //  using (GitHiredApiDbContext context = new GitHiredApiDbContext(options))
        //    {
        //        // Arrange
        //        Company c1 = new Company();
        //        c1.ID = 1;
        //        c1.Name = "TestCo";
        //        c1.Website = "www.Testco.com";
        //        c1.Industry = "Testing";
        //        c1.Headline = "tt";


        //        // Act
        //        context.Company.Add(c1);
        //        context.SaveChanges();

        //        var result = await context.Company.FirstAsync();

        //        Assert.Equal(1,result.ID);
        //    }

        //}

        //test GetCompanyInfocontroller's method--> GetCompany(int id)
             [Fact]
        public async void CanGetCompaniesByID()
        {

            using (GitHiredApiDbContext context = new GitHiredApiDbContext(options))
            {
                // Arrange
                Company c2 = new Company();
                c2.ID = 2;
                c2.Name = "TestCo";
                c2.Website = "www.Testco.com";
                c2.Industry = "Testing";
                c2.Headline = "tt";


                // Act
                context.Companies.Add(c2);
                context.SaveChanges();

                var _controller = new GetCompanyInfoController(context);

                var result = await _controller.GetCompany(2);

                Assert.True(result.Value.ID==2);
            }


        }

        //test GetCompanyInfoController's method-->GetCompany()

        [Fact]
        public async void CanGetAllCompanies()
        {

            using (GitHiredApiDbContext context = new GitHiredApiDbContext(options))
            {
                // Arrange
                Company c3 = new Company();
                c3.ID = 3;
                c3.Name = "GOGOGO";
                c3.Website = "www.GOGOGO.com";
                c3.Industry = "Testing";
                c3.Headline = "tt";


                Company c4= new Company();
                c4.ID = 4;
                c4.Name = "GOGO";
                c4.Website = "www.GOGO.com";
                c4.Industry = "Testing";
                c4.Headline = "tt";

                // Act
                context.Companies.Add(c3);
                context.SaveChanges();
                context.Companies.Add(c4);
                context.SaveChanges();

                var _controller = new GetCompanyInfoController(context);

            var result = await  _controller.GetCompanies() as OkObjectResult;

                Assert.Equal(200,result.StatusCode);
        
            }

        }


        //Getter -->Models-->Company-->ID
        [Fact]
        public void canGetCompanyId()
        {
            Company c1 = new Company();
            c1.ID = 1;
            Assert.True(c1.ID==1);
        }
        //setter -->Models-->Company-->ID
        [Fact]
        public void cansetCompanyId()
        {
            Company c1 = new Company();
            c1.ID = 1;
            c1.ID = 5;
            Assert.True(c1.ID == 5);
        }


        //Getter -->Models-->Company-->Name
        [Fact]
        public void canGetCompanyName()
        {
            Company c1 = new Company();
            c1.Name = "mini";
            Assert.True(c1.Name == "mini");
        }


        /// <summary>
        /// setter -->Models-->Company-->Name
        /// </summary>
        [Fact]
        public void cansetCompanyName()
        {
            Company c1 = new Company();
            c1.Name = "mini";
            c1.Name = "BIG";
            Assert.True(c1.Name =="BIG");
        }



        /// <summary>
        /// Getter -->Models-->Company-->Website
        /// </summary>
        [Fact]
        public void canGetCompanyWebsite()
        {
            Company c1 = new Company();
            c1.Website = "www.mini.com";
            Assert.True(c1.Website == "www.mini.com");
        }
        //setter -->Models-->Company-->Website
        [Fact]
        public void cansetCompanyWebsite()
        {
            Company c1 = new Company();
            c1.Website = "www.mini.com";
            c1.Website = "www.BIG.com";
            Assert.True(c1.Website == "www.BIG.com");
        }



        /// <summary>
        /// Getter -->Models-->Company-->Industry
        /// </summary>
        [Fact]
        public void canGetCompanyIndustry()
        {
            Company c1 = new Company();
            c1.Industry = "Test";
            Assert.True(c1.Industry == "Test");
        }
        /// <summary>
        /// setter -->Models-->Company-->Industry
        /// </summary>
        [Fact]
        public void cansetCompanyIndustry()
        {
            Company c1 = new Company();
            c1.Industry = "Test";
            c1.Industry= "Technology";
            Assert.True(c1.Industry== "Technology");
        }




        /// <summary>
        /// Getter -->Models-->Company-->Headline
        /// </summary>
        [Fact]
        public void canGetCompanyHeadline()
        {
            Company c1 = new Company();
            c1.Headline = "T";
            Assert.True(c1.Headline == "T");
        }

        /// <summary>
        ///  setter -->Models-->Company-->Headline
        /// </summary>

        [Fact]
        public void cansetCompanyHeadline()
        {
            Company c1 = new Company();
            c1.Headline = "T";
            c1.Headline = "e";
            Assert.True(c1.Headline == "e");
        }



        /// <summary>
        /// Getter -->Models-->Company-->can get jobs 
        /// </summary>

        [Fact]
       public void canGetJoblist()
        {
            List<Job> list = new List<Job>();
              Job j1 = new Job();
            j1.JobTitle = "Junior Dev";
            Job j2 = new Job();
            j2.JobTitle = "Senior web Dev";
            list.Add(j1);
            list.Add(j2);

            Company c1 = new Company();
            c1.Jobs = list;

            Assert.True(c1.Jobs.Count==2);

        }


        /// <summary>
        /// setter -->Models-->Company-->can get jobs 
        /// </summary>
        [Fact]
        public void cansetJoblist()
        {
            List<Job> list = new List<Job>();
            Job j1 = new Job();
            j1.JobTitle = "Junior Dev";
            Job j2 = new Job();
            j2.JobTitle = "Senior web Dev";
            list.Add(j1);
            list.Add(j2);

            Company c1 = new Company();
            c1.Jobs = list;
            list.RemoveAt(0);
            Assert.True(c1.Jobs.Count == 1);

        }



        /// <summary>
        /// Getter -->Models-->Job-->ID
        /// </summary>
        [Fact]
        public void canGetJobId()
        {
            Job j1 = new Job();
            j1.ID = 1;
            Assert.True(j1.ID == 1);
        }
        /// <summary>
        /// setter -->Models-->Job-->ID
        /// </summary>
        [Fact]
        public void cansetJobId()
        {
            Job j1 = new Job();
            j1.ID = 1;
            j1.ID = 5;
            Assert.True(j1.ID == 5);
        }


        /// <summary>
        /// Getter -->Models-->Job-->CompanyID
        /// </summary>
        [Fact]
        public void canGetJobcompanyId()
        {
            Job j1 = new Job();
            j1.CompanyID = 1;
            Assert.True(j1.CompanyID == 1);
        }

        /// <summary>
        /// setter -->Models-->Job-->CompanyID
        /// </summary>
        [Fact]
        public void cansetJobcompanyId()
        {
            Job j1 = new Job();
            j1.CompanyID = 1;
            j1.CompanyID = 5;
            Assert.True(j1.CompanyID == 5);
        }



        /// <summary>
        /// Getter -->Models-->Job-->Jobtitle
        /// </summary>
        [Fact]
        public void canGetJobTitle()
        {
            Job j1 = new Job();
            j1.JobTitle = "Junior Dev";
            Assert.True(j1.JobTitle =="Junior Dev" );
        }
        /// <summary>
        /// setter -->Models-->Job-->JobTitle
        /// </summary>
        [Fact]
        public void cansetJobTitle()
        {
            Job j1 = new Job();
            j1.JobTitle = "Junior Dev";
            j1.JobTitle = "senior Dev";
            Assert.True(j1.JobTitle == "senior Dev");
        }



        /// <summary>
        /// Getter -->Models-->Job-->Description
        /// </summary>
        [Fact]
        public void canGetJobDescription()
        {
            Job j1 = new Job();
            j1.Description = "good";
            Assert.True(j1.Description == "good");
        }


        /// <summary>
        /// setter -->Models-->Job-->Description
        /// </summary>
        [Fact]
        public void cansetJobDescription()
        {
            Job j1 = new Job();
            j1.Description = "good";
            j1.Description= "bravo";
            Assert.True(j1.Description == "bravo");
        }


        /// <summary>
        /// Getter -->Models-->Job-->Location
        /// </summary>
        [Fact]
        public void canGetJobLocation()
        {
            Job j1 = new Job();
            j1.Location = "seattle";
            Assert.True(j1.Location == "seattle");
        }

        /// <summary>
        /// setter -->Models-->Job-->Location
        /// </summary>
        [Fact]
        public void cansetJobLocation()
        {
            Job j1 = new Job();
            j1.Location = "seattle";
            j1.Location = "bellevue";
            Assert.True(j1.Location == "bellevue");
        }

        /// <summary>
        /// Getter -->Models-->Job-->WegRange
        /// </summary>
        [Fact]
        public void canGetJobWegRange()
        {
            Job j1 = new Job();
            j1.WageRange = "5k";
            Assert.True(j1.WageRange == "5k");
        }


        /// <summary>
        /// Setter -->Models-->Job-->WegRange
        /// </summary>
        [Fact]
        public void canSetJobWegRange()
        {
            Job j1 = new Job();
            j1.WageRange = "5k";
            j1.WageRange = "8k";
            Assert.True(j1.WageRange == "8k");
        }



        /// <summary>
        /// Getter -->Models-->Job-->Appurl
        /// </summary>
        [Fact]
        public void canGetJobAppUrl()
        {
            Job j1 = new Job();
            j1.ApplicationUrl = "www.jobapp.com";
            Assert.True(j1.ApplicationUrl == "www.jobapp.com");
        }

        /// <summary>
        /// Setter -->Models-->Job-->Appurl
        /// </summary>
        [Fact]
        public void canSetJobAppUrl()
        {
            Job j1 = new Job();
            j1.ApplicationUrl = "www.jobapp.com";
            j1.ApplicationUrl = "www.jobappSETTTTTT.com";
            Assert.True(j1.ApplicationUrl == "www.jobappSETTTTTT.com");
        }

        /// <summary>
        /// Getter -->Models-->Job-->company
        /// </summary>
        [Fact]
        public void canGetJobCompany()
        {
            Job j1 = new Job();
            j1.Company = new Company
            {   ID = 1,
                Name = "testco",
                Website = "",
                Industry="tech",
                Headline="t"
               
            };

            Assert.True(j1.Company.ID == 1);
        }

        /// <summary>
        /// Setter -->Models-->Job-->company
        /// </summary>
        [Fact]
        public void canSetJobCompany()
        {
            Job j1 = new Job();
            j1.Company = new Company
            {
                ID = 1,
                Name = "testco",
                Website = "",
                Industry = "tech",
                Headline = "t"

            };
            j1.Company.Name = "walmart";
            Assert.True(j1.Company.Name =="walmart");
        }



        /// <summary>
        /// Getter -->Models-->Job-->requiredskills
        /// </summary>
        [Fact]
        public void CangetJobRequiredSkills()
        {
            Job j1 = new Job();
            RequiredSkill r1 = new RequiredSkill();
            r1.SkillID = 1;
            RequiredSkill r2 = new RequiredSkill();
            r2.SkillID = 2;
            List<RequiredSkill> list = new List<RequiredSkill>();
            list.Add(r1);
            list.Add(r2);
            j1.RequiredSkills = list;
            Assert.True(j1.RequiredSkills.Contains(r1));
            Assert.True(j1.RequiredSkills.Contains(r2));
        }


        /// <summary>
        /// Setter -->Models-->Job-->requiredskills
        /// </summary>
        [Fact]
        public void CansetJobRequiredSkills()
        {
            Job j1 = new Job();
            RequiredSkill r1 = new RequiredSkill();
            r1.SkillID = 1;
            RequiredSkill r2 = new RequiredSkill();
            r2.SkillID = 2;
            List<RequiredSkill> list = new List<RequiredSkill>();
            list.Add(r1);
            list.Add(r2);
            j1.RequiredSkills = list;
            list.ToArray()[0].SkillID = 4;
            Assert.True(j1.RequiredSkills.ToArray()[0].SkillID==4);
              }

    }
}
