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


        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<RequiredSkills> RequiredSkills { get; set; }
    
    }
}
