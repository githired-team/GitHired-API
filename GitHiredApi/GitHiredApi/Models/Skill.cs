using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHiredApi.Models
{
    public class Skill
    {
        public int ID { get; set; }
        public string SkillName { get; set; }

        // Navigation Properties
        public ICollection<RequiredSkill> RequiredSkills { get; set; }
    }
}
