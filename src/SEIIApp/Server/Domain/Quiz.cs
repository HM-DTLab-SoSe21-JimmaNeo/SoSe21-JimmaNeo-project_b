using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class Quiz
    {
        [Key]
        public int quizId { get; set; }
        public string title { get; set; }

        public List<Question> questions { get; set;  }
    }
}
