using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared.DomainDTOs
{
    public class QuizDto
    {
        public int quizId { get; set; }
        public string title { get; set; }

        public List<QuestionDto> questions { get; set; }
    }
}
