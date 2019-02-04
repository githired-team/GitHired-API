using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitHiredApi.Models
{
    public class RequiredSkills
    {

        public Skills Skill { get; set; }

        public int JobID { get; set; }

        //nav
        public Job Job { get; set; }
    }
    public enum Skills
    {
        [Display(Name = "c#")]
        cSharp,
        [Display(Name = "c++")]
        cPlusPlus,
        Java,
        Javascript,
        [Display(Name = "Unit Testing")]
        UnitTesting

    }
}
