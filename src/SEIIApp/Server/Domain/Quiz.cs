using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set;  }
    }
}
