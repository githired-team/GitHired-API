using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHiredApi.Models
{ 
    public class Job
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string WageRange { get; set; }

        //navi
        public Company Company { get; set; }
        public ICollection<RequiredSkills> RequiredSkills { get; set; }

    }
}
