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
        public async void CanCreateHotel()
        {
            DbContextOptions<GitHiredApiDbContext> options = new DbContextOptionsBuilder<GitHiredApiDbContext>().UseInMemoryDatabase("GetCompany").Options;

            using (GitHiredApiDbContext context = new GitHiredApiDbContext(options))
            {
                // Arrange
                Company c1 = new Company();
                c1.ID = 1;
                c1.Name = "TestCo";
                c1.Website = "www.Testco.com";
                c1.Industry = "Testing";
                c1.Headline="tt";

                // Act
                GetCompanyInfoController _controller  = new GetCompanyInfoController(context);
               var res= await _controller.GetCompany(1);
                // var result = context.Companies.Where(h => h.ID == c1.ID);

                // Assert
                Assert.True(res.Value.ID == 1);
            }
        }
    }
}
