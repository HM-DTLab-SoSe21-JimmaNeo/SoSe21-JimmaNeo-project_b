using System.Collections.Generic;

namespace SEIIApp.Shared.DomainDTOs
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<LessonDto> Lessons { get; set; }
    }
}