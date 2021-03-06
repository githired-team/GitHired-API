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
using GitHiredApi.Helpers;

namespace APITDD
{
    
    public class UnitTest1
    {


        /// <summary>
        /// test GetCompanyInfocontroller's method--> GetCompany(int id)
        /// </summary>
        [Fact]
        public async void CanGetCompaniesByID()
        {
            DbContextOptions<GitHiredApiDbContext> options = new DbContextOptionsBuilder<GitHiredApiDbContext>()
                                                                     .UseInMemoryDatabase(databaseName: "CanGetCompany").Options;
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

        /// <summary>
        /// test GetCompanyInfoController's method-->GetCompany()
        /// </summary>

        [Fact]
        public async void CanGetAllCompanies()
        {
            DbContextOptions<GitHiredApiDbContext> options = new DbContextOptionsBuilder<GitHiredApiDbContext>()
                                                                        .UseInMemoryDatabase(databaseName: "CanGetCompany").Options;

            using (GitHiredApiDbContext context1 = new GitHiredApiDbContext(options))
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
                context1.Companies.Add(c3);
                context1.SaveChanges();
                context1.Companies.Add(c4);
                context1.SaveChanges();

                var _controller = new GetCompanyInfoController(context1);

            var result = await  _controller.GetCompanies() as OkObjectResult;

                Assert.Equal(200,result.StatusCode);
        
            }

        }


        /// <summary>
        /// Getter -->Models-->Company-->ID
        /// </summary>
        [Fact]
        public void canGetCompanyId()
        {
            Company c1 = new Company();
            c1.ID = 1;
            Assert.True(c1.ID==1);
        }

        /// <summary>
        /// setter -->Models-->Company-->ID
        /// </summary>
        [Fact]
        public void cansetCompanyId()
        {
            Company c1 = new Company();
            c1.ID = 1;
            c1.ID = 5;
            Assert.True(c1.ID == 5);
        }


        /// <summary>
        /// Getter -->Models-->Company-->Name
        /// </summary>
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
        /// <summary>
        /// setter -->Models-->Company-->Website
        /// </summary>
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

        /// <summary>
        /// Getter-->RequiredSkill-->skillID
        /// </summary>

        [Fact]
        public void canGetRequiredSkillSkillID()
        {
            RequiredSkill r1 = new RequiredSkill();
           r1.SkillID = 1;
            Assert.True(r1.SkillID == 1);
        }
        /// <summary>
        /// Setter-->RequiredSkill-->skillID
        /// </summary>
        [Fact]
        public void cansetRequiredSkillSkillID()
        {
            RequiredSkill r1 = new RequiredSkill();
            r1.SkillID = 1;
            r1.SkillID = 4;
            Assert.True(r1.SkillID == 4);
        }

        /// <summary>
        /// Getter-->RequiredSkill-->JobID
        /// </summary>
        [Fact]
        public void canGetRequiredSkillJobID()
        {
            RequiredSkill r1 = new RequiredSkill();
            r1.JobID = 1;
            Assert.True(r1.JobID == 1);
        }

        /// <summary>
        /// Setter-->RequiredSkill-->JobID
        /// </summary>
        [Fact]
        public void canSetRequiredSkillJobID()
        {
            RequiredSkill r1 = new RequiredSkill();
            r1.JobID = 1;
            r1.JobID = 11;
            Assert.True(r1.JobID == 11);
        }




        /// <summary>
        /// Getter-->RequiredSkill-->Job
        /// </summary>
        [Fact]
        public void canGetRequiredSkillJob()
        {
            RequiredSkill r1 = new RequiredSkill();
            Job job = new Job();
            job.JobTitle = "QA tester";
            r1.Job = job;
            Assert.True(job.JobTitle == "QA tester");
        }

        /// <summary>
        /// Setter-->RequiredSkill-->Job
        /// </summary>
        [Fact]
        public void canSetRequiredSkillJob()
        {
            RequiredSkill r1 = new RequiredSkill();
            Job job = new Job();
            job.JobTitle = "QA tester";
            r1.Job = job;
            r1.Job.JobTitle = "Jr Dev";

            Assert.True(job.JobTitle == "Jr Dev");
        }


        /// <summary>
        /// Getter-->RequiredSkill-->skill
        /// </summary>

