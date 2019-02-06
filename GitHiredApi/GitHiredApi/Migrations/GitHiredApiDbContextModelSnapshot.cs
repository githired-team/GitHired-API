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

                    b.Property<string>("ApplicationUrl");

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
                            ApplicationUrl = "www.TechCompanyThatShouldTotallyHireRick.com/BestEverJobs/Apply",
                            CompanyID = 1,
                            Description = " Solid understanding of Object Oriented Programming and some other stuff, experience with SQL",
                            JobTitle = "C# Back-End Developer",
                            Location = "Kirkland,WA",
                            WageRange = "8k monthly"
                        },
                        new
                        {
                            ID = 2,
                            ApplicationUrl = "www.RickSuxNeverHireHim.com/IfIWorkedOnFrontEnd",
                            CompanyID = 1,
                            Description = "1+ years of experience with React.js. Gotta be a cool cat and like other cool cats, and CSS.",
                            JobTitle = "Front-end Developer",
                            Location = "Bellevue,WA",
                            WageRange = "5k monthly"
                        },
                        new
                        {
                            ID = 3,
                            ApplicationUrl = "www.WayCoolerThanYourTechCompany.com/N00bCrushers/apply",
                            CompanyID = 2,
                            Description = "Solid understanding of Object Oriented Programming principles, 4000+ years of experience with latest frameworks. GIANT ROBOT BODY a must. Lazer eyes a plus!!",
                            JobTitle = "GIGASENIOR MECHA-DEVELOPER",
                            Location = "Secret Lunar Base, WV",
                            WageRange = "5-6 Xolthar-Class Power Crystals/Month, DOE"
                        });
                });

            modelBuilder.Entity("GitHiredApi.Models.RequiredSkill", b =>
                {
                    b.Property<int>("SkillID");

                    b.Property<int>("JobID");

                    b.HasKey("SkillID", "JobID");

                    b.HasIndex("JobID");

                    b.ToTable("RequiredSkills");

                    b.HasData(
                        new
                        {
                            SkillID = 4,
                            JobID = 3
                        },
                        new
                        {
                            SkillID = 7,
                            JobID = 2
                        },
                        new
                        {
                            SkillID = 2,
                            JobID = 1
                        },
                        new
                        {
                            SkillID = 6,
                            JobID = 1
                        });
                });

            modelBuilder.Entity("GitHiredApi.Models.Skill", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SkillName");

                    b.HasKey("ID");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            SkillName = "Java"
                        },
                        new
                        {
                            ID = 2,
                            SkillName = "C#"
                        },
                        new
                        {
                            ID = 3,
                            SkillName = "C++"
                        },
                        new
                        {
                            ID = 4,
                            SkillName = "React.js"
                        },
                        new
                        {
                            ID = 5,
                            SkillName = "JavaScript"
                        },
                        new
                        {
                            ID = 6,
                            SkillName = "SQL"
                        },
                        new
                        {
                            ID = 7,
                            SkillName = "CSS"
                        },
                        new
                        {
                            ID = 8,
                            SkillName = "Project Management"
                        });
                });

            modelBuilder.Entity("GitHiredApi.Models.Job", b =>
                {
                    b.HasOne("GitHiredApi.Models.Company", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GitHiredApi.Models.RequiredSkill", b =>
                {
                    b.HasOne("GitHiredApi.Models.Job", "Job")
                        .WithMany("RequiredSkills")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GitHiredApi.Models.Skill", "Skill")
                        .WithMany("RequiredSkills")
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
