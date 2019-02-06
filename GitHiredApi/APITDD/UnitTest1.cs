using System;
using Xunit;
using GitHiredApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using GitHiredApi.Models;
using GitHiredApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APITDD
{
    
    public class UnitTest1
    {

        [Fact]
        public async void CanGetCompany()
        {
            DbContextOptions<GitHiredApiDbContext> options = new DbContextOptionsBuilder<GitHiredApiDbContext>()
                                                                    .UseInMemoryDatabase(databaseName: "CanGetCompany").Options;

            using (GitHiredApiDbContext context = new GitHiredApiDbContext(options))
            {
                // Arrange
                Company c1 = new Company();
                c1.ID = 1;
                c1.Name = "TestCo";
                c1.Website = "www.Testco.com";
                c1.Industry = "Testing";
                c1.Headline = "tt";


                // Act
                context.Companies.Add(c1);
                context.SaveChanges();

                var result = await context.Companies.FirstOrDefaultAsync();

                Assert.True(result.ID == 1);
            }
        }
    }
}
