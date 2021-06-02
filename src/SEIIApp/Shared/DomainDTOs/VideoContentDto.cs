using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared.DomainDTOs
{
    public class VideoContentDto
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public Uri Location { get; set; }
    }
}
