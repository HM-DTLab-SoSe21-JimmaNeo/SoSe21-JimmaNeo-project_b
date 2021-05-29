using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared.DomainDTOs
{
    public class StudentProfileDto
    {
        public int StudentProfileId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Experience { get; set; }
    }
}
