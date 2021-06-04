using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class FinishedCourse
    {
        [Key]
        public int FinishedCourseId { get; set; }
        public int CourseId { get; set; }
        public DateTime FinishedDateTime { get; set; }
    }
}
