﻿// <auto-generated />
using GitHiredApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GitHiredApi.Migrations
{
    [DbContext(typeof(GitHiredApiDbContext))]
    partial class GitHiredApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GitHiredApi.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Headline");

                    b.Property<string>("Industry");

                    b.Property<string>("Name");

                    b.Property<string>("Website");

                    b.HasKey("ID");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Headline = "a",
                            Industry = "Real Estate",
                            Name = "Redfin",
                            Website = "www.Redfin.com"
                        },
                        new
                        {
                            ID = 2,
                            Headline = "b",
                            Industry = "Technology",
                            Name = "Microsoft",
                            Website = "www.Microsoft.com"
                        },
                        new
                        {
                            ID = 3,
                            Headline = "c",
                            Industry = "e-commerce Market",
                            Name = "Groupon",
                            Website = "www.Groupon.com"
                        });
                });

            modelBuilder.Entity("GitHiredApi.Models.Job", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyID");

                    b.Property<string>("Description");

                    b.Property<string>("JobTitle");

                    b.Property<string>("Location");

                    b.Property<string>("WageRange");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CompanyID = 1,
                            Description = " Solid understanding of Object Oriented Programming",
                            JobTitle = "Java Developer",
                            Location = "Kirkland,WA",
                            WageRange = "8k monthly"
                        },
                        new
                        {
                            ID = 2,
                            CompanyID = 1,
                            Description = "Solid understanding of Object Oriented Programming,Outstanding verbal and written communication skills",
                            JobTitle = "Front-end Developer",
                            Location = "Bellevue,WA",
                            WageRange = "5k monthly"
                        },
                        new
                        {
                            ID = 3,
                            CompanyID = 2,
                            Description = "Solid understanding of Object Oriented Programming,Outstanding verbal and written communication skills",
                            JobTitle = "Front-end Developer",
                            Location = "Bellevue,WA",
                            WageRange = "5k monthly"
                        });
                });

            modelBuilder.Entity("GitHiredApi.Models.RequiredSkills", b =>
                {
                    b.Property<int>("Skill");

                    b.Property<int>("JobID");

                    b.HasKey("Skill", "JobID");

                    b.HasIndex("JobID");

                    b.ToTable("RequiredSkills");

                    b.HasData(
                        new
                        {
                            Skill = 2,
                            JobID = 1
                        },
                        new
                        {
                            Skill = 4,
                            JobID = 2
                        },
                        new
                        {
                            Skill = 1,
                            JobID = 2
                        });
                });

            modelBuilder.Entity("GitHiredApi.Models.Job", b =>
                {
                    b.HasOne("GitHiredApi.Models.Company", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GitHiredApi.Models.RequiredSkills", b =>
                {
                    b.HasOne("GitHiredApi.Models.Job", "Job")
                        .WithMany("RequiredSkills")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
