using System.Collections.Generic;

namespace SEIIApp.Shared.DomainDTOs
{
    public class LessonDto
    {
        public int LessonId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<QuizDto> Quizzes { get; set; }
        public List<LessonContenDto> Contents { get; set; }
    }
}