using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class FinishedLesson
    {
        [Key]
        public int FinishedLessonId { get; set; }
        public int LessonId { get; set; }
        public DateTime FinishedDateTime { get; set; }
    }
}