        [Fact]
        public void canGetRequiredSkill()
        {
            RequiredSkill r1 = new RequiredSkill();
            Skill s = new Skill();
            s.SkillName = "Java";
            r1.Skill =s;
            Assert.True(r1.Skill.SkillName == "Java");
        }
        /// <summary>
        /// Setter-->RequiredSkill-->skill
        /// </summary>
        [Fact]
        public void canSetRequiredSkill()
        {
            RequiredSkill r1 = new RequiredSkill();
            Skill s = new Skill();
            s.SkillName = "Java";
            r1.Skill = s;
            r1.Skill.SkillName = "c#";
            Assert.True(r1.Skill.SkillName == "c#");
        }



        /// <summary>
        /// Getter-->Model-->skill-->ID
        /// </summary>
        [Fact]
        public void CangetSkillID()
        {
            Skill s = new Skill();
            s.ID = 1;
            Assert.True(s.ID == 1);
        }

        /// <summary>
        /// Setter-->Model-->skill-->ID
        /// </summary>
        [Fact]
        public void CanSetSkillID()
        {
            Skill s = new Skill();
            s.ID = 1;
            s.ID = 13;
            Assert.True(s.ID == 13);
        }

        /// <summary>
        /// Getter-->Model-->Skill-->SkillName
        /// </summary>
        [Fact]
        public void CanGetSkillName()
        {
            Skill s = new Skill();
            s.SkillName = "Java";
            Assert.True(s.SkillName == "Java");
        }


        /// <summary>
        /// Setter-->Model-->Skill-->SkillName
        /// </summary>
        [Fact]
        public void CanSetSkillName()
        {
            Skill s = new Skill();
            s.SkillName = "Java";
            s.SkillName = ".Net";
            Assert.True(s.SkillName == ".Net");
        }


        /// <summary>
        ///Getter-->Model-->Skill-->RequredSkills
        /// </summary>
         [Fact]
        public void SkillCanGetRequredSkill()
        {
            Skill s = new Skill();
            List<RequiredSkill> list = new List<RequiredSkill>();
            RequiredSkill r1 = new RequiredSkill();
            r1.SkillID = 1;
            RequiredSkill r2 = new RequiredSkill();
            r2.SkillID = 2;
            list.Add(r1);
            list.Add(r2);
            s.RequiredSkills = list;

            Assert.True(s.RequiredSkills.Count == 2);
        }

        /// <summary>
        /// Setter-->Model-->Skill-->RequredSkills
        /// </summary>
        [Fact]
        public void SkillCanSetRequredSkill()
        {
            Skill s = new Skill();
            List<RequiredSkill> list = new List<RequiredSkill>();
            RequiredSkill r1 = new RequiredSkill();
            r1.SkillID = 1;
            RequiredSkill r2 = new RequiredSkill();
            r2.SkillID = 2;
            list.Add(r1);
            list.Add(r2);
            s.RequiredSkills = list;
            s.RequiredSkills.Add(new RequiredSkill {
            SkillID=3,}
                );
            Assert.True(s.RequiredSkills.Count == 3);
        }

        /// <summary>
        /// Test-->Controller-->GetJobsController-->Search(string query)
        /// </summary>
        [Fact]
        public async void canSearchQuery()
        {
            DbContextOptions<GitHiredApiDbContext> options = new DbContextOptionsBuilder<GitHiredApiDbContext>()
                                                                        .UseInMemoryDatabase(databaseName: "Cangetjobs").Options;
            using (GitHiredApiDbContext context3 = new GitHiredApiDbContext(options))
            {
                //Arrange
                Company co = new Company();
                co.Name = "cocacola";
                Job job1 = new Job();
                job1.ID = 1;
                // List<RequiredSkill> list1 = new List<RequiredSkill>();
                Skill s1 = new Skill();
                s1.SkillName = "Javatest";
                Skill s2 = new Skill();
                s2.SkillName = "C#test";
                RequiredSkill rr1 = new RequiredSkill();
                rr1.Skill = s1;
                RequiredSkill rr2 = new RequiredSkill();
                rr2.Skill= s2;
               // list1.Add(rr1);
               // list1.Add(rr2);
               context3.Companies.Add(co);
                context3.SaveChanges();
                context3.Jobs.Add(job1);
                context3.SaveChanges();
                context3.Skills.Add(s1);
                context3.SaveChanges();
                context3.Skills.Add(s2);
                context3.SaveChanges();
                context3.RequiredSkills.Add(rr1);
                context3.SaveChanges();
                context3.RequiredSkills.Add(rr2);
                context3.SaveChanges();
                             
                var _controller = new GetJobsController(context3);
                var result = await _controller.Search("cocacola") as OkObjectResult;
                Assert.Equal(200, result.StatusCode);

            }
        }


