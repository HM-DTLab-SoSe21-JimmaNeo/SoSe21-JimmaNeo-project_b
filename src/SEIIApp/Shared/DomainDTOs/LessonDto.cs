using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SEIIApp.Shared.DomainDTOs
{
    public class LessonDto
    {
        public int lessonId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<QuizDto> quizzes { get; set; }
        public List<LessonContenDto> contents { get; set; }

    }
}