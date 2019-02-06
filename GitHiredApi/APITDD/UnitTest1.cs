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

               var result= await _controller.GetCompany(2);

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

              var result = await _controller.GetCompanies();

                Assert.Equal(3,result.Value.Count);
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






    }
}
