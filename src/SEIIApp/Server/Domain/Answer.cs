using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class Answer
    {
        [Key]
        public int answerId { get; set; }
        public string answerText { get; set; }
        public Boolean correct { get; set; }
    }
}
