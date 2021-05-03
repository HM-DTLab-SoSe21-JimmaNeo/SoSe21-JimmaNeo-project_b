using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SEIIApp.Shared.DomainDTOs
{
    public class CourseDto
    {
        public int courseId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<LessonDto> lessons { get; set; }

    }
}