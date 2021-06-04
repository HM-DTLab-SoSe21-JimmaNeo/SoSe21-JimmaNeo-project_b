using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class FinishedQuiz
    {
        [Key]
        public int FinishedQuizId { get; set; }
        public int QuizId { get; set; }
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public DateTime FinishedDateTime {get; set; }
    }
}
