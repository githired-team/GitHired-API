using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitHiredApi.Models
{
    public class RequiredSkills
    {

        public skills skill { get; set; }

        public int JobID { get; set; }


        public enum skills
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


        //nav
        public Job job { get; set; }
    }
}
