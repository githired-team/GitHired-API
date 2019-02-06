using GitHiredApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHiredApi.Helpers
{
    public class JobPosting
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string WageRange { get; set; }
        public string ApplicationUrl { get; set; }
        public List<string> Skillset { get; set; }

        public JobPosting (Job job)
        {
            ID = job.ID;
            CompanyID = job.CompanyID;

            if (job.Company != null)
            {
                CompanyName = job.Company.Name;
            }

            JobTitle = job.JobTitle;
            Description = job.Description;
            Location = job.Location;
            WageRange = job.WageRange;
            ApplicationUrl = job.ApplicationUrl;

            Skillset = new List<string>();

            if (job.RequiredSkills != null)
            {
                foreach(RequiredSkill skill in job.RequiredSkills)
                {
                    Skillset.Add(skill.Skill.SkillName);
                }
            }

        }

    }
}
