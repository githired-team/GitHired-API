using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHiredApi.Models
{
    public class Company
    {
        public int ID { get; set; }

        //title=companyName
        public string Title { get; set; }
        public string Website { get; set; }
        public string Industry { get; set; }
        public string Headline { get; set; }
        
        //Navi
        public ICollection<Job> Jobs { get; set; }
    }
}
