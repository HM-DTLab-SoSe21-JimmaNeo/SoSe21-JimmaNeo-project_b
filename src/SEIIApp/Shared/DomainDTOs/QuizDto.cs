using System.Collections.Generic;

namespace SEIIApp.Shared.DomainDTOs
{
    public class QuizDto
    {
        public int QuizId { get; set; }
        public string Title { get; set; }

        public List<QuestionDto> Questions { get; set; }
    }
}