        /// <summary>
        /// Test-->Controller-->SkillsController-->SkillsData()
        /// </summary>
        [Fact]
        public async  void cangetSkillsData()
        {
            DbContextOptions<GitHiredApiDbContext> options = new DbContextOptionsBuilder<GitHiredApiDbContext>()
                                                                     .UseInMemoryDatabase(databaseName: "CanGetCompany").Options;
            using (GitHiredApiDbContext context2 = new GitHiredApiDbContext(options))
            {

                //Ararnge
                Job j1 = new Job();
                j1.ID = 1;
                j1.JobTitle = "Jr Dev";
                Skill skill1 = new Skill();
                skill1.ID = 1;
                skill1.SkillName = "aspNetCore";
                Skill skill2 = new Skill();
                skill2.ID = 2;
                skill2.SkillName = "c++";
                RequiredSkill rs1 = new RequiredSkill();
                rs1.Skill = skill1;
                RequiredSkill rs2 = new RequiredSkill();
                rs2.Skill = skill2;

                context2.Jobs.Add(j1);
                context2.SaveChanges();
                context2.Skills.Add(skill1);
                context2.SaveChanges();
                context2.Skills.Add(skill2);
                context2.SaveChanges();
                context2.RequiredSkills.Add(rs1);
                context2.SaveChanges();
                context2.RequiredSkills.Add(rs2);
                context2.SaveChanges();

                var _controller = new SkillsController(context2);
                var result = await _controller.SkillsData() as OkObjectResult;
                Assert.Equal(200, result.StatusCode);
            }

        }

        /// <summary>
        /// Test-->HElper-->skillcount-->Getter-->count
        /// </summary>
        [Fact]
        public void GetskillCount()
        {
            SkillCount sc = new SkillCount();
            sc.count = 2;
            Assert.Equal(2, sc.count);

        }

        /// <summary>
        /// Test-->HElper-->skillcount-->Setter-->count
        /// </summary>

        [Fact]
        public void SetskillCount()
        {
            SkillCount sc = new SkillCount();
            sc.count = 2;
            sc.count = 3;
            Assert.Equal(3, sc.count);

        }
        /// <summary>
        /// Test-->HElper-->skillcount-->Getter-->Name
        /// </summary>
        [Fact]
        public void GetskillName()
        {
            SkillCount sc = new SkillCount();
            sc.name = ".net";
            Assert.Equal(".net", sc.name);

        }


        /// <summary>
        /// Test-->HElper-->skillcount-->Setter-->Name
        /// </summary>
        [Fact]
        public void setskillName()
        {
            SkillCount sc = new SkillCount();
            sc.name = ".net";
            sc.name = "js";
            Assert.Equal("js", sc.name);

        }


        /// <summary>
        /// Test-->HElper-->Jobposting-->Getter
        /// </summary>

        [Fact]
        public void GetJoblisting()
        {
            Job newjob = new Job();
         RequiredSkill rq  = new RequiredSkill();
            RequiredSkill rq2 = new RequiredSkill();
            rq.Skill = new Skill();
            rq.Skill.SkillName = "java";
            rq2.Skill = new Skill();
            rq2.Skill.SkillName = "c++";
            List<RequiredSkill> list = new List<RequiredSkill>();
            list.Add(rq);
            list.Add(rq2);
            newjob.RequiredSkills = list;
            JobPosting jp = new JobPosting(newjob);
           
            Assert.Equal("java", jp.Skillset[0]);
            Assert.Equal("c++", jp.Skillset[1]);


        }
        /// <summary>
        /// setter-->jobposting
        /// </summary>
        [Fact]
        public void setJoblisting()
        {
            Job newjob = new Job();
            RequiredSkill rq = new RequiredSkill();
            RequiredSkill rq2 = new RequiredSkill();
            rq.Skill = new Skill();
            rq.Skill.SkillName = "java";
            rq2.Skill = new Skill();
            rq2.Skill.SkillName = "c++";
            List<RequiredSkill> list = new List<RequiredSkill>();
            list.Add(rq);
            list.Add(rq2);
            newjob.RequiredSkills = list;
            JobPosting jp = new JobPosting(newjob);
            jp.Skillset[0] = "sqlserver";
            Assert.Equal("sqlserver", jp.Skillset[0]);


        }

    }
}
