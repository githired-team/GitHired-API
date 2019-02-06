using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHiredApi.Helpers
{
    // Struct that stores the name of a Skill, and the number of times it has appeared in job postings.
    public struct SkillCount
    {
        public int count;
        public string name;

        public SkillCount (int ct, string skillName)
        {
            count = ct;
            name = skillName;
        }
    }
}
